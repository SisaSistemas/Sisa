$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("Requisicion-Edicion.aspx") > -1) {
        
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarRequisiciones();

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }
    function CargarRequisiciones() {
        var parametros = "{'pid': '1'}";
        $.ajax({
            dataType: "json",
            url: "Requisicion-Edicion.aspx/ObtenerRequisicion",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {
                        var idRequisiciones = item.IdReqEnc;
                        var Folio = item.NoReq;
                        var Proyecto = item.NombreProyecto;
                        var Fecha = item.Fecha;
                        var FechaAutorizada = item.FechaAutorizada;
                        var FechaCompra = item.FechaCompra;
                        var Observaciones = item.Observaciones;
                        $("#txtIdRequicion").val(idRequisiciones);
                        $("#txtComentariosReq").val(Observaciones);
                        $("#txtFecha").val(Fecha);
                        $("#txtFolio").val(Folio);
                        $("#txtProyecto").val(Proyecto);
                        CargarDetalles();
                    });
                }
                else {
                    $("#CargandoRequisiciones").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }
            }
        });
    }
    var item = 0;
    function CargarDetalles() {
        var parametros = "{'pid': '1'}";
        $.ajax({
            dataType: "json",
            url: "Requisicion-Edicion.aspx/ObtenerRequisicionDetalle",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {
                        var idDetalle = item.IdReqDet;
                        var numero = item.Item;
                        var Descripcion = item.Descripcion;
                        var Cantidad = item.Cantidad;
                        var Unidad = item.Unidad;
                        var NumParte = item.NumeroParte;
                        var Marca = item.Marca;
                        var nodoAInsertar = "<tr>";
                        item = numero;

                        //nodoAInsertar += '<td style="display: none;">';
                        //nodoAInsertar += "  <span>" + idDetalle + "</span>";
                        //nodoAInsertar += "</td>";
                        nodoAInsertar += "  <td><span>" + numero + "</span></td>";      
                        nodoAInsertar += "<td>";
                        nodoAInsertar += "  <span>" + Descripcion + "</span>";
                        nodoAInsertar += "</td>";
                        nodoAInsertar += "<td>";
                        nodoAInsertar += "  <span>" + Cantidad + "</span>";
                        nodoAInsertar += "</td>";
                        nodoAInsertar += "<td>";
                        nodoAInsertar += "  <span>" + Unidad + "</span>";
                        nodoAInsertar += "</td>";
                        nodoAInsertar += "<td>";
                        nodoAInsertar += "  <span>" + NumParte + "</span>";
                        nodoAInsertar += "</td>";
                        nodoAInsertar += "<td>";
                        nodoAInsertar += "  <span>" + Marca + "</span>";
                        nodoAInsertar += "</td>";
                        nodoAInsertar += "  <td><span class='icon_close_alt eliminar'></span></td>";
                        nodoAInsertar += "</tr>";

                        $("#tblReqAddEdit").append(nodoAInsertar);
                        
                    });
                }
                else {
                    $("#CargandoRequisiciones").append('<div class="alert alert-danger fade in"><p>No se obtuvo información.</p></div >');

                }
            }
        });
    }
    $('#btnAgregarItem').click(function () {
        var txtDescripcion = document.getElementById('txtDescripcion').value;
        var txtCantidad = document.getElementById('txtCantidad').value;
        var txtUnidad = document.getElementById('txtUnidad').value;
        if (txtDescripcion == "" || txtCantidad == "" || txtUnidad == "") {
            $('.agregaedita').val("");
            //$("#AddMsgRequisiciones").append('<div class="alert alert-danger fade in"><p>Completa los campos obligatorios.</p></div >');
            swal('Completa los campos obligatorios.');
            return;
        }
        else {
            var nodoAInsertar = "<tr>";
            var tbl = document.getElementsByTagName("body")[0];
            var tr = tbl.getElementsByTagName("tr");
            item = tr.length;
            //for (i = 0; i < tr.length; i++) {
            //    item += 1;
            //}

            //nodoAInsertar += '  <td style="display: none;"><span></span></td>';
            nodoAInsertar += "  <td><span>" + item + "</span></td>";

            $(".agregaedita").each(function () {
                nodoAInsertar += "<td>";
                nodoAInsertar += "  <span>" + $(this).prop("value") + "</span>";
                nodoAInsertar += "</td>";
            });
            nodoAInsertar += "  <td><span class='icon_close_alt eliminar'></span></td>";
            nodoAInsertar += "</tr>";
            $("#tblReqAddEdit").append(nodoAInsertar);
            $('.agregaedita').val("");
            $("#txtDescripcion").focus();
        }      

    });
    $('#btnActualizarRequisiciones').click(function () {
        var id = $('#txtIdRequicion').val(); 
        var Comentarios = $('#txtComentariosReq').val();
        var parametros = "{'pObservaciones': '" + Comentarios + "', 'pid': '" + id + "'}";
        $.ajax({
            dataType: "json",
            url: "Requisicion-Edicion.aspx/GuardarRequisiciones",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "Requisiciones actualizadas.") {

                    var items = 0;
                    var itemsGuardados = 0;
                    //guardar detalles
                    $("#tblReqAddEdit tbody tr").each(function (index) {
                        items++;
                    });


                    $("#tblReqAddEdit tbody tr").each(function (index) {
                        var item, descripcion, cantidad, unidad, numParte, marca;

                        $(this).children("td").each(function (index2) {
                            switch (index2) {
                                case 0:
                                    item = $(this).find("span").text();
                                    break;
                                case 1:
                                    descripcion = $(this).find("span").text();
                                    break;
                                case 2:
                                    cantidad = $(this).find("span").text();
                                    break;
                                case 3:
                                    unidad = $(this).find("span").text();
                                    break;
                                case 4:
                                    numParte = $(this).find("span").text();
                                    break;
                                case 5:
                                    marca = $(this).find("span").text();
                                    break;
                            }
                        });

                        var param = "{'pItem': '" + item
                            + "','pDescripcio': '" + descripcion
                            + "','pCantidad': '" + cantidad
                            + "','pUnidad': '" + unidad
                            + "','pNumParte': '" + numParte
                            + "','pMarca': '" + marca + "'}";

                        $.ajax({
                            async: true,
                            url: "Requisicion-Edicion.aspx/GuardarRequisicionesDetalle",
                            dataType: "json",
                            data: param,
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data, textStatus) {

                                itemsGuardados++;

                                if (itemsGuardados == items) {
                                    CargarRequisiciones();
                                    swal('Requisición actualizada.');
                                }
                            }
                        });
                    });
                    // $("#AddMsgRequisiciones").append('<div class="alert alert-success fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
                else {
                    //$("#AddMsgRequisiciones").append('<div class="alert alert-danger fade in"><p>' + msg.d + '</p></div >');
                    swal(msg.d);
                }
            }
        });    
    });

    

    $(document).on('click', '.eliminar', function (event) {
        var boton = $(this);

        var padreTRBoton = $(boton).parent().parent();

        padreTRBoton.remove();

        item -= 1;

        $("#txtDescripcion").focus();
    });
});