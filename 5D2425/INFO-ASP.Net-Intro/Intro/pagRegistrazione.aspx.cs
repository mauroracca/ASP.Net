using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intro
{
    public partial class pagRegistrazione : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Lettura parametri GET
            //lblNome.Text = Request.QueryString["txtUsername"];
            //lblPwd.Text = Request.QueryString["password"];
            //lblSex.Text = Request.QueryString["comboSesso"];

            // Lettura parametri POST
            lblNome.Text = Request.Form["txtUsername"];
            lblPwd.Text = Request.Form["password"];
            lblSex.Text = Request.Form["comboSesso"];

            // Lettura parametri GET Response.Redirect
            //lblNome.Text = Request.QueryString["txtUsername"];
            //lblPwd.Text = Request.QueryString["password"];
            //lblSex.Text = Request.QueryString["comboSesso"];
        }
    }
}