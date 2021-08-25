using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    /// <summary>
    /// Interface que refgerencia as clinicas
    /// </summary>
    interface IClinicaRepository
    {
        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>Uma Lista com todas as clinicas</returns>
        List<Clinica> ListarTodos();

        /// <summary>
        /// Busca uma clinica por ID
        /// </summary>
        /// <param name="idClinica">ID da clinica que sera buscada</param>
        /// <returns></returns>
        Clinica BuscarPorId(int idClinica);

        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="novaClinica">Objeto com as novas informações</param>
        void Cadastrar(Clinica novaClinica);

        /// <summary>
        /// Atualiza uma clinica existente
        /// </summary>
        /// <param name="idClinica">ID da clinica que sera atualizada</param>
        /// <param name="clinicaAtualizada">Objeto com as novas informações</param>
        void Atualizar(int idClinica, Clinica clinicaAtualizada);

        /// <summary>
        /// Deleta uma clinica cadastrada no Banco
        /// </summary>
        /// <param name="idClinica">ID da Clinica que sera deletada</param>
        void Deletar(int idClinica);
    }
}
