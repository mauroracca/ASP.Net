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
        try
        {
            Response.Write("ViewState: " + ViewState["myViewState"]);
            Response.Write("<br/>Cookies: " + Request.Cookies["myCookies"].Value);
            Response.Write("<br/>Session: " + Session["mySession"]);
            Response.Write("<br/>Session2: " + Session["var2"]);
            Response.Write("<br/>SessionID: " + Session.SessionID);
        }
        catch (Exception ex)
        {
            Response.Write("<br/>" + ex.Message);
        }
    }
}