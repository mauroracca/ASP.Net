using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
            Response.Write("<h1>Caricamento di una pagina tramite Redirect Transfer Execute</h1>");
    }
    protected void btnRedirect_Click(object sender, EventArgs e)
    {
        HttpCookie cook = new HttpCookie("cookieName");
        cook.Value = name.Text;
        cook.Expires = DateTime.Today.AddDays(1);
        Response.Cookies.Add(cook);
        //false fa eseguire tutte le istruzioni dopo la redirect
        Response.Redirect("Default2.aspx?ID=Redirect");
        //Response.Redirect("Default3.aspx");
    }   
    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        Server.Transfer("Default2.aspx?ID=Transfer");
        Server.Transfer("https://www.html.it");
        Response.Redirect("Default3.aspx");
    }
    protected void btnExecute_Click(object sender, EventArgs e)
    {
        Server.Execute("Default2.aspx?ID=Execute");
        //Server.Execute("Default3.aspx");
        if (Request.Cookies["login"] != null)
        {
            if (Request.Cookies["login"].Value == "Login OK")
            {
                Response.Redirect("Default3.aspx");
            }
            else
                lblUser.Text = "Login Errato";
        }
    }

    protected void btnAccedi_Click(object sender, EventArgs e)
    {
        string percorsoFile=HttpContext.Current.Server.MapPath("user.txt");
        //StreamReader sr = new StreamReader(@"D:\Scuola\A.S.2020-2021_Progetti\Esercitazioni\ASP.net\3 ese03_EsempioRedirectTransferExecute\user.txt");
        StreamReader sr = new StreamReader(percorsoFile);
        while (sr.Peek() != -1)
        {
            string strFile = sr.ReadLine();
            Response.Write(strFile);
            lblUser.Text += strFile+ "<br />";
        }
        sr.Close();
    }
}