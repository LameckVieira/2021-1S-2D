using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public int? IdJogo { get; set; }
        public int? IdClasse { get; set; }
        public string NomePersonagem { get; set; }
        public int CapacidadeMaximaDeVida { get; set; }
        public int CapacidadeMaximaDeMana { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Jogo IdJogoNavigation { get; set; }
    }
}
