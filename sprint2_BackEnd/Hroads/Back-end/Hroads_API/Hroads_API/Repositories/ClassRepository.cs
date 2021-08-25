using Hroads_API.Contexts;
using Hroads_API.Domains;
using Hroads_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_API.Repositories
{
    /// <summary>
    /// Classe reponsavel pelo repositório das Classes
    /// </summary>
    public class ClassRepository : IClassesRepository
    {
        /// <summary>
        /// Objeto contexto(ctx) por onde serão chamados os metodos do EF Core
        /// </summary>
        HROADSContex ctx = new HROADSContex();


        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">ID da Classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto classeAtualizada com as novas informações</param>

        public void Atualizar(int id, Class classeAtualizada)
        {
            //busca classe através do id
            Class classeBuscada = ctx.Classes.Find(id);

            //verifica se o nome da classe foi informado
            if(classeAtualizada.NomeClasse !=null)
            {
                classeBuscada.NomeClasse = classeAtualizada.NomeClasse;
            }

            //Atualizo a classe atualizada
            ctx.Classes.Update(classeBuscada);

            //salvo as Mudanças
            ctx.SaveChanges();
        }


        /// <summary>
        /// Busca uma Classe através do seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Classe buscada</returns>
        public Class BuscarPorId(int id)
        {
            //retorna a primeira classe encontrada do id da classe informada
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == id);
        }



        /// <summary>
        /// Cadastra uma nova Classe
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse que sera cadastrado</param>
        public void Cadastrar(Class novaClasse)
        {
            //adicona a nova classe
            ctx.Classes.Add(novaClasse);
            //salva as informações inseridas no bd
            ctx.SaveChanges();
        }


        /// <summary>
        /// Deleta Classe existente 
        /// </summary>
        /// <param name="id">ID do estudio que será deletada</param>
        public void Deletar(int id)
        {
            //busca uma classe pelo seu id
            Class classeBuscada = ctx.Classes.Find(id);

            //remove a classe do bd
            ctx.Classes.Remove(classeBuscada);

            //Salva as mudanças
            ctx.SaveChanges();
        }


        /// <summary>
        /// Lista todas as Classes 
        /// </summary>
        /// <returns>Uma Lista de estúdios</returns>
        public List<Class> Listar()
        {
            //Retorna Uma lista com todas as classes
            return ctx.Classes.ToList();
        }

    }
}
