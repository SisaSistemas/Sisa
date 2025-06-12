$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("Cotizaciones.aspx") > -1) {
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        //CargarCotizaciones();
        CargarCotizacionesNEW();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);

    }


    $('#btnAgregarComentarioCotizacion').click(function () {
        var id = document.getElementById('idCotizacionComentario').textContent;

        var params = "{'pid': '" + id + "', 'Comentario': '" + $('#txtComentario').val() + "'}";

        $.ajax({
            async: true,
            url: "Cotizaciones.aspx/GuardarComentarios",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                cargarComentariosCotizacion(id);

                $('#txtComentario').val('');
            }
        });
    });

    $('#btnEliminarCotizaciones').click(function () {
        var id = document.getElementById('idCotizacionesEliminar').textContent;

        var parametros = "{'pid': '" + id + "'}";
        $.ajax({
            dataType: "json",
            url: "Cotizaciones.aspx/EliminarCotizaciones",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Cotización eliminado.") {
                    //$("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarCotizaciones();
                    swal(msg.d);
                }
                else {
                    //$("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    function cargarComentariosCotizacion(id) {
        var params = "{'pid': '" + id + "'}";
        $.ajax({
            async: true,
            url: "Cotizaciones.aspx/CargarComentarios",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                var nodoTRAgregar = "";
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
    }

    $('#btnCancelarCotizacion').click(function () {
        var id = document.getElementById('idCotizacionCancelar').textContent;

        var parametros = "{'pid': '" + id + "'}";
        $.ajax({
            dataType: "json",
            url: "Cotizaciones.aspx/CancelarCotizacion",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Cotización cancelado.") {
                    //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarCotizaciones();
                    swal(msg.d);
                }
                else {
                    //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnConvertirCotizacion').click(function () {
        var id = document.getElementById('idCotizacionesConvertir').textContent;

        if ($('#cmbUsuarioLider').val() == '-1') {
            swal("Elige lider");
            return;
        }
        //if ($('#cmbSucursal').val() == '-1') {
        //    swal("Elige Sucursal");
        //    return;
        //}
        if ($('#cmbPO').val() == '-1') {
            swal("Elige Orden de Compra");
            return;
        }
        if ($('#txtConceptoProyecto').val() == '') {
            swal("Concepto del proyecto no porporcionado");
            return;
        }
        if ($('#dtInicial').val() == '') {
            swal("Elige fecha inicial");
            return;
        }
        if ($('#dtFinal').val() == '') {
            swal("Elige fecha final");
            return;
        }
        if ($('#txtNombreProyecto').val() == '') {
            swal("Nombre del proyecto no proporcionado");
            return;
        }
        else if ($('#txtNombreProyecto').val().lenght > 100) {
            swal("Nombre del proyecto proporcionado demasiado largo");
            return;
        }
        /*$("#ConvCotizacionesModal2").modal();*/
        var ContadorProyeccionProyectado = 0;
        if ($('#txtCostoMOProyectado').val() == '0' || $('#txtCostoMOProyectado').val() == '') {
            //swal("Ingresa cantidad de mano de obra..");
            //return;
            ContadorProyeccionProyectado++;
        }

        if ($('#txtCostoMaterialProyectado').val() == '0' || $('#txtCostoMaterialProyectado').val() == '') {
            //swal("Ingresa cantidad de materiales..");
            //return;
            ContadorProyeccionProyectado++;
        }

        if ($('#txtCostoMEProyectado').val() == '0' || $('#txtCostoMEProyectado').val() == '') {
            //swal("Ingresa cantidad de equipo..");
            //return;
            ContadorProyeccionProyectado++;
        }
        if (ContadorProyeccionProyectado == 3) {
            swal("Al menos un dato de proyección de costos del proyecto debe ser mayor a 0");
            return;
        }
        //if ($('#txtFolioPO').val() == '') {
        //    swal("Favor de introducir Folio PO");
        //    return;
        //}

        var chkEsCCM = $('#chkEsCCM').is(':checked');


        var parametros = "{'pid': '" + id + "', 'Concepto' : '" + $('#txtConceptoProyecto').val() + "', 'dtInicial':'" + $('#dtInicial').val() +
            "', 'dtFinal' : '" + $('#dtFinal').val() + "', 'idLider':'" + $('#cmbUsuarioLider').val() + "', 'Nombre':'" + $('#txtNombreProyecto').val() +
            "', 'MOC' : '" + $('#txtCostoMOCotizado').val() + "', 'MC':'" + $('#txtCostoMaterialCotizado').val() + "', 'MEC':'" + $('#txtCostoMECotizado').val() +
            "', 'MOP' : '" + $('#txtCostoMOProyectado').val() + "', 'MP':'" + $('#txtCostoMaterialProyectado').val() + "', 'MEP':'" + $('#txtCostoMEProyectado').val() +
            "', 'CorreoLider': '" + $('#cmbUsuarioLider option:selected').attr('rel') + "', 'Coordinador': '" + $('#cmbUsuarioLider option:selected').text() +
            //"', 'IdSucursal': '" + $('#cmbSucursal').val() +
            "', 'IdFolioPO': '" + $('#cmbPO').val() + "', 'FolioPO': '" + $('#cmbPO option:selected').attr('rel') +
            "', 'EsCCM': '" + chkEsCCM
            + "'}";

        //console.log(parametros);
        $.ajax({
            dataType: "json",
            url: "Cotizaciones.aspx/ConvertirCotizacion",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Cotización convertida.") {
                    CargarCotizaciones();

                    swal("Cotización convertida a proyecto exisotosamente.");
                }
                else {
                    swal("Ooops:" + msg.d);

                }
            }
        });
    });


});

function CargarCotizacionesNEW() {
    //$('tbody#listaOC').empty();
    //$('#myPager').html('');
    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "Cotizaciones.aspx/ObtenerCotizaciones",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            //debugger;
            var jsonArray = $.parseJSON(data.d);

            //$('#TablaOC').bootstrapTable('destroy');

            data = jsonArray;
            //debugger;
            $('#TablaCOT').bootstrapTable({
                data: data,
                detailView: false,
                striped: true,
                //pagination: true,
                //onlyInfoPagination: true,
                pageSize: 100,
                idField: 'IdCotizaciones',
                uniqueId: 'IdCotizaciones',
                onSearch: function (text) {
                    //CargarResumen(text);
                },
                onExpandRow: function (index, row, $detail) {
                    //$detail.hide().html(row.IdMaterial).fadeIn('slow');
                },
                onCollapseRow: function (index, row, $detail) {
                    $detail.clone().insertAfter($detail).fadeOut('slow', function () {
                        $(this).remove()
                    })
                }
            });

            //cargaPagosMultiplesPendientes();

        }
    });

}


function CargarCotizaciones() {
    $('tbody#listaCotizaciones').empty();
    $('#myPager').html('');
    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "Cotizaciones.aspx/ObtenerCotizaciones",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = JSON.parse(data.d);
                $(json).each(function (index, item) {
                    var idCotizaciones = json[index].IdCotizaciones;
                    var NoCotizaciones = json[index].NoCotizaciones;
                    var NoRequisicion = json[index].RFQ;
                    var FechaCotizaciones = json[index].FechaCotizaciones;
                    var RazonSocial = json[index].RazonSocial;
                    var NombreContacto = json[index].NombreContacto;
                    var Concepto = json[index].Concepto;
                    var CostoCotizaciones = json[index].CostoCotizaciones;
                    var HechaPor = json[index].HechaPor;
                    var EnviadaPor = json[index].EnviadaPor;
                    var VendidaPor = json[index].VendidaPor;
                    var Estatus = json[index].Estatus;

                    if (Estatus == 0) {
                        Estatus = "ELIMINADA";
                    } else if (Estatus == 1) {
                        Estatus = "CREADA";
                    } else if (Estatus == 2) {
                        Estatus = "CANCELADA";
                    } else if (Estatus == 3) {
                        Estatus = "GANADA";
                    } else if (Estatus == 4) {
                        Estatus = "ENVIADA";
                    } else if (Estatus == 5) {
                        Estatus = "PROYECTO";
                    }


                    $('tbody#listaCotizaciones').append(
                        '<tr><td style="display:none;">'
                        + idCotizaciones
                        + '</td>'
                        + '<td>'
                        + FechaCotizaciones.substring(0, 10)
                        + '</td>'
                        + '<td>'
                        + NoCotizaciones
                        + '</td>'
                        + '<td>'
                        + NoRequisicion
                        + '</td>'
                        + '<td>'
                        + RazonSocial
                        + '</td>'
                        + '<td>'
                        + NombreContacto
                        + '</td>'
                        + '<td>'
                        + Concepto
                        + '</td>'
                        //+ '<td>'
                        //+ CostoCotizaciones
                        //+ '</td>'
                        + '<td>'
                        + Estatus
                        + '</td>'
                        + '<td>'
                        + HechaPor
                        + '</td>'
                        + '<td>'
                        + EnviadaPor
                        + '</td>'
                        + '<td>'
                        + VendidaPor
                        + '</td>'
                        + '<td>'
                        + '<div class="form-inline">'
                        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                        + '<Button title="Convertir a proyecto" class= "btn btn-success" value="' + idCotizaciones + '" rel="' + NoCotizaciones + '" onclick="ConvertirProyecto(this);"> <i class="icon_check"></i></Button><input type="hidden" id="txtConceptoCotizacion" value="' + Concepto + '">'
                        + '<Button title="Enviar correo" class= "btn btn-warning" value="' + idCotizaciones + '" onclick="EnviarCotizacion(this);"> <i class="icon_mail"></i></Button><input type="hidden" id="NombreOrden" value="' + NoCotizaciones + '">'
                        + '<Button title="Ver PDF" class= "btn btn-success" value="' + idCotizaciones + '" onclick="PDFCotizacion(this);"> <i class="icon_search-2"></i></Button>'
                        + '</div > '
                        + '</td>'
                        + '<td>'
                        + '<div class="form-inline">'
                        + '<Button title="Ver Excel" class= "btn btn-default" value="' + idCotizaciones + '" onclick="ExcelCotizacion(this);"> <i class="icon_search-2"></i></Button>'
                        + '<Button title="Agregar comentario" class= "btn btn-info" value="' + idCotizaciones + '" onclick="AgregarComentario(this);"> <i class="icon_comment_alt"></i></Button>'

                        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                        + '<Button title="Editar" class= "btn btn-success" value="' + idCotizaciones + '" rel="' + item.idRequisicion + '" onclick="EditarCotizacion(this);"> <i class="icon_pencil"></i></Button>'
                        //+ '<Button title="Eliminar" class="btn btn-danger" value="' + idCotizaciones + '" onclick="EliminarCotizacion(this);"><i class="icon_minus_alt"></i></Button>'
                        + '</div > '
                        + '</td>'
                        + '<td>'
                        + '<div class="form-inline">'
                        + '<Button title="Archivos" class="btn btn-info" value="' + idCotizaciones + '" onclick="Archivos(this);"><i class="icon_documents"></i></Button>'
                        + '<Button title="Cancelar" class="btn btn-danger" value="' + idCotizaciones + '" onclick="CancelarCotizacion(this);"><i class="icon_close_alt2"></i></Button>'
                        + '</div > '
                        + '</td>'
                        + '</tr>')
                });
                //$('#listaCotizaciones').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
                $('#TablaCotizaciones').DataTable({
                    "bLengthChange": false,
                    "pageLength": 100,
                    "order": [[1, "desc"]],
                    "oLanguage": {
                        "sSearch": "Buscar:"
                    },
                    "retrieve": true
                });
            }
            else {
                $("#CargandoCotizaciones").append('<div class="alert alert-danger fade in"><p>No se obtuvo información, probablemente problemas de permisos.</p></div >');

            }
        }
    });
}

function formato_numero(numero, decimales, separador_decimal, separador_miles) { // v2007-08-06
    //debugger;
    numero = parseFloat(numero);
    if (isNaN(numero)) {
        return "";
    }

    if (decimales !== undefined) {
        // Redondeamos
        numero = numero.toFixed(decimales);
    }

    // Convertimos el punto en separador_decimal
    numero = numero.toString().replace(".", separador_decimal !== undefined ? separador_decimal : ",");

    if (separador_miles) {
        // Añadimos los separadores de miles
        var miles = new RegExp("(-?[0-9]+)([0-9]{3})");
        while (miles.test(numero)) {
            numero = numero.replace(miles, "$1" + separador_miles + "$2");
        }
    }

    return numero;
}


function accionCOTFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Convertir a proyecto" class="btn btn-success convertirProyecto"> <i class="icon_check"></i></span><input type="hidden" id="txtConceptoCotizacion" value="">',
        '<span title="Enviar correo" class= "btn btn-warning enviarCorreo"> <i class="icon_mail"></i></span>',
        '<span title="Ver PDF" class= "btn btn-success verPDF"> <i class="icon_search-2"></i></span>',
        '</div>'
    ].join(' ');
}

function accionCOT2Formatter(value, row, index) {
    return [
        '<div class="btn-group">',
        '<span title="Ver Excel" class="btn btn-default verExcel"> <i class="icon_search-2"></i></span>',
        '<span title="Agregar comentario" class="btn btn-info agregarComentario"> <i class="icon_comment_alt"></i></span>',
        '<span title="Editar" class="btn btn-success editar"> <i class="icon_pencil"></i></span>',
        '</div>'
    ].join(' ');
}

function accionCOT3Formatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Archivos" class="btn btn-info subirArchivos"> <i class="icon_documents"></i></span>',
        '<span title="Cancelar" class="btn btn-danger cancelar"><i class="icon_close_alt2"></i></span>',
        '</div>'
    ].join(' ');
}


window.accionCOTEvents = {
    'click .convertirProyecto': function (e, value, row, index) {

        CargarComboUsuarios();
        //CargarSucursales();
        CargarPO();
        CargarMontosCotizacion(row.IdCotizaciones);

        $('#txtConceptoProyecto').val(row.Concepto);
        $('#idCotizacionesConvertir').text(row.IdCotizaciones);

        document.getElementById('txtModalConvertirCotizaciones').textContent = '';
        document.getElementById('txtModalConvertirCotizaciones').textContent = '¿Estás seguro de convertir cotización con folio "' + row.NoCotizaciones + '"?';

        $("#ConvCotizacionesModal").modal();
    },
    'click .enviarCorreo': function (e, value, row, index) {

        window.open('../Administracion/EnviarCorreo.aspx?id=' + row.IdCotizaciones + '&Tipo=2');

    },
    'click .verPDF': function (e, value, row, index) {

        $('#testmodalpdfCot').html('');

        var params = "{'id': '" + row.IdCotizaciones +
            "','Opcion': '" + "Cot" + "'}";

        $.ajax({
            async: true,
            url: "Cotizaciones.aspx/CargarDocumentos",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

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

    }
};

window.accionCOT2Events = {
    'click .verExcel': function (e, value, row, index) {

        $('#testmodalpdfCot').html('');

        var params = "{'id': '" + row.IdCotizaciones +
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

    },
    'click .agregarComentario': function (e, value, row, index) {

        document.getElementById('idCotizacionComentario').textContent = row.IdCotizaciones;
        var params = "{'pid': '" + row.IdCotizaciones + "'}";
        $.ajax({
            async: true,
            url: "Cotizaciones.aspx/CargarComentarios",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var nodoTRAgregar = "";

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

    },
    'click .editar': function (e, value, row, index) {

        //$(btn).attr('rel');
        window.open("CotizacionesDetalles.aspx?idCotizacion=" + row.IdCotizaciones + "&idSolicitud=" + row.idRequisicion);

    }
};

window.accionCOT3Events = {
    'click .subirArchivos': function (e, value, row, index) {
        //debugger;
        var idCotizacion = row.IdCotizaciones;

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

    },
    'click .cancelar': function (e, value, row, index) {

        document.getElementById('idCotizacionCancelar').textContent = '';
        document.getElementById('idCotizacionCancelarTexto').textContent = '¿Estás seguro de cancelar Cotizacion con folio "' + row.NoCotizaciones + '" ?';
        document.getElementById('idCotizacionCancelar').textContent = row.IdCotizaciones;
        $("#CancelarCotizacionModal").modal();
    }

};

function dateFormat(value, row, index) {
    return moment(value).format('YYYY-MM-DD');
}

function estatusFormatter(value) {
    var icono;
    //debugger;
    if (value == "0") {
        icono = '<span>ELIMINADA</span>';
    }
    else if (value == "1") {
        icono = '<span>CREADA</span>';
    }
    else if (value == "2") {
        icono = '<span>CANCELADA</span>';
    }
    else if (value == "3") {
        icono = '<span>GANADA</span>';
    }
    else if (value == "4") {
        icono = '<span>ENVIADA</span>';
    }
    else if (value == "5") {
        icono = '<span>PROYECTO</span>';
    }

    return icono;//'<i class="glyphicon glyphicon-ok"></i> ' + value;
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

//function CargarSucursales() {
//    var params = "{'Opcion': '18'}";

//    $.ajax({
//        dataType: 'json',
//        async: true,
//        contentType: "application/json; charset=utf-8",
//        type: 'POST',
//        url: 'Cotizaciones.aspx/CargarCombos',
//        data: params,
//        success: function (data, textStatus) {

//            var json = $.parseJSON(data.d);

//            $('#cmbSucursal').html('');
//            $('#cmbSucursal').html('<option value="-1">-- Selecciona Sucursal --</option>');
//            $.each(json, function (index, value) {
//                $("#cmbSucursal").append('<option value="' + value.Id + '" rel="' + value.Correo + '">' + value.Nombre.toUpperCase() + '</option>');
//            });
//            $('#cmbSucursal').selectpicker('refresh');
//            $('#cmbSucursal').selectpicker('render');
//        }
//    });


//}

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


function CargarPO() {
    var params = "{'Opcion': '28'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'Cotizaciones.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {
            //debugger;
            var json = $.parseJSON(data.d);

            $('#cmbPO').html('');
            $('#cmbPO').html('<option value="-1">-- Selecciona PO --</option>');
            $.each(json, function (index, value) {
                $("#cmbPO").append('<option value="' + value.Id + '" rel="' + value.Nombre + '">' + value.Nombre.toUpperCase() + '</option>');
            });
            $('#cmbPO').selectpicker('refresh');
            $('#cmbPO').selectpicker('render');
        }
    });


}