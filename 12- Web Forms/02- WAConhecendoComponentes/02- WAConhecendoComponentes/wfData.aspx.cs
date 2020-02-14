using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02__WAConhecendoComponentes
{
	public partial class wfData : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
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
			cmd.CommandText = "INSERT INTO contato (nome,email) VALUES(@nome,@email)";
			cmd.Parameters.AddWithValue("nome", txbNome.Text);
			cmd.Parameters.AddWithValue("email", txbEmail.Text);
			con.Open();
			cmd.ExecuteNonQuery();
			con.Close();

			// Recarregando Lista
			DataList1.DataBind();
		}
	}
}