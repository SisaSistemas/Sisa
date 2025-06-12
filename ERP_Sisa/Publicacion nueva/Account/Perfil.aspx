<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Sitio.Master" CodeBehind="Perfil.aspx.cs" Inherits="SisaDev.Account.Perfil" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
      <section class="wrapper">
        <div class="row">
          <div class="col-lg-12">
            
            <ol class="breadcrumb">
              <li><i class="icon_house_alt"></i>Usuarios</li>
              <li><i class="icon_profile"></i>Perfil</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         
          <div class="row">
          <div class="col-lg-6">
            <section class="panel">
              <header class="panel-heading">
                Datos generales
              </header>
              <div class="panel-body">
                <%--<form role="form">--%>
                   <div class="form-group">
                    <label for="imgPerfil"></label>
                       <div class="row">
                        <div class="col-lg-6">
                            <form runat="server">
                                <asp:Image ID="ImgPrv" Height="227" Width="162" ClientIDMode="Static" runat="server" />
                                <asp:FileUpload runat="server" ID="FlupImage" onchange="ShowImagePreview(this);" />
                            </form>
                             
                        </div>
                        <div class="col-lg-6">
                            <img src="<%= usuario.Foto %>" id="ImagenActual" class="fotoPerfil" height="227" width="162">
                           
                        </div>
                       </div>                     
                      
                    <p class="help-block">Cambiar foto.</p>
                  </div>
                  <div class="form-group">
                    <label for="txtNombre">Nombre completo</label>
                      <input type="text" class="form-control" runat="server" id="txtNombre" readonly/>
                      <input type="hidden" class="form-control" id="txtId" runat="server"/>
                      <%--<asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox> 
                      <asp:TextBox ID="txtid" runat="server" CssClass="form-control" Visible="false" ReadOnly="true"></asp:TextBox>--%>
                  </div>
                  <div class="form-group">
                    <label for="txtUsuario">Usuario</label>
                      <input type="text" class="form-control" id="txtUsuario" runat="server" readonly/>
                       <%--<asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>--%> 
                  </div>
                  <div class="form-group">
                    <label for="txtCorreo">Correo</label>
                      <input type="text" class="form-control" id="txtCorreo" runat="server" required/>
                      <%--<asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>--%>
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtCorreo" CssClass="text-danger" ErrorMessage="El correo es obligatorio." />--%>
                   
                  </div>
                  <div class="form-group">
                    <label for="txtTelefono">Télefono</label>
                      <input type="tel" class="form-control" id="txtTelefono" runat="server" required/>
                        <%--<asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>--%>
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtTelefono" CssClass="text-danger" ErrorMessage="El télefono es obligatorio." />--%>
                  </div>
                  <div class="form-group" id="ContenedorMensajePerfilGuardado">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
                 
                  <button class="btn btn-primary" type="submit" id="btnGuardarDatosPerfil">Guardar</button>
                     <%--<asp:Button runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" ID="btnGuardar" />--%>                 
                <%--</form>--%>

              </div>
            </section>
          </div>
          <div class="col-lg-6">
            <section class="panel">
              <header class="panel-heading">
                Clave de acceso
              </header>
              <div class="panel-body">
                <form class="form-horizontal" role="form">
                  <div class="form-group">
                    <label for="txtClaveACtual" class="col-lg-2 control-label">Clave actual</label>
                    <div class="col-lg-10">
                      <input type="password" class="form-control" placeholder="Clave actual" id="txtClaveACtual" required="required"/>
                      
                    </div>
                  </div>
                  <div class="form-group">
                    <label for="txtClaveNueva" class="col-lg-2 control-label">Clave nueva</label>
                    <div class="col-lg-10">
                      <input type="password" class="form-control" placeholder="Clave nueva" minlength="8" id="txtClaveNueva" required="required"/>
                    </div>
                  </div>
                  <div class="form-group" id="ContenedorMensajeClave">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
                 
                  <div class="form-group">
                    <div class="col-lg-offset-2 col-lg-10">
                      <button type="submit" class="btn btn-danger" id="btnGuardarClave">Guardar cambios</button>
                    </div>
                  </div>
                </form>
              </div>
            </section>
            
          </div>
        </div>
        <!-- page end-->
      </section>
    </section>

    

</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/Perfil.js" type="text/javascript" ></script>  
  <%--<script src="../js/jquery.js" type="text/javascript"></script>
  <script src="../js/bootstrap.min.js" type="text/javascript" ></script>
  <!-- nice scroll -->
  <script src="../js/jquery.scrollTo.min.js" type="text/javascript" ></script>
  <script src="../js/jquery.nicescroll.js" type="text/javascript" ></script>
  <!--custome script for all page-->
  <script src="../js/scripts.js" type="text/javascript" ></script>--%>
    
</asp:Content>
