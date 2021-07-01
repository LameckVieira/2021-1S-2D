using Microsoft.EntityFrameworkCore;
using senai_InLock_webApi_CodeFirst.Contexts;
using senai_InLock_webApi_CodeFirst.Domains;
using senai_InLock_webApi_CodeFirst.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_InLock_webApi_CodeFirst.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos Estúdios
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        InLockContext ctx = new InLockContext();

        /// <summary>
        /// Atualiza um estúdio existente
        /// </summary>
        /// <param name="id">ID do estúdio que será atualizado</param>
        /// <param name="estudioAtualizado">Objeto estudioAtualizado com as novas informações</param>
        public void Atualizar(int id, Estudios estudioAtualizado)
        {
            // Busca um estúdio através do id
            Estudios estudioBuscado = ctx.Estudios.Find(id);

            // Verifica se o nome do estúdio foi informado
            if (estudioAtualizado.nomeEstudio != null)
            {
                // Atribui os novos valores aos campos existentes
                estudioBuscado.nomeEstudio = estudioAtualizado.nomeEstudio;
            }

            // Atualiza o estúdio que foi buscado
            ctx.Estudios.Update(estudioBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um estúdio através do seu ID
        /// </summary>
        /// <param name="id">ID do estúdio que será buscado</param>
        /// <returns>Um estúdio buscado</returns>
        public Estudios BuscarPorId(int id)
        {
            // Retorna o primeiro estúdio encontrado para o ID informado
            return ctx.Estudios.FirstOrDefault(e => e.idEstudio == id);
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        public void Cadastrar(Estudios novoEstudio)
        {
            // Adiciona este novoEstudio
            ctx.Estudios.Add(novoEstudio);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um estúdio existente
        /// </summary>
        /// <param name="id">ID do estúdio que será deletado</param>
        public void Deletar(int id)
        {
            // Busca um estúdio através do seu id
            Estudios estudioBuscado = ctx.Estudios.Find(id);

            // Remove o estúdio que foi buscado
            ctx.Estudios.Remove(estudioBuscado);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios</returns>
        public List<Estudios> Listar()
        {
            // Retorna uma lista com todas as informações dos estúdios
            return ctx.Estudios.ToList();
        }

        /// <summary>
        /// Lista todos os estúdios com seus respectivos jogos
        /// </summary>
        /// <returns>Uma lista de estúdios com seus jogos</returns>
        public List<Estudios> ListarJogos()
        {
            // Retorna uma lista de estúdios com seus jogos
            return ctx.Estudios.Include(e => e.jogos).ToList();
        }
    }
}
