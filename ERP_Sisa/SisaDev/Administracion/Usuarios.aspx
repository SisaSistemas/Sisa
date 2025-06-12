<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Admin.Usuarios" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
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

        //(function (document) {
        //    'use strict';

        //    var LightTableFilter = (function (Arr) {

        //        var _input;

        //        function _onInputEvent(e) {
        //            _input = e.target;
        //            var tables = document.getElementsByClassName(_input.getAttribute('data-table'));
        //            Arr.forEach.call(tables, function (table) {
        //                Arr.forEach.call(table.tBodies, function (tbody) {
        //                    Arr.forEach.call(tbody.rows, _filter);
        //                });
        //            });
        //        }

        //        function _filter(row) {
        //            var text = row.textContent.toLowerCase(), val = _input.value.toLowerCase();
        //            row.style.display = text.indexOf(val) === -1 ? 'none' : 'table-row';
        //        }

        //        return {
        //            init: function () {
        //                var inputs = document.getElementsByClassName('light-table-filter');
        //                Arr.forEach.call(inputs, function (input) {
        //                    input.oninput = _onInputEvent;
        //                });
        //            }
        //        };
        //    })(Array.prototype);

        //    document.addEventListener('readystatechange', function () {
        //        if (document.readyState === 'complete') {
        //            LightTableFilter.init();
        //        }
        //    });

        //})(document);
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
                        <li><i class="icon_building"></i>Usuarios</li>
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
                            <%--<table class="table table-striped table-advance table-hover order-table" id="TablaUsuarios">
                                <thead>
                                    <tr>
                                        <th style="display: none;"><i class="icon_building"></i>Código</th>
                                        <th><i class="icon_profile"></i>Nombre</th>
                                        <th><i class="icon_profile"></i>Usuario</th>
                                        <th><i class="icon_phone"></i>Teléfono</th>
                                        <th><i class="icon_mail"></i>Correo</th>
                                        <th><i class="icon_tag"></i>Tipo</th>
                                        <th><i class="icon_building"></i>Sucursal</th>

                                        <th><i class="icon_ol"></i>Acciones</th>
                                    </tr>
                                </thead>
                                <tbody id="listaUsuarios">
                                </tbody>
                            </table>--%>
                            <div id="toolbar">

                            </div>

                             <table id="TablaUsuarios" class="table table-striped table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                <thead>
                                    <tr>
                                        <th data-field="NombreCompleto" data-sortable="true"><i class="icon_profile"></i>Nombre</th>
                                        <th data-field="Usuario" data-sortable="true"><i class="icon_profile"></i>Usuario</th>
                                        <th data-field="Telefono" data-sortable="true"><i class="icon_phone"></i>Teléfono</th>
                                        <th data-field="Correo" data-sortable="true"><i class="icon_mail"></i>Correo</th>
                                        <th data-field="Tipo" data-sortable="true"><i class="icon_tag"></i>Tipo</th>
                                        <th data-field="CiudadSucursal" data-sortable="true"><i class="icon_building"></i>Sucursal</th>
                                        <th data-align="center" data-formatter="accionUsersFormatter" data-events="accionUsersEvents"><i class="icon_ol"></i>Acciones</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                        <%--<div class="col-md-12 text-center">
                            <ul class="pagination pagination-lg pager" id="myPager"></ul>
                        </div>--%>

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
                                <label>Nombre</label>
                                <input type="text" class="form-control" placeholder="Nombre completo" id="txtNombreCompleto" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Correo</label>
                                <input type="email" class="form-control" placeholder="Correo" id="txtCorreoUsuario" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Teléfono</label>
                                <input type="tel" class="form-control" placeholder="Teléfono" id="txtTelefonoUsuarios" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Salario</label>
                                <input type="number" class="form-control" id="txtSalarioUsuario" required />
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
                                    <option value="VENTAS">Ventas</option>
                                    <option value="COMPRAS">Compras</option>
                                    <option value="ADMINISTRACION">Administracion</option>
                                    <option value="CLIENTE">Cliente</option>
                                    <option value="COORDINADOR">Coordinador</option>
                                    <option value="GERENCIAL">Gerencia</option>
                                    <option value="SISTEMAS">Sistemas</option>
                                    <option value="ROOT">ROOT</option>
                                    <option value="AYUDANTE">Ayudante</option>
                                    <option value="SUPERVISOR">Supervisor</option>
                                    <option value="SEGURIDAD">Seguridad</option>
                                    <option value="CONTROL">Control</option>
                                    <option value="MAQUINADO">Maquinado</option>
                                    <option value="DISENO">Diseño</option>

                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <div class="panel-group">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">SUCURSAL</div>
                                        <div class="panel-body">
                                            <label class="checkbox-inline">
                                                <input type="checkbox" id="chkSucursalCuautitlanNew">
                                                Cuautitlan
                                            </label>
                                            <label class="checkbox-inline">
                                                <input type="checkbox" id="chkSucursalChihuahuaNew">
                                                Chihuahua
                                            </label>
                                            <label class="checkbox-inline">
                                                <input type="checkbox" id="chkSucursalUsaNew">
                                                Estados Unidos
                                            </label>
                                            <label class="checkbox-inline">
                                                <input type="checkbox" id="chkSucursalHermosilloNew">
                                                Hermosillo
                                            </label>
                                            <label class="checkbox-inline">
                                                <input type="checkbox" id="chkSucursalIrapuatoNew">
                                                Irapuato
                                            </label>
                                            <label class="checkbox-inline">
                                                <input type="checkbox" id="chkSucursalQueretaroNew">
                                                Queretaro
                                            </label>
                                            <label class="checkbox-inline">
                                                <input type="checkbox" id="chkSucursalTecateNew">
                                                Tecate
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <%--<label>Sucursal</label>
                                <select id="slctSucursalUsuario" class="form-control"></select>--%>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Cliente Empresa</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliEmpVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliEmpAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliEmpEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliEmpDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Cliente Contácto</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliConVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliConAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliConEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliConDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">RFQ</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRFQVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRFQAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRFQEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRFQDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Cotizaciones</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCotVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCotAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCotEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCotDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Materiales</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkMatVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkMatAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkMatEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkMatDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Proveedores</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProvVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProvAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProvEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProvDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Requisiciones</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRequiVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRequiAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRequiEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRequiDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Orden Compra</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkOCVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkOCAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkOCEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkOCDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Viaticos</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkViaVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkViaAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkViaEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkViaDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Proyectos</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProyVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProyAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProyEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProyDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Caja chica</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Caja chica Sucursal</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaCuautitlan">
                                    Cuautitlan
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaChihuahua">
                                    Chihuahua
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaUSA">
                                    USA
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaIrapuato">
                                    Irapuato
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaQueretaro">
                                    Queretaro
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaTecate">
                                    Tecate
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Usuarios</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkUserVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkUserAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkUserEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkUserDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Sucursales</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkSucVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkSucAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkSucEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkSucDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Control Facturas</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFRVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFRAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFREdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFRDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Facturas Emitidas</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFEVer">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFEAdd">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFEEdit">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFEDel">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <%--<div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Control</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFacVer">
                                    Control Facturas
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFacVerEmitidas">
                                    Facturas emitidas
                                </label>

                            </div>
                        </div>--%>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Documentos</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkDocsAdd">
                                    Documentos
                                </label>

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Administración</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkAdminVer">
                                    Admin Proyectos</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkInventaAdd">
                                    Inventario</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkTimmEdit">
                                    Timming</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkBoletines">
                                    Boletines</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkModuloPO">
                                    Modulo PO</label>
                                 <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCostoIndirecto">
                                    Costos Indirectos</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Servicios</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCarroVer">
                                    Carros
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkPCAdd">
                                    Compúto
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Reportes</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptOrdenCompra">Orden Compra</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptFacturasRecibidas">
                                    Facturas Recibidas</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptFacturasEmitidas">
                                    Facturas Emitidas</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptProyectos">
                                    Proyectos</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptCotizaciones">
                                    Cotizaciones</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptProyectosGastos">
                                    Proyectos y Gastos</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptProveedoresPagar">
                                    Proveedores a Pagar</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptEficiencias">
                                    Eficiencias</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptMonitor">
                                    Monitor Op</label>
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
    <%--EDITAR--%>
    <%--<div class="modal fade" data-backdrop="static" data-keyboard="false" id="EditUsuariosModal" tabindex="-1" role="dialog" aria-labelledby="EditUsuariosModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelEditarUsuarios">Editar Usuarios</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal" id="EditarUsuariosForm"></form>


            </div>
        </div>
    </div>--%>
    <%--EDITAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="EditarUsuariosModal" tabindex="-1" role="dialog" aria-labelledby="EditarUsuariosModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelEditarUsuarios">Editar Usuario</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">

                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Nombre</label>
                                <input type="text" class="form-control" placeholder="Nombre completo" id="txtNombreCompletoEditar" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Correo</label>
                                <input type="email" class="form-control" placeholder="Correo" id="txtCorreoUsuarioEditar" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Teléfono</label>
                                <input type="tel" class="form-control" placeholder="Teléfono" id="txtTelefonoUsuariosEditar" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Salario</label>
                                <input type="number" class="form-control" id="txtSalarioUsuarioEditar" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Usuario</label>
                                <input type="text" class="form-control" placeholder="Usuario" id="txtUsuarioEditar" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Clave</label>
                                <input type="password" class="form-control" placeholder="Clave" id="txtClaveUsuarioEditar" minlengh="8" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Tipo de usuario</label>
                                <select id="slctTipoEditar" class="form-control" required>
                                    <option value="VENTAS">Ventas</option>
                                    <option value="COMPRAS">Compras</option>
                                    <option value="ADMINISTRACION">Administracion</option>
                                    <option value="CLIENTE">Cliente</option>
                                    <option value="COORDINADOR">Coordinador</option>
                                    <option value="GERENCIAL">Gerencia</option>
                                    <option value="SISTEMAS">Sistemas</option>
                                    <option value="ROOT">ROOT</option>
                                    <option value="AYUDANTE">Ayudante</option>
                                    <option value="SUPERVISOR">Supervisor</option>
                                    <option value="SEGURIDAD">Seguridad</option>
                                    <option value="CONTROL">Control</option>
                                    <option value="MAQUINADO">Maquinado</option>
                                    <option value="DISENO">Diseño</option>

                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <div class="panel-group">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">SUCURSAL</div>
                                        <div class="panel-body">
                                            <label class="checkbox-inline">
                                                <input type="checkbox" id="chkSucursalCuautitlan">
                                                Cuautitlan
                                            </label>
                                            <label class="checkbox-inline">
                                                <input type="checkbox" id="chkSucursalChihuahua">
                                                Chihuahua
                                            </label>
                                            <label class="checkbox-inline">
                                                <input type="checkbox" id="chkSucursalUsa">
                                                Estados Unidos
                                            </label>
                                            <label class="checkbox-inline">
                                                <input type="checkbox" id="chkSucursalHermosillo">
                                                Hermosillo
                                            </label>
                                            <label class="checkbox-inline">
                                                <input type="checkbox" id="chkSucursalIrapuato">
                                                Irapuato
                                            </label>
                                            <label class="checkbox-inline">
                                                <input type="checkbox" id="chkSucursalQueretaro">
                                                Queretaro
                                            </label>
                                            <label class="checkbox-inline">
                                                <input type="checkbox" id="chkSucursalTecate">
                                                Tecate
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <%--<label>Sucursal</label>
                                <select id="slctSucursalUsuarioEditar" class="form-control"></select>--%>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <select id="pEstatus" class="form-control" required> 
                                    <option value="1">ACTIVO</option> 
                                    <option value="0">INACTIVO</option> 
                                </select> 
                            </div> 
                        </div> 
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkEsCCM">
                                    Es CCM?
                                </label>
                            </div>
                        </div>
                        <div class="form-group" id="dvPuestoCCM">
                            <div class="col-sm-10">
                                <label>Puesto CCM</label>
                                <select id="slctPuestoCCM" class="form-control" required>
                                    <option value="GERENCIA">Gerencia</option>
                                    <option value="ESPECIALISTA">Especialista</option>
                                    <option value="PM">Project Manager</option>
                                    <option value="SEGURIDAD">Seguridad</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-group" id="dvAreaCCM">
                            <div class="col-sm-10">
                                <label>Area CCM</label>
                                <select id="slctAreaCCM" class="form-control"></select>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Cliente Empresa</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliEmpVerEditar">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliEmpAddEditar">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliEmpEditEditar">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliEmpDelEditar">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Cliente Contácto</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliConVerEditar">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliConAddEditar">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliConEditEditar">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCliConDelEditar">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">RFQ</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRFQVerEditar">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRFQAddEditar">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRFQEditEditar">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRFQDelEditar">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Cotizaciones</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCotVerEditar">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCotAddEditar">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCotEditEditar">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCotDelEditar">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Materiales</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkMatVerEditar">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkMatAddEditar">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkMatEditEditar">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkMatDelEditar">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Proveedores</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProvVerEditar">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProvAddEditar">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProvEditEditar">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProvDelEditar">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Requisiciones</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRequiVerEditar">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRequiAddEditar">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRequiEditEditar">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRequiDelEditar">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Orden Compra</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkOCVerEditar">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkOCAddEditar">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkOCEditEditar">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkOCDelEditar">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Viaticos</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkViaVerEditar">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkViaAddEditar">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkViaEditEditar">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkViaDelEditar">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Proyectos</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProyVerEditar">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProyAddEditar">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProyEditEditar">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkProyDelEditar">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Caja chica</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaVerEditar">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaAddEditar">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaEditEditar">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaDelEditar">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Caja chica Sucursal</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaCuautitlanEditar">
                                    Cuautitlan
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaChihuahuaEditar">
                                    Chihuahua
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaUSAEditar">
                                    USA
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaIrapuatoEditar">
                                    Irapuato
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaQueretaroEditar">
                                    Queretaro
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCajaTecateEditar">
                                    Tecate
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Usuarios</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkUserVerEditar">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkUserAddEditar">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkUserEditEditar">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkUserDelEditar">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Sucursales</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkSucVerEditar">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkSucAddEditar">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkSucEditEditar">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkSucDelEditar">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Control Facturas</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFRVerEditar">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFRAddEditar">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFREditEditar">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFRDelEditar">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Facturas Emitidas</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFEVerEditar">
                                    Ver
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFEAddEditar">
                                    Agregar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFEEditEditar">
                                    Editar
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFEDelEditar">
                                    Eliminar
                                </label>
                            </div>
                        </div>
                        <%--<div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Control</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFacVer">
                                    Control Facturas
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkFacVerEmitidas">
                                    Facturas emitidas
                                </label>

                            </div>
                        </div>--%>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Documentos</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkDocsAddEditar">
                                    Documentos
                                </label>

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Administración</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkAdminVerEditar">
                                    Admin Proyectos</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkInventaAddEditar">
                                    Inventario</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkTimmEditEditar">
                                    Timming</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkBoletinesEditar">
                                    Boletines</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkModuloPOEditar">
                                    Modulo PO</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCostoIndirectoEditar">
                                    Costos Indirectos</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Servicios</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkCarroVerEditar">
                                    Carros
                                </label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkPCAddEditar">
                                    Compúto
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2" for="inputSuccess">Reportes</label>
                            <div class="col-lg-10">
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptOrdenCompraEditar">Orden Compra</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptFacturasRecibidasEditar">
                                    Facturas Recibidas</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptFacturasEmitidasEditar">
                                    Facturas Emitidas</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptProyectosEditar">
                                    Proyectos</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptCotizacionesEditar">
                                    Cotizaciones</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptProyectosGastosEditar">
                                    Proyectos y Gastos</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptProveedoresPagarEditar">
                                    Proveedores a Pagar</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptEficienciasEditar">
                                    Eficiencias</label>
                                <label class="checkbox-inline">
                                    <input type="checkbox" id="chkRptMonitorEditar">
                                    Monitor Op</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <div class="form-group" id="AddMsgUsuariosEditar">
                                    <%--<label id="txtMensajeDatos"></label>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-primary" id="btnModificarUsuarios" type="button">Modificar</button>
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
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/Usuarios.js" type="text/javascript" ></script>
</asp:Content>





