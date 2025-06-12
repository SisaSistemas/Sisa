$(document).ready(function () {
    var URLactual = window.location;

    if (URLactual.href.indexOf("Biddings.aspx") > -1) {

        //document.body.style.zoom = "80%";
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarSolicitudes();
        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);

    }

    
});

function CargarSolicitudes() {
    $.ajax({
        dataType: "json",
        url: "Biddings.aspx/ObtieneSolicitudes",
        async: true,
        //data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var jsonArray = $.parseJSON(data.d);

            //$('#TablaOC').bootstrapTable('destroy');

            data = jsonArray;

            $('#TablaSolicitud').bootstrapTable({
                data: data,
                detailView: true,
                striped: true,
                //pagination: true,
                //onlyInfoPagination: true,
                pageSize: 100,
                idField: 'IdBiddings',
                uniqueId: 'IdBiddings',
                onSearch: function (text) {
                    //CargarResumen(text);
                },
                onExpandRow: function (index, row, $detail) {
                    //$detail.hide().html(row.IdMaterial).fadeIn('slow');
                    $detail.html('Loading request...');
                    var params = "{'IdBiddings': '" + row.IdBiddings + "'}";
                    $.ajax({
                        dataType: "json",
                        url: "Biddings.aspx/ObtieneBiddingsDet",
                        async: true,
                        data: params,
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            var jsonArray = $.parseJSON(data.d);

                            //$('#TablaOC').bootstrapTable('destroy');

                            data = jsonArray;
                            //debugger;
                            $detail.html('<table></table>').find('table').bootstrapTable({
                                columns: [{
                                    field: 'Proveedor',
                                    title: 'Proveedor'
                                }, {
                                    field: 'FolioCotizacion',
                                    title: 'Folio'
                                }, {
                                    field: 'Concepto',
                                    title: 'Concepto'
                                }, {
                                    field: 'CostoCotizacion',
                                    title: 'Costo'
                                }, {
                                    title: 'Fecha Entrega',
                                    formatter: 'formatterFechaEntrega'
                                }, {
                                    title: 'Estatus',
                                    formatter: 'formatterEstatus'
                                }, {
                                    title: 'Acciones',
                                    formatter: 'accionCotDetFormatter',
                                    events: 'accionCotDetEvents'
                                }],
                                data: data,
                                striped: true,
                                idField: 'IdBiddingsDet',
                                uniqueId: 'IdBiddingsDet',
                            });
                        }
                    });
                },
                onCollapseRow: function (index, row, $detail) {
                    //$detail.clone().insertAfter($detail).fadeOut('slow', function () {
                    //    $(this).remove()
                    //})
                }
            });
        }
    });
}

function dateFormat(value, row, index) {
    return moment(value).format('YYYY-MM-DD');
}

window.accionCotEvents = {
    'click .crearCotizacion': function (e, value, row, index) {
        //debugger;
        window.open("CotizacionesDetalles.aspx?idCotizacion=0&idSolicitud=" + row.idSolicitudCotizacion);
    },
    'click .verArchivos': function (e, value, row, index) {

        var params = "{'IdSolicitudCotizacion': '" + row.idSolicitudCotizacion +
            "','Opcion': '" + "1" + "'}";

        //console.log(params);

        $.ajax({
            async: true,
            url: "frmSolicitudesCotizaciones.aspx/CargarDocumentos",
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

                    $('#ulFiles').append('<li>' + icono + '&nbsp<Button type="button" id="idDocumentoBoton" class="btn btn-default" value="' + value.idArchivosIngenieria_CCM.trim() + '" onclick="VerDoc(this);">' + value.FileName + '</Button>&nbsp&nbsp<button class="btn btn-danger eliminarDoc" id="btnEliminarArchivo" type="button" value="' + value.idArchivosIngenieria_CCM.trim() + '" rel="' + value.FileName + '"><i class="icon_close_alt2"></i></button></li><br>');

                });
            }

        });

        $("#GaleriaArchivosProyectosModal").modal();

    }
};

function accionCotFormatter(value, row, index) {
    return [
        '<div class="btn-group">',
        '<span title="Crear Cotización" class="btn btn-default crearCotizacion"><i class="fa-solid fa-file-circle-plus"></i></span>',
        '<span title="Ver Archivos" class="btn btn-info verArchivos"><i class="icon_documents"></i></span>',
        '</div>'
    ].join(' ');
    
}

function formatterEstatus(value, row, index) {

    if (row.Estatus == 0) {
        return [
            "CREADA",
        ].join(' ');
    } else if (row.Estatus == 1) {
        return [
            "ENTREGADA",
        ].join(' ');
    } else if (row.Estatus == 2) {
        return [
            "GANADA",
        ].join(' ');
    } else if (row.Estatus == 3) {
        return [
            "TERMINADA",
        ].join(' ');
    }
}

function accionCotDetFormatter(value, row, index) {

    if (row.Estatus == 0) {
        return [
            '<div class="btn-group">',
            '<span title="Agregar Cotizacion" class="btn btn-default agregarCotizacion"><i class="fa-solid fa-file-circle-plus"></i></span>',
            '<span title="Subir Archivos" class="btn btn-default subirArchivos" disabled> <i class="icon_cloud-upload"></i></span>',
            '<span title="Ver PDF" class="btn btn-info verPDF"><i class="fa-regular fa-file-pdf"></i></span>',

            '</div>'
        ].join(' ');
    }
    else {
        return [
            '<div class="btn-group">',
            '<span title="Agregar Cotizacion" class="btn btn-default agregarCotizacion" disabled><i class="fa-solid fa-file-circle-plus"></i></span>',
            '<span title="Subir Archivos" class="btn btn-default agregarArchivos"> <i class="icon_cloud-upload"></i></span>',
            '<span title="Ver PDF" class="btn btn-info verPDF"><i class="fa-regular fa-file-pdf"></i></span>',

            '</div>'
        ].join(' ');
    }
   
}

window.accionCotDetEvents = {
    'click .agregarCotizacion': function (e, value, row, index) {
        //debugger;

        $('#btnGuardarCotizacion').attr('rel', row.IdBiddingDet);


        $('#AddCotizacionProveedor').modal();
    },
    'click .agregarArchivos': function (e, value, row, index) {
        //debugger;
        swal({
            title: 'Seleccione Archivos',
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

                var params = "{'IdBiddingDet': '" + row.IdBiddingDet +
                    "','FileName': '" + nombreArchivo +
                    "','fileSize': '" + fileSize +
                    "','filetype': '" + filetype +
                    "','fileExtension': '" + fileExtension +
                    "','Archivo': '" + e.target.result + "'}";

                //console.log(params);
                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "Biddings.aspx/GuardarDocumentos",
                    data: params,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        //location.href = './frmProjects.aspx';

                        swal({
                            title: msg.d,
                            timer: 2000
                        }).then(() => {
                            //$('#TablaCotizacion').bootstrapTable('destroy');
                            //CargarCotizaciones();
                            //CargarOrdenesCompra();
                            location.reload(true);
                        }).catch(swal.noop);

                        //$('#TablaOC').bootstrapTable('destroy');

                        //CargarOrdenesCompra();

                    },
                    error: function (xhr, ajaxOptions, thrownError) {

                    }
                });


            }

            reader.readAsDataURL(file);

        });
    },
    'click .verPDF': function (e, value, row, index) {

        var params = "{'IdBiddingDet': '" + row.IdBiddingDet +
            "','Opcion': '" + "1" + "'}";

        //console.log(params);

        $.ajax({
            async: true,
            url: "Biddings.aspx/CargarPDF",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var jsonArray = $.parseJSON(data.d);

                //$.each(jsonArray, function (index, value) {
                //    var icono = '<i class="icon_document_alt"></i>';

                //    $('#ulFiles').append('<li>' + icono + '&nbsp<Button type="button" id="idDocumentoBoton" class="btn btn-default" value="' + value.idArchivosIngenieria_CCM.trim() + '" onclick="VerDoc(this);">' + value.FileName + '</Button>&nbsp&nbsp<button class="btn btn-danger eliminarDoc" id="btnEliminarArchivo" type="button" value="' + value.idArchivosIngenieria_CCM.trim() + '" rel="' + value.FileName + '"><i class="icon_close_alt2"></i></button></li><br>');

                //});

                if (jsonArray[0].File != null) {
                    $('#testmodalpdf').html('');

                    document.getElementById('txtTipoDocumento').textContent = "";

                    document.getElementById('txtidProyectoArchivo').textContent = row.IdBiddingDet;
                    $('#testmodalpdf').append('<object id="visorPDF" data="' + jsonArray[0].File + '" type="application/pdf" style="width:100%; height: 800px;"></object>');

                    $("#dvPDF").modal();
                }
                else {
                    swal('No existe el archivo!.');
                }
            }

        });

        // $("#GaleriaArchivosProyectosModal").modal();





    }

};

function formatterFechaEntrega(value, row, index) {
    var fecha = moment(value).format('YYYY-MM-DD');
    if (fecha == "Invalid date") {
        fecha = "Pendiente Prog Fecha";
    }

    return fecha;
}

$('#btnGuardarCotizacion').click(function () {
    var txtFolioCotizacion = $('#txtFolioCotizacion').val();
    var txtConcepto = $('#txtConcepto').val();
    var txtCostoCotizacion = $('#txtCostoCotizacion').val();

    var idBidding = $(this).attr('rel');

    if (txtFolioCotizacion == "") {
        swal("Favor de llenar el campo Folio");
        return;
    }

    if (txtConcepto == "") {
        swal("Favor de llenar el campo Concepto");
        return;
    }

    if (txtCostoCotizacion == "") {
        swal("Favor de llenar el campo Costo Cotizacion");
        return;
    }

    var parametros = "{'pIdBiddingDet': '" + idBidding + "', 'pFolio': '" + txtFolioCotizacion + "', 'pConcepto': '" + txtConcepto + "', 'pCostoCotizacion': '" + txtCostoCotizacion + "'}";
    $.ajax({
        dataType: "json",
        url: "Biddings.aspx/GuardarCotizacion",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Cotizacion actualizada.") {
                //$("#AddMsgProveedores").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                CargarSolicitudes();
                swal(msg.d);

                $("#AddCotizacionProveedor .close").click()
            }
            else {
                //$("#AddMsgProveedores").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
});