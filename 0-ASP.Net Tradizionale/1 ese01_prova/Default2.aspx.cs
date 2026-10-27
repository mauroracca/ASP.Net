using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Label1.Text = Request.QueryString["txtName"];
            //Request.
            // Prova lettura parametri post (aggiungere action e method sul form di pag1)
            //string nome = Request.Form["txtName"];
            //lblPag2.Text = "Benvenuto " + nome.ToUpper();
            if (Session["nome"] != null && Session["pwd"] != null)
            {
                string nome, pwd, sesso;

                nome = Session["nome"].ToString();
                pwd = Session["pwd"].ToString();
                sesso = Request.QueryString["sesso"];
                lblPag2.Text = "Benvenuto " + nome.ToUpper();
                lblPwd.Text = "La tua password è: " + pwd;
                lblSesso.Text = "Anatomicamente sei: " + sesso + " - " + Session.SessionID;
            }
            else
            {
                lblPag2.Text = "Utente non loggato";
                btnBack.Visible = true;
            }
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
}