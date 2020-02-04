using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Autenticar(string login, string senha)
        {
            // Usuario de Acesso
            // Login : caelum
            // Senha: caelum
            UsuariosDAO dao = new UsuariosDAO();
            Usuario usuario = dao.Busca(login, senha);

            if (usuario != null)
            {
                Session["usuarioLogado"] = usuario.Nome;
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}