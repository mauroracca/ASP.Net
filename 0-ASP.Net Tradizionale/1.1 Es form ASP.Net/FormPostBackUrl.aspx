<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPostBackUrl.aspx.cs" Inherits="FormPostBackUrl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Form con PostBackUrl</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="p-5">
        <h1 class="bg-info text-white p-3">Form con PostBackUrl (Cross-Page Posting)</h1>

        <input type="hidden" name="metodo" value="POSTBACKURL" />

        <div class="form-group mb-2">
            <asp:Label ID="Label1" runat="server" Text="Nome" AssociatedControlID="txtNome"></asp:Label>
            <br />
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control w-25" placeholder="Nome"></asp:TextBox>
        </div>
        <div class="form-group mb-2">
            <asp:Label ID="Label2" runat="server" Text="Cognome" AssociatedControlID="txtCognome"></asp:Label>
            <br />
            <asp:TextBox ID="txtCognome" runat="server" CssClass="form-control w-25" placeholder="Cognome"></asp:TextBox>
        </div>
        <div class="form-group mb-2">
            <asp:Label ID="Label3" runat="server" Text="Email" AssociatedControlID="txtEmail"></asp:Label>
            <br />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control w-25" placeholder="Email"></asp:TextBox>
        </div>

        <br />
        <asp:Button ID="btnInvia" runat="server" Text="Invia (PostBackUrl)" CssClass="btn btn-primary" PostBackUrl="~/Pagina2.aspx" />
        <a href="Default.aspx" class="btn btn-secondary">Torna al menu</a>
    </div>
    </form>
</body>
</html>
