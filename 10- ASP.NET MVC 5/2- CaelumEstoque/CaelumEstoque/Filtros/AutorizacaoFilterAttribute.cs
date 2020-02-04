using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaelumEstoque.Filtros
{
    // Classe para validar Session de usuario(Assim verificando se esta logado)
    // Deve herdar de ActionFilterAttribute
    public class AutorizacaoFilterAttribute: ActionFilterAttribute
    {
        // Sobrescrevendo metodo (O mesmo é executado antes da execução de uma Action de uma controller)

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuario = filterContext.HttpContext.Session["usuarioLogado"];

            // Caso o usuario não esteja logado, impedir a execução da ActionResult, e redirecionalo para tela de login
            if (usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Login", action = "Index" }
                    )
                );
            }
        }
    }
}