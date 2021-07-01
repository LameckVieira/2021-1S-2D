using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_gufi_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de presenças
    /// </summary>
    public partial class Presenca
    {
        public int IdPresenca { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEvento { get; set; }

        // Define que o campo é obrigatório!
        [Required(ErrorMessage = "A situação da presença é obrigatória!")]
        public string Situacao { get; set; }

        public virtual Evento IdEventoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
