$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("Requisiciones.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarRequisiciones();
        CargarProyectosRequisicion();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }

});
function CargarProyectosRequisicion() {
    var params = "{'Opcion': '10'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'Requisiciones.aspx/ProyectosCombos',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#slctProyecto').html('');
            $('#slctProyecto').html('<option value="-1">-- SELECCIONE PROYECTO --</option>');
            $.each(json, function (index, value) {
                $("#slctProyecto").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
            });
            $("#slctProyecto").append('<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER</option>');
            $("#slctProyecto").append('<option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA</option>');
            $("#slctProyecto").append('<option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD</option>');
            $("#slctProyecto").append('<option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA</option>');
            $('#slctProyecto').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
            $('#slctProyecto').append('<option value="1621D8FD-690E-4C1E-BB94-7E0FAB7C7F56">GASTOS ADMINISTRATIVOS</option>');
            $('#slctProyecto').selectpicker('refresh');
            $('#slctProyecto').selectpicker('render');
            //$('#cmbProyectos').val(idProyecto);
        }
    });
}
function CargarRequisiciones() {
    $('tbody#listaRequisiciones').empty();
    $('#myPager').html('');
    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "Requisiciones.aspx/ObtenerRequisiciones",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = JSON.parse(data.d);
                $(json).each(function (index, item) {
                    var idRequisiciones = json[index].IdReqEnc;
                    var Folio = json[index].NoReq;
                    var Proyecto = json[index].NombreProyecto;
                    var Fecha = json[index].Fecha.substring(0, 10);
                    var FechaAutorizada = json[index].FechaAutorizada;

                    var FechaCompra = json[index].FechaCompra;
                    if (FechaCompra != null) {
                        FechaCompra = FechaCompra.substring(0, 10);
                    }
                    var Observaciones = json[index].Observaciones;
                    $('tbody#listaRequisiciones').append(
                        '<tr><td style="display:none;">'
                        + idRequisiciones
                        + '</td>'
                        + '<td>'
                        + Fecha
                        + '</td>'
                        + '<td>'
                        + Folio
                        + '</td>'
                        + '<td>'
                        + Proyecto
                        + '</td>'
                        + '<td>'
                        + FechaAutorizada.substring(0, 10)
                        + '</td>'
                        + '<td>'
                        + FechaCompra
                        + '</td>'
                        + '<td>'
                        + Observaciones
                        + '</td>'
                        + '<td>'
                        + '<div class="btn-group">'
                        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                        //+ '<Button class= "btn btn-primary" value="' + idRequisiciones + '" onclick="VisorRequisiciones(this);"> <i class="icon_search_alt"></i></Button>'
                        + '<Button title="Editar" class= "btn btn-success" value="' + idRequisiciones + '" onclick="EditarRequisiciones(this);"> <i class="icon_pencil"></i></Button>'
                        + '<Button title="Eliminar" class="btn btn-danger" value="' + idRequisiciones + '" onclick="EliminarRequisiciones(this);"><i class="icon_close_alt2"></i></Button>'
                        + '</div > '
                        + '</td>'
                        + '</tr>')
                });
                // $('#listaRequisiciones').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
                $('#TablaRequisiciones').DataTable({
                    "bLengthChange": false,
                    "pageLength": 100,

                    "oLanguage": {
                        "sSearch": "Buscar:"
                    },
                    "retrieve": true
                });
            }
            else {
                $("#CargandoRequisiciones").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

            }
        }
    });
}
$('#btnGuardarRequisiciones').click(function () {
    var idProyecto = $('#slctProyecto').val();
    var Comentarios = $('#txtComentariosReq').val();
    var items = 0;
    if (idProyecto == "") {
        //$("#AddMsgRequisiciones").append('<div class="alert alert-danger fade in"><p>Completa los campos obligatorios.</p></div >');
        //document.getElementById('AddMsgRequisiciones').textContent = '¿Estás seguro de eliminar requisición con código "' + btn.value + '"?';
        swal('Completa los campos obligatorios.');
    }
    else {
        var parametros = "{'pObservaciones': '" + Comentarios + "', 'pidProyecto': '" + idProyecto + "'}";
        $.ajax({
            dataType: "json",
            url: "Requisiciones.aspx/GuardarRequisiciones",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Requisiciones creada.") {


                    //guardar detalles
                    $("#tblReqAdd tbody tr").each(function (index) {
                        items++;
                    });


                    $("#tblReqAdd tbody tr").each(function (index) {
                        var item, descripcion, cantidad, unidad, numParte, marca;

                        $(this).children("td").each(function (index2) {
                            switch (index2) {
                                case 0:
                                    item = $(this).find("span").text();
                                    break;
                                case 1:
                                    descripcion = $(this).find("span").text();
                                    break;
                                case 2:
                                    cantidad = $(this).find("span").text();
                                    break;
                                case 3:
                                    unidad = $(this).find("span").text();
                                    break;
                                case 4:
                                    numParte = $(this).find("span").text();
                                    break;
                                case 5:
                                    marca = $(this).find("span").text();
                                    break;
                            }
                        });

                        var param = "{'pItem': '" + item
                            + "','pDescripcio': '" + descripcion
                            + "','pCantidad': '" + cantidad
                            + "','pUnidad': '" + unidad
                            + "','pNumParte': '" + numParte
                            + "','pMarca': '" + marca + "'}";

                        $.ajax({
                            async: true,
                            url: "Requisiciones.aspx/GuardarRequisicionesDetalle",
                            dataType: "json",
                            data: param,
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data, textStatus) {

                                itemsGuardados++;

                                if (itemsGuardados == items) {

                                }
                            }
                        });
                    });
                    // $("#AddMsgRequisiciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarRequisiciones();
                    swal(msg.d);
                }
                else {
                    //$("#AddMsgRequisiciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    }

});

$('#btnEliminarRequisiciones').click(function () {
    var idReq = document.getElementById('idRequisicionesEliminar').textContent;

    var parametros = "{'pidRequisicion': '" + idReq + "'}";
    $.ajax({
        dataType: "json",
        url: "Requisiciones.aspx/EliminarRequisicion",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Requisiciones eliminada.") {
                //$("#txtModalEliminarMensajeRequisiciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                CargarRequisiciones();
                swal(msg.d);
            }
            else {
                //$("#txtModalEliminarMensajeRequisiciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
});


$('#btnEditarRequisiciones').click(function () {

    var idRequisicion = document.getElementById('txtidRequisicionesEditar').textContent;
    window.open("Requisicion-Edicion.aspx?idReq=" + idRequisicion);
    //var CiudadRequisiciones = document.getElementById('txtCiudadRequisicionesEditar').textContent;
    //var DireccionRequisiciones = document.getElementById('txtDireccionRequisicionesEditar').textContent;
    //var TelefonoRequisiciones = document.getElementById('txtTelefonoRequisicionesEditar').textContent;

    //var parametros = "{'pid': '" + idSuc + "','CiudadRequisiciones': '" + CiudadRequisiciones + "','pDireccion': '" + DireccionRequisiciones + "','pTelefono': '" + TelefonoRequisiciones + "'}";
    //$.ajax({
    //    dataType: "json",
    //    url: "Requisiciones.aspx/EditarRequisiciones",
    //    async: true,
    //    data: parametros,
    //    type: "POST",
    //    contentType: "application/json; charset=utf-8",
    //    success: function (msg) {
    //        if (msg.d == "Requisiciones actualizada.") {
    //            $("#txtModalEditarMensajeRequisiciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
    //            CargarRequisiciones();
    //        }
    //        else {
    //            $("#txtModalEditarMensajeRequisiciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');

    //        }
    //    }
    //});
});
var item = 0;
$('#btnAgregarItem').click(function () {
    var nodoAInsertar = "<tr>";
    item += 1;
    nodoAInsertar += "  <td><span>" + item + "</span></td>";

    $(".agrega").each(function () {
        nodoAInsertar += "<td>";
        nodoAInsertar += "  <span>" + $(this).prop("value") + "</span>";
        nodoAInsertar += "</td>";
    });

    nodoAInsertar += "  <td><span class='icon_close_alt eliminar'></span></td>";
    nodoAInsertar += "</tr>";

    $("#tblReqAdd").append(nodoAInsertar);

    $('.agrega').val("");
    $("#txtDescripcion").focus();

});

$(document).on('click', '.eliminar', function (event) {
    var boton = $(this);

    var padreTRBoton = $(boton).parent().parent();

    padreTRBoton.remove();

    item -= 1;

    $("#txtDescripcion").focus();
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


