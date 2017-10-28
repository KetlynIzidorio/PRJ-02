using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Administrador
    {
        [Required(ErrorMessage = "Informe o id do Administrador")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do Administrador")]
        [Display(Name = "Nome")]
        public string nomeAdministrador { get; set; }

        [Required(ErrorMessage = "Informe o email do Administrador")]
        [Display(Name = "Email")]
        public string emailAdministrador { get; set; }

        [Required(ErrorMessage = "Informe o usuário do Administrador")]
        [Display(Name = "User")]
        public string userAdministrador { get; set; }

        [Required(ErrorMessage = "Informe o usuário do Administrador")]
        [Display(Name = "Senha")]
        public string senhaAdministrador { get; set; }





    }

    
}