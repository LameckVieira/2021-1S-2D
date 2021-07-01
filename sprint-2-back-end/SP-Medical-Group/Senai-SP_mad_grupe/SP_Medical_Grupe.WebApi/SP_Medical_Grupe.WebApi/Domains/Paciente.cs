using System;
using System.Collections.Generic;

#nullable disable

namespace SP_Medical_Grupe.WebApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
