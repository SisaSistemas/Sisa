$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("EnviarCorreo.aspx") > -1) {
        
        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        var tipo = document.getElementById('MainContent_TipoEnviar').textContent;
        if (tipo == '1') {
            CargarInformacionOC();
        } else if (tipo == '2') {
            CargarInformacionCotizacion();
        }

        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }    

    var editor = CKEDITOR.replace('MainContent_editor1');

    function CargarInformacionOC() {

        var parametros = "{'pid': '" + document.getElementById('MainContent_idEnviar').textContent + "'}";
        $.ajax({
            dataType: "json",
            url: "EnviarCorreo.aspx/ObtenerOC",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                //debugger;
                if (data.d != "Error, no se encontro información de correo.") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {

                        var Folio = item.FOLIO;
                        var Proveedor = item.DIRIGIDO;
                        var Correo = item.CORREO;
                        var CorreoU = item.ENVIADOR;
                        $('#LabelEnviarOC').text('Enviar Correo al Proveedor: ' + Proveedor);
                        //document.getElementById('LabelEnviarOC').textContent = 'Enviar Correo al Proveedor: ' + Proveedor;
                        
                        document.getElementById('MainContent_txtSubject').value = Folio + ' - ' + Proveedor;
                        document.getElementById('MainContent_txtPara').value = Correo;
                        document.getElementById('MainContent_txtCorreo').value = CorreoU;
                        //var editor = CKEDITOR.instances.editor1;
                        ////var value = document.getElementById('htmlArea').value;
                        editor.insertHtml('<p>Buen día, <br /> '
                        + 'Adjunto orden de compra autorizada <b style = "font: bold; color:blue;" > <label id="OCText">No. '+ Folio +'</label> </b > Para su envió a la brevedad posible.<br />'
                        + '    <br />'
                        + 'Quedo a sus órdenes para cualquier duda o información que requiera. <br />'
                        + '    Favor de verificar que la información sea correcta y confirmar de recibido.<br /> <br />'
                        + ''
                        + 'Saludos <br /> <br />'
                        + 'Anexo nuestro link para mayor información <br />'
                        + '        <a href="http://www.sistemasautomatizados.net/SISA/es/index.html" target="_blank">http://www.sistemasautomatizados.net/SISA/es/index.html</a>'
                        + '                <br /><br />'
                        + '           '
                        + '                <br /><br />'
                            + '            </p >');


                        //CKEDITOR.appendTo('cke_MainContent_editor1',
                        //    null,
                        //    '<p>Buen día, <br /> '
                        //+ 'Adjunto orden de compra autorizada <b style = "font: bold; color:blue;" > <label id="OCText">No. '+ Folio +'</label> </b > Para su envió a la brevedad posible.<br />'
                        //+ '    <br />'
                        //+ 'Quedo a sus órdenes para cualquier duda o información que requiera. <br />'
                        //+ '    Favor de verificar que la información sea correcta y confirmar de recibido.<br /> <br />'
                        //+ ''
                        //+ 'Saludos <br /> <br />'
                        //+ 'Anexo nuestro link para mayor información <br />'
                        //+ '        <a href="http://www.sistemasautomatizados.net/SISA/es/index.html" target="_blank">http://www.sistemasautomatizados.net/SISA/es/index.html</a>'
                        //+ '                <br /><br />'
                        //+ '           '
                        //+ '                <br /><br />'
                        //    + '            </p >'
                        //);
                       
                        //document.getElementById('cke_MainContent_editor1').textContent = '<p>Buen día, <br /> ' 
                        //+ 'Adjunto orden de compra autorizada <b style = "font: bold; color:blue;" > <label id="OCText">No. '+ Folio +'</label> </b > Para su envió a la brevedad posible.<br />'
                        //+ '    <br />'
                        //+ 'Quedo a sus órdenes para cualquier duda o información que requiera. <br />'
                        //+ '    Favor de verificar que la información sea correcta y confirmar de recibido.<br /> <br />'
                        //+ ''
                        //+ 'Saludos <br /> <br />'
                        //+ 'Anexo nuestro link para mayor información <br />'
                        //+ '        <a href="http://www.sistemasautomatizados.net/SISA/es/index.html" target="_blank">http://www.sistemasautomatizados.net/SISA/es/index.html</a>'
                        //+ '                <br /><br />'
                        //+ '           '
                        //+ '                <br /><br />'
                        //    + '            </p >';
                        //debugger;

                    });

                }
                else {
                    swal(data.d);
                }
            }
        });
    }

    function CargarInformacionCotizacion() {

        var parametros = "{'pid': '" + document.getElementById('MainContent_idEnviar').textContent + "'}";
        $.ajax({
            dataType: "json",
            url: "EnviarCorreo.aspx/ObtenerOC",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d != "Error") {
                    var json = JSON.parse(data.d);
                    $(json).each(function (index, item) {

                        var Folio = item.FOLIO;
                        var Cliente = item.DIRIGIDO;
                        var Correo = item.CORREO;
                        var CorreoU = item.ENVIADOR;
                        document.getElementById('LabelEnviarOC').textContent = 'Enviar Correo al cliente: ' + Cliente;

                        document.getElementById('MainContent_txtSubject').value = Folio + ' - ' + Cliente;
                        document.getElementById('MainContent_txtPara').value = Correo;
                        document.getElementById('MainContent_txtCorreo').value = CorreoU;
                        document.getElementById('MainContent_editor1').textContent = '<p>Buen día, <br /> '
                            + 'Adjunto cotización <b style = "font: bold; color:blue;" > <label id="OCText">No. ' + Folio + '</label> </b > Para su revisión a la brevedad posible.<br />'
                            + '    <br />'
                            + 'Quedo a sus órdenes para cualquier duda o información que requiera. <br />'
                            + '    Favor de verificar que la información sea correcta y confirmar de recibido.<br /> <br />'
                            + ''
                            + 'Saludos <br /> <br />'
                            + 'Anexo nuestro link para mayor información <br />'
                            + '        <a href="http://www.sistemasautomatizados.net/SISA/es/index.html" target="_blank">http://www.sistemasautomatizados.net/SISA/es/index.html</a>'
                            + '                <br /><br />'
                            + '           '
                            + '                <br /><br />'
                            + '            </p >';


                    });

                }
                else {
                    swal('Recarga página, ocurrio un error.');
                }
            }
        });
    }
});