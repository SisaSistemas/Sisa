$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("Savings.aspx") > -1) {

        //document.body.style.zoom = "80%";

        //CargarSavings();
        fnDibujarGraficaHSAP();
        fnDibujarGraficaCSAP();
        fnDibujarGraficaCHEP();
        fnDibujarGraficaITP();
    }

});

function CargarSavings() {

    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "Savings.aspx/CargarSavings",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d == "No tienes permiso.") {
                swal(data.d);
                return;
            }
            if (data.d != "Error" || data.d != "-1") {
                var json = JSON.parse(data.d);

                data = json;
                //debugger;
                //console.log(data);

                $('#TablaSavings').bootstrapTable({
                    data: data,
                    detailView: false,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'IdSavings',
                    uniqueId: 'IdSavings',
                    onSearch: function (text) {
                        //CargarResumen(text);
                    },
                    onExpandRow: function (index, row, $detail) {
                        //$detail.hide().html(row.IdMaterial).fadeIn('slow');
                    },
                    onCollapseRow: function (index, row, $detail) {
                        $detail.clone().insertAfter($detail).fadeOut('slow', function () {
                            $(this).remove()
                        })
                    }
                });

                //CargarTotalesRecibidas();
                //CargarCombosFiltros(6);
                //CargarCombosFiltros(7);
                //CargarCombosFiltros(2);
                //CargarCombosFiltros(3);
                //CargarCombosFiltros(4);
                //CargarCombosFiltros(5);
                //CargarCombosFiltros(8);

            }
            else {
                swal(data.d);

            }
        }
    });

}

window.accionEvents = {
    'click .agregarMonto': function (e, value, row, index) {

        $('#txtMonto').val(row.Monto);

        $('#btnGuardarMonto').attr('rel', row.IdSavings);

        $('#modalEntregada').modal();

    },
    'click .editarTipo': function (e, value, row, index) {

        if (row.TipoAhorro == '' || row.TipoAhorro == "") {
            $('#cmbTipoAhorro').val(-1);
            $('#cmbTipoAhorro').selectpicker('refresh');
        }
        else {
            $('#cmbTipoAhorro').val(row.TipoAhorro);
            $('#cmbTipoAhorro').selectpicker('refresh');
        }

        $('#btnGuardarTipoAhorro').attr('rel', row.IdSavings);

        $('#modalTipoAhorro').modal();
    }
};

function accionFormatter(value, row, index) {
    return [
        '<div class="btn-group">',
        '<Button title="Agregar Monto" class= "btn btn-success agregarMonto" value="' + row.IdSavings + '"> <i class="icon_currency"></i></Button>',
        '<Button title="Editar" class= "btn btn-info editarTipo" value="' + row.IdSavings + '"> <i class="icon_pencil"></i></Button>',
        '</div>'
    ].join(' ');
}

function fnDibujarGraficaHSAP() {

    var graficaDatos = [];
    var graficaFechas = [];

    var params = "{'Id': 'E9A70DAC-356F-4AD0-988A-9CC3D8D88DB8'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'Savings.aspx/CargarGrafica',
        data: params,
        success: function (data, textStatus) {
            //debugger;
            graficaDatos = [];
            graficaFechas = [];
            var totalGastado = 0;

            var JsonDatos;
            var JsonPastel;
            var jsonArray = $.parseJSON(data.d);

            var i = 1;
            $.each(jsonArray, function (index, value) {
                graficaDatos.push([parseFloat(value.Monto)]);
                graficaFechas.push([value.MES]);

                //if (value.Nombre == 'TotalGastos') {
                //    totalGastado = parseFloat(value.Dato);
                //}
            });

            //console.log(graficaFechas);
            //console.log(graficaDatos[graficaDatos.length-1][0]);
            //console.log(graficaDatos.length);
            dibujarGraficaHSAP('maina', graficaFechas, graficaDatos, 'SAVINGS HSAP');

            //if (totalGastado != 0) {
            //    verGraficaPastelDetalle('TotalGastos', idProyecto, totalGastado);
            //}

        }
    });

}

function fnDibujarGraficaCSAP() {

    var graficaDatos = [];
    var graficaFechas = [];

    var params = "{'Id': '9DB0E133-FEFA-497D-899A-FAD6526AB652'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'Savings.aspx/CargarGrafica',
        data: params,
        success: function (data, textStatus) {
            //debugger;
            graficaDatos = [];
            graficaFechas = [];
            var totalGastado = 0;

            var JsonDatos;
            var JsonPastel;
            var jsonArray = $.parseJSON(data.d);

            var i = 1;
            $.each(jsonArray, function (index, value) {
                graficaDatos.push([parseFloat(value.Monto)]);
                graficaFechas.push([value.MES]);

            });

            //console.log(graficaFechas);
            dibujarGraficaCSAP('mainb', graficaFechas, graficaDatos, 'SAVINGS CSAP');

            //if (totalGastado != 0) {
            //    verGraficaPastelDetalle('TotalGastos', idProyecto, totalGastado);
            //}

        }
    });

}

function fnDibujarGraficaCHEP() {

    var graficaDatos = [];
    var graficaFechas = [];

    var params = "{'Id': '9DBA90B1-192D-4536-B79C-B86FDFF45CD3'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'Savings.aspx/CargarGrafica',
        data: params,
        success: function (data, textStatus) {
            //debugger;
            graficaDatos = [];
            graficaFechas = [];
            var totalGastado = 0;

            var JsonDatos;
            var JsonPastel;
            var jsonArray = $.parseJSON(data.d);

            var i = 1;
            $.each(jsonArray, function (index, value) {
                graficaDatos.push([parseFloat(value.Monto)]);
                graficaFechas.push([value.MES]);

            });

            //console.log(graficaFechas);
            dibujarGraficaCHEP('mainc', graficaFechas, graficaDatos, 'SAVINGS CHEP');

            //if (totalGastado != 0) {
            //    verGraficaPastelDetalle('TotalGastos', idProyecto, totalGastado);
            //}

        }
    });

}

function fnDibujarGraficaITP() {

    var graficaDatos = [];
    var graficaFechas = [];

    var params = "{'Id': '11C3483C-8E3C-4956-A6AC-A6BD908D896A'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'Savings.aspx/CargarGrafica',
        data: params,
        success: function (data, textStatus) {
            //debugger;
            graficaDatos = [];
            graficaFechas = [];
            var totalGastado = 0;

            var JsonDatos;
            var JsonPastel;
            var jsonArray = $.parseJSON(data.d);

            var i = 1;
            $.each(jsonArray, function (index, value) {
                graficaDatos.push([parseFloat(value.Monto)]);
                graficaFechas.push([value.MES]);

            });

            //console.log(graficaFechas);
            dibujarGraficaITP('maind', graficaFechas, graficaDatos, 'SAVINGS ITP');

            //if (totalGastado != 0) {
            //    verGraficaPastelDetalle('TotalGastos', idProyecto, totalGastado);
            //}

        }
    });

}

function dibujarGraficaHSAP(divGrafica, graficaFecha, graficaDatos, titulo) {
    Highcharts.chart(divGrafica, {
        title: {
            text: titulo
        },
        xAxis: {
            categories: graficaFecha //['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic']
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Monto'
            }

        },
        tooltip: {
            enabled: true,
            formatter: function () {
                return '<b>' + this.x + '</b><br/>' +
                    this.series.name + ': $' + this.y;
            }
        },
        series: [{
            type: 'line',
            name: 'SavingsHSAP',
            text: 'SavingsHSAP',
            data: graficaDatos, //[[0, graficaDatos[0][0]], [graficaDatos.length - 1, graficaDatos[graficaDatos.length - 1][0]]],
            marker: {
                enabled: false
            },
            states: {
                hover: {
                    lineWidth: 0
                }
            },
            enableMouseTracking: false
        },
        {
            type: 'scatter',
            name: 'Monto',
            data: graficaDatos,
            marker: {
                radius: 4
            },
            point: {
                events: {
                    click: function (e) {
                        verDetalleGrafica('FORD HSAP', e.point.category[0])
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
            filename: 'Reporte_SavingsHSAP'
        }
    });
}

function dibujarGraficaCSAP(divGrafica, graficaFecha, graficaDatos, titulo) {
    Highcharts.chart(divGrafica, {
        title: {
            text: titulo
        },
        xAxis: {
            categories: graficaFecha //['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic']
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Monto'
            }

        },
        tooltip: {
            enabled: true,
            formatter: function () {
                return '<b>' + this.x + '</b><br/>' +
                    this.series.name + ': $' + this.y;
            }
        },
        series: [{
            type: 'line',
            name: 'SavingsCSAP',
            text: 'SavingsCSAP',
            data: graficaDatos, //[[0, graficaDatos[0][0]], [graficaDatos.length - 1, graficaDatos[graficaDatos.length - 1][0]]],
            marker: {
                enabled: true
            },
            states: {
                hover: {
                    lineWidth: 0
                }
            },
            enableMouseTracking: false
        },
        {
            type: 'scatter',
            name: 'Monto',
            data: graficaDatos,
            marker: {
                radius: 4
            },
            point: {
                events: {
                    click: function (e) {
                        verDetalleGrafica('FORD CSAP', e.point.category[0])
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
            filename: 'Reporte_SavingsCSAP'
        }
    });
}

function dibujarGraficaCHEP(divGrafica, graficaFecha, graficaDatos, titulo) {
    Highcharts.chart(divGrafica, {
        title: {
            text: titulo
        },
        xAxis: {
            categories: graficaFecha //['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic']
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Monto'
            }

        },
        tooltip: {
            enabled: true,
            formatter: function () {
                return '<b>' + this.x + '</b><br/>' +
                    this.series.name + ': $' + this.y;
            }
        },
        series: [{
            type: 'line',
            name: 'SavingsCHEP',
            text: 'SavingsCHEP',
            data: graficaDatos, //[[0, graficaDatos[0][0]], [graficaDatos.length - 1, graficaDatos[graficaDatos.length - 1][0]]],
            marker: {
                enabled: false
            },
            states: {
                hover: {
                    lineWidth: 0
                }
            },
            enableMouseTracking: false
        },
        {
            type: 'scatter',
            name: 'Monto',
            data: graficaDatos,
            marker: {
                radius: 4
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
            filename: 'Reporte_SavingsCHEP'
        }
    });
}

function dibujarGraficaITP(divGrafica, graficaFecha, graficaDatos, titulo) {
    Highcharts.chart(divGrafica, {
        title: {
            text: titulo
        },
        xAxis: {
            categories: graficaFecha //['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic']
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Monto'
            }

        },
        tooltip: {
            enabled: true,
            formatter: function () {
                return '<b>' + this.x + '</b><br/>' +
                    this.series.name + ': $' + this.y;
            }
        },
        series: [{
            type: 'line',
            name: 'SavingsITP',
            text: 'SavingsITP',
            data: graficaDatos, //[[0, graficaDatos[0][0]], [graficaDatos.length - 1, graficaDatos[graficaDatos.length - 1][0]]],
            marker: {
                enabled: false
            },
            states: {
                hover: {
                    lineWidth: 0
                }
            },
            enableMouseTracking: false
        },
        {
            type: 'scatter',
            name: 'Monto',
            data: graficaDatos,
            marker: {
                radius: 4
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
            filename: 'Reporte_SavingsITP'
        }
    });
}

$('#btnGuardarMonto').click(function () {

    var idSavings = $(this).attr('rel');
    //console.log(idSavings);
    swal({
        title: 'Estas Seguro que quieres guardar la cantidad?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Aceptar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {

        if (result) {

            var monto = $('#txtMonto').val();

            var parametros = "{'IdSavings':'" + idSavings + "', 'Monto': '" + monto + "'}";
            $.ajax({
                dataType: "json",
                url: "Savings.aspx/AgregarMonto",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Cantidad actualizada.") {
                        // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');

                        swal(msg.d);
                        location.reload();
                    }
                    else {
                        //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                        swal(msg.d);
                    }
                }
            });

        }
    });

});

$('#btnGuardarTipoAhorro').click(function () {

    var idSavings = $(this).attr('rel');
    //console.log(idSavings);
    swal({
        title: 'Estas Seguro que quieres guardar el Tipo de Ahorro?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Aceptar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {

        if (result) {


            var parametros = "{'IdSavings':'" + idSavings + "', 'TipoAhorro': '" + $('#cmbTipoAhorro').val() + "'}";
            $.ajax({
                dataType: "json",
                url: "Savings.aspx/ActualizarTipoAhorro",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Tipo Ahorro actualizada.") {
                        // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');

                        swal(msg.d);
                        location.reload();
                    }
                    else {
                        //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                        swal(msg.d);
                    }
                }
            });

        }
    });

});

function verDetalleGrafica(_planta, _mes) {

    $('#LabelmodalDetalle').text("Detalle " + _planta);

    var parametros = "{'Planta': '" + _planta + "', 'Mes': '" + _mes + "'}";

    //console.log(parametros);

    $.ajax({
        dataType: "json",
        url: "Savings.aspx/CargarSavings",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d == "No tienes permiso.") {
                swal(data.d);
                return;
            }
            if (data.d != "Error" || data.d != "-1") {
                var json = JSON.parse(data.d);

                data = json;

                $('#TablaSavings').bootstrapTable({
                    data: data,
                    detailView: false,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'IdSavings',
                    uniqueId: 'IdSavings',
                    onSearch: function (text) {
                        //CargarResumen(text);
                    },
                    onExpandRow: function (index, row, $detail) {
                        //$detail.hide().html(row.IdMaterial).fadeIn('slow');
                    },
                    onCollapseRow: function (index, row, $detail) {
                        $detail.clone().insertAfter($detail).fadeOut('slow', function () {
                            $(this).remove()
                        })
                    }
                });


                $("#modalDetalle").modal();

            }
            else {
                swal(data.d);

            }
        }
    });

    
}