<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientesContacto.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Clientes.ClientesContacto" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     function AgregarImagenContacto(btn) {
         swal({
             title: 'Seleccione archivo',
             input: 'file',
             allowOutsideClick: false,
             allowEscapeKey: false,
             allowEnterKey: false,
             showCloseButton: true
         }).then(function (file) {
             var nombreArchivo = file.name;
             var reader = new FileReader
             reader.onload = function (e) {
                 //debugger;
                 //console.log(nombreArchivo);

                 //var params = "{'IdCotizacion': '" + idCotizacion +
                 //    "','NombreArchivo': '" + nombreArchivo +
                 //    "','Documento': '" + e.target.result + "'}";

                 var params = "{'idContacto': '" + btn.value +
                     "','FileName': '" + nombreArchivo +
                     "','File': '" + e.target.result +
                     "'}";

                 //console.log(params);
                 $.ajax({
                     dataType: "json",
                     async: true,
                     url: "ClientesContacto.aspx/GuardarImagenContacto",
                     data: params,
                     type: "POST",
                     contentType: "application/json; charset=utf-8",
                     success: function (msg) {
                         //location.href = './frmProjects.aspx';

                         swal({
                             title: msg.d,
                             timer: 3000
                         });

                         //cargarArchivos();
                     },
                     error: function (xhr, ajaxOptions, thrownError) {

                     }
                 });


             }

             reader.readAsDataURL(file);

         });
     }

     function ActivarContacto(btn) {
         document.getElementById('idContactoActivar').textContent = '';
         //$('#txtModalEliminarContacto').append('<p>¿Estás seguro de eliminar Contacto con código "' + btn.value + '"?</p>');
         document.getElementById('idContactoActivarTexto').textContent = '¿Estás seguro de reactivar Contacto con código "' + btn.value + '"?';

         document.getElementById('idContactoActivar').textContent = btn.value;
         $("#ActivarContactoModal").modal();

     }

     function EliminarCcontacto(btn) {
         document.getElementById('idCcontactoEliminar').textContent = '';
         document.getElementById('idCcontactoEliminarTexto').textContent = '¿Estás seguro de eliminar contácto de cliente con código "' + btn.value + '"?';

         //$('#txtModalEliminarCcontacto').append('<p>¿Estás seguro de eliminar contácto de cliente con código "' + btn.value + '"?</p>');
         document.getElementById('idCcontactoEliminar').textContent = btn.value;
         $("#DelCcontactoModal").modal();
     }




 </script>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div id="loading-img"> </div>--%>
    <section id="main-content">
      <section class="wrapper">
        <div class="row">
          <div class="col-lg-12">
            
            <ol class="breadcrumb">
              <li><i class="icon_folder-open"></i>Administración</li>
              <li><i class="icon_building"></i>Cliente</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeCcontacto">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <header class="panel-heading">
                Lista de contáctos de empresas 
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                             <%--<Button class="btn btn-primary" data-toggle="modal" data-target="#AddCcontactoModal"><i class="icon_plus_alt2"></i></Button>--%>
                              <a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddCcontactoModal"><i class="icon_plus_alt2"></i> Agregar </a>
                          </div>
                         <%-- <div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>--%>
                      
                      </form>
                       
                      </div>
              </header>
                <div class="form-group" id="CargandoCcontacto">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <table class="table table-advance table-hover order-table" id="TablaCcontacto">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i> Código</th>
                    <th><i class="icon_profile"></i> Nombre</th>                    
                    <th><i class="icon_phone"></i> Teléfono</th>
                      <th><i class="icon_mail"></i> Correo</th>
                      <th><i class="icon_building"></i> Empresa</th>
                      <th><i class="icon_loading"></i> Estatus</th>
                    <th><i class="icon_ol"></i> Acciones</th>
                          
                  </tr>
                 </thead>
                <tbody id="listaCcontacto">
                   
                </tbody>
              </table>
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
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddCcontactoModal" tabindex="-1" role="dialog" aria-labelledby="AddCcontactoModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelAgregarCcontacto">Agregar contácto de cliente</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Empresa</label>
                  <select id="slctEmpresa" class="form-control selectpicker" data-live-search="true"></select>
              </div>
          </div>            
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Nombre contacto</label>
                  <input type="text" class="form-control" placeholder="Nombre contacto" id="txtNombreContacto" required/>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Teléfono</label>
                  <input type="tel" class="form-control" placeholder="Teléfono" id="txtTelefonoCcontacto" required/>
              </div>
            </div>            
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Correo</label>
                  <input type="email" class="form-control" placeholder="Correo" id="txtCorreoCcontacto" required/>
              </div>
            </div>     
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Usuario</label>
                  <input type="text" class="form-control" placeholder="Usuario" id="txtUsuarioCcontacto" required/>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Clave</label>
                  <input type="password" class="form-control" placeholder="Clave" id="txtClaveCcontacto" required/>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <div class="form-group" id="AddMsgCcontacto">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              </div>
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-primary" id="btnGuardarCcontacto" type="button">Crear</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelCcontactoModal" tabindex="-1" role="dialog" aria-labelledby="DelCcontactoModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEliminarCcontacto">Eliminar contácto de cliente</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalEliminarCcontacto">
              <label id="idCcontactoEliminar" hidden="hidden"></label>               
              <label id="idCcontactoEliminarTexto" ></label>               
            </div>
          <div class="form-group" id="txtModalEliminarMensajeCcontacto">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnEliminarCcontacto" type="button">Eliminar</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--EDITAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="EditCcontactoModal" tabindex="-1" role="dialog" aria-labelledby="EditCcontactoModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEditarCcontacto">Editar contácto de cliente</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal" id="EditarCcontactoForm"></form>
        
         
    </div>
  </div>
</div>
     <%--ACTIVAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="ActivarContactoModal" tabindex="-1" role="dialog" aria-labelledby="ActivarContactoModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelActivarContacto">Activar Contacto</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalActivarContacto">
              <label id="idContactoActivar" hidden="hidden"></label>               
              <label id="idContactoActivarTexto"></label>               
            </div>
          <div class="form-group" id="txtModalActivarMensajeContacto">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnActivarContacto" type="button">Activar</button>
      </div>
      </form>
    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/ClienteContacto.js" type="text/javascript" ></script>
    
</asp:Content>

