using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intro
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)  // primo caricamento della pagina
            {
                // operazioni da svolgere la prima volta che carico la pagina
            }
            else
            {
                // successive volte che la pagina viene caricata
            }
        }

        protected void btnInvia_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnAsp_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || password.Text == "")
            {
                lblCampi.Text = "Campi incompleti";
                lblCampi.Visible = true;
            }
            else
            {
                Session["user"] = txtUsername.Text;
                lblCampi.Visible = false;
                Response.Redirect("pagRegistrazione.aspx?txtUsername="+txtUsername.Text+"&password="+password.Text+ "&comboSesso="+comboSesso.Text);
            }
        }
    }
}