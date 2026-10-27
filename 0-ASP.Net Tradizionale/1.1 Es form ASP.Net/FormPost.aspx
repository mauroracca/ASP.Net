<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPost.aspx.cs" Inherits="FormPost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Form in POST</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" action="Pagina2.aspx" method="post">
    <div class="p-5">
        <h1 class="bg-success text-white p-3">Form in POST</h1>

        <input type="hidden" name="metodo" value="POST" />

        <div class="form-group mb-2">
            <label for="nome">Nome</label>
            <input type="text" class="form-control w-25" id="nome" name="nome" placeholder="Nome" />
        </div>
        <div class="form-group mb-2">
            <label for="cognome">Cognome</label>
            <input type="text" class="form-control w-25" id="cognome" name="cognome" placeholder="Cognome" />
        </div>
        <div class="form-group mb-2">
            <label for="email">Email</label>
            <input type="email" class="form-control w-25" id="email" name="email" placeholder="Email" />
        </div>

        <br />
        <input type="submit" class="btn btn-primary" value="Invia (POST)" />
        <a href="Default.aspx" class="btn btn-secondary">Torna al menu</a>
    </div>
    </form>
</body>
</html>
