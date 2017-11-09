using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Controllers.Usuarios_DAO;
using System.Web.Security;

namespace WebApplication2.Controllers
{
    public class HomeController : GlobalController
    {

        public int ClienteId { get; set; }
        public string Nome { get; set; }



        AdministradorDAO administradorDAO = new AdministradorDAO();
        public static List<Administrador> administrador = new List<Administrador>();

        ClientesDAO clienteDAO = new ClientesDAO();
        public static List<Clientes> clientes = new List<Clientes>();

        FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
        public static List<Funcionario> funcionario = new List<Funcionario>();

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.tipoUsuario = new SelectList
                (
                    new Login().ListaLogin(),
                    "Id",
                    "TipoUsuario"
                );
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.Login model, string returnUrl)
        {

            ViewBag.tipoUsuario = new SelectList
                               (
                                   new Login().ListaLogin(),
                                   "Id",
                                   "TipoUsuario"
                               );

            switch (model.TipoUsuario)
            {
                case "1":
                    administrador = administradorDAO.List();
                    var admin = administrador.FirstOrDefault(p => p.userAdministrador == model.nomeUsuario
                                                    && p.senhaAdministrador == model.senhaUsuario);

                    if (admin == null)
                    {
                        ViewBag.Error = "Login ou Senha Inválido.";
                        return View();
                    }
                    FormsAuthentication.SetAuthCookie(model.nomeUsuario, true);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Administrador");
                    }
                    break;
                case "2":
                    clientes = clienteDAO.List();
                    var cliente = clientes.FirstOrDefault(p => p.userClientes == model.nomeUsuario
                                                    && p.senhaClientes == model.senhaUsuario);

                    if (cliente == null)
                    {
                        ViewBag.Error = "Login ou Senha Inválido.";
                        return View();
                    }
                    FormsAuthentication.SetAuthCookie(model.nomeUsuario, true);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "AreaCliente");
                    }
                    break;
                case "3":
                    funcionario = funcionarioDAO.List();
                    var func = funcionario.FirstOrDefault(p => p.userFuncionario == model.nomeUsuario
                                                    && p.senhaFuncionario == model.senhaUsuario);

                    if (func == null)
                    {
                        ViewBag.Error = "Login ou Senha Inválido.";
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Index", "AreaCliente");
                    }
                    break;
                default:
                    ViewBag.Error = "Login ou Senha Inválido.";
                    return View();
            }

            FormsAuthentication.SetAuthCookie(model.nomeUsuario, true);

            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Administrador");
            }
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}