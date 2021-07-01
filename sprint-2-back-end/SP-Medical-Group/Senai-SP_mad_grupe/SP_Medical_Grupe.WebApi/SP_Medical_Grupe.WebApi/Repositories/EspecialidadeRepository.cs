using Microsoft.EntityFrameworkCore;
using SP_Medical_Grupe.WebApi.Contexts;
using SP_Medical_Grupe.WebApi.Domains;
using SP_Medical_Grupe.WebApi.Interfaces;
using SP_Medical_Grupe.WebApi.Contexts;
using SP_Medical_Grupe.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Grupe.WebApi.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();

        public void Atualizar(int id, Especialidade especializadaAtualizada)
        {
            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id);

            if (especialidadeBuscada != null)
            {
                especialidadeBuscada.TituloEspecialidade = especializadaAtualizada.TituloEspecialidade;
            }

            ctx.Especialidades.Update(especialidadeBuscada);

            ctx.SaveChanges();
        }

        public Especialidade BuscarPorId(int id)
        {
            return ctx.Especialidades.FirstOrDefault(e => e.IdEspecialidade == id);
        }

        public void Cadastrar(Especialidade novaEspecialidade)
        {
            ctx.Especialidades.Add(novaEspecialidade);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id);

            ctx.Especialidades.Remove(especialidadeBuscada);

            ctx.SaveChanges();
        }

        public List<Especialidade> Listar()
        {
            return ctx.Especialidades.ToList();
        }

        public List<Especialidade> ListarMedicos()
        {
            return ctx.Especialidades.Include(e => e.Medicos).ToList();
        }
    }
}
