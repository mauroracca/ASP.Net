<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Esercitazione form ASP.Net</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="p-5">
        <h1 class="bg-warning p-3">Esercitazione: Form GET, POST, Click Event e PostBackUrl</h1>
        <p>Ogni form raccoglie 3 campi (Nome, Cognome, Email) e invia i dati a <b>Pagina2.aspx</b>, che li legge e li visualizza.</p>
        <ul class="list-group w-50">
            <li class="list-group-item"><a href="FormGet.aspx">1) Form in GET</a></li>
            <li class="list-group-item"><a href="FormPost.aspx">2) Form in POST</a></li>
            <li class="list-group-item"><a href="FormClick.aspx">3) Form con Click Event su Button (Redirect)</a></li>
            <li class="list-group-item"><a href="FormPostBackUrl.aspx">4) Form in POST con PostBackUrl</a></li>
        </ul>
    </div>
    </form>
</body>
</html>
