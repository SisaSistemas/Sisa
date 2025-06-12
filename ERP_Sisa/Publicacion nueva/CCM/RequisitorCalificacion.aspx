<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="RequisitorCalificacion.aspx.cs" Inherits="SisaDev.CCM.RequisitorCalificacion" %>
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
                              <a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddUsuariosModal"><i class="icon_plus_alt2"></i>Agregar </a>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/RequisitorCalificacion.js" type="text/javascript" ></script>
</asp:Content>
