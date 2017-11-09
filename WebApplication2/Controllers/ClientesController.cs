using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Controllers.Usuarios_DAO;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ClientesController : Controller
    {
        ClientesDAO clientesDAO = new ClientesDAO();
        public static List<Clientes> listaClientes = new List<Clientes>();
        // GET: Clientes
        public ActionResult Index(/*int pagina =1, int tamanhoPagina = 10*/)
        { 
            listaClientes = clientesDAO.List();   /*.(Skip(tamanhoPagina * (pagina - 1)).Take(tamanhoPagina))*/
            return View(listaClientes);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Clientes clientes)
        {
            try
            {
                listaClientes.Add(clientes);
                clientesDAO.Create(clientes);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
           
            var clientes = listaClientes.Single(p => p.Id == id);
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var clientes = listaClientes.Single(p => p.Id == id);
                if (TryUpdateModel(clientes))
                {
                    clientesDAO.Edit(clientes);
                    return RedirectToAction("Index");
                }
                return View(clientes);
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var clientes = listaClientes.Single(p => p.Id == id);
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(Clientes clientes)
        {
            try
            {
                listaClientes.Remove(clientes);
                clientesDAO.Delete(clientes);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
