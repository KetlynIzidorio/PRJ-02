using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Usuarios_DAO
{

    public class AdministradorController : Controller
    {
        AdministradorDAO administradorDAO = new AdministradorDAO();
        public static List<Administrador> listaAdministrador = new List<Administrador>();
        // GET: Administrador
        public ActionResult Index()
        {
            listaAdministrador = administradorDAO.List();
            return View(listaAdministrador);

        }

        // GET: Administrador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrador/Create
        [HttpPost]
        public ActionResult Create(Administrador administrador)
        {
            try
            {
                listaAdministrador.Add(administrador);
                administradorDAO.Create(administrador);
                return RedirectToAction("Index");
              
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrador/Edit/5
        public ActionResult Edit(int id)
        {
            var administrador = listaAdministrador.Single(p => p.Id == id);
            return View(administrador);
        }

        // POST: Administrador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var administrador = listaAdministrador.Single(p => p.Id == id);
                if (TryUpdateModel(administrador))
                {
                    administradorDAO.Edit(administrador);
                    return RedirectToAction("Index");
                }
                return View(administrador);
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrador/Delete/5
        public ActionResult Delete(int id)
        {
            var administrador = listaAdministrador.Single(p => p.Id == id);
            return View(administrador);
        }

        // POST: Administrador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Administrador administrador)
        {
            try
            {
                listaAdministrador.Remove(administrador);
                administradorDAO.Delete(administrador);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
