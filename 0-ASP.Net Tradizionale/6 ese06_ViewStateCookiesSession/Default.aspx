<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnViewState" runat="server" OnClick="btnViewState_Click" Text="ViewState" />
&nbsp;
        <asp:Button ID="btnCookies" runat="server" OnClick="btnCookies_Click" Text="Cookies" />
&nbsp;
        <asp:Button ID="btnSession" runat="server" OnClick="btnSession_Click" Text="Session" />
        &nbsp;<asp:Button ID="btnStop" runat="server" OnClick="btnApplication_Click" Text="Stop session" />
        <br />
        <br />
        <asp:Button ID="btnVedi" runat="server" OnClick="btnVedi_Click" Text="Vedi" />
&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Default2.aspx">Apri Pagina 2</asp:HyperLink>
    
        <asp:Button ID="btnPag2" runat="server" OnClick="btnPag2_Click" Text="apri pag 2" style="height: 26px" />
        <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" ViewStateMode="Disabled"></asp:TextBox>
        <br />
        <asp:DropDownList ID="cboCategoria" runat="server" EnableViewState="False">
        </asp:DropDownList>
&nbsp;<asp:Button ID="btnAggiorna" runat="server" Text="Aggiorna" />
    </div>
    </form>
</body>
</html>
