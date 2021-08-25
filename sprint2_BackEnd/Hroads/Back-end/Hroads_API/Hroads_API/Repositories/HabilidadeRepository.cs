using Hroads_API.Contexts;
using Hroads_API.Domains;
using Hroads_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_API.Repositories
{
    public class HabilidadeRepository : IHabilidadesRepository
    {
        /// <summary>
        /// Objeto contexto(ctx) por onde serão chamados os metodos do EF Core
        /// </summary>
        HROADSContex ctx = new HROADSContex();


        /// <summary>
        /// Atualiza uma Habilidade existente
        /// </summary>
        /// <param name="id">ID da Habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto classeAtualizada com as novas informações</param>
        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            //busca uma habilidade através do id
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);
            Habilidade idBuscadoHabilidade = ctx.Habilidades.Find(id);

            //verifica se o nome da habilidade foi informado
            if (habilidadeAtualizada.NomeHabilidade != null)
            {
                habilidadeBuscada.NomeHabilidade = habilidadeAtualizada.NomeHabilidade;
            }

            if (habilidadeAtualizada.IdTipo !=null)
            {
                habilidadeBuscada.IdTipo = habilidadeAtualizada.IdTipo;
            }
     

            //Atualizo a classe atualizada
            ctx.Habilidades.Update(habilidadeBuscada);

            //salvo as Mudanças
            ctx.SaveChanges();
        }


        /// <summary>
        /// Busca uma Habilidade através do seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Habilidade buscada</returns>
        public Habilidade BuscarPorId(int id)
        {
            //retorna a primeira Habilidade encontrada do id da classe informada
            return ctx.Habilidades.FirstOrDefault(h => h.IdHabilidade == id);
        }

        /// <summary>
        /// Cadastra uma nova Habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaClasse que sera cadastrado</param>
        public void Cadastrar(Habilidade novaHabilidade)
        {
            //adicona a nova classe
            ctx.Habilidades.Add(novaHabilidade);
            //salva as informações inseridas no bd
            ctx.SaveChanges();
        }



        /// <summary>
        /// Deleta umaHabilidade existente 
        /// </summary>
        /// <param name="id">ID da Habilidade que será deletada</param>
        public void Deletar(int id)
        {

            //busca uma classe pelo seu id
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            //remove a classe do bd
            ctx.Habilidades.Remove(habilidadeBuscada);

            //Salva as mudanças
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as Habilidades cadastradas no BD 
        /// </summary>
        /// <returns>Uma Lista de habilidades</returns>
        public List<Habilidade> Listar()
        {
            return ctx.Habilidades.ToList();
        }

        /// <summary>
        /// Lista uma habilidade e seu tipo
        /// </summary>
        /// <returns>uma habilidade e seu tipo</returns>
        public List<Habilidade> ListarTipo()
        {
            return ctx.Habilidades.Include(h => h.IdTipoNavigation).ToList();
        }

    }
}
