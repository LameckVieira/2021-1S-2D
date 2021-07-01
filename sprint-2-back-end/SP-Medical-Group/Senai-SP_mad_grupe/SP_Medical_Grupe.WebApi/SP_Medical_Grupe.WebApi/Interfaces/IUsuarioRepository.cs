
using SP_Medical_Grupe.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Grupe.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorId(int id);

        void Cadastrar(Usuario novaUsuario);

        void Atualizar(int id, Usuario usuarioAtualizado);

        void Deletar(int id);

        Usuario Login(string email, string senha);

        List<Usuario> UsuariosMedicosPacientes();

    }
}
