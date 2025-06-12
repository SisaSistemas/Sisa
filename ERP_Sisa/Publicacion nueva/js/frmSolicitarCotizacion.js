$(document).ready(function () {
    var URLactual = window.location;
    var item = 0;
    if (URLactual.href.indexOf("frmSolicitudCotizacion.aspx") > -1) {
        CargaAreas();
    }

    function CargaAreas() {
        $.ajax({
            dataType: "json",
            url: "frmSolicitudCotizacion.aspx/ObtieneAreas",
            async: true,
            //data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    $("#slctAreas").append('<option value="0">Selecciona el Area...</option>');

                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {
                        var idArea = json[index].idArea;
                        var NombreArea = json[index].Nombre;
                        var Activo = json[index].Activo;
                        //var jsonItem = "{'idSucursa': '" + IdSucursal + "', 'CiudadSucursal': '" + CiudadSucursal + "', 'DireccionSucursal': '" + DireccionSucursal + "', 'TelefonoSucursal': '" + TelefonoSucursal + "' }";                       
                        $("#slctAreas").append('<option value="' + idArea.toUpperCase() + '">' + NombreArea.toUpperCase() + '</option>');
                    });
                    $('#slctAreas').selectpicker('refresh');
                    $('#slctAreas').selectpicker('render');
                }
                else {
                    $("#CargandoEmpresa").append('<div class="alert alert-danger fade in"><p>No se obtuvo información o no tienes permiso de acceso.</p></div >');

                }
            }
        });
    }

    $('#btnGuardarSolicitud').click(function () {

        var _planta = document.getElementById('slctPlanta').value;
        if (_planta == '0') {
            swal('Es necesario elegir una planta!!!');
            return;
        }
        var _otherText = document.getElementById('txtDescTipo').value;
        var _tipo = document.getElementById('slctTipo').value;
        if (_tipo == '0') {
            swal('Es necesario elegir un tipo!!!');
            return;
        }
        else if (_tipo == "OTHER" && _otherText == '') {
            swal('Es necesario describir un tipo!!!');
            return;
        }

        var _nombreRequisitor = $('#txtNombreRequisitor').val();
        if (_nombreRequisitor == '') {
            swal('Es necesario ingresar el Nombre del requisitor para continuar!!!');
            return;
        }
        var _cdsid = $('#txtCDSID').val();
        if (_cdsid == '') {
            swal('Es necesario ingresar el CSD ID para poder continuar!!');
            return;
        }
        var _telefono = $('#txtTelefonoRequisitor').val();
        //if (_telefono == '') {
        //    swal('Es necesario ingresar el Telefono para poder continuar!!!');
        //    return;
        //}
        var _area = '';
        var a = document.getElementById('slctAreas');
        if (a.value == '0') {
            swal('Es necesario seleccionar el Area para poder continuar!!!');
            return;
        }
        else {
            _area = a.value;
        }
        var _objetivo = '';
        if ($('#rbtnBudget').is(':checked')) {
            _objetivo = 'Budget';
        }
        else {
            if ($('#rbtnProyecto').is(':checked')) {
                _objetivo = 'Proyecto';
            }
            else {
                if ($('#rbtnMantenimiento').is(':checked')) {
                    _objetivo = 'Mantenimiento';
                }
                else {
                    if ($('#rbtnSeguridad').is(':checked')) {
                        _objetivo = 'Seguridad';
                    }
                    else {
                        if ($('#rbtnEmergencia').is(':checked')) {
                            _objetivo = 'Emergencia';
                        }
                        else {
                            if ($('#rbtnSingleSource').is(':checked')) {
                                _objetivo = 'SingleSource';
                            }
                        }
                    }
                }
            }
        }
        if (_objetivo == '') {
            swal('Es necesario seleccionar el Objetivo para poder continuar!!!');
            return;
        }
        var _resumen = $('#txtResumen').val();
        if (_resumen == '') {
            swal('Es necesario ingresar el Resumen para poder continuar!!!');
            return;
        }
        var _fechaVisita = $('#dtFechaVisita').val();
        if (_fechaVisita == '') {
            swal('Es necesario seleccionar la Fecha de visita para poder continuar!!!');
            return;
        }
        var _horaVisita = $('#dtHoraVisita').val();
        if (_horaVisita == '') {
            swal('Es necesario seleccionar la Hora de visita para poder continuar!!!');
            return;
        }
        //var _fechaEntrega = $('#dtFechaEntrega').val();
        //if (_fechaEntrega == '') {
        //    swal('Es necesario seleccionar la Fecha de entrega para poder continuar!!!');
        //    return;
        //}
        var _ubicacionTrabajo = $('#txtUbicacionTrabajo').val();
        if (_ubicacionTrabajo == '') {
            swal('Es necesario ingresar la Ubicacion del trabajo para poder continuar!!!');
            return;
        }
        var parametros = "{'_nombreRequisitor': '" + _nombreRequisitor +
            "', '_cdsid': '" + _cdsid +
            "', '_telefono': '" + _telefono +
            "', '_idArea': '" + _area +
            "', '_objetivo': '" + _objetivo +
            "', '_resumen': '" + _resumen +
            "', '_fechaVisita': '" + _fechaVisita +
            "', '_horaVisita': '" + _horaVisita +
            "', '_ubicacionTrabajo': '" + _ubicacionTrabajo +
            "', '_otherText': '" + _otherText +
            "', '_planta': '" + _planta + "'}";

        $.ajax({
            dataType: "json",
            url: "frmSolicitudCotizacion.aspx/GuardaSolicitud",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                var cadena = msg.d.split('.');
                //debugger;
                if (cadena[0] == "idSolicitudCotizacion") {
                    //redireccionar a la pagina del listado de las cotizaciones
                    window.location.replace('frmSolicitudesCotizaciones.aspx');
                }
                else {
                    swal(msg.d);
                }
            }
        });
    });

    $('#dvDescTipo').hide();

    $("#slctTipo").change(function () {

        var Tipo = $(this).val();

        if (Tipo == "OTHER") {
            $('#txtDescTipo').val('');
            $('#dvDescTipo').show();
        }
        else {
            $('#txtDescTipo').val(Tipo);
            $('#dvDescTipo').hide();
        }

    });

    $('#iFoto').hover(function (e) {
        //var x = e.pageX;
        //var y = e.pageY;

        //$('<div class="marcofoto"><img src="../img/Inclusions.png"></div>"').appendTo('body');

        //var altoImagen = $('.marcofoto img').height();

        //$('.marcofoto').css({ 'left': x - 50 + 'px', 'top': y - altoImagen - 25 + 'px' });

        $('#imgModal').modal();
    });

});