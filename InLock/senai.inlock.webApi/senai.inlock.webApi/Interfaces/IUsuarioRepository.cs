using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();

        Usuario BuscarPorId(int id);
        void Cadastrar(Usuario novoUsuario);
        void Atualizar(int id, Usuario UsuarioAtualizado);
        void Deletar(int id);
        Usuario BuscarPorEmailSenha(string email, string senha);
    }
}
