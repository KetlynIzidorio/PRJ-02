using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Funcionario
    {
        [Required(ErrorMessage = "Informe o id do Funcionário")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do Funcionário")]
        [Display(Name = "Nome")]
        public string nomeFuncionario { get; set; }

        [Required(ErrorMessage = "Informe o cargo do Funcionário")]
        [Display(Name = "Cargo")]
        public string cargoFuncionario { get; set; }

        [Required(ErrorMessage = "Informe o user do Funcionário")]
        [Display(Name = "User")]
        public string userFuncionario { get; set; }

        [Required(ErrorMessage = "Informe a senha do Funcionário")]
        [Display(Name = "Senha")]
        public string senhaFuncionario { get; set; }

      
    }
}