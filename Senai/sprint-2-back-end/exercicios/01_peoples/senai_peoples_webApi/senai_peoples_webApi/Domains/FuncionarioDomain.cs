using System;
using System.ComponentModel.DataAnnotations;

namespace senai_peoples_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Funcionarios
    /// </summary>
    public class FuncionarioDomain
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sobrenome do funcionário é obrigatório!")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "O sobrenome do funcionário deve conter de 5 a 10 caracteres.")]
        public string Sobrenome { get; set; }

        // DataType não valida campo, apenas especifica o tipo do campo
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
