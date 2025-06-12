<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SisaDev.Cliente.Default" %>


<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
 <meta name="description" content="Sisa- Sistemas Automatizados">
  <meta name="author" content="SISA">
  <link rel="shortcut icon" type="image/x-icon" href="../img/logo.ico" />

  <title>Acceder- Sisa</title>

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

<body class="login-img3-body">

  <div class="container">

    <form runat="server" class="login-form">
      <div class="login-wrap">
        <p class="login-img">
            <img src="../img/logo.png" /><%--><i class="icon_lock_alt"></i>--%></p>
        <div class="input-group">
          <span class="input-group-addon"><i class="icon_profile"></i></span>
            <asp:TextBox ID="UserName" runat="server" CssClass="form-control" PlaceHolder="Usuario"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="text-danger" ErrorMessage="El campo de usuario es obligatorio." />
          
        </div>
        <div class="input-group">
          <span class="input-group-addon"><i class="icon_key_alt"></i></span>
            <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password" PlaceHolder="Contraseña"></asp:TextBox>
           <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
        </div>
          <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
              <div class="alert alert-danger fade in">
                  <asp:Literal runat="server"  ID="FailureText" />
              </div>
            </asp:PlaceHolder>
        <label class="checkbox">
            <span class="pull-left"> <a href="../Default.aspx"> Soy Empleado</a></span>
            </label>
          <asp:Button runat="server" Text="Acceder como cliente" OnClick="btnLoginCliente_Click" CssClass="btn btn-primary btn-lg btn-block" ID="btnLoginCliente" />
           
      </div>
    </form>
    
  </div>


</body>

</html>


