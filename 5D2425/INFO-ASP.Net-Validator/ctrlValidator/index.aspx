<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ctrlValidator.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Validator</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                <asp:TextBox class="form-control" ID="txtUsername" runat="server" placeholder="user"></asp:TextBox>
            </div>
            <p>
                <asp:RequiredFieldValidator ID="RFV" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </p>

            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Età"></asp:Label>
                <asp:TextBox class="form-control" ID="txtRange" runat="server" placeholder="Inserire età"></asp:TextBox>
            </div>
            <p>
                <asp:RangeValidator ID="RV" runat="server" ErrorMessage="RangeValidator"></asp:RangeValidator>
            </p>

            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                <asp:TextBox class="form-control" ID="txtMail" runat="server" placeholder="Inserire email"></asp:TextBox>
            </div>
            <p>
                <asp:RegularExpressionValidator ID="REV" runat="server" ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator>
            </p>





            <asp:Button ID="btnInvia" class="btn btn-warning w-25" runat="server" Text="Invia dati" OnClick="btnInvia_Click"/>
        </div>
    </form>
</body>
</html>
