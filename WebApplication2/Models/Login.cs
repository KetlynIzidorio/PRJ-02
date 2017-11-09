using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string TipoUsuario { get; set; }

        public List<Login> ListaLogin()
        {
            return new List<Login>
            {
                new Login { Id = 1,TipoUsuario = "Administrador"},
                new Login { Id = 2, TipoUsuario = "Cliente"},
                new Login { Id = 3, TipoUsuario = "Funcioanrio"}
            };
        }

        [Display(Name = "Nome")]
        public string nomeUsuario { get; set; }

        [Display(Name = "Email")]
        public string emailUsuario { get; set; }

        [Display(Name = "User")]
        public string user { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string senhaUsuario { get; set; }
    }
}