<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProyectoHorasHombre.aspx.cs" Inherits="SisaDev.Administracion.ProyectoHorasHombre" MasterPageFile="~/Sitio.Master" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <script>
        function EliminarHH(btn) {
            document.getElementById('idProyectosHH').textContent = '';
            document.getElementById('idProyectosHHTexto').textContent = '¿Estás seguro de eliminar horas con código "' + btn.value + '"?';
            document.getElementById('idProyectosHH').textContent = btn.value;
            $("#HHEliminarProyectosModal").modal();
        }
    </script>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
     <%--<div id="loading-img">  <img src="../img/logoloading.png" /></div>--%>
    <section id="main-content">
      <section class="wrapper">
        <div class="row">
          <div class="col-lg-12">            
            <ol class="breadcrumb">
              <li><i class="icon_folder-open"></i>Horas Hombre</li>
              <li><i class="icon_building"></i>Proyecto <label style="color: blue; font-weight: bold;" id="lblProyectoTarea" runat="server"></label> <label id="lblFolio" hidden="hidden" runat="server"></label> </li>
            </ol>
          </div>
        </div>
        <!-- page start-->
          <div class="row">
              <div class="col-lg-12">
                  <section class="panel">
                      <div class="col-md-8 col-sm-6 col-xs-12">
                                    <div id="dvGrafica"></div>
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-12">
                                    <div id="dvGraficaDetalle"></div>
                                </div>
                  </section>
              </div>
          </div>
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeProyectos">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <header class="panel-heading">
                Lista de tareas
                  <div class="btn-group" id="botones">
                        <Button title="Agregar horas hombre" class="btn btn-primary" data-toggle="modal" data-target="#HHProyectosModal"><i class="icon_plus_alt2"></i>Agregar</Button>
                        
                      <input type="hidden" id="idProyectoHH" runat="server"/>
                      </div>
              </header>
                <div class="form-group" id="CargandoProyectosTareas">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
                <div style="overflow-x: auto; overflow-y: auto; height:500px;"> 
              <table class="table table-striped table-advance table-hover" id="HHProyectosTareas">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i>Código</th>                    
                      <th><i class="icon_profile"></i>Persona</th>                    
                    <th><i class="icon_tag_alt"></i>Lunes</th>                      
                    <th><i class="icon_tag_alt"></i>Martes</th>                      
                    <th><i class="icon_tag_alt"></i>Miercoles</th>                      
                    <th><i class="icon_tag_alt"></i>Jueves</th>                      
                    <th><i class="icon_tag_alt"></i>Viernes</th>                      
                    <th><i class="icon_tag_alt"></i>Sabado</th>                      
                    <th><i class="icon_tag_alt"></i>Domingo</th>                      
                    <th><i class="icon_tag_alt"></i>Fecha</th>   
                    <th><i class="icon_tag_alt"></i>Total</th>   
                    <th><i class="icon_ol"></i> Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaProyectosHH">
                   
                </tbody>
              </table>
                     </div>
                
               
            </section>
          </div>
        </div>
        <!-- page end-->
      </section>
    </section>



     <%--Tarea--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="HHProyectosModal" tabindex="-1" role="dialog" aria-labelledby="HHProyectosModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelHHProyectos">Horas hombre Proyectos</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-inline">
      <div class="modal-body">        
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Persona: </label>
                  <select class="form-control selectpicker" data-live-search="true" id="cmbUsuarios"></select>
              </div>
            </div>
          
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Lunes</label>
                 <input type="number" class="form-control" id="txtLunes" step="0.10">
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Martes</label>
                 <input type="number" class="form-control" id="txtMartes" step="0.10">
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Miercoles</label>
                 <input type="number" class="form-control" id="txtMiercoles" step="0.10">
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Jueves</label>
                 <input type="number" class="form-control" id="txtJueves" step="0.10">
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Viernes</label>
                 <input type="number" class="form-control" id="txtViernes" step="0.10">
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Sabado</label>
                 <input type="number" class="form-control" id="txtSabado" step="0.10">
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Domingo</label>
                 <input type="number" class="form-control" id="txtDomingo" step="0.10">
              </div>
            </div>
          
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-info" id="btnHHProyectos" type="button">Agregar</button>
      </div>
      </form>
    </div>
  </div>
</div>
     <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="HHEliminarProyectosModal" tabindex="-1" role="dialog" aria-labelledby="HHProyectosModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelHHEliminarProyectos">Horas hombre Proyectos</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalHHProyectos">
              <label id="idProyectosHH" hidden="hidden"></label> 
                 <label id="idProyectosHHTexto"></label>
            </div>
          <div class="form-group" id="txtModalHHMensajeProyectos">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnHHEliminarProyectos" type="button">Eliminar</button>
      </div>
      </form>
    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/HorasHombre.js" type="text/javascript"></script>
    
</asp:Content>








