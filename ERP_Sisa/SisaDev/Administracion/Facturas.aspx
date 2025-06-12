<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Sitio.Master" CodeBehind="Facturas.aspx.cs" Inherits="SisaDev.Administracion.Facturas" %>


<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <style>
        .row-selected {
            background-color: orange;
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
                    var tables = document.getElementsByClassName(_input.getAttribute('data-table'));
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
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
     <%--<div id="loading-img">  <img src="../img/logoloading.png" class="blink" /></div>--%>

    <section id="main-content">

        <section class="wrapper">

            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Administración</li>
                        <li><i class="icon_building"></i>Facturas</li>
                    </ol>
                </div>
            </div>
            <!-- page start-->
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div class="btn-group">
                            <button class="btn btn-warning" id="btnFacturasEmitidas" style="color: black;"><i class="icon_documents"></i>Facturas Emitidas</button>
                            <button class="btn btn-info" id="btnFacturasRecibidas"><i class="icon_documents"></i>Facturas Recibidas (Control facturas)</button>
                        </div>

                    </section>
                </div>
            </div>

            <button class="btn btn-primary" title="XML" id="btnFEmitidasXML"><i class="icon_documents"></i>Facturas Emitidas (XML)</button>
            <%--<button class="btn btn-default" id="btnEmitidas" title="Filtrar" data-toggle="modal" data-target="#FiltroEmitidasFacturasModal">Filtrar<i class="icon_search"></i></button>--%>

            <button class="btn btn-primary" title="Global" id="btnModificarGlobalmente" data-toggle="modal" data-target="#FormaPagoFacturasModal"><i class="icon_pencil"></i>Modificar globalmente facturas seleccionadas.</button>
            <%--<button class="btn btn-default" title="Filtrar" id="btnrRecibidas" data-toggle="modal" data-target="#FiltroRecibidasFacturasModal">Filtrar<i class="icon_search"></i></button>--%>
            <button class="btn btn-default" title="XML" id="btnFRecibidaXML"><i class="icon_documents"></i>Facturas Recibida (XML)</button>
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
                                        <a class="btn btn-primary add-link" title="Agregar Emitidas" data-toggle="modal" id="btnAgregarEmitidas" data-keyboard="false" data-backdrop="static" data-target="#AddFacturasEmitidasModal"><i class="icon_plus_alt2"></i> Agregar Emitidas </a>

                                        <%--<button class="btn btn-primary" title="Agregar recibidas" id="btnAgregarRecibidas" data-toggle="modal" data-target="#AddFacturasFRModal"><i class="icon_plus_alt2"></i></button>--%>
                                        <a class="btn btn-primary add-link" title="Agregar Recibidas" data-toggle="modal" id="btnAgregarRecibidas" data-keyboard="false" data-backdrop="static" data-target="#AddFacturasFRModal"><i class="icon_plus_alt2"></i> Agregar Recibidas </a>
                                        <%--  onclick="abrirmodal();"--%>
                                    </div>
                                    <div class="form-group">
                                        <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar" id="btnBusquedaEscrita" style="width: 100px;">
                                        <div id="busquedarecibidos">
                                            Mes
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbFechaBuscar"></select>
                                            Año
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbFechaAnioBuscar"></select>
                                            Proveedor
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbProveedorBuscar"></select>
                                            Factura
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbFacturaBuscar"></select></>
                                            Proyecto
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbProyectoRecibidaBuscar"></select>
                                            Moneda
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbMonedaRecibidaBuscar"></select>
                                            Estatus
                                            <select id="cmbEstatusRecibidas" class="form-control" style="width: 100px;">
                                                <option value="-1">TODOS</option>
                                                <option value="0">PENDIENTE</option>
                                                <option value="1">PAGADO</option>
                                                <option value="2">CANCELADA</option>
                                            </select>
                                            OC
                                            <select id="cmb0Recibida" class="form-control" style="width: 100px;">
                                                <option value="-1">TODAS</option>
                                                <option value="1">PENDIENTES</option>
                                            </select>
                                            <button class="btn btn-danger" id="btnBuscarRecibidas" type="button">Buscar.</button>
                                        </div>
                                        <%--EMITIDAS--%>
                                        <div id="busquedaemitidas">
                                            <%--Factura
                                    <select class="form-control selectpicker" data-live-search="true" id="cmbFacturaREcibidaBuscar">                                       
                                    </select>--%>
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
                            <table class="table table-stripped order-table" id="TablaFacturas">
                                <thead id="EncabezadoFacturas">
                                    <%--<tr>
                                    <th style="display: none;"><i class="icon_building"></i>Código</th>
                                    <th><i class="icon_table"></i>Código</th>
                                    <th><i class="icon_link_alt"></i>Descripción</th>
                                    <th><i class="icon_info_alt"></i>Catégoria</th>
                                    <th><i class="icon_search-2"></i>Pálabras claves</th>
                                    <th><i class="icon_profile"></i>Usuario</th>

                                    <th><i class="icon_ol"></i>Acciones</th>
                                </tr>--%>
                                </thead>
                                <tbody id="listaFacturas">
                                </tbody>
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
    <%--AGREGAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddFacturasFRModal" tabindex="-1" role="dialog" aria-labelledby="AddFacturasFRModal" aria-hidden="true">
        <div class="modal-dialog" id="divAncho" style="width: 75%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelAgregarFacturasFR">Agregar Facturas </h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal">
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-6">
                                <section class="panel">
                                    <div class="panel-body">
                                        <label>Proveedores</label>
                                        <select id="cmbProveedoresFR" class="form-control selectpicker" tabindex="1" data-live-search="true"></select>
                                        <label>Proyectos</label>
                                        <select id="cmbProyectosFR" class="form-control selectpicker" tabindex="3" data-live-search="true"></select>
                                        <label>No. Factura</label>
                                        <input type="text" class="form-control" placeholder="No. Factura" id="txtFolioFacturaR" tabindex="5" required />
                                        <label>Subtotal</label>
                                        <input type="text" class="form-control" placeholder="Subtotal" id="txtSubtotalFR" tabindex="7" required />

                                        <label>IVA</label>
                                        <input type="text" class="form-control" placeholder="IVA" id="txtIvaFR" tabindex="9" required />
                                        <label>Anticipo con IVA</label>
                                        <input type="text" class="form-control" placeholder="Anticipo" tabindex="11" id="txtAnticipoFR" value="0" />
                                        <label>Estatus</label>
                                        <select id="cmbEstatusFR" class="form-control" tabindex="13">
                                            <option value="0">PENDIENTE</option>
                                            <option value="1">PAGADO</option>
                                            <option value="2">CANCELADA</option>
                                        </select>
                                        <label>Viaticos</label>
                                        <input type="checkbox" id="chkViaticos" class="flat" tabindex="15"><span id="txtTextoViaticos">NO</span>
                                    </div>
                                </section>
                            </div>
                            <div class="col-sm-6">
                                <section class="panel">
                                    <div class="panel-body">
                                        <label>Orden de compra</label>
                                        <select id="cmbOCFR" class="form-control selectpicker" tabindex="2" data-live-search="true">
                                            <option value="-1">-- SELECCION ORDEN COMPRA --</option>
                                            <option value="N/A">N/A</option>
                                            <option value="PENDIENTE">PENDIENTE</option>
                                        </select>
                                        <label>Fecha factura</label>
                                        <input type="date" class="form-control" id="dtFechaFR" tabindex="4" required />
                                        <label>MONEDA</label>
                                        <select id="txtMonedaFR" class="form-control" tabindex="6">
                                            <option value="MXN">MXN</option>
                                            <option value="USD">USD</option>
                                        </select>
                                        <label>Descuento</label>
                                        <input type="text" value="0" class="form-control" value="0.00" tabindex="8" placeholder="Descuento" id="txtDescuentoFR" onfocusout="DescuentoFocus()" required />

                                        <label>Total</label>
                                        <input type="text" class="form-control" placeholder="Total" id="txtTotalFR" tabindex="10" required />

                                        <label>Nota de credito con IVA</label>
                                        <input type="text" class="form-control" placeholder="Nota de credito" tabindex="12" id="txtNotaCreditoFR" value="0" />
                                        <label>Forma pago</label>
                                        <input type="text" class="form-control" placeholder="Forma pago" tabindex="14" id="txtFormaPagoFR" required />
                                        <label>Categoria:</label>
                                        <select id="cmbCategoriaFactura" class="form-control" tabindex="16" required>
                                            <option value="MATERIAL">MATERIAL</option>
                                            <option value="MANOOBRA">MANO DE OBRA</option>
                                            <option value="EQUIPO">EQUIPO</option>
                                        </select>
                                    </div>
                                </section>
                            </div>
                        </div>




                    </div>
                    <div class="form-group">
                        <div class="col-lg-offset-2 col-lg-10">
                            <i class="icon_documents_alt"></i>
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnAdjuntarArchivoFR">Adjuntar archivo</button>
                            <input type="hidden" id="dataarchivopdf" />
                            <input type="hidden" id="nombreaarchivopdf" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-primary" id="btnGuardarFacturasRecibidas" type="button">Crear</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <%--Editar--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddFacturasFRModalEditar" tabindex="-1" role="dialog" aria-labelledby="AddFacturasFRModalEditar" aria-hidden="true">
        <div class="modal-dialog" id="divAnchoEditar" style="width: 75%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelAgregarFacturasFREditar">Editar Facturas </h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-6">
                                <section class="panel">
                                    <div class="panel-body">
                                        <input type="hidden" id="idFREditar" />
                                        <label>Proveedores</label>
                                        <select id="cmbProveedoresFREditar" class="form-control selectpicker" tabindex="1" data-live-search="true"></select>
                                        <label>Proyectos</label>
                                        <select id="cmbProyectosFREditar" tabindex="3" class="form-control  selectpicker" data-live-search="true"></select>
                                        <label>No. Factura</label>
                                        <input type="text" class="form-control" tabindex="5" placeholder="No. Factura" id="txtFolioFacturaREditar" required />
                                        <label>Subtotal</label>
                                        <input type="text" class="form-control" tabindex="7" placeholder="Subtotal" id="txtSubtotalFREditar" />
                                        <label>IVA</label>
                                        <input type="text" class="form-control" tabindex="9" placeholder="IVA" id="txtIvaFREditar" required />
                                        <label>Anticipo con IVA</label>
                                        <input type="text" class="form-control" tabindex="11" placeholder="Anticipo" id="txtAnticipoFREditar" value="0" />

                                        <label>Estatus</label>
                                        <select id="cmbEstatusFREditar" class="form-control" tabindex="13">
                                            <option value="0">PENDIENTE</option>
                                            <option value="1">PAGADO</option>
                                            <option value="2">CANCELADA</option>
                                        </select>
                                        <label>Viaticos</label>
                                        <input type="checkbox" id="chkViaticosEditar" tabindex="15" class="flat"><span id="txtTextoViaticosEditar">NO</span>
                                    </div>
                                </section>
                            </div>
                            <div class="col-sm-6">
                                <section class="panel">
                                    <div class="panel-body">
                                        <label>Orden de compra</label>
                                        <select id="cmbOCFREditar" class="form-control  selectpicker" tabindex="2" data-live-search="true">
                                            <option value="-1">-- SELECCION ORDEN COMPRA --</option>
                                            <option value="N/A">N/A</option>
                                            <option value="PENDIENTE">PENDIENTE</option>
                                        </select>
                                        <label>Fecha factura</label>
                                        <input type="date" class="form-control" id="dtFechaFREditar" tabindex="4" required />
                                        <label>MONEDA</label>
                                        <select id="txtMonedaFREditar" class="form-control" tabindex="6">
                                            <option value="MXN">MXN</option>
                                            <option value="USD">USD</option>
                                        </select>
                                        <label>Descuento</label>
                                        <input type="text" class="form-control" tabindex="8" placeholder="Descuento" id="txtDescuentoFREditar" onfocusout="DescuentoFocusEditar()" required />
                                        <label>Total</label>
                                        <input type="text" class="form-control" placeholder="Total" tabindex="10" id="txtTotalFREditar" required />
                                        <label>Forma pago</label>
                                        <input type="text" class="form-control" placeholder="Forma pago" tabindex="12" id="txtFormaPagoFREditar" required />
                                        <label>Categoria:</label>
                                        <select id="cmbCategoriaFacturaEditar" class="form-control" tabindex="14" required>
                                            <option value="MATERIAL">MATERIAL</option>
                                            <option value="MANOOBRA">MANO DE OBRA</option>
                                            <option value="EQUIPO">EQUIPO</option>
                                        </select>

                                        <label>Nota de credito con IVA</label>
                                        <input type="text" class="form-control" tabindex="16" placeholder="Nota de credito" id="txtNotaCreditoFREditar" value="0" />
                                    </div>
                                </section>
                            </div>
                        </div>



                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-primary" id="btnEditarFacturasRecibidas" type="button">Guardar cambios</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
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
                                        <label>Retención</label>
                                        <input type="text" class="form-control" placeholder="Total" id="txtRetencionFE" required />
                                        <label>Por pagar</label>
                                        <input type="text" class="form-control" placeholder="Por pagar" id="txtPorPagarFE" />
                                        <label>Tipo de cambio</label>
                                        <input type="text" class="form-control" value="1.00" id="txtTipoCambioFE" required />
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
                                        <label>Retención</label>
                                        <input type="text" class="form-control" placeholder="Total" id="txtRetencionFEEditar" required />
                                        <label>Por pagar</label>
                                        <input type="text" class="form-control" placeholder="Por pagar" id="txtPorPagarFEEditar" />
                                        <label>Tipo de cambio</label>
                                        <input type="text" class="form-control" value="1.00" id="txtTipoCambioFEEditar" required />
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

</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/Facturas.js" type="text/javascript"></script>
</asp:Content>






