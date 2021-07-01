using Microsoft.EntityFrameworkCore;
using SP_Medical_Grupe.WebApi.Contexts;
using SP_Medical_Grupe.WebApi.Domains;
using SP_Medical_Grupe.WebApi.Interfaces;
using SP_Medical_Grupe.WebApi.Contexts;
using SP_Medical_Grupe.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Grupe.WebApi.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();
        public void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            TiposUsuario tiposUsuarioBuscado = ctx.TiposUsuarios.Find(id);

            if (tiposUsuarioBuscado != null)
            {
                tiposUsuarioBuscado.TituloTipoUsuario = tipoUsuarioAtualizado.TituloTipoUsuario;
            }

            ctx.TiposUsuarios.Update(tiposUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            ctx.TiposUsuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposUsuario tipoUsuarioBuscado = ctx.TiposUsuarios.Find(id);

            ctx.TiposUsuarios.Remove(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuarios.ToList();
        }

        public List<TiposUsuario> ListarUsuarios()
        {
            return ctx.TiposUsuarios.Include(t => t.Usuarios).ToList();
        }
    }
}
