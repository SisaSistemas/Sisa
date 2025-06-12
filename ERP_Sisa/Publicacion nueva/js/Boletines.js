$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("Boletines.aspx") > -1) {
       
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarBoletines();
        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
        
        
    }   
});
function CargarBoletines() {
    $('tbody#listaBoletines').empty();
    $('#myPager').html('');
    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "Boletines.aspx/ObtenerBoletin",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = JSON.parse(data.d);
                $(json).each(function (index, item) {
                   
                    var idBoletin = json[index].idBoletin;
                    var Usuario = json[index].Usuario;
                    var Fecha = json[index].Fecha;
                    var Informacion = json[index].Texto;
                    var Imagen = json[index].Imagen;
                    var PDF = json[index].PDF;
                    
                    if (Imagen == "NULL" || Imagen === null || Imagen == '') {
                        Imagen = '<Button title="Agregar imagen" class="btn btn-danger" value="' + idBoletin + '" onclick="AgregarImagenBoletin(this);"><i class="icon_close"></i></Button>';

                    }
                    else {
                        Imagen = '<Button title="Ver imagen" class="btn btn-info" value="' + idBoletin + '" onclick="VisualizarImagenBoletine(this);"><i class="icon_document"></i></Button>';

                    }
                    if (PDF == "NULL" || PDF === null || PDF == '') {
                        PDF = '<Button title="Agregar pdf" class="btn btn-danger" value="' + idBoletin + '" onclick="AgregarPDFBoletin(this);"><i class="icon_close"></i></Button>';

                    }
                    else {
                        PDF = '<Button title="Ver pdf" class="btn btn-info" value="' + idBoletin + '" onclick="VisualizarPDFBoletine(this);"><i class="icon_document"></i></Button>';

                    }
                    $('tbody#listaBoletines').append(
                        '<tr><td style="display:none;">'
                        + idBoletin
                        + '</td>'
                        + '<td>'
                        + Fecha.substring(0, 10)
                        + '</td>'
                        + '<td>'
                        + Usuario
                        + '</td>'                        
                        + '<td> '
                        + Informacion
                        + '</td><td>'
                        + Imagen
                        + '</td>'
                        + '<td>'
                        + PDF
                        + '</td>'                        
                        + '<td>'
                        + '<div class="btn-group">'                      
                        + '<Button title="Eliminar" class="btn btn-danger" value="' + idBoletin + '" onclick="EliminaBoletin(this);"><i class="icon_minus_alt2"></i></Button>'
                        + '</div > '
                        + '</td>'
                        + '</tr>')
                });
                $('#listaBoletines').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
            }
            else {
                $("#CargandoBoletines").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

            }
        }
    });
}

function AgregarImagenBoletin(btn) {
    swal({
        title: 'Seleccione imagen',
        input: 'file',
        allowOutsideClick: false,
        allowEscapeKey: false,
        allowEnterKey: false,
        showCloseButton: true
    }).then(function (file) {
        var nombreArchivo = file.name;
        var reader = new FileReader
        reader.onload = function (e) {
            //debugger;
            //console.log(nombreArchivo);

            //var params = "{'IdCotizacion': '" + idCotizacion +
            //    "','NombreArchivo': '" + nombreArchivo +
            //    "','Documento': '" + e.target.result + "'}";

            var params = "{'TipoDoc': '" + 'IMAGEN' +
                "','idBoletin': '" + btn.value +
                "','FileName': '" + nombreArchivo +
                "','File': '" + e.target.result + "'}";

            //console.log(params);
            $.ajax({
                dataType: "json",
                async: true,
                url: "Boletines.aspx/GuardarDocumentos",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    //location.href = './frmProjects.aspx';
                    CargarBoletines();
                    swal({
                        title: msg.d,
                        timer: 3000
                    });
                    
                    //cargarArchivos();
                },
                error: function (xhr, ajaxOptions, thrownError) {

                }
            });


        }

        reader.readAsDataURL(file);

    });
}
function VisualizarPDFBoletine(btn) {
    $('#testmodalpdf').html('');

    var params = "{'idBoletin': '" + btn.value +
        "','Opcion': '" + "PDF" + "'}";

    $.ajax({
        async: true,
        url: "Boletines.aspx/CargarDocumentos",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            var datos = "";

            var JsonCombos;
            var jsonArray = $.parseJSON(data.d);


            $.each(jsonArray, function (index, value) {
                document.getElementById('txtTipoDocumento').textContent = "PDF";

                document.getElementById('txtidBoletin').textContent = value.idBoletin;
                $('#testmodalpdf').append('<object id="visorPDF" data="' + value.PDF + '" type="application/pdf" style="width:100%; height: 800px;"></object>');
            });
        }
    });
    $("#dvPDF").modal();
}
function AgregarPDFBoletin(btn) {
    swal({
        title: 'Seleccione pdf',
        input: 'file',
        allowOutsideClick: false,
        allowEscapeKey: false,
        allowEnterKey: false,
        showCloseButton: true
    }).then(function (file) {
        var nombreArchivo = file.name;
        var reader = new FileReader
        reader.onload = function (e) {
            //debugger;
            //console.log(nombreArchivo);

            //var params = "{'IdCotizacion': '" + idCotizacion +
            //    "','NombreArchivo': '" + nombreArchivo +
            //    "','Documento': '" + e.target.result + "'}";

            var params = "{'TipoDoc': '" + 'PDF' +
                "','idBoletin': '" + btn.value +
                "','FileName': '" + nombreArchivo +
                "','File': '" + e.target.result + "'}";

            //console.log(params);
            $.ajax({
                dataType: "json",
                async: true,
                url: "Boletines.aspx/GuardarDocumentos",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    //location.href = './frmProjects.aspx';
                    CargarBoletines();
                    swal({
                        title: msg.d,
                        timer: 3000
                    });

                    //cargarArchivos();
                },
                error: function (xhr, ajaxOptions, thrownError) {

                }
            });


        }

        reader.readAsDataURL(file);

    });
}
function VisualizarImagenBoletine(btn) {
    $('#VistaBoletinForm').empty();
    var params = "{'idBoletin': '" + btn.value +
        "','Opcion': '" + "Imagen" + "'}";
    document.getElementById('txtidBoletinImagen').textContent = btn.value;
            
    $.ajax({
        async: true,
        url: "Boletines.aspx/CargarDocumentos",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {            
            var jsonArray = $.parseJSON(data.d);


            $.each(jsonArray, function (index, value) {
                $('#VistaBoletinForm').append('<img style="width: 60%; height: 80%; display: block;" src="' + value.Imagen + '" alt="image" />');
               
            });
        }
    });
    $("#VistaBoletinModal").modal();
    
}


$('#btnGuardarBoletin').click(function () {
    var texto = $('#txtInformacionBoletin').val();

    var parametros = "{'texto': '" + texto + "'}";
    $.ajax({
        dataType: "json",
        url: "Boletines.aspx/NuevoBoletin",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Boletin creado, favor de agregar archivos.") {
                //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                CargarBoletines();
                swal(msg.d);
            }
            else {
                //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
});
$('#btnEliminarBoletin').click(function () {
    var id = document.getElementById('idBoletinEliminar').textContent;

    var parametros = "{'pid': '" + id + "'}";
    $.ajax({
        dataType: "json",
        url: "Boletines.aspx/EliminarBoletin",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Informacion eliminada.") {
                //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                CargarBoletines();
                swal(msg.d);
            }
            else {
                //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
});


$('#btnEliminadDocumentoBoletin').click(function () {
    swal({
        title: 'Estas Seguro que quieres eliminar documento del boletin?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Aceptar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {

        if (result) {

            var id = document.getElementById('txtidBoletin').textContent;

            var parametros = "{'idBoletin': '" + id + "'}";
            $.ajax({
                dataType: "json",
                url: "Boletines.aspx/EliminarDocumentoBoletin",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Documento eliminado.") {
                        // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                        CargarBoletines();
                        swal(msg.d);

                    }
                    else {
                        //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                        swal(msg.d);
                    }
                }
            });

        }
    });
});

$('#btnEliminadImagenBoletin').click(function () {
    swal({
        title: 'Estas Seguro que quieres eliminar imagen del boletin?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Aceptar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {

        if (result) {

            var id = document.getElementById('txtidBoletinImagen').textContent;

            var parametros = "{'idBoletin': '" + id + "'}";
            $.ajax({
                dataType: "json",
                url: "Boletines.aspx/EliminarImagenBoletin",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Documento eliminado.") {
                        // $("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                        CargarBoletines();
                        swal(msg.d);

                    }
                    else {
                        //$("#txtModalCancelarMensajeCotizacion").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                        swal(msg.d);
                    }
                }
            });

        }
    });
});
$.fn.pageMe = function (opts) {
    var $this = this,
        defaults = {
            perPage: 7,
            showPrevNext: false,
            hidePageNumbers: false
        },
        settings = $.extend(defaults, opts);

    var listElement = $this;
    var perPage = settings.perPage;
    var children = listElement.children();
    var pager = $('.pager');

    if (typeof settings.childSelector != "undefined") {
        children = listElement.find(settings.childSelector);
    }

    if (typeof settings.pagerSelector != "undefined") {
        pager = $(settings.pagerSelector);
    }

    var numItems = children.size();
    var numPages = Math.ceil(numItems / perPage);

    pager.data("curr", 0);

    if (settings.showPrevNext) {
        $('<li><a href="#" class="prev_link">«</a></li>').appendTo(pager);
    }

    var curr = 0;
    while (numPages > curr && (settings.hidePageNumbers == false)) {
        $('<li><a href="#" class="page_link">' + (curr + 1) + '</a></li>').appendTo(pager);
        curr++;
    }

    if (settings.showPrevNext) {
        $('<li><a href="#" class="next_link">»</a></li>').appendTo(pager);
    }

    pager.find('.page_link:first').addClass('active');
    pager.find('.prev_link').hide();
    if (numPages <= 1) {
        pager.find('.next_link').hide();
    }
    pager.children().eq(1).addClass("active");

    children.hide();
    children.slice(0, perPage).show();

    pager.find('li .page_link').click(function () {
        var clickedPage = $(this).html().valueOf() - 1;
        goTo(clickedPage, perPage);
        return false;
    });
    pager.find('li .prev_link').click(function () {
        previous();
        return false;
    });
    pager.find('li .next_link').click(function () {
        next();
        return false;
    });

    function previous() {
        var goToPage = parseInt(pager.data("curr")) - 1;
        goTo(goToPage);
    }

    function next() {
        goToPage = parseInt(pager.data("curr")) + 1;
        goTo(goToPage);
    }

    function goTo(page) {
        var startAt = page * perPage,
            endOn = startAt + perPage;

        children.css('display', 'none').slice(startAt, endOn).show();

        if (page >= 1) {
            pager.find('.prev_link').show();
        }
        else {
            pager.find('.prev_link').hide();
        }

        if (page < (numPages - 1)) {
            pager.find('.next_link').show();
        }
        else {
            pager.find('.next_link').hide();
        }

        pager.data("curr", page);
        pager.children().removeClass("active");
        pager.children().eq(page + 1).addClass("active");

    }
};
