$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("FacturasEmitidas.aspx") > -1) {

        document.body.style.zoom = "80%";

        $('#btnEmitidas').hide();
        //$('#btnrRecibidas').hide();
        $('#busquedaemitidas').hide();
        $('#btnAgregarEmitidas').hide();
        $('#btnFEmitidasXML').hide();

        cargarFacturasEmitidas();
        cuantosPagosMultiples();

        //CargarProveedoresFacturas();
        CargarProyectos();



    }

});

var arrayfacturasrecibidasseleccionadas = '';
var arrayNoFacturasRecibidasSeleccionadas = 0;

function CargarFE() {

    var parametros = "{'pid': '2'}";
    $.ajax({ 
        dataType: "json",
        url: "FacturasEmitidas.aspx/CargarFacturas",
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
                    idField: 'IdFacturasEmitidas',
                    uniqueId: 'IdFacturasEmitidas',
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

                        if (row.Enviada == 0 || row.Enviada == "0") {
                            return {
                                classes: 'estatusNoEnviada'
                            };
                        }
                        else if (row.Estatus == 1 || row.Estatus == "1") {
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
                            };
                            //if (row.Enviada == 0 || row.Enviada == "0") {
                            //    return {
                            //        classes: 'estatusNoEnviada'
                            //    };
                            //}
                            //else {
                                
                            //}
                            
                        }

                    }
                });
                //debugger;
                CargarTotalesEmitidas();
                CargarCombosFiltrosEmitidas(12);
                CargarCombosFiltrosEmitidas(13);
                //CargarCombosFiltrosEmitidas(26);
                CargarCombosFiltrosEmitidas(7);

                cargarCombosProyectos(26);
                
                //$('#listaFacturas').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
            }
            else {


            }
        }
    });
}


function CargarTotalesEmitidas() {
    //var params = "{'Opcion': '1'}";
    var params = "{'anio': '" + $('#cmbAnioBuscar').val() + "', 'cliente': '" + $('#cmbClienteBuscar').val() + "', 'proyecto': '" + $('#cmbProyectoEmitidaBuscar').val() + "', 'moneda': '" + $('#cmbMonedaEmitidaBuscar').val() + "', 'estatus': '" + $('#cmbEstatusEmitidas').val() + "'}";
    //console.log(params);
    $.ajax({
        async: true,
        url: "FacturasEmitidas.aspx/CargarFacturasEmitidas",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            //debugger;
            var jsonArray = $.parseJSON(data.d);


            $('#TablaTotales').html('');
            $('#TablaTotales').append('<table class= "table table-bordered table-hover table-striped" >      '
                + '         <thead>                                                                        '
                + '             <tr>                                                                       '
                + '                 <th colspan="7">RESUMEN</th>                                           '
                + '             </tr>                                                                      '
                + '             <tr>                                                                       '
                + '                 <th>MONEDA</th>                                                        '
                + '                 <th>SUB-TOTAL</th>                                                     '
                + '                 <th>IVA</th>                                                           '
                + '                 <th>TOTAL</th>                                                         '
                + '                 <th>POR PAGAR</th>                                                     '
                + '                 <th>% CON PROG PAGO</th>                                               '
                + '                 <th>% SIN PROG PAGO</th>                                               '
                + '             </tr>                                                                      '
                + '         </thead>                                                                       '
                + '         <tbody>                                                                        '
                + '              <tr>                                                                      '
                + '                 <th>PESOS (MXN)</th>                                                   '
                + '                 <td><span id="lblPesosSubTotal">$ 0.00</span></td>                  '
                + '                 <td><span id="lblPesosIVA">$ 0.00</span></td>                       '
                + '                 <td><span id="lblPesosTotal">$ 0.00</span></td>                     '
                + '                 <td><span id="lblPesosPorPagar">$ 0.00</span></td>                  '
                + '                 <td><span id="lblPesosPorcentajeConProg">0.00 %</span></td>         '
                + '                 <td><span id="lblPesosPorcentajeSinProg">0.00 %</span></td>         '
                + '             </tr>                                                                      '
                + '             <tr>                                                                       '
                + '                 <th>DOLARES (USD)</th>                                                 '
                + '                 <td><span id="lblDolaresSubTotal">$ 0.00</span></td>                '
                + '                 <td><span id="lblDolaresIVA">$ 0.00</span></td>                     '
                + '                 <td><span id="lblDolaresTotal">$ 0.00</span></td>                   '
                + '                 <td><span id="lblDolaresPorPagar">$ 0.00</span></td>                '
                + '                 <td><span id="lblDolaresPorcentajeConProg">0.00 %</span></td>       '
                + '                 <td><span id="lblDolaresPorcentajeSinProg">0.00 %</span></td>       '
                + '             </tr>                                                                      '
                + '             <tr>                                                                       '
                + '                 <th>TOTALES</th>                                                       '
                + '                 <th><span id="lblSubTotal">$ 0.00</span></th>                       '
                + '                 <th><span id="lblIVA">$ 0.00</span></th>                            '
                + '                 <th><span id="lblTotal">$ 0.00</span></th>                          '
                + '                 <th><span id="lblPorPagar">$ 0.00</span></th>                       '
                + '                 <th><span id="lblPorcentajeConProg">0.00 %</span></th>              '
                + '                 <th><span id="lblPorcentajeSinProg">0.00 %</span></th>              '
                + '             </tr>                                                                      '
                + '         </tbody>                                                                       '
                + '                                                                                        '
                + '     </table >                                                                          ');
            $.each(jsonArray, function (index, value) {


                if (value.Moneda == "MXN") {
                    $('#lblPesosSubTotal').text(formato_numero(value.SubTotal, 2, '.', ','));
                    $('#lblPesosIVA').text(formato_numero(value.IVA, 2, '.', ','));
                    $('#lblPesosTotal').text(formato_numero(value.Total, 2, '.', ','));
                    $('#lblPesosPorPagar').text(formato_numero(value.PorPagar, 2, '.', ','));
                    $('#lblPesosPorcentajeConProg').text(formato_numero(((value.TotalConProgPago / value.PorPagar) * 100), 2, '.', ',') + ' %');
                    $('#lblPesosPorcentajeSinProg').text(formato_numero(((value.TotalSinProgPago / value.PorPagar) * 100), 2, '.', ',') + ' %');
                }
                else if (value.Moneda == "USD") {
                    $('#lblDolaresSubTotal').text(formato_numero(value.SubTotal, 2, '.', ','));
                    $('#lblDolaresIVA').text(formato_numero(value.IVA, 2, '.', ','));
                    $('#lblDolaresTotal').text(formato_numero(value.Total, 2, '.', ','));
                    $('#lblDolaresPorPagar').text(formato_numero(value.PorPagar, 2, '.', ','));
                    $('#lblDolaresPorcentajeConProg').text(formato_numero(((value.TotalConProgPago / value.PorPagar) * 100), 2, '.', ',') + ' %');
                    $('#lblDolaresPorcentajeSinProg').text(formato_numero(((value.TotalSinProgPago / value.PorPagar) * 100), 2, '.', ',') + ' %');
                }
                else {
                    $('#lblSubTotal').text(formato_numero(value.SubTotal, 2, '.', ','));
                    $('#lblIVA').text(formato_numero(value.IVA, 2, '.', ','));
                    $('#lblTotal').text(formato_numero(value.Total, 2, '.', ','));
                    $('#lblPorPagar').text(formato_numero(value.PorPagar, 2, '.', ','));
                    $('#lblPorcentajeConProg').text(formato_numero(((value.TotalConProgPago / value.PorPagar) * 100), 2, '.', ',') + ' %');
                    $('#lblPorcentajeSinProg').text(formato_numero(((value.TotalSinProgPago / value.PorPagar) * 100), 2, '.', ',') + ' %');
                }
            });

        }
    });
}

function cargarFacturasEmitidas() {
    //$("#main-content").css("opacity", 0.2);
    //$("#loading-img").css({ "display": "block" });
    document.getElementById('TipoFactura').textContent = 'emitidas';
    $('#btnEmitidas').show();
    //$('#btnrRecibidas').hide();
    
    $('#busquedaemitidas').show();
    
    $('#btnAgregarEmitidas').show();
    $('#btnFEmitidasXML').show();

    CargarFE();
    //setTimeout(function () {
    //    $("#main-content").css("opacity", 1);
    //    $("#loading-img").css({ "display": "none" });
    //}, 3000);
}



$('#btnBuscarEmitidas').click(function () {
    //$("#main-content").css("opacity", 0.2);
    //$("#loading-img").css({ "display": "block" });
    document.getElementById('TipoFactura').textContent = 'emitidas';
    $('#btnEmitidas').show();
    //$('#btnrRecibidas').hide();
    $('#busquedarecibidos').hide();
    $('#busquedaemitidas').show();
    $('#btnAgregarRecibidas').hide();
    $('#btnAgregarEmitidas').show();
    $('#btnFEmitidasXML').show();
    $('#btnFRecibidaXML').hide();
    $('#btnModificarGlobalmente').hide();
    CargarFEBusqueda();
    CargarTotalesEmitidas();
    //setTimeout(function () {
    //    $("#main-content").css("opacity", 1);
    //    $("#loading-img").css({ "display": "none" });
    //}, 5000);
});

function CargarFEBusqueda() {



    var parametros = "{'pid':'2','AnioBuscar': '" + $('#cmbAnioBuscar').val() +
        "','ClienteBuscar': '" + $('#cmbClienteBuscar').val() +
        "','ProyectoEmitidaBuscar': '" + $('#cmbProyectoEmitidaBuscar').val() +
        "','MonedaEmitidaBuscar': '" + $('#cmbMonedaEmitidaBuscar').val() +
        "','EstatusEmitidas': '" + $('#cmbEstatusEmitidas').val() +
        "','Enviada': '" + $('#cmbEnviadaEmitidas').val() + "'}";

    $.ajax({
        dataType: "json",
        url: "FacturasEmitidas.aspx/CargarBusquedaEmitidas",
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

                $('#TablaFacturas').bootstrapTable('destroy');

                data = json;

                $('#TablaFacturas').bootstrapTable({
                    data: data,
                    detailView: false,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'IdFacturasEmitidas',
                    uniqueId: 'IdFacturasEmitidas',
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

                        if (row.Enviada == 0 || row.Enviada == "0") {
                            return {
                                classes: 'estatusNoEnviada'
                            };
                        }
                        else if (row.Estatus == 1 || row.Estatus == "1") {
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
                            };
                            //if (row.Enviada == 0 || row.Enviada == "0") {
                            //    return {
                            //        classes: 'estatusNoEnviada'
                            //    };
                            //}
                            //else {

                            //}

                        }

                    }
                });

                //$(json).each(function (index, item) {

                //    var trstyle = '';
                //    var Estatus = item.Estatus;

                //    if (Estatus == "1") {
                //        Estatus = "PAGADA";
                //        trstyle = 'style="background-color: #90ee90;"';
                //    } else if (Estatus == "2") {
                //        Estatus = "CANCELADA";
                //        trstyle = 'style="background-color: #ffa084;"';
                //    } else {
                //        Estatus = "PENDIENTE";
                //        trstyle = 'style="background-color: white;"';
                //    }

                //    var botonFile = '';
                //    if (item.NombreArchivo == '' || item.NombreArchivo === null) {
                //        botonFile = '<Button title="Agregar archivo" class="btn btn-danger" value="' + item.IdFacturasEmitidas + '" onclick="AgregarFE(this);"><i class="icon_document"></i></Button>';

                //    }
                //    else {
                //        botonFile = '<Button title="Ver archivo" class="btn btn-default" value="' + item.IdFacturasEmitidas + '" onclick="VisualizarDocumentoFE(this);"><i class="icon_document"></i></Button>';
                //    }

                //    var iconoEnviado = '<i class="icon_close" style="color: red; font-size: 20px;"></i>';

                //    if (item.Enviada == "1") {
                //        iconoEnviado = '<i class="icon_check" style="color: green; font-size: 20px;"></i>';
                //    }
                //    else {
                //        trstyle = 'style="background-color: #ffff9e;"';
                //    }

                //    $('tbody#listaFacturas').append(
                //        '<tr ' + trstyle + '><td style="display:none;">'
                //        + item.IdFacturasEmitidas
                //        + '</td>'
                //        + '<td>'
                //        + item.FolioFactura
                //        + '</td>'
                //        + '<td>'
                //        + item.FechaFactura.substring(0, 10)
                //        + '</td><td>'
                //        + item.RfcReceptor
                //        + '</td><td>'
                //        + item.NombreReceptor
                //        + '</td>'
                //        + '<td>'
                //        + item.NombreProyecto
                //        + '</td>'
                //        + '<td>'
                //        + item.NoCotizacion
                //        + '</td>'
                //        + '<td>'
                //        + item.OrdenCompraRecibida
                //        + '</td>'
                //        + '<td>'
                //        + formato_numero(item.SubTotal, 2, '.', ',')
                //        + '</td>'
                //        + '<td>'
                //        + formato_numero(item.Iva, 2, '.', ',')
                //        + '</td>'
                //        + '<td>'
                //        + formato_numero(item.Retencion, 2, '.', ',')
                //        + '</td>'
                //        + '<td>'
                //        + formato_numero(item.Total, 2, '.', ',')
                //        + '</td>'
                //        + '<td>'
                //        + item.Moneda
                //        + '</td>'
                //        + '<td>'
                //        + item.ProgramacionPago1
                //        + '</td>'
                //        + '<td>'
                //        + formato_numero(item.PorPagar, 2, '.', ',')
                //        + '</td>'
                //        + '<td>'
                //        + item.FechaPago1
                //        + '</td>'
                //        + '<td>'
                //        + Estatus
                //        + '</td>'
                //        + '<td style="text-align: center;">'
                //        + iconoEnviado
                //        + '</td>'
                //        + '<td>'
                //        + item.CorreoEnviado
                //        + '</td>'
                //        + '<td>'
                //        + '<div class="btn-group">'
                //        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                //        + '<Button title="Editar" class="btn btn-info" value="' + item.IdFacturasEmitidas + '" onclick="EditarFE(this);"> <i class="icon_pencil"></i></Button>'
                //        + botonFile
                //        + '<Button title="Eliminar" class="btn btn-danger" value="' + item.IdFacturasEmitidas + '" onclick="EliminarFE(this);"> <i class="icon_minus-06"></i></Button>'
                //        + '</div > '
                //        + '</td>'
                //        + '</tr>')
                //});
                CargarTotalesEmitidas();
                //CargarCombosFiltrosEmitidas(12);
                //CargarCombosFiltrosEmitidas(13);
                //CargarCombosFiltrosEmitidas(10);
                //CargarCombosFiltrosEmitidas(7);

                //$('#listaFacturas').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
            }
            else {


            }
        }
    });
}

function CargarCombosFiltrosEmitidas(Opcion) {
    var params = "{'Opcion': '" + Opcion + "'}";

    $.ajax({
        async: true,
        url: "FacturasEmitidas.aspx/CargarEmitidasBuscar",
        //url: "FacturasEmitidas.aspx/CargarCombos",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var jsonArray = $.parseJSON(data.d);
            //debugger;
            if (Opcion == 12) {
                $('#cmbAnioBuscar').html('');
                $('#cmbAnioBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbAnioBuscar").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                });
                $('#cmbAnioBuscar').selectpicker('refresh');
                $('#cmbAnioBuscar').selectpicker('render');
            }

            if (Opcion == 13) {
                $('#cmbClienteBuscar').html('');
                $('#cmbClienteBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbClienteBuscar").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                });
                $('#cmbClienteBuscar').selectpicker('refresh');
                $('#cmbClienteBuscar').selectpicker('render');
            }

            if (Opcion == 7) {
                $('#cmbMonedaEmitidaBuscar').html('');
                $('#cmbMonedaEmitidaBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbMonedaEmitidaBuscar").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                });
                $('#cmbMonedaEmitidaBuscar').selectpicker('refresh');
                $('#cmbMonedaEmitidaBuscar').selectpicker('render');

            }

            if (Opcion == 26) {
                $('#cmbProyectoEmitidaBuscar').html('');
                $('#cmbProyectoEmitidaBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbProyectoEmitidaBuscar").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                });
                //$("#cmbProyectoEmitidaBuscar").append('<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER HERMOSILLO</option>');
                //$("#cmbProyectoEmitidaBuscar").append('<option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA HERMOSILLO</option>');
                //$("#cmbProyectoEmitidaBuscar").append('<option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD HERMOSILLO</option>');
                //$("#cmbProyectoEmitidaBuscar").append('<option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA HERMOSILLO</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="1621D8FD-690E-4C1E-BB94-7E0FAB7C7F56">GASTOS ADMINISTRATIVOS HERMOSILLO</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="80914600-CC95-48F6-8AC0-8667EAFBCFEC">PENDIENTE</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="83B995B4-3877-4600-A16D-5FFF9F3A84E3">ECONOLINE 2003</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="214104A8-0083-4481-8813-A754CD8FFD40">ECONOLINE 2006</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="F765BA07-20A2-4E00-A208-F06D97DF3160">FOCUS</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="8EEE37DB-F5BD-405D-9492-4919618E8C15">IKON</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="697966BC-9116-443E-A0E6-876528AABF08">RANGER</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="83A889B9-11CA-47A9-8538-B1736B773FA8">REMOLQUE</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="9F71A091-10E7-4322-A0AA-F442B45D4958">RAM</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="3A9F72BA-0011-4606-A1C6-07FB83EC4F8D">CHEYENNE</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="3BE79512-40A2-4CC6-83EF-B1C2CDBA6765">RAM 700</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="B0488C4F-1B55-4DB2-B6F4-7555E46916BF">JEEP</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="B9938D9A-DDE7-453A-B430-2D9ADF68D15F">GASOLINA HERMOSILLO</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="40F670F5-A145-4C52-AC38-6E791E3B5A19">FRONTIER</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="11313417-6F42-40B8-A933-06C452E34441">SWIFT</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="F76F2A6C-4FA1-4505-82B5-82EE5EE69497">SPARK</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="A9B875EC-1AA2-49D0-8D97-144DBFF21B56">F150</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="EF4EDE9E-BFCD-4D31-9B40-8E6B21291F21">BRONCO</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="1A713837-3DFF-4012-9F5F-7844B3DED561">TONELADA</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="F74683C3-A52D-4C2B-9B7E-25771AD50ABD">CONSUMIBLES TALLER CUAUTITLÁN</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="05AC88FC-6340-4936-B749-2F6EDA17F88A">CONSUMIBLES TALLER QUERÉTARO</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="39A9783A-0AA3-48BE-AF1C-8BDEEC4E1625">CONSUMIBLES TALLER TECATE</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="07BF808D-A646-4D63-9CD7-5161A94FC7FB">CONSUMIBLES TALLER CHIHUAHUA</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="6A50C6ED-0384-4E54-9142-B14E7338E2DC">EQUIPO DE SEGURIDAD CUAUTITLÁN</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="89AE75F8-2D98-40B1-AC47-FDD4D951881C">EQUIPO DE SEGURIDAD QUERÉTARO</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="77C10A22-E1E3-4EBB-806A-2891165EDD88">EQUIPO DE SEGURIDAD TECATE</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="BFC64785-CAD4-4247-B0AE-A64FE53B4669">EQUIPO DE SEGURIDAD CHIHUAHUA</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="BB913E5E-3200-4639-894A-628741DDB24E">INVENTARIO SISA CUAUTITLÁN</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="C8589B15-CAF9-44EB-A49C-FAE500B17EC2">INVENTARIO SISA QUERÉTARO</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="B99F1969-83AF-457B-BC6E-7544B40683EF">INVENTARIO SISA TECATE</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="734B8D0E-DEBE-46F1-9B69-5FF7334D9EB1">INVENTARIO SISA CHIHUAHUA</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="A46D00C1-0D5B-41B3-8702-0ADA1D98E175">GASTOS ADMINISTRATIVOS CUAUTITLÁN</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="C9E46130-B035-4B7E-97BA-7BED2441BBDD">GASTOS ADMINISTRATIVOS QUERÉTARO</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="9AE78058-4070-4F65-82A1-DDEB1E2F624A">GASTOS ADMINISTRATIVOS TECATE</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="7846992F-5AF1-4C5F-91C6-A91541C6E405">GASTOS ADMINISTRATIVOS CHIHUAHUA</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="79144254-9D84-486B-A0C6-A2C3D2CC6167">GASOLINA CUAUTITLÁN</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="84DF1AF7-AD10-4AD6-8F51-9CA6EF0EEC47">GASOLINA QUERÉTARO</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="178B1FE7-2E94-4F4D-951C-0A823B095505">GASOLINA TECATE</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="EE3ADE54-E730-4C9D-980E-F1A57BB53BE2">GASOLINA CHIHUAHUA</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="08369BA2-25DD-4CB4-829A-0A472997794F">PASSAT</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="4AD1CAF0-E15C-434C-8A93-794474D902D8">COLORADO</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="57F02FB0-ABFD-4907-8D69-ED9284309B80">BATANGA CHICA</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="EC17D9F8-4824-4B9C-AFA2-C89B34DE2D23">BATANGA MEDIANA</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="3601B5DB-0ACE-468D-80CD-4DE5831362D6">BATANGA GRANDE</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="0EF1486A-A756-4064-981D-A5DDFF46F9B4">HILUX</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="83099F5D-8420-45DF-BAFC-5218A79D2233">FRONTIER 2021</option>');
                //$('#cmbProyectoEmitidaBuscar').append('<option value="A0D7E7EF-DB76-4F99-BAC0-7A4995954481">L200</option>');
                $('#cmbProyectoEmitidaBuscar').selectpicker('refresh');
                $('#cmbProyectoEmitidaBuscar').selectpicker('render');
            }



        }
    });
}

function cargarCombosProyectos(Opcion) {
    var params = "{'Opcion': '" + Opcion + "'}";

    $.ajax({
        async: true,
        url: "FacturasEmitidas.aspx/CargarCombos",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var jsonArray = $.parseJSON(data.d);
            //debugger;

            if (Opcion == 26) {
                $('#cmbProyectoEmitidaBuscar').html('');
                $('#cmbProyectoEmitidaBuscar').html('<option value="-1">--Selecciona--</option>');
                $.each(jsonArray, function (index, value) {
                    $("#cmbProyectoEmitidaBuscar").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                });
                $('#cmbProyectoEmitidaBuscar').selectpicker('refresh');
                $('#cmbProyectoEmitidaBuscar').selectpicker('render');
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
                url: "FacturasEmitidas.aspx/EliminarDocumento",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Documento eliminado.") {
                        // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                        if (tipo == 'FE') {
                            $('#TablaFacturas').bootstrapTable('destroy');

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


function CargarProyectos() {
    var params = "{'Opcion': '21'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'FacturasEmitidas.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {
            //debugger;
            var json = $.parseJSON(data.d);


            $('#cmbProyectosFEEditar').html('');
            $('#cmbProyectosFEEditar').html('<option value="-1">-- SELECCION PROYECTO --</option>');
            //$('#cmbProyectosFEEditar').html('<option value="N/A">N/A</option>');
            $('#cmbProyectosFE').html('');
            $('#cmbProyectosFE').html('<option value="-1">-- SELECCION PROYECTO --</option>');
            //$('#cmbProyectosFE').html('<option value="N/A">N/A</option>');
          
            $.each(json, function (index, value) {
                $("#cmbProyectosFEEditar").append('<option value="' + value.Id.toUpperCase() + '">' + value.Nombre.toUpperCase() + '</option>');
                $("#cmbProyectosFE").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
            });

            
            //$("#cmbProyectosFREditar").append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
            //$("#cmbProyectosFEEditar").append('<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER HERMOSILLO</option>');
            //$("#cmbProyectosFEEditar").append('<option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA HERMOSILLO</option>');
            //$("#cmbProyectosFEEditar").append('<option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD HERMOSILLO</option>');
            //$("#cmbProyectosFEEditar").append('<option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA HERMOSILLO</option>');
            //$('#cmbProyectosFEEditar').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
            //$('#cmbProyectosFEEditar').append('<option value="1621D8FD-690E-4C1E-BB94-7E0FAB7C7F56">GASTOS ADMINISTRATIVOS HERMOSILLO</option>');
            //$('#cmbProyectosFEEditar').append('<option value="80914600-CC95-48F6-8AC0-8667EAFBCFEC">PENDIENTE</option>');
            //$('#cmbProyectosFEEditar').append('<option value="83B995B4-3877-4600-A16D-5FFF9F3A84E3">ECONOLINE 2003</option>');
            //$('#cmbProyectosFEEditar').append('<option value="214104A8-0083-4481-8813-A754CD8FFD40">ECONOLINE 2006</option>');
            //$('#cmbProyectosFEEditar').append('<option value="F765BA07-20A2-4E00-A208-F06D97DF3160">FOCUS</option>');
            //$('#cmbProyectosFEEditar').append('<option value="8EEE37DB-F5BD-405D-9492-4919618E8C15">IKON</option>');
            //$('#cmbProyectosFEEditar').append('<option value="697966BC-9116-443E-A0E6-876528AABF08">RANGER</option>');
            //$('#cmbProyectosFEEditar').append('<option value="83A889B9-11CA-47A9-8538-B1736B773FA8">REMOLQUE</option>');
            //$('#cmbProyectosFEEditar').append('<option value="9F71A091-10E7-4322-A0AA-F442B45D4958">RAM</option>');
            //$('#cmbProyectosFEEditar').append('<option value="3A9F72BA-0011-4606-A1C6-07FB83EC4F8D">CHEYENNE</option>');
            //$('#cmbProyectosFEEditar').append('<option value="3BE79512-40A2-4CC6-83EF-B1C2CDBA6765">RAM 700</option>');
            //$('#cmbProyectosFEEditar').append('<option value="B0488C4F-1B55-4DB2-B6F4-7555E46916BF">JEEP</option>');
            //$('#cmbProyectosFEEditar').append('<option value="B9938D9A-DDE7-453A-B430-2D9ADF68D15F">GASOLINA HERMOSILLO</option>');
            //$('#cmbProyectosFEEditar').append('<option value="40F670F5-A145-4C52-AC38-6E791E3B5A19">FRONTIER</option>');
            //$('#cmbProyectosFEEditar').append('<option value="11313417-6F42-40B8-A933-06C452E34441">SWIFT</option>');
            //$('#cmbProyectosFEEditar').append('<option value="F76F2A6C-4FA1-4505-82B5-82EE5EE69497">SPARK</option>');
            //$('#cmbProyectosFEEditar').append('<option value="A9B875EC-1AA2-49D0-8D97-144DBFF21B56">F150</option>');
            //$('#cmbProyectosFEEditar').append('<option value="EF4EDE9E-BFCD-4D31-9B40-8E6B21291F21">BRONCO</option>');
            //$('#cmbProyectosFEEditar').append('<option value="1A713837-3DFF-4012-9F5F-7844B3DED561">TONELADA</option>');
            //$('#cmbProyectosFEEditar').append('<option value="F74683C3-A52D-4C2B-9B7E-25771AD50ABD">CONSUMIBLES TALLER CUAUTITLÁN</option>');
            //$('#cmbProyectosFEEditar').append('<option value="05AC88FC-6340-4936-B749-2F6EDA17F88A">CONSUMIBLES TALLER QUERÉTARO</option>');
            //$('#cmbProyectosFEEditar').append('<option value="39A9783A-0AA3-48BE-AF1C-8BDEEC4E1625">CONSUMIBLES TALLER TECATE</option>');
            //$('#cmbProyectosFEEditar').append('<option value="07BF808D-A646-4D63-9CD7-5161A94FC7FB">CONSUMIBLES TALLER CHIHUAHUA</option>');
            //$('#cmbProyectosFEEditar').append('<option value="6A50C6ED-0384-4E54-9142-B14E7338E2DC">EQUIPO DE SEGURIDAD CUAUTITLÁN</option>');
            //$('#cmbProyectosFEEditar').append('<option value="89AE75F8-2D98-40B1-AC47-FDD4D951881C">EQUIPO DE SEGURIDAD QUERÉTARO</option>');
            //$('#cmbProyectosFEEditar').append('<option value="77C10A22-E1E3-4EBB-806A-2891165EDD88">EQUIPO DE SEGURIDAD TECATE</option>');
            //$('#cmbProyectosFEEditar').append('<option value="BFC64785-CAD4-4247-B0AE-A64FE53B4669">EQUIPO DE SEGURIDAD CHIHUAHUA</option>');
            //$('#cmbProyectosFEEditar').append('<option value="BB913E5E-3200-4639-894A-628741DDB24E">INVENTARIO SISA CUAUTITLÁN</option>');
            //$('#cmbProyectosFEEditar').append('<option value="C8589B15-CAF9-44EB-A49C-FAE500B17EC2">INVENTARIO SISA QUERÉTARO</option>');
            //$('#cmbProyectosFEEditar').append('<option value="B99F1969-83AF-457B-BC6E-7544B40683EF">INVENTARIO SISA TECATE</option>');
            //$('#cmbProyectosFEEditar').append('<option value="734B8D0E-DEBE-46F1-9B69-5FF7334D9EB1">INVENTARIO SISA CHIHUAHUA</option>');
            //$('#cmbProyectosFEEditar').append('<option value="A46D00C1-0D5B-41B3-8702-0ADA1D98E175">GASTOS ADMINISTRATIVOS CUAUTITLÁN</option>');
            //$('#cmbProyectosFEEditar').append('<option value="C9E46130-B035-4B7E-97BA-7BED2441BBDD">GASTOS ADMINISTRATIVOS QUERÉTARO</option>');
            //$('#cmbProyectosFEEditar').append('<option value="9AE78058-4070-4F65-82A1-DDEB1E2F624A">GASTOS ADMINISTRATIVOS TECATE</option>');
            //$('#cmbProyectosFEEditar').append('<option value="7846992F-5AF1-4C5F-91C6-A91541C6E405">GASTOS ADMINISTRATIVOS CHIHUAHUA</option>');
            //$('#cmbProyectosFEEditar').append('<option value="79144254-9D84-486B-A0C6-A2C3D2CC6167">GASOLINA CUAUTITLÁN</option>');
            //$('#cmbProyectosFEEditar').append('<option value="84DF1AF7-AD10-4AD6-8F51-9CA6EF0EEC47">GASOLINA QUERÉTARO</option>');
            //$('#cmbProyectosFEEditar').append('<option value="178B1FE7-2E94-4F4D-951C-0A823B095505">GASOLINA TECATE</option>');
            //$('#cmbProyectosFEEditar').append('<option value="EE3ADE54-E730-4C9D-980E-F1A57BB53BE2">GASOLINA CHIHUAHUA</option>');
            //$('#cmbProyectosFEEditar').append('<option value="08369BA2-25DD-4CB4-829A-0A472997794F">PASSAT</option>');
            //$('#cmbProyectosFEEditar').append('<option value="4AD1CAF0-E15C-434C-8A93-794474D902D8">COLORADO</option>');
            //$('#cmbProyectosFEEditar').append('<option value="57F02FB0-ABFD-4907-8D69-ED9284309B80">BATANGA CHICA</option>');
            //$('#cmbProyectosFEEditar').append('<option value="EC17D9F8-4824-4B9C-AFA2-C89B34DE2D23">BATANGA MEDIANA</option>');
            //$('#cmbProyectosFEEditar').append('<option value="3601B5DB-0ACE-468D-80CD-4DE5831362D6">BATANGA GRANDE</option>');
            //$('#cmbProyectosFEEditar').append('<option value="0EF1486A-A756-4064-981D-A5DDFF46F9B4">HILUX</option>');
            //$('#cmbProyectosFEEditar').append('<option value="83099F5D-8420-45DF-BAFC-5218A79D2233">FRONTIER 2021</option>');
            //$('#cmbProyectosFEEditar').append('<option value="A0D7E7EF-DB76-4F99-BAC0-7A4995954481">L200</option>');
            ////$("#cmbProyectosFEEditar").append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
            //$("#cmbProyectosFE").append('<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER HERMOSILLO</option>');
            //$("#cmbProyectosFE").append('<option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA HERMOSILLO</option>');
            //$("#cmbProyectosFE").append('<option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD HERMOSILLO</option>');
            //$("#cmbProyectosFE").append('<option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA HERMOSILLO</option>');
            //$('#cmbProyectosFE').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
            //$('#cmbProyectosFE').append('<option value="1621D8FD-690E-4C1E-BB94-7E0FAB7C7F56">GASTOS ADMINISTRATIVOS HERMOSILLO</option>');
            //$('#cmbProyectosFE').append('<option value="80914600-CC95-48F6-8AC0-8667EAFBCFEC">PENDIENTE</option>');
            //$('#cmbProyectosFE').append('<option value="83B995B4-3877-4600-A16D-5FFF9F3A84E3">ECONOLINE 2003</option>');
            //$('#cmbProyectosFE').append('<option value="214104A8-0083-4481-8813-A754CD8FFD40">ECONOLINE 2006</option>');
            //$('#cmbProyectosFE').append('<option value="F765BA07-20A2-4E00-A208-F06D97DF3160">FOCUS</option>');
            //$('#cmbProyectosFE').append('<option value="8EEE37DB-F5BD-405D-9492-4919618E8C15">IKON</option>');
            //$('#cmbProyectosFE').append('<option value="697966BC-9116-443E-A0E6-876528AABF08">RANGER</option>');
            //$('#cmbProyectosFE').append('<option value="83A889B9-11CA-47A9-8538-B1736B773FA8">REMOLQUE</option>');
            //$('#cmbProyectosFE').append('<option value="9F71A091-10E7-4322-A0AA-F442B45D4958">RAM</option>');
            //$('#cmbProyectosFE').append('<option value="3A9F72BA-0011-4606-A1C6-07FB83EC4F8D">CHEYENNE</option>');
            //$('#cmbProyectosFE').append('<option value="3BE79512-40A2-4CC6-83EF-B1C2CDBA6765">RAM 700</option>');
            //$('#cmbProyectosFE').append('<option value="B0488C4F-1B55-4DB2-B6F4-7555E46916BF">JEEP</option>');
            //$('#cmbProyectosFE').append('<option value="B9938D9A-DDE7-453A-B430-2D9ADF68D15F">GASOLINA HERMOSILLO</option>');
            //$('#cmbProyectosFE').append('<option value="40F670F5-A145-4C52-AC38-6E791E3B5A19">FRONTIER</option>');
            //$('#cmbProyectosFE').append('<option value="11313417-6F42-40B8-A933-06C452E34441">SWIFT</option>');
            //$('#cmbProyectosFE').append('<option value="F76F2A6C-4FA1-4505-82B5-82EE5EE69497">SPARK</option>');
            //$('#cmbProyectosFE').append('<option value="A9B875EC-1AA2-49D0-8D97-144DBFF21B56">F150</option>');
            //$('#cmbProyectosFE').append('<option value="EF4EDE9E-BFCD-4D31-9B40-8E6B21291F21">BRONCO</option>');
            //$('#cmbProyectosFE').append('<option value="1A713837-3DFF-4012-9F5F-7844B3DED561">TONELADA</option>');
            //$('#cmbProyectosFE').append('<option value="F74683C3-A52D-4C2B-9B7E-25771AD50ABD">CONSUMIBLES TALLER CUAUTITLÁN</option>');
            //$('#cmbProyectosFE').append('<option value="05AC88FC-6340-4936-B749-2F6EDA17F88A">CONSUMIBLES TALLER QUERÉTARO</option>');
            //$('#cmbProyectosFE').append('<option value="39A9783A-0AA3-48BE-AF1C-8BDEEC4E1625">CONSUMIBLES TALLER TECATE</option>');
            //$('#cmbProyectosFE').append('<option value="07BF808D-A646-4D63-9CD7-5161A94FC7FB">CONSUMIBLES TALLER CHIHUAHUA</option>');
            //$('#cmbProyectosFE').append('<option value="6A50C6ED-0384-4E54-9142-B14E7338E2DC">EQUIPO DE SEGURIDAD CUAUTITLÁN</option>');
            //$('#cmbProyectosFE').append('<option value="89AE75F8-2D98-40B1-AC47-FDD4D951881C">EQUIPO DE SEGURIDAD QUERÉTARO</option>');
            //$('#cmbProyectosFE').append('<option value="77C10A22-E1E3-4EBB-806A-2891165EDD88">EQUIPO DE SEGURIDAD TECATE</option>');
            //$('#cmbProyectosFE').append('<option value="BFC64785-CAD4-4247-B0AE-A64FE53B4669">EQUIPO DE SEGURIDAD CHIHUAHUA</option>');
            //$('#cmbProyectosFE').append('<option value="BB913E5E-3200-4639-894A-628741DDB24E">INVENTARIO SISA CUAUTITLÁN</option>');
            //$('#cmbProyectosFE').append('<option value="C8589B15-CAF9-44EB-A49C-FAE500B17EC2">INVENTARIO SISA QUERÉTARO</option>');
            //$('#cmbProyectosFE').append('<option value="B99F1969-83AF-457B-BC6E-7544B40683EF">INVENTARIO SISA TECATE</option>');
            //$('#cmbProyectosFE').append('<option value="734B8D0E-DEBE-46F1-9B69-5FF7334D9EB1">INVENTARIO SISA CHIHUAHUA</option>');
            //$('#cmbProyectosFE').append('<option value="A46D00C1-0D5B-41B3-8702-0ADA1D98E175">GASTOS ADMINISTRATIVOS CUAUTITLÁN</option>');
            //$('#cmbProyectosFE').append('<option value="C9E46130-B035-4B7E-97BA-7BED2441BBDD">GASTOS ADMINISTRATIVOS QUERÉTARO</option>');
            //$('#cmbProyectosFE').append('<option value="9AE78058-4070-4F65-82A1-DDEB1E2F624A">GASTOS ADMINISTRATIVOS TECATE</option>');
            //$('#cmbProyectosFE').append('<option value="7846992F-5AF1-4C5F-91C6-A91541C6E405">GASTOS ADMINISTRATIVOS CHIHUAHUA</option>');
            //$('#cmbProyectosFE').append('<option value="79144254-9D84-486B-A0C6-A2C3D2CC6167">GASOLINA CUAUTITLÁN</option>');
            //$('#cmbProyectosFE').append('<option value="84DF1AF7-AD10-4AD6-8F51-9CA6EF0EEC47">GASOLINA QUERÉTARO</option>');
            //$('#cmbProyectosFE').append('<option value="178B1FE7-2E94-4F4D-951C-0A823B095505">GASOLINA TECATE</option>');
            //$('#cmbProyectosFE').append('<option value="EE3ADE54-E730-4C9D-980E-F1A57BB53BE2">GASOLINA CHIHUAHUA</option>');
            //$('#cmbProyectosFE').append('<option value="08369BA2-25DD-4CB4-829A-0A472997794F">PASSAT</option>');
            //$('#cmbProyectosFE').append('<option value="4AD1CAF0-E15C-434C-8A93-794474D902D8">COLORADO</option>');
            //$('#cmbProyectosFE').append('<option value="57F02FB0-ABFD-4907-8D69-ED9284309B80">BATANGA CHICA</option>');
            //$('#cmbProyectosFE').append('<option value="EC17D9F8-4824-4B9C-AFA2-C89B34DE2D23">BATANGA MEDIANA</option>');
            //$('#cmbProyectosFE').append('<option value="3601B5DB-0ACE-468D-80CD-4DE5831362D6">BATANGA GRANDE</option>');
            //$('#cmbProyectosFE').append('<option value="0EF1486A-A756-4064-981D-A5DDFF46F9B4">HILUX</option>');
            //$('#cmbProyectosFE').append('<option value="83099F5D-8420-45DF-BAFC-5218A79D2233">FRONTIER 2021</option>');
            //$('#cmbProyectosFE').append('<option value="A0D7E7EF-DB76-4F99-BAC0-7A4995954481">L200</option>');

            //$("#cmbProyectosFE").append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
           
            $('#cmbProyectosFEEditar').selectpicker('refresh');
            $('#cmbProyectosFEEditar').selectpicker('render');
            $('#cmbProyectosFE').selectpicker('refresh');
            $('#cmbProyectosFE').selectpicker('render');


        }
    });
}


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

$('#btnFEmitidasXML').click(function () {
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
                url: "FacturasEmitidas.aspx/GuardarXml",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {
                    //location.href = './frmProjects.aspx';

                    if (data.d == 'Factura emitida, agregada.') {
                        swal({
                            title: 'Se adjunto correctamente el archivo, recuerda elegir el proveedor correcto.',
                            timer: 3000
                        });

                        $('#TablaFacturas').bootstrapTable('destroy');

                        CargarFE();
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

$('#btnEditarFacturasEmitidas').click(function () {
    var enviado = 0;
    var Proyecto = $('#cmbProyectosFEEditar').val();

    if (Proyecto == '-1') {
        swal('No hay proyecto seleccionado');
        return;
    }

    if ($('#txtTextoEnviadaEditar').text() == 'SI') {
        enviado = 1;
    }
    var params = "{'IdFacturasEmitidas': '" + $('#idFEEditar').val() +
        "','IdProyecto': '" + Proyecto +
        "','NoCotizacion': '" + $('#txtCotizacionFacturaEEditar').val() +
        "','NoOrdenCompra': '" + $('#txtOCFacturaEEditar').val() +
        "','ProgramacionPago': '" + $('#dtProgramacionFechaFEEditar').val() +
        "','PorPagar': '" + $('#txtPorPagarFEEditar').val() +
        "','FechaPago': '" + $('#dtFechaPagoFEEditar').val() +
        "','Estatus': '" + $('#cmbEstatusFEEditar').val() +
        "','FechaPA': '" + $('#dtFechaPAEditar').val() +
        "','EstatusEnviado': '" + enviado +
        "','CorreoEnviado': '" + $('#txtCorreoEditar').val() + "'}";

    $.ajax({
        dataType: "json",
        async: true,
        url: "FacturasEmitidas.aspx/EditarFactura",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            //location.href = './frmProjects.aspx';                
            swal({
                title: msg.d,
                timer: 3000
            });

            $('#TablaFacturas').bootstrapTable('destroy');

            CargarFE();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            swal({
                title: 'Error, intenta de nuevo',
                timer: 3000
            });
        }
    });
});

$('#btnGuardarFacturasEmitidas').click(function () {
    var Proyecto = $('#cmbProyectosFE').val();

    if (Proyecto == '-1' || Proyecto == '') {

        swal('Proporciona proyecto.');
        return;
    }

    if ($('#dtFechaFE').val() == '') {
        swal('Proporciona fecha de factura.');
        return;
    }
    var params = "{'folioFactura': '" + $('#txtFolioFE').val() +
        "','fecha': '" + $('#dtFechaFE').val() +
        "','rfcReceptor': '" + $('#txtRFCFacturaE').val() +
        "','nombreReceptor': '" + $('#txtReceptorFacturaE').val() +
        "','subTotal': '" + $('#txtSubtotalFE').val() +
        "','iva': '" + $('#txtIvaFE').val() +
        "','FechaPA': '" + $('#dtFechaPA').val() +
        "','total': '" + $('#txtTotalFE').val() +
        "','moneda': '" + $('#cmbMonedaFE').val() +
        "','tipoCambio': '" + $('#txtTipoCambioFE').val() +
        "','IdProyecto': '" + Proyecto +
        "','NoCotizacion': '" + $('#txtCotizacionFacturaE').val() +
        "','NoOrdenCompra': '" + $('#txtOCFacturaE').val() +
        "','ProgramacionPago': '" + $('#dtProgramacionFechaFE').val() +
        "','PorPagar': '" + $('#txtPorPagarFE').val() +
        "','FechaPago': '" + $('#dtFechaPagoFE').val() +
        "','Estatus': '" + $('#cmbEstatusFE').val() +
        "'}";

    $.ajax({
        dataType: "json",
        async: true,
        url: "FacturasEmitidas.aspx/AgregarFacturaEmitida",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            //location.href = './frmProjects.aspx';                
            swal({
                title: msg.d,
                timer: 3000
            });
            $('#TablaFacturas').bootstrapTable('destroy');

            CargarFE();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            swal({
                title: 'Error, intenta de nuevo',
                timer: 3000
            });
        }
    });
});

$('#btnEliminarFacturas').click(function () {
    var id = document.getElementById('idFacturasEliminar').textContent;
    var tipo = document.getElementById('idFacturasEliminarTipo').textContent;

    var parametros = "{'pid': '" + id + "', 'Opcion':'" + tipo + "'}";
    $.ajax({
        dataType: "json",
        url: "FacturasEmitidas.aspx/EliminarFacturas",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Documento eliminado.") {
                // $("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                if (tipo == 'FR') {
                    CargarFR();
                }
                else {
                    $('#TablaFacturas').bootstrapTable('destroy');

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

function EliminarFE(btn) {
    document.getElementById('idFacturasEliminar').textContent = '';
    document.getElementById('idFacturasEliminarTipo').textContent = '';
    document.getElementById('idFacturasEliminarTexto').textContent = '¿Estás seguro de eliminar factura emitida con código "' + btn.value + '"?';
    document.getElementById('idFacturasEliminar').textContent = btn.value;
    document.getElementById('idFacturasEliminarTipo').textContent = 'FE';
    $("#DelFacturasModal").modal();
}

var oc = '';
var Proyecto = '';

function EditarFE(btn) {
    var id = btn.value;
    $('#idFEEditar').val(id);
    var params = "{'pid': '" + btn.value + "'}";
    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'FacturasEmitidas.aspx/CargarFacturaEmitida',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);
            $(json).each(function (index, value) {
                //debugger;
                //value.Id

                $('#txtFolioFEEditar').val(value.FolioFactura);
                $('#dtFechaFEEditar').val(value.FechaFactura.substring(0, 10));
                $('#txtRFCFacturaEEditar').val(value.RfcReceptor);
                $('#txtReceptorFacturaEEditar').val(value.NombreReceptor);
                Proyecto = value.IdProyecto.toUpperCase();
                $('#cmbProyectosFEEditar').val(Proyecto);

                $('#cmbProyectosFEEditar').selectpicker('refresh');
                if (value.IdProyecto == 'N/A') {
                    $('#cmbProyectosFEEditar').val('B2C9AA16-C340-47A1-8744-5CA73C388F92');
                    $('#cmbProyectosFEEditar').selectpicker('refresh');
                }


                $('#txtCotizacionFacturaEEditar').val(value.NoCotizacion);
                $('#txtOCFacturaEEditar').val(value.OrdenCompraRecibida);
                $('#cmbEstatusFEEditar').val(value.Estatus);
                $('#txtOCFacturaEEditar').val(value.OrdenCompraRecibida);
                $('#cmbMonedaFEEditar').val(value.Moneda);
                $('#txtSubtotalFEEditar').val(formato_numero(value.SubTotal, 2, '.', ','));
                $('#txtIvaFEEditar').val(formato_numero(value.Iva, 2, '.', ','));
                $('#txtTotalFEEditar').val(formato_numero(value.Total, 2, '.', ','));
                $('#txtPorPagarFEEditar').val(formato_numero(value.PorPagar, 2, '.', ','));
                $('#txtTipoCambioFEEditar').val(value.TipoCambio);
                /*$('#txtRetencionFEEditar').val(formato_numero(value.Retencion, 2, '.', ','));*/
                $('#dtFechaPAEditar').val(value.FechaPA === null ? '' : value.FechaPA.substring(0, 10));
                $('#dtFechaPagoFEEditar').val(value.FechaPago === null ? '' : value.FechaPago.substring(0, 10));
                $('#dtProgramacionFechaFEEditar').val(value.ProgramacionPago === null ? '' : value.ProgramacionPago.substring(0, 10));
                if (value.Enviada == "1") {
                    $('#txtTextoEnviadaEditar').text('SI');
                    document.getElementById("chkEnviadaEditar").checked = true;
                }
                $('#txtCorreoEditar').val(value.CorreoEnviado);

            });

        }
    });
    $("#AddFacturasEmitidasEditarModal").modal();
}

function AgregarFE(btn) {
    var id = btn.value;
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

                var params = "{'pid': '" + btn.value +
                    "','NombreArchivo': '" + nombreArchivo +
                    "','Documento': '" + e.target.result + "'}";

                //console.log(params);

                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "FacturasEmitidas.aspx/GuardarArchivosEmitida",
                    data: params,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data, textStatus) {
                        //location.href = './frmProjects.aspx';
                        if (data.d == 'Factura actualizada.') {
                            $('#TablaFacturas').bootstrapTable('destroy');
                            CargarFE();
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

function VisualizarDocumentoFE(btn) {
    $('#testmodalpdffe').html('');

    var params = "{'IdControlFacturas': '" + btn.value +
        "','Opcion': '" + "FE" + "'}";

    $.ajax({
        async: true,
        url: "FacturasEmitidas.aspx/CargarDocumentos",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            var datos = "";

            var JsonCombos;
            var jsonArray = $.parseJSON(data.d);


            $.each(jsonArray, function (index, value) {
                document.getElementById('txtTipoDocumentoFactura').textContent = "FE";

                document.getElementById('txtidFacturaArchivo').textContent = value.IdControlFacturas;
                $('#testmodalpdffe').append('<object id="visorPDF" data="' + value.ArchivoFactura + '" type="application/pdf" style="width:100%; height: 800px;"></object>');
            });
        }
    });
    $("#dvPDFFacturas").modal();
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

function enviadoFormatter(value) {

    var icono;
    //debugger;
    if (value == "1") {
        icono = '<i class="icon_check" style="color: green; font-size: 20px;"></i>';
    }
    else {
        icono = '<i class="icon_close" style="color: red; font-size: 20px;"></i>';
    }
    return icono;
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

    var boronFile = '';

    if (row.NombreArchivo == '' || row.NombreArchivo === null) {
        botonFile = '<Button title="Agregar archivo" class="btn btn-danger" value="' + row.IdFacturasEmitidas + '" onclick="AgregarFE(this);"><i class="icon_document"></i></Button>';
    }
    else {
        botonFile = '<Button title="Ver archivo" class="btn btn-default" value="' + row.IdFacturasEmitidas + '" onclick="VisualizarDocumentoFE(this);"><i class="icon_document"></i></Button>';
    }

    return [
        '<div class="btn-group">',
        '<Button title="Editar" class= "btn btn-info" value="' + row.IdFacturasEmitidas + '" onclick="EditarFE(this);"> <i class="icon_pencil"></i></Button>',
        botonFile,
        '<Button title="Eliminar" class="btn btn-danger" value="' + row.IdFacturasEmitidas + '" onclick="EliminarFE(this);"> <i class="icon_minus-06"></i></Button>',
        '</div>'
    ].join(' ');
}

function dateFormat(value, row, index) {
    return moment(value).format('YYYY-MM-DD');
}

function formatoMonedaFormatter(value) {
    return formato_numero(value, 2, ".", ",");
}

function pagoMultipleFormatter(value, row, index) {
   
    var estatusPagado = row.Estatus;
    if (estatusPagado == "1") {
        return [
            '<div class="form-check form-switch">',
            '<input class="form-check-input" type="checkbox" id="chk_' + row.Folio + '" disabled checked/>',
            '</div>'
        ].join(' ');
    }
    else if (estatusPagado == "2") {
        return [
            '<div class="form-check form-switch">',
            '<input class="form-check-input" type="checkbox" id="chk_' + row.Folio + '" disabled/>',
            '</div>'
        ].join(' ');
    }
    else {
        return [
            '<div class="form-check form-switch" >',
            '<input class="form-check-input pagosMultiples" type="checkbox" id="chk_' + row.Folio + '"/>',
            '</div>'
        ].join(' ');
    }

}

window.pagoMultipleEvents = {
    'click .pagosMultiples': function (e, value, row, index) {


        //debugger;
        var isChecked = e.target.checked;
        var idFfacturaEmitidas = row.IdFacturasEmitidas;
        var folio = row.FolioFactura;
        var NombreProyecto = row.NombreProyecto;
        var Total = row.Total;
        //debugger;
        var params = "{'IdFacturasEmitidas': '" + idFfacturaEmitidas + "', 'Folio': '" + folio + "', 'NombreProyecto': '" + NombreProyecto + "', 'Total': '" + Total + "'}";
        
        if (isChecked) {
            $.ajax({
                async: true,
                url: "FacturasEmitidas.aspx/AgregaOrdenParaPagoMultiple",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {
                    //debugger;
                    //var jsonArray = $.parseJSON(data.d);
                    cuantosPagosMultiples();

                }
            });
        }
        else {
            $.ajax({
                async: true,
                url: "FacturasEmitidas.aspx/EliminaOrdenParaPagoMultiple",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {
                    //debugger;
                    //var jsonArray = $.parseJSON(data.d);

                    cuantosPagosMultiples();
                }
            });
        }
    }
};

function cuantosPagosMultiples() {
    //CuantosParaPagoMultiple
    var params = "{'id': '0'}";

    $.ajax({
        async: true,
        url: "FacturasEmitidas.aspx/CuantosParaPagoMultiple",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var value = $.parseJSON(data.d);
            //debugger;

            if (value > 0) {
                $('#btnmultipleOrdenes').removeAttr('disabled');
            }
            else {
                $('#btnmultipleOrdenes').attr('disabled', 'disabled');
            }
        }
    });
}

$('#btnmultipleOrdenes').click(function () {
    document.getElementById('idOCPagoMultipleTexto').textContent = '¿Estás seguro de realizar el Pago de todas las Facturas de la siguiente lista?';

    var params = "{'id': '1'}";
    $.ajax({
        async: true,
        url: "FacturasEmitidas.aspx/obtienePagosMultiplesPendientes",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var datos = "";
            var nodoTRAgregar = "";

            var JsonCombos;
            var jsonArray = $.parseJSON(data.d);
            var total = 0;

            $('#TablaPrincipalPagosMultiples tbody').html('');
            $.each(jsonArray, function (index, value) {
                total += value.Total;
                nodoTRAgregar += "<tr>";
                nodoTRAgregar += "  <td>" + value.Folio + "</td>";
                nodoTRAgregar += "  <td>" + value.NombreProyecto + "</td>";
                nodoTRAgregar += "  <td>" + formato_numero(value.Total, 2, '.', ',') + "</td>";
                nodoTRAgregar += "</tr>";
            });

            $('#lblTotalPagado').text(formato_numero(total, 2, '.', ','));
            $('#TablaPrincipalPagosMultiples tbody').append(nodoTRAgregar);
        }
    });
    $("#MultipagosOCModal").modal();
});

$('#btnPagoMultipleOC').click(function () {
    //debugger;
    var _fecha = $('#txtFechaPagoMultiple').val();

    if (!!_fecha) {
        //la fecha tiene valor y se manda como parametro
        var params = "{'_fecha': '" + $('#txtFechaPagoMultiple').val() +
            "','_estatus': '" + $('#cmbEstatus').val() +
            "'}";

        $.ajax({
            async: true,
            url: "FacturasEmitidas.aspx/guardaPagosMultiples",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Ordenes pagadas.") {

                    swal({
                        title: msg.d,
                        timer: 2000
                    }).then(() => {
                        //CargarOrdenesCompra();
                        location.reload(true);
                    }).catch(swal.noop);

                }
                else {
                    swal(msg.d);
                }
            }
        });
    }
    else {
        //no hay fecha seleccionada y hay que mandar mensaje de error
        swal('Es necesario seleccionar la Fecha de pago para poder continuar!!!');
    }






});