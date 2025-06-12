$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("CajaChica.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarCC();
        CargarProyectos();
        CargarUsuarios();
        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }



    function CargarProyectos() {
        var params = "{'Opcion': '10'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'CajaChica.aspx/CargarCombos',
            data: params,
            success: function (data, textStatus) {
                //debugger;
                var json = $.parseJSON(data.d);
                $('#cmbProyectos').html('');
                $('#cmbProyectos').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
                $('#cmbProyectos').append('<option value="80914600-CC95-48F6-8AC0-8667EAFBCFEC">PENDIENTE</option>');
                $('#cmbProyectos').append('<option value="83B995B4-3877-4600-A16D-5FFF9F3A84E3">ECONOLINE 2003</option>');
                $('#cmbProyectos').append('<option value="214104A8-0083-4481-8813-A754CD8FFD40">ECONOLINE 2006</option>');
                $('#cmbProyectos').append('<option value="F765BA07-20A2-4E00-A208-F06D97DF3160">FOCUS</option>');
                $('#cmbProyectos').append('<option value="8EEE37DB-F5BD-405D-9492-4919618E8C15">IKON</option>');
                $('#cmbProyectos').append('<option value="697966BC-9116-443E-A0E6-876528AABF08">RANGER</option>');
                $('#cmbProyectos').append('<option value="83A889B9-11CA-47A9-8538-B1736B773FA8">REMOLQUE</option>');
                $('#cmbProyectos').append('<option value="9F71A091-10E7-4322-A0AA-F442B45D4958">RAM</option>');
                $('#cmbProyectos').append('<option value="3A9F72BA-0011-4606-A1C6-07FB83EC4F8D">CHEYENNE</option>');
                $('#cmbProyectos').append('<option value="3BE79512-40A2-4CC6-83EF-B1C2CDBA6765">RAM 700</option>');
                $('#cmbProyectos').append('<option value="B0488C4F-1B55-4DB2-B6F4-7555E46916BF">JEEP</option>');
                $('#cmbProyectos').append('<option value="40F670F5-A145-4C52-AC38-6E791E3B5A19">FRONTIER</option>');
                $('#cmbProyectos').append('<option value="11313417-6F42-40B8-A933-06C452E34441">SWIFT</option>');
                $('#cmbProyectos').append('<option value="F76F2A6C-4FA1-4505-82B5-82EE5EE69497">SPARK</option>');
                $('#cmbProyectos').append('<option value="A9B875EC-1AA2-49D0-8D97-144DBFF21B56">F150</option>');
                $('#cmbProyectos').append('<option value="EF4EDE9E-BFCD-4D31-9B40-8E6B21291F21">BRONCO</option>');
                $('#cmbProyectos').append('<option value="1A713837-3DFF-4012-9F5F-7844B3DED561">TONELADA</option>');
                $('#cmbProyectos').append('<option value="08369BA2-25DD-4CB4-829A-0A472997794F">PASSAT</option>');
                $('#cmbProyectos').append('<option value="4AD1CAF0-E15C-434C-8A93-794474D902D8">COLORADO</option>');
                $('#cmbProyectos').append('<option value="57F02FB0-ABFD-4907-8D69-ED9284309B80">BATANGA CHICA</option>');
                $('#cmbProyectos').append('<option value="EC17D9F8-4824-4B9C-AFA2-C89B34DE2D23">BATANGA MEDIANA</option>');
                $('#cmbProyectos').append('<option value="3601B5DB-0ACE-468D-80CD-4DE5831362D6">BATANGA GRANDE</option>');
                $('#cmbProyectos').append('<option value="0EF1486A-A756-4064-981D-A5DDFF46F9B4">HILUX</option>');
                $('#cmbProyectos').append('<option value="83099F5D-8420-45DF-BAFC-5218A79D2233">FRONTIER 2021</option>');
                $('#cmbProyectos').append('<option value="A0D7E7EF-DB76-4F99-BAC0-7A4995954481">L200</option>');

                /* HERMOSILLO */
                $('#cmbProyectos').append('<option value="7D0116F4-17E1-47A3-82C8-48E0F46110AC">VIATICOS HERMOSILLO</option>');
                $('#cmbProyectos').append('<option value="B9938D9A-DDE7-453A-B430-2D9ADF68D15F">GASOLINA HERMOSILLO</option>');
                $('#cmbProyectos').append('<option value="1621D8FD-690E-4C1E-BB94-7E0FAB7C7F56">GASTOS ADMINISTRATIVOS HERMOSILLO</option>');
                $("#cmbProyectos").append('<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER HERMOSILLO</option>');
                $("#cmbProyectos").append('<option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA HERMOSILLO</option>');
                $("#cmbProyectos").append('<option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD HERMOSILLO</option>');
                $("#cmbProyectos").append('<option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA HERMOSILLO</option>');

                /* QUERETARO */
                $('#cmbProyectos').append('<option value="C66E57D6-6390-4D12-8118-4B21F662C8E3">VIATICOS QUERETARO</option>');
                $('#cmbProyectos').append('<option value="05AC88FC-6340-4936-B749-2F6EDA17F88A">CONSUMIBLES TALLER QUERÉTARO</option>');
                $('#cmbProyectos').append('<option value="89AE75F8-2D98-40B1-AC47-FDD4D951881C">EQUIPO DE SEGURIDAD QUERÉTARO</option>');
                $('#cmbProyectos').append('<option value="C8589B15-CAF9-44EB-A49C-FAE500B17EC2">INVENTARIO SISA QUERÉTARO</option>');
                $('#cmbProyectos').append('<option value="C9E46130-B035-4B7E-97BA-7BED2441BBDD">GASTOS ADMINISTRATIVOS QUERÉTARO</option>');
                $('#cmbProyectos').append('<option value="84DF1AF7-AD10-4AD6-8F51-9CA6EF0EEC47">GASOLINA QUERÉTARO</option>');


                /* CHIHUAHUA */
                $('#cmbProyectos').append('<option value="3A4C9E3B-7BA1-4ABE-8F32-FC1844C51AC1">VIATICOS CHIHUAHUA</option>');
                $('#cmbProyectos').append('<option value="07BF808D-A646-4D63-9CD7-5161A94FC7FB">CONSUMIBLES TALLER CHIHUAHUA</option>');
                $('#cmbProyectos').append('<option value="BFC64785-CAD4-4247-B0AE-A64FE53B4669">EQUIPO DE SEGURIDAD CHIHUAHUA</option>');
                $('#cmbProyectos').append('<option value="734B8D0E-DEBE-46F1-9B69-5FF7334D9EB1">INVENTARIO SISA CHIHUAHUA</option>');
                $('#cmbProyectos').append('<option value="7846992F-5AF1-4C5F-91C6-A91541C6E405">GASTOS ADMINISTRATIVOS CHIHUAHUA</option>');
                $('#cmbProyectos').append('<option value="EE3ADE54-E730-4C9D-980E-F1A57BB53BE2">GASOLINA CHIHUAHUA</option>');


                /* CUAUTITLAN */
                $('#cmbProyectos').append('<option value="00DAC103-6BC1-419C-BEFE-9F803F9031B9">VIATICOS CUAUTITLAN</option>');
                $('#cmbProyectos').append('<option value="F74683C3-A52D-4C2B-9B7E-25771AD50ABD">CONSUMIBLES TALLER CUAUTITLÁN</option>');
                $('#cmbProyectos').append('<option value="6A50C6ED-0384-4E54-9142-B14E7338E2DC">EQUIPO DE SEGURIDAD CUAUTITLÁN</option>');
                $('#cmbProyectos').append('<option value="BB913E5E-3200-4639-894A-628741DDB24E">INVENTARIO SISA CUAUTITLÁN</option>');
                $('#cmbProyectos').append('<option value="A46D00C1-0D5B-41B3-8702-0ADA1D98E175">GASTOS ADMINISTRATIVOS CUAUTITLÁN</option>');
                $('#cmbProyectos').append('<option value="79144254-9D84-486B-A0C6-A2C3D2CC6167">GASOLINA CUAUTITLÁN</option>');


                /* TECATE */
                $('#cmbProyectos').append('<option value="0EEBCB40-578B-4815-B46B-BFDA1D7DE4C1">VIATICOS TECATE</option>');
                $('#cmbProyectos').append('<option value="39A9783A-0AA3-48BE-AF1C-8BDEEC4E1625">CONSUMIBLES TALLER TECATE</option>');
                $('#cmbProyectos').append('<option value="77C10A22-E1E3-4EBB-806A-2891165EDD88">EQUIPO DE SEGURIDAD TECATE</option>');
                $('#cmbProyectos').append('<option value="B99F1969-83AF-457B-BC6E-7544B40683EF">INVENTARIO SISA TECATE</option>');
                $('#cmbProyectos').append('<option value="9AE78058-4070-4F65-82A1-DDEB1E2F624A">GASTOS ADMINISTRATIVOS TECATE</option>');
                $('#cmbProyectos').append('<option value="178B1FE7-2E94-4F4D-951C-0A823B095505">GASOLINA TECATE</option>');


                /* IRAPUATO */
                $('#cmbProyectos').append('<option value="08F847C4-B48F-4951-AD73-31144BE6F86D">VIATICOS IRAPUATO</option>');
                $('#cmbProyectos').append('<option value="B79F496D-5148-4369-A941-F158BF493CA1">CONSUMIBLES TALLER IRAPUATO</option>');
                $('#cmbProyectos').append('<option value="0D4A2608-980D-4E1F-8203-5F6D7AA6C19F">EQUIPO DE SEGURIDAD IRAPUATO</option>');
                $('#cmbProyectos').append('<option value="752B58CB-8B6F-4164-998E-087CAF4FD52F">INVENTARIO SISA IRAPUATO</option>');
                $('#cmbProyectos').append('<option value="D3B9254C-A667-4E42-B478-701A34D32DC0">GASTOS ADMINISTRATIVOS IRAPUATO</option>');
                $('#cmbProyectos').append('<option value="FE6D1459-F29F-47FC-844C-0D4158E80E9E">GASOLINA IRAPUATO</option>');


                $.each(json, function (index, value) {
                    $("#cmbProyectos").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
                });

                $('#cmbProyectos').selectpicker('refresh');
                $('#cmbProyectos').selectpicker('render');
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


                //$("#txtResponsableEditar").append('<option value="' + value.Nombre + '">' + value.Nombre.toUpperCase() + '</option>');
                //$('#txtResponsableEditar').selectpicker('refresh');
                //$('#txtResponsableEditar').selectpicker('render');
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
                    //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
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

    $('#btnGuardarCajaChica').click(function () {
        $('#txtDireccionEmpresa').val();
        if ($('#txtResponsable').val() == '-1' || $('#txtResponsable').val() == '' || $('#txtConcepto').val() == '' || $('#cmbProyectos').val() == '' || $('#cmbProyectos').val() == '-1' || $('#cmbComprobante').val() == '-1' || $('#cmbComprobante').val() == '' || $('#txtCargo').val() == '' || $('#txtAbono').val() == '' || $('#dtFecha').val() == '' || $('#cmbEstatus').val() == '' || $('#cmbCategoriaCC').val() == '') {
            swal('Todos los campos son obligatorios');
            return;
        }
        var parametros = "{'Responsable':'" + $('#txtResponsable').val() + "','Concepto': '" + $('#txtConcepto').val() + "', 'pidproyecto':'" + $('#cmbProyectos').val() + "', 'Proyecto':'" + $("#cmbProyectos option:selected").text() + "',"
            + "'Comprobante': '" + $('#cmbComprobante').val() + "', 'Cargo': '" + $('#txtCargo').val() + "', 'Abono': '" + $('#txtAbono').val() + "', 'Fecha':'" + $('#dtFecha').val() + "','Estatus':'" + $('#cmbEstatus').val() + "', 'Tipo':'1', 'pid':'', 'Categoria':'" + $('#cmbCategoriaCC').val() + "', 'CampoExtra':'" + $('#txtResponsable2').val() + "'}";
        $.ajax({
            dataType: "json",
            url: "CajaChica.aspx/GuardarCC",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
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


                    //CargarCC();
                    //$('#txtResponsable').val('-1');
                    //$('#txtResponsable').val('');
                    //$('#txtConcepto').val('');
                    //$('#cmbProyectos').val('');
                    //$('#cmbProyectos').val('-1');
                    //$('#cmbComprobante').val('-1');
                    //$('#cmbComprobante').val('');
                    //$('#txtCargo').val('');
                    //$('#txtAbono').val('');
                    //$('#dtFecha').val('');
                    //$('#cmbEstatus').val('');
                    //$('#cmbCategoriaCC').val('');
                }
                else {
                    //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
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

function CargarCC() {
    //$('tbody#listaCajaChica').empty();
    //$('#myPager').html('');
    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "CajaChica.aspx/ObtenerCC",
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
                    idField: 'IdCajaChica',
                    uniqueId: 'IdCajaChica',
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

                        //if (row.Estatus == 3) {
                        //    return {
                        //        classes: 'success'
                        //    };
                        //}
                        //else if (row.Estatus == 2) {
                        //    return {
                        //        classes: 'warning'
                        //    };
                        //}
                        //else if (row.Estatus == 1) {
                        //    return {
                        //        classes: 'info'
                        //    };
                        //}
                        //else if (row.Estatus == 4) {
                        //    return {
                        //        classes: 'danger'
                        //    };
                        //}
                        //else {
                        //    return {
                        //        classes: ''
                        //    };
                        //}

                    }
                });

                //$(json).each(function (index, item) {

                //    var IdCajaChica = json[index].IdCajaChica;
                //    var Responsable = json[index].Responsable;
                //    var Responsable2 = json[index].CampoExtra;
                //    var Concepto = json[index].Concepto;
                //    var Proyecto = json[index].Proyecto;
                //    var Comprobante = json[index].Comprobante;
                //    var Cargo = json[index].Cargo;
                //    var Abono = json[index].Abono;
                //    var Saldo = json[index].Saldo;
                //    var Fecha = json[index].Fecha;
                //    var Estatus = json[index].Estatus;
                //    var IdProyecto = json[index].IdProyecto;
                //    var Categoria = json[index].Categoria;
                //    var trstyle = '';
                //    if (Estatus == 0) {
                //        trstyle = 'style="background-color: yellow;"';
                //    }
                //    $('tbody#listaCajaChica').append(
                //        '<tr ' + trstyle + '><td style="display:none;">'
                //        + IdCajaChica
                //        + '</td>'
                //        + '<td>'
                //        + Fecha.substring(0, 10)
                //        + '</td>'
                //        + '<td>'
                //        + Responsable
                //        + '</td>'
                //        + '<td>'
                //        + Responsable2
                //        + '</td>'
                //        + '<td>'
                //        + Concepto
                //        + '</td><td>'
                //        + Proyecto
                //        + '</td>'
                //        + '<td>'
                //        + Comprobante
                //        + '</td>'
                //        + '<td>'
                //        + formato_numero(Cargo, 2, '.', ',')
                //        + '</td>'
                //        + '<td>'
                //        + formato_numero(Abono, 2, '.', ',')
                //        + '</td>'
                //        + '<td>'
                //        + formato_numero(Saldo, 2, '.', ',')
                //        + '</td>'
                //        + '<td>'
                //        + Categoria
                //        + '</td>'
                //        + '<td>'
                //        + '<div class="btn-group">'
                //        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                //        + '<Button title="Editar" class= "btn btn-info" value="' + IdCajaChica + '" onclick="EditarCChica(this);"> <i class="icon_pencil"></i></Button>'
                //        + '<Button title="Eliminar" class="btn btn-danger" value="' + IdCajaChica + '" onclick="EliminaCC(this);"><i class="icon_close_alt2"></i></Button>'
                //        + '</div > '
                //        + '</td>'
                //        + '</tr>')
                //});
                ////$('#listaCajaChica').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
                //$('#TablaCajaChica').DataTable({
                //    "bLengthChange": false,
                //    "pageLength": 100,
                //    "order": [[1, "desc"]],
                //    "oLanguage": {
                //        "sSearch": "Buscar:"
                //    },
                //    "retrieve": true
                //});
            }
            else {
                $("#CargandoCajaChica").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

            }
        }
    });
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
        '<span title="Editar" class="btn btn-info editar"> <i class="icon_pencil"></i></span>',
        '<span title="Eliminar" class="btn btn-danger eliminar"><i class="icon_close_alt2"></i></span>',
        '</div>'
    ].join(' ');
}

window.accionCC1Events = {
    'click .editar': function (e, value, row, index) {

        var idCajaChica = row.IdCajaChica;

        $('#EditarCajaChicaForm').empty();
        //$(btn.value).each(function (index, item) {
        //    var IdCajaChica = json[index].idSucursa;
        //    var CiudadCajaChica = json[index].CiudadCajaChica;
        //    var DireccionCajaChica = json[index].DireccionCajaChica;
        //    var TelefonoCajaChica = json[index].TelefonoCajaChica;
        //    $('#EditarCajaChicaForm').append(' <div class= "modal-body" >  <div class="form-group"> <div class="col-sm-10"> <input type="hidden" class="form-control" id="txtidCajaChicaEditar" value="' + IdCajaChica + '" required/></div></div<div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtCiudadCajaChicaEditar" value="' + CiudadCajaChica + '" required/></div></div><div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtDireccionCajaChicaEditar" value="' + DireccionCajaChica + '" required/></div></div><div class="form-group"> <div class="col-sm-10"><input type="tel" class="form-control"  id="txtTelefonoCajaChicaEditar" value="' + TelefonoCajaChica + '" required/></div> </div>  <div class="form-group"> <div class="col-sm-10"><div class="form-group" id="txtModalEditarMensajeCajaChica"> </div></div> </div> </div > <div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> <button class="btn btn-primary" id="btnEditarCajaChica" type="button">Guardar cambios</button> </div>');
        //});
        var parametros = "{'pid': '" + idCajaChica + "'}";
        $.ajax({
            dataType: "json",
            url: "CajaChica.aspx/ObtenerCC",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {
                        var IdCajaChica = item.IdCajaChica;
                        var Responsable = item.Responsable;
                        var Responsable2 = item.CampoExtra;
                        var Concepto = item.Concepto;
                        var Proyecto = item.Proyecto;
                        var Comprobante = item.Comprobante;
                        var Cargo = item.Cargo;
                        var Abono = item.Abono;
                        var Saldo = item.Saldo;
                        var Fecha = item.Fecha.substring(0, 10);
                        var Estatus = item.Estatus;
                        var Categoria = item.Categoria;
                        var IdProyecto = item.IdProyecto;
                        $('#EditarCajaChicaForm').append(' <div class= "modal-body">  '
                            + ' <div class= "form-group" > <div class="col-sm-10"> <input type="hidden" class="form-control" id="txtidCajaChicaEditar" value="' + IdCajaChica + '" required /> '
                            + ' </div> </div ><div class= "form-group" ><div class="col-sm-10"> <label>Fecha:</label> <input type="date" class="form-control" id="dtFechaEditar" value="' + Fecha + '" required />  '
                            // + ' </div ></div> <div class= "form-group" > <div class="col-sm-10"><label>Responsable:</label><input type="text" class="form-control" id="txtResponsableEditar" value="' + Responsable + '" required/>'
                            + ' </div ></div> <div class= "form-group" > <div class="col-sm-10"><label>Responsable:</label><select class="form-control selectpicker" id="txtResponsableEditar" data-live-search="true" required></select>'
                            + ' </div ></div> <div class= "form-group" > <div class="col-sm-10"><label>Responsable:</label><input type="text" class="form-control selectpicker" id="txtResponsable2Editar" value="' + Responsable2 + '"/>'
                            + '</div></div ><div class="form-group"><div class="col-sm-10"><label>Concepto:</label><input type="text" class="form-control" id="txtConceptoEditar" value="' + Concepto + '" required/>'
                            + '</div></div><div class="form-group"><div class="col-sm-10"><label>Proyecto:</label><select id="cmbProyectosEditarCC" class="form-control selectpicker" data-live-search="true" required></select>'
                            + '</div></div><div class= "form-group" ><div class="col-sm-10"><label>Comprobante:</label><select id="cmbComprobanteEdicarCC" class="form-control" required><option value="SIN COMPROBANTE">SIN COMPROBANTE</option><option value="TICKET">TICKET</option><option value="FACTURA">FACTURA</option><option value="NOTA">NOTA</option><option value="RECIBO DE EFECTIVO">RECIBO DE EFECTIVO</option><option value="VIATICOS">VIATICOS</option><option value="ORDEN DE COMPRA">ORDEN DE COMPRA</option><option value="N/A">N/A</option><option value="PENDIENTE">PENDIENTE</option></select>'
                            + '</div></div> <div class="form-group"> <div class="col-sm-10"> <label>Cargo:</label> <input type="text" class="form-control" id="txtCargoEditar" value="' + formato_numero(Cargo, 2, '.', ',') + '" required/> '
                            + ' </div></div> <div class="form-group"> <div class="col-sm-10"><label>Abono:</label>  <input type="text" class="form-control" id="txtAbonoEditar" value="' + formato_numero(Abono, 2, '.', ',') + '" required/>'
                            + ' </div></div> <div class="form-group"> <div class= "col-sm-10"><label>Estatus:</label><select id="cmbEstatusEditar" class="form-control" required><option value="0">PENDIENTE</option><option value="1">COMPLETO</option></select>'
                            + '</div></div><div class="form-group"><div class= "col-sm-10" ><label>Categoria:</label> <select id="cmbCategoriaCCEditar" class="form-control" required> <option value="MATERIAL">MATERIAL</option><option value="MANOOBRA">MANO DE OBRA</option><option value="EQUIPO">EQUIPO</option> <option value="N/A">N/A</option></select></div ></div > <div class="form-group" id="txtModalEditarMensajeCajaChica"> </div>'
                            + '<div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> '
                            + '<button class="btn btn-primary" id="btnEditarCajaChica" onclick="EditarCajaChicaDesdePopUp();" type="button">Guardar cambios</button> </div></div>');
                        CargarProyectosEditarCC(IdProyecto);
                        CargarUsuariosEditar(Responsable);
                        $('#cmbEstatusEditar').val(Estatus);
                        $('#cmbCategoriaCCEditar').val(Categoria);
                        $('#cmbComprobanteEdicarCC').val(Comprobante);
                        $('#txtResponsableEditar').val(Responsable);
                        $('#txtResponsableEditar').selectpicker('refresh');
                    });
                    $("#EditCajaChicaModal").modal();
                }
                else {
                    $("#CargandoCajaChica").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }
            }
        });
    },
    'click .eliminar': function (e, value, row, index) {
        var idCajaChica = row.IdCajaChica;
        //var folio = row.Folio;

        document.getElementById('idCajaChicaEliminar').textContent = '';
        document.getElementById('idCajaChicaEliminarTexto').textContent = '¿Estás seguro de eliminar información de caja chica con código "' + idCajaChica + '"?';


        document.getElementById('idCajaChicaEliminar').textContent = idCajaChica;

        $("#DelCajaChicaModal").modal();
    }
};

function CargarProyectosEditarCC(IdProyecto) {
    var params = "{'Opcion': '10'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'CajaChica.aspx/CargarCombos',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbProyectosEditarCC').html('');
            $('#cmbProyectosEditarCC').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
            $('#cmbProyectosEditarCC').append('<option value="80914600-CC95-48F6-8AC0-8667EAFBCFEC">PENDIENTE</option>');
            $('#cmbProyectosEditarCC').append('<option value="83B995B4-3877-4600-A16D-5FFF9F3A84E3">ECONOLINE 2003</option>');
            $('#cmbProyectosEditarCC').append('<option value="214104A8-0083-4481-8813-A754CD8FFD40">ECONOLINE 2006</option>');
            $('#cmbProyectosEditarCC').append('<option value="F765BA07-20A2-4E00-A208-F06D97DF3160">FOCUS</option>');
            $('#cmbProyectosEditarCC').append('<option value="8EEE37DB-F5BD-405D-9492-4919618E8C15">IKON</option>');
            $('#cmbProyectosEditarCC').append('<option value="697966BC-9116-443E-A0E6-876528AABF08">RANGER</option>');
            $('#cmbProyectosEditarCC').append('<option value="83A889B9-11CA-47A9-8538-B1736B773FA8">REMOLQUE</option>');
            $('#cmbProyectosEditarCC').append('<option value="9F71A091-10E7-4322-A0AA-F442B45D4958">RAM</option>');
            $('#cmbProyectosEditarCC').append('<option value="3A9F72BA-0011-4606-A1C6-07FB83EC4F8D">CHEYENNE</option>');
            $('#cmbProyectosEditarCC').append('<option value="3BE79512-40A2-4CC6-83EF-B1C2CDBA6765">RAM 700</option>');
            $('#cmbProyectosEditarCC').append('<option value="B0488C4F-1B55-4DB2-B6F4-7555E46916BF">JEEP</option>');
            $('#cmbProyectosEditarCC').append('<option value="40F670F5-A145-4C52-AC38-6E791E3B5A19">FRONTIER</option>');
            $('#cmbProyectosEditarCC').append('<option value="11313417-6F42-40B8-A933-06C452E34441">SWIFT</option>');
            $('#cmbProyectosEditarCC').append('<option value="F76F2A6C-4FA1-4505-82B5-82EE5EE69497">SPARK</option>');
            $('#cmbProyectosEditarCC').append('<option value="A9B875EC-1AA2-49D0-8D97-144DBFF21B56">F150</option>');
            $('#cmbProyectosEditarCC').append('<option value="EF4EDE9E-BFCD-4D31-9B40-8E6B21291F21">BRONCO</option>');
            $('#cmbProyectosEditarCC').append('<option value="1A713837-3DFF-4012-9F5F-7844B3DED561">TONELADA</option>');
            $('#cmbProyectosEditarCC').append('<option value="08369BA2-25DD-4CB4-829A-0A472997794F">PASSAT</option>');
            $('#cmbProyectosEditarCC').append('<option value="4AD1CAF0-E15C-434C-8A93-794474D902D8">COLORADO</option>');
            $('#cmbProyectosEditarCC').append('<option value="57F02FB0-ABFD-4907-8D69-ED9284309B80">BATANGA CHICA</option>');
            $('#cmbProyectosEditarCC').append('<option value="EC17D9F8-4824-4B9C-AFA2-C89B34DE2D23">BATANGA MEDIANA</option>');
            $('#cmbProyectosEditarCC').append('<option value="3601B5DB-0ACE-468D-80CD-4DE5831362D6">BATANGA GRANDE</option>');
            $('#cmbProyectosEditarCC').append('<option value="0EF1486A-A756-4064-981D-A5DDFF46F9B4">HILUX</option>');
            $('#cmbProyectosEditarCC').append('<option value="83099F5D-8420-45DF-BAFC-5218A79D2233">FRONTIER 2021</option>');
            $('#cmbProyectosEditarCC').append('<option value="A0D7E7EF-DB76-4F99-BAC0-7A4995954481">L200</option>');

            /* HERMOSILLO */
            $('#cmbProyectosEditarCC').append('<option value="7D0116F4-17E1-47A3-82C8-48E0F46110AC">VIATICOS HERMOSILLO</option>');
            $('#cmbProyectosEditarCC').append('<option value="B9938D9A-DDE7-453A-B430-2D9ADF68D15F">GASOLINA HERMOSILLO</option>');
            $('#cmbProyectosEditarCC').append('<option value="1621D8FD-690E-4C1E-BB94-7E0FAB7C7F56">GASTOS ADMINISTRATIVOS HERMOSILLO</option>');
            $("#cmbProyectosEditarCC").append('<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER HERMOSILLO</option>');
            $("#cmbProyectosEditarCC").append('<option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA HERMOSILLO</option>');
            $("#cmbProyectosEditarCC").append('<option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD HERMOSILLO</option>');
            $("#cmbProyectosEditarCC").append('<option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA HERMOSILLO</option>');

            /* QUERETARO */
            $('#cmbProyectosEditarCC').append('<option value="C66E57D6-6390-4D12-8118-4B21F662C8E3">VIATICOS QUERETARO</option>');
            $('#cmbProyectosEditarCC').append('<option value="05AC88FC-6340-4936-B749-2F6EDA17F88A">CONSUMIBLES TALLER QUERÉTARO</option>');
            $('#cmbProyectosEditarCC').append('<option value="89AE75F8-2D98-40B1-AC47-FDD4D951881C">EQUIPO DE SEGURIDAD QUERÉTARO</option>');
            $('#cmbProyectosEditarCC').append('<option value="C8589B15-CAF9-44EB-A49C-FAE500B17EC2">INVENTARIO SISA QUERÉTARO</option>');
            $('#cmbProyectosEditarCC').append('<option value="C9E46130-B035-4B7E-97BA-7BED2441BBDD">GASTOS ADMINISTRATIVOS QUERÉTARO</option>');
            $('#cmbProyectosEditarCC').append('<option value="84DF1AF7-AD10-4AD6-8F51-9CA6EF0EEC47">GASOLINA QUERÉTARO</option>');


            /* CHIHUAHUA */
            $('#cmbProyectosEditarCC').append('<option value="3A4C9E3B-7BA1-4ABE-8F32-FC1844C51AC1">VIATICOS CHIHUAHUA</option>');
            $('#cmbProyectosEditarCC').append('<option value="07BF808D-A646-4D63-9CD7-5161A94FC7FB">CONSUMIBLES TALLER CHIHUAHUA</option>');
            $('#cmbProyectosEditarCC').append('<option value="BFC64785-CAD4-4247-B0AE-A64FE53B4669">EQUIPO DE SEGURIDAD CHIHUAHUA</option>');
            $('#cmbProyectosEditarCC').append('<option value="734B8D0E-DEBE-46F1-9B69-5FF7334D9EB1">INVENTARIO SISA CHIHUAHUA</option>');
            $('#cmbProyectosEditarCC').append('<option value="7846992F-5AF1-4C5F-91C6-A91541C6E405">GASTOS ADMINISTRATIVOS CHIHUAHUA</option>');
            $('#cmbProyectosEditarCC').append('<option value="EE3ADE54-E730-4C9D-980E-F1A57BB53BE2">GASOLINA CHIHUAHUA</option>');


            /* CUAUTITLAN */
            $('#cmbProyectosEditarCC').append('<option value="00DAC103-6BC1-419C-BEFE-9F803F9031B9">VIATICOS CUAUTITLAN</option>');
            $('#cmbProyectosEditarCC').append('<option value="F74683C3-A52D-4C2B-9B7E-25771AD50ABD">CONSUMIBLES TALLER CUAUTITLÁN</option>');
            $('#cmbProyectosEditarCC').append('<option value="6A50C6ED-0384-4E54-9142-B14E7338E2DC">EQUIPO DE SEGURIDAD CUAUTITLÁN</option>');
            $('#cmbProyectosEditarCC').append('<option value="BB913E5E-3200-4639-894A-628741DDB24E">INVENTARIO SISA CUAUTITLÁN</option>');
            $('#cmbProyectosEditarCC').append('<option value="A46D00C1-0D5B-41B3-8702-0ADA1D98E175">GASTOS ADMINISTRATIVOS CUAUTITLÁN</option>');
            $('#cmbProyectosEditarCC').append('<option value="79144254-9D84-486B-A0C6-A2C3D2CC6167">GASOLINA CUAUTITLÁN</option>');


            /* TECATE */
            $('#cmbProyectosEditarCC').append('<option value="0EEBCB40-578B-4815-B46B-BFDA1D7DE4C1">VIATICOS TECATE</option>');
            $('#cmbProyectosEditarCC').append('<option value="39A9783A-0AA3-48BE-AF1C-8BDEEC4E1625">CONSUMIBLES TALLER TECATE</option>');
            $('#cmbProyectosEditarCC').append('<option value="77C10A22-E1E3-4EBB-806A-2891165EDD88">EQUIPO DE SEGURIDAD TECATE</option>');
            $('#cmbProyectosEditarCC').append('<option value="B99F1969-83AF-457B-BC6E-7544B40683EF">INVENTARIO SISA TECATE</option>');
            $('#cmbProyectosEditarCC').append('<option value="9AE78058-4070-4F65-82A1-DDEB1E2F624A">GASTOS ADMINISTRATIVOS TECATE</option>');
            $('#cmbProyectosEditarCC').append('<option value="178B1FE7-2E94-4F4D-951C-0A823B095505">GASOLINA TECATE</option>');


            /* IRAPUATO */
            $('#cmbProyectosEditarCC').append('<option value="08F847C4-B48F-4951-AD73-31144BE6F86D">VIATICOS IRAPUATO</option>');
            $('#cmbProyectosEditarCC').append('<option value="B79F496D-5148-4369-A941-F158BF493CA1">CONSUMIBLES TALLER IRAPUATO</option>');
            $('#cmbProyectosEditarCC').append('<option value="0D4A2608-980D-4E1F-8203-5F6D7AA6C19F">EQUIPO DE SEGURIDAD IRAPUATO</option>');
            $('#cmbProyectosEditarCC').append('<option value="752B58CB-8B6F-4164-998E-087CAF4FD52F">INVENTARIO SISA IRAPUATO</option>');
            $('#cmbProyectosEditarCC').append('<option value="D3B9254C-A667-4E42-B478-701A34D32DC0">GASTOS ADMINISTRATIVOS IRAPUATO</option>');
            $('#cmbProyectosEditarCC').append('<option value="FE6D1459-F29F-47FC-844C-0D4158E80E9E">GASOLINA IRAPUATO</option>');

            $.each(json, function (index, value) {
                $("#cmbProyectosEditarCC").append('<option value="' + value.Id.toUpperCase() + '">' + value.Nombre.toUpperCase() + '</option>');
            });

            $('#cmbProyectosEditarCC').selectpicker('refresh');
            $('#cmbProyectosEditarCC').selectpicker('render');
            var id = IdProyecto.toUpperCase();
            $('#cmbProyectosEditarCC').val(id);
            $('#cmbProyectosEditarCC').selectpicker('refresh');
        }

    });
}



function CargarUsuariosEditar(Responsable) {
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

            $('#txtResponsableEditar').html('');
            $.each(json, function (index, value) {

                $("#txtResponsableEditar").append('<option value="' + value.Nombre + '">' + value.Nombre.toUpperCase() + '</option>');

            });
            $('#txtResponsableEditar').selectpicker('refresh');
            $('#txtResponsableEditar').selectpicker('render');

            $('#txtResponsableEditar').val(Responsable);
            $('#txtResponsableEditar').selectpicker('refresh');
        }
    });
}



