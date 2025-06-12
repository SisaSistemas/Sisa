<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProyectoTareasClientes.aspx.cs" MasterPageFile="~/SitioCliente.Master" Inherits="SisaDev.Cliente.ProyectoTareas" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <link href="../css/slider.css" rel="stylesheet" />
    <script>

        function ComentariosTarea(btn) {
            document.getElementById('idComentariosTareaTexto').textContent = '';
            document.getElementById('idComentariosTareaTexto').textContent = btn.value;
            var params = "{'pid': '" + btn.value + "'}";
            $.ajax({
                async: true,
                url: "ProyectoTareasClientes.aspx/CargarComentariosTareas",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {

                    var datos = "";
                    var nodoTRAgregar = "";

                    var JsonCombos;
                    var jsonArray = $.parseJSON(data.d);

                    $('#TablaPrincipalComentariosProyectosTarea tbody').html('');
                    $.each(jsonArray, function (index, value) {
                        nodoTRAgregar += "<tr>";
                        nodoTRAgregar += '  <td style="display: none;">' + value.IdTaskComentario + "</td>";
                        nodoTRAgregar += "  <td>" + value.Comentario + "</td>";
                        nodoTRAgregar += "  <td>" + value.NombreCompleto + "</td>";
                        nodoTRAgregar += "  <td>" + value.Fecha.substring(0, 10) + "</td>";
                        nodoTRAgregar += "</tr>";
                    });
                    $('#TablaPrincipalComentariosProyectosTarea tbody').append(nodoTRAgregar);
                }
            });
            $("#ComentariosTareaModal").modal();
        }

        function VerDoc(btn) {
            //swal(btn.value);
            var params = "{'id': '" + btn.value + "'}";

            $.ajax({
                async: true,
                url: "ProyectoTareasClientes.aspx/VerPdf",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {
                    if (data.d == 'No se encontro archivo.') {
                        swal('No se encontro archivo de pdf');
                        return;
                    }
                    var jsonArray = $.parseJSON(data.d);
                    var archivo = '';
                    archivo = jsonArray.NombreArchivo;

                    window.open("docs/" + archivo);
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
    <%--   <div id="loading-img">  <img src="../img/logoloading.png" /></div>--%>
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Administración</li>
                        <li><i class="icon_building"></i>Proyectos 
                        </li>
                    </ol>
                </div>
            </div>
            <!-- page start-->
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div class="col-md-8 col-sm-8 col-xs-12">
                            <%--<div id="dvGrafica"></div>--%>
                           <iframe id="MyIframe" runat="server" style="height: 800px; width: 100%;"></iframe>
                            
                        </div>
                        <%--<div class="col-md-4 col-sm-6 col-xs-12">
                            <div id="dvGraficaDetalle"></div>
                        </div>--%>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                            <div class="row">
                                <label style="color: blue; font-weight: bold;" id="lblProyectoTarea" runat="server"></label>
                                <br />
                                <label id="lblFolio" runat="server"></label>
                                <br />
                                <label id="lblFechas" runat="server"></label>
                                <br />
                                <label id="lblEmpresa" runat="server"></label>
                                <br />
                                <label id="lblContacto" runat="server"></label>
                                <br />
                                <label id="lbllider" runat="server"></label>
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
                                                <%--<button title="Agregar tarea" class="btn btn-primary" data-toggle="modal" data-target="#TareaProyectosModal"><i class="icon_plus_alt2"></i></button>
                                                <button title="Agregar archivo" class="btn btn-warning" id="btnAgregarArchivoProyecto"><i class="icon_plus_alt2"></i>Agregar archivo</button>
                                                <button title="Ver galeria" class="btn btn-info" id="btnVerGaleria"><i class="icon_plus_alt2"></i>Ver galeria</button>
                                                <button title="Ver archivos" class="btn btn-default" id="btnVerGaleriaArchivos"><i class="icon_plus_alt2"></i>Archivos registrados</button>--%>
                                                <input type="hidden" id="idProyectoTarea" runat="server" />
                                            </div>
                                        </header>
                                        <div class="form-group" id="CargandoProyectosTareas">
                                            <%--<label id="txtMensajeDatos"></label>--%>
                                        </div>
                                        <div style="overflow-x: auto; overflow-y: auto; height: 550px; width: 100%;">
                                            <table class="table table-striped table-sm table-advance table-hover" id="TablaProyectosTareas">
                                                <thead>
                                                    <tr>
                                                        <th style="display: none;"><i class="icon_building"></i>Código</th>
                                                        <th><i class="icon_menu"></i>Tarea</th>
                                                        <%--<th><i class="icon_profile"></i>Asignado</th>
                                                        <th><i class="icon_tag_alt"></i>Fecha inicio</th>
                                                        <th><i class="icon_tag_alt"></i>Fecha termino</th>
                                                        <th><i class="icon_calendar"></i>Días</th>
                                                        <th><i class="icon_calendar"></i>Días transcurridos</th>--%>
                                                        <th><i class="icon_documents_alt"></i>Docs</th>
                                                        <th><i class="icon_ol"></i>Acciones</th>
                                                    </tr>
                                                </thead>
                                                <tbody id="listaProyectosTareas">
                                                </tbody>
                                            </table>
                                        </div>
                                    </section>
                                </div>
                            </div>
                            
                        </div>
                    </section>
                </div>
            </div>
            <%--<div class="row">
               
            </div>--%>
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

    <%--Avance--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AvanceProyectosModal" tabindex="-1" role="dialog" aria-labelledby="AvanceProyectosModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelAvanceProyectos">Avance Proyectos</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Selecciona porcentaje de avance (por criterio):</label>
                                <select id="cmbPorcentaje" class="form-control">
                                    <option value="10">10</option>
                                    <option value="20">20</option>
                                    <option value="30">30</option>
                                    <option value="40">40</option>
                                    <option value="50">50</option>
                                    <option value="60">60</option>
                                    <option value="70">70</option>
                                    <option value="80">80</option>
                                    <option value="90">90</option>
                                    <option value="100">100</option>
                                </select>
                            </div>
                            <label id="idProyectosAvance" hidden="hidden"></label>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-danger" id="btnAvanceProyectos" type="button">Avance</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--Galeria--%>
<%--    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="GaleriaProyectosModal" tabindex="-1" role="dialog" aria-labelledby="GaleriaProyectosModal" aria-hidden="true">
        <div class="modal-dialog" style="width: 80%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelGaleriaProyectos">Galeria de imagenes de Proyectos</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">

                        <div class="wrapper2" style="height: 600px;">
                            <div class="slider" id="slider" style="height: 600px;">
                                <ul class="slides" id="slideimagenes">

                                </ul>
                                <ul class="slider-controler" id="slidenumeracion">
 
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>--%>

    <%--Tarea--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="TareaProyectosModal" tabindex="-1" role="dialog" aria-labelledby="TareaProyectosModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelTareaProyectos">Agregar Tarea a Proyecto</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Tarea</label>
                                <input type="text" class="form-control" id="txtTitulo" placeholder="Titulo Tarea">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Asignado a:</label>
                                <select id="cmbUsuarios" class="form-control selectpicker" data-live-search="true"></select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Inicio</label>
                                <input type="date" class="form-control" id="dtInicio">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Final</label>
                                <input type="date" class="form-control" id="dtFin">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Comentario</label>
                                <input type="text" class="form-control" id="txtComentario" placeholder="Comentarios">
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-danger" id="btnTareaProyectos" type="button">Agregar Tarea</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--PDF--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvPDF" tabindex="-1" role="dialog" aria-labelledby="dvPDF" aria-hidden="true">
        <div class="modal-dialog" style="width: 80%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelPDFProyectos">Archivo Proyectos</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div id="testmodalpdf" style="padding: 5px 20px;">
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--Ver imagen tarea--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvImagenTarea" tabindex="-1" role="dialog" aria-labelledby="dvImagenTarea" aria-hidden="true">
        <div class="modal-dialog" style="width: 55%; height: 100%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelImagenProyectos">Imagen Tarea</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="wrapper2">
                            <div class="slider" id="slidertareas">
                                <ul class="slides" id="slideimagenestareas">
                                </ul>
                                <ul class="slider-controler" id="slidenumeraciontareas">
                                </ul>
                            </div>
                        </div>
                        <%--<div id="ImagenObtenida">
                       <img src="" id="imgTarea" />
                    </div>--%>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--COMENTARIOS--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="ComentariosTareaModal" tabindex="-1" role="dialog" aria-labelledby="ComentariosTareaModal" aria-hidden="true">
        <div class="modal-dialog" style="width: 65%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelComentariosTarea">Ver comentarios de tarea</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <label id="idComentariosTareaTexto" hidden="hidden"></label>

                        </div>
                        <div class="col-md-10 col-sm-10 col-xs-12 form-group has-feedback">
                            <label>Comentario</label>
                            <input type="text" class="form-control has-feedback-left" id="txtComentarioProyectoTarea" placeholder="Comentario">
                            <span class="fas fa-comment-dots form-control-feedback left" aria-hidden="true"></span>
                        </div>
                        <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback">
                            <span class="btn btn-success" id="btnAgregarComentarioProyectosTarea"><i class="fa fa-plus"></i>Agregar</span>
                        </div>
                        <div id="testmodalComentariosProyectoTarea" style="padding: 5px 20px;">
                            <table id="TablaPrincipalComentariosProyectosTarea" class="table table-striped projects">
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
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-danger" id="btnComentariosTarea" type="button">Agregar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--VER ARCHIVOS--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="GaleriaArchivosProyectosModal" tabindex="-1" role="dialog" aria-labelledby="GaleriaArchivosProyectosModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelGaleriaArchicosProyectos">Archivos de Proyectos</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <ul id="ulFiles">
                                </ul>
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btnCerrarModal" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--fechas--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvCambiarFechasTareas" tabindex="-1" role="dialog" aria-labelledby="dvCambiarFechasTareas" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelddvCambiarFechas">Cambio de fechas del proyecto</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <%--<form class="form-horizontal ">--%>
                <div class="modal-body">
                    <div class="modal-body">
                        <label>Razón de cambio</label>
                        <input type="text" class="form-control" placeholder="Razón de cambio" id="txtRazonCambio" required />
                        <label>Fecha inicio</label>
                        <input type="date" class="form-control" id="dtFechaInicio" required />
                        <label>Fecha termino</label>
                        <input type="date" class="form-control" id="dtFechaTermino" required />
                        <label id="idProyectoFechasTarea" hidden="hidden"></label>


                    </div>
                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                    <button type="submit" id="btnGuardarFechasTarea" class="btn btn-success">Guardar cambios</button>
                </div>
                <%--</form>--%>
            </div>
        </div>
    </div>
    <%--<section id="main-content">
      <section class="wrapper">
        <div class="row">
          <div class="col-lg-12">
            
            <ol class="breadcrumb">
              <li><i class="icon_folder-open"></i>Administración</li>
              <li><i class="icon_building"></i>Proyectos</li>
            </ol>
          </div>
            <div class="col-lg-12">
            
            <div class="col-lg-12">                
              <label style="color: blue; font-weight: bold;" id="lblProyectoTarea" runat="server"></label> <label id="lblFolio" hidden="hidden" runat="server"></label>
            </div>
          </div>
        </div>

         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeProyectos">
                    
                  </div>
              <header class="panel-heading">
                Lista de tareas
                  <div class="btn-group" id="botones">
                        
                        <Button title="Ver archivo" class="btn btn-info" id="btnVerGaleria"><i class="icon_plus_alt2"></i>Archivos registrados</Button>
                      <input type="hidden" id="idProyectoTarea" runat="server"/>
                      </div>
              </header>
                <div class="form-group" id="CargandoProyectosTareas">

                  </div>
                <div style="overflow-x: auto; overflow-y: auto; height:500px;"> 
              <table class="table table-striped table-advance table-hover" id="TablaProyectosTareas">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i>Código</th>
                    <th><i class="icon_menu"></i>Tarea</th>
                      <th><i class="icon_profile"></i>Asignado</th>                    
                    <th><i class="icon_tag_alt"></i>Fecha inicio</th>                      
                    <th><i class="icon_tag_alt"></i>Fecha termino</th>    
                      <th><i class="icon_calendar"></i>Días</th>
                    <th><i class="icon_calendar"></i>Días transcurridos</th>
                    <th><i class="icon_loading"></i>Estatus</th>
                    <th><i class="icon_ol"></i> Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaProyectosTareas">
                   
                </tbody>
              </table>
                     </div>
                
               
            </section>
          </div>
        </div>

      </section>
    </section>


    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="GaleriaProyectosModal" tabindex="-1" role="dialog" aria-labelledby="GaleriaProyectosModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelGaleriaProyectos">Archivo de Proyectos</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group">
              <div class="col-sm-10">
                  <ul id="ulFiles">
                                </ul> 
            </div>
      </div>
          <div class="wrapper2">
    <div class="slider" id="slider">      
        <ul class="slides" id="slideimagenes">       
            
                          
        </ul>
        <ul class="slider-controler" id="slidenumeracion">         
           
        </ul>
    </div>
</div>
         </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
      </div>
      </form>
    </div>
  </div>
</div>


    
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvPDF" tabindex="-1" role="dialog" aria-labelledby="dvPDF" aria-hidden="true">
  <div class="modal-dialog" style="width:80%;">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelPDFProyectos">Archivo Proyectos</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div id="testmodalpdf" style="padding: 5px 20px;">
                       
                    </div>
          
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
      </div>
      </form>
    </div>
  </div>
</div>

    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvImagenTarea" tabindex="-1" role="dialog" aria-labelledby="dvImagenTarea" aria-hidden="true">
  <div class="modal-dialog" style="width:80%;">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelImagenProyectos">Imagen Tarea</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div id="ImagenObtenida">
                       <img src="" id="imgTarea" />
                    </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
      </div>
      </form>
    </div>
  </div>
</div>

    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="ComentariosTareaModal" tabindex="-1" role="dialog" aria-labelledby="ComentariosTareaModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelComentariosTarea">Ver comentarios de tarea</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group">
                 <label id="idComentariosTareaTexto" hidden="hidden"></label>
                
            </div>
            
            <div id="testmodalComentariosProyectoTarea" style="padding: 5px 20px;">
                <table id="TablaPrincipalComentariosProyectosTarea" class="table table-striped projects">
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
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>

      </div>
      </form>
    </div>
  </div>
</div>--%>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/ProyectoTareasClientes.js" type="text/javascript"></script>
</asp:Content>








