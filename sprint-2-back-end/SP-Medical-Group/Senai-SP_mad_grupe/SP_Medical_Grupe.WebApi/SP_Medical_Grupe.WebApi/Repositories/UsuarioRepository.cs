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
    public class UsuarioRepository : IUsuarioRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;

                usuarioBuscado.Nome = usuarioAtualizado.Nome;

                usuarioBuscado.Email = usuarioAtualizado.Email;

                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novaUsuario)
        {
            ctx.Usuarios.Add(novaUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public List<Usuario> UsuariosMedicosPacientes()
        {
            return ctx.Usuarios.Include(u => u.Medicos)
                .Include(u => u.Pacientes)
                .ToList();
        }
    }
}
