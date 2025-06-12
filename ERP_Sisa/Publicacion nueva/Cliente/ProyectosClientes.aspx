<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProyectosClientes.aspx.cs" MasterPageFile="~/SitioCliente.Master" Inherits="SisaDev.Cliente.Proyectos" %>



<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     function TareasProyectos(btn) {
         window.open("ProyectoTareasClientes.aspx?id=" + btn.value);
     }
    
     function AgregarComentario(btn) {

         document.getElementById('idProyectoComentario').textContent = btn.value;
         var params = "{'pid': '" + btn.value + "'}";
         $.ajax({
             async: true,
             url: "ProyectosClientes.aspx/CargarComentarios",
             dataType: "json",
             data: params,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             success: function (data, textStatus) {

                 var datos = "";
                 var nodoTRAgregar = "";

                 var JsonCombos;
                 var jsonArray = $.parseJSON(data.d);

                 $('#TablaPrincipalComentariosProyectos tbody').html('');
                 $.each(jsonArray, function (index, value) {
                     nodoTRAgregar += "<tr>";
                     nodoTRAgregar += '  <td style="display: none;">' + value.IdProyecto + "</td>";
                     nodoTRAgregar += "  <td>" + value.Comentario + "</td>";
                     nodoTRAgregar += "  <td>" + value.NombreCompleto + "</td>";
                     nodoTRAgregar += "  <td>" + value.Fecha + "</td>";
                     nodoTRAgregar += "</tr>";
                 });

                 $('#TablaPrincipalComentariosProyectos tbody').append(nodoTRAgregar);
             }
         });
         $("#dvComentarios").modal();
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
    <section id="main-content">
      <section class="wrapper">
        <div class="row">
          <div class="col-lg-12">
            
            <ol class="breadcrumb">
              <li><i class="icon_folder-open"></i>Administración</li>
              <li><i class="icon_building"></i>Proyectos</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeProyectos">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <header class="panel-heading">
                Lista de Proyectos 
                  <div class="btn-group" id="botones">
                        <%--<Button class="btn btn-primary" data-toggle="modal" data-target="#AddProyectosModal"><i class="icon_plus_alt2"></i></Button>--%>
                      <form class="form-inline">
                          
                          <div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>
                      
                      </form>
                      </div>
              </header>
                <div class="form-group" id="CargandoProyectos">
                  </div>
                <div style="overflow-x: auto; overflow-y: auto; height:500px;"> 
              <table class="table table-advance table-hover order-table" id="TablaProyectos">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i>Código</th>
                    <th><i class="icon_building"></i>Folio</th>
                    <th><i class="icon_building"></i>Proyecto</th>
                    <th><i class="icon_building"></i>Folio PO</th>
                    <th><i class="icon_profile"></i>Contacto</th>
                    <th><i class="icon_building"></i>Empresa</th>
                    <th><i class="icon_profile"></i>Lider</th>
                    <th><i class="icon_building"></i>Sucursal</th>
                    <th><i class="icon_tag_alt"></i>Fecha inicio</th>                      
                    <th><i class="icon_tag_alt"></i>Fecha termino</th>                      
                    <th><i class="icon_ol"></i> Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaProyectos">
                   
                </tbody>
              </table>
                     </div>
                <div class="col-md-12 text-center">
                            <ul class="pagination pagination-lg pager" id="myPagerProy"></ul>
                        </div>
               
            </section>
          </div>
        </div>
        <!-- page end-->
      </section>
    </section>
    <%--comentarios--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvComentarios" tabindex="-1" role="dialog" aria-labelledby="dvComentarios" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabeldvComentarios">Agregar comentario al proyecto</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="modal-body">
                            
                            <label id="idProyectoComentario" hidden="hidden"></label>
                            <div id="testmodalComentariosProyecto" style="padding: 5px 20px;">
                                <table id="TablaPrincipalComentariosProyectos" class="table table-striped projects">
                                    <thead>
                                        <tr>
                                            <th style="display: none;">#</th>
                                            <th>Comentario</th>
                                            <th>Usuario</th>
                                            <th>Fecha</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                </table>
                            </div>

                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="submit" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                        <%--<button type="submit" id="btnGuardarComentario" class="btn btn-success">Guardar</button>--%>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/ProyectosClientes.js" type="text/javascript"></script>
    
</asp:Content>







