<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="riparazioni.aspx.cs" Inherits="market.market" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <title>Gestione Officina</title>
</head>
<body>
    <div class="container mt-3 mb-3">
        <h1>Gestione officina</h1>
        <form id="form1" runat="server">
            <asp:DropDownList AutoPostBack="true" ID="cboMarche" runat="server" CssClass=" mt-3 mb-3 form-select" OnSelectedIndexChanged="cboMarche_SelectedIndexChanged">

            </asp:DropDownList>
            <asp:PlaceHolder ID="listaRiparazioni" runat="server"></asp:PlaceHolder>
            <asp:Panel ID="divModifica" runat="server" Visible="False">
                <asp:Label ID="Label1" runat="server" Text="Modello" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtModello" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="Targa" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtTarga" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="Descrizione" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtDescr" runat="server" CssClass="form-control"></asp:TextBox>
                <div>
                    <asp:Label ID="Label4" runat="server" Text="Terminato" CssClass="form-check-label"></asp:Label>
                    <asp:CheckBox ID="chkTerminato" runat="server" CssClass="form-check-input"/>
                </div>
                <div>
                    <asp:Label ID="Label5" runat="server" Text="Pagato" CssClass="form-check-label" Visible="true"></asp:Label>
                    <asp:CheckBox ID="chkPagato" runat="server" CssClass="form-check-input"/>
                </div>
                <asp:Button ID="btnModifica" runat="server" Text="Modifica dati" CssClass="btn btn-success w-100 mt-3 mb-3" OnClick="btnModifica_Click1" />
            </asp:Panel>
            <asp:Label ID="lblRis" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Medium" ForeColor="#0066FF"></asp:Label>
            <asp:Button ID="btnLogout" runat="server" Text="LOGOUT" CssClass="btn btn-danger w-100 mt-3 mb-3" OnClick="btnLogout_Click1" />
        </form>
    </div>
    
</body>
</html>
