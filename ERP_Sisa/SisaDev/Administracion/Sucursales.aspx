<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sucursales.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Administracion.Sucursales" %>


<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     function EliminarSucursal(btn) {         
         document.getElementById('idSucursalEliminar').textContent = '';
         
            $('#txtModalEliminarSucursal').append('<p id="parrafo">¿Estás seguro de eliminar sucursal con código "' + btn.value + '"?</p>');
         //document.getElementById('idSucursalEliminar').textContent = '';
         document.getElementById('idSucursalEliminar').textContent = btn.value;
         $("#DelSucursalModal").modal();
     }

     function EditarSucursal(btn) {
         $('#EditarSucursalForm').empty();
         //$(btn.value).each(function (index, item) {
         //    var IdSucursal = json[index].idSucursa;
         //    var CiudadSucursal = json[index].CiudadSucursal;
         //    var DireccionSucursal = json[index].DireccionSucursal;
         //    var TelefonoSucursal = json[index].TelefonoSucursal;
         //    $('#EditarSucursalForm').append(' <div class= "modal-body" >  <div class="form-group"> <div class="col-sm-10"> <input type="hidden" class="form-control" id="txtidSucursalEditar" value="' + IdSucursal + '" required/></div></div<div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtCiudadSucursalEditar" value="' + CiudadSucursal + '" required/></div></div><div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtDireccionSucursalEditar" value="' + DireccionSucursal + '" required/></div></div><div class="form-group"> <div class="col-sm-10"><input type="tel" class="form-control"  id="txtTelefonoSucursalEditar" value="' + TelefonoSucursal + '" required/></div> </div>  <div class="form-group"> <div class="col-sm-10"><div class="form-group" id="txtModalEditarMensajeSucursal"> </div></div> </div> </div > <div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> <button class="btn btn-primary" id="btnEditarSucursal" type="button">Guardar cambios</button> </div>');
         //});
         var parametros = "{'pid': '" + btn.value +"'}";
         $.ajax({
             dataType: "json",
             url: "Sucursales.aspx/ObtenerSucursales",
             async: true,
             data: parametros,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             success: function (data) {
                 if (data.d != "") {
                     var json = JSON.parse(data.d);
                     $(json).each(function (index, item) {                         
                         var CiudadSucursal = item.CiudadSucursal;
                         var IdSucursal = item.idSucursa;
                         var DireccionSucursal = item.DireccionSucursal;
                         var TelefonoSucursal = item.TelefonoSucursal;
                         var GerenteSucursal = item.Gerente;
                         var ColoniaSucursal = item.ColoniaSucursal;
                         var CPSucursal = item.CPSucursal;
                         $('#EditarSucursalForm').append(' <div class= "modal-body" >  ' +
                                     '<div class="form-group"> ' +
                                         '<div class="col-sm-10"> ' +
                                            '<input type="hidden" class="form-control" id="txtidSucursalEditar" value="' + IdSucursal + '" required /> ' +
                                         '</div> ' +
                                     '</div> ' +
                                     '<div class="form-group"> ' +
                                         '<div class="col-sm-10"> ' +
                                             '<label>Ciudad</label> ' +
                                             '<input type="text" class="form-control" id="txtCiudadSucursalEditar" value="' + CiudadSucursal + '" readonly /> ' +
                                         '</div> ' +
                                     '</div> ' +
                                     '<div class="form-group"> ' +
                                         '<div class="col-sm-10"> ' +
                                             '<label>Dirección</label> ' +
                                             '<input type="text" class="form-control" id="txtDireccionSucursalEditar" value="' + DireccionSucursal + '" required /> ' +
                                         '</div> ' +
                                     '</div> ' +
                                     '<div class="form-group"> ' +
                                         '<div class="col-sm-10"> ' +
                                             '<label>Colonia</label> ' +
                                             '<input type="text" class="form-control" id="txtColoniaSucursalEditar" value="' + ColoniaSucursal + '" required /> ' +
                                         '</div> ' +
                                     '</div> ' +
                                     '<div class="form-group"> ' +
                                         '<div class="col-sm-10"> ' +
                                             '<label>C.P.</label> ' +
                                             '<input type="text" class="form-control" id="txtCPSucursalEditar" value="' + CPSucursal + '" required /> ' +
                                         '</div> ' +
                                     '</div> ' +
                                     '<div class="form-group"> ' +
                                         '<div class="col-sm-10"> ' +
                                             '<label>Teléfono</label> ' +
                                             '<input type="tel" class="form-control" id="txtTelefonoSucursalEditar" value="' + TelefonoSucursal + '" required /> ' +
                                         '</div> ' +
                                     '</div> ' +
                                     '<div class="form-group"> ' +
                                         '<div class="col-sm-10"> ' +
                                             '<label>Gerente</label> ' +
                                             '<input type="tel" class="form-control" id="txtGerenteSucursalEditar" value="' + GerenteSucursal + '" required /> ' +
                                         '</div> ' +
                                     '</div> ' +
                                     '<div class="form-group"> ' +
                                         '<div class="col-sm-10"> ' +
                                            '<div class="form-group" id="txtModalEditarMensajeSucursal"> </div> ' +
                                         '</div> ' +
                                     '</div> ' +
                                 '</div> ' +
                                 '<div class="modal-footer"> ' +
                                     '<button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> ' +
                                     '<button class="btn btn-primary" id="btnEditarSucursal" onclick="EditarSucursalDesdePopUp();" type="button">Guardar cambios</button> ' +
                                 '</div > ');
                     });
                     $("#EditSucursalModal").modal();
                 }
                 else {
                     $("#CargandoSucursales").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                 }
             }
         });

         
     }    

     function EditarSucursalDesdePopUp() {
         var idSuc = document.getElementById('txtidSucursalEditar').value;
         var CiudadSucursal = document.getElementById('txtCiudadSucursalEditar').value;
         var DireccionSucursal = document.getElementById('txtDireccionSucursalEditar').value;
         var TelefonoSucursal = document.getElementById('txtTelefonoSucursalEditar').value;
         var GerenteSucursal = document.getElementById('txtGerenteSucursalEditar').value;
         var ColoniaSucursal = document.getElementById('txtColoniaSucursalEditar').value;
         var CPSucursal = document.getElementById('txtCPSucursalEditar').value;
         
         var parametros = "{'pid': '" + idSuc +
             "','pCiudad': '" + CiudadSucursal +
             "','pDireccion': '" + DireccionSucursal +
             "','pTelefono': '" + TelefonoSucursal +
             "','pGerente': '" + GerenteSucursal +
             "','pColonia': '" + ColoniaSucursal +
             "','pCP': '" + CPSucursal + "'}";

         $.ajax({
             dataType: "json",
             url: "Sucursales.aspx/EditarSucursal",
             async: true,
             data: parametros,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             success: function (msg) {
                 if (msg.d == "Sucursal actualizada.") {
                     //$("#txtModalEditarMensajeSucursal").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                     CargarSucursales(); //llamada a function en sucursales.js
                     swal(msg.d);
                 }
                 else {
                     //$("#txtModalEditarMensajeSucursal").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                     swal(msg.d);

                 }
             }
         });
     }

     (function (document) {
         'use strict';

         var LightTableFilter = (function (Arr) {

             var _input;

             function _onInputEvent(e) {
                 _input = e.target;
                 var tables = document.getElementsByClassName(_input.getAttribute('data-table'));
                 Arr.forEach.call(tables, function (table) {
                     Arr.forEach.call(table.tBodies, function (tbody) {
                         Arr.forEach.call(tbody.rows, _filter);
                     });
                 });
             }

             function _filter(row) {
                 var text = row.textContent.toLowerCase(), val = _input.value.toLowerCase();
                 row.style.display = text.indexOf(val) === -1 ? 'none' : 'table-row';
             }

             return {
                 init: function () {
                     var inputs = document.getElementsByClassName('light-table-filter');
                     Arr.forEach.call(inputs, function (input) {
                         input.oninput = _onInputEvent;
                     });
                 }
             };
         })(Array.prototype);

         document.addEventListener('readystatechange', function () {
             if (document.readyState === 'complete') {
                 LightTableFilter.init();
             }
         });

     })(document);
 </script>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
   <%-- <div id="loading-img">  <img src="../img/logoloading.png" /></div>--%>
    <section id="main-content">
      <section class="wrapper">
        <div class="row">
          <div class="col-lg-12">
            
            <ol class="breadcrumb">
              <li><i class="icon_folder-open"></i>Administración</li>
              <li><i class="icon_building"></i>Sucursales</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeSucursales">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <header class="panel-heading">
                Lista de sucursales 
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                            <%--<Button class="btn btn-primary" data-toggle="modal" data-target="#AddSucursalModal"><i class="icon_plus_alt2"></i></Button>--%>
                              <a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddSucursalModal"><i class="icon_plus_alt2"></i> Agregar </a>
                          </div>
                          <div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>
                      
                      </form>
                        
                      </div>
              </header>
                <div class="form-group" id="CargandoSucursales">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <table class="table table-striped table-advance table-hover order-table" data-search="true" id="TablaSucursales">
                <thead>
                  <tr>
                        
                    <th style="display:none;"><i class="icon_building"></i> Código</th>
                    <th><i class="icon_building"></i> Ciudad</th>
                    <th><i class="icon_ribbon_alt"></i> Dirección</th>
                    <th><i class=""></i>Colonia</th>
                      <th><i class=""></i>CP</th>
                      <th><i class="icon_profile"></i> Gerente</th>
                    <th><i class="icon_phone"></i> Teléfono</th>
                    
                    <th><i class="icon_ol"></i> Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listasucursales">
                   
                </tbody>
              </table>
            </section>
          </div>
        </div>
        <!-- page end-->
      </section>
    </section>
    <%--AGREGAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddSucursalModal" tabindex="-1" role="dialog" aria-labelledby="AddSucursalModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelAgregarSucursal">Agregar Sucursal</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">
        
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Ciudad</label>
                  <input type="text" class="form-control" placeholder="Ciudad" id="txtCiudadSucursal" required/>
              </div>
            </div>
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Dirección</label>
                  <input type="text" class="form-control" placeholder="Dirección" id="txtDireccionSucursal" required/>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Colonia</label>
                  <input type="text" class="form-control" placeholder="Dirección" id="txtColoniaSucursal" required/>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>CP</label>
                  <input type="text" class="form-control" placeholder="Dirección" id="txtCPSucursal" required/>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Telefono</label>
                  <input type="tel" class="form-control" placeholder="Teléfono" id="txtTelefonoSucursal" required/>
              </div>
            </div>    
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Gerente</label>
                  <input type="tel" class="form-control" placeholder="Gerente" id="txtGerenteSucursal" required/>
              </div>
            </div>   
          <div class="form-group">
              <div class="col-sm-10">
                  <div class="form-group" id="AddMsgSucursal">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              </div>
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-primary" id="btnGuardarSucursal" type="button">Crear</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelSucursalModal" tabindex="-1" role="dialog" aria-labelledby="DelSucursalModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEliminarSucursal">Eliminar Sucursal</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal">
      <div class="modal-body">        
            <div class="form-group" id="txtModalEliminarSucursal">
              <label id="idSucursalEliminar" hidden="hidden"></label>               
            </div>
          <div class="form-group" id="txtModalEliminarMensajeSucursal">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnEliminarSucursal" type="button">Eliminar</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--EDITAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="EditSucursalModal" tabindex="-1" role="dialog" aria-labelledby="EditSucursalModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEditarSucursal">Editar Sucursal</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal" id="EditarSucursalForm"></form>
        
         
    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/Sucursales.js" type="text/javascript" ></script>  
    
</asp:Content>

