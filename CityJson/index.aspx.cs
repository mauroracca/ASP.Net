using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CityJson.Controllers;

namespace CityJson
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        public CityController cityControl;

        protected void btnCarica_Click(object sender, EventArgs e)
        {
            cityControl = new CityController();
            gvCity.DataSource= cityControl.GetAllCity();
            gvCity.DataBind();
        }

        protected void gvCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow r;
            int index;
            String nome;
            index = gvCity.SelectedIndex;
            r = gvCity.Rows[index];
            nome = r.Cells[1].Text;
            lblRow.Text = nome;
        }
    }
}