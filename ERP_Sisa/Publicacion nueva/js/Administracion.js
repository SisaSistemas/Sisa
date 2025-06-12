$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("Administracion.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });
        document.body.style.zoom = "80%";

        CargarProyectos();
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
                    $("#cmbProyectoBuscar").append('<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER HERMOSILLO</option>');
                    $("#cmbProyectoBuscar").append('<option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA HERMOSILLO</option>');
                    $("#cmbProyectoBuscar").append('<option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD HERMOSILLO</option>');
                    $("#cmbProyectoBuscar").append('<option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA HERMOSILLO</option>');
                    $('#cmbProyectoBuscar').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
                    $('#cmbProyectoBuscar').append('<option value="1621D8FD-690E-4C1E-BB94-7E0FAB7C7F56">GASTOS ADMINISTRATIVOS HERMOSILLO</option>');
                    $('#cmbProyectoBuscar').append('<option value="80914600-CC95-48F6-8AC0-8667EAFBCFEC">PENDIENTE</option>');
                    $('#cmbProyectoBuscar').append('<option value="83B995B4-3877-4600-A16D-5FFF9F3A84E3">ECONOLINE 2003</option>');
                    $('#cmbProyectoBuscar').append('<option value="214104A8-0083-4481-8813-A754CD8FFD40">ECONOLINE 2006</option>');
                    $('#cmbProyectoBuscar').append('<option value="F765BA07-20A2-4E00-A208-F06D97DF3160">FOCUS</option>');
                    $('#cmbProyectoBuscar').append('<option value="8EEE37DB-F5BD-405D-9492-4919618E8C15">IKON</option>');
                    $('#cmbProyectoBuscar').append('<option value="697966BC-9116-443E-A0E6-876528AABF08">RANGER</option>');
                    $('#cmbProyectoBuscar').append('<option value="83A889B9-11CA-47A9-8538-B1736B773FA8">REMOLQUE</option>');
                    $('#cmbProyectoBuscar').append('<option value="9F71A091-10E7-4322-A0AA-F442B45D4958">RAM</option>');
                    $('#cmbProyectoBuscar').append('<option value="3A9F72BA-0011-4606-A1C6-07FB83EC4F8D">CHEYENNE</option>');
                    $('#cmbProyectoBuscar').append('<option value="3BE79512-40A2-4CC6-83EF-B1C2CDBA6765">RAM 700</option>');
                    $('#cmbProyectoBuscar').append('<option value="B0488C4F-1B55-4DB2-B6F4-7555E46916BF">JEEP</option>');
                    $('#cmbProyectoBuscar').append('<option value="B9938D9A-DDE7-453A-B430-2D9ADF68D15F">GASOLINA HERMOSILLO</option>');
                    $('#cmbProyectoBuscar').append('<option value="40F670F5-A145-4C52-AC38-6E791E3B5A19">FRONTIER</option>');
                    $('#cmbProyectoBuscar').append('<option value="11313417-6F42-40B8-A933-06C452E34441">SWIFT</option>');
                    $('#cmbProyectoBuscar').append('<option value="F76F2A6C-4FA1-4505-82B5-82EE5EE69497">SPARK</option>');
                    $('#cmbProyectoBuscar').append('<option value="A9B875EC-1AA2-49D0-8D97-144DBFF21B56">F150</option>');
                    $('#cmbProyectoBuscar').append('<option value="EF4EDE9E-BFCD-4D31-9B40-8E6B21291F21">BRONCO</option>');
                    $('#cmbProyectoBuscar').append('<option value="1A713837-3DFF-4012-9F5F-7844B3DED561">TONELADA</option>');
                    $('#cmbProyectoBuscar').append('<option value="F74683C3-A52D-4C2B-9B7E-25771AD50ABD">CONSUMIBLES TALLER CUAUTITLÁN</option>');
                    $('#cmbProyectoBuscar').append('<option value="05AC88FC-6340-4936-B749-2F6EDA17F88A">CONSUMIBLES TALLER QUERÉTARO</option>');
                    $('#cmbProyectoBuscar').append('<option value="39A9783A-0AA3-48BE-AF1C-8BDEEC4E1625">CONSUMIBLES TALLER TECATE</option>');
                    $('#cmbProyectoBuscar').append('<option value="07BF808D-A646-4D63-9CD7-5161A94FC7FB">CONSUMIBLES TALLER CHIHUAHUA</option>');
                    $('#cmbProyectoBuscar').append('<option value="6A50C6ED-0384-4E54-9142-B14E7338E2DC">EQUIPO DE SEGURIDAD CUAUTITLÁN</option>');
                    $('#cmbProyectoBuscar').append('<option value="89AE75F8-2D98-40B1-AC47-FDD4D951881C">EQUIPO DE SEGURIDAD QUERÉTARO</option>');
                    $('#cmbProyectoBuscar').append('<option value="77C10A22-E1E3-4EBB-806A-2891165EDD88">EQUIPO DE SEGURIDAD TECATE</option>');
                    $('#cmbProyectoBuscar').append('<option value="BFC64785-CAD4-4247-B0AE-A64FE53B4669">EQUIPO DE SEGURIDAD CHIHUAHUA</option>');
                    $('#cmbProyectoBuscar').append('<option value="BB913E5E-3200-4639-894A-628741DDB24E">INVENTARIO SISA CUAUTITLÁN</option>');
                    $('#cmbProyectoBuscar').append('<option value="C8589B15-CAF9-44EB-A49C-FAE500B17EC2">INVENTARIO SISA QUERÉTARO</option>');
                    $('#cmbProyectoBuscar').append('<option value="B99F1969-83AF-457B-BC6E-7544B40683EF">INVENTARIO SISA TECATE</option>');
                    $('#cmbProyectoBuscar').append('<option value="734B8D0E-DEBE-46F1-9B69-5FF7334D9EB1">INVENTARIO SISA CHIHUAHUA</option>');
                    $('#cmbProyectoBuscar').append('<option value="A46D00C1-0D5B-41B3-8702-0ADA1D98E175">GASTOS ADMINISTRATIVOS CUAUTITLÁN</option>');
                    $('#cmbProyectoBuscar').append('<option value="C9E46130-B035-4B7E-97BA-7BED2441BBDD">GASTOS ADMINISTRATIVOS QUERÉTARO</option>');
                    $('#cmbProyectoBuscar').append('<option value="9AE78058-4070-4F65-82A1-DDEB1E2F624A">GASTOS ADMINISTRATIVOS TECATE</option>');
                    $('#cmbProyectoBuscar').append('<option value="7846992F-5AF1-4C5F-91C6-A91541C6E405">GASTOS ADMINISTRATIVOS CHIHUAHUA</option>');
                    $('#cmbProyectoBuscar').append('<option value="79144254-9D84-486B-A0C6-A2C3D2CC6167">GASOLINA CUAUTITLÁN</option>');
                    $('#cmbProyectoBuscar').append('<option value="84DF1AF7-AD10-4AD6-8F51-9CA6EF0EEC47">GASOLINA QUERÉTARO</option>');
                    $('#cmbProyectoBuscar').append('<option value="178B1FE7-2E94-4F4D-951C-0A823B095505">GASOLINA TECATE</option>');
                    $('#cmbProyectoBuscar').append('<option value="EE3ADE54-E730-4C9D-980E-F1A57BB53BE2">GASOLINA CHIHUAHUA</option>');
                    $('#cmbProyectoBuscar').append('<option value="08369BA2-25DD-4CB4-829A-0A472997794F">PASSAT</option>');
                    $('#cmbProyectoBuscar').append('<option value="4AD1CAF0-E15C-434C-8A93-794474D902D8">COLORADO</option>');
                    $('#cmbProyectoBuscar').append('<option value="57F02FB0-ABFD-4907-8D69-ED9284309B80">BATANGA CHICA</option>');
                    $('#cmbProyectoBuscar').append('<option value="EC17D9F8-4824-4B9C-AFA2-C89B34DE2D23">BATANGA MEDIANA</option>');
                    $('#cmbProyectoBuscar').append('<option value="3601B5DB-0ACE-468D-80CD-4DE5831362D6">BATANGA GRANDE</option>');
                    $('#cmbProyectoBuscar').append('<option value="0EF1486A-A756-4064-981D-A5DDFF46F9B4">HILUX</option>');
                    $('#cmbProyectoBuscar').append('<option value="83099F5D-8420-45DF-BAFC-5218A79D2233">FRONTIER 2021</option>');
                    $('#cmbProyectoBuscar').append('<option value="A0D7E7EF-DB76-4F99-BAC0-7A4995954481">L200</option>');
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
        debugger;
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

    $.fn.pageMe = function (opts) {
        var $this = this,
            defaults = {
                perPage: 7,
                showPrevNext: false,
                hidePageNumbers: true
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
                    CargarProyectos();
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
                    CargarProyectos();
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
        var folioPO = $('#txtFolioPO').val();

        

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

        var parametros = "{'pid': '" + id + "', 'idLider':'" + $('#cmbLiderProyecto').val() + "', 'nombreProyecto': '" + nomProyecto + "', 'folioPO': '" + folioPO + "', 'idSucursal': '" + $('#cmbSucursalProyecto').val() + "'}";
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
                    CargarProyectos();
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
                if (msg.d == "Proyecto finalizado.") {
                    // $("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarProyectos();
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
                            CargarProyectos();
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
                    CargarProyectos();
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
                    CargarProyectos();
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
                    CargarProyectos();
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
                    CargarProyectos();
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