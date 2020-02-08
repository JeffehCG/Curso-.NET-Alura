using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02__WAConhecendoComponentes
{
    public partial class wfWizard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Wizard1.ActiveStepIndex = 0;
            }
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            // Pegando Dados Basicos
            //var nome = ((TextBox)Wizard1.WizardSteps[0].FindControl("txbNome")).Text;
            var nome = txbnome.Text;
            var cpf = txbCpf.Text;
            var rg = txbRg.Text;

            // Pegando dados Endereço
            //var cep = ((TextBox)Wizard1.WizardSteps[1].FindControl("txbCpf")).Text;
            var cep = txbCpf;
            var estado = txbEstado;
            var cidade = txbCidade;
            var rua = txbRua;
            var bairro = txbBairro;

            Wizard1.Visible = false;
            Response.Write("<h1>Dados do formulario Wizard</h1>");
            Response.Write($"<h3>Nome: {nome}</h3>");
            Response.Write($"<h3>CPF: {cpf}</h3>");
            Response.Write($"<h3>RG: {rg}</h3>");
            Response.Write($"<h3>CEP: {cep}</h3>");
            Response.Write($"<h3>Estado: {estado}</h3>");
            Response.Write($"<h3>Cidade: {cidade}</h3>");
            Response.Write($"<h3>Rua: {rua}</h3>");
            Response.Write($"<h3>Bairro: {bairro}</h3>");
        }
    }
}