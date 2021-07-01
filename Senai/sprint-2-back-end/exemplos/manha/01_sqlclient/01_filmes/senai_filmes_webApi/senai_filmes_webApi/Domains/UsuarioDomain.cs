using System.ComponentModel.DataAnnotations;

/// <summary>
/// Classe que representa a entidade (tabela) Usuarios
/// </summary>
namespace senai_filmes_webApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "Informe o e-mail")]
        public string email { get; set; }

        // Define que o campo é obrigatório, com no mínimo 3 e no máximo 20 caracteres
        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo senha precisa ter no mínimo 3 e no máximo 20 caracteres")]
        public string senha { get; set; }

        public string permissao { get; set; }
    }
}
