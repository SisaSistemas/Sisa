<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mecanico.aspx.cs" MasterPageFile="~/Sitio.Master"  Inherits="SisaDev.Proyectos.Mecanico" %>


<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     function EliminarMecanico(btn) {
         document.getElementById('idMecanicoEliminar').textContent = '';
    $('#txtModalEliminarMecanico').append('<p>¿Estás seguro de eliminar requisición con código "' + btn.value + '"?</p>');
    document.getElementById('idMecanicoEliminar').textContent = btn.value;
    $("#DelMecanicoModal").modal();
     }
     function EditarMecanico(btn) {
         $('#EditarMecanicoForm').empty();
         //$(btn.value).each(function (index, item) {
         //    var IdMecanico = json[index].idSucursa;
         //    var CiudadMecanico = json[index].CiudadMecanico;
         //    var DireccionMecanico = json[index].DireccionMecanico;
         //    var TelefonoMecanico = json[index].TelefonoMecanico;
         //    $('#EditarMecanicoForm').append(' <div class= "modal-body" >  <div class="form-group"> <div class="col-sm-10"> <input type="hidden" class="form-control" id="txtidMecanicoEditar" value="' + IdMecanico + '" required/></div></div<div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtCiudadMecanicoEditar" value="' + CiudadMecanico + '" required/></div></div><div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtDireccionMecanicoEditar" value="' + DireccionMecanico + '" required/></div></div><div class="form-group"> <div class="col-sm-10"><input type="tel" class="form-control"  id="txtTelefonoMecanicoEditar" value="' + TelefonoMecanico + '" required/></div> </div>  <div class="form-group"> <div class="col-sm-10"><div class="form-group" id="txtModalEditarMensajeMecanico"> </div></div> </div> </div > <div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> <button class="btn btn-primary" id="btnEditarMecanico" type="button">Guardar cambios</button> </div>');
         //});
         var parametros = "{'pid': '" + btn.value +"'}";
         $.ajax({
             dataType: "json",
             url: "Mecanico.aspx/ObtenerMecanico",
             async: true,
             data: parametros,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             success: function (data) {
                 if (data.d != "") {
                     var json = JSON.parse(data.d);
                     $(json).each(function (index, item) {                         
                         var CiudadMecanico = item.CiudadMecanico;
                         var IdMecanico = item.idSucursa;
                         var DireccionMecanico = item.DireccionMecanico;
                         var TelefonoMecanico = item.TelefonoMecanico;
                         $('#EditarMecanicoForm').append(' <div class= "modal-body" >  <div class="form-group"> <div class="col-sm-10"> <input type="hidden" class="form-control" id="txtidMecanicoEditar" value="' + IdMecanico + '" required/></div></div<div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtCiudadMecanicoEditar" value="' + CiudadMecanico + '" readonly/></div></div><div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtDireccionMecanicoEditar" value="' + DireccionMecanico + '" required/></div></div><div class="form-group"> <div class="col-sm-10"><input type="tel" class="form-control"  id="txtTelefonoMecanicoEditar" value="' + TelefonoMecanico + '" required/></div> </div>  <div class="form-group"> <div class="col-sm-10"><div class="form-group" id="txtModalEditarMensajeMecanico"> </div></div> </div> </div > <div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> <button class="btn btn-primary" id="btnEditarMecanico" onclick="EditarMecanicoDesdePopUp();" type="button">Guardar cambios</button> </div>');
                     });
                     $("#EditMecanicoModal").modal();
                 }
                 else {
                     $("#CargandoMecanico").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                 }
             }
         });

         
     }    
     function EditarMecanicoDesdePopUp() {
         var idSuc = document.getElementById('txtidMecanicoEditar').value;
         var CiudadMecanico = document.getElementById('txtCiudadMecanicoEditar').value;
         var DireccionMecanico = document.getElementById('txtDireccionMecanicoEditar').value;
         var TelefonoMecanico = document.getElementById('txtTelefonoMecanicoEditar').value;

         var parametros = "{'pid': '" + idSuc + "','pCiudad': '" + CiudadMecanico + "','pDireccion': '" + DireccionMecanico + "','pTelefono': '" + TelefonoMecanico + "'}";
         $.ajax({
             dataType: "json",
             url: "Mecanico.aspx/EditarMecanico",
             async: true,
             data: parametros,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             success: function (msg) {
                 if (msg.d == "Mecanico actualizada.") {
                     $("#txtModalEditarMensajeMecanico").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                     CargarMecanico(); //llamada a function en Mecanico.js
                 }
                 else {
                     $("#txtModalEditarMensajeMecanico").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');

                 }
             }
         });
     }

 </script>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
   <%--  <div id="loading-img">  <img src="../img/logoloading.png" /></div>--%>
    <section id="main-content">
      <section class="wrapper">
        <div class="row">
          <div class="col-lg-12">
            
            <ol class="breadcrumb">
              <li><i class="icon_folder-open"></i>Administración</li>
              <li><i class="icon_building"></i>Mecanico</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeMecanico">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <header class="panel-heading">
                Lista de Mecanico 
                  <div class="btn-group" id="botones">
                        <Button class="btn btn-primary" data-toggle="modal" data-target="#AddMecanicoModal"><i class="icon_plus_alt2"></i></Button>
                      </div>
              </header>
                <div class="form-group" id="CargandoMecanico">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <table class="table table-striped table-advance table-hover" id="TablaMecanico">
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
                <tbody id="listaMecanico">
                   
                </tbody>
              </table>
            </section>
          </div>
        </div>
        <!-- page end-->
      </section>
    </section>
    <%--AGREGAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddMecanicoModal" tabindex="-1" role="dialog" aria-labelledby="AddMecanicoModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelAgregarMecanico">Agregar Mecanico</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">
        
            <div class="form-group">
              <div class="col-sm-10">
                  <input type="text" class="form-control" placeholder="Ciudad" id="txtCiudadMecanico" required/>
              </div>
            </div>
            <div class="form-group">
              <div class="col-sm-10">
                  <input type="text" class="form-control" placeholder="Dirección" id="txtDireccionMecanico" required/>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <input type="tel" class="form-control" placeholder="Teléfono" id="txtTelefonoMecanico" required/>
              </div>
            </div>            
          <div class="form-group">
              <div class="col-sm-10">
                  <div class="form-group" id="AddMsgMecanico">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              </div>
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-primary" id="btnGuardarMecanico" type="button">Crear</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelMecanicoModal" tabindex="-1" role="dialog" aria-labelledby="DelMecanicoModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEliminarMecanico">Eliminar Mecanico</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalEliminarMecanico">
              <label id="idMecanicoEliminar" hidden="hidden"></label>               
            </div>
          <div class="form-group" id="txtModalEliminarMensajeMecanico">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnEliminarMecanico" type="button">Eliminar</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--EDITAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="EditMecanicoModal" tabindex="-1" role="dialog" aria-labelledby="EditMecanicoModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEditarMecanico">Editar Mecanico</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal" id="EditarMecanicoForm"></form>
        
         
    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">

    
</asp:Content>






