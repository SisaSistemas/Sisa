$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("ClientesContacto.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarCcontacto();
        CargarEmpresa();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }

    $('#btnGuardarCcontacto').click(function () {
        var Nombre = $('#txtNombreContacto').val();
        var Correo = $('#txtCorreoCcontacto').val();
        var Telefono = $('#txtTelefonoCcontacto').val();
        var Usuario = $('#txtUsuarioCcontacto').val();
        var slctEmpresa = $('#slctEmpresa').val();
        var Clave = $('#txtClaveCcontacto').val();

        if (Nombre == "") {
            // $("#AddMsgCcontacto").append('<div class="alert alert-danger fade in"><p>Completa los campos obligatorios.</p></div >');
            swal('Completa campos obligatorios. (Nombre)');

        }
        else {
            var parametros = "{'pNombre': '" + Nombre +
                "', 'pTelefono': '" + Telefono +
                "', 'pCorreo': '" + Correo +
                "', 'pEmpresa': '" + slctEmpresa +
                "', 'pUsuario': '" + Usuario +
                "', 'pClave': '" + Clave +
                "'}";
            $.ajax({
                dataType: "json",
                url: "ClientesContacto.aspx/GuardarContacto",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Contacto creado.") {
                        // $("#AddMsgCcontacto").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                        CargarCcontacto();
                        swal(msg.d);

                    }
                    else {
                        //$("#AddMsgCcontacto").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                        swal(msg.d);

                    }
                }
            });
        }

    });

    $('#btnEliminarCcontacto').click(function () {
        var idContacto = document.getElementById('idCcontactoEliminar').textContent;

        var parametros = "{'pidContacto': '" + idContacto + "'}";
        $.ajax({
            dataType: "json",
            url: "ClientesContacto.aspx/EliminarContacto",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Contacto eliminado.") {
                    //$("#txtModalEliminarMensajeCcontacto").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarCcontacto();
                    swal(msg.d);
                }
                else {
                    // $("#txtModalEliminarMensajeCcontacto").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });


    $('#btnEditarCcontacto').click(function () {
        var idSuc = document.getElementById('txtidCcontactoEditar').textContent;
        var CiudadCcontacto = document.getElementById('txtCiudadCcontactoEditar').textContent;
        var DireccionCcontacto = document.getElementById('txtDireccionCcontactoEditar').textContent;
        var TelefonoCcontacto = document.getElementById('txtTelefonoCcontactoEditar').textContent;

        var parametros = "{'pid': '" + idSuc + "','CiudadCcontacto': '" + CiudadCcontacto + "','pDireccion': '" + DireccionCcontacto + "','pTelefono': '" + TelefonoCcontacto + "'}";
        $.ajax({
            dataType: "json",
            url: "Sucursales.aspx/EditarSucursal",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Ccontacto actualizada.") {
                    //$("#txtModalEditarMensajeCcontacto").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarCcontacto();
                    swal(msg.d);
                }
                else {
                    // $("#txtModalEditarMensajeCcontacto").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnActivarContacto').click(function () {
        var idContacto = document.getElementById('idContactoActivar').textContent;

        var parametros = "{'pidContacto': '" + idContacto + "'}";
        $.ajax({
            dataType: "json",
            url: "ClientesContacto.aspx/ActivarContacto",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Contacto activada.") {
                    //$("#txtModalEliminarMensajeContacto").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarCcontacto();
                    swal(msg.d);
                }
                else {
                    //$("#txtModalEliminarMensajeContacto").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });
});

function CargarEmpresa() {
    var parametros = "{'pid': '2'}";
    $.ajax({
        dataType: "json",
        url: "ClientesContacto.aspx/ObtenerEmpresas",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = JSON.parse(data.d);
                $(json).each(function (index, item) {

                    var IdEmpresa = json[index].idEmpresa;
                    var RazonSocialEmpresa = json[index].Cliente;
                    //var jsonItem = "{'idSucursa': '" + IdSucursal + "', 'CiudadSucursal': '" + CiudadSucursal + "', 'DireccionSucursal': '" + DireccionSucursal + "', 'TelefonoSucursal': '" + TelefonoSucursal + "' }";                       
                    $("#slctEmpresa").append('<option value="' + IdEmpresa + '">' + RazonSocialEmpresa + '</option>');
                });
                $('#slctEmpresa').selectpicker('refresh');
                $('#slctEmpresa').selectpicker('render');
            }
            else {
                $("#CargandoEmpresa").append('<div class="alert alert-danger fade in"><p>No se obtuvo información o no tienes permiso de acceso.</p></div >');

            }
        }
    });
}


function CargarCcontacto() {
    $('tbody#listaCcontacto').empty();
    $('#myPager').html('');

    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "ClientesContacto.aspx/ObtenerContactos",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = JSON.parse(data.d);
                $(json).each(function (index, item) {

                    var IdCcontacto = json[index].idContacto;
                    var NombreContacto = json[index].NombreContacto;
                    var TelefonoCcontacto = json[index].Telefono;
                    var CorreoContacto = json[index].Correo;
                    var EmpresaContacto = json[index].Cliente;
                    var idEmpresa = json[index].idEmpresa;
                    var Usuario = json[index].Usuario;
                    var Clave = json[index].Clave;
                    //var jsonItem = "{'idSucursa': '" + IdCcontacto + "', 'CiudadCcontacto': '" + CiudadCcontacto + "', 'DireccionCcontacto': '" + DireccionCcontacto + "', 'TelefonoCcontacto': '" + TelefonoCcontacto + "' }";
                    var Estatus = json[index].Estatus;
                    var trstyle = '';
                    if (Estatus == false) {
                        Estatus = 'INACTIVO';
                        trstyle = 'style="background-color: red; color: white;"';
                    } else if (Estatus == true) {
                        Estatus = 'ACTIVO';
                    }
                    $('tbody#listaCcontacto').append(
                        '<tr ' + trstyle + '><td style="display:none;">'
                        + IdCcontacto
                        + '</td>'
                        + '<td>'
                        + NombreContacto
                        + '</td>'
                        + '<td>'
                        + TelefonoCcontacto
                        + '</td><td>'
                        + CorreoContacto
                        + '</td><td>'
                        + EmpresaContacto
                        + '</td>'
                        + '<td>'
                        + Estatus
                        + '</td>'
                        + '<td>'
                        + '<div class="btn-group">'
                        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                        + '<Button title="Editar contacto" class= "btn btn-info" value="' + IdCcontacto + '" onclick="EditarCcontacto(this);"> <i class="icon_pencil"></i></Button>'
                        + '<Button title="Activar contacto" class="btn btn-success" value="' + IdCcontacto + '" onclick="ActivarContacto(this);"><i class="icon_check_alt2"></i></Button>'
                        + '<Button title="Eliminar contacto" class="btn btn-danger" value="' + IdCcontacto + '" onclick="EliminarCcontacto(this);"><i class="icon_close_alt2"></i></Button>'
                        + '<Button title="Agregar imágen" class="btn btn-info" value="' + IdCcontacto + '" onclick="AgregarImagenContacto(this);"><i class="icon_image"></i></Button>'
                        + '</div > '
                        + '</td>'
                        + '</tr>')
                });
                //$('#listaCcontacto').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
                $('#TablaCcontacto').DataTable({
                    "bLengthChange": false,
                    "pageLength": 100,
                    "order": [[1, "asc"]],
                    "oLanguage": {
                        "sSearch": "Buscar:"
                    },
                    "retrieve": true
                });
            }
            else {
                $("#CargandoCcontacto").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

            }
        }
    });
}

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

function CargarEmpresasEditar(id) {
    var parametros = "{'pid': '2'}";
    $.ajax({
        dataType: "json",
        url: "ClientesContacto.aspx/ObtenerEmpresas",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = JSON.parse(data.d);
                $(json).each(function (index, item) {

                    var IdEmpresa = json[index].idEmpresa;
                    var RazonSocialEmpresa = json[index].Cliente;
                    //var jsonItem = "{'idSucursa': '" + IdSucursal + "', 'CiudadSucursal': '" + CiudadSucursal + "', 'DireccionSucursal': '" + DireccionSucursal + "', 'TelefonoSucursal': '" + TelefonoSucursal + "' }";                       
                    $("#slctEmpresaEditar").append('<option value="' + IdEmpresa + '">' + RazonSocialEmpresa + '</option>');
                });
                $('#slctEmpresaEditar').selectpicker('refresh');
                $('#slctEmpresaEditar').selectpicker('render');
                $('#slctEmpresaEditar').val(id);
                $('#slctEmpresaEditar').selectpicker('refresh');
            }
            else {
                $("#CargandoEmpresa").append('<div class="alert alert-danger fade in"><p>No se obtuvo información o no tienes permiso de acceso.</p></div >');

            }
        }
    });
}

function EditarCcontactoDesdePopUp() {
    var NombreCcontacto = document.getElementById('txtNombreCcontactoEditar').value;
    var IdCcontacto = document.getElementById('txtidCcontactoEditar').value;
    var CorreoCcontacto = document.getElementById('txtCorreoCcontactoEditar').value;
    var TelefonoCcontacto = document.getElementById('txtTelefonoCcontactoEditar').value;
    var UsuarioCcontacto = document.getElementById('txtUsuarioCcontactoEditar').value;
    var ClaveCcontacto = document.getElementById('txtClaveCcontactoEditar').value;
    var idEmpresa = $('#slctEmpresaEditar').val();
    var parametros = "{'pid': '" + IdCcontacto + "','pNombre': '" + NombreCcontacto + "','pTelefono': '" + TelefonoCcontacto + "','pCorreo': '" + CorreoCcontacto + "','pUsuario': '" + UsuarioCcontacto + "','pClave': '" + ClaveCcontacto + "', 'idEmpresa':'" + idEmpresa + "'}";
    $.ajax({
        dataType: "json",
        url: "ClientesContacto.aspx/EditarContacto",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Contacto actualizada.") {
                //$("#txtModalEditarMensajeCcontacto").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                //CargarCcontacto(); //llamada a function en Ccontacto.js
                swal(msg.d);
                location.reload();
            }
            else {
                //$("#txtModalEditarMensajeCcontacto").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
}

function EditarCcontacto(btn) {
    $('#EditarCcontactoForm').empty();
    //$(btn.value).each(function (index, item) {
    //    var IdCcontacto = json[index].idSucursa;
    //    var CiudadCcontacto = json[index].CiudadCcontacto;
    //    var DireccionCcontacto = json[index].DireccionCcontacto;
    //    var TelefonoCcontacto = json[index].TelefonoCcontacto;
    //    $('#EditarCcontactoForm').append(' <div class= "modal-body" >  <div class="form-group"> <div class="col-sm-10"> <input type="hidden" class="form-control" id="txtidCcontactoEditar" value="' + IdCcontacto + '" required/></div></div<div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtCiudadCcontactoEditar" value="' + CiudadCcontacto + '" required/></div></div><div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtDireccionCcontactoEditar" value="' + DireccionCcontacto + '" required/></div></div><div class="form-group"> <div class="col-sm-10"><input type="tel" class="form-control"  id="txtTelefonoCcontactoEditar" value="' + TelefonoCcontacto + '" required/></div> </div>  <div class="form-group"> <div class="col-sm-10"><div class="form-group" id="txtModalEditarMensajeCcontacto"> </div></div> </div> </div > <div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> <button class="btn btn-primary" id="btnEditarCcontacto" type="button">Guardar cambios</button> </div>');
    //});
    var parametros = "{'pid': '" + btn.value + "'}";
    $.ajax({
        dataType: "json",
        url: "ClientesContacto.aspx/ObtenerContactos",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = JSON.parse(data.d);
                $(json).each(function (index, item) {
                    var NombreCcontacto = item.NombreContacto;
                    var IdCcontacto = item.idContacto;
                    var CorreoCcontacto = item.Correo;
                    var TelefonoCcontacto = item.Telefono;
                    var UsuarioCcontacto = item.Usuario;
                    var ClaveCcontacto = item.Clave;
                    var idEmpresa = item.idEmpresa;
                    $('#EditarCcontactoForm').append(' <div class= "modal-body"> ' +
                        '<div class="form-group"> ' +
                        '<div class="col-sm-10"> ' +
                        '<input type="hidden" class="form-control" id="txtidCcontactoEditar" value="' + IdCcontacto + '" required /> ' +
                        '</div> ' +
                        '</div> ' +
                        '<div class="form-group"> ' +
                        '<div class="col-sm-10"> ' +
                        '<label>Empresa</label> ' +
                        '<select id="slctEmpresaEditar" class="form-control selectpicker" data-live-search="true"></select>' +
                        '</div> ' +
                        '</div> ' +
                        '<div class="form-group"> ' +
                        '<div class="col-sm-10"> ' +
                        '<label>Nombre contacto</label> ' +
                        '<input type="text" class="form-control" id="txtNombreCcontactoEditar" value="' + NombreCcontacto + '" /> ' +
                        '</div> ' +
                        '</div> ' +
                        '<div class="form-group"> ' +
                        '<div class="col-sm-10"> ' +
                        '<label>Teléfono</label> ' +
                        '<input type="tel" class="form-control" id="txtTelefonoCcontactoEditar" value="' + TelefonoCcontacto + '" required /> ' +
                        '</div> ' +
                        '</div> ' +
                        '<div class="form-group"> ' +
                        '<div class="col-sm-10"> ' +
                        '<label>Correo</label> ' +
                        '<input type="email" class="form-control" id="txtCorreoCcontactoEditar" value="' + CorreoCcontacto + '" required /> ' +
                        '</div> ' +
                        '</div> ' +
                        '<div class="form-group"> ' +
                        '<div class="col-sm-10"> ' +
                        '<label>Usuario</label> ' +
                        '<input type="text" class="form-control" id="txtUsuarioCcontactoEditar" value="' + UsuarioCcontacto + '" required /> ' +
                        '</div> ' +
                        '</div> ' +
                        '<div class="form-group"> ' +
                        '<div class="col-sm-10"> ' +
                        '<label>Clave</label> ' +
                        '<input type="password" class="form-control" id="txtClaveCcontactoEditar" value="' + ClaveCcontacto + '" required /> ' +
                        '</div> ' +
                        '</div> ' +
                        '<div class="form-group"> ' +
                        '<div class="col-sm-10"> ' +
                        '<div class="form-group" id="txtModalEditarMensajeCcontacto"> ' +
                        '</div> ' +
                        '</div> ' +
                        '</div> ' +
                        '</div> ' +
                        '<div class="modal-footer"> ' +
                        '<button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> ' +
                        '<button class="btn btn-primary" id="btnEditarCcontacto" onclick="EditarCcontactoDesdePopUp();" type="button">Guardar cambios</button> ' +
                        '</div > ');
                    CargarEmpresasEditar(idEmpresa);
                    $('#slctEmpresaEditar').val(idEmpresa);
                    $('#slctEmpresaEditar').selectpicker('refresh');
                    

                });


                $("#EditCcontactoModal").modal();

            }
            else {
                $("#EditCcontactoModal").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

            }
        }
    });


}
