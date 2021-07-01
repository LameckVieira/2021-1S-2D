
using SP_Medical_Grupe.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Grupe.WebApi.Interfaces
{
    interface ITiposUsuarioRepository
    {
        List<TiposUsuario> Listar();

        TiposUsuario BuscarPorId(int id);

        void Cadastrar(TiposUsuario novoTipoUsuario);

        void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado);

        void Deletar(int id);

        List<TiposUsuario> ListarUsuarios();
    }
}
