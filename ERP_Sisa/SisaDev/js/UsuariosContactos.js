$(document).ready(function () {
    
    var URLactual = window.location;
    if (URLactual.href.indexOf("UsuariosContactos.aspx") > -1) {

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
            url: "UsuariosContactos.aspx/ObtenerEmpresas",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {

                    $('#slctEmpresa').html('');
                    var json = JSON.parse(data.d);
                    $('#slctEmpresa').html('<option value="-1">-- SELECCIONE EMPRESA --</option>');
                    $(json).each(function (index, item) {
                       
                        $("#slctEmpresa").append("<option value=" + item.idEmpresa + ">" + item.RazonSocial + "</option>");

                    });
                }
                else {
                    $("#slctEmpresa").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }

                $('#slctEmpresa').selectpicker('refresh');
                $('#slctEmpresa').selectpicker('render');
            }
        });

    }

    function CargarContactos(idEmpresa) {
        var params = "{'IdEmpresa': '" + idEmpresa + "'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'UsuariosContactos.aspx/ObtenerContactos',
            data: params,
            success: function (data, textStatus) {

                var json = $.parseJSON(data.d);

                $('#slctContacto').html('');
                $('#slctContacto').html('<option value="-1">-- SELECCIONE CONTACTO --</option>');
                $.each(json, function (index, value) {
                    $("#slctContacto").append('<option value="' + value.idContacto + '" rel="' + value.Correo + '"  name="' + value.Usuario + '" data-subtext="' + value.Clave + '">' + value.NombreContacto + '</option>');
                    //$('#txtPrecio').val(value.Precio);
                });
                $('#slctContacto').selectpicker('refresh');
                $('#slctContacto').selectpicker('render');

                console.log(id);
                if (id != "") {

                    $('#slctContacto').val(id);

                    $('#slctContacto').selectpicker('refresh');
                    $('#slctContacto').selectpicker('render');
                }
            }
        });
    }

    $("#slctEmpresa").change(function () {

        var idEmpresa = $(this).val();

        CargarContactos(idEmpresa);

    });

    $("#slctContacto").change(function () {

        var idContacto = $(this).val();

        var usuario = $('#slctContacto option:selected').attr('name');
        var correo = $('#slctContacto option:selected').attr('rel');
        var clave = $('#slctContacto option:selected').attr('data-subtext');

        $('#txtCorreo').val(correo);
        $('#txtUsuario').val(usuario);
        $('#txtClaveUsuario').val(clave);
        $('#slctContacto').selectpicker('refresh');

    });

    function CargarUsuarios() {

        var parametros = "{'pid': '1'}";
        $.ajax({
            dataType: "json",
            url: "UsuariosContactos.aspx/ObtenerUsuarios",
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
                    idField: 'idContacto',
                    uniqueId: 'idContacto',
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
        var slctContacto = $('#slctContacto').val();
        var txtCorreo = $('#txtCorreo').val();
        var txtUsuario = $('#txtUsuario').val();
        var txtClaveUsuario = $('#txtClaveUsuario').val();
        var slctTipo = $('#slctTipo').val();
        //checkboxes
        var chkCotiVer = $('#chkCotiVer').is(':checked');
        var chkCotiAdd = $('#chkCotiAdd').is(':checked');
        var chkCotiEdit = $('#chkCotiEdit').is(':checked');
        var chkCotiDel = $('#chkCotiDel').is(':checked');
        var chkProyectosVer = $('#chkProyectosVer').is(':checked');
        var chkPaquetesVer = $('#chkPaquetesVer').is(':checked');
        var chkPaquetesAdd = $('#chkPaquetesAdd').is(':checked');
        var chkPaquetesEdit = $('#chkPaquetesEdit').is(':checked');
        var chkPaquetesDel = $('#chkPaquetesDel').is(':checked');

        if (txtCorreo == "" || txtUsuario == "" || txtClaveUsuario == "") {
            //$("#AddMsgUsuarios").append('<div class="alert alert-danger fade in"><p>Completa los campos obligatorios.</p></div >');
            swal('Completa los campos obligatorios.');
        }
        else {
            var intchkCotiVer = 0;
            var intchkCotiAdd = 0;
            var intchkCotiEdit = 0;
            var intchkCotiDel = 0;
            var intchkProyectosVer = 0;
            var intchkPaquetesVer = 0;
            var intchkPaquetesAdd = 0;
            var intchkPaquetesEdit = 0;
            var intchkPaquetesDel = 0;

            if (chkCotiVer) {
                intchkCotiVer = 1;
            }

            if (chkCotiAdd) {
                intchkCotiAdd = 1;
            }

            if (chkCotiEdit) {
                intchkCotiEdit = 1;
            }

            if (chkCotiDel) {
                intchkCotiDel = 1;
            }

            if (chkProyectosVer) {
                intchkProyectosVer = 1;
            }

            if (chkPaquetesVer) {
                intchkPaquetesVer = 1;
            }

            if (chkPaquetesAdd) {
                intchkPaquetesAdd = 1;
            }

            if (chkPaquetesEdit) {
                intchkPaquetesEdit = 1;
            }

            if (chkPaquetesDel) {
                intchkPaquetesDel = 1;
            }

            var parametros = "{'pIdContacto': '" + slctContacto
                + "', 'pCorreo': '" + txtCorreo
                + "', 'pUsuario': '" + txtUsuario
                + "', 'pClaveUsuario': '" + txtClaveUsuario
                + "', 'pTipo': '" + slctTipo
                + "', 'pchkCotiVer': '" + intchkCotiVer
                + "', 'pchkCotiAdd': '" + intchkCotiAdd
                + "', 'pchkCotiEdit': '" + intchkCotiEdit
                + "', 'pchkCotiDel': '" + intchkCotiDel
                + "', 'pchkProyectosVer': '" + intchkProyectosVer
                + "', 'pchkPaquetesVer': '" + intchkPaquetesVer
                + "', 'pchkPaquetesAdd': '" + intchkPaquetesAdd
                + "', 'pchkPaquetesEdit': '" + intchkPaquetesEdit
                + "', 'pchkPaquetesDel': '" + intchkPaquetesDel
                + "'}";
            $.ajax({
                dataType: "json",
                url: "UsuariosContactos.aspx/GuardarUsuarios",
                async: true,
                data: parametros,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "Contacto creado." || msg.d == "Contacto Modificado.") {
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

        var parametros = "{'pid': '" + row.idContacto + "'}";
        $.ajax({
            dataType: "json",
            url: "UsuariosContactos.aspx/ObtenerUsuarios",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                
                if (data.d != "") {
                    
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {

                        id = item.idContacto;
                        $('#slctEmpresa').val(item.idEmpresa);
                        $('#slctEmpresa').selectpicker('refresh');
                        $('#slctEmpresa').selectpicker('render');

                        $('#slctEmpresa').selectpicker('refresh');
                        $('#slctEmpresa').trigger('change');

                        
                        $('#slctContacto').val(item.idContacto);
                        $('#slctContacto').selectpicker('refresh');
                        $('#slctContacto').selectpicker('render');

                        $('#txtCorreo').val(item.Correo);
                        $('#txtUsuario').val(item.Usuario);

                        $('#txtClaveUsuario').val(item.Clave);
                       
                        $('#slctTipo').val(item.Tipo);

                        //$('#pEstatus').val(item.Activo);

                        //
                        $('#chkCotiVer').prop('checked', item.Cotizaciones);
                        $('#chkCotiAdd').prop('checked', item.CotizacionesAgregar);
                        $('#chkCotiEdit').prop('checked', item.CotizacionesEditar);
                        $('#chkCotiDel').prop('checked', item.CotizacionesEliminar);

                        $('#chkProyectosVer').prop('checked', item.Proyectos);
                        $('#chkPaquetesVer').prop('checked', item.Paquetes);
                        $('#chkPaquetesAdd').prop('checked', item.PaquetesAgregar);
                        $('#chkPaquetesEdit').prop('checked', item.PaquetesEditar);
                        $('#chkPaquetesDel').prop('checked', item.PaquetesEliminar);
                       
                        $('#btnGuardarUsuarios').val(item.idContacto);

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