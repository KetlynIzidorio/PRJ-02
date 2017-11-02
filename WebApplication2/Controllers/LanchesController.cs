using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Controllers.Usuarios_DAO;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LanchesController : Controller
    {
        LanchesDAO lanchesDAO = new LanchesDAO();
        public static List<Lanches> listaLanches = new List<Lanches>();

        // GET: Lanches
        public ActionResult Index()
        {
            listaLanches = lanchesDAO.List();
            return View(listaLanches);
          
        }

        public ActionResult Cardapio()
        {
            listaLanches = lanchesDAO.List();
            return View(listaLanches);

        }

        // GET: Lanches/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lanches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lanches/Create
        [HttpPost]
        public ActionResult Create(Lanches lanches)
        {
            try
            {
                listaLanches.Add(lanches);
                lanchesDAO.Create(lanches);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lanches/Edit/5
        public ActionResult Edit(int id)
        {
            var lanches = listaLanches.Single(p => p.Id == id);
            return View(lanches);
        }

        // POST: Lanches/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var lanches = listaLanches.Single(p => p.Id == id);
                if (TryUpdateModel(lanches))
                {
                    lanchesDAO.Edit(lanches);
                    return RedirectToAction("Index");
                }

                return View(lanches);
            }
            catch
            {
                return View();
            }
        }

        // GET: Lanches/Delete/5
        public ActionResult Delete(int id)
        {
            var lanches = listaLanches.Single(p => p.Id == id);
            return View(lanches);
        }

        // POST: Lanches/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Lanches lanches)
        {
            try
            {
                listaLanches.Remove(lanches);
                lanchesDAO.Delete(lanches);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
