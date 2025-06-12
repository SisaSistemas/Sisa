<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Requisicion-Solicitud.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Compras.Requisicion_Solicitud" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     
     function VerRequisiciones(btn) {
         window.open("Requisicion-Edicion.aspx?idReq=" + btn.value);
     }    
     function AprobarRequisiciones(btn) {
         
         document.getElementById('idAprobarRequisicion').textContent = '';
         //$('#txtModalEliminarEmpresa').append('<p>¿Estás seguro de eliminar Empresa con código "' + btn.value + '"?</p>');
         document.getElementById('idAprobarRequisicionTexto').textContent = '¿Estás seguro de aprobar requisicion #"' + btn.value + '"?';

         document.getElementById('idAprobarRequisicion').textContent = btn.value;
         $("#AprobarRequisicion").modal();

     }
     function RechazarRequisiciones(btn) {
         document.getElementById('idRechazarRequisicion').textContent = '';
         //$('#txtModalEliminarEmpresa').append('<p>¿Estás seguro de eliminar Empresa con código "' + btn.value + '"?</p>');
         document.getElementById('idRechazarRequisicionTexto').textContent = '¿Estás seguro de aprobar requisicion #"' + btn.value + '"?';

         document.getElementById('idRechazarRequisicion').textContent = btn.value;
         $("#RechazarRequisicion").modal();

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
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
              <div class="alert alert-danger fade in">
                  <asp:Literal runat="server"  ID="FailureText" />
              </div>
            </asp:PlaceHolder>
              <header class="panel-heading">
                Lista de Solicitudes requisición 
                  <div class="btn-group" id="botones">
                        <form class="form-inline">
                          
                          <div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>
                      
                      </form>
                      </div>
              </header>
                <div class="form-group" id="CargandoRequisiciones">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
                <div style="overflow-x: auto; overflow-y: auto; height:500px;"> 
              <table class="table table-striped table-advance table-hover order-table" id="TablaRequisiciones">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i>id</th>
                    <th><i class="icon_building"></i>#</th>
                    <th><i class="icon_calendar"></i>Fecha</th>
                    <th><i class="icon_calendar"></i>Requisicion</th>                     
                    <th><i class="icon_profile"></i>Estatus</th>                     
                    <th><i class="icon_profile"></i>Usuario Solicita</th>                     
                    <th><i class="icon_ol"></i>Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaSolRequisiciones">
                   
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
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AprobarRequisicion" tabindex="-1" role="dialog" aria-labelledby="AprobarRequisicion" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEliminarCcontacto">Aprobar requisición.</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalAprobarRequisicion">
              <label id="idAprobarRequisicion" hidden="hidden"></label>               
              <label id="idAprobarRequisicionTexto" ></label>               
            </div>
          <div class="form-group" id="txtModalAprobarRequisicionMensaje">                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-success" id="btnAprobar" type="button">Aprobar</button>
      </div>
      </form>
    </div>
  </div>
</div>

    <!-- Rechazar-->
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="RechazarRequisicion" tabindex="-1" role="dialog" aria-labelledby="RechazarRequisicion" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelRechazar">Rechazar requisición.</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalRechazarRequisicion">
              <label id="idRechazarRequisicion" hidden="hidden"></label>               
              <label id="idRechazarRequisicionTexto" ></label>               
            </div>
          <div class="form-group" id="txtModalRechazarRequisicionMensaje">                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnRechazarRequisicion" type="button">Rechazar</button>
      </div>
      </form>
    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">    
    <script src="<%= ResolveUrl("~") %>js/Requisicion-Solicitud.js" type="text/javascript" ></script>
</asp:Content>






