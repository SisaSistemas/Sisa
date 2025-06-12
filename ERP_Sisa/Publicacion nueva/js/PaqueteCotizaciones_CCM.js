$(document).ready(function () {
    var URLactual = window.location;

    var _idpaquete = getUrlVars()["idPaquete"];

    if (URLactual.href.indexOf("PaqueteCotizaciones.aspx") > - 1) {
        CargarCotizacionesPaquete();
        if (_idpaquete == "0") {
            document.getElementById("btnAsignarPorcentaje").disabled = true;
        }
        else {
            document.getElementById("btnAsignarPorcentaje").disabled = false;
        }
    }

});

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

function CargaCotizacionesIrapuato() {
    $.ajax({
        dataType: "json",
        url: "PaqueteCotizaciones.aspx/ObtieneCotizacionesIrapuato",
        async: true,
        //data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var jsonArray = $.parseJSON(data.d);

            //$('#TablaOC').bootstrapTable('destroy');

            data = jsonArray;

            $('#TablaCotizacionIrapuato').bootstrapTable({
                data: data,
                detailView: false,
                striped: true,
                //pagination: true,
                //onlyInfoPagination: true,
                pageSize: 5,
                idField: 'IdCotizaciones',
                uniqueId: 'IdCotizaciones',
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
        }
    });
}

function CargaCotizacionesChihuahua() {
    $.ajax({
        dataType: "json",
        url: "PaqueteCotizaciones.aspx/ObtieneCotizacionesChihuahua",
        async: true,
        //data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var jsonArray = $.parseJSON(data.d);

            //$('#TablaOC').bootstrapTable('destroy');

            data = jsonArray;

            $('#TablaCotizacionChihu').bootstrapTable({
                data: data,
                detailView: false,
                striped: true,
                //pagination: true,
                //onlyInfoPagination: true,
                pageSize: 5,
                idField: 'IdCotizaciones',
                uniqueId: 'IdCotizaciones',
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
        }
    });
}

function CargaCotizacionesCuautitlan() {
    $.ajax({
        dataType: "json",
        url: "PaqueteCotizaciones.aspx/ObtieneCotizacionesCuautitlan",
        async: true,
        //data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var jsonArray = $.parseJSON(data.d);

            //$('#TablaOC').bootstrapTable('destroy');

            data = jsonArray;

            $('#TablaCotizacionCuau').bootstrapTable({
                data: data,
                detailView: false,
                striped: true,
                //pagination: true,
                //onlyInfoPagination: true,
                pageSize: 5,
                idField: 'IdCotizaciones',
                uniqueId: 'IdCotizaciones',
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
        }
    });
}

function CargaCotizacionesHSAP() {
    $.ajax({
        dataType: "json",
        url: "PaqueteCotizaciones.aspx/ObtieneCotizacionesHSAP",
        async: true,
        //data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var jsonArray = $.parseJSON(data.d);

            //$('#TablaOC').bootstrapTable('destroy');

            data = jsonArray;

            $('#TablaCotizacionHSAP').bootstrapTable({
                data: data,
                detailView: false,
                striped: true,
                //pagination: true,
                //onlyInfoPagination: true,
                pageSize: 5,
                idField: 'IdCotizaciones',
                uniqueId: 'IdCotizaciones',
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
        }
    });
}

function CargarCotizacionesPaquete() {
    $.ajax({
        dataType: "json",
        url: "PaqueteCotizaciones.aspx/CargaCotizacionesPaquete",
        async: true,
        //data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var jsonArray = $.parseJSON(data.d);

            //$('#TablaOC').bootstrapTable('destroy');

            data = jsonArray;

            $('#TablaCotizacionPaquete').bootstrapTable({
                data: data,
                detailView: false,
                striped: true,
                //pagination: true,
                //onlyInfoPagination: true,
                pageSize: 10,
                idField: 'IdCotizaciones',
                uniqueId: 'IdCotizaciones',
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

            CargaCotizacionesHSAP();
            CargaCotizacionesIrapuato();
            CargaCotizacionesChihuahua();
            CargaCotizacionesCuautitlan();
        }
    });
}

function TotalFormatter(items) {
    var totalPrice = 0;
    //debugger;
    items.forEach(function (item) {
        totalPrice = parseFloat(totalPrice) + parseFloat(item.CostoCotizaciones);
    });

    return '$' + parseFloat(totalPrice).toLocaleString(undefined, {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2
    });
};

function accionCotHSAPFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Agregar cotizacion a paquete" class="' + row.Estilo + '" > <i class="tagsinput-add"></i></span>',
        '</div>'
    ].join(' ');
}

function accionCotIrapuatoFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Agregar cotizacion a paquete" class="' + row.Estilo + '" > <i class="tagsinput-add"></i></span>',
        '</div>'
    ].join(' ');
}

function accionCotChihuFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Agregar cotizacion a paquete" class="' + row.Estilo + '" > <i class="tagsinput-add"></i></span>',
        '</div>'
    ].join(' ');
}

function accionCotCuauFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Agregar cotizacion a paquete" class="' + row.Estilo + '" > <i class="tagsinput-add"></i></span>',
        '</div>'
    ].join(' ');
}

function accionCotPaqueteFormatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Eliminar cotizacion de paquete" class="btn btn-warning EliminarCotizacion"> <i class="icon_close_alt2"></i></span>',
        '</div>'
    ].join(' ');
}

window.accionCotEvents = {
    'click .AgregarCotizacion': function (e, value, row, index) {
        //debugger;
        var params = "{'IdCotizaciones': '" + row.IdCotizaciones + "'}";
        console.log(e.currentTarget.className);
        if (e.currentTarget.className.includes("AgregarCotizacion")) {
            $.ajax({
                dataType: "json",
                async: true,
                url: "PaqueteCotizaciones.aspx/AgregarCotizacion",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    //location.href = './frmProjects.aspx';
                    $('#TablaCotizacionPaquete').bootstrapTable('destroy');
                    CargarCotizacionesPaquete();
                    //debugger;
                    if (row.IdEmpresa.toUpperCase() == 'E9A70DAC-356F-4AD0-988A-9CC3D8D88DB8') {
                        $('#TablaCotizacionHSAP').bootstrapTable('destroy');
                        CargaCotizacionesHSAP();
                    }
                    if (row.IdEmpresa.toUpperCase() == '11C3483C-8E3C-4956-A6AC-A6BD908D896A' || 
                        row.IdEmpresa.toUpperCase() == '0227A2C1-D05B-49F1-9EA2-FF0C77667CC1') {
                        
                        $('#TablaCotizacionIrapuato').bootstrapTable('destroy');
                        CargaCotizacionesIrapuato();
                    }
                    if (row.IdEmpresa.toUpperCase() == '9DBA90B1-192D-4536-B79C-B86FDFF45CD3') {
                        $('#TablaCotizacionChihu').bootstrapTable('destroy');
                        CargaCotizacionesChihuahua();
                    }
                    if (row.IdEmpresa.toUpperCase() == '9DB0E133-FEFA-497D-899A-FAD6526AB652') {
                        $('#TablaCotizacionCuau').bootstrapTable('destroy');
                        CargaCotizacionesCuautitlan();
                    }

                    //e.currentTarget.className = 'btn btn-warning EliminarCotizacion';
                    //e.currentTarget.addEventListener("click", function () {
                    //    this.removeClass("btn btn-success AgregarCotizacion").addClass("btn btn-warning EliminarCotizacion");
                    //});
                    //console.log(e.currentTarget.classname);
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
    },
    'click .EliminarCotizacion': function (e, value, row, index) {

        var params = "{'IdCotizaciones': '" + row.IdCotizaciones + "'}";
        console.log(e.currentTarget.className);
        $.ajax({
            dataType: "json",
            async: true,
            url: "PaqueteCotizaciones.aspx/EliminarCotizacion",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                //location.href = './frmProjects.aspx';
                $('#TablaCotizacionPaquete').bootstrapTable('destroy');
                CargarCotizacionesPaquete();

                if (row.IdEmpresa.toUpperCase() == 'E9A70DAC-356F-4AD0-988A-9CC3D8D88DB8') {
                    $('#TablaCotizacionHSAP').bootstrapTable('destroy');
                    CargaCotizacionesHSAP();
                }
                if (row.IdEmpresa.toUpperCase() == '11C3483C-8E3C-4956-A6AC-A6BD908D896A' ||
                    row.IdEmpresa.toUpperCase() == '0227A2C1-D05B-49F1-9EA2-FF0C77667CC1') {

                    $('#TablaCotizacionIrapuato').bootstrapTable('destroy');
                    CargaCotizacionesIrapuato();
                }
                if (row.IdEmpresa.toUpperCase() == '9DBA90B1-192D-4536-B79C-B86FDFF45CD3') {
                    $('#TablaCotizacionChihu').bootstrapTable('destroy');
                    CargaCotizacionesChihuahua();
                }
                if (row.IdEmpresa.toUpperCase() == '9DB0E133-FEFA-497D-899A-FAD6526AB652') {
                    $('#TablaCotizacionCuau').bootstrapTable('destroy');
                    CargaCotizacionesCuautitlan();
                }

                //e.currentTarget.className = 'btn btn-success AgregarCotizacion';
                //e.currentTarget.addEventListener();
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

window.accionCotPaqueteEvents = {
    'click .EliminarCotizacion': function (e, value, row, index) {
        var params = "{'IdCotizaciones': '" + row.IdCotizaciones + "'}";

        $.ajax({
            dataType: "json",
            async: true,
            url: "PaqueteCotizaciones.aspx/EliminarCotizacion",
            data: params,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                //location.href = './frmProjects.aspx';
                $('#TablaCotizacionPaquete').bootstrapTable('destroy');
                CargarCotizacionesPaquete();

                if (row.IdEmpresa.toUpperCase() == 'E9A70DAC-356F-4AD0-988A-9CC3D8D88DB8') {
                    $('#TablaCotizacionHSAP').bootstrapTable('destroy');
                    CargaCotizacionesHSAP();
                }
                if (row.IdEmpresa.toUpperCase() == '11C3483C-8E3C-4956-A6AC-A6BD908D896A' ||
                    row.IdEmpresa.toUpperCase() == '0227A2C1-D05B-49F1-9EA2-FF0C77667CC1') {

                    $('#TablaCotizacionIrapuato').bootstrapTable('destroy');
                    CargaCotizacionesIrapuato();
                }
                if (row.IdEmpresa.toUpperCase() == '9DBA90B1-192D-4536-B79C-B86FDFF45CD3') {
                    $('#TablaCotizacionChihu').bootstrapTable('destroy');
                    CargaCotizacionesChihuahua();
                }
                if (row.IdEmpresa.toUpperCase() == '9DB0E133-FEFA-497D-899A-FAD6526AB652') {
                    $('#TablaCotizacionCuau').bootstrapTable('destroy');
                    CargaCotizacionesCuautitlan();
                }

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

$('#btnGuardarPaquete').click(function () {
    $.ajax({
        dataType: "json",
        url: "PaqueteCotizaciones.aspx/GuardaPaquete",
        async: true,
        //data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            swal({
                title: msg.d,
                timer: 2000
            }).then(() => {
                //$('#TablaCotizacion').bootstrapTable('destroy');
                //CargarCotizaciones();
                //CargarOrdenesCompra();
                //location.reload(true);

                document.getElementById("btnAsignarPorcentaje").disabled = false;

            }).catch(swal.noop);
        }
    });
});

$('#btnAsignarPorcentaje').click(function () {
    $.ajax({
        async: true,
        url: "PaqueteCotizaciones.aspx/ObtienePorcentaje",
        dataType: "json",
        //data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var jsonArray = $.parseJSON(data.d);

            $('#txtPorcentaje').val(jsonArray);
        }

    });

    $("#GaleriaPorcentajeModal").modal();
});

$('#btnGuardaPorcentaje').click(function () {
    
    var params = "{'_porcentaje': '" + $('#txtPorcentaje').val() + "'}";

    $.ajax({
        dataType: "json",
        url: "PaqueteCotizaciones.aspx/GuardaPorcentaje",
        async: true,
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            //swal({
            //    title: msg.d,
            //    timer: 2000
            //}).then(() => {
            //    //$('#TablaCotizacion').bootstrapTable('destroy');
            //    //CargarCotizaciones();
            //    //CargarOrdenesCompra();
            //    location.reload(true);

            //}).catch(swal.noop);
        }
    });
});