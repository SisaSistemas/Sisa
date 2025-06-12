$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("ProveedoresCalificacion.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarProveedores();
        //CargarEmpresas();
        //CargarAreas();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }

    function CargarProveedores() {

        var parametros = "{'pid': '1', 'pIdProveedor': '0'}";
        $.ajax({
            dataType: "json",
            url: "ProveedoresCalificacion.aspx/ObtenerProveedores",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonArray = $.parseJSON(data.d);

                data = jsonArray;

                $('#TablaProveedores').bootstrapTable('destroy');

                $('#TablaProveedores').bootstrapTable({
                    data: data,
                    detailView: true,
                    striped: true,
                    pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 10,
                    idField: 'IdProveedor',
                    uniqueId: 'IdProveedor',
                    onSearch: function (text) {
                        //CargarResumen(text);
                    },
                    onExpandRow: function (index, row, $detail) {
                        //$detail.hide().html(row.IdMaterial).fadeIn('slow');
                        $detail.html('Loading request...');

                        var params = "{'pid': '2', 'pIdProveedor': '" + row.IdProveedor + "'}";

                        $.ajax({
                            dataType: "json",
                            url: "ProveedoresCalificacion.aspx/ObtenerProveedores",
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
                                        title: '<i class="fa-solid fa-award"></i> Calidad',
                                        field: 'Calidad',
                                        formatter: 'formatterNumero',
                                    }, {
                                        title: '<i class="fa-solid fa-shield"></i> Seguridad',
                                        field: 'Seguridad',
                                        formatter: 'formatterNumero',
                                    }, {
                                        title: '<i class="fa-solid fa-truck"></i> T. Entrega',
                                        field: 'TiempoEntrega',
                                        formatter: 'formatterNumero'
                                    }, {
                                        title: '<i class="fa-solid fa-hand-holding-dollar"></i> Costos',
                                        field: 'Costos',
                                        formatter: 'formatterNumero'
                                    }, {
                                        title: '<i class="fa-solid fa-percent"></i> Calif',
                                        formatter: 'formatterCalificacion'
                                    }],
                                    data: data,
                                    striped: true,
                                    idField: 'IdCalProveedor',
                                    uniqueId: 'IdCalProveedor',
                                });
                            }
                        });
                    },
                    onCollapseRow: function (index, row, $detail) {
                        $detail.clone().insertAfter($detail).fadeOut('slow', function () {
                            $(this).remove()
                        })
                    }
                });
            }
        });
    }

    $('#btnGuardarCal').click(function () {
        CierraPopup();
        var id = $(this).attr('rel');

        var parametros = "{'pIdProveedor': '" + id
            + "', 'pCalCalidad': '" + $('#txtCalidad').val()
            + "', 'pCalSeguridad': '" + $('#txtSeguridad').val()
            + "', 'pCalTEntrega': '" + $('#txtTiempoEntrega').val()
            + "', 'pCalCostos': '" + $('#txtCostos').val()
            + "', 'pCapFinanciera': '" + $('#txtCapFinanciera').val()
            + "'}";
        //debugger;
        $.ajax({
            dataType: "json",
            url: "ProveedoresCalificacion.aspx/GuardarCalificacion",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Calificación Guardada." || msg.d == "Calificación Modificada") {
                    //$("#AddMsgUsuarios").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    //$('#TablaProveedores').bootstrapTable('destroy');
                    
                    CargarProveedores();
                    swal(msg.d);
                    //location.reload();
                   
                }
                else {
                    //$("#AddMsgUsuarios").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });

    });
});

function accionUsersFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<Button title="Calificar" class= "btn btn-success calificar"><i class="fa-solid fa-list-check"></i></Button>',
        '</div>'
    ].join(' ');
}

window.accionUsersEvents = {
    'click .calificar': function (e, value, row, index) {

        $('#btnGuardarCal').attr('rel', row.IdProveedor);

        $('#txtCalidad').val('');
        $('#txtSeguridad').val('');
        $('#txtTiempoEntrega').val('');
        $('#txtCostos').val('');
        $('#txtCapFinanciera').val('');

        $('#dvCalificacion').modal();
        //var parametros = "{'pid': '" + row.IdUsuario + "'}";
        //$.ajax({
        //    dataType: "json",
        //    url: "Usuarios.aspx/ObtenerUsuariosFoto",
        //    async: true,
        //    data: parametros,
        //    type: "POST",
        //    contentType: "application/json; charset=utf-8",
        //    success: function (data) {
        //        if (data.d != "") {
        //            var json = JSON.parse(data.d);
        //            $(json).each(function (index, item) {
        //                $("[id*='ImagenActualUsuarios']").prop('src', item.Foto);
        //            });
        //        }
        //        else {
        //            //$("#CargandoUsuarios").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');
        //            swal('No se obtuvo información.');
        //        }
        //    }
        //});

        //$("#FotoUsuariosModal").modal();
    }
};

function formatoMonedaFormatter(value) {
    return formato_numero(value, 2, ".", ",");
}

function formatterNumero(value) {
    return formato_numeroSinSigno(value, 2, ".", ",");
}

function formatterCalificacion(value, row, index) {

    var calif = 0;

    calif = (parseInt(row.Calidad) + parseInt(row.Seguridad) + parseInt(row.TiempoEntrega) + parseInt(row.Costos)) / 4;

    return formato_numeroSinSigno(calif, 2, ".", ",");
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

function formato_numeroSinSigno(numero, decimales, separador_decimal, separador_miles) { // v2007-08-06
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
            numero = numero.replace(miles, "1" + separador_miles + "2");
        }
    }

    return numero;
}

function CierraPopup() {
    $("#dvCalificacion").modal('hide');//ocultamos el modal
    $('body').removeClass('modal-open');//eliminamos la clase del body para poder hacer scroll
    $('.modal-backdrop').remove();//eliminamos el backdrop del modal
}