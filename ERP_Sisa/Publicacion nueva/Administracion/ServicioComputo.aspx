<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Sitio.Master" CodeBehind="ServicioComputo.aspx.cs" Inherits="SisaDev.Administracion.ServicioComputo" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>     
     function EliminaComputo(btn) {
         document.getElementById('idComputoEliminar').textContent = '';
         document.getElementById('idComputoEliminarMsj').textContent = '¿Estás seguro de eliminar servicio de Computo "' + btn.value + '"?';
         document.getElementById('idComputoEliminar').textContent = btn.value;
         $("#DelComputoModal").modal();
     }
     function ServicioRealizado(btn) {
         document.getElementById('idComputoServicioCerrar').textContent = '';
         
         document.getElementById('idComputoServicioCerrar').textContent = btn.value;
         $('#EditarComputoForm').empty();
         var parametros = "{'pid': '" + btn.value + "'}";
         $.ajax({
             dataType: "json",
             url: "ServicioComputo.aspx/ObtenerServicios",
             async: true,
             data: parametros,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             success: function (data) {
                 if (data.d != "") {
                     var json = JSON.parse(data.d);
                     $(json).each(function (index, item) {                        
                         $('#EditarComputoForm').append(' <div class="modal-body"> '
                             + '<div class="form-group"><label>Usuario:</label><input type="text" class="form-control" id="txtResponsableEditar" readonly/><input type="hidden" class="form-control" id="txtResponsableEditarid" readonly/>'
                             + ' <label>Marca y modelo</label><input type="text" class="form-control" placeholder="PC" id="txtComputoEditar" value="' + item.PC +'"/>'
                             + '<label>Número de serie</label><input type="text" class="form-control" placeholder="Serie/Tag" id="txtSeriePCEditar" value="' + item.Serie +'"/>'
                             + '<label>Tipo de servicio</label><select class="form-control" id="txtServicioEditar"><option value="MANTENIMIENTO PREVENTIVO">MANTENIMIENTO PREVENTIVO</option><option value="MANTENIMIENTO CORRECTIVO">MANTENIMIENTO CORRECTIVO</option><option value="CAMBIO DE PIEZA">CAMBIO DE PIEZA</option><option value="FECHA DE MANTENIMIENTO">FECHA DE MANTENIMIENTO</option></select>'
                             + '<label>Fecha proximo mantenimiento</label><input type="date" class="form-control" placeholder="Serie/Tag" id="dtProximoMtoEditar" />'
                             + '<label>Comentarios</label><textarea class="form-control" placeholder="Comentarios" id="txtComentariosCerrados" rows="5" required>' + item.Comentarios +'</textarea></div></div>'                        
                             + ''
                             + '');
                         CargarUsuariosEditar();
                         $('#txtResponsableEditar').val(item.Usuario);                         
                         $('#txtServicioEditar').val(item.Tipo);                         
                         $('#dtProximoMtoEditar').val(item.FechaProximoMantenimiento);                         
                         document.getElementById('idComputoServicioMsj').textContent = '¿Estás seguro de cerrar servicio de Computo a "' + item.PC + '"?';
                     });
                 }
                 else {
                     swal('No se encontro información, intenta de nuevo refrescando pagina.');
                 }
             }
         })
         $("#DelComputoServicioModal").modal();
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
              <li><i class="icon_building"></i>Computo</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeComputo">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <header class="panel-heading">
                Lista de ServicioComputo 
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                            <%--<Button class="btn btn-primary" data-toggle="modal" data-target="#AddComputoModal"><i class="icon_plus_alt2"></i></Button>--%>
                              <a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddComputoModal"><i class="icon_plus_alt2"></i> Agregar </a>
                          </div>
                          <div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>
                      
                      </form>
                        
                      </div>
              </header>
                <div class="form-group" id="CargandoComputo">
                  </div>
                <div style="overflow-x: auto; overflow-y: auto; height:500px;"> 
              <table class="table table-striped table-advance table-hover order-table" id="TablaComputo">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i>Código</th>
                       <th><i class="icon_info_alt"></i>Fecha</th>
                    <th><i class="icon_profile"></i>Usuario</th>
                    <th><i class="icon_table"></i>PC</th>
                    <th><i class="icon_table"></i>Serie</th>
                      <th><i class="icon_info_alt"></i> Tipo servicio</th>
                    <th><i class="icon_link_alt"></i> Comentarios</th>
                   
                      <th><i class="icon_info_alt"></i>Proximo mantenimiento</th>
                      <th><i class="icon_loading"></i>Estatus</th>
                    <th><i class="icon_ol"></i> Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaComputo">
                   
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
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddComputoModal" tabindex="-1" role="dialog" aria-labelledby="AddComputoModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelAgregarComputo">Agregar Computo</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal">
      <div class="modal-body">        
            <div class="form-group">
                <label>Usuario:</label>
                  <select class="form-control selectpicker" data-live-search="true" id="txtResponsable"></select>
                <label>Marca y modelo</label>
                  <input type="text" class="form-control" placeholder="PC" id="txtComputo"/>
                 <label>Número de serie</label>
                  <input type="text" class="form-control" placeholder="Serie/Tag" id="txtSeriePC"/>
                <label>Tipo de servicio</label>
                    <select class="form-control" id="txtServicio"> 
                        <option value="MANTENIMIENTO PREVENTIVO">MANTENIMIENTO PREVENTIVO</option>
                        <option value="MANTENIMIENTO CORRECTIVO">MANTENIMIENTO CORRECTIVO</option>
                        <option value="CAMBIO DE PIEZA">CAMBIO DE PIEZA</option>
                        <option value="FECHA DE MANTENIMIENTO">FECHA DE MANTENIMIENTO</option>
                    </select>
                  <%--<input type="text"  placeholder="Tipo Servicio solicitado"  required/>--%>
                <label>Fecha proximo mantenimiento</label>
                  <input type="date" class="form-control" placeholder="Serie/Tag" id="dtProximoMto"/>
              <label>Comentarios</label>
                  <textarea class="form-control" placeholder="Comentarios" id="txCComentarios" rows="5" required></textarea>
              
             
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-primary" id="btnGuardarComputo" type="button">Crear</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelComputoModal" tabindex="-1" role="dialog" aria-labelledby="DelComputoModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEliminarComputo">Eliminar Computo</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalEliminarComputo">
              <label id="idComputoEliminar" hidden="hidden"></label>               
              <label id="idComputoEliminarMsj"></label>               
            </div>
          <div class="form-group" id="txtModalEliminarMensajeComputo">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnEliminarComputo" type="button">Eliminar</button>
      </div>
      </form>
    </div>
  </div>
</div> 
    <%--SERVICIO--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelComputoServicioModal" tabindex="-1" role="dialog" aria-labelledby="DelComputoServicioModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelServicioComputo">Servicio Computo</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
      <div class="modal-body">   
          <form class="form-horizontal" id="EditarComputoForm"></form>
            <div class="form-group" id="txtModalServicioComputo">
              <label id="idComputoServicioCerrar" hidden="hidden"></label>               
              <label id="idComputoServicioMsj"></label>               
            </div>
          
      </div>
       <div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
      <button class="btn btn-danger" id="btnServicioComputo" type="button">Servicio terminado</button></div></div>
    </div>
  </div>
</div> 
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/ServicioComputo.js" type="text/javascript"></script>
    
</asp:Content>











