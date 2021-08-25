using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    /// <summary>
    /// Interface Responsavel pela ClasseRepository
    /// </summary>
    interface IClassesRepository
    {
        /// <summary>
        /// Lista todas as Classes 
        /// </summary>
        /// <returns>Uma Lista de classes</returns>
        List<Class> Listar();

        /// <summary>
        /// Busca uma Classe através do seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Classe buscada</returns>
        Class BuscarPorId(int id);
        
        /// <summary>
        /// Cadastra uma nova Classe
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse que sera cadastrado</param>
        void Cadastrar(Class novaClasse);

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">ID da Classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto classeAtualizada com as novas informações</param>
        void Atualizar(int id, Class classeAtualizada);

        /// <summary>
        /// Deleta Classe existente 
        /// </summary>
        /// <param name="id">ID do estudio que será deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Lista as classes e os personagens que possuem aquelas classes
        /// </summary>
        /// <returns>Uma lista de classes com os personagens que possuem aquelas classes</returns>
        List<Class> ListarPersonagem();


    }
}
