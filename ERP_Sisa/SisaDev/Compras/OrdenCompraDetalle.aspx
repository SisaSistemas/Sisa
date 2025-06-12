<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdenCompraDetalle.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Compras.OrdenCompraDetalle" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <style>
        .row-selected {
            background-color: orange;
        }

        #verde{
            background-color: #00ff21;
        }

        .estatusCancelada {
            background-color: #ffa084;
            color: white;
        }

        .estatus {
            background-color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div id="loading-img">  <img src="../img/logoloading.png" /></div>--%>
    <section id="main-content">
      <section class="wrapper">
    <div class="row">
        <div class="col-md-12">
            <div class="x_panel">
                <%--<div class="x_title">
                    <div class="clearfix"></div>
                </div>--%>
                <form runat="server">
                    <asp:HiddenField runat="server" ID="idUsuarioLog" Value="x" />
                    <asp:HiddenField runat="server" ID="idSucursalLog" Value="x" />
                </form>
                
                <div class="x_content">
                    <section class="content invoice">
                        <!-- title row -->
                        <div class="row">
                            <div class="col-xs-12 invoice-header">
                                <h1>
                                    <img src="../img/OrdenCompraImage.jpeg" style="width:40%;" />
                                    <small class="pull-right" style="font-weight: bold;"># ORDEN DE COMPRA: <span id="lblNoOrdenCompra"></span></small>
                                </h1>
                            </div>
                            <!-- /.col -->
                        </div>                        

                        <!-- info row -->
                        <div class="row invoice-info">
                            <div class="col-sm-4 invoice-col">
                                Para:
                                <address>
                                    <strong>
                                        <select id="cmbProveedores" class="col-sm-12 form-control form-control-sm selectpicker" data-live-search="true"></select>
                                    </strong>
                                    <%--<br><span id="lblAtencion"></span>
                                    <br><span id="lblDireccion"></span><%--CARRETERA INTTER. A NOGALES K.M 7.5 NO.805
                                    <br><span id="lblCorreo"></span><%--pabloo@coastaluminum.com
                                    <br><span id="lblTelefono"></span><%--(662) 285-0702--%>
                                    <input type="hidden" id="idOC" runat="server"/>
                                   
                                    <label>Requisición:</label>
                                    <br><input type="text" class="col-sm-12 form-control form-control-sm UpperCase" placeholder="REFERENCIA REQUISICION (FOLIO)" id="txtReferenciarReq" onkeyup="mayus(this);" /><%--VIA TELEFONICA--%>
                                    <label>Cotización:</label>
                                    <br><input type="text" class="col-sm-12 form-control form-control-sm UpperCase" placeholder="REFERENCIA COTIZACION" id="txtReferenciaCot" onkeyup="mayus(this);" /><%--VIA TELEFONICA--%>
                                   
                                    <label>Pedido por:</label>
                                    <br><select id="cmbUsuarios" class="col-sm-12 form-control form-control-sm selectpicker" data-live-search="true"></select>
                                    <label>Aprobado por:</label>
                                    <br><select id="cmbUsuariosAprobo" class="col-sm-12 form-control form-control-sm selectpicker" data-live-search="true"></select>
                                     <label>Proyecto:</label>                                    
                                    <br><select id="cmbProyectos" class="col-sm-12 form-control selectpicker" data-live-search="true"></select>
                                    <label>Tipo OC:</label>
                                    <br><select id="cmbTipoOC" class="col-sm-12 form-control form-control-sm">                                            
                                            <option value="Material">Material</option>
                                            <option value="Equipo">Equipo</option>
                                            <option value="ManoObra">Mano de Obra</option>
                                        </select>
                                    <label id="lblSucursal">Sucursal:</label>
                                    <br /><select id="cmbSucursal" class="col-sm-12 form-control form-control-sm">
                                          </select>
                                    <label>Criterio:</label>
                                    <br><select id="cmbCriterioOC" class="col-sm-12 form-control form-control-sm">
                                        </select>
                                </address>
                            </div>
                            <!-- /.col -->
                            <div class="col-sm-4 invoice-col">
                                Enviar A:
                                <address>
                                    <strong>SISA&AUT S.A. DE C.V</strong>
                                    <% 
                                        if (usuario.idSucursal.ToString().ToUpper() == "E8FB7D08-3E75-4DD4-9D6F-18A31886B638")
                                        {

                                        %>
                                    <br>CAROLINA GARCIA
                                    <br>cgarcia@sistemasautomatizados.net
                                    <br>TELEFONO:  662 282 1011 
                                    <br>TELEFONO 2: 8441974250
                                    <br>AVENIDA PIRULES, NÚMERO 24, COLONIA SAN ISIDRO, 
                                    <br>MUNICIPIO CUAUTITLAN IZCALLI, ESTADO DE MÉXICO, 
                                    <br>C.P. 54730 
                                    <br>

                                     <% 
                                        }else if (usuario.idSucursal.ToString().ToUpper() == "1479126E-06FA-4F4B-BA36-380CF73A6912")
                                        {



%>
                                    <br> YOLANDA CALDERON
                                <br>YCALDERON@SISAAUT.COM
                                <br>TELEFONO:  662 377 3007
                                <br>TELEFONO 2: 442 711 7375
                                <br>SANTA MARIA MAGDALENA PARCELA 2 
                                <br>MICROPARQUE INDUSTRUAL TLACOTE 2 NAVE 2 SISA&AUT.    
                                <br>CARRETERA TLACOTE EL BAJO A UN LADO DE AGROGEN Y SUBESTACION DE CFE
                                <br>SANTIAGO QUERETARO, QUERETARO C.P. 76024
                                    <br>

                                     <%
            }
            else if (usuario.idSucursal.ToString().ToUpper() == "F8E5400A-E1B5-4100-A990-E73E9DA59370"){ 
                                       %>
                                    <br>CRISTAL ZAZUETA
                                    <br>czazueta@sistemasautomatizados.net
                                    <br>(662) 3-173318
                                    <br>TANAMA 1262
                                    <br>COL. COLINAS CUCHUMA
                                    <br>TECATE, BAJA CALIFORNIA.
                                    <br>
                                     <%
            }
                                         else if (usuario.idSucursal.ToString().ToUpper() == "4327A1A3-B1F1-438A-9C89-081B2FB69D08"){ 
                                       %>
                                    <br>SILVIA CARAVEO
                                    <br>scaraveo@sistemasautomatizados.net
                                    <br>(662) 3-173318
                                    <br>AVENIDA DE LOS OLIVOS Y AVENIDA DE LOS SERIS #97 
                                    <br>COL. PARQUE INDUSTRIAL C.P. 83299
                                    <br>HILLO, SON.
                                    <br>
                                     <%
            }
                                         else { 
                                       %>
                                    <br>ANGELICA ROMERO
                                    <br>aromero@sistemasautomatizados.net
                                    <br>(662) 2-050986
                                    <br>AVENIDA DE LOS OLIVOS Y AVENIDA DE LOS SERIS #97 
                                    <br>COL. PARQUE INDUSTRIAL C.P. 83299
                                    <br>HILLO, SON.
                                    <br>
                                     <%
            }
                                        %>
                                </address>
                            </div>
                            <!-- /.col -->
                            <div class="col-sm-4 invoice-col">
                                Datos Facturación:
                                <address>
                                    <strong>SISA&AUT S.A. DE C.V</strong>
                                    <br>SIS1610182X4
                                    <br>AVENIDA DE LOS OLIVOS Y AVENIDA DE LOS SERIS #97 COL. PARQUE INDUSTRIAL C.P. 83299
                                    <br>HILLO, SON.
                                    <br>facturacion@sisaaut.com
                                    <br>TRANSFERENCIA BANCARIA
                                    <br>ULTIMOS 4 DIGITOS DE LA CUENTA 8920. BANCO SANTANDER PESOS
                                    <br>ULTIMOS 4 DIGITOS DE LA CUENTA 3107. BANCO SANTANDER DLLS
                                    <br>USO CFDI: P01-POR DEFINIR
                                </address>
                            </div>
                            <%--<div class="col-sm-4 invoice-col">
                                <b>FACTURA: #007612</b>
                                <br>
                                <br>
                                <b>ATENCION:</b> aromero@sisaaut.com
                                <br><b>CEL:</b> (662) 205-0986
                                <br>
                                <br>
                                <b>FECHA ORDEN:</b> 01/06/2018
                            </div>--%>
                            <!-- /.col -->
                            <div class="col-sm-4 invoice-col">
                                <button class="btn btn-success" id="btnRecibirGlobalOC"><i class="icon_check"></i>Productos recibidos.</button>
                            </div>
                            
                        </div>
                        <!-- /.row -->

                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                    <label>Material:</label>
                                <select id="cmbMateriales" class="select2_single form-control form-control-smselectpicker" data-live-search="true"></select>
                            </div>

                            <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback">
                                <label>Comentarios:</label>
                                <input type="text" class="form-control has-feedback-left agrega UpperCase" style="padding-right:0px;" id="txtComentarios" onkeyup="mayus(this);" placeholder="Comentarios">
                                
                            </div>

                            <div class="col-md-1 col-sm-1 col-xs-12 form-group has-feedback">
                                <label>Cantidad:</label>
                                <input type="text" class="form-control has-feedback-left agrega money" style="padding-right:0px;" id="txtCantidad" placeholder="Cantidad de Piezas">
                                
                            </div>

                            <div class="col-md-1 col-sm-1 col-xs-12 form-group has-feedback">
                                <label>Precio:</label>
                                <input type="text" class="form-control has-feedback-left agrega money" style="padding-right:0px;" id="txtPrecio" placeholder="Precio">
                                
                            </div>

                            <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback">
                                <label>Tiempo entrega:</label>
                                <input type="text" class="form-control has-feedback-left agrega money" style="padding-right:0px;" id="txtTiempoEntrega" onkeyup="mayus(this);" placeholder="Tiempo Entrega">
                               
                            </div>
                            <%
                                if (rolesUsuarios.Tipo != "Recepcion almacen")
                                {
                                    %>
                                     <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback pull-right" style="width:10%;">
                                            <label>
                                            </label>
                                            <button class="btn btn-info btn-dark" id="btnAgregar"><i class="fa fa-plus fa-fw"></i>Agregar</button>
                                
                                        </div>
                                    <%
                                }
                            %>
                           
                            
                        </div>

                        <!-- Table row -->
                        <div class="row">
                            <div class="col-xs-12 table">
                                <table class="table table-striped" id="tblItems">
                                    <thead>
                                        <tr>
                                            <th>ITEM</th>
                                            <th>CODIGO</th>
                                            <th style="width: 29%;">DESCRIPCION</th>
                                            <th style="width: 20%;">COMENTARIOS</th>
                                            <th>CANT</th>
                                            <th>UNIDAD</th>
                                            <th>PRECIO</th>
                                            <th>IMPORTE</th>
                                            <th>TIEMPO ENTREGA</th>
                                            <th>CANT RECIBIDA</th>
                                            <th>FECHA RECIBIDA</th>
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
                                <p class="lead">NOTAS ACLARATORIAS:</p>
                                <div class="table-responsive">
                                    <table class="table">
                                        <tbody>
                                            <tr>
                                                <th>1.-</th>
                                                <td>ORDEN DE COMPRA EXPRESADA EN <select id="cmbMoneda" class="form-control"></select> CON IVA INCLUIDO. </td>
                                            </tr>
                                            <tr>
                                                <th>2.-</th>
                                                <td>TIEMPO DE ENTREGA VIENE INDICADO EN CADA ITEM.</td>
                                            </tr>
                                            <tr>
                                                <th>3.-</th>
                                                <td>CONDICIONES DE PAGO: <input type="text" class="form-control" id="txtCondicionPago" style="width:50%;" placeholder="CONDICION PAGO" />  </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <!-- /.col -->
                            <div class="col-xs-6">
                                <p class="lead">&nbsp;</p>
                                <div class="table-responsive">
                                    <table class="table">
                                        <tbody>
                                            <tr>
                                                <th style="width:50%">Subtotal:</th>
                                                <td><span id="lblSubTotal">$0.00</span></td>
                                            </tr>
                                            <tr>
                                                <th>IVA (<input type="text" id="txtIVA" style="width:30px;" class="UpperCase" value="0" />%)</th>
                                                <td><span id="lblIVA">$0.00</span></td>
                                            </tr>
                                            <tr>
                                                <th>Descuento:</th>
                                                <td>
                                                    <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                                        <input type="text" class="form-control has-feedback-left money" style="padding-right:0px;" id="txtDescuento" placeholder="0.00">
                                                        <span class="fas fa-hand-holding-usd form-control-feedback left" aria-hidden="true"></span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>Total:</th>
                                                <td><span id="lblTotal">$0.00</span></td>
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
                                <%
                                if (rolesUsuarios.Tipo != "Recepcion almacen")
                                {
                                    %>
                                    <button class="btn btn-default" onclick="window.print();"><i class="fa fa-print"></i> Print</button>
                                    <button class="btn btn-success pull-right" id="btnGuardar"><i class="fas fa-save"></i> Guardar</button>
                                    <button class="btn btn-success pull-right" id="btnModificar"><i class="fas fa-save"></i> Guardar</button>
                                    <button class="btn btn-primary pull-right" id="btnPDF" style="margin-right: 5px;"><i class="fa fa-download"></i> Generate PDF</button>
                                    <%
                                } %>
                                
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>

          <%--editar item 06-01-2025 VAM--%>
            <div class="modal fade" data-backdrop="static" data-keyboard="false" id="EditarItemModal" tabindex="-1" role="dialog" aria-labelledby="EditarItemModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="LabelEditarItem">Editar Item</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            </button>
                        </div>
                        <form class="form-horizontal ">
                            <div class="modal-body">
                                <table id="TablaItemOC" class="table table-striped projects">
                                        <thead>
                                            <tr>
                                                <th>ID</th>
                                                <th>Comentarios</th>
                                                <th>Cantidad</th>
                                                <th>Precio</th>
                                                <th>Tiempo entrega</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                                <button class="btn btn-success" id="btnActualizaItemOC" type="button">Guardar</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <!-- page end-->
          </section>
        </section>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/OrdenCompraDetalle.js" type="text/javascript" ></script>
    
</asp:Content>



 


