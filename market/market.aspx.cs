using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using market.Controllers;
using market.Models;

namespace market
{
    public partial class market : System.Web.UI.Page
    {
        private ProdottiController pc = new ProdottiController();
        private List<prodottiModel> lstProdotti;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                userModel user = (userModel)Session["user"];
                lblMail.Text=user.Email; 
                lblIndirizzo.Text=user.Indirizzo;
                lblNome.Text=user.Cognome + " " + user.Nome;
            }
            lstProdotti = pc.getAllProdotti();
                for(int i = 0; i < lstProdotti.Count; i++)
                {
                    prodottiModel p = lstProdotti[i];

                    // --- CARD CONTAINER ---
                    Panel card = new Panel();
                    card.CssClass = "card mb-3 w-50 bg-light d-inline-block";  // classe card di bootstrap + margine
                

                    // --- CARD BODY ---
                    Panel body = new Panel();
                    body.CssClass = "card-body";

                    // --- TITOLO NOME ---
                    Label litTitolo = new Label();
                    litTitolo.Text = $"<h5 class='card-title'>{p.NomeProdotto}</h5>";

                    // --- DESCRIZIONE ---
                    Label litDescrizione = new Label();
                    litDescrizione.Text = $"<p class='card-text'>{p.Descrizione}</p>";

                    // --- PREZZO ---
                    Label litPrezzo = new Label();
                    litPrezzo.Text = $"<p class='card-text'><strong>Prezzo:</strong> € {p.Prezzo}</p>";

                    // --- QUANTITÀ ---
                    Label litQuantita = new Label();
                    litQuantita.Text = $"<p class='card-text'><strong>Disponibili:</strong> {p.Quantita}</p>";

                    // --- VENDITORE ---
                    Label litVenditore = new Label();
                    litVenditore.Text = $"<p class='card-text'><small class='text-muted'>Venditore ID: {p.IdV}</small></p>";

                    Button btn = new Button();
                    btn.Text = "Acquista";
                    btn.CssClass = "btn btn-primary w-100";
                    btn.CommandArgument = $"{p.IdProdotto.ToString()},{p.Descrizione.ToString()}";
                    btn.Click += BtnAggiungi_Click;

                    // --- ASSEMBLA I CONTROLLI ---
                    body.Controls.Add(litTitolo);
                    body.Controls.Add(litDescrizione);
                    body.Controls.Add(litPrezzo);
                    body.Controls.Add(litQuantita);
                    body.Controls.Add(litVenditore);
                    body.Controls.Add(btn);

                    card.Controls.Add(body);

                    // --- AGGIUNGI AL PLACEHOLDER ---
                    listaProd.Controls.Add(card);
                }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAggiungi_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] param = btn.CommandArgument.Split(',');
            string descr = param[1];
            int idP=Convert.ToInt32(param[0]);

            // Logica per acquisto
        }
    }
}