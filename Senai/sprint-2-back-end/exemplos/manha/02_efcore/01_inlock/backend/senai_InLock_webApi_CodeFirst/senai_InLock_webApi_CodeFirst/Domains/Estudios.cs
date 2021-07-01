using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_InLock_webApi_CodeFirst.Domains
{
    /// <summary>
    /// Classe representa a entidade Estudios
    /// </summary>

    [Table("Estudios")]
    public class Estudios
    {
        // Define que será uma chave primária
        [Key]
        // Define o auto-incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEstudio { get; set; }

        // Define o nome da coluna e o tipo de dado
        [Column(TypeName = "VARCHAR(150)")]
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do estúdio é obrigatório!")]
        public string nomeEstudio { get; set; }

        public List<Jogos> jogos { get; set; }
    }
}
