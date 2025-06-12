<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Compras.Proveedores" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <div id="loading-img">  <img src="../img/logoloading.png" /></div>--%>
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Administración</li>
                        <li><i class="icon_building"></i>Proveedores</li>
                    </ol>
                </div>
            </div>
            <!-- page start-->
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div class="form-group" id="MensajeProveedores">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>
                        <header class="panel-heading">
                            Lista de Proveedores 
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                              <%--<Button class="btn btn-primary" data-toggle="modal" data-target="#AddProveedoresModal"><i class="icon_plus_alt2"></i></Button>--%>
                              <a id="btnAgregarProveedor" class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddProveedoresModal"><i class="icon_plus_alt2"></i>Agregar </a>
                          </div>
                          <%--<div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>--%>
                      </form>

                  </div>
                        </header>
                        <div class="form-group" id="CargandoProveedores">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="x_panel">
                                <div class="x_content">

                                    <div id="toolbar">
                                    </div>

                                    <table id="TablaProveedores" class="table table-striped table-advance table-hover table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                        <thead>
                                            <tr>
                                                <th data-field="NombreComercial" data-sortable="true"><i class="icon_building"></i>Nombre</th>
                                                <th data-field="Proveedor" data-sortable="true"><i class="icon_building"></i>Nombre Comercial</th>
                                                <th data-field="RFC" data-sortable="true"><i class="icon_building"></i>RFC</th>
                                                <th data-field="Contacto" data-sortable="true"><i class="icon_profile"></i>Contacto</th>
                                                <th data-field="Email" data-sortable="true"><i class="icon_mail"></i>Correo</th>
                                                <th data-field="Telefono1" data-sortable="true"><i class="icon_phone"></i>Telefono</th>
                                                <th data-align="center" data-formatter="accionFormatter" data-events="accionEvents"><i class="icon_ol"></i>Accion</th>
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
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddProveedoresModal" tabindex="-1" role="dialog" aria-labelledby="AddProveedoresModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelAgregarProveedores">Agregar Proveedores</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Razon Social</label>
                                <input type="text" class="form-control" placeholder="Razon Social" id="txtNombreProveedor" onkeyup="mayus(this);" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Nombre comercial</label>
                                <input type="text" class="form-control" placeholder="Nombre Comercial" id="txtNombreComercial" onkeyup="mayus(this);" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>RFC</label>
                                <input type="text" class="form-control" placeholder="RFC" id="txtRFCProveedor" onkeyup="mayus(this);" required />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Teléfono</label>
                                <input type="tel" class="form-control" placeholder="Teléfono" id="txtTelefonoProveedores" onkeyup="mayus(this);" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Correo</label>
                                <input type="email" class="form-control" placeholder="Correo" id="txtCorreoProveedor" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Contácto</label>
                                <input type="text" class="form-control" placeholder="Contacto" id="txtContactoProveedor" onkeyup="mayus(this);" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Dirección</label>
                                <input type="text" class="form-control" placeholder="Dirección" id="txtDireccionProveedor" onkeyup="mayus(this);" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Días de crédito</label>
                                <input type="number" class="form-control" placeholder="Dias de credito" id="txtCreditoProv" onkeyup="mayus(this);" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Usuario</label>
                                <input type="text" class="form-control" placeholder="Usuario" id="txtUsuario" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Clave</label>
                                <input type="password" class="form-control" placeholder="Clave" id="txtClaveUsuario" minlengh="8" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Tipo Empresa</label>
                                <input type="text" class="form-control" placeholder="Tipo Empresa Perfil" id="txtTipoEmpresa" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <div class="form-group" id="AddMsgProveedores">
                                    <%--<label id="txtMensajeDatos"></label>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-primary" id="btnGuardarProveedores" type="button">Crear</button>
                        <button class="btn btn-primary" id="btnEditarProveedores" type="button">Guardar cambios</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelProveedoresModal" tabindex="-1" role="dialog" aria-labelledby="DelProveedoresModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelEliminarProveedores">Eliminar Proveedores</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group" id="txtModalEliminarProveedores">
                            <label id="idProveedoresEliminar" hidden="hidden"></label>
                            <label id="idProveedoresEliminarTexto"></label>
                        </div>
                        <div class="form-group" id="txtModalEliminarMensajeProveedores">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-danger" id="btnEliminarProveedores" type="button">Eliminar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/Proveedores.js" type="text/javascript"></script>

</asp:Content>





