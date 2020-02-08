using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02__WAConhecendoComponentes
{
    public partial class wfDiasDeVida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Pegando a data atual
            calAtual.SelectedDate = DateTime.Now;
        }

        // Trabalhando com Calendar
        protected void Button1_Click(object sender, EventArgs e)
        {
            int diaNascimento = 0, anoNascimento = 0, mesNascimento =0;
            int diaAtual = 0, anoAtual = 0, mesAtual = 0;

            diaNascimento = calNascimento.SelectedDate.Day;
            mesNascimento = calNascimento.SelectedDate.Month*30;
            anoNascimento = calNascimento.SelectedDate.Year*365;

            diaAtual = calAtual.SelectedDate.Day;
            mesAtual = calAtual.SelectedDate.Month*30;
            anoAtual = calAtual.SelectedDate.Year*365;

            int total = (diaAtual + mesAtual + anoAtual) - (diaNascimento + mesNascimento + anoNascimento);
            lbResultado.Text = $"Dias de vida: {total}";
        }
    }
}