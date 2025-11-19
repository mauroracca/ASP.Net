<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Accesso_Dati_MVC._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Accesso ai dati</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlTabella" runat="server">
            <asp:GridView ID="tabUser" runat="server" class="table table-striped mt-4" OnSelectedIndexChanged="tabUser_SelectedIndexChanged">
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Modifica" ShowHeader="true" Text="Modifica" /><%-- il comando Select genera l'evento SelectIndexChanged --%>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnAggiungi" runat="server" Text="AGGIUNGI" class="btn btn-primary" OnClick="btnAggiungi_Click" />
        </asp:Panel>
        <asp:Panel ID="pnlScheda" runat="server" >
            <div class="form-group mt-4">
                <div class="mt-3">
                    <label for="txtMatricola" class="form-label">Matricola</label>
                    <asp:TextBox ID="txtMatricola" runat="server" class="form-control"></asp:TextBox>
                </div>

                <div class="mt-3">
                    <label for="txtCognome" class="form-label">Cognome</label>
                    <asp:TextBox ID="txtCognome" runat="server" class="form-control"></asp:TextBox>
                </div>

                <div class="mt-3">
                    <label for="txtNome" class="form-label">Nome</label>
                    <asp:TextBox ID="txtNome" runat="server" class="form-control"></asp:TextBox>
                </div>

                <div class="mt-3">
                    <label for="txtDataN" class="form-label">DataN</label>
                    <asp:TextBox ID="txtDataN" runat="server" class="form-control"></asp:TextBox>
                </div>

                <div class="mt-3">
                    <label for="txtCodCl" class="form-label">Cod. Classe</label>
                    <asp:TextBox ID="txtCodCl" runat="server" class="form-control"></asp:TextBox>
                    <button type="button" class="btn btn-primary" onclick="document.getElementById('pnlClasse').style.display='block'">Mostra Classe</button>
                    <button type="button" class="btn btn-primary" onclick="document.getElementById('pnlClasse').style.display='none'">Nascondi Classe</button>
                    <div id="pnlClasse" style="display:none;">
                        <div class="mt-3">
                            <label for="txtNomeCl" class="form-label">Nome Classe</label>
                            <asp:TextBox ID="txtNomeCl" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="mt-3">
                            <label for="txtSpec" class="form-label">Specializzaione</label>
                            <asp:TextBox ID="txtSpec" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <label for="txtStage" class="form-label">Stage</label>
                    <asp:TextBox ID="txtStage" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="mt-3">
                    <asp:Button ID="btnOK" runat="server" Text="OK" class="btn btn-primary" OnClick="btnOK_Click" />
                    <asp:Button ID="btnElimina" runat="server" Text="ELIMINA" class="btn btn-primary" OnClick="btnElimina_Click" />
                    <asp:Button ID="btnAnnulla" runat="server" Text="ANNULLA" class="btn btn-primary" OnClick="btnAnnulla_Click" />
                </div>

            </div>
        </asp:Panel>

    </form>
</body>
</html>
