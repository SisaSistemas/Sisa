<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Sitio.Master" CodeBehind="CajaChica.aspx.cs" Inherits="SisaDev.Admin.CajaChica" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <script>

        function EditarCajaChicaDesdePopUp() {
            var parametros = "{'Responsable':'" + $('#txtResponsableEditar').val() + "','Concepto': '" + $('#txtConceptoEditar').val() + "', 'pidproyecto':'" + $('#cmbProyectosEditarCC').val() + "', 'Proyecto':'" + $('#cmbProyectosEditarCC option:selected').text() + "',"
                + "'Comprobante': '" + $('#cmbComprobanteEdicarCC').val() + "', 'Cargo': '" + $('#txtCargoEditar').val() + "', 'Abono': '" + $('#txtAbonoEditar').val() + "', 'Fecha':'','Estatus':'" + $('#cmbEstatusEditar').val() + "', 'Tipo':'2', 'pid':'" + $('#txtidCajaChicaEditar').val() + "', 'Categoria':'" + $('#cmbCategoriaCCEditar').val() + "'"
                + ",'CampoExtra': '" + $('#txtResponsable2Editar').val() + "'} ";
            $.ajax({
                dataType: "json",
                url: "CajaChica.aspx/GuardarCC",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Informacion actualizada.") {
                        //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                        //CargarCC();
                        //swal(msg.d);
                        //location.reload();

                        swal({
                            title: msg.d
                        }).then((result) => {

                            if (result) {
                                location.reload();
                            }
                        });

                    }
                    else {
                        //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                        swal(msg.d);
                    }
                }
            });
        }

        function VerDoc(btn) {
            //swal(btn.value);
            var params = "{'id': '" + btn.value + "'}";

            $.ajax({
                async: true,
                url: "CajaChica.aspx/VerPdf",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {
                    if (data.d == 'No se encontro archivo.') {
                        swal('No se encontro archivo de pdf');
                        return;
                    }
                    var jsonArray = $.parseJSON(data.d);
                    var archivo = '';
                    archivo = jsonArray.NombreArchivo;

                    window.open("docs/" + archivo);
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
                              <a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddCajaChicaSucursalModal" id="btnAgregarCajaChicaSucursal"><i class="icon_plus_alt2"></i>Agregar Sucursal</a>
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
                        <%--<div class="form-group" id="CargandoCajaChica">
                     <label id="txtMensajeDatos"></label>
                  </div>
                <div style="overflow-x: auto; overflow-y: auto;"> 
              <table class="table table-advance table-hover order-table" id="TablaCajaChica">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i>Código</th>
                      <th><i class="icon_calendar"></i> Fecha</th>  
                      <th><i class="icon_profile"></i> Responsable</th>
                      <th><i class="icon_profile"></i> Responsable (2)</th>
                                      
                      <th><i class="icon_info_alt"></i> Concepto</th>
                    <th><i class="icon_tags_alt"></i>Proyecto</th>
                    <th><i class="icon_document_alt"></i>Comprobante</th>
                    <th><i class="icon_calculator_alt"></i>Cargo</th>
                    <th><i class="icon_calculator_alt"></i>Abono</th>
                    <th><i class="icon_calculator_alt"></i>Saldo</th>
                    <th><i class="icon_box-empty"></i>Categoria</th>
                      
                    <th><i class="icon_ol"></i> Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaCajaChica">
                   
                </tbody>
              </table>
                </div>
                <div class="col-md-12 text-center">
      <ul class="pagination pagination-lg pager" id="myPager"></ul>
      </div>--%>
                    </section>
                </div>
            </div>
            <!-- page end-->
        </section>
    </section>
    <%--AGREGAR--%>
   <%-- <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddCajaChicaModal" tabindex="-1" role="dialog" aria-labelledby="AddCajaChicaModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelAgregarCajaChica">Agregar CajaChica</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">

                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Fecha:</label>
                                <input type="date" class="form-control" id="dtFecha" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Responsable:</label>
                                <select class="form-control selectpicker" id="txtResponsable" data-live-search="true"></select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Responsable (2):</label>
                                <input type="text" class="form-control" id="txtResponsable2" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Concepto:</label>
                                <input type="text" class="form-control" id="txtConcepto" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Proyecto:</label>
                                <select id="cmbProyectos" class="form-control selectpicker" data-live-search="true" required></select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Comprobante:</label>
                                <select id="cmbComprobante" class="form-control" required>
                                    <option value="SIN COMPROBANTE">SIN COMPROBANTE</option>
                                    <option value="TICKET">TICKET</option>
                                    <option value="FACTURA">FACTURA</option>
                                    <option value="NOTA">NOTA</option>
                                    <option value="RECIBO DE EFECTIVO">RECIBO DE EFECTIVO</option>
                                    <option value="VIATICOS">VIATICOS</option>
                                    <option value="ORDEN DE COMPRA">ORDEN DE COMPRA</option>
                                    <option value="N/A">N/A</option>
                                    <option value="PENDIENTE">PENDIENTE</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Cargo:</label>
                                <input type="number" class="form-control" id="txtCargo" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Abono:</label>
                                <input type="number" class="form-control" id="txtAbono" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Estatus:</label>
                                <select id="cmbEstatus" class="form-control" required>
                                    <option value="0">PENDIENTE</option>
                                    <option value="1">COMPLETO</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Categoria:</label>
                                <select id="cmbCategoriaCC" class="form-control" required>
                                    <option value="MATERIAL">MATERIAL</option>
                                    <option value="MANOOBRA">MANO DE OBRA</option>
                                    <option value="EQUIPO">EQUIPO</option>
                                    <option value="N/A">N/A</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-primary" id="btnGuardarCajaChica" type="button">Crear</button>
                    </div>
                </form>
            </div>
        </div>
    </div>--%>

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
                                        <label>Cargo:</label>
                                        <input type="number" class="form-control" id="txtCargo" required />
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

    <%--AGREGAR SUCURSAL--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddCajaChicaSucursalModal" tabindex="-1" role="dialog" aria-labelledby="AddCajaChicaSucursalModal" aria-hidden="true">
        <div class="modal-dialog" id="divAnchoSucursal" style="width: 75%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Agregar Caja Chica a SUCURSAL </h4>
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
                                        <input type="date" class="form-control" id="dtFechaSucursal" required />
                                        <label>Sucursal:</label>
                                        <select class="form-control selectpicker" id="cmbSucursal" data-live-search="true"></select>
                                        <label>Concepto:</label>
                                        <input type="text" class="form-control" id="txtConceptoSucursal" required />
                                        <label>Proyecto:</label>
                                        <select id="cmbProyectosSucursal" class="form-control selectpicker" data-live-search="true" required></select>
                                        <label>Comprobante:</label>
                                        <select id="cmbComprobanteSucursal" class="form-control" required>
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

                                        <label>Cargo:</label>
                                        <input type="number" class="form-control" id="txtCargoSucursal" required />
                                        <label>Abono:</label>
                                        <input type="number" class="form-control" id="txtAbonoSucursal" required />
                                    </div>
                                </section>
                            </div>
                            <div class="col-sm-6">
                                <section class="panel">
                                    <div class="panel-body">
                                        <label>Estatus:</label>
                                        <select id="cmbEstatusSucursal" class="form-control" required>
                                            <option value="0">PENDIENTE</option>
                                            <option value="1">COMPLETO</option>
                                        </select>
                                    </div>
                                </section>
                            </div>
                        </div>




                    </div>
                    <div class="form-group">
                        <div class="col-lg-offset-2 col-lg-10">
                            <i class="icon_documents_alt"></i>
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnAdjuntarArchivoSucursal">Adjuntar archivo</button>
                            <input type="hidden" id="dataarchivopdfSucursal" />
                            <input type="hidden" id="nombreaarchivopdfSucursal" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <input type="hidden" id="txtidCajaChicaEditarSucursal" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-primary" id="btnGuardarCajaChicaSucursal" type="button">Crear</button>
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
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/CajaChica.js" type="text/javascript"></script>

</asp:Content>





