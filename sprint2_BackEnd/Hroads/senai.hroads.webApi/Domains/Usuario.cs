using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        [Required(ErrorMessage = "o e-mail é obrigatório")]
        public string Email { get; set; }
        // Define que o campo é obrigatório, com no mínimo 3 e no máximo 20 caractéres
        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo senha precisa ter no minimo 3 caracteres")]
        public string Senha { get; set; }

        public virtual TiposUsuario IdTiposUsuarioNavigation { get; set; }
    }
}
