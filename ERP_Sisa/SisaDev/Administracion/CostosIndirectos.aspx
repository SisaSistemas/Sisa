<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="CostosIndirectos.aspx.cs" Inherits="SisaDev.Administracion.CostosIndirectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">

                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Administración</li>
                        <li><i class="icon_building"></i>Costos Indirectos</li>
                    </ol>
                </div>
            </div>
            <!-- page start-->
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div class="form-group" id="MensajeSucursales"></div>
                        <header class="panel-heading">
                            Lista de sucursales 
                            <div class="btn-group" id="botones">
                                <form class="form-inline">
                                    <div class="form-group">
                                        <a class="btn btn-primary add-link" data-toggle="modal" data-keyboard="false" data-backdrop="static" id="btnTipoCambio"><i class="icon_plus_alt2"></i>Obtener Tipo de Cambio </a>| 
                                        <a class="btn btn-primary add-link" title="Capturar Datos" data-toggle="modal" id="btnCaptura" data-keyboard="false" data-backdrop="static" data-target="#CapturaDatosModal"><i class="icon_plus_alt2"></i>Capturar Datos </a>
                                    </div>
                                </form>

                            </div>
                        </header>
                        <div class="form-group" id="CargandoDatos"></div>
                        <div style="overflow-x: auto; overflow-y: auto; height: 100%;">
                            <table class="table table-sm" data-pagination="true" id="TablaCostoIndirecto" data-search="true">
                                <thead>
                                    <tr>
                                        <th data-align="center" data-formatter="accionFormatter" data-events="accionEvents"><i class="icon_ol"></i>Acciones</th>
                                        <th data-field="FechaIni" data-sortable="true" data-formatter="dateFormat"><i class="icon_info_alt"></i>Desde</th>
                                        <th data-field="FechaFin" data-sortable="true"data-formatter="dateFormat"><i class="icon_info_alt"></i>Hasta</th>
                                        <th data-field="TotalGlobal" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_building"></i>Global</th>
                                        <th data-field="PorcentajeGlobal" data-sortable="true" data-formatter="formatoPorcentajeFormatter"><i class="icon_building"></i>% Global</th>
                                        <th data-field="TotalHermosillo" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_building"></i>Hermosillo</th>
                                        <th data-field="PorcentajeHermosillo" data-sortable="true" data-formatter="formatoPorcentajeFormatter"><i class="icon_building"></i>% Hermosillo</th>
                                        <th data-field="TotalChihuahua" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_book_alt"></i>Chihuahua</th>
                                        <th data-field="PorcentajeChihuahua" data-sortable="true" data-formatter="formatoPorcentajeFormatter"><i class="icon_book_alt"></i>% Chihuahua</th>
                                        <th data-field="TotalCuautitlan" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_info_alt"></i>Cuautitlan</th>
                                        <th data-field="PorcentajeCuautitlan" data-sortable="true" data-formatter="formatoPorcentajeFormatter"><i class="icon_info_alt"></i>% Cuautitlan</th>
                                        <th data-field="TotalIrapuato" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_info_alt"></i>Irapuato</th>
                                        <th data-field="PorcentajeIrapuato" data-sortable="true" data-formatter="formatoPorcentajeFormatter"><i class="icon_info_alt"></i>% Irapuato</th>
                                        <th data-field="TotalQueretaro" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_info_alt"></i>Queretaro</th>
                                        <th data-field="PorcentajeQueretaro" data-sortable="true" data-formatter="formatoPorcentajeFormatter"><i class="icon_info_alt"></i>% Queretaro</th>
                                        <th data-field="TotalTecate" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_info_alt"></i>Tecate</th>
                                        <th data-field="PorcentajeTecate" data-sortable="true" data-formatter="formatoPorcentajeFormatter"><i class="icon_info_alt"></i>% Tecate</th>
                                        <th data-field="TotalUSA" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_info_alt"></i>USA</th>
                                        <th data-field="PorcentajeUSA" data-sortable="true" data-formatter="formatoPorcentajeFormatter"><i class="icon_info_alt"></i>% USA</th>
                                        <th data-field="TotalHermosilloCCM" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_info_alt"></i>Hermosillo CCM</th>
                                        <th data-field="PorcentajeHermosilloCCM" data-sortable="true" data-formatter="formatoPorcentajeFormatter"><i class="icon_info_alt"></i>% Hermosillo CCM</th>
                                        <th data-field="TotalChihuahuaCCM" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_info_alt"></i>Chihuahua CCM</th>
                                        <th data-field="PorcentajeChihuahuaCCM" data-sortable="true" data-formatter="formatoPorcentajeFormatter"><i class="icon_info_alt"></i>% Chihuahua CCM</th>
                                        <th data-field="TotalCuautitlanCCM" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_info_alt"></i>Cuautitlan CCM</th>
                                        <th data-field="PorcentajeCuautitlanCCM" data-sortable="true" data-formatter="formatoPorcentajeFormatter"><i class="icon_info_alt"></i>% Cuautitlan CCM</th>
                                        <th data-field="TotalIrapuatoCCM" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_info_alt"></i>Irapuato CCM</th>
                                        <th data-field="PorcentajeIrapuatoCCM" data-sortable="true" data-formatter="formatoPorcentajeFormatter"><i class="icon_info_alt"></i>% Irapuato CCM</th>
                                        <th data-field="TotalQueretaroCCM" data-sortable="true" data-formatter="formatoMonedaFormatter"><i class="icon_info_alt"></i>Queretaro CCM</th>
                                        <th data-field="PorcentajeQueretaroCCM" data-sortable="true" data-formatter="formatoPorcentajeFormatter"><i class="icon_info_alt"></i>% Queretaro CCM</th>

                                        
                                    </tr>
                                </thead>
                            </table>
                        </div>

                    </section>
                </div>
            </div>
            <!-- page end-->
        </section>
    </section>

    <%--AGREGAR DATOS--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="CapturaDatosModal" tabindex="-1" role="dialog" aria-labelledby="CapturaDatosModal" aria-hidden="true">
        <div class="modal-dialog" style="width: 75%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelCapturaDatos"> 
                        <span>Datos Obtenidos Desde: </span><span id="lblFechaIni"></span><span>Hasta: </span> <span id="lblFechaFin"></span>
                    </h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal ">
                    <div class="modal-body">
                        <%--<div class="form-group">--%>
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="row">
                                    <div class="panel-group">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">DATOS GLOBAL</div>
                                            <div class="panel-body">
                                                <div class="col-lg-6">
                                                    <label>Costo Nomina</label>
                                                    <input type="text" class="form-control costosGlobal" placeholder="Costo Nomina" id="txtNominaGlobal" required />
                                                    <label>Costo IMSS, Infonavit, 3%</label>
                                                    <input type="text" class="form-control costosGlobal" placeholder="Costo IMSS, Infonavit, 3%" id="txtCostoImss" required />
                                                    <label>Interes</label>
                                                    <input type="text" class="form-control costosGlobal" placeholder="Intereses" id="txtInteresGlobal" required />
                                                     <label>Costo Total</label>
                                                    <input type="text" class="form-control" placeholder="Costo Total" id="txtCostoTotal" required />
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Vacaciones</label>
                                                    <input type="text" class="form-control costosGlobal" placeholder="Vacaciones" id="txtVacacionesGlobal" required />
                                                    <label>Aguinaldo</label>
                                                    <input type="text" class="form-control costosGlobal" placeholder="Aguinaldo" id="txtAguinaldoGlobal" required />
                                                    <label>Total Empleados</label>
                                                    <input type="text" class="form-control" placeholder="Total Empleados" id="txtTotalEmpleados" required />
                                                </div>

                                            </div>
                                            <div class="panel-footer">
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                        <span style="font-weight:bold;">Total:</span><span id="lblTotalGlobal"></span>
                                                    </div>
                                                    <div class="col-lg-3">
                                                            <span style="font-weight:bold;">Proyectos:</span><span id="lblTotalProyectos"></span>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <span style="font-weight:bold;">Cotizado:</span><span id="lblTotalCotizado"></span>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <span style="font-weight:bold;">%:</span><span id="lblTotalPorcentaje"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>


                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="panel-group">
                                        <div class="panel panel-primary">
                                            <div class="panel-heading">DATOS SISA&AUT HERMOSILLO</div>
                                            <div class="panel-body">
                                                <div class="col-lg-6">
                                                    <label>Costo Nomina</label>
                                                    <input type="text" class="form-control costosHermosillo" placeholder="Costo Nomina" id="txtNominaHermosillo" required />
                                                    <label>Costo IMSS, Infonavit, 3%</label>
                                                    <input type="text" class="form-control costosHermosillo" placeholder="Costo IMSS, Infonavit, 3%" id="txtCostoImssHermosillo" required />
                                                    <label>Costo Total</label>
                                                    <input type="text" class="form-control" placeholder="Costo Total" id="txtCostoTotalHermosillo" required />
                                                    <label>Total Empleados</label>
                                                    <input type="text" class="form-control" placeholder="Total Empleados" id="txtTotalEmpleadosHermosillo" required />
                                                    <label>Perdida Cambiaria</label>
                                                    <input type="text" class="form-control costosHermosillo" placeholder="Perdida Cambiaria" id="txtPerdidaCambiariaHermosillo" required />
                                                    <label>Utilidad Cambiaria</label>
                                                    <input type="text" class="form-control costosHermosillo" placeholder="Utilidad Cambiaria" id="txtUtilidadCambiariaHermosillo" required />
                                                    <label>Comision Bancaria</label>
                                                    <input type="text" class="form-control costosHermosillo" placeholder="Comision Bancaria" id="txtComisionBancariaHermosillo" required />
                                                    <label>Vacaciones</label>
                                                    <input type="text" class="form-control costosHermosillo" placeholder="Vacaciones" id="txtVacacionesHermosillo" required />
                                                    <label>Aguinaldo</label>
                                                    <input type="text" class="form-control costosHermosillo" placeholder="Aguinaldo" id="txtAguinaldoHermosillo" required />
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Gastos Administrativos</label>
                                                    <input type="text" class="form-control" placeholder="Gastos Administrativos" id="txtGastosAdmonHermosillo" readonly />
                                                    <label>Consumibles Taller</label>
                                                    <input type="text" class="form-control" placeholder="Consumibles Taller" id="txtConsumiblesHermosillo" readonly />
                                                    <label>Gasolina</label>
                                                    <input type="text" class="form-control" placeholder="Gasolina" id="txtGasolinaHermosillo" readonly />
                                                    <label>Equipo Seguridad</label>
                                                    <input type="text" class="form-control" placeholder="Equipo Seguridad" id="txtEquipoSeguridadHermosillo" readonly />
                                                    <label>Inventario Sisa</label>
                                                    <input type="text" class="form-control" placeholder="Inventario Sisa" id="txtInventarioSisaHermosillo" readonly />
                                                    <label>Viaticos</label>
                                                    <input type="text" class="form-control" placeholder="Viaticos" id="txtViaticosHermosillo" readonly />
                                                    <label>Carros</label>
                                                    <input type="text" class="form-control" placeholder="Carros" id="txtCarrosHermosillo" readonly />
                                                    <label>Uniformes</label>
                                                    <input type="text" class="form-control" placeholder="Uniformes" id="txtUniformesHermosillo" readonly />
                                                </div>


                                            </div>
                                            <div class="panel-footer">
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                        <span style="font-weight:bold;">Total:</span><span id="lblTotalHermosillo"></span>
                                                    </div>
                                                    <div class="col-lg-3">
                                                            <span style="font-weight:bold;">Proyectos:</span><span id="lblTotalProyectosHermosillo"></span>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <span style="font-weight:bold;">Cotizado:</span><span id="lblTotalCotizadoHermosillo"></span>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <span style="font-weight:bold;">%:</span><span id="lblTotalPorcentajeHermosillo"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="panel-group">
                                        <div class="panel panel-primary">
                                            <div class="panel-heading">DATOS SISA&AUT CHIHUAHUA</div>
                                            <div class="panel-body">
                                                <div class="col-lg-6">
                                                    <label>Costo Nomina</label>
                                                    <input type="text" class="form-control costosChihuahua" placeholder="Costo Nomina" id="txtNominaChihuahua" required />
                                                    <label>Costo IMSS, Infonavit, 3%</label>
                                                    <input type="text" class="form-control costosChihuahua" placeholder="Costo IMSS, Infonavit, 3%" id="txtCostoImssChihuahua" required />
                                                    <label>Costo Total</label>
                                                    <input type="text" class="form-control" placeholder="Costo Total" id="txtCostoTotalChihuahua" required />
                                                    <label>Total Empleados</label>
                                                    <input type="text" class="form-control" placeholder="Total Empleados" id="txtTotalEmpleadosChihuahua" required />
                                                    <label>Perdida Cambiaria</label>
                                                    <input type="text" class="form-control costosChihuahua" placeholder="Perdida Cambiaria" id="txtPerdidaCambiariaChihuahua" required />
                                                    <label>Utilidad Cambiaria</label>
                                                    <input type="text" class="form-control costosChihuahua" placeholder="Utilidad Cambiaria" id="txtUtilidadCambiariaChihuahua" required />
                                                    <label>Comision Bancaria</label>
                                                    <input type="text" class="form-control costosChihuahua" placeholder="Comision Bancaria" id="txtComisionBancariaChihuahua" required />
                                                    <label>Vacaciones</label>
                                                    <input type="text" class="form-control costosChihuahua" placeholder="Vacaciones" id="txtVacacionesChihuahua" required />
                                                    <label>Aguinaldo</label>
                                                    <input type="text" class="form-control costosChihuahua" placeholder="Aguinaldo" id="txtAguinaldoChihuahua" required />
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Gastos Administrativos</label>
                                                    <input type="text" class="form-control" placeholder="Gastos Administrativos" id="txtGastosAdmonChihuahua" readonly />
                                                    <label>Consumibles Taller</label>
                                                    <input type="text" class="form-control" placeholder="Consumibles Taller" id="txtConsumiblesChihuahua" readonly />
                                                    <label>Gasolina</label>
                                                    <input type="text" class="form-control" placeholder="Gasolina" id="txtGasolinaChihuahua" readonly />
                                                    <label>Equipo Seguridad</label>
                                                    <input type="text" class="form-control" placeholder="Equipo Seguridad" id="txtEquipoSeguridadChihuahua" readonly />
                                                    <label>Inventario Sisa</label>
                                                    <input type="text" class="form-control" placeholder="Inventario Sisa" id="txtInventarioSisaChihuahua" readonly />
                                                    <label>Viaticos</label>
                                                    <input type="text" class="form-control" placeholder="Viaticos" id="txtViaticosChihuahua" readonly />
                                                    <label>Carros</label>
                                                    <input type="text" class="form-control" placeholder="Carros" id="txtCarrosChihuahua" readonly />
                                                    <label>Uniformes</label>
                                                    <input type="text" class="form-control" placeholder="Uniformes" id="txtUniformesChihuahua" readonly />
                                                </div>
                                            </div>
                                            <div class="panel-footer">
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                         <span style="font-weight:bold;">Total:</span><span id="lblTotalChihuahua"></span>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <span style="font-weight:bold;">Proyectos:</span><span id="lblTotalProyectosChihuahua"></span>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <span style="font-weight:bold;">Cotizado:</span><span id="lblTotalCotizadoChihuahua"></span>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <span style="font-weight:bold;">%:</span><span id="lblTotalPorcentajeChihuahua"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="panel-group">
                                        <div class="panel panel-primary">
                                            <div class="panel-heading">DATOS SISA&AUT CUAUTITLAN</div>
                                            <div class="panel-body">
                                                <div class="col-lg-6">
                                                    <label>Costo Nomina</label>
                                                    <input type="text" class="form-control costosCuatitlan" placeholder="Costo Nomina" id="txtNominaCuautitlan" required />
                                                    <label>Costo IMSS, Infonavit, 3%</label>
                                                    <input type="text" class="form-control costosCuatitlan" placeholder="Costo IMSS, Infonavit, 3%" id="txtCostoImssCuautitlan" required />
                                                    <label>Costo Total</label>
                                                    <input type="text" class="form-control" placeholder="Costo Total" id="txtCostoTotalCuautitlan" required />
                                                    <label>Total Empleados</label>
                                                    <input type="text" class="form-control" placeholder="Total Empleados" id="txtTotalEmpleadosCuautitlan" required />
                                                    <label>Perdida Cambiaria</label>
                                                    <input type="text" class="form-control costosCuatitlan" placeholder="Perdida Cambiaria" id="txtPerdidaCambiariaCuautitlan" required />
                                                    <label>Utilidad Cambiaria</label>
                                                    <input type="text" class="form-control costosCuatitlan" placeholder="Utilidad Cambiaria" id="txtUtilidadCambiariaCuautitlan" required />
                                                    <label>Comision Bancaria</label>
                                                    <input type="text" class="form-control costosCuatitlan" placeholder="Comision Bancaria" id="txtComisionBancariaCuautitlan" required />
                                                    <label>Vacaciones</label>
                                                    <input type="text" class="form-control costosCuatitlan" placeholder="Vacaciones" id="txtVacacionesCuautitlan" required />
                                                    <label>Aguinaldo</label>
                                                    <input type="text" class="form-control costosCuatitlan" placeholder="Aguinaldo" id="txtAguinaldoCuautitlan" required />
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Gastos Administrativos</label>
                                                    <input type="text" class="form-control" placeholder="Gastos Administrativos" id="txtGastosAdmonCuautitlan" readonly />
                                                    <label>Consumibles Taller</label>
                                                    <input type="text" class="form-control" placeholder="Consumibles Taller" id="txtConsumiblesCuautitlan" readonly />
                                                    <label>Gasolina</label>
                                                    <input type="text" class="form-control" placeholder="Gasolina" id="txtGasolinaCuautitlan" readonly />
                                                    <label>Equipo Seguridad</label>
                                                    <input type="text" class="form-control" placeholder="Equipo Seguridad" id="txtEquipoSeguridadCuautitlan" readonly />
                                                    <label>Inventario Sisa</label>
                                                    <input type="text" class="form-control" placeholder="Inventario Sisa" id="txtInventarioSisaCuautitlan" readonly />
                                                    <label>Viaticos</label>
                                                    <input type="text" class="form-control" placeholder="Viaticos" id="txtViaticosCuautitlan" readonly />
                                                    <label>Carros</label>
                                                    <input type="text" class="form-control" placeholder="Carros" id="txtCarrosCuautitlan" readonly />
                                                    <label>Uniformes</label>
                                                    <input type="text" class="form-control" placeholder="Uniformes" id="txtUniformesCuautitlan" readonly />
                                                </div>


                                            </div>
                                            <div class="panel-footer">
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                         <span style="font-weight:bold;">Total:</span><span id="lblTotalCuautitlan"></span>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <span style="font-weight:bold;">Proyectos:</span><span id="lblTotalProyectosCuautitlan"></span>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <span style="font-weight:bold;">Cotizado:</span><span id="lblTotalCotizadoCuautitlan"></span>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <span style="font-weight:bold;">%:</span><span id="lblTotalPorcentajeCuautitlan"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="panel-group">
                                        <div class="panel panel-primary">
                                            <div class="panel-heading">DATOS SISA&AUT IRAPUATO</div>
                                            <div class="panel-body">
                                                <div class="col-lg-6">
                                                    <label>Costo Nomina</label>
                                                    <input type="text" class="form-control costosIrapuato" placeholder="Costo Nomina" id="txtNominaIrapuato" required />
                                                    <label>Costo IMSS, Infonavit, 3%</label>
                                                    <input type="text" class="form-control costosIrapuato" placeholder="Costo IMSS, Infonavit, 3%" id="txtCostoImssIrapuato" required />
                                                    <label>Costo Total</label>
                                                    <input type="text" class="form-control" placeholder="Costo Total" id="txtCostoTotalIrapuato" required />
                                                    <label>Total Empleados</label>
                                                    <input type="text" class="form-control" placeholder="Total Empleados" id="txtTotalEmpleadosIrapuato" required />
                                                    <label>Perdida Cambiaria</label>
                                                    <input type="text" class="form-control costosIrapuato" placeholder="Perdida Cambiaria" id="txtPerdidaCambiariaIrapuato" required />
                                                    <label>Utilidad Cambiaria</label>
                                                    <input type="text" class="form-control costosIrapuato" placeholder="Utilidad Cambiaria" id="txtUtilidadCambiariaIrapuato" required />
                                                    <label>Comision Bancaria</label>
                                                    <input type="text" class="form-control costosIrapuato" placeholder="Comision Bancaria" id="txtComisionBancariaIrapuato" required />
                                                    <label>Vacaciones</label>
                                                    <input type="text" class="form-control costosIrapuato" placeholder="Vacaciones" id="txtVacacionesIrapuato" required />
                                                    <label>Aguinaldo</label>
                                                    <input type="text" class="form-control costosIrapuato" placeholder="Aguinaldo" id="txtAguinaldoIrapuato" required />
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Gastos Administrativos</label>
                                                    <input type="text" class="form-control" placeholder="Gastos Administrativos" id="txtGastosAdmonIrapuato" readonly />
                                                    <label>Consumibles Taller</label>
                                                    <input type="text" class="form-control" placeholder="Consumibles Taller" id="txtConsumiblesIrapuato" readonly />
                                                    <label>Gasolina</label>
                                                    <input type="text" class="form-control" placeholder="Gasolina" id="txtGasolinaIrapuato" readonly />
                                                    <label>Equipo Seguridad</label>
                                                    <input type="text" class="form-control" placeholder="Equipo Seguridad" id="txtEquipoSeguridadIrapuato" readonly />
                                                    <label>Inventario Sisa</label>
                                                    <input type="text" class="form-control" placeholder="Inventario Sisa" id="txtInventarioSisaIrapuato" readonly />
                                                    <label>Viaticos</label>
                                                    <input type="text" class="form-control" placeholder="Viaticos" id="txtViaticosIrapuato" readonly />
                                                    <label>Carros</label>
                                                    <input type="text" class="form-control" placeholder="Carros" id="txtCarrosIrapuato" readonly />
                                                    <label>Uniformes</label>
                                                    <input type="text" class="form-control" placeholder="Uniformes" id="txtUniformesIrapuato" readonly />
                                                </div>


                                            </div>
                                            <div class="panel-footer">
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                         <span style="font-weight:bold;">Total:</span><span id="lblTotalIrapuato"></span>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <span style="font-weight:bold;">Proyectos:</span><span id="lblTotalProyectosIrapuato"></span>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <span style="font-weight:bold;">Cotizado:</span><span id="lblTotalCotizadoIrapuato"></span>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <span style="font-weight:bold;">%:</span><span id="lblTotalPorcentajeIrapuato"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="panel-group">
                                        <div class="panel panel-primary">
                                            <div class="panel-heading">DATOS SISA&AUT QUERETARO</div>
                                            <div class="panel-body">
                                                <div class="col-lg-6">
                                                    <label>Costo Nomina</label>
                                                    <input type="text" class="form-control costosQueretaro" placeholder="Costo Nomina" id="txtNominaQueretaro" required />
                                                    <label>Costo IMSS, Infonavit, 3%</label>
                                                    <input type="text" class="form-control costosQueretaro" placeholder="Costo IMSS, Infonavit, 3%" id="txtCostoImssQueretaro" required />
                                                    <label>Costo Total</label>
                                                    <input type="text" class="form-control" placeholder="Costo Total" id="txtCostoTotalQueretaro" required />
                                                    <label>Total Empleados</label>
                                                    <input type="text" class="form-control" placeholder="Total Empleados" id="txtTotalEmpleadosQueretaro" required />
                                                    <label>Perdida Cambiaria</label>
                                                    <input type="text" class="form-control costosQueretaro" placeholder="Perdida Cambiaria" id="txtPerdidaCambiariaQueretaro" required />
                                                    <label>Utilidad Cambiaria</label>
                                                    <input type="text" class="form-control costosQueretaro" placeholder="Utilidad Cambiaria" id="txtUtilidadCambiariaQueretaro" required />
                                                    <label>Comision Bancaria</label>
                                                    <input type="text" class="form-control costosQueretaro" placeholder="Comision Bancaria" id="txtComisionBancariaQueretaro" required />
                                                    <label>Vacaciones</label>
                                                    <input type="text" class="form-control costosQueretaro" placeholder="Vacaciones" id="txtVacacionesQueretaro" required />
                                                    <label>Aguinaldo</label>
                                                    <input type="text" class="form-control costosQueretaro" placeholder="Aguinaldo" id="txtAguinaldoQueretaro" required />
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Gastos Administrativos</label>
                                                    <input type="text" class="form-control" placeholder="Gastos Administrativos" id="txtGastosAdmonQueretaro" readonly />
                                                    <label>Consumibles Taller</label>
                                                    <input type="text" class="form-control" placeholder="Consumibles Taller" id="txtConsumiblesQueretaro" readonly />
                                                    <label>Gasolina</label>
                                                    <input type="text" class="form-control" placeholder="Gasolina" id="txtGasolinaQueretaro" readonly />
                                                    <label>Equipo Seguridad</label>
                                                    <input type="text" class="form-control" placeholder="Equipo Seguridad" id="txtEquipoSeguridadQueretaro" readonly />
                                                    <label>Inventario Sisa</label>
                                                    <input type="text" class="form-control" placeholder="Inventario Sisa" id="txtInventarioSisaQueretaro" readonly />
                                                    <label>Viaticos</label>
                                                    <input type="text" class="form-control" placeholder="Viaticos" id="txtViaticosQueretaro" readonly />
                                                    <label>Carros</label>
                                                    <input type="text" class="form-control" placeholder="Carros" id="txtCarrosQueretaro" readonly />
                                                    <label>Uniformes</label>
                                                    <input type="text" class="form-control" placeholder="Uniformes" id="txtUniformesQueretaro" readonly />
                                                </div>


                                            </div>
                                            <div class="panel-footer">
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                         <span style="font-weight:bold;">Total:</span><span id="lblTotalQueretaro"></span>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <span style="font-weight:bold;">Proyectos:</span><span id="lblTotalProyectosQueretaro"></span>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <span style="font-weight:bold;">Cotizado:</span><span id="lblTotalCotizadoQueretaro"></span>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <span style="font-weight:bold;">%:</span><span id="lblTotalPorcentajeQueretaro"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="panel-group">
                                        <div class="panel panel-primary">
                                            <div class="panel-heading">DATOS SISA&AUT TECATE</div>
                                            <div class="panel-body">
                                                <div class="col-lg-6">
                                                    <label>Costo Nomina</label>
                                                    <input type="text" class="form-control costosTecate" placeholder="Costo Nomina" id="txtNominaTecate" required />
                                                    <label>Costo IMSS, Infonavit, 3%</label>
                                                    <input type="text" class="form-control costosTecate" placeholder="Costo IMSS, Infonavit, 3%" id="txtCostoImssTecate" required />
                                                    <label>Costo Total</label>
                                                    <input type="text" class="form-control" placeholder="Costo Total" id="txtCostoTotalTecate" required />
                                                    <label>Total Empleados</label>
                                                    <input type="text" class="form-control" placeholder="Total Empleados" id="txtTotalEmpleadosTecate" required />
                                                    <label>Perdida Cambiaria</label>
                                                    <input type="text" class="form-control costosTecate" placeholder="Perdida Cambiaria" id="txtPerdidaCambiariaTecate" required />
                                                    <label>Utilidad Cambiaria</label>
                                                    <input type="text" class="form-control costosTecate" placeholder="Utilidad Cambiaria" id="txtUtilidadCambiariaTecate" required />
                                                    <label>Comision Bancaria</label>
                                                    <input type="text" class="form-control costosTecate" placeholder="Comision Bancaria" id="txtComisionBancariaTecate" required />
                                                    <label>Vacaciones</label>
                                                    <input type="text" class="form-control costosTecate" placeholder="Vacaciones" id="txtVacacionesTecate" required />
                                                    <label>Aguinaldo</label>
                                                    <input type="text" class="form-control costosTecate" placeholder="Aguinaldo" id="txtAguinaldoTecate" required />
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Gastos Administrativos</label>
                                                    <input type="text" class="form-control" placeholder="Gastos Administrativos" id="txtGastosAdmonTecate" readonly />
                                                    <label>Consumibles Taller</label>
                                                    <input type="text" class="form-control" placeholder="Consumibles Taller" id="txtConsumiblesTecate" readonly />
                                                    <label>Gasolina</label>
                                                    <input type="text" class="form-control" placeholder="Gasolina" id="txtGasolinaTecate" readonly />
                                                    <label>Equipo Seguridad</label>
                                                    <input type="text" class="form-control" placeholder="Equipo Seguridad" id="txtEquipoSeguridadTecate" readonly />
                                                    <label>Inventario Sisa</label>
                                                    <input type="text" class="form-control" placeholder="Inventario Sisa" id="txtInventarioSisaTecate" readonly />
                                                    <label>Viaticos</label>
                                                    <input type="text" class="form-control" placeholder="Viaticos" id="txtViaticosTecate" readonly />
                                                    <label>Carros</label>
                                                    <input type="text" class="form-control" placeholder="Carros" id="txtCarrosTecate" readonly />
                                                    <label>Uniformes</label>
                                                    <input type="text" class="form-control" placeholder="Uniformes" id="txtUniformesTecate" readonly />
                                                </div>


                                            </div>
                                            <div class="panel-footer">
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                         <span style="font-weight:bold;">Total:</span><span id="lblTotalTecate"></span>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <span style="font-weight:bold;">Proyectos:</span><span id="lblTotalProyectosTecate"></span>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <span style="font-weight:bold;">Cotizado:</span><span id="lblTotalCotizadoTecate"></span>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <span style="font-weight:bold;">%:</span><span id="lblTotalPorcentajeTecate"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="panel-group">
                                        <div class="panel panel-primary">
                                            <div class="panel-heading">DATOS SISA&AUT USA</div>
                                            <div class="panel-body">
                                                <div class="col-lg-6">
                                                    <label>Costo Nomina</label>
                                                    <input type="text" class="form-control costosUSA" placeholder="Costo Nomina" id="txtNominaUSA" required />
                                                    <label>Costo IMSS, Infonavit, 3%</label>
                                                    <input type="text" class="form-control costosUSA" placeholder="Costo IMSS, Infonavit, 3%" id="txtCostoImssUSA" required />
                                                    <label>Costo Total</label>
                                                    <input type="text" class="form-control" placeholder="Costo Total" id="txtCostoTotalUSA" required />
                                                    <label>Total Empleados</label>
                                                    <input type="text" class="form-control" placeholder="Total Empleados" id="txtTotalEmpleadosUSA" required />
                                                    <label>Perdida Cambiaria</label>
                                                    <input type="text" class="form-control costosUSA" placeholder="Perdida Cambiaria" id="txtPerdidaCambiariaUSA" required />
                                                    <label>Utilidad Cambiaria</label>
                                                    <input type="text" class="form-control costosUSA" placeholder="Utilidad Cambiaria" id="txtUtilidadCambiariaUSA" required />
                                                    <label>Comision Bancaria</label>
                                                    <input type="text" class="form-control costosUSA" placeholder="Comision Bancaria" id="txtComisionBancariaUSA" required />
                                                    <label>Vacaciones</label>
                                                    <input type="text" class="form-control costosUSA" placeholder="Vacaciones" id="txtVacacionesUSA" required />
                                                    <label>Aguinaldo</label>
                                                    <input type="text" class="form-control costosUSA" placeholder="Aguinaldo" id="txtAguinaldoUSA" required />
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Gastos Administrativos</label>
                                                    <input type="text" class="form-control" placeholder="Gastos Administrativos" id="txtGastosAdmonUSA" readonly />
                                                    <label>Consumibles Taller</label>
                                                    <input type="text" class="form-control" placeholder="Consumibles Taller" id="txtConsumiblesUSA" readonly />
                                                    <label>Gasolina</label>
                                                    <input type="text" class="form-control" placeholder="Gasolina" id="txtGasolinaUSA" readonly />
                                                    <label>Equipo Seguridad</label>
                                                    <input type="text" class="form-control" placeholder="Equipo Seguridad" id="txtEquipoSeguridadUSA" readonly />
                                                    <label>Inventario Sisa</label>
                                                    <input type="text" class="form-control" placeholder="Inventario Sisa" id="txtInventarioSisaUSA" readonly />
                                                    <label>Viaticos</label>
                                                    <input type="text" class="form-control" placeholder="Viaticos" id="txtViaticosUSA" readonly />
                                                    <label>Carros</label>
                                                    <input type="text" class="form-control" placeholder="Carros" id="txtCarrosUSA" readonly />
                                                    <label>Uniformes</label>
                                                    <input type="text" class="form-control" placeholder="Uniformes" id="txtUniformesUSA" readonly />
                                                </div>


                                            </div>
                                            <div class="panel-footer">
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                         <span style="font-weight:bold;">Total:</span><span id="lblTotalUSA"></span>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <span style="font-weight:bold;">Proyectos:</span><span id="lblTotalProyectosUSA"></span>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <span style="font-weight:bold;">Cotizado:</span><span id="lblTotalCotizadoUSA"></span>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <span style="font-weight:bold;">%:</span><span id="lblTotalPorcentajeUSA"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="panel-group">
                                        <div class="panel panel-info">
                                            <div class="panel-heading">DATOS SISA&AUT HERMOSILLO CCM</div>
                                            <div class="panel-body">
                                                <div class="col-lg-6">
                                                    <label>Costo Nomina</label>
                                                    <input type="text" class="form-control costosHermosilloCCM" placeholder="Costo Nomina" id="txtNominaHermosilloCCM" required />
                                                    <label>Costo IMSS, Infonavit, 3%</label>
                                                    <input type="text" class="form-control costosHermosilloCCM" placeholder="Costo IMSS, Infonavit, 3%" id="txtCostoImssHermosilloCCM" required />
                                                    <label>Costo Total</label>
                                                    <input type="text" class="form-control" placeholder="Costo Total" id="txtCostoTotalHermosilloCCM" required />
                                                    <label>Total Empleados</label>
                                                    <input type="text" class="form-control" placeholder="Total Empleados" id="txtTotalEmpleadosHermosilloCCM" required />
                                                    <label>Perdida Cambiaria</label>
                                                    <input type="text" class="form-control costosHermosilloCCM" placeholder="Perdida Cambiaria" id="txtPerdidaCambiariaHermosilloCCM" required />
                                                    <label>Utilidad Cambiaria</label>
                                                    <input type="text" class="form-control costosHermosilloCCM" placeholder="Utilidad Cambiaria" id="txtUtilidadCambiariaHermosilloCCM" required />
                                                    <label>Comision Bancaria</label>
                                                    <input type="text" class="form-control costosHermosilloCCM" placeholder="Comision Bancaria" id="txtComisionBancariaHermosilloCCM" required />
                                                    <label>Vacaciones</label>
                                                    <input type="text" class="form-control costosHermosilloCCM" placeholder="Vacaciones" id="txtVacacionesHermosilloCCM" required />
                                                    <label>Aguinaldo</label>
                                                    <input type="text" class="form-control costosHermosilloCCM" placeholder="Aguinaldo" id="txtAguinaldoHermosilloCCM" required />
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Gastos Administrativos</label>
                                                    <input type="text" class="form-control" placeholder="Gastos Administrativos" id="txtGastosAdmonHermosilloCCM" readonly />
                                                    <label>Consumibles Taller</label>
                                                    <input type="text" class="form-control" placeholder="Consumibles Taller" id="txtConsumiblesHermosilloCCM" readonly />
                                                    <label>Gasolina</label>
                                                    <input type="text" class="form-control" placeholder="Gasolina" id="txtGasolinaHermosilloCCM" readonly />
                                                    <label>Equipo Seguridad</label>
                                                    <input type="text" class="form-control" placeholder="Equipo Seguridad" id="txtEquipoSeguridadHermosilloCCM" readonly />
                                                    <label>Inventario Sisa</label>
                                                    <input type="text" class="form-control" placeholder="Inventario Sisa" id="txtInventarioSisaHermosilloCCM" readonly />
                                                    <label>Viaticos</label>
                                                    <input type="text" class="form-control" placeholder="Viaticos" id="txtViaticosHermosilloCCM" readonly />
                                                    <label>Carros</label>
                                                    <input type="text" class="form-control" placeholder="Carros" id="txtCarrosHermosilloCCM" readonly />
                                                    <label>Uniformes</label>
                                                    <input type="text" class="form-control" placeholder="Uniformes" id="txtUniformesHermosilloCCM" readonly />
                                                </div>


                                            </div>
                                            <div class="panel-footer">
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                         <span style="font-weight:bold;">Total:</span><span id="lblTotalHermosilloCCM"></span>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <span style="font-weight:bold;">Proyectos:</span><span id="lblTotalProyectosHermosilloCCM"></span>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <span style="font-weight:bold;">Cotizado:</span><span id="lblTotalCotizadoHermosilloCCM"></span>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <span style="font-weight:bold;">%:</span><span id="lblTotalPorcentajeHermosilloCCM"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="panel-group">
                                        <div class="panel panel-info">
                                            <div class="panel-heading">DATOS SISA&AUT CHIHUAHUA CCM</div>
                                            <div class="panel-body">
                                                <div class="col-lg-6">
                                                    <label>Costo Nomina</label>
                                                    <input type="text" class="form-control costosChihuahuaCCM" placeholder="Costo Nomina" id="txtNominaChihuahuaCCM" required />
                                                    <label>Costo IMSS, Infonavit, 3%</label>
                                                    <input type="text" class="form-control costosChihuahuaCCM" placeholder="Costo IMSS, Infonavit, 3%" id="txtCostoImssChihuahuaCCM" required />
                                                    <label>Costo Total</label>
                                                    <input type="text" class="form-control" placeholder="Costo Total" id="txtCostoTotalChihuahuaCCM" required />
                                                    <label>Total Empleados</label>
                                                    <input type="text" class="form-control" placeholder="Total Empleados" id="txtTotalEmpleadosChihuahuaCCM" required />
                                                    <label>Perdida Cambiaria</label>
                                                    <input type="text" class="form-control costosChihuahuaCCM" placeholder="Perdida Cambiaria" id="txtPerdidaCambiariaChihuahuaCCM" required />
                                                    <label>Utilidad Cambiaria</label>
                                                    <input type="text" class="form-control costosChihuahuaCCM" placeholder="Utilidad Cambiaria" id="txtUtilidadCambiariaChihuahuaCCM" required />
                                                    <label>Comision Bancaria</label>
                                                    <input type="text" class="form-control costosChihuahuaCCM" placeholder="Comision Bancaria" id="txtComisionBancariaChihuahuaCCM" required />
                                                    <label>Vacaciones</label>
                                                    <input type="text" class="form-control costosChihuahuaCCM" placeholder="Vacaciones" id="txtVacacionesChihuahuaCCM" required />
                                                    <label>Aguinaldo</label>
                                                    <input type="text" class="form-control costosChihuahuaCCM" placeholder="Aguinaldo" id="txtAguinaldoChihuahuaCCM" required />
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Gastos Administrativos</label>
                                                    <input type="text" class="form-control" placeholder="Gastos Administrativos" id="txtGastosAdmonChihuahuaCCM" readonly />
                                                    <label>Consumibles Taller</label>
                                                    <input type="text" class="form-control" placeholder="Consumibles Taller" id="txtConsumiblesChihuahuaCCM" readonly />
                                                    <label>Gasolina</label>
                                                    <input type="text" class="form-control" placeholder="Gasolina" id="txtGasolinaChihuahuaCCM" readonly />
                                                    <label>Equipo Seguridad</label>
                                                    <input type="text" class="form-control" placeholder="Equipo Seguridad" id="txtEquipoSeguridadChihuahuaCCM" readonly />
                                                    <label>Inventario Sisa</label>
                                                    <input type="text" class="form-control" placeholder="Inventario Sisa" id="txtInventarioSisaChihuahuaCCM" readonly />
                                                    <label>Viaticos</label>
                                                    <input type="text" class="form-control" placeholder="Viaticos" id="txtViaticosChihuahuaCCM" readonly />
                                                    <label>Carros</label>
                                                    <input type="text" class="form-control" placeholder="Carros" id="txtCarrosChihuahuaCCM" readonly />
                                                    <label>Uniformes</label>
                                                    <input type="text" class="form-control" placeholder="Uniformes" id="txtUniformesChihuahuaCCM" readonly />
                                                </div>


                                            </div>
                                            <div class="panel-footer">
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                         <span style="font-weight:bold;">Total:</span><span id="lblTotalChihuahuaCCM"></span>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <span style="font-weight:bold;">Proyectos:</span><span id="lblTotalProyectosChihuahuaCCM"></span>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <span style="font-weight:bold;">Cotizado:</span><span id="lblTotalCotizadoChihuahuaCCM"></span>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <span style="font-weight:bold;">%:</span><span id="lblTotalPorcentajeChihuahuaCCM"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="panel-group">
                                        <div class="panel panel-info">
                                            <div class="panel-heading">DATOS SISA&AUT CUAUTITLAN CCM</div>
                                            <div class="panel-body">
                                                <div class="col-lg-6">
                                                    <label>Costo Nomina</label>
                                                    <input type="text" class="form-control costosCuautitlanCCM" placeholder="Costo Nomina" id="txtNominaCuautitlanCCM" required />
                                                    <label>Costo IMSS, Infonavit, 3%</label>
                                                    <input type="text" class="form-control costosCuautitlanCCM" placeholder="Costo IMSS, Infonavit, 3%" id="txtCostoImssCuautitlanCCM" required />
                                                    <label>Costo Total</label>
                                                    <input type="text" class="form-control" placeholder="Costo Total" id="txtCostoTotalCuautitlanCCM" required />
                                                    <label>Total Empleados</label>
                                                    <input type="text" class="form-control" placeholder="Total Empleados" id="txtTotalEmpleadosCuautitlanCCM" required />
                                                    <label>Perdida Cambiaria</label>
                                                    <input type="text" class="form-control costosCuautitlanCCM" placeholder="Perdida Cambiaria" id="txtPerdidaCambiariaCuautitlanCCM" required />
                                                    <label>Utilidad Cambiaria</label>
                                                    <input type="text" class="form-control costosCuautitlanCCM" placeholder="Utilidad Cambiaria" id="txtUtilidadCambiariaCuautitlanCCM" required />
                                                    <label>Comision Bancaria</label>
                                                    <input type="text" class="form-control costosCuautitlanCCM" placeholder="Comision Bancaria" id="txtComisionBancariaCuautitlanCCM" required />
                                                    <label>Vacaciones</label>
                                                    <input type="text" class="form-control costosCuautitlanCCM" placeholder="Vacaciones" id="txtVacacionesCuautitlanCCM" required />
                                                    <label>Aguinaldo</label>
                                                    <input type="text" class="form-control costosCuautitlanCCM" placeholder="Aguinaldo" id="txtAguinaldoCuautitlanCCM" required />
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Gastos Administrativos</label>
                                                    <input type="text" class="form-control" placeholder="Gastos Administrativos" id="txtGastosAdmonCuautitlanCCM" readonly />
                                                    <label>Consumibles Taller</label>
                                                    <input type="text" class="form-control" placeholder="Consumibles Taller" id="txtConsumiblesCuautitlanCCM" readonly />
                                                    <label>Gasolina</label>
                                                    <input type="text" class="form-control" placeholder="Gasolina" id="txtGasolinaCuautitlanCCM" readonly />
                                                    <label>Equipo Seguridad</label>
                                                    <input type="text" class="form-control" placeholder="Equipo Seguridad" id="txtEquipoSeguridadCuautitlanCCM" readonly />
                                                    <label>Inventario Sisa</label>
                                                    <input type="text" class="form-control" placeholder="Inventario Sisa" id="txtInventarioSisaCuautitlanCCM" readonly />
                                                    <label>Viaticos</label>
                                                    <input type="text" class="form-control" placeholder="Viaticos" id="txtViaticosCuautitlanCCM" readonly />
                                                    <label>Carros</label>
                                                    <input type="text" class="form-control" placeholder="Carros" id="txtCarrosCuautitlanCCM" readonly />
                                                    <label>Uniformes</label>
                                                    <input type="text" class="form-control" placeholder="Uniformes" id="txtUniformesCuautitlanCCM" readonly />
                                                </div>


                                            </div>
                                            <div class="panel-footer">
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                         <span style="font-weight:bold;">Total:</span><span id="lblTotalCuautitlanCCM"></span>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <span style="font-weight:bold;">Proyectos:</span><span id="lblTotalProyectosCuautitlanCCM"></span>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <span style="font-weight:bold;">Cotizado:</span><span id="lblTotalCotizadoCuautitlanCCM"></span>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <span style="font-weight:bold;">%:</span><span id="lblTotalPorcentajeCuautitlanCCM"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="panel-group">
                                        <div class="panel panel-info">
                                            <div class="panel-heading">DATOS SISA&AUT IRAPUATO CCM</div>
                                            <div class="panel-body">
                                                <div class="col-lg-6">
                                                    <label>Costo Nomina</label>
                                                    <input type="text" class="form-control costosIrapuatoCCM" placeholder="Costo Nomina" id="txtNominaIrapuatoCCM" required />
                                                    <label>Costo IMSS, Infonavit, 3%</label>
                                                    <input type="text" class="form-control costosIrapuatoCCM" placeholder="Costo IMSS, Infonavit, 3%" id="txtCostoImssIrapuatoCCM" required />
                                                    <label>Costo Total</label>
                                                    <input type="text" class="form-control" placeholder="Costo Total" id="txtCostoTotalIrapuatoCCM" required />
                                                    <label>Total Empleados</label>
                                                    <input type="text" class="form-control" placeholder="Total Empleados" id="txtTotalEmpleadosIrapuatoCCM" required />
                                                    <label>Perdida Cambiaria</label>
                                                    <input type="text" class="form-control costosIrapuatoCCM" placeholder="Perdida Cambiaria" id="txtPerdidaCambiariaIrapuatoCCM" required />
                                                    <label>Utilidad Cambiaria</label>
                                                    <input type="text" class="form-control costosIrapuatoCCM" placeholder="Utilidad Cambiaria" id="txtUtilidadCambiariaIrapuatoCCM" required />
                                                    <label>Comision Bancaria</label>
                                                    <input type="text" class="form-control costosIrapuatoCCM" placeholder="Comision Bancaria" id="txtComisionBancariaIrapuatoCCM" required />
                                                    <label>Vacaciones</label>
                                                    <input type="text" class="form-control costosIrapuatoCCM" placeholder="Vacaciones" id="txtVacacionesIrapuatoCCM" required />
                                                    <label>Aguinaldo</label>
                                                    <input type="text" class="form-control costosIrapuatoCCM" placeholder="Aguinaldo" id="txtAguinaldoIrapuatoCCM" required />
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Gastos Administrativos</label>
                                                    <input type="text" class="form-control" placeholder="Gastos Administrativos" id="txtGastosAdmonIrapuatoCCM" readonly />
                                                    <label>Consumibles Taller</label>
                                                    <input type="text" class="form-control" placeholder="Consumibles Taller" id="txtConsumiblesIrapuatoCCM" readonly />
                                                    <label>Gasolina</label>
                                                    <input type="text" class="form-control" placeholder="Gasolina" id="txtGasolinaIrapuatoCCM" readonly />
                                                    <label>Equipo Seguridad</label>
                                                    <input type="text" class="form-control" placeholder="Equipo Seguridad" id="txtEquipoSeguridadIrapuatoCCM" readonly />
                                                    <label>Inventario Sisa</label>
                                                    <input type="text" class="form-control" placeholder="Inventario Sisa" id="txtInventarioSisaIrapuatoCCM" readonly />
                                                    <label>Viaticos</label>
                                                    <input type="text" class="form-control" placeholder="Viaticos" id="txtViaticosIrapuatoCCM" readonly />
                                                    <label>Carros</label>
                                                    <input type="text" class="form-control" placeholder="Carros" id="txtCarrosIrapuatoCCM" readonly />
                                                    <label>Uniformes</label>
                                                    <input type="text" class="form-control" placeholder="Uniformes" id="txtUniformesIrapuatoCCM" readonly />
                                                </div>


                                            </div>
                                            <div class="panel-footer">
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                         <span style="font-weight:bold;">Total:</span><span id="lblTotalIrapuatoCCM"></span>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <span style="font-weight:bold;">Proyectos:</span><span id="lblTotalProyectosIrapuatoCCM"></span>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <span style="font-weight:bold;">Cotizado:</span><span id="lblTotalCotizadoIrapuatoCCM"></span>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <span style="font-weight:bold;">%:</span><span id="lblTotalPorcentajeIrapuatoCCM"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="panel-group">
                                        <div class="panel panel-info">
                                            <div class="panel-heading">DATOS SISA&AUT QUERETARO CCM</div>
                                            <div class="panel-body">
                                                <div class="col-lg-6">
                                                    <label>Costo Nomina</label>
                                                    <input type="text" class="form-control costosQueretaroCCM" placeholder="Costo Nomina" id="txtNominaQueretaroCCM" required />
                                                    <label>Costo IMSS, Infonavit, 3%</label>
                                                    <input type="text" class="form-control costosQueretaroCCM" placeholder="Costo IMSS, Infonavit, 3%" id="txtCostoImssQueretaroCCM" required />
                                                    <label>Costo Total</label>
                                                    <input type="text" class="form-control" placeholder="Costo Total" id="txtCostoTotalQueretaroCCM" required />
                                                    <label>Total Empleados</label>
                                                    <input type="text" class="form-control" placeholder="Total Empleados" id="txtTotalEmpleadosQueretaroCCM" required />
                                                    <label>Perdida Cambiaria</label>
                                                    <input type="text" class="form-control costosQueretaroCCM" placeholder="Perdida Cambiaria" id="txtPerdidaCambiariaQueretaroCCM" required />
                                                    <label>Utilidad Cambiaria</label>
                                                    <input type="text" class="form-control costosQueretaroCCM" placeholder="Utilidad Cambiaria" id="txtUtilidadCambiariaQueretaroCCM" required />
                                                    <label>Comision Bancaria</label>
                                                    <input type="text" class="form-control costosQueretaroCCM" placeholder="Comision Bancaria" id="txtComisionBancariaQueretaroCCM" required />
                                                    <label>Vacaciones</label>
                                                    <input type="text" class="form-control costosQueretaroCCM" placeholder="Vacaciones" id="txtVacacionesQueretaroCCM" required />
                                                    <label>Aguinaldo</label>
                                                    <input type="text" class="form-control costosQueretaroCCM" placeholder="Aguinaldo" id="txtAguinaldoQueretaroCCM" required />
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Gastos Administrativos</label>
                                                    <input type="text" class="form-control" placeholder="Gastos Administrativos" id="txtGastosAdmonQueretaroCCM" readonly />
                                                    <label>Consumibles Taller</label>
                                                    <input type="text" class="form-control" placeholder="Consumibles Taller" id="txtConsumiblesQueretaroCCM" readonly />
                                                    <label>Gasolina</label>
                                                    <input type="text" class="form-control" placeholder="Gasolina" id="txtGasolinaQueretaroCCM" readonly />
                                                    <label>Equipo Seguridad</label>
                                                    <input type="text" class="form-control" placeholder="Equipo Seguridad" id="txtEquipoSeguridadQueretaroCCM" readonly />
                                                    <label>Inventario Sisa</label>
                                                    <input type="text" class="form-control" placeholder="Inventario Sisa" id="txtInventarioSisaQueretaroCCM" readonly />
                                                    <label>Viaticos</label>
                                                    <input type="text" class="form-control" placeholder="Viaticos" id="txtViaticosQueretaroCCM" readonly />
                                                    <label>Carros</label>
                                                    <input type="text" class="form-control" placeholder="Carros" id="txtCarrosQueretaroCCM" readonly />
                                                    <label>Uniformes</label>
                                                    <input type="text" class="form-control" placeholder="Uniformes" id="txtUniformesQueretaroCCM" readonly />
                                                </div>


                                            </div>
                                            <div class="panel-footer">
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                         <span style="font-weight:bold;">Total:</span><span id="lblTotalQueretaroCCM"></span>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <span style="font-weight:bold;">Proyectos:</span><span id="lblTotalProyectosQueretaroCCM"></span>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <span style="font-weight:bold;">Cotizado:</span><span id="lblTotalCotizadoQueretaroCCM"></span>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <span style="font-weight:bold;">%:</span><span id="lblTotalPorcentajeQueretaroCCM"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--</div>--%>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button class="btn btn-primary" id="btnGuardarCostoIndirecto" type="button">Guardar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/CostosIndirectos.js" type="text/javascript"></script>
</asp:Content>
