using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class PersonagensRepository : IPersonagensRepository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int id, Personagen personagemAtualizado)
        {
            // Busca um personagem pelo id
            Personagen personagemBuscado = ctx.Personagens.Find(id);
             
            // Verifica se o nome do personagem foi informado
            if (personagemAtualizado.NomePersonagem != null)
            {
                // Atribui os novos valores aos campos existentes
                personagemBuscado.NomePersonagem = personagemAtualizado.NomePersonagem;
            }

            // Verifica se a CapacidadeMaxvida do personagem foi informado
            if (personagemAtualizado.CapacidadeMaxvida != null)
            {
                // Atribui os novos valores aos campos existentes
                personagemBuscado.CapacidadeMaxvida = personagemAtualizado.CapacidadeMaxvida;
            }

            // Verifica se a CapacidadeMaxmana do personagem foi informado
            if (personagemAtualizado.CapacidadeMaxmana != null)
            {
                // Atribui os novos valores aos campos existentes
                personagemBuscado.CapacidadeMaxmana = personagemAtualizado.CapacidadeMaxmana;
            }

            // Verifica se a DataAtualizacao do personagem foi informado
            if (personagemAtualizado.DataAtualizacao != null)
            {
                // Atribui os novos valores aos campos existentes
                personagemBuscado.DataAtualizacao = personagemAtualizado.DataAtualizacao;
            }

            // Verifica se a DataCriacao do personagem foi informado
            if (personagemAtualizado.DataCriacao != null)
            {
                // Atribui os novos valores aos campos existentes
                personagemBuscado.DataCriacao = personagemAtualizado.DataCriacao;
            }

            // Atualiza o personagem que foi buscado
            ctx.Personagens.Update(personagemBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Personagen BuscarPorId(int id)
        {
            // Retorna o primeiro estúdio encontrado para o ID informado
            return ctx.Personagens.FirstOrDefault(p => p.IdPersonagem == id); 
        }

        public void Cadastrar(Personagen novoPersonagem)
        {
            // Adiciona este novoPersonagem
            ctx.Personagens.Add(novoPersonagem);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um personagem através do seu Id
            Personagen personagenBuscado = ctx.Personagens.Find(id);

            // Remove o personagem que foi buscado
            ctx.Personagens.Remove(personagenBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<Personagen> Listar()
        {
            return ctx.Personagens.ToList();
        }

        public List<Personagen> ListarClasses()
        {
            return ctx.Personagens.Include(p => p.IdClasseNavigation).ToList();
        }
    }
}
