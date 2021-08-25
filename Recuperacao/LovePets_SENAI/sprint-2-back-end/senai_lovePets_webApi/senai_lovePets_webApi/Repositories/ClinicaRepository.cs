using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        /// <summary>
        /// Instancia o objeto ctx com a classe lovePetsContext
        /// </summary>
        lovePetsContext ctx = new lovePetsContext();


        /// <summary>
        /// Atualiza uma clinica já existente
        /// </summary>
        /// <param name="idClinica">ID da clinica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int idClinica, Clinica clinicaAtualizada)
        {
            //Procura a clinica pelo ID que sera buscado
            Clinica clinicaBuscada = BuscarPorId(idClinica);

          
            //Verifico se existe
            if(clinicaAtualizada.RazaoSocial != null)
            {
                clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
            }

            //Verifico se existe
            if (clinicaAtualizada.Endereco != null)
            {
                clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
            }

            //Verifico se existe
            if (clinicaAtualizada.Cnpj != null)
            {
                clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
            }

            //Atualiza a Clinica que foi buscada 
            ctx.Clinicas.Update(clinicaBuscada);

            //Salva as informações para serem salvadas no campo
            ctx.SaveChanges();

        }


        /// <summary>
        /// Busca uma clinica através de seu ID
        /// </summary>
        /// <param name="idClinica">ID da clinica que sera buscada</param>
        /// <returns>Uma clinica encontrada</returns>
        public Clinica BuscarPorId(int idClinica)
        {
            //Busca uma e retorna uma clinica através do id Informado.
            return ctx.Clinicas.Find(idClinica);
        }

        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="novaClinica">Onjeto com as novas informações</param>
        public void Cadastrar(Clinica novaClinica)
        {
            //adiciona a nova clinica
            ctx.Clinicas.Add(novaClinica);

            //Salva as novas informações no banco.
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma clinica
        /// </summary>
        /// <param name="idClinica">ID da clinica que sera deletada</param>
        public void Deletar(int idClinica)
        {
            //Remove a clinica com o ID informado
            ctx.Clinicas.Remove(BuscarPorId(idClinica));

            //Salva as novas informações no banco.
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>Retorna uma lista com todas as clinicas cadastradas no banco</returns>
        public List<Clinica> ListarTodos()
        {
            //Retorna a lista com todas as Clinicas
            return ctx.Clinicas.ToList();
        }
    }
}
