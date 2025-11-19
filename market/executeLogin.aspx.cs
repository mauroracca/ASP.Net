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
    public partial class executeLogin : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            UserController uc = new UserController();
            TextBox txtUserId = (TextBox)PreviousPage.FindControl("txtUser");
            TextBox txtPwd = (TextBox)PreviousPage.FindControl("txtPwd");
            userModel userLogged = uc.userLogin(Convert.ToInt32(txtUserId.Text), txtPwd.Text);
            if (userLogged != null)
            {
                Session["user"] = userLogged;
                Session["autenticato"] = true;
            } else
                Session["autenticato"] = false;
        }
    }
}