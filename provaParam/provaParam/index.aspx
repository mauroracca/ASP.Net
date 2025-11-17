<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="provaParam.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Prova Parametri</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server" method="get" action="pag2.aspx">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Inserisci il tuo nome:"></asp:Label>
                <asp:TextBox ID="nome" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Inserisci la password:"></asp:Label>
                <asp:TextBox ID="pwd" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div>
                Sesso: <asp:DropDownList ID="comboSesso" runat="server" class='form-select form-select-md w-50'>
                    <asp:ListItem Value="M">Maschio</asp:ListItem>
                    <asp:ListItem Value="F">Femmina</asp:ListItem>
                    <asp:ListItem Value="BO">Non saprei</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <asp:Button Text="Invia" OnClick="btnInvia_Click" runat="server" class="btn btn-warning w-100 mt-3 mb-3" />
            </div>
        </div>
    </form>
</body>
</html>
