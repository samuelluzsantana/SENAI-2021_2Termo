﻿using senai_gufi_webApi.Domains;
using System.Collections.Generic;

namespace senai_gufi_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo ITiposUsuarioRepository
    /// </summary>
    interface ITiposUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Uma lista de tipos de usuários</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será buscado</param>
        /// <returns>Um tipo de usuário buscado</returns>
        TiposUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado</param>
        void Cadastrar(TiposUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        void Deletar(int id);
    }
}
