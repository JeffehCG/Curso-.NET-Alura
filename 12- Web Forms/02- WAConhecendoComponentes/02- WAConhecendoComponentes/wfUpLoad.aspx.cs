using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02__WAConhecendoComponentes
{
    public partial class wfUpLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btEnviar_Click(object sender, EventArgs e)
        {
            String nome = fuArquivo.FileName;
            txbNome.Text = nome;

            String tamanho = fuArquivo.PostedFile.ContentLength.ToString();
            txbTamanho.Text = tamanho;

            // Pegando o caminho da pasta dentro do servidor
            String caminho = Server.MapPath(@"Uploads\");
            // Salvando arquivo enviado
            fuArquivo.PostedFile.SaveAs(caminho + nome);
        }

        protected void btEnviarMultiplos_Click(object sender, EventArgs e)
        {
            String nome = "";
            // Pegando o caminho da pasta dentro do servidor
            // Salvando multiplos arquivos enviado
            String caminho = Server.MapPath(@"Uploads\");
            for (int i = 0; i < fuArquivo.PostedFiles.Count; i++)
            {
                nome = nome + fuArquivo.PostedFiles[i].FileName + " - ";
                fuArquivo.PostedFiles[i].SaveAs(caminho + fuArquivo.PostedFiles[i].FileName);
            }
            txbNome.Text = nome;
        }
    }
}