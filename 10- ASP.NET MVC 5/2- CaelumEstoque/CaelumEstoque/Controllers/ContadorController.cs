using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class ContadorController : Controller
    {
        // GET: Contador
        public ActionResult Index()
        {
            // Recuperando o valor de uma Session
            object valorSession = Session["contador"];
            int contador = Convert.ToInt32(valorSession);
            contador++;

            // Atribuindo valor a Session
            Session["contador"] = contador;
            return View(contador);
        }
    }
}