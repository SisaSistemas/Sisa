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
                        $detail.hide().html(row.idSolicitudCotizacion).fadeIn('slow');

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


function dateFormat(value, row, index) {
    var fecha = moment(value).format('YYYY-MM-DD');
    if (fecha == "Invalid date") {
        fecha = "Pendiente Prog Fecha";
    }
    
    return fecha;
}

$('#btnSelect').click(function () {
    
    window.open("SolicitarCotizacion.aspx");
});

window.accionCotEvents = {
    'click .subirArchivos': function (e, value, row, index) {
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

                var params = "{'IdSolicitudCotizacion': '" + row.idSolicitudCotizacion +
                    "','FileName': '" + nombreArchivo +
                    "','fileSize': '" + fileSize +
                    "','filetype': '" + filetype +
                    "','fileExtension': '" + fileExtension +
                    "','Archivo': '" + e.target.result + "'}";

                //console.log(params);
                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "frmSolicitudesCotizaciones.aspx/GuardarDocumentos",
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
    'click .verPDFSol': function (e, value, row, index) {

        var idSolicitud = row.idSolicitudCotizacion;
        var folio = row.Folio;

        window.open("ReporteSolicitudCotizacion.aspx?IdSolicitudCotizacion=" + idSolicitud + "&Folio=" + folio);



    }
};

window.accionCotDetEvents = {
    'click .crearCotizacion': function (e, value, row, index) {
        //debugger;
        window.open("CotizacionesDetalles.aspx?idCotizacion=0&idSolicitud=" + row.idSolicitudCotizacion);
    },
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



    }

};

function accionCotFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Subir Archivos" class="btn btn-default subirArchivos"> <i class="icon_cloud-upload"></i></span>',
        '<span title="Ver Archivos" class="btn btn-info verArchivos"><i class="icon_documents"></i></span>',
        '<span title="Ver PDF" class="btn btn-success verPDFSol"><i class="icon_documents"></i></span>',
        '</div>'
    ].join(' ');
}

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
            url: 'frmSolicitudesCotizaciones.aspx/EliminarDocumento',
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

function accionCotDetFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Ver PDF" class="btn btn-default verPDF"><i class="fa-regular fa-file-pdf"></i></span>',
        '</div>'
    ].join(' ');
}