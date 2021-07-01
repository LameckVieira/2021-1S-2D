using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) Generos
    /// </summary>
    public class GeneroDomain
    {
        public int idGenero { get; set; }

        [Required(ErrorMessage = "O nome do gênero é obrigatório!")]
        public string nome { get; set; }
    }
}
