using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            // Busca um tipo de usuário pelo id
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            // Verifica se o tipo de usuário foi informado
            if (usuarioAtualizado.IdTipoUsuario != null)
            {
                // Atribui os novos valores aos campos existentes
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            }

            // Verifica se o nome foi informado
            if (usuarioAtualizado.Nome != null)
            {
                // Atribui os novos valores aos campos existentes
                usuarioBuscado.Nome = usuarioAtualizado.Nome;
            }

            // Verifica se o email foi informado
            if (usuarioAtualizado.Email != null)
            {
                // Atribui os novos valores aos campos existentes
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            // Verifica se a senha foi informado
            if (usuarioAtualizado.Senha != null)
            {
                // Atribui os novos valores aos campos existentes
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }



            // Atualiza o personagem que foi buscado
            ctx.Usuarios.Update(usuarioBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            // Retorna o primeiro tipo de usuário encontrado para o ID informado
            return ctx.Usuarios.FirstOrDefault(u => u.IdTipoUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            // Adiciona este novoTipo
            ctx.Usuarios.Add(novoUsuario);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um personagem através do seu Id
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            // Remove o personagem que foi buscado
            ctx.Usuarios.Remove(usuarioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public List<Usuario> ListarTipo()
        {
            return ctx.Usuarios.Include(u => u.IdTiposUsuarioNavigation).ToList();
        }

        public string stringConexao = "Data Source = DESKTOP-Q0JOIHU\\SQLEXPRESS; initial catalog = SENAI_HROADS_TARDE; user Id = sa; pwd=strilicherk2012n";
        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Define a query a ser executada no banco de dados
                string querySelect = "SELECT * FROM Usuarios WHERE Email = @Email AND Senha = @Senha";

                // Define o comando passando a query e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso dados tenham sido obtidos
                    if (rdr.Read())
                    {
                        // Cria um objeto usuarioBuscado
                        Usuario usuarioBuscado = new Usuario
                        {
                            // Atribui às propriedades os valores das colunas
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])

                        };
                        // Retorna o objeto usuarioBuscado
                        return usuarioBuscado;
                    }

                    // Caso não encontre um e-mail e senha correspondentes, retorna null
                    return null;
                }
            }
        }
    }
}
