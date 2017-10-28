using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class FuncionarioController : Controller
    {
        FuncionarioDAO funcionarioDAO = new FuncionarioDAO ();
        public static List<Funcionario> listaFuncionario = new List<Funcionario>();

        // GET: Funcionario
        public ActionResult Index()
        {
            listaFuncionario = funcionarioDAO.List();
            return View(listaFuncionario);
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Funcionario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionario/Create
        [HttpPost]
        public ActionResult Create(Funcionario funcionario)
        {
            try
            {         
                listaFuncionario.Add(funcionario);
                funcionarioDAO.Create(funcionario);
                return RedirectToAction("Index");
  
            }
            catch
            {
                return View();
            }
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int id)
        {
           
            var funcionario = listaFuncionario.Single(p => p.Id == id);
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                

                var funcionario = listaFuncionario.Single(p => p.Id == id);
                if (TryUpdateModel(funcionario))
                {
                    funcionarioDAO.Edit(funcionario);
                    return RedirectToAction("Index");
                }

                return View(funcionario);
            }
            catch
            {
                return View();
            }
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int id)
        {
            var funcionario = listaFuncionario.Single(p => p.Id == id);
            return View(funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Funcionario funcionario)
        {
            try
            {
                listaFuncionario.Remove(funcionario);
                funcionarioDAO.Delete(funcionario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
