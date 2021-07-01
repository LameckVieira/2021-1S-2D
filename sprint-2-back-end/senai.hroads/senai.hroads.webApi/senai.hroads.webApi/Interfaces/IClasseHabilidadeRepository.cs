using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseHabilidadeRepository
    {
        List<ClasseHabilidade> ListarTodos();
        ClasseHabilidade BuscarporId(int id);

        void Cadastrar(ClasseHabilidade novahabilidade);
        void Atualizar(int id, ClasseHabilidade habilidadeAtualizada);
        void Deletar(int id);
    }
}
