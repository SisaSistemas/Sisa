<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerViaticos.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Proyecto.VerViaticos" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <script>
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $("[id*='ImgPrv']").prop('src', e.target.result)
                        .width(240)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }

        function AgregarTicket(btn) {
            swal({
                title: 'Seleccione ticket (Imágen)',
                input: 'file',
                allowOutsideClick: false,
                allowEscapeKey: false,
                allowEnterKey: false,
                showCloseButton: true
            }).then(function (file) {
                var nombreArchivo = file.name;
                var reader = new FileReader
                reader.onload = function (e) {
                    //debugger;
                    //console.log(nombreArchivo);

                    //var params = "{'IdCotizacion': '" + idCotizacion +
                    //    "','NombreArchivo': '" + nombreArchivo +
                    //    "','Documento': '" + e.target.result + "'}";

                    var params = "{'TipoDoc': '" + '1' +
                        "','Id': '" + btn.value +
                        "','FileName': '" + nombreArchivo +
                        "','File': '" + e.target.result + "'}";

                    //console.log(params);
                    $.ajax({
                        dataType: "json",
                        async: true,
                        url: "VerViaticos.aspx/GuardarDocumentos",
                        data: params,
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (msg) {
                            //location.href = './frmProjects.aspx';

                            swal({
                                title: msg.d,
                                timer: 3000
                            });
                            location.reload();
                            //cargarArchivos();
                        },
                        error: function (xhr, ajaxOptions, thrownError) {

                        }
                    });


                }

                reader.readAsDataURL(file);

            });
        }
        function VisualizarDocumentoTicket(btn) {
            $('#testmodalpdfTicket').html('');

            var params = "{'Id': '" + btn.value +
                "','Opcion': '" + "T" + "'}";
            $.ajax({
                async: true,
                url: "VerViaticos.aspx/CargarDocumentos",
                dataType: "json",
                data: params,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data, textStatus) {
                    var datos = "";

                    var JsonCombos;
                    var jsonArray = $.parseJSON(data.d);


                    $.each(jsonArray, function (index, value) {
                        document.getElementById('txtTipoDocumentoTicket').textContent = "T";

                        document.getElementById('txtidArchivoTicket').textContent = value.IdDet;
                        if (value.Ticket.includes("PDF") || value.Ticket.includes("pdf")) {

                            $('#testmodalpdfTicket').append('<embed src="' + value.Ticket + '" type="application/pdf" width="100%" height="600px" />');
                        }
                        else {

                            $('#testmodalpdfTicket').append('<img src="' + value.Ticket + '" width="500" height="500"/>');
                        }

                    });
                }
            });
            $("#dvPDFTicket").modal();

        }

        function EliminarViatico(btn) {

            swal({
                title: "Esta seguro que desea eliminar información de viatico?",
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

                var params = "{'Id': '" + btn.value + "', 'Gastada':'" + document.getElementById('lblCantGastada').textContent + "', 'Entregada':'" + document.getElementById('lblCantEntregada').textContent + "', 'Diferencia':'" + document.getElementById('lblDiferencia').textContent + "'}";

                $.ajax({
                    dataType: "json",
                    async: true,
                    url: "VerViaticos.aspx/EliminarViatico",
                    data: params,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        swal({
                            title: msg.d,
                            timer: 3000
                        });
                        //CargarViaticoTodo();
                        setTimeout(function () { location.reload() }, 1000);
                    },
                    error: function (xhr, ajaxOptions, thrownError) {

                    }
                });


            }, function (dismiss) {
                // dismiss can be 'cancel', 'overlay',
                // 'close', and 'timer'
                if (dismiss === 'cancel') {
                    swal(
                        'Cancelado',
                        'Cancelaste eliminación.',
                        'error'
                    );
                }
            });
        }
        function ActualizaMontoViatico() {
            $("#modalEntregada").modal();
        }
    </script>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <div id="loading-img">  <img src="../img/logoloading.png" /></div>--%>
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Administración</li>
                        <li><i class="icon_building"></i>Viaticos</li>
                    </ol>
                </div>
            </div>
            <!-- page start-->



            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div class="form-group" id="MensajeViaticos">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>
                        <header class="panel-heading">
                            Vista de Viaticos 
                  
                        </header>
                        <div class="form-group" id="CargandoViaticos">
                            <%--<label id="txtMensajeDatos"></label>--%>
                        </div>
                    </section>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <section class="panel">
                        <header class="panel-heading">
                            Agregar registro de gastos
                        </header>
                        <div class="panel-body">
                            <%--<form role="form">--%>
                            <div class="form-group">
                                <label>Proyecto al que se registra inicialmente.</label>
                                <select class="form-control" id="cmbProyectos" required>
                                </select>
                            </div>
                            <label><b>Elegir proyecto diferente.</b></label>
                            <input type="checkbox" id="chkViatico" class="flat"><span id="txtTextoViaticos">NO</span>
                            <div class="form-group">
                                <label>Proyecto.</label>
                                <select class="form-control selectpicker" data-live-search="true" id="cmbProyectosNuevos">
                                </select>
                            </div>
                            <div class="form-group">
                                <label>Concepto</label>
                                <input class="form-control" type="text" id="txtDescripcion" placeholder="Descripción" required />
                            </div>
                            <div class="form-group">
                                <label>Cantidad gastada</label>
                                <input class="form-control" type="number" id="txtCantidad" placeholder="Precio" required />
                            </div>
                            <div class="form-group">
                                <label>Tipo de gasto</label>
                                <select class="form-control" id="cmbGasto" required>
                                    <option value="1" selected>Gasolina</option>
                                    <option value="2">Desayuno</option>
                                    <option value="3">Comida</option>
                                    <option value="4">Cena</option>
                                    <option value="5">Casetas</option>
                                    <option value="6">Hotel</option>
                                    <option value="7">Transporte</option>
                                    <option value="8">Otros</option>
                                    <option value="9">Material</option>
                                    <option value="10">Mano de Obra</option>
                                    <option value="11">Equipo</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <label>Fecha Gasto</label>
                                <input type="date" class="form-control" id="dtFechaGasto">
                            </div>
                            <div class="form-group">
                                <label>Ticket</label>
                                <%-- <input type="file" id="Ticket"  required>--%>
                                <form runat="server">
                                    <asp:FileUpload CssClass="form-control" ID="Ticket" runat="server" onchange="ShowImagePreview(this);" accept="image/png, image/jpeg, application/pdf" />
                                    <asp:Image ID="ImgPrv" Height="50px" Width="50px" ClientIDMode="Static" runat="server" /><br />
                                </form>

                                <p class="help-block"></p>
                            </div>
                            <button type="submit" id="btnAgregarGastos" class="btn btn-primary">Agregar</button>
                            <%--</form>--%>
                        </div>


                    </section>
                </div>
                <div class="col-sm-6">
                    <section class="panel">
                        <header class="panel-heading">
                            Totales
                        </header>
                        <table class="table">
                            <tbody>
                                <tr>
                                    <th style="width: 50%">Cantidad Entregada:</th>
                                    <td><span id="lblCantEntregada"></span>
                                        <button title="Actualizar monto" class="btn btn-success" onclick="ActualizaMontoViatico();"><i class="icon_pencil"></i></button>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Cantidad Gastada</th>
                                    <td><span id="lblCantGastada"></span></td>
                                </tr>
                                <tr>
                                    <th>Diferencia:</th>
                                    <td><span id="lblDiferencia"></span></td>
                                </tr>
                                <tr>
                                    <th>Persona que recibio:</th>
                                    <td><span id="lblResponsable"></span></td>
                                </tr>
                                <tr>
                                    <th>Proyecto para el que se otorgo:</th>
                                    <td><span id="lblProyectoPrincipal"></span></td>
                                </tr>
                            </tbody>
                        </table>
                    </section>

                    <section class="panel">
                        <header class="panel-heading">
                            <div class="col-md-4 col-sm-4">
                                <input type="text" class="form-control col-sm-4 decimal-2-places" placeholder="Cantidad Entregada" id="txtCantidadEntregada" required />
                            </div>
                            
                            <span class="btn btn-primary" id="btnAgregar"><i class="icon_plus"></i> Agregar</span>
                        </header>
                        <table class="table table-sm table-striped" data-pagination="true" id="Tabla">
                            <thead id="EncabezadoFacturas">
                                <tr>
                                    <th data-field="ID" data-sortable="true"><i class="icon_calendar"></i> Id</th> 
                                    <th data-field="Cantidad" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_currency"></i> Cantidad Entregada</th>     
                                    <th data-field="FechaAlta" data-formatter="dateFormat" data-sortable="true"><i class="icon_calendar"></i> Fecha Alta</th>          
                                                                                     
                                    <th data-align="center" data-formatter="accionFormatter" data-events="accionEvents"><i class="icon_ol"></i> Acciones</th>             
                                </tr >
                            </thead>
                            <%--<tbody id="listaFacturas">
                            </tbody>--%>
                        </table>
                    </section>
                </div>
            </div>



            <!-- Table row -->
            <div class="row">

                <div class="col-lg-12 table">

                    <table class="table table-striped" id="tblViaticos">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Fecha</th>
                                <th>Proyecto</th>
                                <th>Concepto</th>
                                <th>Gasolina</th>
                                <th>Desayuna</th>
                                <th>Comida</th>
                                <th>Cena</th>
                                <th>Casetas</th>
                                <th>Hotel</th>
                                <th>Transporte</th>
                                <th>Otros</th>
                                <th>Mano de obra</th>
                                <th>Materiales</th>
                                <th>Equipo</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th></th>
                                <th></th>
                                <th colspan="2">Totales</th>
                                <th><span id="lblGasolina">$     0.00</span></th>
                                <th><span id="lblDesayuno">$     0.00</span></th>
                                <th><span id="lblComida">$     0.00</span></th>
                                <th><span id="lblCena">$     0.00</span></th>
                                <th><span id="lblCasetas">$     0.00</span></th>
                                <th><span id="lblHotel">$     0.00</span></th>
                                <th><span id="lblTransporte">$     0.00</span></th>
                                <th><span id="lblOtros">$     0.00</span></th>
                                <th></th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->

            <div class="row">
                <!-- accepted payments column -->
                <div class="col-xs-6">
                </div>
                <!-- /.col -->

                <!-- /.col -->
            </div>
            <!-- /.row -->

            <!-- this row will not appear when printing -->
            <div class="row no-print">
                <div class="col-xs-12">
                    <button class="btn btn-default" onclick="window.print();"><i class="fa fa-print fa-fw"></i>Imprimir</button>
                    <%--<button class="btn btn-success pull-right"><i class="fa fa-credit-card"></i>Submit Payment</button>--%>
                    <%--<button class="btn btn-primary pull-right" style="margin-right: 5px;" id="btnGuardar"><i class="fa fa-save fa-fw"></i>Guardar</button>--%>
                </div>
            </div>


            <!-- page end-->
        </section>
    </section>
    <%--Ticket--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvPDFTicket" tabindex="-1" role="dialog" aria-labelledby="dvPDFTicket" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabeldvPDFTicket">Visualizar ticket</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal">
                    <div class="modal-body">
                        <label id="txtidArchivoTicket" hidden="hidden"></label>
                        <label id="txtTipoDocumentoTicket" hidden="hidden"></label>
                        <div id="testmodalpdfTicket" style="padding: 5px 20px;">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button type="button" class="btn btn-danger" id="btnEliminadDocumentoTicket" data-dismiss="modal">Eliminar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <%--PDF--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="dvPDFViatico" tabindex="-1" role="dialog" aria-labelledby="dvPDFViatico" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title" id="LabeldvPDFViatico">Archivo</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          
        </button>
      </div>
        <form class="form-horizontal ">
      <div class="modal-body">
        <div id="testmodalpdfViatico" style="padding: 5px 20px;">
                       
                    </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
          <button type="button" class="btn btn-danger" id="btnEliminadDocumentoTicketPDF" data-dismiss="modal">Eliminar</button>
        <%--<button type="button" class="btn btn-danger" id="btnEliminadDocumentoCot" data-dismiss="modal">Eliminar</button>--%>
        <%--<button type="button" class="btn btn-danger" id="btnDescargarDocumentoCot" data-dismiss="modal">Descargar</button>--%>
      </div>
      </form>
    </div>
  </div>
</div>
    <%--CAMBIAR ENTREGADA--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="modalEntregada" tabindex="-1" role="dialog" aria-labelledby="modalEntregada" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelmodalEntregada">Actualizar monto</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Proporciona cantidad total</label>
                                <input type="text" class="form-control" id="txtMontoEntregadoNuevo" placeholder="Cantidad recibida." />
                                <label style="font-size: smaller;">Si estas agregando mas dinero, proporciona la cantidad total de la suma, ejemplo: si la cantidad es de 100 y se le otorgaron 100 mas, la cantidad a introducir es de 200. Lo mismo sucede cuando se disminuye la cantidad entregada.</label>
                            </div>

                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button type="button" class="btn btn-info" id="btnActualizaCantidadViatico" data-dismiss="modal">Guardar cambios</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/jquery.numeric.js"></script>
    <script src="<%= ResolveUrl("~") %>js/VerViatico.js" type="text/javascript"></script>
</asp:Content>







