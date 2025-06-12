$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("RFQ.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarRFQ();
        CargarEmpresaContacto();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }


    function CargarEmpresaContacto() {
        var parametros = "{'pid': '2'}";
        $.ajax({
            dataType: "json",
            url: "RFQ.aspx/ObtenerEmpresas2",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {

                        var IdEmpresa = json[index].idEmpresa;
                        var RazonSocialEmpresa = json[index].RazonSocial;
                        var Contacto = json[index].NombreContacto;
                        //var jsonItem = "{'idSucursa': '" + IdSucursal + "', 'CiudadSucursal': '" + CiudadSucursal + "', 'DireccionSucursal': '" + DireccionSucursal + "', 'TelefonoSucursal': '" + TelefonoSucursal + "' }";                       
                        $("#slctEmpresa").append("<option value=" + IdEmpresa + ">" + RazonSocialEmpresa.toUpperCase() + "-" + Contacto.toUpperCase() + "</option>");
                    });
                }
                else {
                    $("#CargandoEmpresa").append('<div class="alert alert-danger fade in"><p>No se obtuvo información o no tienes permiso de acceso.</p></div >');

                }
            }
        });
    }


    function CargarRFQ() {
        $('tbody#listaRFQ').empty();
        $('#myPager').html('');
        var parametros = "{'pid': '1'}";
        $.ajax({
            dataType: "json",
            url: "RFQ.aspx/ObtenerRFQ",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {
                        var IdRfq = json[index].IdRfq;
                        var Folio = json[index].Folio;
                        var FechaRFQ = json[index].FechaRFQ.substring(0, 10);
                        var NombreContacto = json[index].NombreContacto;
                        var Descripcion = json[index].Descripcion;
                        var Telefono = json[index].Telefono;
                        var FechaCompromiso = json[index].FechaCompromiso.substring(0, 10);
                        var Vendedor = json[index].Vendedor;
                        var Coordinador = json[index].Coordinador;
                        var Estatus = json[index].EstatusN;
                        var EstatusDias = json[index].Estatus;
                        var Seguimiento = json[index].Seguimiento;

                        //0=inactico/eliminado
                        //1=pendiente
                        //2=enviado

                        if (Estatus == 2 && EstatusDias > 0) {
                            Estatus = "SUPERAMOS EXPECTATIVAS";
                        } else if (Estatus == 1 && EstatusDias > 0) {
                            Estatus = "PENDIENTE";
                        } else if (Estatus == 1 && EstatusDias == 0) {
                            Estatus = "A TIEMPO";
                        } else if (Estatus == 1 && EstatusDias < 0) {
                            Estatus = "RETARDADO";
                        } else if (Estatus == 2 && EstatusDias == 0) {
                            Estatus = "SUPERAMOS EXPECTATIVAS";
                        }
                        $('tbody#listaRFQ').append(
                            '<tr><td style="display:none;">'
                            + IdRfq
                            + '</td>'
                            + '<td>'
                            + FechaRFQ
                            + '</td>'
                            + '<td>'
                            + Folio
                            + '</td><td>'
                            + Descripcion
                            + '</td>'
                            + '<td>'
                            + FechaCompromiso
                            + '</td>'
                            + '<td>'
                            + Vendedor
                            + '</td>'
                            + '<td>'
                            + Coordinador
                            + '</td>'
                            + '<td>'
                            + NombreContacto
                            + '</td>'
                            + '<td>'
                            + Telefono
                            + '</td>'
                            + '<td>'
                            + Estatus
                            + '</td>'
                            + '<td>'
                            + Seguimiento
                            + '</td>'
                            + '<td>'
                            + '<div class="btn-group">'
                            //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                            + '<Button title="Editar RFQ" class= "btn btn-success" value="' + IdRfq + '" onclick="EditarRFQ(this);"> <i class="icon_pencil"></i></Button>'
                            + '<Button title="Eliminar RFQ" class="btn btn-danger" value="' + IdRfq + '" onclick="EliminarRFQ(this);"><i class="icon_close_alt2"></i></Button>'
                            + '<Button title="Terminar RFQ" class="btn btn-warning" value="' + IdRfq + '" onclick="EnviarRFQ(this);"><i class="icon_check_alt"></i></Button>'
                            + '</div > '
                            + '</td>'
                            + '</tr>')
                    });
                    //$('#listaRFQ').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: false, perPage: 100 });
                    $('#TablaRFQ').DataTable({
                        "bLengthChange": false,
                        "pageLength": 100,

                        "oLanguage": {
                            "sSearch": "Buscar:"
                        },
                        "retrieve": true
                    });
                }
                else {
                    $("#CargandoRFQ").append('<div class="alert alert-danger fade in"><p>No se obtuvo información, problemas de permisos.</p></div >');

                }
            }
        });
    }


    $('#btnEliminarRFQ').click(function () {
        var idReq = document.getElementById('idRFQEliminar').textContent;

        var parametros = "{'pidRFQ': '" + idReq + "'}";
        $.ajax({
            dataType: "json",
            url: "RFQ.aspx/EliminarRFQ",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "RFQ eliminada.") {
                    //$("#txtModalEliminarMensajeRFQ").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarRFQ();
                    swal(msg.d);
                }
                else {
                    //$("#txtModalEliminarMensajeRFQ").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnEnviarRFQ').click(function () {
        var idReq = document.getElementById('idRFQEnviar').textContent;

        var parametros = "{'pidRFQ': '" + idReq + "'}";
        $.ajax({
            dataType: "json",
            url: "RFQ.aspx/EnviarRFQ",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "RFQ terminada.") {
                    //$("#txtModalEnviarMensajeRFQ").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarRFQ();
                    swal(msg.d);
                }
                else {
                    //$("#txtModalEnviarMensajeRFQ").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
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

