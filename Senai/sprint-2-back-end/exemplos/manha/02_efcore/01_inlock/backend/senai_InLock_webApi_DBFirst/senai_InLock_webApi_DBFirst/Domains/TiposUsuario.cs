using System;
using System.Collections.Generic;

#nullable disable

namespace senai_InLock_webApi_DBFirst.Domains
{
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string Titulo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
