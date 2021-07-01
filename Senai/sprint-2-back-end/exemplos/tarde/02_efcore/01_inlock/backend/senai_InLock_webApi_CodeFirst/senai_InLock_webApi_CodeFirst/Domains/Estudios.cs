using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_InLock_webApi_CodeFirst.Domains
{
    [Table("Estudios")]
    public class Estudios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEstudio { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O nome do estúdio é obrigatório!")]
        public string nomeEstudio { get; set; }

        public List<Jogos> jogos { get; set; }
    }
}
