using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogosRepository
    {
        List<Jogos> ListarTodos();

        Jogos BuscarPorId(int id);
        void Cadastrar(Jogos novoJogo);
        void Atualizar(int id, Jogos jogoAtualizado);
        void Deletar(int id);
    }
}
