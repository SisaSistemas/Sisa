$(document).ready(function () {
    var URLactual = window.location;
    var idProyecto = 0;
    var Tarea = '';
    if (URLactual.href.indexOf("ProyectoHorasHombre.aspx") > -1) {
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        idProyecto = document.getElementById('MainContent_idProyectoHH').value;
        CargarUsuarios();
        CargarHH();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
        
    }

    function CargarUsuarios() {
        var params = "{'Opcion': '1'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'ProyectoTareas.aspx/CargarCombos',
            data: params,
            success: function (data, textStatus) {

                var json = $.parseJSON(data.d);

                $('#cmbUsuarios').html('');
                $.each(json, function (index, value) {
                    $("#cmbUsuarios").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
                });
                $('#cmbUsuarios').selectpicker('refresh');
                $('#cmbUsuarios').selectpicker('render');
            }
        });
    }

    function CargarHH() {
        $('tbody#listaProyectosHH').empty();
        var parametros = "{'pid': '" + idProyecto + "'}";
        $.ajax({
            dataType: "json",
            url: "ProyectoHorasHombre.aspx/CargarHorasHombre",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {
                        var idHH = json[index].IdHorasHombre;
                        var Persona = json[index].NombreCompleto;
                        var Lunes = json[index].Lunes;
                        var Martes = json[index].Martes;
                        var Miercoles = json[index].Miercoles;
                        var Jueves = json[index].Jueves;
                        var Viernes = json[index].Viernes;
                        var Sabado = json[index].Sabado;
                        var Domingo = json[index].Domingo;
                        var Fecha = json[index].Fecha.substring(0,10);
                        var Total = json[index].Total;
                        $('tbody#listaProyectosHH').append(
                            '<tr><td style="display:none;">'
                            + idHH
                            + '</td>'
                            + '<td>'
                            + Persona
                            + '</td>'
                            + '<td>'
                            + Lunes
                            + '</td>'
                            + '<td>'
                            + Martes
                            + '</td>'
                            + '<td>'
                            + Miercoles
                            + '</td>'
                            + '<td>'
                            + Jueves
                            + '</td>'
                            + '<td>'
                            + Viernes
                            + '</td>'
                            + '<td>'
                            + Sabado
                            + '</td>'
                            + '<td>'
                            + Domingo
                            + '</td>'
                            + '<td>'
                            + Fecha
                            + '</td>'
                            + '<td>'
                            + Total
                            + '</td>'
                            + '<td>'
                            + '<div class="btn-group">'
                            //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                            + '<Button title="Eliminar" class="btn btn-danger" value="' + idHH + '" onclick="EliminarHH(this);"><i class="icon_close_alt2"></i></Button>'
                            + '</div> '
                            + '</td>'
                            + '</tr>')
                    });


                }
                else {
                    $("#CargandoProyectosTareas").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }
            }
        });
    }

    $('#btnHHProyectos').click(function () {
        if ($('#cmbUsuarios').val() == '') {
            swal("Selecciona persona...");
            return;
        } //string pid, string Usuario, string Lunes, string Martes, string Miercoles, string Jueves, string Viernes, string Sabado, string Domingo
        var parametros = "{'pid': '" + idProyecto + "', 'Usuario':'" + $('#cmbUsuarios').val() + "','Lunes':'" + $('#txtLunes').val() + "','Martes':'" + $('#txtMartes').val() + "','Miercoles':'" + $('#txtMiercoles').val() + "','Jueves':'" + $('#txtJueves').val() + "','Viernes':'" + $('#txtViernes').val() + "','Sabado':'" + $('#txtSabado').val() + "','Domingo':'" + $('#txtDomingo').val() + "'}";
        $.ajax({
            dataType: "json",
            url: "ProyectoHorasHombre.aspx/AgregarHorasHombre",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Horas agregadas.") {
                    // $("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarHH();
                    swal(msg.d);
                   
                }
                else {
                    //$("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnHHEliminarProyectos').click(function () {
        
        var idProyectosHH = document.getElementById('idProyectosHH').textContent;
        var parametros = "{'pid': '" + idProyectosHH + "'}";
        $.ajax({
            dataType: "json",
            url: "ProyectoHorasHombre.aspx/EliminarProyectosHH",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Horas eliminadas.") {
                    // $("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarHH();
                    swal(msg.d);
                    
                }
                else {
                    //$("#txtModalEliminarMensajeCotizaciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });
});




