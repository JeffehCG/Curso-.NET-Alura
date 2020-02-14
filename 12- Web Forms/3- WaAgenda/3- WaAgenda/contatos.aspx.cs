using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3__WaAgenda
{
    public partial class contatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btInserir_Click(object sender, EventArgs e)
        {
			try
			{
				if (txbEmail.Text != "" && txbNome.Text != "" && txbTelefone.Text != "")
				{
					// Acessando Web.config
					System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
					System.Configuration.ConnectionStringSettings connString;
					// Pegando a string de conexão no do web.config
					connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
					SqlConnection con = new SqlConnection();
					con.ConnectionString = connString.ToString();

					// Inserindo
					SqlCommand cmd = new SqlCommand();
					cmd.Connection = con;
					cmd.CommandText = "INSERT INTO contato (nome,email,telefone) VALUES(@nome,@email,@telefone)";
					cmd.Parameters.AddWithValue("nome", txbNome.Text);
					cmd.Parameters.AddWithValue("email", txbEmail.Text);
					cmd.Parameters.AddWithValue("telefone", txbTelefone.Text);
					con.Open();
					cmd.ExecuteNonQuery();
					con.Close();

					// Recarregando Lista
					GridView1.DataBind();
				}
				else
				{
					throw new Exception("Campos em branco");
				}
			}
			catch (Exception error)
			{

				// Escrevendo script na pagina
				Response.Write("<script> alert('Error', "+error.Message+"); </script>");
			}
		}
    }
}