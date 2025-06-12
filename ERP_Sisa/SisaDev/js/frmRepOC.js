$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("frmRepOC.aspx") > -1) {



    }

});


$('#btnBuscarRecibidas').click(function () {

    console.log($('#dtFechaInicio').val());
    console.log($('#dtFechaFin').val());

    window.open("OC.aspx?fechaIni=" + $('#dtFechaInicio').val() + "&FechaFin=" + $('#dtFechaFin').val());
});