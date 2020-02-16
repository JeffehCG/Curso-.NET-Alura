using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _4__AspAprofundandoNosConceitos
{
    public partial class wfSalarioMinimoResposta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<h1>Objeto Request</h1>");

            // Recuperando dados passados por outra pagina "Request["txbSalarioBruto"]"
            // Pegando por POST ou GET
            Response.Write($"<h3>Salario Bruto: {Request["txbSalarioBruto"]}</h3>");
            // Pegando apenas por POST
            Response.Write($"<h3>Percentual Desconto: {Request.Form["txbPercentual"]}</h3>");
            // Pegando apenas por GET
            Response.Write($"<h3>Nome: {Request.QueryString["nome"]}</h3>");
            // Pegando o componente completo passado pela outra pagina, e não apenas o valor
            RadioButtonList radioButton = Page.PreviousPage != null ?(RadioButtonList)Page.PreviousPage.FindControl("rbPerDesconto") : new RadioButtonList();

            // Voltando para pagina anterios caso valores sejam invalidos
            if (String.IsNullOrEmpty(Request.Form["txbSalarioBruto"]) || (String.IsNullOrEmpty(Request.Form["txbPercentual"]) && radioButton.SelectedIndex == 3))
            {
                Response.Redirect("~/wfSalarioMinimo.aspx");
            }

            // Calculando Salario
            Double salarioBruto = Convert.ToDouble(Request.Form["txbSalarioBruto"]);
            Double percentualDesc;
            if (radioButton.SelectedIndex != 3)
            {
                percentualDesc = Convert.ToDouble(radioButton.SelectedItem.Value);
            }
            else
            {
                percentualDesc = Convert.ToDouble(Request.Form["txbPercentual"]);
            }
            Double desconto = (salarioBruto * percentualDesc) / 100;
            Double salarioLiquido = salarioBruto - desconto;

            Table tabela = new Table();
            TableRow linha = new TableRow();
            TableCell coluna = new TableCell();

            // Salario Bruto
            coluna.Text = "Salario Bruto:";
            linha.Cells.Add(coluna);
            coluna = new TableCell();
            coluna.Text = salarioBruto.ToString();
            linha.Cells.Add(coluna);
            tabela.Rows.Add(linha);

            // Percentual Desconto
            coluna = new TableCell();
            linha = new TableRow();
            coluna.Text = "Percentual Desconto:";
            linha.Cells.Add(coluna);
            coluna = new TableCell();
            coluna.Text = percentualDesc.ToString();
            linha.Cells.Add(coluna);
            tabela.Rows.Add(linha);

            // Salario Liquido
            coluna = new TableCell();
            linha = new TableRow();
            coluna.Text = "Salario Liquido:";
            linha.Cells.Add(coluna);
            coluna = new TableCell();
            coluna.Text = salarioLiquido.ToString();
            linha.Cells.Add(coluna);
            tabela.Rows.Add(linha);

            PlaceHolder1.Controls.Add(tabela);
        }
    }
}