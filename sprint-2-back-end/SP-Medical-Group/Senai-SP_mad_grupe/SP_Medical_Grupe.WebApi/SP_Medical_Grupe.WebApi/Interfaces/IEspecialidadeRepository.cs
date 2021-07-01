
using SP_Medical_Grupe.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Grupe.WebApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        List<Especialidade> Listar();

        Especialidade BuscarPorId(int id);

        void Cadastrar(Especialidade novaEspecialidade);

        void Atualizar(int id, Especialidade especializadaAtualizada);

        void Deletar(int id);

        List<Especialidade> ListarMedicos();
    }
}
