<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Materiales.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Compras.Materiales" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <script>
        var arrayImagenes2 = [];
        var idMaterial = "";
        //function EliminarMateriales(btn) {
        //    document.getElementById('idMaterialesEliminar').textContent = '';

        //    document.getElementById('idMaterialesEliminarTexto').textContent = '¿Estás seguro de eliminar material con código "' + btn.value + '"?';

        //    document.getElementById('idMaterialesEliminar').textContent = btn.value;

        //    $("#DelMaterialesModal").modal();
        //}
        //function CargarCategorias2() {
        //    var params = "{'Opcion': '" + 4 + "'}"

        //    $.ajax({
        //        dataType: 'json',
        //        async: true,
        //        contentType: "application/json; charset=utf-8",
        //        type: 'POST',
        //        url: 'Materiales.aspx/CargarCategorias',
        //        data: params,
        //        success: function (data, textStatus) {

        //            var json = $.parseJSON(data.d);

        //            $('#cmbCategoria2').html('');
        //            $('#cmbCategoria2').html('<option value="-1">-- SELECCIONE CATEGORIA --</option>');
        //            $.each(json, function (index, value) {
        //                $("#cmbCategoria2").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
        //                //$('#txtPrecio').val(value.Precio);
        //            });
        //            $('#cmbCategoria2').val(idCategoriaEditar);
        //        }
        //    });
        //}
        var idCategoriaEditar = "";
        //function EditarMateriales(btn) {
        //    $('#EditarMaterialesForm').empty();
        //    var parametros = "{'pid': '" + btn.value + "'}";
        //    $.ajax({
        //        dataType: "json",
        //        url: "Materiales.aspx/ObtenerMateriales",
        //        async: true,
        //        data: parametros,
        //        type: "POST",
        //        contentType: "application/json; charset=utf-8",
        //        success: function (data) {
        //            if (data.d != "") {
        //                var json = JSON.parse(data.d);

        //                $(json).each(function (index, item) {

        //                    $('#EditarMaterialesForm').append('<div class= "modal-body" ><div class="form-group"><div class="col-sm-10"><label>No. Material</label><input type="text" value="' + item.Codigo + '" class="form-control" placeholder="No. Material" id="txtNoMaterialEditar" readonly/></div></div><div class="form-group"><div class="col-sm-10"><label>Categoria</label><select class="form-control" id="cmbCategoria2"></select></div></div><div class="form-group"><div class="col-sm-10"><label>Descripción</label><input type="text" class="form-control" value="' + item.Descripcion.replace('"', '') + '" placeholder="Descripción" id="txtDescripcionMaterialesEditar" required/></div></div><div class="form-group"><div class="col-sm-10"><label>Búsqueda</label><input type="tel" class="form-control" value="' + item.Buscador.replace('"', '') + '" placeholder="Buscador" id="txtBuscadorMaterialesEditar" required/></div></div> <div class="form-group"><div class="col-sm-10"><button type="button" class="btn btn-info" id="btnAddFiles2" onclick="AgregarFotoEditar();">Agregar fotos</button><div id="testmodalImagenes2" style="padding: 5px 20px;"><div class="row" id="rowImagenes2"> </div></div></div></div></div ><div class= "modal-footer" ><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> <button class="btn btn-primary" id="btnEditarMateriales" onclick="EditarMaterialesDesdePopUp();" type="button">Guardar cambios</button> </div > ');
        //                    idCategoriaEditar = item.IdCategoria;
        //                    idMaterial = item.IdMaterial;

        //                    //document.getElementById("cmbCategoria2").value = idCategoria;
        //                });
        //                CargarImagenes();
        //                CargarCategorias2();

        //                $("#EditMaterialesModal").modal();
        //            }
        //            else {
        //                $("#CargandoMateriales").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

        //            }
        //        }
        //    });
        //}
        function AgregarFotoEditar() {
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
                    $('#rowImagenes2').append('<div class="col-md-55"> ' +
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

                    arrayImagenes2.push(objImagenes);
                }
                reader.readAsDataURL(file)
            })
        }

        function EditarMaterialesDesdePopUp() {
            if ($('#cmbCategoria2').val() == '-1') {
                swal('Elige categoria');
                return;
            }
            if ($('#txtNoMaterialEditar').val() == '') {
                swal('Proporciona, número o código de material.');
                return;
            }
            if ($('#txtDescripcionMaterialesEditar').val() == '') {
                swal('Proporciona, descripción de material.');
                return;
            }
            if ($('#txtBuscadorMaterialesEditar').val() == '') {
                swal('Proporciona, descripción para metodo de búsqueda de material.');
                return;
            }
            var params = "{'IdMaterial': '" + idMaterial + "'" +
                ",'Codigo': '" + $('#txtNoMaterialEditar').val() +
                "','Descripcion': '" + $('#txtDescripcionMaterialesEditar').val() +
                "','IdCategoria': '" + $('#cmbCategoria2').val() +
                "','Buscador': '" + $('#txtBuscadorMaterialesEditar').val() +
                "','Tipo': '2','IdUsuario': '0'}";
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

        }

     //function CargarImagenes() {
     //    var params = "{'IdMaterial': '" + idMaterial + "'}";

     //    $.ajax({
     //        async: true,
     //        url: "Materiales.aspx/CargarImagenes",
     //        dataType: "json",
     //        data: params,
     //        type: "POST",
     //        contentType: "application/json; charset=utf-8",
     //        success: function (data, textStatus) {

     //            var datos = "";
     //            var nodoTRAgregar = "";

     //            var JsonCombos;
     //            var jsonArray = $.parseJSON(data.d);
     //            var objImagenes = {};
     //            $('#rowImagenes2').html('');
     //            $.each(jsonArray, function (index, value) {
     //                $('#rowImagenes2').append('<div class="col-md-55"> ' +
     //                    '<div class="thumbnail"> ' +
     //                    '<div class="image view view-first"> ' +
     //                    '<img style="width: 20%; height: 10%; display: block;" src="' + value.Imagen + '" alt="image" /> ' +
     //                    '<div class="mask"> ' +
     //                    '<p></p> ' +
     //                    '<div class="tools tools-bottom"> ' +
     //                    '<a><i class="fa fa-search verImagen" rel="' + value.Imagen + '" title="' + value.FileName + '"></i></a> ' +
     //                    '</div> ' +
     //                    '</div> ' +
     //                    '</div> ' +
     //                    '<div class="caption"> ' +
     //                    '<p>' + value.FileName + '</p> ' +
     //                    '</div> ' +
     //                    '</div> ' +
     //                    '</div>');

     //                objImagenes["FileName"] = value.FileName;
     //                objImagenes["FileExtension"] = value.FileName.substring(value.FileName.indexOf("."));
     //                objImagenes["FileSize"] = 0;
     //                objImagenes["base64"] = value.Imagen;

     //                arrayImagenes2.push(objImagenes);
     //            });
     //        }
     //    });
     //}
     //function VistaImagenes(id) {
     //    var params = "{'IdMaterial': '" + id + "'}";

     //    $.ajax({
     //        async: true,
     //        url: "Materiales.aspx/CargarImagenes",
     //        dataType: "json",
     //        data: params,
     //        type: "POST",
     //        contentType: "application/json; charset=utf-8",
     //        success: function (data, textStatus) {

     //            var datos = "";
     //            var nodoTRAgregar = "";

     //            var JsonCombos;
     //            var jsonArray = $.parseJSON(data.d);

     //            $('#rowImagenes3').html('');
     //            $.each(jsonArray, function (index, value) {
     //                $('#rowImagenes3').append('<div class="col-md-55"> ' +
     //                    '<div class="thumbnail"> ' +
     //                    '<div class="image view view-first"> ' +
     //                    '<img style="width: 20%; height: 10%; display: block;" src="' + value.Imagen + '" alt="image" /> ' +
     //                    '<div class="mask"> ' +
     //                    '<p></p> ' +
     //                    '<div class="tools tools-bottom"> ' +
     //                    '<a><i class="fa fa-search verImagen" rel="' + value.Imagen + '" title="' + value.FileName + '"></i></a> ' +
     //                    '</div> ' +
     //                    '</div> ' +
     //                    '</div> ' +
     //                    '<div class="caption"> ' +
     //                    '<p>' + value.FileName + '</p> ' +
     //                    '</div> ' +
     //                    '</div> ' +
     //                    '</div>');
     //            });
     //        }
     //    });
     //}
     //function Verimagenes(btn) {
     //    $('#VistaMaterialesForm').empty();
     //    var parametros = "{'pid': '" + btn.value + "'}";
     //    $.ajax({
     //        dataType: "json",
     //        url: "Materiales.aspx/ObtenerMateriales",
     //        async: true,
     //        data: parametros,
     //        type: "POST",
     //        contentType: "application/json; charset=utf-8",
     //        success: function (data) {
     //            if (data.d != "") {
     //                var json = JSON.parse(data.d);
     //                var idCategoria = "";
     //                $(json).each(function (index, item) {

     //                    $('#VistaMaterialesForm').append('<div class= "modal-body" ><div class="form-group"><div class="col-sm-10"><div id="testmodalImagenes3" style="padding: 5px 20px;"><div class="row" id="rowImagenes3"> </div></div></div></div></div ><div class= "modal-footer" ><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> </div > ');

     //                });
     //                VistaImagenes(btn.value);
     //                $("#VistaMaterialesModal").modal();
     //            }
     //            else {
     //                swal('No se encontro información.');

     //            }
     //        }
     //    });
     //}
     //function VerProveedores(btn) {
     //    var params = "{'Opcion': '9'}";

     //    $.ajax({
     //        dataType: 'json',
     //        async: true,
     //        contentType: "application/json; charset=utf-8",
     //        type: 'POST',
     //        url: 'Materiales.aspx/CargarProveedores',
     //        data: params,
     //        success: function (data, textStatus) {

     //            var json = $.parseJSON(data.d);

     //            $('#cmbProveedorMaterial').html('');
     //            $('#cmbProveedorMaterial').html('<option value="-1">-- SELECCION PROVEEDOR --</option>');
     //            $.each(json, function (index, value) {
     //                $("#cmbProveedorMaterial").append('<option value="' + value.Id + '">' + value.Nombre.toUpperCase() + '</option>');
     //            });
     //            $('#cmbProveedorMaterial').selectpicker('refresh');
     //            $('#cmbProveedorMaterial').selectpicker('render');
     //        }
     //    });
     //    var parametros = "{'pid': '" + btn.value + "'}";
     //    $.ajax({
     //        dataType: "json",
     //        url: "Materiales.aspx/ObtenerMateriales",
     //        async: true,
     //        data: parametros,
     //        type: "POST",
     //        contentType: "application/json; charset=utf-8",
     //        success: function (data) {
     //            if (data.d != "") {
     //                var json = JSON.parse(data.d);
     //                var Descripcion = "";
     //                $(json).each(function (index, item) {

     //                    Descripcion = item.Descripcion
     //                });
     //                document.getElementById('idMaterialProveedor').textContent = btn.value;
     //                document.getElementById('ProveedoresVistaMateriales').textContent = Descripcion;
     //                $("#ProveedoresMaterialesModal").modal();
     //            }
     //            else {
     //                swal('No se obtuvo información.');
     //            }
     //        }
     //    });
     //}

     //function VerProveedoresPrecios(btn) {
     //    $('tbody#listaMaterialesPrecios').empty();
     //    $('#myPager').html('');
     //    var parametros = "{'pid': '" + btn.value + "'}";
     //    $.ajax({
     //        dataType: "json",
     //        url: "Materiales.aspx/ObtenerMaterialesPrecios",
     //        async: true,
     //        data: parametros,
     //        type: "POST",
     //        contentType: "application/json; charset=utf-8",
     //        success: function (data) {
     //            if (data.d != "") {
     //                var json = JSON.parse(data.d);
     //                $(json).each(function (index, item) {
     //                    //var FechaM = json[index].FechaModificacion;
     //                    $('tbody#listaMaterialesPrecios').append(
     //                        '<tr><td style="display:none;">'
     //                        + json[index].IdProveedorMaterial
     //                        + '</td>'
     //                        + '<td>'
     //                        + json[index].Proveedor
     //                        + '</td>'
     //                        + '<td>'
     //                        + json[index].UnidadMedida
     //                        + '</td>'
     //                        + '<td>'
     //                        + formato_numero(json[index].Precio, 2, '.', ',')
     //                        + '</td>'
     //                        + '<td>'
     //                        + json[index].Moneda
     //                        + '</td>'
     //                        + '<td>'
     //                        + json[index].Usuario
     //                        + '</td>'
     //                        + '<td>'
     //                        + json[index].FechaModificacion.substring(0, 10)
     //                        + '</td>'
     //                        + '<td>'
     //                        + '<span class="btn btn-success icon_pencil cambiarpreciomaterial"></span>'
     //                        + '</td>'
     //                        + '</tr>')
     //                });
     //                $("#VistaPMaterialesModal").modal();
     //                //$('#listaMateriales').pageMe({ pagerSelector: '#myPager', showPrevNext: true, hidePageNumbers: false, perPage: 100 });
     //            }
     //            else {
     //                swal('No se pudo obtener información.');

     //            }
     //        }
     //    });
     //}

     //(function (document) {
     //    'use strict';

     //    var LightTableFilter = (function (Arr) {

     //        var _input;

     //        function _onInputEvent(e) {
     //            _input = e.target;
     //            var tables = document.getElementsByClassName(_input.getAttribute('data-table'));
     //            Arr.forEach.call(tables, function (table) {
     //                Arr.forEach.call(table.tBodies, function (tbody) {
     //                    Arr.forEach.call(tbody.rows, _filter);
     //                });
     //            });
     //        }

     //        function _filter(row) {
     //            var text = row.textContent.toLowerCase(), val = _input.value.toLowerCase();
     //            row.style.display = text.indexOf(val) === -1 ? 'none' : 'table-row';
     //        }

     //        return {
     //            init: function () {
     //                var inputs = document.getElementsByClassName('light-table-filter');
     //                Arr.forEach.call(inputs, function (input) {
     //                    input.oninput = _onInputEvent;
     //                });
     //            }
     //        };
     //    })(Array.prototype);

     //    document.addEventListener('readystatechange', function () {
     //        if (document.readyState === 'complete') {
     //            LightTableFilter.init();
     //        }
     //    });

     //})(document);
    </script>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div id="loading-img">  <img src="../img/logoloading.png" /></div>--%>

    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Administración</li>
                        <li><i class="icon_building"></i>Materiales</li>
                    </ol>
                </div>
            </div>
            <form runat="server">
                <asp:HiddenField runat="server" ID="idUsuarioLog" />
            </form>
            <!-- page start-->
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div class="form-group" id="MensajeMateriales">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>
                        <header class="panel-heading">
                            Lista de Materiales 
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                              <%--<Button class="btn btn-primary" data-toggle="modal" data-target="#AddMaterialesModal"><i class="icon_plus_alt2"></i></Button>--%>
                              <%--<span class="btn btn-primary" data-toogle="modal" data-target="#AddMaterialesModal"><i class="icon_plus_alt2"></i></span>--%>
                              <a id="btnAgregarMaterial" class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddMaterialesModal"><i class="icon_plus_alt2"></i>Agregar </a>
                          </div>
                          <%--<div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>--%>
                      </form>

                  </div>

                        </header>
                        <div class="form-group" id="CargandoMateriales">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="x_panel">
                                <div class="x_content">

                                    <div id="toolbar">
                                    </div>

                                    <table id="TablaMateriales" class="table table-striped table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                        <thead>
                                            <tr>
                                                <th data-field="NoMaterial" data-sortable="true"><i class="icon_table"></i>No</th>
                                                <th data-field="Codigo" data-sortable="true"><i class="icon_table"></i>Código</th>
                                                <th data-field="Descripcion" data-sortable="true"><i class="icon_link_alt"></i>Descripción</th>
                                                <th data-field="Categoria" data-sortable="true"><i class="icon_info_alt"></i>Catégoria</th>
                                                <%--<th data-field="Buscador" data-sortable="true"><i class="icon_search-2"></i>Pálabras claves</th>--%>
                                                <th data-field="Usuario" data-sortable="true"><i class="icon_profile"></i>Usuario</th>
                                                <th data-field="CiudadSucursal" data-sortable="true"><i class="icon_table"></i>Sucursal</th>
                                                <th data-align="center" data-formatter="accionMat1Formatter" data-events="accionMat1Events"><i class="icon_ol"></i>Accion</th>
                                                <th data-align="center" data-formatter="accionMat2Formatter" data-events="accionMat2Events"></th>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <%--<div style="overflow-x: auto; overflow-y: auto;"> 
                  <table class="table table-striped table-advance table-hover order-table" id="TablaMateriales">
                    <thead>
                      <tr>
                        <th style="display:none;"><i class="icon_building"></i>Código</th>
                        <th><i class="icon_table"></i> Código</th>
                        <th><i class="icon_link_alt"></i> Descripción</th>
                          <th><i class="icon_info_alt"></i> Catégoria</th>
                        <th><i class="icon_search-2"></i> Pálabras claves</th>
                        <th><i class="icon_profile"></i>Usuario</th>                      
                        <th><i class="icon_ol"></i> Acciones</th>
                        <th><i class="icon_ol"></i> </th>
                      </tr>
                     </thead>
                    <tbody id="listaMateriales">
                   
                    </tbody>
                  </table>
                </div>
                <div class="col-md-12 text-center">
      <ul class="pagination pagination-lg pager" id="myPager"></ul>
      </div>--%>
                    </section>
                </div>
            </div>
            <!-- page end-->
        </section>
    </section>
    <%--AGREGAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddMaterialesModal" tabindex="-1" role="dialog" aria-labelledby="AddMaterialesModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelAgregarMateriales">Agregar Materiales</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">

                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>No. Material</label>
                                <input type="text" class="form-control" placeholder="No. Material" id="txtNoMaterial" disabled />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Codigo Proveedor</label>
                                <input type="tel" class="form-control" placeholder="Codigo Proveedor" id="txtCodigoProveedor" onkeyup="mayus(this);" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Descripción</label>
                                <input type="text" class="form-control" placeholder="Descripción" id="txtDescripcionMateriales" onkeyup="mayus(this);" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Categoria</label>
                                <select class="form-control" id="cmbCategoria"></select>
                            </div>
                        </div>


                        <div class="form-group">
                            <div class="col-sm-10">
                                <button type="button" class="btn btn-info" id="btnAddFiles">Agregar fotos</button>
                                <div id="testmodalImagenes" style="padding: 5px 20px;">
                                    <div class="row" id="rowImagenes">
                                        <%--<div class="col-md-3">
                                    <div class="thumbnail">
                                        <div class="image view view-first">
                                            <img style="width: 100%; display: block;" src="images/media.jpg" alt="image" />
                                            <div class="mask">
                                                <p></p>
                                                <div class="tools tools-bottom">
                                                    <a href="#" target="_blank"><i class="fa fa-search"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="caption">
                                            <p>Snow and Ice Incoming for the South</p>
                                        </div>
                                    </div>
                                </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-primary" id="btnGuardarMateriales" type="button">Crear</button>
                        <button class="btn btn-primary" id="btnEditarMateriales" type="button">Guardar cambios</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelMaterialesModal" tabindex="-1" role="dialog" aria-labelledby="DelMaterialesModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelEliminarMateriales">Eliminar Materiales</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <div class="form-group" id="txtModalEliminarMateriales">
                            <label id="idMaterialesEliminar" hidden="hidden"></label>
                            <label id="idMaterialesEliminarTexto"></label>
                        </div>
                        <div class="form-group" id="txtModalEliminarMensajeMateriales">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-danger" id="btnEliminarMateriales" type="button">Eliminar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <%--EDITAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="EditMaterialesModal" tabindex="-1" role="dialog" aria-labelledby="EditMaterialesModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelEditarMateriales">Editar Materiales</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal" id="EditarMaterialesForm">
                </form>


            </div>
        </div>
    </div>
    <%--VISTA IMAGENES--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="VistaMaterialesModal" tabindex="-1" role="dialog" aria-labelledby="VistaMaterialesModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelVistaMateriales">Imágenes</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal" id="VistaMaterialesForm">
                </form>


            </div>
        </div>
    </div>
    <%--Proveedores--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="ProveedoresMaterialesModal" tabindex="-1" role="dialog" aria-labelledby="ProveedoresMaterialesModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="ProveedoresVistaMateriales">Agregar proveedor</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal" id="ProveedoresMaterialesForm">
                    <label id="idMaterialProveedor" hidden="hidden"></label>
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Proveedores</label>
                                <select class="form-control selectpicker" data-live-search="true" id="cmbProveedorMaterial"></select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Unidad de medida</label>
                                <input type="text" class="form-control" placeholder="Unidad medida" id="txtUnidadMaterial" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Precio</label>
                                <input type="number" class="form-control" placeholder="Precio" id="txtPrecioMaterial" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Moneda</label>
                                <select class="form-control" id="cmbMonedaMaterial">
                                    <option value="07F60F95-8F8A-4ABD-9BED-369EE7DFCCFF">DOLARES</option>
                                    <option value="9F77F47A-3B1E-4531-99BC-4E2CB1FFF9B2">PESOS</option>
                                </select>
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-primary" id="btnProveedoresMateriales" type="button">Agregar</button>
                    </div>
                </form>


            </div>
        </div>
    </div>
    <%--VISTA Proveedores--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="VistaPMaterialesModal" tabindex="-1" role="dialog" aria-labelledby="VistaPMaterialesModal" aria-hidden="true">
        <div class="modal-dialog" style="width: 65%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelVistaPMateriales">Proveedores y precios</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal" id="VistaPMaterialesForm">
                    <table class="table table-striped table-advance table-hover order-table" id="TablaMaterialesP">
                        <thead>
                            <tr>
                                <th><i class="icon_building"></i>Proveedor</th>
                                <th><i class="icon_table"></i>Unidad medida</th>
                                <th><i class="icon_creditcard"></i>Precio</th>
                                <th><i class="icon_currency"></i>Moneda</th>
                                <th><i class="icon_profile"></i>Usuario</th>
                                <th><i class="icon_profile"></i>Ultima modificacion</th>
                                <th><i class="icon_pencil"></i>Cambiar precio</th>
                            </tr>
                        </thead>
                        <tbody id="listaMaterialesPrecios">
                        </tbody>
                    </table>

                </form>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/Materiales.js" type="text/javascript"></script>

</asp:Content>




