<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ViewState.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ViewState</title>
</head>
<body>
    <h1>Esempio di applicazione del ViewState</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblContatore" runat="server" Text="Contatore: 0"></asp:Label>
            <br /><br />
            <asp:Button ID="btnIncrementa" runat="server" Text="Incrementa Contatore" OnClick="Button1_Click" />
            <asp:Button runat="server" ID="btnAzzera" Text="Azzera Contatore" OnClick="btnAzzera_Click"/>
        </div>
    </form>
</body>

</html>
