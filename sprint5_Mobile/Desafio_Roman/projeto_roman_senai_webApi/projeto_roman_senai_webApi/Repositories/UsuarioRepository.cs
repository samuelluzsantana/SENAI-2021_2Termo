using projeto_roman_senai_webApi.Contexts;
using projeto_roman_senai_webApi.Domains;
using projeto_roman_senai_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_roman_senai_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        roman ctx = new roman();
        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
