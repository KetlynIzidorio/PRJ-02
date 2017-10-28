using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(Administrador objUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (Administrador adm = new Administrador)
        //        {
        //            var obj = Administrador(a => a.userAdministrador(objUser.userAdministrador) && a.senhaAdministrador.Equals(objUser.senhaAdministrador)).FirstOrDefault();
        //            if (obj != null)
        //            {
        //                Administrador objlogin = new Administrador();
        //                objlogin["userAdministrador"] = obj.userAdministrador.ToString();
        //                objlogin["senhaAdministrador"] = obj.senhaAdministrador.ToString();
        //                return RedirectToAction("UserDashBoard");
        //            }
        //        }
        //    }
        //    return View(objUser);
        //}

        //public ActionResult UserDashBoard()
        //{
        //    if (Session["UserID"] != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //}
    }
}