var tipo = 0;

$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("CajaChica.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });
        document.body.style.zoom = "80%";

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
                $.each(json, function (index, value) {
                    $("#cmbProyectos").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
                });

                $('#cmbProyectos').selectpicker('refresh');
                $('#cmbProyectos').selectpicker('render');

                //$('#cmbProyectos').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
                //$('#cmbProyectos').append('<option value="80914600-CC95-48F6-8AC0-8667EAFBCFEC">PENDIENTE</option>');
                //$('#cmbProyectos').append('<option value="83B995B4-3877-4600-A16D-5FFF9F3A84E3">ECONOLINE 2003</option>');
                //$('#cmbProyectos').append('<option value="214104A8-0083-4481-8813-A754CD8FFD40">ECONOLINE 2006</option>');
                //$('#cmbProyectos').append('<option value="F765BA07-20A2-4E00-A208-F06D97DF3160">FOCUS</option>');
                //$('#cmbProyectos').append('<option value="8EEE37DB-F5BD-405D-9492-4919618E8C15">IKON</option>');
                //$('#cmbProyectos').append('<option value="697966BC-9116-443E-A0E6-876528AABF08">RANGER</option>');
                //$('#cmbProyectos').append('<option value="83A889B9-11CA-47A9-8538-B1736B773FA8">REMOLQUE</option>');
                //$('#cmbProyectos').append('<option value="9F71A091-10E7-4322-A0AA-F442B45D4958">RAM</option>');
                //$('#cmbProyectos').append('<option value="3A9F72BA-0011-4606-A1C6-07FB83EC4F8D">CHEYENNE</option>');
                //$('#cmbProyectos').append('<option value="3BE79512-40A2-4CC6-83EF-B1C2CDBA6765">RAM 700</option>');
                //$('#cmbProyectos').append('<option value="B0488C4F-1B55-4DB2-B6F4-7555E46916BF">JEEP</option>');
                //$('#cmbProyectos').append('<option value="40F670F5-A145-4C52-AC38-6E791E3B5A19">FRONTIER</option>');
                //$('#cmbProyectos').append('<option value="11313417-6F42-40B8-A933-06C452E34441">SWIFT</option>');
                //$('#cmbProyectos').append('<option value="F76F2A6C-4FA1-4505-82B5-82EE5EE69497">SPARK</option>');
                //$('#cmbProyectos').append('<option value="A9B875EC-1AA2-49D0-8D97-144DBFF21B56">F150</option>');
                //$('#cmbProyectos').append('<option value="EF4EDE9E-BFCD-4D31-9B40-8E6B21291F21">BRONCO</option>');
                //$('#cmbProyectos').append('<option value="1A713837-3DFF-4012-9F5F-7844B3DED561">TONELADA</option>');
                //$('#cmbProyectos').append('<option value="08369BA2-25DD-4CB4-829A-0A472997794F">PASSAT</option>');
                //$('#cmbProyectos').append('<option value="4AD1CAF0-E15C-434C-8A93-794474D902D8">COLORADO</option>');
                //$('#cmbProyectos').append('<option value="57F02FB0-ABFD-4907-8D69-ED9284309B80">BATANGA CHICA</option>');
                //$('#cmbProyectos').append('<option value="EC17D9F8-4824-4B9C-AFA2-C89B34DE2D23">BATANGA MEDIANA</option>');
                //$('#cmbProyectos').append('<option value="3601B5DB-0ACE-468D-80CD-4DE5831362D6">BATANGA GRANDE</option>');
                //$('#cmbProyectos').append('<option value="0EF1486A-A756-4064-981D-A5DDFF46F9B4">HILUX</option>');
                //$('#cmbProyectos').append('<option value="83099F5D-8420-45DF-BAFC-5218A79D2233">FRONTIER 2021</option>');
                //$('#cmbProyectos').append('<option value="A0D7E7EF-DB76-4F99-BAC0-7A4995954481">L200</option>');

                ///* HERMOSILLO */
                //$('#cmbProyectos').append('<option value="7D0116F4-17E1-47A3-82C8-48E0F46110AC">VIATICOS HERMOSILLO</option>');
                //$('#cmbProyectos').append('<option value="B9938D9A-DDE7-453A-B430-2D9ADF68D15F">GASOLINA HERMOSILLO</option>');
                //$('#cmbProyectos').append('<option value="1621D8FD-690E-4C1E-BB94-7E0FAB7C7F56">GASTOS ADMINISTRATIVOS HERMOSILLO</option>');
                //$("#cmbProyectos").append('<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER HERMOSILLO</option>');
                //$("#cmbProyectos").append('<option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA HERMOSILLO</option>');
                //$("#cmbProyectos").append('<option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD HERMOSILLO</option>');
                //$("#cmbProyectos").append('<option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA HERMOSILLO</option>');

                ///* QUERETARO */
                //$('#cmbProyectos').append('<option value="C66E57D6-6390-4D12-8118-4B21F662C8E3">VIATICOS QUERETARO</option>');
                //$('#cmbProyectos').append('<option value="05AC88FC-6340-4936-B749-2F6EDA17F88A">CONSUMIBLES TALLER QUERÉTARO</option>');
                //$('#cmbProyectos').append('<option value="89AE75F8-2D98-40B1-AC47-FDD4D951881C">EQUIPO DE SEGURIDAD QUERÉTARO</option>');
                //$('#cmbProyectos').append('<option value="C8589B15-CAF9-44EB-A49C-FAE500B17EC2">INVENTARIO SISA QUERÉTARO</option>');
                //$('#cmbProyectos').append('<option value="C9E46130-B035-4B7E-97BA-7BED2441BBDD">GASTOS ADMINISTRATIVOS QUERÉTARO</option>');
                //$('#cmbProyectos').append('<option value="84DF1AF7-AD10-4AD6-8F51-9CA6EF0EEC47">GASOLINA QUERÉTARO</option>');


                ///* CHIHUAHUA */
                //$('#cmbProyectos').append('<option value="3A4C9E3B-7BA1-4ABE-8F32-FC1844C51AC1">VIATICOS CHIHUAHUA</option>');
                //$('#cmbProyectos').append('<option value="07BF808D-A646-4D63-9CD7-5161A94FC7FB">CONSUMIBLES TALLER CHIHUAHUA</option>');
                //$('#cmbProyectos').append('<option value="BFC64785-CAD4-4247-B0AE-A64FE53B4669">EQUIPO DE SEGURIDAD CHIHUAHUA</option>');
                //$('#cmbProyectos').append('<option value="734B8D0E-DEBE-46F1-9B69-5FF7334D9EB1">INVENTARIO SISA CHIHUAHUA</option>');
                //$('#cmbProyectos').append('<option value="7846992F-5AF1-4C5F-91C6-A91541C6E405">GASTOS ADMINISTRATIVOS CHIHUAHUA</option>');
                //$('#cmbProyectos').append('<option value="EE3ADE54-E730-4C9D-980E-F1A57BB53BE2">GASOLINA CHIHUAHUA</option>');


                ///* CUAUTITLAN */
                //$('#cmbProyectos').append('<option value="00DAC103-6BC1-419C-BEFE-9F803F9031B9">VIATICOS CUAUTITLAN</option>');
                //$('#cmbProyectos').append('<option value="F74683C3-A52D-4C2B-9B7E-25771AD50ABD">CONSUMIBLES TALLER CUAUTITLÁN</option>');
                //$('#cmbProyectos').append('<option value="6A50C6ED-0384-4E54-9142-B14E7338E2DC">EQUIPO DE SEGURIDAD CUAUTITLÁN</option>');
                //$('#cmbProyectos').append('<option value="BB913E5E-3200-4639-894A-628741DDB24E">INVENTARIO SISA CUAUTITLÁN</option>');
                //$('#cmbProyectos').append('<option value="A46D00C1-0D5B-41B3-8702-0ADA1D98E175">GASTOS ADMINISTRATIVOS CUAUTITLÁN</option>');
                //$('#cmbProyectos').append('<option value="79144254-9D84-486B-A0C6-A2C3D2CC6167">GASOLINA CUAUTITLÁN</option>');


                ///* TECATE */
                //$('#cmbProyectos').append('<option value="0EEBCB40-578B-4815-B46B-BFDA1D7DE4C1">VIATICOS TECATE</option>');
                //$('#cmbProyectos').append('<option value="39A9783A-0AA3-48BE-AF1C-8BDEEC4E1625">CONSUMIBLES TALLER TECATE</option>');
                //$('#cmbProyectos').append('<option value="77C10A22-E1E3-4EBB-806A-2891165EDD88">EQUIPO DE SEGURIDAD TECATE</option>');
                //$('#cmbProyectos').append('<option value="B99F1969-83AF-457B-BC6E-7544B40683EF">INVENTARIO SISA TECATE</option>');
                //$('#cmbProyectos').append('<option value="9AE78058-4070-4F65-82A1-DDEB1E2F624A">GASTOS ADMINISTRATIVOS TECATE</option>');
                //$('#cmbProyectos').append('<option value="178B1FE7-2E94-4F4D-951C-0A823B095505">GASOLINA TECATE</option>');


                ///* IRAPUATO */
                //$('#cmbProyectos').append('<option value="08F847C4-B48F-4951-AD73-31144BE6F86D">VIATICOS IRAPUATO</option>');
                //$('#cmbProyectos').append('<option value="B79F496D-5148-4369-A941-F158BF493CA1">CONSUMIBLES TALLER IRAPUATO</option>');
                //$('#cmbProyectos').append('<option value="0D4A2608-980D-4E1F-8203-5F6D7AA6C19F">EQUIPO DE SEGURIDAD IRAPUATO</option>');
                //$('#cmbProyectos').append('<option value="752B58CB-8B6F-4164-998E-087CAF4FD52F">INVENTARIO SISA IRAPUATO</option>');
                //$('#cmbProyectos').append('<option value="D3B9254C-A667-4E42-B478-701A34D32DC0">GASTOS ADMINISTRATIVOS IRAPUATO</option>');
                //$('#cmbProyectos').append('<option value="FE6D1459-F29F-47FC-844C-0D4158E80E9E">GASOLINA IRAPUATO</option>');


                
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
                    //swal({
                    //    title: msg.d
                    //}).then((result) => {

                    //    if (result) {
                    //        location.reload();
                    //    }
                    //});

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

    $('#btnAgregarCajaChicaSucursal').click(function () {
        $('#txtidCajaChicaEditarSucursal').val(0);
        cargarSucursales();
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

    function cargarSucursales() {
        var params = "{'Opcion': '18'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'CajaChica.aspx/CargarCombos',
            data: params,
            success: function (data, textStatus) {

                var json = $.parseJSON(data.d);

                $('#cmbSucursal').html('');
                $("#cmbSucursal").append('<option value="-1">-- SELECCIONE UNA SUCURSAL --</option>');
                $.each(json, function (index, value) {

                    $("#cmbSucursal").append('<option value="' + value.Id + '" rel="' + value.Correo + '" >' + value.Nombre.toUpperCase() + '</option>');

                });
                $('#cmbSucursal').selectpicker('refresh');
                $('#cmbSucursal').selectpicker('render');

                //$('#cmbSucursal').val(Responsable);
                //$('#cmbSucursal').selectpicker('refresh');
            }
        });
    }

    $('#btnGuardarCajaChicaSucursal').click(function () {
        
        if ($('#cmbSucursal').val() == '-1' || $('#txtConceptoSucursal').val() == '' || $('#txtCargoSucursal').val() == '' || $('#txtAbonoSucursal').val() == '' || $('#dtFechaSucursal').val() == '' || $('#cmbEstatusSucursal').val() == '') {
            swal('Todos los campos son obligatorios');
            return;
        }

        var parametros = "{'Concepto':'" + $('#txtConceptoSucursal').val() +
            "','Fecha': '" + $('#dtFechaSucursal').val() +
            "', 'IdSucursal':'" + $('#cmbSucursal').val() +
            "', 'Sucursal':'" + $("#cmbSucursal option:selected").text() +
            "', 'Responsable': '" + $("#cmbSucursal option:selected").attr('rel') +
            "', 'Comprobante': '" + $('#cmbComprobanteSucursal').val() +
            "', 'pidproyecto':'" + $('#cmbProyectosSucursal').val() +
            "', 'Proyecto':'" + $("#cmbProyectosSucursal option:selected").text() +
            "', 'Cargo': '" + $('#txtCargoSucursal').val() +
            "', 'Abono': '" + $('#txtAbonoSucursal').val() +
            "','Estatus':'" + $('#cmbEstatusSucursal').val() +
            "', 'Tipo': '" + tipo +
            "', 'nombrearchivo': '" + $('#nombreaarchivopdfSucursal').val() +
            "', 'dataarchivo': '" + $('#dataarchivopdfSucursal').val() +
            "'}";

        //console.log(parametros);
        
        $.ajax({
            dataType: "json",
            url: "CajaChica.aspx/GuardarCCSucursal",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                //debugger;
                if (msg.d == "Informacion actualizada.") {

                    swal({
                        title: msg.d
                    }).then((result) => {

                        if (result) {
                            location.reload();
                        }
                    });

                }
                else {
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
    $('#TablaCajaChica').bootstrapTable('destroy');
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
        '<span title="Ver Archivo" class="btn btn-warning verArchivo"><i class="fa fa-file-o" aria-hidden="true"></i></span>',
        '<span title="Subir Archivo" class="btn btn-success subirArchivo"><i class="fa fa-file-o" aria-hidden="true"></i></span>',
        '</div>'
    ].join(' ');
}

window.accionCC1Events = {
    'click .editar': function (e, value, row, index) {

        var idCajaChica = row.IdCajaChica;
        tipo = 2;
        //$('#EditarCajaChicaForm').empty();
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
                        var OC = item.FolioOrdenCompra;

                        $('#txtidCajaChicaEditar').val(IdCajaChica);
                        $('#dtFecha').val(Fecha);
                        $('#txtResponsable').val(Responsable);
                        $('#txtResponsable2').val(Responsable2);
                        $('#txtConcepto').val(Concepto);
                        CargarProyectosEditarCC(IdProyecto);
                        $('#cmbComprobante').val(Comprobante);
                        //$('#txtCargo').val(formato_numero(Cargo, 2, '.', ','));
                        //$('#txtAbono').val(formato_numero(Abono, 2, '.', ','));
                        $('#txtCargo').val(Cargo);
                        $('#txtAbono').val(Abono);
                        $('#cmbEstatus').val(Estatus);
                        $('#cmbCategoriaCC').val(Categoria);
                        $('#cmbOC').val(OC);

                        $('#txtResponsable').val(Responsable);
                        $('#txtResponsable').selectpicker('refresh');

                      
                    });
                    $("#AddCajaChicaModal").modal();
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

$("#cmbSucursal").change(function () {

    var idSucursal = $(this).val();

    if (idSucursal != null) {
        var params = "{'IdSucursal': '" + idSucursal + "'}";
        //;
        $.ajax({
            async: true,
            url: "CajaChica.aspx/BuscarSucursalInsumo",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                var json = $.parseJSON(data.d);

                $('#cmbProyectosSucursal').html('');
                $('#cmbProyectosSucursal').html('<option value="-1">-- SELECCION --</option>');
                $.each(json, function (index, value) {
                    $("#cmbProyectosSucursal").append('<option value="' + value.IdProyectoInsumos + '">' + value.Descripcion.toUpperCase() + '</option>');
                });
                $('#cmbProyectosSucursal').selectpicker('refresh');
                $('#cmbProyectosSucursal').selectpicker('render');




            }
        });
    }



});

$(document).on('click', '.eliminarDoc', function (event) {
    //;
    //var _boton = $(this);
    //var _item = $(this).parent().parent().find('td')[0].innerHTML;
    //var _producto = $(this).parent().parent().find('td')[2].innerHTML;
    //var _cantidad = $(this).parent().parent().find('td')[4].innerHTML;

    var nombreArchivo = $(this).attr('rel');
    var idDocumento = $(this).val();

    //debugger;

    swal({
        title: "Esta seguro que desea eliminar el documento " + nombreArchivo + "?",
        type: "warning",
        allowOutsideClick: false,
        allowEscapeKey: false,
        allowEnterKey: false,
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si',
        cancelButtonText: 'No'
    }).then(function (result) {

        var params = "{'IdDocumento': '" + idDocumento + "', 'NombreArchivo': '" + nombreArchivo + "'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'CajaChica.aspx/EliminarDocumento',
            data: params,
            success: function (data, textStatus) {
                if (data.d == 'Error') {
                    swal({
                        title: "Hay un error no se encontro el documento, favor de recargar la pagina!",
                        type: "warning",
                        allowOutsideClick: false,
                        allowEscapeKey: false,
                        allowEnterKey: false,
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        cancelButtonText: 'Cerrar'
                    }).then(function () {
                    });
                }
                else {
                    //CargarDatosDetalle();

                    swal({
                        title: "Se elimino correctamente el archivo.",
                        type: "success",
                        allowOutsideClick: false,
                        allowEscapeKey: false,
                        allowEnterKey: false,
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        cancelButtonText: 'Cerrar'
                    }).then(function () {
                        location.reload();
                    });
                }


            }
        });


    }, function (dismiss) {
        // dismiss can be 'cancel', 'overlay',
        // 'close', and 'timer'
        if (dismiss === 'cancel') {
            swal(
                'Cancelled',
                'Cancelo la eliminacion del documento.',
                'error'
            );
        }
    });

});

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

            $('#cmbProyectos').html('');
            //$('#cmbProyectos').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
            //$('#cmbProyectos').append('<option value="80914600-CC95-48F6-8AC0-8667EAFBCFEC">PENDIENTE</option>');
            //$('#cmbProyectos').append('<option value="83B995B4-3877-4600-A16D-5FFF9F3A84E3">ECONOLINE 2003</option>');
            //$('#cmbProyectos').append('<option value="214104A8-0083-4481-8813-A754CD8FFD40">ECONOLINE 2006</option>');
            //$('#cmbProyectos').append('<option value="F765BA07-20A2-4E00-A208-F06D97DF3160">FOCUS</option>');
            //$('#cmbProyectos').append('<option value="8EEE37DB-F5BD-405D-9492-4919618E8C15">IKON</option>');
            //$('#cmbProyectos').append('<option value="697966BC-9116-443E-A0E6-876528AABF08">RANGER</option>');
            //$('#cmbProyectos').append('<option value="83A889B9-11CA-47A9-8538-B1736B773FA8">REMOLQUE</option>');
            //$('#cmbProyectos').append('<option value="9F71A091-10E7-4322-A0AA-F442B45D4958">RAM</option>');
            //$('#cmbProyectos').append('<option value="3A9F72BA-0011-4606-A1C6-07FB83EC4F8D">CHEYENNE</option>');
            //$('#cmbProyectos').append('<option value="3BE79512-40A2-4CC6-83EF-B1C2CDBA6765">RAM 700</option>');
            //$('#cmbProyectos').append('<option value="B0488C4F-1B55-4DB2-B6F4-7555E46916BF">JEEP</option>');
            //$('#cmbProyectos').append('<option value="40F670F5-A145-4C52-AC38-6E791E3B5A19">FRONTIER</option>');
            //$('#cmbProyectos').append('<option value="11313417-6F42-40B8-A933-06C452E34441">SWIFT</option>');
            //$('#cmbProyectos').append('<option value="F76F2A6C-4FA1-4505-82B5-82EE5EE69497">SPARK</option>');
            //$('#cmbProyectos').append('<option value="A9B875EC-1AA2-49D0-8D97-144DBFF21B56">F150</option>');
            //$('#cmbProyectos').append('<option value="EF4EDE9E-BFCD-4D31-9B40-8E6B21291F21">BRONCO</option>');
            //$('#cmbProyectos').append('<option value="1A713837-3DFF-4012-9F5F-7844B3DED561">TONELADA</option>');
            //$('#cmbProyectos').append('<option value="08369BA2-25DD-4CB4-829A-0A472997794F">PASSAT</option>');
            //$('#cmbProyectos').append('<option value="4AD1CAF0-E15C-434C-8A93-794474D902D8">COLORADO</option>');
            //$('#cmbProyectos').append('<option value="57F02FB0-ABFD-4907-8D69-ED9284309B80">BATANGA CHICA</option>');
            //$('#cmbProyectos').append('<option value="EC17D9F8-4824-4B9C-AFA2-C89B34DE2D23">BATANGA MEDIANA</option>');
            //$('#cmbProyectos').append('<option value="3601B5DB-0ACE-468D-80CD-4DE5831362D6">BATANGA GRANDE</option>');
            //$('#cmbProyectos').append('<option value="0EF1486A-A756-4064-981D-A5DDFF46F9B4">HILUX</option>');
            //$('#cmbProyectos').append('<option value="83099F5D-8420-45DF-BAFC-5218A79D2233">FRONTIER 2021</option>');
            //$('#cmbProyectos').append('<option value="A0D7E7EF-DB76-4F99-BAC0-7A4995954481">L200</option>');

            ///* HERMOSILLO */
            //$('#cmbProyectos').append('<option value="7D0116F4-17E1-47A3-82C8-48E0F46110AC">VIATICOS HERMOSILLO</option>');
            //$('#cmbProyectos').append('<option value="B9938D9A-DDE7-453A-B430-2D9ADF68D15F">GASOLINA HERMOSILLO</option>');
            //$('#cmbProyectos').append('<option value="1621D8FD-690E-4C1E-BB94-7E0FAB7C7F56">GASTOS ADMINISTRATIVOS HERMOSILLO</option>');
            //$("#cmbProyectos").append('<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER HERMOSILLO</option>');
            //$("#cmbProyectos").append('<option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA HERMOSILLO</option>');
            //$("#cmbProyectos").append('<option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD HERMOSILLO</option>');
            //$("#cmbProyectos").append('<option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA HERMOSILLO</option>');

            ///* QUERETARO */
            //$('#cmbProyectos').append('<option value="C66E57D6-6390-4D12-8118-4B21F662C8E3">VIATICOS QUERETARO</option>');
            //$('#cmbProyectos').append('<option value="05AC88FC-6340-4936-B749-2F6EDA17F88A">CONSUMIBLES TALLER QUERÉTARO</option>');
            //$('#cmbProyectos').append('<option value="89AE75F8-2D98-40B1-AC47-FDD4D951881C">EQUIPO DE SEGURIDAD QUERÉTARO</option>');
            //$('#cmbProyectos').append('<option value="C8589B15-CAF9-44EB-A49C-FAE500B17EC2">INVENTARIO SISA QUERÉTARO</option>');
            //$('#cmbProyectos').append('<option value="C9E46130-B035-4B7E-97BA-7BED2441BBDD">GASTOS ADMINISTRATIVOS QUERÉTARO</option>');
            //$('#cmbProyectos').append('<option value="84DF1AF7-AD10-4AD6-8F51-9CA6EF0EEC47">GASOLINA QUERÉTARO</option>');


            ///* CHIHUAHUA */
            //$('#cmbProyectos').append('<option value="3A4C9E3B-7BA1-4ABE-8F32-FC1844C51AC1">VIATICOS CHIHUAHUA</option>');
            //$('#cmbProyectos').append('<option value="07BF808D-A646-4D63-9CD7-5161A94FC7FB">CONSUMIBLES TALLER CHIHUAHUA</option>');
            //$('#cmbProyectos').append('<option value="BFC64785-CAD4-4247-B0AE-A64FE53B4669">EQUIPO DE SEGURIDAD CHIHUAHUA</option>');
            //$('#cmbProyectos').append('<option value="734B8D0E-DEBE-46F1-9B69-5FF7334D9EB1">INVENTARIO SISA CHIHUAHUA</option>');
            //$('#cmbProyectos').append('<option value="7846992F-5AF1-4C5F-91C6-A91541C6E405">GASTOS ADMINISTRATIVOS CHIHUAHUA</option>');
            //$('#cmbProyectos').append('<option value="EE3ADE54-E730-4C9D-980E-F1A57BB53BE2">GASOLINA CHIHUAHUA</option>');


            ///* CUAUTITLAN */
            //$('#cmbProyectos').append('<option value="00DAC103-6BC1-419C-BEFE-9F803F9031B9">VIATICOS CUAUTITLAN</option>');
            //$('#cmbProyectos').append('<option value="F74683C3-A52D-4C2B-9B7E-25771AD50ABD">CONSUMIBLES TALLER CUAUTITLÁN</option>');
            //$('#cmbProyectos').append('<option value="6A50C6ED-0384-4E54-9142-B14E7338E2DC">EQUIPO DE SEGURIDAD CUAUTITLÁN</option>');
            //$('#cmbProyectos').append('<option value="BB913E5E-3200-4639-894A-628741DDB24E">INVENTARIO SISA CUAUTITLÁN</option>');
            //$('#cmbProyectos').append('<option value="A46D00C1-0D5B-41B3-8702-0ADA1D98E175">GASTOS ADMINISTRATIVOS CUAUTITLÁN</option>');
            //$('#cmbProyectos').append('<option value="79144254-9D84-486B-A0C6-A2C3D2CC6167">GASOLINA CUAUTITLÁN</option>');


            ///* TECATE */
            //$('#cmbProyectos').append('<option value="0EEBCB40-578B-4815-B46B-BFDA1D7DE4C1">VIATICOS TECATE</option>');
            //$('#cmbProyectos').append('<option value="39A9783A-0AA3-48BE-AF1C-8BDEEC4E1625">CONSUMIBLES TALLER TECATE</option>');
            //$('#cmbProyectos').append('<option value="77C10A22-E1E3-4EBB-806A-2891165EDD88">EQUIPO DE SEGURIDAD TECATE</option>');
            //$('#cmbProyectos').append('<option value="B99F1969-83AF-457B-BC6E-7544B40683EF">INVENTARIO SISA TECATE</option>');
            //$('#cmbProyectos').append('<option value="9AE78058-4070-4F65-82A1-DDEB1E2F624A">GASTOS ADMINISTRATIVOS TECATE</option>');
            //$('#cmbProyectos').append('<option value="178B1FE7-2E94-4F4D-951C-0A823B095505">GASOLINA TECATE</option>');


            ///* IRAPUATO */
            //$('#cmbProyectos').append('<option value="08F847C4-B48F-4951-AD73-31144BE6F86D">VIATICOS IRAPUATO</option>');
            //$('#cmbProyectos').append('<option value="B79F496D-5148-4369-A941-F158BF493CA1">CONSUMIBLES TALLER IRAPUATO</option>');
            //$('#cmbProyectos').append('<option value="0D4A2608-980D-4E1F-8203-5F6D7AA6C19F">EQUIPO DE SEGURIDAD IRAPUATO</option>');
            //$('#cmbProyectos').append('<option value="752B58CB-8B6F-4164-998E-087CAF4FD52F">INVENTARIO SISA IRAPUATO</option>');
            //$('#cmbProyectos').append('<option value="D3B9254C-A667-4E42-B478-701A34D32DC0">GASTOS ADMINISTRATIVOS IRAPUATO</option>');
            //$('#cmbProyectos').append('<option value="FE6D1459-F29F-47FC-844C-0D4158E80E9E">GASOLINA IRAPUATO</option>');

            $.each(json, function (index, value) {
                $("#cmbProyectos").append('<option value="' + value.Id.toUpperCase() + '">' + value.Nombre.toUpperCase() + '</option>');
            });

            $('#cmbProyectos').selectpicker('refresh');
            $('#cmbProyectos').selectpicker('render');
            var id = IdProyecto.toUpperCase();
            $('#cmbProyectos').val(id);
            $('#cmbProyectos').selectpicker('refresh');
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

$("#cmbProyectos").change(function () {

    var idProyecto = $(this).val();

    CargarOrdenCompra(idProyecto);
});

function CargarOrdenCompra(id) {
    var params = "{'pid': '" + id + "'}";

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'CajaChica.aspx/CargarOC',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbOC').html('');
            $('#cmbOC').append('<option value="-1">-- SELECCION ORDEN COMPRA --</option>');
            $('#cmbOC').append('<option value="N/A" name="MATERIAL">N/A</option>');
            $('#cmbOC').append('<option value="PENDIENTE" name="MATERIAL">PENDIENTE</option>');
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
                $("#cmbOC").append('<option value="' + value.Folio + '" name="' + tipo + '">' + value.Folio.toUpperCase() + '</option>');
            });
            $('#cmbOC').selectpicker('refresh');
            $('#cmbOC').selectpicker('render');
        }
    });
}

$('#btnAdjuntarArchivoCC').click(function () {
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
                $("#AddCajaChicaModal").modal();
            }
            reader.readAsDataURL(file);
        }


    });
});

$('#btnEliminadDocumento').click(function () {
    swal({
        title: 'Estas Seguro que quieres eliminar documento?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Aceptar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {

        if (result) {

            var id = document.getElementById('txtidCajaChicaArchivo').textContent;

            var parametros = "{'IdProyecto': '" + id + "'}";
            $.ajax({
                dataType: "json",
                url: "CajaChica.aspx/EliminarDocumento",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Documento eliminado.") {
                        // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                        CargarCC(); 
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
