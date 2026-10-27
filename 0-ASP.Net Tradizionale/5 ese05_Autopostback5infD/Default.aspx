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
    
        <asp:CheckBox ID="chkAutoPostBack" runat="server" OnCheckedChanged="chkAutoPostBack_CheckedChanged" Text="Abilita AutoPostBack" />
        <br />
        <br />
        <asp:DropDownList ID="cmbColori" runat="server" OnSelectedIndexChanged="cmbColori_SelectedIndexChanged" ViewStateMode="Enabled">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Panel ID="pnlColore" runat="server" Height="67px" Width="118px">
        </asp:Panel>
        <br />
        <asp:Button ID="btnPremi" runat="server" OnClick="btnPremi_Click" Text="Premi" />
    
    </div>
    </form>
</body>
</html>
