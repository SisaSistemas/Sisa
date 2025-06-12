$(document).ready(function () {

    

    var URLactual = window.location;
    if (URLactual.href.indexOf("Inicio.aspx") > -1) {
        OBtenerBoletines();

    }
});

function OBtenerBoletines() {
    var params = "{'pid':'1'}";
    $.ajax({
        async: true,
        url: "Inicio.aspx/ObtenerBoletin",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            var datos = "";
            var JsonCombos;
            var jsonArray = $.parseJSON(data.d);
            $('#slideimagenes').html('');
            $('#slidenumeracion').html('');
            var cont = 1;
            $.each(jsonArray, function (index, value) {
                if (value.NombrePDF == '') {
                    $('#slideimagenes').append('<li class="slide" id="slide' + cont + '"><a href = "#" ><p class="caption">' + value.Texto + '</p><img src="' + value.Imagen + '" alt="photo ' + cont + '" height="600" width="500"></a></li >');

                } else {
                    $('#slideimagenes').append('<li class="slide" id="slide' + cont + '"><a href = "docsboletines/' + value.NombrePDF + '" ><p class="caption">'+ value.Texto +'</p><img src="' + value.Imagen + '" alt="photo ' + cont + '" height="600" width="500"></a></li >');
                }
                $('#slidenumeracion').append('<li><a href="#slide' + cont + '">&bullet;</a></li>');
               
                cont++;

            });
        }

    });
}

