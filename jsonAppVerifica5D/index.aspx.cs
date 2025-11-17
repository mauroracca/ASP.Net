using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jsonApp.Controllers;

namespace jsonApp
{
    public partial class index : System.Web.UI.Page
    {
        public AutoController autoCTRL;
        //public PersonController personCTRL;
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Request.Cookies.Clear();
            Server.Execute("pagCtrLogin.aspx");
            if (Session["login"].ToString() == "OK")
            {
                pnlLogin.Visible = false;
                pnlDati.Visible = true;
                creaTabellaBootstrap();
                lblUser.Text = Session["cognome"].ToString() + " " + Session["nome"].ToString();
            }
            else
            {
                lblLogin.Text = "Login Errato";
                pnlLogin.Visible = true;
                pnlDati.Visible = false;
            }
            //Problema con i cookie che salta un turno tra ok e fail e viceversa
            //if (Request.Cookies["login"] != null)
            //    if (Request.Cookies["login"].Value == "Login OK")
            //        lblLogin.Text = "Login OK!!!";
            //    else
            //        lblLogin.Text = "Login Errato";
            //else
            //    lblLogin.Text = "Login Errato";
        }

        protected void creaTabellaBootstrap()
        {
            TableRow tRow;
            TableCell tCell;
            int i;
            autoCTRL = new AutoController();
            autoCTRL.GetAllAuto();
            tabAuto.Rows.Clear();
            for (i = 0; i < autoCTRL.LstAuto.Count; i++)
            {
                tRow = new TableRow();

                tCell = new TableCell();
                tCell.Text = @"<input type='checkbox' name='r" + i + "' value='" + i + "' />";
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = autoCTRL.LstAuto[i].Marca;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = autoCTRL.LstAuto[i].Modello;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = autoCTRL.LstAuto[i].Costo + " €";
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = autoCTRL.LstAuto[i].Categoria;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = autoCTRL.LstAuto[i].Alimentazione;
                tRow.Cells.Add(tCell);

                //tCell = new TableCell();
                //tCell.Text = autoCTRL.LstAuto[i].Dati[0].ToString();
                //tRow.Cells.Add(tCell);

                //tCell = new TableCell();
                //tCell.Text = autoCTRL.LstAuto[i].Dati[1].ToString();
                //tRow.Cells.Add(tCell);

                tabAuto.Rows.Add(tRow);
            }
            Session["totRow"] = i;
            ViewState["totRow"] = i;
            lblAuto.Text = ViewState["totRow"].ToString();
        }

        protected void btnDettagli_Click(object sender, EventArgs e)
        {
            autoCTRL = new AutoController();
            autoCTRL.GetAllAuto();
            int indiceAuto = -1;
            lblAuto.Text = lblAuto.Text + " - " + ViewState["totRow"].ToString();
            for (int i = 0; i < Convert.ToInt32(ViewState["totRow"]); i++)
            {
                if (Request["r" + i] == i.ToString())
                {
                    indiceAuto = i;
                    break;
                }
            }
            Image1.ImageUrl = "~/Content/img/" + autoCTRL.LstAuto[indiceAuto].Marca + ".jpg";
            lblAlimentazione.Text = autoCTRL.LstAuto[indiceAuto].Alimentazione;
            lblMarca.Text = autoCTRL.LstAuto[indiceAuto].Marca;
            lblModello.Text = autoCTRL.LstAuto[indiceAuto].Modello;
            lblCategoria.Text = autoCTRL.LstAuto[indiceAuto].Categoria;
            lblCosto.Text = autoCTRL.LstAuto[indiceAuto].Costo;
            pnlDettagli.Visible = true;
            pnlDati.Visible = false;
        }

        protected void backToAuto(object sender, EventArgs e)
        {
            pnlDettagli.Visible = false;
            pnlDati.Visible = true;
            pnlInsert.Visible = false;
            creaTabellaBootstrap();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            pnlDettagli.Visible = false;
            pnlDati.Visible = false;
            pnlInsert.Visible = true;
        }
        protected void insertAuto(object sender, EventArgs e)
        {
           
            autoCTRL = new AutoController();
            string msg = autoCTRL.addAuto(txtModello.Text, txtMarca.Text, txtAlimentazione.Text, txtCosto.Text, txtCat.Text, txtId.Text);
            if(msg== "Auto inserita corretamente!")
            {
                pnlDettagli.Visible = false;
                pnlDati.Visible = true;
                pnlInsert.Visible = false;
                creaTabellaBootstrap();
            }
            else
            {
                lblInsert.Text = msg;
            }
            
        }
        
    }
}