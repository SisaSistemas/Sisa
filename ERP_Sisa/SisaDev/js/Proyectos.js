$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("Proyectos.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarProyectos();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }

    $(this).ajaxStart(function () {
        var Sobreponer = '<div id="SobrePoner"><img id="cargando" src="./img/loading.gif">'
            + '</div>';
    });

    $(this).ajaxStop(function () {
        $('SobrePoner').remove();
    });

    function CargarProyectos() {
        $('tbody#listaProyectos').empty();
        var parametros = "{'pid': '1'}";
        $.ajax({
            dataType: "json",
            url: "Proyectos.aspx/ObtenerProyectos",
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
                        var Contacto = json[index].ContactoCliente;//json[index].NombreContacto;
                        var Empresa = json[index].Cliente;//json[index].RazonSocial;
                        var Lider = json[index].LiderProyecto;//json[index].Lider;
                        var FechaI = json[index].FechaInicio.substring(0, 10);
                        var FechaT = json[index].FechaFin.substring(0, 10);
                        var Estatus = json[index].Estatus;
                        var Avance = item.Avance;
                        var Sucursal = json[index].Sucursal;
                        var FolioPO = json[index].FolioPO;

                        var trstyle = '';
                        if (Estatus == '0') {
                            Estatus = "PENDIENTE";
                        } else if (Estatus == '1') {
                            trstyle = 'style="background-color: lightskyblue;"';
                            Estatus = "POR INICIAR";
                        } else if (Estatus == '2') {
                            trstyle = 'style="background-color: wheat;"';
                            Estatus = "EN PROCESO";
                        } else if (Estatus == '3') {
                            trstyle = 'style="background-color: #90ee90;"';
                            Estatus = "TERMINADO";
                        } else if (Estatus == '4') {
                            trstyle = 'style="background-color: #ffa084;"';
                            Estatus = "CANCELADO";
                        }
                        var botonLink = '';

                        //console.log(json[index].LinkSharepoint);
                        //if (json[index].LinkSharepoint == '') {
                        //    botonLink = '<Button title="Link Sharepoint" class="btn btn-danger AgregarLink" value="' + idProyecto + '"><i class="icon_link"></i></Button>';
                        //}
                        //else {
                        //    botonLink = '<Button title="Link Sharepoint" class="btn btn-success AbrirLink" value="' + json[index].LinkSharepoint + '"><i class="icon_link"></i></Button>';
                        //}

                        $('tbody#listaProyectos').append(
                            '<tr ' + trstyle + '><td style="display:none;">'
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
                            + Sucursal
                            + '</td>'
                            + '<td>'
                            + FechaI
                            + '</td>'
                            + '<td>'
                            + FechaT
                            + '</td>'
                            + '<td>'
                            + Avance + '%'
                            + '<div class="progress progress-striped"><div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="' + Avance + '" aria-valuemin="0" aria-valuemax="100" style="width:' + Avance + '%"></div></div>'
                            + Estatus
                            + '</td>'
                            + '<td>'
                            + '<div class="btn-group">'
                            + '<Button title="Tareas" class="btn btn-default" value="' + idProyecto + '" onclick="TareasProyectos(this);"><i class="icon_menu"></i></Button>'
                            + '<Button title="Agregar comentario" class= "btn btn-info" value="' + idProyecto + '" onclick="AgregarComentario(this);"> <i class="icon_comment_alt"></i></Button>'
                            + '<Button title="Avance %" class="btn btn-default" value="' + idProyecto + '" rel="' + Folio + '" onclick="AvanceProyecto(this);"><i class="fa fa-line-chart" aria-hidden="true"></i></Button>'
                            + '<Button title="Editar fechas" class="btn btn-success" value="' + idProyecto + '" rel="' + Folio + '" onclick="EditarProyectoFechas(this);"><i class="icon_calendar"></i></Button>'
                            //+ '<Button title="Cancelar" class="btn btn-danger" value="' + idProyecto + '" onclick="CancelarProyecto(this);"><i class="icon_close_alt2"></i></Button>'
                            //+ '<Button title="Editar fechas" class="btn btn-success" value="' + idProyecto + '" onclick="EditarProyectoFechas(this);"><i class="icon_pencil"></i></Button>'
                            + '</div> '
                            + '</td>'
                            + '<td>'
                            + '<div class="btn-group">'
                            + '<Button title="Horas hombre" class="btn btn-warning" value="' + idProyecto + '" onclick="HorasHombre(this);"><i class="icon_group"></i></Button>'
                            //+ '<Button title="Grafica" class="btn btn-success" value="' + idProyecto + '" onclick="Grafica(this);"><i class="social_dribbble_circle"></i></Button>'
                            + '</div> '

                            + '</td>'
                            + '<td style="display:none;">'
                            + json[index].FechaAlta
                            + '</td>'
                            + '<td style="display:none;">'
                            + json[index].Estatus
                            + '</td>'
                            + '</tr>')

                    });
                    //$('#listaProyectos').pageMe({ pagerSelector: '#myPagerProy', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
                    $('#TablaProyectos').DataTable({
                        "bLengthChange": false,
                        "pageLength": 100,
                        "order": [[14, "asc"], [13, "desc"]],
                        "oLanguage": {
                            "sSearch": "Buscar:"
                        },
                        "retrieve": true
                    });
                }
                else {
                    $("#CargandoCotizaciones").append('<div class="alert alert-danger fade in"><p>No se obtuvo información, pueden ser problemas de permisos.</p></div >');

                }
            }
        });
    }


    $('#btnGuardarFechas').click(function () {
        var id = document.getElementById('idProyectoFechas').textContent;
        if ($('#txtRazonCambio').val() == '') {
            swal('Es obligatorio proporcionar una razón de cambio.');
            return;
        }
        var params = "{'pid': '" + id + "', 'Razon': '" + $('#txtRazonCambio').val() + "', 'Inicio': '" + $('#dtFechaInicio').val() + "', 'Fin': '" + $('#dtFechaTermino').val() + "'}";

        $.ajax({
            async: true,
            url: "Proyectos.aspx/GuardarFechas",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                if (data.d == 'Fechas actualizadas.') {

                    swal(data.d);
                    CargarProyectos();
                }
                else {
                    swal(data.d);
                }
            }
        });
    });

    $('#btnCambiarAvance').click(function () {

        var id = document.getElementById('idProyectosAvance').textContent;

        $('#myPagerProy2').html('');
        var parametros = "{'pid': '" + id + "', 'Avance':'" + $('#txtAvanceProyecto').val() + "'}";
        $.ajax({
            dataType: "json",
            url: "Proyectos.aspx/ActualizarAvance",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Proyecto actualizado.") {
                    // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarProyectos();
                    swal(msg.d);

                }
                else {
                    //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnAgregarComentarioProyecto').click(function () {
        var id = document.getElementById('idProyectoComentario').textContent;

        var params = "{'pid': '" + id + "', 'Comentario': '" + $('#txtComentario').val() + "'}";

        $.ajax({
            async: true,
            url: "Proyectos.aspx/GuardarComentarios",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                cargarComentariosProyectos(id);

                $('#txtComentario').val('');
            }
        });
    });


    //function cargarComentariosProyectos(id) {
    //    var params = "{'pid': '" + id + "'}";
    //    $.ajax({
    //        async: true,
    //        url: "Proyectos.aspx/CargarComentariosProyectos",
    //        dataType: "json",
    //        data: params,
    //        type: "POST",
    //        contentType: "application/json; charset=utf-8",
    //        success: function (data, textStatus) {
    //            var nodoTRAgregar = "";
    //            var jsonArray = $.parseJSON(data.d);

    //            $('#TablaPrincipalComentariosProyectos tbody').html('');
    //            $.each(jsonArray, function (index, value) {
    //                nodoTRAgregar += "<tr>";
    //                nodoTRAgregar += '  <td style="display: none;">' + value.IdProyecto + "</td>";
    //                nodoTRAgregar += "  <td>" + value.Comentario + "</td>";
    //                nodoTRAgregar += "  <td>" + value.NombreCompleto + "</td>";
    //                nodoTRAgregar += "  <td>" + value.Fecha.substring(0, 10) + "</td>";
    //                nodoTRAgregar += "</tr>";
    //            });

    //            $('#TablaPrincipalComentariosProyectos tbody').append(nodoTRAgregar);
    //        }
    //    });
    //}

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

    //$('#btnCancelarProyectos').click(function () {
    //    var id = document.getElementById('idProyectosCancelar').textContent;

    //    var parametros = "{'pid': '" + id + "'}";
    //    $.ajax({
    //        dataType: "json",
    //        url: "Proyectos.aspx/CancelarProyectos",
    //        async: true,
    //        data: parametros,
    //        type: "POST",
    //        contentType: "application/json; charset=utf-8",
    //        success: function (msg) {
    //            if (msg.d == "Proyecto cancelado.") {
    //                // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
    //                swal(msg.d);
    //                CargarProyectos();
    //            }
    //            else {
    //                //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
    //                swal(msg.d);
    //            }
    //        }
    //    });
    //});

    $('#btnEliminarProyectos').click(function () {
        var id = document.getElementById('idProyectosEliminar').textContent;

        var parametros = "{'pid': '" + id + "'}";
        $.ajax({
            dataType: "json",
            url: "Proyectos.aspx/EliminarProyectos",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Proyecto eliminado.") {
                    // $("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');

                    CargarProyectos();
                    swal(msg.d);
                }
                else {
                    //$("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

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


    $(document).on('click', '.AgregarLink', function (event) {
        //;
        var _boton = $(this);
        var idProyecto = _boton.val();

        //console.log(_boton.val());

        swal({
            title: "Favor de Capturar Link",
            type: "question",
            input: "text",
            showCancelButton: true,
            closeOnConfirm: false,
            inputPlaceholder: "Link",
            allowOutsideClick: false,
            allowEnterKey: false,
            allowEscapeKey: false,
            showCloseButton: true,
        }).then(function (result) {

            var params = "{'IdProyecto': '" + idProyecto + "','Link': '" + result + "'}";

            $.ajax({
                dataType: 'json',
                async: true,
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                url: 'Proyectos.aspx/ActualizaLink',
                data: params,
                success: function (data, textStatus) {
                    if (data.d == 'Error') {
                        swal({
                            title: "Ocurrio un problema al obtener información, recarga página.",
                            type: "warning",
                            allowOutsideClick: false,
                            allowEscapeKey: false,
                            allowEnterKey: false,
                            showCancelButton: true,
                            confirmButtonColor: '#3085d6',
                            cancelButtonColor: '#d33',
                            cancelButtonText: 'Cerrar'
                        }).then(function () {
                        });
                    }
                    else {
                        swal({
                            title: 'Link Actualizado actualizada.',
                            timer: 3000
                        }).then(function () {
                            location.reload();
                        });

                        
                    }


                }
            });
        });


    });


    $(document).on('click', '.AbrirLink', function (event) {
        //;
        var _boton = $(this);
        var linkProyecto = _boton.val();

        //console.log(_boton.val());

        window.open(linkProyecto, '_blank');


    });

});


