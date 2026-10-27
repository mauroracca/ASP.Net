using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            chkAutoPostBack.AutoPostBack = true;
            cmbColori.Items.Add("Rosso");
            cmbColori.Items.Add("Verde");
            cmbColori.Items.Add("Giallo");
            cmbColori.Items.Add("Blu");
            cambiaColore();
        }
    }
    protected void cambiaColore()
    {
        switch (cmbColori.SelectedIndex)
        { 
            case 0:
                pnlColore.BackColor = System.Drawing.Color.Red;
                break;
            case 1:
                pnlColore.BackColor = System.Drawing.Color.Green;
                break;
            case 2:
                pnlColore.BackColor = System.Drawing.Color.Yellow;
                break;
            case 3:
                pnlColore.BackColor = System.Drawing.Color.Blue;
                break;
        }
    }
    protected void cmbColori_SelectedIndexChanged(object sender, EventArgs e)
    {
        cambiaColore();
    }
    protected void btnPremi_Click(object sender, EventArgs e)
    {
        cambiaColore();
    }
    protected void chkAutoPostBack_CheckedChanged(object sender, EventArgs e)
    {
        cmbColori.AutoPostBack = chkAutoPostBack.Checked;
    }
}