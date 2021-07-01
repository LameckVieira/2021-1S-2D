
using SP_Medical_Grupe.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Grupe.WebApi.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> Listar();

        Medico BuscarPorId(int id);

        void Cadastrar(Medico novoMedico);

        void Atualizar(int id, Medico medicoAtualizado);

        void Deletar(int id);

        



    }
}
