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
        string id;
        id = Request.QueryString["ID"];
        if (id == "Execute") {
            //Codice di controllo del login
            HttpCookie cookLogin = new HttpCookie("login");
            cookLogin.Value = "Login OK1";
            cookLogin.Expires = DateTime.Today.AddDays(1);
            Response.Cookies.Add(cookLogin);
        }
        else
        {
            Response.Write("Pagina richiamata da un operazione di " + id);
            Response.Write("<br />Dati del browser: " + Request.ServerVariables["HTTP_USER_AGENT"]);
            Response.Write("<br />Indirizzo IP: " + Request.ServerVariables["REMOTE_ADDR"]);
            Response.Write("<br />Percorso fisico sul server di pagina2.aspx: " + Server.MapPath("Default2.aspx"));
            Response.Write("<br />Metodo con cui è stata richiamata pagina2.aspx: " + Request.ServerVariables["REQUEST_METHOD"]);
            Response.Write("<br />Pagina richiesta con questa chiamata: " + Request.ServerVariables["SCRIPT_NAME"]);
            Response.Write("<br />Valore textbox del nome: " + Request.Form["name"]);
            Response.Write("<br />Valore della input type text del cognome: " + Request.Form["txtCognome"]);
            if (id != "Redirect")
            {
                TextBox tNome = (TextBox)PreviousPage.FindControl("name");
                Response.Write("<br />Valore textbox del nome con PreviousPage.FindControl(): " + tNome.Text);
            }
            Response.Write("<br />Nome salvato nel cookie: " + Request.Cookies["cookieName"].Value);
        }
    }
}