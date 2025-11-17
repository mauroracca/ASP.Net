using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace provaParam
{
    public partial class pag2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Parametri get
                string nome = Request.QueryString["nome"];
                string pwd = Request.QueryString["pwd"];
                string sex = Request.QueryString["comboSesso"];
                //Parametri post
                //string nome = Request.Form["nome"];
                //string pwd = Request.Form["pwd"];
                //string sex = Request.Form["comboSesso"];
                if (!string.IsNullOrEmpty(nome))
                {
                    lblNome.InnerText = "Ciao, " + nome + "! La tua password è: "+pwd+". Sei un individuo: "+sex;
                }
                else
                {
                    lblNome.InnerText = "Nome non fornito.";
                }
            }
        }
    }
}