$(document).ready(function () {
    var URLactual = window.location;
    if (URLactual.href.indexOf("ControlProyectos.aspx") > -1) {

        //$("#main-content").css("opacity", 0.2);
        //$("#loading-img").css({ "display": "block" });

        CargarProyectos();
        //CargarTotal();
        //setTimeout(function () {
        //    $("#main-content").css("opacity", 1);
        //    $("#loading-img").css({ "display": "none" });
        //}, 3000);
    }

    function CargarProyectos() {

        var parametros = "{'pid': '1'}";
        $.ajax({
            dataType: "json",
            url: "OrdenCompra.aspx/ObtenerOC",
            async: true,
            data: parametros,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                //debugger;
                var jsonArray = $.parseJSON(data.d);

                //$('#TablaOC').bootstrapTable('destroy');

                data = jsonArray;

                $('#tblProyectos').bootstrapTable({
                    data: data,
                    detailView: false,
                    striped: true,
                    //pagination: true,
                    //onlyInfoPagination: true,
                    pageSize: 100,
                    idField: 'IdProyecto',
                    uniqueId: 'IdProyecto',
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

});