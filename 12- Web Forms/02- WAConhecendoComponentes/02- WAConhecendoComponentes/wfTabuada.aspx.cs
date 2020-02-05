using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02__WAConhecendoComponentes
{
    public partial class wfTabuada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // IsPostBack = true quando a pagina é recarregada
            // Ou seja, só executa o for na primeira vez que a pagina é carregada
            if (!IsPostBack)
            {
                for (int i = 1; i < 11; i++)
                {
                    dlNumeros.Items.Add(i.ToString());
                }
            }
        }

        protected void btExecutar_Click(object sender, EventArgs e)
        {
            lbTabuada.Items.Clear();
            ListItem numeroSelecionado = dlNumeros.SelectedItem;
            int numero = Convert.ToInt32(numeroSelecionado.Value);

            // List Box
            #region Preenchendo List Box
            for (int i = 0; i < 11; i++)
            {
                int resultado = i * numero; 
                lbTabuada.Items.Add($"{i} X {numero} = {resultado}");
            }
            #endregion

            // Table
            #region Preenchendo Table
            for (int i = 0; i < 11; i++)
            {
                int resultado = i * numero;
                tbTabuada.Rows[i].Cells[0].Text = numero.ToString();
                tbTabuada.Rows[i].Cells[2].Text = i.ToString();
                tbTabuada.Rows[i].Cells[4].Text = resultado.ToString();
            }
            #endregion

            // Placeholder - utilizado para inserir qualquer codigo dentro
            // Criando estrutura tabela, e preenchendo no PlaceHolder
            #region Usando PlaceHolder
            Table tabela = new Table();
            for(int i = 0; i < 11; i++)
            {
                TableRow linha = new TableRow();
                for(int j = 0; j <= 4; j++)
                {
                    TableCell coluna = new TableCell();
                    linha.Cells.Add(coluna);
                }
                tabela.Rows.Add(linha);
            }
            for (int i = 0; i < 11; i++)
            {
                int resultado = i * numero;
                tabela.Rows[i].Cells[0].Text = numero.ToString();
                tabela.Rows[i].Cells[1].Text = "X";
                tabela.Rows[i].Cells[2].Text = i.ToString();
                tabela.Rows[i].Cells[3].Text = "=";
                tabela.Rows[i].Cells[4].Text = resultado.ToString();
            }
            PlaceHolder.Controls.Add(tabela);
            #endregion
        }
    }
}