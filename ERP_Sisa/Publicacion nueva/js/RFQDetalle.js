$(document).ready(function () {
    var URLactual = window.location;
    var IdRFQ = 0;
    var item = 0;
    if (URLactual.href.indexOf("RFQDetalle.aspx") > -1) {
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        IdRFQ = document.getElementById('MainContent_txtIdRFQ').value;
        CargarEmpresaContacto();
        CargarUsuarios();

        if (IdRFQ != '0') {
            CargarDatosDetalle();
            CargarDatosEncabezado();
            $('#btnGuardarRFQ').hide();
            $('#btnModificarRFQ').show();
        }
        else {

            $('#btnPDFRFQ').hide();
            $('#btnModificarRFQ').hide();
            $('#btnGuardarRFQ').show();
        }

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
        
    }

    $('#btnAgregarRFQ').click(function () {

        if ($('#txtComentariosRFQ').val() == "") {
            swal("Favor de ingresar los datos correcamente...");
            return;
        }

        var nodoTRAgregar = "";

        item++;

        nodoTRAgregar += "<tr>";

        nodoTRAgregar += "  <td>" + $('#txtComentariosRFQ').val() + "</td>";
        
        nodoTRAgregar += "  <td><span class='btn btn-danger icon_close eliminar'></span></td>";

        nodoTRAgregar += "</tr>";
        $("#tblItemsRFQ").append(nodoTRAgregar);

        $('#txtComentariosRFQ').val('');
    });


    function CargarEmpresaContacto() {
        var parametros = "{'pid': '2'}";
        $.ajax({
            dataType: "json",
            url: "RFQDetalle.aspx/ObtenerEmpresas",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {

                        var idContacto = json[index].idContacto;
                        var RazonSocialEmpresa = json[index].RazonSocial;
                        var Contacto = json[index].NombreContacto;
                        //var jsonItem = "{'idSucursa': '" + IdSucursal + "', 'CiudadSucursal': '" + CiudadSucursal + "', 'DireccionSucursal': '" + DireccionSucursal + "', 'TelefonoSucursal': '" + TelefonoSucursal + "' }";                       
                        $("#slctEmpresa").append('<option value="' + idContacto.toUpperCase() + '">' + RazonSocialEmpresa.toUpperCase() + '-' + Contacto.toUpperCase() + '</option>');
                    });
                    $('#slctEmpresa').selectpicker('refresh');
                    $('#slctEmpresa').selectpicker('render');
                }
                else {
                    $("#CargandoEmpresa").append('<div class="alert alert-danger fade in"><p>No se obtuvo información o no tienes permiso de acceso.</p></div >');

                }
            }
        });
    }


    function CargarUsuarios() {
        var parametros = "{'pid': '2'}";
        $.ajax({
            dataType: "json",
            url: "RFQ.aspx/ObtenerUsuarios",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {

                        var IdEmpresa = json[index].IdUsuario;
                        var RazonSocialEmpresa = json[index].NombreCompleto;
                        var Contacto = json[index].Tipo;
                        //var jsonItem = "{'idSucursa': '" + IdSucursal + "', 'CiudadSucursal': '" + CiudadSucursal + "', 'DireccionSucursal': '" + DireccionSucursal + "', 'TelefonoSucursal': '" + TelefonoSucursal + "' }";                       
                        $("#slctVendedor").append('<option value="' + IdEmpresa.toUpperCase() + '">' + RazonSocialEmpresa.toUpperCase() + '-' + Contacto.toUpperCase() + '</option>');
                        $("#slctCoordinador").append('<option value="' + IdEmpresa.toUpperCase() + '">' + RazonSocialEmpresa.toUpperCase() + '-' + Contacto.toUpperCase() + '</option>');
                    });
                    $('#slctVendedor').selectpicker('refresh');
                    $('#slctVendedor').selectpicker('render');
                    $('#slctCoordinador').selectpicker('refresh');
                    $('#slctCoordinador').selectpicker('render');
                }
                else {
                    $("#CargandoEmpresa").append('<div class="alert alert-danger fade in"><p>No se obtuvo información o no tienes permiso de acceso.</p></div >');

                }
            }
        });
    }
    $('#btnGuardarRFQ').click(function () {
        var items = 0;
        var fe = $('#dtCaduca').val();
        if (fe == '') {
            swal('Selecciona fecha');
            return;
        }
        if ($('#txtDescripcion').val() == '') {
            swal('Indica descripción');
            return;
        }
        var a = document.getElementById("slctEmpresa");
        var b = document.getElementById("slctVendedor");
        var c = document.getElementById("slctCoordinador");
        var parametros = "{'pO': '', 'dtCaduca':'" + $('#dtCaduca').val() + "', 'idContacto':'" + a.value + "', 'idVendedor':'" + b.value + "', 'idCoordinador':'" + c.value + "', 'Seguimiento':'" + $('#txtSeguimiento').val() + "', 'Descripcion':'" + $('#txtDescripcion').val() + "'}";
        $.ajax({
            dataType: "json",
            url: "RFQDetalle.aspx/GuardarRFQes",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                var cadena = msg.d.split('.');
                if (cadena[0] == "RFQ creada") {


                    //guardar comentarios
                    $("#tblItemsRFQ tbody tr").each(function (index) {
                        items++;
                    });

                    var itemsGuardados = 0;
                    $("#tblItemsRFQ tbody tr").each(function (index) {
                        var item, descripcion, cantidad, unidad;

                        $(this).children("td").each(function (index2) {
                            switch (index2) {
                                case 0:
                                    descripcion = $(this).html();
                                    break;
                                case 1:
                                    item = $(this).text();
                                    break;
                                case 2:
                                    cantidad = $(this).text();
                                    break;
                                case 3:
                                    unidad = $(this).text();
                                    break;
                            }
                        });

                        var param = "{'pItem': '0','pDescripcio': '" + descripcion + "','pCantidad': '0','pUnidad': '0'}";

                        $.ajax({
                            async: true,
                            url: "RFQDetalle.aspx/GuardarRFQesDetalle",
                            dataType: "json",
                            data: param,
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data, textStatus) {

                                itemsGuardados++;

                            }
                        });
                    });
                    IdRFQ = cadena[1];
                    CargarDatosDetalle();
                    CargarDatosEncabezado();
                    //$("#AddMsgRFQ").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
                else {
                    //$("#AddMsgRFQ").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });

    });
    function CargarDatosDetalle() {
        var params = "{'IdRFQ': '" + IdRFQ + "','Opcion': '" + 2 + "'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'RFQDetalle.aspx/CargarDatosDetalle',
            data: params,
            success: function (data, textStatus) {

                $('#tblItemsRFQ tbody').remove();

                var datos = "";
                var idProv;
                var nodoTRAgregar = "";
                var json = $.parseJSON(data.d);

                $.each(json, function (index, value) {
                    
                    var nodoTRAgregar = "";


                    nodoTRAgregar += "<tr>";

                    nodoTRAgregar += "  <td>" + value.Descripcion + "</td>";
                    
                    nodoTRAgregar += "  <td><span class='btn btn-danger icon_close eliminar'></span></td>";

                    nodoTRAgregar += "</tr>";
                    $("#tblItemsRFQ").append(nodoTRAgregar);


                });

                //fnCargarMateriales(idProv);


            }
        });
    }


    function CargarDatosEncabezado() {
        var params = "{'IdRFQ': '" + IdRFQ + "','Opcion': '" + 1 + "'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'RFQDetalle.aspx/CargarDatosEncabezado',
            data: params,
            success: function (data, textStatus) {

                var json = $.parseJSON(data.d);

                $.each(json, function (index, value) {
                    var a = value.FechaVencimiento.substring(0, 10);
                    document.getElementById("dtCaduca").value = a;
                    //$('#dtCaduca').val(value.FechaVencimiento);
                    //document.getElementById("dtCaduca").value = value.FechaVencimiento;
                    //document.getElementById("slctEmpresa").value = value.IdCliente;
                    $('#slctEmpresa').val(value.IdCliente.toUpperCase());
                    $('#slctEmpresa').selectpicker('refresh');
                    //document.getElementById("slctVendedor").value = value.idVendedor;
                    $('#slctVendedor').val(value.idVendedor.toUpperCase());
                    $('#slctVendedor').selectpicker('refresh');
                    //document.getElementById("slctCoordinador").value = value.idCoordinador;
                    $('#slctCoordinador').val(value.idCoordinador.toUpperCase());
                    $('#slctCoordinador').selectpicker('refresh');
                    $('#txtSeguimiento').val(value.Seguimiento);
                    $('#txtDescripcion').val(value.Descripcion);
                    var Estatus = value.EstatusN;
                    var EstatusDias = value.Estatus;
                    $('#txtDiasResta').val(EstatusDias);
                    if (Estatus == 2 && EstatusDias > 0) {
                        $('#txtEstatus').val("SUPERAMOS EXPECTATIVAS");
                    } else if (Estatus == 1 && EstatusDias > 0) {
                        $('#txtEstatus').val("PENDIENTE");
                    } else if (Estatus == 1 && EstatusDias == 0) {
                        $('#txtEstatus').val("A TIEMPO");
                    } else if (Estatus == 1 && EstatusDias < 0) {
                        $('#txtEstatus').val("RETARDADO");
                    }
                    
                });
               


            }
        });
    }

    $('#btnPDFRFQ').click(function () {
        window.open("ReporteRFQ.aspx?IdRFQ=" + IdRFQ);
    });


    $('#btnModificarRFQ').click(function () {
        var items = 0;
        var fe = $('#dtCaduca').val();
        if (fe == '') {
            swal('Selecciona fecha');
            return;
        }
        if ($('#txtDescripcion').val() == '') {
            swal('Indica descripción');
            return;
        }
        var a = document.getElementById("slctEmpresa");
        var b = document.getElementById("slctVendedor");
        var c = document.getElementById("slctCoordinador");
        var parametros = "{'id': '"+ IdRFQ +"', 'dtCaduca':'" + $('#dtCaduca').val() + "', 'idContacto':'" + a.value + "', 'idVendedor':'" + b.value + "', 'idCoordinador':'" + c.value + "', 'Seguimiento':'" + $('#txtSeguimiento').val() + "', 'Descripcion':'" + $('#txtDescripcion').val() + "'}";
        $.ajax({
            dataType: "json",
            url: "RFQDetalle.aspx/ModificarRFQes",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                var cadena = msg.d.split('.');
                if (cadena[0] == "RFQ modificada") {


                    //guardar comentarios
                    $("#tblItemsRFQ tbody tr").each(function (index) {
                        items++;
                    });

                    var itemsGuardados = 0;
                    $("#tblItemsRFQ tbody tr").each(function (index) {
                        var item, descripcion, cantidad, unidad;

                        $(this).children("td").each(function (index2) {
                            switch (index2) {
                                case 0:
                                    descripcion = $(this).html();
                                    break;
                                case 1:
                                    item = $(this).text();
                                    break;
                                case 2:
                                    cantidad = $(this).text();
                                    break;
                                case 3:
                                    unidad = $(this).text();
                                    break;
                            }
                        });

                        var param = "{'pItem': '0','pDescripcio': '" + descripcion + "','pCantidad': '0','pUnidad': '0'}";

                        $.ajax({
                            async: true,
                            url: "RFQDetalle.aspx/GuardarRFQesDetalle",
                            dataType: "json",
                            data: param,
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data, textStatus) {

                                itemsGuardados++;

                            }
                        });
                    });
                    //IdRFQ = cadena[1];
                    //CargarDatosDetalle();
                    //CargarDatosEncabezado();
                    //$("#AddMsgRFQ").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
                else {
                    //$("#AddMsgRFQ").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });

    });

});

