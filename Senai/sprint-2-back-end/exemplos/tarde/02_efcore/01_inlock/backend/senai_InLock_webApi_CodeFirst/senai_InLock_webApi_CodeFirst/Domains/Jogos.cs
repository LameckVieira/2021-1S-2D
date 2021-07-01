using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_InLock_webApi_CodeFirst.Domains
{
    [Table("Jogos")]
    public class Jogos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idJogo { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string nomeJogo { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do jogo é obrigatória!")]
        public string descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória!")]
        public DateTime dataLancamento { get; set; }

        // Define o nome da coluna e o tipo de dado
        [Column("Preco", TypeName = "DECIMAL (18,2)")]
        [Required(ErrorMessage = "O preço do jogo deve ser informado!")]
        public decimal valor { get; set; }

        [Required(ErrorMessage = "É necessário informar o estúdio que produziu o jogo")]
        public int idEstudio { get; set; }

        [ForeignKey("idEstudio")]
        public Estudios estudio { get; set; }
    }
}
