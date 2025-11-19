using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace market
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Server.Execute("executeLogin.aspx");
            if ((bool)Session["autenticato"])
            {
                Response.Redirect("market.aspx");
            }
            else
                lblError.Text = "Errore di autenticazione";
        }
    }
}