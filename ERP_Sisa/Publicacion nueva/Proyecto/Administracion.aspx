<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Proyectos.Administracion" %>


<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <script>
        function AgregarOC(btn) {
            swal({
                title: 'Seleccione OC',
                input: 'file',
                allowOutsideClick: false,
                allowEscapeKey: false,
                allowEnterKey: false,
                showCloseButton: true
            }).then(function (file) {
                var nombreArchivo = file.name;
                var reader = new FileReader
                reader.onload = function (e) {
                    //debugger;
                    //console.log(nombreArchivo);

                    //var params = "{'IdCotizacion': '" + idCotizacion +
                    //    "','NombreArchivo': '" + nombreArchivo +
                    //    "','Documento': '" + e.target.result + "'}";

                    var params = "{'TipoDoc': '" + '1' +
                        "','IdProyecto': '" + btn.value +
                        "','FileName': '" + nombreArchivo +
                        "','File': '" + e.target.result + "'}";

                    //console.log(params);
                    $.ajax({
                        dataType: "json",
                        async: true,
                        url: "Administracion.aspx/GuardarDocumentos",
                        data: params,
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (msg) {
                            //location.href = './frmProjects.aspx';

                            swal({
                                title: msg.d,
                                timer: 3000
                            });

                            //cargarArchivos();
                        },
                        error: function (xhr, ajaxOptions, thrownError) {

                        }
                    });


                }

                reader.readAsDataURL(file);

            });
        }

        function AgregarCL(btn) {
            swal({
                title: 'Seleccione CL',
                input: 'file',
                allowOutsideClick: false,
                allowEscapeKey: false,
                allowEnterKey: false,
                showCloseButton: true
            }).then(function (file) {
                var nombreArchivo = file.name;
                var reader = new FileReader
                reader.onload = function (e) {
                    //debugger;
                    //console.log(nombreArchivo);

                    //var params = "{'IdCotizacion': '" + idCotizacion +
                    //    "','NombreArchivo': '" + nombreArchivo +
                    //    "','Documento': '" + e.target.result + "'}";

                    var params = "{'TipoDoc': '" + '2' +
                        "','IdProyecto': '" + btn.value +
                        "','FileName': '" + nombreArchivo +
                        "','File': '" + e.target.result + "'}";

                    //console.log(params);
                    $.ajax({
                        dataType: "json",
                        async: true,
                        url: "Administracion.aspx/GuardarDocumentos",
                        data: params,
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (msg) {
                            //location.href = './frmProjects.aspx';

                            swal({
                                title: msg.d,
                                timer: 3000
                            });

                            //cargarArchivos();
                        },
                        error: function (xhr, ajaxOptions, thrownError) {

                        }
                    });


                }

                reader.readAsDataURL(file);

            });
        }

        function AbriGrafica(btn) {
            window.open("ProyectoDetallesAdmin.aspx?id=" + btn.value);
        }

        function HorasHombre(btn) {
            window.open("ProyectoHorasHombre.aspx?id=" + btn.value);

        }

        function CambiarEstatus(btn) {
            document.getElementById('idProyectosEstatus').textContent = '';
            document.getElementById('idProyectosEstatusTexto').textContent = '¿Estás seguro de actualizar estatus de proyecto con Folio "' + $(btn).attr('rel')  + '"?';
            document.getElementById('idProyectosEstatus').textContent = btn.value;
            $("#CambiarEstatus").modal();

        }

        function EditarGastos(btn) {
            CargarGastos(btn.value);
            document.getElementById('idProyectosGastos').textContent = '';
            document.getElementById('idProyectosGastosTexto').textContent = '¿Estás seguro de actualizar gastos de proyecto con Folio "' + $(btn).attr('rel')  + '"?';
            document.getElementById('idProyectosGastos').textContent = btn.value;
            $("#CambiarGastos").modal();
        }

        function CargarGastos(id) {
            var params = "{'pid': '" + id + "'}";

            $.ajax({
                dataType: 'json',
                async: true,
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                url: 'Administracion.aspx/CargarGastos',
                data: params,
                success: function (data, textStatus) {
                    ;
                    var json = $.parseJSON(data.d);

                    $('#cmbLiderProyecto').html('');
                    $.each(json, function (index, value) {
                        $('#txtMOProyectado').val(formato_numero(value.CostoMOProyectado, 2, '.', ','));
                        $('#txtCostoMaterialProyectado').val(formato_numero(value.CostoMaterialProyectado, 2, '.', ','));
                        $('#txtCEProyectado').val(formato_numero(value.CostoMEProyectado, 2, '.', ','));

                        $('#txtMOCotizado').val(formato_numero(value.CostoMOCotizado, 2, '.', ','));
                        $('#txtCostoMaterialCotizado').val(formato_numero(value.CostoMaterialCotizado, 2, '.', ','));
                        $('#txtCECotizado').val(formato_numero(value.CostoMECotizado, 2, '.', ','));
                    });

                }
            });
        }

        function CambiarMonto(btn) {
            
            document.getElementById('idProyectosMonto').textContent = '';
            document.getElementById('idProyectosMontoTexto').textContent = '¿Estás seguro de actualizar monto de proyecto con Folio "' + $(btn).attr('rel')  + '"?';
            document.getElementById('idProyectosMonto').textContent = btn.value;
            $("#CambiarMonto").modal();

        }

        function CambiarLider(btn) {
            
            var folnom = $(btn).attr('data-subtext').split("&_");
            
            var idLider = $(btn).attr('name');
            var folioPO = folnom[1];
            var nombreProyecto = folnom[0];
            var idSucursal = folnom[2];
            
            console.log(idSucursal);
            CargarSucursal(idSucursal);
            CargarLideres(idLider);
            document.getElementById('idProyectosLider').textContent = '';
            document.getElementById('idProyectosLiderTexto').textContent = '¿Estás seguro de actualizar Lider de proyecto con Folio "' + $(btn).attr('rel')  + '"?';
            document.getElementById('idProyectosLider').textContent = btn.value;

            document.getElementById('txtNombreProyecto').value = nombreProyecto;
            document.getElementById('txtFolioPO').value = folioPO;

            $("#CambiarLider").modal();

        }

        function TerminarProyecto(btn) {
            document.getElementById('idProyectosFinalizar').textContent = '';
            document.getElementById('idProyectosFinalizarTexto').textContent = '¿Estás seguro de cambiar estatus de proyecto con Folio "' + $(btn).attr('rel') + '"?';
            document.getElementById('idProyectosFinalizar').textContent = btn.value;
            $("#FinalizarProyecto").modal();
        }

        function AvanceProyecto(btn) {
            document.getElementById('idProyectosAvance').textContent = '';
            document.getElementById('idProyectosAvanceTexto').textContent = '¿Estás seguro de actualizar avance de proyecto con Folio "' + $(btn).attr('rel') + '"?';
            document.getElementById('idProyectosAvance').textContent = btn.value;
            $("#AvanceProyecto").modal();
        }

        function CargarLideres(lider) {
            var params = "{'Opcion': '1'}";

            $.ajax({
                dataType: 'json',
                async: true,
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                url: 'Administracion.aspx/CargarCombos',
                data: params,
                success: function (data, textStatus) {
                    
                    var json = $.parseJSON(data.d);

                    $('#cmbLiderProyecto').html('');
                    $.each(json, function (index, value) {
                        $("#cmbLiderProyecto").append("<option value=" + value.Id + ">" + value.Nombre.toUpperCase() + "</option>");
                    });

                    //$('#cmbLiderProyecto').selectpicker('refresh');
                    //$('#cmbLiderProyecto').selectpicker('render');
                    
                    $('#cmbLiderProyecto').val(lider);
                    $('#cmbLiderProyecto').selectpicker('refresh');

                }
            });
        }

        function CargarSucursal(sucursal) {
            var params = "{'Opcion': '18'}";

            $.ajax({
                dataType: 'json',
                async: true,
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                url: 'Administracion.aspx/CargarCombos',
                data: params,
                success: function (data, textStatus) {

                    var json = $.parseJSON(data.d);

                    $('#cmbSucursalProyecto').html('');
                    $.each(json, function (index, value) {
                        $("#cmbSucursalProyecto").append("<option value=" + value.Id + ">" + value.Nombre.toUpperCase() + "</option>");
                    });

                    //$('#cmbLiderProyecto').selectpicker('refresh');
                    //$('#cmbLiderProyecto').selectpicker('render');

                    $('#cmbSucursalProyecto').val(sucursal);
                    $('#cmbSucursalProyecto').selectpicker('refresh');

                }
            });
        }

        function VisualizarDocumentoOC(btn) {
            $('#testmodalpdf').html('');

            var params = "{'IdProyecto': '" + btn.value +
                "','Opcion': '" + "OC" + "'}";

            $.ajax({
                async: true,
                url: "Administracion.aspx/CargarDocumentos",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {
                    var datos = "";

                    var JsonCombos;
                    var jsonArray = $.parseJSON(data.d);


                    $.each(jsonArray, function (index, value) {
                        document.getElementById('txtTipoDocumento').textContent = "OC";

                        document.getElementById('txtidProyectoArchivo').textContent = value.IdProyecto;
                        $('#testmodalpdf').append('<object id="visorPDF" data="' + value.ArchivoOC + '" type="application/pdf" style="width:100%; height: 800px;"></object>');
                    });
                }
            });
            $("#dvPDF").modal();
        }

        function VisualizarDocumentoCL(btn) {
            $('#testmodalpdf').html('');
            var params = "{'IdProyecto': '" + btn.value +
                "','Opcion': '" + "CL" + "'}";
            //console.log(params);

            $.ajax({
                async: true,
                url: "Administracion.aspx/CargarDocumentos",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {
                    //debugger;
                    var datos = "";

                    var JsonCombos;
                    var jsonArray = $.parseJSON(data.d);


                    $.each(jsonArray, function (index, value) {
                        document.getElementById('txtidProyectoArchivo').textContent = value.IdProyecto;
                        document.getElementById('txtTipoDocumento').textContent = "CL";
                        $('#testmodalpdf').append('<object id="visorPDF" data="' + value.ArchivoCL + '" type="application/pdf" style="width:100%; height: 800px;"></object>');
                    });
                }
            });
            $("#dvPDF").modal();
        }

        function EditarProyectoFechas(btn) {

            document.getElementById('idProyectoFechas').textContent = btn.value;
            var params = "{'pid': '" + btn.value + "'}";
            $.ajax({
                async: true,
                url: "Proyectos.aspx/ObtenerFechas",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {

                    var jsonArray = $.parseJSON(data.d);
                    $.each(jsonArray, function (index, value) {
                        $('#dtFechaInicio').val(value.FechaInicio.substring(0, 10));
                        $('#dtFechaTermino').val(value.FechaFin.substring(0, 10));
                    });

                }
            });
            $("#dvCambiarFechas").modal();
        }

        function CancelarProyecto(btn) {
            document.getElementById('idProyectosCancelar').textContent = '';
            document.getElementById('idProyectosCancelarTexto').textContent = '¿Estás seguro de Cancelar proyecto con Folio "' + $(btn).attr('rel')  + '"?';
            document.getElementById('idProyectosCancelar').textContent = btn.value;
            $("#CancelarProyectosModal").modal();
        }

        function AgregarComentario(btn) {

            document.getElementById('idProyectoComentario').textContent = btn.value;
            var params = "{'pid': '" + btn.value + "'}";
            $.ajax({
                async: true,
                url: "Administracion.aspx/CargarComentarios",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {

                    var datos = "";
                    var nodoTRAgregar = "";

                    var JsonCombos;
                    var jsonArray = $.parseJSON(data.d);

                    $('#TablaPrincipalComentariosProyectos tbody').html('');
                    $.each(jsonArray, function (index, value) {
                        nodoTRAgregar += "<tr>";
                        nodoTRAgregar += '  <td style="display: none;">' + value.IdProyecto + "</td>";
                        nodoTRAgregar += "  <td>" + value.Comentario + "</td>";
                        nodoTRAgregar += "  <td>" + value.NombreCompleto + "</td>";
                        nodoTRAgregar += "  <td>" + value.Fecha.substring(0, 10) + "</td>";
                        nodoTRAgregar += "</tr>";
                    });

                    $('#TablaPrincipalComentariosProyectos tbody').append(nodoTRAgregar);
                }
            });
            $("#dvComentarios").modal();
        }

        (function (document) {
            'use strict';

            var LightTableFilter = (function (Arr) {

                var _input;

                function _onInputEvent(e) {
                    _input = e.target;
                    var tables = document.getElementsByClassName(_input.getAttribute('data-table'));
                    Arr.forEach.call(tables, function (table) {
                        Arr.forEach.call(table.tBodies, function (tbody) {
                            Arr.forEach.call(tbody.rows, _filter);
                        });
                    });
                }

                function _filter(row) {
                    var text = row.textContent.toLowerCase(), val = _input.value.toLowerCase();
                    row.style.display = text.indexOf(val) === -1 ? 'none' : 'table-row';
                }

                return {
                    init: function () {
                        var inputs = document.getElementsByClassName('light-table-filter');
                        Arr.forEach.call(inputs, function (input) {
                            input.oninput = _onInputEvent;
                        });
                    }
                };
            })(Array.prototype);

            document.addEventListener('readystatechange', function () {
                if (document.readyState === 'complete') {
                    LightTableFilter.init();
                }
            });

        })(document);
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
                        <li><i class="icon_building"></i>Proyectos</li>
                    </ol>
                </div>
            </div>
            <!-- page start-->
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div class="form-group" id="MensajeAdministracion">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>
                        <table class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>
                                    <th colspan="4" style="text-align: right;">TOTAL PROYECTOS SIN ORDEN DE COMPRA</th>
                                    <td><span id="lblProyectosSinPO">$ 123,456</span></td>
                                </tr>
                                <tr>
                                    <th colspan="4" style="text-align: right;">TOTAL PROYECTOS FACTURADOS</th>
                                    <td><span id="lblProyectoFacturado">$ 123,456</span></td>
                                </tr>
                                <tr>
                                    <th colspan="4" style="text-align: right;">TOTAL EN OC SIN FACTURA</th>
                                    <td><span id="lblProyectoSinFactura">$ 123,456</span></td>
                                </tr>
                            </thead>

                        </table>
                        <%--<header class="panel-heading">
                            Lista de Proyectos --%>
                  <%--<div class="btn-group" id="botones">
                      <form class="form-inline">


                           <div class="form-group">
                                <div id="busquedaProyectos" >
                                    <br />
                                 
                                    Proyecto
                                    <select class="form-control selectpicker" data-live-search="true" id="cmbProyectoBuscar"></select>
                                  
                                    Contacto
                                    <select class="form-control selectpicker" data-live-search="true" id="cmbContactoBuscar"></select>
                                    Empresa
                                    <select class="form-control selectpicker" data-live-search="true" id="cmbEmpresaBuscar"></select>
                                    Lider
                                    <select class="form-control selectpicker" data-live-search="true" id="cmbLiderBuscar"></select>
                                    Sucursal
                                    <select class="form-control selectpicker" data-live-search="true" id="cmbSucursalBuscar"></select>
                                    Fecha Inicio
                                    <input type="date" class="form-control" id="dtFechaInicioBuscar" placeholder="Fecha de Inicio" />
                                    Fecha termino
                                    <input type="date" class="form-control" id="dtFechaFinBuscar" placeholder="Fecha de Fin" />
                                    Estatus
                                    <select id="cmbEstatusProyectos" class="form-control" style="width: 150px;">
                                        <option value="-1">TODOS</option>
                                        <option value="0">PENDIENTE</option>
                                        <option value="1">POR INICIAR</option>
                                        <option value="2">EN PROCESO</option>
                                        <option value="3">TERMINADO</option>
                                        <option value="4">CANCELADO</option>
                                    </select>
                                    OC
                                    <select id="cmbOCBuscar" class="form-control" style="width: 150px;">
                                        <option value="-1">TODOS</option>
                                        <option value="0">SIN ORDEN DE COMPRA</option>
                                        <option value="1">CON ORDEN DE COMPRA</option>
                                    </select>
                                    CL
                                    <select id="cmbCLBuscar" class="form-control" style="width: 150px;">
                                        <option value="-1">TODOS</option>
                                        <option value="0">SIN CARTA DE LIBERACION</option>
                                        <option value="1">CON CARTA DE LIBERACION</option>
                                    </select>
                                    <button class="btn btn-danger" id="btnBuscarProyectos" type="button">Buscar.</button>
                                </div>
                            </div>
                      </form>
                  </div>--%>
                    <header class="panel-heading">
                        Lista de Proyectos 
                        </header>
                        <div class="form-group" id="CargandoAdministracion">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>
                        <div style="overflow-x: auto; overflow-y: auto;">
                            <table class="table table-advance table-hover order-table" id="TablaAdministracion">
                                <thead>
                                    <tr>
                                        <th style="display: none;"><i class="icon_building"></i>Código</th>
                                        <th><i class="icon_building"></i>Folio</th>
                                        <th><i class="icon_building"></i>Proyecto</th>
                                        <th><i class="icon_building"></i>Folio PO</th>
                                        <th><i class="icon_profile"></i>Contacto</th>
                                        <th><i class="icon_building"></i>Empresa</th>
                                        <th><i class="icon_profile"></i>Lider</th>
                                        <th><i class="icon_building"></i>Sucursal</th>
                                        <th><i class="icon_tag_alt"></i>Fecha inicio</th>
                                        <th><i class="icon_tag_alt"></i>Fecha termino</th>
                                        <th><i class="icon_loading"></i>Estatus</th>
                                        <%-- <th><i class="icon_currency"></i>Mano de obra</th>                      
                    <th><i class="icon_currency"></i>Material</th>                      
                    <th><i class="icon_currency"></i>Equipo</th>  --%>
                                        <th><i class="icon_documents_alt"></i>OC</th>
                                        <th><i class="icon_documents_alt"></i>CL</th>
                                        <th><i class="icon_currency"></i>FC</th>
                                        <th><i class="icon_currency"></i>Pagado</th>
                                        <th><i class="icon_ol"></i>Acciones</th>
                                        <th></th>
                                        <th style="display: none;"></th>
                                        <th style="display: none;"></th>
                                    </tr>
                                </thead>
                                <tbody id="listaAdministracion">
                                </tbody>
                            </table>
                        </div>
                        <div class="col-md-12 text-center">
                            <ul class="pagination pagination-lg pager" id="myPagerProy2"></ul>
                        </div>
                    </section>
                </div>
            </div>
            <!-- page end-->
        </section>
    </section>
    <%--AGREGAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddAdministracionModal" tabindex="-1" role="dialog" aria-labelledby="AddAdministracionModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelAgregarAdministracion">Agregar Administracion</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">

                        <div class="form-group">
                            <div class="col-sm-10">
                                <input type="text" class="form-control" placeholder="Ciudad" id="txtCiudadAdministracion" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <input type="text" class="form-control" placeholder="Dirección" id="txtDireccionAdministracion" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <input type="tel" class="form-control" placeholder="Teléfono" id="txtTelefonoAdministracion" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <div class="form-group" id="AddMsgAdministracion">
                                    <%--<label id="txtMensajeDatos"></label>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-primary" id="btnGuardarAdministracion" type="button">Crear</button>
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
                    <h4 class="modal-title" id="LabeldvPDFAdministracion">Agregar Administracion</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <label id="txtidProyectoArchivo" hidden="hidden"></label>
                        <label id="txtTipoDocumento" hidden="hidden"></label>
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
    <%--Cambiar estatus--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="CambiarEstatus" tabindex="-1" role="dialog" aria-labelledby="CambiarEstatus" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelEstatusAdministracion">Cambiar estatus de proyecto</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Selecciona estatus:</label>

                                <select id="cmbEstatusProyecto" class="form-control">
                                    <option value="1">POR INICIAR</option>
                                    <option value="2">EN PROCESO</option>

                                </select>
                            </div>

                        </div>
                        <label id="idProyectosEstatus" hidden="hidden"></label>
                        <label id="idProyectosEstatusTexto"></label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-info" id="btnCambiarEstatus" type="button">Cambiar estatus</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <%--FInalizar--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="FinalizarProyecto" tabindex="-1" role="dialog" aria-labelledby="FinalizarProyecto" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelFinalizarAdministracion">Agregar Administracion</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <label id="idProyectosFinalizar" hidden="hidden"></label>
                            <label id="idProyectosFinalizarTexto"></label>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-info" id="btnFinalizarProyecto" type="button">Finalizado</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--MONTO--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="CambiarMonto" tabindex="-1" role="dialog" aria-labelledby="CambiarMonto" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelMontoAdministracion">Cambiar Monto de proyecto</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Proporciona Monto: (sin comas, solo puntos decimales)</label>
                                <input type="text" id="cmbMontoProyecto" class="form-control" <%--onfocusout="CalculaIvaMonto()"--%> placeholder="Monto" />

                            </div>

                        </div>
                        <label id="idProyectosMonto" hidden="hidden"></label>
                        <label id="idProyectosMontoTexto"></label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-info" id="btnCambiarMonto" type="button">Cambiar Monto</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <%--Lider--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="CambiarLider" tabindex="-1" role="dialog" aria-labelledby="CambiarLider" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelLiderAdministracion">Cambiar Lider de proyecto</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Proporciona Lider:</label>
                                <select id="cmbLiderProyecto" class="form-control"></select>
                                <label>Nombre Proyecto:</label>
                                <input type="text" id="txtNombreProyecto" class="form-control" onkeyup="mayus(this);" />
                                <label>Folio PO:</label>
                                <input type="text" id="txtFolioPO" class="form-control" onkeyup="mayus(this);" />
                                <label>Sucursal:</label>
                                <select id="cmbSucursalProyecto" class="form-control"></select>
                            </div>

                        </div>
                        <label id="idProyectosLider" hidden="hidden"></label>
                        <label id="idProyectosLiderTexto"></label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-info" id="btnCambiarLider" type="button">Cambiar Lider</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <%--GASTOS--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="CambiarGastos" tabindex="-1" role="dialog" aria-labelledby="CambiarGastos" aria-hidden="true">
        <div class="modal-dialog" style="width: 75%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelGastosAdministracion">Cambiar información de proyección</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-6">
                                <section class="panel">
                                    <label>PROYECTO</label>
                                    <div class="panel-body">
                                        <label>Mano de obra:</label>
                                        <input type="text" class="form-control" id="txtMOProyectado" value="0" />
                                        <label>Costo de material:</label>
                                        <input type="text" class="form-control" id="txtCostoMaterialProyectado" value="0" />
                                        <label>Costo de equipo:</label>
                                        <input type="text" class="form-control" id="txtCEProyectado" value="0" />
                                    </div>
                                </section>
                            </div>
                            <div class="col-sm-6">
                                <section class="panel">
                                    <label>COTIZACIÓN</label>
                                    <div class="panel-body">
                                        <label>Mano de obra:</label>
                                        <input type="text" class="form-control" id="txtMOCotizado" value="0" />
                                        <label>Costo de material:</label>
                                        <input type="text" class="form-control" id="txtCostoMaterialCotizado" value="0" />
                                        <label>Costo de equipo:</label>
                                        <input type="text" class="form-control" id="txtCECotizado" value="0" />
                                    </div>
                                </section>
                            </div>
                        </div>



                        <label id="idProyectosGastos" hidden="hidden"></label>
                        <label id="idProyectosGastosTexto"></label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-info" id="btnCambiarGastos" type="button">Actualizar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvCambiarFechas" tabindex="-1" role="dialog" aria-labelledby="dvCambiarFechas" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelddvCambiarFechas">Cambio de fechas del proyecto</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="modal-body">
                            <label>Razón de cambio</label>
                            <input type="text" class="form-control" placeholder="Razón de cambio" id="txtRazonCambio" required />
                            <label>Fecha inicio</label>
                            <input type="date" class="form-control" id="dtFechaInicio" required />
                            <label>Fecha termino</label>
                            <input type="date" class="form-control" id="dtFechaTermino" required />
                            <label id="idProyectoFechas" hidden="hidden"></label>


                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="submit" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        <button type="submit" id="btnGuardarFechas" class="btn btn-success">Guardar cambios</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="CancelarProyectosModal" tabindex="-1" role="dialog" aria-labelledby="CancelarProyectosModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelCancelarProyectos">Cancelar Proyectos</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group" id="txtModalCancelarProyectos">
                            <label id="idProyectosCancelar" hidden="hidden"></label>
                            <label id="idProyectosCancelarTexto"></label>
                        </div>
                        <div class="form-group" id="txtModalCancelarMensajeProyectos">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-danger" id="btnCancelarProyectos" type="button">Cancelar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%--AVANCE %--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AvanceProyecto" tabindex="-1" role="dialog" aria-labelledby="CambiarMonto" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Cambiar Avance de proyecto</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Proporciona Monto: (sin comas, solo puntos decimales)</label>
                                <input type="text" id="txtAvanceProyecto" class="form-control" placeholder="Avance" />

                            </div>

                        </div>
                        <label id="idProyectosAvance" hidden="hidden"></label>
                        <label id="idProyectosAvanceTexto"></label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-info" id="btnCambiarAvance" type="button">Actualizar Avance</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

     <%--comentarios--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvComentarios" tabindex="-1" role="dialog" aria-labelledby="dvComentarios" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabeldvComentarios">Agregar comentario al proyecto</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="modal-body">
                            <div class="col-md-10 col-sm-10 col-xs-12 form-group has-feedback">
                                <input type="text" class="form-control has-feedback-left" id="txtComentarioProyecto" placeholder="Comentario">
                                <span class="fas fa-comment-dots form-control-feedback left" aria-hidden="true"></span>
                            </div>
                            <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback">
                                <span class="btn btn-success" id="btnAgregarComentarioProyectos"><i class="fa fa-plus"></i>Agregar</span>
                            </div>
                            <label id="idProyectoComentario" hidden="hidden"></label>
                            <div id="testmodalComentariosProyecto" style="padding: 5px 20px;">
                                <table id="TablaPrincipalComentariosProyectos" class="table table-striped projects">
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
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/Administracion.js" type="text/javascript"></script>

</asp:Content>






