$(document).ready(function () {
    var URLactual = window.location;
    var idProyecto = 0;
    var Tarea = '';
    if (URLactual.href.indexOf("ProyectoGrafica.aspx") > -1) {
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        idProyecto = document.getElementById('MainContent_idProyectoDetalle').value;
        //EscribirEficienciasTabla();
        cargarDatos();
        cargarComentarios();
        //fnDibujarGrafica();
        fnDibujarGraficaPastel();
        //fnDibujarGraficaPastelEficiencias();
        //Grafica();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);

    }

});