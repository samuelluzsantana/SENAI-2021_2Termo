using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IDonoRepository
    {
        /// <summary>
        /// Lista todos os donos cadastrados no banco
        /// </summary>
        /// <returns>Uma lista de donos</returns>
        List<Dono> List();

        /// <summary>
        /// busca um dono através do seu id
        /// </summary>
        /// <param name="idDono">Id do Dono que sera buscado</param>
        /// <returns>O Dono buscado</returns> 
        Dono BuscarPorId(int idDono);

        /// <summary>
        /// Cadastra um novo dono no banco
        /// </summary>
        /// <param name="donoCadastrado">Objeto com as novas informações</param>
        void Cadastrar(Dono donoCadastrado);

        /// <summary>
        /// Atualiza um dono ja cadastrado no banco
        /// </summary>
        /// <param name="idDono">ID do dono que sera atualizado</param>
        /// <param name="donoAtualizado">Objeto com as novas informações</param>
        void Atualizar(int idDono, Dono donoAtualizado);

        /// <summary>
        /// Deleta um dono
        /// </summary>
        /// <param name="idDono">id do dono que sera deletado</param>
        void Deletar(int idDono);
    }
}
