<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Intro.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sito ASP.Net</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
</head>
<body>
    <h1>Sito web ASP.Net</h1>
    <form id="form1" runat="server" action="pagRegistrazione.aspx" method="post">   <%----%>
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            <asp:TextBox class="form-control" ID="txtUsername" runat="server" placeholder="user"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <asp:TextBox class="form-control" ID="password" runat="server" placeholder="password" type="password"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Sesso"></asp:Label>
            <asp:DropDownList ID="comboSesso" class="form-select form-select-md w-50" runat="server">
                <asp:ListItem Value="D">Donna</asp:ListItem>
                <asp:ListItem Value="U">Uomo</asp:ListItem>
                <asp:ListItem Value="NP">Sono incerto</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="mt-5 mb-5">
            <asp:Label ID="lblCampi" runat="server" Visible="false" Text="Label" BackColor="Red" ForeColor="White" class="alert alert-danger mt-4 mb-4"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Button ID="btnInvia" class="btn btn-warning w-25" runat="server" Text="Invia dati" OnClick="btnInvia_Click" />
            <asp:Button ID="btnSubmit" class="btn btn-danger w-25" runat="server" type="submit" Text="Btn Submit" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnAsp"  class="btn btn-success w-25" runat="server" Text="Btn ASP.Net" OnClick="btnAsp_Click" />
            <input type="submit" name="name" value="Submit HTML" class="btn btn-primary w-25"/>
        </div>
    </form>
</body>
</html>
