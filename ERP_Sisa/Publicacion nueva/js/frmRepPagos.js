$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("frmRepPagos.aspx") > -1) {



    }

});


$('#btnBuscar').click(function () {

    window.open("Pagos.aspx?fechaIni=" + $('#dtFechaInicio').val() + "&FechaFin=" + $('#dtFechaFin').val());
});