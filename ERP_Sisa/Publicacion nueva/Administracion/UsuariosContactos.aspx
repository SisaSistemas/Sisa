<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="UsuariosContactos.aspx.cs" Inherits="SisaDev.Administracion.UsuariosContactos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>

        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $("[id*='ImgPrvUsuarios']").prop('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
     </script>
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

                             <table id="TablaUsuarios" class="table table-striped table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                <thead>
                                    <tr>
                                        <th data-field="NombreContacto" data-sortable="true"><i class="icon_profile"></i> Nombre</th>
                                        <th data-field="Correo" data-sortable="true"><i class="icon_mail"></i> Correo</th>
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
    <%--AGREGAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddUsuariosModal" tabindex="-1" role="dialog" aria-labelledby="AddUsuariosModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelAgregarUsuarios">Agregar Usuarios</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">

                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Empresa</label>
                                <select id="slctEmpresa" class="form-control form-control-sm selectpicker" data-live-search="true"></select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Contacto</label>
                                <select id="slctContacto" class="form-control form-control-sm selectpicker" data-live-search="true"></select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Correo</label>
                                <input type="email" class="form-control" placeholder="Correo" id="txtCorreo" required />
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
                                <label>Tipo de usuario</label>
                                <select id="slctTipo" class="form-control" required>
                                    <option value="0">-- SELECCIONE TIPO --</option>
                                    <option value="REQUISITOR">Requisitor</option>
                                    <option value="COMPRAS">Compras</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Cotizaciones</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCotiVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCotiAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCotiEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCotiDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Proyectos</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProyectosVer">
                                    Ver
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Paquetes</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkPaquetesVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkPaquetesAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkPaquetesEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkPaquetesDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <div class="form-group" id="AddMsgUsuarios">
                                    <%--<label id="txtMensajeDatos"></label>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-primary" id="btnGuardarUsuarios" type="button">Crear</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelUsuariosModal" tabindex="-1" role="dialog" aria-labelledby="DelUsuariosModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelEliminarUsuarios">Eliminar Usuarios</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal">
                    <div class="modal-body">
                        <div class="form-group">
                            <label id="idUsuariosEliminar" hidden="hidden"></label>
                            <label id="txtModalEliminarUsuarios"></label>

                        </div>
                        <div class="form-group" id="txtModalEliminarMensajeUsuarios">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-danger" id="btnEliminarUsuarios" type="button">Eliminar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
   
    <%--Foto--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="FotoUsuariosModal" tabindex="-1" role="dialog" aria-labelledby="FotoUsuariosModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelFotoUsuarios">Foto Usuarios</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group" id="txtModalFotoUsuarios">
                        <label id="idUsuariosFoto" hidden="hidden"></label>
                    </div>
                    <div class="form-group">
                        <label for="imgPerfil"></label>
                        <div class="row">
                            <div class="col-lg-6">
                                <form runat="server">
                                    <asp:Image ID="ImgPrvUsuarios" Height="227" Width="162" ClientIDMode="Static" runat="server" />
                                    <asp:FileUpload runat="server" ID="FlupImage" onchange="ShowImagePreview(this);" />
                                </form>

                            </div>
                            <div class="col-lg-6">
                                <img src="" id="ImagenActualUsuarios" class="fotoPerfil" height="227" width="162">
                            </div>
                        </div>

                        <p class="help-block">Cambiar foto.</p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button class="btn btn-danger" id="btnFotoUsuarios" type="button">Actualizar</button>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/UsuariosContactos.js" type="text/javascript" ></script>
</asp:Content>
