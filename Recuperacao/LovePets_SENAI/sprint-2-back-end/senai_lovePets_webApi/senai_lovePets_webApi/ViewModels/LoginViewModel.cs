using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o seu e-mail!")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a sua senha!")]
        public string senha { get; set; }
    }
}
