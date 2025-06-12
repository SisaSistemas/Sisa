$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("ProyectosClientes.aspx") > -1) {
        CargarProyectosCliente();
    }

    $(this).ajaxStart(function () {
        var Sobreponer = '<div id="SobrePoner"><img id="cargando" src="./img/loading.gif">'
            + '</div>';
    });
    $(this).ajaxStop(function () {
        $('SobrePoner').remove();
    });
    
});

function CargarProyectosCliente() {
    $('tbody#listaProyectos').empty();
    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "ProyectosClientes.aspx/ObtenerProyectos",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "No tienes permiso.") {
                var json = JSON.parse(data.d);
                $(json).each(function (index, item) {
                    //debugger;
                    var idProyecto = json[index].IdProyecto;
                    var Folio = json[index].FolioProyecto;
                    var NombreProyecto = json[index].NombreProyecto;
                    var Contacto = json[index].ContactoCliente;
                    var Empresa = json[index].Cliente;
                    var Lider = json[index].LiderProyecto;
                    var FechaI = json[index].FechaInicio.substring(0, 10);
                    var FechaT = json[index].FechaFin.substring(0, 10);
                    var Estatus = json[index].Estatus;
                    var FolioPO = json[index].FolioPO;
                    
                    //if (json[index].Activo == '1') {
                        
                    //}

                    $('tbody#listaProyectos').append(
                        '<tr><td style="display:none;">'
                        + idProyecto
                        + '</td>'
                        + '<td>'
                        + Folio
                        + '</td>'
                        + '<td>'
                        + NombreProyecto
                        + '</td>'
                        + '<td>'
                        + FolioPO
                        + '</td>'
                        + '<td>'
                        + Contacto
                        + '</td>'
                        + '<td>'
                        + Empresa
                        + '</td>'
                        + '<td>'
                        + Lider
                        + '</td>'
                        + '<td>'
                        + item.Sucursal
                        + '</td>'
                        + '<td>'
                        + FechaI
                        + '</td>'
                        + '<td>'
                        + FechaT
                        + '</td>'
                        + '<td>'
                        + '<div class="btn-group">'
                        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                        + '<Button title="Tareas" class="btn btn-default" value="' + idProyecto + '" onclick="TareasProyectos(this);"><i class="icon_menu"></i></Button>'
                        + '<Button title="Agregar comentario" class= "btn btn-info" value="' + idProyecto + '" onclick="AgregarComentario(this);"> <i class="icon_comment_alt"></i></Button>'
                        + '</div > '
                        + '</td>'
                        + '</tr>')

                });
                $('#listaProyectos').pageMe({ pagerSelector: '#myPagerProy', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
            }
            else {
                $("#CargandoCotizaciones").append('<div class="alert alert-danger fade in"><p>No se obtuvo información, pueden ser problemas de permisos.</p></div >');

            }
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
$('#btnAgregarComentarioProyectos').click(function () {
    var id = document.getElementById('idProyectoComentario').textContent;

    var params = "{'pid': '" + id + "', 'Comentario': '" + $('#txtComentarioProyecto').val() + "'}";

    $.ajax({
        async: true,
        url: "Proyectos.aspx/GuardarComentarios",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            cargarComentariosProyectos(id);

            $('#txtComentarioProyecto').val('');
        }
    });
});
function cargarComentariosProyectos(id) {
    var params = "{'pid': '" + id + "'}";
    $.ajax({
        async: true,
        url: "Proyectos.aspx/CargarComentarios",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            var nodoTRAgregar = "";
            var jsonArray = $.parseJSON(data.d);

            $('#TablaPrincipalComentariosProyectos tbody').html('');
            $.each(jsonArray, function (index, value) {
                nodoTRAgregar += "<tr>";
                nodoTRAgregar += '  <td style="display: none;">' + value.IdProyecto + "</td>";
                nodoTRAgregar += "  <td>" + value.Comentario + "</td>";
                nodoTRAgregar += "  <td>" + value.NombreCompleto + "</td>";
                nodoTRAgregar += "  <td>" + value.Fecha + "</td>";
                nodoTRAgregar += "</tr>";
            });

            $('#TablaPrincipalComentariosProyectos tbody').append(nodoTRAgregar);
        }
    });
}


