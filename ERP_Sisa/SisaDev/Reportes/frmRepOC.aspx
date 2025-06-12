<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="frmRepOC.aspx.cs" Inherits="SisaDev.Reportes.frmRepOC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">

        <section class="wrapper">

            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Reportes</li>
                        <li><i class="icon_building"></i>Orden de Compra</li>
                    </ol>
                </div>
            </div>
            <!-- page start-->

            
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">

                       
                        <header class="panel-heading">
                            Parametros <br />
                            <label id="TipoFactura" style="font-weight: bold; font-size: large;"></label>
                            <div class="btn-group" id="botones">

                                <form class="form-inline">
                                    
                                    <div class="form-group">
                                        <div id="busquedarecibidos">
                                            Fecha Inicio
                                            <input type="date" class="form-control" id="dtFechaInicio" tabindex="4" required />
                                            Fecha Fin
                                            <input type="date" class="form-control" id="dtFechaFin" tabindex="5" required />
                                            <%--Proveedor
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
                                            <select class="form-control selectpicker" data-live-search="true" id="cmbOCRecibidaBuscar"></select>--%>
                                            <button class="btn btn-danger" id="btnBuscarRecibidas" type="button">Buscar.</button>
                                        </div>
                                    </div>

                                </form>
                            </div>

                        </header>
                        
                        
                    </section>
                </div>
            </div>
            <!-- page end-->
        </section>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/frmRepOC.js" type="text/javascript"></script>
</asp:Content>
