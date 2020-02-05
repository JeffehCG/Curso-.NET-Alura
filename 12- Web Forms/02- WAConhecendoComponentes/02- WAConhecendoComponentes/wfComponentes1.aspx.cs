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
            if(txtSite.Text != "" && txtEndereco.Text != "")
            {
                //dlSite.Items.Add(txtSite.Text);

                // Primeiro parametro texto, segundo valor
                ListItem item = new ListItem(txtSite.Text, txtEndereco.Text);
                lbEndereco.Items.Add(item);
                txtSite.Text = "";
                txtEndereco.Text = "";
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Retorno no txt o item selecionado
        protected void btSelecionar_Click(object sender, EventArgs e)
        {
            //ListItem item = dlSite.SelectedItem;
            //txtSite.Text = item.Text;
            //ListItem item2 = lbEndereco.SelectedItem;
            //txtEndereco.Text = item2.Value;

            // Para utilizar uma List Box com multiplos itens selecionados deve ativar na propriedades SelectionMode 
            dlSite.Items.Clear();
            ListItem item;
            for (int i = 0; i < lbEndereco.Items.Count; i++)
            {
                item = lbEndereco.Items[i];
                // Adicionando ao DropDown os itens selecionados
                if (item.Selected)
                {
                    item.Selected = false;
                    dlSite.Items.Add(item);
                }
            }
        }
    }
}