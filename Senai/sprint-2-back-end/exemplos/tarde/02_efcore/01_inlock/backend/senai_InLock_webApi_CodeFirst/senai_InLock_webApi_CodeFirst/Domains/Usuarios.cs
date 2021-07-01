using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_InLock_webApi_CodeFirst.Domains
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        public string email { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        // Define os requisitos da propriedade
        [StringLength(30, MinimumLength = 5, ErrorMessage = "A senha deve conter de 5 a 30 caracteres.")]
        public string senha { get; set; }

        public int idTipoUsuario { get; set; }

        // Define a chave estrangeira
        [ForeignKey("idTipoUsuario")]
        public TiposUsuario tipoUsuario { get; set; }
    }
}
