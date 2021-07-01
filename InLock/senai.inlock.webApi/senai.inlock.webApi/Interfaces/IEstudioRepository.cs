using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IEstudioRepository
    {
        List<Estudios> ListarTodos();
        Estudios BuscarporId(int id);

        void Cadastrar(Estudios novoEstudio);
        void Atualizar(int id, Estudios estudioAtualizado);
        void Deletar(int id);
     
    }
}
