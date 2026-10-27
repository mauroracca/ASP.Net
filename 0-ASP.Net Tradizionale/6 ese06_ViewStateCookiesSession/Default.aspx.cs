using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public string str = "Ciao Ciccio";
    protected void Page_Load(object sender, EventArgs e)
    {
        // Page.DataBind();
        if (!Page.IsPostBack)
        {
            int contaVisite = Convert.ToInt32(Application["cont"]);
            Application.Lock();
            contaVisite++;
            Application["cont"] = contaVisite;
            Application.UnLock();
            cboCategoria.Items.Add("Utilitarie");
            cboCategoria.Items.Add("SUV");
            cboCategoria.Items.Add("Berline");
            cboCategoria.Items.Add("Station Wagon");
        }
    }
    protected void btnViewState_Click(object sender, EventArgs e)
    {
        ViewState["myViewState"] = "myVS";
    }
    protected void btnCookies_Click(object sender, EventArgs e)
    {
        Response.Cookies["myCookies"].Value = "myCookies";
    }
    protected void btnSession_Click(object sender, EventArgs e)
    {
        Session["mySession"] = "mySession";
        Session["var2"] = "var sessione 2";
    }
    protected void btnVedi_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Write("ViewState: " + ViewState["myViewState"]);
            Response.Write("<br/>Cookies: " + Request.Cookies["myCookies"].Value);
            Response.Write("<br/>Session: " + Session["mySession"]);
            Response.Write("<br/>SessionID: " + Session.SessionID);
            Response.Write("<br/>Visite: " + Application["cont"]);
        }
        catch (Exception ex)
        {
            Response.Write("<br/>"+ex.Message);
        }
    }
    protected void btnPag2_Click(object sender, EventArgs e)
    {
        ViewState["myViewState"] = "myVS";
        Response.Cookies["myCookies"].Value = "myCookies";
        Session["mySession"] = "mySession";
        Response.Redirect("Default2.aspx");
    }


    protected void btnApplication_Click(object sender, EventArgs e)
    {
        Session.Abandon();
    }
}