using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class ClasseHabilidade
    {
        public int? IdClasse { get; set; }
        public int? IdHabilidade { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
    }
}
