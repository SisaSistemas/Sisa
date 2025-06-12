<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="FacturasRecibidas.aspx.cs" Inherits="SisaDev.Administracion.FacturasRecibidas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .row-selected {
            background-color: orange;
        }

        .estatusPagada{
            background-color: #90ee90;
        }

        .estatusCancelada {
            background-color: #ffa084;
            color: white;
        }

        .estatus {
            background-color: white;
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">

        <section class="wrapper">

            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Administración</li>
                        <li><i class="icon_building"></i>Facturas Recibidas</li>
                    </ol>
                </div>
            </div>
            <!-- page start-->
            <%--<div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div class="btn-group">
                            <button class="btn btn-info" id="btnFacturasRecibidas"><i class="icon_documents"></i>Facturas Recibidas (Control facturas)</button>
                        </div>

                    </section>
                </div>
            </div>--%>

            <button class="btn btn-primary" title="Global" id="btnModificarGlobalmente" ><i class="icon_pencil"></i>Modificar globalmente facturas seleccionadas.</button>
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
                                            OC Folio
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbOCRecibidaBuscar"></select>
                                            <button class="btn btn-danger" id="btnBuscarRecibidas" type="button">Buscar.</button>
                                        </div>
                                    </div>

                                </form>
                            </div>

                        </header>
                        <div class="form-group" id="CargandoFacturas">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>
                        <div style="overflow-x: auto; overflow-y: auto; height: 100%;">
                            <table class="table table-sm" data-pagination="true" id="TablaFacturas">
                                <thead id="EncabezadoFacturas">
                                    <tr>
                                        <th data-visible="false"> <i class="icon_building"></i>Código</th> 
                                        <th data-field="FechaFactura" data-sortable="true"><i class="icon_calendar"></i>Fecha factura</th> 
                                        <th data-field="Proveedor" data-sortable="true"><i class="icon_building"></i>Proveedor</th>     
                                        <th data-field="NoFactura" data-sortable="true"><i class="icon_info_alt"></i>Folio</th>          
                                        <th data-field="OrdenCompra" data-sortable="true"><i class="icon_info_alt"></i>Orden Compra</th>   
                                        <th data-field="Proyecto" data-sortable="true"><i class="icon_book_alt"></i>Proyecto</th>       
                                        <th data-field="Moneda" data-sortable="true"><i class="icon_currency"></i>Moneda</th>         
                                        <th data-field="SubTotal" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_currency"></i>Subtotal</th>       
                                        <th data-field="Descuento" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_currency"></i>Descuento</th>      
                                        <th data-field="IVA" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_currency"></i>IVA</th>            
                                        <th data-field="Total" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_currency"></i>Total</th>          
                                        <th data-field="APagar" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_currency"></i>A pagar</th>        
                                        <th data-field="Estatus" data-sortable="true" data-formatter="estatusFormatter"><i class="icon_loading"></i>Estatus</th>         
                                        <th data-field="FormaPago" data-sortable="true"><i class="icon_info_alt"></i>Forma de pago</th>  
                                        <th data-field="FechaPago" data-sortable="true"><i class="icon_calendar"></i>Fecha de pago</th>  
                                        <th data-field="Categoria" data-sortable="true"><i class="icon_box-empty"></i>Categoria</th>     
                                        <th data-field="Anticipo" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_currency"></i>Anticipo</th>       
                                        <th data-field="NotaCredito" data-sortable="true"><i class="icon_currency"></i>Nota de credito</th>
                                                                                     
                                        <th data-align="center" data-formatter="accionFormatter" data-events="accionEvents"><i class="icon_ol"></i>Acciones</th>             
                                    </tr >
                                </thead>
                                <%--<tbody id="listaFacturas">
                                </tbody>--%>
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
<asp:Content ID="Content3" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/FacturasRecibidas.js" type="text/javascript"></script>
</asp:Content>
