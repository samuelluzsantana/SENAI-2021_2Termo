using Microsoft.EntityFrameworkCore;
using projeto_roman_senai_webApi.Contexts;
using projeto_roman_senai_webApi.Domains;
using projeto_roman_senai_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_roman_senai_webApi.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        roman ctx = new roman();
        public void Cadastrar(Projeto projeto)
        {
            ctx.Projetos.Add(projeto);

            ctx.SaveChanges();
        }

        public List<Projeto> ListarTodos()
        {
            return ctx.Projetos

                .Include(p => p.IdTemaNavigation).ToList();
        }
    }
}
