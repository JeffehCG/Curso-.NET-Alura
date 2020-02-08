using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02__WAConhecendoComponentes
{
    public partial class wfParOuImparFatorial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Adicionando itens ao BulletedList
            List<ListItem> dadosBullet = new List<ListItem>();
            dadosBullet.Add(new ListItem("Par ou Impar"));
            dadosBullet.Add(new ListItem("Calcula o Fatorial"));
            blLista.DataSource = dadosBullet;
            blLista.DataBind();

            // Adicionando itens ao RadioButtonList
            if (!IsPostBack)
            {
                List<ListItem> dadosRadio = new List<ListItem>();
                dadosRadio.Add(new ListItem("Par ou Impar"));
                dadosRadio.Add(new ListItem("Calcula o Fatorial"));
                radioButtonList.DataSource = dadosRadio;
                radioButtonList.DataBind();
            }    
        }

        protected void blLista_Click(object sender, BulletedListEventArgs e)
        {
            // DisplayMode = "LinkButton"
            // Para que os itens do BulletedList sejam clicaveis
            // Indentificando item clicado pelo index, e exibindo o mesmo
            switch (e.Index)
            {
                case 0:
                    pnParOuImpar.Visible = !pnParOuImpar.Visible;
                    break;
                case 1:
                    pnFatorial.Visible = !pnFatorial.Visible;
                    break;
                default:
                    break;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int numero = Convert.ToInt32(txtValorPn1.Text);

            string texto = numero % 2 != 0 ? "O numero é Impar" : "O numero é par";

            lResp1.Text = texto;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int numero = Convert.ToInt32(txtValorPn2.Text);
            try
            {
                if (numero < 0)
                {
                    lResp2.Text = "Informe apenas numeros positivos";
                }
                else if (numero == 0)
                {
                    lResp2.Text = "0! = 1";
                }
                else
                {
                    int fatorial = numero;
                    for (int i = numero - 1; i > 0; i--)
                    {
                        fatorial = fatorial * i;
                    }
                    lResp2.Text = $"O fatorial é: {fatorial}";
                }
            }
            catch (Exception)
            {
                lResp2.Text = "Permitido apenas numeros";
            }     
        }

        protected void radioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Para que funcione o radioButtonList tem que ter 'AutoPostBack="True"'
            pnParOuImpar.Visible = false;
            pnFatorial.Visible = false;
            if (radioButtonList.SelectedIndex == 0)
            {
                pnParOuImpar.Visible = true;      
            }
            else
            {
                pnFatorial.Visible = true;           
            }
        }
    }
}