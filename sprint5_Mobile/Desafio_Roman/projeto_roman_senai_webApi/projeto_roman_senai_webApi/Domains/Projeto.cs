using System;
using System.Collections.Generic;

#nullable disable

namespace projeto_roman_senai_webApi.Domains
{
    public partial class Projeto
    {
        public int IdProjeto { get; set; }
        public string NomeProjeto { get; set; }
        public int? IdTema { get; set; }

        public virtual Tema IdTemaNavigation { get; set; }
    }
}
