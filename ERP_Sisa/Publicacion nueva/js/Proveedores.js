$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("Proveedores.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarProveedores();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }


});

function mayus(e) {
    e.value = e.value.toUpperCase();
}

function CargarProveedores() {
    //$('tbody#listaProveedores').empty();
    //$('#myPager').html('');
    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "Proveedores.aspx/ObtenerProveedores",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = JSON.parse(data.d);

                $('#TablaProveedores').bootstrapTable({
                    data: json,
                    detailView: false,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'IdProveedor',
                    uniqueId: 'IdProveedor',
                    onSearch: function (text) {
                        //CargarResumen(text);
                    },
                    onExpandRow: function (index, row, $detail) {
                        //$detail.hide().html(row.IdMaterial).fadeIn('slow');
                    },
                    onCollapseRow: function (index, row, $detail) {
                        $detail.clone().insertAfter($detail).fadeOut('slow', function () {
                            $(this).remove()
                        })
                    }
                });


                //$(json).each(function (index, item) {
                //    var idProveedores = json[index].IdProveedor;
                //    var NombreCom = json[index].NombreComercial;
                //    var Proveedor = json[index].Proveedor;
                //    var Contacto = json[index].Contacto;
                //    var Email = json[index].Email;
                //    var tel = json[index].Telefono1;
                //    var cel = json[index].Telefono2;
                //    var RFC = json[index].RFC;
                //    $('tbody#listaProveedores').append(
                //        '<tr><td style="display:none;">'
                //        + idProveedores
                //        + '</td>'
                //        + '<td>'
                //        + NombreCom
                //        + '</td>'
                //        + '<td>'
                //        + Proveedor
                //        + '</td>'
                //        + '<td>'
                //        + RFC
                //        + '</td>'
                //        + '<td>'
                //        + Contacto
                //        + '</td>'
                //        + '<td>'
                //        + Email
                //        + '</td>'
                //        + '<td>'
                //        + tel
                //        + '</td>'
                //        //+ '<td>'
                //        //+ cel
                //        //+ '</td>'
                //        + '<td>'
                //        + '<div class="btn-group">'
                //        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                //        + '<Button class= "btn btn-success" value="' + idProveedores + '" onclick="EditarProveedores(this);"> <i class="icon_pencil"></i></Button>'
                //        + '<Button class="btn btn-danger" value="' + idProveedores + '" onclick="EliminarProveedores(this);"><i class="icon_close_alt2"></i></Button>'
                //        + '</div > '
                //        + '</td>'
                //        + '</tr>')
                //});
                ////$('#listaProveedores').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
                //$('#TablaProveedores').DataTable({
                //    "bLengthChange": false,
                //    "pageLength": 100,

                //    "oLanguage": {
                //        "sSearch": "Buscar:"
                //    },
                //    "retrieve": true
                //});
            }
            else {
                $("#CargandoProveedores").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

            }
        }
    });
}

$('#btnGuardarProveedores').click(function () {
    var txtCreditoProv = $('#txtCreditoProv').val();
    var txtDireccionProveedor = $('#txtDireccionProveedor').val();
    var txtContactoProveedor = $('#txtContactoProveedor').val();
    var txtCorreoProveedor = $('#txtCorreoProveedor').val();
    var txtTelefonoProveedores = $('#txtTelefonoProveedores').val();
    var txtNombreComercial = $('#txtNombreComercial').val();
    var txtNombreProveedor = $('#txtNombreProveedor').val();
    var txtRFCProveedor = $('#txtRFCProveedor').val();
    var txtUsuario = $('#txtUsuario').val();
    var txtClave = $('#txtClaveUsuario').val();
    var txtTipoEmpresa = $('#txtTipoEmpresa').val();

    if (txtNombreProveedor == "") {
        swal("Favor de llenar el campo Razon Social");
        return;
    }

    if (txtNombreComercial == "") {
        swal("Favor de llenar el campo Nombre Comercial");
        return;
    }

    if (txtRFCProveedor == "") {
        swal("Favor de llenar el campo RFC");
        return;
    }

    if (txtTelefonoProveedores == "") {
        swal("Favor de llenar el campo Telefono");
        return;
    }

    if (txtCorreoProveedor == "") {
        swal("Favor de llenar el campo Correo");
        return;
    }

    if (txtContactoProveedor == "") {
        swal("Favor de llenar el campo Contacto");
        return;
    }

    if (txtDireccionProveedor == "") {
        swal("Favor de llenar el campo Direccion");
        return;
    }

    if (txtCreditoProv == "") {
        swal("Favor de llenar el campo Dias de Credito");
        return;
    }

    if (txtUsuario == "") {
        swal("Favor de llenar el campo Usuario");
        return;
    }

    if (txtClave == "") {
        swal("Favor de llenar el campo Clave");
        return;
    }

    if (txtTipoEmpresa == "") {
        swal("Favor de llenar el campo Tipo o Perfil de Empresa");
    }

    
    var parametros = "{'pNombre': '" + txtNombreProveedor + "', 'pComercial': '" + txtNombreComercial + "', 'pTelefono': '" + txtTelefonoProveedores + "'" + ", 'pCorreo': '" + txtCorreoProveedor + "'" + ", 'pContacto': '" + txtContactoProveedor + "'" + ", 'pDireccion': '" + txtDireccionProveedor + "' " + ", 'pCredito': '" + txtCreditoProv + "', 'pRFC': '" + txtRFCProveedor + "', 'pUsuario': '" + txtUsuario + "', 'pClave': '" + txtClave + "', 'pTipoEmpresa': '" + txtTipoEmpresa + "'}";
    $.ajax({
        dataType: "json",
        url: "Proveedores.aspx/GuardarProveedores",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Proveedor creado.") {
                //$("#AddMsgProveedores").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                CargarProveedores();
                swal(msg.d);
            }
            else {
                //$("#AddMsgProveedores").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
    

});

$('#btnEliminarProveedores').click(function () {
    var idPro = document.getElementById('idProveedoresEliminar').textContent;

    var parametros = "{'pidProveedores': '" + idPro + "'}";
    $.ajax({
        dataType: "json",
        url: "Proveedores.aspx/EliminarProveedores",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Proveedor eliminado.") {
                //$("#txtModalEliminarMensajeProveedores").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                CargarProveedores();
                swal(msg.d);
            }
            else {
                // $("#txtModalEliminarMensajeProveedores").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
});

window.accionEvents = {
    'click .editarProveedores': function (e, value, row, index) {

        //idMaterial = row.IdProveedor;

        $('#btnEditarProveedores').show();
        $('#btnGuardarProveedores').hide();

        var parametros = "{'pid': '" + row.IdProveedor + "'}";
        $.ajax({
            dataType: "json",
            url: "Proveedores.aspx/ObtenerProveedores",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {

                        $('#txtNombreProveedor').val(item.Proveedor);
                        $('#txtNombreComercial').val(item.NombreComercial);
                        $('#txtRFCProveedor').val(item.RFC);

                        $('#txtTelefonoProveedores').val(item.Telefono1);
                        $('#txtCorreoProveedor').val(item.Email);
                        $('#txtContactoProveedor').val(item.Contacto);

                        $('#txtDireccionProveedor').val(item.Domicilio);
                        $('#txtCreditoProv').val(item.DiasCredito);

                        $('#txtUsuario').val(item.Usuario);
                        $('#txtClaveUsuario').val(item.Contrasena);

                        $('#txtTipoEmpresa').val(item.PerfilEmpresa);
                        
                        $('#btnEditarProveedores').val(item.IdProveedor);
                        
                    });

                    $('#AddProveedoresModal').modal();
                }
                else {
                    $("#CargandoProveedores").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }
            }
        });
    },
    'click .eliminarProveedores': function (e, value, row, index) {

        document.getElementById('idProveedoresEliminar').textContent = '';
        //$('#txtModalEliminarProveedores').append('<p>¿Estás seguro de eliminar requisición con código "' + btn.value + '"?</p>');         
        document.getElementById('idProveedoresEliminarTexto').textContent = '¿Estás seguro de eliminar proveedor  "' + row.NombreComercial + '"?';
        document.getElementById('idProveedoresEliminar').textContent = row.IdProveedor;
        $("#DelProveedoresModal").modal();

    }
};

function accionFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Editar Proveedores" class="btn btn-success editarProveedores"><i class="icon_pencil"></i></span>',
        '<span title="Eliminar Proveedores" class="btn btn-danger eliminarProveedores"><i class="icon_close_alt2"></i></span>',
        '</div>'
    ].join(' ');
}

$('#btnAgregarProveedor').click(function () {
    $('#btnEditarProveedores').hide();
    $('#btnGuardarProveedores').show();
});

$('#btnEditarProveedores').click(function () {
    var idProveedor = $(this).val();
    var txtCreditoProv = $('#txtCreditoProv').val();
    var txtDireccionProveedor = $('#txtDireccionProveedor').val();
    var txtContactoProveedor = $('#txtContactoProveedor').val();
    var txtCorreoProveedor = $('#txtCorreoProveedor').val();
    var txtTelefonoProveedores = $('#txtTelefonoProveedores').val();
    var txtNombreComercial = $('#txtNombreComercial').val();
    var txtNombreProveedor = $('#txtNombreProveedor').val();
    var txtRFCProveedor = $('#txtRFCProveedor').val();
    var txtUsuario = $('#txtUsuario').val();
    var txtClave = $('#txtClaveUsuario').val();
    var txtTipoEmpresa = $('#txtTipoEmpresa').val();

    if (txtNombreProveedor == "") {
        swal("Favor de llenar el campo Razon Social");
        return;
    }

    if (txtNombreComercial == "") {
        swal("Favor de llenar el campo Nombre Comercial");
        return;
    }

    if (txtRFCProveedor == "") {
        swal("Favor de llenar el campo RFC");
        return;
    }

    if (txtTelefonoProveedores == "") {
        swal("Favor de llenar el campo Telefono");
        return;
    }

    if (txtCorreoProveedor == "") {
        swal("Favor de llenar el campo Correo");
        return;
    }

    if (txtContactoProveedor == "") {
        swal("Favor de llenar el campo Contacto");
        return;
    }

    if (txtDireccionProveedor == "") {
        swal("Favor de llenar el campo Direccion");
        return;
    }

    if (txtCreditoProv == "") {
        swal("Favor de llenar el campo Dias de Credito");
        return;
    }

    if (txtUsuario == "") {
        swal("Favor de llenar el campo Usuario");
        return;
    }

    if (txtClave == "") {
        swal("Favor de llenar el campo Clave");
        return;
    }

    if (txtTipoEmpresa == "") {
        swal("Favor de llenar el campo Tipo o Perfil de Empresa");
    }

    var parametros = "{'pid': '" + idProveedor +
        "','pNombre': '" + txtNombreProveedor +
        "', 'pComercial': '" + txtNombreComercial +
        "', 'pTelefono': '" + txtTelefonoProveedores +
        "', 'pCorreo': '" + txtCorreoProveedor +
        "', 'pContacto': '" + txtContactoProveedor +
        "', 'pDireccion': '" + txtDireccionProveedor +
        "', 'pCredito': '" + txtCreditoProv +
        "', 'pRFC': '" + txtRFCProveedor +
        "', 'pUsuario': '" + txtUsuario +
        "', 'pClave': '" + txtClave +
        "', 'pTipoEmpresa': '" + txtTipoEmpresa + "'}";

    $.ajax({
        dataType: "json",
        url: "Proveedores.aspx/EditarProveedores",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Proveedor actualizado.") {
                //$("#txtModalEditarMensajeProveedores").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                CargarProveedores(); //llamada a function en Proveedores.js
                swal(msg.d);
            }
            else {
                //("#txtModalEditarMensajeProveedores").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });


});
