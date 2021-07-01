using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webApi_CodeFirst.Domains
{
    /// <summary>
    /// Classe que representa a entidade Jogos
    /// </summary>
    
    // Define o nome da tabela que será criada no banco de dados
    [Table("Jogos")]
    public class Jogos
    {
        // Define que será uma chave primária
        [Key]
        // Define o auto-incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idJogo { get; set; }

        // Define o tipo de dado
        [Column(TypeName = "VARCHAR(150)")]
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string nomeJogo { get; set; }

        // Define o tipo de dado
        [Column(TypeName = "TEXT")]
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A descrição do jogo é obrigatória!")]
        public string descricao { get; set; }

        // Define o tipo do dado
        [Column(TypeName = "DATE")]
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória!")]
        public DateTime dataLancamento { get; set; }

        // Define o tipo de dado
        [Column(TypeName = "DECIMAL (18,2)")]
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "É necessário informar o preço do jogo!")]
        public decimal valor { get; set; }

        // Define que a o propriedade é obrigatória
        [Required(ErrorMessage = "É necessário informar o estúdio que produziu o jogo!")]
        public int idEstudio { get; set; }

        // Define a chave estrangeira
        [ForeignKey("idEstudio")]
        public Estudios estudio { get; set; }
    }
}
