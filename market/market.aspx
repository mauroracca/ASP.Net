<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="market.aspx.cs" Inherits="market.market" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <title>Market online</title>
</head>
<body>
    <h1>market</h1>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-9">
                    <asp:PlaceHolder ID="listaProd" runat="server"></asp:PlaceHolder>
                </div>
                <div class="col-sm-3">
                    <div class="card bg-secondary">
                        <div class="card-body w-100">
                            <h4><asp:Label ID="lblNome" class="card-title" runat="server" Text=""></asp:Label></h4>
                            <div><asp:Label ID="lblMail" runat="server" Text="" class="card-text"></asp:Label></div>
                            <div><asp:Label ID="lblIndirizzo" runat="server" Text="" class="card-text"></asp:Label></div>
                            <div><asp:Button ID="btnLogout" runat="server" Text="Logout" class="btn btn-primary w-100" OnClick="btnLogout_Click"/></div>
                        </div>
                    </div>    
                </div>
            </div>
        </div>
    </form>
</body>
</html>
