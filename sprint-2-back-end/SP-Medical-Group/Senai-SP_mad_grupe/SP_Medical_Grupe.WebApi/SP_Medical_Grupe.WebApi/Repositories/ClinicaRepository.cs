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
    public class ClinicaRepository : IClinicaRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();

        public void Atualizar(int id, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            if (clinicaAtualizada != null)
            {
                clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;

                clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;

                clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
            }

            ctx.Clinicas.Update(clinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int id)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == id);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            ctx.Clinicas.Remove(clinicaBuscada);

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }

        public List<Clinica> ListarMedicos()
        {
            return ctx.Clinicas.Include(c => c.Medicos).ToList();
        }


    }
}
