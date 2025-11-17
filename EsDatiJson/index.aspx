<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EsDatiJson.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Italy JSON</title>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.0/dist/jquery.min.js"></script>
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.11.3/js/jquery.dataTables.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <script src="https://cdn.datatables.net/1.11.3/js/dataTables.bootstrap5.min.js"></script>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.11.3/css/dataTables.bootstrap5.min.css" />
    <script src="index.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="tabella">
            <asp:Table ID="tabDati" runat="server">
                <asp:TableHeaderRow runat="server" ID="tHeader">
                    <asp:TableHeaderCell>City</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Abitanti</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Superficie</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <div id="frmModifica">
            <div class="row">
                <div class="col-sm-12">
                    <p>Form di inserimento di una nuova Città</p>
                </div>
            </div>
            <div class="row mb-2">
                <div class="col-sm-2"><asp:Label ID="Label1" runat="server" Text="Label">Città</asp:Label></div>
                <div class="col-sm-6"><asp:TextBox ID="txtCity" runat="server" class="w-100"></asp:TextBox></div>
            </div>
            <div class="row mb-2">
                <div class="col-sm-2"><asp:Label ID="Label2" runat="server" Text="Label">Nome</asp:Label></div>
                <div class="col-sm-6"><asp:TextBox ID="txtNome" runat="server" class="w-100"></asp:TextBox></div>
            </div>
            <div class="row mb-2">
                <div class="col-sm-2"><asp:Label ID="Label3" runat="server" Text="Label">Abitanti</asp:Label></div>
                <div class="col-sm-6"><asp:TextBox ID="txtAb" runat="server" class="w-100"></asp:TextBox></div>
            </div>
            <div class="row mb-2">
                <div class="col-sm-2"><asp:Label ID="Label4" runat="server" Text="Label">Superficie</asp:Label></div>
                <div class="col-sm-6"><asp:TextBox ID="txtSup" runat="server" class="w-100"></asp:TextBox></div>
            </div>
            <div class="row mb-2">
                <div class="col-sm-8"><asp:Button ID="btnDati" runat="server" Text="Inserisci Città" class="btn btn-primary w-100" OnClick="btnDati_Click"/></div>
            </div>
        </div>
    </form>
</body>
</html>
