<%@ Page Language="C#" MasterPageFile="~/SitioCliente.Master" AutoEventWireup="true" CodeBehind="PaqueteCotizaciones.aspx.cs" Inherits="SisaDev.Cliente.PaqueteCotizaciones" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Cliente</li>
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
                            Lista de ordenes de Cotizaciones
                            <div class="btn-group" id="botones">
                                <form class="form-inline">
                                    <%--<div class="form-group">
                                        <button class="btn btn-primary" onclick="NuevaOC();"><i class="icon_plus_alt2"></i></button>
                                    </div>--%>
                                </form>

                            </div>
                        </header>

                        <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <div class="x_panel">
                                    <div class="x_content">
                                        <div>
                                            <span class="d-inline-block btn-add-excel">
                                                <label>Ford HSAP</label>
                                            </span>
                                        </div>
                                        <table id="TablaCotizacionHSAP" class="table table-striped table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                            <thead>
                                                <tr>
                                                    <th data-align="center" data-formatter="accionCotHSAPFormatter" data-events="accionCotEvents"><i class="icon_ol"></i></th>
                                                    <th data-field="NoCotizaciones" data-sortable="true"><i class="icon_ribbon_alt"></i># Cotizacion</th>
                                                    <%--<th data-field="Cliente" data-sortable="true"><i class="icon_building"></i>Cliente</th>--%>
                                                    <th data-field="Concepto" data-sortable="true"><i class="icon_archive_alt"></i>Concepto</th>
                                                    <th data-field="CostoCotizaciones" data-sortable="true"><i class="icon_creditcard"></i>Costo</th>
                                                    <%--<th data-field="FechaCotizaciones" data-sortable="true"><i class="icon_calendar"></i>Fecha</th>--%>
                                                    <%--<th data-field="FechaCreacion" data-sortable="true" data-formatter="dateFormat"><i class="icon_calendar"></i>Fecha</th>
                                                    --%>
                                                </tr>
                                            </thead>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <div class="x_panel">
                                    <div class="x_content">
                                        <div>
                                            <span class="d-inline-block btn-add-excel">
                                                <label>Ford Irapuato</label>
                                            </span>
                                        </div>
                                        <table id="TablaCotizacionIrapuato" class="table table-striped table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                            <thead>
                                                <tr>
                                                    <th data-align="center" data-formatter="accionCotIrapuatoFormatter" data-events="accionCotEvents"><i class="icon_ol"></i></th>
                                                    <th data-field="NoCotizaciones" data-sortable="true"><i class="icon_ribbon_alt"></i># Cotizacion</th>
                                                    <%--<th data-field="Cliente" data-sortable="true"><i class="icon_building"></i>Cliente</th>--%>
                                                    <th data-field="Concepto" data-sortable="true"><i class="icon_archive_alt"></i>Concepto</th>
                                                    <th data-field="CostoCotizaciones" data-sortable="true"><i class="icon_creditcard"></i>Costo</th>
                                                    <%--<th data-field="FechaCotizaciones" data-sortable="true"><i class="icon_calendar"></i>Fecha</th>--%>
                                                    <%--<th data-field="FechaCreacion" data-sortable="true" data-formatter="dateFormat"><i class="icon_calendar"></i>Fecha</th>
                                                    --%>
                                                </tr>
                                            </thead>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
                        <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <div class="x_panel">
                                    <div class="x_content">
                                        <div>
                                            <span class="d-inline-block btn-add-excel">
                                                <label>Ford Chihuahua</label>
                                            </span>
                                        </div>
                                        <table id="TablaCotizacionChihu" class="table table-striped table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                            <thead>
                                                <tr>
                                                    <th data-align="center" data-formatter="accionCotChihuFormatter" data-events="accionCotEvents"><i class="icon_ol"></i></th>
                                                    <th data-field="NoCotizaciones" data-sortable="true"><i class="icon_ribbon_alt"></i># Cotizacion</th>
                                                    <%--<th data-field="Cliente" data-sortable="true"><i class="icon_building"></i>Cliente</th>--%>
                                                    <th data-field="Concepto" data-sortable="true"><i class="icon_archive_alt"></i>Concepto</th>
                                                    <th data-field="CostoCotizaciones" data-sortable="true"><i class="icon_creditcard"></i>Costo</th>
                                                    <%--<th data-field="FechaCotizaciones" data-sortable="true"><i class="icon_calendar"></i>Fecha</th>--%>
                                                    <%--<th data-field="FechaCreacion" data-sortable="true" data-formatter="dateFormat"><i class="icon_calendar"></i>Fecha</th>
                                                    --%>
                                                </tr>
                                            </thead>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <div class="x_panel">
                                    <div class="x_content">
                                        <div>
                                            <span class="d-inline-block btn-add-excel">
                                                <label>Ford Cuautitlan</label>
                                            </span>
                                        </div>
                                        <table id="TablaCotizacionCuau" class="table table-striped table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                            <thead>
                                                <tr>
                                                    <th data-align="center" data-formatter="accionCotCuauFormatter" data-events="accionCotEvents"><i class="icon_ol"></i></th>
                                                    <th data-field="NoCotizaciones" data-sortable="true"><i class="icon_ribbon_alt"></i># Cotizacion</th>
                                                    <%--<th data-field="Cliente" data-sortable="true"><i class="icon_building"></i>Cliente</th>--%>
                                                    <th data-field="Concepto" data-sortable="true"><i class="icon_archive_alt"></i>Concepto</th>
                                                    <th data-field="CostoCotizaciones" data-sortable="true"><i class="icon_creditcard"></i>Costo</th>
                                                    <%--<th data-field="FechaCotizaciones" data-sortable="true"><i class="icon_calendar"></i>Fecha</th>--%>
                                                    <%--<th data-field="FechaCreacion" data-sortable="true" data-formatter="dateFormat"><i class="icon_calendar"></i>Fecha</th>
                                                    --%>
                                                </tr>
                                            </thead>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="x_panel">
                                    <div class="x_content">
                                        <div>
                                            <span class="d-inline-block btn-add-excel">
                                                <label>Paquete</label>
                                            </span>
                                        </div>
                                        <table id="TablaCotizacionPaquete" class="table table-striped table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-show-footer="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                            <thead>
                                                <tr>
                                                    <th data-align="center" data-formatter="accionCotPaqueteFormatter" data-events="accionCotPaqueteEvents"><i class="icon_ol"></i></th>
                                                    <th data-field="NoCotizaciones" data-sortable="true"><i class="icon_ribbon_alt"></i># Cotizacion</th>
                                                    <th data-field="Cliente" data-sortable="true"><i class="icon_building"></i>Cliente</th>
                                                    <th data-field="Concepto" data-sortable="true"><i class="icon_archive_alt"></i>Concepto</th>
                                                    <th data-field="CostoCotizaciones" data-sortable="true" data-footer-formatter="TotalFormatter"><i class="icon_creditcard"></i>Costo</th>
                                                    <th data-field="FechaCotizaciones" data-sortable="true"><i class="icon_calendar"></i>Fecha</th>
                                                </tr>
                                            </thead>
                                            <tfoot>
                                                <tr>
                                                    <th></th>
                                                    <th></th>
                                                    <th></th>
                                                    <th>Total:</th>
                                                    <td><span id="lblTotal">$0.00</span></td>
                                                    <th></th>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row col-md-12 col-sm-12 col-xs-12">
                            <button class="btn btn-primary" id="btnGuardarPaquete" type="button">Guardar cambios</button>
                        </div>
                    </section>
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
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/PaqueteCotizaciones.js" type="text/javascript"></script>
</asp:Content>

