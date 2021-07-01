using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_gufi_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de tipos de usuários
    /// </summary>
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "O título do tipo de usuário é obrigatório!")]
        public string TituloTipoUsuario { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
