using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    /// <summary>
    /// Interface referente a HabilidadeRepository
    /// </summary>
    interface IHabilidadesRepository
    {
        /// <summary>
        /// Lista todas as Habilidades cadastradas no BD 
        /// </summary>
        /// <returns>Uma Lista de habilidades</returns>
        List<Habilidade> Listar();

        /// <summary>
        /// Busca uma Habilidade através do seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Habilidade buscada</returns>
        Habilidade BuscarPorId(int id);


        /// <summary>
        /// Cadastra uma nova Habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaClasse que sera cadastrado</param>
        void Cadastrar(Habilidade novaHabilidade);



        /// <summary>
        /// Atualiza uma Habilidade existente
        /// </summary>
        /// <param name="id">ID da Habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto classeAtualizada com as novas informações</param>
        void Atualizar(int id,Habilidade habilidadeAtualizada);




        /// <summary>
        /// Deleta umaHabilidade existente 
        /// </summary>
        /// <param name="id">ID da Habilidade que será deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Lista uma habilidade e seu tipo
        /// </summary>
        /// <returns>uma habilidade e seu tipo</returns>
        List<Habilidade> ListarTipo();

    }
}
