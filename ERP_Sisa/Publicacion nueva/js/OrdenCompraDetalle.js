$(document).ready(function () {
    var URLactual = window.location;
    var IdOrdenCompra = 0;
    var IdUsuario = '';
    var item = 0;
    var IdSucursal = '';
    var rolusuario = "";
    if (URLactual.href.indexOf("OrdenCompraDetalle.aspx") > -1) {
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });
        //console.log("usuarioID: " + $('#MainContent_idUsuarioLog').val())
        obtieneRolUsuario();
        IdUsuario = $('#MainContent_idUsuarioLog').val();
        IdOrdenCompra = document.getElementById('MainContent_idOC').value;
        CargarProveedores();
        CargarProyectos();
        CargarUsuariosAprobo();
        CargarUsuarios();
        CargarMonedas();

        if (IdUsuario.toUpperCase() == '48B22A65-EE08-4E87-AD82-34472302888A' || IdUsuario.toUpperCase() == '15DFF984-223B-4B00-BA26-FE809065E689' || IdUsuario.toUpperCase() == '7BCC0D27-D537-4D4D-82AE-C32EA87314FA') {
            $('#lblSucursal').show();
            $('#cmbSucursal').show();
            CargarSucursales();
        }
        else {
            $('#lblSucursal').hide();
            $('#cmbSucursal').hide();
        }
        

        if (IdOrdenCompra != '0') {
            CargarDatosEncabezado();
            CargarDatosDetalle();
            $('#btnGuardar').hide();
            $('#btnModificar').show();
        }
        else {
            $('#btnPDF').hide();
            $('#btnModificar').hide();
            $('#btnGuardar').show();
        }


        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);

    }

    function obtieneRolUsuario() {
        var params = '';

        $.ajax({
            async: true,
            url: "OrdenCompraDetalle.aspx/ObtieneRolUsuarioLogueado",
            dataType: "json",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus) {
                debugger;
                rolusuario = data.d;
            }
        });
    }

    function CargarMateriales(idProveedor) {
        var params = "{'IdProveedor': '" + idProveedor + "'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'OrdenCompraDetalle.aspx/CargarMateriales',
            data: params,
            success: function (data, textStatus) {

                var json = $.parseJSON(data.d);

                $('#cmbMateriales').html('');
                $('#cmbMateriales').html('<option value="-1">-- SELECCIONE MATERIALES --</option>');
                $.each(json, function (index, value) {
                    $("#cmbMateriales").append('<option value="' + value.IdMaterial + '" rel="' + value.Codigo + '"  name="' + value.Precio + '" data-subtext="' + value.UnidadMedida + '">' + value.Descripcion + '</option>');
                    //$('#txtPrecio').val(value.Precio);
                });
                $('#cmbMateriales').selectpicker('refresh');
                $('#cmbMateriales').selectpicker('render');
            }
        });
    }

    function CargarProveedores() {
        var params = "{'Opcion': '9'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'OrdenCompraDetalle.aspx/CargarCombos2',
            data: params,
            success: function (data, textStatus) {

                var json = $.parseJSON(data.d);

                $('#cmbProveedores').html('');
                $('#cmbProveedores').html('<option value="-1">-- SELECCION PROVEEDOR --</option>');
                $.each(json, function (index, value) {
                    $("#cmbProveedores").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
                });
                $('#cmbProveedores').selectpicker('refresh');
                $('#cmbProveedores').selectpicker('render');
            }
        });
    }

    function CargarDatosEncabezado() {
        var params = "{'IdOrdenCompra': '" + IdOrdenCompra + "','Opcion': '" + 1 + "'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'OrdenCompraDetalle.aspx/CargarDatosEncabezado',
            data: params,
            success: function (data, textStatus) {

                var datos = "";
                var idProv;
                var JsonCombos;
                var json = $.parseJSON(data.d);

                $.each(json, function (index, value) {
                    //;
                    idProv = value.IdProveedor;
                    $("#cmbProveedores").val(value.IdProveedor);
                    $('#cmbProveedores').selectpicker('refresh');
                    $('#txtReferenciaCot').val(value.ReferenciaCot);
                    $('#txtReferenciarReq').val(value.FolioReq);
                    $('#cmbProyectos').val(value.IdProyecto.toUpperCase());
                    $('#cmbProyectos').selectpicker('refresh');
                    //$('#cmbProyectos').removeAttr('disabled');

                    $('#cmbTipoOC').val(value.TipoOC);
                    //$('#cmbProyectos').val(value.IdProyecto);
                    $('#cmbUsuarios').val(value.IdUsuario);
                    $('#cmbUsuarios').selectpicker('refresh');
                    $('#lblNoOrdenCompra').text(value.Folio);
                    $('#cmbMoneda').val(value.IdMoneda);
                    $('#txtCondicionPago').val(value.CondicionPago);
                    $('#cmbUsuariosAprobo').val(value.IdUsuarioAprobo);
                    $('#cmbUsuariosAprobo').selectpicker('refresh');
                    $('#txtDescuento').val(value.Descuento);

                    $('#lblSubTotal').text(value.SubTotal);

                    if (value.Iva == "0.00") {
                        $('#txtIVA').val("0");
                    }
                    else {
                        $('#txtIVA').val("16");
                    }

                    $('#lblIVA').text(value.Iva);

                    $('#lblTotal').text(value.Total);

                    
                });
                $('#cmbProveedores').selectpicker('refresh');
                $('#cmbProveedores').trigger('change');



                //fnCargarMateriales(idProv);


            }
        });
    }

    function CargarProyectos() {
        var params = "{'Opcion': '10'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'OrdenCompraDetalle.aspx/CargarCombos',
            data: params,
            success: function (data, textStatus) {
                ;
                var json = $.parseJSON(data.d);

                $('#cmbProyectos').html('');
                $('#cmbProyectos').html('<option value="-1">-- SELECCIONE PROYECTO --</option>');
                $.each(json, function (index, value) {
                    $("#cmbProyectos").append('<option value="' + value.Id.toUpperCase() + '">' + value.Nombre.toUpperCase() + '</option>');
                });
                $('#cmbProyectos').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');

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

                if (IdOrdenCompra != '0') {
                    CargarDatosEncabezado();
                }

                //$('cmbProyectos').selectpicker();
                //$('#cmbProyectos').val(idProyecto);
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
            url: 'OrdenCompraDetalle.aspx/CargarCombos',
            data: params,
            success: function (data, textStatus) {

                var json = $.parseJSON(data.d);

                $('#cmbUsuarios').html('');
                $('#cmbUsuarios').html('<option value="-1">-- PEDIDO POR --</option>');
                $.each(json, function (index, value) {
                    $("#cmbUsuarios").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
                });
                $('#cmbUsuarios').selectpicker('refresh');
                $('#cmbUsuarios').selectpicker('render');
                if (IdOrdenCompra != '0') {
                    CargarDatosEncabezado();
                }
            }
        });
    }

    function CargarUsuariosAprobo() {
        var params = "{'Opcion': '11'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'OrdenCompraDetalle.aspx/CargarCombosGerencial',
            data: params,
            success: function (data, textStatus) {

                var json = $.parseJSON(data.d);
                //debugger;
                $('#cmbUsuariosAprobo').html('');
                $('#cmbUsuariosAprobo').html('<option value="-1">-- APROBADO POR --</option>');
                //$("#cmbUsuariosAprobo").append('<option value="9ACA5529-3587-4DC4-AA92-A6D50234740E">FRANCISCO MIGUEL ROMERO RIOS</option>');
                //$("#cmbUsuariosAprobo").append('<option value="392f6964-a915-4fa9-b822-2291e7251f02">ROBER GUILLERMO RODRIGUEZ DAVILA</option>');

                $.each(json, function (index, value) {
                    $("#cmbUsuariosAprobo").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
                });
                


                $('#cmbUsuariosAprobo').selectpicker('refresh');
                $('#cmbUsuariosAprobo').selectpicker('render');
                //if (IdOrdenCompra != '0') {
                //    fnCargarDatosEncabezado();
                //}
            }
        });
    }

    function CargarMonedas() {

        var params = "{'Opcion': '7'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'OrdenCompraDetalle.aspx/CargarCombos',
            data: params,
            success: function (data, textStatus) {

                var json = $.parseJSON(data.d);

                $('#cmbMoneda').html('');
                $('#cmbMoneda').html("<option value=-1>-- SELECCIONE MONEDA --</option>");
                $.each(json, function (index, value) {
                    $("#cmbMoneda").append("<option value=" + value.Id + ">" + value.Nombre.toUpperCase() + "</option>");
                });

                if (IdOrdenCompra != '0') {
                    CargarDatosEncabezado();
                }
            }
        });

    }

    function CargarSucursales() {
        var params = "";

        if (IdUsuario.toUpperCase() == '48B22A65-EE08-4E87-AD82-34472302888A') {
            params = "{'Opcion': '16'}";
        }
        else if (IdUsuario.toUpperCase() == '15DFF984-223B-4B00-BA26-FE809065E689' || IdUsuario.toUpperCase() == '7BCC0D27-D537-4D4D-82AE-C32EA87314FA') {
            params = "{'Opcion': '20'}";
        }

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'OrdenCompraDetalle.aspx/CargarCombos',
            data: params,
            success: function (data, textStatus) {

                var json = $.parseJSON(data.d);

                $('#cmbSucursal').html('');
                $('#cmbSucursal').html('<option value="-1">-- SUCURSAL --</option>');
                $.each(json, function (index, value) {
                    $("#cmbSucursal").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
                });
                $('#cmbSucursal').selectpicker('refresh');
                $('#cmbSucursal').selectpicker('render');
                //if (IdOrdenCompra != '0') {
                //    CargarDatosEncabezado();
                //}
            }
        });
    }

    function sumarColumnas() {

        var mImporte = 0, mIVA = 0, mTotal = 0, mDescuento = 0;

        $('#tblItems tbody tr').each(function () {

            $(this).children("td").each(function (index2) {
                switch (index2) {
                    case 7:
                        mImporte += parseFloat($(this).text().replace(/\,/g, ""));
                        break;
                }
            });

        });
        //;
        $('#lblSubTotal').text(formato_numero(mImporte, 2, ".", ","));

        mIVA = mImporte * ($('#txtIVA').val() / 100);
        //;
        $('#lblIVA').text(formato_numero(mIVA, 2, ".", ","));

        mDescuento = $('#txtDescuento').val();

        mTotal = (mImporte - mDescuento) + mIVA;

        $('#lblTotal').text(formato_numero(mTotal, 2, ".", ","));
    }


    function CargarDatosDetalle() {
        var params = "{'IdOrdenCompra': '" + IdOrdenCompra + "','Opcion': '" + 2 + "'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'OrdenCompraDetalle.aspx/CargarDatosDetalle',
            data: params,
            success: function (data, textStatus) {

                $('#tblItems tbody').remove();

                var datos = "";
                var idProv;
                var nodoTRAgregar = "";
                var json = $.parseJSON(data.d);

                $.each(json, function (index, value) {
                    var _pintarRenglon = "";

                    if (value.CantidadRecibida == value.Cantidad) {
                        _pintarRenglon = 'verde';
                    }
                    else if (value.CantidadRecibida < value.Cantidad && value.CantidadRecibida != 0) {
                        _pintarRenglon = 'yellow';
                    }
                    else {
                        _pintarRenglon = "";
                    }
                    var fechar = '';
                    if (value.FechaRecibida === null || value.FechaRecibida == 'null') {
                    } else {
                        fechar = value.FechaRecibida.substring(0, 10);
                    }
                    nodoTRAgregar += "<tr class='" + _pintarRenglon + "'>";
                    nodoTRAgregar += "  <td>" + value.Item + "</td>";
                    item = parseInt(value.Item);
                    nodoTRAgregar += "  <td>" + value.Codigo + "</td>";
                    nodoTRAgregar += "  <td>" + value.Descripcion + "</td>";
                    nodoTRAgregar += "  <td>" + value.Comentarios + "</td>";
                    nodoTRAgregar += "  <td>" + value.Cantidad + "</td>";
                    nodoTRAgregar += "  <td>" + value.Unidad + "</td>";
                    nodoTRAgregar += "  <td>" + formato_numero(value.Precio, 2, '.', ',') + "</td>";
                    nodoTRAgregar += "  <td>" + formato_numero(value.Importe, 2, '.', ',') + "</td>";
                    nodoTRAgregar += "  <td>" + value.TiempoEntrega + "</td>";
                    nodoTRAgregar += "  <td>" + value.CantidadRecibida + "</td>";
                    nodoTRAgregar += "  <td>" + fechar + "</td>";
                    //nodoTRAgregar += "  <td><span class='btn btn-danger btn-xs fa fa-remove eliminar'></span></td>";
                    if (_pintarRenglon == "") {
                        nodoTRAgregar += "  <td><span class='btn btn-success icon_check recibir'></span>";
                        if (rolusuario != "Recepcion almacen") {                            
                            nodoTRAgregar += "&nbsp;&nbsp;<span class='btn btn-danger icon_close eliminaritemoc'></span></td>";
                        }
                    }
                    else {
                        nodoTRAgregar += "  <td></td>";
                    }
                    

                    nodoTRAgregar += "</tr>";

                });

                $("#tblItems").append(nodoTRAgregar);
                //sumarColumnas();
                //fnCargarMateriales(idProv);


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

    $("#cmbProveedores").change(function () {

        var idProveedor = $(this).val();

        if (idProveedor != null) {
            var params = "{'IdProveedor': '" + idProveedor + "'}";
            //;
            $.ajax({
                async: true,
                url: "OrdenCompraDetalle.aspx/BuscarDatosProveedor",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {

                    var json = $.parseJSON(data.d);
                    $("#lblAtencion").text('');
                    $('#lblDireccion').text('');
                    $("#lblCorreo").text('');
                    $('#lblTelefono').text('');
                    $.each(json, function (index, value) {
                        $("#lblAtencion").text(value.Contacto);
                        $('#lblDireccion').text(value.Domicilio);
                        $("#lblCorreo").text(value.Email);
                        $('#lblTelefono').text(value.Telefono1);

                        CargarMateriales(idProveedor);
                    });


                }
            });
        }



    });

    var unidadMedida = "";
    $("#cmbMateriales").change(function () {

        //debugger;
        //;
        var precio = $('#cmbMateriales option:selected').attr('name');
        var valor = $('#cmbMateriales').val();
        unidadMedida = $('#cmbMateriales option:selected').attr('data-subtext');

        $('#txtPrecio').val(precio);
        $('#cmbMateriales').val(valor);
        $('#cmbMateriales').selectpicker('refresh');


    });

    $('#btnPDF').click(function () {
        window.open("ReporteOrdenCompra.aspx?IdOrdenCompra=" + IdOrdenCompra + "&NombreOrden=" + $('#lblNoOrdenCompra').text(), '_blank');
    });

    $('#btnAgregar').click(function () {

        if ($('#cmbMateriales option:selected').val() == '-1' || $('#txtCantidad').val() == "" || $('#txtPrecio').val() == "") {
            swal("Favor de ingresar los datos de materiales correctamente...");
            return;
        }

        var nodoTRAgregar = "";

        item++;
        var a = $('#cmbMateriales option:selected').attr('rel');
        var b = $('#cmbMateriales option:selected').text().replace(a + " - ", "");
        var c = unidadMedida;//$('#cmbMateriales option:selected').attr('data-subtext');
        //debugger;
        nodoTRAgregar += "<tr>";
        nodoTRAgregar += "  <td>" + item + "</td>";

        nodoTRAgregar += "  <td>" + a + "</td>";
        nodoTRAgregar += "  <td>" + b + "</td>";
        nodoTRAgregar += "  <td>" + $('#txtComentarios').val() + "</td>";
        nodoTRAgregar += "  <td>" + $('#txtCantidad').val() + "</td>";
        nodoTRAgregar += "  <td>" + c + "</td>";
        nodoTRAgregar += "  <td>" + formato_numero($('#txtPrecio').val(), 2, '.', ',') + "</td>";
        nodoTRAgregar += "  <td>" + formato_numero(($('#txtCantidad').val() * $('#txtPrecio').val()), 2, '.', ',') + "</td>";
        nodoTRAgregar += "  <td>" + $('#txtTiempoEntrega').val() + "</td>";
        nodoTRAgregar += "  <td></td>";
        nodoTRAgregar += "  <td></td>";
        if (rolusuario != "Recepcion almacen") {
            nodoTRAgregar += "  <td><span class='btn btn-danger icon_close eliminaritemoc'></span></td>";
        }
        

        nodoTRAgregar += "</tr>";
        $("#tblItems").append(nodoTRAgregar);

        sumarColumnas();

        $('#cmbMateriales').val('-1');
        $('#txtCantidad').val('');
        $('#txtPrecio').val('');
        $('#txtComentarios').val('');
        $('#txtTiempoEntrega').val('');
    });

    $('#btnGuardar').click(function () {

        swal({
            title: "Esta seguro que desea crear la ORDEN DE COMPRA?",
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
            if ($('#cmbProveedores').val() == '-1') {
                swal("Selecciona proveedor...");
                return;
            }
            if ($('#cmbProyectos').val() == '-1') {
                swal("Selecciona proyecto...");
                return;
            }
            if ($('#cmbUsuarios').val() == '-1') {
                swal("Selecciona quien solicito...");
                return;
            }

            if ($('#cmbUsuariosAprobo').val() == '-1') {
                swal("Selecciona quien aprobo...");
                return;
            }

            if ($('#cmbTipoOC').val() == '-1') {
                swal("Selecciona tipo de OC...");
                return;
            }
            if ($('#cmbMoneda').val() == '-1') {
                swal("Selecciona tipo de moneda...");
                return;
            }

            //if (IdUsuario.toUpperCase() == '0914A20B-80C3-4FFD-96EE-FD3F034B80E3') {
            if (IdUsuario.toUpperCase() == '48B22A65-EE08-4E87-AD82-34472302888A') {
                if ($('#cmbSucursal').val() == '-1') {
                    swal("Selecciona Sucursal...");
                    return;
                }

                IdSucursal = $('#cmbSucursal').val();
            }
            else {
                IdSucursal = '';
            }
            //if ($('#cmbMoneda').val() == '-1') {
            //    swal("Selecciona tipo de moneda...");
            //    return;
            //}

            var itemsTot = 0, itemsIns = 0;
            $("#tblItems tbody tr").each(function (index) {
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

            var valorProyecto = "";
            var tipoOC = "";

            valorProyecto = $('#cmbProyectos').val();
            tipoOC = $('#cmbTipoOC').val();
            var ReferenciarReq = $('#txtReferenciarReq').val();
            var params = "{'Folio': '" + $('#lblNoOrdenCompra').text() +
                "','IdProveedor': '" + $('#cmbProveedores').val() +
                "','ReferenciaCot': '" + $('#txtReferenciaCot').val() +
                "','IdProyecto': '" + valorProyecto +
                "','PedidoPor': '" + $('#cmbUsuarios').val() +
                "','SubTotal': '" + $('#lblSubTotal').text() +
                "','Iva': '" + $('#lblIVA').text() +
                "','Estatus': '" + 0 +
                "','IdMoneda': '" + $('#cmbMoneda').val() +
                "','CondicionPago': '" + $('#txtCondicionPago').val() +
                "','Comentarios': '" + "" +
                "','Descuento': '" + $('#txtDescuento').val() +
                "','IdUsuarioAprobo': '" + $('#cmbUsuariosAprobo').val() +
                "','TipoOC': '" + tipoOC +
                "','IdUsuario': '" + sessionStorage.getItem('IdUsuario') +
                "','ReferenciarReq': '" + ReferenciarReq +
                "','idUsuarioLog': '" + $('#MainContent_idUsuarioLog').val() +
                "','IdSucursal': '" + IdSucursal +
                "'}";

            $.ajax({
                dataType: "json",
                async: true,
                url: "OrdenCompraDetalle.aspx/CrearOrdenCompra",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {


                    var idOrdenCompra = 0;
                    var noOrdenCompra = '';
                    var JsonCombos;
                    var jsonArray = $.parseJSON(data.d);


                    $.each(jsonArray, function (index, value) {
                        idOrdenCompra = value.IdOrdenCompra;
                        noOrdenCompra = value.NoOrdenCompra;
                    });

                    if (idOrdenCompra != 0) {

                        /****** inicia codigo para guardar todos los items con json */
                        var ItemsToSaveJson = "[";

                        var header = [];
                        var rows = [];

                        $("#tblItems tr th").each(function (i, th) {
                            header.push($(th).html());
                        });

                        $("#tblItems tr:has(td)").each(function (i, tr) {
                            var row = {};
                            $(tr).find('td').each(function (j, td) {
                                row[header[j]] = $(td).html().replace(/"/g, '\\"').replace(",", "");
                            });
                            rows.push(row);
                        });

                        ItemsToSaveJson = JSON.stringify(rows);

                        var param = "{'IdOrdenCompra': '" + idOrdenCompra +
                            "','items': '" + ItemsToSaveJson +
                            "'}";

                        $.ajax({
                            async: true,
                            url: "OrdenCompraDetalle.aspx/InsertaItemsOrdenCompraDet",
                            dataType: "json",
                            data: param,
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data, textStatus) {
                                itemsIns++;

                                //if (itemsIns == itemsTot) {
                                //    if (swal.isVisible()) {
                                swal.closeModal();
                                //}

                                if (IdOrdenCompra == '0') {
                                            swal({
                                                title: "Desea Generar el PDF?",
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
                                                window.open("ReporteOrdenCompra.aspx?IdOrdenCompra=" + idOrdenCompra + "&NombreOrden=" + noOrdenCompra, '_blank');

                                                swal({
                                                    title: 'Guardado Correctamente!',
                                                    timer: 10000
                                                });

                                                location.href = 'OrdenCompra.aspx';

                                            }, function (dismiss) {
                                                // dismiss can be 'cancel', 'overlay',
                                                // 'close', and 'timer'
                                                if (dismiss === 'cancel') {
                                                    swal(
                                                        'Cancelado',
                                                        '',
                                                        'error'
                                                    );
                                                }
                                            });
                                        }
                                        else {
                                            swal({
                                                title: 'Guardado Correctamente!',
                                                timer: 3000
                                            });

                                            location.href = 'OrdenCompra.aspx';
                                        }
                                //}
                            }
                        });

                        /******finaliza el codigo para guardar por json*/

                        //$("#tblItems tbody tr").each(function (index) {
                        //    var item, codigo, descripcion, comentarios, cantidad, unidad, precio, importe, tiempoEntrega;

                        //    $(this).children("td").each(function (index2) {
                        //        switch (index2) {
                        //            case 0:
                        //                item = $(this).text();
                        //                break;
                        //            case 1:
                        //                codigo = $(this).text();
                        //                break;
                        //            case 2:
                        //                descripcion = $(this).text();
                        //                break;
                        //            case 3:
                        //                comentarios = $(this).text();
                        //                break;
                        //            case 4:
                        //                cantidad = $(this).text();
                        //                break;
                        //            case 5:
                        //                unidad = $(this).text();
                        //                break;
                        //            case 6:
                        //                precio = $(this).text();
                        //                break;
                        //            case 7:
                        //                importe = $(this).text();
                        //                break;
                        //            case 8:
                        //                tiempoEntrega = $(this).text();
                        //                break;
                        //        }
                        //    });

                        //    var param = "{'IdOrdenCompra': '" + idOrdenCompra +
                        //        "','Item': '" + item +
                        //        "','Codigo': '" + codigo +
                        //        "','Descripcion': '" + descripcion +
                        //        "','Comentarios': '" + comentarios +
                        //        "','Cantidad': '" + cantidad +
                        //        "','Unidad': '" + unidad +
                        //        "','Precio': '" + precio +
                        //        "','Importe': '" + importe +
                        //        "','TiempoEntrega': '" + tiempoEntrega +
                        //        "','CantidadRecibida': '" + 0 +
                        //        "','Opcion': '" + 1 + "'}";

                        //    $.ajax({
                        //        async: true,
                        //        url: "OrdenCompraDetalle.aspx/InsertarOrdenCompraDetalle",
                        //        dataType: "json",
                        //        data: param,
                        //        type: "POST",
                        //        contentType: "application/json; charset=utf-8",
                        //        success: function (data, textStatus) {
                        //            itemsIns++;

                        //            if (itemsIns == itemsTot) {
                        //                if (swal.isVisible()) {
                        //                    swal.closeModal();
                        //                }

                        //                if (IdOrdenCompra == '0') {
                        //                    swal({
                        //                        title: "Desea Generar el PDF?",
                        //                        type: "warning",
                        //                        allowOutsideClick: false,
                        //                        allowEscapeKey: false,
                        //                        allowEnterKey: false,
                        //                        showCancelButton: true,
                        //                        confirmButtonColor: '#3085d6',
                        //                        cancelButtonColor: '#d33',
                        //                        confirmButtonText: 'Si',
                        //                        cancelButtonText: 'No'
                        //                    }).then(function () {
                        //                        window.open("ReporteOrdenCompra.aspx?IdOrdenCompra=" + idOrdenCompra + "&NombreOrden=" + noOrdenCompra, '_blank');

                        //                        swal({
                        //                            title: 'Guardado Correctamente!',
                        //                            timer: 10000
                        //                        });

                        //                        location.href = 'OrdenCompra.aspx';

                        //                    }, function (dismiss) {
                        //                        // dismiss can be 'cancel', 'overlay',
                        //                        // 'close', and 'timer'
                        //                        if (dismiss === 'cancel') {
                        //                            swal(
                        //                                'Cancelado',
                        //                                '',
                        //                                'error'
                        //                            );
                        //                        }
                        //                    });
                        //                }
                        //                else {
                        //                    swal({
                        //                        title: 'Guardado Correctamente!',
                        //                        timer: 3000
                        //                    });

                        //                    location.href = 'OrdenCompra.aspx';
                        //                }

                        //            }
                        //            //window.open('./frmReporteCotizacion.aspx?IdCotizacion=' + IdCotizacion, '_blank');
                        //            //location.href = './frmAgregarCotizacionNew.aspx?IdCotizacion=' + IdCotizacion;
                        //        }
                        //    });
                        //});
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
                    'Cancelled',
                    'Your imaginary file is safe :)',
                    'error'
                );
            }
        });
    });

    $('#btnModificar').click(function () {
        //debugger;


        swal({
            title: "Esta seguro que desea Modificar la ORDEN DE COMPRA?",
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

            if (IdUsuario.toUpperCase() == '48B22A65-EE08-4E87-AD82-34472302888A') {
                if ($('#cmbSucursal').val() == '-1') {
                    swal("Selecciona Sucursal...");
                    return;
                }

                IdSucursal = $('#cmbSucursal').val();
            }
            else {
                IdSucursal = '';
            }

            swal({
                title: 'Guardando Datos!',
                text: 'Espere un Momento...',
                onOpen: function () {
                    swal.showLoading()
                }
            });

            var valorProyecto = "";
            var tipoOC = "";
            var ReferenciarReq = $('#txtReferenciarReq').val();
            valorProyecto = $('#cmbProyectos').val();
            tipoOC = $('#cmbTipoOC').val();
            var params = "{'Folio': '" + $('#lblNoOrdenCompra').text() +
                "','IdProveedor': '" + $('#cmbProveedores').val() +
                "','ReferenciaCot': '" + $('#txtReferenciaCot').val() +
                "','IdProyecto': '" + valorProyecto +
                "','PedidoPor': '" + $('#cmbUsuarios').val() +
                "','SubTotal': '" + $('#lblSubTotal').text() +
                "','Iva': '" + $('#lblIVA').text() +
                "','Estatus': '" + 0 +
                "','IdMoneda': '" + $('#cmbMoneda').val() +
                "','CondicionPago': '" + $('#txtCondicionPago').val() +
                "','Comentarios': '" + "" +
                "','Descuento': '" + $('#txtDescuento').val() +
                "','IdUsuarioAprobo': '" + $('#cmbUsuariosAprobo').val() +
                "','TipoOC': '" + tipoOC +
                "','IdUsuario': '" + sessionStorage.getItem('IdUsuario') +
                "','ReferenciarReq': '" + ReferenciarReq +
                "','idUsuarioLog': '" + $('#MainContent_idUsuarioLog').val() +
                "','IdSucursal': '" + IdSucursal +
                "'}";


            $.ajax({
                dataType: "json",
                async: true,
                url: "OrdenCompraDetalle.aspx/CrearOrdenCompra",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {
                    var idOrdenCompra = 0;
                    var noOrdenCompra = '';
                    var JsonCombos;
                    var jsonArray = $.parseJSON(data.d);


                    $.each(jsonArray, function (index, value) {
                        idOrdenCompra = value.IdOrdenCompra;
                        noOrdenCompra = value.NoOrdenCompra;
                    });

                    if (idOrdenCompra != 0) {
                        var itemsTot = 0, itemsIns = 0;
                        var ItemsToSaveJson = "[";
                        //$("#tblItems tbody tr").each(function (index) {
                        //    itemsTot++;
                        //});


                        /****** inicia codigo para guardar todos los items con json */
                        var ItemsToSaveJson = "[";

                        var header = [];
                        var rows = [];

                        $("#tblItems tr th").each(function (i, th) {
                            header.push($(th).html());
                        });

                        $("#tblItems tr:has(td)").each(function (i, tr) {
                            var row = {};
                            $(tr).find('td').each(function (j, td) {
                                row[header[j]] = $(td).html().replace(/"/g, '\\"').replace(",", "");
                            });
                            rows.push(row);
                        });

                        ItemsToSaveJson = JSON.stringify(rows);

                        var param = "{'IdOrdenCompra': '" + IdOrdenCompra +
                            "','items': '" + ItemsToSaveJson +
                            "'}";

                        $.ajax({
                            async: true,
                            url: "OrdenCompraDetalle.aspx/InsertaItemsOrdenCompraDet",
                            dataType: "json",
                            data: param,
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data, textStatus) {
                                itemsIns++;

                                //if (itemsIns == itemsTot) {
                                //    if (swal.isVisible()) {
                                        swal.closeModal();
                                    //}

                                    swal({
                                        title: 'Guardado Correctamente!',
                                        timer: 10000
                                    });
                                    location.href = 'OrdenCompraDetalle.aspx?IdOrdenCompra=' + IdOrdenCompra;
                                //}
                            }
                        });

                        /******finaliza el codigo para guardar por json*/

                        //$("#tblItems tbody tr").each(function (index) {
                        //    var item, codigo, descripcion, comentarios, cantidad, unidad, precio, importe, tiempoEntrega;

                        //    $(this).children("td").each(function (index2) {
                        //        switch (index2) {
                        //            case 0:
                        //                item = $(this).text();
                        //                break;
                        //            case 1:
                        //                codigo = $(this).text();
                        //                break;
                        //            case 2:
                        //                descripcion = $(this).text();
                        //                break;
                        //            case 3:
                        //                comentarios = $(this).text();
                        //                break;
                        //            case 4:
                        //                cantidad = $(this).text();
                        //                break;
                        //            case 5:
                        //                unidad = $(this).text();
                        //                break; 
                        //            case 6:
                        //                precio = $(this).text();
                        //                break;
                        //            case 7:
                        //                importe = $(this).text();
                        //                break;
                        //            case 8:
                        //                tiempoEntrega = $(this).text();
                        //                break;
                        //        }
                        //    });

                        //    var param = "{'IdOrdenCompra': '" + idOrdenCompra +
                        //        "','Item': '" + item +
                        //        "','Codigo': '" + codigo +
                        //        "','Descripcion': '" + descripcion +
                        //        "','Comentarios': '" + comentarios +
                        //        "','Cantidad': '" + cantidad +
                        //        "','Unidad': '" + unidad +
                        //        "','Precio': '" + precio +
                        //        "','Importe': '" + importe +
                        //        "','TiempoEntrega': '" + tiempoEntrega +
                        //        "','CantidadRecibida': '" + 0 +
                        //        "','Opcion': '" + index + "'},";

                        //    ItemsToSaveJson += param;

                        //    //$.ajax({
                        //    //    async: true,
                        //    //    url: "OrdenCompraDetalle.aspx/InsertarOrdenCompraDetalle",
                        //    //    dataType: "json",
                        //    //    data: param,
                        //    //    type: "POST",
                        //    //    contentType: "application/json; charset=utf-8",
                        //    //    success: function (data, textStatus) {
                        //    //        itemsIns++;

                        //    //        if (itemsIns == itemsTot) {
                        //    //            if (swal.isVisible()) {
                        //    //                swal.closeModal();
                        //    //            }

                        //    //            swal({
                        //    //                title: 'Guardado Correctamente!',
                        //    //                timer: 10000
                        //    //            });
                        //    //            location.href = 'OrdenCompraDetalle.aspx?IdOrdenCompra=' + idOrdenCompra;
                        //    //        }
                        //    //    }
                        //    //});
                        //});
                        
                        //ItemsToSaveJson += "]";
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
                    'Cancelaste modificación.',
                    'error'
                );
            }
        });
    });

    $('#btnRecibirGlobalOC').click(function () {

        swal({
            title: "Todos los productos de la ORDEN DE COMPRA, fueron obtenidos?",
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
                title: 'Guardando Datos!',
                text: 'Espere un Momento...',
                onOpen: function () {
                    swal.showLoading()
                }
            });

            if (IdOrdenCompra != 0) {
                var itemsTot = 0, itemsIns = 0;

                $("#tblItems tbody tr").each(function (index) {
                    itemsTot++;
                });

                $("#tblItems tbody tr").each(function (index) {
                    var item, codigo, descripcion, comentarios, cantidad, unidad, precio, importe, tiempoEntrega;

                    $(this).children("td").each(function (index2) {
                        switch (index2) {
                            case 0:
                                item = $(this).text();
                                break;
                            case 1:
                                codigo = $(this).text();
                                break;
                            case 2:
                                descripcion = $(this).text();
                                break;
                            case 3:
                                comentarios = $(this).text();
                                break;
                            case 4:
                                cantidad = $(this).text();
                                break;
                            case 5:
                                unidad = $(this).text();
                                break;
                            case 6:
                                precio = $(this).text();
                                break;
                            case 7:
                                importe = $(this).text();
                                break;
                            case 8:
                                tiempoEntrega = $(this).text();
                                break;
                        }
                    });

                    var params = "{'IdOrdenCompra': '" + IdOrdenCompra + "','Item': '" + item + "', 'CantidadRecibida': '" + cantidad + "'}";

                    $.ajax({
                        async: true,
                        url: 'OrdenCompraDetalle.aspx/ActualizaCantRecibida',
                        dataType: "json",
                        data: params,
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data, textStatus) {
                            itemsIns++;
                            ;
                            if (itemsIns == itemsTot) {
                                if (swal.isVisible()) {
                                    swal.closeModal();
                                }

                                swal({
                                    title: 'Guardado Correctamente!',
                                    timer: 5000
                                }).then((result) => {

                                    location.href = 'OrdenCompraDetalle.aspx?IdOrdenCompra=' + IdOrdenCompra;
                                });
                                
                            }
                        }
                    });
                });
            }
            else {
                swal('Existe un problema con los datos de la OC, o aun no ha sido almacenada en la base de datos, guarda información y recarga la página.');
            }

        }, function (dismiss) {
            // dismiss can be 'cancel', 'overlay',
            // 'close', and 'timer'
            if (dismiss === 'cancel') {
                swal(
                    'Cancelado',
                    'Cancelaste modificación.',
                    'error'
                );
            }
        });
    });

    $(document).on('click', '.recibir', function (event) {
        //;
        var _boton = $(this);
        var _item = $(this).parent().parent().find('td')[0].innerHTML;
        var _producto = $(this).parent().parent().find('td')[2].innerHTML;
        var _cantidad = $(this).parent().parent().find('td')[4].innerHTML;

        swal({
            title: "Esta seguro que desea recibir el item " + _producto + "?",
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
                title: "Favor de Capturar Cantidad",
                type: "question",
                input: "text",
                showCancelButton: true,
                closeOnConfirm: false,
                inputPlaceholder: "Cantidad a Recibir",
                allowOutsideClick: false,
                allowEnterKey: false,
                allowEscapeKey: false,
                showCloseButton: true,
            }).then(function (result) {

                var params = "{'IdOrdenCompra': '" + IdOrdenCompra + "','Item': '" + _item + "', 'CantidadRecibida': '" + result + "'}";

                $.ajax({
                    dataType: 'json',
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    type: 'POST',
                    url: 'OrdenCompraDetalle.aspx/ActualizaCantRecibida',
                    data: params,
                    success: function (data, textStatus) {
                        if (data.d == 'Error') {
                            swal({
                                title: "Hay un error en los nÚmeros, la cantidad recibida, es mayor a la cantidad registrada.",
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
                            CargarDatosDetalle();
                        }

                        //if (parseInt(result) == parseInt(_cantidad)) {
                        //    $(_boton).parent().parent().addClass('verde');
                        //}
                        //else {
                        //    $(_boton).parent().parent().addClass('yellow');
                        //}


                    }
                });

            });


        }, function (dismiss) {
            // dismiss can be 'cancel', 'overlay',
            // 'close', and 'timer'
            if (dismiss === 'cancel') {
                swal(
                    'Cancelled',
                    'Error al cargar.',
                    'error'
                );
            }
        });


        //var params = "{'IdOrdenCompra': '" + IdOrdenCompra + "','Item': '" + _item + "'}";

        //$.ajax({
        //    dataType: 'json',
        //    async: true,
        //    contentType: "application/json; charset=utf-8",
        //    type: 'POST',
        //    url: './frmOrdenCompraDetalle.aspx/ActualizaCantRecibida',
        //    data: params,
        //    success: function (data, textStatus) {
        //        $(_boton).parent().parent().addClass('verde');

        //    }
        //});
    });

    $(document).on('click', '.eliminaritemoc', function (event) {
        //;
        if (IdOrdenCompra != '0') {
            var _boton = $(this);
            var _item = $(this).parent().parent().find('td')[0].innerHTML;
            var _code = $(this).parent().parent().find('td')[1].innerHTML;
            var _producto = $(this).parent().parent().find('td')[2].innerHTML;
            var _cantidad = $(this).parent().parent().find('td')[4].innerHTML;
            var _importe = $(this).parent().parent().find('td')[7].innerHTML;

            swal({
                title: "¿Esta seguro que desea eliminar el item " + _producto + "?, se actualizará la OC",
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
                sumarColumnas();

                var params = "{'IdOrdenCompra': '" + IdOrdenCompra + "','Item': '" + _item + "','SubTotal': '" + $('#lblSubTotal').text() + "','Iva': '" + $('#txtIVA').val() + "', 'Codigo':'" + _code + "', 'Importe': '" + _importe + "'}"

                $.ajax({
                    dataType: 'json',
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    type: 'POST',
                    url: 'OrdenCompraDetalle.aspx/ItemEliminado',
                    data: params,
                    success: function (data, textStatus) {
                        if (data.d == 'Actualizado') {
                            //swal('Orden de compra actualizada.');

                            swal({
                                title: 'Orden de compra actualizada.',
                                timer: 10000
                            });

                            location.href = 'OrdenCompraDetalle.aspx?IdOrdenCompra=' + IdOrdenCompra;
                        }
                    }
                });


            }, function (dismiss) {
                // dismiss can be 'cancel', 'overlay',
                // 'close', and 'timer'
                if (dismiss === 'cancel') {
                    swal(
                        'Proceso cancelado'
                    );
                    CargarDatosDetalle();
                }
            });
        }
        else {
            //var _boton = $(this);
            //var _item = $(this).parent().parent().find('tr')[0].innerHTML;
            //$(_item).remove();
            console.log("AQUI");
            $(this).closest("tr").remove();
            sumarColumnas();
        }
       
    });

    $("#txtIVA").keyup(function () {
        sumarColumnas();

    });

    

});

function mayus(e) {
    e.value = e.value.toUpperCase();
}