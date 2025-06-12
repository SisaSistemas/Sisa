$(document).ready(function () {
    var URLactual = window.location;
    var idProyecto = 0;
    var Tarea = '';

    if (URLactual.href.indexOf("ProyectoTareas.aspx") > -1) {
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        idProyecto = document.getElementById('MainContent_idProyectoTarea').value;
        Tarea = document.getElementById('MainContent_lblFolio').textContent

        verGraficaPastelDetalle('TotalTareas', idProyecto);


        CargarTareas();
        CargarUsuarios();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
        
    }

    function CargarTareas() {
        $('tbody#listaProyectosTareas').empty();
        var parametros = "{'pid': '"+idProyecto+"'}";
        $.ajax({
            dataType: "json",
            url: "ProyectoTareas.aspx/CargaTareas",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {
                        var idTarea = json[index].IdTask;
                        var Task = json[index].Task;
                        var NombreCompleto = json[index].NombreCompleto;
                        var FechaInicio = json[index].FechaInicio.substring(0,10);
                        var FechaFin = json[index].FechaFin.substring(0, 10);
                        var Dias = json[index].Dias;
                        var DiasTranscurridos = json[index].DiasTranscurridos;
                        var Comentarios = json[index].Comentarios;
                        var Porcentaje = json[index].Porcentaje;
                        var Estatus = json[index].Estatus;
                        var botonSubirArchivo = "";
                        var botonVerArchivo = "";
                        var noArchivos = "0";

                        var trstyle = '';
                        if (Estatus == '0') {
                            Estatus = "PENDIENTE";
                            trstyle = 'style="background - color: lightskyblue;"';
                        } else if (Estatus == '1') {
                            Estatus = "AVANCE";
                            trstyle = 'style="background - color: wheat;"';
                        } else if (Estatus == '2') {
                            Estatus = "TERMINADO";
                            trstyle = 'style="background - color: green;"';
                        }

                        if (Task == "03-DAILY REPORTS") {
                            botonVerArchivo = '<Button title="Ver Archivos" class="btn btn-info btn-sm verArchivosDaily" value="' + idTarea + '"><i class="icon_desktop"></i></Button>';
                            botonSubirArchivo = '<Button title="Subir Archivos" class="btn btn-primary btn-sm subirArchivosDaily" value="' + idTarea + '" ><i class="icon_upload"></i></Button>';
                            noArchivos = item.ContDaily;
                        }
                        else {
                            botonVerArchivo = '<Button title="Ver Archivos" class="btn btn-info btn-sm verArchivos" value="' + idTarea + '"><i class="icon_desktop"></i></Button>';
                            botonSubirArchivo = '<Button title="Subir Archivos" class="btn btn-primary btn-sm subirArchivos" value="' + idTarea + '" ><i class="icon_upload"></i></Button>';
                            noArchivos = item.CONT;
                        }



                        $('tbody#listaProyectosTareas').append(
                            '<tr ' + trstyle + '><td style="display:none;">'
                            + idTarea
                            + '</td>'
                            + '<td>'
                            + Task
                            + '</td>'
                            //+ '<td>'
                            //+ NombreCompleto
                            //+ '</td>'
                            //+ '<td>'
                            //+ FechaInicio
                            //+ '</td>'
                            //+ '<td>'
                            //+ FechaFin
                            //+ '</td>'
                            //+ '<td>'
                            //+ Dias
                            //+ '</td>'
                            //+ '<td>'
                            //+ DiasTranscurridos
                            //+ '</td>'
                            + '<td>'
                            + '<span class="badge badge-warning">' + noArchivos + '</span>'
                            +'</td>'
                            + '<td>'
                            + '<div class="btn-group">'
                            //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> 'onclick="VerImagen(this);"
                            + botonVerArchivo
                            //+ '<span class="btn btn-info btn-sm"><i class="icon_desktop"></i></span>'
                            //+ '<Button title="Comentario" class="btn btn-default" value="' + idTarea + '" onclick="ComentariosTarea(this);"><i class="icon_comment_alt"></i></Button>'onclick="AgregarImagen(this);"
                            //+ '<Button title="Subir Archivos" class="btn btn-primary btn-sm subirArchivos" value="' + idTarea + '" ><i class="icon_upload"></i></Button>'
                            + botonSubirArchivo
                            //+ '<Button title="Avance" class="btn btn-success btn-sm avance" value="' + idTarea + '" ><i class="icon_check"></i></Button>'
                            //+ '<Button title="Eliminar" class="btn btn-danger" value="' + idTarea + '" onclick="EliminarTarea(this);"><i class="icon_close_alt2"></i></Button>'onclick="AvanceTarea(this);"
                            //+ '<Button title="Editar fechas" class="btn btn-success" value="' + idTarea + '" onclick="EditarTareasFechas(this);"><i class="icon_pencil"></i></Button>'
                            + '</div > '
                            + '</td>'
                            + '</tr>')
                    });
                   
                    
                }
                else {
                    $("#CargandoProyectosTareas").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }
            }
        });
    }

    function CargarUsuarios() {
        var params = "{'Opcion': '1'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'ProyectoTareas.aspx/CargarCombos',
            data: params,
            success: function (data, textStatus) {

                var json = $.parseJSON(data.d);

                $('#cmbUsuarios').html('');
                $.each(json, function (index, value) {
                    $("#cmbUsuarios").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
                });
                $('#cmbUsuarios').selectpicker('refresh');
                $('#cmbUsuarios').selectpicker('render');
            }
        });
    }

    //function fnDibujarGraficaPastel() {

    //    var graficaDatos = [];
    //    var graficaFechas = [];

    //    var params = "{'IdProyecto': '" + idProyecto + "'}";

    //    $.ajax({
    //        dataType: 'json',
    //        async: true,
    //        contentType: "application/json; charset=utf-8",
    //        type: 'POST',
    //        url: 'ProyectoTareas.aspx/CargarGraficaPastel',
    //        data: params,
    //        success: function (data, textStatus) {
    //            //debugger;
    //            graficaDatos = [];
    //            graficaFechas = [];
    //            var totalGastado = 0;

    //            var JsonDatos;
    //            var JsonPastel;
    //            var jsonArray = $.parseJSON(data.d);

    //            var i = 1;
    //            $.each(jsonArray, function (index, value) {
    //                graficaDatos.push([value.Nombre, parseFloat(value.Porcentaje), parseFloat(value.Dato)]);
    //                graficaFechas.push([value.Nombre]);

    //                if (value.Nombre == 'TotalGastos') {
    //                    totalGastado = parseFloat(value.Dato);
    //                }
    //            });
    //            //console.log(totalGastado)
    //            dibujarGraficaPastel('maina', graficaFechas, graficaDatos);

    //            if (totalGastado != 0) {
    //                verGraficaPastelDetalle('TotalGastos', idProyecto, totalGastado);
    //            }

    //        }
    //    });

    //}

    //function dibujarGraficaPastel(divGrafica, graficaFecha, graficaNombre) {
    //    Highcharts.chart(divGrafica, {
    //        chart: {
    //            type: 'pie',
    //            animation: true,
    //            options3d: {
    //                enabled: true,
    //                alpha: 45,
    //                beta: 0
    //            }
    //        },
    //        title: {
    //            text: 'GRAFICA UTILIDAD'
    //        },
    //        tooltip: {
    //            //pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
    //            pointFormat: '<b>$ {point.x:.2f}</b>: <b>{point.y:.2f} %</b>'
    //        },
    //        plotOptions: {
    //            pie: {
    //                allowPointSelect: true,
    //                cursor: 'pointer',
    //                depth: 35,
    //                dataLabels: {
    //                    enabled: true,
    //                    format: '{point.name}'
    //                }
    //            }
    //        },
    //        series: [{
    //            type: 'pie',
    //            name: '',
    //            data: [{
    //                name: graficaNombre[0][0],
    //                color: '#FF0000',
    //                x: formato_numero(graficaNombre[0][2], 2, '.', ','),
    //                y: graficaNombre[0][1],
    //                sliced: true,
    //                selected: true
    //            }, {
    //                name: graficaNombre[1][0],
    //                color: '#81F781',
    //                x: formato_numero(graficaNombre[1][2], 2, '.', ','),
    //                y: graficaNombre[1][1]
    //            }]//,
    //            //point: {
    //            //    events: {
    //            //        click: function (e) {
    //            //            verGraficaPastelDetalle(e.point.name, idProyecto);
    //            //            //verDetallePastel(fechaIni, fechaFin, e.point.name, $('#DDParte :selected').text().substring(0, $('#DDParte :selected').text().indexOf('-')).trim());
    //            //        }
    //            //    }
    //            //}
    //        }],
    //        credits: {
    //            enabled: false,                      // Whether to show the credits text.
    //            href: 'http://www.highcharts.com',  // The URL for the credits label.
    //            position: null,                     // Position configuration for the credtis label.
    //            style: null,                        // CSS styles for the credits label.
    //            text: 'Highcharts.com.'             // The text for the credits label.
    //        },
    //        exporting: {
    //            filename: 'Reporte_Resumen'
    //        }
    //    });
    //}

    //function dibujarGrafica(divGrafica, graficaFecha, graficaNombre) {
    //    Highcharts.chart(divGrafica, {
    //        chart: {
    //            type: 'pie',
    //            animation: true,
    //            options3d: {
    //                enabled: true,
    //                alpha: 45,
    //                beta: 0
    //            }
    //        },
    //        title: {
    //            text: Tarea
    //        },
    //        tooltip: {
    //            //pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
    //            pointFormat: '{series.name}: <b>{point.y}</b>'
    //        },
    //        plotOptions: {
    //            pie: {
    //                allowPointSelect: true,
    //                cursor: 'pointer',
    //                depth: 35,
    //                dataLabels: {
    //                    enabled: true,
    //                    format: '{point.name}'
    //                }
    //            }
    //        },
    //        series: [{
    //            type: 'pie',
    //            name: '# Tasks',
    //            data: [graficaNombre[0], graficaNombre[1], graficaNombre[2], graficaNombre[3], graficaNombre[4], graficaNombre[5], graficaNombre[6], graficaNombre[7], graficaNombre[8]],
    //            point: {
    //                events: {
    //                    click: function (e) {
    //                        verGraficaPastelDetalle(e.point.name, idProyecto);
    //                        //verDetallePastel(fechaIni, fechaFin, e.point.name, $('#DDParte :selected').text().substring(0, $('#DDParte :selected').text().indexOf('-')).trim());
    //                    }
    //                }
    //            }
    //        }],
    //        credits: {
    //            enabled: false,                      // Whether to show the credits text.
    //            href: 'http://www.highcharts.com',  // The URL for the credits label.
    //            position: null,                     // Position configuration for the credtis label.
    //            style: null,                        // CSS styles for the credits label.
    //            text: 'Highcharts.com.'             // The text for the credits label.
    //        },
    //        exporting: {
    //            filename: 'Reporte_Resumen'
    //        }
    //    });
    //}

    function verGraficaPastelDetalle(nombre, idProyecto) {
        debugger;
        var graficaDefecto = [];
        var graficaErroneos = [];
        var params = "{'Nombre': '" + nombre + "', 'IdProyecto': '" + idProyecto + "'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'ProyectoTareas.aspx/CargarGrafica',
            data: params,
            success: function (data, textStatus) {
                debugger;
                graficaDefecto = [];
                graficaErroneos = [];

                var JsonDatos;
                var jsonArray = $.parseJSON(data.d);
              
                $.each(jsonArray, function (index, value) {
                    graficaErroneos.push([value.Nombre, parseFloat(value.Total), parseFloat(value.Porcentaje)]);
                    graficaDefecto.push([value.Task]);
                });

                graficaPastelDetalle('dvGraficaDetalle', graficaErroneos, graficaDefecto);
            }


        });
    }

    function graficaPastelDetalle(divGrafica, graficaErroneos, graficaFormato) {
        debugger;

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
                        enabled: false,
                        format: '{point.name}'
                    }
                }
            },
            series: [{
                type: 'pie',
                name: '',
                data: [{
                    name: graficaErroneos[0][0],
                    color: '#FE2E2E',
                    x: graficaErroneos[0][2],
                    y: graficaErroneos[0][1]
                }, {
                    name: graficaErroneos[1][0],
                    color: '#FE2E2E',
                    x: graficaErroneos[1][2],
                    y: graficaErroneos[1][1]
                }, {
                    name: graficaErroneos[2][0],
                    color: '#FE2E2E',
                    x: graficaErroneos[2][2],
                    y: graficaErroneos[2][1]
                }, {
                    name: graficaErroneos[3][0],
                    color: '#FE2E2E',
                    x: graficaErroneos[3][2],
                    y: graficaErroneos[3][1]
                }, {
                    name: graficaErroneos[4][0],
                    color: '#FE2E2E',
                    x: graficaErroneos[4][2],
                    y: graficaErroneos[4][1]
                }, {
                    name: graficaErroneos[5][0],
                    color: '#FE2E2E',
                    x: graficaErroneos[5][2],
                    y: graficaErroneos[5][1]
                }, {
                    name: graficaErroneos[6][0],
                    color: '#81F781',
                    x: graficaErroneos[6][2],
                    y: graficaErroneos[6][1]
                }
                ],
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

        if (punto == 'UTILIDAD') {
            return;
        }

        $('#lblTituloDetalle').text('Detalle de ' + punto);

        var params = "{'Punto': '" + punto + "', 'IdProyecto': '" + proyecto + "'}";
        var FActuraOC = '';
        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'ProyectoTareas.aspx/CargarDetalle',
            data: params,
            success: function (data, textStatus) {
                var JsonClienes;
                debugger;
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

    //function graficaPastelDetalle(divGrafica, graficaErroneos, graficaFormato) {

    //    Highcharts.chart(divGrafica, {
    //        chart: {
    //            type: 'pie',
    //            animation: true,
    //            options3d: {
    //                enabled: true,
    //                alpha: 45,
    //                beta: 0
    //            }
    //        },
    //        title: {
    //            text: 'Estatus tareas de encargado eleccionado'
    //        },
    //        tooltip: {
    //            //pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
    //            pointFormat: '{series.name}: <b>{point.y}</b>'
    //        },
    //        plotOptions: {
    //            pie: {
    //                allowPointSelect: true,
    //                cursor: 'pointer',
    //                depth: 35,
    //                dataLabels: {
    //                    enabled: true,
    //                    format: '{point.name}'
    //                }
    //            }
    //        },
    //        series: [{
    //            type: 'pie',
    //            name: '# Tasks',
    //            data: [graficaErroneos[0], graficaErroneos[1], graficaErroneos[2], graficaErroneos[3], graficaErroneos[4], graficaErroneos[5], graficaErroneos[6], graficaErroneos[7], graficaErroneos[8]],
    //            point: {
    //                events: {
    //                    click: function (e) {
    //                        //verGraficaPastelDetalle(fechaIni, fechaFin, e.point.name, $('#DDParte :selected').text().substring(0, $('#DDParte :selected').text().indexOf('-')).trim());
    //                        //verDetallePastel(fechaIni, fechaFin, e.point.name, $('#DDParte :selected').text().substring(0, $('#DDParte :selected').text().indexOf('-')).trim());
    //                    }
    //                }
    //            }
    //        }],
    //        credits: {
    //            enabled: false,                      // Whether to show the credits text.
    //            href: 'http://www.highcharts.com',  // The URL for the credits label.
    //            position: null,                     // Position configuration for the credtis label.
    //            style: null,                        // CSS styles for the credits label.
    //            text: 'Highcharts.com.'             // The text for the credits label.
    //        },
    //        exporting: {
    //            filename: 'Reporte_'
    //        }
    //    });
    //}

    $('#btnEliminarProyectos').click(function () {
        var id = document.getElementById('idProyectosEliminar').textContent;

        var parametros = "{'pid': '" + id + "'}";
        $.ajax({
            dataType: "json",
            url: "ProyectoTareas.aspx/EliminarProyectosTarea",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Tarea eliminado.") {
                    // $("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                    Grafica();
                    CargarTareas();
                }
                else {
                    //$("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnTareaProyectos').click(function () {
        
        var parametros = "{'pid': '" + idProyecto + "', 'Tarea':'" + $('#txtTitulo').val() + "', 'Inicio':'" + $('#dtInicio').val() + "', 'Fin':'" + $('#dtFin').val() + "', 'Comentario':'" + $('#txtComentario').val() + "', 'idUsuarioAsignado':'" + $('#cmbUsuarios').val() +"'}";
        $.ajax({
            dataType: "json",
            url: "ProyectoTareas.aspx/GuardarTarea",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Tarea agregada") {
                    // $("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                    Grafica();
                    CargarTareas();
                }
                else {
                    //$("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnAvanceProyectos').click(function () {
        var id = document.getElementById('idProyectosAvance').textContent;
        if ($('#cmbPorcentaje').val() == '') {
            swal("Selecciona porcentaje...");
            return;
        }
        var parametros = "{'pid': '" + id + "', 'Porcentaje':'" + $('#cmbPorcentaje').val() + "'}";
        $.ajax({
            dataType: "json",
            url: "ProyectoTareas.aspx/ActualizarAvance",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Tarea actualizada") {
                    // $("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                    Grafica();
                    CargarTareas();
                }
                else {
                    //$("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnAgregarArchivoProyecto').click(function () {

        swal({
            title: 'Seleccione archivo',
            input: 'file',
            allowOutsideClick: false,
            allowEscapeKey: false,
            allowEnterKey: false,
            showCloseButton: true
        }).then(function (file) {
            var nombreArchivo = file.name;
            var reader = new FileReader
            reader.onload = function (e) {
                //debugger;
                //console.log(nombreArchivo);

                //var params = "{'IdCotizacion': '" + idCotizacion +
                //    "','NombreArchivo': '" + nombreArchivo +
                //    "','Documento': '" + e.target.result + "'}";

                var params = "{'IdDocumento': '" + '0' +
                    "','IdProyecto': '" + idProyecto +
                    "','FileName': '" + nombreArchivo +
                    "','File': '" + e.target.result +
                    "','Opcion': '" + "1" + "'}";

                //console.log(params);
                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "ProyectoTareas.aspx/GuardarDocumentos",
                    data: params,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        //location.href = './frmProjects.aspx';

                        swal({
                            title: msg.d,
                            timer: 3000
                        });

                        //cargarArchivos();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {

                    }
                });


            }

            reader.readAsDataURL(file);

        });


    });

    $('#btnVerGaleria').click(function () {

        var params = "{'IdDocumento': '" + 0 +
            "','IdProyecto': '" + idProyecto +
            "','FileName': '" + "" +
            "','File': '" + "" +
            "','Opcion': '" + "3" + "'}";

        $.ajax({
            async: true,
            url: "ProyectoTareas.aspx/CargarDocumentos",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                var datos = "";

                var JsonCombos;
                var jsonArray = $.parseJSON(data.d);
                
                $('#ulFiles').html('');
                $('#slideimagenes').html('');
                $('#slidenumeracion').html('');
                var cont = 1;
                $.each(jsonArray, function (index, value) {
                    var icono = '<i class="fa fa-file-code-o"></i>';
                    
                    var file = value.NombreArchivo.substring(value.NombreArchivo.indexOf("."));
                    if (file == '.png' || file == '.jpg' || file == '.PNG' || file == '.JPG' || file == '.JPEG' || file == '.jpeg' || file == '.jfif' || file == '.JFIF') {
                        $('#slideimagenes').append('<li class="slide" id="slide' + cont + '"><a href = "#" ><img src="' + value.Archivo + '" alt="photo ' + cont + '" height="350" width="120"></a></li >');
                        $('#slidenumeracion').append('<li><a href="#slide' + cont + '">&bullet;</a></li>');
                        cont++;
                    }
                    else {
                        //$('#ulFiles').append('<li>'+ icono + '<a href="' + value.Archivo + '" target="_blank">' + value.NombreArchivo + '</a></li>');
                    }
                   

                });
            }
            
        });
        $("#GaleriaProyectosModal").modal();

    });    

    $('#btnVerGaleriaArchivos').click(function () {

        var params = "{'IdDocumento': '" + 0 +
            "','IdProyecto': '" + idProyecto +
            "','FileName': '" + "" +
            "','File': '" + "" +
            "','Opcion': '" + "3" + "'}";

        $.ajax({
            async: true,
            url: "ProyectoTareas.aspx/CargarDocumentos",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                
                var jsonArray = $.parseJSON(data.d);

                $('#ulFiles').html('');
                var cont = 1;
                $.each(jsonArray, function (index, value) {
                    var icono = '<i class="icon_document_alt"></i>';

                    var file = value.NombreArchivo.substring(value.NombreArchivo.indexOf("."));
                    if (file == '.png' || file == '.jpg' || file == '.PNG' || file == '.JPG' || file == '.JPEG' || file == '.jpeg' || file == '.jfif' || file == '.JFIF') {
                        //$('#slideimagenes').append('<li class="slide" id="slide' + cont + '"><a href = "#" ><img src="' + value.Archivo + '" alt="photo ' + cont + '" height="350" width="120"></a></li >');
                        //$('#slidenumeracion').append('<li><a href="#slide' + cont + '">&bullet;</a></li>');
                        //cont++;
                    }
                    else {
                        $('#ulFiles').append('<li>' + icono + '&nbsp<Button type="button" id="idDocumentoBoton" class="btn btn-default" value="' + value.IdDocumento.trim() + '" onclick="VerDoc(this);">' + value.NombreArchivo + '</Button>&nbsp&nbsp<button class="btn btn-danger eliminarDoc" id="btnEliminarArchivo" type="button" value="' + value.IdDocumento.trim() + '" rel="' + value.NombreArchivo +'"><i class="icon_close_alt2"></i></button></li><br>');

                    }
                    

                });
            }

        });
        $("#GaleriaArchivosProyectosModal").modal();

    });  
    
    

    $('#btnAgregarComentarioProyectosTarea').click(function () {
        var id = document.getElementById('idComentariosTareaTexto').textContent;

        var params = "{'pid': '" + id + "', 'Comentario': '" + $('#txtComentarioProyectoTarea').val() + "'}";

        $.ajax({
            async: true,
            url: "ProyectoTareas.aspx/GuardarComentariosTarea",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                if (data.d != "") {
                    cargarComentariosProyectos(id);

                    $('#txtComentarioProyectoTarea').val('');
                } else {
                    swal('Ocurrio un error al insertar comentario, intenta de nuevo recargando la página.');
                }
                
            }
        });
    });

    function cargarComentariosProyectos(id) {
       
        var params = "{'pid': '" + id+ "'}";
        $.ajax({
            async: true,
            url: "ProyectoTareas.aspx/CargarComentariosTareas",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var datos = "";
                var nodoTRAgregar = "";

                var JsonCombos;
                var jsonArray = $.parseJSON(data.d);

                $('#TablaPrincipalComentariosProyectosTarea tbody').html('');
                $.each(jsonArray, function (index, value) {
                    nodoTRAgregar += "<tr>";
                    nodoTRAgregar += '  <td style="display: none;">' + value.IdTaskComentario + "</td>";
                    nodoTRAgregar += "  <td>" + value.Comentario + "</td>";
                    nodoTRAgregar += "  <td>" + value.NombreCompleto + "</td>";
                    nodoTRAgregar += "  <td>" + value.Fecha.substring(0,10) + "</td>";
                    nodoTRAgregar += "</tr>";
                });

                $('#TablaPrincipalComentariosProyectosTarea tbody').append(nodoTRAgregar);
            }
        });
    }

    $('#btnGuardarFechasTarea').click(function () {
        var id = document.getElementById('idProyectoFechasTarea').textContent;
        if ($('#txtRazonCambio').val() == '') {
            swal('Es obligatorio proporcionar una razón de cambio.');
            return;
        }
        var params = "{'pid': '" + id + "', 'Razon': '" + $('#txtRazonCambio').val() + "', 'Inicio': '" + $('#dtFechaInicio').val() + "', 'Fin': '" + $('#dtFechaTermino').val() + "'}";

        $.ajax({
            async: true,
            url: "ProyectoTareas.aspx/GuardarFechas",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                if (data.d == 'Fechas actualizadas.') {

                    swal(data.d);
                    //CargarTareas();
                    location.reload();
                }
                else {
                    swal(data.d);
                }
            }
        });
    });

    $(document).on('click', '.eliminarDoc', function (event) {
        //;
        //var _boton = $(this);
        //var _item = $(this).parent().parent().find('td')[0].innerHTML;
        //var _producto = $(this).parent().parent().find('td')[2].innerHTML;
        //var _cantidad = $(this).parent().parent().find('td')[4].innerHTML;

        var nombreArchivo = $(this).attr('rel');
        var idDocumento = $(this).val();

        //debugger;

        swal({
            title: "Esta seguro que desea eliminar el documento " + nombreArchivo + "?",
            type: "warning",
            allowOutsideClick: false,
            allowEscapeKey: false,
            allowEnterKey: false,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si',
            cancelButtonText: 'No'
        }).then(function (result) {

            var params = "{'IdDocumento': '" + idDocumento + "','IdProyecto': '" + idProyecto + "'}";

            $.ajax({
                dataType: 'json',
                async: true,
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                url: 'ProyectoTareas.aspx/EliminarDocumento',
                data: params,
                success: function (data, textStatus) {
                    if (data.d == 'Error') {
                        swal({
                            title: "Hay un error no se encontro el documento, favor de recargar la pagina!",
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
                        //CargarDatosDetalle();

                        swal({
                            title: "Se elimino correctamente el archivo.",
                            type: "success",
                            allowOutsideClick: false,
                            allowEscapeKey: false,
                            allowEnterKey: false,
                            showCancelButton: true,
                            confirmButtonColor: '#3085d6',
                            cancelButtonColor: '#d33',
                            cancelButtonText: 'Cerrar'
                        }).then(function () {
                            location.reload();
                        });
                    }


                }
            });


        }, function (dismiss) {
            // dismiss can be 'cancel', 'overlay',
            // 'close', and 'timer'
            if (dismiss === 'cancel') {
                swal(
                    'Cancelled',
                    'Cancelo la eliminacion del documento.',
                    'error'
                );
            }
        });

    });

    $(document).on('click', '.verArchivos', function (event) {

       

        var params = "{'IdDocumento': '" + 0 +
            "','IdProyecto': '" + idProyecto +
            "','FileName': '" + "" +
            "','File': '" + "" +
            "','IdTask': '" + $(this).val() +
            "','Opcion': '" + "6" + "'}";

        //console.log(params);

        $.ajax({
            async: true,
            url: "ProyectoTareas.aspx/CargarDocumentos",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var jsonArray = $.parseJSON(data.d);

                $('#ulFiles').html('');
                var cont = 1;
                $.each(jsonArray, function (index, value) {
                    var icono = '<i class="icon_document_alt"></i>';

                    var file = value.NombreArchivo.substring(value.NombreArchivo.indexOf("."));
                    //if (file == '.png' || file == '.jpg' || file == '.PNG' || file == '.JPG' || file == '.JPEG' || file == '.jpeg' || file == '.jfif' || file == '.JFIF') {
                    //    //$('#slideimagenes').append('<li class="slide" id="slide' + cont + '"><a href = "#" ><img src="' + value.Archivo + '" alt="photo ' + cont + '" height="350" width="120"></a></li >');
                    //    //$('#slidenumeracion').append('<li><a href="#slide' + cont + '">&bullet;</a></li>');
                    //    //cont++;
                    //}
                    //else {
                    //    $('#ulFiles').append('<li>' + icono + '&nbsp<Button type="button" id="idDocumentoBoton" class="btn btn-default" value="' + value.IdDocumento.trim() + '" onclick="VerDoc(this);">' + value.NombreArchivo + '</Button>&nbsp&nbsp<button class="btn btn-danger eliminarDoc" id="btnEliminarArchivo" type="button" value="' + value.IdDocumento.trim() + '" rel="' + value.NombreArchivo + '"><i class="icon_close_alt2"></i></button></li><br>');

                    //}
                    $('#ulFiles').append('<li>' + icono + '&nbsp<Button type="button" id="idDocumentoBoton" class="btn btn-default" value="' + value.IdDocumento.trim() + '" onclick="VerDoc(this);">' + value.NombreArchivo + '</Button>&nbsp&nbsp<button class="btn btn-danger eliminarDoc" id="btnEliminarArchivo" type="button" value="' + value.IdDocumento.trim() + '" rel="' + value.NombreArchivo + '"><i class="icon_close_alt2"></i></button></li><br>');

                });
            }

        });
        $("#GaleriaArchivosProyectosModal").modal();


        ////console.log("si entro");
        //var idBoton = $(this).val();

        //var parametros = "{'pid': '" + idBoton + "'}";
        //$.ajax({
        //    dataType: "json",
        //    url: "ProyectoTareas.aspx/ObtenerImagenTarea",
        //    async: true,
        //    data: parametros,
        //    type: "POST",
        //    contentType: "application/json; charset=utf-8",
        //    success: function (data) {
        //        var datos = data.d;
        //        if (data.d != "") {
                   
        //            var jsonArray = $.parseJSON(data.d);

                   
        //            $('#slidertareas').html('');

        //            $('#slidertareas').append('<ul class="slides" id="slideimagenestareas"></ul><ul class="slider-controler" id="slidenumeraciontareas"></ul>');

        //            $('#slideimagenestareas').html('');
        //            $('#slidenumeraciontareas').html('');
        //            var cont = 1;
        //            $.each(jsonArray, function (index, value) {
        //                var icono = '<i class="fa fa-file-code-o"></i>';
                       
        //                if (value.Imagen.includes("PDF") || value.Imagen.includes("pdf")) {

        //                    $('#slidertareas').append('<embed src="' + value.Imagen + '" type="application/pdf" width="100%" height="600px" />');
        //                }
        //                else {

        //                    $('#slideimagenestareas').append('<li class="slide" id="slide' + cont + '"><a href = "#" ><img src="' + value.Imagen + '" alt="photo ' + cont + '" height="350" width="120"></a></li >');
        //                    $('#slidenumeraciontareas').append('<li><a href="#slide' + cont + '">&bullet;</a></li>');
        //                    cont++;
        //                }

        //            });

        //            $("#dvImagenTarea").modal();

        //        }
        //        else {
        //            swal("No existe registro");
        //        }
        //    }
        //});

    });

    $(document).on('click', '.verArchivosDaily', function (event) {

        

        var params = "{'IdDocumento': '" + 0 +
            "','IdProyecto': '" + idProyecto +
            "','FileName': '" + "" +
            "','File': '" + "" +
            "','IdTask': '" + $(this).val() +
            "','Opcion': '" + "7" + "'}";

        //console.log(params);

        $.ajax({
            async: true,
            url: "ProyectoTareas.aspx/CargarDocumentos",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var jsonArray = $.parseJSON(data.d);

                $('#ulFiles').html('');
                var cont = 1;
                $.each(jsonArray, function (index, value) {
                    var icono = '<i class="icon_document_alt"></i>';

                    var file = value.NombreArchivo.substring(value.NombreArchivo.indexOf("."));
                    if (file == '.png' || file == '.jpg' || file == '.PNG' || file == '.JPG' || file == '.JPEG' || file == '.jpeg' || file == '.jfif' || file == '.JFIF') {
                        //$('#slideimagenes').append('<li class="slide" id="slide' + cont + '"><a href = "#" ><img src="' + value.Archivo + '" alt="photo ' + cont + '" height="350" width="120"></a></li >');
                        //$('#slidenumeracion').append('<li><a href="#slide' + cont + '">&bullet;</a></li>');
                        //cont++;
                    }
                    else {
                        $('#ulFiles').append('<li>' + icono + '&nbsp<Button type="button" id="idDocumentoBoton" class="btn btn-default" value="' + value.IdDocumento.trim() + '" onclick="VerDoc(this);">' + value.NombreArchivo + '</Button>&nbsp&nbsp<button class="btn btn-danger eliminarDoc" id="btnEliminarArchivo" type="button" value="' + value.IdDocumento.trim() + '" rel="' + value.NombreArchivo + '"><i class="icon_close_alt2"></i></button></li><br>');

                    }


                });
            }

        });
        $("#GaleriaArchivosProyectosModal").modal();

    });


    $(document).on('click', '.subirArchivos', function (event) {

        var idBoton = $(this).val();

        swal({
            title: 'Seleccione archivo',
            input: 'file',
            allowOutsideClick: false,
            allowEscapeKey: false,
            allowEnterKey: false,
            showCloseButton: true
        }).then(function (file) {
            var nombreArchivo = file.name;
            var fileSize = file.size;
            var filetype = file.type;
            var reader = new FileReader
            reader.onload = function (e) {
                //debugger;
                //console.log(nombreArchivo);

                var params = "{'idTask': '" + idBoton +
                    "','IdProyecto': '" + document.getElementById('MainContent_idProyectoTarea').value +
                    "','FileName': '" + nombreArchivo +
                    "','FileSize': '" + fileSize +
                    "','FileType': '" + filetype +
                    "','File': '" + e.target.result +
                    "','Opcion': '" + "1" + "'}";

                //console.log(params);

                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "ProyectoTareas.aspx/GuardarImagenTarea",
                    data: params,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        //location.href = './frmProjects.aspx';

                        swal({
                            title: msg.d,
                            timer: 2000
                        }).then(function () {
                            cargarArchivos();
                        });

                        //
                    },
                    error: function (xhr, ajaxOptions, thrownError) {

                    }
                });


            }

            reader.readAsDataURL(file);
            //debugger;

        });

    });

    $(document).on('click', '.subirArchivosDaily', function (event) {

        var idBoton = $(this).val();

        swal({
            title: 'Seleccione archivo',
            input: 'file',
            allowOutsideClick: false,
            allowEscapeKey: false,
            allowEnterKey: false,
            showCloseButton: true
        }).then(function (file) {
            var nombreArchivo = file.name;
            var fileSize = file.size;
            var filetype = file.type;
            var reader = new FileReader
            reader.onload = function (e) {
                //debugger;
                //console.log(nombreArchivo);

                var params = "{'idTask': '" + idBoton +
                    "','IdProyecto': '" + document.getElementById('MainContent_idProyectoTarea').value +
                    "','FileName': '" + nombreArchivo +
                    "','FileSize': '" + fileSize +
                    "','FileType': '" + filetype +
                    "','file': '" + e.target.result +
                    "','Opcion': '" + "1" + "'}";

                //console.log(params);

                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "ProyectoTareas.aspx/GuardarDailyReport",
                    data: params,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        //location.href = './frmProjects.aspx';

                        swal({
                            title: msg.d,
                            timer: 2000
                        }).then(function () {
                            location.reload();
                        });

                        //
                    },
                    error: function (xhr, ajaxOptions, thrownError) {

                    }
                });


            }

            reader.readAsDataURL(file);
            //debugger;

        });

    });

    $(document).on('click', '.avance', function (event) {
        document.getElementById('idProyectosAvance').textContent = $(this).val();
        $("#AvanceProyectosModal").modal();
    });

});





