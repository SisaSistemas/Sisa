var rolusuario = "";
$(document).ready(function () {
    var URLactual = window.location;
    
    var nombreArchivoCotComparativa = "";// = file.name;
    var fileSizeCotComparativa = "";// = file.size;
    var filetypeCotComparativa = "";// = file.type;
    var fileExtensionCotComparativa = "";// = nombreArchivo.substring((nombreArchivo.lastIndexOf('.')));
    var archivoCotComparativa = "";
    var readerCotComparativa = new FileReader;

    var ultimoNumCotizacion = 1;
    var idOrdenCompraCotComparativa = "";

    if (URLactual.href.indexOf("OrdenCompra.aspx") > -1) {

        document.body.style.zoom = "80%";

        obtieneRolUsuario();
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        cuantosPagosMultiples();
        CargarOrdenesCompra();
        CargarResumen('');
        CargarProveedores();

    }


});

//$("#search").on("keyup", function () {
    
//    var value = $(this).val().toLowerCase();
//    $("#listaOC tr").filter(function () {
//        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
//    });
//});

function obtieneRolUsuario() {
    var params = '';

    $.ajax({
        async: true,
        url: "OrdenCompra.aspx/ObtieneRolUsuarioLogueado",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
           rolusuario = data.d;
        }
    });
}

function cargaPagosMultiplesPendientes() {
    var params = "{'id': '1'}";
    //$.ajax({
    //    dataType: "json",
    //    url: "OrdenCompra.aspx/obtienePagosMultiplesPendientes",
    //    async: true,
    //    data: parametros,
    //    type: "POST",
    //    contentType: "application/json; charset=utf-8",
    //    success: function (data) {
    //        debugger;
    //        var jsonArray = $.parseJSON(data.d);
    //        $.each(jsonArray, function (index, value) {
    //            $("#chk_" + value).prop("checked", true);
    //        });
    //    }
    //});

    $.ajax({
        async: true,
        url: "OrdenCompra.aspx/obtienePagosMultiplesPendientes",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var jsonArray = $.parseJSON(data.d);
            $.each(jsonArray, function (index, value) {
                $('#chk_' + value.Folio).prop('checked', true);
            });

        }
    });
}

function CargarOrdenesCompra() {
    //$('tbody#listaOC').empty();
    //$('#myPager').html('');
    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "OrdenCompra.aspx/ObtenerOC",
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
            $('#TablaOC').bootstrapTable({
                data: data,
                detailView: false,
                striped: true,
                //pagination: true,
                //onlyInfoPagination: true,
                pageSize: 100,
                idField: 'IdOrdenCompra',
                uniqueId: 'IdOrdenCompra',
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
                }
            });

            cargaPagosMultiplesPendientes();

        }
    });

}

function CargarProveedores() {
    var params = "{'Opcion': '9'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'OrdenCompraDetalle.aspx/CargarCombos2',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbProveedores').html('');
            $('#cmbProveedores').html('<option value="-1">-- SELECCION PROVEEDOR --</option>');
            $.each(json, function (index, value) {
                $("#cmbProveedores").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
            });
            $('#cmbProveedores').selectpicker('refresh');
            $('#cmbProveedores').selectpicker('render');
        }
    });
}

function dateFormat(value, row, index) {
    return moment(value).format('YYYY-MM-DD');
}

function cellStyle(value, row, index) {
    //debugger;

    var classes = [
        'bg-red',
        'bg-lime'
    ];

    if (value == "1") {
        return {
            classes: classes[1]
        }
    }
    else if (value == 2) {
        return {
            classes: classes[0]
        }
    }
    return {
        css: {
            color: '#797979'
        }
    }
}

function estatusFormatter(value) {
    var icono;
    //debugger;
    if (value == "1") {
        icono = '<span>ENTREGADO</span>';
    }
    else if (value == "2"){
        icono = '<span style="color:white;">CANCELADA</span>';
    }
    else {
        icono = '<span>NO ENTREGADO</span>';
    }
    return icono;//'<i class="glyphicon glyphicon-ok"></i> ' + value;
}

function esCCMFormatter(value) {
    var icono;
    //debugger;
    if (value == "1") {
        icono = '<span><i class="glyphicon glyphicon-ok-circle fa-lg" style="color: green;"></i></span>';
        //icono = '<i class="icon_mail"></i>';
    }
    else {
        icono = '<span><i class="glyphicon glyphicon-remove-circle fa-lg" style="color: red;"></i>';
    }
    return icono;//'<i class="glyphicon glyphicon-ok"></i> ' + value;
}


function formatoMonedaFormatter(value) {
    
    return formato_numero(value,2,".",",");
}

window.accionOCEvents = {
    'click .enviarOC': function (e, value, row, index) {

        var idOrdenCompra = row.IdOrdenCompra;

        window.open('../Administracion/EnviarCorreo.aspx?id=' + idOrdenCompra + '&Tipo=1');

        //

        //window.open("./frmReporteOrdenCompra.aspx?IdOrdenCompra=" + idOrdenCompra + "&NombreOrden=" + row.Folio, '_blank');
    },
    'click .verPDF': function (e, value, row, index) {
        var idOrdenCompra = row.IdOrdenCompra;
        var folio = row.Folio;

        window.open("ReporteOrdenCompra.aspx?IdOrdenCompra=" + idOrdenCompra + "&NombreOrden=" + folio);
    },
    'click .comentarios': function (e, value, row, index) {
        var idOrdenCompra = row.IdOrdenCompra;

        document.getElementById('idOCComentario').textContent = idOrdenCompra;
        var params = "{'IdOrdenCompra': '" + idOrdenCompra + "'}";
        $.ajax({
            async: true,
            url: "OrdenCompra.aspx/CargarComentarios",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var datos = "";
                var nodoTRAgregar = "";

                var JsonCombos;
                var jsonArray = $.parseJSON(data.d);

                $('#TablaPrincipalComentarios tbody').html('');
                $.each(jsonArray, function (index, value) {
                    nodoTRAgregar += "<tr>";
                    nodoTRAgregar += "  <td>" + value.ID + "</td>";
                    nodoTRAgregar += "  <td>" + value.Comentario + "</td>";
                    nodoTRAgregar += "  <td>" + value.NombreCompleto + "</td>";
                    nodoTRAgregar += "  <td>" + value.Fecha + "</td>";
                    nodoTRAgregar += "</tr>";
                });

                $('#TablaPrincipalComentarios tbody').append(nodoTRAgregar);
            }
        });
        $("#dvComentarios").modal();
    }
};

window.accionOC2Events = {
    'click .editarOC': function (e, value, row, index) {
        var idOrdenCompra = row.IdOrdenCompra;

        window.open("OrdenCompraDetalle.aspx?IdOrdenCompra=" + idOrdenCompra);
    },
    'click .eliminarOC': function (e, value, row, index) {
        var idOrdenCompra = row.IdOrdenCompra;
        var folio = row.Folio;

        document.getElementById('idOCEliminar').textContent = '';
        document.getElementById('idOCEliminarTexto').textContent = '¿Estás seguro de eliminar OC con código "' + folio + '" ?';
        document.getElementById('idOCEliminar').textContent = idOrdenCompra;
        $("#DelOCModal").modal();

    },
    'click .cancelarOC': function (e, value, row, index) {
        var idOrdenCompra = row.IdOrdenCompra;
        var folio = row.Folio;

        document.getElementById('idOCCancelar').textContent = '';
        document.getElementById('idOCCancelarTexto').textContent = '¿Estás seguro de cancelar OC con código "' + folio + '" ?';
        document.getElementById('idOCCancelar').textContent = idOrdenCompra;
        $("#CancelarOCModal").modal();
    }
};

window.accionOC3Events = {
    'click .subirArchivos': function (e, value, row, index) {
        //debugger;
        swal({
            title: 'Seleccione Cotizacion',
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

                var params = "{'IdOrdenCompra': '" + row.IdOrdenCompra +
                    "','FileName': '" + nombreArchivo +
                    "','fileSize': '" + fileSize +
                    "','filetype': '" + filetype +
                    "','fileExtension': '" + fileExtension +
                    "','Archivo': '" + e.target.result + "'}";

                //console.log(params);
                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "OrdenCompra.aspx/GuardarDocumentos",
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

                        $('#TablaOC').bootstrapTable('destroy');

                        CargarOrdenesCompra();

                    },
                    error: function (xhr, ajaxOptions, thrownError) {

                    }
                });


            }

            reader.readAsDataURL(file);

        });
    },
    'click .verArchivos': function (e, value, row, index) {

        var params = "{'IdOrdenCompra': '" + row.IdOrdenCompra +
            "','Opcion': '" + "1" + "'}";

        //console.log(params);

        $.ajax({
            async: true,
            url: "OrdenCompra.aspx/CargarDocumentos",
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

                    $('#ulFiles').append('<li>' + icono + '&nbsp<Button type="button" id="idDocumentoBoton" class="btn btn-default" value="' + value.IdDocumento.trim() + '" onclick="VerDoc(this);">' + value.NombreArchivo + '</Button>&nbsp&nbsp<button class="btn btn-danger eliminarDoc" id="btnEliminarArchivo" type="button" value="' + value.IdDocumento.trim() + '" rel="' + value.NombreArchivo + '"><i class="icon_close_alt2"></i></button></li><br>');

                });
            }

        });
        $("#GaleriaArchivosProyectosModal").modal();


    },
    'click .verPagos': function (e, value, row, index) {
        var idOrdenCompra = row.IdOrdenCompra;

        var params = "{'Opcion': '" + 27 + "'}";

        $.ajax({
            async: true,
            url: "OrdenCompra.aspx/CargarCombos",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                //debugger; OC031224-016
                var json = $.parseJSON(data.d);

                $('#cmbBancos').html('');
                $('#cmbBancos').html('<option value="-1">-- SELECCIONE BANCO --</option>');
                $.each(json, function (index, value) {
                    $("#cmbBancos").append('<option value="' + value.Id.toUpperCase() + '">' + value.Nombre.toUpperCase() + '</option>');
                });

                $('#cmbBancos').selectpicker('refresh');
                $('#cmbBancos').selectpicker('render');


                document.getElementById('idOCPago').textContent = idOrdenCompra;
                var params = "{'IdOrden': '" + idOrdenCompra + "'}";
                $.ajax({
                    async: true,
                    url: "OrdenCompra.aspx/CargarPagosOrdenes",
                    dataType: "json",
                    data: params,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data, textStatus) {

                        var datos = "";
                        var nodoTRAgregar = "";

                        var JsonCombos;
                        var jsonArray = $.parseJSON(data.d);

                        $('#TablaPrincipalPagos tbody').html('');
                        $.each(jsonArray, function (index, value) {
                            nodoTRAgregar += "<tr>";
                            nodoTRAgregar += "  <td>" + moment(value.FechaPago).format('YYYY-MM-DD') + "</td>";
                            nodoTRAgregar += "  <td>" + formato_numero(value.Pago, 2, '.', ',') + "</td>";
                            nodoTRAgregar += "  <td>" + value.Banco + "</td>";
                            nodoTRAgregar += "  <td>" + value.FolioFactura + "</td>";
                            if (value.esRoot) {
                                nodoTRAgregar += "  <td><button class='btn btn-danger eliminarDoc' id='btnEliminarPago' type='button' value='" + value.IdPago.trim() + "'><i class='icon_close_alt2'></i></button></td>";
                            }
                            else {
                                nodoTRAgregar += "  <td><button class='btn btn-danger eliminarDoc' id='btnEliminarPago' type='button' value='" + value.IdPago.trim() + "' disabled><i class='icon_close_alt2'></i></button></td>";
                            }
                            nodoTRAgregar += "</tr>";
                        });

                        $('#TablaPrincipalPagos tbody').append(nodoTRAgregar);
                    }
                });
                $("#dvPagos").modal();

            }
        });
        

       
    },
   
};

window.accionOC4Events = {
    'click .SubirCotProveedores': function (e, value, row, index) {
        idOrdenCompraCotComparativa = row.IdOrdenCompra;
        var folio = row.Folio;
        ultimoNumCotizacion = 1;
        //document.getElementById('idOCPago').textContent = idOrdenCompraCotComparativa;
        var params = "{'IdOrden': '" + idOrdenCompraCotComparativa + "'}";
        $.ajax({
            async: true,
            url: "OrdenCompra.aspx/CargarCotizacionesComparativa",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var datos = "";
                var nodoTRAgregar = "";

                var JsonCombos;
                var jsonArray = $.parseJSON(data.d);
                var valorVacio = false;
                $('#TablaPrincipalCotComparativa tbody').html('');
                $.each(jsonArray, function (index, value) {
                    //debugger;

                    nodoTRAgregar += "<tr>";
                    nodoTRAgregar += "  <td>" + value.NumCotizacion + "</td>";
                    nodoTRAgregar += "  <td>" + value.Proveedor + "</td>";
                    nodoTRAgregar += "  <td>" + formato_numero(value.Monto, 2, '.', ',') + "</td>";
                    if (value.ArchivoCot.trim() == "") {
                        nodoTRAgregar += '  <td>' + value.NombreCotizacion + '</td>';
                    }
                    else {

                        nodoTRAgregar += '  <td><Button type="button" id="idDocumentoBotonCotComparativa" class="btn btn-default" value="' + value.ArchivoCot.trim() + '" onclick="VerDocCotComparativas(this);">' + value.NombreCotizacion + '</button></td>';
                    }



                    if (value.Proveedor != "") {
                        nodoTRAgregar += "  <td><button class='btn btn-danger eliminarCot' id='btnEliminarCotizacion' type='button' value='" + value.NumCotizacion.trim() + "' onclick='EliminarCotizacion(" + value.NumCotizacion.trim() + ")'><i class='icon_close_alt2'></i></button></td>";
                    }
                    else {
                        nodoTRAgregar += "  <td><button class='btn btn-danger eliminarCot' id='btnEliminarCotizacion' type='button' value='" + value.NumCotizacion.trim() + "' disabled><i class='icon_close_alt2'></i></button></td>";
                    }
                    nodoTRAgregar += "</tr>";
                    //debugger;

                    if (value.Proveedor != "" && (!valorVacio)) {
                        ultimoNumCotizacion = ultimoNumCotizacion + 1;
                    }
                    else {
                        valorVacio = true;
                    }
                });

                $('#TablaPrincipalCotComparativa tbody').append(nodoTRAgregar);
            }
        });
        $("#dvCotComparativa").modal();

    },
};

$("#btnExaminarCotComparativa").click(function () {
    swal({
        title: 'Seleccione Cotizacion',
        input: 'file',
        allowOutsideClick: false,
        allowEscapeKey: false,
        allowEnterKey: false,
        showCloseButton: true
    }).then(function (file) {
        nombreArchivoCotComparativa = file.name;
        fileSizeCotComparativa = file.size;
        filetypeCotComparativa = file.type;
        fileExtensionCotComparativaCotComparativa = nombreArchivoCotComparativa.substring((nombreArchivoCotComparativa.lastIndexOf('.')));
        readerCotComparativa = new FileReader
        readerCotComparativa.onload = function (e) {
            //debugger;

            $("#txtCotizacionCotComparativa").val(nombreArchivoCotComparativa);
            archivoCotComparativa = e.target.result;
            //console.log("NombreArchivo: " + nombreArchivo);
            //console.log("fileSize: " + fileSize);
            //console.log("filetype: " + filetype);
            //console.log("fileExtension: " + fileExtension);

            //var params = "{'IdOrdenCompra': '" + row.IdOrdenCompra +
            //    "','FileName': '" + nombreArchivoCotComparativa +
            //    "','fileSize': '" + fileSizeCotComparativa +
            //    "','filetype': '" + filetypeCotComparativa +
            //    "','fileExtension': '" + fileExtensionCotComparativa +
            //    "','Archivo': '" + e.target.result + "'}";

            //console.log(params);
            //$.ajax({
            //    dataType: "json",
            //    async: true,
            //    url: "OrdenCompra.aspx/GuardarDocumentos",
            //    data: params,
            //    type: "POST",
            //    contentType: "application/json; charset=utf-8",
            //    success: function (msg) {
            //        //location.href = './frmProjects.aspx';

            //        swal({
            //            title: msg.d,
            //            timer: 2000
            //        }).then(() => {
            //            //CargarOrdenesCompra();
            //            location.reload(true);
            //        }).catch(swal.noop);

            //        $('#TablaOC').bootstrapTable('destroy');

            //        CargarOrdenesCompra();

            //    },
            //    error: function (xhr, ajaxOptions, thrownError) {

            //    }
            //});


        }

        readerCotComparativa.readAsDataURL(file);

    });
});

$("#btnAgregarCotizacion").click(function () {
    //debugger;
    //validar campos obligatorios
    var monto = "";

    if ($('#cmbProveedores option:selected').val() == '-1') {
        swal("Favor de seleccionar el Proveedor para poder continuar...");
        return;
    }

    if ($("#txtCotizacionCotComparativa").val().trim() == "") {
        swal("Favor de adjuntar el archivo de la Cotizacion para poder continuar...");
        return;
    }

    if (ultimoNumCotizacion > 3) {
        swal("Para poder agregar otra cotizacion, es necesario eliminar una primero...");
        return;
    }

    if ($("#txtMonto_CotComparativa").val().trim() == "") {
        monto = "0.00";
    }
    else {
        monto = formato_numero($("#txtMonto_CotComparativa").val().trim(), 2, '.', ',');
    }

    //string IdOrdenCompra, int NumCotizacion, string NombreCot, string ArchivoCot, string IdProveedor, string Monto, string IdUsuario
    var params = "{'IdOrdenCompra': '" + idOrdenCompraCotComparativa + "', 'NumCotizacion': '" + ultimoNumCotizacion + "', 'NombreCot': '" + nombreArchivoCotComparativa + "', 'ArchivoCot': '" + archivoCotComparativa + "', 'IdProveedor': '" + $('#cmbProveedores option:selected').val() + "', 'Monto': '" + monto + "'}";

    $.ajax({
        async: true,
        url: "OrdenCompra.aspx/GuardaCotizacionComparativa",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            $("#txtCotizacionCotComparativa").val("");
            archivoCotComparativa = "";
            nombreArchivoCotComparativa = "";
            location.href = 'OrdenCompra.aspx';
        }
    });
});

function EliminarCotizacion(numCot) {
   // debugger;

    //var numCot = $("#btnEliminarCotizacion").val();
    var params = "{'IdOrdenCompra': '" + idOrdenCompraCotComparativa + "', 'NumCotizacion': '" + numCot + "'}";

    $.ajax({
        async: true,
        url: "OrdenCompra.aspx/EliminaCotizacionComparativa",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            location.reload();
        }
    });
}

window.pagoMultipleEvents = {
    'click .pagosMultiples': function (e, value, row, index) {


        //debugger;
        var isChecked = e.target.checked;
        var idOrdenCompra = row.IdOrdenCompra;
        var folio = row.Folio;
        var NombreProyecto = row.NombreProyecto;
        var Total = row.Total;
        //debugger;
        var params = "{'IdOrdenCompra': '" + idOrdenCompra + "', 'Folio': '" + folio + "', 'NombreProyecto': '" + NombreProyecto + "', 'Total': '" + Total + "'}";

        if (isChecked) {
            $.ajax({
                async: true,
                url: "OrdenCompra.aspx/AgregaOrdenParaPagoMultiple",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {
                    
                    //var jsonArray = $.parseJSON(data.d);
                    cuantosPagosMultiples();
                    
                }
            });
        }
        else {
            $.ajax({
                async: true,
                url: "OrdenCompra.aspx/EliminaOrdenParaPagoMultiple",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {

                    //var jsonArray = $.parseJSON(data.d);

                    cuantosPagosMultiples();
                }
            });
        }
    }
};

function cuantosPagosMultiples() {
    //CuantosParaPagoMultiple
    var params = "{'id': '0'}";

    $.ajax({
        async: true,
        url: "OrdenCompra.aspx/CuantosParaPagoMultiple",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var value = $.parseJSON(data.d);
            //debugger;
            
            if (value > 0) {
                $('#btnmultipleOrdenes').removeAttr('disabled');
            }
            else {
                $('#btnmultipleOrdenes').attr('disabled', 'disabled');
            }
        }
    });
}

function cargarComentarios(idOrdenCompra) {
    var params = "{'IdOrdenCompra': '" + idOrdenCompra + "'}";
    $.ajax({
        async: true,
        url: "OrdenCompra.aspx/CargarComentarios",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var datos = "";
            var nodoTRAgregar = "";

            var JsonCombos;
            var jsonArray = $.parseJSON(data.d);

            $('#TablaPrincipalComentarios tbody').html('');
            $.each(jsonArray, function (index, value) {
                nodoTRAgregar += "<tr>";
                nodoTRAgregar += "  <td>" + value.ID + "</td>";
                nodoTRAgregar += "  <td>" + value.Comentario + "</td>";
                nodoTRAgregar += "  <td>" + value.NombreCompleto + "</td>";
                nodoTRAgregar += "  <td>" + value.Fecha + "</td>";
                nodoTRAgregar += "</tr>";
            });

            $('#TablaPrincipalComentarios tbody').append(nodoTRAgregar);
        }
    });
}

function cargarPagos(idOrdenCompra) {
    var params = "{'IdOrden': '" + idOrdenCompra + "'}";
    $.ajax({
        async: true,
        url: "OrdenCompra.aspx/CargarPagosOrdenes",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var datos = "";
            var nodoTRAgregar = "";

            var JsonCombos;
            var jsonArray = $.parseJSON(data.d);

            $('#TablaPrincipalPagos tbody').html('');
            $.each(jsonArray, function (index, value) {
                nodoTRAgregar += "<tr>";
                nodoTRAgregar += "  <td>" + moment(value.FechaPago).format('YYYY-MM-DD') + "</td>";
                nodoTRAgregar += "  <td>" + formato_numero(value.Pago, 2, '.', ',') + "</td>";
                nodoTRAgregar += "  <td>" + value.Banco + "</td>";
                nodoTRAgregar += "  <td>" + value.FolioFactura + "</td>";
                nodoTRAgregar += "  <td><button class='btn btn-danger eliminarDoc' id='btnEliminarPago' type='button' value='" + value.IdPago.trim() + "'><i class='icon_close_alt2'></i></button></td>";
                nodoTRAgregar += "</tr>";
            });

            $('#TablaPrincipalPagos tbody').append(nodoTRAgregar);
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

function CargarResumen(buscar) {
    var params = "{'valor': '" + buscar + "'}";

    $.ajax({
        async: true,
        url: "OrdenCompra.aspx/CargarResumen",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var jsonArray = $.parseJSON(data.d);


            $('#lblPesosSubTotal').html('');
            $('#lblPesosIVA').html('');
            $('#lblPesosTotal').html('');
            $('#lblPesosPagado').html('');
            $('#lblPesosPorPagar').html('');

            $('#lblDolaresSubTotal').html('');
            $('#lblDolaresIVA').html('');
            $('#lblDolaresTotal').html('');
            $('#lblDolaresPagado').html('');
            $('#lblDolaresPorPagar').html('');

            $.each(jsonArray, function (index, value) {
                
                if (value.Moneda == "MXN") {
                    $('#lblPesosSubTotal').text(formato_numero(value.SubTotal, 2, '.', ','));
                    $('#lblPesosIVA').text(formato_numero(value.IVA, 2, '.', ','));
                    $('#lblPesosTotal').text(formato_numero(value.Total, 2, '.', ','));
                    $('#lblPesosPagado').text(formato_numero(value.Pagado, 2, '.', ','));

                    $('#lblPesosPorPagar').text(formato_numero((value.Total - value.Pagado), 2, '.', ','));
                }
                else {
                    $('#lblDolaresSubTotal').text(formato_numero(value.SubTotal, 2, '.', ','));
                    $('#lblDolaresIVA').text(formato_numero(value.IVA, 2, '.', ','));
                    $('#lblDolaresTotal').text(formato_numero(value.Total, 2, '.', ','));
                    $('#lblDolaresPagado').text(formato_numero(value.Pagado, 2, '.', ','));
                    $('#lblDolaresPorPagar').text(formato_numero((value.Total - value.Pagado), 2, '.', ','));
                }
            });

        }
    });
}

$('#btnmultipleOrdenes').click(function () {
    document.getElementById('idOCPagoMultipleTexto').textContent = '¿Estás seguro de realizar el Pago de todas las OC en la siguiente lista?';

    var params = "{'Opcion': '" + 27 + "'}";

    $.ajax({
        async: true,
        url: "OrdenCompra.aspx/CargarCombos",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            //debugger; OC031224-016
            var json = $.parseJSON(data.d);

            $('#cmbBancosMultiple').html('');
            $('#cmbBancosMultiple').html('<option value="-1">-- SELECCIONE BANCO --</option>');
            $.each(json, function (index, value) {
                $("#cmbBancosMultiple").append('<option value="' + value.Id.toUpperCase() + '">' + value.Nombre.toUpperCase() + '</option>');
            });

            $('#cmbBancosMultiple').selectpicker('refresh');
            $('#cmbBancosMultiple').selectpicker('render');


            var params = "{'id': '1'}";
            $.ajax({
                async: true,
                url: "OrdenCompra.aspx/obtienePagosMultiplesPendientes",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {

                    var datos = "";
                    var nodoTRAgregar = "";

                    var JsonCombos;
                    var jsonArray = $.parseJSON(data.d);
                    var total = 0;

                    $('#TablaPrincipalPagosMultiples tbody').html('');
                    $.each(jsonArray, function (index, value) {
                        total += value.Total;
                        nodoTRAgregar += "<tr>";
                        nodoTRAgregar += "  <td>" + value.Folio + "</td>";
                        nodoTRAgregar += "  <td>" + value.NombreProyecto + "</td>";
                        nodoTRAgregar += "  <td>" + formato_numero(value.Total, 2, '.', ',')  + "</td>";
                        nodoTRAgregar += "</tr>";
                    });

                    $('#lblTotalPagado').text(formato_numero(total, 2, '.', ','));
                    $('#TablaPrincipalPagosMultiples tbody').append(nodoTRAgregar);
                }
            });
            $("#MultipagosOCModal").modal();
        }
    });
});

$('#btnPagoMultipleOC').click(function () {
    //debugger;
    var _fecha = $('#txtFechaPagoMultiple').val();

    if (!!_fecha) {
        //la fecha tiene valor y se manda como parametro
        var params = "{'_fecha': '" + $('#txtFechaPagoMultiple').val() +
            "','_Banco': '" + $('#cmbBancosMultiple').val() +
            "'}";

        $.ajax({
        async: true,
        url: "OrdenCompra.aspx/guardaPagosMultiples",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Ordenes pagadas.") {
                location.reload();
                swal(msg.d);
            }
            else {
                swal(msg.d);
            }
        }
    });
    }
    else {
        //no hay fecha seleccionada y hay que mandar mensaje de error
        swal('Es necesario seleccionar la Fecha de pago para poder continuar!!!');
    }

   

    


});

$('#btnExportar').click(function () {
    tableToExcel('table', 'OrdenesCompra');
});

$('#btnAgregarComentario').click(function () {
    var idOrdenCompra = document.getElementById('idOCComentario').textContent;

    var params = "{'IdOrdenCompra': '" + idOrdenCompra + "', 'Comentario': '" + $('#txtComentario').val() + "'}";

    $.ajax({
        async: true,
        url: "OrdenCompra.aspx/GuardarComentarios",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            cargarComentarios(idOrdenCompra);

            $('#txtComentario').val('');
        }
    });
});

$('#btnAgregarPago').click(function () {
    var idOrdenCompra = document.getElementById('idOCPago').textContent;

    var params = "{'IdOrdenCompra': '" + idOrdenCompra +
        "', 'FechaPago': '" + $('#txtFecha').val() +
        "', 'Monto': '" + $('#txtMonto').val() +
        "', 'Banco': '" + $('#cmbBancos').val() +
        "', 'FolioFactura': '" + $('#txtFolioFactura').val() +
        "'}";

    $.ajax({
        async: true,
        url: "OrdenCompra.aspx/GuardarPagos",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            cargarPagos(idOrdenCompra);

            $('#txtMonto').val('');
        }
    });
});

$('#btnEliminarOC').click(function () {
    var idOC = document.getElementById('idOCEliminar').textContent;

    var parametros = "{'pidOC': '" + idOC + "'}";
    $.ajax({
        dataType: "json",
        url: "OrdenCompra.aspx/EliminarOC",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "OC eliminada.") {
                //$("#txtModalEliminarMensajeOC").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                CargarOrdenesCompra();
                swal(msg.d);
            }
            else {
                //$("#txtModalEliminarMensajeOC").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
});

$('#btnCancelarOC').click(function () {
    var idOC = document.getElementById('idOCCancelar').textContent;
    var texto = $('#txtComentarioCancelar').val();

    var parametros = "{'pidOC': '" + idOC + "','Comentarios': '" + texto + "'}";
    //console.log(parametros);
    $.ajax({
        dataType: "json",
        url: "OrdenCompra.aspx/CancelarOC",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "OC cancelada.") {
                //$("#txtModalCancelarMensajeOC").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                CargarOrdenesCompra();
                swal(msg.d);
            }
            else {
                $("#txtModalCancelarMensajeOC").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
});

$(document).on('click', '#btnEliminarArchivo', function (event) {
    //;
    //var _boton = $(this);
    //var _item = $(this).parent().parent().find('td')[0].innerHTML;
    //var _producto = $(this).parent().parent().find('td')[2].innerHTML;
    //var _cantidad = $(this).parent().parent().find('td')[4].innerHTML;

    var nombreArchivo = $(this).attr('rel');
    var idDocumento = $(this).val();

    //debugger;

    swal({
        title: "Esta seguro que desea eliminar el documento " + nombreArchivo + "?",
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

        var params = "{'IdDocumento': '" + idDocumento + "'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'OrdenCompra.aspx/EliminarDocumento',
            data: params,
            success: function (data, textStatus) {
                if (data.d == 'Error') {
                    swal({
                        title: "Hay un error no se encontro el documento, favor de recargar la pagina!",
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
                else {
                    //CargarDatosDetalle();

                    swal({
                        title: "Se elimino correctamente el archivo.",
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

});

function enviadaFormatter(value) {
    var icono;
    //debugger;
    if (value == "1") {
        icono = '<span>ENVIADA</span> ';
    }
    else {
        icono = '<span>NO ENVIADA</span> ';
    }
    return icono;//'<i class="glyphicon glyphicon-ok"></i> ' + value;
}


function facturaFormatter(value) {
    var icono;
    //debugger;
    if (value == "PAGADO") {
        icono = '<span>PAGADA</span>';
    }
    else if (value == "PARCIAL") {
        icono = '<span>PARCIAL</span>';
    }
    else{
        icono = '<span>PENDIENTE</span>';
    }
    return icono;
}

function categoriaFormatter(value) {
    var icono;
    //debugger;
    if (value == "ManoObra") {
        icono = '<span>MANO DE OBRA</span>';
    }
    else if (value == "Consumible") {
        icono = '<span>CONSUMIBLE</span>';
    }
    else {
        icono = '<span>MATERIAL</span>';
    }
    return icono;
}

function accionOCFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Enviar OC" class="btn btn-warning enviarOC"> <i class="icon_mail"></i></span><input type="hidden" id="NombreOrden" value="">',
        '<span title="Ver PDF" class= "btn btn-success verPDF"> <i class="icon_search-2"></i></span>',
        '<span title="Comentarios" class= "btn btn-info comentarios"> <i class="icon_comment_alt"></i></span>',
        '</div>'
    ].join(' ');
}

function accionOC2Formatter(value, row, index) {
    if (rolusuario == "Recepcion almacen") {
        return [
            '<div class="btn-group">',
            '<span title="Editar" class="btn btn-success editarOC"> <i class="icon_pencil"></i></span>',
            '</div>'
        ].join(' ');
    }
    else {
        return [
            '<div class="btn-group">',
            '<span title="Editar" class="btn btn-success editarOC"> <i class="icon_pencil"></i></span>',
/*            '<span title="Eliminar" class="btn btn-danger eliminarOC"><i class="icon_minus_alt"></i></span>',*/
            '<span title="Cancelar" class="btn btn-danger cancelarOC"><i class="icon_close_alt2"></i></span>',
            '</div>'
        ].join(' ');
    }
}

function accionOC3Formatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Subir Archivos" class="btn btn-default subirArchivos"> <i class="icon_cloud-upload"></i></span>',
        '<span title="Ver Archivos" class="btn btn-info verArchivos"><i class="icon_documents"></i></span>',
        '<span title="Pagos" class="btn btn-warning verPagos"><i class="icon_wallet"></i></span>',
        '</div>'
    ].join(' ');
}

function accionOC4Formatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Subir Cotizaciones" class="btn btn-default SubirCotProveedores"> <i class="icon_cloud-upload"></i></span>',
        '<span title="Ver Archivos" class="btn btn-info verCotProveedores"><i class="icon_documents"></i></span>',
        '</div>'
    ].join(' ');
}
       
function pagoMultipleFormatter(value, row, index) {
    //debugger;
    var estatusPagado = row.EstatusPagado;
    if (estatusPagado == "PAGADO") {
        return [
            '<div class="form-check form-switch">',
            '<input class="form-check-input" type="checkbox" id="chk_' + row.Folio + '" disabled checked/>',
            '</div>'
        ].join(' ');
    }
    else if (estatusPagado == "PARCIAL") {
        return [
            '<div class="form-check form-switch">',
            '<input class="form-check-input" type="checkbox" id="chk_' + row.Folio + '"/>',
            '</div>'
        ].join(' ');
    }
    else {
        return [
            '<div class="form-check form-switch" >',
            '<input class="form-check-input pagosMultiples" type="checkbox" id="chk_' + row.Folio + '"/>',
            '</div>'
        ].join(' ');
    }
   
}

function queryParams(params) {
    alert('queryParams: ' + JSON.stringify(params));
    return params;
    //return {
    //    type: 'owner',
    //    sort: 'updated',
    //    direction: 'desc',
    //    per_page: 100,
    //    page: 1
    //};
}


var tableToExcel = (function () {
    var uri = 'data:application/vnd.ms-excel;base64,', template = '<html xmlns:o="urn:schemas-microsoft-com:office:office"xmlns:x="urn:schemas-microsoft-com:office:excel"xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>'
        , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
        , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }
    return function (table, name) {
        if (!table.nodeType) table = document.getElementById(table)
        var ctx = { worksheet: name || 'Worksheet', table: table.innerHTML }
        window.location.href = uri + base64(format(template, ctx))
    }
})()



$(document).on('click', '.eliminarDoc', function (event) {
    //;
    //var _boton = $(this);
    //var _item = $(this).parent().parent().find('td')[0].innerHTML;
    //var _producto = $(this).parent().parent().find('td')[2].innerHTML;
    //var _cantidad = $(this).parent().parent().find('td')[4].innerHTML;

    //var nombreArchivo = $(this).attr('rel');
    var idDocumento = $(this).val();

    //debugger;

    swal({
        title: "Esta seguro que desea eliminar el pago?",
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

        var params = "{'IdPago': '" + idDocumento + "'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'OrdenCompra.aspx/EliminarPago',
            data: params,
            success: function (data, textStatus) {
                if (data.d == 'Error') {
                    swal({
                        title: "Hay un error no se encontro el pago, favor de recargar la pagina!",
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
                else {
                    //CargarDatosDetalle();

                    swal({
                        title: "Se elimino correctamente el pago.",
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

});