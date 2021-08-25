using senai_filmes_webApi.Doamins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //TipoRetorno NomeMetodo();

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns> Lista de gêneros</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Busca um gênero através do seu id
        /// </summary>
        /// <param name="id">id do genero que sera buscado</param>
        /// <returns>Um objeto genero que foi buscado</returns>
        GeneroDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com as informações que será cadastradas</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um genêro existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        void atualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza um genero existente passando o id pela url da requisição.
        /// </summary>
        /// <param name="id">Id do Genero que sera atualizado</param>
        /// <param name="genero">Objeto genero com as novas informações</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">id do genero que sera deletado</param>
        void Deletar(int id);
    }
}
