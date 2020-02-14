using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3__WaAgenda
{
    public partial class MasterPagePrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificando se usuario esta Autenticado
            if (Request.Cookies["login"] != null)
            {

            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }
    }
}