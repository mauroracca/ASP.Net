<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Validator</title>
    <link rel="stylesheet" href="index.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Cognome e nome"></asp:Label>
        <br />
        <asp:TextBox ID="txtRequired" runat="server" style="text-align: center"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFV" runat="server" ErrorMessage="Il campo cognome è obbligatorio"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Inserire un numero tra 7 e 77"></asp:Label>
        <br />
        <asp:TextBox ID="txtRange" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="RV" runat="server" ErrorMessage="RangeValidator" ControlToValidate="txtRange"></asp:RangeValidator>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Inserire la mail"></asp:Label>
        <br />
        <asp:TextBox ID="txtRegular" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="REV" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtCustom"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Confronto colori"></asp:Label>
        <br />
        <asp:TextBox ID="txtCompare" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="CV" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>
&nbsp;&nbsp;
        <asp:DropDownList ID="cmbCompare" runat="server">
            <asp:ListItem>rosso</asp:ListItem>
            <asp:ListItem>verde</asp:ListItem>
            <asp:ListItem>blu</asp:ListItem>
        </asp:DropDownList>
        <asp:CompareValidator ID="CV2" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>
        <br />
        <br />
        Campo con lunghezza minima 8 caratteri<br />
        <asp:TextBox ID="txtCustom" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="CustV" runat="server" OnServerValidate="CustV_ServerValidate"></asp:CustomValidator>
        <br />
        <br />
      
        <asp:Label ID="Label7" runat="server" Text="Campo prova obbligatorio"></asp:Label>
      
        <br />
        <asp:TextBox ID="txtProva" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFVprova" runat="server" ControlToValidate="txtProva" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:ValidationSummary ID="VS" runat="server" Width="388px" />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="351px" />
        <br />
        <br />
        <asp:Button ID="btnInvia" runat="server" OnClick="btnInvia_Click" Text="Invia" class="pulsante"/>
    
    </div>
    </form>
</body>
</html>
