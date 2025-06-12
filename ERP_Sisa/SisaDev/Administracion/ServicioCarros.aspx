<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServicioCarros.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Compras.ServicioCarros" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>     
     function EditarCarro(btn) {
         $('#EditarCarroForm').empty();
         //$(btn.value).each(function (index, item) {
         //    var IdCarro = json[index].idSucursa;
         //    var CiudadCarro = json[index].CiudadCarro;
         //    var DireccionCarro = json[index].DireccionCarro;
         //    var TelefonoCarro = json[index].TelefonoCarro;
         //    $('#EditarCarroForm').append(' <div class= "modal-body" >  <div class="form-group"> <div class="col-sm-10"> <input type="hidden" class="form-control" id="txtidCarroEditar" value="' + IdCarro + '" required/></div></div<div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtCiudadCarroEditar" value="' + CiudadCarro + '" required/></div></div><div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtDireccionCarroEditar" value="' + DireccionCarro + '" required/></div></div><div class="form-group"> <div class="col-sm-10"><input type="tel" class="form-control"  id="txtTelefonoCarroEditar" value="' + TelefonoCarro + '" required/></div> </div>  <div class="form-group"> <div class="col-sm-10"><div class="form-group" id="txtModalEditarMensajeCarro"> </div></div> </div> </div > <div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> <button class="btn btn-primary" id="btnEditarCarro" type="button">Guardar cambios</button> </div>');
         //});
         var parametros = "{'pid': '" + btn.value + "'}";
         $.ajax({
             dataType: "json",
             url: "ServicioCarros.aspx/ObtenerCarros",
             async: true,
             data: parametros,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             success: function (data) {
                 if (data.d != "") {
                     var json = JSON.parse(data.d);
                     $(json).each(function (index, item) {
                         var Comentarios = item.Comentarios;
                         var IdCarro = item.IdCarro;
                         var Anio = item.Anio;
                         var Vehiculo = item.Vehiculo;
                         $('#EditarCarroForm').append(' <div class= "modal-body" >  <div class="form-group"> <div class="col-sm-10"> <input type="hidden" class="form-control" id="txtidCarroEditar" value="' + IdCarro + '" required/></div></div<div class="form-group"><div class="col-sm-10"><label>Vehiculo</label><input type="text" class="form-control" id="txtCarroEditar" value="' + Vehiculo + '" readonly/></div></div><div class="form-group"><div class="col-sm-10"><label>Año</label><input type="text" class="form-control" id="txtAnioCarroEditar" value="' + Anio + '" readonly/></div></div><div class="form-group"> <div class="col-sm-10"><label>Comentarios</label><textarea class="form-control" rows="8"  id="txtComentariosCarroEditar" value="" required>' + Comentarios + '</textarea></div> </div>  <div class="form-group"> <div class="col-sm-10"><div class="form-group" id="txtModalEditarMensajeCarro"> </div></div> </div> </div > <div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> <button class="btn btn-primary" id="btnEditarCarro" onclick="EditarCarroDesdePopUp();" type="button">Guardar cambios</button> </div>');
                     });
                     $("#EditCarroModal").modal();
                 }
                 else {
                     $("#CargandoCarro").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                 }
             }
         });


     }
     function EditarCarroDesdePopUp() {

         var Comentarios = document.getElementById('txtComentariosCarroEditar').value;
         var IdCarro = document.getElementById('txtidCarroEditar').value;
         var parametros = "{'pid': '" + IdCarro + "','cComentarios': '" + Comentarios + "'}";
         $.ajax({
             dataType: "json",
             url: "ServicioCarros.aspx/EditarCarro",
             async: true,
             data: parametros,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             success: function (msg) {
                 if (msg.d == "Carro actualizada.") {
                     //$("#txtModalEditarMensajeCarro").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                     CargarVehiculos(); //llamada a function en Carro.js
                     swal(msg.d);
                 }
                 else {
                     //$("#txtModalEditarMensajeCarro").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                     swal(msg.d);
                 }
             }
         });
     }

     function AgregarServicio(btn) {
         document.getElementById('idServicioCarro').textContent = btn.value;
         var params = "{'pid': '" + btn.value + "'}";
         $.ajax({
             async: true,
             url: "ServicioCarros.aspx/CargarServicios",
             dataType: "json",
             data: params,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             success: function (data, textStatus) {

                 var datos = "";
                 var nodoTRAgregar = "";
                 var JsonCombos;
                 var jsonArray = $.parseJSON(data.d);
                 $('#TablaPrincipalServicio tbody').html('');
                 $.each(jsonArray, function (index, value) {
                     nodoTRAgregar += "<tr>";
                     nodoTRAgregar += '  <td style="display: none;">' + value.IdServicioVehiculo + "</td>";
                     nodoTRAgregar += "  <td>" + value.KilometrajeActual + "</td>";
                     nodoTRAgregar += "  <td>" + value.KilometrajeProximo + "</td>";
                     nodoTRAgregar += "  <td>" + value.FechaServicio + "</td>";
                     nodoTRAgregar += "  <td>" + value.Taller + "</td>";
                     nodoTRAgregar += "  <td>" + value.TipoServicio + "</td>";
                     nodoTRAgregar += "</tr>";
                 });

                 $('#TablaPrincipalServicio tbody').append(nodoTRAgregar);
             }
         });
         $("#AddServicioCarroModal").modal();
     }
     function EliminaCarro(btn) {
         document.getElementById('idCarroEliminar').textContent = '';
         document.getElementById('idCarroEliminarMsj').textContent = '¿Estás seguro de eliminar carro "' + btn.value + '"?';
         document.getElementById('idCarroEliminar').textContent = btn.value;
         $("#DelCarroModal").modal();
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
              <li><i class="icon_building"></i>Carro</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeCarro">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <header class="panel-heading">
                Lista de ServicioCarro 
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                           <%--<Button class="btn btn-primary" data-toggle="modal" data-target="#AddCarroModal"><i class="icon_plus_alt2"></i></Button>--%>
                              <a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddCarroModal"><i class="icon_plus_alt2"></i> Agregar </a>
                          </div>
                          <div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>
                      
                      </form>
                        
                      </div>
              </header>
                <div class="form-group" id="CargandoCarro">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
                <div style="overflow-x: auto; overflow-y: auto; height:500px;"> 
              <table class="table table-striped table-advance table-hover order-table" id="TablaCarro">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i>Código</th>
                       <th><i class="icon_info_alt"></i>Fecha</th>
                    <th><i class="icon_table"></i> Vehiculo</th>
                      <th><i class="icon_info_alt"></i> Año</th>
                    <th><i class="icon_link_alt"></i> Comentarios</th>
                   
                      
                    <th><i class="icon_ol"></i> Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaCarro">
                   
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
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddCarroModal" tabindex="-1" role="dialog" aria-labelledby="AddCarroModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelAgregarCarro">Agregar Carro</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">
        
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Vehiculo</label>
                  <input type="text" class="form-control" placeholder="Vehiculo" id="txtCarro" required/>
              </div>
            </div>
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Año</label>
                  <input type="number" class="form-control" placeholder="Año" id="txtAnio" required/>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Comentarios</label>
                  <textarea class="form-control" placeholder="Comentarios" id="txCComentarios" rows="5" required></textarea>
              </div>
            </div>            
          <div class="form-group">
              <div class="col-sm-10">
                  <div class="form-group" id="AddMsgCarro">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              </div>
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-primary" id="btnGuardarCarro" type="button">Crear</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelCarroModal" tabindex="-1" role="dialog" aria-labelledby="DelCarroModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEliminarCarro">Eliminar Carro</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalEliminarCarro">
              <label id="idCarroEliminar" hidden="hidden"></label>               
              <label id="idCarroEliminarMsj"></label>               
            </div>
          <div class="form-group" id="txtModalEliminarMensajeCarro">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnEliminarCarro" type="button">Eliminar</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--EDITAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="EditCarroModal" tabindex="-1" role="dialog" aria-labelledby="EditCarroModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEditarCarro">Editar Carro</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal" id="EditarCarroForm">

        </form>
        
         
    </div>
  </div>
</div>
    <%--AGREGAR SERVICIO--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddServicioCarroModal" tabindex="-1" role="dialog" aria-labelledby="AddServicioCarroModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelServicioAgregarCarro">Agregar servicio de Carro</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">
        
            <div class="form-group">
              <div class="col-sm-10">
                  <input type="hidden" id="idServicioCarro" />
                  <input class="form-control" type="number" id="idKmAc" placeholder="KM Anterior" required/>
                  
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <input class="form-control" type="number" id="idKmPr" placeholder="KM Actual" required/>                  
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Fecha de servicio</label>
                  <input class="form-control" type="date" id="txtFecha" required>      
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <input class="form-control" type="text" id="txtTaller" placeholder="Taller de servicio" required/>                  
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <input class="form-control" type="text" id="txtTipoServicio" placeholder="Tipo de servicio" required/>                  
              </div>
            </div>
           <span class="btn btn-success" id="btnAgregarServicio"><i class="fa fa-plus"></i>Agregar</span>
          <div id="testmodalServicios" style="padding: 5px 20px;">
              <table id="TablaPrincipalServicio" class="table table-striped projects">
                  <thead>
                      <tr>
                          <th style="display:none;">#</th>
                          <th>Kilometraje anterior</th>
                          <th>Kilometraje actual</th>
                          <th>Fecha</th>
                          <th>Taller</th>
                          <th>Tipo Servicio</th>
                      </tr>
                  </thead>
                  <tbody>
                  </tbody>
              </table>
          </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <div class="form-group" id="AddMsgServicioCarro">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              </div>
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <%--<button class="btn btn-primary" id="btnGuardarServicioCarro" type="button">Crear</button>--%>
      </div>
      </form>
      </div>
    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/ServicioCarros.js" type="text/javascript"></script>
    
</asp:Content>





