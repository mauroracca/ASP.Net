<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pagina2.aspx.cs" Inherits="Pagina2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pagina 2 - Riepilogo dati</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="p-5">
        <h1 class="bg-warning p-3">Pagina 2 - Dati ricevuti</h1>

        <p><asp:Label ID="lblMetodo" runat="server" CssClass="fw-bold"></asp:Label></p>
        <p><asp:Label ID="lblNome" runat="server"></asp:Label></p>
        <p><asp:Label ID="lblCognome" runat="server"></asp:Label></p>
        <p><asp:Label ID="lblEmail" runat="server"></asp:Label></p>

        <br />
        <a href="Default.aspx" class="btn btn-secondary">Torna al menu</a>
    </div>
    </form>
</body>
</html>
