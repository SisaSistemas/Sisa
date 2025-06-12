var IdCotizaciones = 0;
var item = 0;
var idContacto = '0';
var IdUsuarioCreo = '';
$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("CotizacionesDetalles.aspx") > -1) {
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        IdCotizaciones = document.getElementById('MainContent_idCotiza').value;
        IdSolicitud = document.getElementById('MainContent_idSolicitud').value;
        IdBidding = document.getElementById('MainContent_idBiddingInput').value;
        IdEmpresa = document.getElementById('MainContent_idEmpresa').value;
        IdContacto = document.getElementById('MainContent_idContacto').value;

        CargarEmpresas();
        CargarUsuarios();
        if (IdCotizaciones == 0) {
            if (IdSolicitud != "0" || IdSolicitud != 0) {
                cargarDatosSolicitud();
            }
            $('#btnPDFCotizacion').hide();
            $('#btnModificarCotizacion').hide();
            $('#btnGuardarCotizacion').show();
        } else {
            CargarDatosEncabezado();
            /*CargarDatosDetalle();*/
            CargarNotas();
            
            $('#btnGuardarCotizacion').hide();
            $('#btnModificarCotizacion').show();
        }

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
        
    }
    $(document).on('click', '.eliminaritemcotiza', function (event) {
        //;
        $(this).closest("tr").remove();
        sumarColumnas();
        //if (IdCotizaciones != '0') {
        //    var _boton = $(this);
        //    var _id = $(this).parent().parent().find('td')[0].innerHTML;
        //    var _producto = $(this).parent().parent().find('td')[2].innerHTML;

        //    swal({
        //        title: "¿Esta seguro que desea eliminar el item " + _producto + "?, se actualizará la cotización",
        //        type: "warning",
        //        allowOutsideClick: false,
        //        allowEscapeKey: false,
        //        allowEnterKey: false,
        //        showCancelButton: true,
        //        confirmButtonColor: '#3085d6',
        //        cancelButtonColor: '#d33',
        //        confirmButtonText: 'Si',
        //        cancelButtonText: 'No'
        //    }).then(function () {
        //        sumarColumnas();

        //        var params = "{'IdOrdenCompra': '" + IdOrdenCompra + "','Item': '" + _item + "','SubTotal': '" + $('#lblSubTotal').text() + "','Iva': '" + $('#lblIVA').text() + "', 'Codigo':'" + _code + "'}"

        //        $.ajax({
        //            dataType: 'json',
        //            async: true,
        //            contentType: "application/json; charset=utf-8",
        //            type: 'POST',
        //            url: 'CotizacionesDetalle.aspx/ItemEliminado',
        //            data: params,
        //            success: function (data, textStatus) {
        //                if (data.d == 'Actualizado') {
        //                    swal('Orden de compra actualizada.');
        //                }
        //            }
        //        });


        //    }, function (dismiss) {
        //        // dismiss can be 'cancel', 'overlay',
        //        // 'close', and 'timer'
        //        if (dismiss === 'cancel') {
        //            swal(
        //                'Proceso cancelado'
        //            );
        //            CargarDatosDetalle();
        //        }
        //    });
        //}
        //else {
        //    //var _boton = $(this);
        //    //var _item = $(this).parent().parent().find('tr')[0].innerHTML;
        //    //$(_item).remove();
        //    $(this).closest("tr").remove();
        //    sumarColumnas();
        //}

    });
});
function CargarNotas() {
    var params = "{'IdCotiza': '" + IdCotizaciones + "'}";
    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'CotizacionesDetalles.aspx/CargarNotas',
        data: params,
        success: function (data, textStatus) {

            $('#tblNotasCotizacion tbody').remove();

            var datos = "";
            var idProv;
            var nodoTRAgregar = "";
            var json = $.parseJSON(data.d);

            $.each(json, function (index, value) {

                nodoTRAgregar += "<tr>";
                nodoTRAgregar += "  <td>" + value.NotaAclaratoria + "</td>";

                nodoTRAgregar += "  <td><span class='btn btn-danger icon_close eliminar'></span></td>";

                nodoTRAgregar += "</tr>";

            });

            $("#tblNotasCotizacion").append(nodoTRAgregar);
        }
    });
}

function CargarDatosEncabezado() {
    var params = "{'idCotiza': '" + IdCotizaciones + "'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'CotizacionesDetalles.aspx/CargarDatosEncabezado',
        data: params,
        success: function (data, textStatus) {

            var datos = "";
            var idCot;
            var JsonCombos;
            var json = $.parseJSON(data.d);

            $.each(json, function (index, value) {
                //debugger;
                idCot = value.IdCotizaciones;
                $("#cmbEmpresas").val(value.IdEmpresa.toUpperCase());
                $('#cmbEmpresas').selectpicker('refresh');
                //
                $('#cmbEmpresas').trigger('change');
                
                $('#txtDescripcionCotizaCompleta').val(value.Concepto);
                idContacto = value.idContacto;                
                IdUsuarioCreo = value.IdUsuarioCreo;
               // $("#cmbContactos option[value='" + idContacto + "']").prop('selected', true);                
                //$('#cmbContactos').val(value.idContacto).prop('selected', true);
                $('#txtMOCotizado').val(value.CostoMOCotizado);
                $('#txtCostoMaterialCotizados').val(value.CostoMaterialCotizado);
                $('#txtCECotizados').val(value.CostoMECotizado);

                $('#txtIVA').val(value.IvaPorcentaje);
                $('#txtSaving').val(value.SavingPorcentaje);

                //$('#cmbProyectos').removeAttr('disabled');
                ObtenerFolioRFQ(value.idRequisicion);
                $("#cmbContactos option[value='" + idContacto.toUpperCase() + "']").prop('selected', true);
                $("#cmbContactos").val(idContacto.toUpperCase());
                $('#cmbContactos').selectpicker('refresh');
                $("#cmbUsuariosCotizacion").val(value.IdUsuarioCreo);
                $('#cmbUsuariosCotizacion').selectpicker('refresh');

               
            });

            CargarDatosDetalle();
        }
    });
}

function cargarDatosSolicitud() {
    var params = "{'idSolicitud': '" + IdSolicitud + "'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'CotizacionesDetalles.aspx/CargarDatosSolicitud',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $.each(json, function (index, value) {
                //debugger;
                //idCot = value.IdCotizaciones;
                $('#txtDescripcionCotizaCompleta').val(value.Resumen);
                $('#txtReferenciarReqCot').val(value.Folio);
                $('#txtReferenciaBidding').val(value.FolioTipo);
            });
        }
    });
}

function ObtenerFolioRFQ(idRFQ) {
    var params = "{'pid': '" + idRFQ + "'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'CotizacionesDetalles.aspx/CargarFolioRFQ',
        data: params,
        success: function (data, textStatus) {
            if (data.d != 'SIN RFQ') {
                var json = $.parseJSON(data.d);

                $.each(json, function (index, value) {

                    $('#txtReferenciarReqCot').val(value.Folio);

                });
            }

        }
    });
}

function CargarDatosDetalle() {
    var params = "{'IdCotiza': '" + IdCotizaciones + "'}";
    var item = 1;
    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'CotizacionesDetalles.aspx/CargarDatosDetalle',
        data: params,
        success: function (data, textStatus) {

            $('#tblItemsCotizacion tbody').remove();

            var datos = "";
            var idProv;
            var nodoTRAgregar = "";
            var json = $.parseJSON(data.d);

            $.each(json, function (index, value) {

                nodoTRAgregar += "<tr>";
                
                nodoTRAgregar += '  <td style = "display: none;">' + value.idCotDetalle + '</td>';
                nodoTRAgregar += "  <td>" + item + "</td>";
                item++;
                nodoTRAgregar += "  <td>" + value.Descripcion + "</td>";
                nodoTRAgregar += "  <td>" + formato_numero(value.Cantidad, 2, ".", ",") + "</td>";
                nodoTRAgregar += "  <td>" + value.Unidad + "</td>";
                nodoTRAgregar += "  <td>" + formato_numero(value.Precio, 2, ".", ",") + "</td>"; 
                nodoTRAgregar += "  <td>" + formato_numero(value.Importe, 2, ".", ",") + "</td>";
                //nodoTRAgregar += "  <td><span class='btn btn-danger btn-xs fa fa-remove eliminar'></span></td>";
                nodoTRAgregar += "  <td><span class='btn btn-danger icon_close eliminaritemcotiza'></span></td>";

                nodoTRAgregar += "</tr>";

            });

            $("#tblItemsCotizacion").append(nodoTRAgregar);
            sumarColumnas();
            //fnCargarMateriales(idProv);


        }
    });
}

function CargarEmpresas() {
    var params = "{'pid': '2'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'CotizacionesDetalles.aspx/ObtenerEmpresas',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbEmpresas').html('');
            $('#cmbEmpresas').html('<option value="-1">-- SELECCION EMPRESA --</option>');
            $.each(json, function (index, value) {
                $("#cmbEmpresas").append('<option value="' + value.idEmpresa.toUpperCase() + '">' + value.Cliente.toUpperCase() + '</option>');
            });
            $('#cmbEmpresas').selectpicker('refresh');
            $('#cmbEmpresas').selectpicker('render');

            
            if (IdSolicitud != "null") {
                $("#cmbEmpresas").val(IdEmpresa.toUpperCase());
                $('#cmbEmpresas').selectpicker('refresh');
                //
                $('#cmbEmpresas').trigger('change');
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
        url: 'CotizacionesDetalles.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbUsuariosCotizacion').html('');
            $.each(json, function (index, value) {
                $("#cmbUsuariosCotizacion").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
            });
            $('#cmbUsuariosCotizacion').selectpicker('refresh');
            $('#cmbUsuariosCotizacion').selectpicker('render');
            if (IdCotizaciones != '0') {
                //$("#cmbUsuariosCotizacion option[value='" + IdUsuarioCreo + "']").prop('selected', true);
                $("#cmbUsuariosCotizacion").val(IdUsuarioCreo);
                $('#cmbUsuariosCotizacion').selectpicker('refresh');
            }
        }
    });
}

$("#cmbEmpresas").change(function () {

    var idEmpresa = $(this).val();

    if (idEmpresa != null) {
        var params = "{'pid': '" + idEmpresa + "'}";
        //debugger;
        $.ajax({
            async: true,
            url: "CotizacionesDetalles.aspx/BuscarContactos",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                var json = $.parseJSON(data.d);
                $('#cmbContactos').html('');
                $.each(json, function (index, value) {
                    $("#cmbContactos").append('<option value="' + value.idContacto.toUpperCase() + '">' + value.NombreContacto.toUpperCase() + '</option>');
                });
                $('#cmbContactos').selectpicker('refresh');
                $('#cmbContactos').selectpicker('render');

                if (IdSolicitud != "null") {
                    $("#cmbContactos").val(IdContacto.toUpperCase());
                    $('#cmbContactos').selectpicker('refresh');
                    $('#cmbContactos').selectpicker('render');
                }
                else {
                    $("#cmbContactos").val(idContacto.toUpperCase());
                    $('#cmbContactos').selectpicker('refresh');
                    $('#cmbContactos').selectpicker('render');
                }
                
            }
        });

    }
    else {
        swal("Selecciona otra empresa con contactos registrados...");
        return;
    }



});

$('#btnAgregarItemCotizacion').click(function () {

    if ($('#txtDescripcionCotiza').val() == '' || $('#txtCantidadCotiza').val() == "" || $('#txtPrecioCotiza').val() == "") {
        swal("Proporcionar datos obligatorios (Descripción, cantidad, precio)...");
        return;
    }
    var nodoTRAgregar = "";
    item++;
    nodoTRAgregar += "<tr>";
    nodoTRAgregar += '  <td style = "display: none;">0</td>';
    nodoTRAgregar += "  <td>" + item + "</td>";
    nodoTRAgregar += "  <td>" + $('#txtDescripcionCotiza').val() + "</td>";
    nodoTRAgregar += "  <td>" + formato_numero($('#txtCantidadCotiza').val(), 2, ".", ",") + "</td>"; 
    nodoTRAgregar += "  <td>" + $('#txtUnidadCotiza').val() + "</td>";
    nodoTRAgregar += "  <td>" + formato_numero($('#txtPrecioCotiza').val(), 2, ".", ",") + "</td>"; 
    nodoTRAgregar += "  <td>" + formato_numero(($('#txtCantidadCotiza').val() * $('#txtPrecioCotiza').val()), 2, ".", ",") + "</td>"; 
    nodoTRAgregar += "  <td><span class='btn btn-danger icon_close eliminaritemcotiza'></span></td>";
    nodoTRAgregar += "</tr>";
    $("#tblItemsCotizacion").append(nodoTRAgregar);

    sumarColumnas();

    $('#txtDescripcionCotiza').val('');
    $('#txtCantidadCotiza').val('');
    $('#txtUnidadCotiza').val('');
    $('#txtPrecioCotiza').val('');
});

$('#btnAgregarNotasCotizacion').click(function () {

    if ($('#txtNotas').val() == '') {
        swal("Proporcionar datos obligatorios (Nota aclaratoria)...");
        return;
    }
    var nodoTRAgregar = "";
    item++;
    nodoTRAgregar += "<tr>";

    nodoTRAgregar += "  <td>" + $('#txtNotas').val() + "</td>";
    nodoTRAgregar += "  <td><span class='btn btn-danger icon_close eliminar'></span></td>";
    nodoTRAgregar += "</tr>";
    $("#tblNotasCotizacion").append(nodoTRAgregar);


    $('#txtNotas').val('');
});

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

function replaceAll(string, search, replace) {
    return string.split(search).join(replace);
}

function sumarColumnas() {

    var mImporte = 0, mImporteNew = 0, mIVA = 0, mTotal = 0, mDescuento = 0;

    $('#tblItemsCotizacion tbody tr').each(function () {

        $(this).children("td").each(function (index2) {
            switch (index2) {
                case 6:
                    var a = $(this).text();
                    var b = replaceAll(a,',', '');
                    mImporte += parseFloat(b);
                    break;
            }
        });

    });
    //debugger;
    $('#lblSubTotal').text(formato_numero(mImporte, 2, ".", ","));

    $("#txtSaving").trigger('keyup');

    mDescuento = replaceAll($('#lblSaving').text(), ',', '');

    mImporteNew = (mImporte - mDescuento);

    mIVA = mImporteNew * ($('#txtIVA').val() / 100);

    //debugger;
    $('#lblIVA').text(formato_numero(mIVA, 2, ".", ","));

    mTotal = mImporteNew + mIVA;

    $('#lblTotal').text(formato_numero(mTotal, 2, ".", ","));
    //$('#idTotal').text(formato_numero(mTotal, 2, ".", ","));
    document.getElementById('idTodal').textContent = formato_numero(mTotal, 2, ".", ",");

    
}

$('#btnGuardarCotizacion').click(function () {

    swal({
        title: "Esta seguro que desea crear cotización?",
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
        if ($('#cmbEmpresas').val() == '-1') {
            swal("Selecciona empresa...");
            return;
        }
        if ($('#cmbContactos').val() == '-1') {
            swal("Selecciona contacto...");
            return;
        }
        var ContadorProyeccionCotizacion = 0;
        if ($('#txtMOCotizado').val() == '0' || $('#txtMOCotizado').val() == '') {
            //swal("Ingresa cantidad de mano de obra..");
            //return;
            ContadorProyeccionCotizacion++;
        }

        if ($('#txtCostoMaterialCotizados').val() == '0' || $('#txtCostoMaterialCotizados').val() == '') {
            //swal("Ingresa cantidad de materiales..");
            //return;
            ContadorProyeccionCotizacion++;
        }

        if ($('#txtCECotizados').val() == '0' || $('#txtCECotizados').val() == '') {
            //swal("Ingresa cantidad de equipo..");
            //return;
            ContadorProyeccionCotizacion++;
        }
        if (ContadorProyeccionCotizacion == 3) {
            swal("Al menos un dato de proyección de costos debe ser mayor a 0");
            return;
        }
        if ($('#txtDescripcionCotizaCompleta').val() == '-1') {
            swal("Crea una descripción de la cotización...");
            return;
        }

        var itemsTot = 0, itemsIns = 0;
        $("#tblItemsCotizacion tbody tr").each(function (index) {
            itemsTot++;
        });
        if (itemsTot == 0) {
            swal("No existen items a regitrar, agrega al menos uno...");
            return;
        }
        swal({
            title: 'Guardando Datos!',
            text: 'Espere un Momento...',
            onOpen: function () {
                swal.showLoading()
            }
        });

        var cmbContactos = "";
        var tipoOC = "";

        var params = "{'idContacto': '" + $('#cmbContactos').val() +
            "','idEmpresa': '" + $('#cmbEmpresas').val() +
            "','RFQ': '" + $('#txtReferenciarReqCot').val() +
            "','txtDescripcionCotizaCompleta': '" + $('#txtDescripcionCotizaCompleta').val() +
            "','CostoCotizacion': '" + document.getElementById('idTodal').textContent +
            "','MO': '" + $('#txtMOCotizado').val() +
            "','CM': '" + $('#txtCostoMaterialCotizados').val() +
            "','CE': '" + $('#txtCECotizados').val() +
            "','pIva': '" + $('#txtCECotizados').val() +
            "','pSaving': '" + $('#txtCECotizados').val() +
            "','CreadoPor': '" + $('#cmbUsuariosCotizacion').val() +
            
            "'}";

        $.ajax({
            dataType: "json",
            async: true,
            url: "CotizacionesDetalles.aspx/CrearCotizacion",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                var cadena = data.d.split('.');
                if (cadena[0] == "Cotizacion creada") {
                    $("#tblItemsCotizacion tbody tr").each(function (index) {
                        var item, descripcion, cantidad, unidad, precio, importe

                        $(this).children("td").each(function (index2) {
                            switch (index2) {
                                case 1:
                                    item = $(this).text();
                                    break;
                                case 2:
                                    descripcion = $(this).text();
                                    break;
                                case 3:
                                    cantidad = $(this).text();
                                    break;
                                case 4:
                                    unidad = $(this).text();
                                    break;
                                case 5:
                                    precio = $(this).text();
                                    break;
                                case 6:
                                    importe = $(this).text();
                                    break;
                            }
                        });

                        var param = "{'item': '" + item +
                            "','Descripcion': '" + descripcion +
                            "','Cantidad': '" + cantidad +
                            "','Unidad': '" + unidad +
                            "','Precio': '" + precio +
                            "','Importe': '" + importe + "'}";

                        $.ajax({
                            async: true,
                            url: "CotizacionesDetalles.aspx/CrearCotizacionItem",
                            dataType: "json",
                            data: param,
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data, textStatus) {
                                itemsIns++;
                                if (itemsIns == itemsTot) {
                                    //notas aclaratorias
                                    var notasTot = 0;
                                    $("#tblNotasCotizacion tbody tr").each(function (index) {
                                        notasTot++;
                                    });
                                    if (notasTot > 0) {
                                        var Nota = '';
                                        $("#tblNotasCotizacion tbody tr").each(function (index) {
                                            $(this).children("td").each(function (index2) {
                                                switch (index2) {
                                                    case 0:
                                                        Nota = $(this).text();
                                                        break;
                                                }
                                            });
                                            var params = "{'Nota': '" + Nota + "'}";
                                            $.ajax({

                                                async: true,
                                                url: "CotizacionesDetalles.aspx/CrearNotasAclaratorias",
                                                dataType: "json",
                                                data: params,
                                                type: "POST",
                                                contentType: "application/json; charset=utf-8",
                                                success: function (data, textStatus) {

                                                }
                                            });
                                        });

                                    }
                                    IdCotizaciones = cadena[1];
                                    document.getElementById('MainContent_idCotiza').value = IdCotizaciones;
                                    CargarDatosEncabezado();
                                    CargarDatosDetalle();
                                    CargarNotas();
                                    $('#btnPDFCotizacion').show();
                                    $('#btnGuardarCotizacion').hide();
                                    $('#btnModificarCotizacion').show();
                                    swal("Cotizacion creada.");
                                    return;
                                }
                            }
                        });
                    });


                }
                else {
                    swal("Error: " + data.d);
                    return;
                }


            },
            error: function (xhr, ajaxOptions, thrownError) {

            }
        });


    }, function (dismiss) {
        // dismiss can be 'cancel', 'overlay',
        // 'close', and 'timer'
        if (dismiss === 'cancel') {
            swal(
                'Cancelado',
                'Cancelaste creación de cotización :)',
                'error'
            );
        }
    });
});

$('#btnModificarCotizacion').click(function () {

    swal({
        title: "Esta seguro que desea modificar cotización?",
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


        swal({
            title: "Quiere generar un folio modificación nuevo?",
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

            if ($('#cmbEmpresas').val() == '-1') {
                swal("Selecciona empresa...");
                return;
            }
            //if ($('#cmbContactos').val() == '-1') {
            //    swal("Selecciona contacto...");
            //    return;
            //}

            if ($('#txtDescripcionCotizaCompleta').val() == '-1') {
                swal("Crea una descripción de la cotización...");
                return;
            }

            var ContadorProyeccionCotizacion = 0;
            if ($('#txtMOCotizado').val() == '0' || $('#txtMOCotizado').val() == '') {
                //swal("Ingresa cantidad de mano de obra..");
                //return;
                ContadorProyeccionCotizacion++;
            }

            if ($('#txtCostoMaterialCotizados').val() == '0' || $('#txtCostoMaterialCotizados').val() == '') {
                //swal("Ingresa cantidad de materiales..");
                //return;
                ContadorProyeccionCotizacion++;
            }

            if ($('#txtCECotizados').val() == '0' || $('#txtCECotizados').val() == '') {
                //swal("Ingresa cantidad de equipo..");
                //return;
                ContadorProyeccionCotizacion++;
            }
            if (ContadorProyeccionCotizacion == 3) {
                swal("Al menos un dato de proyección de costos debe ser mayor a 0");
                return;
            }

            var itemsTot = 0, itemsIns = 0;
            $("#tblItemsCotizacion tbody tr").each(function (index) {
                itemsTot++;
            });
            if (itemsTot == 0) {
                swal("No existen items a regitrar, agrega al menos uno...");
                return;
            }
            swal({
                title: 'Guardando Datos!',
                text: 'Espere un Momento...',
                onOpen: function () {
                    swal.showLoading()
                }
            });

            var cmbContactos = "";
            var tipoOC = "";

            var params = "{'idContacto': '" + $('#cmbContactos').val() +
                "','idEmpresa': '" + $('#cmbEmpresas').val() +
                "','RFQ': '" + $('#txtReferenciarReqCot').val() +
                "','txtDescripcionCotizaCompleta': '" + $('#txtDescripcionCotizaCompleta').val() +
                "','CostoCotizacion': '" + document.getElementById('idTodal').textContent + "'" +
                " ,'idCotiza': '" + IdCotizaciones +
                "','MO': '" + $('#txtMOCotizado').val() +
                "','CM': '" + $('#txtCostoMaterialCotizados').val() +
                "','CE': '" + $('#txtCECotizados').val() +
                "','pIva': '" + $('#txtIVA').val() +
                "','pSaving': '" + $('#txtSaving').val() +
                "','CreadoPor': '" + $('#cmbUsuariosCotizacion').val() + "'}";

            $.ajax({
                dataType: "json",
                async: true,
                url: "CotizacionesDetalles.aspx/CrearCotizacionModifica",//"CotizacionesDetalles.aspx/ActualizarCotizacion",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {
                    var cadena = data.d.split('.');
                    if (cadena[0] == "Cotizacion Modificada") {
                        $("#tblItemsCotizacion tbody tr").each(function (index) {
                            var item, descripcion, cantidad, unidad, precio, importe

                            $(this).children("td").each(function (index2) {
                                switch (index2) {
                                    case 1:
                                        item = $(this).text();
                                        break;
                                    case 2:
                                        descripcion = $(this).text();
                                        break;
                                    case 3:
                                        cantidad = $(this).text();
                                        break;
                                    case 4:
                                        unidad = $(this).text();
                                        break;
                                    case 5:
                                        precio = $(this).text();
                                        break;
                                    case 6:
                                        importe = $(this).text();
                                        break;
                                }
                            });

                            var param = "{'item': '" + item +
                                "','Descripcion': '" + descripcion +
                                "','Cantidad': '" + cantidad +
                                "','Unidad': '" + unidad +
                                "','Precio': '" + precio +
                                "','Importe': '" + importe + "'}";

                            $.ajax({
                                async: true,
                                url: "CotizacionesDetalles.aspx/CrearCotizacionItem",
                                dataType: "json",
                                data: param,
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data, textStatus) {
                                    itemsIns++;
                                    if (itemsIns == itemsTot) {
                                        //notas aclaratorias
                                        var notasTot = 0;
                                        $("#tblNotasCotizacion tbody tr").each(function (index) {
                                            notasTot++;
                                        });
                                        if (notasTot > 0) {
                                            var Nota = '';
                                            $("#tblNotasCotizacion tbody tr").each(function (index) {
                                                $(this).children("td").each(function (index2) {
                                                    switch (index2) {
                                                        case 0:
                                                            Nota = $(this).text();
                                                            break;
                                                    }
                                                });
                                                var params = "{'Nota': '" + Nota + "'}";
                                                $.ajax({

                                                    async: true,
                                                    url: "CotizacionesDetalles.aspx/CrearNotasAclaratorias",
                                                    dataType: "json",
                                                    data: params,
                                                    type: "POST",
                                                    contentType: "application/json; charset=utf-8",
                                                    success: function (data, textStatus) {

                                                    }
                                                });
                                            });

                                        }
                                        swal("Cotizacion actualizada.");
                                        return;
                                    }
                                }
                            });
                        });
                    }
                    else {
                        swal("Error: " + data.d);
                        return;

                    }


                },
                error: function (xhr, ajaxOptions, thrownError) {

                }
            });


        }, function (dismiss) {
            // dismiss can be 'cancel', 'overlay',
            // 'close', and 'timer'
            if (dismiss === 'cancel') {
                if ($('#cmbEmpresas').val() == '-1') {
                    swal("Selecciona empresa...");
                    return;
                }
                //if ($('#cmbContactos').val() == '-1') {
                //    swal("Selecciona contacto...");
                //    return;
                //}

                if ($('#txtDescripcionCotizaCompleta').val() == '-1') {
                    swal("Crea una descripción de la cotización...");
                    return;
                }

                var ContadorProyeccionCotizacion = 0;
                if ($('#txtMOCotizado').val() == '0' || $('#txtMOCotizado').val() == '') {
                    //swal("Ingresa cantidad de mano de obra..");
                    //return;
                    ContadorProyeccionCotizacion++;
                }

                if ($('#txtCostoMaterialCotizados').val() == '0' || $('#txtCostoMaterialCotizados').val() == '') {
                    //swal("Ingresa cantidad de materiales..");
                    //return;
                    ContadorProyeccionCotizacion++;
                }

                if ($('#txtCECotizados').val() == '0' || $('#txtCECotizados').val() == '') {
                    //swal("Ingresa cantidad de equipo..");
                    //return;
                    ContadorProyeccionCotizacion++;
                }
                if (ContadorProyeccionCotizacion == 3) {
                    swal("Al menos un dato de proyección de costos debe ser mayor a 0");
                    return;
                }

                var itemsTot = 0, itemsIns = 0;
                $("#tblItemsCotizacion tbody tr").each(function (index) {
                    itemsTot++;
                });
                if (itemsTot == 0) {
                    swal("No existen items a regitrar, agrega al menos uno...");
                    return;
                }
                swal({
                    title: 'Guardando Datos!',
                    text: 'Espere un Momento...',
                    onOpen: function () {
                        swal.showLoading()
                    }
                });

                var cmbContactos = "";
                var tipoOC = "";

                var params = "{'idContacto': '" + $('#cmbContactos').val() +
                    "','idEmpresa': '" + $('#cmbEmpresas').val() +
                    "','RFQ': '" + $('#txtReferenciarReqCot').val() +
                    "','txtDescripcionCotizaCompleta': '" + $('#txtDescripcionCotizaCompleta').val() +
                    "','CostoCotizacion': '" + document.getElementById('idTodal').textContent + "'" +
                    " ,'idCotiza': '" + IdCotizaciones +
                    "','MO': '" + $('#txtMOCotizado').val() +
                    "','CM': '" + $('#txtCostoMaterialCotizados').val() +
                    "','CE': '" + $('#txtCECotizados').val() +
                    "','pIva': '" + $('#txtIVA').val() +
                    "','pSaving': '" + $('#txtSaving').val() +
                    "','CreadoPor': '" + $('#cmbUsuariosCotizacion').val() + "'}";

                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "CotizacionesDetalles.aspx/ActualizarCotizacion",//"CotizacionesDetalles.aspx/ActualizarCotizacion",
                    data: params,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data, textStatus) {
                        var cadena = data.d.split('.');
                        if (cadena[0] == "Cotizacion actualizada") {
                            $("#tblItemsCotizacion tbody tr").each(function (index) {
                                var item, descripcion, cantidad, unidad, precio, importe

                                $(this).children("td").each(function (index2) {
                                    switch (index2) {
                                        case 1:
                                            item = $(this).text();
                                            break;
                                        case 2:
                                            descripcion = $(this).text();
                                            break;
                                        case 3:
                                            cantidad = $(this).text();
                                            break;
                                        case 4:
                                            unidad = $(this).text();
                                            break;
                                        case 5:
                                            precio = $(this).text();
                                            break;
                                        case 6:
                                            importe = $(this).text();
                                            break;
                                    }
                                });

                                var param = "{'item': '" + item +
                                    "','Descripcion': '" + descripcion +
                                    "','Cantidad': '" + cantidad +
                                    "','Unidad': '" + unidad +
                                    "','Precio': '" + precio +
                                    "','Importe': '" + importe + "'}";

                                $.ajax({
                                    async: true,
                                    url: "CotizacionesDetalles.aspx/CrearCotizacionItem",
                                    dataType: "json",
                                    data: param,
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    success: function (data, textStatus) {
                                        itemsIns++;
                                        if (itemsIns == itemsTot) {
                                            //notas aclaratorias
                                            var notasTot = 0;
                                            $("#tblNotasCotizacion tbody tr").each(function (index) {
                                                notasTot++;
                                            });
                                            if (notasTot > 0) {
                                                var Nota = '';
                                                $("#tblNotasCotizacion tbody tr").each(function (index) {
                                                    $(this).children("td").each(function (index2) {
                                                        switch (index2) {
                                                            case 0:
                                                                Nota = $(this).text();
                                                                break;
                                                        }
                                                    });
                                                    var params = "{'Nota': '" + Nota + "'}";
                                                    $.ajax({

                                                        async: true,
                                                        url: "CotizacionesDetalles.aspx/CrearNotasAclaratorias",
                                                        dataType: "json",
                                                        data: params,
                                                        type: "POST",
                                                        contentType: "application/json; charset=utf-8",
                                                        success: function (data, textStatus) {

                                                        }
                                                    });
                                                });

                                            }
                                            swal("Cotizacion actualizada.");
                                            return;
                                        }
                                    }
                                });
                            });
                        }
                        else {
                            swal("Error: " + data.d);
                            return;

                        }


                    },
                    error: function (xhr, ajaxOptions, thrownError) {

                    }
                });
            }
        });

    }, function (dismiss) {
        // dismiss can be 'cancel', 'overlay',
        // 'close', and 'timer'
        if (dismiss === 'cancel') {
            swal(
                'Cancelado',
                'Cancelaste modificación de cotización :)',
                'error'
            );
        }
    });


        

});

$('#btnPDFCotizacion').click(function () {
    var id = document.getElementById('MainContent_idCotiza').value;
    if (id == '') {
        swal('Es necesario crear cotización para generar pdf e imprimirlo.');
    }
    else {
        window.open("ReporteCotizacion.aspx?IdCotizacion=" + id);
    }
});



$('#txtSaving').keyup(function () {
    var Saving = $(this).val();
    var Subtotal = replaceAll(document.getElementById('lblSubTotal').textContent, ',', '');
    var SavingMostrar = Subtotal * (Saving / 100);
    //$('#txtIVA').val(Iva);//
    document.getElementById('lblSaving').textContent = formato_numero(SavingMostrar, 2, ".", ",");

    //var Total = parseFloat(Subtotal) + parseFloat(IvaMostrar);
    //document.getElementById('lblTotal').textContent = formato_numero(Total, 2, ".", ",");

    $("#txtIVA").trigger('keyup');
});

$('#txtIVA').keyup(function () {
    var Iva = $(this).val();
    var Subtotal = replaceAll(document.getElementById('lblSubTotal').textContent, ',', '');
    var Saving = replaceAll(document.getElementById('lblSaving').textContent, ',', '');
    var SubtotalNew = (Subtotal - Saving);

    var IvaMostrar = SubtotalNew * (Iva / 100);
    //$('#txtIVA').val(Iva);//
    document.getElementById('lblIVA').textContent = formato_numero(IvaMostrar, 2, ".", ",");

    var Total = parseFloat(SubtotalNew) + parseFloat(IvaMostrar);
    document.getElementById('lblTotal').textContent = formato_numero(Total, 2, ".", ",");
});
