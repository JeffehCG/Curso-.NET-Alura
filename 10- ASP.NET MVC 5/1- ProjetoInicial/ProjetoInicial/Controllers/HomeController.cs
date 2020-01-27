using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// Controllers iram cuidar e tratar requisições web da API
// Para criar uma controller clique com o botão direito na pasta controllers/Add/Controller
namespace ProjetoInicial.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // Para criar uma view para o metodo abaixo clique com o botão direito em cima de Index() , Add View
        public ActionResult Index()
        {
            return View();
        }
    }
}