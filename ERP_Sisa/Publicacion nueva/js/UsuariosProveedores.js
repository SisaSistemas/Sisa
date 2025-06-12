$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("UsuariosProveedores.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarUsuarios();
        CargarEmpresas();
        //CargarAreas();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }

    function CargarEmpresas() {
        var parametros = "{'pid': '2'}";
        $.ajax({
            dataType: "json",
            url: "UsuariosProveedores.aspx/ObtenerProveedores",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {

                    $('#slctProveedor').html('');
                    var json = JSON.parse(data.d);
                    $('#slctProveedor').html('<option value="-1">-- SELECCIONE PROVEEDOR --</option>');
                    $(json).each(function (index, item) {

                        $("#slctProveedor").append("<option value='" + item.IdProveedor + "' rel='" + item.Email + "'>" + item.Proveedor + "</option>");

                    });
                }
                else {
                    $("#slctProveedor").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }

                $('#slctProveedor').selectpicker('refresh');
                $('#slctProveedor').selectpicker('render');
            }
        });

    }


    $("#slctProveedor").change(function () {

        var IdProveedor = $(this).val();

        var correo = $('#slctProveedor option:selected').attr('rel');
        $('#txtCorreo').val(correo);

        //CargarContactos(idEmpresa);

    });

    function CargarUsuarios() {

        var parametros = "{'pid': '1'}";
        $.ajax({
            dataType: "json",
            url: "UsuariosProveedores.aspx/ObtenerUsuarios",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonArray = $.parseJSON(data.d);

                //$('#TablaOC').bootstrapTable('destroy');

                data = jsonArray;

                $('#TablaUsuarios').bootstrapTable({
                    data: data,
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
            }
        });
    }


    $('#btnGuardarUsuarios').click(function () {
        var slctProveedor = $('#slctProveedor').val();
        var txtCorreo = $('#txtCorreo').val();
        var txtUsuario = $('#txtUsuario').val();
        var txtClaveUsuario = $('#txtClaveUsuario').val();
    
        //checkboxes
        var chkBidVer = $('#chkBidVer').is(':checked');
        var chkBidAdd = $('#chkBidAdd').is(':checked');
        var chkBidEdit = $('#chkBidEdit').is(':checked');
        var chkBidDel = $('#chkBidDel').is(':checked');

        if (txtCorreo == "" || txtUsuario == "" || txtClaveUsuario == "") {
            //$("#AddMsgUsuarios").append('<div class="alert alert-danger fade in"><p>Completa los campos obligatorios.</p></div >');
            swal('Completa los campos obligatorios.');
        }
        else {

            var parametros = "{'pIdProveedor': '" + slctProveedor
                + "', 'pCorreo': '" + txtCorreo
                + "', 'pUsuario': '" + txtUsuario
                + "', 'pClaveUsuario': '" + txtClaveUsuario
                + "', 'chkBidVer': '" + chkBidVer
                + "', 'chkBidAdd': '" + chkBidAdd
                + "', 'chkBidEdit': '" + chkBidEdit
                + "', 'chkBidDel': '" + chkBidDel
                + "'}";
            $.ajax({
                dataType: "json",
                url: "UsuariosProveedores.aspx/GuardarUsuarios",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Proveedor Creado." || msg.d == "Proveedor Modificado.") {
                        //$("#AddMsgUsuarios").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                        CargarUsuarios();
                        swal(msg.d);
                    }
                    else {
                        //$("#AddMsgUsuarios").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                        swal(msg.d);
                    }
                }
            });
        }

    });

    $('#btnEliminarUsuarios').click(function () {
        var idSuc = document.getElementById('idUsuariosEliminar').textContent;

        var parametros = "{'pidUsuarios': '" + idSuc + "'}";
        $.ajax({
            dataType: "json",
            url: "Usuarios.aspx/EliminarUsuarios",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Usuario actualizado.") {
                    //$("#txtModalEliminarMensajeUsuarios").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    CargarUsuarios();
                    swal('Usuario eliminado.');
                }
                else {
                    //$("#txtModalEliminarMensajeUsuarios").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });
    });

    $('#btnFotoUsuarios').click(function () {
        var Foto = $("[id*='ImgPrv']").prop('src');
        var id = document.getElementById('idUsuariosFoto').textContent;
        if (Foto == '' || Foto === null) {
            swal('Elige foto.');
        }
        else {
            var parametros = "{'pid': '" + id + "', 'pFoto': '" + Foto + "'}";
            $.ajax({
                dataType: "json",
                url: "Usuarios.aspx/ActualizarUsuariosFoto",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Datos guardados.") {
                        //$("#ContenedorMensajePerfilGuardado").append('<div class="alert alert-success fade in"><p>' + msg.d +'</p></div >');
                        document.getElementById("ImagenActualUsuarios").src = Foto;
                        $("[id*='ImgPrvUsuarios']").prop('src', '');
                        swal(msg.d);

                    }
                    else {
                        //("#ContenedorMensajePerfilGuardado").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                        swal(msg.d);
                    }
                }
            });
        }


    });

    $('#btnModificarUsuarios').click(function () {
        var txtNombreCompleto = $('#txtNombreCompletoEditar').val();
        var txtCorreoUsuario = $('#txtCorreoUsuarioEditar').val();
        var txtTelefonoUsuarios = $('#txtTelefonoUsuariosEditar').val();
        var txtUsuario = $('#txtUsuarioEditar').val();
        var txtClaveUsuario = $('#txtClaveUsuarioEditar').val();
        var Salario = $('#txtSalarioUsuarioEditar').val();
        var slctTipo = $('#slctTipoEditar').val();
        var slctSucursalUsuario = $('#slctSucursalUsuarioEditar').val();
        var slctEstatus = $('#pEstatus').val();
        //checkboxes
        var chkCliEmpVer = $('#chkCliEmpVerEditar').is(':checked');
        var chkCliEmpAdd = $('#chkCliEmpAddEditar').is(':checked');
        var chkCliEmpEdit = $('#chkCliEmpEditEditar').is(':checked');
        var chkCliEmpDel = $('#chkCliEmpDelEditar').is(':checked');
        var chkCliConVer = $('#chkCliConVerEditar').is(':checked');
        var chkCliConAdd = $('#chkCliConAddEditar').is(':checked');
        var chkCliConEdit = $('#chkCliConEditEditar').is(':checked');
        var chkCliConDel = $('#chkCliConDelEditar').is(':checked');
        var chkRFQVer = $('#chkRFQVerEditar').is(':checked');
        var chkRFQAdd = $('#chkRFQAddEditar').is(':checked');
        var chkRFQEdit = $('#chkRFQEditEditar').is(':checked');
        var chkRFQDel = $('#chkRFQDelEditar').is(':checked');
        var chkCotVer = $('#chkCotVerEditar').is(':checked');
        var chkCotAdd = $('#chkCotAddEditar').is(':checked');
        var chkCotEdit = $('#chkCotEditEditar').is(':checked');
        var chkCotDel = $('#chkCotDelEditar').is(':checked');
        var chkMatVer = $('#chkMatVerEditar').is(':checked');
        var chkMatAdd = $('#chkMatAddEditar').is(':checked');
        var chkMatEdit = $('#chkMatEditEditar').is(':checked');
        var chkMatDel = $('#chkMatDelEditar').is(':checked');
        var chkProvVer = $('#chkProvVerEditar').is(':checked');
        var chkProvAdd = $('#chkProvAddEditar').is(':checked');
        var chkProvEdit = $('#chkProvEditEditar').is(':checked');
        var chkProvDel = $('#chkProvDelEditar').is(':checked');
        var chkRequiVer = $('#chkRequiVerEditar').is(':checked');
        var chkRequiAdd = $('#chkRequiAddEditar').is(':checked');
        var chkRequiEdit = $('#chkRequiEditEditar').is(':checked');
        var chkRequiDel = $('#chkRequiDelEditar').is(':checked');
        var chkOCVer = $('#chkOCVerEditar').is(':checked');
        var chkOCAdd = $('#chkOCAddEditar').is(':checked');
        var chkOCEdit = $('#chkOCEditEditar').is(':checked');
        var chkOCDel = $('#chkOCDelEditar').is(':checked');
        var chkViaVer = $('#chkViaVerEditar').is(':checked');
        var chkViaAdd = $('#chkViaAddEditar').is(':checked');
        var chkViaEdit = $('#chkViaEditEditar').is(':checked');
        var chkViaDel = $('#chkViaDelEditar').is(':checked');
        var chkProyVer = $('#chkProyVerEditar').is(':checked');
        var chkProyAdd = $('#chkProyAddEditar').is(':checked');
        var chkProyEdit = $('#chkProyEditEditar').is(':checked');
        var chkProyDel = $('#chkProyDelEditar').is(':checked');
        var chkCajaVer = $('#chkCajaVerEditar').is(':checked');
        var chkCajaAdd = $('#chkCajaAddEditar').is(':checked');
        var chkCajaEdit = $('#chkCajaEditEditar').is(':checked');
        var chkCajaDel = $('#chkCajaDelEditar').is(':checked');
        var chkUserVer = $('#chkUserVerEditar').is(':checked');
        var chkUserAdd = $('#chkUserAddEditar').is(':checked');
        var chkUserEdit = $('#chkUserEditEditar').is(':checked');
        var chkUserDel = $('#chkUserDelEditar').is(':checked');
        var chkSucVer = $('#chkSucVerEditar').is(':checked');
        var chkSucAdd = $('#chkSucAddEditar').is(':checked');
        var chkSucEdit = $('#chkSucEditEditar').is(':checked');
        var chkSucDel = $('#chkSucDelEditar').is(':checked');
        var chkFacVer = $('#chkFRVerEditar').is(':checked');
        var chkDocsAdd = $('#chkDocsAddEditar').is(':checked');
        var chkAdminVer = $('#chkAdminVerEditar').is(':checked');
        var chkInventaAdd = $('#chkInventaAddEditar').is(':checked');
        var chkTimmEdit = $('#chkTimmEditEditar').is(':checked');
        var chkBoletines = $('#chkBoletinesEditar').is(':checked');
        var chkCarroVer = $('#chkCarroVerEditar').is(':checked');
        var chkPCAdd = $('#chkPCAddEditar').is(':checked');
        var chkFacVerEmitidas = $('#chkFEVerEditar').is(':checked');
        var chkReportes = true;//$('#chkReportesEdit').is(':checked');

        var chkRptOrdenCompra = $('#chkRptOrdenCompraEditar').is(':checked');
        var chkRptFacturasRecibidas = $('#chkRptFacturasRecibidasEditar').is(':checked');
        var chkRptFacturasEmitidas = $('#chkRptFacturasEmitidasEditar').is(':checked');
        var chkRptProyectos = $('#chkRptProyectosEditar').is(':checked');
        var chkRptCotizaciones = $('#chkRptCotizacionesEditar').is(':checked');
        var chkRptProyectosGastos = $('#chkRptProyectosGastosEditar').is(':checked');
        var chkRptProveedoresPagar = $('#chkRptProveedoresPagarEditar').is(':checked');
        var chkRptEficiencias = $('#chkRptEficienciasEditar').is(':checked');

        var chkFRVer = $('#chkFRVerEditar').is(':checked');
        var chkFRAdd = $('#chkFRAddEditar').is(':checked');
        var chkFREdit = $('#chkFREditEditar').is(':checked');
        var chkFRDel = $('#chkFRDelEditar').is(':checked');

        var chkFEVer = $('#chkFEVerEditar').is(':checked');
        var chkFEAdd = $('#chkFEAddEditar').is(':checked');
        var chkFEEdit = $('#chkFEEditEditar').is(':checked');
        var chkFEDel = $('#chkFEDelEditar').is(':checked');

        var txtidUsuariosEditar = $('#btnModificarUsuarios').val();

        var chkEsCCM = $('#chkEsCCM').is(':checked');
        var slctPuestoCCM = $('#slctPuestoCCM').val();
        var slctAreaCCM = $('#slctAreaCCM').val();

        if (txtNombreCompleto == "" || txtCorreoUsuario == "" || txtTelefonoUsuarios == "" || txtUsuario == "" || txtClaveUsuario == "" || Salario == "") {
            //$("#AddMsgUsuarios").append('<div class="alert alert-danger fade in"><p>Completa los campos obligatorios.</p></div >');
            swal('Completa los campos obligatorios.');
        }
        else {
            var parametros = "{ 'pidUsuario':'" + txtidUsuariosEditar
                + "', 'pNombreCompleto': '" + txtNombreCompleto
                + "', 'pCorreoUsuario': '" + txtCorreoUsuario
                + "', 'pTelefonoUsuario': '" + txtTelefonoUsuarios
                + "', 'pClaveUsuario': '" + txtClaveUsuario
                + "', 'pUsuario': '" + txtUsuario
                + "', 'pTipo': '" + slctTipo
                + "', 'pSucursal': '" + slctSucursalUsuario + "',"
                + "'pchkCliEmpVer': '" + chkCliEmpVer + "'"
                + ",'pchkCliEmpAdd': '" + chkCliEmpAdd + "'"
                + ",'pchkCliEmpEdit': '" + chkCliEmpEdit + "'"
                + ",'pchkCliEmpDel': '" + chkCliEmpDel + "'"
                + ",'pchkCliConVer': '" + chkCliConVer + "'"
                + ",'pchkCliConAdd': '" + chkCliConAdd + "'"
                + ",'pchkCliConEdit': '" + chkCliConEdit + "'"
                + ",'pchkCliConDel': '" + chkCliConDel + "'"
                + ",'pchkRFQVer': '" + chkRFQVer + "'"
                + ",'pchkRFQAdd': '" + chkRFQAdd + "'"
                + ",'pchkRFQEdit': '" + chkRFQEdit + "'"
                + ",'pchkRFQDel': '" + chkRFQDel + "'"
                + ",'pchkCotVer': '" + chkCotVer + "'"
                + ",'pchkCotAdd': '" + chkCotAdd + "'"
                + ",'pchkCotEdit': '" + chkCotEdit + "'"
                + ",'pchkCotDel': '" + chkCotDel + "'"
                + ",'pchkMatVer': '" + chkMatVer + "'"
                + ",'pchkMatAdd': '" + chkMatAdd + "'"
                + ",'pchkMatEdit': '" + chkMatEdit + "'"
                + ",'pchkMatDel': '" + chkMatDel + "'"
                + ",'pchkProvVer': '" + chkProvVer + "'"
                + ",'pchkProvAdd': '" + chkProvAdd + "'"
                + ",'pchkProvEdit': '" + chkProvEdit + "'"
                + ",'pchkProvDel': '" + chkProvDel + "'"
                + ",'pchkRequiVer': '" + chkRequiVer + "'"
                + ",'pchkRequiAdd': '" + chkRequiAdd + "'"
                + ",'pchkRequiEdit': '" + chkRequiEdit + "'"
                + ",'pchkRequiDel': '" + chkRequiDel + "'"
                + ",'pchkOCVer': '" + chkOCVer + "'"
                + ",'pchkOCAdd': '" + chkOCAdd + "'"
                + ",'pchkOCEdit': '" + chkOCEdit + "'"
                + ",'pchkOCDel': '" + chkOCDel + "'"
                + ",'pchkViaVer': '" + chkViaVer + "'"
                + ",'pchkViaAdd': '" + chkViaAdd + "'"
                + ",'pchkViaEdit': '" + chkViaEdit + "'"
                + ",'pchkViaDel': '" + chkViaDel + "'"
                + ",'pchkProyVer': '" + chkProyVer + "'"
                + ",'pchkProyAdd': '" + chkProyAdd + "'"
                + ",'pchkProyEdit': '" + chkProyEdit + "'"
                + ",'pchkProyDel': '" + chkProyDel + "'"
                + ",'pchkCajaVer': '" + chkCajaVer + "'"
                + ",'pchkCajaAdd': '" + chkCajaAdd + "'"
                + ",'pchkCajaEdit': '" + chkCajaEdit + "'"
                + ",'pchkCajaDel': '" + chkCajaDel + "'"
                + ",'pchkUserVer': '" + chkUserVer + "'"
                + ",'pchkUserAdd': '" + chkUserAdd + "'"
                + ",'pchkUserEdit': '" + chkUserEdit + "'"
                + ",'pchkUserDel': '" + chkUserDel + "'"
                + ",'pchkSucVer': '" + chkSucVer + "'"
                + ",'pchkSucAdd': '" + chkSucAdd + "'"
                + ",'pchkSucEdit': '" + chkSucEdit + "'"
                + ",'pchkSucDel': '" + chkSucDel + "'"
                + ",'pchkFacVer': '" + chkFacVer + "'"
                + ",'pchkDocsAdd': '" + chkDocsAdd + "'"
                + ",'pchkAdminVer': '" + chkAdminVer + "'"
                + ",'pchkInventaAdd': '" + chkInventaAdd + "'"
                + ",'pchkTimmEdit': '" + chkTimmEdit + "'"
                + ",'pchkBoletines': '" + chkBoletines + "'"
                + ",'pchkCarroVer': '" + chkCarroVer + "'"
                + ",'pchkPCAdd': '" + chkPCAdd + "'"
                + ",'pSalario': '" + Salario + "'"
                + ",'pchkFacVerEmitidas': '" + chkFacVerEmitidas + "'"
                + ",'pReportes': '" + chkReportes + "'"
                + ",'pRptOrdenCompra': '" + chkRptOrdenCompra + "'"
                + ",'pRptFacturasRecibidas': '" + chkRptFacturasRecibidas + "'"
                + ",'pRptFacturasEmitidas': '" + chkRptFacturasEmitidas + "'"
                + ",'pRptProyectos': '" + chkRptProyectos + "'"
                + ",'pRptCotizaciones': '" + chkRptCotizaciones + "'"
                + ",'pRptProyectosGastos': '" + chkRptProyectosGastos + "'"
                + ",'pRptProveedoresPagar': '" + chkRptProveedoresPagar + "'"
                + ",'pchkFRVer': '" + chkFRVer + "'"
                + ",'pchkFRAdd': '" + chkFRAdd + "'"
                + ",'pchkFREdit': '" + chkFREdit + "'"
                + ",'pchkFRDel': '" + chkFRDel + "'"
                + ",'pchkFEVer': '" + chkFEVer + "'"
                + ",'pchkFEAdd': '" + chkFEAdd + "'"
                + ",'pchkFEEdit': '" + chkFEEdit + "'"
                + ",'pchkFEDel': '" + chkFEDel + "'"
                + ",'pRptEficiencias': '" + chkRptEficiencias + "'"
                + ",'pActivo': '" + slctEstatus + "'"
                + ",'pEsCCM': '" + chkEsCCM + "'"
                + ",'pslctPuestoCCM': '" + slctPuestoCCM + "'"
                + ",'pslctAreaCCM': '" + slctAreaCCM + "'"
                + "}";
            //console.log(parametros);
            $.ajax({
                dataType: "json",
                url: "Usuarios.aspx/EditarUsuarios",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Usuario Actualizado.") {
                        //$("#AddMsgUsuarios").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                        CargarUsuarios();
                        swal(msg.d);
                    }
                    else {
                        //$("#AddMsgUsuarios").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                        swal(msg.d);
                    }
                }
            });
        }
    });


});
var id = "";
function accionUsersFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<Button title="Cambiar foto" class="btn btn-default cambiarFoto"><i class="icon_image"></i></Button>',
        '<Button title="Editar" class= "btn btn-success editar"> <i class="icon_pencil"></i></Button>',
        '<Button title="Eliminar" class="btn btn-danger eliminar"><i class="icon_close_alt2"></i></Button>',
        '</div>'
    ].join(' ');
}

function CargarEmpresas(parametro) {
    var parametros = "{'pid': '" + parametro + "'}";

    console.log(parametros);

    $.ajax({
        dataType: "json",
        url: "UsuariosProveedores.aspx/ObtenerProveedores",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {

                $('#slctProveedor').html('');
                var json = JSON.parse(data.d);
                $('#slctProveedor').html('<option value="-1">-- SELECCIONE PROVEEDOR --</option>');
                $(json).each(function (index, item) {

                    $("#slctProveedor").append("<option value='" + item.IdProveedor + "' rel='" + item.Email + "'>" + item.Proveedor + "</option>");

                });
            }
            else {
                $("#slctProveedor").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

            }

            $('#slctProveedor').selectpicker('refresh');
            $('#slctProveedor').selectpicker('render');
        }
    });

}

window.accionUsersEvents = {
    'click .cambiarFoto': function (e, value, row, index) {

        var parametros = "{'pid': '" + row.IdUsuario + "'}";
        $.ajax({
            dataType: "json",
            url: "Usuarios.aspx/ObtenerUsuariosFoto",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {
                        $("[id*='ImagenActualUsuarios']").prop('src', item.Foto);
                    });
                }
                else {
                    //$("#CargandoUsuarios").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');
                    swal('No se obtuvo información.');
                }
            }
        });

        $("#FotoUsuariosModal").modal();
    },
    'click .editar': function (e, value, row, index) {

        var parametros = "{'pid': '" + row.IdProveedor + "'}";
        $.ajax({
            dataType: "json",
            url: "UsuariosProveedores.aspx/ObtenerUsuarios",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.d != "") {

                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {

                        $('#slctProveedor').val(item.IdProveedor);
                        $('#slctProveedor').selectpicker('refresh');
                        $('#slctProveedor').selectpicker('render');

                        $('#slctProveedor').selectpicker('refresh');
                        //$('#slctProveedor').trigger('change');

                        $('#txtCorreo').val(item.Email);
                        $('#txtUsuario').val(item.Usuario);

                        $('#txtClaveUsuario').val(item.Contrasena);

                        //$('#pEstatus').val(item.Activo);

                        //
                        $('#chkBidVer').prop('checked', item.Biddings);
                        $('#chkBidAdd').prop('checked', item.BiddingsAgregar);
                        $('#chkBidEdit').prop('checked', item.BiddingsEditar);
                        $('#chkBidDel').prop('checked', item.BiddingsEliminar);


                        $('#btnGuardarUsuarios').val(item.IdProveedor);

                    });

                    $('#AddUsuariosModal').modal();
                }
                else {
                    $("#CargandoProveedores").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }
            }
        });


    },
    'click .eliminar': function (e, value, row, index) {

        document.getElementById('idUsuariosEliminar').textContent = '';

        document.getElementById('txtModalEliminarUsuarios').textContent = '¿Estás seguro de eliminar el usuario con código "' + row.NombreCompleto + '" ?';

        document.getElementById('idUsuariosEliminar').textContent = row.IdUsuario;

        $("#DelUsuariosModal").modal();
    }
};