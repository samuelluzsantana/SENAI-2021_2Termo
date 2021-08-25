using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITiposUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Uma lista dos tipos de usuários</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Busca um tipo de usuário especifico
        /// </summary>
        /// <param name="id">Leva o id como parâmetro</param>
        /// <returns>O tipo de usuário buscado pelo id</returns>
        TiposUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario com as informações do tipo de usuário cadastrado</param>
        void Cadastrar(TiposUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza as informações do tipo de usuário
        /// </summary>
        /// <param name="id">id do tipo de usuario que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto tipoUsuarioAtualizado com as novas informações a serem inseridas</param>
        void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um tipo de usuario
        /// </summary>
        /// <param name="id">id do tipo de usuário que será deletado</param>
        void Deletar(int id);
    }
}
