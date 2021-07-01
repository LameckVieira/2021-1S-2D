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
    public class MedicoRepository : IMedicoRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();

        public void Atualizar(int id, Medico medicoAtualizado)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);

            if (medicoBuscado != null)
            {
                medicoBuscado.IdUsuario = medicoAtualizado.IdUsuario;

                medicoBuscado.IdEspecialidade = medicoAtualizado.IdEspecialidade;

                medicoBuscado.IdClinica = medicoAtualizado.IdClinica;

                medicoBuscado.Crm = medicoAtualizado.Crm;
            }

            ctx.Medicos.Update(medicoBuscado);

            ctx.SaveChanges();
        }

        public Medico BuscarPorId(int id)
        {
            return ctx.Medicos.FirstOrDefault(m => m.IdMedico == id);
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
           Medico medicoBuscado = ctx.Medicos.Find(id);

            ctx.Medicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos.ToList();
        }

    }
}
