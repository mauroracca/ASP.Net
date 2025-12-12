<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="market.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <title>Market online</title>
</head>
<body>
    <div class="container mt-4 mb-4 p-3">
        <form id="form1" runat="server">
            <asp:TextBox ID="txtUser" runat="server" placeholder="Inserire nome utente" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnRiparazioni" runat="server" Text="Gestione Officina" CssClass="btn btn-primary" OnClick="btnRiparazioni_Click" />
        </form>
    </div>
</body>
</html>
