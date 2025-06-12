<%@ Page Title="" Language="C#" MasterPageFile="~/SitioCliente.Master" AutoEventWireup="true" CodeBehind="Biddings.aspx.cs" Inherits="SisaDev.Cliente.Biddings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Clientes</li>
                        <li><i class="icon_building"></i>Listado Biddings</li>
                    </ol>
                </div>
            </div>
            <!-- page start-->
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div class="form-group" id="MensajeOC">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>


                        <header class="panel-heading">
                            Lista de Biddings
                            <%--<div class="btn-group" id="botones">
                                <form class="form-inline">
                                    <div class="form-group">
                                        <button class="btn btn-primary" onclick="NuevaOC();"><i class="icon_plus_alt2"></i> Solicitar Cotización</button>
                                    </div>
                                </form>

                            </div>--%>
                        </header>
                        <div class="form-group" id="CargandoOC">
                        </div>

                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="x_panel">
                                <div class="x_content">

                                    <div id="toolbar">
                                        <span class="d-inline-block btn-add-excel">
                                            <%--<button type="button" class="btn btn-primary" id="btnSelect"><i class="icon_plus_alt2"></i> Solicitar Bidding</button>--%>
                                            <%--<strong>|</strong>
                                            <span id="btnExportar" class="btn btn-success pull-right"><i class="far fa-file-excel"></i> Exportar Excel</span>--%>
                                        </span>
                                    </div>


                                    <table id="TablaSolicitud" class="table table-striped table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                        <thead>
                                            <tr>
                                                <%--<th data-field="FechaCreacion" data-sortable="true" data-formatter="dateFormat"><i class="icon_calendar"></i>Fecha</th>--%>
                                                <th data-field="FolioBiddings" data-sortable="true"><i class="icon_ribbon_alt"></i>Folio</th>
                                                <th data-field="Concepto" data-sortable="true"><i class="icon_archive_alt"></i>Concepto</th>
                                                <th data-field="Planta" data-sortable="true"><i class="icon_building"></i>Planta</th>
                                                <th data-field="Area" data-sortable="true"><i class="icon_creditcard"></i>Area</th>
                                                <th data-field="FechaLimite" data-sortable="true" data-formatter="dateFormat"><i class="icon_profile"></i>Fecha Limite</th>
                                                <th data-field="Estatus" data-formatter="EstatusFormmater" data-sortable="true"><i class="icon_creditcard"></i>Estatus</th>
                                                <th data-align="center" data-formatter="accionBidFormatter" data-events="accionBidEvents"><i class="icon_ol"></i>Accion</th>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>
                            </div>
                        </div>

                    </section>
                </div>
            </div>


            <%--comentarios--%>
            <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvComentarios" tabindex="-1" role="dialog" aria-labelledby="dvComentarios" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="LabeldvComentarios">Agregar comentario al proyecto</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            </button>
                        </div>
                        <form class="form-horizontal">
                            <div class="modal-body">
                                <div class="modal-body">
                                    <div class="col-md-10 col-sm-10 col-xs-12 form-group has-feedback">
                                        <textarea class="form-control" id="txtComentario" rows="5" cols="50" ></textarea>
                                    </div>

                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                            <div class="modal-footer">
                                <button type="submit" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                                <%--<button type="submit" id="btnGuardar" class="btn btn-success">Guardar</button>--%>
                                <span id="btnGuardar" class="btn btn-success">Guardar</span>
                            </div>
                        </form>
                    </div>
                </div>
            </div>

            <%--comentarios--%>
            <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvVerComentarios" tabindex="-1" role="dialog" aria-labelledby="dvComentarios" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="LabeldvVerComentarios">Agregar comentario al proyecto</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            </button>
                        </div>
                        <form class="form-horizontal">
                            <div class="modal-body">
                                <div class="row">
                                    <table id="TablaComentarios" class="table table-striped table-sm" >
                                        <thead>
                                            <tr>
                                                <th data-field="FechaComentario" data-sortable="true"><i class="fa-regular fa-clock"></i> Fecha</th>
                                                <th data-field="Comentario" data-sortable="true"><i class="fa-regular fa-message"></i> Comentario</th>
                                                <th data-field="NombreCompleto" data-sortable="true"><i class="fa-solid fa-user-tie"></i> Usuario</th>
                                            </tr>
                                        </thead>
                                    </table>
                                    <%--<div class="col-md-10 col-sm-10 col-xs-12 form-group has-feedback">
                                        <textarea class="form-control" id="txtComentario" rows="5" cols="50" ></textarea>
                                    </div>--%>

                                </div>

                            </div>
                            <div class="modal-footer">
                                <button type="submit" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                                <%--<button type="submit" id="btnGuardar" class="btn btn-success">Guardar</button>--%>
                                <%--<span id="btnGuardar" class="btn btn-success">Guardar</span>--%>
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

            <%--PDF--%>
            <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvPDF" tabindex="-1" role="dialog" aria-labelledby="dvPDF" aria-hidden="true">
                <div class="modal-dialog" style="width: 75%;">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="LabeldvPDFAdministracion">Agregar Administracion</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            </button>
                        </div>
                        <form class="form-horizontal ">
                            <div class="modal-body">
                                <label id="txtidProyectoArchivo" hidden="hidden"></label>
                                <label id="txtTipoDocumento" hidden="hidden"></label>
                                <div id="testmodalpdf" style="padding: 5px 20px;">
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                <%--<button type="button" class="btn btn-danger" id="btnEliminaDocumento" data-dismiss="modal">Eliminar</button>--%>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <!-- page end-->
        </section>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/BiddingsCliente.js" type="text/javascript"></script>
</asp:Content>
