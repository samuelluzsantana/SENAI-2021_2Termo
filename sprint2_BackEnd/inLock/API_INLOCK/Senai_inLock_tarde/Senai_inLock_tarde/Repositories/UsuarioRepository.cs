using Senai_inLock_tarde.Domain;
using Senai_inLock_tarde.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_inLock_tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// String de conexão com o Banco de Dados que recebe os parametros.
        /// 
        /// Data Source = Nome do Servidor 
        /// initial catalog = nome do banco de dados 
        /// user ID = sa; pwd = 35834520898 = faz a autenticação com o usuario do sql server passando logon e senha
        /// integrated security = true = faz a autenticação com o usuario do sistema (Windows)
        /// </summary>
        /// 
        private string stringConexao = "Data Source=DESKTOP-CRR2THJ; initial catalog=inlock_games_tarde; Id=sa; pwd=@nota1000";
        public UsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada
                string querySelectByld = "SELECT idUsuario, email, senha,idTipoUsuario  FROM usuarios WHERE idUsuario = @ID";

                //Abre conexão com o banco de dados
                con.Open();


                //Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;


                //Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectByld, con))
                {

                    //Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);


                    //Executa a query e armazena os dados do rdr
                    rdr = cmd.ExecuteReader();


                    //Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {

                        //Se sim, instancia um novo objeto jogobuscado do tipo JogoDomain
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {

                            //Atribui à propriedade idJogo o valor da coluna idUsuario da tabela do banco de dados
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),

                            //Atribui à propriedade nome o valor da coluna "nomeJogo" da tabela do banco de dados
                            email = rdr["email"].ToString(),

                            senha = rdr["senha"].ToString(),

                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                        };

                        //Retorna o jogobuscado com os dados obtidos
                        return usuarioBuscado;
                    }
                    //Senão, retorna null
                    return null;

                }
            }
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                //Declara a query que será executada
                string queryInsert = "INSERT INTO usuarios (email, senha, idTipoUsuario) VALUES (@email, @senha, @idTipousuario)";

                //Declara que o SqlCommand cmd passando a query que será executada e a conexão como parametros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@email", novoUsuario.email);
                    cmd.Parameters.AddWithValue("@senha", novoUsuario.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", novoUsuario.idTipoUsuario);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UsuarioDomain> ListarTodos()
        {
            List<UsuarioDomain> ListaUsuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT idUsuario, email, senha,idTipoUsuario  FROM usuarios";

                // Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    //executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        //Instancia um objeto jogo do tipo JogoDomain
                        UsuarioDomain usuario = new UsuarioDomain()
                        {

                            //Atribui à propriedade idJogo o valor da coluna idUsuario da tabela do banco de dados
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),

                            //Atribui à propriedade nome o valor da coluna "nomeJogo" da tabela do banco de dados
                            email = rdr["email"].ToString(),

                            senha = rdr["senha"].ToString(),

                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),

                        };

                        //Adiciona o objeto jogo criado à lista de Jogos
                        ListaUsuarios.Add(usuario);
                    }
                }


            }
            //Retorna a lista de jogos
            return ListaUsuarios;
            }

        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada
                string querySelectByld = "SELECT idUsuario, email, senha, usuarios.idTipoUsuario, tiposUsuario.titulo  " +
                    "FROM usuarios INNER JOIN tiposUsuario ON usuarios.idTipoUsuario = tiposUsuario.idTipoUsuario " +
                    "WHERE usuarios.email = @email AND senha = @senha" ;

                //Abre conexão com o banco de dados
                con.Open();



                //Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;


                //Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectByld, con))
                {

                    //Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);


                    //Executa a query e armazena os dados do rdr
                    rdr = cmd.ExecuteReader();


                    //Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {

                        //Se sim, instancia um novo objeto jogobuscado do tipo JogoDomain
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {

                            //Atribui à propriedade idJogo o valor da coluna idUsuario da tabela do banco de dados
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),

                            //Atribui à propriedade nome o valor da coluna "nomeJogo" da tabela do banco de dados
                            email = rdr["email"].ToString(),

                            senha = rdr["senha"].ToString(),

                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),

                            tipoUsuario = new TipoUsuarioDomain
                            {

                                idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),

                                titulo = rdr["titulo"].ToString(),


                            }
                        };

                        //Retorna o jogobuscado com os dados obtidos
                        return usuarioBuscado;
                    }
                    //Senão, retorna null
                    return null;

                }
            }
        }
    }

}

