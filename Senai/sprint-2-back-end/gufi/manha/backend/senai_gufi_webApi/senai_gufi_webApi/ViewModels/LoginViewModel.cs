using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.ViewModels
{
    /// <summary>
    /// Classe responsável pelo modelo de Login
    /// </summary>
    public class LoginViewModel
    {
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        public string Email { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string Senha { get; set; }
    }
}
