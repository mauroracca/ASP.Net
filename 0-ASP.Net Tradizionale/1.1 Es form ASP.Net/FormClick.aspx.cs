using System;

public partial class FormClick : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            lblRis.Text=txtNome.Text + " " + txtCognome.Text + " " + txtEmail.Text;
        }
    }

    protected void btnInvia_Click(object sender, EventArgs e)
    {
        if (txtNome.Text.Trim() != "" && txtCognome.Text.Trim() != "" && txtEmail.Text.Trim() != "")
        {
            // I dati vengono passati a Pagina2.aspx tramite querystring,
            // dopo essere stati raccolti lato server nell'evento Click del Button.
            string url = string.Format("Pagina2.aspx?metodo=CLICK&nome={0}&cognome={1}&email={2}",
                Server.UrlEncode(txtNome.Text.Trim()),
                Server.UrlEncode(txtCognome.Text.Trim()),
                Server.UrlEncode(txtEmail.Text.Trim()));

            Response.Redirect(url);
        }
        else
        {
            lblErrore.Text = "Compilare tutti i campi";
            lblErrore.Visible = true;
        }
    }
}
