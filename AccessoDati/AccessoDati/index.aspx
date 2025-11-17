<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AccessoDati.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Accesso ai Dati</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-group mt-4">
                <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="txtUser" runat="server" placeholder="Username" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group mt-4">
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPwd" runat="server" type="password" placeholder="Password" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group mt-4">
                <asp:Button ID="btnLogin" runat="server" Text="Login to site" class="btn btn-success w-100" OnClick="btnLogin_Click" />
            </div>
            <div class="mt-3 mb-3">
                <asp:Label ID="lblLogin" runat="server" class="alert alert-danger mt-4 mb-4 w-100" Visible="False"></asp:Label>
            </div>
            <div>
                <asp:GridView ID="tabUsers" runat="server" class="table table-striped mt-4" OnSelectedIndexChanged="tabUsers_SelectedIndexChanged">
                    <Columns>
                        <asp:ButtonField CommandName="Select" Text="Modifica" ButtonType="Button" ShowHeader="True" HeaderText="Modifica"></asp:ButtonField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
