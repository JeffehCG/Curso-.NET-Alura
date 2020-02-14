using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3__WaAgenda
{
    public partial class usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Para tratar eventos do SqlDataSource,clique em cima dele em designer, va nas propriedades, e no simbolo de raio para verificar eventos
        protected void SqlDataSourceUsuario_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            // Tratando erros ao inserir registro pelo SqlDataSource
            if (e.Exception != null)
            {
                lMsg.Text = e.Exception.Message;
                // Definindo que o erro já foi tratado
                e.ExceptionHandled = true;
            }
        }

        protected void SqlDataSourceUsuario_Updated(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                lMsg.Text = e.Exception.Message;
                e.ExceptionHandled = true;
            }
        }
    }
}