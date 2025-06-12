$(document).ready(function () {
    var URLactual = window.location;
    var IdCotizaciones = 0;
    var item = 0;
    if (URLactual.href.indexOf("CotizacionesDetalles.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        IdCotizaciones = document.getElementById('MainContent_idCotiza').value;
        CargarEmpresas();
        if (IdCotizaciones == 0) {
            $('#btnPDFCotizacion').hide();
            $('#btnModificarCotizacion').hide();
            $('#btnGuardarCotizacion').show();
        } else {
            CargarDatosEncabezado();
            CargarDatosDetalle();
            $('#btnGuardarCotizacion').hide();
            $('#btnModificarCotizacion').show();
        }

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);

        
    }


});
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
                $('#cmbEmpresas').trigger('change');
                $('#txtDescripcionCotizaCompleta').val(value.Concepto);
                $('#cmbContactos').val(value.idContacto.toUpperCase());
                $('#cmbContactos').selectpicker('refresh');
                //$('#cmbProyectos').removeAttr('disabled');
                ObtenerFolioRFQ(value.idRequisicion);
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
            if (data.d == 'SIN RFQ') {

            }
            else {
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
                nodoTRAgregar += "  <td>" + item + "</td>";
                item++;
                nodoTRAgregar += "  <td>" + value.Descripcion + "</td>";
                nodoTRAgregar += "  <td>" + value.Cantidad + "</td>";
                nodoTRAgregar += "  <td>" + value.Unidad + "</td>";
                nodoTRAgregar += "  <td>" + value.Precio + "</td>";
                nodoTRAgregar += "  <td>" + value.Importe + "</td>";
                //nodoTRAgregar += "  <td><span class='btn btn-danger btn-xs fa fa-remove eliminar'></span></td>";
                nodoTRAgregar += "  <td><span class='btn btn-danger icon_close eliminar'></span></td>";

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
        url: 'CotizacionDetalles.aspx/ObtenerEmpresas',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbEmpresas').html('');
            $('#cmbEmpresas').html("<option value=-1>-- SELECCION EMPRESA --</option>");
            $.each(json, function (index, value) {
                $("#cmbEmpresas").append("<option value=" + value.idEmpresa.toUpperCase() + ">" + value.RazonSocial.toUpperCase() + "</option>");
            });
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
                    $("#cmbContactos").append("<option value=" + value.idContacto.toUpperCase() + ">" + value.NombreContacto.toUpperCase() + "</option>");
                });

            }
        });
    }
    else {
        //swal('Ocurrio un problema al obtener contacto de empresa...');
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
    nodoTRAgregar += "  <td>" + item + "</td>";
    nodoTRAgregar += "  <td>" + $('#txtDescripcionCotiza').val() + "</td>";
    nodoTRAgregar += "  <td>" + $('#txtCantidadCotiza').val() + "</td>";
    nodoTRAgregar += "  <td>" + $('#txtUnidadCotiza').val() + "</td>";
    nodoTRAgregar += "  <td>" + $('#txtPrecioCotiza').val() + "</td>";
    nodoTRAgregar += "  <td>" + $('#txtCantidadCotiza').val() * $('#txtPrecioCotiza').val() + "</td>";
    nodoTRAgregar += "  <td><span class='btn btn-danger icon_close eliminar'></span></td>";
    nodoTRAgregar += "</tr>";
    $("#tblItemsCotizacion").append(nodoTRAgregar);

    sumarColumnas();

    $('#txtDescripcionCotiza').val('');
    $('#txtCantidadCotiza').val('');
    $('#txtUnidadCotiza').val('');
    $('#txtPrecioCotiza').val('');
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

function sumarColumnas() {

    var mImporte = 0, mIVA = 0, mTotal = 0, mDescuento = 0;

    $('#tblItemsCotizacion tbody tr').each(function () {

        $(this).children("td").each(function (index2) {
            switch (index2) {
                case 5:
                    mImporte += parseFloat($(this).text().replace(",", ""));
                    break;
            }
        });

    });
    //debugger;
    $('#lblSubTotal').text(formato_numero(mImporte, 2, ".", ","));

    mIVA = mImporte * ($('#txtIVA').val() / 100);
    //debugger;
    $('#lblIVA').text(formato_numero(mIVA, 2, ".", ","));

    mDescuento = $('#txtDescuento').val();

    mTotal = (mImporte - mDescuento) + mIVA;

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

        if ($('#txtReferenciarReqCot').val() == '-1') {
            swal("Proporciona RFQ...");
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
            "','CostoCotizacion': '" + document.getElementById('idTodal').textContent + "'}";

        $.ajax({
            dataType: "json",
            async: true,
            url: "CotizacionesDetalles.aspx/CrearCotizacion",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                if (data.d == "Cotizacion creada.") {
                    $("#tblItemsCotizacion tbody tr").each(function (index) {
                        var item, descripcion, cantidad, unidad, precio, importe

                        $(this).children("td").each(function (index2) {
                            switch (index2) {
                                case 0:
                                    item = $(this).text();
                                    break;
                                case 1:
                                    descripcion = $(this).text();
                                    break;
                                case 2:
                                    cantidad = $(this).text();
                                    break;
                                case 3:
                                    unidad = $(this).text();
                                    break;
                                case 4:
                                    precio = $(this).text();
                                    break;
                                case 5:
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
        if ($('#cmbEmpresas').val() == '-1') {
            swal("Selecciona empresa...");
            return;
        }
        if ($('#cmbContactos').val() == '-1') {
            swal("Selecciona contacto...");
            return;
        }

        if ($('#txtReferenciarReqCot').val() == '-1') {
            swal("Proporciona RFQ...");
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
            "','CostoCotizacion': '" + document.getElementById('idTodal').textContent + "'" +
            " ,'idCotiza': '" + IdCotizaciones + "'}";

        $.ajax({
            dataType: "json",
            async: true,
            url: "CotizacionesDetalles.aspx/ActualizarCotizacion",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                if (data.d == "Cotizacion actualizada.") {
                    $("#tblItemsCotizacion tbody tr").each(function (index) {
                        var item, descripcion, cantidad, unidad, precio, importe

                        $(this).children("td").each(function (index2) {
                            switch (index2) {
                                case 0:
                                    item = $(this).text();
                                    break;
                                case 1:
                                    descripcion = $(this).text();
                                    break;
                                case 2:
                                    cantidad = $(this).text();
                                    break;
                                case 3:
                                    unidad = $(this).text();
                                    break;
                                case 4:
                                    precio = $(this).text();
                                    break;
                                case 5:
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
            swal(
                'Cancelado',
                'Cancelaste modificación de cotización :)',
                'error'
            );
        }
    });

});