$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("FacturasRecibidas.aspx") > -1) {

        document.body.style.zoom = "80%";

        $('#busquedarecibidos').hide();
        $('#btnAgregarRecibidas').hide();
        $('#btnFRecibidaXML').hide();
        $('#btnModificarGlobalmente').hide();

        CargarProveedoresFacturas();
        CargarProyectos();

        cargarFacturasRecibidas();
        


    }

});

var arrayfacturasrecibidasseleccionadas = '';
var arrayNoFacturasRecibidasSeleccionadas = 0;


function CargarFR() {

    $('#btnBusquedaEscrita').hide();

    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "FacturasRecibidas.aspx/CargarFacturas",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d == "No tienes permiso de acceso.") {
                swal(data.d);
                return;
            }
            if (data.d != "Error" || data.d != "-1") {
                var json = JSON.parse(data.d);

                data = json;

                $('#TablaFacturas').bootstrapTable({
                    data: data,
                    detailView: false,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'IdControlFacturas',
                    uniqueId: 'IdControlFacturas',
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
                    },
                    rowStyle: function (row, index) {

                        if (row.Estatus == 1 || row.Estatus == "1") {
                            return {
                                classes: 'estatusPagada'
                            };
                        }
                        else if (row.Estatus == 2 || row.Estatus == "2"){
                            return {
                                classes: 'estatusCancelada'
                            };
                        }
                        else {
                            return {
                                classes: 'estatus'
                            }
                        }

                    }
                });

                CargarTotalesRecibidas();
                CargarCombosFiltros(6);
                CargarCombosFiltros(7);
                CargarCombosFiltros(2);
                CargarCombosFiltros(3);
                CargarCombosFiltros(4);
                CargarCombosFiltros(5);
                CargarCombosFiltros(8);

            }
            else {
                swal(data.d);

            }
        }
    });

}

function CargarTotalesRecibidas() {
    //var params = "{'Opcion': '1'}";
    var params = "{'mes': '" + $('#cmbFechaBuscar').val() +
        "', 'idProveedor': '" + $('#cmbProveedorBuscar').val() +
        "', 'noFactura': '" + $('#cmbFacturaBuscar').val() +
        "', 'proyecto': '" + $('#cmbProyectoRecibidaBuscar').val() +
        "', 'moneda': '" + $('#cmbMonedaRecibidaBuscar').val() +
        "', 'estatus': '" + $('#cmbEstatusRecibidas').val() +
        "', 'oc': '" + $('#cmb0Recibida').val() +
        "', 'anio': '" + $('#cmbFechaAnioBuscar').val() + "'}";

    //console.log(params);
    $.ajax({
        async: true,
        url: "FacturasRecibidas.aspx/CargarResumenRecibidas",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var datos = "";

            var JsonCombos;
            var jsonArray = $.parseJSON(data.d);


            $('#TablaTotales').html('');
            $('#TablaTotales').append('<table class="table table-bordered table-hover table-striped">           '
                + '    <thead>                                                              '
                + '        <tr>                                                             '
                + '            <th colspan="6">RESUMEN</th>                                 '
                + '        </tr>                                                            '
                + '        <tr>                                                             '
                + '            <th>MONEDA</th>                                              '
                + '            <th>SUB-TOTAL</th>                                           '
                + '            <th>IVA</th>                                                 '
                + '            <th>TOTAL</th>                                               '
                + '            <th>% CON PROG PAGO</th>                                     '
                + '            <th>% SIN PROG PAGO</th>                                     '
                + '        </tr>                                                            '
                + '    </thead>                                                             '
                + '    <tbody>                                                              '
                + '        <tr>                                                             '
                + '            <th>PESOS (MXN)</th>                                         '
                + '            <td><span id="lblPesosSubTotal">$ 0.00</span></td>        '
                + '            <td><span id="lblPesosIVA">$ 0.00</span></td>             '
                + '            <td><span id="lblPesosTotal">$ 0.00</span></td>           '
                + '            <td><span id="lblPesosPorcentajeConProg">0.00 %</span></td>         '
                + '            <td><span id="lblPesosPorcentajeSinProg">0.00 %</span></td>         '
                + '        </tr>                                                            '
                + '        <tr>                                                             '
                + '            <th>DOLARES (USD)</th>                                       '
                + '            <td><span id="lblDolaresSubTotal">$ 0.00</span></td>      '
                + '            <td><span id="lblDolaresIVA">$ 0.00</span></td>           '
                + '            <td><span id="lblDolaresTotal">$ 0.00</span></td>         '
                + '            <td><span id="lblDolaresPorcentajeConProg">0.00 %</span></td>       '
                + '            <td><span id="lblDolaresPorcentajeSinProg">0.00 %</span></td>       '
                + '        </tr>                                                            '
                //+ '        <tr>                                                             '
                //+ '            <th>PROYECTOS POR INICIAR</th>                                       '
                //+ '            <td><span id="lblPISubTotal">$ 0.00</span></td>      '
                //+ '            <td><span id="lblPIIVA">$ 0.00</span></td>           '
                //+ '            <td><span id="lblPITotal">$ 0.00</span></td>         '
                //+ '        </tr>                                                            '
                //+ '        <tr>                                                             '
                //+ '            <th>PROYECTOS EN PROCESO</th>                                       '
                //+ '            <td><span id="lblPPSubTotal">$ 0.00</span></td>      '
                //+ '            <td><span id="lblPPIVA">$ 0.00</span></td>           '
                //+ '            <td><span id="lblPPTotal">$ 0.00</span></td>         '
                //+ '        </tr>                                                            '
                //+ '        <tr>                                                             '
                //+ '            <th>PROYECTOS TERMINADOS</th>                                       '
                //+ '            <td><span id="lblPTSubTotal">$ 0.00</span></td>      '
                //+ '            <td><span id="lblPTIVA">$ 0.00</span></td>           '
                //+ '            <td><span id="lblPTTotal">$ 0.00</span></td>         '
                //+ '        </tr>                                                            '
                //+ '        <tr>                                                             '
                //+ '            <th>OTROS</th>                                       '
                //+ '            <td><span id="lblOtrosSubTotal">$ 0.00</span></td>      '
                //+ '            <td><span id="lblOtrosIVA">$ 0.00</span></td>           '
                //+ '            <td><span id="lblOtrosTotal">$ 0.00</span></td>         '
                //+ '        </tr>                                                            '
                //+ '        <tr>                                                             '
                //+ '            <th>PENDIENTE</th>                                       '
                //+ '            <td><span id="lblPendienteSubTotal">$ 0.00</span></td>      '
                //+ '            <td><span id="lblPendienteIVA">$ 0.00</span></td>           '
                //+ '            <td><span id="lblPendienteTotal">$ 0.00</span></td>         '
                //+ '        </tr>                                                            '
                + '    </tbody>                                                             '
                + '   </table>  ');

            $.each(jsonArray, function (index, value) {
                if (value.Moneda == "MXN") {
                    $('#lblPesosSubTotal').text('$' + formato_numero(value.SubTotal, 2, '.', ','));
                    $('#lblPesosIVA').text('$' + formato_numero(value.IVA, 2, '.', ','));
                    $('#lblPesosTotal').text('$' + formato_numero(value.Total, 2, '.', ','));
                    $('#lblPesosPorcentajeConProg').text(formato_numero(((value.TotConProgramacion / value.Total) * 100), 2, '.', ',') + ' %');
                    $('#lblPesosPorcentajeSinProg').text(formato_numero(((value.TotSinProgramacion / value.Total) * 100), 2, '.', ',') + ' %');
                }
                else {
                    $('#lblDolaresSubTotal').text('$' + formato_numero(value.SubTotal, 2, '.', ','));
                    $('#lblDolaresIVA').text('$' + formato_numero(value.IVA, 2, '.', ','));
                    $('#lblDolaresTotal').text('$' + formato_numero(value.Total, 2, '.', ','));
                    $('#lblDolaresPorcentajeConProg').text(formato_numero(((value.TotConProgramacion / value.Total) * 100), 2, '.', ',') + ' %');
                    $('#lblDolaresPorcentajeSinProg').text(formato_numero(((value.TotSinProgramacion / value.Total) * 100), 2, '.', ',') + ' %');
                }
            });

        }
    });
}


$(document).on('click', '.agregaramodificacionglobal', function (event) {
    //;
    var _boton = $(this);
    var _item = $(this).parent().parent().find('td')[0].innerHTML;
    var _producto = $(this).parent().parent().find('td')[2].innerHTML;
    var _cantidad = $(this).parent().parent().find('td')[4].innerHTML;


});

function AgregarAModificacion(btn) {
    //debugger;
    //console.log(btn.value);
    var opcion;

    if ($(btn).hasClass("agregadaGlobal")) {
        opcion = 1;
    }
    else {
        opcion = 0;
    }

    var params = "{'IdControlFacturas': '" + btn.value + "', 'Monto': '" + $(btn).attr('rel') + "', 'Opcion': '" + opcion + "'}";

    $.ajax({
        dataType: "json",
        async: true,
        url: "FacturasRecibidas.aspx/ModificacionGlobal",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            //debugger;
            if (data.d == "Informacion actualizada." || data.d == "Informacion Guardada.") {

                if (opcion == 1) {
                    $(btn).removeClass("btn btn-success agregadaGlobal").addClass("btn btn-warning");
                    swal('Removido de modificación global.');
                }
                else {
                    $(btn).removeClass("btn btn-warning").addClass("btn btn-success agregadaGlobal");
                    swal('Agregado a modificación global.');
                }

            }
            else {
                swal("Error: " + data.d);
                return;
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            swal("Ocurrio una excepción.");
        }
    });


    //if ($(btn).hasClass("agregadaGlobal")) {
    //    console.log(arrayfacturasrecibidasseleccionadas);
    //    console.log("Boton: " + btn.value);

    //    arrayfacturasrecibidasseleccionadas.replace(btn.value, '');
    //    arrayfacturasrecibidasseleccionadas.replace("||", "");

    //    console.log(arrayfacturasrecibidasseleccionadas);
        
    //}
    //else {
    //    if (arrayfacturasrecibidasseleccionadas.length >= 1) {
    //        //var _item = $(this).parent().parent().find('td')[0].innerHTML;
    //        arrayfacturasrecibidasseleccionadas = arrayfacturasrecibidasseleccionadas + "|" + btn.value;
    //        arrayNoFacturasRecibidasSeleccionadas += parseFloat($(btn).attr('rel'));
    //        $(btn).removeClass("btn btn-warning").addClass("btn btn-success agregadaGlobal");
    //        //var $row = $(this).closest("tr");
    //        //$row.addClass('row-selected');

    //    } else {
    //        arrayfacturasrecibidasseleccionadas = "" + btn.value;
    //        arrayNoFacturasRecibidasSeleccionadas += parseFloat($(btn).attr('rel'));

    //        $(btn).removeClass("btn btn-warning").addClass("btn btn-success agregadaGlobal");
    //        //var $row = $(this).closest("tr");    
    //        //$row.addClass('row-selected');
    //    }



    //    //console.log(arrayfacturasrecibidasseleccionadas);

    //    swal('Agregado a modificación global.');
    //}

    
}

$('#btnModificarGlobalmente').click(function () {
    //console.log(arrayNoFacturasRecibidasSeleccionadas);

    //var _totFacturas = arrayNoFacturasRecibidasSeleccionadas.split(',');
    //$('#lblNoFacturas').text(formato_numero(arrayNoFacturasRecibidasSeleccionadas, 2, '.', ','));

    var params = "{'Opcion': '" + 1 + "'}";

    $.ajax({
        dataType: "json",
        async: true,
        url: "FacturasRecibidas.aspx/ObtenerTotalGlobal",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            //debugger;

            var jsonArray = $.parseJSON(data.d);


            $.each(jsonArray, function (index, value) {
                //debugger;
                $('#lblNoFacturas').text(formato_numero(value, 2, '.', ','));
            });

            $('#FormaPagoFacturasModal').modal();

            //if (data.d == "Informacion actualizada." || data.d == "Informacion Guardada.") {

            //    if (opcion == 1) {
            //        $(btn).removeClass("btn btn-success agregadaGlobal").addClass("btn btn-warning");
            //        swal('Removido de modificación global.');
            //    }
            //    else {
            //        $(btn).removeClass("btn btn-warning").addClass("btn btn-success agregadaGlobal");
            //        swal('Agregado a modificación global.');
            //    }

            //}
            //else {
            //    swal("Error: " + data.d);
            //    return;
            //}
        },
        error: function (xhr, ajaxOptions, thrownError) {
            swal("Ocurrio una excepción.");
        }
    });

    
   


});

$('#btnEstatusFormaPagoFacturas').click(function () {
    swal({
        title: "Esta seguro que desea modificar la forma de pago de las facturas seleccionadas?",
        type: "warning",
        allowOutsideClick: false,
        allowEscapeKey: false,
        allowEnterKey: false,
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si',
        cancelButtonText: 'No'
    }).then(function () {
        if ($('#txtFormaPago').val() == '-1') {
            swal("Proporciona forma de pago...");
            return;
        }

        var params = "{'Opcion': '1'}";

        $.ajax({
            dataType: "json",
            async: true,
            url: "FacturasRecibidas.aspx/ObtenerFactGlobal",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                
                var jsonArray = $.parseJSON(data.d);

                $.each(jsonArray, function (index, value) {
                    //debugger;
                    if (index == 0) {
                        arrayfacturasrecibidasseleccionadas = "" + value;
                    }
                    else {
                        arrayfacturasrecibidasseleccionadas = arrayfacturasrecibidasseleccionadas + "|" + value
                    }
                    
                    //$('#lblNoFacturas').text(formato_numero(value, 2, '.', ','));
                });

                if (arrayfacturasrecibidasseleccionadas.length == 0) {
                    swal('No hay facturas seleccionadas.');
                    return;
                }

                swal({
                    title: 'Actualizando Datos!',
                    text: 'Espere un Momento...',
                    onOpen: function () {
                        swal.showLoading()
                    }
                });

                var params = "{'array': '" + arrayfacturasrecibidasseleccionadas + "', 'FormaPago': '" + $('#txtFormaPago').val() + "'}";

                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "FacturasRecibidas.aspx/CambiarEstatusFR",
                    data: params,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data, textStatus) {
                        if (data.d == "Informacion actualizada.") {
                            arrayfacturasrecibidasseleccionadas = '';
                            arrayNoFacturasRecibidasSeleccionadas = 0;
                            $('#txtFormaPago').val("");

                            $('#TablaFacturas').bootstrapTable('destroy');

                            CargarFR();
                            swal(data.d);
                        }
                        else {
                            swal("Error: " + data.d);
                            return;
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        swal("Ocurrio una excepción.");
                    }
                });

                //debugger;
                //if (data.d == "Informacion actualizada.") {
                //    arrayfacturasrecibidasseleccionadas = '';
                //    arrayNoFacturasRecibidasSeleccionadas = 0;

                //    $('#TablaFacturas').bootstrapTable('destroy');

                //    CargarFR();
                //    swal(data.d);
                //}
                //else {
                //    swal("Error: " + data.d);
                //    return;
                //}
            },
            error: function (xhr, ajaxOptions, thrownError) {
                swal("Ocurrio una excepción.");
            }
        });


       


        


    }, function (dismiss) {
        if (dismiss === 'cancel') {
            swal(
                'Cancelado',
                'Cancelaste edicion global, intenta de nuevo recargando página y eligiendo de nuevo.',
                'error'
            );
        }
    });

});


function cargarFacturasRecibidas() {
    //$("#main-content").css("opacity", 0.2);
    //$("#loading-img").css({ "display": "block" });
    document.getElementById('TipoFactura').textContent = 'recibidas';
    //$('#btnrRecibidas').show();
    $('#busquedarecibidos').show();
    $('#btnFRecibidaXML').show();
    $('#btnModificarGlobalmente').show();
    $('#btnAgregarRecibidas').show();
    CargarFR();
    //setTimeout(function () {
    //    $("#main-content").css("opacity", 1);
    //    $("#loading-img").css({ "display": "none" });
    //}, 3000);
}

$('#btnBuscarRecibidas').click(function () {
    //$("#main-content").css("opacity", 0.2);
    //$("#loading-img").css({ "display": "block" });
    document.getElementById('TipoFactura').textContent = 'recibidas';
    $('#btnEmitidas').hide();
    /*$('#btnrRecibidas').show();*/
    $('#busquedarecibidos').show();
    $('#busquedaemitidas').hide();
    $('#btnFEmitidasXML').hide();
    $('#btnModificarGlobalmente').show();
    $('#btnAgregarEmitidas').hide();
    $('#btnAgregarRecibidas').show();
    CargarFRBusqueda();
    //setTimeout(function () {
    //    $("#main-content").css("opacity", 1);
    //    $("#loading-img").css({ "display": "none" });
    //}, 5000);
});

function CargarFRBusqueda() {

    var parametros = "{'pid':'2','FechaBuscar': '" + $('#cmbFechaBuscar').val() +
        "','ProveedorBuscar': '" + $('#cmbProveedorBuscar').val() +
        "','FacturaBuscar': '" + $('#cmbFacturaBuscar').val() +
        "','ProyectoRecibidaBuscar': '" + $('#cmbProyectoRecibidaBuscar').val() +
        "','MonedaRecibidaBuscar': '" + $('#cmbMonedaRecibidaBuscar').val() +
        "','EstatusRecibidas': '" + $('#cmbEstatusRecibidas').val() +
        "','OC': '" + $('#cmb0Recibida').val() +
        "','FechaAnioBuscar': '" + $('#cmbFechaAnioBuscar').val() +
        "','FolioOC': '" + $('#cmbOCRecibidaBuscar').val() + "'}";
    //console.log(parametros);

    $.ajax({
        dataType: "json",
        url: "FacturasRecibidas.aspx/CargarBusquedaRecibidas",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "Error" || data.d != "-1" || data.d != "No tienes permiso de acceso.") {
                var json = JSON.parse(data.d);

                $('#TablaFacturas').bootstrapTable('destroy');

                data = json;

                $('#TablaFacturas').bootstrapTable({
                    data: data,
                    detailView: false,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'IdControlFacturas',
                    uniqueId: 'IdControlFacturas',
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
                    },
                    rowStyle: function (row, index) {

                        if (row.Estatus == 1 || row.Estatus == "1") {
                            return {
                                classes: 'estatusPagada'
                            };
                        }
                        else if (row.Estatus == 2 || row.Estatus == "2") {
                            return {
                                classes: 'estatusCancelada'
                            };
                        }
                        else {
                            return {
                                classes: 'estatus'
                            }
                        }

                    }
                });


                
                CargarTotalesRecibidas();
                //CargarCombosFiltros(6);
                //CargarCombosFiltros(7);
                //CargarCombosFiltros(2);
                //CargarCombosFiltros(3);
                //CargarCombosFiltros(4);
                //CargarCombosFiltros(5);
                //$('#listaFacturas').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
            }
            else {
                swal(data.d);

            }
        }
    });

}

function CargarCombosFiltros(Opcion) {
    var params = "{'Opcion': '" + Opcion + "'}";

    $.ajax({
        async: true,
        url: "FacturasRecibidas.aspx/CargarRecibidasBuscar",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var jsonArray = $.parseJSON(data.d);

            if (Opcion == 6) {
                $('#cmbFechaBuscar').html('');

                $('#cmbFechaBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbFechaBuscar").append('<option value="' + value.a + '">' + value.a + '</option>');
                });
                $('#cmbFechaBuscar').selectpicker('refresh');
                $('#cmbFechaBuscar').selectpicker('render');
            }

            if (Opcion == 7) {
                $('#cmbFechaAnioBuscar').html('');
                $('#cmbFechaAnioBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbFechaAnioBuscar").append('<option value="' + value.a + '">' + value.a + '</option>');
                });

                $('#cmbFechaAnioBuscar').selectpicker('refresh');
                $('#cmbFechaAnioBuscar').selectpicker('render');
            }

            if (Opcion == 2) {
                $('#cmbProveedorBuscar').html('');
                $('#cmbProveedorBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbProveedorBuscar").append('<option value="' + value.a + '">' + value.b + '</option>');
                });
                $('#cmbProveedorBuscar').selectpicker('refresh');
                $('#cmbProveedorBuscar').selectpicker('render');
            }

            if (Opcion == 3) {
                $('#cmbFacturaBuscar').html('');
                $('#cmbFacturaBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbFacturaBuscar").append('<option value="' + value.a + '">' + value.a + '</option>');
                });
                $('#cmbFacturaBuscar').selectpicker('refresh');
                $('#cmbFacturaBuscar').selectpicker('render');
            }

            if (Opcion == 4) {
                $('#cmbProyectoRecibidaBuscar').html('');
                $('#cmbProyectoRecibidaBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbProyectoRecibidaBuscar").append('<option value="' + value.a + '">' + value.b + '</option>');
                });
                //$("#cmbProyectoRecibidaBuscar").append('<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER HERMOSILLO</option>');
                //$("#cmbProyectoRecibidaBuscar").append('<option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA HERMOSILLO</option>');
                //$("#cmbProyectoRecibidaBuscar").append('<option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD HERMOSILLO</option>');
                //$("#cmbProyectoRecibidaBuscar").append('<option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA HERMOSILLO</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="1621D8FD-690E-4C1E-BB94-7E0FAB7C7F56">GASTOS ADMINISTRATIVOS HERMOSILLO</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="80914600-CC95-48F6-8AC0-8667EAFBCFEC">PENDIENTE</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="83B995B4-3877-4600-A16D-5FFF9F3A84E3">ECONOLINE 2003</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="214104A8-0083-4481-8813-A754CD8FFD40">ECONOLINE 2006</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="F765BA07-20A2-4E00-A208-F06D97DF3160">FOCUS</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="8EEE37DB-F5BD-405D-9492-4919618E8C15">IKON</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="697966BC-9116-443E-A0E6-876528AABF08">RANGER</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="83A889B9-11CA-47A9-8538-B1736B773FA8">REMOLQUE</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="9F71A091-10E7-4322-A0AA-F442B45D4958">RAM</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="3A9F72BA-0011-4606-A1C6-07FB83EC4F8D">CHEYENNE</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="3BE79512-40A2-4CC6-83EF-B1C2CDBA6765">RAM 700</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="B0488C4F-1B55-4DB2-B6F4-7555E46916BF">JEEP</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="B9938D9A-DDE7-453A-B430-2D9ADF68D15F">GASOLINA HERMOSILLO</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="40F670F5-A145-4C52-AC38-6E791E3B5A19">FRONTIER</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="11313417-6F42-40B8-A933-06C452E34441">SWIFT</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="F76F2A6C-4FA1-4505-82B5-82EE5EE69497">SPARK</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="A9B875EC-1AA2-49D0-8D97-144DBFF21B56">F150</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="EF4EDE9E-BFCD-4D31-9B40-8E6B21291F21">BRONCO</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="1A713837-3DFF-4012-9F5F-7844B3DED561">TONELADA</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="F74683C3-A52D-4C2B-9B7E-25771AD50ABD">CONSUMIBLES TALLER CUAUTITLÁN</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="05AC88FC-6340-4936-B749-2F6EDA17F88A">CONSUMIBLES TALLER QUERÉTARO</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="39A9783A-0AA3-48BE-AF1C-8BDEEC4E1625">CONSUMIBLES TALLER TECATE</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="07BF808D-A646-4D63-9CD7-5161A94FC7FB">CONSUMIBLES TALLER CHIHUAHUA</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="6A50C6ED-0384-4E54-9142-B14E7338E2DC">EQUIPO DE SEGURIDAD CUAUTITLÁN</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="89AE75F8-2D98-40B1-AC47-FDD4D951881C">EQUIPO DE SEGURIDAD QUERÉTARO</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="77C10A22-E1E3-4EBB-806A-2891165EDD88">EQUIPO DE SEGURIDAD TECATE</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="BFC64785-CAD4-4247-B0AE-A64FE53B4669">EQUIPO DE SEGURIDAD CHIHUAHUA</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="BB913E5E-3200-4639-894A-628741DDB24E">INVENTARIO SISA CUAUTITLÁN</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="C8589B15-CAF9-44EB-A49C-FAE500B17EC2">INVENTARIO SISA QUERÉTARO</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="B99F1969-83AF-457B-BC6E-7544B40683EF">INVENTARIO SISA TECATE</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="734B8D0E-DEBE-46F1-9B69-5FF7334D9EB1">INVENTARIO SISA CHIHUAHUA</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="A46D00C1-0D5B-41B3-8702-0ADA1D98E175">GASTOS ADMINISTRATIVOS CUAUTITLÁN</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="C9E46130-B035-4B7E-97BA-7BED2441BBDD">GASTOS ADMINISTRATIVOS QUERÉTARO</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="9AE78058-4070-4F65-82A1-DDEB1E2F624A">GASTOS ADMINISTRATIVOS TECATE</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="7846992F-5AF1-4C5F-91C6-A91541C6E405">GASTOS ADMINISTRATIVOS CHIHUAHUA</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="79144254-9D84-486B-A0C6-A2C3D2CC6167">GASOLINA CUAUTITLÁN</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="84DF1AF7-AD10-4AD6-8F51-9CA6EF0EEC47">GASOLINA QUERÉTARO</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="178B1FE7-2E94-4F4D-951C-0A823B095505">GASOLINA TECATE</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="EE3ADE54-E730-4C9D-980E-F1A57BB53BE2">GASOLINA CHIHUAHUA</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="08369BA2-25DD-4CB4-829A-0A472997794F">PASSAT</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="4AD1CAF0-E15C-434C-8A93-794474D902D8">COLORADO</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="57F02FB0-ABFD-4907-8D69-ED9284309B80">BATANGA CHICA</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="EC17D9F8-4824-4B9C-AFA2-C89B34DE2D23">BATANGA MEDIANA</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="3601B5DB-0ACE-468D-80CD-4DE5831362D6">BATANGA GRANDE</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="0EF1486A-A756-4064-981D-A5DDFF46F9B4">HILUX</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="83099F5D-8420-45DF-BAFC-5218A79D2233">FRONTIER 2021</option>');
                //$('#cmbProyectoRecibidaBuscar').append('<option value="A0D7E7EF-DB76-4F99-BAC0-7A4995954481">L200</option>');
                $('#cmbProyectoRecibidaBuscar').selectpicker('refresh');
                $('#cmbProyectoRecibidaBuscar').selectpicker('render');
            }

            if (Opcion == 5) {
                $('#cmbMonedaRecibidaBuscar').html('');
                $('#cmbMonedaRecibidaBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbMonedaRecibidaBuscar").append('<option value="' + value.a + '">' + value.a + '</option>');
                });
                $('#cmbMonedaRecibidaBuscar').selectpicker('refresh');
                $('#cmbMonedaRecibidaBuscar').selectpicker('render');

            }

            if (Opcion == 8) {
                $('#cmbOCRecibidaBuscar').html('');
                $('#cmbOCRecibidaBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbOCRecibidaBuscar").append('<option value="' + value.a + '">' + value.a + '</option>');
                });
                $('#cmbOCRecibidaBuscar').selectpicker('refresh');
                $('#cmbOCRecibidaBuscar').selectpicker('render');

            }

        }
    });
}

$('#btnEliminadDocumentoFactura').click(function () {
    swal({
        title: 'Estas Seguro que quieres eliminar documento de factura?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Aceptar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {

        if (result) {

            var tipo = document.getElementById('txtTipoDocumentoFactura').textContent;
            var id = document.getElementById('txtidFacturaArchivo').textContent;

            var parametros = "{'pid': '" + id + "', 'Opcion':'" + tipo + "'}";
            $.ajax({
                dataType: "json",
                url: "FacturasRecibidas.aspx/EliminarDocumento",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Documento eliminado.") {
                        // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                        if (tipo == 'FE') {
                            CargarFE();
                        }
                        else {
                            CargarFR();
                        }
                        swal(msg.d);

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

$('#btnAdjuntarArchivoFR').click(function () {
    swal({
        title: 'Seleccione archivo',
        input: 'file',
        allowOutsideClick: false,
        allowEscapeKey: false,
        allowEnterKey: false,
        showCloseButton: true,
        inputAttributes: {
            'accept': 'application/pdf',
            'aria-label': 'Seleccione archivo PDF'
        }
    }).then(function (file) {
        if (file === null) {
            swal('Elige archivo.');
        }
        else {
            var nombreArchivo = file.name;
            var reader = new FileReader
            reader.onload = function (e) {

                //var params = "{'IdControlFacturas': '" + btn.value +
                //    "','NombreArchivo': '" + nombreArchivo +
                //    "','Documento': '" + e.target.result + "'}";
                $('#dataarchivopdf').val(e.target.result);
                $('#nombreaarchivopdf').val(file.name);
                $("#AddFacturasFRModal").modal();
            }
            reader.readAsDataURL(file);
        }


    });
});

function CargarProveedoresFacturas() {
    var params = "{'Opcion': '9'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'FacturasRecibidas.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbProveedoresFR').html('');
            $('#cmbProveedoresFR').html("<option value=-1>-- SELECCION PROVEEDOR --</option>");
            $('#cmbProveedoresFREditar').html('');
            $('#cmbProveedoresFREditar').html("<option value=-1>-- SELECCION PROVEEDOR --</option>");
            $.each(json, function (index, value) {
                $("#cmbProveedoresFR").append("<option value=" + value.Id + ">" + value.Nombre.toUpperCase() + "</option>");
                $("#cmbProveedoresFREditar").append("<option value=" + value.Id + ">" + value.Nombre.toUpperCase() + "</option>");
            });
            $('#cmbProveedoresFR').selectpicker('refresh');
            $('#cmbProveedoresFR').selectpicker('render');
            $('#cmbProveedoresFREditar').selectpicker('refresh');
            $('#cmbProveedoresFREditar').selectpicker('render');
        }
    });
}

//$('#btnAgregarRecibidas').click(function () {
//    CargarProyectos();
//    CargarProveedoresFacturas();
//});

function CargarProyectos() {
    var params = "{'Opcion': '10'}";

    $.ajax({
        dataType: 'json',
        async: false,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'FacturasRecibidas.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {
            //debugger;
            var json = $.parseJSON(data.d);

            $('#cmbProyectosFR').html('');
            $('#cmbProyectosFREditar').html('');
            $('#cmbProyectosFR').html('<option value="-1">-- SELECCION PROYECTO --</option>');
            //$('#cmbProyectosFR').html('<option value="N/A<">N/A<</option>');
            $('#cmbProyectosFREditar').html('<option value="-1">-- SELECCION PROYECTO --</option>');
            //$('#cmbProyectosFREditar').html('<option value="N/A">N/A</option>');



            $.each(json, function (index, value) {
                $("#cmbProyectosFR").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
                $("#cmbProyectosFREditar").append('<option value="' + value.Id.toUpperCase() + '">' + value.Nombre.toUpperCase() + '</option>');
                //$("#cmbProyectosFEEditar").append('<option value="' + value.Id.toUpperCase() + '">' + value.Nombre.toUpperCase() + '</option>');
            });

            //$('#cmbProyectosFR').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
            //$('#cmbProyectosFR').append('<option value="80914600-CC95-48F6-8AC0-8667EAFBCFEC">PENDIENTE</option>');
            //$('#cmbProyectosFR').append('<option value="83B995B4-3877-4600-A16D-5FFF9F3A84E3">ECONOLINE 2003</option>');
            //$('#cmbProyectosFR').append('<option value="214104A8-0083-4481-8813-A754CD8FFD40">ECONOLINE 2006</option>');
            //$('#cmbProyectosFR').append('<option value="F765BA07-20A2-4E00-A208-F06D97DF3160">FOCUS</option>');
            //$('#cmbProyectosFR').append('<option value="8EEE37DB-F5BD-405D-9492-4919618E8C15">IKON</option>');
            //$('#cmbProyectosFR').append('<option value="697966BC-9116-443E-A0E6-876528AABF08">RANGER</option>');
            //$('#cmbProyectosFR').append('<option value="83A889B9-11CA-47A9-8538-B1736B773FA8">REMOLQUE</option>');
            //$('#cmbProyectosFR').append('<option value="9F71A091-10E7-4322-A0AA-F442B45D4958">RAM</option>');
            //$('#cmbProyectosFR').append('<option value="3A9F72BA-0011-4606-A1C6-07FB83EC4F8D">CHEYENNE</option>');
            //$('#cmbProyectosFR').append('<option value="3BE79512-40A2-4CC6-83EF-B1C2CDBA6765">RAM 700</option>');
            //$('#cmbProyectosFR').append('<option value="B0488C4F-1B55-4DB2-B6F4-7555E46916BF">JEEP</option>');
            //$('#cmbProyectosFR').append('<option value="40F670F5-A145-4C52-AC38-6E791E3B5A19">FRONTIER</option>');
            //$('#cmbProyectosFR').append('<option value="11313417-6F42-40B8-A933-06C452E34441">SWIFT</option>');
            //$('#cmbProyectosFR').append('<option value="F76F2A6C-4FA1-4505-82B5-82EE5EE69497">SPARK</option>');
            //$('#cmbProyectosFR').append('<option value="A9B875EC-1AA2-49D0-8D97-144DBFF21B56">F150</option>');
            //$('#cmbProyectosFR').append('<option value="EF4EDE9E-BFCD-4D31-9B40-8E6B21291F21">BRONCO</option>');
            //$('#cmbProyectosFR').append('<option value="1A713837-3DFF-4012-9F5F-7844B3DED561">TONELADA</option>');
            //$('#cmbProyectosFR').append('<option value="08369BA2-25DD-4CB4-829A-0A472997794F">PASSAT</option>');
            //$('#cmbProyectosFR').append('<option value="4AD1CAF0-E15C-434C-8A93-794474D902D8">COLORADO</option>');
            //$('#cmbProyectosFR').append('<option value="57F02FB0-ABFD-4907-8D69-ED9284309B80">BATANGA CHICA</option>');
            //$('#cmbProyectosFR').append('<option value="EC17D9F8-4824-4B9C-AFA2-C89B34DE2D23">BATANGA MEDIANA</option>');
            //$('#cmbProyectosFR').append('<option value="3601B5DB-0ACE-468D-80CD-4DE5831362D6">BATANGA GRANDE</option>');
            //$('#cmbProyectosFR').append('<option value="0EF1486A-A756-4064-981D-A5DDFF46F9B4">HILUX</option>');
            //$('#cmbProyectosFR').append('<option value="83099F5D-8420-45DF-BAFC-5218A79D2233">FRONTIER 2021</option>');
            //$('#cmbProyectosFR').append('<option value="A0D7E7EF-DB76-4F99-BAC0-7A4995954481">L200</option>');

            ///* HERMOSILLO */
            //$('#cmbProyectosFR').append('<option value="7D0116F4-17E1-47A3-82C8-48E0F46110AC">VIATICOS HERMOSILLO</option>');
            //$('#cmbProyectosFR').append('<option value="B9938D9A-DDE7-453A-B430-2D9ADF68D15F">GASOLINA HERMOSILLO</option>');
            //$('#cmbProyectosFR').append('<option value="1621D8FD-690E-4C1E-BB94-7E0FAB7C7F56">GASTOS ADMINISTRATIVOS HERMOSILLO</option>');
            //$("#cmbProyectosFR").append('<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER HERMOSILLO</option>');
            //$("#cmbProyectosFR").append('<option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA HERMOSILLO</option>');
            //$("#cmbProyectosFR").append('<option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD HERMOSILLO</option>');
            //$("#cmbProyectosFR").append('<option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA HERMOSILLO</option>');

            ///* QUERETARO */
            //$('#cmbProyectosFR').append('<option value="C66E57D6-6390-4D12-8118-4B21F662C8E3">VIATICOS QUERETARO</option>');
            //$('#cmbProyectosFR').append('<option value="05AC88FC-6340-4936-B749-2F6EDA17F88A">CONSUMIBLES TALLER QUERÉTARO</option>');
            //$('#cmbProyectosFR').append('<option value="89AE75F8-2D98-40B1-AC47-FDD4D951881C">EQUIPO DE SEGURIDAD QUERÉTARO</option>');
            //$('#cmbProyectosFR').append('<option value="C8589B15-CAF9-44EB-A49C-FAE500B17EC2">INVENTARIO SISA QUERÉTARO</option>');
            //$('#cmbProyectosFR').append('<option value="C9E46130-B035-4B7E-97BA-7BED2441BBDD">GASTOS ADMINISTRATIVOS QUERÉTARO</option>');
            //$('#cmbProyectosFR').append('<option value="84DF1AF7-AD10-4AD6-8F51-9CA6EF0EEC47">GASOLINA QUERÉTARO</option>');


            ///* CHIHUAHUA */
            //$('#cmbProyectosFR').append('<option value="3A4C9E3B-7BA1-4ABE-8F32-FC1844C51AC1">VIATICOS CHIHUAHUA</option>');
            //$('#cmbProyectosFR').append('<option value="07BF808D-A646-4D63-9CD7-5161A94FC7FB">CONSUMIBLES TALLER CHIHUAHUA</option>');
            //$('#cmbProyectosFR').append('<option value="BFC64785-CAD4-4247-B0AE-A64FE53B4669">EQUIPO DE SEGURIDAD CHIHUAHUA</option>');
            //$('#cmbProyectosFR').append('<option value="734B8D0E-DEBE-46F1-9B69-5FF7334D9EB1">INVENTARIO SISA CHIHUAHUA</option>');
            //$('#cmbProyectosFR').append('<option value="7846992F-5AF1-4C5F-91C6-A91541C6E405">GASTOS ADMINISTRATIVOS CHIHUAHUA</option>');
            //$('#cmbProyectosFR').append('<option value="EE3ADE54-E730-4C9D-980E-F1A57BB53BE2">GASOLINA CHIHUAHUA</option>');


            ///* CUAUTITLAN */
            //$('#cmbProyectosFR').append('<option value="00DAC103-6BC1-419C-BEFE-9F803F9031B9">VIATICOS CUAUTITLAN</option>');
            //$('#cmbProyectosFR').append('<option value="F74683C3-A52D-4C2B-9B7E-25771AD50ABD">CONSUMIBLES TALLER CUAUTITLÁN</option>');
            //$('#cmbProyectosFR').append('<option value="6A50C6ED-0384-4E54-9142-B14E7338E2DC">EQUIPO DE SEGURIDAD CUAUTITLÁN</option>');
            //$('#cmbProyectosFR').append('<option value="BB913E5E-3200-4639-894A-628741DDB24E">INVENTARIO SISA CUAUTITLÁN</option>');
            //$('#cmbProyectosFR').append('<option value="A46D00C1-0D5B-41B3-8702-0ADA1D98E175">GASTOS ADMINISTRATIVOS CUAUTITLÁN</option>');
            //$('#cmbProyectosFR').append('<option value="79144254-9D84-486B-A0C6-A2C3D2CC6167">GASOLINA CUAUTITLÁN</option>');


            ///* TECATE */
            //$('#cmbProyectosFR').append('<option value="0EEBCB40-578B-4815-B46B-BFDA1D7DE4C1">VIATICOS TECATE</option>');
            //$('#cmbProyectosFR').append('<option value="39A9783A-0AA3-48BE-AF1C-8BDEEC4E1625">CONSUMIBLES TALLER TECATE</option>');
            //$('#cmbProyectosFR').append('<option value="77C10A22-E1E3-4EBB-806A-2891165EDD88">EQUIPO DE SEGURIDAD TECATE</option>');
            //$('#cmbProyectosFR').append('<option value="B99F1969-83AF-457B-BC6E-7544B40683EF">INVENTARIO SISA TECATE</option>');
            //$('#cmbProyectosFR').append('<option value="9AE78058-4070-4F65-82A1-DDEB1E2F624A">GASTOS ADMINISTRATIVOS TECATE</option>');
            //$('#cmbProyectosFR').append('<option value="178B1FE7-2E94-4F4D-951C-0A823B095505">GASOLINA TECATE</option>');


            ///* IRAPUATO */
            //$('#cmbProyectosFR').append('<option value="08F847C4-B48F-4951-AD73-31144BE6F86D">VIATICOS IRAPUATO</option>');
            //$('#cmbProyectosFR').append('<option value="B79F496D-5148-4369-A941-F158BF493CA1">CONSUMIBLES TALLER IRAPUATO</option>');
            //$('#cmbProyectosFR').append('<option value="0D4A2608-980D-4E1F-8203-5F6D7AA6C19F">EQUIPO DE SEGURIDAD IRAPUATO</option>');
            //$('#cmbProyectosFR').append('<option value="752B58CB-8B6F-4164-998E-087CAF4FD52F">INVENTARIO SISA IRAPUATO</option>');
            //$('#cmbProyectosFR').append('<option value="D3B9254C-A667-4E42-B478-701A34D32DC0">GASTOS ADMINISTRATIVOS IRAPUATO</option>');
            //$('#cmbProyectosFR').append('<option value="FE6D1459-F29F-47FC-844C-0D4158E80E9E">GASOLINA IRAPUATO</option>');

            ////$("#cmbProyectosFR").append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');

            //$('#cmbProyectosFREditar').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
            //$('#cmbProyectosFREditar').append('<option value="80914600-CC95-48F6-8AC0-8667EAFBCFEC">PENDIENTE</option>');
            //$('#cmbProyectosFREditar').append('<option value="83B995B4-3877-4600-A16D-5FFF9F3A84E3">ECONOLINE 2003</option>');
            //$('#cmbProyectosFREditar').append('<option value="214104A8-0083-4481-8813-A754CD8FFD40">ECONOLINE 2006</option>');
            //$('#cmbProyectosFREditar').append('<option value="F765BA07-20A2-4E00-A208-F06D97DF3160">FOCUS</option>');
            //$('#cmbProyectosFREditar').append('<option value="8EEE37DB-F5BD-405D-9492-4919618E8C15">IKON</option>');
            //$('#cmbProyectosFREditar').append('<option value="697966BC-9116-443E-A0E6-876528AABF08">RANGER</option>');
            //$('#cmbProyectosFREditar').append('<option value="83A889B9-11CA-47A9-8538-B1736B773FA8">REMOLQUE</option>');
            //$('#cmbProyectosFREditar').append('<option value="9F71A091-10E7-4322-A0AA-F442B45D4958">RAM</option>');
            //$('#cmbProyectosFREditar').append('<option value="3A9F72BA-0011-4606-A1C6-07FB83EC4F8D">CHEYENNE</option>');
            //$('#cmbProyectosFREditar').append('<option value="3BE79512-40A2-4CC6-83EF-B1C2CDBA6765">RAM 700</option>');
            //$('#cmbProyectosFREditar').append('<option value="B0488C4F-1B55-4DB2-B6F4-7555E46916BF">JEEP</option>');
            //$('#cmbProyectosFREditar').append('<option value="40F670F5-A145-4C52-AC38-6E791E3B5A19">FRONTIER</option>');
            //$('#cmbProyectosFREditar').append('<option value="11313417-6F42-40B8-A933-06C452E34441">SWIFT</option>');
            //$('#cmbProyectosFREditar').append('<option value="F76F2A6C-4FA1-4505-82B5-82EE5EE69497">SPARK</option>');
            //$('#cmbProyectosFREditar').append('<option value="A9B875EC-1AA2-49D0-8D97-144DBFF21B56">F150</option>');
            //$('#cmbProyectosFREditar').append('<option value="EF4EDE9E-BFCD-4D31-9B40-8E6B21291F21">BRONCO</option>');
            //$('#cmbProyectosFREditar').append('<option value="1A713837-3DFF-4012-9F5F-7844B3DED561">TONELADA</option>');
            //$('#cmbProyectosFREditar').append('<option value="08369BA2-25DD-4CB4-829A-0A472997794F">PASSAT</option>');
            //$('#cmbProyectosFREditar').append('<option value="4AD1CAF0-E15C-434C-8A93-794474D902D8">COLORADO</option>');
            //$('#cmbProyectosFREditar').append('<option value="57F02FB0-ABFD-4907-8D69-ED9284309B80">BATANGA CHICA</option>');
            //$('#cmbProyectosFREditar').append('<option value="EC17D9F8-4824-4B9C-AFA2-C89B34DE2D23">BATANGA MEDIANA</option>');
            //$('#cmbProyectosFREditar').append('<option value="3601B5DB-0ACE-468D-80CD-4DE5831362D6">BATANGA GRANDE</option>');
            //$('#cmbProyectosFREditar').append('<option value="0EF1486A-A756-4064-981D-A5DDFF46F9B4">HILUX</option>');
            //$('#cmbProyectosFREditar').append('<option value="83099F5D-8420-45DF-BAFC-5218A79D2233">FRONTIER 2021</option>');
            //$('#cmbProyectosFREditar').append('<option value="A0D7E7EF-DB76-4F99-BAC0-7A4995954481">L200</option>');

            ///* HERMOSILLO */
            //$('#cmbProyectosFREditar').append('<option value="7D0116F4-17E1-47A3-82C8-48E0F46110AC">VIATICOS HERMOSILLO</option>');
            //$('#cmbProyectosFREditar').append('<option value="B9938D9A-DDE7-453A-B430-2D9ADF68D15F">GASOLINA HERMOSILLO</option>');
            //$('#cmbProyectosFREditar').append('<option value="1621D8FD-690E-4C1E-BB94-7E0FAB7C7F56">GASTOS ADMINISTRATIVOS HERMOSILLO</option>');
            //$("#cmbProyectosFREditar").append('<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER HERMOSILLO</option>');
            //$("#cmbProyectosFREditar").append('<option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA HERMOSILLO</option>');
            //$("#cmbProyectosFREditar").append('<option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD HERMOSILLO</option>');
            //$("#cmbProyectosFREditar").append('<option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA HERMOSILLO</option>');

            ///* QUERETARO */
            //$('#cmbProyectosFREditar').append('<option value="C66E57D6-6390-4D12-8118-4B21F662C8E3">VIATICOS QUERETARO</option>');
            //$('#cmbProyectosFREditar').append('<option value="05AC88FC-6340-4936-B749-2F6EDA17F88A">CONSUMIBLES TALLER QUERÉTARO</option>');
            //$('#cmbProyectosFREditar').append('<option value="89AE75F8-2D98-40B1-AC47-FDD4D951881C">EQUIPO DE SEGURIDAD QUERÉTARO</option>');
            //$('#cmbProyectosFREditar').append('<option value="C8589B15-CAF9-44EB-A49C-FAE500B17EC2">INVENTARIO SISA QUERÉTARO</option>');
            //$('#cmbProyectosFREditar').append('<option value="C9E46130-B035-4B7E-97BA-7BED2441BBDD">GASTOS ADMINISTRATIVOS QUERÉTARO</option>');
            //$('#cmbProyectosFREditar').append('<option value="84DF1AF7-AD10-4AD6-8F51-9CA6EF0EEC47">GASOLINA QUERÉTARO</option>');


            ///* CHIHUAHUA */
            //$('#cmbProyectosFREditar').append('<option value="3A4C9E3B-7BA1-4ABE-8F32-FC1844C51AC1">VIATICOS CHIHUAHUA</option>');
            //$('#cmbProyectosFREditar').append('<option value="07BF808D-A646-4D63-9CD7-5161A94FC7FB">CONSUMIBLES TALLER CHIHUAHUA</option>');
            //$('#cmbProyectosFREditar').append('<option value="BFC64785-CAD4-4247-B0AE-A64FE53B4669">EQUIPO DE SEGURIDAD CHIHUAHUA</option>');
            //$('#cmbProyectosFREditar').append('<option value="734B8D0E-DEBE-46F1-9B69-5FF7334D9EB1">INVENTARIO SISA CHIHUAHUA</option>');
            //$('#cmbProyectosFREditar').append('<option value="7846992F-5AF1-4C5F-91C6-A91541C6E405">GASTOS ADMINISTRATIVOS CHIHUAHUA</option>');
            //$('#cmbProyectosFREditar').append('<option value="EE3ADE54-E730-4C9D-980E-F1A57BB53BE2">GASOLINA CHIHUAHUA</option>');


            ///* CUAUTITLAN */
            //$('#cmbProyectosFREditar').append('<option value="00DAC103-6BC1-419C-BEFE-9F803F9031B9">VIATICOS CUAUTITLAN</option>');
            //$('#cmbProyectosFREditar').append('<option value="F74683C3-A52D-4C2B-9B7E-25771AD50ABD">CONSUMIBLES TALLER CUAUTITLÁN</option>');
            //$('#cmbProyectosFREditar').append('<option value="6A50C6ED-0384-4E54-9142-B14E7338E2DC">EQUIPO DE SEGURIDAD CUAUTITLÁN</option>');
            //$('#cmbProyectosFREditar').append('<option value="BB913E5E-3200-4639-894A-628741DDB24E">INVENTARIO SISA CUAUTITLÁN</option>');
            //$('#cmbProyectosFREditar').append('<option value="A46D00C1-0D5B-41B3-8702-0ADA1D98E175">GASTOS ADMINISTRATIVOS CUAUTITLÁN</option>');
            //$('#cmbProyectosFREditar').append('<option value="79144254-9D84-486B-A0C6-A2C3D2CC6167">GASOLINA CUAUTITLÁN</option>');


            ///* TECATE */
            //$('#cmbProyectosFREditar').append('<option value="0EEBCB40-578B-4815-B46B-BFDA1D7DE4C1">VIATICOS TECATE</option>');
            //$('#cmbProyectosFREditar').append('<option value="39A9783A-0AA3-48BE-AF1C-8BDEEC4E1625">CONSUMIBLES TALLER TECATE</option>');
            //$('#cmbProyectosFREditar').append('<option value="77C10A22-E1E3-4EBB-806A-2891165EDD88">EQUIPO DE SEGURIDAD TECATE</option>');
            //$('#cmbProyectosFREditar').append('<option value="B99F1969-83AF-457B-BC6E-7544B40683EF">INVENTARIO SISA TECATE</option>');
            //$('#cmbProyectosFREditar').append('<option value="9AE78058-4070-4F65-82A1-DDEB1E2F624A">GASTOS ADMINISTRATIVOS TECATE</option>');
            //$('#cmbProyectosFREditar').append('<option value="178B1FE7-2E94-4F4D-951C-0A823B095505">GASOLINA TECATE</option>');


            ///* IRAPUATO */
            //$('#cmbProyectosFREditar').append('<option value="08F847C4-B48F-4951-AD73-31144BE6F86D">VIATICOS IRAPUATO</option>');
            //$('#cmbProyectosFREditar').append('<option value="B79F496D-5148-4369-A941-F158BF493CA1">CONSUMIBLES TALLER IRAPUATO</option>');
            //$('#cmbProyectosFREditar').append('<option value="0D4A2608-980D-4E1F-8203-5F6D7AA6C19F">EQUIPO DE SEGURIDAD IRAPUATO</option>');
            //$('#cmbProyectosFREditar').append('<option value="752B58CB-8B6F-4164-998E-087CAF4FD52F">INVENTARIO SISA IRAPUATO</option>');
            //$('#cmbProyectosFREditar').append('<option value="D3B9254C-A667-4E42-B478-701A34D32DC0">GASTOS ADMINISTRATIVOS IRAPUATO</option>');
            //$('#cmbProyectosFREditar').append('<option value="FE6D1459-F29F-47FC-844C-0D4158E80E9E">GASOLINA IRAPUATO</option>');

            //$("#cmbProyectosFREditar").append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
            
            $('#cmbProyectosFR').selectpicker('refresh');
            $('#cmbProyectosFR').selectpicker('render');
            //$('#cmbProyectosFREditar').selectpicker('refresh');
            //$('#cmbProyectosFREditar').selectpicker('render');

            cargarFacturasRecibidas();
        }
    });
}

function CargarOrdenCompra(id) {
    var params = "{'pid': '" + id + "'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'FacturasRecibidas.aspx/CargarOC',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbOCFR').html('');
            $('#cmbOCFR').append('<option value="-1">-- SELECCION ORDEN COMPRA --</option>');
            $('#cmbOCFR').append('<option value="N/A" name="MATERIAL">N/A</option>');
            $('#cmbOCFR').append('<option value="PENDIENTE" name="MATERIAL">PENDIENTE</option>');
            var tipo = "MATERIAL";
            $.each(json, function (index, value) {
                if (value.TipoOC == 'Material') {
                    tipo = "MATERIAL";
                } else if (value.TipoOC == 'Equipo') {
                    tipo = "EQUIPO";
                } else if (value.TipoOC == 'ManoObra') {
                    tipo = "MANOOBRA";
                }
                else {
                    tipo = "MATERIAL";
                }
                $("#cmbOCFR").append('<option value="' + value.Folio + '" name="' + tipo + '">' + value.Folio.toUpperCase() + '</option>');
            });
            $('#cmbOCFR').selectpicker('refresh');
            $('#cmbOCFR').selectpicker('render');
        }
    });
}

$("#cmbOCFR").change(function () {

    var folio = $(this).val();
    var tipooc = $('#cmbOCFR option:selected').attr('name');
    $('#cmbCategoriaFactura').val(tipooc);
    VerProyecto(folio);
});

function VerProyecto(folio) {
    var params = "{'pid': '" + folio + "'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'FacturasRecibidas.aspx/BuscarProyecto',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);
            $.each(json, function (index, value) {
                var idProyecto = value.IdProyecto;
                $('#cmbProyectosFR').val(idProyecto);
                $('#cmbProyectosFR').selectpicker('refresh');
            });

        }
    });
}

$("#cmbOCFREditar").change(function () {

    var folio = $(this).val();
    var tipooc = $('#cmbOCFREditar option:selected').attr('name');
    //debugger;
    $('#cmbCategoriaFacturaEditar').val(tipooc);
    $('#cmbCategoriaFacturaEditar').selectpicker('refresh');
    VerProyectoEdicion(folio);
});

function VerProyectoEdicion(folio) {
    var params = "{'pid': '" + folio + "'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'FacturasRecibidas.aspx/BuscarProyecto',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);
            $.each(json, function (index, value) {
                var idProyecto = value.IdProyecto.toUpperCase();
                $('#cmbProyectosFREditar').val(idProyecto);
                $('#cmbProyectosFREditar').selectpicker('refresh');
            });

        }
    });
}

function CargarOrdenCompraEditar(id) {
    var params = "{'pid': '" + id + "'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'FacturasRecibidas.aspx/CargarOC',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbOCFREditar').html('');
            $('#cmbOCFREditar').append('<option value="-1">-- SELECCION ORDEN COMPRA --</option>');
            $('#cmbOCFREditar').append('<option value="N/A" name="MATERIAL">N/A</option>');
            $('#cmbOCFREditar').append('<option value="PENDIENTE" name="MATERIAL">PENDIENTE</option>');
            $.each(json, function (index, value) {
                $("#cmbOCFREditar").append('<option value="' + value.Folio + '" name="' + value.TipoOC + '">' + value.Folio.toUpperCase() + '</option>');
            });
            $('#cmbOCFREditar').selectpicker('refresh');
            $('#cmbOCFREditar').selectpicker('render');

            if (oc == "N/A") {
                $('#cmbOCFREditar').val("N/A");
                $('#cmbOCFREditar').selectpicker('refresh');
            }
            else {
                $('#cmbOCFREditar').val(oc);
                $('#cmbOCFREditar').selectpicker('refresh');
            }

        }
    });
}

$("#cmbProveedoresFREditar").change(function () {

    var idProveedor = $(this).val();

    CargarOrdenCompraEditar(idProveedor);
});

$("#cmbProveedoresFR").change(function () {

    var idProveedor = $(this).val();

    CargarOrdenCompra(idProveedor);
});

$('#chkViaticos').change(function () {
    if (this.checked) {
        document.getElementById('txtTextoViaticos').textContent = 'SI';
    } else {
        document.getElementById('txtTextoViaticos').textContent = 'NO';
    }
});

$('#chkViaticosEditar').change(function () {
    if (this.checked) {
        document.getElementById('txtTextoViaticosEditar').textContent = 'SI';
    } else {
        document.getElementById('txtTextoViaticosEditar').textContent = 'NO';
    }
});

$('#chkEnviadaEditar').change(function () {
    if (this.checked) {
        document.getElementById('txtTextoEnviadaEditar').textContent = 'SI';
    } else {
        document.getElementById('txtTextoEnviadaEditar').textContent = 'NO';
    }
});

$('#btnGuardarFacturasRecibidas').click(function () {
    var viaticos = 0;

    if ($('#cmbOCFR').val() == '-1') {
        swal('Elige dato de orden de compra.');
        return;
    }
    if ($('#txtTextoViaticos').text() == 'SI') {
        viaticos = 1;
    }
    var parametros = "{'IdControlFactura': '" + 0 +
        "','IdProveedor': '" + $('#cmbProveedoresFR').val() +
        "','OrdenCompra': '" + $('#cmbOCFR').val() +
        "','IdProyecto': '" + $("#cmbProyectosFR").val().toUpperCase() +
        "','FechaFactura': '" + $('#dtFechaFR').val() +
        "','NoFactura': '" + $('#txtFolioFacturaR').val() +
        "','Moneda': '" + $('#txtMonedaFR').val() +
        "','SubTotal': '" + $("#txtSubtotalFR").val().replace(",", "") +
        "','Descuento': '" + $('#txtDescuentoFR').val().replace(",", "") +
        "','Iva': '" + $('#txtIvaFR').val().replace(",", "") +
        "','Total': '" + $("#txtTotalFR").val().replace(",", "") +
        "','Estatus': '" + $('#cmbEstatusFR').val() +
        "','FormaPago': '" + $('#txtFormaPagoFR').val() +
        "','Viaticos': '" + viaticos +
        "','Categoria': '" + $('#cmbCategoriaFactura').val() +
        "','Anticipo': '" + $('#txtAnticipoFR').val() +
        "','NotaCredito': '" + $('#txtNotaCreditoFR').val() +
        "','Proyecto': '" + $("#cmbProyectosFR option:selected").text() +
        "','nombrearchivo': '" + $('#nombreaarchivopdf').val() +
        "','dataarchivo': '" + $('#dataarchivopdf').val() +
        "'}";
    
    $.ajax({
        dataType: "json",
        url: "FacturasRecibidas.aspx/GuardarFacturaFR",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Factura agregada.") {
                // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');

                swal(msg.d);
                //CargarFR();
                $('#cmbProveedoresFR').val('-1');
                $('#cmbProveedoresFR').selectpicker('refresh');
                $('#cmbOCFR').val('-1');
                $('#cmbOCFR').selectpicker('refresh');
                $('#cmbProyectosFR').val('-1');
                $('#cmbProyectosFR').selectpicker('refresh');
                $('#txtFolioFacturaR').val('');
                $('#dtFechaFR').val('');
                $('#txtMonedaFR').val('');
                $('#txtSubtotalFR').val('');
                $('#txtDescuentoFR').val('0');
                $('#txtIvaFR').val('');
                $('#txtTotalFR').val('');
                $('#cmbEstatusFR').val('0');
                $('#cmbCategoriaFactura').val('MATERIAL');
                $('#txtAnticipoFR').val('0');
                $('#txtNotaCreditoFR').val('0');
                $('#txtFormaPagoFR').val('');
                $('#nombreaarchivopdf').val('');
                $('#dataarchivopdf').val('');
                CargarCombosFiltros(1);
                CargarCombosFiltros(3);
            }
            else {
                //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
});

$('#btnEditarFacturasRecibidas').click(function () {
    var viaticos = 0;
    if ($('#cmbOCFREditar').val() == '-1') {
        swal('Elige dato de orden de compra.');
        return;
    }
    if ($('#txtTextoViaticos').text() == 'SI') {
        viaticos = 1;
    }
    var parametros = "{'IdControlFactura': '" + document.getElementById('idFREditar').textContent +
        "','IdProveedor': '" + $('#cmbProveedoresFREditar').val() +
        "','OrdenCompra': '" + $('#cmbOCFREditar').val() +
        "','IdProyecto': '" + $("#cmbProyectosFREditar").val() +
        "','FechaFactura': '" + $('#dtFechaFREditar').val() +
        "','NoFactura': '" + $('#txtFolioFacturaREditar').val() +
        "','Moneda': '" + $('#txtMonedaFREditar').val() +
        "','SubTotal': '" + $("#txtSubtotalFREditar").val().replace(",", "") +
        "','Descuento': '" + $('#txtDescuentoFREditar').val().replace(",", "") +
        "','Iva': '" + $('#txtIvaFREditar').val().replace(",", "") +
        "','Total': '" + $("#txtTotalFREditar").val().replace(",", "") +
        "','Estatus': '" + $('#cmbEstatusFREditar').val() +
        "','FormaPago': '" + $('#txtFormaPagoFREditar').val() +
        "','Viaticos': '" + viaticos +
        "','Categoria': '" + $('#cmbCategoriaFacturaEditar').val() +
        "','Anticipo': '" + $('#txtAnticipoFREditar').val() +
        "','NotaCredito': '" + $('#txtNotaCreditoFREditar').val() +
        "','Proyecto': '" + $("#cmbProyectosFREditar option:selected").text() +
        "','nombrearchivo': '" + $('#nombreaarchivopdf').val() +
        "','dataarchivo': '" + $('#dataarchivopdf').val() +
        "'}";

    $.ajax({
        dataType: "json",
        url: "FacturasRecibidas.aspx/GuardarFacturaFR",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Factura agregada.") {
                // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                //CargarFR();
                swal('Factura actualizada.');

            }
            else {
                //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
});

$('#btnFRecibidaXML').click(function () {
    swal({
        title: 'Seleccione archivo',
        input: 'file',
        allowOutsideClick: false,
        allowEscapeKey: false,
        allowEnterKey: false,
        showCloseButton: true,
        inputAttributes: {
            'accept': 'text/xml'
        }
    }).then(function (file) {
        if (file === null) {
            swal('No haz seleccionado archivo.');

        }
        var nombreArchivo = file.name;
        var reader = new FileReader
        reader.onload = function (e) {

            var params = "{'NombreArchivo': '" + nombreArchivo +
                "','Archivo': '" + e.target.result + "'}";

            $.ajax({
                dataType: "json",
                async: true,
                url: "FacturasRecibidas.aspx/GuardarRecibidaXml",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {
                    //location.href = './frmProjects.aspx';
                    if (data.d == 'Factura recibida, agregada.') {
                        swal({
                            title: 'Se adjunto correctamente el archivo, recuerda elegir el proveedor correcto.',
                            timer: 3000
                        });

                        $('#TablaFacturas').bootstrapTable('destroy');

                        CargarFR();
                    }
                    else {
                        swal({
                            title: data.d,
                            timer: 3000
                        });
                    }

                },
                error: function (xhr, ajaxOptions, thrownError) {
                    swal({
                        title: 'Error, intenta de nuevo',
                        timer: 3000
                    });
                }
            });


        }

        reader.readAsDataURL(file);

    });
});

$('#btnEliminarFacturas').click(function () {
    var id = document.getElementById('idFacturasEliminar').textContent;
    var tipo = document.getElementById('idFacturasEliminarTipo').textContent;

    var parametros = "{'pid': '" + id + "', 'Opcion':'" + tipo + "'}";
    $.ajax({
        dataType: "json",
        url: "FacturasRecibidas.aspx/EliminarFacturas",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Documento eliminado.") {
                // $("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                if (tipo == 'FR') {

                    $('#TablaFacturas').bootstrapTable('destroy');

                    CargarFR();
                }
                else {
                    CargarFE()
                }
                swal(msg.d);
            }
            else {
                //$("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
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

$("#txtSubtotalFR").on('input', function (e) {

    var Subtotal = $(this).val();
    var IVA = Subtotal * .16;
    var Total = Subtotal * 1.16;
    $("#txtIvaFR").val(formato_numero(IVA, 2, '.', ','));
    $("#txtTotalFR").val(formato_numero(Total, 2, '.', ','));

    //$("#txtSubtotalFR").val(formato_numero(Subtotal, 2, '.', ','));
});

$("#txtSubtotalFE").on('input', function (e) {

    var Subtotal = $(this).val();
    var IVA = Subtotal * .16;
    var Total = Subtotal * 1.16;
    $("#txtIvaFE").val(formato_numero(IVA, 2, '.', ','));
    $("#txtTotalFE").val(formato_numero(Total, 2, '.', ','));
    $("#txtPorPagarFE").val(formato_numero(Total, 2, '.', ','));

    //$("#txtSubtotalFR").val(formato_numero(Subtotal, 2, '.', ','));
});

$("#txtRetencionFE").on('input', function (e) {
    var retencion = $(this).val();
    var Subtotal = $('#txtSubtotalFE').val();
    var IVA = Subtotal * .16;
    var Total = (Subtotal * 1.16) - retencion;
    $("#txtIvaFE").val(formato_numero(IVA, 2, '.', ','));
    $("#txtTotalFE").val(formato_numero(Total, 2, '.', ','));
    $("#txtPorPagarFE").val(formato_numero(Total, 2, '.', ','));

    //$("#txtSubtotalFR").val(formato_numero(Subtotal, 2, '.', ','));
});


function DescuentoFocus() {
    var Descuento = $("#txtDescuentoFR").val();
    var Subtotal = $("#txtSubtotalFR").val() - Descuento;
    $("#txtSubtotalFR").val(formato_numero(Subtotal, 2, '.', ','));
    var IVA = Subtotal * .16;
    var Total = Subtotal * 1.16;
    $("#txtIvaFR").val(formato_numero(IVA, 2, '.', ','));
    $("#txtTotalFR").val(formato_numero(Total, 2, '.', ','));
}

function DescuentoFocusEditar() {
    var Descuento = $("#txtDescuentoFREditar").val();
    var Subtotal = $("#txtSubtotalFREditar").val();
    $("#txtSubtotalFREditar").val(formato_numero(Subtotal.replace(',', '') - Descuento.replace(',', ''), 2, '.', ','));
    var IVA = (Subtotal.replace(',', '') - Descuento.replace(',', '')) * .16;
    var Total = (Subtotal.replace(',', '') - Descuento.replace(',', '')) * 1.16;
    $("#txtIvaFREditar").val(formato_numero(IVA, 2, '.', ','));
    $("#txtTotalFREditar").val(formato_numero(Total, 2, '.', ','));
}
//$("#txtDescuentoFR").on('input', function (e) {

//    var Descuento = $(this).val();
//    var Subtotal = $("#txtSubtotalFR").val() - Descuento;
//    $("#txtSubtotalFR").val(formato_numero(Subtotal, 2, '.', ','));
//    var IVA = Subtotal * .16;
//    var Total = Subtotal * 1.16;
//    $("#txtIvaFR").val(formato_numero(IVA, 2, '.', ','));
//    $("#txtTotalFR").val(formato_numero(Total, 2, '.', ','));
//    //$("#txtTotalFR").val(formato_numero(Total, 2, '.', ','));

//    //$("#txtSubtotalFR").val(formato_numero(Subtotal, 2, '.', ','));
//});

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


function EliminarFR(btn) {
    document.getElementById('idFacturasEliminar').textContent = '';
    document.getElementById('idFacturasEliminarTipo').textContent = '';
    document.getElementById('idFacturasEliminarTexto').textContent = '¿Estás seguro de eliminar factura recibida con código "' + btn.value + '"?';
    document.getElementById('idFacturasEliminar').textContent = btn.value;
    document.getElementById('idFacturasEliminarTipo').textContent = 'FR';
    $("#DelFacturasModal").modal();
}

var oc = '';
var Proyecto = '';

function EditarFR(btn) {
    
    var id = btn.value;

    document.getElementById('idFREditar').textContent = '';
    document.getElementById('idFREditar').textContent = id;
    var params = "{'pid': '" + btn.value + "'}";
    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'FacturasRecibidas.aspx/CargarFacturasRecibida',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);
            $(json).each(function (index, value) {
                //value.Id
                //$('#cmbProyectosFREditar').val(value.IdProyecto);




                $('#cmbProveedoresFREditar').val(value.IdProveedor);
                $('#cmbProveedoresFREditar').selectpicker('refresh');
                $('#cmbProveedoresFREditar').trigger('change');
                $('#txtFolioFacturaREditar').val(value.NoFactura);
                $('#txtSubtotalFREditar').val(formato_numero(value.SubTotal, 2, '.', ','));
                $('#txtIvaFREditar').val(formato_numero(value.IVA, 2, '.', ','));
                $('#cmbEstatusFREditar').val(value.Estatus);
                if (value.Viaticos == "1") {
                    $('#txtTextoViaticosEditar').text() = 'SI';
                    document.getElementById("chkViaticosEditar").checked = true;
                }
                oc = value.OrdenCompra;
                Proyecto = value.IdProyecto.toUpperCase();
                if (Proyecto == 'N/A') {
                    $('#cmbProyectosFREditar').val('B2C9AA16-C340-47A1-8744-5CA73C388F92');
                    $('#cmbProyectosFREditar').selectpicker('refresh');
                }
                else {
                    $('#cmbProyectosFREditar').selectpicker('refresh');
                    $('#cmbProyectosFREditar').val(Proyecto);
                    $('#cmbProyectosFREditar').selectpicker('refresh');
                }
                $('#dtFechaFREditar').val(value.FechaFactura.substring(0, 10));
                $('#txtMonedaFREditar').val(value.Moneda);
                $('#txtDescuentoFREditar').val(formato_numero(value.Descuento, 2, '.', ','));
                $('#txtTotalFREditar').val(formato_numero(value.Total, 2, '.', ','));
                $('#txtFormaPagoFREditar').val(value.FormaPago);

                $('#cmbCategoriaFacturaEditar').val(value.Categoria);
                $('#txtAnticipoFREditar').val(formato_numero(value.Anticipo, 2, '.', ','));
                $('#txtNotaCreditoFREditar').val(formato_numero(value.NotaCredito, 2, '.', ','));


            });

        }
    });
    //if (oc == "N/A") {
    //    $('#cmbOCFREditar').val("N/A");
    //}
    //else {
    //    $('#cmbOCFREditar').val(oc);
    //}
    //$('#cmbOCFREditar').selectpicker('refresh');

    $("#AddFacturasFRModalEditar").modal();
}

function AgregarFR(btn) {
    swal({
        title: 'Seleccione archivo',
        input: 'file',
        allowOutsideClick: false,
        allowEscapeKey: false,
        allowEnterKey: false,
        showCloseButton: true,
        inputAttributes: {
            'accept': 'application/pdf',
            'aria-label': 'Seleccione archivo PDF'
        }
    }).then(function (file) {
        if (file === null) {
            swal('Elige archivo.');
        }
        else {
            var nombreArchivo = file.name;
            var reader = new FileReader
            reader.onload = function (e) {
                //debugger;
                //console.log(nombreArchivo);

                //var params = "{'IdCotizacion': '" + idCotizacion +
                //    "','NombreArchivo': '" + nombreArchivo +
                //    "','Documento': '" + e.target.result + "'}";

                var params = "{'IdControlFacturas': '" + btn.value +
                    "','NombreArchivo': '" + nombreArchivo +
                    "','Documento': '" + e.target.result + "'}";

                //console.log(params);

                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "FacturasRecibidas.aspx/GuardarArchivos",
                    data: params,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data, textStatus) {
                        //location.href = './frmProjects.aspx';
                        if (data.d == 'Factura actualizada.') {

                            $('#TablaFacturas').bootstrapTable('destroy');

                            CargarFR();
                            swal('Se adjuntaron correctamente los archivos');
                        }
                        else {
                            swal('Ocurrio un error, intenta de nuevo.');
                        }
                        //location.reload();

                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        swal('Ocurrio un error, intenta de nuevo.');
                    }
                });


            }

            reader.readAsDataURL(file);
        }


    });
}

function VisualizarDocumentoFR(btn) {
    $('#testmodalpdffe').html('');

    var params = "{'IdControlFacturas': '" + btn.value +
        "','Opcion': '" + "FR" + "'}";

    $.ajax({
        async: true,
        url: "FacturasRecibidas.aspx/CargarDocumentos",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            var datos = "";

            var JsonCombos;
            var jsonArray = $.parseJSON(data.d);


            $.each(jsonArray, function (index, value) {
                document.getElementById('txtTipoDocumentoFactura').textContent = "FR";

                document.getElementById('txtidFacturaArchivo').textContent = value.IdControlFacturas;
                $('#testmodalpdffe').append('<object id="visorPDF" data="' + value.ArchivoFactura + '" type="application/pdf" style="width:100%; height: 800px;"></object>');
            });
        }
    });
    $("#dvPDFFacturas").modal();
}


function formatoMonedaFormatter(value) {
    return formato_numero(value, 2, ".", ",");
}

function estatusFormatter(value) {
    var icono;
    //debugger;
    if (value == "1") {
        icono = '<span>PAGADA</span>';
    }
    else if (value == "2") {
        icono = '<span>CANCELADA</span>';
    }
    else {
        icono = '<span>PENDIENTE</span>';
    }
    return icono;//'<i class="glyphicon glyphicon-ok"></i> ' + value;
}

window.accionEvents = {
    'click .enviarOC': function (e, value, row, index) {

        var idOrdenCompra = row.IdOrdenCompra;

        window.open('../Administracion/EnviarCorreo.aspx?id=' + idOrdenCompra + '&Tipo=1');

        //

        //window.open("./frmReporteOrdenCompra.aspx?IdOrdenCompra=" + idOrdenCompra + "&NombreOrden=" + row.Folio, '_blank');
    },
    'click .verPDF': function (e, value, row, index) {
        var idOrdenCompra = row.IdOrdenCompra;
        var folio = row.Folio;

        window.open("ReporteOrdenCompra.aspx?IdOrdenCompra=" + idOrdenCompra + "&NombreOrden=" + folio);
    },
    'click .comentarios': function (e, value, row, index) {
        var idOrdenCompra = row.IdOrdenCompra;

        document.getElementById('idOCComentario').textContent = idOrdenCompra;
        var params = "{'IdOrdenCompra': '" + idOrdenCompra + "'}";
        $.ajax({
            async: true,
            url: "OrdenCompra.aspx/CargarComentarios",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var datos = "";
                var nodoTRAgregar = "";

                var JsonCombos;
                var jsonArray = $.parseJSON(data.d);

                $('#TablaPrincipalComentarios tbody').html('');
                $.each(jsonArray, function (index, value) {
                    nodoTRAgregar += "<tr>";
                    nodoTRAgregar += "  <td>" + value.ID + "</td>";
                    nodoTRAgregar += "  <td>" + value.Comentario + "</td>";
                    nodoTRAgregar += "  <td>" + value.NombreCompleto + "</td>";
                    nodoTRAgregar += "  <td>" + value.Fecha + "</td>";
                    nodoTRAgregar += "</tr>";
                });

                $('#TablaPrincipalComentarios tbody').append(nodoTRAgregar);
            }
        });
        $("#dvComentarios").modal();
    }
};

function accionFormatter(value, row, index) {
    //    if (json[index].NombreArchivo == '' || json[index].NombreArchivo === null) {
    //        botonFile = '<Button title="Agregar archivo" class="btn btn-danger" value="' + json[index].IdControlFacturas + '" onclick="AgregarFR(this);"><i class="icon_document"></i></Button>';
    //    }
    //    else {
    //        botonFile = '<Button title="Ver archivo" class="btn btn-default" value="' + json[index].IdControlFacturas + '" onclick="VisualizarDocumentoFR(this);"><i class="icon_document"></i></Button>';
    //    }
    var botonFile = '';
    var botonModificacion = '';
    
    if (row.NombreArchivo == '' || row.NombreArchivo === null) {
        botonFile = '<Button title="Agregar archivo" class="btn btn-danger" value="' + row.IdControlFacturas + '" onclick="AgregarFR(this);"><i class="icon_document"></i></Button>';
    }
    else {
        botonFile = '<Button title="Ver archivo" class="btn btn-default" value="' + row.IdControlFacturas + '" onclick="VisualizarDocumentoFR(this);"><i class="icon_document"></i></Button>';
    }

    if (row.ModificacionGlobal == '' || row.ModificacionGlobal === null ) {
        botonModificacion = '<Button title="Agregar a modificación global" onclick="AgregarAModificacion(this);" class= "btn btn-warning" value="' + row.IdControlFacturas + '" rel="' + row.APagar + '"> <i class="icon_globe-2"></i></Button>';
    }
    else {
        botonModificacion = '<Button title="Quitar de modificación global" onclick="AgregarAModificacion(this);" class= "btn btn-success agregadaGlobal" value="' + row.IdControlFacturas + '" rel="' + row.APagar + '"> <i class="icon_globe-2"></i></Button>';
    }
    //debugger;
    return [
        '<div class="btn-group">',
        botonModificacion,
        '<Button title="Editar" class= "btn btn-info" value="' + row.IdControlFacturas + '" onclick="EditarFR(this);"> <i class="icon_pencil"></i></Button>',
        botonFile,
        '<Button title="Eliminar" class="btn btn-danger" value="' + row.IdControlFacturas + '" onclick="EliminarFR(this);"> <i class="icon_minus-06"></i></Button>',
        '</div>'
    ].join(' ');
}