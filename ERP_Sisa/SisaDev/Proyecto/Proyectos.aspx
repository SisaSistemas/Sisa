<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Proyectos.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Proyectos.Proyectos" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     function TareasProyectos(btn) {
         window.open("ProyectoTareas.aspx?id=" + btn.value);
     }
     function EliminarProyecto(btn) {
         document.getElementById('idProyectosEliminar').textContent = '';
         document.getElementById('idProyectosEliminarTexto').textContent = '¿Estás seguro de eliminar proyecto con código "' + btn.value + '"?';
         document.getElementById('idProyectosEliminar').textContent = btn.value;
         $("#DelProyectosModal").modal();
     }
     //function CancelarProyecto(btn) {
     //    document.getElementById('idProyectosCancelar').textContent = '';
     //    document.getElementById('idProyectosCancelarTexto').textContent = '¿Estás seguro de Cancelar proyecto con código "' + btn.value + '"?';
     //    document.getElementById('idProyectosCancelar').textContent = btn.value;
     //    $("#CancelarProyectosModal").modal();
     //}
     function AgregarComentario(btn) {

         document.getElementById('idProyectoComentario').textContent = btn.value;
         var params = "{'pid': '" + btn.value + "'}";
         $.ajax({
             async: true,
             url: "Proyectos.aspx/CargarComentarios",
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
                     nodoTRAgregar += "  <td>" + value.Fecha.substring(0, 10) + "</td>";
                     nodoTRAgregar += "</tr>";
                 });

                 $('#TablaPrincipalComentariosProyectos tbody').append(nodoTRAgregar);
             }
         });
         $("#dvComentarios").modal();
     }

     function HorasHombre(btn) {
         window.open("ProyectoHorasHombre.aspx?id=" + btn.value);

     }

     function Grafica(btn) {
         window.open("ProyectoGrafica.aspx?id=" + btn.value);

     }

     function AvanceProyecto(btn) {
         document.getElementById('idProyectosAvance').textContent = '';
         document.getElementById('idProyectosAvanceTexto').textContent = '¿Estás seguro de actualizar avance de proyecto con Folio "' + $(btn).attr('rel') + '"?';
         document.getElementById('idProyectosAvance').textContent = btn.value;
         $("#AvanceProyecto").modal();
     }

     function EditarProyectoFechas(btn) {

         document.getElementById('idProyectoFechas').textContent = btn.value;
         var params = "{'pid': '" + btn.value + "'}";
         $.ajax({
             async: true,
             url: "Proyectos.aspx/ObtenerFechas",
             dataType: "json",
             data: params,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             success: function (data, textStatus) {

                 var jsonArray = $.parseJSON(data.d);
                 $.each(jsonArray, function (index, value) {
                     $('#dtFechaInicio').val(value.FechaInicio.substring(0, 10));
                     $('#dtFechaTermino').val(value.FechaFin.substring(0, 10));
                 });

             }
         });
         $("#dvCambiarFechas").modal();
     }

     //function EditarProyectoFechas(btn) {

     //    document.getElementById('idProyectoFechas').textContent = btn.value;
     //    var params = "{'pid': '" + btn.value + "'}";
     //    $.ajax({
     //        async: true,
     //        url: "Proyectos.aspx/ObtenerFechas",
     //        dataType: "json",
     //        data: params,
     //        type: "POST",
     //        contentType: "application/json; charset=utf-8",
     //        success: function (data, textStatus) {

     //            var jsonArray = $.parseJSON(data.d);
     //            $.each(jsonArray, function (index, value) {
     //                $('#dtFechaInicio').val(value.FechaInicio.substring(0, 10));
     //                $('#dtFechaTermino').val(value.FechaFin.substring(0, 10));
     //            });

     //        }
     //    });
     //    $("#dvCambiarFechas").modal();
     //}

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
     <%--<div id="loading-img">  <img src="../img/logoloading.png" /></div>--%>
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
                          
                          <%--<div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>--%>
                      
                      </form>
                      </div>
              </header>
                <div class="form-group" id="CargandoProyectos">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
                <div style="overflow-x: auto; overflow-y: auto;"> 
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
                    <th><i class="icon_loading"></i>Estatus</th>
                    <th><i class="icon_ol"></i> Acciones</th>
                    <th></th>
                    <th style="display:none;"></th>
                    <th style="display:none;"></th>
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
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelProyectosModal" tabindex="-1" role="dialog" aria-labelledby="DelProyectosModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEliminarProyectos">Eliminar Proyectos</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalEliminarProyectos">
              <label id="idProyectosEliminar" hidden="hidden"></label> 
                 <label id="idProyectosEliminarTexto"></label>
            </div>
          <div class="form-group" id="txtModalEliminarMensajeProyectos">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnEliminarProyectos" type="button">Eliminar</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--Cancelar--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="CancelarProyectosModal" tabindex="-1" role="dialog" aria-labelledby="CancelarProyectosModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelCancelarProyectos">Cancelar Proyectos</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalCancelarProyectos">
              <label id="idProyectosCancelar" hidden="hidden"></label> 
                 <label id="idProyectosCancelarTexto"></label>
            </div>
          <div class="form-group" id="txtModalCancelarMensajeProyectos">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnCancelarProyectos" type="button">Cancelar</button>
      </div>
      </form>
    </div>
  </div>
</div>
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
                            <div class="col-md-10 col-sm-10 col-xs-12 form-group has-feedback">
                                <input type="text" class="form-control has-feedback-left" id="txtComentarioProyecto" placeholder="Comentario">
                                <span class="fas fa-comment-dots form-control-feedback left" aria-hidden="true"></span>
                            </div>
                            <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback">
                                <span class="btn btn-success" id="btnAgregarComentarioProyectos"><i class="fa fa-plus"></i>Agregar</span>
                            </div>
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

    <%--fechas--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvCambiarFechas" tabindex="-1" role="dialog" aria-labelledby="dvCambiarFechas" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelddvCambiarFechas">Cambio de fechas del proyecto</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="modal-body">
                            <label>Razón de cambio</label>
                                        <input type="text" class="form-control" placeholder="Razón de cambio" id="txtRazonCambio" required/>
                                        <label>Fecha inicio</label>
                                        <input type="date" class="form-control" id="dtFechaInicio" required />
                            <label>Fecha termino</label>
                                        <input type="date" class="form-control" id="dtFechaTermino" required />
                            <label id="idProyectoFechas" hidden="hidden"></label>
                            

                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="submit" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        <button type="submit" id="btnGuardarFechas" class="btn btn-success">Guardar cambios</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--AVANCE %--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AvanceProyecto" tabindex="-1" role="dialog" aria-labelledby="CambiarMonto" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Cambiar Avance de proyecto</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Proporciona Monto: (sin comas, solo puntos decimales)</label>
                                <input type="text" id="txtAvanceProyecto" class="form-control" placeholder="Avance" />

                            </div>

                        </div>
                        <label id="idProyectosAvance" hidden="hidden"></label>
                        <label id="idProyectosAvanceTexto"></label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-info" id="btnCambiarAvance" type="button">Actualizar Avance</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/Proyectos.js" type="text/javascript"></script>
    
</asp:Content>






