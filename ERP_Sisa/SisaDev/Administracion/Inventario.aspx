<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Sitio.Master" CodeBehind="Inventario.aspx.cs" Inherits="SisaDev.Admin.Inventario" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     function Entradas(btn) {
         document.getElementById('idEntradaInventario').textContent = btn.value;

         $("#EntradaInventarioModal").modal();
     }     
     function Salidas(btn) {
         document.getElementById('idSalidaInventario').textContent = btn.value;

         $("#SalidaInventarioModal").modal();
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
              <li><i class="icon_building"></i>Inventario</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeInventario">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <header class="panel-heading">
                Lista de Inventario 
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                              <%--<Button class="btn btn-primary" data-toggle="modal" data-target="#AddInventarioModal"><i class="icon_plus_alt2"></i></Button>--%>
                              <a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddInventarioModal"><i class="icon_plus_alt2"></i> Agregar </a>

                          </div>
                          <div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>
                      
                      </form>
                        
                      </div>
              </header>
                <div class="form-group" id="CargandoInventario">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
                <div style="overflow-x: auto; overflow-y: auto; height:500px;"> 
              <table class="table table-striped table-advance table-hover order-table" id="TablaInventario">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i>Código</th>
                    <th><i class="icon_link_alt"></i>Código</th>
                    <th><i class="icon_comment_alt"></i>Descripción</th>
                      <th><i class="icon_info_alt"></i>Tipo</th>
                    <th><i class="icon_map"></i>Contenedor</th>
                    <th><i class="icon_paperclip"></i>Observaciones</th>
                      <th><i class="arrow_carrot_up_alt"></i>Entradas</th>
                      <th><i class="arrow_carrot-down_alt"></i>Salidas</th>
                      <th><i class="icon_grid-3×3"></i>TotalAlmacen</th>
                      <th><i class="icon_loading"></i>Estatus</th>
                    <th><i class="icon_ol"></i> Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaInventario">
                   
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
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddInventarioModal" tabindex="-1" role="dialog" aria-labelledby="AddInventarioModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelAgregarInventario">Agregar Inventario</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">
        
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Descripción</label>
                  <input type="text" class="form-control" placeholder="Descripción" id="txtDescripcionInventario" required/>
              </div>            
              <div class="col-sm-10">
                   <label>Tipo</label>
                 <select id="cmbTipoInventario" class="form-control">
                     <option value="HERRAMIENTA">HERRAMIENTA</option>
                     <option value="MATERIAL">MATERIAL</option>
                 </select>
              </div>           
              <div class="col-sm-10">
                   <label>Observaciones</label>
                  <input type="text" class="form-control" placeholder="Observación" id="txtObservacionInventario" required/>
              </div>
                <div class="col-sm-10">
                   <label>Número contenedor</label>
                  <input type="number" class="form-control" id="txtContenedorInventario" required/>
              </div>
                <div class="col-sm-10">
                   <label>Cantidad inicial</label>
                  <input type="number" class="form-control"  id="txtCantidadInventario" required/>
              </div>
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-primary" id="btnGuardarInventario" type="button">Crear</button>
      </div>
      </form>
    </div>
  </div>
</div>
    
    <%--ENTRADAS--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="EntradaInventarioModal" tabindex="-1" role="dialog" aria-labelledby="EntradaInventarioModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEditarInventario">Editar Inventario</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"></button>
      </div>
        <form class="form-horizontal" id="EditarInventarioForm">
             <div class="modal-body">
        
            <div class="form-group">
              <label id="idEntradaInventario" hidden="hidden"></label>
                <div class="col-sm-10">
                   <label>Cantidad entrada</label>
                  <input type="number" class="form-control"  id="txtCantidadEntrada" required/>
              </div>
            </div>
      </div>
            <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-primary" id="btnRegistrarEntrada" type="button">Actualizar</button>
      </div>

        </form>
        
         
    </div>
  </div>
</div>
     <%--SALIDAS--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="SalidaInventarioModal" tabindex="-1" role="dialog" aria-labelledby="SalidaInventarioModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEditarSalidaInventario">Editar Inventario</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"></button>
      </div>
        <form class="form-horizontal" id="EditarInventarioFormSalida">
             <div class="modal-body">
        
            <div class="form-group">
              <label id="idSalidaInventario" hidden="hidden"></label>
                <div class="col-sm-10">
                   <label>Cantidad entrada</label>
                  <input type="number" class="form-control"  id="txtCantidadSalida" required/>
              </div>
            </div>
      </div>
            <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-primary" id="btnRegistrarSalida" type="button">Actualizar</button>
      </div>
        </form>

    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/Inventario.js" type="text/javascript"></script>
    
</asp:Content>







