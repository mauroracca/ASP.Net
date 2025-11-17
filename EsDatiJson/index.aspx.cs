using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EsDatiJson.CTRL;

namespace EsDatiJson
{
    public partial class index : System.Web.UI.Page
    {
        public controller ctrl = new controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                caricaTabella();
        }

        protected void caricaTabella()
        {
            tHeader.TableSection = TableRowSection.TableHeader;
            List<modello> lstItaly;
            lstItaly = ctrl.GetAllCity();
            int cont = 0;
            foreach(modello item in lstItaly)
            {
                TableRow tRow=new TableRow();
                TableCell tCell;
                tRow.ID = "R" + cont;
                tRow.Attributes.Add("onclick","getData('" + tRow.ID + "')");
                tCell = new TableCell();
                tCell.Text = item.City;
                tRow.Cells.Add(tCell);
                tCell.BorderWidth = 2;
                tCell.BorderColor = System.Drawing.Color.Aqua;
                tCell.ID = "city" + cont;
                tCell = new TableCell();
                tCell.Text = item.Name;
                tRow.Cells.Add(tCell);
                tCell.BorderWidth = 2;
                tCell.BorderColor = System.Drawing.Color.Aqua;
                tCell.ID = "name" + cont;
                tCell = new TableCell();
                tCell.Text = item.AbitSup.ab.ToString();
                tRow.Cells.Add(tCell);
                tCell.BorderWidth = 2;
                tCell.BorderColor = System.Drawing.Color.Aqua;
                tCell.ID = "ab" + cont;
                tCell = new TableCell();
                tCell.Text = item.AbitSup.sup.ToString();
                tRow.Cells.Add(tCell);
                tCell.BorderWidth = 2;
                tCell.BorderColor = System.Drawing.Color.Aqua;
                tCell.ID = "sup" + cont;
                cont++;
                tabDati.Rows.Add(tRow);
            }
            tabDati.BorderWidth = 2;
            tabDati.BorderColor = System.Drawing.Color.Aqua;
        }

        protected void btnDati_Click(object sender, EventArgs e)
        {

        }
    }
}