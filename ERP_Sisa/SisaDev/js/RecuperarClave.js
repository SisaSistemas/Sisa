$(document).ready(function () {
    
});
$('#btnGuardarClave').click(function () {
    var Codigo = $('#txtCodigoRecibido').val();
    var Clave = $('#txtClaveNueva').val();
    $('#txtMensaje').text('');
    if (Codigo.trim() == "" && Clave.trim() == "") {
        $('#txtMensaje').text('Completa todos los campos.');
        $('#txtMensaje').css('color: red;');
    }
    else {
        var parametros = "{'pCodigo': '" + $('#txtCodigoRecibido').val() + "', 'pClaveNueva': '" + $('#txtClaveNueva').val() + "'}";
        $.ajax({
            dataType: "json",
            url: "RecuperarClave.aspx/GuardarClaveNueva",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Se ha actualizado información.") {
                    //$('#txtMensaje').text(msg.d);
                    //$('#txtMensaje').css('color: green;');
                    swal(msg.d + " Ve a la página de inicio de sesión y proporciona información actualizada.");

                }
                else {
                    //$('#txtMensaje').text(msg.d);
                    //$('#txtMensaje').css('color: red;');
                    swal(msg.d);

                }
            }
        });
    }
    
});