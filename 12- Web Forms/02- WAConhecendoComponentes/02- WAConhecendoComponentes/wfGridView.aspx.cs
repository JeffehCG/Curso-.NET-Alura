using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02__WAConhecendoComponentes
{
    public partial class wfGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Quando o item é selecionado, sera alterado o indice do Details View
            DetailsView1.Visible = true;
            DetailsView1.PageIndex = (GridView2.PageIndex * GridView2.PageSize) + GridView2.SelectedIndex;
        }
    }
}