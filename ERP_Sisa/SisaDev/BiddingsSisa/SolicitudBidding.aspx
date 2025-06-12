<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="SolicitudBidding.aspx.cs" Inherits="SisaDev.BiddingsSisa.SolicitudBidding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Solicitar Bidding</li>
                        <li><i class="icon_building"></i>Crear/Modificar</li>
                    </ol>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="x_panel">
                        <%--<div class="x_title">
                    <div class="clearfix"></div>
                </div>--%>

                        <div class="x_content">
                            <section class="content invoice">

                                <!-- info row -->
                                <div class="row invoice-info">
                                    <div class="col-sm-4 invoice-col">
                                        <input type="hidden" id="txtIdRFQ" runat="server" />
                                        <div class="form-group">
                                            <div class="col-sm-10">
                                                <div class="form-group" id="AddMsgRFQ">
                                                    <%--<label id="txtMensajeDatos"></label>--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.row -->
                                <div class="row">
                                    <%--<div class="col-sm-4">
                                         <label>Fecha:</label>
                                        <input type="date" class="form-control" id="dtFecha" placeholder="Fecha" />
                                    </div>
                                    --%>
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="x_panel">
                                                <div class="x_content">
                                                    <div class="col-sm-4">
                                                        <label><b>PLANTA:</b></label>
                                                        <select id="slctPlanta" class="form-control selectpicker" data-live-search="true">
                                                            <option value="0">-- SELECCIONE PLANTA --</option>
                                                            <option value="HSAP">FORD HSAP</option>
                                                            <option value="CHEP">FORD CHIHUAHUA</option>
                                                            <option value="CSAP">FORD CUAUTITLAN</option>
                                                            <option value="ITP">FORD IRAPUATO</option>
                                                        </select>
                                                    </div>
                                                    <div class="col-sm-5">
                                                            <div>
                                                                <label>Area:</label>
                                                                <select id="slctAreas" class="form-control selectpicker" data-live-search="true"></select>
                                                            </div>
                                                        </div>
                                                </div>
                                            </div>
                                        </div>
                                        
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="x_panel">
                                                <div class="x_content">
                                                    <div class="col-sm-10">
                                                        <label><b>Información:</b></label>
                                                        <textarea class="form-control" id="txtResumen" rows="5" cols="50" ></textarea>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        
                                    </div>

                                    

                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="x_panel">
                                                <div class="x_content">
                                                    <div class="col-sm-12">
                                                        <label><b>Fecha Limite:</b></label>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <div class="col-sm-3">
                                                            <label>Fecha</label>
                                                            <input type="date" class="form-control" id="dtFechaLimite" />
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <div class="x_panel">
                                            <div class="x_content">
                                                <div class="col-sm-10">
                                                    <table id="TablaProveedores" class="table table-striped table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                                        <thead>
                                                            <tr>
                                                                <th data-align="center" data-formatter="accionCotHSAPFormatter" data-events="accionCotEvents"><i class="icon_ol"></i></th>
                                                                <th data-field="RFC" data-sortable="true"><i class="icon_ribbon_alt"></i>RFC</th>
                                                                <th data-field="NombreComercial" data-sortable="true"><i class="icon_ribbon_alt"></i>Proveedor</th>
                                                                <th data-field="Contacto" data-sortable="true"><i class="icon_archive_alt"></i>Contacto</th>
                                                            </tr>
                                                        </thead>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <br />

                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <div class="x_panel">
                                            <div class="x_content">
                                                <div class="col-sm-10">
                                                    <table id="TablaProveedoresPermitidos" class="table table-striped table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                                        <thead>
                                                            <tr>
                                                                <th data-align="center" data-formatter="accionSolFormatter" data-events="accionSolEvents"><i class="icon_ol"></i></th>
                                                                <th data-field="RFC" data-sortable="true"><i class="icon_ribbon_alt"></i>RFC</th>
                                                                <th data-field="NombreComercial" data-sortable="true"><i class="icon_ribbon_alt"></i>Proveedor</th>
                                                                <th data-field="Contacto" data-sortable="true"><i class="icon_archive_alt"></i>Contacto</th>
                                                            </tr>
                                                        </thead>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <br />

                                <!-- this row will not appear when printing -->
                                <div class="row no-print">
                                    <div class="col-xs-10">
                                        <%--<button class="btn btn-default" onclick="window.print();"><i class="fa fa-print"></i>Print</button>--%>
                                        <button class="btn btn-success pull-right btn-lg" id="btnGuardarSolicitud" type="submit"> <i class="fas fa-save"></i>Guardar</button>
                                        <%--<button class="btn btn-success pull-right" id="btnModificarCotizacion"><i class="fas fa-save"></i>Guardar</button>--%>
                                        <%--<button class="btn btn-primary pull-right" id="btnPDFRFQ" style="margin-right: 5px;"><i class="fa fa-download"></i>Generate PDF</button>--%>
                                    </div>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/SolicitudBidding.js" type="text/javascript"></script>
</asp:Content>
