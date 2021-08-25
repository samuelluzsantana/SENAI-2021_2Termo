using projeto_roman_senai_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_roman_senai_webApi.Interfaces
{
    interface IProjetoRepository
    {
        List<Projeto> ListarTodos();
        void Cadastrar(Projeto projeto);
    }
}
