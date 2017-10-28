using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Clientes
    {
        [Required(ErrorMessage = "Informe o id do Cliente")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o usurio do Cliente")]
        [Display(Name = "User")]
        public string userClientes { get; set; }

        [Required(ErrorMessage = "Informe a senha do Cliente")]
        [Display(Name = "Senha")]
        public string senhaClientes { get; set; }

        public string pedidosClientes { get; set; }
        
        public string contaClientes { get; set; }

    }
}