$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("ModuloPO.aspx") > -1) {
        document.body.style.zoom = "80%";

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarModuloPO();
        CargarResumen();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }


});

function dateFormat(value, row, index) {
    return moment(value).format('YYYY-MM-DD');
}

function dateFormatText(value, row, index) {
    return moment(value).format('DD-MM-YYYY');
}

function formatoMonedaFormatter(value) {
    return formato_numero(value, 2, ".", ",");
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


function accionFormatter(value, row, index) {
    if (row.Archivo == 'NO') {
        return [
            '<div class="btn-group">',
            '<span title="Editar" class="btn btn-warning editarDatos"><i class="icon_pencil"></i></span>',
            '<span title="Subir PO" class="btn btn-primary subirArchivo"><i class="icon_cloud-upload"></i></span>',
            '</div>'
        ].join(' ');
    }
    else {
        return [
            '<div class="btn-group">',
            '<span title="Editar" class="btn btn-warning editarDatos"><i class="icon_pencil"></i></span>',
            '<span title="Ver Archivos" class="btn btn-info verArchivos"><i class="icon_documents"></i></span>',
            '</div>'
        ].join(' ');
    }
    
}

function accionFormatter2(value, row, index) {
    return [
        '<div class="btn-group">',
        '<span title="Eliminar" class="btn btn-danger eliminar"><i class="icon_close_alt2"></i></span>',
        '</div>'
    ].join(' ');

}


var idRequisitor = "-1";
var idCotizacion = "-1";
window.accionEvents = {
    'click .subirArchivo': function (e, value, row, index) {
        //debugger;
        swal({
            title: 'Seleccione PO',
            input: 'file',
            allowOutsideClick: false,
            allowEscapeKey: false,
            allowEnterKey: false,
            showCloseButton: true
        }).then(function (file) {
            var nombreArchivo = file.name;
            var fileSize = file.size;
            var filetype = file.type;
            var fileExtension = nombreArchivo.substring((nombreArchivo.lastIndexOf('.')));
            var reader = new FileReader
            reader.onload = function (e) {
                //debugger;
                //console.log("NombreArchivo: " + nombreArchivo);
                //console.log("fileSize: " + fileSize);
                //console.log("filetype: " + filetype);
                //console.log("fileExtension: " + fileExtension);

                var params = "{'IdModuloPO': '" + row.IdModuloPO +
                    "','FileName': '" + nombreArchivo +
                    "','fileSize': '" + fileSize +
                    "','filetype': '" + filetype +
                    "','fileExtension': '" + fileExtension +
                    "','Archivo': '" + e.target.result + "'}";

                //console.log(params);
                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "ModuloPO.aspx/GuardarDocumentos",
                    data: params,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        //location.href = './frmProjects.aspx';

                        swal({
                            title: msg.d,
                            timer: 2000
                        }).then(() => {
                            //CargarOrdenesCompra();
                            location.reload(true);
                        }).catch(swal.noop);

                        $('#TablaModuloPO').bootstrapTable('destroy');

                        CargarModuloPO();

                    },
                    error: function (xhr, ajaxOptions, thrownError) {

                    }
                });


            }

            reader.readAsDataURL(file);

        });
    },
    'click .editarDatos': function (e, value, row, index) {
        CargarClientes(row.IdCliente);
        CargarMonedas(row.IdMoneda);
        CargarProyectos(row.IdProyecto);
        CargarSucursales(row.IdSucursal);

        var _IdModuloPo = row.IdModuloPO;

        $('#btnGuardarPO').attr('rel', row.IdModuloPO);

        //document.getElementById('idOCComentario').textContent = idOrdenCompra;
        var params = "{'pIdModuloPO': '" + _IdModuloPo + "'}";
        $.ajax({
            async: true,
            url: "ModuloPO.aspx/VerModuloPO",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                //var datos = "";
                //var nodoTRAgregar = "";

                var JsonCombos;
                var jsonArray = $.parseJSON(data.d);
                //debugger;
                //console.log(jsonArray);
                //$('#TablaPrincipalComentarios tbody').html('');
                $.each(jsonArray, function (index, value) {
                    var d = new Date(value.Fecha);
                    d = d.toJSON().slice(0, 10);
                    $('#txtFecha').val(d);
                    $('#txtFolioPO').val(value.FolioPO);
                    $('#txtComprador').val(value.Comprador);
                    $('#txtMonto').val(formatoMonedaFormatter(value.Monto));
                    $('#cmbEstatus').val(value.Estatus);
                    $('#txtRequisitor').val(value.Contacto);
                    $('#txtNoCotizacion').val(value.NoCotizacion);
                    

                    if (value.MarkUP == "0") {
                        $('#chkMarkUp').prop('checked', false);
                    }
                    else {
                        $('#chkMarkUp').prop('checked', true);
                    }
                });

                //$('#TablaPrincipalComentarios tbody').append(nodoTRAgregar);

                $("#CapturaDatosModal").modal();
            }
        });

    },
    'click .verArchivos': function (e, value, row, index) {
        $('#testmodalpdf').html('');
        var params = "{'IdModuloPO': '" + row.IdModuloPO +
            "','Opcion': '" + "1" + "'}";

        //console.log(params);

        $.ajax({
            async: true,
            url: "ModuloPO.aspx/CargarDocumentos",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var jsonArray = $.parseJSON(data.d);

                $.each(jsonArray, function (index, value) {
                    document.getElementById('txtidProyectoArchivo').textContent = value.IdArchivoPO;
                    /*document.getElementById('txtTipoDocumento').textContent = "";*/
                    $('#LabeldvPDF').text('Archivo: ' + value.NombreArchivo);
                    $('#testmodalpdf').append('<object id="visorPDF" data="' + value.Archivo + '" type="application/pdf" style="width:100%; height: 800px;"></object>');
                });


                //var jsonArray = $.parseJSON(data.d);

                //$('#ulFiles').html('');
                //var cont = 1;
                //$.each(jsonArray, function (index, value) {
                //    var icono = '<i class="icon_document_alt"></i>';

                //    $('#ulFiles').append('<li>' + icono + '&nbsp<Button type="button" id="idDocumentoBoton" class="btn btn-default" value="' + value.IdDocumento.trim() + '" onclick="VerDoc(this);">' + value.NombreArchivo + '</Button>&nbsp&nbsp<button class="btn btn-danger eliminarDoc" id="btnEliminarArchivo" type="button" value="' + value.IdDocumento.trim() + '" rel="' + value.NombreArchivo + '"><i class="icon_close_alt2"></i></button></li><br>');

                //});
            }

        });
        $("#dvPDF").modal();
        //$("#GaleriaArchivosProyectosModal").modal();


    }
}

window.accionEvents2 = {
    'click .eliminar': function (e, value, row, index) {

        var _idModuloPO = row.IdModuloPO;

        swal({
            title: "Esta seguro que desea eliminar la PO " + row.FolioPO + "?",
            type: "warning",
            allowOutsideClick: false,
            allowEscapeKey: false,
            allowEnterKey: false,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si',
            cancelButtonText: 'No'
        }).then(function (result) {

            var params = "{'IdModuloPO': '" + _idModuloPO + "'}";

            $.ajax({
                dataType: 'json',
                async: true,
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                url: 'ModuloPO.aspx/EliminarModuloPO',
                data: params,
                success: function (data, textStatus) {
                    if (data.d == 'ModuloPO eliminado.') {
                        swal({
                            title: "Se elimino correctamente el registro.",
                            type: "success",
                            allowOutsideClick: false,
                            allowEscapeKey: false,
                            allowEnterKey: false,
                            showCancelButton: true,
                            confirmButtonColor: '#3085d6',
                            cancelButtonColor: '#d33',
                            cancelButtonText: 'Cerrar'
                        }).then(function () {
                            location.reload();
                        });

                        
                    }
                    else {
                        //CargarDatosDetalle();

                        swal({
                            title: "Hay un error no se encontro el registro, favor de recargar la pagina!",
                            type: "warning",
                            allowOutsideClick: false,
                            allowEscapeKey: false,
                            allowEnterKey: false,
                            showCancelButton: true,
                            confirmButtonColor: '#3085d6',
                            cancelButtonColor: '#d33',
                            cancelButtonText: 'Cerrar'
                        }).then(function () {
                        });
                    }


                }
            });


        }, function (dismiss) {
            // dismiss can be 'cancel', 'overlay',
            // 'close', and 'timer'
            if (dismiss === 'cancel') {
                swal(
                    'Cancelled',
                    'Cancelo la eliminacion del documento.',
                    'error'
                );
            }
        });

    }
}

$('#btnCaptura').click(function () {
    CargarClientes("-1");
    CargarMonedas("-1");
    CargarSucursales("-1");
    //CargarProyectos("-1");
    $('#btnGuardarPO').attr('rel', "0");

    $('#CapturaDatosModal').modal();
});

function CargarClientes(idCliente) {
    var params = "{'Opcion': '3'}";
    $.ajax({
        dataType: 'json',
        async: false,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'ModuloPO.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {
            //debugger;
            var json = $.parseJSON(data.d);
            //debugger;
            $('#cmbClientes').html('');
            $('#cmbClientes').html('<option value="-1">-- SELECCIONE CLIENTE --</option>');

            $.each(json, function (index, value) {
                $("#cmbClientes").append('<option value="' + value.idEmpresa + '">' + value.Cliente.toUpperCase() + '</option>');
            });

            $('#cmbClientes').selectpicker('refresh');
            $('#cmbClientes').selectpicker('render');

            if (typeof(idCliente) != "undefined") {
                $("#cmbClientes").val(idCliente);
                $('#cmbClientes').selectpicker('refresh');
                //$('#cmbClientes').trigger('change');
            }
        }
    });
}

//$("#cmbClientes").change(function () {

//    var idCliente = $(this).val();
//    //console.log(idCliente);
//    if (idCliente != null) {
//        var params = "{'IdCliente': '" + idCliente + "'}";
//        //;
//        $.ajax({
//            async: true,
//            url: "ModuloPO.aspx/BuscarContactos",
//            dataType: "json",
//            data: params,
//            type: "POST",
//            contentType: "application/json; charset=utf-8",
//            success: function (data, textStatus) {

//                var json = $.parseJSON(data.d);

//                $('#cmbRequisitor').html('');
//                $('#cmbRequisitor').html('<option value="-1">-- SELECCIONE CONTACTO --</option>');
//                $.each(json, function (index, value) {
//                    $("#cmbRequisitor").append('<option value="' + value.idContacto + '">' + value.NombreContacto.toUpperCase() + '</option>');
//                });

//                $('#cmbRequisitor').selectpicker('refresh');
//                $('#cmbRequisitor').selectpicker('render');

//                if (typeof (idCliente) != "undefined") {
//                    //console.log(idRequisitor);
//                    $("#cmbRequisitor").val(idRequisitor);
//                    $('#cmbRequisitor').selectpicker('refresh');
//                }

//                $.ajax({
//                    async: true,
//                    url: "ModuloPO.aspx/BuscarCotizaciones",
//                    dataType: "json",
//                    data: params,
//                    type: "POST",
//                    contentType: "application/json; charset=utf-8",
//                    success: function (data, textStatus) {

//                        var json = $.parseJSON(data.d);

//                        $('#cmbCotizacion').html('');
//                        $('#cmbCotizacion').html('<option value="-1">-- SELECCIONE COTIZACION --</option>');
//                        $.each(json, function (index, value) {
//                            $("#cmbCotizacion").append('<option value="' + value.Id + '">' + value.Folio.toUpperCase() + '</option>');
//                        });

//                        $('#cmbCotizacion').selectpicker('refresh');
//                        $('#cmbCotizacion').selectpicker('render');

//                        if (typeof (idCliente) != "undefined") {
//                            $("#cmbCotizacion").val(idCotizacion);
//                            $('#cmbCotizacion').selectpicker('refresh');
//                        }
//                    }
//                });
//            }
//        });
//    }
//});

function CargarMonedas(idMoneda) {
    var params = "{'Opcion': '1'}";

    $.ajax({
        dataType: 'json',
        async: false,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'ModuloPO.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {
            //debugger;
            var json = $.parseJSON(data.d);
            //debugger;
            $('#cmbMoneda').html('');
            $('#cmbMoneda').html('<option value="-1">-- SELECCIONE MONEDA --</option>');

            $.each(json, function (index, value) {
                $("#cmbMoneda").append('<option value="' + value.IdMoneda + '">' + value.Abreviatura.toUpperCase() + '</option>');
            });

            $('#cmbMoneda').selectpicker('refresh');
            $('#cmbMoneda').selectpicker('render');

            if (typeof (idMoneda) != "undefined") {
                $("#cmbMoneda").val(idMoneda);
                $('#cmbMoneda').selectpicker('refresh');
            }
        }
    });
}

function CargarSucursales(idSucursal) {
    var params = "{'Opcion': '4'}";
    console.log(idSucursal);
    $.ajax({
        dataType: 'json',
        async: false,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'ModuloPO.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {
            //debugger;
            var json = $.parseJSON(data.d);
            //debugger;
            $('#cmbSucursal').html('');
            $('#cmbSucursal').html('<option value="-1">-- SELECCIONE SUCURSAL --</option>');

            $.each(json, function (index, value) {
                $("#cmbSucursal").append('<option value="' + value.idSucursa + '">' + value.CiudadSucursal.toUpperCase() + '</option>');
            });

            $('#cmbSucursal').selectpicker('refresh');
            $('#cmbSucursal').selectpicker('render');
            //debugger;
            if (typeof (idSucursal) != "undefined") {
                $("#cmbSucursal").val(idSucursal);
                $('#cmbSucursal').selectpicker('refresh');
                $('#cmbSucursal').selectpicker('render');
            }
        }
    });
}

function CargarProyectos(idProyecto) {
    var params = "{'Opcion': '2'}";

    $.ajax({
        dataType: 'json',
        async: false,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'ModuloPO.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {
            //debugger;
            var json = $.parseJSON(data.d);
            //debugger;
            $('#cmbProyectos').html('');
            $('#cmbProyectos').html('<option value="-1">-- SELECCIONE PROYECTO --</option>');

            $.each(json, function (index, value) {
                $("#cmbProyectos").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
            });

            $('#cmbProyectos').selectpicker('refresh');
            $('#cmbProyectos').selectpicker('render');

            if (typeof (idProyecto) != "undefined") {
                $("#cmbProyectos").val(idProyecto);
                $('#cmbProyectos').selectpicker('refresh');
            }
        }
    });
}

$('#btnGuardarPO').click(function () {
    var _fecha = $('#txtFecha').val();
    var _ordenCompa = $('#txtFolioPO').val();
    var _idCliente = $('#cmbClientes').val();
    var _idRequisitor = $('#txtRequisitor').val();
    var _comprador = $('#txtComprador').val();
    var _monto = $('#txtMonto').val().replace(",", "").replace(",", "");
    var _idMoneda = $('#cmbMoneda').val();
    var _markup = $('#chkMarkUp').is(':checked');
    //var _idProyecto = $('#cmbProyectos').val();
    var _idCotizacion = $('#txtNoCotizacion').val();
    var _estatus = $('#cmbEstatus').val();
    var _idSucursal = $('#cmbSucursal').val();

    if (_markup) {
        _markup = 1;
    }
    else {
        _markup = 0;
    }

    var params = "{'pIdModuloPO': '" + $(this).attr('rel') + "', 'pFecha': '" + _fecha + "', 'pOrdenCompra': '" + _ordenCompa + "', 'pIdCliente': '" + _idCliente +
        "', 'pIdRequisitor': '" + _idRequisitor + "', 'pComprador': '" + _comprador + "', 'pMonto': '" + _monto +
        "', 'pIdMoneda': '" + _idMoneda + "', 'pMarkUp': '" + _markup + 
        "', 'pIdCotizacion': '" + _idCotizacion + "', 'pEstatus': '" + _estatus +
        "', 'pIdSucursal': '" + _idSucursal +
        "'}";
    //console.log(params);
    $.ajax({
        dataType: "json",
        async: true,
        url: "ModuloPO.aspx/GuardarPO",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            //location.href = './frmProjects.aspx';  
            //debugger;
            swal({
                title: msg.d,
                timer: 3000
            });
            //$('#TablaFacturas').bootstrapTable('destroy');



        },
        error: function (xhr, ajaxOptions, thrownError) {
            swal({
                title: 'Error, intenta de nuevo',
                timer: 3000
            });
        }
    });

});

$('#btnEliminadDocumento').click(function () {
    swal({
        title: 'Estas Seguro que quieres eliminar documento de PO?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Aceptar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {

        if (result) {

            //var tipo = document.getElementById('txtTipoDocumento').textContent;
            var id = document.getElementById('txtidProyectoArchivo').textContent;

            $('#myPagerProy2').html('');
            var parametros = "{'IdArchivoPO': '" + id + "'}";
            $.ajax({
                dataType: "json",
                url: "ModuloPO.aspx/EliminarDocumento",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Documento eliminado.") {
                        // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                        swal({
                            title: msg.d,
                            timer: 2000
                        }).then(() => {
                            //CargarOrdenesCompra();
                            location.reload(true);
                        }).catch(swal.noop);

                        $('#TablaModuloPO').bootstrapTable('destroy');

                        CargarModuloPO();

                    }
                    else {
                        //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                        swal(msg.d);
                    }
                }
            });

        }
    });

});

function CargarModuloPO() {

    var parametros = "{'Opcion': '" + 1 + "'}";
    $.ajax({
        dataType: "json",
        url: "ModuloPO.aspx/CargarModuloPO",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var json = JSON.parse(data.d);

            data = json;

            $('#TablaModuloPO').bootstrapTable({
                data: data,
                detailView: false,
                striped: true,
                //pagination: true,
                //onlyInfoPagination: true,
                pageSize: 100,
                idField: 'IdModuloPO',
                uniqueId: 'IdModuloPO',
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
                },
                rowStyle: function (row, index) {

                    if (row.Estatus == "CANCELADA") {
                        return {
                            classes: 'estatusCancelada'
                        };
                    }
                    else if (row.Estatus == "REEMPLAZADA") {
                        return {
                            classes: 'estatusReemplazadas'
                        };
                    }
                    else if (row.Estatus == "COMPLETADA") {
                        return {
                            classes: 'estatusCompletadas'
                        };
                    }
                    else {
                        return {
                            classes: 'estatus'
                        };
                        //if (row.Enviada == 0 || row.Enviada == "0") {
                        //    return {
                        //        classes: 'estatusNoEnviada'
                        //    };
                        //}
                        //else {

                        //}

                    }

                }
            });

            CargarCombosFiltrosEmitidas(12);
            CargarCombosFiltrosEmitidas(13);
            CargarCombosFiltrosEmitidas(26);
            CargarCombosFiltrosEmitidas(7);
            CargarCombosFiltrosEmitidas(1);
            CargarCombosFiltrosEmitidas(2);
            CargarCombosFiltrosEmitidas(3);
        }
    });
}

function CargarCombosFiltrosEmitidas(Opcion) {
    var params = "{'Opcion': '" + Opcion + "'}";

    $.ajax({
        async: true,
        url: "ModuloPO.aspx/CargarFiltrosBuscar",
        //url: "FacturasEmitidas.aspx/CargarCombos",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var jsonArray = $.parseJSON(data.d);
            //debugger;
            if (Opcion == 12) {
                $('#cmbAnioBuscar').html('');
                $('#cmbAnioBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbAnioBuscar").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                });
                $('#cmbAnioBuscar').selectpicker('refresh');
                $('#cmbAnioBuscar').selectpicker('render');
            }

            if (Opcion == 3) {
                $('#cmbMesBuscar').html('');
                $('#cmbMesBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbMesBuscar").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                });
                $('#cmbMesBuscar').selectpicker('refresh');
                $('#cmbMesBuscar').selectpicker('render');
            }

            if (Opcion == 13) {
                $('#cmbClienteBuscar').html('');
                $('#cmbClienteBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbClienteBuscar").append('<option value="' + value.IdCliente + '">' + value.Cliente + '</option>');
                });
                $('#cmbClienteBuscar').selectpicker('refresh');
                $('#cmbClienteBuscar').selectpicker('render');
            }

            if (Opcion == 7) {
                $('#cmbMonedaEmitidaBuscar').html('');
                $('#cmbMonedaEmitidaBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbMonedaEmitidaBuscar").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                });
                $('#cmbMonedaEmitidaBuscar').selectpicker('refresh');
                $('#cmbMonedaEmitidaBuscar').selectpicker('render');

            }

            if (Opcion == 26) {
                $('#cmbProyectoEmitidaBuscar').html('');
                $('#cmbProyectoEmitidaBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbProyectoEmitidaBuscar").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                });
                $('#cmbProyectoEmitidaBuscar').selectpicker('refresh');
                $('#cmbProyectoEmitidaBuscar').selectpicker('render');
            }

            if (Opcion == 1) {
                $('#cmbComprador').html('');
                $('#cmbComprador').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbComprador").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                });
                $('#cmbComprador').selectpicker('refresh');
                $('#cmbComprador').selectpicker('render');
            }

            if (Opcion == 2) {
                $('#cmbRequisitor').html('');
                $('#cmbRequisitor').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbRequisitor").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                });
                $('#cmbRequisitor').selectpicker('refresh');
                $('#cmbRequisitor').selectpicker('render');
            }



        }
    });
}

$('#btnBuscarPO').click(function () {
    //$("#main-content").css("opacity", 0.2);
    //$("#loading-img").css({ "display": "block" });
    //document.getElementById('TipoFactura').textContent = 'emitidas';
    
    CargarFEBusqueda();
    CargarResumen();
    //setTimeout(function () {
    //    $("#main-content").css("opacity", 1);
    //    $("#loading-img").css({ "display": "none" });
    //}, 5000);
});

function CargarFEBusqueda() {

    var parametros = "{'pid':'2','AnioBuscar': '" + $('#cmbAnioBuscar').val() +
        "','ClienteBuscar': '" + $('#cmbClienteBuscar').val() +
        "','ProyectoEmitidaBuscar': '" + $('#cmbProyectoEmitidaBuscar').val() +
        "','MonedaEmitidaBuscar': '" + $('#cmbMonedaEmitidaBuscar').val() +
        "','Requisitor': '" + $('#cmbRequisitor').val() +
        "','Comprador': '" + $('#cmbComprador').val() +
        "','Estatus': '" + $('#cmbEstatusEmitidas').val() +
        "','Mes': '" + $('#cmbMesBuscar').val() +
        "','MarkUp': '" + $('#cmbMarkUp').val() + "'}";

    $.ajax({
        dataType: "json",
        url: "ModuloPO.aspx/CargarModuloPOBuscar",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d == "No tienes permiso de acceso.") {
                swal(data.d);
                return;
            }
            if (data.d != "Error" || data.d != "-1") {
                var json = JSON.parse(data.d);

                $('#TablaModuloPO').bootstrapTable('destroy');

                data = json;

                $('#TablaModuloPO').bootstrapTable({
                    data: data,
                    detailView: false,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'IdModuloPO',
                    uniqueId: 'IdModuloPO',
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
                    },
                    rowStyle: function (row, index) {

                        if (row.Estatus == "CANCELADA") {
                            return {
                                classes: 'estatusCancelada'
                            };
                        }
                        else if (row.Estatus == "REEMPLAZADA") {
                            return {
                                classes: 'estatusReemplazadas'
                            };
                        }
                        else if (row.Estatus == "COMPLETADA") {
                            return {
                                classes: 'estatusCompletadas'
                            };
                        }
                        else {
                            return {
                                classes: 'estatus'
                            };

                        }

                    }
                });
                //CargarTotalesEmitidas();

            }
            else {


            }
        }
    });
}

function CargarResumen() {
    var parametros = "{'anio': '" + $('#cmbAnioBuscar').val() +
        "','cliente': '" + $('#cmbClienteBuscar').val() +
        "','proyecto': '" + $('#cmbProyectoEmitidaBuscar').val() +
        "','moneda': '" + $('#cmbMonedaEmitidaBuscar').val() +
        "','requisitor': '" + $('#cmbRequisitor').val() +
        "','comprador': '" + $('#cmbComprador').val() +
        "','estatus': '" + $('#cmbEstatusEmitidas').val() +
        "','mes': '" + $('#cmbMesBuscar').val() +
        "','markup': '" + $('#cmbMarkUp').val() + "'}";

    $.ajax({
        async: true,
        url: "ModuloPO.aspx/CargarResumenPO",
        dataType: "json",
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            //debugger;
            var jsonArray = $.parseJSON(data.d);


            $('#lblPesosMonto').html('');
            $('#lblPesosFacturado').html('');
            $('#lblPesosPendiente').html('');

            $('#lblDolaresMonto').html('');
            $('#lblDolaresFacturado').html('');
            $('#lblDolaresPendiente').html('');

            $.each(jsonArray, function (index, value) {

                if (value.Moneda == "MXN") {
                    $('#lblPesosMonto').text(formato_numero(value.Monto, 2, '.', ','));
                    $('#lblPesosFacturado').text(formato_numero(value.MontoFacturado, 2, '.', ','));
                    $('#lblPesosPendiente').text(formato_numero(value.PendienteFacturar, 2, '.', ','));
                }
                else {
                    $('#lblDolaresMonto').text(formato_numero(value.Monto, 2, '.', ','));
                    $('#lblDolaresFacturado').text(formato_numero(value.MontoFacturado, 2, '.', ','));
                    $('#lblDolaresPendiente').text(formato_numero(value.PendienteFacturar, 2, '.', ','));
                }
            });

        }
    });
}