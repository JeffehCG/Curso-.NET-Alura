using LojaRazor.DAO;
using LojaRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaRazor.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Form(string email)
        {
            Usuario u = new Usuario()
            {
                Email = email
            };
            return View(u);
        }

        public ActionResult Cadastra(Usuario usuario)
        {
            // Verificando se o usuario é valido
            if (ModelState.IsValid)
            {
                UsuariosDAO dao = new UsuariosDAO();
                dao.Adiciona(usuario);
                Session["usuarioLogado"] = usuario.Nome;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Caso não seja valido, retorna para view form o usuario enviado
                return View("Form", usuario);
            }
        }

    }
}
