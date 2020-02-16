using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _4__AspAprofundandoNosConceitos
{
    public partial class wfLoginAcesso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Recuperando dados do cookies
            lbLogin.Text = "";
            if(Request.Cookies["login"] != null)
            {
                lbLogin.Text = Request.Cookies["login"].Value;
            }

            // Permitindo acesso a essa pagina apenas com o login efetuado
            if (Session["login"] == null)
            {
                Response.Redirect("~/wfLogin.aspx");
            }
            else
            {
                // Pegando o ID da sessão
                lbIdSession.Text = $"Session ID: {Session.SessionID}";
                
                if(Session["contador"] == null)
                {
                    Session["contador"] = 0;
                }
                lbContador.Text = $"Contador Session: {Session["contador"]}";
            }

            // Trabalhando com Aplicação
            // Diferente da Session, que é compartilhada apenas com um usuario, a Application é compartilhada com todos usuarios
            // Exemplo de utilização "Um contador exibindo a quantidade de usuarios logados no site"
            if (Application["contador"] == null)
            {
                Application["contador"] = 0;
            }
            lbContadorAplicacao.Text = $"Contador Application: {Application["contador"]}";
        }

        protected void btLogout_Click(object sender, EventArgs e)
        {
            // Remove apenas o Coockie selecionado
            Request.Cookies.Remove("login");
            // Remove todos Coockies
            Request.Cookies.Clear();
            // Obs: As requisições acima só apagam os cookies do servidor, e não do browser, ou seja, quando a pagina for recarregado, os cookies seram pegos denovo

            // Tecnica utilizada para remover completamente o coockie (Colocando data de expiração como um dia anterior, assim o browser exclui o mesmo)
            Response.Cookies["login"].Expires = DateTime.Now.AddDays(-1);
        }

        protected void btListar_Click(object sender, EventArgs e)
        {
            var keys = Request.Cookies.AllKeys;
            string texto = "";
            for (int i = 0; i < Request.Cookies.Count; i++)
            {
                texto += $"<p> {keys[i]}: {Request.Cookies[keys[i]].Value}</p> </br>";
            }
            Response.Write(texto);
        }

        protected void btAdicionarS_Click(object sender, EventArgs e)
        {
            Session["contador"] = Convert.ToInt32(Session["contador"]) + 1;
        }

        protected void btRemoverS_Click(object sender, EventArgs e)
        {
            // Removendo uma sessão
            Session.Remove("contador");
            // Removendo todas sessões
            Session.RemoveAll();

            Response.Redirect("~/wfLogin.aspx");
        }

        protected void btAdicionarAplic_Click(object sender, EventArgs e)
        {
            // Lock e UnLock - Utilizados para a application não ser usada ao mesmo tempo por dois usuarios
            Application.Lock();
            Application["contador"] = Convert.ToInt32(Application["contador"]) + 1;
            Application.UnLock();
        }

        protected void btRemoverA_Click(object sender, EventArgs e)
        {
            // Removendo uma Application
            Application.Remove("contador");
            // Removendo todas Applications
            Application.RemoveAll();
        }
    }
}