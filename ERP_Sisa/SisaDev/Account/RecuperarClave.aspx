<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarClave.aspx.cs" Inherits="SisaDev.RecuperarClave" %>

<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
 <meta name="description" content="Sisa- Sistemas Automatizados">
  <meta name="author" content="SISA">
  <link rel="shortcut icon" type="image/x-icon" href="/img/logo.ico" />

  <title>Reestablecer clave- Sisa</title>

  <!-- Bootstrap CSS -->
  <link href="../css/bootstrap.min.css" rel="stylesheet">
  <!-- bootstrap theme -->
  <link href="../css/bootstrap-theme.css" rel="stylesheet">
  <!--external css-->
  <!-- font icon -->
  <link href="../css/elegant-icons-style.css" rel="stylesheet" />
  <link href="../css/font-awesome.css" rel="stylesheet" />
  <!-- Custom styles -->
  <link href="../css/style.css" rel="stylesheet">
  <link href="../css/style-responsive.css" rel="stylesheet" />

</head>

<body>

  <div class="container">

    <form runat="server" class="login-form">
      <div class="login-wrap">
        <p class="login-img">
            <img src="../img/logo.png" /><%--><i class="icon_lock_alt"></i>--%></p>
        <div class="input-group">
          <span class="input-group-addon"><i class="icon_profile"></i></span>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" PlaceHolder="Nombre de usuario"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUsuario" CssClass="text-danger" ErrorMessage="El nombre de usuario es obligatorio." />
          
        </div>
          <%--<div class="input-group">
          <span class="input-group-addon"><i class="icon_profile"></i></span>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" PlaceHolder="Correo de recuperación"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCorreo" CssClass="text-danger" ErrorMessage="El correo es obligatorio." />
          
        </div>--%>
          <div class="input-group">
            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
              <div class="alert alert-danger fade in">
                  <asp:Literal runat="server"  ID="FailureText" />
              </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="CorrectMessage" Visible="false">
              <div class="alert alert-success fade in">
                  <asp:Literal runat="server"  ID="CorrectText" />
              </div>
            </asp:PlaceHolder>
          
        </div>
           <label class="checkbox">
                <%--<input type="checkbox" value="remember-me"> Remember me--%>               
                <span class="pull-right"> <a href="#" data-toggle="modal" data-target="#basicModal">Tengo un código</a></span>
            </label>
          <asp:Button runat="server" Text="Enviar solicitud" OnClick="btnEnviar_Click" CssClass="btn btn-primary btn-lg btn-block" ID="btnEnviar" />
          
      </div>
    </form>
    
  </div>

<div class="modal fade" data-backdrop="static" data-keyboard="false" id="basicModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="myModalLabel">Cambiar clave </h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">
        
            <div class="form-group">
              <div class="col-sm-10">
                  <input type="password" class="form-control" placeholder="Código recibido" id="txtCodigoRecibido" required="required"/>
              </div>
            </div>
            <div class="form-group">
              <div class="col-sm-10">
                  <input type="password" class="form-control" placeholder="Clave nueva" id="txtClaveNueva" required="required"/>
              </div>
            </div>
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Antes de presionar botón, revisa la escritura de la clave.</label>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label id="txtMensaje"></label>
              </div>
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
        <button type="button" class="btn btn-primary" id="btnGuardarClave">Enviar</button>
      </div>
      </form>
    </div>
  </div>
</div>


  <!-- javascripts -->
  <script src="../js/jquery.js"></script>
  <script src="../js/bootstrap.min.js"></script>
  <!-- nice scroll -->
  <script src="../js/jquery.scrollTo.min.js"></script>
  <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
  <!--custome script for all page-->
  <script src="../js/scripts.js"></script>
  <script src="../js/RecuperarClave.js"></script>
    <script src="../js/sweetalert2.all.js" type="text/javascript"></script>
  <script src="../js/sweetalert2.min.js" type="text/javascript"></script>
</body>

</html>

