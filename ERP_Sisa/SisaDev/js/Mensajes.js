$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("Mensajes.aspx") > -1) {
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargaSolicitud();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
        
    }
    function CargaSolicitud() {
        $('tbody#listaSolMensajes').empty();
        $('#myPager').html('');
        var parametros = "{'pid': '1'}";
        $.ajax({
            dataType: "json",
            url: "Mensajes.aspx/CargarSolicitud",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {
                        var idSol = json[index].idSolicitud;
                        var idDoc = json[index].idDocumento;
                        var fecha = json[index].timestamp;
                        var Comentarios = json[index].Comentarios;
                        var Usuario = json[index].UsuarioSolicita;
                        var CondicionEstatus = json[index].CondicionEstatus;
                        var Boton = '';
                        if (Comentarios.includes('Requisicion')) {
                            Boton = '<Button title="Ver" class="btn btn-primary" value="' + idDoc + '"  onClick="VerMensajeReq(this);"> <i class="icon_search_alt"></i></Button>';
                        }
                        else {
                            Boton = '<Button title="Ver" class="btn btn-primary" value="' + idDoc + '" onClick="VerMensaje(this);"> <i class="icon_search_alt"></i></Button>';
                        }
                        var trstyle = '';
                        if (Comentarios.includes('LEIDO')) {
                            trstyle = 'style="background-color: lightskyblue;"';
                        }
                        
                        
                        $('tbody#listaSolMensajes').append(
                            '<tr ' + trstyle + '><td style="display:none;">'
                            + idSol
                            + '</td>'
                            + '<td>'
                            + idSol
                            + '</td>'
                            + '<td>'
                            + fecha.substring(0,10)
                            + '</td>'
                            + '<td>'
                            + Comentarios
                            + '</td>'
                            + '<td>'
                            + CondicionEstatus
                            + '</td>'
                            + '<td>'
                            + Usuario
                            + '</td>'
                            + '<td>'
                            + '<div class="btn-group">'
                            //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                            + Boton
                            + '<Button title="Leído" class="btn btn-success" value="' + idSol + '" onclick="AprobarMensaje(this);"><i class="icon_check_alt"></i></Button>'
                            //+ '<Button class="btn btn-danger" value="' + idSol + '" onclick="RechazarMensaje(this);"><i class="icon_close_alt"></i></Button>'
                            + '</div > '
                            + '</td>'
                            + '</tr>')
                    });
                    $('#listaSolMensajes').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
                }
                else {
                    $("#CargandoMensaje").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }
            }
        });
    }
    $('#btnAprobarMensaje').click(function () {
        var id = document.getElementById('idAprobarMensaje').textContent;

        var parametros = "{'pid': '" + id + "', 'pEstatus': 'true'}";
        $.ajax({
            dataType: "json",
            url: "Mensajes.aspx/AprobarRechazar",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Mensajes actualizada.") {
                    //$("#txtModalAprobarMensajesMensaje").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargaSolicitud();
                    swal('Información actualizada');
                }
                else {
                    //$("#txtModalAprobarMensajesMensaje").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnRechazarMensaje').click(function () {
        var id = document.getElementById('idRechazarMensaje').textContent;

        var parametros = "{'pid': '" + id + "', 'pEstatus': 'false'}";
        $.ajax({
            dataType: "json",
            url: "Mensajes.aspx/AprobarRechazar",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Mensajes actualizada.") {
                    //$("#txtModalRechazarMensajesMensaje").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargaSolicitud();
                    swal(msg.d);
                }
                else {
                    //$("#txtModalRechazarMensajesMensaje").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
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
});

