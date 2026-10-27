using System;

public partial class Pagina2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Il parametro "metodo" indica quale dei tre form ha generato la richiesta:
            // - "GET"   -> i dati arrivano in Request.QueryString (form HTML method="get")
            // - "POST"  -> i dati arrivano in Request.Form (form HTML method="post")
            // - "CLICK" -> i dati arrivano in Request.QueryString (Response.Redirect da code-behind)
            string metodo = Request.QueryString["metodo"];
            if (string.IsNullOrEmpty(metodo))
            {
                metodo = Request.Form["metodo"];
            }

            string nome="", cognome="", email="";

            if (metodo == "POST")
            {
                nome = Request.Form["nome"];
                cognome = Request.Form["cognome"];
                email = Request.Form["email"];
            }
            else if (metodo == "POSTBACKURL")
            {
                // Lettura dal body del POST (Request.Form): i name sono gli ID dei controlli asp:TextBox
                //nome = Request.Form["txtNome"];
                //cognome = Request.Form["txtCognome"];
                //email = Request.Form["txtEmail"];

                // --- Alternativa con PreviousPage + FindControl ---
                if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
                {
                    nome = ((System.Web.UI.WebControls.TextBox)PreviousPage.FindControl("txtNome")).Text;
                    cognome = ((System.Web.UI.WebControls.TextBox)PreviousPage.FindControl("txtCognome")).Text;
                    email = ((System.Web.UI.WebControls.TextBox)PreviousPage.FindControl("txtEmail")).Text;
                }

                // --- Alternativa tipizzata con PreviousPage ---
                // Richiede in Pagina2.aspx la direttiva: <%@ PreviousPageType VirtualPath="~/FormPostBackUrl.aspx" %>
                // (usa le proprieta' Nome/Cognome/Email di FormPostBackUrl.aspx.cs)
                // if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
                // {
                //     nome = PreviousPage.Nome;
                //     cognome = PreviousPage.Cognome;
                //     email = PreviousPage.Email;
                // }
            }
            else
            {
                nome = Request.QueryString["nome"];
                cognome = Request.QueryString["cognome"];
                email = Request.QueryString["email"];
            }

            if (string.IsNullOrEmpty(metodo))
            {
                lblMetodo.Text = "Nessun dato ricevuto. Torna al menu e compila uno dei form.";
            }
            else
            {
                lblMetodo.Text = "Metodo di invio: " + metodo;
                lblNome.Text = "Nome: " + nome;
                lblCognome.Text = "Cognome: " + cognome;
                lblEmail.Text = "Email: " + email;
            }
        }
    }
}
