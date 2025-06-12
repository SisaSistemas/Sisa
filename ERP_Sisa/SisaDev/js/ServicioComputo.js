$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("ServicioComputo.aspx") > -1) {
        
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarServicio();
        CargarUsuariosComputo();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }

});

function CargarServicio() {
    $('tbody#listaComputo').empty();
    $('#myPager').html('');
    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "ServicioComputo.aspx/ObtenerServicios",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = JSON.parse(data.d);
                $(json).each(function (index, item) {

                    var IdComputo = json[index].IdComputo;
                    var PC = json[index].PC;
                    var NombreUsuario = json[index].Usuario;
                    var Tipo = json[index].Tipo;
                    var Comentarios = json[index].Comentarios;
                    var FechaAlta = json[index].FechaAlta.substring(0,10);
                    var FechaProximoMantenimiento = json[index].FechaProximoMantenimiento.substring(0, 10);
                    var Serie = json[index].Serie;
                    var Estatus = json[index].Activo;
                    if (Estatus == true) { Estatus = "ACTIVO"; } else { Estatus = "INACTIVO"; }
                    $('tbody#listaComputo').append(
                        '<tr><td style="display:none;">'
                        + IdComputo
                        + '</td>'
                        + '<td>'
                        + FechaAlta
                        + '</td>'
                        + '<td>'
                        + NombreUsuario
                        + '</td>'
                        + '<td>'
                        + PC
                        + '</td>'
                        + '<td>'
                        + Serie
                        + '</td>'
                        + '<td>'
                        + Tipo
                        + '</td><td>'
                        + Comentarios
                        + '</td>'                        
                        + '<td>'
                        + FechaProximoMantenimiento
                        + '</td>'
                        + '<td>'
                        + Estatus
                        + '</td><td>'
                        + '<div class="btn-group">'
                        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                        + '<Button class= "btn btn-success" value="' + IdComputo + '" onclick="ServicioRealizado(this);"> <i class="icon_pencil"></i></Button>'
                        + '<Button class="btn btn-danger" value="' + IdComputo + '" onclick="EliminaComputo(this);"><i class="icon_close_alt2"></i></Button>'
                        + '</div >'
                        + '</td>'
                        + '</tr>')
                });
                $('#listaComputo').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
            }
            else {
                $("#MensajeComputo").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

            }
        }
    });
}

function CargarUsuariosComputo() {
    var params = "{'Opcion': '1'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'ServicioComputo.aspx/CargarCombosComputo',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#txtResponsable').html('');
            $('#txtResponsable').html('<option value="-1">-- SELECCIONA USUARIO --</option>');
            $.each(json, function (index, value) {

                $("#txtResponsable").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
            });
            $('#txtResponsable').selectpicker('refresh');
            $('#txtResponsable').selectpicker('render');
        }
    });
}
function CargarUsuariosEditar() {
    var params = "{'Opcion': '1'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'ServicioComputo.aspx/CargarCombosComputo',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#txtResponsableEditar').html('');
            $('#txtResponsableEditar').html("<option value=-1>-- SELECCIONA USUARIO --</option>");
            $.each(json, function (index, value) {

                $("#txtResponsableEditar").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
            });
        }
    });
}

$('#btnEliminarComputo').click(function () {
    var idComputo = document.getElementById('idComputoEliminar').textContent;

    var parametros = "{'pid': '" + idComputo + "'}";
    $.ajax({
        dataType: "json",
        url: "ServicioComputo.aspx/EliminarServicio",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Servicio eliminado.") {
                //$("#txtModalEliminarMensajeComputo").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                CargarServicio();
                swal(msg.d);
            }
            else {
                //$("#txtModalEliminarMensajeComputo").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
});
$('#btnGuardarComputo').click(function () {
    var PC = $('#txtComputo').val();
    var txtServicio = $('#txtServicio').val();
    var txCComentarios = $('#txCComentarios').val();
    var txtSerie = $('#txtSeriePC').val();
    var dtFechaMto = $('#dtProximoMto').val();
    var Usuario = $('#txtResponsable').val();
    var NombreUsuario = $("#txtResponsable option:selected").text();
    if (Usuario == '-1' || NombreUsuario == '-- SELECCIONA USUARIO --') {
        //$("#AddMsgComputo").append('<div class="alert alert-danger fade in"><p>Completa los campos obligatorios.</p></div >');
        swal('Selecciona usuario de pc.');
        return;
    }
    if (PC == "" && txtSerie == "") {
        //$("#AddMsgComputo").append('<div class="alert alert-danger fade in"><p>Completa los campos obligatorios.</p></div >');
        swal('Completa los campos obligatorios.');
        return;
    }
    else {
        var parametros = "{'PC' : '" + PC + "','Comentarios' : '" + txCComentarios + "', 'Tipo' : '" + txtServicio + "', 'Serie' : '" + txtSerie + "', 'FechaMto' : '" + dtFechaMto + "', 'idUsuario' : '" + Usuario + "', 'NombreUsuario' : '" + NombreUsuario + "'}";
        $.ajax({
            dataType: "json",
            url: "ServicioComputo.aspx/GuardarServicio",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Computo creado.") {
                    // $("#AddMsgComputo").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarServicio();
                    swal(msg.d);
                }
                else {
                    //$("#AddMsgComputo").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    }

});

$('#btnServicioComputo').click(function () {
    var PC = $('#txtComputoEditar').val();
    var txtServicio = $('#txtServicioEditar').val();
    var txtSerie = $('#txtSeriePCEditar').val();
    var dtFechaMto = $('#dtProximoMtoEditar').val();
    var Usuario = $('#txtResponsableEditarid').val();
    var NombreUsuario = $('#txtResponsableEditar').val();
    var txtComentariosCerrados = $('#txtComentariosCerrados').val();
    var idComputo = document.getElementById('idComputoServicioCerrar').textContent;

    var parametros = "{'pid': '" + idComputo + "','txtComentariosCerrados': '" + txtComentariosCerrados + "', 'PC' : '" + PC + "', 'Tipo' : '" + txtServicio + "', 'Serie' : '" + txtSerie + "', 'FechaMto' : '" + dtFechaMto + "'}";
    $.ajax({
        dataType: "json",
        url: "ServicioComputo.aspx/EditarComputo",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Servicio terminado.") {
                //$("#txtModalServicioMensajeComputo").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                CargarServicio();
                swal(msg.d);
            }
            else {
                //$("#txtModalServicioMensajeComputo").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
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



