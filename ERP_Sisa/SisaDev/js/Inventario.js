$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("Inventario.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        Cargar();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }

});
function Cargar() {
    $('tbody#listaInventario').empty();
    $('#myPager').html('');
    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "Inventario.aspx/Cargar",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "Error" || data.d != "-1") {
                var json = JSON.parse(data.d);
                $(json).each(function (index, item) {

                    //var trstyle = '';
                    var Estatus = json[index].Estatus;
                    if (Estatus == true) {
                        Estatus = "ACTIVO";
                        //trstyle = 'style="background-color: green; color: white;"';
                    } else if (Estatus == false) {
                        Estatus = "INACTIVO";
                        //trstyle = 'style="background-color: red; color: white;"';
                    }
                    $('tbody#listaInventario').append(
                        //'<tr ' + trstyle + '><td style="display:none;">'
                        '<tr><td style="display:none;">'
                        + json[index].IdHerramienta
                        + '</td>'
                        + '<td>'
                        + json[index].NoCodigo
                        + '</td>'
                        + '<td>'
                        + json[index].Descripcion
                        + '</td><td>'
                        + json[index].Tipo
                        + '</td><td>'
                        + json[index].Contenedor
                        + '</td>'
                        + '<td>'
                        + json[index].Observaciones
                        + '</td>'
                        + '<td>'
                        + json[index].Entradas
                        + '</td>'
                        + '<td>'
                        + json[index].Salidas
                        + '</td>'
                        + '<td>'
                        + json[index].TotalAlmacen
                        + '</td>'
                        + '<td>'
                        + Estatus
                        + '</td>'
                        + '<td>'
                        + '<div class="btn-group">'
                        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                        + '<Button title="Entrada" class="btn btn-info" value="' + json[index].IdHerramienta + '" onclick="Entradas(this);"> <i class="icon_plus"></i></Button>'
                        + ''
                        + '<Button title="Salida" class="btn btn-danger" value="' + json[index].IdHerramienta + '" onclick="Salidas(this);"> <i class="icon_minus-06"></i></Button>'
                        + '</div > '
                        + '</td>'
                        + '</tr>')
                });
                // $('#listaInventario').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
                $('#TablaInventario').DataTable({
                    "bLengthChange": false,
                    "pageLength": 100,

                    "oLanguage": {
                        "sSearch": "Buscar:"
                    },
                    "retrieve": true
                });
            }
            else {
                $("#MensajeInventario").append('<div class="alert alert-danger fade in"><p>No se obtuvo información o no tienes permiso.</p></div >');

            }
        }
    });
}


$('#btnGuardarInventario').click(function () {
    if ($('#txtDescripcionInventario').val() == '') {
        swal('Proporciona descripcion.');
        return;
    }
    if ($('#cmbTipoInventario').val() == '') {
        swal('Proporciona tipo.');
        return;
    }
    if ($('#txtContenedorInventario').val() == '') {
        swal('Proporciona contenedor.');
        return;
    }
    if ($('#txtCantidadInventario').val() == '') {
        swal('Proporciona contenedor.');
        return;
    }
    var params = "{'Descripcion': '" + $('#txtDescripcionInventario').val() +
        "','Tipo': '" + $('#cmbTipoInventario').val() +
        "','Observaciones': '" + $('#txtObservacionInventario').val() +
        "','Contenedor': '" + $('#txtContenedorInventario').val() +
        "','CantInicial': '" + $('#txtCantidadInventario').val() +
        "'}";

    $.ajax({
        dataType: "json",
        async: true,
        url: "Inventario.aspx/GuardarInventario",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == 'Inventario actualizado.') {
                Cargar();
                swal({
                    title: msg.d,
                    timer: 3000
                });
            }
            else {
                swal({
                    title: msg.d,
                    timer: 3000
                });
            }



        },
        error: function (xhr, ajaxOptions, thrownError) {
            swal({
                title: 'Error, intenta de nuevo',
                timer: 3000
            });
        }
    });
});
$('#btnRegistrarEntrada').click(function () {
    var id = document.getElementById('idEntradaInventario').textContent;
    if ($('#txtCantidadEntrada').val() == '' || $('#txtCantidadEntrada').val() == '0') {
        swal('Proporciona cantidad valida.');
        return;
    }
    var parametros = "{'pid': '" + id + "', 'Cantidad':'" + $('#txtCantidadEntrada').val() + "'}";
    $.ajax({
        dataType: "json",
        url: "Inventario.aspx/RegistroEntradas",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Informacion actualizada.") {
                // $("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                Cargar();
                swal(msg.d);
            }
            else {
                //$("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
});
$('#btnRegistrarSalida').click(function () {
    var id = document.getElementById('idSalidaInventario').textContent;
    if ($('#txtCantidadSalida').val() == '' || $('#txtCantidadSalida').val() == '0') {
        swal('Proporciona cantidad valida.');
        return;
    }
    var parametros = "{'pid': '" + id + "', 'Cantidad':'" + $('#txtCantidadSalida').val() + "'}";
    $.ajax({
        dataType: "json",
        url: "Inventario.aspx/RegistroSalidas",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Informacion actualizada.") {
                // $("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                Cargar();
                swal(msg.d);
            }
            else {
                //$("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
});
$.fn.pageMe = function (opts) {
    var $this = this,
        defaults = {
            perPage: 7,
            showPrevNext: false,
            hidePageNumbers: false
        },
        settings = $.extend(defaults, opts);

    var listElement = $this;
    var perPage = settings.perPage;
    var children = listElement.children();
    var pager = $('.pager');

    if (typeof settings.childSelector != "undefined") {
        children = listElement.find(settings.childSelector);
    }

    if (typeof settings.pagerSelector != "undefined") {
        pager = $(settings.pagerSelector);
    }

    var numItems = children.size();
    var numPages = Math.ceil(numItems / perPage);

    pager.data("curr", 0);

    if (settings.showPrevNext) {
        $('<li><a href="#" class="prev_link">«</a></li>').appendTo(pager);
    }

    var curr = 0;
    while (numPages > curr && (settings.hidePageNumbers == false)) {
        $('<li><a href="#" class="page_link">' + (curr + 1) + '</a></li>').appendTo(pager);
        curr++;
    }

    if (settings.showPrevNext) {
        $('<li><a href="#" class="next_link">»</a></li>').appendTo(pager);
    }

    pager.find('.page_link:first').addClass('active');
    pager.find('.prev_link').hide();
    if (numPages <= 1) {
        pager.find('.next_link').hide();
    }
    pager.children().eq(1).addClass("active");

    children.hide();
    children.slice(0, perPage).show();

    pager.find('li .page_link').click(function () {
        var clickedPage = $(this).html().valueOf() - 1;
        goTo(clickedPage, perPage);
        return false;
    });
    pager.find('li .prev_link').click(function () {
        previous();
        return false;
    });
    pager.find('li .next_link').click(function () {
        next();
        return false;
    });

    function previous() {
        var goToPage = parseInt(pager.data("curr")) - 1;
        goTo(goToPage);
    }

    function next() {
        goToPage = parseInt(pager.data("curr")) + 1;
        goTo(goToPage);
    }

    function goTo(page) {
        var startAt = page * perPage,
            endOn = startAt + perPage;

        children.css('display', 'none').slice(startAt, endOn).show();

        if (page >= 1) {
            pager.find('.prev_link').show();
        }
        else {
            pager.find('.prev_link').hide();
        }

        if (page < (numPages - 1)) {
            pager.find('.next_link').show();
        }
        else {
            pager.find('.next_link').hide();
        }

        pager.data("curr", page);
        pager.children().removeClass("active");
        pager.children().eq(page + 1).addClass("active");

    }
};



