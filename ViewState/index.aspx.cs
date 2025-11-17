using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewState
{
    public partial class index : System.Web.UI.Page
    {
        int valore=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["contatore"] = 0;
                lblContatore.Text = "Contatore: " + ViewState["contatore"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            valore = (int)ViewState["contatore"];
            valore++;
            ViewState["contatore"] = valore;
            lblContatore.Text = "Contatore: " + valore.ToString();
        }

        protected void btnAzzera_Click(object sender, EventArgs e)
        {
            ViewState["contatore"] = 0;
            lblContatore.Text = "Contatore: "+ ViewState["contatore"];
        }
    }
}