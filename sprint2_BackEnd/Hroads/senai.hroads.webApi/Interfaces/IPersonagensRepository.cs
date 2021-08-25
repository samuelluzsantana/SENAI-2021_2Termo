using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IPersonagensRepository
    {
        /// <summary>
        /// Lista todos os personagens
        /// </summary>
        /// <returns>Uma lista de personagens</returns>
        List<Personagen> Listar();

        /// <summary>
        /// Busca um personagem especifico
        /// </summary>
        /// <param name="id">Leva o id como parâmetro</param>
        /// <returns>O personagem que tiver aquele id</returns>
        Personagen BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto novoPersonagem com as informações do personagem cadastrado</param>
        void Cadastrar(Personagen novoPersonagem);

        /// <summary>
        /// Atualiza as informações de um personagem
        /// </summary>
        /// <param name="id">id do personagem que será atualizado</param>
        /// <param name="personagemAtualizado">Objeto personagemAtualizado com as novas informações a serem inseridas</param>
        void Atualizar(int id, Personagen personagemAtualizado);

        /// <summary>
        /// Deleta um personagem
        /// </summary>
        /// <param name="id">id do personagem que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// lista todos os personagens com suas respectivas classes
        /// </summary>
        /// <returns>Uma lista de personagens e suas classes</returns>
        List<Personagen> ListarClasses();
    }
}
