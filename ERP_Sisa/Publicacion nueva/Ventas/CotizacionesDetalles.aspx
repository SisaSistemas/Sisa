<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CotizacionesDetalles.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Ventas.CotizacionesDetalles" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <script>
        function CargarComboUsuarios() {
            var params = "{'Opcion': '1'}";

            $.ajax({
                dataType: 'json',
                async: true,
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                url: 'Cotizaciones.aspx/CargarCombos',
                data: params,
                success: function (data, textStatus) {

                    var json = $.parseJSON(data.d);

                    $('#cmbUsuarioLider').html('');
                    $('#cmbUsuarioLider').html("<option value=-1>-- Selecciona lider de proyecto --</option>");
                    $.each(json, function (index, value) {
                        $("#cmbUsuarioLider").append("<option value=" + value.Id + ">" + value.Nombre.toUpperCase() + "</option>");
                    });
                }
            });
            var params2 = "{'pid': '" + document.getElementById('idCotiza').textContent + "'}";

            $.ajax({
                dataType: 'json',
                async: true,
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                url: 'Cotizaciones.aspx/ObtenerCotizaciones',
                data: params2,
                success: function (data, textStatus) {

                    var json = $.parseJSON(data.d);
                    $.each(json, function (index, value) {
                        document.getElementById('txtConceptoProyecto').textContent = value.Concepto;
                    });
                }
            });

        }

</script>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
     <%--<div id="loading-img">  <img src="../img/logoloading.png" /></div>--%>
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Cotizaciones</li>
                        <li><i class="icon_building"></i>Crear/Modificar</li>
                    </ol>
                </div>
            </div>
            <form runat="server"><asp:HiddenField runat="server" ID="idUsuarioLog" /></form>
            <!-- page start-->
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        
                        <div class="form-group" id="MensajeCotizacionDetalle">
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <label><strong>Empresa:</strong></label>
                                <strong>
                                    <select id="cmbEmpresas" class="form-control selectpicker" data-live-search="true"></select>
                                    <input id="idEmpresa" type="hidden" runat="server" />
                                </strong>
                                <label><strong>Contacto:</strong></label>
                                <select id="cmbContactos" class="form-control selectpicker" data-live-search="true"></select>
                                <input id="idContacto" type="hidden" runat="server" />
                                <input id="idCotiza" type="hidden" runat="server" />
                                <input id="idSolicitud" type="hidden" runat="server" />
                                <input id="idBiddingInput" type="hidden" runat="server" />
                                <label><strong>Creado por:</strong></label>
                                <select id="cmbUsuariosCotizacion" class="col-sm-12 form-control form-control-sm selectpicker" data-live-search="true"></select>

                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <label><strong># Solicitud Cotizacion:</strong></label>
                                        <input type="text" class="col-md-6 form-control form-control-sm UpperCase" placeholder="Solicitud Cotizacion (Folio)" id="txtReferenciarReqCot" />
                                    </div>
                                    <div class="col-md-6">
                                        <label><strong># Solicitud Bidding:</strong></label>
                                        <input type="text" class="col-md-6 form-control form-control-sm UpperCase" placeholder="Bidding (Folio)" id="txtReferenciaBidding" />
                                    </div>
                                    
                                    <br />
                                </div>
                                
                                <br />
                                <label><strong>Concepto:</strong></label>
                                <textarea cols="5" style="width: 100%;" class="col-sm-12 form-control form-control-sm UpperCase" placeholder="Concepto" id="txtDescripcionCotizaCompleta"></textarea>
                            </div>
                            <div class="col-sm-4">                                
                                <label><strong>Mano de obra:</strong></label>
                                <input type="number" class="form-control" id="txtMOCotizado" value="0"/>                           
                                <label><strong>Costo de material:</strong></label>
                                <input type="number" class="form-control" id="txtCostoMaterialCotizados" value="0"/>
                                <label><strong>Costo de equipo:</strong></label>
                                <input type="number" class="form-control" id="txtCECotizados" value="0"/>
                            </div>
                        </div>
                        <!-- /.row -->

                        <div class="row">
                            <div class="col-md-1 col-sm-1 col-xs-12 form-group has-feedback" style="width: 20%;">
                                <label><strong>Descripcion:</strong></label>
                                <input type="text" class="form-control agrega money" style="padding-right: 0px;" id="txtDescripcionCotiza" placeholder="Descripción">
                            </div>
                            <div class="col-md-1 col-sm-1 col-xs-12 form-group has-feedback" style="width: 20%;">
                                <label><strong>Cantidad:</strong></label>
                                <input type="number" class="form-control agrega money" style="padding-right: 0px;" id="txtCantidadCotiza" placeholder="Cantidad de Piezas">
                            </div>

                            <div class="col-md-1 col-sm-1 col-xs-12 form-group has-feedback" style="width: 20%;">
                                <label><strong>Precio:</strong></label>
                                <input type="text" class="form-control agrega money" style="padding-right: 0px;" id="txtPrecioCotiza" placeholder="Precio">
                            </div>
                            <div class="col-md-1 col-sm-1 col-xs-12 form-group has-feedback" style="width: 20%;">
                                <label><strong>Unidad:</strong></label>
                                <input type="text" class="form-control agrega money" style="padding-right: 0px;" id="txtUnidadCotiza" placeholder="Unidad">
                            </div>

                            <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback pull-right" style="width: 20%;">
                                <label>
                                </label>
                                <button class="btn btn-info btn-dark" id="btnAgregarItemCotizacion"><i class="fa fa-plus fa-fw"></i>Agregar</button>
                            </div>
                        </div>

                        <!-- Table row -->
                        <div class="row">
                            <div class="col-xs-12 table">
                                <table class="table table-striped" id="tblItemsCotizacion">
                                    <thead>
                                        <tr>
                                            <th style="display:none;">id</th>
                                            <th>ITEM</th>
                                            <th style="width: 29%;">DESCRIPCION</th>
                                            <th>CANT</th>
                                            <th>UNIDAD</th>
                                            <th>PRECIO</th>
                                            <th>IMPORTE</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                </table>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                        <div class="row">
                            <!-- accepted payments column -->
                            <div class="col-xs-6">
                                <div class="row">
                            
                            <div class="col-md-1 col-sm-1 col-xs-12 form-group has-feedback" style="width: 60%;">
                                
                                <label><strong>Notas aclaratorias:</strong></label>
                                <input type="text" class="form-control" id="txtNotas" placeholder="Notas">
                            </div>

                            <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback pull-right" style="width: 40%;">
                              <button class="btn btn-info btn-dark" id="btnAgregarNotasCotizacion"><i class="fa fa-plus fa-fw"></i>Agregar nota</button>

                            </div>
                        </div>

                                <table class="table table-striped" id="tblNotasCotizacion">
                                    <thead>
                                        <tr>
                                            
                                            <th style="width: 29%;">Notas</th>
                                            
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                </table>

                            </div>
                            <!-- /.col -->
                            <div class="col-xs-6">
                                <p class="lead">&nbsp;</p>
                                <div class="table-responsive">
                                    <table class="table">
                                        <tbody>
                                            <tr>
                                                <th style="width: 50%">Subtotal:</th>
                                                <td><span id="lblSubTotal">$0.00</span></td>
                                            </tr>
                                            <tr>
                                                <th>Saving (<input type="text" id="txtSaving" style="width: 30px;" value="0" /> %):</th>
                                                <td><span id="lblSaving">$0.00</span>
                                                    <%--<div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                                        <input type="text" class="form-control money" style="padding-right: 0px;" id="txtDescuento" placeholder="0.00" />
                                                        
                                                    </div>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>IVA (<input type="text" id="txtIVA" style="width: 30px;" value="16" /> %)</th>
                                                <td><span id="lblIVA">$0.00</span></td>
                                            </tr>
                                            <tr>
                                                <th>Total:</th>
                                                <td><span id="lblTotal">$0.00</span><label hidden="hidden" id="idTodal"></label></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <!-- /.col -->
                        </div>

                        <!-- /.row -->

                        <!-- this row will not appear when printing -->
                        <div class="row no-print">
                            <div class="col-xs-12">
                                <%--<button class="btn btn-default" onclick="window.print();"><i class="icon_printer"></i>Print</button>--%>
                                <button class="btn btn-success pull-right" id="btnGuardarCotizacion"><i class="icon_floppy"></i>Guardar</button>
                                <button class="btn btn-success pull-right" id="btnModificarCotizacion"><i class="icon_floppy"></i>Guardar</button>
                                <button class="btn btn-primary pull-right" id="btnPDFCotizacion" style="margin-right: 5px;"><i class="icon_document_alt"></i>Generate PDF</button>                                
                            </div>
                        </div>
                    </section>
                </div>
            </div>
            <!-- page end-->
        </section>
    </section>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/CotizacionesDetalles.js" type="text/javascript"></script>
</asp:Content>




