<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Sitio.Master" CodeBehind="CajaChica.aspx.cs" Inherits="SisaDev.Admin.CajaChica" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     //function EliminaCC(btn) {
     //    document.getElementById('idCajaChicaEliminar').textContent = '';
     //    document.getElementById('idCajaChicaEliminarTexto').textContent = '¿Estás seguro de eliminar información de caja chica con código "' + btn.value + '"?';


     //    document.getElementById('idCajaChicaEliminar').textContent = btn.value;

     //    $("#DelCajaChicaModal").modal();
     //}
     //function EditarCChica(btn) {
     //    $('#EditarCajaChicaForm').empty();
     //    //$(btn.value).each(function (index, item) {
     //    //    var IdCajaChica = json[index].idSucursa;
     //    //    var CiudadCajaChica = json[index].CiudadCajaChica;
     //    //    var DireccionCajaChica = json[index].DireccionCajaChica;
     //    //    var TelefonoCajaChica = json[index].TelefonoCajaChica;
     //    //    $('#EditarCajaChicaForm').append(' <div class= "modal-body" >  <div class="form-group"> <div class="col-sm-10"> <input type="hidden" class="form-control" id="txtidCajaChicaEditar" value="' + IdCajaChica + '" required/></div></div<div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtCiudadCajaChicaEditar" value="' + CiudadCajaChica + '" required/></div></div><div class="form-group"><div class="col-sm-10"><input type="text" class="form-control" id="txtDireccionCajaChicaEditar" value="' + DireccionCajaChica + '" required/></div></div><div class="form-group"> <div class="col-sm-10"><input type="tel" class="form-control"  id="txtTelefonoCajaChicaEditar" value="' + TelefonoCajaChica + '" required/></div> </div>  <div class="form-group"> <div class="col-sm-10"><div class="form-group" id="txtModalEditarMensajeCajaChica"> </div></div> </div> </div > <div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> <button class="btn btn-primary" id="btnEditarCajaChica" type="button">Guardar cambios</button> </div>');
     //    //});
     //    var parametros = "{'pid': '" + btn.value + "'}";
     //    $.ajax({
     //        dataType: "json",
     //        url: "CajaChica.aspx/ObtenerCC",
     //        async: true,
     //        data: parametros,
     //        type: "POST",
     //        contentType: "application/json; charset=utf-8",
     //        success: function (data) {
     //            if (data.d != "") {
     //                var json = JSON.parse(data.d);
     //                $(json).each(function (index, item) {
     //                    var IdCajaChica = item.IdCajaChica;
     //                    var Responsable = item.Responsable;
     //                    var Responsable2 = item.CampoExtra;
     //                    var Concepto = item.Concepto;
     //                    var Proyecto = item.Proyecto;
     //                    var Comprobante = item.Comprobante;
     //                    var Cargo = item.Cargo;
     //                    var Abono = item.Abono;
     //                    var Saldo = item.Saldo;
     //                    var Fecha = item.Fecha.substring(0, 10);
     //                    var Estatus = item.Estatus;
     //                    var Categoria = item.Categoria;
     //                    var IdProyecto = item.IdProyecto;
     //                    $('#EditarCajaChicaForm').append(' <div class= "modal-body">  '
     //                        + ' <div class= "form-group" > <div class="col-sm-10"> <input type="hidden" class="form-control" id="txtidCajaChicaEditar" value="' + IdCajaChica + '" required /> '
     //                        + ' </div> </div ><div class= "form-group" ><div class="col-sm-10"> <label>Fecha:</label> <input type="date" class="form-control" id="dtFechaEditar" value="' + Fecha + '" required />  '
     //                        // + ' </div ></div> <div class= "form-group" > <div class="col-sm-10"><label>Responsable:</label><input type="text" class="form-control" id="txtResponsableEditar" value="' + Responsable + '" required/>'
     //                        + ' </div ></div> <div class= "form-group" > <div class="col-sm-10"><label>Responsable:</label><select class="form-control selectpicker" id="txtResponsableEditar" data-live-search="true" required></select>'
     //                        + ' </div ></div> <div class= "form-group" > <div class="col-sm-10"><label>Responsable:</label><input type="text" class="form-control selectpicker" id="txtResponsable2Editar" value="' + Responsable2 + '"/>'
     //                        + '</div></div ><div class="form-group"><div class="col-sm-10"><label>Concepto:</label><input type="text" class="form-control" id="txtConceptoEditar" value="' + Concepto + '" required/>'
     //                        + '</div></div><div class="form-group"><div class="col-sm-10"><label>Proyecto:</label><select id="cmbProyectosEditarCC" class="form-control selectpicker" data-live-search="true" required></select>'
     //                        + '</div></div><div class= "form-group" ><div class="col-sm-10"><label>Comprobante:</label><select id="cmbComprobanteEdicarCC" class="form-control" required><option value="SIN COMPROBANTE">SIN COMPROBANTE</option><option value="TICKET">TICKET</option><option value="FACTURA">FACTURA</option><option value="NOTA">NOTA</option><option value="RECIBO DE EFECTIVO">RECIBO DE EFECTIVO</option><option value="VIATICOS">VIATICOS</option><option value="ORDEN DE COMPRA">ORDEN DE COMPRA</option><option value="N/A">N/A</option><option value="PENDIENTE">PENDIENTE</option></select>'
     //                        + '</div></div> <div class="form-group"> <div class="col-sm-10"> <label>Cargo:</label> <input type="text" class="form-control" id="txtCargoEditar" value="' + formato_numero(Cargo, 2, '.', ',') + '" required/> '
     //                        + ' </div></div> <div class="form-group"> <div class="col-sm-10"><label>Abono:</label>  <input type="text" class="form-control" id="txtAbonoEditar" value="' + formato_numero(Abono, 2, '.', ',') + '" required/>'
     //                        + ' </div></div> <div class="form-group"> <div class= "col-sm-10"><label>Estatus:</label><select id="cmbEstatusEditar" class="form-control" required><option value="0">PENDIENTE</option><option value="1">COMPLETO</option></select>'
     //                        + '</div></div><div class="form-group"><div class= "col-sm-10" ><label>Categoria:</label> <select id="cmbCategoriaCCEditar" class="form-control" required> <option value="MATERIAL">MATERIAL</option><option value="MANOOBRA">MANO DE OBRA</option><option value="EQUIPO">EQUIPO</option> <option value="N/A">N/A</option></select></div ></div > <div class="form-group" id="txtModalEditarMensajeCajaChica"> </div>'
     //                        + '<div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button> '
     //                        + '<button class="btn btn-primary" id="btnEditarCajaChica" onclick="EditarCajaChicaDesdePopUp();" type="button">Guardar cambios</button> </div></div>');
     //                    CargarProyectosEditarCC(IdProyecto);
     //                    CargarUsuariosEditar(Responsable);
     //                    $('#cmbEstatusEditar').val(Estatus);
     //                    $('#cmbCategoriaCCEditar').val(Categoria);
     //                    $('#cmbComprobanteEdicarCC').val(Comprobante);
     //                    $('#txtResponsableEditar').val(Responsable);
     //                    $('#txtResponsableEditar').selectpicker('refresh');
     //                });
     //                $("#EditCajaChicaModal").modal();
     //            }
     //            else {
     //                $("#CargandoCajaChica").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

     //            }
     //        }
     //    });
     //}



     function EditarCajaChicaDesdePopUp() {
         var parametros = "{'Responsable':'" + $('#txtResponsableEditar').val() + "','Concepto': '" + $('#txtConceptoEditar').val() + "', 'pidproyecto':'" + $('#cmbProyectosEditarCC').val() + "', 'Proyecto':'" + $('#cmbProyectosEditarCC option:selected').text() + "',"
             + "'Comprobante': '" + $('#cmbComprobanteEdicarCC').val() + "', 'Cargo': '" + $('#txtCargoEditar').val() + "', 'Abono': '" + $('#txtAbonoEditar').val() + "', 'Fecha':'','Estatus':'" + $('#cmbEstatusEditar').val() + "', 'Tipo':'2', 'pid':'" + $('#txtidCajaChicaEditar').val() + "', 'Categoria':'" + $('#cmbCategoriaCCEditar').val() + "'"
             + ",'CampoExtra': '" + $('#txtResponsable2Editar').val() + "'} ";
         $.ajax({
             dataType: "json",
             url: "CajaChica.aspx/GuardarCC",
             async: true,
             data: parametros,
             type: "POST",
             contentType: "application/json; charset=utf-8",
             success: function (msg) {
                 if (msg.d == "Informacion actualizada.") {
                     //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                     //CargarCC();
                     //swal(msg.d);
                     //location.reload();

                     swal({
                         title: msg.d
                     }).then((result) => {

                         if (result) {
                             location.reload();
                         }
                     });

                 }
                 else {
                     //$("#txtModalEliminarMensajeEmpresa").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                     swal(msg.d);
                 }
             }
         });
     }
     //function CargarProyectosEditarCC(IdProyecto) {
     //    var params = "{'Opcion': '10'}";

     //    $.ajax({
     //        dataType: 'json',
     //        async: true,
     //        contentType: "application/json; charset=utf-8",
     //        type: 'POST',
     //        url: 'CajaChica.aspx/CargarCombos',
     //        data: params,
     //        success: function (data, textStatus) {

     //            var json = $.parseJSON(data.d);

     //            $('#cmbProyectosEditarCC').html('');
     //            $("#cmbProyectosEditarCC").append('<option value="AC7E508E-6E89-4778-A9B5-0343FEF9201D">CONSUMIBLES TALLER HERMOSILLO</option>');
     //            $("#cmbProyectosEditarCC").append('<option value="9D2FE3B0-5E86-4FF2-B300-144B1C94F1FA">UNIFORMES SISA HERMOSILLO</option>');
     //            $("#cmbProyectosEditarCC").append('<option value="14AFC99E-E0A1-487A-9AA4-0C6C3EB32B77">EQUIPO DE SEGURIDAD HERMOSILLO</option>');
     //            $("#cmbProyectosEditarCC").append('<option value="8E94B853-6E03-4726-B60F-415B5F7294D6">INVENTARIO SISA HERMOSILLO</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="B2C9AA16-C340-47A1-8744-5CA73C388F92">N/A</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="1621D8FD-690E-4C1E-BB94-7E0FAB7C7F56">GASTOS ADMINISTRATIVOS HERMOSILLO</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="80914600-CC95-48F6-8AC0-8667EAFBCFEC">PENDIENTE</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="83B995B4-3877-4600-A16D-5FFF9F3A84E3">ECONOLINE 2003</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="214104A8-0083-4481-8813-A754CD8FFD40">ECONOLINE 2006</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="F765BA07-20A2-4E00-A208-F06D97DF3160">FOCUS</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="8EEE37DB-F5BD-405D-9492-4919618E8C15">IKON</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="697966BC-9116-443E-A0E6-876528AABF08">RANGER</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="83A889B9-11CA-47A9-8538-B1736B773FA8">REMOLQUE</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="9F71A091-10E7-4322-A0AA-F442B45D4958">RAM</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="3A9F72BA-0011-4606-A1C6-07FB83EC4F8D">CHEYENNE</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="3BE79512-40A2-4CC6-83EF-B1C2CDBA6765">RAM 700</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="B0488C4F-1B55-4DB2-B6F4-7555E46916BF">JEEP</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="B9938D9A-DDE7-453A-B430-2D9ADF68D15F">GASOLINA HERMOSILLO</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="40F670F5-A145-4C52-AC38-6E791E3B5A19">FRONTIER</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="11313417-6F42-40B8-A933-06C452E34441">SWIFT</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="F76F2A6C-4FA1-4505-82B5-82EE5EE69497">SPARK</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="A9B875EC-1AA2-49D0-8D97-144DBFF21B56">F150</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="EF4EDE9E-BFCD-4D31-9B40-8E6B21291F21">BRONCO</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="1A713837-3DFF-4012-9F5F-7844B3DED561">TONELADA</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="F74683C3-A52D-4C2B-9B7E-25771AD50ABD">CONSUMIBLES TALLER CUAUTITLÁN</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="05AC88FC-6340-4936-B749-2F6EDA17F88A">CONSUMIBLES TALLER QUERÉTARO</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="39A9783A-0AA3-48BE-AF1C-8BDEEC4E1625">CONSUMIBLES TALLER TECATE</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="07BF808D-A646-4D63-9CD7-5161A94FC7FB">CONSUMIBLES TALLER CHIHUAHUA</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="6A50C6ED-0384-4E54-9142-B14E7338E2DC">EQUIPO DE SEGURIDAD CUAUTITLÁN</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="89AE75F8-2D98-40B1-AC47-FDD4D951881C">EQUIPO DE SEGURIDAD QUERÉTARO</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="77C10A22-E1E3-4EBB-806A-2891165EDD88">EQUIPO DE SEGURIDAD TECATE</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="BFC64785-CAD4-4247-B0AE-A64FE53B4669">EQUIPO DE SEGURIDAD CHIHUAHUA</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="BB913E5E-3200-4639-894A-628741DDB24E">INVENTARIO SISA CUAUTITLÁN</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="C8589B15-CAF9-44EB-A49C-FAE500B17EC2">INVENTARIO SISA QUERÉTARO</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="B99F1969-83AF-457B-BC6E-7544B40683EF">INVENTARIO SISA TECATE</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="734B8D0E-DEBE-46F1-9B69-5FF7334D9EB1">INVENTARIO SISA CHIHUAHUA</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="A46D00C1-0D5B-41B3-8702-0ADA1D98E175">GASTOS ADMINISTRATIVOS CUAUTITLÁN</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="C9E46130-B035-4B7E-97BA-7BED2441BBDD">GASTOS ADMINISTRATIVOS QUERÉTARO</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="9AE78058-4070-4F65-82A1-DDEB1E2F624A">GASTOS ADMINISTRATIVOS TECATE</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="7846992F-5AF1-4C5F-91C6-A91541C6E405">GASTOS ADMINISTRATIVOS CHIHUAHUA</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="79144254-9D84-486B-A0C6-A2C3D2CC6167">GASOLINA CUAUTITLÁN</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="84DF1AF7-AD10-4AD6-8F51-9CA6EF0EEC47">GASOLINA QUERÉTARO</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="178B1FE7-2E94-4F4D-951C-0A823B095505">GASOLINA TECATE</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="EE3ADE54-E730-4C9D-980E-F1A57BB53BE2">GASOLINA CHIHUAHUA</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="08369BA2-25DD-4CB4-829A-0A472997794F">PASSAT</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="4AD1CAF0-E15C-434C-8A93-794474D902D8">COLORADO</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="57F02FB0-ABFD-4907-8D69-ED9284309B80">BATANGA CHICA</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="EC17D9F8-4824-4B9C-AFA2-C89B34DE2D23">BATANGA MEDIANA</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="3601B5DB-0ACE-468D-80CD-4DE5831362D6">BATANGA GRANDE</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="0EF1486A-A756-4064-981D-A5DDFF46F9B4">HILUX</option>');
     //            $('#cmbProyectosEditarCC').append('<option value="83099F5D-8420-45DF-BAFC-5218A79D2233">FRONTIER 2021</option>');
     //            $.each(json, function (index, value) {
     //                $("#cmbProyectosEditarCC").append('<option value="' + value.Id.toUpperCase() + '">' + value.Nombre.toUpperCase() + '</option>');
     //            });

     //            $('#cmbProyectosEditarCC').selectpicker('refresh');
     //            $('#cmbProyectosEditarCC').selectpicker('render');
     //            var id = IdProyecto.toUpperCase();
     //            $('#cmbProyectosEditarCC').val(id);
     //            $('#cmbProyectosEditarCC').selectpicker('refresh');
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
              <li><i class="icon_building"></i>CajaChica</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeCajaChica">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <header class="panel-heading">
                Lista de CajaChica 
                  <div class="btn-group" id="botones">
                      <form class="form-inline">
                          <div class="form-group">
                            <%--<Button class="btn btn-primary" data-toggle="modal" data-target="#AddCajaChicaModal"><i class="icon_plus_alt2"></i></Button>--%>
                              <a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#AddCajaChicaModal"><i class="icon_plus_alt2"></i> Agregar </a>
                          </div>
                          <%--<div class="form-group">
                            <input class="form-control col-md-3 light-table-filter" data-table="order-table" type="text" placeholder="Buscar">
                          </div>--%>
                      
                      </form>
                        
                      </div>
              </header>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_content">

                            <div id="toolbar">

                            </div>

                            <table id="TablaCajaChica" class="table table-striped table-sm" data-search="true" data-show-refresh="true" data-show-export="true" data-query-params="queryParams" data-pagination="true" data-toolbar="#toolbar">
                                <thead>
                                    <tr>
                                        <th data-field="Fecha" data-sortable="true" data-formatter="dateFormat"><i class="icon_calendar"></i> Fecha</th>
                                        <th data-field="Responsable" data-sortable="true"><i class="icon_profile"></i> Responsable</th>
                                        <th data-field="CampoExtra" data-sortable="true"><i class="icon_profile"></i> Responsable (2)</th>
                                        <th data-field="Concepto" data-sortable="true"><i class="icon_info_alt"></i> Concepto</th>
                                        <th data-field="Proyecto" data-sortable="true"><i class="icon_tags_alt"></i> Proyecto</th>

                                        <th data-field="Comprobante" data-sortable="true"><i class="icon_document_alt"></i> Comprobante</th>
                                        <th data-field="Cargo" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_calculator_alt"></i> Cargo</th>
                                        <th data-field="Abono" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_calculator_alt"></i> Abono</th>
                                        <th data-field="Saldo" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_calculator_alt"></i> Saldo</th>
                                        <th data-field="Categoria" data-sortable="true"><i class="icon_box-empty"></i> Categoria</th>

                                        <th data-align="center" data-formatter="accionCC1Formatter" data-events="accionCC1Events"><i class="icon_ol"></i>Accion</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                </div>
                <%--<div class="form-group" id="CargandoCajaChica">
                     <label id="txtMensajeDatos"></label>
                  </div>
                <div style="overflow-x: auto; overflow-y: auto;"> 
              <table class="table table-advance table-hover order-table" id="TablaCajaChica">
                <thead>
                  <tr>
                    <th style="display:none;"><i class="icon_building"></i>Código</th>
                      <th><i class="icon_calendar"></i> Fecha</th>  
                      <th><i class="icon_profile"></i> Responsable</th>
                      <th><i class="icon_profile"></i> Responsable (2)</th>
                                      
                      <th><i class="icon_info_alt"></i> Concepto</th>
                    <th><i class="icon_tags_alt"></i>Proyecto</th>
                    <th><i class="icon_document_alt"></i>Comprobante</th>
                    <th><i class="icon_calculator_alt"></i>Cargo</th>
                    <th><i class="icon_calculator_alt"></i>Abono</th>
                    <th><i class="icon_calculator_alt"></i>Saldo</th>
                    <th><i class="icon_box-empty"></i>Categoria</th>
                      
                    <th><i class="icon_ol"></i> Acciones</th>
                  </tr>
                 </thead>
                <tbody id="listaCajaChica">
                   
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
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="AddCajaChicaModal" tabindex="-1" role="dialog" aria-labelledby="AddCajaChicaModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelAgregarCajaChica">Agregar CajaChica</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">
       
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Fecha:</label>
                  <input type="date" class="form-control" id="dtFecha" required />
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Responsable:</label>
                  <select class="form-control selectpicker" id="txtResponsable" data-live-search="true"></select>
                  <%--<input type="text" class="form-control" id="txtResponsable" required />--%>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Responsable (2):</label>
                  <%--<select class="form-control selectpicker" id="txtResponsable2" data-live-search="true"></select>--%>
                  <input type="text" class="form-control" id="txtResponsable2" />
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Concepto:</label>
                  <input type="text" class="form-control" id="txtConcepto" required />
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Proyecto:</label>
                  <select id="cmbProyectos" class="form-control selectpicker" data-live-search="true" required></select>
              </div>
              </div>
              <div class="form-group">
                  <div class="col-sm-10">
                       <label>Comprobante:</label>
                      <select id="cmbComprobante" class="form-control" required>
                          <option value="SIN COMPROBANTE">SIN COMPROBANTE</option>
                          <option value="TICKET">TICKET</option>
                          <option value="FACTURA">FACTURA</option>
                          <option value="NOTA">NOTA</option>
                          <option value="RECIBO DE EFECTIVO">RECIBO DE EFECTIVO</option>
                          <option value="VIATICOS">VIATICOS</option>
                          <option value="ORDEN DE COMPRA">ORDEN DE COMPRA</option>
                          <option value="N/A">N/A</option>
                          <option value="PENDIENTE">PENDIENTE</option>
                      </select>
                  </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Cargo:</label>
                  <input type="number" class="form-control" id="txtCargo" required/>
              </div>
            </div>      
          <div class="form-group">
              <div class="col-sm-10">
                  <label>Abono:</label>
                  <input type="number" class="form-control" id="txtAbono" required/>
              </div>
            </div>  
          <div class="form-group">
                  <div class="col-sm-10">
                       <label>Estatus:</label>
                      <select id="cmbEstatus" class="form-control" required>
                          <option value="0">PENDIENTE</option>
                          <option value="1">COMPLETO</option>                          
                      </select>
                  </div>
            </div>
          <div class="form-group">
                  <div class="col-sm-10">
                       <label>Categoria:</label>
                      <select id="cmbCategoriaCC" class="form-control" required>
                          <option value="MATERIAL">MATERIAL</option>
                          <option value="MANOOBRA">MANO DE OBRA</option>
                          <option value="EQUIPO">EQUIPO</option>
                          <option value="N/A">N/A</option>                          
                      </select>
                  </div>
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-primary" id="btnGuardarCajaChica" type="button">Crear</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--ELIMINAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="DelCajaChicaModal" tabindex="-1" role="dialog" aria-labelledby="DelCajaChicaModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEliminarCajaChica">Eliminar CajaChica</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">        
            <div class="form-group" id="txtModalEliminarCajaChica">
              <label id="idCajaChicaEliminar" hidden="hidden"></label>               
              <label id="idCajaChicaEliminarTexto"></label>               
            </div>
          <div class="form-group" id="txtModalEliminarMensajeCajaChica">
                              
            </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button class="btn btn-danger" id="btnEliminarCajaChica" type="button">Eliminar</button>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--EDITAR--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="EditCajaChicaModal" tabindex="-1" role="dialog" aria-labelledby="EditCajaChicaModal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabelEditarCajaChica">Editar CajaChica</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal" id="EditarCajaChicaForm"></form>
        
         
    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/CajaChica.js" type="text/javascript"></script>
    
</asp:Content>





