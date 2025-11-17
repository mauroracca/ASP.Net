<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pagRegistrazione.aspx.cs" Inherits="Intro.pagRegistrazione" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Registrazione avvenuta con successo</h2>
            <p>Nome: <asp:Label ID="lblNome" runat="server" Text=""></asp:Label></p>
            <p>Password: <asp:Label ID="lblPwd" runat="server" Text=""></asp:Label></p>
            <p>Sesso: <asp:Label ID="lblSex" runat="server" Text=""></asp:Label></p>
        </div>
    </form>
</body>
</html>
