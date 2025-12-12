using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using market.Controllers;
using market.Models;

namespace market
{
    public partial class market : System.Web.UI.Page
    {
        private marcheController marcheCtrl = new marcheController();
        private List<marcheModel> lstMarche;
        private riparazioniController ripCtrl = new riparazioniController();
        private List<riparazioniModel> lstriparazioni;
        int idRip;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null && Session["user"].ToString() != "")
            {
                if (!Page.IsPostBack)
                {
                    marcheModel marche = new marcheModel();
                    lstMarche = marcheCtrl.getAllMarche();
                    cboMarche.Items.Clear();
                    cboMarche.DataSource = lstMarche;
                    cboMarche.DataValueField = "IdMarca";
                    cboMarche.DataTextField = "NomeMarca";
                    cboMarche.DataBind();
                    cboMarche.Items.Insert(0, new ListItem("-- nessuna selezione --", ""));
                }
                caricaCardRip();
            }else
                Response.Redirect("index.aspx");
            
            //lstProdotti = pc.getAllProdotti();
            //    for(int i = 0; i < lstProdotti.Count; i++)
            //    {
            //        marcheModel p = lstProdotti[i];

            //        // --- CARD CONTAINER ---
            //        Panel card = new Panel();
            //        card.CssClass = "card mb-3 w-50 bg-light d-inline-block";  // classe card di bootstrap + margine


            //        // --- CARD BODY ---
            //        Panel body = new Panel();
            //        body.CssClass = "card-body";

            //        // --- TITOLO NOME ---
            //        Label litTitolo = new Label();
            //        litTitolo.Text = $"<h5 class='card-title'>{p.NomeProdotto}</h5>";

            //        // --- DESCRIZIONE ---
            //        Label litDescrizione = new Label();
            //        litDescrizione.Text = $"<p class='card-text'>{p.Descrizione}</p>";

            //        // --- PREZZO ---
            //        Label litPrezzo = new Label();
            //        litPrezzo.Text = $"<p class='card-text'><strong>Prezzo:</strong> € {p.Prezzo}</p>";

            //        // --- QUANTITÀ ---
            //        Label litQuantita = new Label();
            //        litQuantita.Text = $"<p class='card-text'><strong>Disponibili:</strong> {p.Quantita}</p>";

            //        // --- VENDITORE ---
            //        Label litVenditore = new Label();
            //        litVenditore.Text = $"<p class='card-text'><small class='text-muted'>Venditore ID: {p.IdV}</small></p>";

            //        Button btn = new Button();
            //        btn.Text = "Acquista";
            //        btn.CssClass = "btn btn-primary w-100";
            //        btn.CommandArgument = $"{p.IdProdotto.ToString()},{p.Descrizione.ToString()}";
            //        btn.Click += BtnAggiungi_Click;

            //        // --- ASSEMBLA I CONTROLLI ---
            //        body.Controls.Add(litTitolo);
            //        body.Controls.Add(litDescrizione);
            //        body.Controls.Add(litPrezzo);
            //        body.Controls.Add(litQuantita);
            //        body.Controls.Add(litVenditore);
            //        body.Controls.Add(btn);

            //        card.Controls.Add(body);

            //        // --- AGGIUNGI AL PLACEHOLDER ---
            //        listaProd.Controls.Add(card);
            //    }
        }

        protected void cboMarche_SelectedIndexChanged(object sender, EventArgs e)
        {
            //caricaCardRip();
        }

        protected void caricaCardRip() {
            divModifica.Visible = false;
            //listaRiparazioni.Controls.Clear();
            var codMarca = cboMarche.SelectedValue;
            lstriparazioni = ripCtrl.getRipXmarca(codMarca);
            for (int i = 0; i < lstriparazioni.Count; i++)
            {
                riparazioniModel riparazione = lstriparazioni[i];
                

                // --- CARD CONTAINER ---
                Panel card = new Panel();
                card.CssClass = "card mb-3 w-50 bg-light d-inline-block";  // classe card di bootstrap + margine


                // --- CARD BODY ---
                Panel body = new Panel();
                body.CssClass = "card-body";

                // --- Modello ---
                Label litModello = new Label();
                litModello.Text = $"<h5 class='card-title'>{riparazione.Modello}</h5>";

                // --- Targa ---
                Label litTarga = new Label();
                litTarga.Text = $"<p class='card-text'>{riparazione.Targa}</p>";

                // --- Descrizione ---
                Label litDescrizione = new Label();
                litDescrizione.Text = $"<p class='card-text'>{riparazione.Descrizione}</p>";

                // --- TERMINATO ---
                Label litTerminato = new Label();
                litTerminato.Text = $"<p class='card-text'><strong>Lavoro Terminato:</strong> {riparazione.Terminato}</p>";

                // --- PAGATO ---
                Label litPagato = new Label();
                litPagato.Text = $"<p class='card-text'><strong>Pagato:</strong> {riparazione.Pagato}</p>";

                // --- DATA ---
                Label litData = new Label();
                litData.Text = $"<p class='card-text'><small class='text-muted'>Data Ingresso: {riparazione.DataStart}</small></p>";

                // -- IMAGE --
                Image img = new Image();
                img.Width = 150;
                img.Height = 150;
                if(riparazione.Pagato)
                    img.ImageUrl = "img/pagato.jpg";
                else
                    img.ImageUrl = "img/non_pagato.jpg";

                Button btn = new Button();
                btn.Text = "Modifica dati";
                btn.CssClass = "btn btn-primary w-100";
                btn.CommandArgument = $"{riparazione.IdRiparazione},{riparazione.Modello},{riparazione.Targa},{riparazione.Descrizione},{riparazione.Terminato},{riparazione.Pagato}";
                btn.Click += BtnModifica_Click;

                // --- ASSEMBLA I CONTROLLI ---
                body.Controls.Add(litModello);
                body.Controls.Add(litTarga);
                body.Controls.Add(litDescrizione);
                body.Controls.Add(litTerminato);
                body.Controls.Add(litPagato);
                body.Controls.Add(img);
                body.Controls.Add(litData);
                body.Controls.Add(btn);

                card.Controls.Add(body);

                // --- AGGIUNGI AL PLACEHOLDER ---
                listaRiparazioni.Controls.Add(card);
            }
        }

        protected void BtnModifica_Click(object sender, EventArgs e)
        {
            lblRis.Visible = false;
            Button btn = (Button)sender;
            string[] param = btn.CommandArgument.Split(',');
            ViewState["idRip"] = Convert.ToInt32(param[0]);
            string modello = param[1];
            string targa = param[2];
            string descr = param[3];
            bool terminato = false;
            if (param[4]=="True")
                terminato=true;
            bool pagato=false;
            if (param[5]=="True")
                pagato = true;
            txtDescr.Text = descr;
            txtModello.Text = modello;
            txtTarga.Text = targa;
            chkPagato.Checked= pagato;
            chkTerminato.Checked= terminato;
            divModifica.Visible = true;

            // Logica per acquisto
        }

        protected void btnModifica_Click1(object sender, EventArgs e)
        {
            lblRis.Visible= true;
            if (ripCtrl.modificaRiparazione(Convert.ToInt32(ViewState["idRip"]), txtModello.Text, txtTarga.Text, txtDescr.Text, chkTerminato.Checked, chkPagato.Checked))
                lblRis.Text = "Modifiche salvate correttamente!";
            else
                lblRis.Text = "Errore durante la modifica dei dati: si prega di riprovare in un secondo momento!";
            //caricaCardRip();
        }

        protected void btnLogout_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
    }
}