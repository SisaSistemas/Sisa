$(document).ready(function () {
    var URLactual = window.location;
    var idProyecto = 0;
    var Tarea = '';
    if (URLactual.href.indexOf("ProyectoDetallesAdmin.aspx") > -1) {
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        idProyecto = document.getElementById('MainContent_idProyectoDetalle').value;
        $('#btnComentarios').val(idProyecto);
        $('#btnDetalle').val(idProyecto);
        $('#btnProyeccionFinanciera').val(idProyecto);
        EscribirEficienciasTabla();
        cargarDatos();
        cargarComentarios();
        //fnDibujarGrafica();
        fnDibujarGraficaPastel();
        //fnDibujarGraficaPastelEficiencias();
        //Grafica();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);

    }
    function cargarDatos() {
        var params = "{'IdProyecto': '" + idProyecto +
            "','Opcion': '" + "1" + "'}";

        $.ajax({
            async: true,
            url: "ProyectoDetallesAdmin.aspx/CargarDatos",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                var datos = "";

                var JsonCombos;
                var json = JSON.parse(data.d);
                $(json).each(function (index, value) {
                    //$('#lblProyecto').text(value.Folio + ' - ' + value.NombreProyecto);
                    //$('#lblDescripcion').text(value.Descripcion);

                    $('#lblLider').text(value.NombreCompleto);
                    $('#lblDuracion').text(value.Dia);
                    $('#lblTotalCotizacion').text("$ " + formato_numero(value.Total, 2, '.', ','));
                    var lblgastos = $('#lblTotalGastos').text();
                    var lblFlujoProyecto = 0;

                    lblFlujoProyecto = value.Total - value.Gastos;
                    //if (lblgastos == '$ 0.00') {
                    //    $('#lblTotalGastos').text("$ " + formato_numero(value.Gastos, 2, '.', ','));
                    //}
                    $('#lblTotalGastos').text("$ " + formato_numero(value.Gastos, 2, '.', ','));

                    $('#lblFlujoProyecto').text("$ " + formato_numero(lblFlujoProyecto, 2, '.', ','));
                    $('#lblUtilidadProyecto').text("$ " + formato_numero(value.UtilidadProyecto, 2, '.', ','));

                    $('#lblGastosPend').text("$ " + formato_numero(value.GastosPend, 2, '.', ','));

                    $('#lblFechaInicio').text(value.Fecha);
                    $('#lblCliente').text(value.RazonSocial + ' ' + value.NombreContacto);


                    //$('#lblDepartamento').text(value.Departamento);
                    //$('#lblRequisitor').text(value.Contacto);
                    //$('#lblFechas').text(value.Fecha);
                });

                if ($('#lblTotalCotizacion').text() == "$ 0.00" || $('#lblTotalCotizacion').text() == "") {
                    $('#lblTotalCotizacion').hide();
                    $('#totalCotizacion').append('<div class="form-group has-feedback"> ' +
                        '<input type="text" class="form-control has-feedback-left" id="txtCostoCotizacion" placeholder="Costo Cotizacion"> ' +
                        '<span class="fa fa-usd form-control-feedback left" aria-hidden="true"></span> ' +
                        '</div>');
                }


            }
        });
    }

    function formato_numero(numero, decimales, separador_decimal, separador_miles) { // v2007-08-06
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

    function cargarComentarios() {
        var params = "{'IdProyecto': '" + idProyecto +
            "','Opcion': '" + "2" + "'}";
        $('tbody#ListaComentarios').empty();
        $.ajax({
            dataType: "json",
            url: "ProyectoDetallesAdmin.aspx/CargarComentarios",
            async: true,
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "" && data.d != "[]") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {
                        var NombreCompleto = item.NombreCompleto;
                        var Comentario = item.Comentario;
                        var FechaComentario = item.Fecha;
                        var Foto = item.Foto;

                        $('#ListaComentarios').append(
                            '    <div class= "act-time" >'
                            + ' <div class="activity-body act-in">'
                            + '     <span class="arrow"></span>'
                            + '    <div class="text">'
                            + '        <a href="#" class="activity-img"><img class="avatar" src="' + Foto + '" alt=""></a>'
                            + '           <p class="attribution">' + NombreCompleto + '</p>'
                            + '           <p>' + Comentario + '</p>'
                            + '           <p>' + FechaComentario + '</p>'
                            + '</div>'
                            + '    </div>'
                            + ' </div>'

                        )
                    });


                }
                else {
                    //$("#MensajeProyectos").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }
            }
        });
    }

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

    function fnDibujarGrafica() {

        var graficaDatos = [];
        var graficaFechas = [];

        var params = "{'IdProyecto': '" + idProyecto + "'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'ProyectoDetallesAdmin.aspx/CargarGrafica',
            data: params,
            success: function (data, textStatus) {
                //debugger;
                graficaDatos = [];
                graficaFechas = [];

                var JsonDatos;
                var JsonPastel;
                var jsonArray = $.parseJSON(data.d);

                var i = 1;
                $.each(jsonArray, function (index, value) {
                    graficaDatos.push([value.Fecha, parseFloat(value.Utilidad)]);
                    graficaFechas.push([value.Fecha]);
                });
                //console.log(graficaNombres)
                dibujarGrafica('mainb', graficaFechas, graficaDatos);

            }


        });
    }

    function dibujarGrafica(divGrafica, graficaFecha, graficaDato) {
        //debugger;
        Highcharts.chart(divGrafica, {

            title: {
                text: 'Utilidad de Proyecto'
            },

            xAxis: {
                categories: (function () {
                    var cate = [], i;

                    for (var i = 0; i < graficaDato.length; i++) {
                        cate.push(
                            graficaDato[i][0]
                        );
                    }
                    return cate
                }())
                //type: 'datetime'
                //tickInterval: 1
                //categories: [graficaFecha[0], graficaFecha[1], graficaFecha[2], graficaFecha[3], graficaFecha[4], graficaFecha[5], graficaFecha[6], graficaFecha[7], graficaFecha[8], graficaFecha[9]]
            },

            yAxis: {
                type: 'logarithmic',
                minorTickInterval: 0
            },

            tooltip: {
                formatter: function () {
                    return 'The value for <b>' + this.x +
                        '</b> is <b>' + this.y + '</b>';
                }
                //headerFormat: '<b>{series.name}</b><br />',
                //pointFormat: 'x = {point.x}, y = {point.y}'
            },

            series: [{
                name: 'Fechas',
                data: (function () {
                    // generate an array of random data
                    var data = [], i;

                    for (i = 0; i < graficaDato.length; i++) {
                        //debugger;
                        data.push({
                            y: graficaDato[i][1]
                        });
                    }
                    return data;
                }()),
                //data: [graficaDato[0], graficaDato[1], graficaDato[2], graficaDato[3], graficaDato[4], graficaDato[5], graficaDato[6], graficaDato[7], graficaDato[8], graficaDato[9]],
                pointStart: 0
            }, {
                name: 'Total',
                data: (function () {
                    // generate an array of random data
                    var data = [],
                        time = (new Date()).getTime(),
                        i;

                    for (i = 0; i < graficaDato.length; i++) {
                        data.push({
                            y: 1221277
                        });
                    }
                    return data;
                }()),
                color: '#FF0000'
                //data: [1221277, 1221277, 1221277, 1221277, 1221277, 1221277, 1221277, 1221277, 1221277, 1221277]
            }],
            credits: {
                enabled: false,                      // Whether to show the credits text.
                href: 'http://www.highcharts.com',  // The URL for the credits label.
                position: null,                     // Position configuration for the credtis label.
                style: null,                        // CSS styles for the credits label.
                text: 'Highcharts.com.'             // The text for the credits label.
            },
            exporting: {
                filename: 'Reporte_Resumen'
            }
        });




        // Apply the theme
        Highcharts.setOptions(Highcharts.theme);
    }

    function fnDibujarGraficaPastel() {

        var graficaDatos = [];
        var graficaFechas = [];

        var params = "{'IdProyecto': '" + idProyecto + "'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'PRoyectoDetallesAdmin.aspx/CargarGraficaPastel',
            data: params,
            success: function (data, textStatus) {
                //debugger;
                graficaDatos = [];
                graficaFechas = [];
                graficaDatosSinIVA = [];
                graficaFechasSinIVA = [];
                var totalGastado = 0;
                var totalGastadoSinIva = 0;

                var JsonDatos;
                var JsonPastel;
                var jsonArray = $.parseJSON(data.d);

                var i = 1;
                $.each(jsonArray, function (index, value) {
                    graficaDatos.push([value.Nombre, parseFloat(value.Porcentaje), parseFloat(value.Dato)]);
                    graficaFechas.push([value.Nombre]);

                    graficaDatosSinIVA.push([value.Nombre, parseFloat(value.PorcentajeSinIva), parseFloat(value.DatoSinIva)]);
                    graficaFechasSinIVA.push([value.Nombre]);

                    if (value.Nombre == 'TotalGastos') {
                        totalGastado = parseFloat(value.Dato);
                        totalGastadoSinIva = parseFloat(value.DatoSinIva);
                    }

                });
                //console.log(totalGastado)
                dibujarGraficaPastel('maina', graficaFechas, graficaDatos);
                dibujarGraficaPastel('maind', graficaFechasSinIVA, graficaDatosSinIVA);

                if (totalGastado != 0) {
                    verGraficaPastelDetalle('TotalGastos', idProyecto, totalGastado);
                }

                if (totalGastadoSinIva != 0) {
                    verGraficaPastelDetalle('TotalGastosSinIva', idProyecto, totalGastadoSinIva);
                }

            }
        });

    }

    function fnDibujarGraficaPastelEficiencias() {

        var graficaDatos = [];
        var graficaFechas = [];

        var params = "{'IdProyecto': '" + idProyecto + "'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'PRoyectoDetallesAdmin.aspx/CargarGraficaPastelEficiencia',
            data: params,
            success: function (data, textStatus) {
                //debugger;
                graficaDatos = [];
                graficaFechas = [];

                var jsonArray = $.parseJSON(data.d);

                var i = 1;
                $.each(jsonArray, function (index, value) {
                    graficaDatos.push([parseFloat(value.ManoObra), parseFloat(value.Material), parseFloat(value.Equipo), parseFloat(value.MOPorcentaje), parseFloat(value.MPorcentaje), parseFloat(value.EPorcentaje), parseFloat(value.MEficientia), parseFloat(value.EEficientia), parseFloat(value.MOEficientia)]);


                });
                //console.log(totalGastado)

                //dibujarGraficaPastelEficiencias('mainc', graficaDatos);
                EscribirEficiencias(graficaDatos);
            }
        });

    }

    function EscribirEficienciasTabla() {
        //if (graficaDatos.length > 0) {
        //    document.getElementById('lblMOEficiencia').textContent = graficaDatos[0][8];
        //    document.getElementById('lblMEficiencia').textContent = graficaDatos[0][6];
        //    document.getElementById('lblEEficiencia').textContent = graficaDatos[0][7];
        //} else {
        //    document.getElementById('lblMOEficiencia').textContent = '0';
        //    document.getElementById('lblMEficiencia').textContent = '0';
        //    document.getElementById('lblEEficiencia').textContent = '0';
        //}
        var params = "{'IdProyecto': '" + idProyecto + "'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'PRoyectoDetallesAdmin.aspx/Proyecciones',
            data: params,
            success: function (data, textStatus) {
                if (data.d != '[]' && data.d != 'No tienes permiso de actualizar proyecto.') {
                    var jsonArray = $.parseJSON(data.d);
                    var cotizado = 0;
                    var proyectado = 0;
                    var gastado = 0;

                    $.each(jsonArray, function (index, value) {
                        //value.ManoObra
                        document.getElementById('lblMOCotizado').textContent = formato_numero((value.CostoMOCotizado), 2, '.', ',');
                        document.getElementById('lblMOProyectado').textContent = formato_numero((value.CostoMOProyectado), 2, '.', ',');
                        document.getElementById('lblMOGastos').textContent = formato_numero(value.ManoObraOC, 2, '.', ',');

                        document.getElementById('lblECotizado').textContent = formato_numero((value.CostoMECotizado), 2, '.', ',');
                        document.getElementById('lblEProyectado').textContent = formato_numero((value.CostoMEProyectado), 2, '.', ',');
                        document.getElementById('lblEGastos').textContent = formato_numero(value.EquipoOC, 2, '.', ',');

                        document.getElementById('lblMCotizado').textContent = formato_numero((value.CostoMaterialCotizado), 2, '.', ',');
                        document.getElementById('lblMProyectado').textContent = formato_numero((value.CostoMaterialProyectado), 2, '.', ',');
                        document.getElementById('lblMGastos').textContent = formato_numero(value.MaterialOC, 2, '.', ',');

                        document.getElementById('lblMOEficiencia').textContent = formato_numero((value.CostoMOProyectado) / value.ManoObraOC, 2, '.', ',');
                        document.getElementById('lblMEficiencia').textContent = formato_numero((value.CostoMaterialProyectado) / value.MaterialOC, 2, '.', ',');
                        document.getElementById('lblEEficiencia').textContent = formato_numero((value.CostoMEProyectado) / value.EquipoOC, 2, '.', ',');

                        document.getElementById('lblCajaChicaGastos').textContent = formato_numero(value.CajaChica, 2, '.', ',');
                        document.getElementById('lblViaticosGastos').textContent = formato_numero(value.Viaticos, 2, '.', ',');

                        cotizado += (value.CostoMOCotizado + value.CostoMECotizado + value.CostoMaterialCotizado);
                        proyectado += (value.CostoMOProyectado + value.CostoMEProyectado + value.CostoMaterialProyectado);
                        gastado += (value.ManoObraOC + value.EquipoOC + value.MaterialOC + value.CajaChica + value.Viaticos);

                        //$('#lblTotalGastos').text("$ " + formato_numero(value.ManoObra + value.Equipo + value.Material, 2, '.', ','));
                    });

                    document.getElementById('lblTotalCotizado').textContent = formato_numero((cotizado), 2, '.', ',');
                    document.getElementById('lblTotalProyectado').textContent = formato_numero((proyectado), 2, '.', ',');
                    document.getElementById('lblTotalGastoss').textContent = formato_numero((gastado), 2, '.', ',');
                    document.getElementById('lblTotalEficiencia').textContent = formato_numero((proyectado / gastado), 2, '.', ',');
                }
            }
        });

    }

    function EscribirEficiencias(graficaDatos) {
        //if (graficaDatos.length > 0) {
        //    document.getElementById('lblMOEficiencia').textContent = graficaDatos[0][8];
        //    document.getElementById('lblMEficiencia').textContent = graficaDatos[0][6];
        //    document.getElementById('lblEEficiencia').textContent = graficaDatos[0][7];
        //} else {
        //    document.getElementById('lblMOEficiencia').textContent = '0';
        //    document.getElementById('lblMEficiencia').textContent = '0';
        //    document.getElementById('lblEEficiencia').textContent = '0';
        //}
        var params = "{'IdProyecto': '" + idProyecto + "'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'PRoyectoDetallesAdmin.aspx/Proyecciones',
            data: params,
            success: function (data, textStatus) {
                if (data.d != '[]' && data.d != 'No tienes permiso de actualizar proyecto.') {
                    var jsonArray = $.parseJSON(data.d);

                    $.each(jsonArray, function (index, value) {
                        //value.ManoObra
                        document.getElementById('lblMOCotizado').textContent = formato_numero(value.CostoMOCotizado, 2, '.', ',');
                        document.getElementById('lblMOProyectado').textContent = formato_numero(value.CostoMOProyectado, 2, '.', ',');

                        document.getElementById('lblECotizado').textContent = formato_numero(value.CostoMOCotizado, 2, '.', ',');
                        document.getElementById('lblEProyectado').textContent = formato_numero(value.CostoMEProyectado, 2, '.', ',');

                        document.getElementById('lblMCotizado').textContent = formato_numero(value.CostoMaterialCotizado, 2, '.', ',');
                        document.getElementById('lblMProyectado').textContent = formato_numero(value.CostoMaterialProyectado, 2, '.', ',');

                    });
                }
            }
        });

    }

    function dibujarGraficaPastelEficiencias(divGrafica, graficaDatos) {
        if (graficaDatos.length > 0) {
            Highcharts.chart(divGrafica, {
                chart: {
                    type: 'pie',
                    animation: true,
                    options3d: {
                        enabled: true,
                        alpha: 45,
                        beta: 0
                    }
                },
                title: {
                    text: 'EFICIENCIA'
                },
                tooltip: {
                    //pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                    pointFormat: '<b>$ {point.x:.2f}</b>: <b>{point.y:.2f} %</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        depth: 35,
                        dataLabels: {
                            enabled: true,
                            format: '{point.name}'
                        }
                    }
                },
                series: [{
                    type: 'pie',
                    name: '',
                    data: [{
                        name: 'Mano de obra',
                        color: '#9A9897',
                        x: graficaDatos[0][0],
                        y: graficaDatos[0][3],
                        sliced: true,
                        selected: true
                    }, {
                        name: 'Materiales',
                        color: '#284AB6',
                        x: graficaDatos[0][1],
                        y: graficaDatos[0][4]
                    },
                    {
                        name: 'Equipo',
                        color: '#ED923E',
                        x: graficaDatos[0][2],
                        y: graficaDatos[0][5]
                    }]//,
                    //point: {
                    //    events: {
                    //        click: function (e) {
                    //            verGraficaPastelDetalle(e.point.name, idProyecto);
                    //            //verDetallePastel(fechaIni, fechaFin, e.point.name, $('#DDParte :selected').text().substring(0, $('#DDParte :selected').text().indexOf('-')).trim());
                    //        }
                    //    }
                    //}
                }],
                credits: {
                    enabled: false,                      // Whether to show the credits text.
                    href: 'http://www.highcharts.com',  // The URL for the credits label.
                    position: null,                     // Position configuration for the credtis label.
                    style: null,                        // CSS styles for the credits label.
                    text: 'Highcharts.com.'             // The text for the credits label.
                },
                exporting: {
                    filename: 'Reporte_Resumen'
                }
            });
        }

    }

    function dibujarGraficaPastel(divGrafica, graficaFecha, graficaNombre) {
        Highcharts.chart(divGrafica, {
            chart: {
                type: 'pie',
                animation: true,
                options3d: {
                    enabled: true,
                    alpha: 45,
                    beta: 0
                }
            },
            title: {
                text: 'GRAFICA UTILIDAD'
            },
            tooltip: {
                //pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                pointFormat: '<b>$ {point.x:.2f}</b>: <b>{point.y:.2f} %</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    depth: 35,
                    dataLabels: {
                        enabled: true,
                        format: '{point.name}'
                    }
                }
            },
            series: [{
                type: 'pie',
                name: '',
                data: [{
                    name: graficaNombre[0][0],
                    color: '#FF0000',
                    x: formato_numero(graficaNombre[0][2], 2, '.', ','),
                    y: graficaNombre[0][1],
                    sliced: true,
                    selected: true
                }, {
                    name: graficaNombre[1][0],
                    color: '#81F781',
                    x: formato_numero(graficaNombre[1][2], 2, '.', ','),
                    y: graficaNombre[1][1]
                }]//,
                //point: {
                //    events: {
                //        click: function (e) {
                //            verGraficaPastelDetalle(e.point.name, idProyecto);
                //            //verDetallePastel(fechaIni, fechaFin, e.point.name, $('#DDParte :selected').text().substring(0, $('#DDParte :selected').text().indexOf('-')).trim());
                //        }
                //    }
                //}
            }],
            credits: {
                enabled: false,                      // Whether to show the credits text.
                href: 'http://www.highcharts.com',  // The URL for the credits label.
                position: null,                     // Position configuration for the credtis label.
                style: null,                        // CSS styles for the credits label.
                text: 'Highcharts.com.'             // The text for the credits label.
            },
            exporting: {
                filename: 'Reporte_Resumen'
            }
        });
    }

    function verGraficaPastelDetalle(nombre, idProyecto, total) {
        var graficaDefecto = [];
        var graficaErroneos = [];
        var params = "{'Nombre': '" + nombre + "', 'IdProyecto': '" + idProyecto + "', 'Gastado': '" + total + "'}";
        console.log(params);
        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'ProyectoDetallesAdmin.aspx/CargarDetalleGrafica',
            data: params,
            success: function (data, textStatus) {
                graficaDefecto = [];
                graficaErroneos = [];


                var JsonDatos;
                var jsonArray = $.parseJSON(data.d);

                $.each(jsonArray, function (index, value) {
                    graficaErroneos.push([value.Nombre, parseFloat(value.Total), parseFloat(value.Porcentaje)]);
                    graficaDefecto.push([value.Task]);
                });

                if (nombre == "TotalGastos") {
                    graficaPastelDetalle('mainb', graficaErroneos, graficaDefecto);
                }
                else {
                    graficaPastelDetalleSinIva('maine', graficaErroneos, graficaDefecto);
                }
                
                
            }


        });
    }

    function graficaPastelDetalle(divGrafica, graficaErroneos, graficaFormato) {
        const options2 = { style: 'currency', currency: 'USD' };
        const numberFormat2 = new Intl.NumberFormat('en-US', options2);

        Highcharts.chart(divGrafica, {
            chart: {
                type: 'pie',
                animation: true,
                options3d: {
                    enabled: true,
                    alpha: 45,
                    beta: 0
                }
            },
            title: {
                text: 'DETALLE GASTOS'
            },
            tooltip: {
                //pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                pointFormat: '<b>$ {point.y:.2f}</b>: <b>{point.x:.2f} %</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    depth: 35,
                    dataLabels: {
                        enabled: true,
                        format: '{point.name}'
                    }
                }
            },
            series: [{
                type: 'pie',
                name: '',
                data: [{
                    name: graficaErroneos[0][0],
                    color: '#0489B1',
                    x: graficaErroneos[0][2],
                    y: graficaErroneos[0][1]
                }, {
                    name: graficaErroneos[1][0],
                    color: '#FF8000',
                    x: graficaErroneos[1][2],
                    y: graficaErroneos[1][1]
                }, {
                    name: graficaErroneos[2][0],
                    color: '#FFFF00',
                    x: graficaErroneos[2][2],
                    y: graficaErroneos[2][1]
                }, {
                    name: graficaErroneos[3][0],
                    color: '#088A08',
                    x: graficaErroneos[3][2],
                    y: graficaErroneos[3][1]
                }, {
                    name: graficaErroneos[4][0],
                    color: '#FE2E2E',
                    x: graficaErroneos[4][2],
                    y: graficaErroneos[4][1]
                }, {
                    name: graficaErroneos[5][0],
                    color: '#FFFF00',
                    x: graficaErroneos[5][2],
                    y: graficaErroneos[5][1]
                }],
                point: {
                    events: {
                        click: function (e) {
                            //debugger;
                            fnVerDetalleGrafica(e.point.name, idProyecto);
                            //verDetallePastel(fechaIni, fechaFin, e.point.name, $('#DDParte :selected').text().substring(0, $('#DDParte :selected').text().indexOf('-')).trim());
                        }
                    }
                }
            }],
            credits: {
                enabled: false,                      // Whether to show the credits text.
                href: 'http://www.highcharts.com',  // The URL for the credits label.
                position: null,                     // Position configuration for the credtis label.
                style: null,                        // CSS styles for the credits label.
                text: 'Highcharts.com.'             // The text for the credits label.
            },
            exporting: {
                filename: 'Reporte_'
            }
        });
    }

    function graficaPastelDetalleSinIva(divGrafica, graficaErroneos, graficaFormato) {
        const options2 = { style: 'currency', currency: 'USD' };
        const numberFormat2 = new Intl.NumberFormat('en-US', options2);

        Highcharts.chart(divGrafica, {
            chart: {
                type: 'pie',
                animation: true,
                options3d: {
                    enabled: true,
                    alpha: 45,
                    beta: 0
                }
            },
            title: {
                text: 'DETALLE GASTOS'
            },
            tooltip: {
                //pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                pointFormat: '<b>$ {point.y:.2f}</b>: <b>{point.x:.2f} %</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    depth: 35,
                    dataLabels: {
                        enabled: true,
                        format: '{point.name}'
                    }
                }
            },
            series: [{
                type: 'pie',
                name: '',
                data: [{
                    name: graficaErroneos[0][0],
                    color: '#0489B1',
                    x: graficaErroneos[0][2],
                    y: graficaErroneos[0][1]
                }, {
                    name: graficaErroneos[1][0],
                    color: '#FF8000',
                    x: graficaErroneos[1][2],
                    y: graficaErroneos[1][1]
                }, {
                    name: graficaErroneos[2][0],
                    color: '#FFFF00',
                    x: graficaErroneos[2][2],
                    y: graficaErroneos[2][1]
                }, {
                    name: graficaErroneos[3][0],
                    color: '#088A08',
                    x: graficaErroneos[3][2],
                    y: graficaErroneos[3][1]
                }, {
                    name: graficaErroneos[4][0],
                    color: '#FE2E2E',
                    x: graficaErroneos[4][2],
                    y: graficaErroneos[4][1]
                }, {
                    name: graficaErroneos[5][0],
                    color: '#FFFF00',
                    x: graficaErroneos[5][2],
                    y: graficaErroneos[5][1]
                }, {
                    name: graficaErroneos[6][0],
                    color: '#3383ff',
                    x: graficaErroneos[6][2],
                    y: graficaErroneos[6][1]
                }, {
                    name: graficaErroneos[7][0],
                    color: '#33ffe3',
                    x: graficaErroneos[7][2],
                    y: graficaErroneos[7][1]
                }],
                point: {
                    events: {
                        click: function (e) {
                            //debugger;
                            fnVerDetalleGrafica(e.point.name, idProyecto);
                            //verDetallePastel(fechaIni, fechaFin, e.point.name, $('#DDParte :selected').text().substring(0, $('#DDParte :selected').text().indexOf('-')).trim());
                        }
                    }
                }
            }],
            credits: {
                enabled: false,                      // Whether to show the credits text.
                href: 'http://www.highcharts.com',  // The URL for the credits label.
                position: null,                     // Position configuration for the credtis label.
                style: null,                        // CSS styles for the credits label.
                text: 'Highcharts.com.'             // The text for the credits label.
            },
            exporting: {
                filename: 'Reporte_'
            }
        });
    }

    function fnVerDetalleGrafica(punto, proyecto) {
        $('#lblTituloDetalle').text('Detalle de ' + punto);

        var params = "{'Punto': '" + punto + "', 'IdProyecto': '" + proyecto + "'}";
        var FActuraOC = '';
        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'ProyectoDetallesAdmin.aspx/CargarDetalle',
            data: params,
            success: function (data, textStatus) {
                var JsonClienes;
                //debugger;
                $('#TablaPrincipalMatSinOC').hide();
                $('#TablaPrincipalImprevistos').hide();
                $('#TablaPrincipalMatConOC').hide();
                $('#TablaPrincipalViaticos').hide();
                $('#TablaPrincipalManoObra').hide();
                $('#TablaPrincipalMatConOCPend').hide();

                if (data.d != '[]') {
                    var json = $.parseJSON(data.d);
                    //debugger;
                    $('tbody#listaTablaPrincipalViaticos').empty();
                    $('tbody#listaTablaPrincipalMatSinOC').empty();
                    $('tbody#listaTablaPrincipalImprevistos').empty();
                    $('tbody#listaTablaPrincipalMatConOC').empty();
                    $('tbody#listaTablaPrincipalManoObra').empty();
                    $('tbody#listaTablaPrincipalMatConOCPend').empty();
                    $(json).each(function (index, item) {
                        if (punto == "Viaticos") {

                            $('#TablaPrincipalMatSinOC').hide();
                            $('#TablaPrincipalImprevistos').hide();
                            $('#TablaPrincipalMatConOC').hide();
                            $('#TablaPrincipalViaticos').show();
                            $('#TablaPrincipalManoObra').hide();
                            $('#TablaPrincipalMatConOCPend').hide();

                            $('tbody#listaTablaPrincipalViaticos').append(
                                '<tr><td>'
                                + json[index].FechaViaticos
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].Gasolina, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].Desayuno, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].Comida, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].Cena, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].Casetas, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].Hotel, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].Transporte, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].Otros, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].ManoObra, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].Equipo, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].Materiales, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + json[index].Descripcion
                                + '</td>'
                                + '</tr>')


                        }

                        if (punto == "Fac Sin OC") {
                            $('#TablaPrincipalMatSinOC').show();
                            $('#TablaPrincipalImprevistos').hide();
                            $('#TablaPrincipalMatConOC').hide();
                            $('#TablaPrincipalViaticos').hide();
                            $('#TablaPrincipalManoObra').hide();
                            $('#TablaPrincipalMatConOCPend').hide();
                            if (FActuraOC == '') {
                                $('tbody#listaTablaPrincipalMatSinOC').append(
                                    '<tr><td>'
                                    + json[index].FechaFactura
                                    + '</td>'
                                    + '<td>'
                                    + json[index].NoFactura
                                    + '</td>'
                                    + '<td>'
                                    + json[index].NombreComercial
                                    + '</td>'
                                    + '<td>'
                                    + json[index].OrdenCompra
                                    + '</td>'
                                    + '<td>'
                                    + formato_numero(json[index].SubTotal, 2, '.', ',')
                                    + '</td>'
                                    + '<td>'
                                    + formato_numero(json[index].Iva, 2, '.', ',')
                                    + '</td>'
                                    + '<td>'
                                    + formato_numero(json[index].Total, 2, '.', ',')
                                    + '</td>'
                                    + '</tr>')
                                FActuraOC = json[index].NoFactura
                            }
                            if (FActuraOC != '' && FActuraOC != json[index].NoFactura) {
                                $('tbody#listaTablaPrincipalMatSinOC').append(
                                    '<tr><td>'
                                    + json[index].FechaFactura
                                    + '</td>'
                                    + '<td>'
                                    + json[index].NoFactura
                                    + '</td>'
                                    + '<td>'
                                    + json[index].NombreComercial
                                    + '</td>'
                                    + '<td>'
                                    + json[index].OrdenCompra
                                    + '</td>'
                                    + '<td>'
                                    + formato_numero(json[index].SubTotal, 2, '.', ',')
                                    + '</td>'
                                    + '<td>'
                                    + formato_numero(json[index].Iva, 2, '.', ',')
                                    + '</td>'
                                    + '<td>'
                                    + formato_numero(json[index].Total, 2, '.', ',')
                                    + '</td>'
                                    + '</tr>')
                            }




                        }

                        if (punto == "Caja Chica") {
                            $('#TablaPrincipalMatSinOC').hide();
                            $('#TablaPrincipalImprevistos').show();
                            $('#TablaPrincipalMatConOC').hide();
                            $('#TablaPrincipalViaticos').hide();
                            $('#TablaPrincipalManoObra').hide();
                            $('#TablaPrincipalMatConOCPend').hide();


                            $('tbody#listaTablaPrincipalImprevistos').append(
                                '<tr><td>'
                                + json[index].FechaGastos.substring(0, 10)
                                + '</td>'
                                + '<td>'
                                + json[index].Responsable
                                + '</td>'
                                + '<td>'
                                + json[index].Concepto
                                + '</td>'
                                + '<td>'
                                + json[index].Comprobante
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].Gastos, 2, '.', ',')
                                + '</td>'
                                + '</tr>')

                        }

                        if (punto == "Mat Con OC") {
                            $('#TablaPrincipalMatSinOC').hide();
                            $('#TablaPrincipalImprevistos').hide();
                            $('#TablaPrincipalMatConOC').show();
                            $('#TablaPrincipalViaticos').hide();
                            $('#TablaPrincipalManoObra').hide();
                            $('#TablaPrincipalMatConOCPend').hide();


                            $('tbody#listaTablaPrincipalMatConOC').append(
                                '<tr><td>'
                                + json[index].Folio
                                + '</td>'
                                + '<td>'
                                + json[index].ReferenciaCot
                                + '</td>'
                                + '<td>'
                                + json[index].NombreComercial
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].SubTotal, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].Iva, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].Total, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + json[index].Fecha
                                + '</td>'
                                + '</tr>')

                        }

                        if (punto == "Mano de Obra") {
                            $('#TablaPrincipalMatSinOC').hide();
                            $('#TablaPrincipalImprevistos').hide();
                            $('#TablaPrincipalMatConOC').hide();
                            $('#TablaPrincipalViaticos').hide();
                            $('#TablaPrincipalManoObra').show();
                            $('#TablaPrincipalMatConOCPend').hide();

                            $('tbody#listaTablaPrincipalManoObra').append(
                                '<tr><td>'
                                + item.Tipo
                                + '</td>'
                                + '<td>'
                                + item.Folio
                                + '</td>'
                                + '<td>'
                                + item.NombreCompleto
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].TotalDinero, 2, '.', ',')
                                + '</td>'
                                + '</tr>');
                            //$('tbody#listaTablaPrincipalManoObra').append(
                            //    '<tr><td>'
                            //    + json[index].NombreCompleto
                            //    + '</td>'
                            //    + '<td>'
                            //    + json[index].Lunes
                            //    + '</td>'
                            //    + '<td>'
                            //    + json[index].Martes
                            //    + '</td>'
                            //    + '<td>'
                            //    + json[index].Miercoles
                            //    + '</td>'
                            //    + '<td>'
                            //    + json[index].Jueves
                            //    + '</td>'
                            //    + '<td>'
                            //    + json[index].Viernes
                            //    + '</td>'
                            //    + '<td>'
                            //    + json[index].Sabado
                            //    + '</td>'
                            //    + '<td>'
                            //    + json[index].Domingo
                            //    + '</td>'
                            //    + '<td>'
                            //    + formato_numero(json[index].TotalDinero, 2, '.', ',')
                            //    + '</td>'
                            //    + '</tr>')
                        }

                        if (punto == "Mat Con OC Pend") {
                            $('#TablaPrincipalMatSinOC').hide();
                            $('#TablaPrincipalImprevistos').hide();
                            $('#TablaPrincipalMatConOC').hide();
                            $('#TablaPrincipalViaticos').hide();
                            $('#TablaPrincipalManoObra').hide();
                            $('#TablaPrincipalMatConOCPend').show();


                            $('tbody#listaTablaPrincipalMatConOCPend').append(
                                '<tr><td>'
                                + json[index].Folio
                                + '</td>'
                                + '<td>'
                                + json[index].ReferenciaCot
                                + '</td>'
                                + '<td>'
                                + json[index].NombreComercial
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].SubTotal, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].Iva, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + formato_numero(json[index].Total, 2, '.', ',')
                                + '</td>'
                                + '<td>'
                                + json[index].Fecha
                                + '</td>'
                                + '</tr>')
                        }
                    });
                    //debugger;
                    //data = jsonArray[0].DatosTabla;




                    //$('.detail').removeClass('detail');
                }

            }
        });

        $("#dvDetalleGrafica").modal();
    }

    Highcharts.theme = {
        colors: ['#f45b5b', '#8085e9', '#8d4654', '#7798BF', '#aaeeee',
            '#ff0066', '#eeaaee', '#55BF3B', '#DF5353', '#7798BF', '#aaeeee'],
        chart: {
            backgroundColor: null,
            style: {
                fontFamily: 'Signika, serif'
            }
        },
        title: {
            style: {
                color: 'black',
                fontSize: '16px',
                fontWeight: 'bold'
            }
        },
        subtitle: {
            style: {
                color: 'black'
            }
        },
        tooltip: {
            borderWidth: 0
        },
        legend: {
            itemStyle: {
                fontWeight: 'bold',
                fontSize: '13px'
            }
        },
        xAxis: {
            labels: {
                style: {
                    color: '#6e6e70'
                }
            }
        },
        yAxis: {
            labels: {
                style: {
                    color: '#6e6e70'
                }
            }
        },
        plotOptions: {
            series: {
                shadow: true
            },
            candlestick: {
                lineColor: '#404048'
            },
            map: {
                shadow: false
            }
        },

        // Highstock specific
        navigator: {
            xAxis: {
                gridLineColor: '#D0D0D8'
            }
        },
        rangeSelector: {
            buttonTheme: {
                fill: 'white',
                stroke: '#C0C0C8',
                'stroke-width': 1,
                states: {
                    select: {
                        fill: '#D0D0D8'
                    }
                }
            }
        },
        scrollbar: {
            trackBorderColor: '#C0C0C8'
        },

        // General
        background2: '#E0E0E8'

    };

    $('#btnGuardarProyeccion').click(function () {
        var id = document.getElementById('idProyecto').textContent;
        var txt10 = $('#txt10').val() == '' ? "0" : $('#txt10').val().replace(",", "");
        var txt20 = $('#txt20').val() == '' ? "0" : $('#txt20').val().replace(",", "");
        var txt30 = $('#txt30').val() == '' ? "0" : $('#txt30').val().replace(",", "");
        var txt40 = $('#txt40').val() == '' ? "0" : $('#txt40').val().replace(",", "");
        var txt50 = $('#txt50').val() == '' ? "0" : $('#txt50').val().replace(",", "");
        var txt60 = $('#txt60').val() == '' ? "0" : $('#txt60').val().replace(",", "");
        var txt70 = $('#txt70').val() == '' ? "0" : $('#txt70').val().replace(",", "");
        var txt80 = $('#txt80').val() == '' ? "0" : $('#txt80').val().replace(",", "");
        var txt90 = $('#txt90').val() == '' ? "0" : $('#txt90').val().replace(",", "");
        var txt100 = $('#txt100').val() == '' ? "0" : $('#txt100').val().replace(",", "");

        var params = "{'pid': '" + id +
            "', 'str10': '" + txt10.replace(",", "") + 
            "', 'strFecha10': '" + $('#txt10Fecha').val() + 
            "', 'str20': '" + txt20.replace(",", "") + 
            "', 'strFecha20': '" + $('#txt20Fecha').val() + 
            "', 'str30': '" + txt30.replace(",", "") + 
            "', 'strFecha30': '" + $('#txt30Fecha').val() + 
            "', 'str40': '" + txt40.replace(",", "") + 
            "', 'strFecha40': '" + $('#txt40Fecha').val() + 
            "', 'str50': '" + txt50.replace(",", "") + 
            "', 'strFecha50': '" + $('#txt50Fecha').val() + 
            "', 'str60': '" + txt60.replace(",", "") + 
            "', 'strFecha60': '" + $('#txt60Fecha').val() + 
            "', 'str70': '" + txt70.replace(",", "") + 
            "', 'strFecha70': '" + $('#txt70Fecha').val() + 
            "', 'str80': '" + txt80.replace(",", "") + 
            "', 'strFecha80': '" + $('#txt80Fecha').val() + 
            "', 'str90': '" + txt90.replace(",", "") + 
            "', 'strFecha90': '" + $('#txt90Fecha').val() + 
            "', 'str100': '" + txt100.replace(",", "") +
            "', 'strFecha100': '" + $('#txt100Fecha').val() + 
            "'}";
        console.log(params);
        $.ajax({
            async: true,
            url: "ProyectoDetallesAdmin.aspx/GuardarProyecciones",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                //cargarComentariosProyectos(id);

                //$('#txtComentarioProyecto').val('');

                swal({
                    title: 'Guardado Correctamente!',
                    timer: 10000
                });

                location.href = URLactual;
            }
        });

    });

    $('#btnProyeccionFinanciera').click(function () {

        //console.log(this.value);

        //$('#idProyecto').text(this.value);
        document.getElementById('idProyecto').textContent = this.value;


        var params = "{'IdProyecto': '" + this.value + "'}";
        $.ajax({
            async: true,
            url: "ProyectoDetallesAdmin.aspx/cargarProyeccionFinanciera",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var json = JSON.parse(data.d);
                $(json).each(function (index, value) {
                    //$('#lblProyecto').text(value.Folio + ' - ' + value.NombreProyecto);
                    //$('#lblDescripcion').text(value.Descripcion);

                    $('#txt10').val(formato_numero((value.str10), 2, '.', ',') );
                    $('#txt20').val(formato_numero((value.str20), 2, '.', ','));
                    $('#txt30').val(formato_numero((value.str30), 2, '.', ','));
                    $('#txt40').val(formato_numero((value.str40), 2, '.', ','));
                    $('#txt50').val(formato_numero((value.str50), 2, '.', ','));
                    $('#txt60').val(formato_numero((value.str60), 2, '.', ','));
                    $('#txt70').val(formato_numero((value.str70), 2, '.', ','));
                    $('#txt80').val(formato_numero((value.str80), 2, '.', ','));
                    $('#txt90').val(formato_numero((value.str90), 2, '.', ','));
                    $('#txt100').val(formato_numero((value.str100), 2, '.', ','));
                    //debugger;
                    $('#txt10Fecha').val(value.strFecha10.substring(0, 10));
                    $('#txt20Fecha').val(value.strFecha20.substring(0, 10));
                    $('#txt30Fecha').val(value.strFecha30.substring(0, 10));
                    $('#txt40Fecha').val(value.strFecha40.substring(0, 10));
                    $('#txt50Fecha').val(value.strFecha50.substring(0, 10));
                    $('#txt60Fecha').val(value.strFecha60.substring(0, 10));
                    $('#txt70Fecha').val(value.strFecha70.substring(0, 10));
                    $('#txt80Fecha').val(value.strFecha80.substring(0, 10));
                    $('#txt90Fecha').val(value.strFecha90.substring(0, 10));
                    $('#txt100Fecha').val(value.strFecha100.substring(0, 10));
                });

                $('#ProyeccionFinancieraModal').modal();
            }
        });


        

    });

    //function proyeccionFinanciera(btn) {

    //    console.log(btn.value);

    //    document.getElementById('idProyecto').textContent = btn.value;

    //    $('#ProyeccionFinancieraModal').modal();
    //}


});


