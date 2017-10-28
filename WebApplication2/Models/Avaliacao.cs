using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Avaliacao
    {
        [Required(ErrorMessage = "Informe o id ")]
        public int idAvaliacao { get; set; }

        [Required(ErrorMessage = "Informe o nome do Administrador")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Informe o email do Administrador")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a mensagem")]
        [Display(Name = "Mensagem")]
        public string mensagem { get; set; }
    }
}