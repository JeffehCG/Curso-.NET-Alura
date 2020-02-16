using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _4__AspAprofundandoNosConceitos
{
    public partial class wfFilmes : System.Web.UI.Page
    {
        public List<String> Filmes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btInserir_Click(object sender, EventArgs e)
        {
            ddlFilmes.Items.Add(new ListItem(txbFilme.Text, txbFilme.Text));
        }

        protected void btEnviar_Click(object sender, EventArgs e)
        {
            Filmes = new List<string>();
            // Adicionando a lista de filmes na propriedade Filmes
            foreach (ListItem item in ddlFilmes.Items)
            {
                Filmes.Add(item.Text);
            }

            // O botão esta com a propriedade PostBackUrl, assim todos dados dessa pagina seram enviados para wfFilmesResposta.aspx
        }
    }
}