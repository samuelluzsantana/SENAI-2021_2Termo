using System;
using System.Collections.Generic;

#nullable disable

namespace projeto_roman_senai_webApi.Domains
{
    public partial class Professor
    {
        public int IdProfessor { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEquipe { get; set; }
        public string NomeProfessor { get; set; }

        public virtual Equipe IdEquipeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
