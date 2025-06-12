$(document).ready(function () {

});

$('#btnGuardarDatosPerfil').click(function () {
    var Telefono = $('#MainContent_txtTelefono').val();
    var Correo = $('#MainContent_txtCorreo').val();
    var Foto = $("[id*='ImgPrv']").prop('src');
   // $('#txtMensajeDatos').text('');
    if (Telefono == "" && Correo == "") {
        //$('#txtMensajeDatos').text('Completa los campos obligatorios y editables (teléfono, correo).');
        //$('#txtMensajeDatos').css('color: red;');
        swal('Completa los campos obligatorios y editables (teléfono, correo).');
    }
    else {        
        var parametros = "{'pFoto': '" + Foto + "', 'pTelefono': '" + Telefono + "', 'pCorreo': '" + Correo + "'}";
        $.ajax({
            dataType: "json",
            url: "Perfil.aspx/GuardarDatosGenerales",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Datos guardados.") {
                    //$("#ContenedorMensajePerfilGuardado").append('<div class="alert alert-success fade in"><p>' + msg.d +'</p></div >');
                    document.getElementById("ImagenActual").src = Foto;
                    $("[id*='ImgPrv']").prop('src', '');
                    swal(msg.d);

                }
                else {
                    //("#ContenedorMensajePerfilGuardado").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    }

});

$('#btnGuardarClave').click(function () {
    var ClaveActual = $('#txtClaveACtual').val();
    var ClaveNueva = $('#txtClaveNueva').val();
    //$('#txtMensaje').text('');
    if (ClaveActual == "" && ClaveNueva == "") {
       // $('#txtMensaje').text('Completa todos los campos.');
        //$('#txtMensaje').css('color: red;');
        swal('Completa todos los campos.');
    }
    else {
        var parametros = "{'pClaveActual': '" + ClaveActual + "', 'pClaveNueva': '" + ClaveNueva + "'}";
        $.ajax({
            dataType: "json",
            url: "Perfil.aspx/GuardarClaveNueva",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Se ha actualizado información.") {
                    //$("#ContenedorMensajeClave").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);

                }
                else {
                    //$("#ContenedorMensajeClave").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);

                }
            }
        });
    }

});

function ShowImagePreview(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("[id*='ImgPrv']").prop('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}

