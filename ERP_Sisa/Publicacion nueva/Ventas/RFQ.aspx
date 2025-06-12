<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RFQ.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Ventas.RFQ" %>


<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     function EliminarRFQ(btn) {
         document.getElementById('idRFQEliminar').textContent = '';
         document.getElementById('txtModalEliminarRFQ').textContent = '¿Estás seguro de eliminar requisición con código "' + btn.value + '"?';

         document.getElementById('idRFQEliminar').textContent = btn.value;
         $("#DelRFQModal").modal();
     }
     function EditarRFQ(btn) {
         window.open("RFQDetalle.aspx?idRFQ=" + btn.value);
     }
     function AddRFQ() {
         window.open("RFQDetalle.aspx?idRFQ=0");
     }
     function EnviarRFQ(btn) {
         document.getElementById('idRFQEnviar').textContent = '';
         document.getElementById('txtModalEnviarRFQ').textContent = '¿Estás seguro de cambiar estatus de requisición con código "' + btn.value + '"?';
         document.getElementById('idRFQEnviar').textContent = btn.value;
         $("#EnviarRFQModal").modal();
     }

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
              <li><i class="icon_building"></i>RFQ</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeRFQ">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <header class="panel-heading">
                Lista de RFQ 
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                            <Button class="btn btn-primary" onclick="AddRFQ()"><i class="icon_plus_alt2"></i></Button>
                          </div>
                         <%-- <div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>--%>
                      
                      </form>
                        
                      </div>
              </header>
                <div class="form-group" id="CargandoRFQ">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
                 <%--<div style="overflow-x: auto; overflow-y: auto; height:500px;"> --%>
              <table class="table table-striped table-advance table-hover order-table" id="TablaRFQ">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i> Código</th>
                      <th><i class="icon_ribbon_alt"></i> Fecha</th>
                    <th><i class="icon_table"></i> Folio</th>
                    <th><i class="icon_ribbon_alt"></i> Descripción</th>
                    
                    <th><i class="icon_ribbon_alt"></i> Fecha compromiso</th>
                      <th><i class="icon_profile"></i> Vendedor</th>
                      <th><i class="icon_profile"></i> Coordinador</th>
                      <th><i class="icon_profile"></i> Contacto-Cliente</th>
                      <th><i class="icon_phone"></i> Teléfono</th>
                      <th><i class="icon_link"></i> Estatus</th>
                      <th><i class="icon_ribbon_alt"></i> Seguimiento</th>
                    <th><i class="icon_ol"></i> Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaRFQ">
                   
                </tbody>
              </table>
                    <%-- </div>--%>
                <div class="col-md-12 text-center">
      <ul class="pagination pagination-lg pager" id="myPager"></ul>
      </div>
            </section>
          </div>
        </div>
        <!-- page end-->
      </section>
    </section>
    
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelRFQModal" tabindex="-1" role="dialog" aria-labelledby="DelRFQModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEliminarRFQ">Eliminar RFQ</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group">
              <label id="idRFQEliminar" hidden="hidden"></label>               
              <label id="txtModalEliminarRFQ"></label>               
            </div>
          <div class="form-group" id="txtModalEliminarMensajeRFQ">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnEliminarRFQ" type="button">Eliminar</button>
      </div>
      </form>
    </div>
  </div>
</div>
    
    <%--Enviar--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="EnviarRFQModal" tabindex="-1" role="dialog" aria-labelledby="EnviarRFQModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEnviarRFQ">Terminar RFQ</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" >
              <label id="idRFQEnviar" hidden="hidden"></label>  
              <label id="txtModalEnviarRFQ"></label>  
                
            </div>
          <div class="form-group" id="txtModalEnviarMensajeRFQ">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnEnviarRFQ" type="button">Terminar</button>
      </div>
      </form>
    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/RFQ.js" type="text/javascript" ></script>
    
</asp:Content>