
using SP_Medical_Grupe.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Grupe.WebApi.Interfaces
{
    interface IConsultaRepository
    {
        List<Consulta> Listar();

        Consulta BuscarPorId(int id);

        void Cadastrar(Consulta novaConsulta);

        void Atualizar(int id, Consulta consultaAtualizada);

        void Deletar(int id);

        List<Consulta> ListarMinhasConsultas(int id);

        void Confirmação(int id, string status);

        void Prontuario(int id, string descricao);
    }
}
