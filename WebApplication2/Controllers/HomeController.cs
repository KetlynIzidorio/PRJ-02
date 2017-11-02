using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Controllers.Usuarios_DAO;



namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Login(Administrador objUser)
//        {
//            if (ModelState.IsValid)
//            {

//                //using (Administrador adm = new Administrador)
//                //{
//                Administrador Administrador = new Administrador();
                   
//                    var obj = Administrador(a => a.userAdministrador(objUser.userAdministrador) && a.senhaAdministrador.Equals(objUser.senhaAdministrador)).FirstOrDefault();
//                    if (obj != null)
//                    {
//                        Administrador objlogin = new Administrador();

//                        objlogin.userAdministrador = Administrador.userAdministrador;
//                        objlogin["senhaAdministrador"] = obj.senhaAdministrador.ToString();
//                        return RedirectToAction("Index2");
//    }
////}
//            }
//            return View(objUser);
//        }

//        public ActionResult Index2()
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