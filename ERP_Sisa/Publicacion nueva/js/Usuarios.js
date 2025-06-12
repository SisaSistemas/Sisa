$(document).ready(function () {

    var URLactual = window.location;
    if (URLactual.href.indexOf("Usuarios.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarUsuarios();
        CargarSucursales();
        CargarAreas();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }

    function CargarSucursales() {
        var parametros = "{'pid': '2'}";
        $.ajax({
            dataType: "json",
            url: "Sucursales.aspx/ObtenerSucursales",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    $('#slctSucursalUsuario').html('');
                    var json = JSON.parse(data.d);
                    $("#slctSucursalUsuario").html('');
                    $("#slctSucursalUsuarioEditar").html('');
                    $(json).each(function (index, item) {
                        var IdSucursal = json[index].idSucursa;
                        var CiudadSucursal = json[index].CiudadSucursal;
                        //var jsonItem = "{'idSucursa': '" + IdSucursal + "', 'CiudadSucursal': '" + CiudadSucursal + "', 'DireccionSucursal': '" + DireccionSucursal + "', 'TelefonoSucursal': '" + TelefonoSucursal + "' }";                       
                        $("#slctSucursalUsuario").append("<option value=" + IdSucursal + ">" + CiudadSucursal + "</option>");
                        $("#slctSucursalUsuarioEditar").append("<option value=" + IdSucursal + ">" + CiudadSucursal + "</option>");
                    });
                }
                else {
                    $("#slctSucursalUsuario").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');
                    $("#slctSucursalUsuarioEditar").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }
            }
        });

    }

    function CargarUsuarios() {
        $('tbody#listaUsuarios').empty();
        $('#myPager').html('');
        var parametros = "{'pid': '1'}";
        $.ajax({
            dataType: "json",
            url: "Usuarios.aspx/ObtenerUsuarios",
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
                    idField: 'IdUsuario',
                    uniqueId: 'IdUsuario',
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

                //if (data.d != "") {
                //    var json = JSON.parse(data.d);
                //    $(json).each(function (index, item) {

                //        var IdUsuarios = json[index].IdUsuario;
                //        var NombreUsuario = json[index].NombreCompleto;
                //        var Usuario = json[index].Usuario;
                //        var CorreoUsuario = json[index].Correo;
                //        var TelefonoUsuario = json[index].Telefono;
                //        var TipoUsuario = json[index].Tipo;
                //        var SucursalUsuario = json[index].CiudadSucursal;
                //        //var jsonItem = "{'idSucursa': '" + IdUsuarios + "', 'CiudadUsuarios': '" + CiudadUsuarios + "', 'DireccionUsuarios': '" + DireccionUsuarios + "', 'TelefonoUsuarios': '" + TelefonoUsuarios + "' }";

                //        $('tbody#listaUsuarios').append(
                //            '<tr><td style="display:none;">'
                //            + IdUsuarios
                //            + '</td>'
                //            + '<td>'
                //            + NombreUsuario
                //            + '</td>'
                //            + '<td>'
                //            + Usuario
                //            + '</td><td>'
                //            + TelefonoUsuario
                //            + '</td><td>'
                //            + CorreoUsuario
                //            + '</td>'
                //            + '<td>'
                //            + TipoUsuario
                //            + '</td>'
                //            + '<td>'
                //            + SucursalUsuario
                //            + '</td>'
                //            + '<td>'
                //            + '<div class="btn-group">'
                //            //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> '
                //            + '<Button title="Cambiar foto" class="btn btn-default" value="' + IdUsuarios + '" onclick="FotoUsuarios(this);"><i class="icon_image"></i></Button>'
                //            + '<Button title="Editar" class= "btn btn-success" value="' + IdUsuarios + '" onclick="EditarUsuarios(this);"> <i class="icon_pencil"></i></Button>'
                //            + '<Button title="Eliminar" class="btn btn-danger" value="' + IdUsuarios + '" onclick="EliminarUsuarios(this);"><i class="icon_close_alt2"></i></Button>'
                //            + '</div > '
                //            + '</td>'
                //            + '</tr>')
                //    });
                //    //$('#listaUsuarios').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
                //    $('#TablaUsuarios').DataTable({
                //        "bLengthChange": false,
                //        "pageLength": 100,

                //        "oLanguage": {
                //            "sSearch": "Buscar:"
                //        },
                //        "retrieve": true
                //    });
                //}
                //else {
                //    $("#CargandoUsuarios").append('<div class="alert alert-danger fade in"><p>No se obtuvo información o no tienes permiso de acceso.</p></div >');

                //}
            }
        });
    }

    function CargarAreas() {
        var parametros = "{'pid': '2'}";
        $.ajax({
            dataType: "json",
            url: "Usuarios.aspx/ObtieneAreas",
            async: true,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    $('#slctAreaCCM').html('');
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {
                        $("#slctAreaCCM").append("<option value=" + item.Nombre + ">" + item.Nombre + "</option>");
                    });
                }
                else {
                    $("#slctAreaCCM").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }
            }
        });

    }

    $('#btnGuardarUsuarios').click(function () {
        var txtNombreCompleto = $('#txtNombreCompleto').val();
        var txtCorreoUsuario = $('#txtCorreoUsuario').val();
        var txtTelefonoUsuarios = $('#txtTelefonoUsuarios').val();
        var txtUsuario = $('#txtUsuario').val();
        var txtClaveUsuario = $('#txtClaveUsuario').val();
        var Salario = $('#txtSalarioUsuario').val();
        var slctTipo = $('#slctTipo').val();
        var slctSucursalUsuario = $('#slctSucursalUsuario').val();
        //checkboxes
        var chkCliEmpVer = $('#chkCliEmpVer').is(':checked');
        var chkCliEmpAdd = $('#chkCliEmpAdd').is(':checked');
        var chkCliEmpEdit = $('#chkCliEmpEdit').is(':checked');
        var chkCliEmpDel = $('#chkCliEmpDel').is(':checked');
        var chkCliConVer = $('#chkCliConVer').is(':checked');
        var chkCliConAdd = $('#chkCliConAdd').is(':checked');
        var chkCliConEdit = $('#chkCliConEdit').is(':checked');
        var chkCliConDel = $('#chkCliConDel').is(':checked');
        var chkRFQVer = $('#chkRFQVer').is(':checked');
        var chkRFQAdd = $('#chkRFQAdd').is(':checked');
        var chkRFQEdit = $('#chkRFQEdit').is(':checked');
        var chkRFQDel = $('#chkRFQDel').is(':checked');
        var chkCotVer = $('#chkCotVer').is(':checked');
        var chkCotAdd = $('#chkCotAdd').is(':checked');
        var chkCotEdit = $('#chkCotEdit').is(':checked');
        var chkCotDel = $('#chkCotDel').is(':checked');
        var chkMatVer = $('#chkMatVer').is(':checked');
        var chkMatAdd = $('#chkMatAdd').is(':checked');
        var chkMatEdit = $('#chkMatEdit').is(':checked');
        var chkMatDel = $('#chkMatDel').is(':checked');
        var chkProvVer = $('#chkProvVer').is(':checked');
        var chkProvAdd = $('#chkProvAdd').is(':checked');
        var chkProvEdit = $('#chkProvEdit').is(':checked');
        var chkProvDel = $('#chkProvDel').is(':checked');
        var chkRequiVer = $('#chkRequiVer').is(':checked');
        var chkRequiAdd = $('#chkRequiAdd').is(':checked');
        var chkRequiEdit = $('#chkRequiEdit').is(':checked');
        var chkRequiDel = $('#chkRequiDel').is(':checked');
        var chkOCVer = $('#chkOCVer').is(':checked');
        var chkOCAdd = $('#chkOCAdd').is(':checked');
        var chkOCEdit = $('#chkOCEdit').is(':checked');
        var chkOCDel = $('#chkOCDel').is(':checked');
        var chkViaVer = $('#chkViaVer').is(':checked');
        var chkViaAdd = $('#chkViaAdd').is(':checked');
        var chkViaEdit = $('#chkViaEdit').is(':checked');
        var chkViaDel = $('#chkViaDel').is(':checked');
        var chkProyVer = $('#chkProyVer').is(':checked');
        var chkProyAdd = $('#chkProyAdd').is(':checked');
        var chkProyEdit = $('#chkProyEdit').is(':checked');
        var chkProyDel = $('#chkProyDel').is(':checked');
        var chkCajaVer = $('#chkCajaVer').is(':checked');
        var chkCajaAdd = $('#chkCajaAdd').is(':checked');
        var chkCajaEdit = $('#chkCajaEdit').is(':checked');
        var chkCajaDel = $('#chkCajaDel').is(':checked');
        var chkUserVer = $('#chkUserVer').is(':checked');
        var chkUserAdd = $('#chkUserAdd').is(':checked');
        var chkUserEdit = $('#chkUserEdit').is(':checked');
        var chkUserDel = $('#chkUserDel').is(':checked');
        var chkSucVer = $('#chkSucVer').is(':checked');
        var chkSucAdd = $('#chkSucAdd').is(':checked');
        var chkSucEdit = $('#chkSucEdit').is(':checked');
        var chkSucDel = $('#chkSucDel').is(':checked');
        var chkFacVer = $('#chkFacVer').is(':checked');
        var chkDocsAdd = $('#chkDocsAdd').is(':checked');
        var chkAdminVer = $('#chkAdminVer').is(':checked');
        var chkInventaAdd = $('#chkInventaAdd').is(':checked');
        var chkTimmEdit = $('#chkTimmEdit').is(':checked');
        var chkBoletines = $('#chkBoletines').is(':checked');
        var chkCarroVer = $('#chkCarroVer').is(':checked');
        var chkPCAdd = $('#chkPCAdd').is(':checked');
        var chkFacVerEmitidas = $('#chkFacVerEmitidas').is(':checked');
        var chkReportes = true;//$('#chkReportesEdit').is(':checked');

        var chkRptOrdenCompra = $('#chkRptOrdenCompra').is(':checked');
        var chkRptFacturasRecibidas = $('#chkRptFacturasRecibidas').is(':checked');
        var chkRptFacturasEmitidas = $('#chkRptFacturasEmitidas').is(':checked');
        var chkRptProyectos = $('#chkRptProyectos').is(':checked');
        var chkRptCotizaciones = $('#chkRptCotizaciones').is(':checked');
        var chkRptProyectosGastos = $('#chkRptProyectosGastos').is(':checked');
        var chkRptProveedoresPagar = $('#chkRptProveedoresPagar').is(':checked');
        var chkRptEficiencias = $('#chkRptEficiencias').is(':checked');

        var chkFRVer = $('#chkFRVer').is(':checked');
        var chkFRAdd = $('#chkFRAdd').is(':checked');
        var chkFREdit = $('#chkFREdit').is(':checked');
        var chkFRDel = $('#chkFRDel').is(':checked');

        var chkFEVer = $('#chkFEVer').is(':checked');
        var chkFEAdd = $('#chkFEAdd').is(':checked');
        var chkFEEdit = $('#chkFEEdit').is(':checked');
        var chkFEDel = $('#chkFEDel').is(':checked');

        if (txtNombreCompleto == "" || txtCorreoUsuario == "" || txtTelefonoUsuarios == "" || txtUsuario == "" || txtClaveUsuario == "" || Salario == "") {
            //$("#AddMsgUsuarios").append('<div class="alert alert-danger fade in"><p>Completa los campos obligatorios.</p></div >');
            swal('Completa los campos obligatorios.');
        }
        else {
            var parametros = "{'pNombreCompleto': '" + txtNombreCompleto
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

                + "}";
            $.ajax({
                dataType: "json",
                url: "Usuarios.aspx/GuardarUsuarios",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Usuario creado.") {
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
    
    
    $('#chkEsCCM').change(function () {
        if (this.checked) {
            $('#dvPuestoCCM').show();

            if ($('#slctPuestoCCM').val() == "PM") {
                $('#dvAreaCCM').show();
            }
            else {
                $('#dvAreaCCM').hide();
            }
        }
        else {
            $('#dvPuestoCCM').hide();

            if ($('#dvAreaCCM').is(':visible')) {
                $('#dvAreaCCM').hide();
            }
        }
    });

    $('#slctPuestoCCM').on('change', function () {
        if (this.value == "PM") {
            $('#dvAreaCCM').show();
        }
        else {
            $('#dvAreaCCM').hide();
        }
    });

});

function accionUsersFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<Button title="Cambiar foto" class="btn btn-default cambiarFoto"><i class="icon_image"></i></Button>',
        '<Button title="Editar" class= "btn btn-success editar"> <i class="icon_pencil"></i></Button>',
        '<Button title="Eliminar" class="btn btn-danger eliminar"><i class="icon_close_alt2"></i></Button>',
        '</div>'
    ].join(' ');
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

        var parametros = "{'pid': '" + row.IdUsuario + "'}";
        $.ajax({
            dataType: "json",
            url: "Usuarios.aspx/ObtenerUsuarios",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {

                        $('#txtNombreCompletoEditar').val(item.NombreCompleto);
                        $('#txtCorreoUsuarioEditar').val(item.Correo);
                        $('#txtTelefonoUsuariosEditar').val(item.Telefono);

                        $('#txtSalarioUsuarioEditar').val(item.SueldoDiario);
                        $('#txtUsuarioEditar').val(item.Usuario);
                        $('#txtClaveUsuarioEditar').val(item.Contrasena);

                        $('#slctTipoEditar').val(item.Tipo);
                        $('#slctSucursalUsuarioEditar').val(item.idSucursal);
                        $('#pEstatus').val(item.Activo);

                        $('#chkEsCCM').prop('checked', item.EsCCM);

                        $('#slctPuestoCCM').val(item.PuestoCCM);
                        $('#slctAreaCCM').val(item.AreaCCM);
                        //
                        $('#chkCliEmpVerEditar').prop('checked', item.ClienteEmpresa);
                        $('#chkCliEmpAddEditar').prop('checked', item.ClienteEmpresaAgregar);
                        $('#chkCliEmpEditEditar').prop('checked', item.ClienteEmpresaEditar);
                        $('#chkCliEmpDelEditar').prop('checked', item.ClienteEmpresaEliminar);

                        $('#chkCliConVerEditar').prop('checked', item.ClienteContacto);
                        $('#chkCliConAddEditar').prop('checked', item.ClienteContactoAgrear);
                        $('#chkCliConEditEditar').prop('checked', item.ClienteContactoEditar);
                        $('#chkCliConDelEditar').prop('checked', item.ClienteContactoEliminar);

                        $('#chkRFQVerEditar').prop('checked', item.RFQ);
                        $('#chkRFQAddEditar').prop('checked', item.RFQAgregar);
                        $('#chkRFQEditEditar').prop('checked', item.RFQEditar);
                        $('#chkRFQDelEditar').prop('checked', item.RFQEliminar);

                        $('#chkCotVerEditar').prop('checked', item.Cotizaciones);
                        $('#chkCotAddEditar').prop('checked', item.CotizacionesAgregar);
                        $('#chkCotEditEditar').prop('checked', item.CotizacionesEditar);
                        $('#chkCotDelEditar').prop('checked', item.CotizacionesEliminar);

                        $('#chkMatVerEditar').prop('checked', item.Materiales);
                        $('#chkMatAddEditar').prop('checked', item.MaterialesAgregar);
                        $('#chkMatEditEditar').prop('checked', item.MaterialesEditar);
                        $('#chkMatDelEditar').prop('checked', item.MaterialesEliminar);

                        $('#chkProvVerEditar').attr('checked', item.Proveedores);
                        $('#chkProvAddEditar').prop('checked', item.ProveedoresAgregar);
                        $('#chkProvEditEditar').prop('checked', item.ProveedoresEditar);
                        $('#chkProvDelEditar').prop('checked', item.ProveedoresEliminar);

                        $('#chkRequiVerEditar').prop('checked', item.Requisiciones);
                        $('#chkRequiAddEditar').prop('checked', item.RequisicionesAgregar);
                        $('#chkRequiEditEditar').prop('checked', item.RequisicionesEditar);
                        $('#chkRequiDelEditar').prop('checked', item.RequisicionesEliminar);

                        $('#chkOCVerEditar').prop('checked', item.OC);
                        $('#chkOCAddEditar').prop('checked', item.OCAgregar);
                        $('#chkOCEditEditar').prop('checked', item.OCEditar);
                        $('#chkOCDelEditar').prop('checked', item.OCEliminar);

                        $('#chkViaVerEditar').prop('checked', item.Viaticos);
                        $('#chkViaAddEditar').prop('checked', item.ViaticosAgregar);
                        $('#chkViaEditEditar').prop('checked', item.ViaticosEditar);
                        $('#chkViaDelEditar').prop('checked', item.ViaticosEliminar);

                        $('#chkProyVerEditar').prop('checked', item.Proyectos);
                        $('#chkProyAddEditar').prop('checked', item.ProyectosAgregar);
                        $('#chkProyEditEditar').prop('checked', item.ProyectosEditar);
                        $('#chkProyDelEditar').prop('checked', item.ProyectosEliminar);

                        $('#chkCajaVerEditar').prop('checked', item.CajaChica);
                        $('#chkCajaAddEditar').prop('checked', item.CajaChicaAgregar);
                        $('#chkCajaEditEditar').prop('checked', item.CajaChicaEditar);
                        $('#chkCajaDelEditar').prop('checked', item.CajaChicaEliminar);

                        $('#chkUserVerEditar').prop('checked', item.Usuarios);
                        $('#chkUserAddEditar').prop('checked', item.UsuariosAgregar);
                        $('#chkUserEditEditar').prop('checked', item.UsuariosEditar);
                        $('#chkUserDelEditar').prop('checked', item.UsuariosEliminar);

                        $('#chkSucVerEditar').prop('checked', item.Sucursales);
                        $('#chkSucAddEditar').prop('checked', item.SucursalesAgregar);
                        $('#chkSucEditEditar').prop('checked', item.SucursalesEditar);
                        $('#chkSucDelEditar').prop('checked', item.SucursalesEliminar);

                        $('#chkFRVerEditar').prop('checked', item.FacRecibidas);
                        $('#chkFRAddEditar').prop('checked', item.FacRecibidasAgregar);
                        $('#chkFREditEditar').prop('checked', item.FacRecibidasEditar);
                        $('#chkFRDelEditar').prop('checked', item.FacRecibidasEliminar);

                        $('#chkFEVerEditar').prop('checked', item.FacEmitidas);
                        $('#chkFEAddEditar').prop('checked', item.FacEmitidasAgregar);
                        $('#chkFEEditEditar').prop('checked', item.FacEmitidasEditar);
                        $('#chkFEDelEditar').prop('checked', item.FacEmitidasEliminar);

                        $('#chkDocsAddEditar').prop('checked', item.ControlDocumentos);

                        $('#chkAdminVerEditar').prop('checked', item.Administracion);
                        $('#chkInventaAddEditar').prop('checked', item.Inventario);
                        $('#chkTimmEditEditar').prop('checked', item.Timming);
                        $('#chkBoletinesEditar').prop('checked', item.Boletines);

                        $('#chkCarroVerEditar').prop('checked', item.ServiciosCarro);
                        $('#chkPCAddEditar').prop('checked', item.ServiciosComputo);

                        $('#chkRptOrdenCompraEditar').prop('checked', item.rptOrdenCompra);
                        $('#chkRptFacturasRecibidasEditar').prop('checked', item.rptFacturasRecibidas);
                        $('#chkRptFacturasEmitidasEditar').prop('checked', item.chkRptFacturasEmitidas);
                        $('#chkRptProyectosEditar').prop('checked', item.rptProyectos);

                        $('#chkRptCotizacionesEditar').prop('checked', item.rptCotizaciones);
                        $('#chkRptProyectosGastosEditar').prop('checked', item.rptProyectosGastos);
                        $('#chkRptProveedoresPagarEditar').prop('checked', item.rptProveedoresPagar);
                        $('#chkRptEficienciasEditar').prop('checked', item.rptEficiencias);
                        $('#btnModificarUsuarios').val(item.IdUsuario);

                    });

                    if ($('#chkEsCCM').is(":checked")) {
                        $('#dvPuestoCCM').show();
                        if ($('#slctPuestoCCM').val() == "PM") {
                            $('#dvAreaCCM').show();
                        }
                        else {
                            $('#dvAreaCCM').hide();
                        }
                    }
                    else {
                        $('#dvPuestoCCM').hide();
                        $('#dvAreaCCM').hide();
                    }

                    $('#EditarUsuariosModal').modal();
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