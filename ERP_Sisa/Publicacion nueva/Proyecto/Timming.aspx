<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Sitio.Master" CodeBehind="Timming.aspx.cs" Inherits="SisaDev.Proyectos.Timming" %>


<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     function EliminarTimming(btn) {
         document.getElementById('idTimmingEliminar').textContent = '';
    $('#txtModalEliminarTimming').append('<p>¿Estás seguro de eliminar requisición con código "' + btn.value + '"?</p>');
    document.getElementById('idTimmingEliminar').textContent = btn.value;
    $("#DelTimmingModal").modal();
     }
     function EditarTimming(btn) {
         $('#EditarTimmingForm').empty();
         //$(btn.value).each(function (index, item) {
         //    var IdTimming = json[index].idSucursa;
         //    var CiudadTimming = json[index].CiudadTimming;
         //    var DireccionTimming = json[index].DireccionTimming;
         //    var TelefonoTimming = json[index].TelefonoTimming;
         //    $('#EditarTimmingForm').append(' <div class= "modal-body" >  <div class="form-group"> <div class="col-sm-10"> <input type="hidden" class="form-control" id="txtidTimmingEditar" value="' + IdTimming + '" required/></div></div<div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtCiudadTimmingEditar" value="' + CiudadTimming + '" required/></div></div><div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtDireccionTimmingEditar" value="' + DireccionTimming + '" required/></div></div><div class="form-group"> <div class="col-sm-10"><input type="tel" class="form-control"  id="txtTelefonoTimmingEditar" value="' + TelefonoTimming + '" required/></div> </div>  <div class="form-group"> <div class="col-sm-10"><div class="form-group" id="txtModalEditarMensajeTimming"> </div></div> </div> </div > <div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> <button class="btn btn-primary" id="btnEditarTimming" type="button">Guardar cambios</button> </div>');
         //});
         var parametros = "{'pid': '" + btn.value +"'}";
         $.ajax({
             dataType: "json",
             url: "Timming.aspx/ObtenerTimming",
             async: true,
             data: parametros,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             success: function (data) {
                 if (data.d != "") {
                     var json = JSON.parse(data.d);
                     $(json).each(function (index, item) {                         
                         var CiudadTimming = item.CiudadTimming;
                         var IdTimming = item.idSucursa;
                         var DireccionTimming = item.DireccionTimming;
                         var TelefonoTimming = item.TelefonoTimming;
                         $('#EditarTimmingForm').append(' <div class= "modal-body" >  <div class="form-group"> <div class="col-sm-10"> <input type="hidden" class="form-control" id="txtidTimmingEditar" value="' + IdTimming + '" required/></div></div<div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtCiudadTimmingEditar" value="' + CiudadTimming + '" readonly/></div></div><div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtDireccionTimmingEditar" value="' + DireccionTimming + '" required/></div></div><div class="form-group"> <div class="col-sm-10"><input type="tel" class="form-control"  id="txtTelefonoTimmingEditar" value="' + TelefonoTimming + '" required/></div> </div>  <div class="form-group"> <div class="col-sm-10"><div class="form-group" id="txtModalEditarMensajeTimming"> </div></div> </div> </div > <div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> <button class="btn btn-primary" id="btnEditarTimming" onclick="EditarTimmingDesdePopUp();" type="button">Guardar cambios</button> </div>');
                     });
                     $("#EditTimmingModal").modal();
                 }
                 else {
                     $("#CargandoTimming").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                 }
             }
         });

         
     }    
     function EditarTimmingDesdePopUp() {
         var idSuc = document.getElementById('txtidTimmingEditar').value;
         var CiudadTimming = document.getElementById('txtCiudadTimmingEditar').value;
         var DireccionTimming = document.getElementById('txtDireccionTimmingEditar').value;
         var TelefonoTimming = document.getElementById('txtTelefonoTimmingEditar').value;

         var parametros = "{'pid': '" + idSuc + "','pCiudad': '" + CiudadTimming + "','pDireccion': '" + DireccionTimming + "','pTelefono': '" + TelefonoTimming + "'}";
         $.ajax({
             dataType: "json",
             url: "Timming.aspx/EditarTimming",
             async: true,
             data: parametros,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             success: function (msg) {
                 if (msg.d == "Timming actualizada.") {
                     $("#txtModalEditarMensajeTimming").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                     CargarTimming(); //llamada a function en Timming.js
                 }
                 else {
                     $("#txtModalEditarMensajeTimming").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');

                 }
             }
         });
     }

 </script>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
      <section class="wrapper">
        <div class="row">
          <div class="col-lg-12">
            
            <ol class="breadcrumb">
              <li><i class="icon_folder-open"></i>Administración</li>
              <li><i class="icon_building"></i>Timming</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeTimming">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <header class="panel-heading">
                Lista de Timming 
                  <div class="btn-group" id="botones">
                        <Button class="btn btn-primary" data-toggle="modal" data-target="#AddTimmingModal"><i class="icon_plus_alt2"></i></Button>
                      </div>
              </header>
                <div class="form-group" id="CargandoTimming">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <table class="table table-striped table-advance table-hover" id="TablaTimming">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i>Código</th>
                    <th><i class="icon_building"></i>Folio</th>
                    <th><i class="icon_building"></i>Proyecto</th>
                      <th><i class="icon_profile"></i>Fecha</th>
                    <th><i class="icon_phone"></i>Fecha autorizada</th>
                    <th><i class="icon_phone"></i>Fecha compra</th>
                    <th><i class="icon_phone"></i>Observaciones</th>                      
                    <th><i class="icon_ol"></i> Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaTimming">
                   
                </tbody>
              </table>
            </section>
          </div>
        </div>
        <!-- page end-->
      </section>
    </section>
    <%--AGREGAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddTimmingModal" tabindex="-1" role="dialog" aria-labelledby="AddTimmingModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelAgregarTimming">Agregar Timming</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">
        
            <div class="form-group">
              <div class="col-sm-10">
                  <input type="text" class="form-control" placeholder="Ciudad" id="txtCiudadTimming" required/>
              </div>
            </div>
            <div class="form-group">
              <div class="col-sm-10">
                  <input type="text" class="form-control" placeholder="Dirección" id="txtDireccionTimming" required/>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <input type="tel" class="form-control" placeholder="Teléfono" id="txtTelefonoTimming" required/>
              </div>
            </div>            
          <div class="form-group">
              <div class="col-sm-10">
                  <div class="form-group" id="AddMsgTimming">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              </div>
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-primary" id="btnGuardarTimming" type="button">Crear</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelTimmingModal" tabindex="-1" role="dialog" aria-labelledby="DelTimmingModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEliminarTimming">Eliminar Timming</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalEliminarTimming">
              <label id="idTimmingEliminar" hidden="hidden"></label>               
            </div>
          <div class="form-group" id="txtModalEliminarMensajeTimming">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnEliminarTimming" type="button">Eliminar</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--EDITAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="EditTimmingModal" tabindex="-1" role="dialog" aria-labelledby="EditTimmingModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEditarTimming">Editar Timming</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal" id="EditarTimmingForm"></form>
        
         
    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">

    
</asp:Content>






