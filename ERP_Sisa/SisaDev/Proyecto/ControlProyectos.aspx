<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="ControlProyectos.aspx.cs" Inherits="SisaDev.Proyecto.ControlProyectos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Administración</li>
                        <li><i class="icon_building"></i>OC</li>
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

                        <table class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>
                                    <th colspan="4">RESUMEN</th>
                                </tr>
                                <tr>
                                    <th>MONEDA</th>
                                    <th>SUB-TOTAL</th>
                                    <th>IVA</th>
                                    <th>TOTAL</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th>PESOS (MXN)</th>
                                    <td><span id="lblPesosSubTotal">$ 123,456</span></td>
                                    <td><span id="lblPesosIVA">$ 123,456</span></td>
                                    <td><span id="lblPesosTotal">$ 123,456</span></td>
                                </tr>
                                <tr>
                                    <th>DOLARES (USD)</th>
                                    <td><span id="lblDolaresSubTotal">$ 123,456</span></td>
                                    <td><span id="lblDolaresIVA">$ 123,456</span></td>
                                    <td><span id="lblDolaresTotal">$ 123,456</span></td>
                                </tr>
                            </tbody>

                        </table>
                        <header class="panel-heading">
                            Lista de ordenes de compra
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                              <button class="btn btn-primary" onclick="NuevaOC();"><i class="icon_plus_alt2"></i></button>
                          </div>
                          <%-- <div class="form-group">
                            <input class="form-control col-md-3" id="search" type="text" placeholder="Buscar">
                          </div>--%>
                      </form>

                  </div>
                        </header>
                        <div class="form-group" id="CargandoOC">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>

                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="x_panel">
                                <div class="x_content">

                                    <div id="toolbar">
                                        <%--<span class="d-inline-block btn-add-excel">
                                            <button type="button" class="btn btn-primary" id="btnSelect"><i class="fas fa-plus"></i> Crear Orden de Compra</button>
                                            <strong>|</strong>
                                            <span id="btnExportar" class="btn btn-success pull-right"><i class="far fa-file-excel"></i> Exportar Excel</span>
                                        </span>--%>
                                    </div>

                                    <%-- <div id="toolbar" class="btn-group">
                                        <span class="pull-left">
                                            <a href="frmOrdenCompraDetalle.aspx?IdOrdenCompra=0" class="btn btn-default">
                                                <i class="glyphicon glyphicon-plus"> Crear Orden de Compra</i>
                                            </a>
                                        </span>
                                        
                                        <span id="btnExportar" class="btn btn-primary pull-right"><i class="fas fa-print"></i> Exportar Excel</span>
                                    </div>--%>
                                    <table id="tblProyectos" class="table table-striped table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                        <thead>
                                            <tr>
                                                <%--<th data-field="FechaCreacion" data-sortable="true" data-formatter="dateFormat"><i class="icon_calendar"></i>Fecha</th>--%>
                                                <th data-field="FolioProyecto" data-sortable="true"><i class="icon_ribbon_alt"></i>Folio</th>
                                                <th data-field="NombreProyecto" data-sortable="true"><i class="icon_archive_alt"></i>Proyecto</th>
                                                <th data-field="ContactoCliente" data-sortable="true"><i class="icon_building"></i>Contacto</th>
                                                <th data-field="Cliente" data-sortable="true"><i class="icon_creditcard"></i>Empresa</th>
                                                <th data-field="LiderProyecto" data-sortable="true"><i class="icon_profile"></i>Lider</th>
                                                <th data-field="FechaInicio" data-sortable>Fecha inicio</th>
                                                <%--<th data-field="SubTotal" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_creditcard"></i>Sub-Total</th>
                                                <th data-field="Iva" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_creditcard"></i>Iva</th>
                                                <th data-field="Total" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_creditcard"></i>Total</th>
                                                <th data-field="Enviada" data-sortable="true" data-formatter="enviadaFormatter"><i class="icon_ribbon_alt"></i>Enviada</th>
                                                <th data-field="Estatus" data-sortable="true" data-cell-style="cellStyle" data-formatter="estatusFormatter"><i class="icon_ribbon_alt"></i>Estatus</th>
                                                <th data-field="NoFactura" data-sortable="true"><i class="icon_archive_alt"></i>Factura</th>
                                                <th data-field="EstatusFactura" data-sortable="true" data-formatter="facturaFormatter"><i class="icon_ribbon_alt"></i>Pagada</th>
                                                <th data-field="FechaModificacion" data-sortable="true" data-formatter="dateFormat"><i class="icon_calendar"></i>Fecha Modificacion</th>
                                                <th data-field="CiudadSucursal" data-sortable="true"><i class="icon_building"></i>Sucursal</th>--%>
                                                <th data-align="center" data-formatter="accionOCFormatter" data-events="accionOCEvents"><i class="icon_ol"></i>Accion</th>
                                                <th data-align="center" data-formatter="accionOC2Formatter" data-events="accionOC2Events"></th>
                                                <th data-align="center" data-formatter="accionOC3Formatter" data-events="accionOC3Events"></th>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>
                            </div>
                        </div>

                        <div>
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

            <%--ELIMINAR--%>
            <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelOCModal" tabindex="-1" role="dialog" aria-labelledby="DelOCModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="LabelEliminarOC">Eliminar OC</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            </button>
                        </div>
                        <form class="form-horizontal ">
                            <div class="modal-body">
                                <div class="form-group" id="txtModalEliminarOC">
                                    <label id="idOCEliminar" hidden="hidden"></label>
                                    <label id="idOCEliminarTexto"></label>
                                </div>
                                <div class="form-group" id="txtModalEliminarMensajeOC">
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                <button class="btn btn-danger" id="btnEliminarOC" type="button">Eliminar</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <%--CANCELAR--%>
            <div class="modal fade" data-backdrop="static" data-keyboard="false" id="CancelarOCModal" tabindex="-1" role="dialog" aria-labelledby="CancelarOCModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="LabelCancelarOC">Cancelar OC</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            </button>
                        </div>
                        <form class="form-horizontal ">
                            <div class="modal-body">
                                <div class="form-group" id="txtModalCancelarOC">
                                    <label id="idOCCancelar" hidden="hidden"></label>
                                    <label id="idOCCancelarTexto"></label>
                                </div>
                                <div class="form-group" id="txtModalCancelarMensajeOC">
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                <button class="btn btn-danger" id="btnCancelarOC" type="button">Cancelar</button>
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
            <!-- page end-->
        </section>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/Administracion.js" type="text/javascript"></script>
</asp:Content>
