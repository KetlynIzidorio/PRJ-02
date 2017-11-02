using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class Ingredientes
    {
        public int Id { get; set; }

        [Display(Name = "Tipo")]
        public string tipo  { get; set; }

        [Display(Name = "Nome do Ingrediente")]
        public string nome { get; set; }

     

    }
  

}