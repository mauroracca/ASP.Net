using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccessoDati.Controllers;

namespace AccessoDati
{
    public partial class index : System.Web.UI.Page
    {
        public UserController uController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserController uController = new UserController();
            if (uController.login(txtUser.Text, txtPwd.Text))
            {
                StudentiController studController= new StudentiController();
                tabUsers.DataSource = studController.getAllStudents();
                tabUsers.DataBind();
            }
            else
            {
                lblLogin.Text = "Login errato";
                lblLogin.Visible = true;
                
            }
            
        }

        protected void tabUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int riga = tabUsers.SelectedIndex; 
            string nome = tabUsers.Rows[riga].Cells[2].Text.Trim();
            lblLogin.Text = nome;
            lblLogin.Visible = true;
            lblLogin.Attributes.Add("class", "alert-success");
        }
    }
}