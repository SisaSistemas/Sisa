<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="ModuloPO.aspx.cs" Inherits="SisaDev.Administracion.ModuloPO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .row-selected {
            background-color: orange;
        }

        .estatusReemplazadas {
            background-color: wheat;
        }

        .estatusCierreOperativo {
            background-color: #896A46; 
            color: black;
        }

        .estatusCancelada {
            background-color: #ffa084;
        }

        .estatusCompletadas {
            background-color: #90ee90;
        }

        .estatus {
            background-color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Administración</li>
                        <li><i class="icon_building"></i>Modulo PO</li>
                    </ol>
                </div>
            </div>
            <!-- page start-->
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div class="form-group" id="MensajeSucursales"></div>
                        <table class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>
                                    <th colspan="4">RESUMEN</th>
                                </tr>
                                <tr>
                                    <th>MONEDA</th>
                                    <th>MONTO</th>
                                    <th>MONTO FACTURADO</th>
                                    <th>PENDIENTE FACTURAR</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th>PESOS (MXN)</th>
                                    <td><span id="lblPesosMonto">$ 123,456</span></td>
                                    <td><span id="lblPesosFacturado">$ 123,456</span></td>
                                    <td><span id="lblPesosPendiente">$ 123,456</span></td>
                                </tr>
                                <tr>
                                    <th>DOLARES (USD)</th>
                                    <td><span id="lblDolaresMonto">$ 123,456</span></td>
                                    <td><span id="lblDolaresFacturado">$ 123,456</span></td>
                                    <td><span id="lblDolaresPendiente">$ 123,456</span></td>
                                </tr>
                            </tbody>

                        </table>
                        <header class="panel-heading">
                            Lista de PO's
                            <div class="btn-group" id="botones">
                                <form class="form-inline">
                                    <div class="form-group">
                                        <a class="btn btn-primary add-link" title="Capturar Datos" data-toggle="modal" id="btnCaptura" data-keyboard="false" data-backdrop="static"><i class="icon_plus_alt2"></i>Capturar Datos </a>
                                    </div>
                                    <div class="form-group">
                                        <div id="busquedaemitidas" >

                                            Año
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbAnioBuscar"></select>
                                            Mes
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbMesBuscar"></select>
                                            Cliente
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbClienteBuscar"></select>
                                            Proyecto
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbProyectoEmitidaBuscar"></select>
                                            Moneda
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbMonedaEmitidaBuscar"></select>
                                            Requisitor
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbRequisitor"></select>
                                            Comprador
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbComprador"></select>
                                            Estatus
                                            <select id="cmbEstatusEmitidas" class="form-control" style="width: 100px;">
                                                <option value="-1">TODOS</option>
                                                <option value="PENDIENTE">PENDIENTE</option>
                                                <option value="REEMPLAZADA">REEMPLAZADA</option>
                                                <option value="COMPLETADA">COMPLETADA</option>
                                                <option value="CANCELADA">CANCELADA</option>
                                            </select>
                                            Mark UP
                                            <select id="cmbMarkUp" class="form-control selectpicker" style="width: 100px;">
                                                <option value="-1">TODOS</option>
                                                <option value="0">NO</option>
                                                <option value="1">SI</option>
                                            </select>
                                            
                                            <button class="btn btn-danger" id="btnBuscarPO" type="button">Buscar.</button>
                                        </div>
                                    </div>
                                </form>

                            </div>
                        </header>
                        <div class="form-group" id="CargandoDatos"></div>
                        <div style="overflow-x: auto; overflow-y: auto; height: 100%;">
                            <table class="table table-sm" data-pagination="true" id="TablaModuloPO" data-search="true" data-show-export="true" data-export-data-type="all" data-export-types="['pdf', 'doc', 'excel']">
                                <thead>
                                    <tr>
                                        <th data-align="center" data-formatter="accionFormatter" data-events="accionEvents"><i class="icon_ol"></i>Acciones</th>
                                        <th data-field="Fecha" data-sortable="true" data-formatter="dateFormat"><i class="icon_info_alt"></i>Fecha</th>
                                        <th data-field="FolioPO" data-sortable="true"><i class="icon_info_alt"></i>Orden Compra</th>
                                        <th data-field="MarkUP" data-sortable="true"><i class="icon_building"></i>Mark UP</th>
                                        <th data-field="Cliente" data-sortable="true"><i class="icon_building"></i>Cliente</th>
                                        <th data-field="FolioProyecto" data-sortable="true"><i class="icon_building"></i>Folio</th>
                                        <th data-field="NombreProyecto" data-sortable="true"><i class="icon_building"></i>Proyecto</th>
                                        <th data-field="Requisitor" data-sortable="true"><i class="icon_book_alt"></i>Requisitor</th>
                                        <th data-field="Comprador" data-sortable="true"><i class="icon_book_alt"></i>Comprador</th>
                                        <th data-field="Cotizacion" data-sortable="true"><i class="icon_info_alt"></i>Cotizacion</th>
                                        <th data-field="Monto" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_info_alt"></i>Monto</th>
                                        <th data-field="Abreviatura" data-sortable="true"><i class="icon_info_alt"></i>Moneda</th>
                                        <th data-field="MontoNetoPesos" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_info_alt"></i>Monto Neto Pesos</th>
                                        <th data-field="MontoFacturado" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_info_alt"></i>Monto Facturado</th>
                                        <th data-field="PendienteFacturar" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_info_alt"></i>Pendiente Facturar</th>
                                        <th data-field="Estatus" data-sortable="true"><i class="icon_info_alt"></i>Estatus</th>
                                        <th data-field="Sucursal" data-sortable="true"><i class="icon_info_alt"></i>Sucursal</th>
                                        <th data-align="center" data-formatter="accionFormatter2" data-events="accionEvents2"><i class="icon_ol"></i>Acciones</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>

                    </section>
                </div>
            </div>
            <!-- page end-->
        </section>
    </section>

    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="CapturaDatosModal" tabindex="-1" role="dialog" aria-labelledby="CapturaDatosModal" aria-hidden="true">
        <div class="modal-dialog" style="width: 75%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelCapturaDatos"> 
                        <span>Datos Obtenidos Desde: </span><span id="lblFechaIni"></span><span>Hasta: </span> <span id="lblFechaFin"></span>
                    </h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"></button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-12">
                                 <div class="row">
                                     <div class="col-lg-4">
                                        <label>Fecha</label>
                                        <input type="date" class="form-control" id="txtFecha" required />
                                        <label>Orden de Compra</label>
                                        <input type="text" class="form-control" placeholder="Folio PO" id="txtFolioPO" required />
                                        <label>Cliente</label>
                                        <select id="cmbClientes" class="form-control selectpicker" tabindex="1" data-live-search="true"></select>
                                        <label>Requisitor</label>
                                        <input type="text" class="form-control" placeholder="Requisitor" id="txtRequisitor" required />
                                        <%--<select id="cmbRequisitor" class="form-control selectpicker" tabindex="1" data-live-search="true"></select>--%>
                                       
                                    </div>
                                    <div class="col-lg-4">
                                        <label>Comprador</label>
                                        <input type="text" class="form-control" placeholder="Comprador" id="txtComprador" required />
                                        <label>Monto</label>
                                        <input type="text" class="form-control" placeholder="Monto" id="txtMonto" required />
                                        <label>Moneda</label>
                                        <select id="cmbMoneda" class="form-control selectpicker" tabindex="1" data-live-search="true"></select>
                                        <label>Sucursal</label>
                                        <select id="cmbSucursal" class="form-control selectpicker" tabindex="1" data-live-search="true"></select>
                                    </div>
                                     <div class="col-lg-4">
                                        <%--<label>Proyecto</label>
                                        <select id="cmbProyectos" class="form-control selectpicker" tabindex="1" data-live-search="true"></select>--%>
                                        <label>Cotizacion</label>
                                        <input type="text" class="form-control" placeholder="Folio Cotización" id="txtNoCotizacion" required />
                                        <%--<select id="cmbCotizacion" class="form-control selectpicker" tabindex="1" data-live-search="true"></select>--%>
                                        <label>Estatus</label>
                                        <select id="cmbEstatus" class="form-control selectpicker" tabindex="1" data-live-search="true">
                                            <option value="PENDIENTE">PENDIENTE</option>
                                            <option value="REEMPLAZADA">REEMPLAZADA</option>
                                            <option value="COMPLETADA">COMPLETADA</option>
                                            <option value="CANCELADA">CANCELADA</option>
                                        </select>
                                        <label>Mark UP</label>
                                        <div class="form-check">
                                            <input class="form-check-input" type="checkbox" value="" id="chkMarkUp">
                                        </div>
                                    </div>
                                 </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-primary" id="btnGuardarPO" type="button">Guardar</button>
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
                    <h4 class="modal-title" id="LabeldvPDF">Agregar Administracion</h4>
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
                        <button type="button" class="btn btn-danger" id="btnEliminadDocumento" data-dismiss="modal">Eliminar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/ModuloPO.js" type="text/javascript"></script>
</asp:Content>
