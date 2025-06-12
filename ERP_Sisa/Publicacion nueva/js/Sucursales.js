$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("Sucursales.aspx") > -1) {
        
       
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarSucursales();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }

    
    $('#btnGuardarSucursal').click(function () {
        var Ciudad = $('#txtCiudadSucursal').val();
        var Direccion = $('#txtDireccionSucursal').val();
        var Telefono = $('#txtTelefonoSucursal').val();
        var Gerente = $('#txtGerenteSucursal').val();
        var Colonia = $('#txtColoniaSucursal').val();
        var CP = $('#txtCPSucursal').val();

        if (Telefono == "" && Direccion == "" && Ciudad == "") {
            //$("#AddMsgSucursal").append('<div class="alert alert-danger fade in"><p>Completa los campos obligatorios.</p></div >');
            swal('Completa los campos obligatorios.');

        }
        else {
            var parametros = "{'pCiudad': '" + Ciudad +
                "', 'pTelefono': '" + Telefono +
                "', 'pDireccion': '" + Direccion +
                "', 'pGerente': '" + Gerente +
                "', 'pColonia': '" + Colonia +
                "', 'pCP': '" + CPSucursal + "'}";

            $.ajax({
                dataType: "json",
                url: "Sucursales.aspx/GuardarSucursal",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Sucursal creada.") {
                       // $("#AddMsgSucursal").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                        CargarSucursales();
                        swal(msg.d);
                    }
                    else {
                        //$("#AddMsgSucursal").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                        swal(msg.d);
                    }
                }
            });
        }

    });

    $('#btnEliminarSucursal').click(function () {
        var idSuc = document.getElementById('idSucursalEliminar').textContent;

        var parametros = "{'pidSucursal': '" + idSuc + "'}";
        $.ajax({
            dataType: "json",
            url: "Sucursales.aspx/EliminarSucursal",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Sucursal eliminada.") {
                   // $("#txtModalEliminarMensajeSucursal").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarSucursales();
                    swal(msg.d);
                }
                else {
                   // $("#txtModalEliminarMensajeSucursal").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });


    //$('#btnEditarSucursal').click(function () {
    //    var idSuc = document.getElementById('txtidSucursalEditar').textContent;
    //    var CiudadSucursal = document.getElementById('txtCiudadSucursalEditar').textContent;
    //    var DireccionSucursal = document.getElementById('txtDireccionSucursalEditar').textContent;
    //    var TelefonoSucursal = document.getElementById('txtTelefonoSucursalEditar').textContent;
    //    var ColoniaSucursal = document.getElementById('txtColoniaSucursalEditar').textContent;
    //    var CPSucursal = document.getElementById('txtCPSucursalEditar').textContent;

    //    var parametros = "{'pid': '" + idSuc + "','CiudadSucursal': '" + CiudadSucursal + "','pDireccion': '" + DireccionSucursal + "','pTelefono': '" + TelefonoSucursal + "'}";
    //    $.ajax({
    //        dataType: "json",
    //        url: "Sucursales.aspx/EditarSucursal",
    //        async: true,
    //        data: parametros,
    //        type: "POST",
    //        contentType: "application/json; charset=utf-8",
    //        success: function (msg) {
    //            if (msg.d == "Sucursal actualizada.") {
    //                //$("#txtModalEditarMensajeSucursal").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
    //                CargarSucursales();
    //                swal(msg.d);
    //            }
    //            else {
    //                //$("#txtModalEditarMensajeSucursal").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
    //                swal(msg.d);
    //            }
    //        }
    //    });
    //});    
});

function CargarSucursales() {
    $('tbody#listasucursales').empty();
    $('#myPager').html('');
    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "Sucursales.aspx/ObtenerSucursales",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = JSON.parse(data.d);
                $(json).each(function (index, item) {

                    var IdSucursal = item.idSucursa;
                    var CiudadSucursal = item.CiudadSucursal;
                    var DireccionSucursal = item.DireccionSucursal;
                    var TelefonoSucursal = item.TelefonoSucursal;
                    var GerenteSucursal = item.Gerente;
                    //var jsonItem = "{'idSucursa': '" + IdSucursal + "', 'CiudadSucursal': '" + CiudadSucursal + "', 'DireccionSucursal': '" + DireccionSucursal + "', 'TelefonoSucursal': '" + TelefonoSucursal + "' }";

                    $('tbody#listasucursales').append(
                        '<tr><td style="display:none;">'
                        + IdSucursal
                        + '</td>'
                        + '<td>'
                        + CiudadSucursal
                        + '</td>'
                        + '<td> '
                        + DireccionSucursal
                        + '</td>'
                        + '<td> '
                        + item.ColoniaSucursal
                        + '</td>'
                        + '<td> '
                        + item.CPSucursal
                        + '</td>'
                        + '<td> '
                        + GerenteSucursal
                        + '</td>'
                        + '<td>'
                        + TelefonoSucursal
                        + '</td>'
                        + '<td>'
                        + '<div class="btn-group">'
                        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                        + '<Button class= "btn btn-success" value="' + IdSucursal + '" onclick="EditarSucursal(this);"> <i class="icon_pencil"></i></Button>'
                        + '<Button class="btn btn-danger" value="' + IdSucursal + '" onclick="EliminarSucursal(this);"><i class="icon_close_alt2"></i></Button>'
                        + '</div> '
                        + '</td>'
                        + '</tr>')
                });
            }
            else {
                $("#CargandoSucursales").append('<div class="alert alert-danger fade in"><p>No se obtuvo información o no tienes acceso.</p></div >');

            }
        }
    });
}

