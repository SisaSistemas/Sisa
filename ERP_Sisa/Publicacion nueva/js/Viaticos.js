$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("Viaticos.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarViaticos();
        CargarProyectos();
        CargarUsuario();
        CargarConceptos();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }

    function CargarViaticos() {
        $('tbody#listaViaticos').empty();
        $('#myPager').html('');
        var parametros = "{'pid': '1'}";
        $.ajax({
            dataType: "json",
            url: "Viaticos.aspx/ObtenerViaticos",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {
                        var ID = json[index].ID;
                        var NombreProyecto = json[index].NombreProyecto;
                        var NombreCompleto = json[index].NombreCompleto;
                        var CantEntregada = json[index].CantEntregada;
                        var CantGastada = json[index].CantGastada;
                        var Diferencia = json[index].Diferencia;
                        var Estatus = json[index].Estatus;
                        var Concepto = json[index].Concepto;
                        var Fecha = json[index].FechaCaptura.substring(0, 10);
                        var Comentarios = json[index].Comentarios;
                        Estatus = (Estatus == 1) ? "Capturando" : "Pendiente";
                        $('tbody#listaViaticos').append(
                            '<tr><td style="display:none;">'
                            + ID
                            + '</td>'
                            + '<td>'
                            + Fecha
                            + '</td>'
                            + '<td>'
                            + NombreProyecto
                            + '</td>'
                            + '<td>'
                            + Concepto
                            + '</td>'
                            + '<td>'
                            + NombreCompleto
                            + '</td>'
                            + '<td>'
                            + formato_numero(CantEntregada, 2, '.', ',')
                            + '</td>'
                            + '<td>'
                            + formato_numero(CantGastada, 2, '.', ',')
                            + '</td>'
                            + '<td>'
                            + formato_numero(Diferencia, 2, '.', ',')
                            + '</td>'
                            + '<td>'
                            + Estatus
                            + '</td>'
                            + '<td>'
                            + Comentarios
                            + '</td>'
                            + '<td>'
                            + '<div class="btn-group">'
                            //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                            + '<Button title="Editar" class= "btn btn-success" value="' + ID + '" onclick="EditarViaticos(this);"> <i class="icon_pencil"></i></Button>'
                            + '<Button title="Eliminar" class= "btn btn-danger" value="' + ID + '" onclick="EliminarViaticos(this);"> <i class="icon_close_alt2"></i></Button>'
                            + '<Button title="Visualizar" class= "btn btn-warning" value="' + ID + '" onclick="CargarViaticoTodoDet(this);"> <i class="icon_table"></i></Button>'
                            + '<Button title="Imprimir" class= "btn btn-info" value="' + ID + '" onclick="ImprimirViatico(this);"> <i class="icon_printer"></i></Button>'
                            + '</div > '
                            + '</td>'
                            + '</tr>')
                    });
                    // $('#listaViaticos').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
                    $('#TablaViaticos').DataTable({
                        "bLengthChange": false,
                        "pageLength": 100,
                        "order": [[1, "desc"]],
                        "oLanguage": {
                            "sSearch": "Buscar:"
                        },
                        "retrieve": true
                    });
                }
                else {
                    $("#MensajeViaticos").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }
            }
        });
    }

    $('#btnGuardarViaticos').click(function () {
        var txtCantidadEntregada = $('#txtCantidadEntregada').val();
        var cmbProyecto = $('#cmbProyecto').val();
        var cmbConcepto = $('#cmbConcepto').val();
        var cmbUsuarios = $('#cmbUsuario').val();
        var txtComentarios = $('#txtComentarios').val();
        var dtFechaViatico = $('#dtFechaViatico').val();

        if (txtCantidadEntregada == "" || cmbProyecto == "-1" || cmbUsuarios == "-1" || dtFechaViatico == "") {
            //$("#AddMsgViaticos").append('<div class="alert alert-danger fade in"><p>Completa los campos obligatorios.</p></div >');
            swal('Completa los campos obligatorios.');
        }
        else {
            var parametros = "{'Usuario': '" + cmbUsuarios + "', 'Proyecto': '" + cmbProyecto + "', 'Cantidad': '" + txtCantidadEntregada + "', 'Concepto':'" + cmbConcepto + "', 'Comentarios':'" + txtComentarios + "', 'FechaViatico':'" + dtFechaViatico + "'}";
            $.ajax({
                dataType: "json",
                url: "Viaticos.aspx/GuardarViatico",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Viatico creado.") {
                        //$("#AddMsgViaticos").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                        CargarViaticos();
                        swal(msg.d);
                    }
                    else {
                        //$("#AddMsgViaticos").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                        swal(msg.d);
                    }
                }
            });
        }

    });

    $('#btnEliminarViaticos').click(function () {
        var id = document.getElementById('idViaticosEliminar').textContent;

        var parametros = "{'pid': '" + id + "'}";
        $.ajax({
            dataType: "json",
            url: "Viaticos.aspx/EliminarViaticos",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Viatico eliminado.") {
                    //$("#txtModalEliminarMensajeRequisiciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarViaticos();
                    swal('Viático eliminado.');
                }
                else {
                    //$("#txtModalEliminarMensajeRequisiciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    function CargarUsuario() {
        var parametros = "{'pid': '2'}";
        $.ajax({
            dataType: "json",
            url: "Viaticos.aspx/CargarUsuarios",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {

                        var IdUsuario = json[index].IdUsuario;
                        var NombreCompleto = json[index].NombreCompleto;
                        //var jsonItem = "{'idSucursa': '" + IdSucursal + "', 'CiudadSucursal': '" + CiudadSucursal + "', 'DireccionSucursal': '" + DireccionSucursal + "', 'TelefonoSucursal': '" + TelefonoSucursal + "' }";                       
                        $("#cmbUsuario").append('<option value="' + IdUsuario + '">' + NombreCompleto + '</option>');
                    });
                    $('#cmbUsuario').selectpicker('refresh');
                    $('#cmbUsuario').selectpicker('render');
                }
                else {
                    $("#MensajeViaticos").append('<div class="alert alert-danger fade in"><p>No se obtuvo información o no tienes permiso de acceso.</p></div >');

                }
            }
        });
    }

    function CargarProyectos() {
        var parametros = "{'pid': '2'}";
        $.ajax({
            dataType: "json",
            url: "Viaticos.aspx/CargarProyectos",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {

                        var IdProyecto = json[index].IdProyecto;
                        var NombreProyecto = json[index].NombreProyecto;
                        var FolioProyecto = json[index].FolioProyecto;
                        //var jsonItem = "{'idSucursa': '" + IdSucursal + "', 'CiudadSucursal': '" + CiudadSucursal + "', 'DireccionSucursal': '" + DireccionSucursal + "', 'TelefonoSucursal': '" + TelefonoSucursal + "' }";                       
                        $("#cmbProyecto").append('<option value="' + IdProyecto + '">' + FolioProyecto + '-' + NombreProyecto + '</option>');
                    });

                    
                    $('#cmbProyecto').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
                    $('#cmbProyecto').append('<option value="80914600-CC95-48F6-8AC0-8667EAFBCFEC">PENDIENTE</option>');
                    $('#cmbProyecto').append('<option value="83B995B4-3877-4600-A16D-5FFF9F3A84E3">ECONOLINE 2003</option>');
                    $('#cmbProyecto').append('<option value="214104A8-0083-4481-8813-A754CD8FFD40">ECONOLINE 2006</option>');
                    $('#cmbProyecto').append('<option value="F765BA07-20A2-4E00-A208-F06D97DF3160">FOCUS</option>');
                    $('#cmbProyecto').append('<option value="8EEE37DB-F5BD-405D-9492-4919618E8C15">IKON</option>');
                    $('#cmbProyecto').append('<option value="697966BC-9116-443E-A0E6-876528AABF08">RANGER</option>');
                    $('#cmbProyecto').append('<option value="83A889B9-11CA-47A9-8538-B1736B773FA8">REMOLQUE</option>');
                    $('#cmbProyecto').append('<option value="9F71A091-10E7-4322-A0AA-F442B45D4958">RAM</option>');
                    $('#cmbProyecto').append('<option value="3A9F72BA-0011-4606-A1C6-07FB83EC4F8D">CHEYENNE</option>');
                    $('#cmbProyecto').append('<option value="3BE79512-40A2-4CC6-83EF-B1C2CDBA6765">RAM 700</option>');
                    $('#cmbProyecto').append('<option value="B0488C4F-1B55-4DB2-B6F4-7555E46916BF">JEEP</option>');
                    $('#cmbProyecto').append('<option value="40F670F5-A145-4C52-AC38-6E791E3B5A19">FRONTIER</option>');
                    $('#cmbProyecto').append('<option value="11313417-6F42-40B8-A933-06C452E34441">SWIFT</option>');
                    $('#cmbProyecto').append('<option value="F76F2A6C-4FA1-4505-82B5-82EE5EE69497">SPARK</option>');
                    $('#cmbProyecto').append('<option value="A9B875EC-1AA2-49D0-8D97-144DBFF21B56">F150</option>');
                    $('#cmbProyecto').append('<option value="EF4EDE9E-BFCD-4D31-9B40-8E6B21291F21">BRONCO</option>');
                    $('#cmbProyecto').append('<option value="1A713837-3DFF-4012-9F5F-7844B3DED561">TONELADA</option');
                    $('#cmbProyecto').append('<option value="08369BA2-25DD-4CB4-829A-0A472997794F">PASSAT</option>');
                    $('#cmbProyecto').append('<option value="4AD1CAF0-E15C-434C-8A93-794474D902D8">COLORADO</option>');
                    $('#cmbProyecto').append('<option value="57F02FB0-ABFD-4907-8D69-ED9284309B80">BATANGA CHICA</option>');
                    $('#cmbProyecto').append('<option value="EC17D9F8-4824-4B9C-AFA2-C89B34DE2D23">BATANGA MEDIANA</option>');
                    $('#cmbProyecto').append('<option value="3601B5DB-0ACE-468D-80CD-4DE5831362D6">BATANGA GRANDE</option>');
                    $('#cmbProyecto').append('<option value="0EF1486A-A756-4064-981D-A5DDFF46F9B4">HILUX</option>');
                    $('#cmbProyecto').append('<option value="83099F5D-8420-45DF-BAFC-5218A79D2233">FRONTIER 2021</option>');
                    $('#cmbProyecto').append('<option value="CB59215E-2248-4773-91C3-8D77CC33A7F9">VISITA</option>');
                    $('#cmbProyecto').append('<option value="A0D7E7EF-DB76-4F99-BAC0-7A4995954481">L200</option>');


                    /* HERMOSILLO */
                    $('#cmbProyecto').append('<option value="7D0116F4-17E1-47A3-82C8-48E0F46110AC">VIATICOS HERMOSILLO</option>');
                    $('#cmbProyecto').append('<option value="B9938D9A-DDE7-453A-B430-2D9ADF68D15F">GASOLINA HERMOSILLO</option>');
                    $('#cmbProyecto').append('<option value="1621D8FD-690E-4C1E-BB94-7E0FAB7C7F56">GASTOS ADMINISTRATIVOS HERMOSILLO</option>');
                    $("#cmbProyecto").append('<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER HERMOSILLO</option>');
                    $("#cmbProyecto").append('<option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA HERMOSILLO</option>');
                    $("#cmbProyecto").append('<option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD HERMOSILLO</option>');
                    $("#cmbProyecto").append('<option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA HERMOSILLO</option>');

                    /* QUERETARO */
                    $('#cmbProyecto').append('<option value="C66E57D6-6390-4D12-8118-4B21F662C8E3">VIATICOS QUERETARO</option>');
                    $('#cmbProyecto').append('<option value="05AC88FC-6340-4936-B749-2F6EDA17F88A">CONSUMIBLES TALLER QUERÉTARO</option>');
                    $('#cmbProyecto').append('<option value="89AE75F8-2D98-40B1-AC47-FDD4D951881C">EQUIPO DE SEGURIDAD QUERÉTARO</option>');
                    $('#cmbProyecto').append('<option value="C8589B15-CAF9-44EB-A49C-FAE500B17EC2">INVENTARIO SISA QUERÉTARO</option>');
                    $('#cmbProyecto').append('<option value="C9E46130-B035-4B7E-97BA-7BED2441BBDD">GASTOS ADMINISTRATIVOS QUERÉTARO</option>');
                    $('#cmbProyecto').append('<option value="84DF1AF7-AD10-4AD6-8F51-9CA6EF0EEC47">GASOLINA QUERÉTARO</option>');


                    /* CHIHUAHUA */
                    $('#cmbProyecto').append('<option value="3A4C9E3B-7BA1-4ABE-8F32-FC1844C51AC1">VIATICOS CHIHUAHUA</option>');
                    $('#cmbProyecto').append('<option value="07BF808D-A646-4D63-9CD7-5161A94FC7FB">CONSUMIBLES TALLER CHIHUAHUA</option>');
                    $('#cmbProyecto').append('<option value="BFC64785-CAD4-4247-B0AE-A64FE53B4669">EQUIPO DE SEGURIDAD CHIHUAHUA</option>');
                    $('#cmbProyecto').append('<option value="734B8D0E-DEBE-46F1-9B69-5FF7334D9EB1">INVENTARIO SISA CHIHUAHUA</option>');
                    $('#cmbProyecto').append('<option value="7846992F-5AF1-4C5F-91C6-A91541C6E405">GASTOS ADMINISTRATIVOS CHIHUAHUA</option>');
                    $('#cmbProyecto').append('<option value="EE3ADE54-E730-4C9D-980E-F1A57BB53BE2">GASOLINA CHIHUAHUA</option>');


                    /* CUAUTITLAN */
                    $('#cmbProyecto').append('<option value="00DAC103-6BC1-419C-BEFE-9F803F9031B9">VIATICOS CUAUTITLAN</option>');
                    $('#cmbProyecto').append('<option value="F74683C3-A52D-4C2B-9B7E-25771AD50ABD">CONSUMIBLES TALLER CUAUTITLÁN</option>');
                    $('#cmbProyecto').append('<option value="6A50C6ED-0384-4E54-9142-B14E7338E2DC">EQUIPO DE SEGURIDAD CUAUTITLÁN</option>');
                    $('#cmbProyecto').append('<option value="BB913E5E-3200-4639-894A-628741DDB24E">INVENTARIO SISA CUAUTITLÁN</option>');
                    $('#cmbProyecto').append('<option value="A46D00C1-0D5B-41B3-8702-0ADA1D98E175">GASTOS ADMINISTRATIVOS CUAUTITLÁN</option>');
                    $('#cmbProyecto').append('<option value="79144254-9D84-486B-A0C6-A2C3D2CC6167">GASOLINA CUAUTITLÁN</option>');


                    /* TECATE */
                    $('#cmbProyecto').append('<option value="0EEBCB40-578B-4815-B46B-BFDA1D7DE4C1">VIATICOS TECATE</option>');
                    $('#cmbProyecto').append('<option value="39A9783A-0AA3-48BE-AF1C-8BDEEC4E1625">CONSUMIBLES TALLER TECATE</option>');
                    $('#cmbProyecto').append('<option value="77C10A22-E1E3-4EBB-806A-2891165EDD88">EQUIPO DE SEGURIDAD TECATE</option>');
                    $('#cmbProyecto').append('<option value="B99F1969-83AF-457B-BC6E-7544B40683EF">INVENTARIO SISA TECATE</option>');
                    $('#cmbProyecto').append('<option value="9AE78058-4070-4F65-82A1-DDEB1E2F624A">GASTOS ADMINISTRATIVOS TECATE</option>');
                    $('#cmbProyecto').append('<option value="178B1FE7-2E94-4F4D-951C-0A823B095505">GASOLINA TECATE</option>');


                    /* IRAPUATO */
                    $('#cmbProyecto').append('<option value="08F847C4-B48F-4951-AD73-31144BE6F86D">VIATICOS IRAPUATO</option>');
                    $('#cmbProyecto').append('<option value="B79F496D-5148-4369-A941-F158BF493CA1">CONSUMIBLES TALLER IRAPUATO</option>');
                    $('#cmbProyecto').append('<option value="0D4A2608-980D-4E1F-8203-5F6D7AA6C19F">EQUIPO DE SEGURIDAD IRAPUATO</option>');
                    $('#cmbProyecto').append('<option value="752B58CB-8B6F-4164-998E-087CAF4FD52F">INVENTARIO SISA IRAPUATO</option>');
                    $('#cmbProyecto').append('<option value="D3B9254C-A667-4E42-B478-701A34D32DC0">GASTOS ADMINISTRATIVOS IRAPUATO</option>');
                    $('#cmbProyecto').append('<option value="FE6D1459-F29F-47FC-844C-0D4158E80E9E">GASOLINA IRAPUATO</option>');


                    $('#cmbProyecto').selectpicker('refresh');
                    $('#cmbProyecto').selectpicker('render');
                }
                else {
                    $("#MensajeViaticos").append('<div class="alert alert-danger fade in"><p>No se obtuvo información o no tienes permiso de acceso.</p></div >');

                }
            }
        });
    }

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

    function CargarConceptos() {
        var parametros = "{'Opcion': '17'}";
        $.ajax({
            dataType: "json",
            url: "Viaticos.aspx/CargarCombos",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = $.parseJSON(data.d);


                    $('#cmbConcepto').html('');
                    $('#cmbConcepto').html('<option value="-1">-- SELECCIONE CONCEPTO --</option>');                   

                    $.each(json, function (index, value) {
                        $("#cmbConcepto").append('<option value="' + value.Correo + '">' + value.Correo.toUpperCase() + '</option>');
                    });

                    $('#cmbConcepto').selectpicker('refresh');
                    $('#cmbConcepto').selectpicker('render');
                }
                else {
                    $("#MensajeViaticos").append('<div class="alert alert-danger fade in"><p>No se obtuvo información o no tienes permiso de acceso.</p></div >');

                }
            }
        });
    }
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

function sumarColumnasViaticoDet(IdViaticos) {

    var params = "{'IdViatico': '" + IdViaticos + "'}";

    $.ajax({
        async: true,
        url: "VerViaticos.aspx/CargarSuma",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var datos = "";
            var nodoTRAgregar = "";
            var JsonCombos;
            var jsonStr = $.parseJSON(data.d);


            $.each(jsonStr, function (index, value) {
                $('#lblGasolina').text(formato_numero(value.Gasolina, 2, ".", ","));
                $('#lblDesayuno').text(formato_numero(value.Desayuno, 2, ".", ","));
                $('#lblComida').text(formato_numero(value.Comida, 2, ".", ","));
                $('#lblCena').text(formato_numero(value.Cena, 2, ".", ","));
                $('#lblCasetas').text(formato_numero(value.Casetas, 2, ".", ","));
                $('#lblHotel').text(formato_numero(value.Hotel, 2, ".", ","));
                $('#lblTransporte').text(formato_numero(value.Transporte, 2, ".", ","));
                $('#lblOtros').text(formato_numero(value.Otros, 2, ".", ","));
                $('#lblManoObra').text(formato_numero(value.ManoObra, 2, ".", ","));
                $('#lblMateriales').text(formato_numero(value.Materiales, 2, ".", ","));
                $('#lblEquipo').text(formato_numero(value.Equipo, 2, ".", ","));
            });




            //TdCantidadEntregada.html(formato_numero(aData[3], 2, ".", ","));
        }
    });
}


function CargarViaticoTodoDet(IdViaticos) {
    var params = "{'IdViatico': '" + IdViaticos.value + "'}";
    console.log(IdViaticos.value);
    var idProyecto = '';
    var Nom = '';
    $.ajax({
        async: true,
        url: "Viaticos.aspx/Cargar",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var datos = "";
            var nodoTRAgregar = "";
            var JsonCombos;
            var jsonStr = $.parseJSON(data.d);

            $('#tblViaticosVer tbody').html('');
            $.each(jsonStr, function (index, value) {
                $('#lblProyecto').text(value.NombreProyecto);
                $('#lblCantEntregada').text(formato_numero(value.CantEntregada, 2, ".", ","));
                $('#lblCantGastada').text(formato_numero(value.CantGastada, 2, ".", ","));
                $('#lblDiferencia').text(formato_numero(value.Diferencia, 2, ".", ","));
                $('#lblResponsable').text(value.NombreCompleto);
                $('#lblProyectoPrincipal').text(value.ProyectoOtorga);
                //$("#cmbProyectos").append("<option value=" + value.idProyectoOtorga + ">" + value.ProyectoOtorga.toUpperCase() + "</option>");
                var Ticket = value.Ticket;
                if (Ticket == "NULL" || Ticket === null || Ticket == '') {
                    //Ticket = '<Button title="Agregar ticket" class="btn btn-danger" value="' + value.IdDet + '" onclick="AgregarTicket(this);"><i class="icon_document_alt"></i></Button>';

                }
                else {
                    //Ticket = '<Button title="Ver ticket" class="btn btn-info" data-toggle="modal"  data-target="#dvPDFTicketDet" value="' + value.IdDet + '" onclick="VisualizarDocumentoTicketDet(this);"><i class="icon_document"></i></Button>';
                    Ticket = '<span title="Ver ticket" class="btn btn-info" data-toggle="modal" data-keyboard="false" data-backdrop="static" value="' + value.IdDet + '" onclick="VisualizarDocumentoTicketDet(this);"><i class="icon_document"></i></span>';

                }
                //idProyecto = value.IdProyecto;
                Nom = value.NombreProyecto;
                nodoTRAgregar += "<tr>";

                nodoTRAgregar += "<td>" + value.ID + "</td>";
                nodoTRAgregar += "<td>" + value.FechaViaticos.substring(0, 10) + "</td>";
                nodoTRAgregar += "<td>" + value.NombreProyecto + "</td>";
                nodoTRAgregar += "<td>" + value.Descripcion + "</td>";
                nodoTRAgregar += "<td>" + formato_numero(value.Gasolina, 2, '.', ',') + "</td>";
                nodoTRAgregar += "<td>" + formato_numero(value.Desayuno, 2, '.', ',') + "</td>";
                nodoTRAgregar += "<td>" + formato_numero(value.Comida, 2, '.', ',') + "</td>";
                nodoTRAgregar += "<td>" + formato_numero(value.Cena, 2, '.', ',') + "</td>";
                nodoTRAgregar += "<td>" + formato_numero(value.Casetas, 2, '.', ',') + "</td>";
                nodoTRAgregar += "<td>" + formato_numero(value.Hotel, 2, '.', ',') + "</td>";
                nodoTRAgregar += "<td>" + formato_numero(value.Transporte, 2, '.', ',') + "</td>";
                nodoTRAgregar += "<td>" + formato_numero(value.Otros, 2, '.', ',') + "</td>";
                nodoTRAgregar += "<td>" + formato_numero(value.ManoObra, 2, '.', ',') + "</td>";
                nodoTRAgregar += "<td>" + formato_numero(value.Materiales, 2, '.', ',') + "</td>";
                nodoTRAgregar += "<td>" + formato_numero(value.Equipo, 2, '.', ',') + "</td>";
                nodoTRAgregar += '<td><div class="btn-group">' + Ticket + "</div></td>";
                nodoTRAgregar += "</tr>";
            });

            $('#tblViaticosVer').append(nodoTRAgregar);
            sumarColumnasViaticoDet(IdViaticos.value);
            CargarProyectosDet(IdViaticos.value);
        }
    });
    $("#dvDetalleViatico").modal();
}

function CargarProyectosDet(IdViaticos) {
    var params = "{'id': '" + IdViaticos + "'}";
    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'VerViaticos.aspx/CargarInfoGeneral',
        data: params,
        success: function (data, textStatus) {

            var json = JSON.parse(data.d);

            $('#cmbProyectos').html('');
            $(json).each(function (index, value) {
                $('#lblProyecto').text(value.NombreProyecto);
                $('#lblCantEntregada').text(formato_numero(value.CantEntregada, 2, ".", ","));
                $('#lblCantGastada').text(formato_numero(value.CantGastada, 2, ".", ","));
                $('#lblDiferencia').text(formato_numero(value.Diferencia, 2, ".", ","));
                $('#lblResponsable').text(value.NombreCompleto);
                $('#lblProyectoPrincipal').text(value.ProyectoOtorga);
                $("#cmbProyectos").append("<option value=" + value.idProyectoOtorga + ">" + value.ProyectoOtorga.toUpperCase() + "</option>");
            });


        }
    });
    //if (idProyecto == '' && Nom == '') {

    //}
    //else {
    //    $("#cmbProyectos").append("<option value=" + idProyecto + ">" + Nom.toUpperCase() + "</option>");
    //}



}

function VisualizarDocumentoTicketDet(btn) {
    $('#testmodalpdfTicketDet').html('');

    //console.log(btn.value);

    var params = "{'Id': '" + $(btn).attr('value') +
        "','Opcion': '" + "T" + "'}";
    $.ajax({
        async: true,
        url: "VerViaticos.aspx/CargarDocumentos",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            var datos = "";

            var JsonCombos;
            var jsonArray = $.parseJSON(data.d);


            $.each(jsonArray, function (index, value) {

                if (value.Ticket.includes("PDF") || value.Ticket.includes("pdf")) {

                    $('#testmodalpdfTicketDet').append('<embed src="' + value.Ticket + '" type="application/pdf" width="100%" height="600px" />');
                }
                else {

                    $('#testmodalpdfTicketDet').append('<img src="' + value.Ticket + '" width="100%" height="600"/>');
                }

            });
        }
    });
    $("#dvPDFTicketDet").modal();

}

function ImprimirViatico(btn) {
    //debugger;
    var folio = $(btn).val();
    window.open("../Reportes/frmRptViaticos.aspx?IdViaticos=" + folio);
} 