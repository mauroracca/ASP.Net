using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accesso_Dati_MVC.Controllers;
using Accesso_Dati_MVC.Models;

namespace Accesso_Dati_MVC
{
    public partial class _default : System.Web.UI.Page
    {
        protected StudentiController stCTRL;
        protected string modifica;
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlTabella.Visible = true;
            pnlScheda.Visible = false;
            stCTRL=new StudentiController();
            aggiornaTab();
        }

        private void aggiornaTab()
        {
            tabUser.DataSource=stCTRL.getAllStudenti();
            tabUser.DataBind();
        }

        protected void btnAggiungi_Click(object sender, EventArgs e)
        {
            txtMatricola.Text = "";
            txtCognome.Text = "";
            txtNome.Text = "";
            txtDataN.Text = "";
            txtCodCl.Text = "";
            txtStage.Text = "";
            txtNomeCl.Text = "";
            txtSpec.Text = "";
            Session["modifica"] = "false";
            pnlTabella.Visible = false;
            pnlScheda.Visible=true;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            modifica = Session["modifica"].ToString();
            if (modifica == "true")
                stCTRL.updateStudente(Convert.ToInt32(txtMatricola.Text),txtCognome.Text,txtNome.Text,Convert.ToDateTime(txtDataN.Text),Convert.ToInt32(txtCodCl.Text),txtStage.Text);
            else
                stCTRL.createStudente(Convert.ToInt32(txtMatricola.Text), txtCognome.Text, txtNome.Text, Convert.ToDateTime(txtDataN.Text), Convert.ToInt32(txtCodCl.Text), txtStage.Text);
            aggiornaTab();
            pnlScheda.Visible = false;
            pnlTabella.Visible=true;
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            stCTRL.deleteStdente(Convert.ToInt32(txtMatricola.Text));
            aggiornaTab();
            pnlScheda.Visible = false;
            pnlTabella.Visible = true;
        }

        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            pnlScheda.Visible = false;
            pnlTabella.Visible = true;
        }

        protected void tabUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            int riga=tabUser.SelectedIndex;
            string codice = tabUser.Rows[riga].Cells[1].Text.Trim();
            StudentiModel st=new StudentiModel();

            st = stCTRL.getStudente(Convert.ToInt32(codice));

            txtMatricola.Text = st.Matricola.ToString();
            txtCognome.Text = st.Cognome.ToString();
            txtNome.Text = st.Nome.ToString();
            txtDataN.Text = st.DataN.ToString();
            txtCodCl.Text = st.CodCl.ToString();
            txtStage.Text = st.Stage.ToString();
            txtNomeCl.Text=st.Classe.NomeCl.ToString();
            txtSpec.Text=st.Classe.Spec.ToString();
            Session["modifica"] = "true";
            pnlTabella.Visible = false;
            pnlScheda.Visible = true;
        }
    }
}