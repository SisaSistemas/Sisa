<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="FacturasEmitidas.aspx.cs" Inherits="SisaDev.Administracion.FacturasEmitidas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .row-selected {
            background-color: orange;
        }

        .estatusPagada {
            background-color: #90ee90;
        }

        .estatusCancelada {
            background-color: #ffa084;
            color: white;
        }

        .estatus {
            background-color: white;
        }

        .estatusNoEnviada {
            background-color: #ffff9e;
        }
    </style>
    <script>
        function abrirmodal() {
            $('#cmbProveedoresFR').val('-1');
            $('#cmbOCFR').val('-1');
            $('#cmbProyectosFR').val('-1');
            $('#dtFechaFR').val('');
            $("#AddFacturasFRModal").modal();
        }


        (function (document) {
            'use strict';

            var LightTableFilter = (function (Arr) {

                var _input;

                function _onInputEvent(e) {
                    _input = e.target;
                    var tables = document.getElementsByClassName(_input.getAttribute('bootstrap-table'));
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div id="loading-img">  <img src="../img/logoloading.png" class="blink" /></div>--%>

    <section id="main-content">

        <section class="wrapper">

            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Administración</li>
                        <li><i class="icon_building"></i>Facturas Emitidas</li>
                    </ol>
                </div>
            </div>
            <!-- page start-->
            <%--<div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div class="btn-group">
                            <button class="btn btn-warning" id="btnFacturasEmitidas" style="color: black;"><i class="icon_documents"></i>Facturas Emitidas</button>
                            <button class="btn btn-info" id="btnFacturasRecibidas"><i class="icon_documents"></i>Facturas Recibidas (Control facturas)</button>
                        </div>

                    </section>
                </div>
            </div>--%>

            <button class="btn btn-primary" title="XML" id="btnFEmitidasXML"><i class="icon_documents"></i>Facturas Emitidas (XML)</button>

            <div class="form-group">
                                              <span class="btn btn-success" id="btnmultipleOrdenes" >Pagos Multiples<i class="icon_wallet"></i></span>
                                          </div>

            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div class="form-group" id="MensajeFacturas">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>

                        <div id="TablaTotales"></div>
                        <header class="panel-heading">
                            Lista de Facturas
                            <label id="TipoFactura" style="font-weight: bold; font-size: large;"></label>
                            <div class="btn-group" id="botones">

                                <form class="form-inline">
                                    <div class="form-group">
                                        <%--<button class="btn btn-primary" title="Agregar emitidas" id="btnAgregarEmitidas" data-toggle="modal" data-target="#AddFacturasEmitidasModal"><i class="icon_plus_alt2"></i></button>--%>
                                        <a class="btn btn-primary add-link" title="Agregar Emitidas" data-toggle="modal" id="btnAgregarEmitidas" data-keyboard="false" data-backdrop="static" data-target="#AddFacturasEmitidasModal"><i class="icon_plus_alt2"></i>Agregar Emitidas </a>

                                        

                                    </div>
                                    <div class="form-group">
                                        <%--<input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar" id="btnBusquedaEscrita" style="width: 100px;">--%>

                                        <%--EMITIDAS--%>
                                        <div id="busquedaemitidas" >

                                            Año
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbAnioBuscar"></select>
                                            Cliente
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbClienteBuscar"></select>
                                            Proyecto
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbProyectoEmitidaBuscar"></select>
                                            Moneda
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbMonedaEmitidaBuscar"></select>
                                            Estatus
                                            <select id="cmbEstatusEmitidas" class="form-control" style="width: 100px;">
                                                <option value="-1">TODOS</option>
                                                <option value="0">PENDIENTE</option>
                                                <option value="1">PAGADO</option>
                                                <option value="2">CANCELADA</option>
                                            </select>
                                            Enviada
                                            <select id="cmbEnviadaEmitidas" class="form-control selectpicker" style="width: 100px;">
                                                <option value="-1">TODOS</option>
                                                <option value="0">NO</option>
                                                <option value="1">SI</option>
                                            </select>
                                            <button class="btn btn-danger" id="btnBuscarEmitidas" type="button">Buscar.</button>
                                        </div>
                                    </div>

                                </form>
                            </div>

                        </header>
                        <div class="form-group" id="CargandoFacturas">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>
                        <div style="overflow-x: auto; overflow-y: auto; height: 100%;">
                            <table class="table table-sm" data-pagination="true" id="TablaFacturas" data-search="true" data-show-export="true" data-export-data-type="all" data-export-types="['pdf', 'doc', 'excel']">
                                <thead id="EncabezadoFacturas">
                                    <tr>
                                        <th data-align="center" data-formatter="pagoMultipleFormatter" data-events="pagoMultipleEvents"></th>
                                        <th data-visible="false"><i class="icon_building"></i>Código</th>
                                        <th data-field="FechaFactura" data-sortable="true" data-formatter="dateFormat"><i class="icon_calendar"></i>Fecha factura</th>
                                        <th data-field="FolioFactura" data-sortable="true"><i class="icon_info_alt"></i>Folio</th>
                                        <th data-field="NombreReceptor" data-sortable="true"><i class="icon_building"></i>Nombre Receptor</th>
                                        <th data-field="Sucursal" data-sortable="true"><i class="icon_building"></i>Sucursal</th>
                                        <th data-field="NombreProyecto" data-sortable="true"><i class="icon_book_alt"></i>Proyecto</th>
                                        <th data-field="NoCotizacion" data-sortable="true"><i class="icon_info_alt"></i>Cotización</th>
                                        <th data-field="OrdenCompraRecibida" data-sortable="true"><i class="icon_info_alt"></i>Orden Compra</th>
                                        <th data-field="SubTotal" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class=" icon_currency"></i>Subtotal</th>
                                        <th data-field="Iva" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class=" icon_currency"></i>IVA</th>
                                        <%--<th data-field="Retencion" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class=" icon_currency"></i>Retención</th>--%>
                                        <th data-field="Total" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_currency"></i>Total</th>
                                        <th data-field="Moneda" data-sortable="true"><i class="icon_currency"></i>Moneda</th>
                                        <th data-field="FechaPA" data-sortable="true"><i class="icon_calendar"></i>Fecha PA</th>
                                        <th data-field="ProgramacionPago1" data-sortable="true"><i class="icon_info_alt"></i>Prog pago</th>
                                        <th data-field="PorPagar" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_currency"></i>Por pagar</th>
                                        <th data-field="FechaPago1" data-sortable="true"><i class="icon_calendar"></i>Fecha de pago</th>
                                        <th data-field="Estatus" data-sortable="true" data-formatter="estatusFormatter"><i class="icon_loading"></i>Estatus</th>
                                        <th data-field="Enviada" data-sortable="true" data-formatter="enviadoFormatter"><i class="icon_loading"></i>Enviado</th>
                                        <th data-field="CorreoEnviado" data-sortable="true"><i class="icon_mail_alt"></i>Correo Enviado</th>

                                        
                                        <th data-align="center" data-formatter="accionFormatter" data-events="accionEvents"><i class="icon_ol"></i>Acciones</th>
                                    </tr>
                                </thead>
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


    <%--PDF--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvPDFFacturas" tabindex="-1" role="dialog" aria-labelledby="dvPDFdvPDFFacturas" aria-hidden="true">
        <div class="modal-dialog" style="width: 60%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabeldvPDFFacturas">Archivo PDF</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <label id="txtidFacturaArchivo" hidden="hidden"></label>
                        <label id="txtTipoDocumentoFactura" hidden="hidden"></label>
                        <div id="testmodalpdffe" style="padding: 5px 20px;">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button type="button" class="btn btn-danger" id="btnEliminadDocumentoFactura" data-dismiss="modal">Eliminar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--AGREGAR EMITIDAS--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddFacturasEmitidasModal" tabindex="-1" role="dialog" aria-labelledby="AddFacturasEmitidasModal" aria-hidden="true">
        <div class="modal-dialog" style="width: 75%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelAgregarFacturasFE">Agregar Facturas </h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-lg-10">
                                <div class="row">
                                    <div class="col-lg-4" style="width: 100%;">
                                        <label>Folio factura</label>
                                        <input type="text" class="form-control" placeholder="Folio factura" id="txtFolioFE" required />
                                        <label>Fecha factura</label>
                                        <input type="date" class="form-control" id="dtFechaFE" required />
                                        <label>RFC Receptor</label>
                                        <input type="text" class="form-control" placeholder="RFC Receptor" id="txtRFCFacturaE" required />
                                        <label>Nombre receptor</label>
                                        <input type="text" class="form-control" placeholder="Nombre receptor" id="txtReceptorFacturaE" required />
                                        <label>Proyectos</label>
                                        <select id="cmbProyectosFE" class="form-control  selectpicker" data-live-search="true"></select>
                                        <label>Cotización</label>
                                        <input type="text" class="form-control" placeholder="Cotización" id="txtCotizacionFacturaE" />
                                        <label>OC Recibida</label>
                                        <input type="text" class="form-control" placeholder="OC Recibida" id="txtOCFacturaE" />
                                        <label>Estatus</label>
                                        <select id="cmbEstatusFE" class="form-control">
                                            <option value="0">PENDIENTE</option>
                                            <option value="1">PAGADO</option>
                                            <option value="2">CANCELADA</option>
                                        </select>
                                    </div>
                                    <div class="col-lg-4" style="width: 100%;">
                                        <label>MONEDA</label>
                                        <select id="cmbMonedaFE" class="form-control">
                                            <option value="MXN">MXN</option>
                                            <option value="USD">USD</option>
                                        </select>
                                        <label>Subtotal</label>
                                        <input type="text" class="form-control" placeholder="Subtotal" id="txtSubtotalFE" required />
                                        <label>IVA</label>
                                        <input type="text" class="form-control" placeholder="IVA" id="txtIvaFE" required />
                                        <label>Total</label>
                                        <input type="text" class="form-control" placeholder="Total" id="txtTotalFE" required />
                                        <%--<label>Retención</label>
                                        <input type="text" class="form-control" placeholder="Total" id="txtRetencionFE" required />--%>
                                        <label>Por pagar</label>
                                        <input type="text" class="form-control" placeholder="Por pagar" id="txtPorPagarFE" />
                                        <label>Tipo de cambio</label>
                                        <input type="text" class="form-control" value="1.00" id="txtTipoCambioFE" required />
                                        <label>Fecha de PA</label>
                                        <input type="date" value="" class="form-control" id="dtFechaPA" required />
                                        <label>Fecha de pago</label>
                                        <input type="date" value="" class="form-control" id="dtFechaPagoFE" required />
                                        <label>Programación de pago</label>
                                        <input type="date" value="" class="form-control" id="dtProgramacionFechaFE" required />
                                    </div>

                                </div>
                            </div>
                        </div>



                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-primary" id="btnGuardarFacturasEmitidas" type="button">Crear</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--EDITAR EMITIDAS--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddFacturasEmitidasEditarModal" tabindex="-1" role="dialog" aria-labelledby="AddFacturasEmitidasEditarModal" aria-hidden="true">
        <div class="modal-dialog" style="width: 75%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelAgregarFacturasFEEditar">Editar Facturas </h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-lg-10">
                                <div class="row">
                                    <div class="col-lg-4" style="width: 100%;">
                                        <input type="hidden" id="idFEEditar" />
                                        <label>Folio factura</label>
                                        <input type="text" class="form-control" placeholder="Folio factura" id="txtFolioFEEditar" required />
                                        <label>Fecha factura</label>
                                        <input type="date" class="form-control" id="dtFechaFEEditar" required />
                                        <label>RFC Receptor</label>
                                        <input type="text" class="form-control" placeholder="RFC Receptor" id="txtRFCFacturaEEditar" required />
                                        <label>Nombre receptor</label>
                                        <input type="text" class="form-control" placeholder="Nombre receptor" id="txtReceptorFacturaEEditar" required />
                                        <label>Proyectos</label>
                                        <select id="cmbProyectosFEEditar" class="form-control  selectpicker" data-live-search="true"></select>
                                        <label>Cotización</label>
                                        <input type="text" class="form-control" placeholder="Cotización" id="txtCotizacionFacturaEEditar" />
                                        <label>OC Recibida</label>
                                        <input type="text" class="form-control" placeholder="OC Recibida" id="txtOCFacturaEEditar" />
                                        <label>Estatus</label>
                                        <select id="cmbEstatusFEEditar" class="form-control">
                                            <option value="0">PENDIENTE</option>
                                            <option value="1">PAGADO</option>
                                            <option value="2">CANCELADA</option>
                                        </select>
                                    </div>
                                    <div class="col-lg-4" style="width: 100%;">
                                        <label>MONEDA</label>
                                        <select id="cmbMonedaFEEditar" class="form-control">
                                            <option value="MXN">MXN</option>
                                            <option value="USD">USD</option>
                                        </select>
                                        <label>Subtotal</label>
                                        <input type="text" class="form-control" placeholder="Subtotal" id="txtSubtotalFEEditar" required />
                                        <label>IVA</label>
                                        <input type="text" class="form-control" placeholder="IVA" id="txtIvaFEEditar" required />
                                        <label>Total</label>
                                        <input type="text" class="form-control" placeholder="Total" id="txtTotalFEEditar" required />
                                       <%-- <label>Retención</label>
                                        <input type="text" class="form-control" placeholder="Total" id="txtRetencionFEEditar" required />--%>
                                        <label>Por pagar</label>
                                        <input type="text" class="form-control" placeholder="Por pagar" id="txtPorPagarFEEditar" />
                                        <label>Tipo de cambio</label>
                                        <input type="text" class="form-control" value="1.00" id="txtTipoCambioFEEditar" required />
                                        <label>Fecha de PA</label>
                                        <input type="date" value="" class="form-control" id="dtFechaPAEditar" required />
                                        <label>Fecha de pago</label>
                                        <input type="date" value="" class="form-control" id="dtFechaPagoFEEditar" required />
                                        <label>Programación de pago</label>
                                        <input type="date" value="" class="form-control" id="dtProgramacionFechaFEEditar" required />
                                        <label>Enviada</label>
                                        <input type="checkbox" id="chkEnviadaEditar" tabindex="15" class="flat"><span id="txtTextoEnviadaEditar">NO</span><br />
                                        <label>Correo Enviado</label>
                                        <input type="text" class="form-control" placeholder="Correo Enviado" id="txtCorreoEditar" required />
                                    </div>

                                </div>
                            </div>
                        </div>



                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-primary" id="btnEditarFacturasEmitidas" type="button">Actualizar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelFacturasModal" tabindex="-1" role="dialog" aria-labelledby="DelFacturasModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelEliminarFacturas">Eliminar Facturas</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group" id="txtModalEliminarFacturas">
                            <label id="idFacturasEliminar" hidden="hidden"></label>
                            <label id="idFacturasEliminarTipo" hidden="hidden"></label>
                            <label id="idFacturasEliminarTexto"></label>
                        </div>
                        <div class="form-group" id="txtModalEliminarMensajeFacturas">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-danger" id="btnEliminarFacturas" type="button">Eliminar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--FORMA PAGO--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="FormaPagoFacturasModal" tabindex="-1" role="dialog" aria-labelledby="FormaPagoFacturasModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelFormaPagoFacturas">Cambiar estatus a pagado de Facturas</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"></button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <label>No Facturas: </label>
                            <span id="lblNoFacturas"></span>
                        </div>
                        <div class="form-group">
                            <label>Forma de pago</label>
                            <input type="text" class="form-control" id="txtFormaPago" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-danger" id="btnEstatusFormaPagoFacturas" type="button">Actualizar información de facturas.</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--PAGOS MULTIPLES 16-05-2024 VAM--%>
            <div class="modal fade" data-backdrop="static" data-keyboard="false" id="MultipagosOCModal" tabindex="-1" role="dialog" aria-labelledby="MultipagosOCModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="LabelMultipagosOC">Pagos Multiples OC</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            </button>
                        </div>
                        <form class="form-horizontal ">
                            <div class="modal-body">
                                <div class="form-group" id="txtModalPagoMultipleOC">
                                    <label id="idOCPagoMultiple" hidden="hidden"></label>
                                    <label id="idOCPagoMultipleTexto"></label>
                                </div>
                                <div class="col-md-5 col-sm-5 col-xs-12 form-group has-feedback">
                                        <input type="date" class="form-control" id="txtFechaPagoMultiple" tabindex="4" required />
                                    </div>
                                <div class="col-md-5 col-sm-5 col-xs-12 form-group has-feedback">
                                    <select id="cmbEstatus" class="form-control selectpicker has-feedback-left" data-live-search="true">
                                        <option value="0">PENDIENTE</option>
                                        <option value="1">PAGADO</option>
                                        <option value="2">CANCELADA</option>
                                    </select>
                                </div>
                                <div class="form-group" id="txtModalPagoMultipleMensajeOC">
                                    <table id="TablaPrincipalPagosMultiples" class="table table-striped projects">
                                        <thead>
                                            <tr>
                                                <th>Folio</th>
                                                <th>Proyecto</th>
                                                <th>Por Pagar</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <th></th>
                                                <th><span style="text-align:right;">Total:</span></th>
                                                <th><span id="lblTotalPagado"></span></th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                                <button class="btn btn-success" id="btnPagoMultipleOC" type="button">Pagar</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <!-- page end-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/FacturasEmitidas.js" type="text/javascript"></script>
</asp:Content>
