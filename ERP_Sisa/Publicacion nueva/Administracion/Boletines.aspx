<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Sitio.Master" CodeBehind="Boletines.aspx.cs" Inherits="SisaDev.Administracion.Boletines" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     function EliminaBoletin(btn) {
         document.getElementById('idBoletinEliminar').textContent = '';
         document.getElementById('idBoletinEliminarTexto').textContent = '¿Estás seguro de eliminar boletin con código "' + btn.value + '"?';


         document.getElementById('idBoletinEliminar').textContent = btn.value;

         $("#DelBoletinModal").modal();
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
              <li><i class="icon_building"></i>Boletin</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeBoletin">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <header class="panel-heading">
                Lista de Boletines registrados 
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                            <%--<Button class="btn btn-primary" data-toggle="modal" data-target="#AddBoletinModal"><i class="icon_plus_alt2"></i></Button>--%>
                              <a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddBoletinModal"><i class="icon_plus_alt2"></i> Agregar </a>
                          </div>
                          <div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>
                      
                      </form>
                        
                      </div>
              </header>
                <div class="form-group" id="CargandoBoletines">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
                <div style="overflow-x: auto; overflow-y: auto; height:500px;"> 
              <table class="table table-advance table-hover order-table" id="TablaBoletines">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i>Código</th>
                      <th><i class="icon_calendar"></i> Fecha</th>   
                    <th><i class="icon_profile"></i>Publicado por</th>
                                   
                     <th><i class="icon_menu-square_alt2"></i> Información</th>  
                      <th><i class="icon_image"></i> Imagen</th>  
                      <th><i class="icon_document_alt"></i> Archivo</th>                        
                    <th><i class="icon_ol"></i>Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaBoletines">
                   
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
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddBoletinModal" tabindex="-1" role="dialog" aria-labelledby="AddBoletinModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelAgregarBoletin">Agregar Boletin</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal">
      <div class="modal-body">
       
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Información:</label>
                  <textarea class="form-control" id="txtInformacionBoletin" required></textarea>
              </div>
            </div>
                
          
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-primary" id="btnGuardarBoletin" type="button">Crear</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelBoletinModal" tabindex="-1" role="dialog" aria-labelledby="DelBoletinModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEliminarBoletin">Eliminar Boletin</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalEliminarBoletin">
              <label id="idBoletinEliminar" hidden="hidden"></label>               
              <label id="idBoletinEliminarTexto"></label>               
            </div>
          <div class="form-group" id="txtModalEliminarMensajeBoletin">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnEliminarBoletin" type="button">Eliminar</button>
      </div>
      </form>
    </div>
  </div>
</div>
   <%--PDF--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvPDF" tabindex="-1" role="dialog" aria-labelledby="dvPDF" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabeldvPDFAdministracion">Archivo pdf</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">
          <label id="txtidBoletin" hidden="hidden"></label>
          <label id="txtTipoDocumento" hidden="hidden"></label>
        <div id="testmodalpdf" style="padding: 5px 20px;">
                       
                    </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button type="button" class="btn btn-danger" id="btnEliminadDocumentoBoletin" data-dismiss="modal">Eliminar</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--VISTA IMAGENES--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="VistaBoletinModal" tabindex="-1" role="dialog" aria-labelledby="VistaBoletinModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelVistaBoletin">Imágenes</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
         
        <form class="form-horizontal" >
          <div class="modal-body">
          <label id="txtidBoletinImagen" hidden="hidden"></label>
         <div id="VistaBoletinForm"></div>
      </div>
            <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button type="button" class="btn btn-danger" id="btnEliminadImagenBoletin" data-dismiss="modal">Eliminar</button>
      </div>
        </form>
        
         
    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/Boletines.js" type="text/javascript"></script>
    
</asp:Content>






