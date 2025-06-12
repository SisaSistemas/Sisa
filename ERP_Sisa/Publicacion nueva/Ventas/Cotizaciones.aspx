<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cotizaciones.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Ventas.Cotizaciones" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <script>
        function EliminarCotizacion(btn) {
            document.getElementById('idCotizacionesEliminar').textContent = '';
            document.getElementById('idCotizacionesEliminarTexto').textContent = '¿Estás seguro de eliminar cotización con código "' + btn.value + '"?';
            document.getElementById('idCotizacionesEliminar').textContent = btn.value;
            $("#DelCotizacionesModal").modal();
        }
        function CancelarCotizacion(btn) {
            document.getElementById('idCotizacionCancelar').textContent = '';
            document.getElementById('idCotizacionCancelarTexto').textContent = '¿Estás seguro de cancelar Cotizacion con código "' + btn.value + '" ?';
            document.getElementById('idCotizacionCancelar').textContent = btn.value;
            $("#CancelarCotizacionModal").modal();
        }

        function AgregarComentario(btn) {

            document.getElementById('idCotizacionComentario').textContent = btn.value;
            var params = "{'pid': '" + btn.value + "'}";
            $.ajax({
                async: true,
                url: "Cotizaciones.aspx/CargarComentarios",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {

                    var datos = "";
                    var nodoTRAgregar = "";

                    var JsonCombos;
                    var jsonArray = $.parseJSON(data.d);

                    $('#TablaPrincipalComentariosCotizacion tbody').html('');
                    $.each(jsonArray, function (index, value) {
                        nodoTRAgregar += "<tr>";
                        nodoTRAgregar += '  <td style="display: none;">' + value.IdCotizacion + "</td>";
                        nodoTRAgregar += "  <td>" + value.Comentario + "</td>";
                        nodoTRAgregar += "  <td>" + value.NombreCompleto + "</td>";
                        nodoTRAgregar += "  <td>" + value.Fecha + "</td>";
                        nodoTRAgregar += "</tr>";
                    });

                    $('#TablaPrincipalComentariosCotizacion tbody').append(nodoTRAgregar);
                }
            });
            $("#dvComentarios").modal();
        }
        function NuevaCotizacion(btn) {
            window.open("CotizacionesDetalles.aspx?idCotizacion=0&idSolicitud=0");
        }

        function EditarCotizacion(btn) {
            $(btn).attr('rel');
            window.open("CotizacionesDetalles.aspx?idCotizacion=" + btn.value + "&idSolicitud=" + $(btn).attr('rel'));
        }

        function PDFCotizacion(btn) {
            //var folio = document.getElementById('NombreOrden').value;
            //window.open("ReporteCotizacion.aspx?idCotizacion=" + btn.value + "&NombreOrden=" + folio);
            $('#testmodalpdfCot').html('');

            var params = "{'id': '" + btn.value +
                "','Opcion': '" + "Cot" + "'}";

            $.ajax({
                async: true,
                url: "Cotizaciones.aspx/CargarDocumentos",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {
                    var datos = "";

                    var JsonCombos;
                    var jsonArray = $.parseJSON(data.d);


                    $.each(jsonArray, function (index, value) {
                        if (value.Nombre == '') {
                            swal('No hay archivo de pdf');
                            return;
                        }
                        document.getElementById('txtTipoDocumentoCot').textContent = "Cot";
                        //$('#testmodalpdfCot').append('<embed src="' + value.Archivo + '" type="application/pdf" width="100%" height="600px" />');
                        document.getElementById('txtidArchivoCot').textContent = value.IdCotizaciones;
                        //$('#testmodalpdfCot').append('<object id="visorPDF" data="' + value.Archivo + '" type="application/pdf" style="width:100%; height: 800px;"></object>');

                        window.open("docs/" + value.Nombre);
                        //window.location.href = value.Archivo;
                    });
                }
            });
            //$("#dvPDFCot").modal();
        }

        function ExcelCotizacion(btn) {
            //var folio = document.getElementById('NombreOrden').value;
            //window.open("ReporteCotizacion.aspx?idCotizacion=" + btn.value + "&NombreOrden=" + folio);
            $('#testmodalpdfCot').html('');

            var params = "{'id': '" + btn.value +
                "','Opcion': '" + "Cot" + "'}";

            $.ajax({
                async: true,
                url: "Cotizaciones.aspx/CargarDocumentosExcel",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {
                    var datos = "";

                    var JsonCombos;
                    var jsonArray = $.parseJSON(data.d);


                    $.each(jsonArray, function (index, value) {
                        if (value.Nombre == '') {
                            swal('No hay archivo excel');
                            return;
                        }
                        document.getElementById('txtTipoDocumentoCot').textContent = "Cot";
                        //$('#testmodalpdfCot').append('<embed src="' + value.Archivo + '" type="application/pdf" width="100%" height="600px" />');
                        document.getElementById('txtidArchivoCot').textContent = value.IdCotizaciones;
                        //$('#testmodalpdfCot').append('<object id="visorPDF" data="' + value.Archivo + '" type="application/pdf" style="width:100%; height: 800px;"></object>');

                        window.open("docs/" + value.Nombre);
                        //window.location.href = value.Archivo;
                    });
                }
            });
            //$("#dvPDFCot").modal();
        }

        function EnviarCotizacion(btn) {
            window.open('../Administracion/EnviarCorreo.aspx?id=' + btn.value + '&Tipo=2');
        }

        function ConvertirProyecto(btn) {
           
            document.getElementById('idCotizacionesConvertir').textContent = '';
            document.getElementById('idCotizacionesConvertir').textContent = btn.value;

            CargarComboUsuarios();
            CargarSucursales();
            CargarMontosCotizacion(btn.value);
            document.getElementById('txtModalConvertirCotizaciones').textContent = '';
            document.getElementById('txtModalConvertirCotizaciones').textContent = '¿Estás seguro de convertir cotización con folio "' + $(btn).attr('rel') + '"?';

            $("#ConvCotizacionesModal").modal();
        }
        function CargarMontosCotizacion(id) {
            var params = "{'pid': '" + id + "'}";

            $.ajax({
                dataType: 'json',
                async: true,
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                url: 'Cotizaciones.aspx/CargarMontosCotizacion',
                data: params,
                success: function (data, textStatus) {
                    var json = $.parseJSON(data.d);
                    $.each(json, function (index, value) {
                        var a = formato_numero(value.CostoMOCotizado, 2, '.', ',');
                        var b = formato_numero(value.CostoMECotizado, 2, '.', ',');
                        var c = formato_numero(value.CostoMaterialCotizado, 2, '.', ',');
                        $('#txtCostoMOCotizado').val(a);
                        $('#txtCostoMECotizado').val(b);
                        $('#txtCostoMaterialCotizado').val(c);
                        $('#txtCostoMOProyectado').val(formato_numero('0', '.', ','));
                        $('#txtCostoMEProyectado').val(formato_numero('0', '.', ','));
                        $('#txtCostoMaterialProyectado').val(formato_numero('0', '.', ','));
                    });
                }
            });

        }
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
                    $('#cmbUsuarioLider').html('<option value="-1">-- Selecciona lider de proyecto --</option>');
                    $.each(json, function (index, value) {
                        $("#cmbUsuarioLider").append('<option value="' + value.Id + '" rel="' + value.Correo + '">' + value.Nombre.toUpperCase() + '</option>');
                    });
                    $('#cmbUsuarioLider').selectpicker('refresh');
                    $('#cmbUsuarioLider').selectpicker('render');
                }
            });
            var params2 = "{'pid': '" + document.getElementById('idCotizacionesConvertir').textContent + "'}";

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

        function CargarSucursales() {
            var params = "{'Opcion': '18'}";

            $.ajax({
                dataType: 'json',
                async: true,
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                url: 'Cotizaciones.aspx/CargarCombos',
                data: params,
                success: function (data, textStatus) {

                    var json = $.parseJSON(data.d);

                    $('#cmbSucursal').html('');
                    $('#cmbSucursal').html('<option value="-1">-- Selecciona Sucursal --</option>');
                    $.each(json, function (index, value) {
                        $("#cmbSucursal").append('<option value="' + value.Id + '" rel="' + value.Correo + '">' + value.Nombre.toUpperCase() + '</option>');
                    });
                    $('#cmbSucursal').selectpicker('refresh');
                    $('#cmbSucursal').selectpicker('render');
                }
            });
            

        }

        function Archivos(btn) {
            var idCotizacion = btn.value;

            swal.setDefaults({
                input: 'file',
                allowOutsideClick: false,
                allowEnterKey: false,
                allowEscapeKey: false,
                showCloseButton: true,
                confirmButtonText: 'Next &rarr;',
                showCancelButton: true,
                progressSteps: ['1', '2']
            });

            var steps = [
                {
                    title: 'Seleccione Cotización (Excel)',
                    //inputAttributes: {
                    //    //'accept': 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
                    //    'accept': 'application/vnd.ms-excel'
                    //}
                },
                {
                    title: 'Seleccione Cotización (Pdf)',
                    inputAttributes: {
                        'accept': 'application/pdf'
                    }
                }
            ];

            swal.queue(steps).then(function (result) {
                swal.resetDefaults();

                var items = 0, item = 0;
                var cont = 0;
                $.each(result, function (i, val) {
                    if (result[cont]) {
                        items++;
                    }
                    cont++;
                });
                if (items == 0) {
                    swal("No se encontraron archivos...");
                    return;
                }
                cont = 0;
                $.each(result, function (i, val) {
                    if (val) {
                        var nombreArchivo = val.name;
                        var reader = new FileReader
                        reader.onload = function (e) {
                            var params = "{'IdCotizacion': '" + idCotizacion +
                                "','NombreArchivo': '" + nombreArchivo +
                                "','Documento': '" + e.target.result + "'}";

                            //console.log(params);
                            $.ajax({
                                dataType: "json",
                                async: true,
                                url: "Cotizaciones.aspx/GuardarArchivo",
                                data: params,
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data, textStatus) {
                                    //location.href = './frmProjects.aspx';
                                    item++;

                                    if (items == item) {
                                        swal({
                                            title: 'Se adjuntaron correctamente los archivos!'
                                        });
                                    }

                                },
                                error: function (xhr, ajaxOptions, thrownError) {
                                    swal({
                                        title: 'Ocurrio un error, intenta de nuevo.'
                                    });
                                }
                            });
                        };

                        reader.readAsDataURL(val);
                    }

                });

            }, function () {
                swal.resetDefaults();
            });
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
                        <div class="form-group" id="CargandoCotizaciones">
                            <%--<label id="txtMensajeDatos"></label>--%>
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
                                        <%--<th><i class="icon_creditcard"></i>Costo</th>--%>
                                        <th><i class="icon_ribbon_alt"></i>Estatus</th>
                                        <th><i class="icon_ribbon_profile"></i>Hecha Por</th>
                                        <th><i class="icon_ribbon_profile"></i>Enviada Por</th>
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
                        </div>
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

                            <div class="col-sm-10">
                                <label>Sucursal</label>
                                <select class="form-control selectpicker" data-live-search="true" id="cmbSucursal"></select>
                            </div>
                        
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
                                <input type="text" class="form-control" id="txtFolioPO" placeholder="Folio PO">
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