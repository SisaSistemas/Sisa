<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mensajes.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Compras.Mensajes" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     
     function VerMensaje(btn) {
         
        window.open("../Ventas/RFQDetalle.aspx?idRFQ=" + btn.value);
     }    
     function VerMensajeReq(btn) {

         window.open("../Compras/Requisicion-Edicion.aspx?idReq=" + btn.value);
     }   
     function AprobarMensaje(btn) {
         
         document.getElementById('idAprobarMensaje').textContent = '';
         //$('#txtModalEliminarEmpresa').append('<p>¿Estás seguro de eliminar Empresa con código "' + btn.value + '"?</p>');
         document.getElementById('idAprobarMensajeTexto').textContent = '¿Estás seguro de aprobar como leído Mensaje #"' + btn.value + '"?';

         document.getElementById('idAprobarMensaje').textContent = btn.value;
         $("#AprobarMensaje").modal();

     }
     function RechazarMensajes(btn) {
         document.getElementById('idRechazarMensaje').textContent = '';
         //$('#txtModalEliminarEmpresa').append('<p>¿Estás seguro de eliminar Empresa con código "' + btn.value + '"?</p>');
         document.getElementById('idRechazarMensajeTexto').textContent = '¿Estás seguro de aprobar Mensaje #"' + btn.value + '"?';

         document.getElementById('idRechazarMensaje').textContent = btn.value;
         $("#RechazarMensaje").modal();

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
              <li><i class="icon_building"></i>Mensajes</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeMensajes">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
              <div class="alert alert-danger fade in">
                  <asp:Literal runat="server"  ID="FailureText" />
              </div>
            </asp:PlaceHolder>
              <header class="panel-heading">
                Lista de Mensajes
                  <div class="btn-group" id="botones">
                        <form class="form-inline">
                          
                          <div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>
                      
                      </form>
                      </div>
              </header>
                <div class="form-group" id="CargandoMensaje">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
                <div style="overflow-x: auto; overflow-y: auto; height:500px;"> 
              <table class="table table-advance table-hover order-table" id="TablaMensaje">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i>id</th>
                    <th><i class="icon_building"></i>#</th>
                    <th><i class="icon_calendar"></i>Fecha</th>
                    <th><i class="icon_calendar"></i>RFQ</th>                     
                    <th><i class="icon_profile"></i>Estatus</th>                     
                    <th><i class="icon_profile"></i>Usuario Envia</th>                     
                    <th><i class="icon_ol"></i>Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaSolMensajes">
                   
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
    <!-- ARPOBAR-->
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AprobarMensaje" tabindex="-1" role="dialog" aria-labelledby="AprobarMensaje" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEliminarCcontacto">Aprobar requisición.</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalAprobarMensaje">
              <label id="idAprobarMensaje" hidden="hidden"></label>               
              <label id="idAprobarMensajeTexto" ></label>               
            </div>
          <div class="form-group" id="txtModalAprobarMensajeMensaje">                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-success" id="btnAprobarMensaje" type="button">Aprobar</button>
      </div>
      </form>
    </div>
  </div>
</div>

    <!-- Rechazar-->
  <%--  <div class="modal fade" data-backdrop="static" data-keyboard="false" id="RechazarMensaje" tabindex="-1" role="dialog" aria-labelledby="RechazarMensaje" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelRechazar">Rechazar requisición.</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalRechazarMensaje">
              <label id="idRechazarMensaje" hidden="hidden"></label>               
              <label id="idRechazarMensajeTexto" ></label>               
            </div>
          <div class="form-group" id="txtModalRechazarMensajeMensaje">                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnRechazarMensaje" type="button">Rechazar</button>
      </div>
      </form>
    </div>
  </div>
</div>--%>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">    
    <script src="<%= ResolveUrl("~") %>js/Mensajes.js" type="text/javascript"></script>
</asp:Content>






