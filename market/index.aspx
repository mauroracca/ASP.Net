<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="market.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <title>Market online</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="bg-dark text-white container p-4 mt-4 mb-4">
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUser" runat="server" class="form-control"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPwd" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="bg-dark text-white container p-4 mt-4 mb-4">
            <asp:Button ID="btnLogin" runat="server" Text="LOGIN" class="btn btn-warning w-100 mt-4 mb-4" OnClick="btnLogin_Click" />
            <div><asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Medium" ForeColor="Red"></asp:Label></div>
        </div>
        
    </form>
</body>
</html>
