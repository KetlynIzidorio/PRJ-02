using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Controllers.Usuarios_DAO;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AvaliacaoController : Controller
    {
        AvaliacaoDAO avaliacaoDAO = new AvaliacaoDAO();
        public static List<Avaliacao> listaAvaliacao = new List<Avaliacao>();

        // GET: Avaliacao
        public ActionResult Index()
        {
            listaAvaliacao = avaliacaoDAO.List();
            return View(listaAvaliacao);
        }

        // GET: Avaliacao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Avaliacao/Create
        public ActionResult Avaliacao()
        {
            return View();
        }

        // POST: Avaliacao/Create
        [HttpPost]
        public ActionResult Avaliacao(Avaliacao avaliacao)
        {
            try
            {
                listaAvaliacao.Add(avaliacao);
                avaliacaoDAO.Avaliacao(avaliacao);
                return RedirectToAction("avaliacao");
            }
            catch
            {
                return View();
            }
        }

        // GET: Avaliacao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Avaliacao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Avaliacao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Avaliacao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
