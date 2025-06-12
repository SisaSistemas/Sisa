$(document).ready(function () {
    var URLactual = window.location;
    var item = 0;

    

    if (URLactual.href.indexOf("SolicitudBidding.aspx") > -1) {
        CargaAreas();
        CargarProveedoresPermitidos();
    }
    //debugger;

    function CargaAreas() {
        $.ajax({
            dataType: "json",
            url: "SolicitudBidding.aspx/ObtieneAreas",
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
        //var _fecha = $('#dtFecha').val();
        //if (_fecha == '') {
        //    swal('Selecciona la fecha antes de continuar!!!');
        //    return;
        //}

        var _planta = document.getElementById('slctPlanta').value;
        if (_planta == '0') {
            swal('Es necesario elegir una planta!!!');
            return;
        }

        var _area = '';
        var a = document.getElementById('slctAreas');
        if (a.value == '0') {
            swal('Es necesario seleccionar el Area para poder continuar!!!');
            return;
        }
        else {
            _area = a.value;
        }
       

        var _resumen = $('#txtResumen').val();
        if (_resumen == '') {
            swal('Es necesario ingresar el Resumen para poder continuar!!!');
            return;
        }

        var _fechaLimite = $('#dtFechaLimite').val();
        if (_fechaLimite == '') {
            swal('Es necesario seleccionar la Fecha limite para poder continuar!!!');
            return;
        }
        
       
        var parametros = "{'_planta': '" + _planta + "', '_idArea': '" + _area + "', '_resumen': '" + _resumen + "', '_fechaLimite': '" + _fechaLimite + "', '_idSolicitud': '" + IdSolicitud + "'}";
        $.ajax({
            dataType: "json",
            url: "SolicitudBidding.aspx/GuardaSolicitud",
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

});

var IdSolicitud = getUrlVars()["idSolicitud"]; //"lgalvez01";
//var accion = getUrlVars()["Accion"];

function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

function CargarProveedores() {
    $.ajax({
        dataType: "json",
        url: "SolicitudBidding.aspx/ObtieneProveedores",
        async: true,
        //data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var jsonArray = $.parseJSON(data.d);

            //$('#TablaOC').bootstrapTable('destroy');

            data = jsonArray;

            $('#TablaProveedores').bootstrapTable({
                data: data,
                detailView: false,
                striped: true,
                //pagination: true,
                //onlyInfoPagination: true,
                pageSize: 5,
                idField: 'IdProveedor',
                uniqueId: 'IdProveedor',
                onSearch: function (text) {
                    //CargarResumen(text);
                },
                onExpandRow: function (index, row, $detail) {

                },
                onCollapseRow: function (index, row, $detail) {
                    //$detail.clone().insertAfter($detail).fadeOut('slow', function () {
                    //    $(this).remove()
                    //})
                }
            });
        }
    });
}

function CargarProveedoresPermitidos() {
    $.ajax({
        dataType: "json",
        url: "SolicitudBidding.aspx/CargaProveedoresPermitidos",
        async: true,
        //data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var jsonArray = $.parseJSON(data.d);

            //$('#TablaOC').bootstrapTable('destroy');

            data = jsonArray;

            $('#TablaProveedoresPermitidos').bootstrapTable({
                data: data,
                detailView: false,
                striped: true,
                //pagination: true,
                //onlyInfoPagination: true,
                pageSize: 5,
                idField: 'IdProveedor',
                uniqueId: 'IdProveedor',
                onSearch: function (text) {
                    //CargarResumen(text);
                },
                onExpandRow: function (index, row, $detail) {
                    //$detail.hide().html(row.IdMaterial).fadeIn('slow');
                },
                onCollapseRow: function (index, row, $detail) {
                    //$detail.clone().insertAfter($detail).fadeOut('slow', function () {
                    //    $(this).remove()
                    //})
                }
            });

            CargarProveedores();
            //CargaCotizacionesIrapuato();
            //CargaCotizacionesChihuahua();
            //CargaCotizacionesCuautitlan();
        }
    });
}

function accionCotHSAPFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Agregar Proveedor" class="' + row.Estilo + '" > <i class="tagsinput-add"></i></span>',
        '</div>'
    ].join(' ');
}

window.accionCotEvents = {
    'click .AgregarProveedor': function (e, value, row, index) {
        //debugger;
        var params = "{'IdProveedor': '" + row.IdProveedor + "'}";
        
        if (e.currentTarget.className.includes("AgregarProveedor")) {
            $.ajax({
                dataType: "json",
                async: true,
                url: "SolicitudBidding.aspx/AgregarProveedor",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    //location.href = './frmProjects.aspx';
                    $('#TablaProveedoresPermitidos').bootstrapTable('destroy');
                    CargarProveedoresPermitidos();
                    //debugger;

                    $('#TablaProveedores').bootstrapTable('destroy');
                    CargarProveedores();

                    swal({
                        title: msg.d,
                        timer: 2000
                    }).then(() => {


                    }).catch(swal.noop);
                },
                error: function (xhr, ajaxOptions, thrownError) {

                }
            });
        }
    },
    'click .EliminarProveedor': function (e, value, row, index) {

        var params = "{'IdProveedor': '" + row.IdProveedor + "'}";

        $.ajax({
            dataType: "json",
            async: true,
            url: "SolicitudBidding.aspx/EliminarProveedor",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                //location.href = './frmProjects.aspx';
                $('#TablaProveedoresPermitidos').bootstrapTable('destroy');
                CargarProveedoresPermitidos();

                $('#TablaProveedores').bootstrapTable('destroy');
                CargarProveedores();


                swal({
                    title: msg.d,
                    timer: 2000
                }).then(() => {
                    //$('#TablaCotizacion').bootstrapTable('destroy');
                    //CargarCotizaciones();
                    //CargarOrdenesCompra();
                    //location.reload(true);
                }).catch(swal.noop);



            },
            error: function (xhr, ajaxOptions, thrownError) {

            }
        });
    }

}

function accionSolFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Eliminar Proveedor" class="btn btn-warning EliminarProveedor"> <i class="icon_close_alt2"></i></span>',
        '</div>'
    ].join(' ');
}

window.accionSolEvents = {
    'click .EliminarProveedor': function (e, value, row, index) {
        var params = "{'IdProveedor': '" + row.IdProveedor + "'}";

        $.ajax({
            dataType: "json",
            async: true,
            url: "SolicitudBidding.aspx/EliminarProveedor",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                //location.href = './frmProjects.aspx';
                $('#TablaProveedoresPermitidos').bootstrapTable('destroy');
                CargarProveedoresPermitidos();

                $('#TablaProveedores').bootstrapTable('destroy');
                CargarProveedores();
                

                swal({
                    title: msg.d,
                    timer: 2000
                }).then(() => {
                    //$('#TablaCotizacion').bootstrapTable('destroy');
                    //CargarCotizaciones();
                    //CargarOrdenesCompra();
                    //location.reload(true);
                }).catch(swal.noop);



            },
            error: function (xhr, ajaxOptions, thrownError) {

            }
        });
    }
}