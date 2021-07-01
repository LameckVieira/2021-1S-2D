using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoHabilidade
    {
        List<TipoHabilidade> ListarTodos();
        TipoHabilidade BuscarporId(int id);

        void Cadastrar(TipoHabilidade novaHabilidade);
        void Atualizar(int id, TipoHabilidade HabilidadeAtualizada);
        void Deletar(int id);
    }
}
