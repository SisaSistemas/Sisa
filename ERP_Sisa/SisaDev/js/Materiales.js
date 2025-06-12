$(document).ready(function () {
    var URLactual = window.location;
    var arrayImagenes = [];
    if (URLactual.href.indexOf("Materiales.aspx") > -1) {
        //$('#loading').show();
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        //here palce your code
        CargarMateriales();
        CargarCategorias();
        //i set timeout that you can view the change
        //you must use below code without setTimeout function
        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);

        //CargarProveedores();
        //$('#loading').hide();
    }

});
//var $rows = $('#TablaMateriales td');
//$('#search').keyup(function () {
//    var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

//    $rows.show().filter(function () {
//        var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
//        return !~text.indexOf(val);
//    }).hide();
//});

function mayus(e) {
    e.value = e.value.toUpperCase();
}

function CargarMateriales() {
    //$('tbody#listaMateriales').empty();
    //$('#myPager').html('');

    var parametros = "{'pid': '1'}";
    $.ajax({
        dataType: "json",
        url: "Materiales.aspx/ObtenerMateriales",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != "") {
                var json = $.parseJSON(data.d);//JSON.parse(data.d);

                $('#TablaMateriales').bootstrapTable({
                    data: json,
                    detailView: false,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'IdMaterial',
                    uniqueId: 'IdMaterial',
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
                //    var idMateriales = json[index].IdMaterial;
                //    var NoMateriales = json[index].Codigo;
                //    var DescripcionMaterial = json[index].Descripcion;
                //    var Categoria = json[index].Categoria;
                //    var Buscador = json[index].Buscador;
                //    var USuario = json[index].Usuario;
                //    // var FechaM = json[index].FechaModificacion;


                //    $('tbody#listaMateriales').append(
                //        '<tr><td style="display:none;">'
                //        + idMateriales
                //        + '</td>'
                //        + '<td>'
                //        + NoMateriales
                //        + '</td>'
                //        + '<td>'
                //        + DescripcionMaterial
                //        + '</td>'
                //        + '<td>'
                //        + Categoria
                //        + '</td>'
                //        + '<td>'
                //        + Buscador
                //        + '</td>'
                //        + '<td>'
                //        + USuario
                //        + '</td>'
                //        + '<td>'
                //        + '<div class="btn-group">'
                //        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> 'icon_images
                //        + '<Button title="Ver Proveedores" class= "btn btn-default" value="' + idMateriales + '" onclick="VerProveedoresPrecios(this);"> <i class="icon_profile"></i></Button>'
                //        + '<Button title="Agregar Proveedores" class= "btn btn-info" value="' + idMateriales + '" onclick="VerProveedores(this);"> <i class="icon_profile"></i></Button>'
                //        + '</div > '
                //        + '</td>'
                //        + '<td>'
                //        + '<div class="btn-group">'
                //        //+'<a class= "btn btn-primary" href = "#" > <i class="icon_plus_alt2"></i></a> 'icon_images
                //        + '<Button title="Editar" class= "btn btn-success" value="' + idMateriales + '" onclick="EditarMateriales(this);"> <i class="icon_pencil"></i></Button>'
                //        + '<Button title="Inactivar" class="btn btn-danger" value="' + idMateriales + '" onclick="EliminarMateriales(this);"><i class="icon_close_alt2"></i></Button>'
                //        + '<Button title="Ver foto" class="btn btn-warning" value="' + idMateriales + '" onclick="Verimagenes(this);"><i class="icon_images"></i></Button>'
                //        + '</div > '
                //        + '</td>'
                //        + '</tr>')
                //});
                //// $('#listaMateriales').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: true, perPage: 100 });
                //$('#TablaMateriales').DataTable({
                //    "bLengthChange": false,
                //    "pageLength": 100,
                //    "order": [[2, "asc"]],
                //    "oLanguage": {
                //        "sSearch": "Buscar:",
                //        "sInfo": "Mostrando _START_ a _END_ de _TOTAL_ registros",
                //        "sInfoFiltered": "(filtrado de _MAX_ total de registros)",
                //        "oPaginate": {
                //            "sNext": "Siguiente",
                //            "sPrevious": "Anterior"
                //        }
                //    },
                //    "retrieve": true,
                //});

            }
            else {
                $("#CargandoMateriales").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

            }
        }
    });
}

function CargarCategorias() {
    var params = "{'Opcion': '" + 4 + "'}"

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'Materiales.aspx/CargarCategorias',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbCategoria').html('');
            $('#cmbCategoria').html("<option value=-1>-- SELECCIONE CATEGORIA --</option>");
            $.each(json, function (index, value) {
                $("#cmbCategoria").append("<option value='" + value.Id + "'>" + value.Nombre.toUpperCase() + "</option>");
                //$('#txtPrecio').val(value.Precio);
            });

        }
    });
}

$('#btnAddFiles').click(function () {

    swal({
        title: 'Seleccione la imagen',
        input: 'file',
        allowOutsideClick: false,
        allowEnterKey: false,
        allowEscapeKey: false,
        showCloseButton: true,
        inputAttributes: {
            'accept': 'image/*',
            'aria-label': 'Upload your profile picture'
        }
    }).then(function (file) {
        var objImagenes = {};
        var reader = new FileReader
        var size = file.size;
        var nombre = file.name;
        var fileExtension = file.name.substring(file.name.indexOf("."));

        reader.onload = function (e) {
            //AddFiles(nombre, fileExtension, size, e.target.result);
            swal({
                title: 'Tu foto cargada',
                imageUrl: e.target.result,
                imageAlt: 'La imagen'
            });

            var img = e.target.result;
            $('#rowImagenes').append('<div class="col-md-55"> ' +
                '<div class="thumbnail"> ' +
                '<div class="image view view-first"> ' +
                '<img style="width: 20%; height: 10%; display: block;" src="' + e.target.result + '" alt="image" /> ' +
                '<div class="mask"> ' +
                '<p></p> ' +
                '<div class="tools tools-bottom"> ' +
                '<a><i class="fa fa-search verImagen" rel="' + e.target.result + '" title="' + nombre + '"></i></a> ' +
                '</div> ' +
                '</div> ' +
                '</div> ' +
                '<div class="caption"> ' +
                '<p>' + nombre + '</p> ' +
                '</div> ' +
                '</div> ' +
                '</div>');

            objImagenes["FileName"] = nombre;
            objImagenes["FileExtension"] = fileExtension;
            objImagenes["FileSize"] = size;
            objImagenes["base64"] = e.target.result;

            arrayImagenes.push(objImagenes);
        }
        reader.readAsDataURL(file)
    })
});

$('#btnAgregarMaterial').click(function () {
    $('#btnEditarMateriales').hide();
    $('#btnGuardarMateriales').show();
});

$('#btnGuardarMateriales').click(function () {
    
    //if ($('#txtNoMaterial').val() == '') {
    //    swal('Proporciona, número o código de material.');
    //    return;
    //}

    //if ($('#txtCodigoProveedor').val() == '') {
    //    swal('Proporciona, el codigo del proveedor.');
    //    return;
    //}

    if ($('#txtDescripcionMateriales').val() == '') {
        swal('Proporciona, descripción de material.');
        return;
    }    

    if ($('#cmbCategoria').val() == '-1') {
        swal('Elige categoria');
        return;
    }

    var params = "{'IdMaterial': '" + 0 + "" +
        "','Descripcion': '" + $('#txtDescripcionMateriales').val() +
        "','IdCategoria': '" + $('#cmbCategoria').val() +
        "','CodigoProveedor': '" + $('#txtCodigoProveedor').val() +
        "','Tipo': '1','IdUsuario': '0'}";

    //console.log(params);

    //var params = "{'IdMaterial': '" + 0 + "'" +
    //    ",'Codigo': '" + $('#txtNoMaterialEditar').val() +
    //    "','Descripcion': '" + $('#txtDescripcionMaterialesEditar').val() +
    //    "','IdCategoria': '" + $('#cmbCategoria2').val() +
    //    "','Buscador': '" + $('#txtBuscadorMaterialesEditar').val() +
    //    "','Tipo': '2','IdUsuario': '0'}";

    $.ajax({
        dataType: "json",
        async: true,
        url: "Materiales.aspx/GuardarMaterial",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            //location.href = "./frmMateriales.aspx";
            var datos = "";
            var idMaterial = "";
            var cadena = data.d.split('.');
            if (cadena[0] == "Material agregado") {
                idMaterial = cadena[1];
                var contImagenes = $('#rowImagenes').find('img').length;
                var contImgInsertadas = 0;
                if (contImagenes > 0) {
                    $.each(arrayImagenes, function (key, value) {

                        var param = "{'IdMaterial': '" + idMaterial + "'" +
                            ",'FileName': '" + value.FileName +
                            "','FileExtension': '" + value.FileExtension +
                            "','FileSize': '" + value.FileSize +
                            "','imagen64': '" + value.base64 +
                            "','IdUsuario': '0'}";

                        $.ajax({
                            dataType: "json",
                            async: true,
                            url: "Materiales.aspx/GuardarImagenes",
                            data: param,
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data, textStatus) {

                                contImgInsertadas++;

                                if (contImgInsertadas == contImagenes) {

                                    swal('Material agregado');
                                    //CargarMateriales();
                                    location.reload();
                                }

                            },
                            error: function (xhr, ajaxOptions, thrownError) {

                            }
                        });


                    });
                }
                else {

                    swal('Material agregado');
                    //CargarMateriales();
                    location.reload();
                }
            }
            else {
                swal(data.d);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    });

});

$('#btnEliminarMateriales').click(function () {
    var id = document.getElementById('idMaterialesEliminar').textContent;

    var parametros = "{'pidMateriales': '" + id + "'}";
    $.ajax({
        dataType: "json",
        url: "Materiales.aspx/EliminarMateriales",
        async: true,
        data: parametros,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            if (msg.d == "Materiales eliminada.") {
                //$("#txtModalEliminarMensajeMateriales").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                // CargarMateriales();
                swal(msg.d);
                location.reload();
            }
            else {
                // $("#txtModalEliminarMensajeMateriales").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                swal(msg.d);
            }
        }
    });
});

$('#btnEditarMateriales').click(function () {
    if ($('#txtDescripcionMateriales').val() == '') {
        swal('Proporciona, descripción de material.');
        return;
    }

    if ($('#cmbCategoria').val() == '-1') {
        swal('Elige categoria');
        return;
    }

    var params = "{'IdMaterial': '" + idMaterial + "" +
        "','Descripcion': '" + $('#txtDescripcionMateriales').val() +
        "','IdCategoria': '" + $('#cmbCategoria').val() +
        "','CodigoProveedor': '" + $('#txtCodigoProveedor').val() +
        "','Tipo': '2','IdUsuario': '0'}";

    //console.log(params);

    $.ajax({
        dataType: "json",
        async: true,
        url: "Materiales.aspx/GuardarMaterial",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            //location.href = "./frmMateriales.aspx";
            var datos = "";
            var cadena = data.d.split('.');
            if (cadena[0] == "Material actualizado") {
                var contImagenes = $('#rowImagenes2').find('img').length;
                var contImgInsertadas = 0;
                if (contImagenes > 0) {
                    $.each(arrayImagenes2, function (key, value) {

                        var param = "{'IdMaterial': '" + idMaterial + "'" +
                            ",'FileName': '" + value.FileName +
                            "','FileExtension': '" + value.FileExtension +
                            "','FileSize': '" + value.FileSize +
                            "','imagen64': '" + value.base64 +
                            "','IdUsuario': '0'}";

                        $.ajax({
                            dataType: "json",
                            async: true,
                            url: "Materiales.aspx/GuardarImagenes",
                            data: param,
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data, textStatus) {

                                contImgInsertadas++;

                                if (contImgInsertadas == contImagenes) {
                                    swal('Material actualizado');
                                }

                            },
                            error: function (xhr, ajaxOptions, thrownError) {

                            }
                        });


                    });
                }
                else {

                    swal('Material actualizado');
                    //CargarMateriales();
                    location.reload();
                }
            }
            else {
                swal(data.d);
            }

        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    });
});

$('#btnProveedoresMateriales').click(function () {
    var id = document.getElementById('idMaterialProveedor').textContent;

    var params = "{'IdProveedorMaterial': '" + $('#cmbProveedorMaterial').val() +
        "','IdProveedor': '" + $('#cmbProveedorMaterial').val() +
        "','IdMaterial': '" + id +
        "','UnidadMedida': '" + $('#txtUnidadMaterial').val() +
        "','Precio': '" + $('#txtPrecioMaterial').val().replace(',', '') +
        "','IdMoneda': '" + $('#cmbMonedaMaterial').val() +
        "','IdUsuario': '0'}";

    $.ajax({
        dataType: "json",
        async: true,
        url: "Materiales.aspx/GuardarProveedorMaterial",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {
            if (data.d == 'Proveedor agregado.') {
                swal(data.d);
            } else {
                swal(data.d);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    });
});

window.accionMat1Events = {
    'click .verProveedores': function (e, value, row, index) {

        var idMaterial = row.IdMaterial;

        var parametros = "{'pid': '" + idMaterial + "'}";

        $.ajax({
            dataType: "json",
            url: "Materiales.aspx/ObtenerMaterialesPrecios",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    //debugger;
                    $('tbody#listaMaterialesPrecios').html('');
                    $(json).each(function (index, item) {
                        //var FechaM = json[index].FechaModificacion;
                        $('tbody#listaMaterialesPrecios').append(
                            '<tr><td style="display:none;">'
                            + json[index].IdProveedorMaterial
                            + '</td>'
                            + '<td>'
                            + json[index].Proveedor
                            + '</td>'
                            + '<td>'
                            + json[index].UnidadMedida
                            + '</td>'
                            + '<td>'
                            + formato_numero(json[index].Precio, 2, '.', ',')
                            + '</td>'
                            + '<td>'
                            + json[index].Moneda
                            + '</td>'
                            + '<td>'
                            + json[index].Usuario
                            + '</td>'
                            + '<td>'
                            + json[index].FechaModificacion.substring(0, 10)
                            + '</td>'
                            + '<td>'
                            + '<span class="btn btn-success icon_pencil cambiarpreciomaterial"></span>'
                            + '</td>'
                            + '</tr>')
                    });
                    $("#VistaPMaterialesModal").modal();
                    //$('#listaMateriales').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: false, perPage: 100 });
                }
                else {
                    swal('No se pudo obtener información.');

                }
            }
        });
    },
    'click .addProveedores': function (e, value, row, index) {
        var idMaterial = row.IdMaterial;

        var params = "{'Opcion': '9'}";

        $.ajax({
            dataType: 'json',
            async: true,
            contentType: "application/json; charset=utf-8",
            type: 'POST',
            url: 'Materiales.aspx/CargarProveedores',
            data: params,
            success: function (data, textStatus) {

                var json = $.parseJSON(data.d);

                $('#cmbProveedorMaterial').html('');
                $('#cmbProveedorMaterial').html('<option value="-1">-- SELECCION PROVEEDOR --</option>');
                $.each(json, function (index, value) {
                    $("#cmbProveedorMaterial").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
                });
                $('#cmbProveedorMaterial').selectpicker('refresh');
                $('#cmbProveedorMaterial').selectpicker('render');
            }
        });
        var parametros = "{'pid': '" + idMaterial + "'}";
        $.ajax({
            dataType: "json",
            url: "Materiales.aspx/ObtenerMateriales",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    var Descripcion = "";
                    $(json).each(function (index, item) {

                        Descripcion = item.Descripcion
                    });
                    document.getElementById('idMaterialProveedor').textContent = idMaterial;
                    document.getElementById('ProveedoresVistaMateriales').textContent = Descripcion;
                    $("#ProveedoresMaterialesModal").modal();
                }
                else {
                    swal('No se obtuvo información.');
                }
            }
        });
    }
};

var idCategoriaEditar = "";
var idMaterial = "";

window.accionMat2Events = {
    'click .editar': function (e, value, row, index) {
        idMaterial = row.IdMaterial;
        
        $('#btnEditarMateriales').show();
        $('#btnGuardarMateriales').hide();
        //$('#EditarMaterialesForm').empty();
        var parametros = "{'pid': '" + idMaterial + "'}";
        $.ajax({
            dataType: "json",
            url: "Materiales.aspx/ObtenerMateriales",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);

                    $(json).each(function (index, item) {

                        $('#txtNoMaterial').val(item.NoMaterial);
                        $('#txtCodigoProveedor').val(item.Codigo);
                        $('#txtDescripcionMateriales').val(item.Descripcion);

                        //$('#EditarMaterialesForm').append('<div class= "modal-body"> ' +
                        //    '<div class= "form-group"> ' +
                        //    '<div class= "col-sm-10"> ' +
                        //    '<label>No. Material</label> ' +
                        //    '<input type="text" value="' + item.Codigo + '" class="form-control" placeholder="No. Material" id="txtNoMaterialEditar" readonly /> ' +
                        //    '</div> ' +
                        //    '</div> ' +
                        //    '<div class="form-group"> ' +
                        //    '<div class="col-sm-10"> ' +
                        //    '<label>Codigo Proveedor</label> ' +
                        //    '<input type="tel" class="form-control" value="' + item.Codigo + '" placeholder="Codigo Proveedor" id="txtCodigoProveedor" required /> ' +
                        //    '</div> ' +
                        //    '</div> ' +
                        //    '<div class="form-group"> ' +
                        //    '<div class="col-sm-10"> ' +
                        //    '<label>Descripción</label> ' +
                        //    '<input type="text" class="form-control" value="' + item.Descripcion + '" placeholder="Descripción" id="txtDescripcionMaterialesEditar" required /> ' +
                        //    '</div> ' +
                        //    '</div> ' +
                        //    '<div class= "form-group"> ' +
                        //    '<div class="col-sm-10"> ' +
                        //    '<label>Categoria</label> ' +
                        //    '<select class="form-control" id="cmbCategoria2"></select> ' +
                        //    '</div> ' +
                        //    '</div> ' +
                        //    '<div class="form-group"> ' +
                        //    '<div class="col-sm-10"> ' +
                        //    '<button type="button" class="btn btn-info" id="btnAddFiles2" onclick="AgregarFotoEditar();">Agregar fotos</button> ' +
                        //    '<div id="testmodalImagenes2" style="padding: 5px 20px;"><div class="row" id="rowImagenes2"> ' +
                        //    '</div> ' +
                        //    '</div> ' +
                        //    '</div> ' +
                        //    '</div> ' +
                        //    '</div> ' +
                        //    '<div class="modal-footer" > ' +
                        //    '<button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> ' +
                        //    '<button class="btn btn-primary" id="btnEditarMateriales" onclick="EditarMaterialesDesdePopUp();" type="button">Guardar cambios</button> </div > ');
                        idCategoriaEditar = item.IdCategoria;
                        idMaterial = item.IdMaterial;

                       
                    });
                    CargarImagenes(idMaterial);
                    CargarCategorias2();

                    $('#cmbCategoria').val(idCategoriaEditar);
                    $('#cmbCategoria').selectpicker('refresh');
                    $('#cmbCategoria').selectpicker('render');
                    
                    //
                    
                    //document.getElementById("cmbCategoria2").value = idCategoriaEditar;

                    //$("#EditMaterialesModal").modal();
                    $('#AddMaterialesModal').modal();
                }
                else {
                    $("#CargandoMateriales").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }
            }
        });
    },
    'click .inactivar': function (e, value, row, index) {
        var idMaterial = row.IdMaterial;
        

        document.getElementById('idMaterialesEliminar').textContent = '';

        document.getElementById('idMaterialesEliminarTexto').textContent = '¿Estás seguro de eliminar material con código "' + row.Codigo + '"?';

        document.getElementById('idMaterialesEliminar').textContent = idMaterial;

        $("#DelMaterialesModal").modal();

    },
    'click .verFoto': function (e, value, row, index) {
        var idMaterial = row.IdMaterial;
        //var folio = row.Folio;

        $('#VistaMaterialesForm').empty();
        var parametros = "{'pid': '" + idMaterial + "'}";
        $.ajax({
            dataType: "json",
            url: "Materiales.aspx/ObtenerMateriales",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    var idCategoria = "";
                    $(json).each(function (index, item) {

                        $('#VistaMaterialesForm').append('<div class= "modal-body" ><div class="form-group"><div class="col-sm-10"><div id="testmodalImagenes3" style="padding: 5px 20px;"><div class="row" id="rowImagenes3"> </div></div></div></div></div ><div class= "modal-footer" ><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> </div > ');

                    });
                    VistaImagenes(idMaterial);
                    $("#VistaMaterialesModal").modal();
                }
                else {
                    swal('No se encontro información.');

                }
            }
        });
    }
};

function accionMat1Formatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<span title="Ver Proveedores" class="btn btn-default verProveedores"><i class="icon_profile"></i></span>',
        '<span title="Agregar Proveedores" class="btn btn-info addProveedores"><i class="icon_profile"></i></span>',
        '</div>'
    ].join(' ');
}

function accionMat2Formatter(value, row, index) {

    return [
        '<div class="btn-group">',
        '<Button title="Editar" class="btn btn-success editar"><i class="icon_pencil"></i></Button>',
        '<Button title="Inactivar" class="btn btn-danger inactivar"><i class="icon_close_alt2"></i></Button>',
        '<Button title="Ver foto" class="btn btn-warning verFoto"><i class="icon_images"></i></Button>',
        '</div>'
    ].join(' ');
}

function formato_numero(numero, decimales, separador_decimal, separador_miles) { // v2007-08-06
    //debugger;
    numero = parseFloat(numero);
    if (isNaN(numero)) {
        return "";
    }

    if (decimales !== undefined) {
        // Redondeamos
        numero = numero.toFixed(decimales);
    }

    // Convertimos el punto en separador_decimal
    numero = numero.toString().replace(".", separador_decimal !== undefined ? separador_decimal : ",");

    if (separador_miles) {
        // Añadimos los separadores de miles
        var miles = new RegExp("(-?[0-9]+)([0-9]{3})");
        while (miles.test(numero)) {
            numero = numero.replace(miles, "$1" + separador_miles + "$2");
        }
    }

    return numero;
}

$('#VistaPMaterialesModal').on('shown.bs.modal', function () {
    $(document).off('focusin.modal');
});

$(document).on('click', '.cambiarpreciomaterial', function (event) {
    //;
    var _boton = $(this);
    var _id = $(this).parent().parent().find('td')[0].innerHTML;
    var _producto = $(this).parent().parent().find('td')[1].innerHTML;
    swal({
        title: "Esta seguro que deseas modificar el precio de " + _producto + "?",
        type: "warning",
        allowOutsideClick: false,
        allowEscapeKey: false,
        allowEnterKey: false,
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si',
        cancelButtonText: 'No'
    }).then(function () {
        swal({
            title: "Favor de Capturar precio",
            type: "question",
            input: "number",
            showCancelButton: true,
            closeOnConfirm: false,
            inputPlaceholder: "Precio nuevo",
            allowOutsideClick: false,
            allowEnterKey: false,
            allowEscapeKey: false,
            showCloseButton: true,
        }).then(function (result) {

            var params = "{'pid': '" + _id + "', 'Precio': '" + result + "'}";

            $.ajax({
                dataType: 'json',
                async: true,
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                url: 'Materiales.aspx/ActualizarPrecio',
                data: params,
                success: function (data, textStatus) {
                    if (data.d == 'Se actualizo') {
                        swal('Se actualizo precio, los cambios ya son visibles, actualiza página.');
                    }
                    else {
                        swal(data.d);
                    }

                    //if (parseInt(result) == parseInt(_cantidad)) {
                    //    $(_boton).parent().parent().addClass('verde');
                    //}
                    //else {
                    //    $(_boton).parent().parent().addClass('yellow');
                    //}


                }
            });

        }, function (dismiss) {
            // dismiss can be 'cancel', 'overlay',
            // 'close', and 'timer'
            if (dismiss === 'cancel') {

            }
        });



    }, function (dismiss) {
        // dismiss can be 'cancel', 'overlay',
        // 'close', and 'timer'
        if (dismiss === 'cancel') {

        }
    });

});

var arrayImagenes2 = [];

function CargarCategorias2() {
    var params = "{'Opcion': '" + 4 + "'}"

    $.ajax({
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        url: 'Materiales.aspx/CargarCategorias',
        data: params,
        success: function (data, textStatus) {

            var json = $.parseJSON(data.d);

            $('#cmbCategoria2').html('');
            $('#cmbCategoria2').html('<option value="-1">-- SELECCIONE CATEGORIA --</option>');
            $.each(json, function (index, value) {
                
                $("#cmbCategoria2").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
                //$('#txtPrecio').val(value.Precio);
            });

            //console.log("Hola " + idCategoriaEditar);

            $('#cmbCategoria2').val(idCategoriaEditar);
            $('#cmbCategoria2').selectpicker('refresh');
            $('#cmbCategoria2').selectpicker('render');
            
        }
    });
}

function CargarImagenes(idMaterial) {
    var params = "{'IdMaterial': '" + idMaterial + "'}";

    $.ajax({
        async: true,
        url: "Materiales.aspx/CargarImagenes",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var datos = "";
            var nodoTRAgregar = "";

            var JsonCombos;
            var jsonArray = $.parseJSON(data.d);
            var objImagenes = {};
            $('#rowImagenes2').html('');
            $.each(jsonArray, function (index, value) {
                $('#rowImagenes2').append('<div class="col-md-55"> ' +
                    '<div class="thumbnail"> ' +
                    '<div class="image view view-first"> ' +
                    '<img style="width: 20%; height: 10%; display: block;" src="' + value.Imagen + '" alt="image" /> ' +
                    '<div class="mask"> ' +
                    '<p></p> ' +
                    '<div class="tools tools-bottom"> ' +
                    '<a><i class="fa fa-search verImagen" rel="' + value.Imagen + '" title="' + value.FileName + '"></i></a> ' +
                    '</div> ' +
                    '</div> ' +
                    '</div> ' +
                    '<div class="caption"> ' +
                    '<p>' + value.FileName + '</p> ' +
                    '</div> ' +
                    '</div> ' +
                    '</div>');

                objImagenes["FileName"] = value.FileName;
                objImagenes["FileExtension"] = value.FileName.substring(value.FileName.indexOf("."));
                objImagenes["FileSize"] = 0;
                objImagenes["base64"] = value.Imagen;

                arrayImagenes2.push(objImagenes);
            });
        }
    });
}

function VistaImagenes(id) {
    var params = "{'IdMaterial': '" + id + "'}";

    $.ajax({
        async: true,
        url: "Materiales.aspx/CargarImagenes",
        dataType: "json",
        data: params,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus) {

            var datos = "";
            var nodoTRAgregar = "";

            var JsonCombos;
            var jsonArray = $.parseJSON(data.d);

            $('#rowImagenes3').html('');
            $.each(jsonArray, function (index, value) {
                $('#rowImagenes3').append('<div class="col-md-55"> ' +
                    '<div class="thumbnail"> ' +
                    '<div class="image view view-first"> ' +
                    '<img style="width: 20%; height: 10%; display: block;" src="' + value.Imagen + '" alt="image" /> ' +
                    '<div class="mask"> ' +
                    '<p></p> ' +
                    '<div class="tools tools-bottom"> ' +
                    '<a><i class="fa fa-search verImagen" rel="' + value.Imagen + '" title="' + value.FileName + '"></i></a> ' +
                    '</div> ' +
                    '</div> ' +
                    '</div> ' +
                    '<div class="caption"> ' +
                    '<p>' + value.FileName + '</p> ' +
                    '</div> ' +
                    '</div> ' +
                    '</div>');
            });
        }
    });
}

//$.fn.pageMe = function (opts) {
//    var $this = this,
//        defaults = {
//            perPage: 7,
//            showPrevNext: false,
//            hidePageNumbers: false
//        },
//        settings = $.extend(defaults, opts);

//    var listElement = $this;
//    var perPage = settings.perPage;
//    var children = listElement.children();
//    var pager = $('.pager');

//    if (typeof settings.childSelector != "undefined") {
//        children = listElement.find(settings.childSelector);
//    }

//    if (typeof settings.pagerSelector != "undefined") {
//        pager = $(settings.pagerSelector);
//    }

//    var numItems = children.size();
//    var numPages = Math.ceil(numItems / perPage);

//    pager.data("curr", 0);

//    if (settings.showPrevNext) {
//        $('<li><a href="#" class="prev_link">«</a></li>').appendTo(pager);
//    }

//    var curr = 0;
//    while (numPages > curr && (settings.hidePageNumbers == false)) {
//        $('<li><a href="#" class="page_link">' + (curr + 1) + '</a></li>').appendTo(pager);
//        curr++;
//    }

//    if (settings.showPrevNext) {
//        $('<li><a href="#" class="next_link">»</a></li>').appendTo(pager);
//    }

//    pager.find('.page_link:first').addClass('active');
//    pager.find('.prev_link').hide();
//    if (numPages <= 1) {
//        pager.find('.next_link').hide();
//    }
//    pager.children().eq(1).addClass("active");

//    children.hide();
//    children.slice(0, perPage).show();

//    pager.find('li .page_link').click(function () {
//        var clickedPage = $(this).html().valueOf() - 1;
//        goTo(clickedPage, perPage);
//        return false;
//    });
//    pager.find('li .prev_link').click(function () {
//        previous();
//        return false;
//    });
//    pager.find('li .next_link').click(function () {
//        next();
//        return false;
//    });

//    function previous() {
//        var goToPage = parseInt(pager.data("curr")) - 1;
//        goTo(goToPage);
//    }

//    function next() {
//        goToPage = parseInt(pager.data("curr")) + 1;
//        goTo(goToPage);
//    }

//    function goTo(page) {
//        var startAt = page * perPage,
//            endOn = startAt + perPage;

//        children.css('display', 'none').slice(startAt, endOn).show();

//        if (page >= 1) {
//            pager.find('.prev_link').show();
//        }
//        else {
//            pager.find('.prev_link').hide();
//        }

//        if (page < (numPages - 1)) {
//            pager.find('.next_link').show();
//        }
//        else {
//            pager.find('.next_link').hide();
//        }

//        pager.data("curr", page);
//        pager.children().removeClass("active");
//        pager.children().eq(page + 1).addClass("active");

//    }
//};


