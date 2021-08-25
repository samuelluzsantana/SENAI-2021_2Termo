using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        lovePetsContext ctx = new lovePetsContext();


        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="idUsuario">ID do Usuario que sera atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(idUsuario);


            if (usuarioAtualizado.Email !=null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            if (usuarioAtualizado.Senha !=null )
            {
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }


            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }




        /// <summary>
        /// Busca um usuário existente
        /// </summary>
        /// <param name="email">O e-mail que o usuário digitou</param>
        /// <param name="senha">A senha que o usuário digitou</param>
        /// <returns>Um usuário encontrado</returns>
        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }



        /// <summary>
        /// Busca um atendimento através do seu ID
        /// </summary>
        /// <param name="idUsuario">ID do atendimento que será buscado</param>
        /// <returns>Um atendimento encontrado</returns>
        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.Find(idUsuario);
        }


        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Um objeto com as novas informações</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }


        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="idUsuario">id do Usuario que sera deletado</param>
        public void Deletar(int idUsuario)
        {
            ctx.Usuarios.Remove(BuscarPorId(idUsuario));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuarios registrados no Banco
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
