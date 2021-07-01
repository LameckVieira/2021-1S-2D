using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int id, Classe ClasseAtualizada)
        {
            throw new NotImplementedException();
        }

        public Classe BuscarporId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Classe novaClasse)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Classe> ListarTodos()
        {
            return ctx.Classes.ToList();
        }
    }
}
