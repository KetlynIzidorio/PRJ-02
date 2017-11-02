using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Controllers.Usuarios_DAO;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class IngredientesController : Controller
    {
        IngredientesDAO ingredientesDAO = new IngredientesDAO();
        public static List<Ingredientes> listaIngredientes = new List<Ingredientes>();
       

        // GET: Ingredientes
        public ActionResult Index()
        {
            listaIngredientes = ingredientesDAO.List();
            return View(listaIngredientes);
        }

        // GET: Ingredientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ingredientes/Create
        public ActionResult Create()
        {
           
            ViewBag.Id = new SelectList("Id", "Selecione uma Categoria");
            return View();
        }

        // POST: Ingredientes/Create
        [HttpPost]
        public ActionResult Create(Ingredientes ingredientes, string Id )
        {
            

            try
            {
              
                listaIngredientes.Add(ingredientes);
                ingredientesDAO.Create(ingredientes);
               
                return RedirectToAction("Index");
              
            }
            catch
            {
                return View();
            }
        }

        // GET: Ingredientes/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.tipo = new SelectList(listaIngredientes, "Id", "tipo");
            string valorRequest = Request["tipo"];
            var ingredientes = listaIngredientes.Single(p => p.Id == id);
            return View(ingredientes);
        }

        // POST: Ingredientes/Edit/5
        [HttpPost]
        public ActionResult Edit(Ingredientes ingredientes)
        {
            try
            {
                
                if (TryUpdateModel(ingredientes))
                {
                    
                    ingredientesDAO.Edit(ingredientes);
                    return RedirectToAction("Index");
                }

                return View(ingredientes);
            }
            catch
            {
                return View();
            }
        }


        // GET: Ingredientes/Delete/5
        public ActionResult Delete(int id)
        {
            var ingredientes = listaIngredientes.Single(p => p.Id == id);
            return View(ingredientes);
        }

        // POST: Ingredientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Ingredientes ingredientes)
        {
            try
            {
                listaIngredientes.Remove(ingredientes);
                ingredientesDAO.Delete(ingredientes);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
