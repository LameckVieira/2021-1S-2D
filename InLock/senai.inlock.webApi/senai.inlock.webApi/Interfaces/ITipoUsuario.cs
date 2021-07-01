using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface ITipoUsuario
    {
        List<TipoUsuario> ListarTodos();
        TipoUsuario BuscarporId(int id);

        void Cadastrar(TipoUsuario novoTipoUsuario);
        void Atualizar(int id, TipoUsuario TipoUsuarioAtualizado);
        void Deletar(int id);
    }
}
