using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _4__AspAprofundandoNosConceitos
{
    public partial class wfFilmesResposta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Acessando as propriedades da pagina wfFilmes com PreviousPageType
            // "<%@ PreviousPageType VirtualPath="~/wfFilmes.aspx"%>"  - essa propriedade deve estar declarada no HTML

            List<string> Filmes = PreviousPage.Filmes;
            foreach (var item in Filmes)
            {
                Response.Write($"<h2>{item}</h2>");
            }
        }
    }
}