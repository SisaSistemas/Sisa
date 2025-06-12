<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="ProveedoresCalificacion.aspx.cs" Inherits="SisaDev.CCM.ProveedoresCalificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Administración</li>
                        <li><i class="icon_building"></i>Usuarios Contactos</li>
                    </ol>
                </div>
            </div>
            <!-- page start-->
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div class="form-group" id="MensajeUsuarios">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>
                        <header class="panel-heading">
                            Lista de Usuarios 
                  <div class="btn-group" id="botones">

                      <form class="form-inline">
                          <div class="form-group">
                              <%--<Button class="btn btn-primary" data-toggle="modal" data-target="#AddUsuariosModal"><i class="icon_plus_alt2"></i></Button>--%>
                              <%--<a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddUsuariosModal"><i class="icon_plus_alt2"></i>Agregar </a>--%>
                          </div>
                          <%--<div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>--%>
                      </form>
                  </div>
                        </header>
                        <div class="form-group" id="CargandoUsuarios">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>
                        <div style="overflow-x: auto; overflow-y: auto;">
                            <div id="toolbar">

                            </div>

                             <table id="TablaProveedores" class="table table-striped table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                <thead>
                                    <tr>
                                        <th data-field="Proveedor" data-sortable="true"><i class="icon_profile"></i> Nombre</th>
                                        <th data-field="Email" data-sortable="true"><i class="icon_mail"></i> Correo</th>
                                        <th data-field="Telefono1" data-sortable="true"><i class="icon_mail"></i> Telefono</th>
                                        <th data-field="NombreComercial" data-sortable="true"><i class="icon_mail"></i> Nombre Comercial</th>
                                        <th data-field="Usuario" data-sortable="true"><i class="icon_profile"></i> Usuario</th>
                                        <th data-field="CapFinanciera" data-formatter="formatoMonedaFormatter" data-sortable="true"><i class="fa-solid fa-sack-dollar"></i> Cap Financiera</th>
                                        <th data-align="center" data-formatter="accionUsersFormatter" data-events="accionUsersEvents"><i class="icon_ol"></i>Acciones</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>

                    </section>
                </div>
            </div>
            <!-- page end-->
        </section>
    </section>

    <%--comentarios--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvCalificacion" tabindex="-1" role="dialog" aria-labelledby="dvComentarios" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabeldvComentarios">Agregar comentario al proyecto</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <div class="modal-body">
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-3">
                                    <label><strong>Calidad:</strong></label>
                                    <input type="number" class="col-md-6 form-control form-control-sm" min="0" max="10" placeholder="Cal Calidad" id="txtCalidad" />
                                </div>
                                <div class="col-md-3">
                                    <label><strong>Seguridad:</strong></label>
                                    <input type="number" class="col-md-6 form-control form-control-sm" min="0" max="10" placeholder="Cal Seg." id="txtSeguridad" />
                                </div>

                                <div class="col-md-3">
                                    <label><strong>T. Entrega:</strong></label>
                                    <input type="number" class="col-md-6 form-control form-control-sm" min="0" max="10" placeholder="Cal TE" id="txtTiempoEntrega" />
                                </div>
                                <div class="col-md-3">
                                    <label><strong>Costos:</strong></label>
                                    <input type="number" class="col-md-6 form-control form-control-sm" min="0" max="10" placeholder="Cal Costo" id="txtCostos" />
                                </div>
                                    
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <label><strong>Cap Financiera:</strong></label>
                                    <input type="number" class="col-md-6 form-control form-control-sm" min="1" placeholder="Cap Financiera" id="txtCapFinanciera" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                    <span class="btn btn-success" id="btnGuardarCal"><i class="fa-solid fa-floppy-disk"></i> Guardar</span>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/ProveedoresCalificacion.js" type="text/javascript" ></script>
</asp:Content>
