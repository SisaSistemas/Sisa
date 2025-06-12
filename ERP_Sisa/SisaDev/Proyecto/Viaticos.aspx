<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Viaticos.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Proyectos.Viaticos" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     function EliminarViaticos(btn) {
         document.getElementById('idViaticosEliminar').textContent = '';

         //$('#txtModalEliminarViaticos').append('<p>¿Estás seguro de eliminar viatico con código "' + btn.value + '"?</p>');
         document.getElementById('idViaticosEliminarTexto').textContent = '¿Estás seguro de eliminar viatico con código "' + btn.value + '"?';

         document.getElementById('idViaticosEliminar').textContent = btn.value;

         $("#DelViaticosModal").modal();
     }
     function EditarViaticos(btn) {

         window.open("VerViaticos.aspx?IdViaticos=" + btn.value);

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
     <%--<div id="loading-img">  <img src="../img/logoloading.png" /></div>--%>
    <section id="main-content">
      <section class="wrapper">
        <div class="row">
          <div class="col-lg-12">
            
            <ol class="breadcrumb">
              <li><i class="icon_folder-open"></i>Administración</li>
              <li><i class="icon_building"></i>Viaticos</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeViaticos">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <header class="panel-heading">
                Lista de Viaticos 
                  <div class="btn-group" id="botones">
                        <form class="form-inline">
                       <div class="form-group">
                            <%--<Button class="btn btn-primary" data-toggle="modal" data-target="#AddViaticosModal"><i class="icon_plus_alt2"></i></Button>--%>
                           <a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddViaticosModal"><i class="icon_plus_alt2"></i> Agregar </a>
                          </div>
                          <%--<div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>--%>
                            </form>
                      </div>
              </header>
                <div class="form-group" id="CargandoViaticos">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
                <div style="overflow-x: auto; overflow-y: auto;"> 
              <table class="table table-striped table-advance table-hover order-table" id="TablaViaticos">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i>Código</th>
                    <th><i class="icon_calendar"></i>Fecha</th>
                    <th><i class="icon_building"></i>Proyecto</th>
                    <th><i class="icon_quotations"></i>Concepto</th>
                    <th><i class="icon_profile"></i>Usuario</th>
                    <th><i class="arrow_left"></i>Cantidad entregada</th>
                    <th><i class="arrow_right"></i>Cantidad gastada</th>
                    <th><i class="arrow_left-right"></i>Diferencia</th>  
                    <th><i class="icon_box-selected"></i>Estado</th>
                      <th><i class="icon_box-selected"></i>Comentarios</th>
                    <th><i class="icon_ol"></i> Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaViaticos">
                   
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
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddViaticosModal" tabindex="-1" role="dialog" aria-labelledby="AddViaticosModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelAgregarViaticos">Agregar Viaticos</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">
        
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Proyecto</label>
                  <select class="form-control selectpicker" id="cmbProyecto" data-live-search="true" required> </select>
              </div>
            </div>
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Responsable</label>
                   <select class="form-control selectpicker" id="cmbUsuario" data-live-search="true" required> </select>
              </div>
            </div>
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Concepto</label>
                   <select class="form-control selectpicker" id="cmbConcepto" data-live-search="true" required> </select>
              </div>
            </div>
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Comentarios</label>
                  <input type="text" class="form-control" placeholder="Comentarios" id="txtComentarios" required/>
              </div>
            </div>  
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Fecha</label>
                  <input type="date" class="form-control" id="dtFechaViatico" required />
              </div>
            </div> 
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Cantidad $</label>
                  <input type="text" class="form-control" placeholder="Cantidad entregada" id="txtCantidadEntregada" required/>
              </div>
            </div>            
          <div class="form-group">
              <div class="col-sm-10">
                  <div class="form-group" id="AddMsgViaticos">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              </div>
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-primary" id="btnGuardarViaticos" type="button">Crear</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelViaticosModal" tabindex="-1" role="dialog" aria-labelledby="DelViaticosModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEliminarViaticos">Eliminar Viaticos</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalEliminarViaticos">
              <label id="idViaticosEliminar" hidden="hidden"></label>   
              <label id="idViaticosEliminarTexto"></label>   
                
            </div>
          <div class="form-group" id="txtModalEliminarMensajeViaticos">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnEliminarViaticos" type="button">Eliminar</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--EDITAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="EditViaticosModal" tabindex="-1" role="dialog" aria-labelledby="EditViaticosModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEditarViaticos">Editar Viaticos</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal" id="EditarViaticosForm"></form>
        
         
    </div>
  </div>
</div>
     <%--Ver detalle--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvDetalleViatico" tabindex="-1" role="dialog" aria-labelledby="dvDetalleViatico" aria-hidden="true">
  <div class="modal-dialog" style="width:100%;">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabeldvDetalleViatico">Tabla detalle de viaticos</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal">
      <div class="modal-body">
          <section class="panel">
              <header class="panel-heading">
                Totales
              </header>
                <table class="table">
                    <tbody>
                        <tr>
                            <th style="width: 50%">Cantidad Entregada:</th>
                            <td><span id="lblCantEntregada"></span></td>
                        </tr>
                        <tr>
                            <th>Cantidad Gastada</th>
                            <td><span id="lblCantGastada"></span></td>
                        </tr>
                        <tr>
                            <th>Diferencia:</th>
                            <td><span id="lblDiferencia"></span></td>
                        </tr>
                        <tr>
                            <th>Persona que recibio:</th>
                            <td><span id="lblResponsable"></span></td>
                        </tr>
                        <tr>
                            <th>Proyecto para el que se otorgo:</th>
                            <td><span id="lblProyectoPrincipal"></span></td>
                        </tr>
                    </tbody>
                </table>
            </section>
          <table class="table table-striped" id="tblViaticosVer">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Fecha</th>
                                            <th>Proyecto</th>
                                            <th>Concepto</th>
                                            <th>Gasolina</th>
                                            <th>Desayuna</th>
                                            <th>Comida</th>
                                            <th>Cena</th>
                                            <th>Casetas</th>
                                            <th>Hotel</th>
                                            <th>Transporte</th>
                                            <th>Otros</th>
                                            <th>Mano de obra</th>
                                            <th>Materiales</th>
                                            <th>Equipo</th>
                                            
                                        </tr>
                                    </thead>
                                    <tbody>

                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <th></th>
                                            <th></th>
                                            <th colspan="2">Totales</th>
                                            <th><span id="lblGasolina">$     0.00</span></th>
                                            <th><span id="lblDesayuno">$     0.00</span></th>
                                            <th><span id="lblComida">$     0.00</span></th>
                                            <th><span id="lblCena">$     0.00</span></th>
                                            <th><span id="lblCasetas">$     0.00</span></th>
                                            <th><span id="lblHotel">$     0.00</span></th>
                                            <th><span id="lblTransporte">$     0.00</span></th>
                                            <th><span id="lblOtros">$     0.00</span></th>
                                            <th><span id="lblManoObra">$     0.00</span></th>
                                            <th><span id="lblMateriales">$     0.00</span></th>
                                            <th><span id="lblEquipo">$     0.00</span></th>
                                            <th></th>
                                        </tr>
                                    </tfoot>
                                </table>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--Ticket--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvPDFTicketDet" tabindex="-1" role="dialog" aria-labelledby="dvPDFTicketDet" aria-hidden="true">
  <div class="modal-dialog" style="width:60%; height:60%;">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabeldvPDFTicket">Visualizar ticket</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal">
      <div class="modal-body">
          <label id="txtidArchivoTicketDet" hidden="hidden"></label>
          <label id="txtTipoDocumentoTicketDet" hidden="hidden"></label>
        <div id="testmodalpdfTicketDet" style="padding: 5px 20px;">
                       
                    </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
      </div>
      </form>
    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/Viaticos.js" type="text/javascript"></script>
    
</asp:Content>






