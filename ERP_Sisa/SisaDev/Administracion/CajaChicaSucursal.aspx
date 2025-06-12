<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="CajaChicaSucursal.aspx.cs" Inherits="SisaDev.Administracion.CajaChicaSucursal" %>
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
                        </div>
                        <header class="panel-heading">
                            Lista de CajaChica 
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                              <%--<a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddCajaChicaModal" id="btnAgregarCajaChica"><i class="icon_plus_alt2"></i>Agregar </a>--%>
                          </div>
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

                                                <th data-field="SUCURSAL" data-sortable="true"><i class="icon_box-empty"></i>Sucursal</th>

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
                                    <header class="panel-heading">
                                        Agregar registro de gastos
                                    </header>
                                    <div class="panel-body">
                                        <%--<form role="form">--%>
                                        <div class="form-group">
                                            <label>Proyecto.</label>
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbProyectos" required></select>
                                            <label>Concepto</label>
                                            <input class="form-control" type="text" id="txtDescripcion" placeholder="Descripción" required />
                                            <label>Cantidad gastada</label>
                                            <input class="form-control" type="number" id="txtCantidad" placeholder="Precio" required />
                                            <label>Tipo de gasto</label>
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbGasto" required>
                                                <option value="-1" selected>--SELECCIONE TIPO --</option>
                                                <option value="Gasolina">Gasolina</option>
                                                <option value="Desayuno">Desayuno</option>
                                                <option value="Comida">Comida</option>
                                                <option value="Cena">Cena</option>
                                                <option value="Casetas">Casetas</option>
                                                <option value="Hotel">Hotel</option>
                                                <option value="Transporte">Transporte</option>
                                                <option value="Otros">Otros</option>
                                                <option value="Material">Material</option>
                                                <option value="ManoObra">Mano de Obra</option>
                                                <option value="Equipo">Equipo</option>
                                            </select>
                                            <label>Fecha Gasto</label>
                                            <input type="date" class="form-control" id="dtFechaGasto">
                                            <label>Ticket</label>
                                            <%-- <input type="file" id="Ticket"  required>--%>
                                            <form runat="server">
                                                <asp:FileUpload CssClass="form-control" ID="Ticket" runat="server" onchange="ShowImagePreview(this);" accept="image/png, image/jpeg, application/pdf" />
                                                <asp:Image ID="ImgPrv" Height="50px" Width="50px" ClientIDMode="Static" runat="server" /><br />
                                            </form>

                                            <p class="help-block"></p>
                                            <span class="btn btn-primary" id="btnAgregarGastos">Agregar</span>
                                            <%--<button type="submit" id="btnAgregarGastos" class="btn btn-primary">Agregar</button>--%>
                                        </div>
                                        
                                    </div>


                                </section>
                            </div>
                            <div class="col-sm-6">
                                <section class="panel">
                                    <header class="panel-heading">
                                        Totales
                                    </header>
                                    <table class="table">
                                        <tbody>
                                            <tr>
                                                <th style="width: 50%">Cantidad Entregada:</th>
                                                <td>
                                                    <span id="lblCantEntregada"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>Cantidad Gastada</th>
                                                <td><span id="lblCantGastada"></span></td>
                                            </tr>
                                            <tr>
                                                <th>Diferencia:</th>
                                                <td><span id="lblDiferencia"></span></td>
                                            </tr>
                                            <tr>
                                                <th>Persona que recibio:</th>
                                                <td><span id="lblResponsable"></span></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </section>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-lg-12 table">

                                <table class="table table-striped" id="tblViaticos">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Fecha</th>
                                            <th>Proyecto</th>
                                            <th>Concepto</th>
                                            <th>Gasto</th>
                                            <th>TipoGasto</th>
                                            <th>Acciones</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <th></th>
                                            <th></th>
                                            <th colspan="2">Totales</th>
                                            <th><span id="lblGastos">$     0.00</span></th>
                                            <th></th>
                                            <th></th>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                            <!-- /.col -->
                        </div>
                    </div>
                    <div class="modal-footer">
                        <input type="hidden" id="txtidCajaChicaEditar" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <%--<button class="btn btn-primary" id="btnGuardarCajaChica" type="button">Crear</button>--%>
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

    <%--Ticket--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvPDFTicket" tabindex="-1" role="dialog" aria-labelledby="dvPDFTicket" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabeldvPDFTicket">Visualizar ticket</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal">
                    <div class="modal-body">
                        <label id="txtidArchivoTicket" hidden="hidden"></label>
                        <label id="txtTipoDocumentoTicket" hidden="hidden"></label>
                        <div id="testmodalpdfTicket" style="padding: 5px 20px;">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button type="button" class="btn btn-danger" id="btnEliminadDocumentoTicket" data-dismiss="modal">Eliminar</button>
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
    <script src="<%= ResolveUrl("~") %>js/CajaChicaSucursal.js" type="text/javascript"></script>
</asp:Content>
