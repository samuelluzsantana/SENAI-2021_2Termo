using senai_peoples_webApi.Domains;
using senai_peoples_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webApi.Repositories
{
    /// <summary>
    /// Repositório dos Funcionários
    /// </summary>
    public class FuncionarioRepository : IFuncionarioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// </summary>
        private string stringConexao = "Data Source=LAB08DESK2101\\SQLEXPRESS;initial catalog=Peoples; user Id=sa; pwd=senai@132";

        /// <summary>
        /// Atualiza um funcionário existente
        /// </summary>
        /// <param name="id">ID do funcionário que será atualizado</param>
        /// <param name="funcionarioAtualizado">Objeto funcionarioAtualizado que será atualizado</param>
        public void Atualizar(int id, FuncionarioDomain funcionarioAtualizado)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara  a query que sera executada (comando do SQL)
                string queryUpdate = "UPDATE Funcionarios" +
                                     "SET nome = @nome, sobrenome = @sobrenome" +
                                     "WHERE idFuncionario = @id";

                //Declara a SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con)
                {

                }
            }


        }



        public FuncionarioDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<FuncionarioDomain> BuscarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<FuncionarioDomain> ListarNomeCompleto()
        {
            throw new NotImplementedException();
        }

        public List<FuncionarioDomain> ListarOrdenado(string ordem)
        {
            throw new NotImplementedException();
        }



        public List<FuncionarioDomain> ListarTodos()
        {
            // Cria uma lista funcionarios onde serão armazenados os dados
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;


                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr abrindo e executando cmd
                    rdr = cmd.ExecuteReader();


                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto funcionario 
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            // Atribui à propriedade IdFuncionario o valor da coluna "IdFuncionario" da tabela do banco
                            idFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            nome = rdr["Nome"].ToString(),

                            // Atribui à propriedade Sobrenome o valor da coluna "Sobrenome" da tabela do banco
                            sobrenome = rdr["Sobrenome"].ToString()
                        };

                        / Adiciona o funcionario criado à lista funcionarios
                        funcionarios.Add(funcionario);

                    }

                    // retorna a lista de funcionario para funcionario
                    return funcionarios;


                }
            }
        }
    }
}
