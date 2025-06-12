<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cotizaciones.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Ventas.Cotizaciones" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <script>
        function EliminarCotizacion(btn) {
            document.getElementById('idCotizacionesEliminar').textContent = '';
            document.getElementById('idCotizacionesEliminarTexto').textContent = '¿Estás seguro de eliminar cotización con código "' + btn.value + '"?';
            document.getElementById('idCotizacionesEliminar').textContent = btn.value;
            $("#DelCotizacionesModal").modal();
        }

        
        function NuevaCotizacion(btn) {
            window.open("CotizacionesDetalles.aspx?idCotizacion=0&idSolicitud=0");
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
                        <li><i class="icon_building"></i>Cotizaciones</li>
                    </ol>
                </div>
            </div>
            <!-- page start-->
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div class="form-group" id="MensajeCotizaciones">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>
                        <header class="panel-heading">
                            Lista de Cotizaciones 
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                            <button class="btn btn-primary" onclick="NuevaCotizacion();"><i class="icon_plus_alt2"></i></button>
                          </div>
                          <%--<div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>--%>
                      
                      </form>
                      
                  </div>
                        </header>
                        <%--<div class="form-group" id="CargandoCotizaciones">
                        </div>
                        <div style="overflow-x: auto; overflow-y: auto;">
                            <table class="table table-advance table-hover order-table" id="TablaCotizaciones">
                                <thead>
                                    <tr>
                                        <th style="display: none;"><i class="icon_building"></i>Código</th>
                                        <th><i class="icon_ribbon_alt"></i>Fecha</th>
                                        <th><i class="icon_table"></i>Folio</th>
                                        
                                        <th><i class="icon_table"></i>Folio RFQ</th>
                                        <th><i class="icon_building"></i>Empresa</th>
                                        <th><i class="icon_profile"></i>Contacto</th>
                                        <th><i class="icon_cart_alt"></i>Concepto</th>
                                        <th><i class="icon_ribbon_alt"></i>Estatus</th>
                                        <th><i class="icon_ribbon_profile"></i>Hecha Por</th>
                                        <th><i class="icon_ribbon_profile"></i>Enviada Por</th>
                                        <th><i class="icon_ribbon_profile"></i>Vendida Por</th>
                                        <th><i class="icon_ol"></i>Acciones</th>
                                        <th></th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody id="listaCotizaciones">
                                </tbody>
                            </table>

                        </div>
                        <div class="col-md-12 text-center">
                            <ul class="pagination pagination-lg pager" id="myPager"></ul>
                        </div>--%>

                        <table id="TablaCOT" class="table table-advance table-hover order-table" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                            <thead>
                                <tr>
                                    <th data-field="FechaCotizaciones" data-sortable="true" data-formatter="dateFormat"><i class="icon_calendar"></i>Fecha</th>
                                    <th data-field="NoCotizaciones" data-sortable="true"><i class="icon_table"></i>Folio</th>
                                    <th data-field="RFQ" data-sortable="true"><i class="icon_table"></i>Folio RFQ</th>
                                    <th data-field="RazonSocial" data-sortable="true"><i class="icon_building"></i>Empresa</th>
                                    <th data-field="NombreContacto" data-sortable="true"><i class="icon_profile"></i>Contacto</th>
                                    <th data-field="Concepto" data-sortable="true"><i class="icon_cart_alt"></i>Concepto</th>
                                    <th data-field="Estatus" data-sortable="true" data-formatter="estatusFormatter"><i class="icon_ribbon_alt"></i>Estatus</th>
                                    <th data-field="HechaPor" data-sortable="true"><i class="icon_ribbon_profile"></i>Hecha Por</th>
                                    <th data-field="EnviadaPor" data-sortable="true"><i class="icon_ribbon_profile"></i>Enviada Por</th>
                                    <th data-field="VendidaPor" data-sortable="true"><i class="icon_ribbon_profile"></i>Vendida Por</th>
                                    <th data-align="center" data-formatter="accionCOTFormatter" data-events="accionCOTEvents"><i class="icon_ol"></i>Acciones</th>
                                    <th data-align="center" data-formatter="accionCOT2Formatter" data-events="accionCOT2Events"><i class="icon_ol"></i></th>
                                    <th data-align="center" data-formatter="accionCOT3Formatter" data-events="accionCOT3Events"><i class="icon_ol"></i></th>
                                </tr>
                            </thead>
                        </table>
                    </section>
                </div>
            </div>
            <!-- page end-->
        </section>
    </section>
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelCotizacionesModal" tabindex="-1" role="dialog" aria-labelledby="DelCotizacionesModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelEliminarCotizaciones">Eliminar Cotizaciones</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group" id="txtModalEliminarCotizaciones">
                            <label id="idCotizacionesEliminar" hidden="hidden"></label>
                            <label id="idCotizacionesEliminarTexto"></label>
                        </div>
                        <div class="form-group" id="txtModalEliminarMensajeCotizaciones">
                            
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-danger" id="btnEliminarCotizaciones" type="button">Eliminar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--correo--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelEnviarCotizacion">Enviar Cotizacion</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form role="form" class="form-horizontal" runat="server">
                    <div class="modal-body">
                        <div class="form-group">
                            <label id="idCotizacionEnviar" hidden="hidden"></label>
                            <label class="col-lg-2 control-label">Para</label>
                            <div class="col-lg-10">
                                <%--<input type="text" placeholder="" id="inputEmail1" class="form-control" runat="server">--%>
                                <asp:TextBox ID="txtPara" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <%--<div class="form-group">
                            <label class="col-lg-2 control-label">Cc / Bcc</label>
                            <div class="col-lg-10">
                                <input type="text" placeholder="" id="cc" class="form-control">
                            </div>
                        </div>--%>
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Asunto</label>
                            <div class="col-lg-10">
                                <%--<input type="text" placeholder="" id="txtSubject" class="form-control">--%>
                                <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Mensaje</label>
                            <div id="editor">
                                <p>
                                    Buen día,
                                    <br />
                                    Adjunto orden de compra autorizada <b style="color: blue;">No. Cotizacion000000-000</b> Para su envió a la brevedad posible.<br />
                                    <br />
                                    Quedo a sus órdenes para cualquier duda o información que requiera.
                                    <br />
                                    Favor de verificar que la información sea correcta y confirmar de recibido.<br />
                                    <br />

                                    Saludos
                                    <br />
                                    <br />
                                    Anexo nuestro link para mayor información<br />
                                    <a href="http://www.sistemasautomatizados.net/SISA/es/index.htm" target="_blank">http://www.sistemasautomatizados.net/SISA/es/index.htm</a>
                                    <br />
                                    <br />
                                    <%--<img src="images/FirmaAngelica.jpg" width="650px" />--%>
                                    <%--<img src="cid:FirmaAngelica.jpg" width="650px" />--%>
                                    <br />
                                    <br />
                                </p>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-offset-2 col-lg-10">
                                <span class="btn green fileinput-button">
                                    <i class="fa fa-plus fa fa-white"></i>
                                    <span>Adjunto</span>
                                    <%--<input type="file" name="files[]" multiple="" id="files">--%>
                                    <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
                                </span>
                                <%--<button class="btn btn-send" type="button" name="btnEnviar" id="btnEnviar" runat="server" onclick="btnSend_Click">Send</button>--%>
                                <%-- <asp:Button CssClass="btn btn-send" ID="Button1" runat="server" OnClick="btnEnviar_Click" Text="Send" />--%>
                            </div>
                        </div>
                        <div style="visibility: hidden;">
                            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <asp:Button CssClass="btn btn-send" ID="btnEnviar" runat="server" OnClick="btnEnviar_Click" Text="Enviar" />
                    </div>
                </form>
            </div>
        </div>
    </div>
    <!-- /.modal -->
    <%--comentarios--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvComentarios" tabindex="-1" role="dialog" aria-labelledby="dvComentarios" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabeldvComentarios">Agregar comentario a cotización</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="modal-body">
                            <div class="col-md-10 col-sm-10 col-xs-12 form-group has-feedback">
                                <input type="text" class="form-control has-feedback-left" id="txtComentario" placeholder="Comentario">
                                <span class="fas fa-comment-dots form-control-feedback left" aria-hidden="true"></span>
                            </div>
                            <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback">
                                <span class="btn btn-success" id="btnAgregarComentarioCotizacion"><i class="fa fa-plus"></i>Agregar</span>
                            </div>
                            <label id="idCotizacionComentario" hidden="hidden"></label>
                            <div id="testmodalComentariosCotiza" style="padding: 5px 20px;">
                                <table id="TablaPrincipalComentariosCotizacion" class="table table-striped projects">
                                    <thead>
                                        <tr>
                                            <th style="display: none;">#</th>
                                            <th>Comentario</th>
                                            <th>Usuario</th>
                                            <th>Fecha</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                </table>
                            </div>

                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="submit" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                        <%--<button type="submit" id="btnGuardarComentario" class="btn btn-success">Guardar</button>--%>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--CANCELAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="CancelarCotizacionModal" tabindex="-1" role="dialog" aria-labelledby="CancelarCotizacionModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelCancelarCotizacion">Cancelar Cotizacion</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group" id="txtModalCancelarCotizacion">
                            <label id="idCotizacionCancelar" hidden="hidden"></label>
                            <label id="idCotizacionCancelarTexto"></label>
                        </div>
                        <div class="form-group" id="txtModalCancelarMensajeCotizacion">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-danger" id="btnCancelarCotizacion" type="button">Cancelar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <%--CONVERTIR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="ConvCotizacionesModal" tabindex="-1" role="dialog" aria-labelledby="ConvCotizacionesModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelConvertirCotizaciones">Convertir Cotizaciones</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Nombre proyecto</label>
                                <input type="text" class="form-control" id="txtNombreProyecto" placeholder="Nombre proyecto">
                            </div>
                        
                            <div class="col-sm-10">
                                <label>Concepto</label>
                                <textarea class="form-control" id="txtConceptoProyecto" placeholder="Nombre proyecto"></textarea>
                            </div>
                        
                            <div class="col-sm-10">
                                <label>Lider proyecto</label>
                                <select class="form-control selectpicker" data-live-search="true" id="cmbUsuarioLider"></select>
                            </div>

                            <%--<div class="col-sm-10">
                                <label>Sucursal</label>
                                <select class="form-control selectpicker" data-live-search="true" id="cmbSucursal"></select>
                            </div>--%>
                        
                            <div class="col-sm-10">
                                <label>Fecha inicial</label>
                                <input type="date" class="form-control" id="dtInicial">
                            </div>
                       
                            <div class="col-sm-10">
                                <label>Fecha final</label>
                                <input type="date" class="form-control" id="dtFinal">
                            </div>
                            <div class="col-sm-10">
                                <label>Mano de obra cotizado:</label>
                                <input type="text" class="form-control" id="txtCostoMOCotizado" value="0"/>   
                            </div>
                            <div class="col-sm-10">
                                <label>Costo de material cotizado:</label>
                                <input type="text" class="form-control" id="txtCostoMaterialCotizado" value="0"/>
                            </div>
                            <div class="col-sm-10">
                                <label>Costo de equipo cotizado:</label>
                                <input type="text" class="form-control" id="txtCostoMECotizado" value="0"/>
                            </div>
                            <div class="col-sm-10">
                                <label>Mano de obra proyectado:</label>
                                <input type="number" class="form-control" id="txtCostoMOProyectado" value="0"/>   
                            </div>
                            <div class="col-sm-10">
                                <label>Costo de material proyectado:</label>
                                <input type="number" class="form-control" id="txtCostoMaterialProyectado" value="0"/>
                            </div>
                            <div class="col-sm-10">
                                <label>Costo de equipo proyectado:</label>
                                <input type="number" class="form-control" id="txtCostoMEProyectado" value="0"/>
                            </div>
                            <div class="col-sm-10">
                                <label>Folio PO:</label>
                                <select class="form-control selectpicker" data-live-search="true" id="cmbPO"></select>
                                <%--<input type="text" class="form-control" id="txtFolioPO" placeholder="Folio PO">--%>
                            </div>

                            <div class="col-sm-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkEsCCM">
                                    Es CCM?
                                </label>
                            </div>

                        </div>
                        
                        <div class="form-group" id="ModalConvertirCotizaciones">
                            <label id="idCotizacionesConvertir" hidden="hidden"></label>
                            <label id="txtModalConvertirCotizaciones"></label>
                        </div>
                        <div class="form-group" id="txtModalConvertirMensajeCotizaciones">
                        </div>
                    </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                <button class="btn btn-danger" id="btnConvertirCotizacion" type="button">Convertir</button>
            </div>
            </form>
        </div>
    </div>
    </div>
     <%--PDF--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvPDFCot" tabindex="-1" role="dialog" aria-labelledby="dvPDFCot" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabeldvPDFAdministracion">Archivo</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">
          <label id="txtidArchivoCot" hidden="hidden"></label>
          <label id="txtTipoDocumentoCot" hidden="hidden"></label>
        <div id="testmodalpdfCot" style="padding: 5px 20px;">
                       
                    </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <%--<button type="button" class="btn btn-danger" id="btnEliminadDocumentoCot" data-dismiss="modal">Eliminar</button>--%>
        <%--<button type="button" class="btn btn-danger" id="btnDescargarDocumentoCot" data-dismiss="modal">Descargar</button>--%>
      </div>
      </form>
    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/Cotizacion.js" type="text/javascript" ></script>
</asp:Content>