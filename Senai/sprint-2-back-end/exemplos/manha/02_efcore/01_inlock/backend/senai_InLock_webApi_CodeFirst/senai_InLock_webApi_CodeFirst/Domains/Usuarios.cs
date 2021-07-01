using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_InLock_webApi_CodeFirst.Domains
{
    /// <summary>
    /// Classe que representa a entidade Usuarios
    /// </summary>

    // Define o nome da tabela que será criada no banco de dados
    [Table("Usuarios")]
    public class Usuarios
    {
        // Define que será uma chave primária
        [Key]
        // Define o auto-incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }

        // Define o tipo de dado
        [Column(TypeName = "VARCHAR(150)")]
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        public string email { get; set; }

        // Define o tipo de dado
        [Column(TypeName = "VARCHAR(150)")]
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        // Define os requisitos da propriedade
        [StringLength(30, MinimumLength = 5, ErrorMessage = "A senha deve conter entre 5 e 30 caracteres.")]
        public string senha { get; set; }

        public int idTipoUsuario { get; set; }

        // Define a chave estrangeira
        [ForeignKey("idTipoUsuario")]
        public TiposUsuario tipoUsuario { get; set; }
    }
}
