<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="ProyectoGrafica.aspx.cs" Inherits="SisaDev.Proyecto.ProyectoGrafica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Detalles</li>
                        <li><i class="icon_building"></i>Proyectos  </li>
                    </ol>
                </div>
            </div>
            <!-- page start-->
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">


                        <div id="maina" class="col-md-7 col-sm-7 col-xs-12" style="height: 350px; width: 30%;"></div>
                        <div id="mainb" class="col-md-5 col-sm-5 col-xs-12" style="height: 350px; width: 30%;"></div>
                        <div id="mainc" class="col-md-5 col-sm-5 col-xs-12" style="height: 350px; width: 30%;">
                            <label style="color: blue; font-weight: bold;" id="lblProyectoTarea" runat="server"></label>
                            <label id="lblFolio" hidden="hidden" runat="server"></label>


                        </div>

                        <div class="col-md-8 col-sm-4 col-xs-12">
                            <div id="dvGraficaMaterial"></div>
                        </div>
                        <div class="col-md-4 col-sm-4 col-xs-12">
                            <div id="dvGraficaManoObra"></div>
                        </div>
                        <div class="col-md-4 col-sm-4 col-xs-12">
                            <div id="dvGraficaEquipo"></div>
                        </div>
                    </section>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <br />
                    <br />
                    <section class="panel">
                        <div class="form-group" id="MensajeProyectos"></div>
                        <header class="panel-heading">
                            Actividad reciente
                            <div class="btn-group" id="botones">
                                <input type="hidden" id="idProyectoDetalle" runat="server" />
                            </div>
                        </header>
                        <div class="profile-activity" id="ListaComentarios"></div>
                    </section>
                </div>
            </div>
            <!-- page end-->
        </section>
    </section>
    <%--HorasHombre--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AvanceProyectosModal" tabindex="-1" role="dialog" aria-labelledby="AvanceProyectosModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelAvanceProyectos">Avance Proyectos</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Selecciona porcentaje de avance (por criterio):</label>
                                <select id="cmbPorcentaje" class="form-control">
                                    <option value="10">10</option>
                                    <option value="20">20</option>
                                    <option value="30">30</option>
                                    <option value="40">40</option>
                                    <option value="50">50</option>
                                    <option value="60">60</option>
                                    <option value="70">70</option>
                                    <option value="80">80</option>
                                    <option value="90">90</option>
                                    <option value="100">100</option>
                                </select>
                            </div>
                            <label id="idProyectosAvance" hidden="hidden"></label>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-danger" id="btnAvanceProyectos" type="button">Avance</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <%--Detalles--%>
    <div id="dvDetalleGrafica" class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="width: 60%;">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" id="lblTituloDetalle">Modal Header</h4>
                </div>
                <div class="modal-body">
                    <div id="testmodalComentarios">
                        <table id="TablaPrincipalViaticos" class="table table-sm" data-sortable="false" data-show-refresh="true" data-show-toggle="true" data-show-columns="true" data-query-params="queryParams" data-pagination="true" data-show-export="true">
                            <thead>
                                <tr>
                                    <th data-field="FechaViaticos" data-sortable="true">Fecha</th>
                                    <th data-field="Gasolina" data-sortable="true">Gasolina</th>
                                    <th data-field="Desayuno" data-sortable="true">Desayuno</th>
                                    <th data-field="Comida" data-sortable="true">Comida</th>
                                    <th data-field="Cena" data-sortable="true">Cena</th>
                                    <th data-field="Casetas" data-sortable="true">Casetas</th>
                                    <th data-field="Hotel" data-sortable="true">Hotel</th>
                                    <th data-field="Transporte" data-sortable="true">Transporte</th>
                                    <th data-field="Otros" data-sortable="true">Otros</th>
                                    <th data-field="Otros" data-sortable="true">Mano de obra</th>
                                    <th data-field="Otros" data-sortable="true">Equipo</th>
                                    <th data-field="Otros" data-sortable="true">Material</th>
                                    <th data-field="Descripcion" data-sortable="true">Descripcion</th>
                                </tr>
                            </thead>
                            <tbody id="listaTablaPrincipalViaticos">
                            </tbody>
                        </table>

                        <table id="TablaPrincipalMatSinOC" class="table table-sm" data-sortable="false" data-show-refresh="true" data-show-toggle="true" data-show-columns="true" data-query-params="queryParams" data-pagination="true" data-show-export="true">
                            <thead>
                                <tr>
                                    <th data-field="FechaFactura" data-sortable="true">Fecha</th>
                                    <th data-field="NoFactura" data-sortable="true">No Factura</th>
                                    <th data-field="NombreComercial" data-sortable="true">Proveedor</th>
                                    <th data-field="OrdenCompra" data-sortable="true">Orden Compra</th>
                                    <th data-field="SubTotal" data-sortable="true">Sub-Total</th>
                                    <th data-field="IVA" data-sortable="true">IVA</th>
                                    <th data-field="Total" data-sortable="true">Total</th>
                                </tr>
                            </thead>
                            <tbody id="listaTablaPrincipalMatSinOC">
                            </tbody>
                        </table>

                        <table id="TablaPrincipalImprevistos" class="table table-sm" data-sortable="false" data-show-refresh="true" data-show-toggle="true" data-show-columns="true" data-query-params="queryParams" data-pagination="true" data-show-export="true">
                            <thead>
                                <tr>
                                    <th data-field="FechaGasto" data-sortable="true">Fecha</th>
                                    <th data-field="Responsable" data-sortable="true">Responsable</th>
                                    <th data-field="Concepto" data-sortable="true">Concepto</th>
                                    <th data-field="Comprobante" data-sortable="true">Comprobante</th>
                                    <th data-field="Total" data-sortable="true">Total</th>
                                </tr>
                            </thead>
                            <tbody id="listaTablaPrincipalImprevistos">
                            </tbody>
                        </table>

                        <table id="TablaPrincipalMatConOC" class="table table-sm" data-sortable="false" data-show-refresh="true" data-show-toggle="true" data-show-columns="true" data-query-params="queryParams" data-pagination="true" data-show-export="true">
                            <thead>
                                <tr>
                                    <th data-field="Folio" data-sortable="true">Folio</th>
                                    <th data-field="ReferenciaCot" data-sortable="true">Referencia</th>
                                    <th data-field="NombreComercial" data-sortable="true">Proveedor</th>
                                    <th data-field="SubTotal" data-sortable="true">Sub-Total</th>
                                    <th data-field="Iva" data-sortable="true">IVA</th>
                                    <th data-field="Total" data-sortable="true">Total</th>
                                    <th data-field="Fecha" data-sortable="true">Fecha</th>
                                </tr>
                            </thead>
                            <tbody id="listaTablaPrincipalMatConOC">
                            </tbody>
                        </table>

                        <table id="TablaPrincipalManoObra" class="table table-sm" data-sortable="false" data-show-refresh="true" data-show-toggle="true" data-show-columns="true" data-query-params="queryParams" data-pagination="true" data-show-export="true">
                            <thead>
                                <tr>
                                    <th data-field="Tipo" data-sortable="true">Tipo</th>
                                    <th data-field="Folio" data-sortable="true"># OC</th>
                                    <th data-field="NombreCompleto" data-sortable="true">Usuarios</th>
                                    <%--<th data-field="Lunes" data-editable="true">Lunes</th>
                                    <th data-field="Martes" data-editable="true">Martes</th>
                                    <th data-field="Miercoles" data-editable="true">Miercoles</th>
                                    <th data-field="Jueves" data-editable="true">Jueves</th>
                                    <th data-field="Viernes" data-editable="true">Viernes</th>
                                    <th data-field="Sabado" data-editable="true">Sabado</th>
                                    <th data-field="Domingo" data-editable="true">Domingo</th>--%>
                                    <th data-field="Total">Total</th>
                                </tr>
                            </thead>
                            <tbody id="listaTablaPrincipalManoObra">
                            </tbody>
                        </table>

                        <table id="TablaPrincipalMatConOCPend" class="table table-sm" data-sortable="false" data-show-refresh="true" data-show-toggle="true" data-show-columns="true" data-query-params="queryParams" data-pagination="true" data-show-export="true">
                            <thead>
                                <tr>
                                    <th data-field="Folio" data-sortable="true">Folio</th>
                                    <th data-field="ReferenciaCot" data-sortable="true">Referencia</th>
                                    <th data-field="NombreComercial" data-sortable="true">Proveedor</th>
                                    <th data-field="SubTotal" data-sortable="true">Sub-Total</th>
                                    <th data-field="Iva" data-sortable="true">IVA</th>
                                    <th data-field="Total" data-sortable="true">Total</th>
                                    <th data-field="Fecha" data-sortable="true">Fecha</th>
                                </tr>
                            </thead>
                            <tbody id="listaTablaPrincipalMatConOCPend">
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/ProyectoGrafica.js" type="text/javascript"></script>
</asp:Content>
