$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("CajaChicaSucursal.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });
        document.body.style.zoom = "80%";

        CargarCC();
        //CargarProyectos();
        //CargarUsuarios();
        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }



   

    function CargarUsuarios() {
        var params = "{'Opcion': '1'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'CajaChica.aspx/CargarCombos',
            data: params,
            success: function (data, textStatus) {

                var json = $.parseJSON(data.d);

                $('#txtResponsable').html('');
                $('#txtResponsable').html("<option value=-1>-- SELECCIONA RESPONSABLE --</option>");
                $.each(json, function (index, value) {

                    $("#txtResponsable").append('<option value="' + value.Nombre + '">' + value.Nombre.toUpperCase() + '</option>');

                });
                $('#txtResponsable').selectpicker('refresh');
                $('#txtResponsable').selectpicker('render');
            }
        });
    }

    $('#btnEliminarCajaChica').click(function () {
        var id = document.getElementById('idCajaChicaEliminar').textContent;

        var parametros = "{'pid': '" + id + "'}";
        $.ajax({
            dataType: "json",
            url: "CajaChica.aspx/EliminarCC",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Informacion eliminada.") {

                    CargarCC();
                    swal(msg.d);
                }
                else {
                    //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnAgregarCajaChica').click(function () {
        $('#txtidCajaChicaEditar').val(0);
        tipo = 1;
    });

    $('#btnGuardarCajaChica').click(function () {
        $('#txtDireccionEmpresa').val();
        if ($('#txtResponsable').val() == '-1' || $('#txtResponsable').val() == '' || $('#txtConcepto').val() == '' || $('#cmbProyectos').val() == '' || $('#cmbProyectos').val() == '-1' || $('#cmbComprobante').val() == '-1' || $('#cmbComprobante').val() == '' || $('#txtCargo').val() == '' || $('#txtAbono').val() == '' || $('#dtFecha').val() == '' || $('#cmbEstatus').val() == '' || $('#cmbCategoriaCC').val() == '') {
            swal('Todos los campos son obligatorios');
            return;
        }
        var parametros = "{'Responsable':'" + $('#txtResponsable').val() +
            "','Concepto': '" + $('#txtConcepto').val() +
            "', 'pidproyecto':'" + $('#cmbProyectos').val() +
            "', 'Proyecto':'" + $("#cmbProyectos option:selected").text() +
            "', 'Comprobante': '" + $('#cmbComprobante').val() +
            "', 'Cargo': '" + $('#txtCargo').val() +
            "', 'Abono': '" + $('#txtAbono').val() +
            "', 'Fecha':'" + $('#dtFecha').val() +
            "','Estatus':'" + $('#cmbEstatus').val() +
            "', 'Tipo':'" + tipo + "', 'pid':'" + $('#txtidCajaChicaEditar').val() +
            "', 'Categoria':'" + $('#cmbCategoriaCC').val() +
            "', 'CampoExtra':'" + $('#txtResponsable2').val() +
            "', 'OC':'" + $('#cmbOC').val() +
            "', 'nombrearchivo': '" + $('#nombreaarchivopdf').val() +
            "', 'dataarchivo': '" + $('#dataarchivopdf').val() +
            "'}";

        $.ajax({
            dataType: "json",
            url: "CajaChica.aspx/GuardarCC",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                //debugger;
                if (msg.d == "Informacion actualizada.") {
                    //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    //swal(msg.d);

                    swal({
                        title: msg.d
                    }).then((result) => {

                        if (result) {
                            location.reload();
                        }
                    });
                }
                else {
                    //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

   
});

function CargarCC() {
    //$('tbody#listaCajaChica').empty();
    //$('#myPager').html('');
    $('#TablaCajaChica').bootstrapTable('destroy');
    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "CajaChicaSucursal.aspx/ObtenerCC",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = $.parseJSON(data.d);//JSON.parse(data.d);

                $('#TablaCajaChica').bootstrapTable({
                    data: json,
                    detailView: false,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'IdCajaChicaSucursal',
                    uniqueId: 'IdCajaChicaSucursal',
                    onSearch: function (text) {
                        CargarResumen(text);
                    },
                    onExpandRow: function (index, row, $detail) {
                        //$detail.hide().html(row.IdMaterial).fadeIn('slow');
                    },
                    onCollapseRow: function (index, row, $detail) {
                        $detail.clone().insertAfter($detail).fadeOut('slow', function () {
                            $(this).remove()
                        })
                    },
                    exportOptions: {
                        fileName: 'Export_CajaChica'
                    },
                    rowStyle: function (row, index) {

                        /*
                         0 = PENDIENTE O NUEVO
                         1 = POR INICIAR
                         2 = EN PROCESO
                         3 = TERMINADO
                         4 = CANCELADO

                        */

                        if (row.Estatus == 0) {
                            return {
                                classes: 'warning'
                            };
                        }
                        else {
                            return {
                                classes: ''
                            };
                        }


                    }
                });

            }
            else {
                $("#CargandoCajaChica").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

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

function dateFormat(value, row, index) {
    return moment(value).format('YYYY-MM-DD');
}

function formatoMonedaFormatter(value) {
    return formato_numero(value, 2, ".", ",");
}

function accionCC1Formatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Editar" class="btn btn-info editar"> <i class="icon_table"></i></span>',
        /*'<span title="Eliminar" class="btn btn-danger eliminar"><i class="icon_close_alt2"></i></span>',*/
        //'<span title="Ver Archivo" class="btn btn-warning verArchivo"><i class="fa fa-file-o" aria-hidden="true"></i></span>',
        //'<span title="Subir Archivo" class="btn btn-success subirArchivo"><i class="fa fa-file-o" aria-hidden="true"></i></span>',
        '</div>'
    ].join(' ');
}

window.accionCC1Events = {
    'click .editar': function (e, value, row, index) {

        var IdCajaChicaSucursal = row.IdCajaChicaSucursal;
        tipo = 2;

        CargarProyectos();
        CargarInfoCajaChica(IdCajaChicaSucursal);
        
        $('#btnAgregarGastos').attr('rel', IdCajaChicaSucursal);
        CargarViaticoTodo(IdCajaChicaSucursal);

        $('#AddCajaChicaModal').modal();
        //$('#EditarCajaChicaForm').empty();
        //$(btn.value).each(function (index, item) {
        //    var IdCajaChica = json[index].idSucursa;
        //    var CiudadCajaChica = json[index].CiudadCajaChica;
        //    var DireccionCajaChica = json[index].DireccionCajaChica;
        //    var TelefonoCajaChica = json[index].TelefonoCajaChica;
        //    $('#EditarCajaChicaForm').append(' <div class= "modal-body" >  <div class="form-group"> <div class="col-sm-10"> <input type="hidden" class="form-control" id="txtidCajaChicaEditar" value="' + IdCajaChica + '" required/></div></div<div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtCiudadCajaChicaEditar" value="' + CiudadCajaChica + '" required/></div></div><div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtDireccionCajaChicaEditar" value="' + DireccionCajaChica + '" required/></div></div><div class="form-group"> <div class="col-sm-10"><input type="tel" class="form-control"  id="txtTelefonoCajaChicaEditar" value="' + TelefonoCajaChica + '" required/></div> </div>  <div class="form-group"> <div class="col-sm-10"><div class="form-group" id="txtModalEditarMensajeCajaChica"> </div></div> </div> </div > <div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> <button class="btn btn-primary" id="btnEditarCajaChica" type="button">Guardar cambios</button> </div>');
        //});
        //var parametros = "{'pid': '" + idCajaChica + "'}";
        //$.ajax({
        //    dataType: "json",
        //    url: "CajaChica.aspx/ObtenerCC",
        //    async: true,
        //    data: parametros,
        //    type: "POST",
        //    contentType: "application/json; charset=utf-8",
        //    success: function (data) {
        //        if (data.d != "") {
        //            var json = JSON.parse(data.d);
        //            $(json).each(function (index, item) {
        //                var IdCajaChica = item.IdCajaChica;
        //                var Responsable = item.Responsable;
        //                var Responsable2 = item.CampoExtra;
        //                var Concepto = item.Concepto;
        //                var Proyecto = item.Proyecto;
        //                var Comprobante = item.Comprobante;
        //                var Cargo = item.Cargo;
        //                var Abono = item.Abono;
        //                var Saldo = item.Saldo;
        //                var Fecha = item.Fecha.substring(0, 10);
        //                var Estatus = item.Estatus;
        //                var Categoria = item.Categoria;
        //                var IdProyecto = item.IdProyecto;
        //                var OC = item.FolioOrdenCompra;

        //                $('#txtidCajaChicaEditar').val(IdCajaChica);
        //                $('#dtFecha').val(Fecha);
        //                $('#txtResponsable').val(Responsable);
        //                $('#txtResponsable2').val(Responsable2);
        //                $('#txtConcepto').val(Concepto);
        //                CargarProyectosEditarCC(IdProyecto);
        //                $('#cmbComprobante').val(Comprobante);
        //                //$('#txtCargo').val(formato_numero(Cargo, 2, '.', ','));
        //                //$('#txtAbono').val(formato_numero(Abono, 2, '.', ','));
        //                $('#txtCargo').val(Cargo);
        //                $('#txtAbono').val(Abono);
        //                $('#cmbEstatus').val(Estatus);
        //                $('#cmbCategoriaCC').val(Categoria);
        //                $('#cmbOC').val(OC);

        //                $('#txtResponsable').val(Responsable);
        //                $('#txtResponsable').selectpicker('refresh');


        //            });
        //            $("#AddCajaChicaModal").modal();
        //        }
        //        else {
        //            $("#CargandoCajaChica").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

        //        }
        //    }
        //});
    },
    'click .eliminar': function (e, value, row, index) {
        var idCajaChica = row.IdCajaChica;
        //var folio = row.Folio;

        document.getElementById('idCajaChicaEliminar').textContent = '';
        document.getElementById('idCajaChicaEliminarTexto').textContent = '¿Estás seguro de eliminar información de caja chica con código "' + idCajaChica + '"?';


        document.getElementById('idCajaChicaEliminar').textContent = idCajaChica;

        $("#DelCajaChicaModal").modal();
    },
    'click .verArchivo': function (e, value, row, index) {
        $('#testmodalpdf').html('');
        var idCajaChica = row.IdCajaChica;
        tipo = 2;
        //var parametros = "{'pid': '" + idCajaChica + "'}";
        //$.ajax({
        //    dataType: "json",
        //    url: "CajaChica.aspx/ObtenerCC",
        //    async: true,
        //    data: parametros,
        //    type: "POST",
        //    contentType: "application/json; charset=utf-8",
        //    success: function (data) {
        //        if (data.d != "") {
        //            var json = JSON.parse(data.d);

        //            $(json).each(function (index, item) {
        //                document.getElementById('txtidCajaChicaArchivo').textContent = item.idCajaChica;
        //                $('#testmodalpdf').append('<object id="visorPDF" data="' + item.Archivo + '" type="application/pdf" style="width:100%; height: 800px;"></object>');
        //            });
        //            $("#dvPDF").modal();
        //        }
        //        else {
        //            $("#CargandoCajaChica").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

        //        }
        //    }
        //});

        var params = "{'IdDocumento': '" + 0 +
            "','IdCajaChica': '" + idCajaChica +
            "','FileName': '" + "" +
            "','File': '" + "" +
            "','Opcion': '" + "8" + "'}";

        //console.log(params);

        $.ajax({
            async: true,
            url: "CajaChica.aspx/CargarDocumentos",
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
                $("#GaleriaArchivosProyectosModal").modal();
            }
        });

    },
    'click .subirArchivo': function (e, value, row, index) {
        $('#testmodalpdf').html('');
        var idCajaChica = row.IdCajaChica;
        tipo = 2;

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

                var params = "{'IdCajaChica': '" + idCajaChica +
                    "','FileName': '" + nombreArchivo +
                    "','FileSize': '" + fileSize +
                    "','FileType': '" + filetype +
                    "','File': '" + e.target.result + "'}";

                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "CajaChica.aspx/GuardarImagenTarea",
                    data: params,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        //location.href = './frmProjects.aspx';

                        swal({
                            title: msg.d,
                            timer: 2000
                        }).then(function () {
                            //cargarArchivos();
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
    }
};

$('#btnAgregarGastos').click(function () {
    
    var IdCajaChicaSucursal = $(this).attr('rel');
    var txtDescripcion = $('#txtDescripcion').val();

    var txtCantidad = $('#txtCantidad').val();
    var cmbProyecto = $('#cmbProyectos').val();

    var cmbGasto = $('#cmbGasto').val();
    var txtFechaGasto = $('#dtFechaGasto').val();

    var Tick = $("[id*='ImgPrv']").prop('src');
    if (txtDescripcion == "" || txtCantidad == "" || cmbProyecto == "-1" || cmbGasto == "-1" || txtFechaGasto == undefined) {
        //$("#MensajeViaticos").append('<div class="alert alert-danger fade in"><p>Completa los campos obligatorios.</p></div >');
        swal('Completa los campos obligatorios.');
    }
    else {
        var parametros = "{'IdProyecto': '" + cmbProyecto +
            "', 'Concepto': '" + txtDescripcion +
            "', 'Cantidad': '" + txtCantidad +
            "', 'TipoGasto': '" + cmbGasto +
            "', 'FechaGasto': '" + txtFechaGasto +
            "', 'IdCajaChicaSucursal': '" + IdCajaChicaSucursal +
            "', 'Tick': '" + Tick +
            "'}";

       // console.log(parametros);

        $.ajax({
            dataType: "json",
            url: "CajaChicaSucursal.aspx/GuardarDetalle",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Detalle creado.") {
                    //$("#MensajeViaticos").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarViaticoTodo(IdCajaChicaSucursal);
                    swal(msg.d);
                }
                else {
                    // $("#MensajeViaticos").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    }

});

function CargarProyectos() {
    var params = "{'Opcion': '10'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'CajaChicaSucursal.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {
            //debugger;
            var json = $.parseJSON(data.d);
            $('#cmbProyectos').html('');
            $('#cmbProyectos').append('<option value="-1"> -- SELECCIONE PROYECTO -- </option>');
            $.each(json, function (index, value) {
                $("#cmbProyectos").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
            });

            $('#cmbProyectos').selectpicker('refresh');
            $('#cmbProyectos').selectpicker('render');
        }

    });
}

function CargarInfoCajaChica(IdCajaChicaSucursal) {
    var params = "{'id': '" + IdCajaChicaSucursal + "'}";
    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'CajaChicaSucursal.aspx/CargarInfoGeneral',
        data: params,
        success: function (data, textStatus) {

            var json = JSON.parse(data.d);

            /*$('#cmbProyectos').html('');*/
            $(json).each(function (index, value) {
                /*$('#lblProyecto').text(value.NombreProyecto);*/
                $('#lblCantEntregada').text(formato_numero(value.CantEntregada, 2, ".", ","));
                $('#lblCantGastada').text(formato_numero(value.CantGastada, 2, ".", ","));
                $('#lblDiferencia').text(formato_numero(value.Diferencia, 2, ".", ","));
                $('#lblResponsable').text(value.Responsable);
                //$('#lblProyectoPrincipal').text(value.ProyectoOtorga);
                //$("#cmbProyectos").append("<option value=" + value.idProyectoOtorga + ">" + value.ProyectoOtorga.toUpperCase() + "</option>");
            });


        }
    });
}

function ShowImagePreview(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("[id*='ImgPrv']").prop('src', e.target.result)
                .width(240)
                .height(150);
        };
        reader.readAsDataURL(input.files[0]);
    }
}

function CargarViaticoTodo(IdCajaChicaSucursal) {
    var params = "{'IdCajaChicaSucursal': '" + IdCajaChicaSucursal + "'}";
    var idProyecto = '';
    var Nom = '';
    $.ajax({
        async: true,
        url: "CajaChicaSucursal.aspx/Cargar",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            //debugger;
            var datos = "";
            var nodoTRAgregar = "";
            var JsonCombos;
            var jsonStr = $.parseJSON(data.d);
            var CantGastada = 0;
            $('#tblViaticos tbody').html('');
            $.each(jsonStr, function (index, value) {
                //$('#lblProyecto').text(value.NombreProyecto);
                $('#lblCantEntregada').text(formato_numero(value.CantEntregada, 2, ".", ","));
                $('#lblCantGastada').text(formato_numero(value.TotGastos, 2, ".", ","));
                $('#lblDiferencia').text(formato_numero((value.CantEntregada - value.TotGastos), 2, ".", ","));
                $('#lblResponsable').text(value.Responsable);
                //$('#lblProyectoPrincipal').text(value.ProyectoOtorga);
                //$("#cmbProyectos").append("<option value=" + value.idProyectoOtorga + ">" + value.ProyectoOtorga.toUpperCase() + "</option>");
                var Ticket = value.Ticket;
                if (Ticket == "NULL" || Ticket === null || Ticket == '') {
                    Ticket = '<Button title="Agregar ticket" class="btn btn-danger" value="' + value.IdCajaChicaSucursalDetalle + '" onclick="AgregarTicket(this);"><i class="icon_document_alt"></i></Button>';

                }
                else {
                    Ticket = '<Button title="Ver ticket" class="btn btn-info" value="' + value.IdCajaChicaSucursalDetalle + '" onclick="VisualizarDocumentoTicket(this);"><i class="icon_document"></i></Button>';

                }
                //idProyecto = value.IdProyecto;
                //Nom = value.NombreProyecto;
                CantGastada += value.CantidadGastada;
                nodoTRAgregar += "<tr>";

                nodoTRAgregar += "<td>" + value.ID + "</td>";
                nodoTRAgregar += "<td>" + value.FechaGasto.substring(0, 10) + "</td>";
                nodoTRAgregar += "<td>" + value.NombreProyecto + "</td>";
                nodoTRAgregar += "<td>" + value.Concepto + "</td>";
                nodoTRAgregar += "<td>" + formato_numero(value.CantidadGastada, 2, '.', ',') + "</td>";
                nodoTRAgregar += "<td>" + value.TipoGasto + "</td>";
                nodoTRAgregar += '<td><div class="btn-group">' + Ticket +
                    '<Button title = "Eliminar" class="btn btn-danger" value = "' + value.IdCajaChicaSucursalDetalle + '" onclick = "EliminarCajaChicaSucursalDet(this);" > <i class="icon_close_alt"></i></Button>'
                    + "</div></td>";
                nodoTRAgregar += "</tr>";
            });
            //CargarProyectos(idProyecto, Nom);
            //$("#cmbProyectos").val(idProyecto);

            $('#tblViaticos').append(nodoTRAgregar);
            $('#lblGastos').text(formato_numero(CantGastada, 2, '.', ','));
            //sumarColumnas();
        }
    });
}


function AgregarTicket(btn) {
    swal({
        title: 'Seleccione ticket (Imágen)',
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
            var IdDetalle = $('#btnAgregarGastos').attr('rel');

            var params = "{'TipoDoc': '" + '1' +
                "','Id': '" + btn.value +
                "','FileName': '" + nombreArchivo +
                "','File': '" + e.target.result + "'}";

            //console.log(params);
            $.ajax({
                dataType: "json",
                async: true,
                url: "CajaChicaSucursal.aspx/GuardarDocumentos",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    //location.href = './frmProjects.aspx';

                    swal({
                        title: msg.d,
                        timer: 3000
                    });
                    CargarViaticoTodo(IdDetalle);
                    //location.reload();
                    //cargarArchivos();
                },
                error: function (xhr, ajaxOptions, thrownError) {

                }
            });


        }

        reader.readAsDataURL(file);

    });
}

function VisualizarDocumentoTicket(btn) {

    $('#testmodalpdfTicket').html('');

    var params = "{'Id': '" + btn.value +
        "','Opcion': '" + "T" + "'}";
    //console.log(params);
    $.ajax({
        async: true,
        url: "CajaChicaSucursal.aspx/CargarDocumentos",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            var datos = "";

            var JsonCombos;
            var jsonArray = $.parseJSON(data.d);


            $.each(jsonArray, function (index, value) {
                document.getElementById('txtTipoDocumentoTicket').textContent = "T";

                document.getElementById('txtidArchivoTicket').textContent = value.IdCajaChicaSucursalDetalle;
                if (value.Ticket.includes("PDF") || value.Ticket.includes("pdf")) {

                    $('#testmodalpdfTicket').append('<embed src="' + value.Ticket + '" type="application/pdf" width="100%" height="600px" />');
                }
                else {

                    $('#testmodalpdfTicket').append('<img src="' + value.Ticket + '" width="100%" height="600"/>');
                }

            });
        }
    });
    $("#dvPDFTicket").modal();

}

$('#btnEliminadDocumentoTicket').click(function () {
    swal({
        title: 'Estas Seguro que quieres eliminar el ticket?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Aceptar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {

        if (result) {

            var tipo = document.getElementById('txtTipoDocumentoTicket').textContent;
            var id = document.getElementById('txtidArchivoTicket').textContent;
            var IdDetalle = $('#btnAgregarGastos').attr('rel');

            var parametros = "{'Id': '" + id + "', 'Opcion':'" + tipo + "'}";
            $.ajax({
                dataType: "json",
                url: "CajaChicaSucursal.aspx/EliminarDocumento",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Documento eliminado.") {
                        // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                        CargarViaticoTodo(IdDetalle);
                        //console.log(IdDetalle);
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

function EliminarCajaChicaSucursalDet(btn) {

    swal({
        title: "Esta seguro que desea eliminar información de Caja Chica?",
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

        var IdDetalle = $('#btnAgregarGastos').attr('rel');
        var params = "{'Id': '" + btn.value + "', 'Gastada':'" + document.getElementById('lblCantGastada').textContent + "', 'Entregada':'" + document.getElementById('lblCantEntregada').textContent + "', 'Diferencia':'" + document.getElementById('lblDiferencia').textContent + "'}";

        $.ajax({
            dataType: "json",
            async: true,
            url: "CajaChicaSucursal.aspx/EliminarCajaChicaDet",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                swal({
                    title: msg.d,
                    timer: 3000
                });
                CargarViaticoTodo(IdDetalle);
                //setTimeout(function () { location.reload() }, 1000);
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
                'Cancelaste eliminación.',
                'error'
            );
        }
    });
}