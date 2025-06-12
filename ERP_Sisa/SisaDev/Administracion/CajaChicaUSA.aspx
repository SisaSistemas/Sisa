<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="CajaChicaUSA.aspx.cs" Inherits="SisaDev.Administracion.CajaChicaUSA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Administración</li>
                        <li><i class="icon_building"></i>CajaChica</li>
                    </ol>
                </div>
            </div>
            <!-- page start-->
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div class="form-group" id="MensajeCajaChica">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>
                        <header class="panel-heading">
                            Lista de CajaChica 
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                              <%--<Button class="btn btn-primary" data-toggle="modal" data-target="#AddCajaChicaModal"><i class="icon_plus_alt2"></i></Button>--%>
                              <a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddCajaChicaModal" id="btnAgregarCajaChica"><i class="icon_plus_alt2"></i>Agregar </a>
                              <%--<a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddCajaChicaSucursalModal" id="btnAgregarCajaChicaSucursal"><i class="icon_plus_alt2"></i>Agregar Sucursal</a>--%>
                          </div>
                          <%--<div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>--%>
                      </form>

                  </div>
                        </header>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="x_panel">
                                <div class="x_content">

                                    <div id="toolbar">
                                    </div>

                                    <table id="TablaCajaChica" class="table table-striped table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                        <thead>
                                            <tr>
                                                <th data-field="Fecha" data-sortable="true" data-formatter="dateFormat"><i class="icon_calendar"></i>Fecha</th>
                                                <th data-field="Responsable" data-sortable="true"><i class="icon_profile"></i>Responsable</th>
                                                <th data-field="CampoExtra" data-sortable="true"><i class="icon_profile"></i>Responsable (2)</th>
                                                <th data-field="Concepto" data-sortable="true"><i class="icon_info_alt"></i>Concepto</th>
                                                <th data-field="Proyecto" data-sortable="true"><i class="icon_tags_alt"></i>Proyecto</th>

                                                <th data-field="FolioOrdenCompra" data-sortable="true"><i class="icon_document_alt"></i>Orden Compra</th>
                                                <th data-field="Comprobante" data-sortable="true"><i class="icon_document_alt"></i>Comprobante</th>
                                                <th data-field="Cargo" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_calculator_alt"></i>Cargo</th>
                                                <th data-field="Abono" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_calculator_alt"></i>Abono</th>
                                                <th data-field="Saldo" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_calculator_alt"></i>Saldo</th>
                                                <th data-field="Categoria" data-sortable="true"><i class="icon_box-empty"></i>Categoria</th>

                                                <th data-field="Sucursal" data-sortable="true"><i class="icon_box-empty"></i>Sucursal</th>

                                                <th data-align="center" data-formatter="accionCC1Formatter" data-events="accionCC1Events"><i class="icon_ol"></i>Accion</th>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
            <!-- page end-->
        </section>
    </section>

    <%--AGREGAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddCajaChicaModal" tabindex="-1" role="dialog" aria-labelledby="AddCajaChicaModal" aria-hidden="true">
        <div class="modal-dialog" id="divAncho" style="width: 75%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelAgregarFacturasFR">Agregar Caja Chica </h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal">
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-6">
                                <section class="panel">
                                    <div class="panel-body">
                                        <label>Fecha:</label>
                                        <input type="date" class="form-control" id="dtFecha" required />
                                        <label>Responsable:</label>
                                        <select class="form-control selectpicker" id="txtResponsable" data-live-search="true"></select>
                                       <label>Responsable (2):</label>
                                        <input type="text" class="form-control" id="txtResponsable2" />
                                        <label>Concepto:</label>
                                        <input type="text" class="form-control" id="txtConcepto" required />

                                         <label>Proyecto:</label>
                                        <select id="cmbProyectos" class="form-control selectpicker" data-live-search="true" required></select>
                                        <label>Comprobante:</label>
                                        <select id="cmbComprobante" class="form-control" required>
                                            <option value="SIN COMPROBANTE">SIN COMPROBANTE</option>
                                            <option value="TICKET">TICKET</option>
                                            <option value="FACTURA">FACTURA</option>
                                            <option value="NOTA">NOTA</option>
                                            <option value="RECIBO DE EFECTIVO">RECIBO DE EFECTIVO</option>
                                            <option value="VIATICOS">VIATICOS</option>
                                            <option value="ORDEN DE COMPRA">ORDEN DE COMPRA</option>
                                            <option value="TRANSFERENCIA">TRANSFERENCIA</option>
                                            <option value="N/A">N/A</option>
                                            <option value="PENDIENTE">PENDIENTE</option>
                                        </select>
                                        <%--<label>Cargo:</label>
                                        <input type="number" class="form-control" id="txtCargo" required />--%>
                                        <label>Abono:</label>
                                        <input type="number" class="form-control" id="txtAbono" required />
                                    </div>
                                </section>
                            </div>
                            <div class="col-sm-6">
                                <section class="panel">
                                    <div class="panel-body">
                                        <label>Estatus:</label>
                                        <select id="cmbEstatus" class="form-control" required>
                                            <option value="0">PENDIENTE</option>
                                            <option value="1">COMPLETO</option>
                                        </select>
                                        <label>Categoria:</label>
                                        <select id="cmbCategoriaCC" class="form-control" required>
                                            <option value="MATERIAL">MATERIAL</option>
                                            <option value="MANOOBRA">MANO DE OBRA</option>
                                            <option value="EQUIPO">EQUIPO</option>
                                            <option value="N/A">N/A</option>
                                        </select>
                                        <label>Orden de compra</label>
                                        <select id="cmbOC" class="form-control selectpicker" tabindex="2" data-live-search="true">
                                            <option value="-1">-- SELECCION ORDEN COMPRA --</option>
                                            <option value="N/A">N/A</option>
                                            <option value="PENDIENTE">PENDIENTE</option>
                                        </select>
                                    </div>
                                </section>
                            </div>
                        </div>




                    </div>
                    <div class="form-group">
                        <div class="col-lg-offset-2 col-lg-10">
                            <i class="icon_documents_alt"></i>
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnAdjuntarArchivoCC">Adjuntar archivo</button>
                            <input type="hidden" id="dataarchivopdf" />
                            <input type="hidden" id="nombreaarchivopdf" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <input type="hidden" id="txtidCajaChicaEditar" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-primary" id="btnGuardarCajaChica" type="button">Crear</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelCajaChicaModal" tabindex="-1" role="dialog" aria-labelledby="DelCajaChicaModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelEliminarCajaChica">Eliminar CajaChica</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group" id="txtModalEliminarCajaChica">
                            <label id="idCajaChicaEliminar" hidden="hidden"></label>
                            <label id="idCajaChicaEliminarTexto"></label>
                        </div>
                        <div class="form-group" id="txtModalEliminarMensajeCajaChica">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-danger" id="btnEliminarCajaChica" type="button">Eliminar</button>
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
                    <h4 class="modal-title" id="LabeldvPDFAdministracion">Archivo</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <label id="txtidCajaChicaArchivo" hidden="hidden"></label>
                        
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

    <%--VER ARCHIVOS--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="GaleriaArchivosProyectosModal" tabindex="-1" role="dialog" aria-labelledby="GaleriaArchivosProyectosModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelGaleriaArchicosProyectos">Archivos de Caja Chica</h4>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/CajaChicaUSA.js" type="text/javascript"></script>
</asp:Content>
