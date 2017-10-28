using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Lanches
    {

        [Display(Name ="Id")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Informe o nome do lanche")]
        [Display(Name = "Nome do Lanche")]
        public string Nome { get; set; }
       
        
        [Required(ErrorMessage = "Informe o pão do lanche")]
        [Display(Name = "Pão")]
        public string Pao { get; set; }


        [Required(ErrorMessage = "Informe o molho do lanche")]
        public string Molho { get; set; }


        [Required(ErrorMessage = "Informe o recheio do lanche")]
        public string Recheio { get; set; }


        [Required(ErrorMessage = "Informe o queijo do lanche")]
        public string Queijo { get; set; }


        [Required(ErrorMessage = "Informe a salada do lanche")]
        public string Salada { get; set; }
       
    }

   
}