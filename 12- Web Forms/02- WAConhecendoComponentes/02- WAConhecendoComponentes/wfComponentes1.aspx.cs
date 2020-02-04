using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02__WAConhecendoComponentes
{
    public partial class wfComponentes1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btInserir_Click(object sender, EventArgs e)
        {
            // Adicionando item ao DropDown
            if(txtSite.Text != "")
            {
                //dlSite.Items.Add(txtSite.Text);

                // Primeiro parametro texto, segundo valor
                ListItem item = new ListItem(txtSite.Text, dlSite.Items.Count.ToString());
                dlSite.Items.Add(item);
                txtSite.Text = "";
            }
        }
    }
}