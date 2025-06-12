$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("ServicioCarros.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarVehiculos();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);

    }


});
function CargarVehiculos() {
    $('tbody#listaCarro').empty();
    $('#myPager').html('');
    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "ServicioCarros.aspx/ObtenerCarros",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = JSON.parse(data.d);
                $(json).each(function (index, item) {

                    var IdCarro = json[index].IdCarro;
                    var Vehiculo = json[index].Vehiculo;
                    var Anio = json[index].Anio;
                    var Comentarios = json[index].Comentarios;
                    var FechaAlta = json[index].FechaAlta;

                    $('tbody#listaCarro').append(
                        '<tr><td style="display:none;">'
                        + IdCarro
                        + '</td>'
                        + '<td>'
                        + FechaAlta.substring(0, 10)
                        + '</td>'
                        + '<td>'
                        + Vehiculo
                        + '</td>'
                        + '<td>'
                        + Anio
                        + '</td><td>'
                        + Comentarios
                        + '</td>'

                        + '<td>'
                        + '<div class="btn-group">'
                        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                        + '<Button title="Agregar servicio" class= "btn btn-warning" value="' + IdCarro + '" onclick="AgregarServicio(this);"> <i class="icon_error-triangle_alt"></i></Button>'
                        + '<Button title="Editar" class= "btn btn-success" value="' + IdCarro + '" onclick="EditarCarro(this);"> <i class="icon_pencil"></i></Button>'
                        + '<Button title="Eliminar" class="btn btn-danger" value="' + IdCarro + '" onclick="EliminaCarro(this);"><i class="icon_close_alt2"></i></Button>'
                        + '</div > '
                        + '</td>'
                        + '</tr>')
                });
                $('#listaCarro').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
            }
            else {
                $("#MensajeCarro").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

            }
        }
    });
}
$('#btnEliminarCarro').click(function () {
    var idCArro = document.getElementById('idCarroEliminar').textContent;

    var parametros = "{'pid': '" + idCArro + "'}";
    $.ajax({
        dataType: "json",
        url: "ServicioCarros.aspx/EliminarCarro",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Carro eliminado.") {
                //$("#txtModalEliminarMensajeCarro").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                CargarVehiculos();
                swal(msg.d);
            }
            else {
                // $("#txtModalEliminarMensajeCarro").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
});
$('#btnGuardarCarro').click(function () {
    var txCComentarios = $('#txCComentarios').val();
    var txtAnio = $('#txtAnio').val();
    var txtCarro = $('#txtCarro').val();

    if (txCComentarios == "" && txtAnio == "" && txtCarro == "") {
        // $("#AddMsgCarro").append('<div class="alert alert-danger fade in"><p>Completa los campos obligatorios.</p></div >');
        swal('Proporciona tipo de servicio, taller y selecciona fecha.');
    }
    else {
        var parametros = "{'pCarro': '" + txtCarro + "','pAno': '" + txtAnio + "', 'cComentarios': '" + txCComentarios + "'}";
        $.ajax({
            dataType: "json",
            url: "ServicioCarros.aspx/GuardarCarro",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Carro creado.") {
                    // $("#AddMsgCarro").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarVehiculos();
                    swal(msg.d);
                }
                else {
                    // $("#AddMsgCarro").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    }

});
$('#btnAgregarServicio').click(function () {
    var id = document.getElementById('idServicioCarro').textContent;
    if ($('#txtFecha').val() == "" && $('#txtTaller').val() == "" && $('#txtTipoServicio').val() == "") {
        swal('Proporciona tipo de servicio, taller y selecciona fecha.');
        //$("#AddMsgServicioCarro").append('<div class="alert alert-danger fade in"><p>Proporciona tipo de servicio, taller y selecciona fecha.</p></div >');
    }
    else {
        var params = "{'pid': '" + id + "', 'pkmAc': '" + $('#idKmAc').val() + "', 'pKmpro': '" + $('#idKmPr').val() + "', 'pTaller': '" + $('#txtTaller').val() + "', 'pTipo': '" + $('#txtTipoServicio').val() + "', 'pFecha': '" + $('#txtFecha').val() + "'}";
        $.ajax({
            async: true,
            url: "ServicioCarros.aspx/GuardarServicio",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Carro creado.") {
                    // $("#AddMsgServicioCarro").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargaServicios(id);
                    swal(msg.d);
                }
                else {
                    //$("#AddMsgServicioCarro").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    }

});

function CargaServicios(id) {
    var params = "{'pid': '" + id + "'}";
    $.ajax({
        async: true,
        url: "ServicioCarros.aspx/CargarServicios",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var datos = "";
            var nodoTRAgregar = "";

            var JsonCombos;
            var jsonArray = $.parseJSON(data.d);

            $('#TablaPrincipalServicio tbody').html('');
            $.each(jsonArray, function (index, value) {
                nodoTRAgregar += "<tr>";
                nodoTRAgregar += '  <td style="display: none;">' + value.IdServicioVehiculo + "</td>";
                nodoTRAgregar += "  <td>" + value.KilometrajeActual + "</td>";
                nodoTRAgregar += "  <td>" + value.KilometrajeProximo + "</td>";
                nodoTRAgregar += "  <td>" + value.FechaServicio + "</td>";
                nodoTRAgregar += "  <td>" + value.Taller + "</td>";
                nodoTRAgregar += "  <td>" + value.TipoServicio + "</td>";
                nodoTRAgregar += "</tr>";
            });

            $('#TablaPrincipalServicio tbody').append(nodoTRAgregar);
        }
    });
}
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



