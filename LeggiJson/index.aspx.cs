using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using provaJson.ctrl;

namespace provaJson
{
    public partial class index : System.Web.UI.Page
    {
        public control ctrl=new control();
        public int cont = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                leggiUsers();
        }

        protected void leggiUsers()
        {
            List<modello> lstUsers;
            lstUsers = ctrl.GetAllUsers();
            //Response.Write(lstItaly[1].abitSup.ab + " - " + lstItaly[1].abitSup.sup);
            //TableRow tRow;
            //TableCell tCell;
            int cont = 0;
            //foreach(modello item in lstItaly)
            lstUsers.ForEach(stampa);
        }

        public void stampa(modello item) {
            lblUsers.Text += item.User + " - " + item.Pwd + " - " + item.Nome + " - " + item.Cognome + " - " + item.Dipartimento + "<br />";
        }
    }
}