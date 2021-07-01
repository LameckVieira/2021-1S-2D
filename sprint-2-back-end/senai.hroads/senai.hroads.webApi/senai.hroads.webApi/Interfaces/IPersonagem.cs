using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IPersonagem
    {
        List<Personagem> ListarTodos();
        Personagem BuscarporId(int id);

        void Cadastrar(Personagem novoPersonagem);
        void Atualizar(int id, Personagem PersonagemAtualizada);
        void Deletar(int id);
    }
}
