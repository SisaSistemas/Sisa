$(document).ready(function () {
    var URLactual = window.location;

    if (URLactual.href.indexOf("frmSolicitudesCotizaciones.aspx") > -1) {

        //document.body.style.zoom = "80%";
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarCotizaciones();
        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);

    }

    function CargarCotizaciones() {
        $.ajax({
            dataType: "json",
            url: "frmSolicitudesCotizaciones.aspx/ObtieneSolicitudesCotizaciones",
            async: true,
            //data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonArray = $.parseJSON(data.d);
               
                //$('#TablaOC').bootstrapTable('destroy');

                data = jsonArray;

                $('#TablaCotizacion').bootstrapTable({
                    data: data,
                    detailView: true,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'idSolicitudCotizacion',
                    uniqueId: 'idSolicitudCotizacion',
                    onSearch: function (text) {
                        //CargarResumen(text);
                    },
                    onExpandRow: function (index, row, $detail) {
                        //$detail.hide().html(row.IdMaterial).fadeIn('slow');
                        $detail.html('Loading request...');
                        var params = "{'idSolicitud': '" + row.idSolicitudCotizacion + "'}";
                        $.ajax({
                            dataType: "json",
                            url: "frmSolicitudesCotizaciones.aspx/ObtieneCotizaciones",
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
                                        title: 'Folio',
                                        formatter: 'formatterFolio',
                                    }, {
                                        field: 'Concepto',
                                        title: 'Concepto'
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
                                    idField: 'IdCotizaciones',
                                    uniqueId: 'IdCotizaciones',
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
});

$('#btnSelect').click(function () {

    window.open("../Ventas/frmSolicitudCotizacion.aspx");
});

function dateFormat(value, row, index) {
    return moment(value).format('YYYY-MM-DD');
}

window.accionCotEvents = {
    'click .crearCotizacion': function (e, value, row, index) {
        //debugger;
        swal({
            title: "Esta seguro que desea crear la COTIZACION O UN BIDDING?",
            type: "warning",
            allowOutsideClick: false,
            allowEscapeKey: true,
            allowEnterKey: false,
            showCancelButton: true,
            showCloseButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#28a745',
            confirmButtonText: 'Bidding',
            cancelButtonText: 'Cotizacion'
        }).then(function () {
            //debugger;

            swal({
                title: "Esta seguro que desea crear un Bidding?",
                type: "question",
                allowOutsideClick: false,
                allowEscapeKey: false,
                allowEnterKey: false,
                showCloseButton: true,
                showCancelButton: true,
                confirmButtonText: 'SI',
                cancelButtonText: 'NO'
            }).then(function (res) {
                //console.log(res);
                var params = "{'IdSolicitudCotizacion': '" + row.idSolicitudCotizacion +
                    "','Tipo': 'Bidding" +
                    "'}";

                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "frmSolicitudesCotizaciones.aspx/GuardarTipoCotizacion",
                    data: params,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data, textStatus) {
                        //console.log(data);
                        if (data.d == "Tipo Actualizada.") {
                            window.open("../BiddingsSisa/SolicitudBidding.aspx?idSolicitud=" + row.idSolicitudCotizacion);
                        }
                        else {
                            Swal.fire('error: ' + data.d, '', 'error');
                        }

                    },
                    error: function (xhr, ajaxOptions, thrownError) {

                    }
                });

            });



            //swal({
            //    title: 'Guardando Datos!',
            //    text: 'Espere un Momento...',
            //    onOpen: function () {
            //        swal.showLoading()
            //    }
            //});            

            //$.ajax({
            //    dataType: "json",
            //    async: true,
            //    url: "OrdenCompraDetalle.aspx/CrearOrdenCompra",
            //    data: params,
            //    type: "POST",
            //    contentType: "application/json; charset=utf-8",
            //    success: function (data, textStatus) {


            //    },
            //    error: function (xhr, ajaxOptions, thrownError) {

            //    }
            //});


        }, function (dismiss) {
            // dismiss can be 'cancel', 'overlay',
            // 'close', and 'timer'
            if (dismiss === 'cancel') {

                swal({
                    title: "Esta seguro que desea crear una COTIZACIÓN?",
                    type: "question",
                    allowOutsideClick: false,
                    allowEscapeKey: false,
                    allowEnterKey: false,
                    showCloseButton: true,
                    showCancelButton: true,
                    confirmButtonText: 'SI',
                    cancelButtonText: 'NO'
                }).then(function (res) {

                    var params = "{'IdSolicitudCotizacion': '" + row.idSolicitudCotizacion +
                        "','Tipo': 'Cotizacion" +
                        "'}";

                    $.ajax({
                        dataType: "json",
                        async: true,
                        url: "frmSolicitudesCotizaciones.aspx/GuardarTipoCotizacion",
                        data: params,
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data, textStatus) {
                            //console.log(data);
                            if (data.d == "Tipo Actualizada.") {
                                window.open("CotizacionesDetalles.aspx?idCotizacion=0&idSolicitud=" + row.idSolicitudCotizacion);
                            }
                            else {
                                Swal.fire('error: ' + data.d, '', 'error');
                            }

                        },
                        error: function (xhr, ajaxOptions, thrownError) {

                        }
                    });

                }, function (dis) {
                    if (dis === 'cancel') {
                        console.log('NO');
                    }
                });
            }
        });

        //window.open("CotizacionesDetalles.aspx?idCotizacion=0&idSolicitud=" + row.idSolicitudCotizacion);
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

    },
    'click .asignarFecha': function (e, value, row, index) {

        $('#btnGuardarFecha').attr('rel', row.idSolicitudCotizacion)
        $("#dvFecha").modal();

    }
};

window.accionCotDetEvents = {
    'click .verPDF': function (e, value, row, index) {

        if (row.DocumentoPdf != null) {
            $('#testmodalpdf').html('');

            document.getElementById('txtTipoDocumento').textContent = "";

            document.getElementById('txtidProyectoArchivo').textContent = row.IdCotizaciones;
            $('#testmodalpdf').append('<object id="visorPDF" data="' + row.DocumentoPdf + '" type="application/pdf" style="width:100%; height: 800px;"></object>');

            $("#dvPDF").modal();
        }
        else {
            swal('No existe el archivo!.');
        }
        


    },
    'click .modificarCotizacion': function (e, value, row, index) {
        window.open("CotizacionesDetalles.aspx?idCotizacion=" + row.IdCotizaciones + "&idSolicitud=" + row.idRequisicion);
    },

};

function accionCotFormatter(value, row, index) {

    var deshabilitado = "disabled";
    var deshabilitadoCrear = "disabled";

    if (row.FechaEntrega == null) {
        deshabilitado = "";
    }

    if (row.FolioTipo == null) {
        deshabilitadoCrear = "";
    }

    return [
        '<div class="btn-group">',
        '<span title="Asignar Fecha" class="btn btn-default asignarFecha ' + deshabilitado + '"><i class="fa-solid fa-calendar-days"></i></span>',
        '<span title="Crear Cotización" class="btn btn-default crearCotizacion ' + deshabilitadoCrear + '"><i class="fa-solid fa-file-circle-plus"></i></span>',
        '<span title="Ver Archivos" class="btn btn-info verArchivos"><i class="icon_documents"></i></span>',
        '</div>'
    ].join(' ');
    
}

function accionCotDetFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Ver PDF" class="btn btn-default verPDF"><i class="fa-regular fa-file-pdf"></i></span>',
        '<span title="Modificar Cotización" class="btn btn-warning modificarCotizacion"><i class="fa-solid fa-pencil"></i></span>',
        '</div>'
    ].join(' ');
}

function estatusFormatter(value, row, index) {

    if (row.Estatus == 0) {
        return ['CREADA'].join(' ');
    }
    else if (row.Estatus == 1) {
        return ['EN PROCESO'].join(' ');
    }
    else if (row.Estatus == 2) {
        return ['ENVIADA'].join(' ');
    }
    else if (row.Estatus == 3) {
        return ['TERMINADA'].join(' ');
    }
    //return [
    //    '<div class="btn-group">',
    //    '<span title="Ver PDF" class="btn btn-default verPDF"><i class="fa-regular fa-file-pdf"></i></span>',
    //    '<span title="Modificar Cotización" class="btn btn-warning modificarCotizacion"><i class="fa-solid fa-pencil"></i></span>',
    //    '</div>'
    //].join(' ');
}

function formatterFolio(value, row, index) {

    if (row.FolioModificacion == "00") {
        return [
            row.NoCotizaciones,
        ].join(' ');
    }
    else {
        return [
            row.NoCotizaciones + '-' + row.FolioModificacion,
        ].join(' ');
    }
    
}

function formatterEstatus(value, row, index) {

    if (row.Estatus == 0) {
        return [
            "ELIMINADA",
        ].join(' ');
    } else if (row.Estatus == 1) {
        return [
            "CREADA",
        ].join(' ');
    } else if (row.Estatus == 2) {
        return [
            "CANCELADA",
        ].join(' ');
    } else if (row.Estatus == 3) {
        return [
            "GANADA",
        ].join(' ');
    } else if (row.Estatus == 4) {
        return [
            "ENVIADA",
        ].join(' ');
    } else if (row.Estatus == 5) {
        return [
            "PROYECTO",
        ].join(' ');
    }
}

$('#btnGuardarFecha').click(function () {
    var id = $(this).attr('rel');
    //console.log(id);

    var params = "{'IdSolicitudCotizacion': '" + id +
        "','Fecha': '" + $('#txtFecha').val() + "'}";

    $.ajax({
        async: true,
        url: "frmSolicitudesCotizaciones.aspx/GuardarFecha",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            if (data.d == "Fecha Actualizada.") {
                swal(data.d);

                location.reload();
            }
            else {
                swal(data.d);
            }
        }

    });

});