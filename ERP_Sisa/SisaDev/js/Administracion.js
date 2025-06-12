$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("Administracion.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });
        document.body.style.zoom = "80%";

        //CargarProyectos();
        CargarProyectosNEW();
        CargarTotal();
        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
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

    function CargarTotal() {
        var params = "{'Opcion': '" + "1" + "'}";

        $.ajax({
            async: true,
            url: "Administracion.aspx/CargarTotal",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var jsonArray = $.parseJSON(data.d);


                $('#lblProyectosSinPO').html('');
                $('#lblProyectoSinFactura').html('');
                $('#lblProyectoFacturado').html('');
                $.each(jsonArray, function (index, value) {
                    $('#lblProyectosSinPO').text("$ " + formato_numero(value.Total, 2, '.', ','));
                    $('#lblProyectoSinFactura').text("$ " + formato_numero(value.TotalSinFactura, 2, '.', ','));
                    $('#lblProyectoFacturado').text("$ " + formato_numero(value.TotalFacturado, 2, '.', ','));
                });

            }
        });
    }

    function CargarProyectosNEW() {
        //$('tbody#listaOC').empty();
        //$('#myPager').html('');
        var parametros = "{'pid': '1'}";
        $.ajax({
            dataType: "json",
            url: "Administracion.aspx/ObtenerProyectos",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                //debugger;
                var jsonArray = $.parseJSON(data.d);

                //$('#TablaOC').bootstrapTable('destroy');

                data = jsonArray;
                //debugger;
                $('#TablaAdministracion').bootstrapTable('destroy');

                $('#TablaAdministracion').bootstrapTable({
                    data: data,
                    detailView: false,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'IdProyecto',
                    uniqueId: 'IdProyecto',
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

                        if (row.Estatus == 1 || row.Enviada == "1") {
                            return {
                                classes: 'estatusPorIniciar'
                            };
                        }
                        else if (row.Estatus == 2 || row.Estatus == "2") {
                            return {
                                classes: 'estatusEnProceso'
                            };
                        }
                        else if (row.Estatus == 3 || row.Estatus == "3") {
                            return {
                                classes: 'estatusCierreOperativo'
                            };
                        }
                        else if (row.Estatus == 4 || row.Estatus == "4") {
                            return {
                                classes: 'estatusCancelado'
                            };
                        }
                        else if (row.Estatus == 5 || row.Estatus == "5") {
                            return {
                                classes: 'estatusTerminado'
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

                //cargaPagosMultiplesPendientes();

            }
        });

    }


    function CargarProyectos() {
        $('tbody#listaAdministracion').empty();
        var parametros = "{'pid': '1'}";
        $.ajax({
            dataType: "json",
            url: "Administracion.aspx/ObtenerProyectos",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "No tienes permiso.") {
                    var json = JSON.parse(data.d);

                    $(json).each(function (index, item) {
                        
                        var idProyecto = item.IdProyecto; //json[index].IdProyecto;
                        var Folio = item.FolioProyecto; //json[index].FolioProyecto;
                        var NombreProyecto = item.NombreProyecto;
                        var Contacto = item.ContactoCliente;
                        var Empresa = item.Cliente;
                        var Lider = item.LiderProyecto;
                        var FechaI = item.FechaInicio.substring(0, 10);
                        var FechaT = item.FechaFin.substring(0, 10);
                        var Estatus = item.Estatus;
                        var OC = item.OC;
                        var CL = item.CL;
                        var Porcentaje = item.Porcentaje;
                        var PorcentajePagado = item.PorcentajePagado;
                        var PorcentajePagoProv = formato_numero(item.PorcentajeGastos, 2, '.', ',');
                        var CostoMaterialProyectado = item.CostoMaterialProyectado;
                        var CostoMOProyectado = item.CostoMOProyectado;
                        var CostoMEProyectado = item.CostoMEProyectado;
                        var Sucursal = item.Sucursal;
                        var idSucursal = item.idSucursal;
                        var FolioPO = item.FolioPO;
                        var Avance = item.Avance;
                        var IdLider = item.IdLider;
                        var EsCCM = item.EsCCM;
                        

                        if (Porcentaje == null) { Porcentaje = '0'; }
                        if (PorcentajePagado == null) { PorcentajePagado = '0'; }
                        if (OC == "NULL" || OC === null || OC == '') {
                            OC = '<Button title="Agregar OC" class="btn btn-danger" value="' + idProyecto + '" onclick="AgregarOC(this);"><i class="icon_close"></i></Button>';

                        }
                        else {
                            OC = '<Button title="Ver OC" class="btn btn-info" value="' + idProyecto + '" onclick="VisualizarDocumentoOC(this);"><i class="icon_document"></i></Button>';

                        }

                        if (CL == "NULL" || CL === null || CL == '') {
                            CL = '<Button title="Agregar CL" class="btn btn-danger" value="' + idProyecto + '" onclick="AgregarCL(this);"><i class="icon_close"></i></Button>';

                        }
                        else {
                            CL = '<Button title="Ver CL" class="btn btn-info" value="' + idProyecto + '" onclick="VisualizarDocumentoCL(this);"><i class="icon_document"></i></Button>';
                        }

                        var botonCierreAdministrativo = '';
                        var botonCierreOperativo = '';
                        var botonCambiaEstatus = '';
                        var botonCancelar = '';
                        var trstyle = '';
                        if (Estatus == '0') {
                            Estatus = "PENDIENTE";
                            botonCierreAdministrativo = '<Button title="Finalizar" class="btn btn-success disabled" value="' + idProyecto + '" rel="' + Folio + '" onclick="FinalizarProyecto(this);"><i class="fa fa-handshake-o"></i></Button>';
                            botonCierreOperativo = '<Button title="Cierre Operativo" class="btn btn-warning disabled" value="' + idProyecto + '" rel="' + Folio + '" onclick="TerminarProyecto(this);"><i class="icon_check"></i></Button>';
                            botonCambiaEstatus = '<Button title="Cambiar estatus" class= "btn btn-info" value="' + idProyecto + '" rel="' + Folio + '" onclick="CambiarEstatus(this);"> <i class="icon_tags"></i></Button>';
                            botonCancelar = '<Button title="Cancelar" class="btn btn-danger" value="' + idProyecto + '" rel="' + Folio + '" onclick="CancelarProyecto(this);"><i class="icon_close_alt2"></i></Button>';
                        } else if (Estatus == '1') {
                            trstyle = 'style="background-color: lightskyblue;"';
                            Estatus = "POR INICIAR";
                            botonCierreAdministrativo = '<Button title="Finalizar" class="btn btn-success disabled" value="' + idProyecto + '" rel="' + Folio + '" onclick="FinalizarProyecto(this);"><i class="fa fa-handshake-o"></i></Button>';
                            botonCierreOperativo = '<Button title="Cierre Operativo" class="btn btn-warning disabled" value="' + idProyecto + '" rel="' + Folio + '" onclick="TerminarProyecto(this);"><i class="icon_check"></i></Button>';
                            botonCambiaEstatus = '<Button title="Cambiar estatus" class= "btn btn-info" value="' + idProyecto + '" rel="' + Folio + '" onclick="CambiarEstatus(this);"> <i class="icon_tags"></i></Button>';
                            botonCancelar = '<Button title="Cancelar" class="btn btn-danger" value="' + idProyecto + '" rel="' + Folio + '" onclick="CancelarProyecto(this);"><i class="icon_close_alt2"></i></Button>';
                        } else if (Estatus == '2') {
                            trstyle = 'style="background-color: wheat;"';
                            Estatus = "EN PROCESO";
                            botonCierreAdministrativo = '<Button title="Finalizar" class="btn btn-success disabled" value="' + idProyecto + '" rel="' + Folio + '" onclick="FinalizarProyecto(this);"><i class="fa fa-handshake-o"></i></Button>';
                            botonCierreOperativo = '<Button title="Cierre Operativo" class="btn btn-warning" value="' + idProyecto + '" rel="' + Folio + '" onclick="TerminarProyecto(this);"><i class="icon_check"></i></Button>';
                            botonCambiaEstatus = '<Button title="Cambiar estatus" class= "btn btn-info" value="' + idProyecto + '" rel="' + Folio + '" onclick="CambiarEstatus(this);"> <i class="icon_tags"></i></Button>';
                            botonCancelar = '<Button title="Cancelar" class="btn btn-danger" value="' + idProyecto + '" rel="' + Folio + '" onclick="CancelarProyecto(this);"><i class="icon_close_alt2"></i></Button>';
                        } else if (Estatus == '3') {
                            trstyle = 'style="background-color: #896A46; color: black;"';
                            Estatus = "CIERRE OPERATIVO";
                            botonCierreAdministrativo = '<Button title="Finalizar" class="btn btn-success" value="' + idProyecto + '" rel="' + Folio + '" onclick="FinalizarProyecto(this);"><i class="fa fa-handshake-o"></i></Button>';
                            botonCierreOperativo = '<Button title="Cierre Operativo" class="btn btn-warning disabled" value="' + idProyecto + '" rel="' + Folio + '" onclick="TerminarProyecto(this);"><i class="icon_check"></i></Button>';
                            botonCambiaEstatus = '<Button title="Cambiar estatus" class= "btn btn-info" value="' + idProyecto + '" rel="' + Folio + '" onclick="CambiarEstatus(this);"> <i class="icon_tags"></i></Button>';
                            botonCancelar = '<Button title="Cancelar" class="btn btn-danger disabled" value="' + idProyecto + '" rel="' + Folio + '" onclick="CancelarProyecto(this);"><i class="icon_close_alt2"></i></Button>';
                        } else if (Estatus == '4') {
                            trstyle = 'style="background-color: #ffa084;"';
                            Estatus = "CANCELADO";
                            botonCierreAdministrativo = '<Button title="Finalizar" class="btn btn-success disabled" value="' + idProyecto + '" rel="' + Folio + '" onclick="FinalizarProyecto(this);"><i class="fa fa-handshake-o"></i></Button>';
                            botonCierreOperativo = '<Button title="Cierre Operativo" class="btn btn-warning disabled" value="' + idProyecto + '" rel="' + Folio + '" onclick="TerminarProyecto(this);"><i class="icon_check"></i></Button>';
                            botonCambiaEstatus = '<Button title="Cambiar estatus" class= "btn btn-info disabled" value="' + idProyecto + '" rel="' + Folio + '" onclick="CambiarEstatus(this);"> <i class="icon_tags"></i></Button>';
                            botonCancelar = '<Button title="Cancelar" class="btn btn-danger disabled" value="' + idProyecto + '" rel="' + Folio + '" onclick="CancelarProyecto(this);"><i class="icon_close_alt2"></i></Button>';
                        }else if (Estatus == '5') {
                            trstyle = 'style="background-color: #90ee90;"';
                            Estatus = "TERMINADO";
                            botonCierreAdministrativo = '<Button title="Finalizar" class="btn btn-success disabled" value="' + idProyecto + '" rel="' + Folio + '" onclick="FinalizarProyecto(this);"><i class="fa fa-handshake-o"></i></Button>';
                            botonCierreOperativo = '<Button title="Cierre Operativo" class="btn btn-warning disabled" value="' + idProyecto + '" rel="' + Folio + '" onclick="TerminarProyecto(this);"><i class="icon_check"></i></Button>';
                            botonCambiaEstatus = '<Button title="Cambiar estatus" class= "btn btn-info disabled" value="' + idProyecto + '" rel="' + Folio + '" onclick="CambiarEstatus(this);"> <i class="icon_tags"></i></Button>';
                            botonCancelar = '<Button title="Cancelar" class="btn btn-danger disabled" value="' + idProyecto + '" rel="' + Folio + '" onclick="CancelarProyecto(this);"><i class="icon_close_alt2"></i></Button>';
                        }

                        if (EsCCM == 1) {
                            EsCCM = '<i class="glyphicon glyphicon-ok-circle fa-lg" style="color: green;"></i>';
                        }
                        else {
                            EsCCM = '<i class="glyphicon glyphicon-remove-circle fa-lg" style="color: red;"></i>';
                        }

                        $('tbody#listaAdministracion').append(
                            '<tr ' + trstyle + '><td style="display:none;">'
                            + idProyecto
                            + '</td>'
                            + '<td>'
                            + Folio
                            + '</td>'
                            + '<td>'
                            + NombreProyecto
                            + '</td>'
                            + '<td>'
                            + EsCCM
                            + '</td>'
                            + '<td>'
                            + FolioPO
                            + '</td>'
                            + '<td>'
                            + Contacto
                            + '</td>'
                            + '<td>'
                            + Empresa
                            + '</td>'
                            + '<td>'
                            + Lider
                            + '</td>'
                            + '<td>'
                            + Sucursal
                            + '</td>'
                            + '<td>'
                            + FechaI
                            + '</td>'
                            + '<td>'
                            + FechaT
                            + '</td>'
                            + '<td>'
                            + Avance + '%'
                            + '<div class="progress progress-striped"><div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="' + Avance + '" aria-valuemin="0" aria-valuemax="100" style="width:' + Avance + '%"></div></div>'
                            + Estatus
                            + '</td>'
                            //+ '<td>'
                            //+ formato_numero(CostoMOProyectado,2,'.',',')
                            //+ '</td>'
                            //+ '<td>'
                            //+ formato_numero(CostoMaterialProyectado, 2, '.', ',')
                            //+ '</td>'
                            //+ '<td>'
                            //+ formato_numero(CostoMEProyectado, 2, '.', ',')
                            //+ '</td>'
                            + '<td>'
                            + OC
                            + '</td>'
                            + '<td>'
                            + CL
                            + '</td>'
                            + '<td>'
                            + '<div class="progress progress-striped"><div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="' + Porcentaje + '" aria-valuemin="0" aria-valuemax="100" style="width:' + Porcentaje + '%"> <span class="sr-only">' + Porcentaje + '%</span></div></div>'
                            + Porcentaje + '%'
                            + '</td>'
                            + '<td>'
                            + '<div class="progress progress-striped"><div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="' + PorcentajePagado + '" aria-valuemin="0" aria-valuemax="100" style="width:' + PorcentajePagado + '%"> <span class="sr-only">' + PorcentajePagado + '%</span></div></div>'
                            + PorcentajePagado + '%'
                            + '</td>'
                            + '<td>'
                            + '<div class="progress progress-striped"><div class="progress-bar progress-bar-warning" role="progressbar" aria-valuenow="' + PorcentajePagoProv + '" aria-valuemin="0" aria-valuemax="100" style="width:' + PorcentajePagoProv + '%"> <span class="sr-only">' + PorcentajePagoProv + '%</span></div></div>'
                            + PorcentajePagoProv + '%'
                            + '</td>'
                            + '<td>'
                            + '<div class="btn-group">'
                            //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                            + '<Button title="Cambiar lider" class="btn btn-warning" value="' + idProyecto + '" rel="' + Folio + '" name="' + IdLider + '" data-subtext="' + NombreProyecto + '&_' + FolioPO + '&_' + idSucursal + '" onclick="CambiarLider(this);"><i class="icon_profile"></i></Button>'
                            + '<Button title="Editar monto" class="btn btn-default" value="' + idProyecto + '" rel="' + Folio + '" onclick="CambiarMonto(this);"><i class="icon_currency"></i></Button>'
                            + '<Button title="Grafica" class="btn btn-default" value="' + idProyecto + '" rel="' + Folio + '" onclick="AbriGrafica(this);"><i class="fa fa-pie-chart" aria-hidden="true"></i></Button>'
                            + '<Button title="Editar fechas" class="btn btn-success" value="' + idProyecto + '" rel="' + Folio + '" onclick="EditarProyectoFechas(this);"><i class="icon_calendar"></i></Button>'
                            + botonCancelar
                            + '<Button title="Avance %" class="btn btn-info" value="' + idProyecto + '" rel="' + Folio + '" onclick="AvanceProyecto(this);"><i class="fa fa-line-chart" aria-hidden="true"></i></Button>'
                            + '</div > '
                            + '</td>'
                            + '<td>'
                            + '<div class="btn-group">'
                            /*+ '<Button title="Horas hombre" class="btn btn-warning" value="' + idProyecto + '" onclick="HorasHombre(this);"><i class="icon_group"></i></Button>'*/
                            + botonCambiaEstatus
                            + '<Button title="Editar gastos" class="btn btn-default" value="' + idProyecto + '" rel="' + Folio + '" onclick="EditarGastos(this);"><i class="icon_pencil"></i></Button>'
                            + botonCierreOperativo
                            + '<Button title="Agregar comentario" class= "btn btn-info" value="' + idProyecto + '" onclick="AgregarComentario(this);"> <i class="icon_comment_alt"></i></Button>'
                            + botonCierreAdministrativo
                            + '</div > '
                            + '</td>'
                            + '<td style="display:none;">'
                            + item.FechaAlta
                            + '</td>'
                            + '<td style="display:none;">'
                            + item.Estatus
                            + '</td>'
                            + '</tr>')
                    });
                    // $('#listaAdministracion').pageMe({ pagerSelector: '#myPagerProy2', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
                    $('#TablaAdministracion').DataTable({
                        "bLengthChange": false,
                        "pageLength": 100,
                        "order": [[20, "asc"], [19, "desc"]],
                        "bFilter": true,//oculta el texto para buscar
                        //"oLanguage": {
                        //    "sSearch": "Buscar:"
                        //},
                        "retrieve": true
                    });

                    //cargaCombosFiltrosProyectos(26);
                    //cargaCombosFiltrosProyectos(22);
                    //cargaCombosFiltrosProyectos(23);
                    //cargaCombosFiltrosProyectos(24);
                    //cargaCombosFiltrosProyectos(25);
                }
                else {
                    $("#CargandoAdministracion").append('<div class="alert alert-danger fade in"><p>No se obtuvo información, pueden ser motivos de permiso..</p></div >');

                }
            }
        });
    }

    function cargaCombosFiltrosProyectos(Opcion) {
        var params = "{'Opcion': '" + Opcion + "'}";

        $.ajax({
            async: true,
            url: "Administracion.aspx/cargaCombosFiltrosBuscar",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var jsonArray = $.parseJSON(data.d);

                //proyectos
                if (Opcion == 26) {
                    $('#cmbProyectoBuscar').html('');
                    $('#cmbProyectoBuscar').html('<option value="-1">--Selecciona--</option>');
                    $.each(jsonArray, function (index, value) {
                        $("#cmbProyectoBuscar").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                    });

                    $('#cmbProyectoBuscar').selectpicker('refresh');
                    $('#cmbProyectoBuscar').selectpicker('render');
                }

                if (Opcion == 22) {
                    $('#cmbContactoBuscar').html('');
                    $('#cmbContactoBuscar').html('<option value="-1">--Selecciona--</option>');
                    $.each(jsonArray, function (index, value) {
                        $("#cmbContactoBuscar").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                    });
                    $('#cmbContactoBuscar').selectpicker('refresh');
                    $('#cmbContactoBuscar').selectpicker('render');
                }

                if (Opcion == 23) {
                    $('#cmbEmpresaBuscar').html('');
                    $('#cmbEmpresaBuscar').html('<option value="-1">--Selecciona--</option>');
                    $.each(jsonArray, function (index, value) {
                        $("#cmbEmpresaBuscar").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                    });
                    $('#cmbEmpresaBuscar').selectpicker('refresh');
                    $('#cmbEmpresaBuscar').selectpicker('render');
                }

                if (Opcion == 24) {
                    $('#cmbLiderBuscar').html('');
                    $('#cmbLiderBuscar').html('<option value="-1">--Selecciona--</option>');
                    $.each(jsonArray, function (index, value) {
                        $("#cmbLiderBuscar").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                    });
                    $('#cmbLiderBuscar').selectpicker('refresh');
                    $('#cmbLiderBuscar').selectpicker('render');
                }

                if (Opcion == 25) {
                    $('#cmbSucursalBuscar').html('');
                    $('#cmbSucursalBuscar').html('<option value="-1">--Selecciona--</option>');
                    $.each(jsonArray, function (index, value) {
                        $("#cmbSucursalBuscar").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                    });
                    $('#cmbSucursalBuscar').selectpicker('refresh');
                    $('#cmbSucursalBuscar').selectpicker('render');
                }
            }
        });
    }

    $('#btnBuscarProyectos').click(function () {
        $('tbody#listaAdministracion').empty();
        var parametros = "{'pid':'2','_proyecto':'" + $('#cmbProyectoBuscar').val() +
            "','_contacto':'" + $('#cmbContactoBuscar').val() +
            "','_empresa':'" + $("#cmbEmpresaBuscar").val() +
            "','_lider':'" + $("#cmbLiderBuscar").val() +
            "','_sucursal':'" + $("#cmbSucursalBuscar").val();

           
        var dtFechainicio = document.getElementById('dtFechaInicioBuscar').value;
        var fechaInicioValida = Date.parse(dtFechainicio);

        var dtFechaFin = document.getElementById('dtFechaFinBuscar').value;
        var fechaFinValida = Date.parse(dtFechaFin);
        //debugger;
        if (!isNaN(fechaInicioValida) && !isNaN(fechaFinValida)) {
            //ambas fechas son validas, se tiene que validar que la fecha inicio no sea mayor a la fecha final
            if (fechaInicioValida > fechaFinValida) {
                //la fecha inicio es mayor, hay que mostrar mensaje de error y no hacer nada
                return;
            }
            fechaInicioValida = dtFechainicio;
            fechaFinValida = dtFechaFin;
        }
        else {
            if (isNaN(fechaInicioValida)) {
                //la fecha inicio NO es valida
                fechaInicioValida = "null";
            }
            else {
                fechaInicioValida = dtFechainicio;
            }
            if (isNaN(fechaFinValida)) {
                //la fecha fin NO es valida
                fechaFinValida = "null";
            }
            else {
                fechaFinValida = dtFechaFin;
            }
        }
        parametros += "','_fechaInicio':'" + fechaInicioValida +
            "','_fechaFin':'" + fechaFinValida +
            "','_estatus':'" + $("#cmbEstatusProyectos").val() +
            "','_oc':'" + $("#cmbOCBuscar").val() +
            "','_cl':'" + $("#cmbCLBuscar").val() +
            "'}";
       
        $.ajax({
            dataType: "json",
            url: "Administracion.aspx/CargaBusqueda",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "No tienes permiso.") {
                    var json = JSON.parse(data.d);

                    $('#TablaAdministracion').bootstrapTable('destroy');

                    $(json).each(function (index, item) {

                        var idProyecto = item.IdProyecto; //json[index].IdProyecto;
                        var Folio = item.FolioProyecto; //json[index].FolioProyecto;
                        var NombreProyecto = item.NombreProyecto;
                        var Contacto = item.ContactoCliente;
                        var Empresa = item.Cliente;
                        var Lider = item.LiderProyecto;
                        var FechaI = item.FechaInicio.substring(0, 10);
                        var FechaT = item.FechaFin.substring(0, 10);
                        var Estatus = item.Estatus;
                        var OC = item.OC;
                        var CL = item.CL;
                        var Porcentaje = item.Porcentaje;
                        var PorcentajePagado = item.PorcentajePagado;
                        var CostoMaterialProyectado = item.CostoMaterialProyectado;
                        var CostoMOProyectado = item.CostoMOProyectado;
                        var CostoMEProyectado = item.CostoMEProyectado;
                        var Sucursal = item.Sucursal;
                        var idSucursal = item.idSucursal;
                        var FolioPO = item.FolioPO;
                        var Avance = item.Avance;
                        var IdLider = item.IdLider;


                        if (Porcentaje == null) { Porcentaje = '0'; }
                        if (PorcentajePagado == null) { PorcentajePagado = '0'; }
                        if (OC == "NULL" || OC === null || OC == '') {
                            OC = '<Button title="Agregar OC" class="btn btn-danger" value="' + idProyecto + '" onclick="AgregarOC(this);"><i class="icon_close"></i></Button>';

                        }
                        else {
                            OC = '<Button title="Ver OC" class="btn btn-info" value="' + idProyecto + '" onclick="VisualizarDocumentoOC(this);"><i class="icon_document"></i></Button>';

                        }

                        if (CL == "NULL" || CL === null || CL == '') {
                            CL = '<Button title="Agregar CL" class="btn btn-danger" value="' + idProyecto + '" onclick="AgregarCL(this);"><i class="icon_close"></i></Button>';

                        }
                        else {
                            CL = '<Button title="Ver CL" class="btn btn-info" value="' + idProyecto + '" onclick="VisualizarDocumentoCL(this);"><i class="icon_document"></i></Button>';
                        }

                        var trstyle = '';
                        if (Estatus == '0') {
                            Estatus = "PENDIENTE";
                        } else if (Estatus == '1') {
                            trstyle = 'style="background-color: lightskyblue;"';
                            Estatus = "POR INICIAR";
                        } else if (Estatus == '2') {
                            trstyle = 'style="background-color: wheat;"';
                            Estatus = "EN PROCESO";
                        } else if (Estatus == '3') {
                            trstyle = 'style="background-color: #90ee90;"';
                            Estatus = "TERMINADO";
                        } else if (Estatus == '4') {
                            trstyle = 'style="background-color: #ffa084;"';
                            Estatus = "CANCELADO";
                        }
                        $('tbody#listaAdministracion').append(
                            '<tr ' + trstyle + '><td style="display:none;">'
                            + idProyecto
                            + '</td>'
                            + '<td>'
                            + Folio
                            + '</td>'
                            + '<td>'
                            + NombreProyecto
                            + '</td>'
                            + '<td>'
                            + FolioPO
                            + '</td>'
                            + '<td>'
                            + Contacto
                            + '</td>'
                            + '<td>'
                            + Empresa
                            + '</td>'
                            + '<td>'
                            + Lider
                            + '</td>'
                            + '<td>'
                            + Sucursal
                            + '</td>'
                            + '<td>'
                            + FechaI
                            + '</td>'
                            + '<td>'
                            + FechaT
                            + '</td>'
                            + '<td>'
                            + Avance + '%'
                            + '<div class="progress progress-striped"><div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="' + Avance + '" aria-valuemin="0" aria-valuemax="100" style="width:' + Avance + '%"></div></div>'
                            + Estatus
                            + '</td>'
                            //+ '<td>'
                            //+ formato_numero(CostoMOProyectado,2,'.',',')
                            //+ '</td>'
                            //+ '<td>'
                            //+ formato_numero(CostoMaterialProyectado, 2, '.', ',')
                            //+ '</td>'
                            //+ '<td>'
                            //+ formato_numero(CostoMEProyectado, 2, '.', ',')
                            //+ '</td>'
                            + '<td>'
                            + OC
                            + '</td>'
                            + '<td>'
                            + CL
                            + '</td>'
                            + '<td>'
                            + '<div class="progress progress-striped"><div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="' + Porcentaje + '" aria-valuemin="0" aria-valuemax="100" style="width:' + Porcentaje + '%"> <span class="sr-only">' + Porcentaje + '%</span></div></div>'
                            + Porcentaje + '%'
                            + '</td>'
                            + '<td>'
                            + '<div class="progress progress-striped"><div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="' + PorcentajePagado + '" aria-valuemin="0" aria-valuemax="100" style="width:' + PorcentajePagado + '%"> <span class="sr-only">' + PorcentajePagado + '%</span></div></div>'
                            + PorcentajePagado + '%'
                            + '</td>'
                            + '<td>'
                            + '<div class="btn-group">'
                            //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                            + '<Button title="Cambiar lider" class="btn btn-warning" value="' + idProyecto + '" rel="' + Folio + '" name="' + IdLider + '" data-subtext="' + NombreProyecto + '&_' + FolioPO + '&_' + idSucursal + '" onclick="CambiarLider(this);"><i class="icon_profile"></i></Button>'
                            + '<Button title="Editar monto" class="btn btn-default" value="' + idProyecto + '" rel="' + Folio + '" onclick="CambiarMonto(this);"><i class="icon_currency"></i></Button>'
                            + '<Button title="Grafica" class="btn btn-default" value="' + idProyecto + '" rel="' + Folio + '" onclick="AbriGrafica(this);"><i class="fa fa-pie-chart" aria-hidden="true"></i></Button>'
                            + '<Button title="Editar fechas" class="btn btn-success" value="' + idProyecto + '" rel="' + Folio + '" onclick="EditarProyectoFechas(this);"><i class="icon_calendar"></i></Button>'
                            + '<Button title="Cancelar" class="btn btn-danger" value="' + idProyecto + '" rel="' + Folio + '" onclick="CancelarProyecto(this);"><i class="icon_close_alt2"></i></Button>'
                            + '<Button title="Avance %" class="btn btn-info" value="' + idProyecto + '" rel="' + Folio + '" onclick="AvanceProyecto(this);"><i class="fa fa-line-chart" aria-hidden="true"></i></Button>'
                            + '</div > '
                            + '</td>'
                            + '<td>'
                            + '<div class="btn-group">'
                            /*+ '<Button title="Horas hombre" class="btn btn-warning" value="' + idProyecto + '" onclick="HorasHombre(this);"><i class="icon_group"></i></Button>'*/
                            + '<Button title="Cambiar estatus" class= "btn btn-info" value="' + idProyecto + '" rel="' + Folio + '" onclick="CambiarEstatus(this);"> <i class="icon_tags"></i></Button>'
                            + '<Button title="Editar gastos" class="btn btn-default" value="' + idProyecto + '" rel="' + Folio + '" onclick="EditarGastos(this);"><i class="icon_pencil"></i></Button>'
                            + '<Button title="Finalizar" class="btn btn-success" value="' + idProyecto + '" rel="' + Folio + '" onclick="TerminarProyecto(this);"><i class="icon_check"></i></Button>'
                            + '<Button title="Agregar comentario" class= "btn btn-info" value="' + idProyecto + '" onclick="AgregarComentario(this);"> <i class="icon_comment_alt"></i></Button>'
                            + '</div > '
                            + '</td>'
                            + '<td style="display:none;">'
                            + item.FechaAlta
                            + '</td>'
                            + '<td style="display:none;">'
                            + item.Estatus
                            + '</td>'
                            + '</tr>')
                    });
                    // $('#listaAdministracion').pageMe({ pagerSelector: '#myPagerProy2', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
                    $('#TablaAdministracion').DataTable({
                        "bLengthChange": false,
                        "pageLength": 100,
                        "order": [[18, "asc"], [17, "desc"]],
                        "bFilter": false,
                        //"oLanguage": {
                        //    "sSearch": "Buscar:"
                        //},
                        "retrieve": true
                    });

                }
            }
        });
    });

   

    $('#btnCambiarEstatus').click(function () {
        var id = document.getElementById('idProyectosEstatus').textContent;
        $('#myPagerProy2').html('');
        var parametros = "{'pid': '" + id + "', 'Estatus':'" + $('#cmbEstatusProyecto').val() + "'}";
        $.ajax({
            dataType: "json",
            url: "Administracion.aspx/CambiarEstatus",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Proyecto actualizado.") {
                    // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarProyectosNEW();
                    swal(msg.d);

                }
                else {
                    //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnCambiarMonto').click(function () {
        var id = document.getElementById('idProyectosMonto').textContent;

        $('#myPagerProy2').html('');
        var parametros = "{'pid': '" + id + "', 'Monto':'" + $('#cmbMontoProyecto').val() + "'}";
        $.ajax({
            dataType: "json",
            url: "Administracion.aspx/CambiarMonto",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Proyecto actualizado.") {
                    // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarProyectosNEW();
                    swal(msg.d);

                }
                else {
                    //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnCambiarLider').click(function () {

        var id = document.getElementById('idProyectosLider').textContent;
        var nomProyecto = $('#txtNombreProyecto').val();
        var idFolioPO = $('#cmbFolioPO').val();
        var folioPO = $('#cmbFolioPO option:selected').text()
        //debugger;

        if ($('#cmbLiderProyecto').val() === null) {
            //console.log('SI ENTRO');

            swal({
                title: "Favor de Seleccionar un lider!!",
                type: "error",
                allowOutsideClick: false,
                allowEscapeKey: false,
                allowEnterKey: false,
                showCancelButton: false,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                cancelButtonText: 'Cerrar'
            }).then(function () {
            });

            return;
        }

        //$('#myPagerProy2').html('');

        var parametros = "{'pid': '" + id
            + "', 'idLider':'" + $('#cmbLiderProyecto').val()
            + "', 'nombreProyecto': '" + nomProyecto
            + "', 'folioPO': '" + folioPO
            + "', 'idSucursal': '" + $('#cmbSucursalProyecto').val()
            + "', 'idFolioPO': '" + idFolioPO
            + "'}";
        $.ajax({
            dataType: "json",
            url: "Administracion.aspx/CambiarLider",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Proyecto actualizado.") {
                    // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarProyectosNEW();
                    swal(msg.d);

                }
                else {
                    //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnFinalizarProyecto').click(function () {
        var id = document.getElementById('idProyectosFinalizar').textContent;
        $('#myPagerProy2').html('');
        var parametros = "{'pid': '" + id + "'}";
        $.ajax({
            dataType: "json",
            url: "Administracion.aspx/FinalizarProyecto",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Proyecto Cierre Operativo.") {
                    // $("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarProyectosNEW();
                    swal(msg.d);

                }
                else {
                    //$("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnTerminarProyecto').click(function () {
        var id = document.getElementById('idProyectosTerminar').textContent;
        $('#myPagerProy2').html('');
        var parametros = "{'pid': '" + id + "'}";
        $.ajax({
            dataType: "json",
            url: "Administracion.aspx/TerminarProyecto",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Proyecto Finalizado.") {
                    // $("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarProyectosNEW();
                    swal(msg.d);

                }
                else {
                    //$("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnEliminadDocumento').click(function () {
        swal({
            title: 'Estas Seguro que quieres eliminar documento del Proyecto?',
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Aceptar',
            cancelButtonText: 'Cancelar'
        }).then((result) => {

            if (result) {

                var tipo = document.getElementById('txtTipoDocumento').textContent;
                var id = document.getElementById('txtidProyectoArchivo').textContent;

                $('#myPagerProy2').html('');
                var parametros = "{'IdProyecto': '" + id + "', 'Opcion':'" + tipo + "'}";
                $.ajax({
                    dataType: "json",
                    url: "Administracion.aspx/EliminarDocumento",
                    async: true,
                    data: parametros,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        if (msg.d == "Documento eliminado.") {
                            // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                            CargarProyectosNEW();
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
    //CambiarGastos(string pid, string MO, string M, string ME)
    $('#btnCambiarGastos').click(function () {
        var id = document.getElementById('idProyectosGastos').textContent;
        var parametros = "{'pid': '" + id + "', 'MO':'" + $('#txtMOProyectado').val() + "', 'M':'" + $('#txtCostoMaterialProyectado').val() + "', 'ME':'" + $('#txtCEProyectado').val() + "', 'MOC':'" + $('#txtMOCotizado').val() + "', 'MC':'" + $('#txtCostoMaterialCotizado').val() + "', 'MEC':'" + $('#txtCECotizado').val() + "'}";
        $.ajax({
            dataType: "json",
            url: "Administracion.aspx/CambiarGastos",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Proyecto actualizado.") {
                    // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarProyectosNEW();
                    swal(msg.d);

                }
                else {
                    //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnGuardarFechas').click(function () {
        var id = document.getElementById('idProyectoFechas').textContent;
        if ($('#txtRazonCambio').val() == '') {
            swal('Es obligatorio proporcionar una razón de cambio.');
            return;
        }
        var params = "{'pid': '" + id + "', 'Razon': '" + $('#txtRazonCambio').val() + "', 'Inicio': '" + $('#dtFechaInicio').val() + "', 'Fin': '" + $('#dtFechaTermino').val() + "'}";

        $.ajax({
            async: true,
            url: "Proyectos.aspx/GuardarFechas",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                if (data.d == 'Fechas actualizadas.') {

                    swal(data.d);
                    CargarProyectosNEW();
                }
                else {
                    swal(data.d);
                }
            }
        });
    });

    $('#btnCancelarProyectos').click(function () {
        var id = document.getElementById('idProyectosCancelar').textContent;

        var parametros = "{'pid': '" + id + "'}";
        $.ajax({
            dataType: "json",
            url: "Proyectos.aspx/CancelarProyectos",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Proyecto cancelado.") {
                    // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                    CargarProyectosNEW();
                }
                else {
                    //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnCambiarAvance').click(function () {

        var id = document.getElementById('idProyectosAvance').textContent;

        $('#myPagerProy2').html('');
        var parametros = "{'pid': '" + id + "', 'Avance':'" + $('#txtAvanceProyecto').val() + "'}";
        $.ajax({
            dataType: "json",
            url: "Administracion.aspx/ActualizarAvance",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Proyecto actualizado.") {
                    // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarProyectosNEW();
                    swal(msg.d);

                }
                else {
                    //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnAgregarComentarioProyectos').click(function () {
        var id = document.getElementById('idProyectoComentario').textContent;

        var params = "{'pid': '" + id + "', 'Comentario': '" + $('#txtComentarioProyecto').val() + "'}";

        $.ajax({
            async: true,
            url: "Administracion.aspx/GuardarComentarios",
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
});

function CalculaIvaMonto() {
    var monto = $('#cmbMontoProyecto').val() * 1.16;
    $('#cmbMontoProyecto').val(Math.round(monto));
}

function mayus(e) {
    e.value = e.value.toUpperCase();
}

function accionPROFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Cambiar lider" class="btn btn-warning cambiarLider"> <i class="icon_profile"></i></span>',
        '<span title="Editar Monto" class= "btn btn-default editarMonto"> <i class="icon_currency"></i></span>',
        '<span title="Grafica" class="btn btn-default grafica"><i class="fa fa-pie-chart" aria-hidden="true"></i></span>',
        '<span title="Editar Fechas" class="btn btn-success editarFechas"> <i class="icon_calendar"></i></span>',
        '<span title="Cancelar" class="btn btn-danger cancelar"> <i class="icon_close_alt2"></i></span>',
        '<span title="Avance %" class="btn btn-info avance"><i class="fa fa-line-chart" aria-hidden="true"></i></span>',
        '</div>'
    ].join(' ');
}

function accionPRO2Formatter(value, row, index) {
    return [
        '<div class="btn-group">',
        '<span title="Cambiar Estatus" class="btn btn-info cambiarEstatus"><i class="icon_tags"></i></span>',
        '<span title="Editar Gastos" class="btn btn-default editarGastos"><i class="icon_pencil"></i></span>',
        '<span title="Cierre Operativo" class="btn btn-warning cierreOperativo"><i class="icon_check"></i></span>',
        '<span title="Agregar Comentario" class="btn btn-info agregarComentario"><i class="icon_comment_alt"></i></span>',
        '<span title="Finalizar" class="btn btn-success finalizar"><i class="fa fa-handshake-o"></i></span>',
        '</div>'
    ].join(' ');
}

window.accionPROEvents = {
    'click .cambiarLider': function (e, value, row, index) {

        

        //console.log(idSucursal);
        CargarSucursal(row.idSucursal);
        CargarLideres(row.IdLider);
        CargarOrdenesCompra(row.IdModuloPO);
        document.getElementById('idProyectosLider').textContent = '';
        document.getElementById('idProyectosLiderTexto').textContent = '¿Estás seguro de actualizar Lider de proyecto con Folio "' + row.FolioProyecto + '"?';
        document.getElementById('idProyectosLider').textContent = row.IdProyecto;

        document.getElementById('txtNombreProyecto').value = row.NombreProyecto;
        //document.getElementById('txtFolioPO').value = row.FolioPO;

        $("#CambiarLider").modal();
    },
    'click .editarMonto': function (e, value, row, index) {

        document.getElementById('idProyectosMonto').textContent = '';
        document.getElementById('idProyectosMontoTexto').textContent = '¿Estás seguro de actualizar monto de proyecto con Folio "' + row.FolioProyecto + '"?';
        document.getElementById('idProyectosMonto').textContent = row.IdProyecto;
        $("#CambiarMonto").modal();

    },
    'click .grafica': function (e, value, row, index) {

        window.open("ProyectoDetallesAdmin.aspx?id=" + row.IdProyecto);

    },
    'click .editarFechas': function (e, value, row, index) {

        document.getElementById('idProyectoFechas').textContent = row.IdProyecto;
        var params = "{'pid': '" + row.IdProyecto + "'}";
        $.ajax({
            async: true,
            url: "Proyectos.aspx/ObtenerFechas",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var jsonArray = $.parseJSON(data.d);
                $.each(jsonArray, function (index, value) {
                    $('#dtFechaInicio').val(value.FechaInicio.substring(0, 10));
                    $('#dtFechaTermino').val(value.FechaFin.substring(0, 10));
                });

            }
        });
        $("#dvCambiarFechas").modal();

    },
    'click .cancelar': function (e, value, row, index) {

        document.getElementById('idProyectosCancelar').textContent = '';
        document.getElementById('idProyectosCancelarTexto').textContent = '¿Estás seguro de Cancelar proyecto con Folio "' + row.FolioProyecto + '"?';
        document.getElementById('idProyectosCancelar').textContent = row.IdProyecto;
        $("#CancelarProyectosModal").modal();

    },
    'click .avance': function (e, value, row, index) {

        document.getElementById('idProyectosAvance').textContent = '';
        document.getElementById('idProyectosAvanceTexto').textContent = '¿Estás seguro de actualizar avance de proyecto con Folio "' + row.FolioProyecto + '"?';
        document.getElementById('idProyectosAvance').textContent = row.IdProyecto;
        $("#AvanceProyecto").modal();

    }
};

window.accionPRO2Events = {
    'click .cambiarEstatus': function (e, value, row, index) {

        document.getElementById('idProyectosEstatus').textContent = '';
        document.getElementById('idProyectosEstatusTexto').textContent = '¿Estás seguro de actualizar estatus de proyecto con Folio "' + row.FolioProyecto + '"?';
        document.getElementById('idProyectosEstatus').textContent = row.IdProyecto;
        $("#CambiarEstatus").modal();

    },
    'click .editarGastos': function (e, value, row, index) {

        CargarGastos(row.IdProyecto);
        document.getElementById('idProyectosGastos').textContent = '';
        document.getElementById('idProyectosGastosTexto').textContent = '¿Estás seguro de actualizar gastos de proyecto con Folio "' + row.FolioProyecto + '"?';
        document.getElementById('idProyectosGastos').textContent = row.IdProyecto;
        $("#CambiarGastos").modal();

    },
    'click .cierreOperativo': function (e, value, row, index) {

        document.getElementById('idProyectosFinalizar').textContent = '';
        document.getElementById('idProyectosFinalizarTexto').textContent = '¿Estás seguro de cambiar estatus a CIERRE OPERATIVO al proyecto con Folio "' + row.FolioProyecto + '"?';
        document.getElementById('idProyectosFinalizar').textContent = row.IdProyecto;
        $("#FinalizarProyecto").modal();

    },
    'click .agregarComentario': function (e, value, row, index) {

        document.getElementById('idProyectoComentario').textContent = row.IdProyecto;
        var params = "{'pid': '" + row.IdProyecto + "'}";
        $.ajax({
            async: true,
            url: "Administracion.aspx/CargarComentarios",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {

                var datos = "";
                var nodoTRAgregar = "";

                var JsonCombos;
                var jsonArray = $.parseJSON(data.d);

                $('#TablaPrincipalComentariosProyectos tbody').html('');
                $.each(jsonArray, function (index, value) {
                    nodoTRAgregar += "<tr>";
                    nodoTRAgregar += '  <td style="display: none;">' + value.IdProyecto + "</td>";
                    nodoTRAgregar += "  <td>" + value.Comentario + "</td>";
                    nodoTRAgregar += "  <td>" + value.NombreCompleto + "</td>";
                    nodoTRAgregar += "  <td>" + value.Fecha.substring(0, 10) + "</td>";
                    nodoTRAgregar += "</tr>";
                });

                $('#TablaPrincipalComentariosProyectos tbody').append(nodoTRAgregar);
            }
        });
        $("#dvComentarios").modal();

    },
    'click .finalizar': function (e, value, row, index) {

        document.getElementById('idProyectosTerminar').textContent = '';
        document.getElementById('idProyectosTerminarTexto').textContent = '¿Estás seguro de cambiar estatus a CIERRE ADMINISTRATIVO al proyecto con Folio "' + row.FolioProyecto + '"?';
        document.getElementById('idProyectosTerminar').textContent = row.IdProyecto;
        $("#TerminarProyecto").modal();

    }
};

function dateFormat(value, row, index) {
    return moment(value).format('YYYY-MM-DD');
}

function estatusFormatter(value, row) {
    var icono;
    var textEstatus = "";

    if (value == "0") {
        textEstatus = '<span>PENDIENTE</span>';
    }
    else if (value == "1") {
        textEstatus = '<span>POR INICIAR</span>';
    }
    else if (value == "2") {
        textEstatus = '<span>EN PROCESO</span>';
    }
    else if (value == "3") {
        textEstatus = '<span>CIERRE OPERATIVO</span>';
    }
    else if (value == "4") {
        textEstatus = '<span>CANCELADO</span>';
    }
    else if (value == "5") {
        textEstatus = '<span>TERMINADO</span>';
    }

    icono = row.Avance + '% <br />' +
        '<div class="progress progress-striped"><div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="' + row.Avance + '" aria-valuemin="0" aria-valuemax="100" style="width:' + row.Avance + '%"></div></div> ' +
        textEstatus;

    return icono;
}

function ccmFormatter(value) {
    var icono;
    //debugger;
 
    if (value == "1") {
        icono = '<i class="glyphicon glyphicon-ok-circle fa-lg" style="color: green;"></i>';
    }
    else {
        icono = '<i class="glyphicon glyphicon-remove-circle fa-lg" style="color: red;"></i>';
    }

    return icono;//'<i class="glyphicon glyphicon-ok"></i> ' + value;
}

window.accionOCEvents = {
    'click .agregarOC': function (e, value, row, index) {
        swal({
            title: 'Seleccione OC',
            input: 'file',
            allowOutsideClick: false,
            allowEscapeKey: false,
            allowEnterKey: false,
            showCloseButton: true
        }).then(function (file) {
            var nombreArchivo = file.name;
            var reader = new FileReader
            reader.onload = function (e) {

                var params = "{'TipoDoc': '" + '1' +
                    "','IdProyecto': '" + row.IdProyecto +
                    "','FileName': '" + nombreArchivo +
                    "','File': '" + e.target.result + "'}";

                //console.log(params);
                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "Administracion.aspx/GuardarDocumentos",
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
    },
    'click .agregarCL': function (e, value, row, index) {
        swal({
            title: 'Seleccione CL',
            input: 'file',
            allowOutsideClick: false,
            allowEscapeKey: false,
            allowEnterKey: false,
            showCloseButton: true
        }).then(function (file) {
            var nombreArchivo = file.name;
            var reader = new FileReader
            reader.onload = function (e) {

                var params = "{'TipoDoc': '" + '2' +
                    "','IdProyecto': '" + row.IdProyecto +
                    "','FileName': '" + nombreArchivo +
                    "','File': '" + e.target.result + "'}";

                //console.log(params);
                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "Administracion.aspx/GuardarDocumentos",
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
    },
    'click .verOC': function (e, value, row, index) {
        $('#testmodalpdf').html('');

        var params = "{'IdProyecto': '" + row.IdProyecto +
            "','Opcion': '" + "OC" + "'}";

        $.ajax({
            async: true,
            url: "Administracion.aspx/CargarDocumentos",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                var datos = "";

                var JsonCombos;
                var jsonArray = $.parseJSON(data.d);


                $.each(jsonArray, function (index, value) {
                    document.getElementById('txtTipoDocumento').textContent = "OC";

                    document.getElementById('txtidProyectoArchivo').textContent = value.IdProyecto;
                    $('#testmodalpdf').append('<object id="visorPDF" data="' + value.ArchivoOC + '" type="application/pdf" style="width:100%; height: 800px;"></object>');
                });
            }
        });
        $("#dvPDF").modal();
    },
    'click .verCL': function (e, value, row, index) {
        $('#testmodalpdf').html('');
        var params = "{'IdProyecto': '" + row.IdProyecto +
            "','Opcion': '" + "CL" + "'}";
        //console.log(params);

        $.ajax({
            async: true,
            url: "Administracion.aspx/CargarDocumentos",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                //debugger;
                var datos = "";

                var JsonCombos;
                var jsonArray = $.parseJSON(data.d);


                $.each(jsonArray, function (index, value) {
                    document.getElementById('txtidProyectoArchivo').textContent = value.IdProyecto;
                    document.getElementById('txtTipoDocumento').textContent = "CL";
                    $('#testmodalpdf').append('<object id="visorPDF" data="' + value.ArchivoCL + '" type="application/pdf" style="width:100%; height: 800px;"></object>');
                });
            }
        });
        $("#dvPDF").modal();
    }
};

function ocFormatter(value) {
    var icono;
    //debugger;

    

    if (value == "NULL" || value === null || value == '') {
        icono = '<span title="Agregar OC" class="btn btn-danger agregarOC"><i class="icon_close"></i></span>';
        //icono = '<Button title="Agregar OC" class="btn btn-danger" value="' + idProyecto + '" onclick="AgregarOC(this);"><i class="icon_close"></i></Button>';
    }
    else {
        icono = '<span title="Ver OC" class="btn btn-info verOC"><i class="icon_document"></i></span>';
        //icono = '<Button title="Ver OC" class="btn btn-info" value="' + idProyecto + '" onclick="VisualizarDocumentoOC(this);"><i class="icon_document"></i></Button>';
    }

    return icono;//'<i class="glyphicon glyphicon-ok"></i> ' + value;
}

function clFormatter(value) {
    var icono;
    //debugger;

    if (value == "NULL" || value === null || value == '') {
        icono = '<span title="Agregar CL" class="btn btn-danger agregarCL"><i class="icon_close"></i></span>';
    }
    else {
        icono = '<span title="Ver CL" class="btn btn-info verCL"><i class="icon_document"></i></span>';
    }

    return icono;//'<i class="glyphicon glyphicon-ok"></i> ' + value;
}

function fcFormatter(value) {
    var icono;

    icono = '<div class="progress progress-striped"><div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="' + value + '" aria-valuemin="0" aria-valuemax="100" style="width:' + value + '%"> <span class="sr-only">' + value + '%</span></div></div>' +
        value + '%';

    return icono;
}


function pagadoFormatter(value) {
    var icono;

    icono = '<div class="progress progress-striped"><div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="' + value + '" aria-valuemin="0" aria-valuemax="100" style="width:' + value + '%"> <span class="sr-only">' + value + '%</span></div></div>' +
        value + '%';

    return icono;
}


function gastosFormatter(value) {
    var icono;

    icono = '<div class="progress progress-striped"><div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="' + value + '" aria-valuemin="0" aria-valuemax="100" style="width:' + value + '%"> <span class="sr-only">' + value + '%</span></div></div>' +
        formato_numero(value, 2, '.', ',') + '%';

    return icono;
}

function CargarGastos(id) {
    var params = "{'pid': '" + id + "'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'Administracion.aspx/CargarGastos',
        data: params,
        success: function (data, textStatus) {
            ;
            var json = $.parseJSON(data.d);

            $('#cmbLiderProyecto').html('');
            $.each(json, function (index, value) {
                $('#txtMOProyectado').val(formato_numero(value.CostoMOProyectado, 2, '.', ','));
                $('#txtCostoMaterialProyectado').val(formato_numero(value.CostoMaterialProyectado, 2, '.', ','));
                $('#txtCEProyectado').val(formato_numero(value.CostoMEProyectado, 2, '.', ','));

                $('#txtMOCotizado').val(formato_numero(value.CostoMOCotizado, 2, '.', ','));
                $('#txtCostoMaterialCotizado').val(formato_numero(value.CostoMaterialCotizado, 2, '.', ','));
                $('#txtCECotizado').val(formato_numero(value.CostoMECotizado, 2, '.', ','));
            });

        }
    });
}

function CargarLideres(lider) {
    var params = "{'Opcion': '1'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'Administracion.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbLiderProyecto').html('');
            $.each(json, function (index, value) {
                $("#cmbLiderProyecto").append("<option value=" + value.Id + ">" + value.Nombre.toUpperCase() + "</option>");
            });

            //$('#cmbLiderProyecto').selectpicker('refresh');
            //$('#cmbLiderProyecto').selectpicker('render');

            $('#cmbLiderProyecto').val(lider);
            $('#cmbLiderProyecto').selectpicker('refresh');

        }
    });
}

function CargarSucursal(sucursal) {
    var params = "{'Opcion': '18'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'Administracion.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbSucursalProyecto').html('');
            $.each(json, function (index, value) {
                $("#cmbSucursalProyecto").append("<option value=" + value.Id + ">" + value.Nombre.toUpperCase() + "</option>");
            });

            //$('#cmbLiderProyecto').selectpicker('refresh');
            //$('#cmbLiderProyecto').selectpicker('render');

            $('#cmbSucursalProyecto').val(sucursal);
            $('#cmbSucursalProyecto').selectpicker('refresh');

        }
    });
}

function CargarOrdenesCompra(folioPO) {
    var params = "{'Opcion': '29'}";
    
    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'Administracion.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbFolioPO').html('');
            $.each(json, function (index, value) {
                $("#cmbFolioPO").append("<option value=" + value.Id + ">" + value.Nombre.toUpperCase() + "</option>");
            });

            //$('#cmbLiderProyecto').selectpicker('refresh');
            //$('#cmbLiderProyecto').selectpicker('render');

            $('#cmbFolioPO').val(folioPO);
            $('#cmbFolioPO').selectpicker('refresh');

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