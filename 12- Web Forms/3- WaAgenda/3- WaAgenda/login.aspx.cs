using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3__WaAgenda
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btLogar_Click(object sender, EventArgs e)
        {
            String email = txbEmail.Text;
            String senha = txbSenha.Text;

			// Acessando Web.config
			System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
			System.Configuration.ConnectionStringSettings connString;
			// Pegando a string de conexão no do web.config
			connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
			SqlConnection con = new SqlConnection();
			con.ConnectionString = connString.ToString();

			// Procurando usuario
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = con;
			cmd.CommandText = "SELECT * FROM usuario WHERE email = @email AND senha = @senha";
			cmd.Parameters.AddWithValue("email", txbEmail.Text);
			cmd.Parameters.AddWithValue("senha", txbSenha.Text);

			// Pegando dados retornados do Select
			con.Open();
			SqlDataReader registro = cmd.ExecuteReader();
			if (registro.HasRows)
			{
				// Para efetuar a leitura dos registros retornados
				// registro.Read();

				// Trabalhando com Coockies
				// Esta sendo feito a validação da autenticação em MasterPagePrincipal
				HttpCookie login = new HttpCookie("login", txbEmail.Text);
				Response.Cookies.Add(login);

				// Direcionar para pagina principal
				Response.Redirect("~/index.aspx");
			}
			else
			{
				// Escrevendo script na pagina
				Response.Write("<script> alert('Error', 'Email ou senha incorretos!!'); </script>");
			}
			con.Close();
		}
    }
}