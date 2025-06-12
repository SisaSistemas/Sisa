var idProyecto = 0;
var Tarea = '';
$(document).ready(function () {
    var URLactual = window.location;   
    
    if (URLactual.href.indexOf("ProyectoTareasClientes.aspx") > -1) {
        idProyecto = document.getElementById('MainContent_idProyectoTarea').value;
        Tarea = document.getElementById('MainContent_lblFolio').textContent
        //Grafica();
        CargarTareas();
        //ObtenerImagenes();
    }
    
});
function CargarTareas() {
    $('tbody#listaProyectosTareas').empty();
    var parametros = "{'pid': '" + idProyecto + "'}";
    $.ajax({
        dataType: "json",
        url: "ProyectoTareasClientes.aspx/CargaTareas",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = JSON.parse(data.d);
                $(json).each(function (index, item) {
                    var idTarea = json[index].IdTask;
                    var Task = json[index].Task;
                    var NombreCompleto = json[index].NombreCompleto;
                    var FechaInicio = json[index].FechaInicio.substring(0, 10);
                    var FechaFin = json[index].FechaFin.substring(0, 10);
                    var Dias = json[index].Dias;
                    var DiasTranscurridos = json[index].DiasTranscurridos;
                    var Comentarios = json[index].Comentarios;
                    var Porcentaje = json[index].Porcentaje;
                    var Estatus = json[index].Estatus;
                    var noArchivos = "0";

                    var botonSubirArchivo = "";
                    var botonVerArchivo = "";

                    var trstyle = '';
                    if (Estatus == '0') {
                        Estatus = "PENDIENTE";
                        trstyle = 'style="background - color: lightskyblue;"';
                    } else if (Estatus == '1') {
                        Estatus = "AVANCE";
                        trstyle = 'style="background - color: wheat;"';
                    } else if (Estatus == '2') {
                        Estatus = "TERMINADO";
                        trstyle = 'style="background - color: green;"';
                    }

                    if (Task == "03-DAILY REPORTS") {
                        botonVerArchivo = '<Button title="Ver Archivos" class="btn btn-info btn-sm verArchivosDaily" value="' + idTarea + '"><i class="icon_desktop"></i></Button>';
                        //botonSubirArchivo = '<Button title="Subir Archivos" class="btn btn-primary btn-sm subirArchivosDaily" value="' + idTarea + '" ><i class="icon_upload"></i></Button>';
                        noArchivos = item.ContDaily;
                    }
                    else {
                        botonVerArchivo = '<Button title="Ver Archivos" class="btn btn-info btn-sm verArchivos" value="' + idTarea + '"><i class="icon_desktop"></i></Button>';
                        //botonSubirArchivo = '<Button title="Subir Archivos" class="btn btn-primary btn-sm subirArchivos" value="' + idTarea + '" ><i class="icon_upload"></i></Button>';
                        noArchivos = item.CONT;
                    }

                    $('tbody#listaProyectosTareas').append(
                        '<tr ' + trstyle + '><td style="display:none;">'
                        + idTarea
                        + '</td>'
                        + '<td>'
                        + Task
                        + '</td>'
                        //+ '<td>'
                        //+ NombreCompleto
                        //+ '</td>'
                        //+ '<td>'
                        //+ FechaInicio
                        //+ '</td>'
                        //+ '<td>'
                        //+ FechaFin
                        //+ '</td>'
                        //+ '<td>'
                        //+ Dias
                        //+ '</td>'
                        //+ '<td>'
                        //+ DiasTranscurridos
                        //+ '</td>'
                        + '<td>'
                        + '<span class="badge badge-warning">' + noArchivos + '</span>'
                        + '</td>'
                        + '<td>'
                        + '<div class="btn-group">'
                        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> 'onclick="VerImagen(this);"
                        + botonVerArchivo
                        //+ '<span class="btn btn-info btn-sm"><i class="icon_desktop"></i></span>'
                        //+ '<Button title="Comentario" class="btn btn-default" value="' + idTarea + '" onclick="ComentariosTarea(this);"><i class="icon_comment_alt"></i></Button>'onclick="AgregarImagen(this);"
                        //+ '<Button title="Subir Archivos" class="btn btn-primary btn-sm subirArchivos" value="' + idTarea + '" ><i class="icon_upload"></i></Button>'
                        //+ botonSubirArchivo
                        //+ '<Button title="Avance" class="btn btn-success btn-sm avance" value="' + idTarea + '" ><i class="icon_check"></i></Button>'
                        //+ '<Button title="Eliminar" class="btn btn-danger" value="' + idTarea + '" onclick="EliminarTarea(this);"><i class="icon_close_alt2"></i></Button>'onclick="AvanceTarea(this);"
                        //+ '<Button title="Editar fechas" class="btn btn-success" value="' + idTarea + '" onclick="EditarTareasFechas(this);"><i class="icon_pencil"></i></Button>'
                        + '</div > '
                        + '</td>'
                        + '</tr>')

                    //$('tbody#listaProyectosTareas').append(
                    //    '<tr ' + trstyle + '><td style="display:none;">'
                    //    + idTarea
                    //    + '</td>'
                    //    + '<td>'
                    //    + Task
                    //    + '</td>'
                    //    + '<td>'
                    //    + NombreCompleto
                    //    + '</td>'
                    //    + '<td>'
                    //    + FechaInicio
                    //    + '</td>'
                    //    + '<td>'
                    //    + FechaFin
                    //    + '</td>'
                    //    + '<td>'
                    //    + Dias
                    //    + '</td>'
                    //    + '<td>'
                    //    + DiasTranscurridos
                    //    + '</td>'
                    //    + '<td>'
                    //    + '<div class="progress progress-striped"><div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="' + Porcentaje + '" aria-valuemin="0" aria-valuemax="100" style="width:' + Porcentaje + '%"> <span class="sr-only">' + Porcentaje + '%</span></div></div>'
                    //    + Estatus + '(' + Porcentaje + '%) '
                    //    + '</td>'
                    //    + '<td>'
                    //    + '<div class="btn-group">'
                    //    //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                    //    + '<Button title="Ver imágen" class="btn btn-info verArchivos" value="' + idProyecto + '"><i class="icon_desktop"></i></Button>'
                    //    + '<Button title="Comentario" class="btn btn-default" value="' + idTarea + '" onclick="ComentariosTarea(this);"><i class="icon_comment_alt"></i></Button>'
                    //    + '</div > '
                    //    + '</td>'
                    //    + '</tr>')
                });


            }
            else {
                $("#CargandoProyectosTareas").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

            }
        }
    });
}

function ObtenerImagenes() {
    var params = "{'IdDocumento': '" + 0 +
        "','IdProyecto': '" + idProyecto +
        "','FileName': '" + "" +
        "','File': '" + "" +
        "','IdTask': '" + "" +
        "','Opcion': '" + "7" + "'}";

    $.ajax({
        async: true,
        url: "ProyectoTareasClientes.aspx/ObtenerCarrusel",
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
                //debugger;
                var _tipo = value.Tipo.substring(0, value.Tipo.indexOf("/"));
                //debugger;
                if (_tipo != "application") {
                    $('#slideimagenes').append('<li class="slide" id="slide' + cont + '"><a href = "#" ><p class="caption">' + value.NombreArchivo + '</p><img src="' + value.Archivo + '" alt="photo ' + cont + '" height="600" width="500"></a></li >');
                    cont++;
                    $('#slidenumeracion').append('<li><a href="#slide' + cont + '">&bullet;</a></li>');
                }
                else {
                    //$('#slideimagenes').append('<li class="slide" id="slide' + cont + '"><a href = "D:/Proyectos/SIS020423-001/' + value.NombreArchivo + '" ><p class="caption">' + value.NombreArchivo + '</p><img src="' + value.Archivo + '" alt="photo ' + cont + '" height="600" width="500"></a></li >');
                }
                
            });

            if (cont == 1) {
                $('#slideimagenes').append('<li class="slide" id="slide' + cont + '"><a href = "#" ><p class="caption">' + "" + '</p><img src="../images/logo.png" alt="photo ' + cont + '" height="600" width="500"></a></li >');
                
                $('#slidenumeracion').append('<li><a href="#slide' + cont + '">&bullet;</a></li>');
            }
        }

    });
}


$(document).on('click', '.verArchivos', function (event) {

    var params = "{'IdDocumento': '" + 0 +
        "','IdProyecto': '" + idProyecto +
        "','FileName': '" + "" +
        "','File': '" + "" +
        "','IdTask': '" + $(this).val() +
        "','Opcion': '" + "6" + "'}";

    //console.log(params);
    $('#ulFiles').html('');
    $.ajax({
        async: true,
        url: "ProyectoTareasClientes.aspx/CargarDocumentos",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var jsonArray = $.parseJSON(data.d);

            $('#ulFiles').html('');
            var cont = 1;
            $.each(jsonArray, function (index, value) {
                var icono = '<i class="icon_document_alt"></i>';

                var file = value.NombreArchivo.substring(value.NombreArchivo.indexOf("."));
                //if (file == '.png' || file == '.jpg' || file == '.PNG' || file == '.JPG' || file == '.JPEG' || file == '.jpeg' || file == '.jfif' || file == '.JFIF') {
                //    //$('#slideimagenes').append('<li class="slide" id="slide' + cont + '"><a href = "#" ><img src="' + value.Archivo + '" alt="photo ' + cont + '" height="350" width="120"></a></li >');
                //    //$('#slidenumeracion').append('<li><a href="#slide' + cont + '">&bullet;</a></li>');
                //    //cont++;
                //}
                //else {
                //    $('#ulFiles').append('<li>' + icono + '&nbsp<Button type="button" id="idDocumentoBoton" class="btn btn-default" value="' + value.IdDocumento.trim() + '" onclick="VerDoc(this);">' + value.NombreArchivo + '</Button>&nbsp&nbsp<button class="btn btn-danger eliminarDoc" id="btnEliminarArchivo" type="button" value="' + value.IdDocumento.trim() + '" rel="' + value.NombreArchivo + '"><i class="icon_close_alt2"></i></button></li><br>');

                //}
                $('#ulFiles').append('<li>' + icono + '&nbsp<Button type="button" id="idDocumentoBoton" class="btn btn-default" value="' + value.IdDocumento.trim() + '" onclick="VerDoc(this);">' + value.NombreArchivo + '</Button>&nbsp&nbsp<button class="btn btn-danger eliminarDoc" id="btnEliminarArchivo" type="button" value="' + value.IdDocumento.trim() + '" rel="' + value.NombreArchivo + '"><i class="icon_close_alt2"></i></button></li><br>');

            });
        }

    });
    $("#GaleriaArchivosProyectosModal").modal();

});

$(document).on('click', '.verArchivosDaily', function (event) {

    var params = "{'IdDocumento': '" + 0 +
        "','IdProyecto': '" + idProyecto +
        "','FileName': '" + "" +
        "','File': '" + "" +
        "','IdTask': '" + $(this).val() +
        "','Opcion': '" + "7" + "'}";

    //console.log(params);
    $('#ulFiles').html('');
    $.ajax({
        async: true,
        url: "ProyectoTareasClientes.aspx/CargarDocumentos",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var jsonArray = $.parseJSON(data.d);

            $('#ulFiles').html('');
            var cont = 1;
            $.each(jsonArray, function (index, value) {
                var icono = '<i class="icon_document_alt"></i>';

                var file = value.NombreArchivo.substring(value.NombreArchivo.indexOf("."));
                if (file == '.png' || file == '.jpg' || file == '.PNG' || file == '.JPG' || file == '.JPEG' || file == '.jpeg' || file == '.jfif' || file == '.JFIF') {
                    //$('#slideimagenes').append('<li class="slide" id="slide' + cont + '"><a href = "#" ><img src="' + value.Archivo + '" alt="photo ' + cont + '" height="350" width="120"></a></li >');
                    //$('#slidenumeracion').append('<li><a href="#slide' + cont + '">&bullet;</a></li>');
                    //cont++;
                }
                else {
                    $('#ulFiles').append('<li>' + icono + '&nbsp<Button type="button" id="idDocumentoBoton" class="btn btn-default" value="' + value.IdDocumento.trim() + '" onclick="VerDoc(this);">' + value.NombreArchivo + '</Button>&nbsp&nbsp<button class="btn btn-danger eliminarDoc" id="btnEliminarArchivo" type="button" value="' + value.IdDocumento.trim() + '" rel="' + value.NombreArchivo + '"><i class="icon_close_alt2"></i></button></li><br>');

                }


            });
        }

    });
    $("#GaleriaArchivosProyectosModal").modal();

});


$('#btnVerGaleria').click(function () {

    var params = "{'IdDocumento': '" + 0 +
        "','IdProyecto': '" + idProyecto +
        "','FileName': '" + "" +
        "','File': '" + "" +
        "','Opcion': '" + "3" + "'}";

    $.ajax({
        async: true,
        url: "ProyectoTareasClientes.aspx/CargarDocumentos",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            var datos = "";

            var JsonCombos;
            var jsonArray = $.parseJSON(data.d);

            $('#ulFiles').html('');
            $('#slideimagenes').html('');
            $('#slidenumeracion').html('');
            var cont = 1;
            $.each(jsonArray, function (index, value) {
                var icono = '<i class="fa fa-file-code-o"></i>';

                var file = value.NombreArchivo.substring(value.NombreArchivo.indexOf("."));
                if (file == '.png' || file == '.jpg' || file == '.PNG' || file == '.JPG') {
                    $('#slideimagenes').append('<li class="slide" id="slide' + cont + '"><a href = "#" ><img src="' + value.Archivo + '" alt="photo ' + cont + '" height="350" width="120"></a></li >');
                    $('#slidenumeracion').append('<li><a href="#slide' + cont + '">&bullet;</a></li>');
                    cont++;
                }
                else {
                    $('#ulFiles').append('<li>' + icono + '<a href="' + value.Archivo + '" target="_blank">' + value.NombreArchivo + '</a></li>');
                }


            });
        }

    });
    $("#GaleriaProyectosModal").modal();

});

function cargarComentariosProyectos(id) {

    var params = "{'pid': '" + id + "'}";
    $.ajax({
        async: true,
        url: "ProyectoTareasClientes.aspx/CargarComentariosTareas",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var datos = "";
            var nodoTRAgregar = "";

            var JsonCombos;
            var jsonArray = $.parseJSON(data.d);

            $('#TablaPrincipalComentariosProyectosTarea tbody').html('');
            $.each(jsonArray, function (index, value) {
                nodoTRAgregar += "<tr>";
                nodoTRAgregar += '  <td style="display: none;">' + value.IdTaskComentario + "</td>";
                nodoTRAgregar += "  <td>" + value.Comentario + "</td>";
                nodoTRAgregar += "  <td>" + value.NombreCompleto + "</td>";
                nodoTRAgregar += "  <td>" + value.Fecha.substring(0, 10) + "</td>";
                nodoTRAgregar += "</tr>";
            });

            $('#TablaPrincipalComentariosProyectosTarea tbody').append(nodoTRAgregar);
        }
    });
}


