$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("Cotizaciones.aspx") > -1) {
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarCotizaciones();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);

    }


    $('#btnAgregarComentarioCotizacion').click(function () {
        var id = document.getElementById('idCotizacionComentario').textContent;

        var params = "{'pid': '" + id + "', 'Comentario': '" + $('#txtComentario').val() + "'}";

        $.ajax({
            async: true,
            url: "Cotizaciones.aspx/GuardarComentarios",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                cargarComentariosCotizacion(id);

                $('#txtComentario').val('');
            }
        });
    });

    $('#btnEliminarCotizaciones').click(function () {
        var id = document.getElementById('idCotizacionesEliminar').textContent;

        var parametros = "{'pid': '" + id + "'}";
        $.ajax({
            dataType: "json",
            url: "Cotizaciones.aspx/EliminarCotizaciones",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Cotización eliminado.") {
                    //$("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarCotizaciones();
                    swal(msg.d);
                }
                else {
                    //$("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    function cargarComentariosCotizacion(id) {
        var params = "{'pid': '" + id + "'}";
        $.ajax({
            async: true,
            url: "Cotizaciones.aspx/CargarComentarios",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                var nodoTRAgregar = "";
                var jsonArray = $.parseJSON(data.d);

                $('#TablaPrincipalComentariosCotizacion tbody').html('');
                $.each(jsonArray, function (index, value) {
                    nodoTRAgregar += "<tr>";
                    nodoTRAgregar += '  <td style="display: none;">' + value.IdCotizacion + "</td>";
                    nodoTRAgregar += "  <td>" + value.Comentario + "</td>";
                    nodoTRAgregar += "  <td>" + value.NombreCompleto + "</td>";
                    nodoTRAgregar += "  <td>" + value.Fecha + "</td>";
                    nodoTRAgregar += "</tr>";
                });

                $('#TablaPrincipalComentariosCotizacion tbody').append(nodoTRAgregar);
            }
        });
    }

    $('#btnCancelarCotizacion').click(function () {
        var id = document.getElementById('idCotizacionCancelar').textContent;

        var parametros = "{'pid': '" + id + "'}";
        $.ajax({
            dataType: "json",
            url: "Cotizaciones.aspx/CancelarCotizacion",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Cotización cancelado.") {
                    //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarCotizaciones();
                    swal(msg.d);
                }
                else {
                    //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnConvertirCotizacion').click(function () {
        var id = document.getElementById('idCotizacionesConvertir').textContent;

        if ($('#cmbUsuarioLider').val() == '-1') {
            swal("Elige lider");
            return;
        }
        if ($('#cmbSucursal').val() == '-1') {
            swal("Elige Sucursal");
            return;
        }
        if ($('#txtConceptoProyecto').val() == '') {
            swal("Concepto del proyecto no porporcionado");
            return;
        }
        if ($('#dtInicial').val() == '') {
            swal("Elige fecha inicial");
            return;
        }
        if ($('#dtFinal').val() == '') {
            swal("Elige fecha final");
            return;
        }
        if ($('#txtNombreProyecto').val() == '') {
            swal("Nombre del proyecto no proporcionado");
            return;
        }
        else if ($('#txtNombreProyecto').val().lenght > 100) {
            swal("Nombre del proyecto proporcionado demasiado largo");
            return;
        }
        /*$("#ConvCotizacionesModal2").modal();*/
        var ContadorProyeccionProyectado = 0;
        if ($('#txtCostoMOProyectado').val() == '0' || $('#txtCostoMOProyectado').val() == '') {
            //swal("Ingresa cantidad de mano de obra..");
            //return;
            ContadorProyeccionProyectado++;
        }

        if ($('#txtCostoMaterialProyectado').val() == '0' || $('#txtCostoMaterialProyectado').val() == '') {
            //swal("Ingresa cantidad de materiales..");
            //return;
            ContadorProyeccionProyectado++;
        }

        if ($('#txtCostoMEProyectado').val() == '0' || $('#txtCostoMEProyectado').val() == '') {
            //swal("Ingresa cantidad de equipo..");
            //return;
            ContadorProyeccionProyectado++;
        }
        if (ContadorProyeccionProyectado == 3) {
            swal("Al menos un dato de proyección de costos del proyecto debe ser mayor a 0");
            return;
        }
        if ($('#txtFolioPO').val() == '') {
            swal("Favor de introducir Folio PO");
            return;
        }


        var parametros = "{'pid': '" + id + "', 'Concepto' : '" + $('#txtConceptoProyecto').val() + "', 'dtInicial':'" + $('#dtInicial').val() +
            "', 'dtFinal' : '" + $('#dtFinal').val() + "', 'idLider':'" + $('#cmbUsuarioLider').val() + "', 'Nombre':'" + $('#txtNombreProyecto').val() +
            "', 'MOC' : '" + $('#txtCostoMOCotizado').val() + "', 'MC':'" + $('#txtCostoMaterialCotizado').val() + "', 'MEC':'" + $('#txtCostoMECotizado').val() +
            "', 'MOP' : '" + $('#txtCostoMOProyectado').val() + "', 'MP':'" + $('#txtCostoMaterialProyectado').val() + "', 'MEP':'" + $('#txtCostoMEProyectado').val() +
            "', 'CorreoLider': '" + $('#cmbUsuarioLider option:selected').attr('rel') + "', 'Coordinador': '" + $('#cmbUsuarioLider option:selected').text() +
            "', 'IdSucursal': '" + $('#cmbSucursal').val() + "', 'FolioPO': '" + $('#txtFolioPO').val()
            + "'}";
        $.ajax({
            dataType: "json",
            url: "Cotizaciones.aspx/ConvertirCotizacion",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Cotización convertida.") {
                    CargarCotizaciones();

                    swal("Cotización convertida a proyecto exisotosamente.");
                }
                else {
                    swal("Ooops:" + msg.d);

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
function CargarCotizaciones() {
    $('tbody#listaCotizaciones').empty();
    $('#myPager').html('');
    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "Cotizaciones.aspx/ObtenerCotizaciones",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = JSON.parse(data.d);
                $(json).each(function (index, item) {
                    var idCotizaciones = json[index].IdCotizaciones;
                    var NoCotizaciones = json[index].NoCotizaciones;
                    var NoRequisicion = json[index].RFQ;
                    var FechaCotizaciones = json[index].FechaCotizaciones;
                    var RazonSocial = json[index].RazonSocial;
                    var NombreContacto = json[index].NombreContacto;
                    var Concepto = json[index].Concepto;
                    var CostoCotizaciones = json[index].CostoCotizaciones;
                    var HechaPor = json[index].HechaPor;
                    var EnviadaPor = json[index].EnviadaPor;
                    var Estatus = json[index].Estatus;

                    if (Estatus == 0) {
                        Estatus = "ELIMINADA";
                    } else if (Estatus == 1) {
                        Estatus = "CREADA";
                    } else if (Estatus == 2) {
                        Estatus = "CANCELADA";
                    } else if (Estatus == 3) {
                        Estatus = "GANADA";
                    } else if (Estatus == 4) {
                        Estatus = "ENVIADA";
                    } else if (Estatus == 5) {
                        Estatus = "PROYECTO";
                    }


                    $('tbody#listaCotizaciones').append(
                        '<tr><td style="display:none;">'
                        + idCotizaciones
                        + '</td>'
                        + '<td>'
                        + FechaCotizaciones.substring(0, 10)
                        + '</td>'
                        + '<td>'
                        + NoCotizaciones
                        + '</td>'
                        + '<td>'
                        + NoRequisicion
                        + '</td>'
                        + '<td>'
                        + RazonSocial
                        + '</td>'
                        + '<td>'
                        + NombreContacto
                        + '</td>'
                        + '<td>'
                        + Concepto
                        + '</td>'
                        //+ '<td>'
                        //+ CostoCotizaciones
                        //+ '</td>'
                        + '<td>'
                        + Estatus
                        + '</td>'
                        + '<td>'
                        + HechaPor
                        + '</td>'
                        + '<td>'
                        + EnviadaPor
                        + '</td>'
                        + '<td>'
                        + '<div class="form-inline">'
                        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                        + '<Button title="Convertir a proyecto" class= "btn btn-success" value="' + idCotizaciones + '" rel="' + NoCotizaciones + '" onclick="ConvertirProyecto(this);"> <i class="icon_check"></i></Button><input type="hidden" id="txtConceptoCotizacion" value="' + Concepto + '">'
                        + '<Button title="Enviar correo" class= "btn btn-warning" value="' + idCotizaciones + '" onclick="EnviarCotizacion(this);"> <i class="icon_mail"></i></Button><input type="hidden" id="NombreOrden" value="' + NoCotizaciones + '">'
                        + '<Button title="Ver PDF" class= "btn btn-success" value="' + idCotizaciones + '" onclick="PDFCotizacion(this);"> <i class="icon_search-2"></i></Button>'
                        + '</div > '
                        + '</td>'
                        + '<td>'
                        + '<div class="form-inline">'
                        + '<Button title="Ver Excel" class= "btn btn-default" value="' + idCotizaciones + '" onclick="ExcelCotizacion(this);"> <i class="icon_search-2"></i></Button>'
                        + '<Button title="Agregar comentario" class= "btn btn-info" value="' + idCotizaciones + '" onclick="AgregarComentario(this);"> <i class="icon_comment_alt"></i></Button>'

                        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                        + '<Button title="Editar" class= "btn btn-success" value="' + idCotizaciones + '" rel="' + item.idRequisicion + '" onclick="EditarCotizacion(this);"> <i class="icon_pencil"></i></Button>'
                        //+ '<Button title="Eliminar" class="btn btn-danger" value="' + idCotizaciones + '" onclick="EliminarCotizacion(this);"><i class="icon_minus_alt"></i></Button>'
                        + '</div > '
                        + '</td>'
                        + '<td>'
                        + '<div class="form-inline">'
                        + '<Button title="Archivos" class="btn btn-info" value="' + idCotizaciones + '" onclick="Archivos(this);"><i class="icon_documents"></i></Button>'
                        + '<Button title="Cancelar" class="btn btn-danger" value="' + idCotizaciones + '" onclick="CancelarCotizacion(this);"><i class="icon_close_alt2"></i></Button>'
                        + '</div > '
                        + '</td>'
                        + '</tr>')
                });
                //$('#listaCotizaciones').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
                $('#TablaCotizaciones').DataTable({
                    "bLengthChange": false,
                    "pageLength": 100,
                    "order": [[1, "desc"]],
                    "oLanguage": {
                        "sSearch": "Buscar:"
                    },
                    "retrieve": true
                });
            }
            else {
                $("#CargandoCotizaciones").append('<div class="alert alert-danger fade in"><p>No se obtuvo información, probablemente problemas de permisos.</p></div >');

            }
        }
    });
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


