using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Jogo
    {
        public Jogo()
        {
            Personagems = new HashSet<Personagem>();
        }

        public int IdJogo { get; set; }
        public string NomeJogo { get; set; }

        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
