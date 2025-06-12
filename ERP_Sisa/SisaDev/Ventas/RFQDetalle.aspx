<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RFQDetalle.aspx.cs" Inherits="SisaDev.Ventas.RFQDetalle" MasterPageFile="~/Sitio.Master" %>


<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
     <%--<div id="loading-img">  <img src="../img/logoloading.png" /></div>--%>
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
          <div class="col-lg-12">
            
            <ol class="breadcrumb">
              <li><i class="icon_folder-open"></i>RFQ</li>
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
                                <div class="row">
                                    <div class="col-xs-12 invoice-header">
                                        <h1>
                                            <small class="pull-right" style="font-weight: bold;"># RFQ:
                                                <asp:Label ID="lblRFQFolio" runat="server"></asp:Label>
                                            </small>
                                        </h1>
                                    </div>
                                    <!-- /.col -->
                                </div>

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
                                    <div class="col-sm-10">
                                         <label>Dias</label>
                                        <input type="text" class="form-control" id="txtDiasResta" placeholder="Dias" readonly/>
                                    </div>
                                    <div class="col-sm-10">
                                         <label>Estatus</label>
                                        <input type="text" class="form-control" id="txtEstatus" readonly/>
                                    </div>
                                     <div class="col-sm-10">
                                        <label>Descripción</label>
                                        <input type="text" class="form-control" id="txtDescripcion" placeholder="Descripción" />
                                    </div>
                                    <div class="col-sm-10">
                                        <label>Fecha compromiso</label>
                                        <input class="form-control" type="date" id="dtCaduca">
                                    </div>
                                    <div class="col-sm-10">
                                        <label>Empresa-Contacto</label>
                                        <select id="slctEmpresa" class="form-control selectpicker" data-live-search="true"></select>
                                    </div>
                                    <div class="col-sm-10">
                                        <label>Vendedor</label>
                                        <select id="slctVendedor" class="form-control selectpicker" data-live-search="true"></select>
                                    </div>
                                    <div class="col-sm-10">
                                        <label>Coordinador</label>
                                        <select id="slctCoordinador" class="form-control selectpicker" data-live-search="true"></select>
                                    </div>
                                    <div class="col-sm-10">
                                        <label>Seguimiento</label>
                                        <input type="text" class="form-control" id="txtSeguimiento" placeholder="Seguimiento" />
                                    </div>
                                </div>

                                <div class="row">


                                    <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback">
                                        <label>Comentarios:</label>
                                        <input type="text" class="form-control has-feedback-left agrega UpperCase" style="padding-right: 0px;" id="txtComentariosRFQ" placeholder="Comentarios">
                                    </div>



                                    <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback pull-right" style="width: 10%;">
                                        <label>
                                        </label>
                                        <button class="btn btn-info btn-dark" id="btnAgregarRFQ"><i class="fa fa-plus fa-fw"></i>Agregar</button>
                                    </div>
                                </div>

                                <!-- Table row -->
                                <div class="row">
                                    <div class="col-xs-12 table">
                                        <table class="table table-striped" id="tblItemsRFQ">
                                            <thead>
                                                <tr>

                                                    <th style="width: 29%;">COMENTARIOS</th>

                                                    <th></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                    </div>
                                    <!-- /.col -->
                                </div>

                                <!-- this row will not appear when printing -->
                                <div class="row no-print">
                                    <div class="col-xs-12">
                                        <%--<button class="btn btn-default" onclick="window.print();"><i class="fa fa-print"></i>Print</button>--%>
                                        <button class="btn btn-success pull-right" id="btnGuardarRFQ"><i class="fas fa-save"></i>Guardar</button>
                                        <button class="btn btn-success pull-right" id="btnModificarRFQ"><i class="fas fa-save"></i>Guardar</button>
                                        <button class="btn btn-primary pull-right" id="btnPDFRFQ" style="margin-right: 5px;"><i class="fa fa-download"></i>Generate PDF</button>
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
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/RFQDetalle.js" type="text/javascript"></script>
</asp:Content>







