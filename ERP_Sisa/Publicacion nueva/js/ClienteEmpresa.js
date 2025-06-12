
$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("ClientesEmpresa.aspx") > -1) {


        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarEmpresa();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);

    }

    function CargarEmpresa() {
        $('tbody#listaEmpresa').empty();
        $('#myPager').html('');
        var parametros = "{'pid': '1'}";
        $.ajax({
            dataType: "json",
            url: "ClientesEmpresa.aspx/ObtenerEmpresas",
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
                        var Cliente = json[index].Cliente;
                        var DireccionEmpresa = json[index].DireccionFiscal;
                        var TelefonoEmpresa = json[index].Telefono;
                        var RFCEmpresa = json[index].RFC;
                        var CiudadEmpresa = json[index].Ciudad;
                        var CorreoEmpresa = json[index].Correo;
                        var CPEmpresa = json[index].CP;
                        var Estatus = json[index].Estatus;
                        var trstyle = '';
                        if (Estatus == false) {
                            Estatus = 'INACTIVO';
                            trstyle = 'style="background-color: red; color: white;"';
                        } else if (Estatus == true) {
                            Estatus = 'ACTIVO';
                        }
                        $('tbody#listaEmpresa').append(
                            '<tr ' + trstyle + '><td style="display:none;">'
                            + IdEmpresa
                            + '</td>'
                            + '<td>'
                            + RazonSocialEmpresa
                            + '</td><td>'
                            + Cliente
                            + '</td><td>'
                            + RFCEmpresa
                            + '</td><td>'
                            + DireccionEmpresa
                            + '</td>'
                            + '<td>'
                            + TelefonoEmpresa
                            + '</td><td>'
                            + CorreoEmpresa
                            + '</td><td>'
                            + CiudadEmpresa
                            + '</td>'
                            + '<td>'
                            + CPEmpresa
                            + '</td>'
                            + '<td>'
                            + Estatus
                            + '</td>'
                            + '<td>'
                            + '<div class="btn-group">'
                            //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                            + '<Button title="Editar empresa" class= "btn btn-info" value="' + IdEmpresa + '" onclick="EditarEmpresa(this);"> <i class="icon_pencil"></i></Button>'
                            + '<Button title="Activar empresa" class="btn btn-success" value="' + IdEmpresa + '" onclick="ActivarEmpresa(this);"><i class="icon_check_alt2"></i></Button>'
                            + '<Button title="Eliminar empresa" class="btn btn-danger" value="' + IdEmpresa + '" onclick="EliminarEmpresa(this);"><i class="icon_close_alt2"></i></Button>'
                            + '</div> '
                            + '</td>'
                            + '</tr>')
                    });
                    //$('#listaEmpresa').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
                    $('#TablaEmpresa').DataTable({
                        "bLengthChange": false,
                        "pageLength": 100,
                        "order": [[1, "asc"]],
                        "oLanguage": {
                            "sSearch": "Buscar:"
                        },
                        "retrieve": true
                    });
                }
                else {
                    $("#CargandoEmpresa").append('<div class="alert alert-danger fade in"><p>No se obtuvo información o no tienes permiso de acceso.</p></div >');

                }
            }
        });
    }
    $('#btnGuardarEmpresa').click(function () {
        var Ciudad = $('#txtCiudad').val();
        var Direccion = $('#txtDireccionEmpresa').val();
        var Telefono = $('#txtTelefonoEmpresa').val();
        var CP = $('#txtCP').val();
        var RZ = $('#txtRazonSocial').val();
        var RFC = $('#txtRFC').val();
        var Correo = $('#txtCorreo').val();
        var Cliente = $('#txtCliente').val();
        if (Telefono == "" || Direccion == "" || Ciudad == "" || CP == "" || RZ == "" || RFC == "" || Correo == "") {
            //$("#AddMsgEmpresa").append('<div class="alert alert-danger fade in"><p>Completa los campos obligatorios.</p></div >');
            swal('Completa los campos obligatorios.');
        }
        else {
            var parametros = "{'pRZ': '" + RZ + "', 'pDireccion': '" + Direccion + "', 'pTelefono': '" + Telefono + "', 'pRFC': '" + RFC + "', 'pCorreo': '" + Correo + "', 'pCP': '" + CP + "', 'pCiudad': '" + Ciudad + "', 'pCliente': '" + Cliente + "'}";

            $.ajax({
                dataType: "json",
                url: "ClientesEmpresa.aspx/GuardarEmpresa",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Empresa creada.") {
                        //$("#AddMsgEmpresa").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                        CargarEmpresa();
                        swal(msg.d);
                    }
                    else {
                        // $("#AddMsgEmpresa").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                        swal(msg.d);
                    }
                }
            });
        }

    });

    $('#btnEliminarEmpresa').click(function () {
        var idEmpresa = document.getElementById('idEmpresaEliminar').textContent;

        var parametros = "{'pidEmpresa': '" + idEmpresa + "'}";
        $.ajax({
            dataType: "json",
            url: "ClientesEmpresa.aspx/EliminarEmpresa",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Empresa eliminada.") {
                    //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarEmpresa();
                    swal(msg.d);
                }
                else {
                    //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnActivarEmpresa').click(function () {
        var idEmpresa = document.getElementById('idEmpresaActivar').textContent;

        var parametros = "{'pidEmpresa': '" + idEmpresa + "'}";
        $.ajax({
            dataType: "json",
            url: "ClientesEmpresa.aspx/ActivarEmpresa",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Empresa activada.") {
                    //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarEmpresa();
                    swal(msg.d);
                }
                else {
                    //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
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


