using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["nome"] = "";
        Session["pwd"] = "";
        lblTitolo.Text = "Pagina di prova ASP.Net";
        lblNome.Visible = false;
        lblCampi.Visible = false;
        if (Page.IsPostBack)
        {
            //lblNome.Text = "Benvenuto " + txtName.Text;
            lblNome.Text = "Benvenutoooooooooo " + Request.Form["txtName1"]; 
            lblNome.Visible = true;
        }
    }

    protected void btnInvia_Click(object sender, EventArgs e)
    {
        Response.Redirect("default2.aspx");
        //if (txtName.Text != ""  && txtPwd.Text != "" )
        //{
        //    Session["nome"] = txtName.Text.Trim();
        //    Session["pwd"] = txtPwd.Text.Trim();
        //    Response.Redirect("default2.aspx");
        //    lblNome.Visible = false;
        //    lblCampi.Visible = false;
        //}
        //else
        //{
        //    lblCampi.Text = "Campi incompleti";
        //    lblCampi.Visible = true;
        //    lblNome.Visible=false;
        //}
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}