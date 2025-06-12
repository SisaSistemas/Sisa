$(document).ready(function () {

    var IdViaticos = 0; //"lgalvez01";
    var URLactual = window.location;
    if (URLactual.href.indexOf("VerViaticos.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        IdViaticos = getUrlVars()["IdViaticos"];
        CargarViaticoTodo();
        //document.getElementById('cmbProyectosNuevos').disabled = true;
        $("#cmbProyectosNuevos").prop("disabled", true);
        $('#cmbProyectosNuevos').selectpicker('refresh');
        CargarProyectosTodo();

        cargarCantidadEntregada();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }

    function getUrlVars() {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        }
        return vars;
    }

    $('#chkViatico').change(function () {
        if (this.checked) {
            document.getElementById('txtTextoViaticos').textContent = 'SI';
            //document.getElementById('cmbProyectosNuevos').disabled = false;
            $("#cmbProyectosNuevos").prop("disabled", false);
            $('#cmbProyectosNuevos').selectpicker('refresh');

        } else {
            document.getElementById('txtTextoViaticos').textContent = 'NO';
            //document.getElementById('cmbProyectosNuevos').disabled = true;
            $("#cmbProyectosNuevos").prop("disabled", true);
            $('#cmbProyectosNuevos').selectpicker('refresh');
        }
    });

    function CargarProyectos(idProyecto, Nom) {
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

    function CargarProyectosTodo() {
        var params = "{'Opcion': '10'}";
        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'VerViaticos.aspx/CargarCombos',
            data: params,
            success: function (data, textStatus) {

                var json = $.parseJSON(data.d);

                $('#cmbProyectosNuevos').html('');
                $("#cmbProyectosNuevos").append('<option value="-1">Selecciona proyecto diferente.</option>');
                $.each(json, function (index, value) {
                    $("#cmbProyectosNuevos").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
                });
                //$('#cmbProyectosNuevos').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
                //$('#cmbProyectosNuevos').append('<option value="80914600-CC95-48F6-8AC0-8667EAFBCFEC">PENDIENTE</option>');
                //$('#cmbProyectosNuevos').append('<option value="83B995B4-3877-4600-A16D-5FFF9F3A84E3">ECONOLINE 2003</option>');
                //$('#cmbProyectosNuevos').append('<option value="214104A8-0083-4481-8813-A754CD8FFD40">ECONOLINE 2006</option>');
                //$('#cmbProyectosNuevos').append('<option value="F765BA07-20A2-4E00-A208-F06D97DF3160">FOCUS</option>');
                //$('#cmbProyectosNuevos').append('<option value="8EEE37DB-F5BD-405D-9492-4919618E8C15">IKON</option>');
                //$('#cmbProyectosNuevos').append('<option value="697966BC-9116-443E-A0E6-876528AABF08">RANGER</option>');
                //$('#cmbProyectosNuevos').append('<option value="83A889B9-11CA-47A9-8538-B1736B773FA8">REMOLQUE</option>');
                //$('#cmbProyectosNuevos').append('<option value="9F71A091-10E7-4322-A0AA-F442B45D4958">RAM</option>');
                //$('#cmbProyectosNuevos').append('<option value="3A9F72BA-0011-4606-A1C6-07FB83EC4F8D">CHEYENNE</option>');
                //$('#cmbProyectosNuevos').append('<option value="3BE79512-40A2-4CC6-83EF-B1C2CDBA6765">RAM 700</option>');
                //$('#cmbProyectosNuevos').append('<option value="B0488C4F-1B55-4DB2-B6F4-7555E46916BF">JEEP</option>');
                //$('#cmbProyectosNuevos').append('<option value="40F670F5-A145-4C52-AC38-6E791E3B5A19">FRONTIER</option>');
                //$('#cmbProyectosNuevos').append('<option value="11313417-6F42-40B8-A933-06C452E34441">SWIFT</option>');
                //$('#cmbProyectosNuevos').append('<option value="F76F2A6C-4FA1-4505-82B5-82EE5EE69497">SPARK</option>');
                //$('#cmbProyectosNuevos').append('<option value="A9B875EC-1AA2-49D0-8D97-144DBFF21B56">F150</option>');
                //$('#cmbProyectosNuevos').append('<option value="EF4EDE9E-BFCD-4D31-9B40-8E6B21291F21">BRONCO</option>');
                //$('#cmbProyectosNuevos').append('<option value="1A713837-3DFF-4012-9F5F-7844B3DED561">TONELADA</option>');
                //$('#cmbProyectosNuevos').append('<option value="08369BA2-25DD-4CB4-829A-0A472997794F">PASSAT</option>');
                //$('#cmbProyectosNuevos').append('<option value="4AD1CAF0-E15C-434C-8A93-794474D902D8">COLORADO</option>');
                //$('#cmbProyectosNuevos').append('<option value="57F02FB0-ABFD-4907-8D69-ED9284309B80">BATANGA CHICA</option>');
                //$('#cmbProyectosNuevos').append('<option value="EC17D9F8-4824-4B9C-AFA2-C89B34DE2D23">BATANGA MEDIANA</option>');
                //$('#cmbProyectosNuevos').append('<option value="3601B5DB-0ACE-468D-80CD-4DE5831362D6">BATANGA GRANDE</option>');
                //$('#cmbProyectosNuevos').append('<option value="0EF1486A-A756-4064-981D-A5DDFF46F9B4">HILUX</option>');
                //$('#cmbProyectosNuevos').append('<option value="83099F5D-8420-45DF-BAFC-5218A79D2233">FRONTIER 2021</option>');
                //$('#cmbProyectosNuevos').append('<option value="CB59215E-2248-4773-91C3-8D77CC33A7F9">VISITA</option>');
                //$('#cmbProyectosNuevos').append('<option value="A0D7E7EF-DB76-4F99-BAC0-7A4995954481">L200</option>');

                ///* HERMOSILLO */
                //$('#cmbProyecto').append('<option value="7D0116F4-17E1-47A3-82C8-48E0F46110AC">VIATICOS HERMOSILLO</option>');
                //$('#cmbProyecto').append('<option value="B9938D9A-DDE7-453A-B430-2D9ADF68D15F">GASOLINA HERMOSILLO</option>');
                //$('#cmbProyecto').append('<option value="1621D8FD-690E-4C1E-BB94-7E0FAB7C7F56">GASTOS ADMINISTRATIVOS HERMOSILLO</option>');
                //$("#cmbProyecto").append('<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER HERMOSILLO</option>');
                //$("#cmbProyecto").append('<option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA HERMOSILLO</option>');
                //$("#cmbProyecto").append('<option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD HERMOSILLO</option>');
                //$("#cmbProyecto").append('<option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA HERMOSILLO</option>');

                ///* QUERETARO */
                //$('#cmbProyecto').append('<option value="C66E57D6-6390-4D12-8118-4B21F662C8E3">VIATICOS QUERETARO</option>');
                //$('#cmbProyecto').append('<option value="05AC88FC-6340-4936-B749-2F6EDA17F88A">CONSUMIBLES TALLER QUERÉTARO</option>');
                //$('#cmbProyecto').append('<option value="89AE75F8-2D98-40B1-AC47-FDD4D951881C">EQUIPO DE SEGURIDAD QUERÉTARO</option>');
                //$('#cmbProyecto').append('<option value="C8589B15-CAF9-44EB-A49C-FAE500B17EC2">INVENTARIO SISA QUERÉTARO</option>');
                //$('#cmbProyecto').append('<option value="C9E46130-B035-4B7E-97BA-7BED2441BBDD">GASTOS ADMINISTRATIVOS QUERÉTARO</option>');
                //$('#cmbProyecto').append('<option value="84DF1AF7-AD10-4AD6-8F51-9CA6EF0EEC47">GASOLINA QUERÉTARO</option>');


                ///* CHIHUAHUA */
                //$('#cmbProyecto').append('<option value="3A4C9E3B-7BA1-4ABE-8F32-FC1844C51AC1">VIATICOS CHIHUAHUA</option>');
                //$('#cmbProyecto').append('<option value="07BF808D-A646-4D63-9CD7-5161A94FC7FB">CONSUMIBLES TALLER CHIHUAHUA</option>');
                //$('#cmbProyecto').append('<option value="BFC64785-CAD4-4247-B0AE-A64FE53B4669">EQUIPO DE SEGURIDAD CHIHUAHUA</option>');
                //$('#cmbProyecto').append('<option value="734B8D0E-DEBE-46F1-9B69-5FF7334D9EB1">INVENTARIO SISA CHIHUAHUA</option>');
                //$('#cmbProyecto').append('<option value="7846992F-5AF1-4C5F-91C6-A91541C6E405">GASTOS ADMINISTRATIVOS CHIHUAHUA</option>');
                //$('#cmbProyecto').append('<option value="EE3ADE54-E730-4C9D-980E-F1A57BB53BE2">GASOLINA CHIHUAHUA</option>');


                ///* CUAUTITLAN */
                //$('#cmbProyecto').append('<option value="00DAC103-6BC1-419C-BEFE-9F803F9031B9">VIATICOS CUAUTITLAN</option>');
                //$('#cmbProyecto').append('<option value="F74683C3-A52D-4C2B-9B7E-25771AD50ABD">CONSUMIBLES TALLER CUAUTITLÁN</option>');
                //$('#cmbProyecto').append('<option value="6A50C6ED-0384-4E54-9142-B14E7338E2DC">EQUIPO DE SEGURIDAD CUAUTITLÁN</option>');
                //$('#cmbProyecto').append('<option value="BB913E5E-3200-4639-894A-628741DDB24E">INVENTARIO SISA CUAUTITLÁN</option>');
                //$('#cmbProyecto').append('<option value="A46D00C1-0D5B-41B3-8702-0ADA1D98E175">GASTOS ADMINISTRATIVOS CUAUTITLÁN</option>');
                //$('#cmbProyecto').append('<option value="79144254-9D84-486B-A0C6-A2C3D2CC6167">GASOLINA CUAUTITLÁN</option>');


                ///* TECATE */
                //$('#cmbProyecto').append('<option value="0EEBCB40-578B-4815-B46B-BFDA1D7DE4C1">VIATICOS TECATE</option>');
                //$('#cmbProyecto').append('<option value="39A9783A-0AA3-48BE-AF1C-8BDEEC4E1625">CONSUMIBLES TALLER TECATE</option>');
                //$('#cmbProyecto').append('<option value="77C10A22-E1E3-4EBB-806A-2891165EDD88">EQUIPO DE SEGURIDAD TECATE</option>');
                //$('#cmbProyecto').append('<option value="B99F1969-83AF-457B-BC6E-7544B40683EF">INVENTARIO SISA TECATE</option>');
                //$('#cmbProyecto').append('<option value="9AE78058-4070-4F65-82A1-DDEB1E2F624A">GASTOS ADMINISTRATIVOS TECATE</option>');
                //$('#cmbProyecto').append('<option value="178B1FE7-2E94-4F4D-951C-0A823B095505">GASOLINA TECATE</option>');


                ///* IRAPUATO */
                //$('#cmbProyecto').append('<option value="08F847C4-B48F-4951-AD73-31144BE6F86D">VIATICOS IRAPUATO</option>');
                //$('#cmbProyecto').append('<option value="B79F496D-5148-4369-A941-F158BF493CA1">CONSUMIBLES TALLER IRAPUATO</option>');
                //$('#cmbProyecto').append('<option value="0D4A2608-980D-4E1F-8203-5F6D7AA6C19F">EQUIPO DE SEGURIDAD IRAPUATO</option>');
                //$('#cmbProyecto').append('<option value="752B58CB-8B6F-4164-998E-087CAF4FD52F">INVENTARIO SISA IRAPUATO</option>');
                //$('#cmbProyecto').append('<option value="D3B9254C-A667-4E42-B478-701A34D32DC0">GASTOS ADMINISTRATIVOS IRAPUATO</option>');
                //$('#cmbProyecto').append('<option value="FE6D1459-F29F-47FC-844C-0D4158E80E9E">GASOLINA IRAPUATO</option>');

                $('#cmbProyectosNuevos').selectpicker('refresh');
                $('#cmbProyectosNuevos').selectpicker('render');
            }
        });
    }



    function sumarColumnas() {

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

    $('#btnAgregarGastos').click(function () {
        var txtDescripcion = $('#txtDescripcion').val();

        var txtCantidad = $('#txtCantidad').val();
        var cmbProyecto = '-1';
        if ($('#chkViatico').is(":checked")) {
            cmbProyecto = $('#cmbProyectosNuevos').val();
        }
        else {
            cmbProyecto = $('#cmbProyectos').val();
        }

        var cmbGasto = $('#cmbGasto').val();
        var txtFechaGasto = $('#dtFechaGasto').val();
        
        var Tick = $("[id*='ImgPrv']").prop('src');
        if (txtDescripcion == "" || txtCantidad == "" || cmbProyecto == "-1" || cmbGasto == "-1" || txtFechaGasto == undefined) {
            //$("#MensajeViaticos").append('<div class="alert alert-danger fade in"><p>Completa los campos obligatorios.</p></div >');
            swal('Completa los campos obligatorios.');
        }
        else { 
            var parametros = "{'idProyecto': '" + cmbProyecto +
                "', 'txtDescripcion': '" + txtDescripcion +
                "', 'txtCantidad': '" + txtCantidad +
                "', 'Tick': '" + Tick +
                "', 'cmbGasto': '" + cmbGasto +
                "', 'txtFechaGasto': '" + txtFechaGasto +
                "', 'idViatico': '" + IdViaticos + "'}";

            $.ajax({
                dataType: "json",
                url: "VerViaticos.aspx/GuardarViaticoDetalle",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Detalle creado.") {
                        //$("#MensajeViaticos").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                        CargarViaticoTodo();
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

    $('#btnEliminadDocumentoTicket').click(function () {
        swal({
            title: 'Estas Seguro que quieres eliminar ticket?',
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

                var parametros = "{'Id': '" + id + "', 'Opcion':'" + tipo + "'}";
                $.ajax({
                    dataType: "json",
                    url: "VerViaticos.aspx/EliminarDocumento",
                    async: true,
                    data: parametros,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        if (msg.d == "Documento eliminado.") {
                            // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                            CargarViaticoTodo();
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

    $('#btnEliminadDocumentoTicketPDF').click(function () {
        swal({
            title: 'Estas Seguro que quieres eliminar ticket?',
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

                var parametros = "{'Id': '" + id + "', 'Opcion':'" + tipo + "'}";
                $.ajax({
                    dataType: "json",
                    url: "VerViaticos.aspx/EliminarDocumento",
                    async: true,
                    data: parametros,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        if (msg.d == "Documento eliminado.") {
                            // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                            CargarViaticoTodo();
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

    function CargarViaticoTodo() {
        var params = "{'IdViatico': '" + IdViaticos + "'}";
        var idProyecto = '';
        var Nom = '';
        $.ajax({
            async: true,
            url: "VerViaticos.aspx/Cargar",
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

                $('#tblViaticos tbody').html('');
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
                        Ticket = '<Button title="Agregar ticket" class="btn btn-danger" value="' + value.IdDet + '" onclick="AgregarTicket(this);"><i class="icon_document_alt"></i></Button>';

                    }
                    else {
                        Ticket = '<Button title="Ver ticket" class="btn btn-info" value="' + value.IdDet + '" onclick="VisualizarDocumentoTicket(this);"><i class="icon_document"></i></Button>';

                    }
                    idProyecto = value.IdProyecto;
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
                    nodoTRAgregar += '<td><div class="btn-group">' + Ticket +
                        '<Button title = "Eliminar" class="btn btn-danger" value = "' + value.IdDet + '" onclick = "EliminarViatico(this);" > <i class="icon_close_alt"></i></Button>'
                        + "</div></td>";
                    nodoTRAgregar += "</tr>";
                });
                CargarProyectos(idProyecto, Nom);
                $("#cmbProyectos").val(idProyecto);

                $('#tblViaticos').append(nodoTRAgregar);
                sumarColumnas();
            }
        });
    }

    $('#btnActualizaCantidadViatico').click(function () {
        swal({
            title: 'Estas Seguro que quieres actualizar la cantidad recibida?',
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Aceptar',
            cancelButtonText: 'Cancelar'
        }).then((result) => {

            if (result) {

                var monto = $('#txtMontoEntregadoNuevo').val();

                var parametros = "{'ActualizarCantidad':'" + monto + "'}";
                $.ajax({
                    dataType: "json",
                    url: "VerViaticos.aspx/ActualizarCantidad",
                    async: true,
                    data: parametros,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        if (msg.d == "Cantidad actualizada.") {
                            // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');

                            swal(msg.d);
                            location.reload();
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

    function cargarCantidadEntregada() {
        var parametros = "{'IdViatico': '" + IdViaticos + "'}";
        $.ajax({
            dataType: "json",
            url: "verViaticos.aspx/CargarCantidadEntregada",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                var json = JSON.parse(data.d);

                data = json;

                $('#Tabla').bootstrapTable('destroy');

                $('#Tabla').bootstrapTable({
                    data: data,
                    detailView: false,
                    striped: true,
                    pagination: false,
                    //onlyInfoPagination: true,
                    pageSize: 15,
                    idField: 'IdViaticosDetCantEntregada',
                    uniqueId: 'IdViaticosDetCantEntregada',
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

    $('#btnAgregar').click(function () {

        if ($('#txtCantidadEntregada').val() == '') {
            swal("Proporcionar datos obligatorios (Cantidad Entregada)...");
            return;
        }

        var parametros = "{'idViaticos': '" + IdViaticos +
            "', 'Cantidad': '" + $('#txtCantidadEntregada').val() + "'}";

        $.ajax({
            dataType: "json",
            url: "VerViaticos.aspx/GuardarCantidadEntregada",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Guardado con Exito!!") {
                    //$("#MensajeViaticos").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    
                    swal({
                        text: msg.d,
                        icon: 'success',
                        showCancelButton: false,
                        confirmButtonText: 'OK'
                    }).then((result) => {
                        //debugger;
                        if (result) {
                            $('#txtCantidadEntregada').val('');
                            CargarViaticoTodo();
                            cargarCantidadEntregada();
                        }
                    });
                    //swal(msg.d);
                }
                else {
                    // $("#MensajeViaticos").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });

        //var nodoTRAgregar = "";
        //item++;
        //nodoTRAgregar += "<tr>";
        //nodoTRAgregar += "  <td>" + item + "</td>";
        //nodoTRAgregar += "  <td>" + $('#txtDescripcionCotiza').val() + "</td>";
        //nodoTRAgregar += "  <td>" + $('#txtCantidadCotiza').val() + "</td>";
        //nodoTRAgregar += "  <td>" + $('#txtUnidadCotiza').val() + "</td>";
        //nodoTRAgregar += "  <td>" + $('#txtPrecioCotiza').val() + "</td>";
        //nodoTRAgregar += "  <td>" + $('#txtCantidadCotiza').val() * $('#txtPrecioCotiza').val() + "</td>";
        //nodoTRAgregar += "  <td><span class='btn btn-danger icon_close eliminar'></span></td>";
        //nodoTRAgregar += "</tr>";
        //$("#tblItemsCotizacion").append(nodoTRAgregar);

        //sumarColumnas();

        //$('#txtDescripcionCotiza').val('');
        //$('#txtCantidadCotiza').val('');
        //$('#txtUnidadCotiza').val('');
        //$('#txtPrecioCotiza').val('');

    });

    $(".decimal-2-places").numeric({ decimalPlaces: 2 });

    window.accionEvents = {
        'click .eliminar': function (e, value, row, index) {

            var IdViaticosDetCantEntregada = row.IdViaticosDetCantEntregada;

            swal({
                title: "Esta seguro que desea eliminar el registro con cantidad: " + row.Cantidad + "?",
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

                var parametros = "{'idViaticosDetCantEntregada': '" + IdViaticosDetCantEntregada + "'}";

                $.ajax({
                    dataType: "json",
                    url: "VerViaticos.aspx/EliminarCantidadEntregada",
                    async: true,
                    data: parametros,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        if (msg.d == "Guardado con Exito!!") {
                            //$("#MensajeViaticos").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');

                            swal({
                                text: msg.d,
                                icon: 'success',
                                showCancelButton: false,
                                confirmButtonText: 'OK'
                            }).then((result) => {
                                //debugger;
                                if (result) {
                                    //$('#txtCantidadEntregada').val('');
                                    CargarViaticoTodo();
                                    cargarCantidadEntregada();
                                }
                            });
                            //swal(msg.d);
                        }
                        else {
                            // $("#MensajeViaticos").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                            swal(msg.d);
                        }
                    }
                });

            }, function (dismiss) {
                // dismiss can be 'cancel', 'overlay',
                // 'close', and 'timer'
                if (dismiss === 'cancel') {
                    swal(
                        'Cancelado',
                        'Cancelaste la eliminacion del registro!! :)',
                        'error'
                    );
                }
            });

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

function accionFormatter(value, row, index) {
    var botonFile = '';

    return [
        '<div class="btn-group">',
        '<Button title="Eliminar" class="btn btn-danger eliminar"> <i class="icon_trash_alt"></i></Button>',
        '</div>'
    ].join(' ');
}



function formatoMonedaFormatter(value) {
    return formato_numero(value, 2, ".", ",");
}

function dateFormat(value, row, index) {
    return moment(value).format('DD/MM/YYYY hh:mm:ss');
}