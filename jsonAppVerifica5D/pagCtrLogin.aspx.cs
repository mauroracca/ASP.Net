using jsonApp.Controllers;
using jsonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jsonApp
{
    public partial class pagCtrLogin : System.Web.UI.Page
    {
        public PersonController personCTRL;
        protected void Page_Load(object sender, EventArgs e)
        {
            personCTRL = new PersonController();
            if (!Page.IsPostBack)
            {
                personCTRL.GetAllPerson();
                TextBox user = (TextBox)PreviousPage.FindControl("txtUser");
                TextBox pwd = (TextBox)PreviousPage.FindControl("txtPwd");
                HttpCookie cookLogin = new HttpCookie("login");
                cookLogin.Expires = DateTime.Today.AddDays(1);
                Response.Cookies.Add(cookLogin);
                cookLogin.Value = "Login FAIL";
                Session["login"] = "FAIL";
                for (int i=0;i< personCTRL.LstPerson.Count; i++)
                {
                    if (user.Text == personCTRL.LstPerson[i].Email && pwd.Text == personCTRL.LstPerson[i].Pwd)
                    { 
                        cookLogin.Value = "Login OK";
                        Session["login"] = "OK";
                        Session["nome"] = personCTRL.LstPerson[i].Nome;
                        Session["cognome"] = personCTRL.LstPerson[i].Cognome;
                        break;
                    }                        
                }
                //cookLogin.Expires = DateTime.Today.AddDays(1);
                //Response.Cookies.Add(cookLogin);
            }
        }
    }
}