
$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("CajaChicaQueretaro.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });
        document.body.style.zoom = "80%";

        CargarCC();
        //CargarProyectos();
        //CargarUsuarios();
        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }
});

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

function CargarCC() {

    $('#TablaCajaChica').bootstrapTable('destroy');
    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "CajaChicaQueretaro.aspx/ObtenerCC",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = $.parseJSON(data.d);//JSON.parse(data.d);

                $('#TablaCajaChica').bootstrapTable({
                    data: json,
                    detailView: false,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'IdCajaChica',
                    uniqueId: 'IdCajaChica',
                    onSearch: function (text) {
                        CargarResumen(text);
                    },
                    onExpandRow: function (index, row, $detail) {
                        //$detail.hide().html(row.IdMaterial).fadeIn('slow');
                    },
                    onCollapseRow: function (index, row, $detail) {
                        $detail.clone().insertAfter($detail).fadeOut('slow', function () {
                            $(this).remove()
                        })
                    },
                    exportOptions: {
                        fileName: 'Export_CajaChica'
                    },
                    rowStyle: function (row, index) {

                        /*
                         0 = PENDIENTE O NUEVO
                         1 = POR INICIAR
                         2 = EN PROCESO
                         3 = TERMINADO
                         4 = CANCELADO

                        */

                        if (row.Estatus == 0) {
                            return {
                                classes: 'warning'
                            };
                        }
                        else {
                            return {
                                classes: ''
                            };
                        }

                        //if (row.Estatus == 3) {
                        //    return {
                        //        classes: 'success'
                        //    };
                        //}
                        //else if (row.Estatus == 2) {
                        //    return {
                        //        classes: 'warning'
                        //    };
                        //}
                        //else if (row.Estatus == 1) {
                        //    return {
                        //        classes: 'info'
                        //    };
                        //}
                        //else if (row.Estatus == 4) {
                        //    return {
                        //        classes: 'danger'
                        //    };
                        //}
                        //else {
                        //    return {
                        //        classes: ''
                        //    };
                        //}

                    }
                });

            }
            else {
                $("#CargandoCajaChica").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

            }
        }
    });
}

function dateFormat(value, row, index) {
    return moment(value).format('YYYY-MM-DD');
}

function formatoMonedaFormatter(value) {
    return formato_numero(value, 2, ".", ",");
}

function accionCC1Formatter(value, row, index) {

    if (row.Cargo == "0.00") {
        return [
            '<div class="btn-group">',
            '<span title="Editar" class="btn btn-info editar"> <i class="icon_pencil"></i></span>',
            '<span title="Eliminar" class="btn btn-danger eliminar"><i class="icon_close_alt2"></i></span>',
            '<span title="Ver Archivo" class="btn btn-warning verArchivo"><i class="fa fa-file-o" aria-hidden="true"></i></span>',
            '<span title="Subir Archivo" class="btn btn-success subirArchivo"><i class="fa fa-file-o" aria-hidden="true"></i></span>',
            '</div>'
        ].join(' ');
    }
    else {
        return [
            '<div class="btn-group">',
            '<span title="Ver Archivo" class="btn btn-warning verArchivo"><i class="fa fa-file-o" aria-hidden="true"></i></span>',
            '<span title="Subir Archivo" class="btn btn-success subirArchivo"><i class="fa fa-file-o" aria-hidden="true"></i></span>',
            '</div>'
        ].join(' ');
    }

}

window.accionCC1Events = {
    'click .editar': function (e, value, row, index) {

        var idCajaChica = row.IdCajaChica;
        tipo = 2;

        CargarUsuarios();

        var parametros = "{'pid': '" + idCajaChica + "'}";
        //console.log(parametros);
        $.ajax({
            dataType: "json",
            url: "CajaChicaQueretaro.aspx/ObtenerCC",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {
                        //debugger;
                        var IdCajaChica = item.IdCajaChicaQueretaro;
                        var Responsable = item.Responsable.toUpperCase();
                        var Responsable2 = item.CampoExtra;
                        var Concepto = item.Concepto;
                        var Proyecto = item.Proyecto;
                        var Comprobante = item.Comprobante;
                        var Abono = item.Abono;
                        var Saldo = item.Saldo;
                        var Fecha = item.Fecha.substring(0, 10);
                        var Estatus = item.Estatus;
                        var Categoria = item.Categoria;
                        var IdProyecto = item.IdProyecto;
                        var OC = item.FolioOrdenCompra;
                        //debugger;
                        $('#txtidCajaChicaEditar').val(IdCajaChica);
                        $('#dtFecha').val(Fecha);
                        /*$('#txtResponsable').val(Responsable);*/
                        $('#txtResponsable2').val(Responsable2);
                        $('#txtConcepto').val(Concepto);
                        CargarProyectosEditarCC(IdProyecto);
                        //CargarUsuariosEditar(Responsable);
                        $('#cmbComprobante').val(Comprobante);
                        //$('#txtCargo').val(formato_numero(Cargo, 2, '.', ','));
                        //$('#txtAbono').val(formato_numero(Abono, 2, '.', ','));
                        //$('#txtCargo').val(Cargo);
                        $('#txtAbono').val(Abono);
                        $('#cmbEstatus').val(Estatus);
                        $('#cmbCategoriaCC').val(Categoria);


                        $('#cmbProyectos').selectpicker('refresh');
                        $('#cmbProyectos').selectpicker('render');
                        $('#cmbProyectos').trigger('change');

                        $('#txtResponsable').val(Responsable);
                        $('#txtResponsable').selectpicker('refresh');
                        $('#txtResponsable').selectpicker('render');

                        $('#cmbOC').val(OC);
                        $('#cmbOC').selectpicker('refresh');
                        $('#cmbOC').selectpicker('render');

                    });
                    $("#AddCajaChicaModal").modal();
                }
                else {
                    $("#CargandoCajaChica").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }
            }
        });
    },
    'click .eliminar': function (e, value, row, index) {
        var idCajaChica = row.IdCajaChica;
        //var folio = row.Folio;

        document.getElementById('idCajaChicaEliminar').textContent = '';
        document.getElementById('idCajaChicaEliminarTexto').textContent = '¿Estás seguro de eliminar información de caja chica con código "' + idCajaChica + '"?';


        document.getElementById('idCajaChicaEliminar').textContent = idCajaChica;

        $("#DelCajaChicaModal").modal();
    },
    'click .verArchivo': function (e, value, row, index) {
        $('#testmodalpdf').html('');
        var idCajaChica = row.IdCajaChica;
        tipo = 2;
        //var parametros = "{'pid': '" + idCajaChica + "'}";
        //$.ajax({
        //    dataType: "json",
        //    url: "CajaChica.aspx/ObtenerCC",
        //    async: true,
        //    data: parametros,
        //    type: "POST",
        //    contentType: "application/json; charset=utf-8",
        //    success: function (data) {
        //        if (data.d != "") {
        //            var json = JSON.parse(data.d);

        //            $(json).each(function (index, item) {
        //                document.getElementById('txtidCajaChicaArchivo').textContent = item.idCajaChica;
        //                $('#testmodalpdf').append('<object id="visorPDF" data="' + item.Archivo + '" type="application/pdf" style="width:100%; height: 800px;"></object>');
        //            });
        //            $("#dvPDF").modal();
        //        }
        //        else {
        //            $("#CargandoCajaChica").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

        //        }
        //    }
        //});

        var params = "{'IdDocumento': '" + 0 +
            "','IdCajaChica': '" + idCajaChica +
            "','FileName': '" + "" +
            "','File': '" + "" +
            "','Opcion': '" + "8" + "'}";

        //console.log(params);

        $.ajax({
            async: true,
            url: "CajaChicaQueretaro.aspx/CargarDocumentos",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var jsonArray = $.parseJSON(data.d);

                $('#ulFiles').html('');
                var cont = 1;
                $.each(jsonArray, function (index, value) {
                    var icono = '<i class="icon_document_alt"></i>';

                    var file = value.NombreArchivo.substring(value.NombreArchivo.indexOf("."));
                    //if (file == '.png' || file == '.jpg' || file == '.PNG' || file == '.JPG' || file == '.JPEG' || file == '.jpeg' || file == '.jfif' || file == '.JFIF') {
                    //    //$('#slideimagenes').append('<li class="slide" id="slide' + cont + '"><a href = "#" ><img src="' + value.Archivo + '" alt="photo ' + cont + '" height="350" width="120"></a></li >');
                    //    //$('#slidenumeracion').append('<li><a href="#slide' + cont + '">&bullet;</a></li>');
                    //    //cont++;
                    //}
                    //else {
                    //    $('#ulFiles').append('<li>' + icono + '&nbsp<Button type="button" id="idDocumentoBoton" class="btn btn-default" value="' + value.IdDocumento.trim() + '" onclick="VerDoc(this);">' + value.NombreArchivo + '</Button>&nbsp&nbsp<button class="btn btn-danger eliminarDoc" id="btnEliminarArchivo" type="button" value="' + value.IdDocumento.trim() + '" rel="' + value.NombreArchivo + '"><i class="icon_close_alt2"></i></button></li><br>');

                    //}
                    $('#ulFiles').append('<li>' + icono + '&nbsp<Button type="button" id="idDocumentoBoton" class="btn btn-default" value="' + value.IdDocumento.trim() + '" onclick="VerDoc(this);">' + value.NombreArchivo + '</Button>&nbsp&nbsp<button class="btn btn-danger eliminarDoc" id="btnEliminarArchivo" type="button" value="' + value.IdDocumento.trim() + '" rel="' + value.NombreArchivo + '"><i class="icon_close_alt2"></i></button></li><br>');

                });
                $("#GaleriaArchivosProyectosModal").modal();
            }
        });

    },
    'click .subirArchivo': function (e, value, row, index) {
        $('#testmodalpdf').html('');
        var idCajaChica = row.IdCajaChica;
        tipo = 2;

        swal({
            title: 'Seleccione archivo',
            input: 'file',
            allowOutsideClick: false,
            allowEscapeKey: false,
            allowEnterKey: false,
            showCloseButton: true
        }).then(function (file) {
            var nombreArchivo = file.name;
            var fileSize = file.size;
            var filetype = file.type;
            var reader = new FileReader
            reader.onload = function (e) {

                var params = "{'IdCajaChica': '" + idCajaChica +
                    "','FileName': '" + nombreArchivo +
                    "','FileSize': '" + fileSize +
                    "','FileType': '" + filetype +
                    "','File': '" + e.target.result + "'}";

                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "CajaChicaQueretaro.aspx/GuardarImagenTarea",
                    data: params,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        //location.href = './frmProjects.aspx';

                        swal({
                            title: msg.d,
                            timer: 2000
                        }).then(function () {
                            //cargarArchivos();
                        });

                        //
                    },
                    error: function (xhr, ajaxOptions, thrownError) {

                    }
                });


            }

            reader.readAsDataURL(file);
            //debugger;

        });
    }
};


$('#btnAgregarCajaChica').click(function () {
    CargarProyectos();
    CargarUsuarios();

    $('#txtidCajaChicaEditar').val(0);
    tipo = 1;
});

function CargarProyectos() {
    var params = "{'Opcion': '10'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'CajaChicaQueretaro.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {
            //debugger;
            var json = $.parseJSON(data.d);
            $('#cmbProyectos').html('');
            $.each(json, function (index, value) {
                $("#cmbProyectos").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
            });

            $('#cmbProyectos').selectpicker('refresh');
            $('#cmbProyectos').selectpicker('render');
        }

    });
}

function CargarUsuarios() {
    var params = "{'Opcion': '1'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'CajaChicaQueretaro.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#txtResponsable').html('');
            $('#txtResponsable').html("<option value=-1>-- SELECCIONA RESPONSABLE --</option>");
            $.each(json, function (index, value) {

                $("#txtResponsable").append('<option value="' + value.Nombre.toUpperCase() + '">' + value.Nombre.toUpperCase() + '</option>');

            });
            $('#txtResponsable').selectpicker('refresh');
            $('#txtResponsable').selectpicker('render');
        }
    });
}

$("#cmbProyectos").change(function () {

    var idProyecto = $(this).val();

    CargarOrdenCompra(idProyecto);
});

function CargarOrdenCompra(id) {
    var params = "{'pid': '" + id + "'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'CajaChicaQueretaro.aspx/CargarOC',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbOC').html('');
            $('#cmbOC').append('<option value="-1">-- SELECCION ORDEN COMPRA --</option>');
            $('#cmbOC').append('<option value="N/A" name="MATERIAL">N/A</option>');
            $('#cmbOC').append('<option value="PENDIENTE" name="MATERIAL">PENDIENTE</option>');
            var tipo = "MATERIAL";
            $.each(json, function (index, value) {
                if (value.TipoOC == 'Material') {
                    tipo = "MATERIAL";
                } else if (value.TipoOC == 'Equipo') {
                    tipo = "EQUIPO";
                } else if (value.TipoOC == 'ManoObra') {
                    tipo = "MANOOBRA";
                }
                else {
                    tipo = "MATERIAL";
                }
                $("#cmbOC").append('<option value="' + value.Folio + '" name="' + tipo + '">' + value.Folio.toUpperCase() + '</option>');
            });
            $('#cmbOC').selectpicker('refresh');
            $('#cmbOC').selectpicker('render');
        }
    });
}

$('#btnGuardarCajaChica').click(function () {

    $('#txtDireccionEmpresa').val();
    if ($('#txtResponsable').val() == '-1' || $('#txtResponsable').val() == '' || $('#txtConcepto').val() == '' || $('#cmbProyectos').val() == '' || $('#cmbProyectos').val() == '-1' || $('#cmbComprobante').val() == '-1' || $('#cmbComprobante').val() == '' || $('#txtAbono').val() == '' || $('#dtFecha').val() == '' || $('#cmbEstatus').val() == '' || $('#cmbCategoriaCC').val() == '') {
        swal('Todos los campos son obligatorios');
        return;
    }
    var parametros = "{'Responsable':'" + $('#txtResponsable').val() +
        "','Concepto': '" + $('#txtConcepto').val() +
        "', 'pidproyecto':'" + $('#cmbProyectos').val() +
        "', 'Proyecto':'" + $("#cmbProyectos option:selected").text() +
        "', 'Comprobante': '" + $('#cmbComprobante').val() +
        "', 'Abono': '" + $('#txtAbono').val() +
        "', 'Fecha':'" + $('#dtFecha').val() +
        "','Estatus':'" + $('#cmbEstatus').val() +
        "', 'Tipo':'" + tipo + "', 'pid':'" + $('#txtidCajaChicaEditar').val() +
        "', 'Categoria':'" + $('#cmbCategoriaCC').val() +
        "', 'CampoExtra':'" + $('#txtResponsable2').val() +
        "', 'OC':'" + $('#cmbOC').val() +
        "', 'nombrearchivo': '" + $('#nombreaarchivopdf').val() +
        "', 'dataarchivo': '" + $('#dataarchivopdf').val() +
        "'}";

    $.ajax({
        dataType: "json",
        url: "CajaChicaQueretaro.aspx/GuardarCC",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            debugger;
            if (msg.d == "Informacion actualizada.") {
                //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                //swal(msg.d);

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


});

function CargarProyectosEditarCC(IdProyecto) {
    var params = "{'Opcion': '10'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'CajaChicaQueretaro.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbProyectos').html('');

            $.each(json, function (index, value) {
                $("#cmbProyectos").append('<option value="' + value.Id.toUpperCase() + '">' + value.Nombre.toUpperCase() + '</option>');
            });

            $('#cmbProyectos').selectpicker('refresh');
            $('#cmbProyectos').selectpicker('render');
            var id = IdProyecto.toUpperCase();
            $('#cmbProyectos').val(id);
            $('#cmbProyectos').selectpicker('refresh');
        }

    });
}

$('#btnEliminarCajaChica').click(function () {
    var id = document.getElementById('idCajaChicaEliminar').textContent;

    var parametros = "{'pid': '" + id + "'}";
    $.ajax({
        dataType: "json",
        url: "CajaChicaQueretaro.aspx/EliminarCC",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Informacion eliminada.") {


                CargarCC();
                swal(msg.d);
            }
            else {
                //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
});

function VerDoc(btn) {
    //swal(btn.value);
    var params = "{'id': '" + btn.value + "'}";
    //console.log(params);
    $.ajax({
        async: true,
        url: "CajaChicaQueretaro.aspx/VerPdf",
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