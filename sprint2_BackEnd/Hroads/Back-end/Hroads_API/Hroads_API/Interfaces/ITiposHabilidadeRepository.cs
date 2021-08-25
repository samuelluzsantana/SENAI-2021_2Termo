using Hroads_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Hroads_API.Interfaces
{
    /// <summary>
    /// Interface referente a TipoHabiliadeRepository
    /// </summary>

    interface ITiposHabilidadeRepository
    {
       
       
            /// <summary>
            /// Lista de todos os tipos de habilidades cadastradas no BD 
            /// </summary>
            /// <returns>Uma Lista de tipos de habilidades</returns>
            List<TiposHabilidade> Listar();

            /// <summary>
            /// Busca um tipo de habilidade através do seu id
            /// </summary>
            /// <param name="id"></param>
            /// <returns>um tipo de habilidade buscada</returns>
            TiposHabilidade BuscarPorId(int id);


            /// <summary>
            /// Cadastra um novo tipo de habilidade
            /// </summary>
            /// <param name="novoTipo">Objeto Tipo que sera cadastrado</param>
            void Cadastrar(TiposHabilidade novoTipo);



            /// <summary>
            /// Atualiza um tipo de habilidade existente
            /// </summary>
            /// <param name="id">ID do tipo de habilidade que será atualizada</param>
            /// <param name="tipoAtualizado">Objeto tipoAtualizado com as novas informações</param>
            void Atualizar(int id, TiposHabilidade tipoAtualizado);


            /// <summary>
            /// Deleta uma tipo de habilidade existente 
            /// </summary>
            /// <param name="id">ID do  Tipo de habilidade que será deletada</param>
            void Deletar(int id);

        



    }

}
