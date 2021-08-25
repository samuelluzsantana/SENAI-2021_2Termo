using senai_filmes_webApi.Doamins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    interface IFilmesRepository
    {
        /// <summary>
        /// Lista todos os filmes cadastrados
        /// </summary>
        /// <returns>Uma lista com filmes cadastrados</returns>
        List<FilmeDomain> ListarTodos();
        
        /// <summary>
        /// Busca um filme através de seu ID
        /// </summary>
        /// <param name="id">Id do Filme que será buscado</param>
        /// <returns>Um objeto filmes que foi buscado</returns>
        FilmeDomain BuscarPorID(int id);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme com o nome do filme que será cadastrado</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Atualiza um filme existente passando um ID pelo corpo da requisição
        /// </summary>
        /// <param name="filme">Objeto filme com as novas informações</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualiza um Filme existente passando um ID pela URl da requisição
        /// </summary>
        /// <param name="id">id do Filme que sera atualizado</param>
        /// <param name="filme">Objeto filme com as novas informações</param>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Deleta um filme através do seu ID
        /// </summary>
        /// <param name="id">id do filme que sera deletado</param>
        void Deletar(int id);
    }
}
