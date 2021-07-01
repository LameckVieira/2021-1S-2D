using Microsoft.EntityFrameworkCore;
using SP_Medical_Grupe.WebApi.Interfaces;
using SP_Medical_Grupe.WebApi.Contexts;
using SP_Medical_Grupe.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Grupe.WebApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();

        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            if (consultaBuscada != null)
            {
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;

                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;

                consultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;
            }

            ctx.Consultas.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(int id)
        {
            return ctx.Consultas.FirstOrDefault(c => c.IdConsulta == id);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            novaConsulta.Situacao = "Aguardando confirmação do agendamento";

            ctx.Consultas.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Confirmação(int id, string status)
        {
            Consulta consultaBuscada = ctx.Consultas
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdPacienteNavigation)
                .FirstOrDefault(c => c.IdConsulta == id);

            switch (status)
            {
                case "1":
                    consultaBuscada.Situacao = "Agendada";
                    break;

                case "2":
                    consultaBuscada.Situacao = "Realizada";
                    break;

                default:
                    consultaBuscada.Situacao = consultaBuscada.Situacao;
                    break;
            }

            ctx.Consultas.Update(consultaBuscada);

            ctx.SaveChanges();

        }

        public void Deletar(int id)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            ctx.Consultas.Remove(consultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consultas.ToList();
        }

        public List<Consulta> ListarMinhasConsultas(int id)
        {

            return ctx.Consultas
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)
                .Include(c => c.IdPacienteNavigation)
                .Include(c => c.IdPacienteNavigation.IdUsuarioNavigation)
                .Include(c => c.IdMedicoNavigation.IdClinicaNavigation)
                .Where(c => c.IdMedicoNavigation.IdUsuario == id || c.IdMedicoNavigation.IdUsuario == id)
                .ToList();
                
        }

        public void Prontuario(int id, string descricao)
        {
            Consulta consultaBuscada = BuscarPorId(id);

            if (consultaBuscada != null)
            {
                consultaBuscada.Descricao = descricao;
            }

            ctx.Consultas.Update(consultaBuscada);

            ctx.SaveChanges();
        }
    }
}
