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
                                    idField: 'IdBiddingDet',
                                    uniqueId: 'IdBiddingDet'
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

    window.open("SolicitudBidding.aspx");
});


function dateFormat(value, row, index) {
    return moment(value).format('YYYY-MM-DD');
}

window.accionBidEvents = {
    'click .crearCotizacion': function (e, value, row, index) {
        //debugger;
        window.open("../Ventas/CotizacionesDetalles.aspx?idCotizacion=0&idSolicitud=" + row.IdSolicitudCotizacion + "&idBidding=" + row.IdBiddings);
    },
    'click .agregarParticipante': function (e, value, row, index) {

        var params = "{'IdSolicitudCotizacion': '" + row.IdSolicitudCotizacion +
            "','Opcion': '" + "1" + "'}";

        //console.log(params);

       

        $.ajax({
            async: true,
            url: "Biddings.aspx/CargarParticipantes",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                $("#slctParticipante").append('<option value="0">Selecciona el Participante...</option>');

                var json = JSON.parse(data.d);

                $(json).each(function (index, item) {
                    //debugger;
                    $("#slctParticipante").append('<option value="' + item.IdProveedor.toUpperCase() + '">' + item.NombreComercial.toUpperCase() + '</option>');
                });

                $('#slctParticipante').selectpicker('refresh');
                $('#slctParticipante').selectpicker('render');

                //var jsonArray = $.parseJSON(data.d);

                //$('#ulFiles').html('');
                //var cont = 1;
                //$.each(jsonArray, function (index, value) {
                //    var icono = '<i class="icon_document_alt"></i>';

                //    $('#ulFiles').append('<li>' + icono + '&nbsp<Button type="button" id="idDocumentoBoton" class="btn btn-default" value="' + value.idArchivosIngenieria_CCM.trim() + '" onclick="VerDoc(this);">' + value.FileName + '</Button>&nbsp&nbsp<button class="btn btn-danger eliminarDoc" id="btnEliminarArchivo" type="button" value="' + value.idArchivosIngenieria_CCM.trim() + '" rel="' + value.FileName + '"><i class="icon_close_alt2"></i></button></li><br>');

                //});
            }

        });
        //debugger;
        $('#btnGuardarModal').attr('rel', row.IdBiddings);

        $("#dvAgregarParticipante").modal();

        //$('#btnGuardar').attr('rel', row.IdBiddingDet);

        

    },
    'click .verComentarios': function (e, value, row, index) {

        var params = "{'IdBidding': '" + row.IdBiddings +
            "','Opcion': '" + "1" + "'}";

        //console.log(params);

        $.ajax({
            async: true,
            url: "Biddings.aspx/CargarComentarios",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var jsonArray = $.parseJSON(data.d);

                $('#TablaComentarios').bootstrapTable('destroy');

                data = jsonArray;

                $('#TablaComentarios').bootstrapTable({
                    data: data,
                    detailView: false,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'IdBiddingComentario',
                    uniqueId: 'IdBiddingComentario',
                    onSearch: function (text) {
                        //CargarResumen(text);
                    },
                    onExpandRow: function (index, row, $detail) {
                        //$detail.hide().html(row.IdMaterial).fadeIn('slow');
                    },
                    onCollapseRow: function (index, row, $detail) {
                        //$detail.clone().insertAfter($detail).fadeOut('slow', function () {
                        //    $(this).remove()
                        //})
                    }
                });
            }

        });

        $("#dvVerComentarios").modal();

    }
};

function accionBidFormatter(value, row, index) {

    var deshabilitado = "disabled";

    if (row.Estatus == "1") {
        deshabilitado = "";
    }

    return [
        '<div class="btn-group">',
        '<span title="Crear Cotización" class="btn btn-default crearCotizacion" ' + deshabilitado + '><i class="fa-solid fa-file-circle-plus"></i></span>',
        '<span title="Agregar Participante" class="btn btn-info agregarParticipante"><i class="fa-solid fa-person-circle-plus"></i></span>',
        '<span title="Ver Comentarios" class="btn btn-success verComentarios"><i class="fa-solid fa-comment-dots"></i></span>',
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

function EstatusFormmater(value, row, index) {

    if (row.Estatus == 0) {
        return [
            "CREADA",
        ].join(' ');
    } else if (row.Estatus == 1) {
        return [
            "TERMINADA",
        ].join(' ');
    } 
}

function accionCotDetFormatter(value, row, index) {
    var deshabilitado = "";
    
    if (row.CostoCotizacion == "") {
        deshabilitado = "disabled";
    }

    if (row.Estatus == "2") {
        deshabilitado = "disabled";
    }

    return [
        '<div class="btn-group">',
        '<span title="Ver PDF" class="btn btn-default verPDF"><i class="fa-regular fa-file-pdf"></i></span>',
        '<span title="Ganador" class="btn btn-default selGanador" ' + deshabilitado + '><i class="fa-solid fa-trophy"></i></span>',
        '</div>'
    ].join(' ');
}

window.accionCotDetEvents = {
    'click .crearCotizacion': function (e, value, row, index) {
        //debugger;
        window.open("CotizacionesDetalles.aspx?idCotizacion=0&idSolicitud=" + row.idSolicitudCotizacion);
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

        



    },
    'click .selGanador': function (e, value, row, index) {
        //debugger;

        $('#btnGuardar').attr('rel', row.IdBiddingDet);

        $('#dvComentarios').modal();
    }

};

$('#btnGuardarModal').click(function () {
    //console.log();

    var parametros = "{'IdBidding': '" + $(this).attr('rel') +
        "', 'IdProveedor': '" + $('#slctParticipante').val() +
        "', 'Opt': '" + 1 + "'}";

    //console.log(parametros);

    $.ajax({
        dataType: "json",
        url: "Biddings.aspx/GuardarParticipante",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {

            //debugger;
            if (msg.d == "Participante Agregado Correctamente!.") {
                swal(msg.d);
                //redireccionar a la pagina del listado de las cotizaciones
                //window.location.replace('frmSolicitudesCotizaciones.aspx');
            }
            else {
                swal(msg.d);
            }
        }
    });

});

function formatterFechaEntrega(value, row, index) {
    var fecha = moment(value).format('YYYY-MM-DD');
    if (fecha == "Invalid date") {
        fecha = "Pendiente Prog Fecha";
    }

    return fecha;
}

$('#btnGuardar').click(function () {

    var id = $(this).attr('rel');

    var parametros = "{'IdBiddingDet': '" + id +
        "', 'Comentario': '" + $('#txtComentario').val() +
        "', 'Opt': '" + 1 + "'}";

    //console.log(parametros);
    $.ajax({
        dataType: "json",
        url: "Biddings.aspx/CreaCotizacion",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {

            //debugger;
            if (msg.d == "Bidding guardado correctamente!!!") {
                swal(msg.d);
                //redireccionar a la pagina del listado de las cotizaciones
                //window.location.replace('frmSolicitudesCotizaciones.aspx');
            }
            else {
                swal(msg.d);
            }
        }
    });

});