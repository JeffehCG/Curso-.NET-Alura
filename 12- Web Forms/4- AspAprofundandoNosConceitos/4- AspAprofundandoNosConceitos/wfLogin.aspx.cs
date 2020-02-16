using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _4__AspAprofundandoNosConceitos
{
    public partial class wfLogin : System.Web.UI.Page
    {
        List<String> Usuarios;
        String SenhaPadrao = "1234";

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuarios = new List<string>();
            Usuarios.Add("Jefferson");
            Usuarios.Add("Rodrigo");
            Usuarios.Add("Fabio");

            // Caso já tenho um coockie, redirecionar para pagina como logado (AutoLogin)
            if (Request.Cookies["login"] != null && Session["login"] != null)
            {
                Response.Redirect("~/wfLoginAcesso.aspx");
            }
        }

        protected void btEntrar_Click(object sender, EventArgs e)
        {
            foreach (var item in Usuarios)
            {
                if (item == txbLogin.Text && SenhaPadrao == txbSenha.Text)
                {
                    // Diferença entre Coockie e Session
                    // Coockie - Salvo do lado do cliente; Session - Salvo do lado do servidor 
                    // Toda vez que o sistema é reiniciado, a Session é apagada, já o cookie não

                    // Trabalhando com Cookies
                    HttpCookie login = new HttpCookie("login", txbLogin.Text);
                    HttpCookie dataAcesso = new HttpCookie("dataAcesso", DateTime.Now.ToString());

                    // Colocando tempo do expiração do coockie
                    login.Expires = DateTime.Now.AddDays(1);
                    dataAcesso.Expires = DateTime.Now.AddDays(1);

                    Response.Cookies.Add(login);
                    Response.Cookies.Add(dataAcesso);

                    // Trabalhando com Session
                    Session["login"] = txbLogin.Text;

                    Response.Redirect("~/wfLoginAcesso.aspx");
                }
            }
        }
    }
}