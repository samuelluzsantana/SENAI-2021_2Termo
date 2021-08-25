using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Busca um usuário existente
        /// </summary>
        /// <param name="email">O e-mail que o usuário digitou</param>
        /// <param name="senha">A senha que o usuário digitou</param>
        /// <returns>Um usuário encontrado</returns>
        Usuario BuscarPorEmailSenha(string email, string senha);

        /// <summary>
        /// Lista todos os usuarios registrados no Banco
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<Usuario> ListarTodos();

        /// <summary>
        /// Busca um atendimento através do seu ID
        /// </summary>
        /// <param name="idUsuario">ID do atendimento que será buscado</param>
        /// <returns>Um atendimento encontrado</returns>
        Usuario BuscarPorId(int idUsuario);

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Um objeto com as novas informações</param>
        void Cadastrar(Usuario novoUsuario);

      

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="idUsuario">id do Usuario que sera deletado</param>
        void Deletar(int idUsuario);

        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="idUsuario">ID do Usuario que sera atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        void Atualizar(int idUsuario, Usuario usuarioAtualizado);

    }

   

}
