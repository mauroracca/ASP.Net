<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pagina benvenuto</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblPag2" runat="server" Text="Benvenuto"></asp:Label> 
        <asp:Button ID="btnBack" runat="server" Text="Torna alla home" OnClick="btnBack_Click" />
        <br />
        <asp:Label ID="lblPwd" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblSesso" runat="server"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
