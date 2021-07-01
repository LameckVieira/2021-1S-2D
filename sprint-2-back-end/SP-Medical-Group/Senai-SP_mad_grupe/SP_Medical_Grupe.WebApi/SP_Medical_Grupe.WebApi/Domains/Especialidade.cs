using System;
using System.Collections.Generic;

#nullable disable

namespace SP_Medical_Grupe.WebApi.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdEspecialidade { get; set; }
        public string TituloEspecialidade { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
