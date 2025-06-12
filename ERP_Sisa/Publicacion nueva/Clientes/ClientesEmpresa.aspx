<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientesEmpresa.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Clientes.Empresas" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     function EliminarEmpresa(btn) {
         document.getElementById('idEmpresaEliminar').textContent = '';
         //$('#txtModalEliminarEmpresa').append('<p>¿Estás seguro de eliminar Empresa con código "' + btn.value + '"?</p>');
         document.getElementById('idEmpresaEliminarTexto').textContent = '¿Estás seguro de eliminar Empresa con código "' + btn.value + '"?';

         document.getElementById('idEmpresaEliminar').textContent = btn.value;
         $("#DelEmpresaModal").modal();

     }
     function ActivarEmpresa(btn) {
         document.getElementById('idEmpresaActivar').textContent = '';
         //$('#txtModalEliminarEmpresa').append('<p>¿Estás seguro de eliminar Empresa con código "' + btn.value + '"?</p>');
         document.getElementById('idEmpresaActivarTexto').textContent = '¿Estás seguro de reactivar Empresa con código "' + btn.value + '"?';

         document.getElementById('idEmpresaActivar').textContent = btn.value;
         $("#ActivarEmpresaModal").modal();

     }
     function EditarEmpresa(btn) {
         $('#EditarEmpresaForm').empty();
         //$(btn.value).each(function (index, item) {
         //    var IdEmpresa = json[index].idSucursa;
         //    var CiudadEmpresa = json[index].CiudadEmpresa;
         //    var DireccionEmpresa = json[index].DireccionEmpresa;
         //    var TelefonoEmpresa = json[index].TelefonoEmpresa;
         //    $('#EditarEmpresaForm').append(' <div class= "modal-body" >  <div class="form-group"> <div class="col-sm-10"> <input type="hidden" class="form-control" id="txtidEmpresaEditar" value="' + IdEmpresa + '" required/></div></div<div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtCiudadEmpresaEditar" value="' + CiudadEmpresa + '" required/></div></div><div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtDireccionEmpresaEditar" value="' + DireccionEmpresa + '" required/></div></div><div class="form-group"> <div class="col-sm-10"><input type="tel" class="form-control"  id="txtTelefonoEmpresaEditar" value="' + TelefonoEmpresa + '" required/></div> </div>  <div class="form-group"> <div class="col-sm-10"><div class="form-group" id="txtModalEditarMensajeEmpresa"> </div></div> </div> </div > <div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> <button class="btn btn-primary" id="btnEditarEmpresa" type="button">Guardar cambios</button> </div>');
         //});
         var parametros = "{'pid': '" + btn.value + "'}";
         $.ajax({
             dataType: "json",
             url: "ClientesEmpresa.aspx/ObtenerEmpresas",
             async: true,
             data: parametros,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             success: function (data) {
                 if (data.d != "") {
                     var json = JSON.parse(data.d);
                     $(json).each(function (index, item) {
                         var CiudadEmpresa = item.Ciudad;
                         var IdEmpresa = item.idEmpresa;
                         var DireccionEmpresa = item.DireccionFiscal;
                         var TelefonoEmpresa = item.Telefono;
                         var CP = item.CP;
                         var RZ = item.RazonSocial;
                         var Cliente = item.Cliente;
                         var RFC = item.RFC;
                         var Correo = item.Correo;
                         $('#EditarEmpresaForm').append(' <div class= "modal-body" >  <div class="form-group"> <div class="col-sm-10"> <input type="hidden" class="form-control" id="txtidEmpresaEditar" value="' + IdEmpresa + '" required/></div></div><div class="form-group"><div class= "col-sm-10" ><label>Empresa</label><input type="text" class="form-control" placeholder="Empresa" id="txtClienteEditar" value="' + Cliente + '"/></div ></div ><div class="form-group"><div class="col-sm-10"><label>Razón social</label><input type="text" class="form-control" id="txtRZEditar" value="' + RZ + '" /></div></div><div class="form-group"><div class="col-sm-10"><label>RFC</label><input type="text" class="form-control" maxlenght="13" id="txtRFCEditar" value="' + RFC + '"/></div></div><div class="form-group"><div class="col-sm-10"><label>Correo</label><input type="email" class="form-control" id="txtCorreoEditar" value="' + Correo + '" /></div></div><div class="form-group"><div class="col-sm-10"><label>Dirección</label><input type="text" class="form-control" id="txtDireccionEditar" value="' + DireccionEmpresa + '" /></div></div><div class="form-group"><div class="col-sm-10"><label>Código postal</label><input type="number" class="form-control" id="txtCPEditar" value="' + CP + '" /></div></div><div class="form-group"><div class="col-sm-10"><label>Télefono</label><input type="tel" class="form-control" id="txtTelefonoEditar" value="' + TelefonoEmpresa + '" /></div></div><div class="form-group"><div class="col-sm-10"><label>Ciudad</label><input type="text" class="form-control" id="txtCiudadEmpresaEditar" value="' + CiudadEmpresa + '"/></div></div> <div class="form-group"> <div class="col-sm-10"><div class="form-group" id="txtModalEditarMensajeEmpresa"> </div></div> </div> </div > <div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> <button class="btn btn-primary" id="btnEditarEmpresa" onclick="EditarEmpresaDesdePopUp();" type="button">Guardar cambios</button> </div>');
                     });
                     $("#EditEmpresaModal").modal();
                 }
                 else {
                     $("#CargandoEmpresa").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                 }
             }
         });


     }
     function EditarEmpresaDesdePopUp() {
         var idEmpresa = document.getElementById('txtidEmpresaEditar').value;
         var RZEdit = document.getElementById('txtRZEditar').value;
         var RFCEdit = document.getElementById('txtRFCEditar').value;
         var CorreoEdit = document.getElementById('txtCorreoEditar').value;
         var CiudadEmpresaEdit = document.getElementById('txtCiudadEmpresaEditar').value;
         var DireccionEdit = document.getElementById('txtDireccionEditar').value;
         var TelefonoEmpresaEdit = document.getElementById('txtTelefonoEditar').value;
         var CPEdit = document.getElementById('txtCPEditar').value;
         var ClienteEdit = document.getElementById('txtClienteEditar').value;

         var parametros = "{'pid': '" + idEmpresa + "','pRZ': '" + RZEdit + "','pDireccion': '" + DireccionEdit + "','pTelefono': '" + TelefonoEmpresaEdit + "','pRFC': '" + RFCEdit + "','pCorreo': '" + CorreoEdit + "','pCP': '" + CPEdit + "','pCiudad': '" + CiudadEmpresaEdit + "','pCliente': '" + ClienteEdit + "'}";
         $.ajax({
             dataType: "json",
             url: "ClientesEmpresa.aspx/EditarEmpresa",
             async: true,
             data: parametros,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             success: function (msg) {
                 if (msg.d == "Empresa actualizada.") {
                     //$("#txtModalEditarMensajeEmpresa").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                     swal(msg.d);
                     CargarEmpresa(); //llamada a function en Empresa.js
                 }
                 else {
                     //$("#txtModalEditarMensajeEmpresa").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                     swal(msg.d);

                 }
             }
         });
     }


 </script>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div id="loading-img">  <img src="../img/logoloading.png" /></div>--%>
    <div id="loading"></div>
    <section id="main-content">
      <section class="wrapper">
        <div class="row">
          <div class="col-lg-12">
            
            <ol class="breadcrumb">
              <li><i class="icon_folder-open"></i>Administración</li>
              <li><i class="icon_building"></i>Empresa</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeEmpresa">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <header class="panel-heading">
                Lista de Empresa 
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                            <%--<Button class="btn btn-primary" data-toggle="modal" data-target="#AddEmpresaModal"><i class="icon_plus_alt2"></i></Button>--%>
                              <a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddEmpresaModal"><i class="icon_plus_alt2"></i> Agregar </a>
                             <%-- <Button class="btn btn-default exportToExcel"><i class="icon_document"></i></Button>--%>
                          </div>
                          <%--<div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>--%>
                      
                      </form>
                        
                      </div>
              </header>
                <div class="form-group" id="CargandoEmpresa">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
                <%--<div style="overflow-x: auto; overflow-y: auto; height:800px;"> --%>
              <table class="table table-advance table-hover order-table" id="TablaEmpresa">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i> Código</th>
                    <th><i class="icon_building"></i> Razón Social</th>
                    <th><i class="icon_building"></i>Empresa</th>
                    <th><i class="icon_building"></i> RFC</th>
                    <th><i class="icon_ribbon_alt"></i> Dirección</th>
                    <th><i class="icon_phone"></i> Teléfono</th>
                    <th><i class="icon_mail"></i> Correo</th>
                    <th><i class="icon_building"></i> Ciudad</th>
                    <th><i class="icon_info"></i> CP</th>
                    <th><i class="icon_loading"></i> Estatus</th>
                    <th><i class="icon_ol"></i> Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaEmpresa">
                   
                </tbody>
              </table>
                    </div>
                <div class="col-md-12 text-center">
      <ul class="pagination pagination-lg pager" id="myPager"></ul>
      </div>
            </section>
          </div>
        </div>
        <!-- page end-->
      </section>
    </section>
    <%--AGREGAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddEmpresaModal" tabindex="-1" role="dialog" aria-labelledby="AddEmpresaModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelAgregarEmpresa">Agregar Empresa</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Empresa</label>
                  <input type="text" class="form-control" placeholder="Empresa" id="txtCliente" required/>
              </div>
            </div>
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Razón social</label>
                  <input type="text" class="form-control" placeholder="Razon Social" id="txtRazonSocial" required/>
              </div>
            </div>
           <div class="form-group">
              <div class="col-sm-10">
                  <label>RFC</label>
                  <input type="text" class="form-control" placeholder="RFC" id="txtRFC" maxlength="13" required/>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Correo</label>
                  <input type="email" class="form-control" placeholder="Correo" id="txtCorreo" required/>
              </div>
            </div>
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Dirección</label>
                  <input type="text" class="form-control" placeholder="Dirección" id="txtDireccionEmpresa" required/>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Código postal</label>
                  <input type="number" class="form-control" placeholder="Código postal" id="txtCP" required/>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Télefono</label>
                  <input type="tel" class="form-control" placeholder="Teléfono" id="txtTelefonoEmpresa" required/>
              </div>
            </div>        
          
          
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Ciudad</label>
                  <input type="text" class="form-control" placeholder="Ciudad" id="txtCiudad" required/>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <div class="form-group" id="AddMsgEmpresa">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              </div>
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-primary" id="btnGuardarEmpresa" type="button">Crear</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelEmpresaModal" tabindex="-1" role="dialog" aria-labelledby="DelEmpresaModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEliminarEmpresa">Eliminar Empresa</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalEliminarEmpresa">
              <label id="idEmpresaEliminar" hidden="hidden"></label>               
              <label id="idEmpresaEliminarTexto"></label>               
            </div>
          <div class="form-group" id="txtModalEliminarMensajeEmpresa">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnEliminarEmpresa" type="button">Eliminar</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--EDITAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="EditEmpresaModal" tabindex="-1" role="dialog" aria-labelledby="EditEmpresaModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEditarEmpresa">Editar Empresa</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal" id="EditarEmpresaForm"></form>
        
         
    </div>
  </div>
</div>
    <%--ACTIVAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="ActivarEmpresaModal" tabindex="-1" role="dialog" aria-labelledby="ActivarEmpresaModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelActivarEmpresa">Activar Empresa</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalActivarEmpresa">
              <label id="idEmpresaActivar" hidden="hidden"></label>               
              <label id="idEmpresaActivarTexto"></label>               
            </div>
          <div class="form-group" id="txtModalActivarMensajeEmpresa">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnActivarEmpresa" type="button">Activar</button>
      </div>
      </form>
    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
     <script src="<%= ResolveUrl("~") %>js/ClienteEmpresa.js" type="text/javascript" ></script> 
    
</asp:Content>
