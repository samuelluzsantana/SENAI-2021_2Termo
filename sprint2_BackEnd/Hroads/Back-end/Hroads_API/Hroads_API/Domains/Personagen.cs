using System;
using System.Collections.Generic;

#nullable disable

namespace Hroads_API.Domains
{
    public partial class Personagen
    {
        public int IdPersonagem { get; set; }
        public int? IdClasse { get; set; }
        public string NomePersonagem { get; set; }
        public string CapacidadeMaxvida { get; set; }
        public string CapacidadeMaxmana { get; set; }
        public string DataAtualizacao { get; set; }
        public string DataCriacao { get; set; }

        public virtual Class IdClasseNavigation { get; set; }
    }
}
