<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registrazione</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />

    <script runat="server">
        //Impostando uno script sul page_load in questa sezione non verrà più eseguito l'eventuale 
        //page_load presente nel code behind
       /*   public String str;
        void Page_Load(object sender, EventArgs e)
        {
            lblTitolo.Text = "Benvenuto";
          if (Page.IsPostBack)
            {
                lblNome.Text = "Bentornato " + txtName.Text;
                lblNome.Visible = true;
            }
        }*/
    </script>
</head>
<body>
   <%-- <% Response.Write("<b> Pagina di registrazione </b>");%>--%>
    <form id="form1" runat="server">    <!--  action="Default2.aspx" method="post"  -->
        <asp:Label ID="lblTitolo" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="lblNome" runat="server" Visible="False"></asp:Label>
        <div><h1 class="bg-warning p-5 mt-4">Pagina di registrazione</h1>
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtName1" name="txtName" runat="server" placeholder="User"></asp:TextBox>
            <br />
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Password" for="txtPwd"></asp:Label>
                <asp:TextBox ID="txtPwd" runat="server" type="password" placeholder="Password" class="form-control"></asp:TextBox>
            </div>
            <br />
            Sesso<asp:DropDownList ID="comboSesso" runat="server" class='form-select form-select-md w-50'>
                <asp:ListItem>Maschio</asp:ListItem>
                <asp:ListItem>Femmina</asp:ListItem>
                <asp:ListItem>Non saprei</asp:ListItem>
            </asp:DropDownList>
            <br />
            <input id="txtHtml" type="text" />
            <br />
            <br />
            <asp:Label ID="lblCampi" runat="server" Visible="False" BackColor="Red" Font-Bold="True" Font-Size="Large" ForeColor="White"></asp:Label>
            <br /> 
            <br />
            <asp:Button ID="btnInvia" runat="server" Text="Invia dati" OnClick="btnInvia_Click" />
            <asp:Button ID="Button1" runat="server" Text="Button submit" type="submit" OnClick="Button1_Click"/>
            <asp:Button ID="Button2" runat="server" Text="Button ASP.Net" />
            <input id="Button3" value="Button submit traditional" type="submit" />

            <input id="Button4" value="Prova post" type="submit" />

        </div>
    </form>
</body>
</html>
