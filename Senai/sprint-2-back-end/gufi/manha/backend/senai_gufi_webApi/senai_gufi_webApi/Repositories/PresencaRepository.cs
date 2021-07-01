using Microsoft.EntityFrameworkCore;
using senai_gufi_webApi.Contexts;
using senai_gufi_webApi.Domains;
using senai_gufi_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace senai_gufi_webApi.Repositories
{
    /// <summary>
    /// Repositório responsável pelas presenças
    /// </summary>
    public class PresencaRepository : IPresencaRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Altera o status de uma presença
        /// </summary>
        /// <param name="id">ID da presença que terá a situação alterada</param>
        /// <param name="status">Parâmetro que atualiza o situação da presença para Confirmada, Não confirmada ou Recusada</param>
        public void AprovarRecusar(int id, string status)
        {
            // Busca a primeira presença para o ID informado e armazena no objeto presencaBuscada
            Presenca presencaBuscada = ctx.Presencas
                // Adiciona na busca as informações do usuário que participa do evento
                .Include(p => p.IdUsuarioNavigation)
                // Adiciona na busca as informações do evento que o usuário participa
                .Include(p => p.IdEventoNavigation)
                .FirstOrDefault(p => p.IdPresenca == id);

            // Verifica qual o status foi informado
            switch (status)
            {
                // Se for 1, a situação da presença será "Confirmada"
                case "1":
                    presencaBuscada.Situacao = "Confirmada";
                    break;

                // Se for 0, a situação da presença será "Recusada"
                case "0":
                    presencaBuscada.Situacao = "Recusada";
                    break;

                // Se for 2, a situação da presença será "Não confirmada"
                case "2":
                    presencaBuscada.Situacao = "Não confirmada";
                    break;

                // Se for qualquer valor diferente de 0, 1 e 2, a situação da presença não será alterada
                default:
                    presencaBuscada.Situacao = presencaBuscada.Situacao;
                    break;
            }

            // Atualiza os dados da presença que foi buscado
            ctx.Presencas.Update(presencaBuscada);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza uma presença existente
        /// </summary>
        /// <param name="id">ID da presença que será atualizado</param>
        /// <param name="presencaAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int id, Presenca presencaAtualizada)
        {
            // Busca uma presença através do id
            Presenca presencaBuscada = ctx.Presencas.Find(id);

            // Verifica se o id do usuário foi informado
            if (presencaAtualizada.IdUsuario != null)
            {
                // Atribui os novos valores ao campos existentes
                presencaBuscada.IdUsuario = presencaAtualizada.IdUsuario;
            }

            // Verifica se o id do evento foi informado
            if (presencaAtualizada.IdEvento != null)
            {
                // Atribui os novos valores ao campos existentes
                presencaBuscada.IdEvento = presencaAtualizada.IdEvento;
            }

            // Verifica se a situação da presença foi informada
            if (presencaAtualizada.Situacao != null)
            {
                // Atribui os novos valores ao campos existentes
                presencaBuscada.Situacao = presencaAtualizada.Situacao;
            }

            // Atualiza a presença que foi buscada
            ctx.Presencas.Update(presencaBuscada);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um presença através do ID
        /// </summary>
        /// <param name="id">ID da presença que será buscada</param>
        /// <returns>Uma presença buscada</returns>
        public Presenca BuscarPorId(int id)
        {
            // Retorna a primeira presença encontrada para o ID informado
            return ctx.Presencas.FirstOrDefault(p => p.IdPresenca == id);
        }

        /// <summary>
        /// Cadastra uma nova presença
        /// </summary>
        /// <param name="novaPresenca">Objeto novaPresenca que será cadastrado</param>
        public void Cadastrar(Presenca novaPresenca)
        {
            // Adiciona esta novaPresenca
            ctx.Presencas.Add(novaPresenca);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma presença existente
        /// </summary>
        /// <param name="id">ID da presença que será deletada</param>
        public void Deletar(int id)
        {
            // Busca uma presença através do id
            Presenca presencaBuscada = ctx.Presencas.Find(id);

            // Remove a presença que foi buscado
            ctx.Presencas.Remove(presencaBuscada);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Cria uma nova presença
        /// </summary>
        /// <param name="inscricao">Objeto com as informações da inscrição</param>
        public void Inscrever(Presenca inscricao)
        {
            // Outra forma, caso os dados da inscrição (nova presença) sejam enviados pelo usuário
            // independente do status que o usuário tente cadastrar ao se inscrever
            // por padrão, a situação será sempre "Não confirmada"
            // inscricao.Situacao = "Não confirmada";

            // Adiciona uma nova presença
            ctx.Presencas.Add(inscricao);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as presenças
        /// </summary>
        /// <returns>Uma lista de presenças</returns>
        public List<Presenca> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de usuários
            return ctx.Presencas.ToList();
        }

        /// <summary>
        /// Lista todos os eventos que um determinado usuário participa
        /// </summary>
        /// <param name="id">ID do usuário que participa dos eventos listados</param>
        /// <returns>Uma lista de presenças com os dados dos eventos</returns>
        public List<Presenca> ListarMinhas(int id)
        {
            // Retorna uma lista com todas as informações das presenças
            return ctx.Presencas
                // Adiciona na busca as informações do evento que o usuário participa
                .Include(p => p.IdEventoNavigation)
                // Adiciona na busca as informações do Tipo de Evento (categoria) deste evento
                .Include(p => p.IdEventoNavigation.IdTipoEventoNavigation)
                // Adiciona na busca as informações da Instituição deste evento
                .Include(p => p.IdEventoNavigation.IdInstituicaoNavigation)
                // Estabelece como parâmetro de consulta o ID do usuário recebido
                .Where(p => p.IdUsuario == id)
                .ToList();
        }
    }
}
