using System;

public partial class FormPostBackUrl : System.Web.UI.Page
{
    // Proprietà pubbliche esposte per la lettura tipizzata tramite PreviousPage in Pagina2
    // (usate solo se in Pagina2 si abilita la direttiva <%@ PreviousPageType %>).
    public string Nome { get { return txtNome.Text.Trim(); } }
    public string Cognome { get { return txtCognome.Text.Trim(); } }
    public string Email { get { return txtEmail.Text.Trim(); } }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Nessuna logica: l'invio avviene tramite PostBackUrl del Button,
        // che fa un POST diretto a Pagina2.aspx (Cross-Page Posting).
        if(Page.IsPostBack)
        {
            // Esempio: log dei dati inviati
            string nome = txtNome.Text.Trim();
            string cognome = txtCognome.Text.Trim();
            string email = txtEmail.Text.Trim();
            System.Diagnostics.Debug.WriteLine("FormPostBackUrl.aspx - PostBack: Nome={0}, Cognome={1}, Email={2}", nome, cognome, email);
        }
    }
}
