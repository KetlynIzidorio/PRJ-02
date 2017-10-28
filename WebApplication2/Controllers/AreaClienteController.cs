using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Controllers.Usuarios_DAO;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AreaClienteController : Controller
    {
        AvaliacaoDAO avaliacaoDAO = new AvaliacaoDAO();
        public static List<Avaliacao> listaAvaliacao = new List<Avaliacao>();
        // GET: AreaCliente
        public ActionResult Index()
        {
            return View();
        }

        // GET: AreaCliente/Create
        public ActionResult Avaliacao()
        {
            return View();
        }

        // POST: AreaCliente/Create
        [HttpPost]
        public ActionResult Avaliacao(Avaliacao avaliacao)
        {
            try
            {
                listaAvaliacao.Add(avaliacao);
                avaliacaoDAO.Avaliacao(avaliacao);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      
    }
}
