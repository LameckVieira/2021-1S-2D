using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Funcionarios
    /// </summary>
    public class FuncionariosDomain
    {
        //Campo 'IdFuncionario' da tabela do banco de dados
        public int IdFuncionario { get; set; }

        //Campo 'Nome' da tabela do banco de dados
        public string Nome { get; set; }

        //Campo 'Sobrenome' da tabela do banco de dados
        public string Sobrenome { get; set; }
    }
}
