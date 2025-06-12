$(document).ready(function () {
    var URLactual = window.location;

    if (URLactual.href.indexOf("PaquetesCotizaciones.aspx") > -1) {

        //document.body.style.zoom = "80%";
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarPaquetes();
        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);


    }

    function CargarPaquetes() {
        $.ajax({
            dataType: "json",
            url: "PaquetesCotizaciones.aspx/ObtienePaquetes",
            async: true,
            //data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonArray = $.parseJSON(data.d);

                //$('#TablaOC').bootstrapTable('destroy');

                data = jsonArray;

                $('#TablaPaquetes').bootstrapTable({
                    data: data,
                    detailView: false,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'IdPaqueteEnc',
                    uniqueId: 'IdPaqueteEnc',
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
    }
});

$('#btnSelect').click(function () {

    window.open("PaqueteCotizaciones.aspx?idPaquete=0");
});

function accionPaqFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Modificar Paquete" class="btn btn-default modificarPaquete"><i class="fa-solid fa-file-circle-plus"></i></span>',
        '</div>'
    ].join(' ');
}

window.accionPaqEvents = {
    'click .modificarPaquete': function (e, value, row, index) {
        //debugger;
        window.open("PaqueteCotizaciones.aspx?idPaquete=" + row.IdPaqueteEnc);
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

function dateFormat(value, row, index) {
    return moment(value).format('YYYY-MM-DD');
}