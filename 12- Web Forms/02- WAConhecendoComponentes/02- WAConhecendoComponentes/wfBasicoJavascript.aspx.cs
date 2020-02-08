using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02__WAConhecendoComponentes
{
    public partial class wfBasicoJavascript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Adiciona um evento associado a uma função do javascript
            Button1.Attributes.Add("onClick", "ExibeMensagem()");
        }
    }
}