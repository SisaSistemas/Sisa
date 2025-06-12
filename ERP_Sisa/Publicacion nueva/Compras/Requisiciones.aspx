<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Requisiciones.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Compras.Requisiciones" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     function EliminarRequisiciones(btn) {
         document.getElementById('idRequisicionesEliminar').textContent = '';
         document.getElementById('idRequisicionesEliminarTexto').textContent = '¿Estás seguro de eliminar requisición con código "' + btn.value + '"?';
         document.getElementById('idRequisicionesEliminar').textContent = btn.value;
         $("#DelRequisicionesModal").modal();
     }

     function EditarRequisiciones(btn) {
         window.open("Requisicion-Edicion.aspx?idReq=" + btn.value);
     }

     function VisorRequisiciones(btn) {
         window.open("Requisicion-Edicion.aspx?idReq=" + btn.value);
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
              <li><i class="icon_building"></i>Requisiciones</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeRequisiciones">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <header class="panel-heading">
                Lista de Requisiciones 
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                            <%--<Button class="btn btn-primary" data-toggle="modal" data-target="#AddRequisicionesModal"><i class="icon_plus_alt2"></i></Button>--%>
                              <a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddRequisicionesModal"><i class="icon_plus_alt2"></i> Agregar </a>
                          </div>
                          <%--<div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>--%>
                      
                      </form>
                        
                      </div>
              </header>
                <div class="form-group" id="CargandoRequisiciones">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
                <div style="overflow-x: auto; overflow-y: auto;"> 
              <table class="table table-striped table-advance table-hover order-table" id="TablaRequisiciones">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i>Código</th>
                      <th><i class="icon_calendar"></i>Fecha</th>
                    <th><i class="icon_ribbon_alt"></i>Folio</th>
                    <th><i class="icon_archive_alt"></i>Proyecto</th>
                    
                    <th><i class="icon_calendar"></i>Fecha autorizada</th>
                    <th><i class="icon_calendar"></i>Fecha compra</th>
                    <th><i class="icon_documents"></i>Observaciones</th>                      
                    <th><i class="icon_ol"></i>Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaRequisiciones">
                   
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
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddRequisicionesModal" tabindex="-1" role="dialog" aria-labelledby="AddRequisicionesModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelAgregarRequisiciones">Agregar Requisiciones</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal" runat="server">
      <div class="modal-body">
        
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Proyecto</label>
                  <select id="slctProyecto" class="form-control selectpicker" data-live-search="true">
                      <%--<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER</option>
                      <option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA</option>
                      <option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD</option>
                      <option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA</option>--%>
                  </select>
              </div>
          </div>  
          <div>
              <div class="col-sm-10">
                  <input type="text" class="form-control col-lg-4 agrega" style="width:20%;" placeholder="Descripcion" id="txtDescripcion" required/>
                  <input type="number" class="form-control col-lg-4 agrega" style="width:20%;" placeholder="Cantidad" id="txtCantidad" required/>
                  <input type="text" class="form-control col-lg-4 agrega" style="width:15%;" placeholder="Unidad" id="txtUnidad" required/>
                  <input type="text" class="form-control col-lg-4 agrega" style="width:20%;" placeholder="No. Parte" id="txtParte" required/>
                  <input type="text" class="form-control col-lg-4 agrega" style="width:15%;" placeholder="Marca" id="txtMarca" required/>
                  <a data-toggle="tooltip" data-placement="top" style="width:10%;"  title="Agregar"><span class="btn btn-primary" id="btnAgregarItem"><i class="icon_plus_alt"></i></span></a>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                   <table id="tblReqAdd" class="table table-striped table-advance table-hover">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Descripción</th>
                                <th>Cantidad</th>
                                <th>Unidad</th>
                                <th>Num Parte</th>
                                <th>Marca</th>
                                <th></th>
                            </tr>
                        </thead>
                    </table>
                  </div>
              </div>
         
            <div class="form-group">
              <div class="col-sm-10">
                  <textarea class="form-control" placeholder="Comentarios" id="txtComentariosReq" cols="5" style="resize: none;"></textarea>
              </div>
            </div>
          



          <div class="form-group">
              <div class="col-sm-10">
                  <div class="form-group" id="AddMsgRequisiciones">
                     <%--<label ></label>--%>
                  </div>
              </div>
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-primary" id="btnGuardarRequisiciones" type="button">Crear</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelRequisicionesModal" tabindex="-1" role="dialog" aria-labelledby="DelRequisicionesModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEliminarRequisiciones">Eliminar Requisiciones</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalEliminarRequisiciones">
              <label id="idRequisicionesEliminar" hidden="hidden"></label>               
              <label id="idRequisicionesEliminarTexto"></label>               
            </div>
          <div class="form-group" id="txtModalEliminarMensajeRequisiciones">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnEliminarRequisiciones" type="button">Eliminar</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--Visor--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="EditRequisicionesModal" tabindex="-1" role="dialog" aria-labelledby="EditRequisicionesModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEditarRequisiciones">Editar Requisiciones</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal" id="EditarRequisicionesForm"></form>
        
         
    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">    
    <script src="<%= ResolveUrl("~") %>js/Requisicion.js" type="text/javascript" ></script>
</asp:Content>





