using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _4__AspAprofundandoNosConceitos
{
    public partial class wfSalarioMinimo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Ação executada quando o index é alterado
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbPercentual.Visible = false;
            if (rbPerDesconto.SelectedIndex == 3)
            {
                txbPercentual.Visible = true;
            }
        }
    }
}