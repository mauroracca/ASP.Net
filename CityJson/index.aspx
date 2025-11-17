<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CityJson.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnCarica" runat="server" Text="Carica Dati City" class="btn btn-primary" OnClick="btnCarica_Click" /><asp:Label runat="server" Text="Label" ID="lblRow"></asp:Label>
        </div>
        <asp:GridView ID="gvCity" runat="server" CellPadding="4" OnSelectedIndexChanged="gvCity_SelectedIndexChanged">
            <Columns>
                <asp:ButtonField CommandName="Select" Text="Seleziona Citt&#224;" ButtonType="Button"></asp:ButtonField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
