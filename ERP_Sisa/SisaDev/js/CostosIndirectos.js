$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("CostosIndirectos.aspx") > -1) {


        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarCostosIndirectos(1, 0);

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }

    /*DECLARA VARIABLES GLOBALES PARA COSTOS INDIRECTOS */
    /*GLOBAL */
    var TotalGlobal = 0;
    var PorcentajeGlobal = 0.0000;

    /*HERMOSILLO*/
    var GastosAdmonHermosillo = 0;
    var ConsumiblesHermosillo = 0;
    var GasolinaHermosillo = 0;
    var EquipoSeguridadHermosillo = 0;
    var InventarioHermosillo = 0;
    var ViaticosHermosillo = 0;
    var CarrosHermosillo = 0;
    var UniformesHermosillo = 0;

    var TotalHermosillo = 0;
    var PorcentajeHermosillo = 0.0000;

    /*HERMOSILLO CCM*/
    var GastosAdmonHermosilloCCM = 0;
    var ConsumiblesHermosilloCCM = 0;
    var GasolinaHermosilloCCM = 0;
    var EquipoSeguridadHermosilloCCM = 0;
    var InventarioHermosilloCCM = 0;
    var ViaticosHermosilloCCM = 0;
    var CarrosHermosilloCCM = 0;
    var UniformesHermosilloCCM = 0;

    var TotalHermosilloCCM = 0;
    var PorcentajeHermosilloCCM = 0;

    /*CHIHUAHUA*/
    var GastosAdmonChihuahua = 0;
    var ConsumiblesChihuahua = 0;
    var GasolinaChihuahua = 0;
    var EquipoSeguridadChihuahua = 0;
    var InventarioChihuahua = 0;
    var ViaticosChihuahua = 0;
    var CarrosChihuahua = 0;
    var UniformesChihuahua = 0;

    var TotalChihuahua = 0;
    var PorcentajeChihuahua = 0;

    /*CHIHUAHUA CCM*/
    var GastosAdmonChihuahuaCCM = 0;
    var ConsumiblesChihuahuaCCM = 0;
    var GasolinaChihuahuaCCM = 0;
    var EquipoSeguridadChihuahuaCCM = 0;
    var InventarioChihuahuaCCM = 0;
    var ViaticosChihuahuaCCM = 0;
    var CarrosChihuahuaCCM = 0;
    var UniformesChihuahuaCCM = 0;

    var TotalChihuahuaCCM = 0;
    var PorcentajeChihuahuaCCM = 0;

    /*CUAUTITLAN*/
    var GastosAdmonCuautitlan = 0;
    var ConsumiblesCuautitlan = 0;
    var GasolinaCuautitlan = 0;
    var EquipoSeguridadCuautitlan = 0;
    var InventarioCuautitlan = 0;
    var ViaticosCuautitlan = 0;
    var CarrosCuautitlan = 0;
    var UniformesCuautitlan = 0;

    var TotalCuautitlan = 0;
    var PorcentajeCuautitlan = 0;

    /*CUAUTILTAN CCM*/
    var GastosAdmonCuautitlanCCM = 0;
    var ConsumiblesCuautitlanCCM = 0;
    var GasolinaCuautitlanCCM = 0;
    var EquipoSeguridadCuautitlanCCM = 0;
    var InventarioCuautitlanCCM = 0;
    var ViaticosCuautitlanCCM = 0;
    var CarrosCuautitlanCCM = 0;
    var UniformesCuautitlanCCM = 0;

    var TotalCuautitlanCCM = 0;
    var PorcentajeCuautitlanCCM = 0;

    /*IRAPUATO*/
    var GastosAdmonIrapuato = 0;
    var ConsumiblesIrapuato = 0;
    var GasolinaIrapuato = 0;
    var EquipoSeguridadIrapuato = 0;
    var InventarioIrapuato = 0;
    var ViaticosIrapuato = 0;
    var CarrosIrapuato = 0;
    var UniformesIrapuato = 0;

    var TotalIrapuato = 0;
    var PorcentajeIrapuato = 0;

    /*IRAPUATO CCM*/
    var GastosAdmonIrapuatoCCM = 0;
    var ConsumiblesIrapuatoCCM = 0;
    var GasolinaIrapuatoCCM = 0;
    var EquipoSeguridadIrapuatoCCM = 0;
    var InventarioIrapuatoCCM = 0;
    var ViaticosIrapuatoCCM = 0;
    var CarrosIrapuatoCCM = 0;
    var UniformesIrapuatoCCM = 0;

    var TotalIrapuatoCCM = 0;
    var PorcentajeIrapuatoCCM = 0;

    /*QUERETARO*/
    var GastosAdmonQueretaro = 0;
    var ConsumiblesQueretaro = 0;
    var GasolinaQueretaro = 0;
    var EquipoSeguridadQueretaro = 0;
    var InventarioQueretaro = 0;
    var ViaticosQueretaro = 0;
    var CarrosQueretaro = 0;
    var UniformesQueretaro = 0;

    var TotalQueretaro = 0;
    var PorcentajeQueretaro = 0;

    /*QUERETARO CCM*/
    var GastosAdmonQueretaroCCM = 0;
    var ConsumiblesQueretaroCCM = 0;
    var GasolinaQueretaroCCM = 0;
    var EquipoSeguridadQueretaroCCM = 0;
    var InventarioQueretaroCCM = 0;
    var ViaticosQueretaroCCM = 0;
    var CarrosQueretaroCCM = 0;
    var UniformesQueretaroCCM = 0;

    var TotalQueretaroCCM = 0;
    var PorcentajeQueretaroCCM = 0;

    /*TECATE*/
    var GastosAdmonTecate = 0;
    var ConsumiblesTecate = 0;
    var GasolinaTecate = 0;
    var EquipoSeguridadTecate = 0;
    var InventarioTecate = 0;
    var ViaticosTecate = 0;
    var CarrosTecate = 0;
    var UniformesTecate = 0;

    var TotalTecate = 0;
    var PorcentajeTecate = 0;

    /*USA*/
    var GastosAdmonUSA = 0;
    var ConsumiblesUSA = 0;
    var GasolinaUSA = 0;
    var EquipoSeguridadUSA = 0;
    var InventarioUSA = 0;
    var ViaticosUSA = 0;
    var CarrosUSA = 0;
    var UniformesUSA = 0;

    var TotalUSA = 0;
    var PorcentajeUSA = 0;

    $('#btnTipoCambio').click(function () {

        var f = new Date();
        var fechaIni = moment().startOf('year').format('YYYY-MM-DD');//moment(f).format('YYYY-MM-DD');
        var fechaFin = moment(f).format('YYYY-MM-DD');


        $.ajax({
            url: "https://www.banxico.org.mx/SieAPIRest/service/v1/series/SF63528/datos/" + fechaIni  + "/" + fechaFin + "?token=b6748f24e63bbfff6f4b7cccec2050285f60eb9b75c5171281787aac11891fbc",
            jsonp: "callback",
            dataType: "jsonp", //Se utiliza JSONP para realizar la consulta cross-site
            success: function (response) {  //Handler de la respuesta
                var series = response.bmx.series;
                //debugger;
                //Se carga una tabla con los registros obtenidos
                console.log(series[0].titulo);

                var ItemsToSaveJson = "[";
                var rows = [];

                $(series[0].datos).each(function (index, item) {
                    //debugger;
                    //var row = {};
                   //console.log(item.fecha + " " + item.dato);
                    //row(index) = [item.fecha, item.dato];
                    rows.push({ "Fecha": item.fecha, "Dato" : item.dato });

                });
               

                ItemsToSaveJson = JSON.stringify(rows);

                var param = "{'ID': '" + 0 +
                    "','items': '" + ItemsToSaveJson +
                    "'}";

                $.ajax({
                    async: true,
                    url: "CostosIndirectos.aspx/ActualizaTipoCambio",
                    dataType: "json",
                    data: param,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data, textStatus) {
                        //itemsIns++;

                        //if (itemsIns == itemsTot) {
                        //    if (swal.isVisible()) {
                        swal.closeModal();
                        //}

                        
                        //}
                    }
                });
            }
        });

    });

    $('#btnCaptura').click(function () {
        var params = "{'Opcion': '" + 1 + "'}";

        $.ajax({
            async: true,
            url: "CostosIndirectos.aspx/ObtieneCostosIndirectos",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var jsonArray = $.parseJSON(data.d);
                

                $.each(jsonArray, function (index, value) {
                    //debugger
                    $('#lblFechaIni').text(value.FechaIni.substring(0, 10));
                    $('#lblFechaFin').text(value.FechaFin.substring(0, 10));
                    if (value.Sucursal == "CUAUTITLAN") {
                        if (value.EsCCM == 0) {
                            //debugger;
                            TotalCuautitlan += value.SubTotal;
                            switch (value.Descripcion) {
                                case 'CONSUMIBLES TALLER CUAUTITLAN':
                                    $('#txtConsumiblesCuautitlan').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ConsumiblesCuautitlan = value.SubTotal;
                                    break;
                                case 'EQUIPO DE SEGURIDAD CUAUTITLAN':
                                    $('#txtEquipoSeguridadCuautitlan').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    EquipoSeguridadCuautitlan = value.SubTotal;
                                    break;
                                case 'GASOLINA CUAUTITLAN':
                                    $('#txtGasolinaCuautitlan').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GasolinaCuautitlan = value.SubTotal;
                                    break;
                                case 'GASTOS ADMINISTRATIVOS CUAUTITLAN':
                                    $('#txtGastosAdmonCuautitlan').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GastosAdmonCuautitlan = value.SubTotal;
                                    break;
                                case 'INVENTARIO SISA CUAUTITLAN':
                                    $('#txtInventarioSisadCuautitlan').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    InventarioCuautitlan = value.SubTotal;
                                    break;
                                case 'UNIFORMES SISA CUAUTITLAN':
                                    $('#txtUniformesCuautitlan').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    UniformesCuautitlan = value.SubTotal;
                                    break;
                                case 'VIATICOS CUAUTITLAN':
                                    $('#txtViaticosCuautitlan').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ViaticosCuautitlan = value.SubTotal;
                                    break;
                                case 'CARROS':
                                    $('#txtCarrosCuautitlan').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    CarrosCuautitlan = value.SubTotal;
                                    break;
                                default:
                            }
                        }
                        else {
                            TotalCuautitlanCCM += value.SubTotal;
                            switch (value.Descripcion) {
                                case 'CONSUMIBLES TALLER CCM CUAUTITLAN':
                                    $('#txtConsumiblesCuautitlanCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ConsumiblesCuautitlanCCM = value.SubTotal;
                                    break;
                                case 'EQUIPO DE SEGURIDAD CCM CUAUTITLAN':
                                    $('#txtEquipoSeguridadCuautitlanCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    EquipoSeguridadCuautitlanCCM = value.SubTotal;
                                    break;
                                case 'GASOLINA CCM CUAUTITLAN':
                                    $('#txtGasolinaCuautitlanCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GasolinaCuautitlanCCM = value.SubTotal;
                                    break;
                                case 'GASTOS ADMINISTRATIVOS CCM CUAUTITLAN':
                                    $('#txtGastosAdmonCuautitlanCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GastosAdmonCuautitlanCCM = value.SubTotal;
                                    break;
                                case 'INVENTARIO SISA CCM CUAUTITLAN':
                                    $('#txtInventarioSisadCuautitlanCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    InventarioCuautitlanCCM = value.SubTotal;
                                    break;
                                case 'UNIFORMES SISA CCM CUAUTITLAN':
                                    $('#txtUniformesCuautitlanCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    UniformesCuautitlanCCM = value.SubTotal;
                                    break;
                                case 'VIATICOS CCM CUAUTITLAN':
                                    $('#txtViaticosCuautitlanCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ViaticosCuautitlanCCM = value.SubTotal;
                                    break;
                                case 'CARROS CCM':
                                    $('#txtCarrosCuautitlanCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    CarrosCuautitlanCCM = value.SubTotal;
                                    break;
                                default:
                            }
                        }
                    }
                    else if (value.Sucursal == "HERMOSILLO, SONORA") {
                        if (value.EsCCM == 0) {
                            //debugger;
                            TotalHermosillo += value.SubTotal;
                            switch (value.Descripcion) {
                                case 'CONSUMIBLES TALLER HERMOSILLO':
                                    $('#txtConsumiblesHermosillo').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ConsumiblesHermosillo = value.SubTotal;
                                    break;
                                case 'EQUIPO DE SEGURIDAD HERMOSILLO':
                                    $('#txtEquipoSeguridadHermosillo').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    EquipoSeguridadHermosillo = value.SubTotal;
                                    break;
                                case 'GASOLINA HERMOSILLO':
                                    $('#txtGasolinaHermosillo').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GasolinaHermosillo = value.SubTotal;
                                    break;
                                case 'GASTOS ADMINISTRATIVOS HERMOSILLO':
                                    $('#txtGastosAdmonHermosillo').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GastosAdmonHermosillo = value.SubTotal;
                                    break;
                                case 'INVENTARIO SISA HERMOSILLO':
                                    $('#txtInventarioSisaHermosillo').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    InventarioHermosillo = value.SubTotal;
                                    break;
                                case 'UNIFORMES SISA HERMOSILLO':
                                    $('#txtUniformesHermosillo').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    UniformesHermosillo = value.SubTotal;
                                    break;
                                case 'VIATICOS HERMOSILLO':
                                    $('#txtViaticosHermosillo').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ViaticosHermosillo = value.SubTotal;
                                    break;
                                case 'CARROS':
                                    $('#txtCarrosHermosillo').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    CarrosHermosillo = value.SubTotal;
                                    break;
                                default:
                            }
                        }
                        else {
                            TotalHermosilloCCM += value.SubTotal;
                            switch (value.Descripcion) {
                                case 'CONSUMIBLES TALLER CCM HERMOSILLO':
                                    $('#txtConsumiblesHermosilloCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ConsumiblesHermosilloCCM = value.SubTotal;
                                    break;
                                case 'EQUIPO DE SEGURIDAD CCM HERMOSILLO':
                                    $('#txtEquipoSeguridadHermosilloCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    EquipoSeguridadHermosilloCCM = value.SubTotal;
                                    break;
                                case 'GASOLINA CCM HERMOSILLO':
                                    $('#txtGasolinaHermosilloCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GasolinaHermosilloCCM = value.SubTotal;
                                    break;
                                case 'GASTOS ADMINISTRATIVOS CCM HERMOSILLO':
                                    $('#txtGastosAdmonHermosilloCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GastosAdmonHermosilloCCM = value.SubTotal;
                                    break;
                                case 'INVENTARIO SISA CCM HERMOSILLO':
                                    $('#txtInventarioSisaHermosilloCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    InventarioHermosilloCCM = value.SubTotal;
                                    break;
                                case 'UNIFORMES SISA CCM HERMOSILLO':
                                    $('#txtUniformesHermosilloCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    UniformesHermosilloCCM = value.SubTotal;
                                    break;
                                case 'VIATICOS CCM HERMOSILLO':
                                    $('#txtViaticosHermosilloCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ViaticosHermosilloCCM = value.SubTotal;
                                    break;
                                case 'CARROS CCM':
                                    $('#txtCarrosHermosilloCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    CarrosHermosilloCCM = value.SubTotal;
                                    break;
                                default:
                            }
                        }
                    }
                    else if (value.Sucursal == "CHIHUAHUA, CHIHUAHUA") {
                        if (value.EsCCM == 0) {
                            //debugger;
                            TotalChihuahua += value.SubTotal;
                            switch (value.Descripcion) {
                                case 'CONSUMIBLES TALLER CHIHUAHUA':
                                    $('#txtConsumiblesChihuahua').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ConsumiblesChihuahua = value.SubTotal;
                                    break;
                                case 'EQUIPO DE SEGURIDAD CHIHUAHUA':
                                    $('#txtEquipoSeguridadChihuahua').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    EquipoSeguridadChihuahua = value.SubTotal;
                                    break;
                                case 'GASOLINA CHIHUAHUA':
                                    $('#txtGasolinaChihuahua').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GasolinaChihuahua = value.SubTotal;
                                    break;
                                case 'GASTOS ADMINISTRATIVOS CHIHUAHUA':
                                    $('#txtGastosAdmonChihuahua').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GastosAdmonChihuahua = value.SubTotal;
                                    break;
                                case 'INVENTARIO SISA CHIHUAHUA':
                                    $('#txtInventarioSisaChihuahua').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    InventarioChihuahua = value.SubTotal;
                                    break;
                                case 'UNIFORMES SISA CHIHUAHUA':
                                    $('#txtUniformesChihuahua').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    UniformesChihuahua = value.SubTotal;
                                    break;
                                case 'VIATICOS CHIHUAHUA':
                                    $('#txtViaticosChihuahua').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ViaticosChihuahua = value.SubTotal;
                                    break;
                                case 'CARROS':
                                    $('#txtCarrosChihuahua').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    CarrosChihuahua = value.SubTotal;
                                    break;
                                default:
                            }
                        }
                        else {
                            TotalChihuahuaCCM += value.SubTotal;
                            switch (value.Descripcion) {
                                case 'CONSUMIBLES TALLER CCM CHIHUAHUA':
                                    $('#txtConsumiblesChihuahuaCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ConsumiblesChihuahuaCCM = value.SubTotal;
                                    break;
                                case 'EQUIPO DE SEGURIDAD CCM CHIHUAHUA':
                                    $('#txtEquipoSeguridadChihuahuaCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    EquipoSeguridadChihuahuaCCM = value.SubTotal;
                                    break;
                                case 'GASOLINA CCM CHIHUAHUA':
                                    $('#txtGasolinaChihuahuaCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GasolinaChihuahuaCCM = value.SubTotal;
                                    break;
                                case 'GASTOS ADMINISTRATIVOS CCM CHIHUAHUA':
                                    $('#txtGastosAdmonChihuahuaCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GastosAdmonChihuahuaCCM = value.SubTotal;
                                    break;
                                case 'INVENTARIO SISA CCM CHIHUAHUA':
                                    $('#txtInventarioSisaChihuahuaCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    InventarioChihuahuaCCM = value.SubTotal;
                                    break;
                                case 'UNIFORMES SISA CCM CHIHUAHUA':
                                    $('#txtUniformesChihuahuaCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    UniformesChihuahuaCCM = value.SubTotal;
                                    break;
                                case 'VIATICOS CCM CHIHUAHUA':
                                    $('#txtViaticosChihuahuaCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ViaticosChihuahuaCCM = value.SubTotal;
                                    break;
                                case 'CARROS CCM':
                                    $('#txtCarrosChihuahuaCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    CarrosChihuahuaCCM = value.SubTotal;
                                    break;
                                default:
                            }
                        }
                    }
                    else if (value.Sucursal == "IRAPUATO, GUANAJUATO") {
                        if (value.EsCCM == 0) {
                            //debugger;
                            TotalIrapuato += value.SubTotal;
                            switch (value.Descripcion) {
                                case 'CONSUMIBLES TALLER IRAPUATO':
                                    $('#txtConsumiblesIrapuato').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ConsumiblesIrapuato = value.SubTotal;
                                    break;
                                case 'EQUIPO DE SEGURIDAD IRAPUATO':
                                    $('#txtEquipoSeguridadIrapuato').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    EquipoSeguridadIrapuato = value.SubTotal;
                                    break;
                                case 'GASOLINA IRAPUATO':
                                    $('#txtGasolinaIrapuato').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GasolinaIrapuato = value.SubTotal;
                                    break;
                                case 'GASTOS ADMINISTRATIVOS IRAPUATO':
                                    $('#txtGastosAdmonIrapuato').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GastosAdmonIrapuato = value.SubTotal;
                                    break;
                                case 'INVENTARIO SISA IRAPUATO':
                                    $('#txtInventarioSisaIrapuato').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    InventarioIrapuato = value.SubTotal;
                                    break;
                                case 'UNIFORMES SISA IRAPUATO':
                                    $('#txtUniformesIrapuato').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    UniformesIrapuato = value.SubTotal;
                                    break;
                                case 'VIATICOS IRAPUATO':
                                    $('#txtViaticosIrapuato').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ViaticosIrapuato = value.SubTotal;
                                    break;
                                case 'CARROS':
                                    $('#txtCarrosIrapuato').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    CarrosIrapuato = value.SubTotal;
                                    break;
                                default:
                            }
                        }
                        else {
                            TotalIrapuatoCCM += value.SubTotal;
                            switch (value.Descripcion) {
                                case 'CONSUMIBLES TALLER CCM IRAPUATO':
                                    $('#txtConsumiblesIrapuatoCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ConsumiblesIrapuatoCCM = value.SubTotal;
                                    break;
                                case 'EQUIPO DE SEGURIDAD CCM IRAPUATO':
                                    $('#txtEquipoSeguridadIrapuatoCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    EquipoSeguridadIrapuatoCCM = value.SubTotal;
                                    break;
                                case 'GASOLINA CCM IRAPUATO':
                                    $('#txtGasolinaIrapuatoCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GasolinaIrapuatoCCM = value.SubTotal;
                                    break;
                                case 'GASTOS ADMINISTRATIVOS CCM IRAPUATO':
                                    $('#txtGastosAdmonIrapuatoCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GastosAdmonIrapuatoCCM = value.SubTotal;
                                    break;
                                case 'INVENTARIO SISA CCM IRAPUATO':
                                    $('#txtInventarioSisaIrapuatoCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    InventarioIrapuatoCCM = value.SubTotal;
                                    break;
                                case 'UNIFORMES SISA CCM IRAPUATO':
                                    $('#txtUniformesIrapuatoCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    UniformesIrapuatoCCM = value.SubTotal;
                                    break;
                                case 'VIATICOS CCM IRAPUATO':
                                    $('#txtViaticosIrapuatoCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ViaticosIrapuatoCCM = value.SubTotal;
                                    break;
                                case 'CARROS CCM':
                                    $('#txtCarrosIrapuatoCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    CarrosIrapuatoCCM = value.SubTotal;
                                    break;
                                default:
                            }
                        }
                    }
                    else if (value.Sucursal == "SANTIAGO QUERETARO, QUERETARO") {
                        if (value.EsCCM == 0) {
                            //debugger;
                            TotalQueretaro += value.SubTotal;
                            switch (value.Descripcion) {
                                case 'CONSUMIBLES TALLER QUERETARO':
                                    $('#txtConsumiblesQueretaro').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ConsumiblesQueretaro = value.SubTotal;
                                    break;
                                case 'EQUIPO DE SEGURIDAD QUERETARO':
                                    $('#txtEquipoSeguridadQueretaro').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    EquipoSeguridadQueretaro = value.SubTotal;
                                    break;
                                case 'GASOLINA QUERETARO':
                                    $('#txtGasolinaQueretaro').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GasolinaQueretaro = value.SubTotal;
                                    break;
                                case 'GASTOS ADMINISTRATIVOS QUERETARO':
                                    $('#txtGastosAdmonQueretaro').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GastosAdmonQueretaro = value.SubTotal;
                                    break;
                                case 'INVENTARIO SISA QUERETARO':
                                    $('#txtInventarioSisaQueretaro').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    InventarioQueretaro = value.SubTotal;
                                    break;
                                case 'UNIFORMES SISA QUERETARO':
                                    $('#txtUniformesQueretaro').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    UniformesQueretaro = value.SubTotal;
                                    break;
                                case 'VIATICOS QUERETARO':
                                    $('#txtViaticosQueretaro').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ViaticosQueretaro = value.SubTotal;
                                    break;
                                case 'CARROS':
                                    $('#txtCarrosQueretaro').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    CarrosQueretaro = value.SubTotal;
                                    break;
                                default:
                            }
                        }
                        else {
                            TotalQueretaroCCM += value.SubTotal;
                            switch (value.Descripcion) {
                                case 'CONSUMIBLES TALLER CCM QUERETARO':
                                    $('#txtConsumiblesQueretaroCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ConsumiblesQueretaroCCM = value.SubTotal;
                                    break;
                                case 'EQUIPO DE SEGURIDAD CCM QUERETARO':
                                    $('#txtEquipoSeguridadQueretaroCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    EquipoSeguridadQueretaroCCM = value.SubTotal;
                                    break;
                                case 'GASOLINA CCM QUERETARO':
                                    $('#txtGasolinaQueretaroCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GasolinaQueretaroCCM = value.SubTotal;
                                    break;
                                case 'GASTOS ADMINISTRATIVOS CCM QUERETARO':
                                    $('#txtGastosAdmonQueretaroCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GastosAdmonQueretaroCCM = value.SubTotal;
                                    break;
                                case 'INVENTARIO SISA CCM QUERETARO':
                                    $('#txtInventarioSisaQueretaroCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    InventarioQueretaroCCM = value.SubTotal;
                                    break;
                                case 'UNIFORMES SISA CCM QUERETARO':
                                    $('#txtUniformesQueretaroCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    UniformesQueretaroCCM = value.SubTotal;
                                    break;
                                case 'VIATICOS CCM QUERETARO':
                                    $('#txtViaticosQueretaroCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ViaticosQueretaroCCM = value.SubTotal;
                                    break;
                                case 'CARROS CCM':
                                    $('#txtCarrosQueretaroCCM').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    CarrosQueretaroCCM = value.SubTotal;
                                    break;
                                default:
                            }
                        }
                    }
                    else if (value.Sucursal == "TECATE, BAJA CALIFORNIA") {
                        if (value.EsCCM == 0) {
                            //debugger;
                            TotalTecate += value.SubTotal;
                            switch (value.Descripcion) {
                                case 'CONSUMIBLES TALLER TECATE':
                                    $('#txtConsumiblesTecate').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ConsumiblesTecate = value.SubTotal;
                                    break;
                                case 'EQUIPO DE SEGURIDAD TECATE':
                                    $('#txtEquipoSeguridadTecate').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    EquipoSeguridadTecate = value.SubTotal;
                                    break;
                                case 'GASOLINA TECATE':
                                    $('#txtGasolinaTecate').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GasolinaTecate = value.SubTotal;
                                    break;
                                case 'GASTOS ADMINISTRATIVOS TECATE':
                                    $('#txtGastosAdmonTecate').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GastosAdmonTecate = value.SubTotal;
                                    break;
                                case 'INVENTARIO SISA TECATE':
                                    $('#txtInventarioSisaTecate').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    InventarioTecate = value.SubTotal;
                                    break;
                                case 'UNIFORMES SISA TECATE':
                                    $('#txtUniformesTecate').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    UniformesTecate = value.SubTotal;
                                    break;
                                case 'VIATICOS TECATE':
                                    $('#txtViaticosTecate').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ViaticosTecate = value.SubTotal;
                                    break;
                                case 'CARROS':
                                    $('#txtCarrosTecate').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    CarrosTecate = value.SubTotal;
                                    break;
                                default:
                            }
                        }
                    }
                    else if (value.Sucursal == "ESTADOS UNIDOS") {
                        if (value.EsCCM == 0) {
                            //debugger;
                            TotalUSA += value.SubTotal;
                            switch (value.Descripcion) {
                                case 'CONSUMIBLES TALLER USA':
                                    $('#txtConsumiblesUSA').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ConsumiblesUSA = value.SubTotal;
                                    break;
                                case 'EQUIPO DE SEGURIDAD USA':
                                    $('#txtEquipoSeguridadUSA').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    EquipoSeguridadUSA = value.SubTotal;
                                    break;
                                case 'GASOLINA USA':
                                    $('#txtGasolinaUSA').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GasolinaUSA = value.SubTotal;
                                    break;
                                case 'GASTOS ADMINISTRATIVOS USA':
                                    $('#txtGastosAdmonUSA').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    GastosAdmonUSA = value.SubTotal;
                                    break;
                                case 'INVENTARIO SISA USA':
                                    $('#txtInventarioSisaUSA').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    InventarioUSA = value.SubTotal;
                                    break;
                                case 'UNIFORMES SISA USA':
                                    $('#txtUniformesUSA').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    UniformesUSA = value.SubTotal;
                                    break;
                                case 'VIATICOS USA':
                                    $('#txtViaticosUSA').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    ViaticosUSA = value.SubTotal;
                                    break;
                                case 'CARROS':
                                    $('#txtCarrosUSA').val(formato_numero(value.SubTotal, 2, '.', ','));
                                    CarrosUSA = value.SubTotal;
                                    break;
                                default:
                            }
                        }
                    }
                });

                params = "{'Opcion': '" + 1 + "'}";
                var totalProyectos = 0;
                var totalCotizado = 0;

                $.ajax({
                    async: true,
                    url: "CostosIndirectos.aspx/ObtieneTotalProyectos",
                    dataType: "json",
                    data: params,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data, textStatus) {

                        var jsonArray = $.parseJSON(data.d);

                        $.each(jsonArray, function (index, value) {
                            totalProyectos += value.TotalProyectos;
                            totalCotizado += value.Cotizacion;
                            if (value.CiudadSucursal == "CUAUTITLAN") {
                                if (value.EsCCM == 0) {
                                    $('#lblTotalProyectosCuautitlan').text(formato_numero(value.TotalProyectos, 2, '.', ','));
                                    $('#lblTotalCotizadoCuautitlan').text(formato_numero(value.Cotizacion, 2, '.', ','));
                                    PorcentajeCuautitlan = (TotalCuautitlan / value.Cotizacion);
                                    $('#lblTotalPorcentajeCuautitlan').text(parseFloat(PorcentajeCuautitlan).toFixed(4));
                                }
                                else {
                                    $('#lblTotalProyectosCuautitlanCCM').text(formato_numero(value.TotalProyectos, 2, '.', ','));
                                    $('#lblTotalCotizadoCuautitlanCCM').text(formato_numero(value.Cotizacion, 2, '.', ','));
                                    PorcentajeCuautitlanCCM = (TotalCuautitlanCCM / value.Cotizacion);
                                    $('#lblTotalPorcentajeCuautitlanCCM').text(parseFloat(PorcentajeCuautitlanCCM).toFixed(4));
                                }
                            }
                            else if (value.CiudadSucursal == "CHIHUAHUA, CHIHUAHUA") {
                                if (value.EsCCM == 0) {
                                    $('#lblTotalProyectosChihuahua').text(formato_numero(value.TotalProyectos, 2, '.', ','));
                                    $('#lblTotalCotizadoChihuahua').text(formato_numero(value.Cotizacion, 2, '.', ','));
                                    PorcentajeChihuahua = (TotalChihuahua / value.Cotizacion);
                                    $('#lblTotalPorcentajeChihuahua').text(parseFloat(PorcentajeChihuahua).toFixed(4));
                                }
                                else {
                                    $('#lblTotalProyectosChihuahuaCCM').text(formato_numero(value.TotalProyectos, 2, '.', ','));
                                    $('#lblTotalCotizadoChihuahuaCCM').text(formato_numero(value.Cotizacion, 2, '.', ','));
                                    PorcentajeChihuahuaCCM = (TotalChihuahuaCCM / value.Cotizacion);
                                    $('#lblTotalPorcentajeChihuahuaCCM').text(parseFloat(PorcentajeChihuahuaCCM).toFixed(4));
                                }
                            }
                            else if (value.CiudadSucursal == "ESTADOS UNIDOS") {
                                if (value.EsCCM == 0) {
                                    $('#lblTotalProyectosUSA').text(formato_numero(value.TotalProyectos, 2, '.', ','));
                                    $('#lblTotalCotizadoUSA').text(formato_numero(value.Cotizacion, 2, '.', ','));
                                    PorcentajeUSA = (TotalUSA / value.Cotizacion);
                                    $('#lblTotalPorcentajeUSA').text(parseFloat(PorcentajeUSA).toFixed(4));
                                }
                            }
                            else if (value.CiudadSucursal == "HERMOSILLO, SONORA") {
                                if (value.EsCCM == 0) {

                                    $('#lblTotalProyectosHermosillo').text(formato_numero(value.TotalProyectos, 2, '.', ','));
                                    $('#lblTotalCotizadoHermosillo').text(formato_numero(value.Cotizacion, 2, '.', ','));
                                    PorcentajeHermosillo = (TotalHermosillo / value.Cotizacion);
                                    $('#lblTotalPorcentajeHermosillo').text(parseFloat(PorcentajeHermosillo).toFixed(4));
                                }
                                else {
                                    $('#lblTotalProyectosHermosilloCCM').text(formato_numero(value.TotalProyectos, 2, '.', ','));
                                    $('#lblTotalCotizadoHermosilloCCM').text(formato_numero(value.Cotizacion, 2, '.', ','));
                                    PorcentajeHermosilloCCM = (TotalHermosilloCCM / value.Cotizacion);
                                    $('#lblTotalPorcentajeHermosilloCCM').text(parseFloat(PorcentajeHermosilloCCM).toFixed(4));
                                }
                            }
                            else if (value.CiudadSucursal == "IRAPUATO, GUANAJUATO") {
                                if (value.EsCCM == 0) {
                                    $('#lblTotalProyectosIrapuato').text(formato_numero(value.TotalProyectos, 2, '.', ','));
                                    $('#lblTotalCotizadoIrapuato').text(formato_numero(value.Cotizacion, 2, '.', ','));
                                    PorcentajeIrapuato = (TotalIrapuato / value.Cotizacion);
                                    $('#lblTotalPorcentajeIrapuato').text(parseFloat(PorcentajeIrapuato).toFixed(4));
                                }
                                else {
                                    $('#lblTotalProyectosIrapuatoCCM').text(formato_numero(value.TotalProyectos, 2, '.', ','));
                                    $('#lblTotalCotizadoIrapuatoCCM').text(formato_numero(value.Cotizacion, 2, '.', ','));
                                    PorcentajeIrapuatoCCM = (TotalIrapuatoCCM / value.Cotizacion);
                                    $('#lblTotalPorcentajeIrapuatoCCM').text(parseFloat(PorcentajeIrapuatoCCM).toFixed(4));
                                }
                            }
                            else if (value.CiudadSucursal == "SANTIAGO QUERETARO, QUERETARO") {
                                if (value.EsCCM == 0) {
                                    $('#lblTotalProyectosQueretaro').text(formato_numero(value.TotalProyectos, 2, '.', ','));
                                    $('#lblTotalCotizadoQueretaro').text(formato_numero(value.Cotizacion, 2, '.', ','));
                                    PorcentajeQueretaro = (TotalQueretaro / value.Cotizacion);
                                    $('#lblTotalPorcentajeQueretaro').text(parseFloat(PorcentajeQueretaro).toFixed(4));
                                }
                                else {
                                    $('#lblTotalProyectosQueretaroCCM').text(formato_numero(value.TotalProyectos, 2, '.', ','));
                                    $('#lblTotalCotizadoQueretaroCCM').text(formato_numero(value.Cotizacion, 2, '.', ','));
                                    PorcentajeQueretaroCCM = (TotalQueretaroCCM / value.Cotizacion);
                                    $('#lblTotalPorcentajeQueretaro').text(parseFloat(PorcentajeQueretaroCCM).toFixed(4));
                                }
                            }
                            else if (value.CiudadSucursal == "TECATE, BAJA CALIFORNIA") {
                                if (value.EsCCM == 0) {
                                    $('#lblTotalProyectosTecate').text(formato_numero(value.TotalProyectos, 2, '.', ','));
                                    $('#lblTotalCotizadoTecate').text(formato_numero(value.Cotizacion, 2, '.', ','));
                                    PorcentajeTecate = (TotalTecate / value.Cotizacion);
                                    $('#lblTotalPorcentajeTecate').text(parseFloat(PorcentajeTecate).toFixed(4));
                                }
                            }

                            $('#lblTotalProyectos').text(formato_numero(totalProyectos, 2, '.', ','));
                            $('#lblTotalCotizado').text(formato_numero(totalCotizado, 2, '.', ','));
                            //$('#lblTotalPorcentajeHermosillo').text(formato_numero(PorcentajeHermosillo, 2, '.', ','));
                        });
                    }

                });

               
                $('#lblTotalHermosillo').text(formato_numero(TotalHermosillo, 2, '.', ','));
                

                $('#lblTotalChihuahua').text(formato_numero(TotalChihuahua, 2, '.', ','));
                $('#lblTotalCuautitlan').text(formato_numero(TotalCuautitlan, 2, '.', ','));
                $('#lblTotalIrapuato').text(formato_numero(TotalIrapuato, 2, '.', ','));
                $('#lblTotalQueretaro').text(formato_numero(TotalQueretaro, 2, '.', ','));
                $('#lblTotalTecate').text(formato_numero(TotalTecate, 2, '.', ','));
                $('#lblTotalUSA').text(formato_numero(TotalUSA, 2, '.', ','));

                $('#lblTotalHermosilloCCM').text(formato_numero(TotalHermosilloCCM, 2, '.', ','));
                $('#lblTotalChihuahuaCCM').text(formato_numero(TotalChihuahuaCCM, 2, '.', ','));
                $('#lblTotalCuautitlanCCM').text(formato_numero(TotalCuautitlanCCM, 2, '.', ','));
                $('#lblTotalIrapuatoCCM').text(formato_numero(TotalIrapuatoCCM, 2, '.', ','));
                $('#lblTotalQueretaroCCM').text(formato_numero(TotalQueretaroCCM, 2, '.', ','));

                



            }
        });
    });

    $(".costosGlobal").keyup(function () {
        //TotalHermosillo += parseFloat($(this).val());
        //$('#lblTotalHermosillo').text(formato_numero(TotalHermosillo, 2, '.', ','));
        //$(this).val(formato_numero($(this).val(), 2, ".", ","));
        sumarGlobal();
    });

    function sumarGlobal() {

        var costosGlobal = 0;

        $('.costosGlobal').each(function () {
            if (!$(this).val() == "") {

                costosGlobal += parseFloat($(this).val().replace(/\,/g, ""));
            }
        });
        costosGlobal += TotalGlobal;
        PorcentajeGlobal = costosGlobal / (parseFloat($('#lblTotalCotizado').text().replace(/\,/g, "")));
        $('#lblTotalGlobal').text(formato_numero(costosGlobal, 2, ".", ","));
        $('#lblTotalPorcentaje').text(parseFloat(PorcentajeGlobal).toFixed(4));
    }

    $(".costosHermosillo").keyup(function () {
        //TotalHermosillo += parseFloat($(this).val());
        //$('#lblTotalHermosillo').text(formato_numero(TotalHermosillo, 2, '.', ','));
        //$(this).val(formato_numero($(this).val(), 2, ".", ","));
        sumarHermosillo();
    });

    function sumarHermosillo() {

        var costosHermosillo = 0;

        $('.costosHermosillo').each(function () {
            if (!$(this).val() == "") {
                
                costosHermosillo += parseFloat($(this).val().replace(/\,/g, ""));
            }
        });
        costosHermosillo += TotalHermosillo;
        PorcentajeHermosillo = costosHermosillo / (parseFloat($('#lblTotalCotizadoHermosillo').text().replace(/\,/g, "")));
        $('#lblTotalHermosillo').text(formato_numero(costosHermosillo, 2, ".", ","));
        $('#lblTotalPorcentajeHermosillo').text(parseFloat(PorcentajeHermosillo).toFixed(4));
    }

    $(".costosHermosilloCCM").keyup(function () {
        sumarHermosilloCCM();
    });

    function sumarHermosilloCCM() {

        var costosHermosilloCCM = 0;

        $('.costosHermosilloCCM').each(function () {
            if (!$(this).val() == "") {
                costosHermosilloCCM += parseFloat($(this).val().replace(/\,/g, ""));
            }
        });
        costosHermosilloCCM += TotalHermosilloCCM;
        PorcentajeHermosilloCCM = costosHermosilloCCM / (parseFloat($('#lblTotalCotizadoHermosilloCCM').text().replace(/\,/g, "")));
        $('#lblTotalHermosilloCCM').text(formato_numero(costosHermosilloCCM, 2, ".", ","));
        $('#lblTotalPorcentajeHermosilloCCM').text(parseFloat(PorcentajeHermosilloCCM).toFixed(4));
    }

    $(".costosChihuahua").keyup(function () {
        sumarChihuahua();
    });

    function sumarChihuahua() {

        var costosChihuahua = 0;

        $('.costosChihuahua').each(function () {
            if (!$(this).val() == "") {
                costosChihuahua += parseFloat($(this).val().replace(/\,/g, ""));
            }
        });
        costosChihuahua += TotalChihuahua;
        PorcentajeChihuahua = costosChihuahua / (parseFloat($('#lblTotalCotizadoChihuahua').text().replace(/\,/g, "")));
        $('#lblTotalChihuahua').text(formato_numero(costosChihuahua, 2, ".", ","));
        $('#lblTotalPorcentajeChihuahua').text(parseFloat(PorcentajeChihuahua).toFixed(4));
    }

    $(".costosChihuahuaCCM").keyup(function () {
        sumarChihuahuaCCM();
    });

    function sumarChihuahuaCCM() {

        var costosChihuahuaCCM = 0;

        $('.costosChihuahuaCCM').each(function () {
            if (!$(this).val() == "") {
                costosChihuahuaCCM += parseFloat($(this).val().replace(/\,/g, ""));
            }
        });
        costosChihuahuaCCM += TotalChihuahuaCCM;
        PorcentajeChihuahuaCCM = costosChihuahuaCCM / (parseFloat($('#lblTotalCotizadoChihuahuaCCM').text().replace(/\,/g, "")));
        $('#lblTotalChihuahuaCCM').text(formato_numero(costosChihuahuaCCM, 2, ".", ","));
        $('#lblTotalPorcentajeChihuahuaCCM').text(parseFloat(PorcentajeChihuahuaCCM).toFixed(4));
    }

    $(".costosCuatitlan").keyup(function () {
        sumarCuatitlan();
    });

    function sumarCuatitlan() {

        var costosCuatitlan = 0;

        $('.costosCuatitlan').each(function () {
            if (!$(this).val() == "") {
                costosCuatitlan += parseFloat($(this).val().replace(/\,/g, ""));
            }
        });
        costosCuatitlan += TotalCuautitlan;
        //console.log("Total:" + TotalCuautitlan);
        PorcentajeCuautitlan = costosCuatitlan / (parseFloat($('#lblTotalCotizadoCuautitlan').text().replace(/\,/g, "")));
        //console.log(PorcentajeCuautitlan);
        $('#lblTotalCuatitlan').text(formato_numero(costosCuatitlan, 2, ".", ","));
        $('#lblTotalPorcentajeCuautitlan').text(formatoPorcentajeFormatter(PorcentajeCuautitlan));
    }

    $(".costosCuautitlanCCM").keyup(function () {
        sumarCuatitlanCCM();
    });

    function sumarCuatitlanCCM() {
        //debugger
        var costosCuatitlanCCM = 0;

        $('.costosCuautitlanCCM').each(function () {
            if (!$(this).val() == "") {
                costosCuatitlanCCM += parseFloat($(this).val().replace(/\,/g, ""));
            }
        });
        costosCuatitlanCCM += TotalCuautitlanCCM;
        PorcentajeCuautitlanCCM = costosCuatitlanCCM / (parseFloat($('#lblTotalCotizadoCuautitlanCCM').text().replace(/\,/g, "")));
        $('#lblTotalCuautitlanCCM').text(formato_numero(costosCuatitlanCCM, 2, ".", ","));
        $('#lblTotalPorcentajeCuautitlanCCM').text(parseFloat(PorcentajeCuautitlanCCM).toFixed(4));
    }

    $(".costosIrapuato").keyup(function () {
        sumarIrapuato();
    });

    function sumarIrapuato() {

        var costosIrapuato = 0;

        $('.costosIrapuato').each(function () {
            if (!$(this).val() == "") {
                costosIrapuato += parseFloat($(this).val().replace(/\,/g, ""));
            }
        });
        costosIrapuato += TotalIrapuato;
        PorcentajeIrapuato = costosIrapuato / (parseFloat($('#lblTotalCotizadoIrapuato').text().replace(/\,/g, "")));
        $('#lblTotalIrapuato').text(formato_numero(costosIrapuato, 2, ".", ","));
        $('#lblTotalPorcentajeIrapuato').text(parseFloat(PorcentajeIrapuato).toFixed(4));
    }

    $(".costosIrapuatoCCM").keyup(function () {
        sumarIrapuatoCCM();
    });

    function sumarIrapuatoCCM() {

        var costosIrapuatoCCM = 0;

        $('.costosIrapuatoCCM').each(function () {
            if (!$(this).val() == "") {
                costosIrapuatoCCM += parseFloat($(this).val().replace(/\,/g, ""));
            }
        });
        costosIrapuatoCCM += TotalIrapuatoCCM;
        PorcentajeIrapuatoCCM = costosIrapuatoCCM / (parseFloat($('#lblTotalCotizadoIrapuatoCCM').text().replace(/\,/g, "")));
        $('#lblTotalIrapuatoCCM').text(formato_numero(costosIrapuatoCCM, 2, ".", ","));
        $('#lblTotalPorcentajeIrapuatoCCM').text(parseFloat(PorcentajeIrapuatoCCM).toFixed(4));
    }

    $(".costosQueretaro").keyup(function () {
        sumarQueretaro();
    });

    function sumarQueretaro() {

        var costosQueretaro = 0;

        $('.costosQueretaro').each(function () {
            if (!$(this).val() == "") {
                costosQueretaro += parseFloat($(this).val().replace(/\,/g, ""));
            }
        });
        costosQueretaro += TotalQueretaro;
        PorcentajeQueretaro = costosQueretaro / (parseFloat($('#lblTotalCotizadoQueretaro').text().replace(/\,/g, "")));
        $('#lblTotalQueretaro').text(formato_numero(costosQueretaro, 2, ".", ","));
        $('#lblTotalPorcentajeQueretaro').text(parseFloat(PorcentajeQueretaro).toFixed(4));
    }

    $(".costosQueretaroCCM").keyup(function () {
        sumarQueretaroCCM();
    });

    function sumarQueretaroCCM() {

        var costosQueretaroCCM = 0;

        $('.costosQueretaroCCM').each(function () {
            if (!$(this).val() == "") {
                costosQueretaroCCM += parseFloat($(this).val().replace(/\,/g, ""));
            }
        });
        costosQueretaroCCM += TotalQueretaroCCM;
        PorcentajeQueretaroCCM = costosQueretaroCCM / (parseFloat($('#lblTotalCotizadoQueretaroCCM').text().replace(/\,/g, "")));
        $('#lblTotalQueretaroCCM').text(formato_numero(costosQueretaroCCM, 2, ".", ","));
        $('#lblTotalPorcentajeQueretaroCCM').text(formatoPorcentajeFormatter(PorcentajeQueretaroCCM));
    }

    $(".costosTecate").keyup(function () {
        sumarTecate();
    });

    function sumarTecate() {

        var costosTecate = 0;

        $('.costosTecate').each(function () {
            if (!$(this).val() == "") {
                costosTecate += parseFloat($(this).val().replace(/\,/g, ""));
            }
        });
        costosTecate += TotalTecate;
        PorcentajeTecate = costosTecate / (parseFloat($('#lblTotalCotizadoTecate').text().replace(/\,/g, "")));
        $('#lblTotalTecate').text(formato_numero(costosTecate, 2, ".", ","));
        $('#lblTotalPorcentajeTecate').text(parseFloat(PorcentajeTecate).toFixed(4));
    }

    $(".costosUSA").keyup(function () {
        sumarUSA();
    });

    function sumarUSA() {

        var costosUSA = 0;

        $('.costosUSA').each(function () {
            if (!$(this).val() == "") {
                costosUSA += parseFloat($(this).val().replace(/\,/g, ""));
            }
        });
        costosUSA += TotalUSA;
        PorcentajeUSA = costosUSA / (parseFloat($('#lblTotalCotizadoUSA').text().replace(/\,/g, "")));
        $('#lblTotalUSA').text(formato_numero(costosUSA, 2, ".", ","));
        $('#lblTotalPorcentajeUSA').text(parseFloat(PorcentajeUSA).toFixed(4));
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

    $('#btnGuardarCostoIndirecto').click(function () {
        /*GLOBAL*/
        var CostoNomina = $('#txtNominaGlobal').val();
        var CostoImss = $('#txtCostoImss').val();
        var CostoTotal = $('#txtCostoTotal').val();
        var TotalEmpleados = $('#txtTotalEmpleados').val();
        var InteresGlobal = $('#txtInteresGlobal').val();
        var Vacaciones = $('#txtVacacionesGlobal').val();
        var Aguinaldo = $('#txtAguinaldoGlobal').val();
        var ProyectosGlobal = $('#lblTotalProyectos').text();
        var CotizadoGlobal = $('#lblTotalCotizado').text();
        var PorcentajeGlobal = $('#lblTotalPorcentaje').text();
        var TotalGlobal = $('#lblTotalGlobal').text();

        /*HERMOSILLO*/
        var CostoNominaHermosillo = $('#txtNominaHermosillo').val();
        var CostoImssHermosillo = $('#txtCostoImssHermosillo').val();
        var CostoTotalHermosillo = $('#txtCostoTotalHermosillo').val();
        var TotalEmpleadosHermosillo = $('#txtTotalEmpleadosHermosillo').val();
        var PerdidaCambiariaHermosillo = $('#txtPerdidaCambiariaHermosillo').val();
        var UtilidadCambiariaHermosillo = $('#txtUtilidadCambiariaHermosillo').val();
        var ComisionBancariaHermosillo = $('#txtComisionBancariaHermosillo').val();
        var VacacionesHermosillo = $('#txtVacacionesHermosillo').val();
        var AguinaldoHermosillo = $('#txtAguinaldoHermosillo').val();
        var ProyectosHermosillo = $('#lblTotalProyectosHermosillo').text();
        var CotizadoHermosillo = $('#lblTotalCotizadoHermosillo').text();
        var PorcentajeHermosillo = $('#lblTotalPorcentajeHermosillo').text();
        var TotalHermosillo = $('#lblTotalHermosillo').text();

        /*HERMOSILLO CCM*/
        var CostoNominaHermosilloCCM = $('#txtNominaHermosilloCCM').val();
        var CostoImssHermosilloCCM = $('#txtCostoImssHermosilloCCM').val();
        var CostoTotalHermosilloCCM = $('#txtCostoTotalHermosilloCCM').val();
        var TotalEmpleadosHermosilloCCM = $('#txtTotalEmpleadosHermosilloCCM').val();
        var PerdidaCambiariaHermosilloCCM = $('#txtPerdidaCambiariaHermosilloCCM').val();
        var UtilidadCambiariaHermosilloCCM = $('#txtUtilidadCambiariaHermosilloCCM').val();
        var ComisionBancariaHermosilloCCM = $('#txtComisionBancariaHermosilloCCM').val();
        var VacacionesHermosilloCCM = $('#txtVacacionesHermosilloCCM').val();
        var AguinaldoHermosilloCCM = $('#txtAguinaldoHermosilloCCM').val();
        var ProyectosHermosilloCCM = $('#lblTotalProyectosHermosilloCCM').text();
        var CotizadoHermosilloCCM = $('#lblTotalCotizadoHermosilloCCM').text();
        var PorcentajeHermosilloCCM = $('#lblTotalPorcentajeHermosilloCCM').text();
        var TotalHermosilloCCM = $('#lblTotalHermosilloCCM').text();
        
        /*CHIHUAHUA*/
        var CostoNominaChihuahua = $('#txtNominaChihuahua').val();
        var CostoImssChihuahua = $('#txtCostoImssChihuahua').val();
        var CostoTotalChihuahua = $('#txtCostoTotalChihuahua').val();
        var TotalEmpleadosChihuahua = $('#txtTotalEmpleadosChihuahua').val();
        var PerdidaCambiariaChihuahua = $('#txtPerdidaCambiariaChihuahua').val();
        var UtilidadCambiariaChihuahua = $('#txtUtilidadCambiariaChihuahua').val();
        var ComisionBancariaChihuahua = $('#txtComisionBancariaChihuahua').val();
        var VacacionesChihuahua = $('#txtVacacionesChihuahua').val();
        var AguinaldoChihuahua = $('#txtAguinaldoChihuahua').val();
        var ProyectosChihuahua = $('#lblTotalProyectosChihuahua').text();
        var CotizadoChihuahua = $('#lblTotalCotizadoChihuahua').text();
        var PorcentajeChihuahua = $('#lblTotalPorcentajeChihuahua').text();
        var TotalChihuahua = $('#lblTotalChihuahua').text();
        
        /*CHIHUAHUA CCM*/
        var CostoNominaChihuahuaCCM = $('#txtNominaChihuahuaCCM').val();
        var CostoImssChihuahuaCCM = $('#txtCostoImssChihuahuaCCM').val();
        var CostoTotalChihuahuaCCM = $('#txtCostoTotalChihuahuaCCM').val();
        var TotalEmpleadosChihuahuaCCM = $('#txtTotalEmpleadosChihuahuaCCM').val();
        var PerdidaCambiariaChihuahuaCCM = $('#txtPerdidaCambiariaChihuahuaCCM').val();
        var UtilidadCambiariaChihuahuaCCM = $('#txtUtilidadCambiariaChihuahuaCCM').val();
        var ComisionBancariaChihuahuaCCM = $('#txtComisionBancariaChihuahuaCCM').val();
        var VacacionesChihuahuaCCM = $('#txtVacacionesChihuahuaCCM').val();
        var AguinaldoChihuahuaCCM = $('#txtAguinaldoChihuahuaCCM').val();
        var ProyectosChihuahuaCCM = $('#lblTotalProyectosChihuahuaCCM').text();
        var CotizadoChihuahuaCCM = $('#lblTotalCotizadoChihuahuaCCM').text();
        var PorcentajeChihuahuaCCM = $('#lblTotalPorcentajeChihuahuaCCM').text();
        var TotalChihuahuaCCM = $('#lblTotalChihuahuaCCM').text();

        /*CUAUTITLAN*/
        var CostoNominaCuautitlan = $('#txtNominaCuautitlan').val();
        var CostoImssCuautitlan = $('#txtCostoImssCuautitlan').val();
        var CostoTotalCuautitlan = $('#txtCostoTotalCuautitlan').val();
        var TotalEmpleadosCuautitlan = $('#txtTotalEmpleadosCuautitlan').val();
        var PerdidaCambiariaCuautitlan = $('#txtPerdidaCambiariaCuautitlan').val();
        var UtilidadCambiariaCuautitlan = $('#txtUtilidadCambiariaCuautitlan').val();
        var ComisionBancariaCuautitlan = $('#txtComisionBancariaCuautitlan').val();
        var VacacionesCuautitlan = $('#txtVacacionesCuautitlan').val();
        var AguinaldoCuautitlan = $('#txtAguinaldoCuautitlan').val();
        var ProyectosCuautitlan = $('#lblTotalProyectosCuautitlan').text();
        var CotizadoCuautitlan = $('#lblTotalCotizadoCuautitlan').text();
        var PorcentajeCuautitlan = $('#lblTotalPorcentajeCuautitlan').text();
        var TotalCuautitlan = $('#lblTotalCuautitlan').text();
        
        /*CUAUTITLAN CCM*/
        var CostoNominaCuautitlanCCM = $('#txtNominaCuautitlanCCM').val();
        var CostoImssCuautitlanCCM = $('#txtCostoImssCuautitlanCCM').val();
        var CostoTotalCuautitlanCCM = $('#txtCostoTotalCuautitlanCCM').val();
        var TotalEmpleadosCuautitlanCCM = $('#txtTotalEmpleadosCuautitlanCCM').val();
        var PerdidaCambiariaCuautitlanCCM = $('#txtPerdidaCambiariaCuautitlanCCM').val();
        var UtilidadCambiariaCuautitlanCCM = $('#txtUtilidadCambiariaCuautitlanCCM').val();
        var ComisionBancariaCuautitlanCCM = $('#txtComisionBancariaCuautitlanCCM').val();
        var VacacionesCuautitlanCCM = $('#txtVacacionesCuautitlanCCM').val();
        var AguinaldoCuautitlanCCM = $('#txtAguinaldoCuautitlanCCM').val();
        var ProyectosCuautitlanCCM = $('#lblTotalProyectosCuautitlanCCM').text();
        var CotizadoCuautitlanCCM = $('#lblTotalCotizadoCuautitlanCCM').text();
        var PorcentajeCuautitlanCCM = $('#lblTotalPorcentajeCuautitlanCCM').text();
        var TotalCuautitlanCCM = $('#lblTotalCuautitlanCCM').text();
        
        /*IRAPUATO*/
        var CostoNominaIrapuato = $('#txtNominaIrapuato').val();
        var CostoImssIrapuato = $('#txtCostoImssIrapuato').val();
        var CostoTotalIrapuato = $('#txtCostoTotalIrapuato').val();
        var TotalEmpleadosIrapuato = $('#txtTotalEmpleadosIrapuato').val();
        var PerdidaCambiariaIrapuato = $('#txtPerdidaCambiariaIrapuato').val();
        var UtilidadCambiariaIrapuato = $('#txtUtilidadCambiariaIrapuato').val();
        var ComisionBancariaIrapuato = $('#txtComisionBancariaIrapuato').val();
        var VacacionesIrapuato = $('#txtVacacionesIrapuato').val();
        var AguinaldoIrapuato = $('#txtAguinaldoIrapuato').val();
        var ProyectosIrapuato = $('#lblTotalProyectosIrapuato').text();
        var CotizadoIrapuato = $('#lblTotalCotizadoIrapuato').text();
        var PorcentajeIrapuato = $('#lblTotalPorcentajeIrapuato').text();
        var TotalIrapuato = $('#lblTotalIrapuato').text();
        
        /*IRAPUATO CCM*/
        var CostoNominaIrapuatoCCM = $('#txtNominaIrapuatoCCM').val();
        var CostoImssIrapuatoCCM = $('#txtCostoImssIrapuatoCCM').val();
        var CostoTotalIrapuatoCCM = $('#txtCostoTotalIrapuatoCCM').val();
        var TotalEmpleadosIrapuatoCCM = $('#txtTotalEmpleadosIrapuatoCCM').val();
        var PerdidaCambiariaIrapuatoCCM = $('#txtPerdidaCambiariaIrapuatoCCM').val();
        var UtilidadCambiariaIrapuatoCCM = $('#txtUtilidadCambiariaIrapuatoCCM').val();
        var ComisionBancariaIrapuatoCCM = $('#txtComisionBancariaIrapuatoCCM').val();
        var VacacionesIrapuatoCCM = $('#txtVacacionesIrapuatoCCM').val();
        var AguinaldoIrapuatoCCM = $('#txtAguinaldoIrapuatoCCM').val();
        var ProyectosIrapuatoCCM = $('#lblTotalProyectosIrapuatoCCM').text();
        var CotizadoIrapuatoCCM = $('#lblTotalCotizadoIrapuatoCCM').text();
        var PorcentajeIrapuatoCCM = $('#lblTotalPorcentajeIrapuatoCCM').text();
        var TotalIrapuatoCCM = $('#lblTotalIrapuatoCCM').text();
        
        /*QUERETARO*/
        var CostoNominaQueretaro = $('#txtNominaQueretaro').val();
        var CostoImssQueretaro = $('#txtCostoImssQueretaro').val();
        var CostoTotalQueretaro = $('#txtCostoTotalQueretaro').val();
        var TotalEmpleadosQueretaro = $('#txtTotalEmpleadosQueretaro').val();
        var PerdidaCambiariaQueretaro = $('#txtPerdidaCambiariaQueretaro').val();
        var UtilidadCambiariaQueretaro = $('#txtUtilidadCambiariaQueretaro').val();
        var ComisionBancariaQueretaro = $('#txtComisionBancariaQueretaro').val();
        var VacacionesQueretaro = $('#txtVacacionesQueretaro').val();
        var AguinaldoQueretaro = $('#txtAguinaldoQueretaro').val();
        var ProyectosQueretaro = $('#lblTotalProyectosQueretaro').text();
        var CotizadoQueretaro = $('#lblTotalCotizadoQueretaro').text();
        var PorcentajeQueretaro = $('#lblTotalPorcentajeQueretaro').text();
        var TotalQueretaro = $('#lblTotalQueretaro').text();
 
        /*QUERETARO CCM*/
        var CostoNominaQueretaroCCM = $('#txtNominaQueretaroCCM').val();
        var CostoImssQueretaroCCM = $('#txtCostoImssQueretaroCCM').val();
        var CostoTotalQueretaroCCM = $('#txtCostoTotalQueretaroCCM').val();
        var TotalEmpleadosQueretaroCCM = $('#txtTotalEmpleadosQueretaroCCM').val();
        var PerdidaCambiariaQueretaroCCM = $('#txtPerdidaCambiariaQueretaroCCM').val();
        var UtilidadCambiariaQueretaroCCM = $('#txtUtilidadCambiariaQueretaroCCM').val();
        var ComisionBancariaQueretaroCCM = $('#txtComisionBancariaQueretaroCCM').val();
        var VacacionesQueretaroCCM = $('#txtVacacionesQueretaroCCM').val();
        var AguinaldoQueretaroCCM = $('#txtAguinaldoQueretaroCCM').val();
        var ProyectosQueretaroCCM = $('#lblTotalProyectosQueretaroCCM').text();
        var CotizadoQueretaroCCM = $('#lblTotalCotizadoQueretaroCCM').text();
        var PorcentajeQueretaroCCM = $('#lblTotalPorcentajeQueretaroCCM').text();
        var TotalQueretaroCCM = $('#lblTotalQueretaroCCM').text();

        /*TECATE*/
        var CostoNominaTecate = $('#txtNominaTecate').val();
        var CostoImssTecate = $('#txtCostoImssTecate').val();
        var CostoTotalTecate = $('#txtCostoTotalTecate').val();
        var TotalEmpleadosTecate = $('#txtTotalEmpleadosTecate').val();
        var PerdidaCambiariaTecate = $('#txtPerdidaCambiariaTecate').val();
        var UtilidadCambiariaTecate = $('#txtUtilidadCambiariaTecate').val();
        var ComisionBancariaTecate = $('#txtComisionBancariaTecate').val();
        var VacacionesTecate = $('#txtVacacionesTecate').val();
        var AguinaldoTecate = $('#txtAguinaldoTecate').val();
        var ProyectosTecate = $('#lblTotalProyectosTecate').text();
        var CotizadoTecate = $('#lblTotalCotizadoTecate').text();
        var PorcentajeTecate = $('#lblTotalPorcentajeTecate').text();
        var TotalTecate = $('#lblTotalTecate').text();
 
        /*USA*/
        var CostoNominaUSA = $('#txtNominaUSA').val();
        var CostoImssUSA = $('#txtCostoImssUSA').val();
        var CostoTotalUSA = $('#txtCostoTotalUSA').val();
        var TotalEmpleadosUSA = $('#txtTotalEmpleadosUSA').val();
        var PerdidaCambiariaUSA = $('#txtPerdidaCambiariaUSA').val();
        var UtilidadCambiariaUSA = $('#txtUtilidadCambiariaUSA').val();
        var ComisionBancariaUSA = $('#txtComisionBancariaUSA').val();
        var VacacionesUSA = $('#txtVacacionesUSA').val();
        var AguinaldoUSA = $('#txtAguinaldoUSA').val();
        var ProyectosUSA = $('#lblTotalProyectosUSA').text();
        var CotizadoUSA = $('#lblTotalCotizadoUSA').text();
        var PorcentajeUSA = $('#lblTotalPorcentajeUSA').text();
        var TotalUSA = $('#lblTotalUSA').text();
        
        var params = "{'pCostoNomina': '" + CostoNomina + "', 'pCostoImss': '" + CostoImss + "', 'pCostoTotal': '" + CostoTotal + "', 'pTotalEmpleados': '" + TotalEmpleados + "', 'pInteresGlobal': '" + InteresGlobal + "', 'pVacacionesGlobal': '" + Vacaciones + "', 'pAguinaldoGlobal': '" + Aguinaldo + 
            "', 'pCostoNominaHermosillo': '" + CostoNominaHermosillo + "', 'pCostoImssHermosillo': '" + CostoImssHermosillo + "', 'pCostoTotalHermosillo': '" + CostoTotalHermosillo + "', 'pTotalEmpleadosHermosillo': '" + TotalEmpleadosHermosillo + "', 'pPerdidaCambiariaHermosillo': '" + PerdidaCambiariaHermosillo + "', 'pUtilidadCambiariaHermosillo': '" + UtilidadCambiariaHermosillo + "', 'pComisionBancariaHermosillo': '" + ComisionBancariaHermosillo + 
            "', 'pGastosAdmonHermosillo': '" + GastosAdmonHermosillo + "', 'pConsumiblesHermosillo': '" + ConsumiblesHermosillo + "', 'pGasolinaHermosillo': '" + GasolinaHermosillo + "', 'pEquipoSeguridadHermosillo': '" + EquipoSeguridadHermosillo + "', 'pInventarioHermosillo': '" + InventarioHermosillo + "', 'pViaticosHermosillo': '" + ViaticosHermosillo + "', 'pCarrosHermosillo': '" + CarrosHermosillo + "', 'pUniformesHermosillo': '" + UniformesHermosillo + "', 'pVacacionesHermosillo': '" + VacacionesHermosillo + "', 'pAguinaldoHermosillo': '" + AguinaldoHermosillo +
            "', 'pCostoNominaHermosilloCCM': '" + CostoNominaHermosilloCCM + "', 'pCostoImssHermosilloCCM': '" + CostoImssHermosilloCCM + "', 'pCostoTotalHermosilloCCM': '" + CostoTotalHermosilloCCM + "', 'pTotalEmpleadosHermosilloCCM': '" + TotalEmpleadosHermosilloCCM + "', 'pPerdidaCambiariaHermosilloCCM': '" + PerdidaCambiariaHermosilloCCM + "', 'pUtilidadCambiariaHermosilloCCM': '" + UtilidadCambiariaHermosilloCCM + "', 'pComisionBancariaHermosilloCCM': '" + ComisionBancariaHermosilloCCM +
            "', 'pGastosAdmonHermosilloCCM': '" + GastosAdmonHermosilloCCM + "', 'pConsumiblesHermosilloCCM': '" + ConsumiblesHermosilloCCM + "', 'pGasolinaHermosilloCCM': '" + GasolinaHermosilloCCM + "', 'pEquipoSeguridadHermosilloCCM': '" + EquipoSeguridadHermosilloCCM + "', 'pInventarioHermosilloCCM': '" + InventarioHermosilloCCM + "', 'pViaticosHermosilloCCM': '" + ViaticosHermosilloCCM + "', 'pCarrosHermosilloCCM': '" + CarrosHermosilloCCM + "', 'pUniformesHermosilloCCM': '" + UniformesHermosilloCCM + "', 'pVacacionesHermosilloCCM': '" + VacacionesHermosilloCCM + "', 'pAguinaldoHermosilloCCM': '" + AguinaldoHermosilloCCM +
            "', 'pCostoNominaChihuahua': '" + CostoNominaChihuahua + "', 'pCostoImssChihuahua': '" + CostoImssChihuahua + "', 'pCostoTotalChihuahua': '" + CostoTotalChihuahua + "', 'pTotalEmpleadosChihuahua': '" + TotalEmpleadosChihuahua + "', 'pPerdidaCambiariaChihuahua': '" + PerdidaCambiariaChihuahua + "', 'pUtilidadCambiariaChihuahua': '" + UtilidadCambiariaChihuahua + "', 'pComisionBancariaChihuahua': '" + ComisionBancariaChihuahua +
            "', 'pGastosAdmonChihuahua': '" + GastosAdmonChihuahua + "', 'pConsumiblesChihuahua': '" + ConsumiblesChihuahua + "', 'pGasolinaChihuahua': '" + GasolinaChihuahua + "', 'pEquipoSeguridadChihuahua': '" + EquipoSeguridadChihuahua + "', 'pInventarioChihuahua': '" + InventarioChihuahua + "', 'pViaticosChihuahua': '" + ViaticosChihuahua + "', 'pCarrosChihuahua': '" + CarrosChihuahua + "', 'pUniformesChihuahua': '" + UniformesChihuahua + "', 'pVacacionesChihuahua': '" + VacacionesChihuahua + "', 'pAguinaldoChihuahua': '" + AguinaldoChihuahua +
            "', 'pCostoNominaChihuahuaCCM': '" + CostoNominaChihuahuaCCM + "', 'pCostoImssChihuahuaCCM': '" + CostoImssChihuahuaCCM + "', 'pCostoTotalChihuahuaCCM': '" + CostoTotalChihuahuaCCM + "', 'pTotalEmpleadosChihuahuaCCM': '" + TotalEmpleadosChihuahuaCCM + "', 'pPerdidaCambiariaChihuahuaCCM': '" + PerdidaCambiariaChihuahuaCCM + "', 'pUtilidadCambiariaChihuahuaCCM': '" + UtilidadCambiariaChihuahuaCCM + "', 'pComisionBancariaChihuahuaCCM': '" + ComisionBancariaChihuahuaCCM +
            "', 'pGastosAdmonChihuahuaCCM': '" + GastosAdmonChihuahuaCCM + "', 'pConsumiblesChihuahuaCCM': '" + ConsumiblesChihuahuaCCM + "', 'pGasolinaChihuahuaCCM': '" + GasolinaChihuahuaCCM + "', 'pEquipoSeguridadChihuahuaCCM': '" + EquipoSeguridadChihuahuaCCM + "', 'pInventarioChihuahuaCCM': '" + InventarioChihuahuaCCM + "', 'pViaticosChihuahuaCCM': '" + ViaticosChihuahuaCCM + "', 'pCarrosChihuahuaCCM': '" + CarrosChihuahuaCCM + "', 'pUniformesChihuahuaCCM': '" + UniformesChihuahuaCCM + "', 'pVacacionesChihuahuaCCM': '" + VacacionesChihuahuaCCM + "', 'pAguinaldoChihuahuaCCM': '" + AguinaldoChihuahuaCCM +
            "', 'pCostoNominaCuautitlan': '" + CostoNominaCuautitlan + "', 'pCostoImssCuautitlan': '" + CostoImssCuautitlan + "', 'pCostoTotalCuautitlan': '" + CostoTotalCuautitlan + "', 'pTotalEmpleadosCuautitlan': '" + TotalEmpleadosCuautitlan + "', 'pPerdidaCambiariaCuautitlan': '" + PerdidaCambiariaCuautitlan + "', 'pUtilidadCambiariaCuautitlan': '" + UtilidadCambiariaCuautitlan + "', 'pComisionBancariaCuautitlan': '" + ComisionBancariaCuautitlan +
            "', 'pGastosAdmonCuautitlan': '" + GastosAdmonCuautitlan + "', 'pConsumiblesCuautitlan': '" + ConsumiblesCuautitlan + "', 'pGasolinaCuautitlan': '" + GasolinaCuautitlan + "', 'pEquipoSeguridadCuautitlan': '" + EquipoSeguridadCuautitlan + "', 'pInventarioCuautitlan': '" + InventarioCuautitlan + "', 'pViaticosCuautitlan': '" + ViaticosCuautitlan + "', 'pCarrosCuautitlan': '" + CarrosCuautitlan + "', 'pUniformesCuautitlan': '" + UniformesCuautitlan + "', 'pVacacionesCuautitlan': '" + VacacionesCuautitlan + "', 'pAguinaldoCuautitlan': '" + AguinaldoCuautitlan +
            "', 'pCostoNominaCuautitlanCCM': '" + CostoNominaCuautitlanCCM + "', 'pCostoImssCuautitlanCCM': '" + CostoImssCuautitlanCCM + "', 'pCostoTotalCuautitlanCCM': '" + CostoTotalCuautitlanCCM + "', 'pTotalEmpleadosCuautitlanCCM': '" + TotalEmpleadosCuautitlanCCM + "', 'pPerdidaCambiariaCuautitlanCCM': '" + PerdidaCambiariaCuautitlanCCM + "', 'pUtilidadCambiariaCuautitlanCCM': '" + UtilidadCambiariaCuautitlanCCM + "', 'pComisionBancariaCuautitlanCCM': '" + ComisionBancariaCuautitlanCCM +
            "', 'pGastosAdmonCuautitlanCCM': '" + GastosAdmonCuautitlanCCM + "', 'pConsumiblesCuautitlanCCM': '" + ConsumiblesCuautitlanCCM + "', 'pGasolinaCuautitlanCCM': '" + GasolinaCuautitlanCCM + "', 'pEquipoSeguridadCuautitlanCCM': '" + EquipoSeguridadCuautitlanCCM + "', 'pInventarioCuautitlanCCM': '" + InventarioCuautitlanCCM + "', 'pViaticosCuautitlanCCM': '" + ViaticosCuautitlanCCM + "', 'pCarrosCuautitlanCCM': '" + CarrosCuautitlanCCM + "', 'pUniformesCuautitlanCCM': '" + UniformesCuautitlanCCM + "', 'pVacacionesCuautitlanCCM': '" + VacacionesCuautitlanCCM + "', 'pAguinaldoCuautitlanCCM': '" + AguinaldoCuautitlanCCM +
            "', 'pCostoNominaIrapuato': '" + CostoNominaIrapuato + "', 'pCostoImssIrapuato': '" + CostoImssIrapuato + "', 'pCostoTotalIrapuato': '" + CostoTotalIrapuato + "', 'pTotalEmpleadosIrapuato': '" + TotalEmpleadosIrapuato + "', 'pPerdidaCambiariaIrapuato': '" + PerdidaCambiariaIrapuato + "', 'pUtilidadCambiariaIrapuato': '" + UtilidadCambiariaIrapuato + "', 'pComisionBancariaIrapuato': '" + ComisionBancariaIrapuato +
            "', 'pGastosAdmonIrapuato': '" + GastosAdmonIrapuato + "', 'pConsumiblesIrapuato': '" + ConsumiblesIrapuato + "', 'pGasolinaIrapuato': '" + GasolinaIrapuato + "', 'pEquipoSeguridadIrapuato': '" + EquipoSeguridadIrapuato + "', 'pInventarioIrapuato': '" + InventarioIrapuato + "', 'pViaticosIrapuato': '" + ViaticosIrapuato + "', 'pCarrosIrapuato': '" + CarrosIrapuato + "', 'pUniformesIrapuato': '" + UniformesIrapuato + "', 'pVacacionesIrapuato': '" + VacacionesIrapuato + "', 'pAguinaldoIrapuato': '" + AguinaldoIrapuato +
            "', 'pCostoNominaIrapuatoCCM': '" + CostoNominaIrapuatoCCM + "', 'pCostoImssIrapuatoCCM': '" + CostoImssIrapuatoCCM + "', 'pCostoTotalIrapuatoCCM': '" + CostoTotalIrapuatoCCM + "', 'pTotalEmpleadosIrapuatoCCM': '" + TotalEmpleadosIrapuatoCCM + "', 'pPerdidaCambiariaIrapuatoCCM': '" + PerdidaCambiariaIrapuatoCCM + "', 'pUtilidadCambiariaIrapuatoCCM': '" + UtilidadCambiariaIrapuatoCCM + "', 'pComisionBancariaIrapuatoCCM': '" + ComisionBancariaIrapuatoCCM +
            "', 'pGastosAdmonIrapuatoCCM': '" + GastosAdmonIrapuatoCCM + "', 'pConsumiblesIrapuatoCCM': '" + ConsumiblesIrapuatoCCM + "', 'pGasolinaIrapuatoCCM': '" + GasolinaIrapuatoCCM + "', 'pEquipoSeguridadIrapuatoCCM': '" + EquipoSeguridadIrapuatoCCM + "', 'pInventarioIrapuatoCCM': '" + InventarioIrapuatoCCM + "', 'pViaticosIrapuatoCCM': '" + ViaticosIrapuatoCCM + "', 'pCarrosIrapuatoCCM': '" + CarrosIrapuatoCCM + "', 'pUniformesIrapuatoCCM': '" + UniformesIrapuatoCCM + "', 'pVacacionesIrapuatoCCM': '" + VacacionesIrapuatoCCM + "', 'pAguinaldoIrapuatoCCM': '" + AguinaldoIrapuatoCCM +
            "', 'pCostoNominaQueretaro': '" + CostoNominaQueretaro + "', 'pCostoImssQueretaro': '" + CostoImssQueretaro + "', 'pCostoTotalQueretaro': '" + CostoTotalQueretaro + "', 'pTotalEmpleadosQueretaro': '" + TotalEmpleadosQueretaro + "', 'pPerdidaCambiariaQueretaro': '" + PerdidaCambiariaQueretaro + "', 'pUtilidadCambiariaQueretaro': '" + UtilidadCambiariaQueretaro + "', 'pComisionBancariaQueretaro': '" + ComisionBancariaQueretaro +
            "', 'pGastosAdmonQueretaro': '" + GastosAdmonQueretaro + "', 'pConsumiblesQueretaro': '" + ConsumiblesQueretaro + "', 'pGasolinaQueretaro': '" + GasolinaQueretaro + "', 'pEquipoSeguridadQueretaro': '" + EquipoSeguridadQueretaro + "', 'pInventarioQueretaro': '" + InventarioQueretaro + "', 'pViaticosQueretaro': '" + ViaticosQueretaro + "', 'pCarrosQueretaro': '" + CarrosQueretaro + "', 'pUniformesQueretaro': '" + UniformesQueretaro + "', 'pVacacionesQueretaro': '" + VacacionesQueretaro + "', 'pAguinaldoQueretaro': '" + AguinaldoQueretaro +
            "', 'pCostoNominaQueretaroCCM': '" + CostoNominaQueretaroCCM + "', 'pCostoImssQueretaroCCM': '" + CostoImssQueretaroCCM + "', 'pCostoTotalQueretaroCCM': '" + CostoTotalQueretaroCCM + "', 'pTotalEmpleadosQueretaroCCM': '" + TotalEmpleadosQueretaroCCM + "', 'pPerdidaCambiariaQueretaroCCM': '" + PerdidaCambiariaQueretaroCCM + "', 'pUtilidadCambiariaQueretaroCCM': '" + UtilidadCambiariaQueretaroCCM + "', 'pComisionBancariaQueretaroCCM': '" + ComisionBancariaQueretaroCCM +
            "', 'pGastosAdmonQueretaroCCM': '" + GastosAdmonQueretaroCCM + "', 'pConsumiblesQueretaroCCM': '" + ConsumiblesQueretaroCCM + "', 'pGasolinaQueretaroCCM': '" + GasolinaQueretaroCCM + "', 'pEquipoSeguridadQueretaroCCM': '" + EquipoSeguridadQueretaroCCM + "', 'pInventarioQueretaroCCM': '" + InventarioQueretaroCCM + "', 'pViaticosQueretaroCCM': '" + ViaticosQueretaroCCM + "', 'pCarrosQueretaroCCM': '" + CarrosQueretaroCCM + "', 'pUniformesQueretaroCCM': '" + UniformesQueretaroCCM + "', 'pVacacionesQueretaroCCM': '" + VacacionesQueretaroCCM + "', 'pAguinaldoQueretaroCCM': '" + AguinaldoQueretaroCCM +
            "', 'pCostoNominaTecate': '" + CostoNominaTecate + "', 'pCostoImssTecate': '" + CostoImssTecate + "', 'pCostoTotalTecate': '" + CostoTotalTecate + "', 'pTotalEmpleadosTecate': '" + TotalEmpleadosTecate + "', 'pPerdidaCambiariaTecate': '" + PerdidaCambiariaTecate + "', 'pUtilidadCambiariaTecate': '" + UtilidadCambiariaTecate + "', 'pComisionBancariaTecate': '" + ComisionBancariaTecate +
            "', 'pGastosAdmonTecate': '" + GastosAdmonTecate + "', 'pConsumiblesTecate': '" + ConsumiblesTecate + "', 'pGasolinaTecate': '" + GasolinaTecate + "', 'pEquipoSeguridadTecate': '" + EquipoSeguridadTecate + "', 'pInventarioTecate': '" + InventarioTecate + "', 'pViaticosTecate': '" + ViaticosTecate + "', 'pCarrosTecate': '" + CarrosTecate + "', 'pUniformesTecate': '" + UniformesTecate + "', 'pVacacionesTecate': '" + VacacionesTecate + "', 'pAguinaldoTecate': '" + AguinaldoTecate +
            "', 'pCostoNominaUSA': '" + CostoNominaUSA + "', 'pCostoImssUSA': '" + CostoImssUSA + "', 'pCostoTotalUSA': '" + CostoTotalUSA + "', 'pTotalEmpleadosUSA': '" + TotalEmpleadosUSA + "', 'pPerdidaCambiariaUSA': '" + PerdidaCambiariaUSA + "', 'pUtilidadCambiariaUSA': '" + UtilidadCambiariaUSA + "', 'pComisionBancariaUSA': '" + ComisionBancariaUSA +
            "', 'pGastosAdmonUSA': '" + GastosAdmonUSA + "', 'pConsumiblesUSA': '" + ConsumiblesUSA + "', 'pGasolinaUSA': '" + GasolinaUSA + "', 'pEquipoSeguridadUSA': '" + EquipoSeguridadUSA + "', 'pInventarioUSA': '" + InventarioUSA + "', 'pViaticosUSA': '" + ViaticosUSA + "', 'pCarrosUSA': '" + CarrosUSA + "', 'pUniformesUSA': '" + UniformesUSA + "', 'pVacacionesUSA': '" + VacacionesUSA + "', 'pAguinaldoUSA': '" + AguinaldoUSA +
            "', 'pProyectosGlobal': '" + ProyectosGlobal + "', 'pProyectosHermosillo': '" + ProyectosHermosillo + "', 'pProyectosHermosilloCCM': '" + ProyectosHermosilloCCM + "', 'pProyectosChihuahua': '" + ProyectosChihuahua + "', 'pProyectosChihuahuaCCM': '" + ProyectosChihuahuaCCM + "', 'pProyectosCuautitlan': '" + ProyectosCuautitlan + "', 'pProyectosCuautitlanCCM': '" + ProyectosCuautitlanCCM + "', 'pProyectosIrapuato': '" + ProyectosIrapuato + "', 'pProyectosIrapuatoCCM': '" + ProyectosIrapuatoCCM +
            "', 'pProyectosQueretaro': '" + ProyectosQueretaro + "', 'pProyectosQueretaroCCM': '" + ProyectosQueretaroCCM + "', 'pProyectosTecate': '" + ProyectosTecate + "', 'pProyectosUSA': '" + ProyectosUSA + 
            "', 'pCotizadoGlobal': '" + CotizadoGlobal + "', 'pPorcentajeGlobal': '" + PorcentajeGlobal + "', 'pCotizadoHermosillo': '" + CotizadoHermosillo + "', 'pPorcentajeHermosillo': '" + PorcentajeHermosillo + "', 'pCotizadoHermosilloCCM': '" + CotizadoHermosilloCCM + "', 'pPorcentajeHermosilloCCM': '" + PorcentajeHermosilloCCM + "', 'pCotizadoChihuahua': '" + CotizadoChihuahua + "', 'pPorcentajeChihuahua': '" + PorcentajeChihuahua +
            "', 'pCotizadoChihuahuaCCM': '" + CotizadoChihuahuaCCM + "', 'pPorcentajeChihuahuaCCM': '" + PorcentajeChihuahuaCCM + "', 'pCotizadoCuautitlan': '" + CotizadoCuautitlan + "', 'pPorcentajeCuautitlan': '" + PorcentajeCuautitlan + "', 'pCotizadoCuautitlanCCM': '" + CotizadoCuautitlanCCM + "', 'pPorcentajeCuautitlanCCM': '" + PorcentajeCuautitlanCCM + "', 'pCotizadoIrapuato': '" + CotizadoIrapuato + "', 'pPorcentajeIrapuato': '" + PorcentajeIrapuato +
            "', 'pCotizadoIrapuatoCCM': '" + CotizadoIrapuatoCCM + "', 'pPorcentajeIrapuatoCCM': '" + PorcentajeIrapuatoCCM + "', 'pCotizadoQueretaro': '" + CotizadoQueretaro + "', 'pPorcentajeQueretaro': '" + PorcentajeQueretaro + "', 'pCotizadoQueretaroCCM': '" + CotizadoQueretaroCCM + "', 'pPorcentajeQueretaroCCM': '" + PorcentajeQueretaroCCM + "', 'pCotizadoTecate': '" + CotizadoTecate + "', 'pPorcentajeTecate': '" + PorcentajeTecate + "', 'pCotizadoUSA': '" + CotizadoUSA + "', 'pPorcentajeUSA': '" + PorcentajeUSA + 
            "', 'pFechaIni': '" + $("#lblFechaIni").text() + "', 'pFechaFin': '" + $("#lblFechaFin").text() + 
            "', 'pTotalGlobal': '" + TotalGlobal + "', 'pTotalHermosillo': '" + TotalHermosillo + "', 'pTotalHermosilloCCM': '" + TotalHermosilloCCM + "', 'pTotalChihuahua': '" + TotalChihuahua + 
            "', 'pTotalChihuahuaCCM': '" + TotalChihuahuaCCM + "', 'pTotalCuautitlan': '" + TotalCuautitlan + "', 'pTotalCuautitlanCCM': '" + TotalCuautitlanCCM + "', 'pTotalIrapuato': '" + TotalIrapuato + 
            "', 'pTotalIrapuatoCCM': '" + TotalIrapuatoCCM + "', 'pTotalQueretaro': '" + TotalQueretaro + "', 'pTotalQueretaroCCM': '" + TotalQueretaroCCM + "', 'pTotalTecate': '" + TotalTecate + "', 'pTotalUSA': '" + TotalUSA + 
            "'}";
        //console.log(params);

        $.ajax({
            dataType: "json",
            async: true,
            url: "CostosIndirectos.aspx/GuardarCostoIndirecto",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                //location.href = './frmProjects.aspx';  
                //debugger;
                swal({
                    title: msg.d,
                    timer: 3000
                });
                //$('#TablaFacturas').bootstrapTable('destroy');

               

            },
            error: function (xhr, ajaxOptions, thrownError) {
                swal({
                    title: 'Error, intenta de nuevo',
                    timer: 3000
                });
            }
        });

    });


    function CargarCostosIndirectos(Opcion, Sucursal) {

        var parametros = "{'Opcion': '" + Opcion + "', 'Sucursal': '" + Sucursal + "'}";
        $.ajax({
            dataType: "json",
            url: "CostosIndirectos.aspx/CargarCostosIndirectos",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var json = JSON.parse(data.d);

                data = json;

                $('#TablaCostoIndirecto').bootstrapTable({
                    data: data,
                    detailView: false,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'FechaIni',
                    uniqueId: 'FechaIni',
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

                
                

            }
        });
    }

    function formatoPorcentajeFormatter(value) {
        return formato_numero(value, 4, ".", "");
    }
});



function dateFormat(value, row, index) {
    return moment(value).format('YYYY-MM-DD');
}

function formatoMonedaFormatter(value) {
    return formato_numero(value, 2, ".", ",");
}

function formatoPorcentajeFormatter(value) {
    return formato_numero(value, 4, ".", "");
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

function accionFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Editar" class="btn btn-warning editarDatos"> <i class="icon_pencil"></i></span>',
        '</div>'
    ].join(' ');
}

window.accionEvents = {
    'click .editarDatos': function (e, value, row, index) {
        var fechaIni = row.FechaIni;
        var fechaFin = row.FechaFin;

        //document.getElementById('idOCComentario').textContent = idOrdenCompra;
        var params = "{'FechaIni': '" + fechaIni + "', 'FechaFin': '" + fechaFin + "'}";
        $.ajax({
            async: true,
            url: "CostosIndirectos.aspx/VerCostosIndirectos",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                
                //var datos = "";
                //var nodoTRAgregar = "";

                var JsonCombos;
                var jsonArray = $.parseJSON(data.d);
                //debugger;
                //$('#TablaPrincipalComentarios tbody').html('');
                $.each(jsonArray, function (index, value) {

                    $('#lblFechaIni').text(value.FechaIni.substring(0, 10));
                    $('#lblFechaFin').text(value.FechaFin.substring(0, 10));

                    $("#txtNominaGlobal").val(formatoMonedaFormatter(value.NominaGlobal));
                    $('#txtCostoImss').val(formatoMonedaFormatter(value.ImssGlobal));
                    $('#txtInteresGlobal').val(formatoMonedaFormatter(value.InteresGlobal));
                    $('#txtCostoTotal').val(formatoMonedaFormatter(value.TotalGlobal));
                    $('#txtTotalEmpleados').val(formatoMonedaFormatter(value.TotalEmpleadosGlobal));
                    $('#lblTotalGlobal').text(formatoMonedaFormatter(value.NominaGlobal + value.ImssGlobal + value.InteresGlobal + value.TotalGlobal));
                    $('#lblTotalProyectos').text(formatoMonedaFormatter(value.TotalProyectos));
                    $('#lblTotalCotizado').text(formatoMonedaFormatter(value.TotalCotizado));
                    $('#lblTotalPorcentaje').text(formatoPorcentajeFormatter(value.Porcentaje));

                    $('#txtVacacionesGlobal').val(formatoMonedaFormatter(value.Vacaciones));
                    $('#txtAguinaldoGlobal').val(formatoMonedaFormatter(value.Aguinaldo));

                    /*HERMOSILLO*/
                    $("#txtNominaHermosillo").val(formatoMonedaFormatter(value.NominaHermosillo));
                    $("#txtCostoImssHermosillo").val(formatoMonedaFormatter(value.ImssHermosillo));
                    $("#txtCostoTotalHermosillo").val(formatoMonedaFormatter(value.TotalHermosillo));
                    $("#txtTotalEmpleadosHermosillo").val(formatoMonedaFormatter(value.TotalEmpleadosHermosillo));
                    $("#txtPerdidaCambiariaHermosillo").val(formatoMonedaFormatter(value.PerdidaCambiariaHermosillo));
                    $("#txtUtilidadCambiariaHermosillo").val(formatoMonedaFormatter(value.UtilidadCambiariaHermosillo));
                    $("#txtComisionBancariaHermosillo").val(formatoMonedaFormatter(value.ComisionesBancariasHermosillo));
                    $("#txtGastosAdmonHermosillo").val(formatoMonedaFormatter(value.GastosAdmonHermosillo));
                    $("#txtConsumiblesHermosillo").val(formatoMonedaFormatter(value.ConsumiblesTallerHermosillo));
                    $("#txtGasolinaHermosillo").val(formatoMonedaFormatter(value.GasolinaHermosillo));
                    $("#txtEquipoSeguridadHermosillo").val(formatoMonedaFormatter(value.EquipoSeguridadHermosillo));
                    $("#txtInventarioSisaHermosillo").val(formatoMonedaFormatter(value.InventarioHermosillo));
                    $("#txtViaticosHermosillo").val(formatoMonedaFormatter(value.ViaticosHermosillo));
                    $("#txtCarrosHermosillo").val(formatoMonedaFormatter(value.CarrosHermosillo));
                    $("#txtUniformesHermosillo").val(formatoMonedaFormatter(value.UniformesHermosillo));
                    $('#txtVacacionesHermosillo').val(formatoMonedaFormatter(value.VacacionesHermosillo));
                    $('#txtAguinaldoHermosillo').val(formatoMonedaFormatter(value.AguinaldoHermosillo));

                    var totalHermosillo = (value.NominaHermosillo + value.ImssHermosillo + value.TotalEmpleadosHermosillo + value.PerdidaCambiariaHermosillo + value.UtilidadCambiariaHermosillo + value.ComisionesBancariasHermosillo + value.GastosAdmonHermosillo + value.ConsumiblesTallerHermosillo + value.GasolinaHermosillo + value.EquipoSeguridadHermosillo + value.InventarioHermosillo + value.ViaticosHermosillo + value.CarrosHermosillo + value.UniformesHermosillo + value.VacacionesHermosillo + value.AguinaldoHermosillo);
                    $('#lblTotalHermosillo').text(formatoMonedaFormatter(totalHermosillo));
                    $('#lblTotalProyectosHermosillo').text(formatoMonedaFormatter(value.TotalProyectosHermosillo));
                    $('#lblTotalCotizadoHermosillo').text(formatoMonedaFormatter(value.TotalCotizadoHermosillo));
                    $('#lblTotalPorcentajeHermosillo').text(formatoPorcentajeFormatter(value.PorcentajeHermosillo));

                    /*CHIHUAHUA*/
                    $("#txtNominaChihuahua").val(formatoMonedaFormatter(value.NominaChihuahua));
                    $("#txtCostoImssChihuahua").val(formatoMonedaFormatter(value.ImssChihuahua));
                    $("#txtCostoTotalChihuahua").val(formatoMonedaFormatter(value.TotalChihuahua));
                    $("#txtTotalEmpleadosChihuahua").val(formatoMonedaFormatter(value.TotalEmpleadosChihuahua));
                    $("#txtPerdidaCambiariaChihuahua").val(formatoMonedaFormatter(value.PerdidaCambiariaChihuahua));
                    $("#txtUtilidadCambiariaChihuahua").val(formatoMonedaFormatter(value.UtilidadCambiariaChihuahua));
                    $("#txtComisionBancariaChihuahua").val(formatoMonedaFormatter(value.ComisionesBancariasChihuahua));
                    $("#txtGastosAdmonChihuahua").val(formatoMonedaFormatter(value.GastosAdmonChihuahua));
                    $("#txtConsumiblesChihuahua").val(formatoMonedaFormatter(value.ConsumiblesTallerChihuahua));
                    $("#txtGasolinaChihuahua").val(formatoMonedaFormatter(value.GasolinaChihuahua));
                    $("#txtEquipoSeguridadChihuahua").val(formatoMonedaFormatter(value.EquipoSeguridadChihuahua));
                    $("#txtInventarioSisaChihuahua").val(formatoMonedaFormatter(value.InventarioChihuahua));
                    $("#txtViaticosChihuahua").val(formatoMonedaFormatter(value.ViaticosChihuahua));
                    $("#txtCarrosChihuahua").val(formatoMonedaFormatter(value.CarrosChihuahua));
                    $("#txtUniformesChihuahua").val(formatoMonedaFormatter(value.UniformesChihuahua));
                    $('#txtVacacionesChihuahua').val(formatoMonedaFormatter(value.VacacionesChihuahua));
                    $('#txtAguinaldoChihuahua').val(formatoMonedaFormatter(value.AguinaldoChihuahua));

                    var totalChihuahua = (value.NominaChihuahua + value.ImssChihuahua + value.TotalEmpleadosChihuahua + value.PerdidaCambiariaChihuahua + value.UtilidadCambiariaChihuahua + value.ComisionesBancariasChihuahua + value.GastosAdmonChihuahua + value.ConsumiblesTallerChihuahua + value.GasolinaChihuahua + value.EquipoSeguridadChihuahua + value.InventarioChihuahua + value.ViaticosChihuahua + value.CarrosChihuahua + value.UniformesChihuahua + value.VacacionesChihuahua + value.AguinaldoChihuahua);
                    $('#lblTotalChihuahua').text(formatoMonedaFormatter(totalChihuahua));
                    $('#lblTotalProyectosChihuahua').text(formatoMonedaFormatter(value.TotalProyectosChihuahua));
                    $('#lblTotalCotizadoChihuahua').text(formatoMonedaFormatter(value.TotalCotizadoChihuahua));
                    $('#lblTotalPorcentajeChihuahua').text(formatoPorcentajeFormatter(value.PorcentajeChihuahua));
                    /*CUAUTITLAN*/
                    $("#txtNominaCuautitlan").val(formatoMonedaFormatter(value.NominaCuautitlan));
                    $("#txtCostoImssCuautitlan").val(formatoMonedaFormatter(value.ImssCuautitlan));
                    $("#txtCostoTotalCuautitlan").val(formatoMonedaFormatter(value.TotalCuautitlan));
                    $("#txtTotalEmpleadosCuautitlan").val(formatoMonedaFormatter(value.TotalEmpleadosCuautitlan));
                    $("#txtPerdidaCambiariaCuautitlan").val(formatoMonedaFormatter(value.PerdidaCambiariaCuautitlan));
                    $("#txtUtilidadCambiariaCuautitlan").val(formatoMonedaFormatter(value.UtilidadCambiariaCuautitlan));
                    $("#txtComisionBancariaCuautitlan").val(formatoMonedaFormatter(value.ComisionesBancariasCuautitlan));
                    $("#txtGastosAdmonCuautitlan").val(formatoMonedaFormatter(value.GastosAdmonCuautitlan));
                    $("#txtConsumiblesCuautitlan").val(formatoMonedaFormatter(value.ConsumiblesTallerCuautitlan));
                    $("#txtGasolinaCuautitlan").val(formatoMonedaFormatter(value.GasolinaCuautitlan));
                    $("#txtEquipoSeguridadCuautitlan").val(formatoMonedaFormatter(value.EquipoSeguridadCuautitlan));
                    $("#txtInventarioSisaCuautitlan").val(formatoMonedaFormatter(value.InventarioCuautitlan));
                    $("#txtViaticosCuautitlan").val(formatoMonedaFormatter(value.ViaticosCuautitlan));
                    $("#txtCarrosCuautitlan").val(formatoMonedaFormatter(value.CarrosCuautitlan));
                    $("#txtUniformesCuautitlan").val(formatoMonedaFormatter(value.UniformesCuautitlan));
                    $('#txtVacacionesCuautitlan').val(formatoMonedaFormatter(value.VacacionesCuautitlan));
                    $('#txtAguinaldoCuautitlan').val(formatoMonedaFormatter(value.AguinaldoCuautitlan));

                    var totalCuautitlan = (value.NominaCuautitlan + value.ImssCuautitlan + value.TotalEmpleadosCuautitlan + value.PerdidaCambiariaCuautitlan + value.UtilidadCambiariaCuautitlan + value.ComisionesBancariasCuautitlan + value.GastosAdmonCuautitlan + value.ConsumiblesTallerCuautitlan + value.GasolinaCuautitlan + value.EquipoSeguridadCuautitlan + value.InventarioCuautitlan + value.ViaticosCuautitlan + value.CarrosCuautitlan + value.UniformesCuautitlan + value.VacacionesCuautitlan + value.AguinaldoCuautitlan);
                    $('#lblTotalCuautitlan').text(formatoMonedaFormatter(totalCuautitlan));
                    $('#lblTotalProyectosCuautitlan').text(formatoMonedaFormatter(value.TotalProyectosCuautitlan));
                    $('#lblTotalCotizadoCuautitlan').text(formatoMonedaFormatter(value.TotalCotizadoCuautitlan));
                    $('#lblTotalPorcentajeCuautitlan').text(formatoPorcentajeFormatter(value.PorcentajeCuautitlan));

                    /*IRAPUATO*/
                    $("#txtNominaIrapuato").val(formatoMonedaFormatter(value.NominaIrapuato));
                    $("#txtCostoImssIrapuato").val(formatoMonedaFormatter(value.ImssIrapuato));
                    $("#txtCostoTotalIrapuato").val(formatoMonedaFormatter(value.TotalIrapuato));
                    $("#txtTotalEmpleadosIrapuato").val(formatoMonedaFormatter(value.TotalEmpleadosIrapuato));
                    $("#txtPerdidaCambiariaIrapuato").val(formatoMonedaFormatter(value.PerdidaCambiariaIrapuato));
                    $("#txtUtilidadCambiariaIrapuato").val(formatoMonedaFormatter(value.UtilidadCambiariaIrapuato));
                    $("#txtComisionBancariaIrapuato").val(formatoMonedaFormatter(value.ComisionesBancariasIrapuato));
                    $("#txtGastosAdmonIrapuato").val(formatoMonedaFormatter(value.GastosAdmonIrapuato));
                    $("#txtConsumiblesIrapuato").val(formatoMonedaFormatter(value.ConsumiblesTallerIrapuato));
                    $("#txtGasolinaIrapuato").val(formatoMonedaFormatter(value.GasolinaIrapuato));
                    $("#txtEquipoSeguridadIrapuato").val(formatoMonedaFormatter(value.EquipoSeguridadIrapuato));
                    $("#txtInventarioSisaIrapuato").val(formatoMonedaFormatter(value.InventarioIrapuato));
                    $("#txtViaticosIrapuato").val(formatoMonedaFormatter(value.ViaticosIrapuato));
                    $("#txtCarrosIrapuato").val(formatoMonedaFormatter(value.CarrosIrapuato));
                    $("#txtUniformesIrapuato").val(formatoMonedaFormatter(value.UniformesIrapuato));
                    $('#txtVacacionesIrapuato').val(formatoMonedaFormatter(value.VacacionesIrapuato));
                    $('#txtAguinaldoIrapuato').val(formatoMonedaFormatter(value.AguinaldoIrapuato));

                    var totalIrapuato = (value.NominaIrapuato + value.ImssIrapuato + value.TotalEmpleadosIrapuato + value.PerdidaCambiariaIrapuato + value.UtilidadCambiariaIrapuato + value.ComisionesBancariasIrapuato + value.GastosAdmonIrapuato + value.ConsumiblesTallerIrapuato + value.GasolinaIrapuato + value.EquipoSeguridadIrapuato + value.InventarioIrapuato + value.ViaticosIrapuato + value.CarrosIrapuato + value.UniformesIrapuato + value.VacacionesIrapuato + value.AguinaldoIrapuato);
                    $('#lblTotalIrapuato').text(formatoMonedaFormatter(totalIrapuato));
                    $('#lblTotalProyectosIrapuato').text(formatoMonedaFormatter(value.TotalProyectosIrapuato));
                    $('#lblTotalCotizadoIrapuato').text(formatoMonedaFormatter(value.TotalCotizadoIrapuato));
                    $('#lblTotalPorcentajeIrapuato').text(formatoPorcentajeFormatter(value.PorcentajeIrapuato));
                    /*QUERETARO*/
                    $("#txtNominaQueretaro").val(formatoMonedaFormatter(value.NominaQueretaro));
                    $("#txtCostoImssQueretaro").val(formatoMonedaFormatter(value.ImssQueretaro));
                    $("#txtCostoTotalQueretaro").val(formatoMonedaFormatter(value.TotalQueretaro));
                    $("#txtTotalEmpleadosQueretaro").val(formatoMonedaFormatter(value.TotalEmpleadosQueretaro));
                    $("#txtPerdidaCambiariaQueretaro").val(formatoMonedaFormatter(value.PerdidaCambiariaQueretaro));
                    $("#txtUtilidadCambiariaQueretaro").val(formatoMonedaFormatter(value.UtilidadCambiariaQueretaro));
                    $("#txtComisionBancariaQueretaro").val(formatoMonedaFormatter(value.ComisionesBancariasQueretaro));
                    $("#txtGastosAdmonQueretaro").val(formatoMonedaFormatter(value.GastosAdmonQueretaro));
                    $("#txtConsumiblesQueretaro").val(formatoMonedaFormatter(value.ConsumiblesTallerQueretaro));
                    $("#txtGasolinaQueretaro").val(formatoMonedaFormatter(value.GasolinaQueretaro));
                    $("#txtEquipoSeguridadQueretaro").val(formatoMonedaFormatter(value.EquipoSeguridadQueretaro));
                    $("#txtInventarioSisaQueretaro").val(formatoMonedaFormatter(value.InventarioQueretaro));
                    $("#txtViaticosQueretaro").val(formatoMonedaFormatter(value.ViaticosQueretaro));
                    $("#txtCarrosQueretaro").val(formatoMonedaFormatter(value.CarrosQueretaro));
                    $("#txtUniformesQueretaro").val(formatoMonedaFormatter(value.UniformesQueretaro));
                    $('#txtVacacionesQueretaro').val(formatoMonedaFormatter(value.VacacionesQueretaro));
                    $('#txtAguinaldoQueretaro').val(formatoMonedaFormatter(value.AguinaldoQueretaro));

                    var totalQueretaro = (value.NominaQueretaro + value.ImssQueretaro + value.TotalEmpleadosQueretaro + value.PerdidaCambiariaQueretaro + value.UtilidadCambiariaQueretaro + value.ComisionesBancariasQueretaro + value.GastosAdmonQueretaro + value.ConsumiblesTallerQueretaro + value.GasolinaQueretaro + value.EquipoSeguridadQueretaro + value.InventarioQueretaro + value.ViaticosQueretaro + value.CarrosQueretaro + value.UniformesQueretaro + value.VacacionesQueretaro + value.AguinaldoQueretaro);
                    $('#lblTotalQueretaro').text(formatoMonedaFormatter(totalQueretaro));
                    $('#lblTotalProyectosQueretaro').text(formatoMonedaFormatter(value.TotalProyectosQueretaro));
                    $('#lblTotalCotizadoQueretaro').text(formatoMonedaFormatter(value.TotalCotizadoQueretaro));
                    $('#lblTotalPorcentajeQueretaro').text(formatoPorcentajeFormatter(value.PorcentajeQueretaro));
                    /*TECATE*/
                    $("#txtNominaTecate").val(formatoMonedaFormatter(value.NominaTecate));
                    $("#txtCostoImssTecate").val(formatoMonedaFormatter(value.ImssTecate));
                    $("#txtCostoTotalTecate").val(formatoMonedaFormatter(value.TotalTecate));
                    $("#txtTotalEmpleadosTecate").val(formatoMonedaFormatter(value.TotalEmpleadosTecate));
                    $("#txtPerdidaCambiariaTecate").val(formatoMonedaFormatter(value.PerdidaCambiariaTecate));
                    $("#txtUtilidadCambiariaTecate").val(formatoMonedaFormatter(value.UtilidadCambiariaTecate));
                    $("#txtComisionBancariaTecate").val(formatoMonedaFormatter(value.ComisionesBancariasTecate));
                    $("#txtGastosAdmonTecate").val(formatoMonedaFormatter(value.GastosAdmonTecate));
                    $("#txtConsumiblesTecate").val(formatoMonedaFormatter(value.ConsumiblesTallerTecate));
                    $("#txtGasolinaTecate").val(formatoMonedaFormatter(value.GasolinaTecate));
                    $("#txtEquipoSeguridadTecate").val(formatoMonedaFormatter(value.EquipoSeguridadTecate));
                    $("#txtInventarioSisaTecate").val(formatoMonedaFormatter(value.InventarioTecate));
                    $("#txtViaticosTecate").val(formatoMonedaFormatter(value.ViaticosTecate));
                    $("#txtCarrosTecate").val(formatoMonedaFormatter(value.CarrosTecate));
                    $("#txtUniformesTecate").val(formatoMonedaFormatter(value.UniformesTecate));
                    $('#txtVacacionesTecate').val(formatoMonedaFormatter(value.VacacionesTecate));
                    $('#txtAguinaldoTecate').val(formatoMonedaFormatter(value.AguinaldoTecate));

                    var totalTecate = (value.NominaTecate + value.ImssTecate + value.TotalEmpleadosTecate + value.PerdidaCambiariaTecate + value.UtilidadCambiariaTecate + value.ComisionesBancariasTecate + value.GastosAdmonTecate + value.ConsumiblesTallerTecate + value.GasolinaTecate + value.EquipoSeguridadTecate + value.InventarioTecate + value.ViaticosTecate + value.CarrosTecate + value.UniformesTecate + value.VacacionesTecate + value.AguinaldoTecate);
                    $('#lblTotalTecate').text(formatoMonedaFormatter(totalTecate));
                    $('#lblTotalProyectosTecate').text(formatoMonedaFormatter(value.TotalProyectosTecate));
                    $('#lblTotalCotizadoTecate').text(formatoMonedaFormatter(value.TotalCotizadoTecate));
                    $('#lblTotalPorcentajeTecate').text(formatoPorcentajeFormatter(value.PorcentajeTecate));
                    /*USA*/
                    $("#txtNominaUSA").val(formatoMonedaFormatter(value.NominaUSA));
                    $("#txtCostoImssUSA").val(formatoMonedaFormatter(value.ImssUSA));
                    $("#txtCostoTotalUSA").val(formatoMonedaFormatter(value.TotalUSA));
                    $("#txtTotalEmpleadosUSA").val(formatoMonedaFormatter(value.TotalEmpleadosUSA));
                    $("#txtPerdidaCambiariaUSA").val(formatoMonedaFormatter(value.PerdidaCambiariaUSA));
                    $("#txtUtilidadCambiariaUSA").val(formatoMonedaFormatter(value.UtilidadCambiariaUSA));
                    $("#txtComisionBancariaUSA").val(formatoMonedaFormatter(value.ComisionesBancariasUSA));
                    $("#txtGastosAdmonUSA").val(formatoMonedaFormatter(value.GastosAdmonUSA));
                    $("#txtConsumiblesUSA").val(formatoMonedaFormatter(value.ConsumiblesTallerUSA));
                    $("#txtGasolinaUSA").val(formatoMonedaFormatter(value.GasolinaUSA));
                    $("#txtEquipoSeguridadUSA").val(formatoMonedaFormatter(value.EquipoSeguridadUSA));
                    $("#txtInventarioSisaUSA").val(formatoMonedaFormatter(value.InventarioUSA));
                    $("#txtViaticosUSA").val(formatoMonedaFormatter(value.ViaticosUSA));
                    $("#txtCarrosUSA").val(formatoMonedaFormatter(value.CarrosUSA));
                    $("#txtUniformesUSA").val(formatoMonedaFormatter(value.UniformesUSA));
                    $('#txtVacacionesUSA').val(formatoMonedaFormatter(value.VacacionesUSA));
                    $('#txtAguinaldoUSA').val(formatoMonedaFormatter(value.AguinaldoUSA));

                    var totalUSA = (value.NominaUSA + value.ImssUSA + value.TotalEmpleadosUSA + value.PerdidaCambiariaUSA + value.UtilidadCambiariaUSA + value.ComisionesBancariasUSA + value.GastosAdmonUSA + value.ConsumiblesTallerUSA + value.GasolinaUSA + value.EquipoSeguridadUSA + value.InventarioUSA + value.ViaticosUSA + value.CarrosUSA + value.UniformesUSA + value.VacacionesUSA + value.AguinaldoUSA);
                    $('#lblTotalUSA').text(formatoMonedaFormatter(totalUSA));
                    $('#lblTotalProyectosUSA').text(formatoMonedaFormatter(value.TotalProyectosUSA));
                    $('#lblTotalCotizadoUSA').text(formatoMonedaFormatter(value.TotalCotizadoUSA));
                    $('#lblTotalPorcentajeUSA').text(formatoPorcentajeFormatter(value.PorcentajeUSA));
                    /*HERMOSILLO CCM*/
                    $("#txtNominaHermosilloCCM").val(formatoMonedaFormatter(value.NominaHermosilloCCM));
                    $("#txtCostoImssHermosilloCCM").val(formatoMonedaFormatter(value.ImssHermosilloCCM));
                    $("#txtCostoTotalHermosilloCCM").val(formatoMonedaFormatter(value.TotalHermosilloCCM));
                    $("#txtTotalEmpleadosHermosilloCCM").val(formatoMonedaFormatter(value.TotalEmpleadosHermosilloCCM));
                    $("#txtPerdidaCambiariaHermosilloCCM").val(formatoMonedaFormatter(value.PerdidaCambiariaHermosilloCCM));
                    $("#txtUtilidadCambiariaHermosilloCCM").val(formatoMonedaFormatter(value.UtilidadCambiariaHermosilloCCM));
                    $("#txtComisionBancariaHermosilloCCM").val(formatoMonedaFormatter(value.ComisionesBancariasHermosilloCCM));
                    $("#txtGastosAdmonHermosilloCCM").val(formatoMonedaFormatter(value.GastosAdmonHermosilloCCM));
                    $("#txtConsumiblesHermosilloCCM").val(formatoMonedaFormatter(value.ConsumiblesTallerHermosilloCCM));
                    $("#txtGasolinaHermosilloCCM").val(formatoMonedaFormatter(value.GasolinaHermosilloCCM));
                    $("#txtEquipoSeguridadHermosilloCCM").val(formatoMonedaFormatter(value.EquipoSeguridadHermosilloCCM));
                    $("#txtInventarioSisaHermosilloCCM").val(formatoMonedaFormatter(value.InventarioHermosilloCCM));
                    $("#txtViaticosHermosilloCCM").val(formatoMonedaFormatter(value.ViaticosHermosilloCCM));
                    $("#txtCarrosHermosilloCCM").val(formatoMonedaFormatter(value.CarrosHermosilloCCM));
                    $("#txtUniformesHermosilloCCM").val(formatoMonedaFormatter(value.UniformesHermosilloCCM));
                    $('#txtVacacionesHermosilloCCM').val(formatoMonedaFormatter(value.VacacionesHermosilloCCM));
                    $('#txtAguinaldoHermosilloCCM').val(formatoMonedaFormatter(value.AguinaldoHermosilloCCM));

                    var totalHermosilloCCM = (value.NominaHermosilloCCM + value.ImssHermosilloCCM + value.TotalEmpleadosHermosilloCCM + value.PerdidaCambiariaHermosilloCCM + value.UtilidadCambiariaHermosilloCCM + value.ComisionesBancariasHermosilloCCM + value.GastosAdmonHermosilloCCM + value.ConsumiblesTallerHermosilloCCM + value.GasolinaHermosilloCCM + value.EquipoSeguridadHermosilloCCM + value.InventarioHermosilloCCM + value.ViaticosHermosilloCCM + value.CarrosHermosilloCCM + value.UniformesHermosilloCCM + value.VacacionesHermosilloCCM + value.AguinaldoHermosilloCCM);
                    $('#lblTotalHermosilloCCM').text(formatoMonedaFormatter(totalHermosilloCCM));
                    $('#lblTotalProyectosHermosilloCCM').text(formatoMonedaFormatter(value.TotalProyectosHermosilloCCM));
                    $('#lblTotalCotizadoHermosilloCCM').text(formatoMonedaFormatter(value.TotalCotizadoHermosilloCCM));
                    $('#lblTotalPorcentajeHermosilloCCM').text(formatoPorcentajeFormatter(value.PorcentajeHermosilloCCM));
                    /*CHIHUAHUA CCM*/
                    $("#txtNominaChihuahuaCCM").val(formatoMonedaFormatter(value.NominaChihuahuaCCM));
                    $("#txtCostoImssChihuahuaCCM").val(formatoMonedaFormatter(value.ImssChihuahuaCCM));
                    $("#txtCostoTotalChihuahuaCCM").val(formatoMonedaFormatter(value.TotalChihuahuaCCM));
                    $("#txtTotalEmpleadosChihuahuaCCM").val(formatoMonedaFormatter(value.TotalEmpleadosChihuahuaCCM));
                    $("#txtPerdidaCambiariaChihuahuaCCM").val(formatoMonedaFormatter(value.PerdidaCambiariaChihuahuaCCM));
                    $("#txtUtilidadCambiariaChihuahuaCCM").val(formatoMonedaFormatter(value.UtilidadCambiariaChihuahuaCCM));
                    $("#txtComisionBancariaChihuahuaCCM").val(formatoMonedaFormatter(value.ComisionesBancariasChihuahuaCCM));
                    $("#txtGastosAdmonChihuahuaCCM").val(formatoMonedaFormatter(value.GastosAdmonChihuahuaCCM));
                    $("#txtConsumiblesChihuahuaCCM").val(formatoMonedaFormatter(value.ConsumiblesTallerChihuahuaCCM));
                    $("#txtGasolinaChihuahuaCCM").val(formatoMonedaFormatter(value.GasolinaChihuahuaCCM));
                    $("#txtEquipoSeguridadChihuahuaCCM").val(formatoMonedaFormatter(value.EquipoSeguridadChihuahuaCCM));
                    $("#txtInventarioSisaChihuahuaCCM").val(formatoMonedaFormatter(value.InventarioChihuahuaCCM));
                    $("#txtViaticosChihuahuaCCM").val(formatoMonedaFormatter(value.ViaticosChihuahuaCCM));
                    $("#txtCarrosChihuahuaCCM").val(formatoMonedaFormatter(value.CarrosChihuahuaCCM));
                    $("#txtUniformesChihuahuaCCM").val(formatoMonedaFormatter(value.UniformesChihuahuaCCM));
                    $('#txtVacacionesChihuahuaCCM').val(formatoMonedaFormatter(value.VacacionesChihuahuaCCM));
                    $('#txtAguinaldoChihuahuaCCM').val(formatoMonedaFormatter(value.AguinaldoChihuahuaCCM));

                    var totalChihuahuaCCM = (value.NominaChihuahuaCCM + value.ImssChihuahuaCCM + value.TotalEmpleadosChihuahuaCCM + value.PerdidaCambiariaChihuahuaCCM + value.UtilidadCambiariaChihuahuaCCM + value.ComisionesBancariasChihuahuaCCM + value.GastosAdmonChihuahuaCCM + value.ConsumiblesTallerChihuahuaCCM + value.GasolinaChihuahuaCCM + value.EquipoSeguridadChihuahuaCCM + value.InventarioChihuahuaCCM + value.ViaticosChihuahuaCCM + value.CarrosChihuahuaCCM + value.UniformesChihuahuaCCM + value.VacacionesChihuahuaCCM + value.AguinaldoChihuahuaCCM);
                    $('#lblTotalChihuahuaCCM').text(formatoMonedaFormatter(totalChihuahuaCCM));
                    $('#lblTotalProyectosChihuahuaCCM').text(formatoMonedaFormatter(value.TotalProyectosChihuahuaCCM));
                    $('#lblTotalCotizadoChihuahuaCCM').text(formatoMonedaFormatter(value.TotalCotizadoChihuahuaCCM));
                    $('#lblTotalPorcentajeChihuahuaCCM').text(formatoPorcentajeFormatter(value.PorcentajeChihuahuaCCM));
                    /*CUAUTITLAN CCM*/
                    $("#txtNominaCuautitlanCCM").val(formatoMonedaFormatter(value.NominaCuautitlanCCM));
                    $("#txtCostoImssCuautitlanCCM").val(formatoMonedaFormatter(value.ImssCuautitlanCCM));
                    $("#txtCostoTotalCuautitlanCCM").val(formatoMonedaFormatter(value.TotalCuautitlanCCM));
                    $("#txtTotalEmpleadosCuautitlanCCM").val(formatoMonedaFormatter(value.TotalEmpleadosCuautitlanCCM));
                    $("#txtPerdidaCambiariaCuautitlanCCM").val(formatoMonedaFormatter(value.PerdidaCambiariaCuautitlanCCM));
                    $("#txtUtilidadCambiariaCuautitlanCCM").val(formatoMonedaFormatter(value.UtilidadCambiariaCuautitlanCCM));
                    $("#txtComisionBancariaCuautitlanCCM").val(formatoMonedaFormatter(value.ComisionesBancariasCuautitlanCCM));
                    $("#txtGastosAdmonCuautitlanCCM").val(formatoMonedaFormatter(value.GastosAdmonCuautitlanCCM));
                    $("#txtConsumiblesCuautitlanCCM").val(formatoMonedaFormatter(value.ConsumiblesTallerCuautitlanCCM));
                    $("#txtGasolinaCuautitlanCCM").val(formatoMonedaFormatter(value.GasolinaCuautitlanCCM));
                    $("#txtEquipoSeguridadCuautitlanCCM").val(formatoMonedaFormatter(value.EquipoSeguridadCuautitlanCCM));
                    $("#txtInventarioSisaCuautitlanCCM").val(formatoMonedaFormatter(value.InventarioCuautitlanCCM));
                    $("#txtViaticosCuautitlanCCM").val(formatoMonedaFormatter(value.ViaticosCuautitlanCCM));
                    $("#txtCarrosCuautitlanCCM").val(formatoMonedaFormatter(value.CarrosCuautitlanCCM));
                    $("#txtUniformesCuautitlanCCM").val(formatoMonedaFormatter(value.UniformesCuautitlanCCM));
                    $('#txtVacacionesCuautitlanCCM').val(formatoMonedaFormatter(value.VacacionesCuautitlanCCM));
                    $('#txtAguinaldoCuautitlanCCM').val(formatoMonedaFormatter(value.AguinaldoCuautitlanCCM));

                    var totalCuautitlanCCM = (value.NominaCuautitlanCCM + value.ImssCuautitlanCCM + value.TotalEmpleadosCuautitlanCCM + value.PerdidaCambiariaCuautitlanCCM + value.UtilidadCambiariaCuautitlanCCM + value.ComisionesBancariasCuautitlanCCM + value.GastosAdmonCuautitlanCCM + value.ConsumiblesTallerCuautitlanCCM + value.GasolinaCuautitlanCCM + value.EquipoSeguridadCuautitlanCCM + value.InventarioCuautitlanCCM + value.ViaticosCuautitlanCCM + value.CarrosCuautitlanCCM + value.UniformesCuautitlanCCM + value.VacacionesCuautitlanCCM + value.AguinaldoCuautitlanCCM);
                    $('#lblTotalCuautitlanCCM').text(formatoMonedaFormatter(totalCuautitlanCCM));
                    $('#lblTotalProyectosCuautitlanCCM').text(formatoMonedaFormatter(value.TotalProyectosCuautitlanCCM));
                    $('#lblTotalCotizadoCuautitlanCCM').text(formatoMonedaFormatter(value.TotalCotizadoCuautitlanCCM));
                    $('#lblTotalPorcentajeCuautitlanCCM').text(formatoPorcentajeFormatter(value.PorcentajeCuautitlanCCM));
                    //$('#lblTotalPorcentajeCuautitlanCCM').text(formatoPorcentajeFormatter(totalCuautitlanCCM / value.TotalCotizadoCuautitlanCCM));

                    /*IRAPUATO CCM*/
                    $("#txtNominaIrapuatoCCM").val(formatoMonedaFormatter(value.NominaIrapuatoCCM));
                    $("#txtCostoImssIrapuatoCCM").val(formatoMonedaFormatter(value.ImssIrapuatoCCM));
                    $("#txtCostoTotalIrapuatoCCM").val(formatoMonedaFormatter(value.TotalIrapuatoCCM));
                    $("#txtTotalEmpleadosIrapuatoCCM").val(formatoMonedaFormatter(value.TotalEmpleadosIrapuatoCCM));
                    $("#txtPerdidaCambiariaIrapuatoCCM").val(formatoMonedaFormatter(value.PerdidaCambiariaIrapuatoCCM));
                    $("#txtUtilidadCambiariaIrapuatoCCM").val(formatoMonedaFormatter(value.UtilidadCambiariaIrapuatoCCM));
                    $("#txtComisionBancariaIrapuatoCCM").val(formatoMonedaFormatter(value.ComisionesBancariasIrapuatoCCM));
                    $("#txtGastosAdmonIrapuatoCCM").val(formatoMonedaFormatter(value.GastosAdmonIrapuatoCCM));
                    $("#txtConsumiblesIrapuatoCCM").val(formatoMonedaFormatter(value.ConsumiblesTallerIrapuatoCCM));
                    $("#txtGasolinaIrapuatoCCM").val(formatoMonedaFormatter(value.GasolinaIrapuatoCCM));
                    $("#txtEquipoSeguridadIrapuatoCCM").val(formatoMonedaFormatter(value.EquipoSeguridadIrapuatoCCM));
                    $("#txtInventarioSisaIrapuatoCCM").val(formatoMonedaFormatter(value.InventarioIrapuatoCCM));
                    $("#txtViaticosIrapuatoCCM").val(formatoMonedaFormatter(value.ViaticosIrapuatoCCM));
                    $("#txtCarrosIrapuatoCCM").val(formatoMonedaFormatter(value.CarrosIrapuatoCCM));
                    $("#txtUniformesIrapuatoCCM").val(formatoMonedaFormatter(value.UniformesIrapuatoCCM));
                    $('#txtVacacionesIrapuatoCCM').val(formatoMonedaFormatter(value.VacacionesIrapuatoCCM));
                    $('#txtAguinaldoIrapuatoCCM').val(formatoMonedaFormatter(value.AguinaldoIrapuatoCCM));

                    var totalIrapuatoCCM = (value.NominaIrapuatoCCM + value.ImssIrapuatoCCM + value.TotalEmpleadosIrapuatoCCM + value.PerdidaCambiariaIrapuatoCCM + value.UtilidadCambiariaIrapuatoCCM + value.ComisionesBancariasIrapuatoCCM + value.GastosAdmonIrapuatoCCM + value.ConsumiblesTallerIrapuatoCCM + value.GasolinaIrapuatoCCM + value.EquipoSeguridadIrapuatoCCM + value.InventarioIrapuatoCCM + value.ViaticosIrapuatoCCM + value.CarrosIrapuatoCCM + value.UniformesIrapuatoCCM + value.VacacionesIrapuatoCCM + value.AguinaldoIrapuatoCCM);
                    $('#lblTotalIrapuatoCCM').text(formatoMonedaFormatter(totalIrapuatoCCM));
                    $('#lblTotalProyectosIrapuatoCCM').text(formatoMonedaFormatter(value.TotalProyectosIrapuatoCCM));
                    $('#lblTotalCotizadoIrapuatoCCM').text(formatoMonedaFormatter(value.TotalCotizadoIrapuatoCCM));
                    $('#lblTotalPorcentajeIrapuatoCCM').text(formatoPorcentajeFormatter(value.PorcentajeIrapuatoCCM));
                    /*QUERETARO CCM*/
                    $("#txtNominaQueretaroCCM").val(formatoMonedaFormatter(value.NominaQueretaroCCM));
                    $("#txtCostoImssQueretaroCCM").val(formatoMonedaFormatter(value.ImssQueretaroCCM));
                    $("#txtCostoTotalQueretaroCCM").val(formatoMonedaFormatter(value.TotalQueretaroCCM));
                    $("#txtTotalEmpleadosQueretaroCCM").val(formatoMonedaFormatter(value.TotalEmpleadosQueretaroCCM));
                    $("#txtPerdidaCambiariaQueretaroCCM").val(formatoMonedaFormatter(value.PerdidaCambiariaQueretaroCCM));
                    $("#txtUtilidadCambiariaQueretaroCCM").val(formatoMonedaFormatter(value.UtilidadCambiariaQueretaroCCM));
                    $("#txtComisionBancariaQueretaroCCM").val(formatoMonedaFormatter(value.ComisionesBancariasQueretaroCCM));
                    $("#txtGastosAdmonQueretaroCCM").val(formatoMonedaFormatter(value.GastosAdmonQueretaroCCM));
                    $("#txtConsumiblesQueretaroCCM").val(formatoMonedaFormatter(value.ConsumiblesTallerQueretaroCCM));
                    $("#txtGasolinaQueretaroCCM").val(formatoMonedaFormatter(value.GasolinaQueretaroCCM));
                    $("#txtEquipoSeguridadQueretaroCCM").val(formatoMonedaFormatter(value.EquipoSeguridadQueretaroCCM));
                    $("#txtInventarioSisaQueretaroCCM").val(formatoMonedaFormatter(value.InventarioQueretaroCCM));
                    $("#txtViaticosQueretaroCCM").val(formatoMonedaFormatter(value.ViaticosQueretaroCCM));
                    $("#txtCarrosQueretaroCCM").val(formatoMonedaFormatter(value.CarrosQueretaroCCM));
                    $("#txtUniformesQueretaroCCM").val(formatoMonedaFormatter(value.UniformesQueretaroCCM));
                    $('#txtVacacionesQueretaro').val(formatoMonedaFormatter(value.VacacionesQueretaroCCM));
                    $('#txtAguinaldoQueretaro').val(formatoMonedaFormatter(value.AguinaldoQueretaroCCM));

                    var totalQueretaroCCM = (value.NominaQueretaroCCM + value.ImssQueretaroCCM + value.TotalEmpleadosQueretaroCCM + value.PerdidaCambiariaQueretaroCCM + value.UtilidadCambiariaQueretaroCCM + value.ComisionesBancariasQueretaroCCM + value.GastosAdmonQueretaroCCM + value.ConsumiblesTallerQueretaroCCM + value.GasolinaQueretaroCCM + value.EquipoSeguridadQueretaroCCM + value.InventarioQueretaroCCM + value.ViaticosQueretaroCCM + value.CarrosQueretaroCCM + value.UniformesQueretaroCCM + value.VacacionesQueretaroCCM + value.AguinaldoQueretaroCCM);
                    $('#lblTotalQueretaroCCM').text(formatoMonedaFormatter(totalQueretaroCCM));
                    $('#lblTotalProyectosQueretaroCCM').text(formatoMonedaFormatter(value.TotalProyectosQueretaroCCM));
                    $('#lblTotalCotizadoQueretaroCCM').text(formatoMonedaFormatter(value.TotalCotizadoQueretaroCCM));
                    $('#lblTotalPorcentajeQueretaroCCM').text(formatoPorcentajeFormatter(value.PorcentajeQueretaroCCM));

                });

                //$('#TablaPrincipalComentarios tbody').append(nodoTRAgregar);

                $("#CapturaDatosModal").modal();
            }
        });
        
    }
};