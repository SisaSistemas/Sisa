<%@ Page Title="" Language="C#" MasterPageFile="~/SitioProveedores.Master" AutoEventWireup="true" CodeBehind="Biddings.aspx.cs" Inherits="SisaDev.Biddings.Biddings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Ventas</li>
                        <li><i class="icon_building"></i>Listado Cotizaciones</li>
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
                            Lista de Solicitud de Cotizaciones 
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
                                            <%--<button type="button" class="btn btn-primary" id="btnSelect"><i class="icon_plus_alt2"></i> Solicitar Bidding</button>
                                            <strong>|</strong>
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
                                                <th data-field="Estatus" data-sortable="true"><i class="icon_creditcard"></i>Estatus</th>
                                                <%--<th data-align="center" data-formatter="accionCotFormatter" data-events="accionCotEvents"><i class="icon_ol"></i>Accion</th>--%>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>
                            </div>
                        </div>

                    </section>
                </div>
            </div>

            <%--AGREGAR--%>
            <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddCotizacionProveedor" tabindex="-1" role="dialog" aria-labelledby="AddCotizacionProveedor" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="LabelAgregarProveedores">Agregar Proveedores</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            </button>
                        </div>
                        <form class="form-horizontal ">
                            <div class="modal-body">
                                <div class="form-group">
                                    <div class="col-sm-10">
                                        <label>Folio Cotizacion</label>
                                        <input type="text" class="form-control" placeholder="Folio Cotizacion" id="txtFolioCotizacion" onkeyup="mayus(this);" required />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-10">
                                        <label>Concepto</label>
                                        <input type="text" class="form-control" placeholder="Concepto" id="txtConcepto" onkeyup="mayus(this);" required />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-10">
                                        <label>Costo</label>
                                        <input type="text" class="form-control" placeholder="Costo Cotizacion" id="txtCostoCotizacion" required />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-10">
                                        <div class="form-group" id="AddMsgProveedores">
                                            <%--<label id="txtMensajeDatos"></label>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                <button class="btn btn-primary" id="btnGuardarCotizacion" type="button">Crear</button>
                                <%--<button class="btn btn-primary" id="btnEditarProveedores" type="button">Guardar cambios</button>--%>
                            </div>
                        </form>
                    </div>
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
                                        <input type="text" class="form-control has-feedback-left" id="txtComentario" placeholder="Comentario">
                                        <span class="fas fa-comment-dots form-control-feedback left" aria-hidden="true"></span>
                                    </div>
                                    <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback">
                                        <span class="btn btn-success" id="btnAgregarComentario"><i class="fa fa-plus"></i>Agregar</span>
                                    </div>
                                    <label id="idOCComentario" hidden="hidden"></label>
                                    <div id="testmodalComentarios" style="padding: 5px 20px;">
                                        <table id="TablaPrincipalComentarios" class="table table-striped projects">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
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
                            </div>
                            <div class="modal-footer">
                                <button type="submit" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                                <%--<button type="submit" id="btnGuardarComentario" class="btn btn-success">Guardar</button>--%>
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
    <script src="<%= ResolveUrl("~") %>js/Bidding.js" type="text/javascript"></script>
</asp:Content>
