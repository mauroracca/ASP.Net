<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Redirect Response Execute</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous" />
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.bundle.min.js" integrity="sha384-LtrjvnR4Twt/qOuYxE721u19sVFLVSA4hf/rRt6PrZTmiPltdZcI7q7PXQBYTKyf" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server"><!-- method="post"> action="Default2.aspx?ID=Redirect">-->
        <div class="jumbotron">
            <asp:Button ID="btnRedirect" runat="server" Text="Redirect" class="btn btn-primary" OnClick="btnRedirect_Click"/>&nbsp;&nbsp; 
            <asp:Button ID="btnTransfer" runat="server" Text="Transfer" class="btn btn-warning" OnClick="btnTransfer_Click" />&nbsp;&nbsp; 
            <asp:Button ID="btnExecute" runat="server" Text="Execute" class="btn btn-danger" OnClick="btnExecute_Click" />
        </div>
        <div class="form-group">
            <label for="name">Name:</label>
            <asp:TextBox ID="name" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="surname">Surname:</label>
            <input type="text" class="form-control" name="txtCognome" id="surname" />
        </div>

        <asp:Button ID="btnAccedi" runat="server" Text="Accedi" class="btn btn-primary" OnClick="btnAccedi_Click"/>
        <br />
        <br />
        <asp:Label ID="lblUser" runat="server" Font-Size="Large"></asp:Label>
    </form>
</body>
</html>
