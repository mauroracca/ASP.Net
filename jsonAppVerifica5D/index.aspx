<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="jsonApp.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<meta name="description" content="">
<meta name="author" content="">
<title>Gestione personale</title>
<!-- Bootstrap core CSS -->
<link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

<!-- Custom fonts for this template -->
<link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
<link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css">
<link href='https://fonts.googleapis.com/css?family=Kaushan+Script' rel='stylesheet' type='text/css'>
<link href='https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
<link href='https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700' rel='stylesheet' type='text/css'>

<!-- Custom styles for this template -->
<link href="css/agency.min.css" rel="stylesheet">
    
</head>
<body id="page-top">
 <form id="form1" runat="server"> 
    <!-- Navigation -->
  <nav class="navbar navbar-expand-lg navbar-dark fixed-top" id="mainNav">
    <div class="container">
      <a class="navbar-brand js-scroll-trigger" href="#page-top">IIS G. Vallauri</a>
      <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
        Menu
        <i class="fas fa-bars"></i>
      </button>
      <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav text-uppercase ml-auto">
          <li class="nav-item">
            <a class="nav-link js-scroll-trigger" href="#login">Login</a>
          </li>
          <li class="nav-item">
            <a class="nav-link js-scroll-trigger" href="#services">Services</a>
          </li>
          <li class="nav-item">
              <asp:Label href="#" ID="lblUser" runat="server" Text="" class="nav-link js-scroll-trigger"></asp:Label>
          </li>
        </ul>
      </div>
    </div>
  </nav>

  <!-- Header -->
  <header class="masthead">
    <div class="container">
      <div class="intro-text">
        <div class="intro-lead-in">Welcome To Vallauto!</div>
        <div><h2>Il portale online per la vendita di auto</h2></div>
      </div>
    </div>
  </header>

    <%--Login--%>
    
        <asp:Panel ID="pnlLogin" runat="server" class="container">
            <section class="page-section" id="login">
               <div class="row">
                   <div class="col-sm-4"></div>
                   <div class="col-sm-4">
                        <div class="loginBox"> 
                            <img class="user" style="display:block; margin:auto" src="https://i.ibb.co/yVGxFPR/2.png" height="100px" width="100px">
                            <h3 class="text-center">Sign in here</h3>
                            <div class="inputBox"> 
                                <asp:TextBox ID="txtUser" runat="server" placeholder="Username" class="form-control w-100 mt-2 mb-2" Text="martina.moretti@email.com"></asp:TextBox> 
                                <asp:TextBox ID="txtPwd" type="password" runat="server" placeholder="Password" class="form-control w-100 mt-2 mb-2" Text="1a2d3d45"></asp:TextBox>
                            </div> 
                            <div>
                                <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-primary w-100 mt-2 mb-2" OnClick="btnLogin_Click" />
                            </div>
                        </div>
                   </div>
                   <div class="col-sm-4"></div>
                </div>
                <asp:Label ID="lblLogin" runat="server" Font-Size="XX-Large" ForeColor="#66FF33"></asp:Label>
            </section>
        </asp:Panel>
        tot auto: <asp:Label ID="lblAuto" runat="server" Text="---"></asp:Label>
        <asp:Panel ID="pnlDati" runat="server" Visible="False">
            
            <%--<asp:GridView ID="gvDati" runat="server"></asp:GridView>--%>
            <asp:Button ID="btnDettagli" runat="server" Text="Dettagli auto" class="btn btn-warning w-100 mt-2 mb-2" OnClick="btnDettagli_Click" />
            <asp:Button ID="Button1" runat="server" Text="Inserisci auto" class="btn btn-success w-100 mt-2 mb-2" OnClick="btnInsert_Click" />
            <asp:Table ID="tabAuto" runat="server" class="table table-striped"></asp:Table>
        </asp:Panel>
        <asp:Panel ID="pnlDettagli" runat="server" Visible="False">
            <div class="container mt-3 mb-3"><asp:Image ID="Image1" runat="server" ImageUrl="~/Content/img/BMW.jpg" Height="200" Width="200" BorderStyle="Double" BorderWidth="2" GenerateEmptyAlternateText="True" /></div>
            <div class="container mt-3 mb-3"><asp:Label ID="lblId" runat="server" Text="" class="form-label w-100"></asp:Label></div>
            <div class="container mt-3 mb-3"><asp:Label ID="lblMarca" runat="server" Text="" class="form-label"></asp:Label></div>
            <div class="container mt-3 mb-3"><asp:Label ID="lblModello" runat="server" Text="" class="form-label"></asp:Label></div>
            <div class="container mt-3 mb-3"><asp:Label ID="lblCosto" runat="server" Text="" class="form-label"></asp:Label></div>
            <div class="container mt-3 mb-3"><asp:Label ID="lblCategoria" runat="server" Text="" class="form-label"></asp:Label></div>
            <div class="container mt-3 mb-3"><asp:Label ID="lblAlimentazione" runat="server" Text="" class="form-label"></asp:Label></div>
            <div class="container mt-3 mb-3"><asp:Button ID="btnBack" runat="server" Text="Torna alla lista auto" class="btn btn-success w-100 mt-4 mb-4" OnClick="backToAuto" /></div>
        </asp:Panel>
        <asp:Panel ID="pnlInsert" runat="server" Visible="False">
            <div class="container mt-3 mb-3"><asp:Label ID="lblInsert" runat="server" Text=""></asp:Label></div>
            <div class="container mt-3 mb-3"><asp:TextBox ID="txtId" runat="server" class="w-100 form-control mt-2 mtb-2" placeholder="Inserisci ID" ></asp:TextBox></div>
            <div class="container mt-3 mb-3"><asp:TextBox ID="txtMarca" runat="server" class="w-100 form-control mt-2 mtb-2" placeholder="Inserisci la marca" ></asp:TextBox></div>
            <div class="container mt-3 mb-3"><asp:TextBox ID="txtModello" runat="server" class="w-100 form-control mt-2 mtb-2" placeholder="Inserisci il modello" ></asp:TextBox></div>
            <div class="container mt-3 mb-3"><asp:TextBox ID="txtCosto" runat="server" class="w-100 form-control mt-2 mtb-2" placeholder="Inserisci il costo" ></asp:TextBox></div>
            <div class="container mt-3 mb-3"><asp:TextBox ID="txtCat" runat="server" class="w-100 form-control mt-2 mtb-2" placeholder="Inserisci la categoria" ></asp:TextBox></div>
            <div class="container mt-3 mb-3"><asp:TextBox ID="txtAlimentazione" runat="server" class="w-100 form-control mt-2 mtb-2" placeholder="Inserisci l'alimentazione" ></asp:TextBox></div>
            <div class="container mt-3 mb-3"><asp:Button ID="btnInsert" runat="server" Text="Inserisci auto" class="btn btn-success w-100 mt-4 mb-4" OnClick="insertAuto" /></div>
            <div class="container mt-3 mb-3"><asp:Button ID="btnBack2" runat="server" Text="Torna alla lista auto" class="btn btn-success w-100 mt-4 mb-4" OnClick="backToAuto" /></div>
        </asp:Panel>
    
  <!-- Services -->
  <section class="page-section" id="services">
    <div class="container">
      <div class="row">
        <div class="col-lg-12 text-center">
          <h2 class="section-heading text-uppercase">Services</h2>
          <h3 class="section-subheading text-muted">Lorem ipsum dolor sit amet consectetur.</h3>
        </div>
      </div>
      <div class="row text-center">
        <div class="col-md-4">
          <span class="fa-stack fa-4x">
            <i class="fas fa-circle fa-stack-2x text-primary"></i>
            <i class="fas fa-shopping-cart fa-stack-1x fa-inverse"></i>
          </span>
          <h4 class="service-heading">E-Commerce</h4>
          <p class="text-muted">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Minima maxime quam architecto quo inventore harum ex magni, dicta impedit.</p>
        </div>
        <div class="col-md-4">
          <span class="fa-stack fa-4x">
            <i class="fas fa-circle fa-stack-2x text-primary"></i>
            <i class="fas fa-laptop fa-stack-1x fa-inverse"></i>
          </span>
          <h4 class="service-heading">Responsive Design</h4>
          <p class="text-muted">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Minima maxime quam architecto quo inventore harum ex magni, dicta impedit.</p>
        </div>
        <div class="col-md-4">
          <span class="fa-stack fa-4x">
            <i class="fas fa-circle fa-stack-2x text-primary"></i>
            <i class="fas fa-lock fa-stack-1x fa-inverse"></i>
          </span>
          <h4 class="service-heading">Web Security</h4>
          <p class="text-muted">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Minima maxime quam architecto quo inventore harum ex magni, dicta impedit.</p>
        </div>
      </div>
    </div>
  </section>
   
    <!-- Footer -->
  <footer class="footer">
    <div class="container">
      <div class="row align-items-center">
        <div class="col-md-4">
          <span class="copyright">Copyright &copy; Your Website 2019</span>
        </div>
        <div class="col-md-4">
          <ul class="list-inline social-buttons">
            <li class="list-inline-item">
              <a href="#">
                <i class="fab fa-twitter"></i>
              </a>
            </li>
            <li class="list-inline-item">
              <a href="#">
                <i class="fab fa-facebook-f"></i>
              </a>
            </li>
            <li class="list-inline-item">
              <a href="#">
                <i class="fab fa-linkedin-in"></i>
              </a>
            </li>
          </ul>
        </div>
        <div class="col-md-4">
          <ul class="list-inline quicklinks">
            <li class="list-inline-item">
              <a href="#">Privacy Policy</a>
            </li>
            <li class="list-inline-item">
              <a href="#">Terms of Use</a>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </footer>
 </form>
    <!-- Bootstrap core JavaScript -->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Plugin JavaScript -->
  <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

  <!-- Contact form JavaScript -->
  <script src="js/jqBootstrapValidation.js"></script>
  <script src="js/contact_me.js"></script>

  <!-- Custom scripts for this template -->
  <script src="js/agency.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
</body>
</html>
