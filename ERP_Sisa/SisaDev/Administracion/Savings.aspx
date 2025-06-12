<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Savings.aspx.cs" Inherits="SisaDev.Administracion.Savings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">
            
                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Administracion</li>
                        <li><i class="icon_building"></i>Savings  </li>
                    </ol>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div id="maina" class="col-md-6 col-sm-6 col-xs-12" style="height: 400px;"></div>
                        <div id="mainb" class="col-md-6 col-sm-6 col-xs-12" style="height: 400px;"></div>
                    </section>
                </div>
            </div>

            <br />
           

            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div id="mainc" class="col-md-6 col-sm-6 col-xs-12" style="height: 400px;"></div>
                        <div id="maind" class="col-md-6 col-sm-6 col-xs-12" style="height: 400px;"></div>
                    </section>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">

                    </section>
                </div>
            </div>

            <%----%>

        </section>
    </section>

    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="modalEntregada" tabindex="-1" role="dialog" aria-labelledby="modalEntregada" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelmodalEntregada">Actualizar Monto</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Cantidad total</label>
                                <input type="text" class="form-control" id="txtMonto" placeholder="Cantidad." />
                                
                            </div>

                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button type="button" class="btn btn-info" id="btnGuardarMonto" data-dismiss="modal">Guardar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="modalTipoAhorro" tabindex="-1" role="dialog" aria-labelledby="modalEntregada" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelmodalTipoAhorro">Tipo de Ahorro</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal">
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <label>Tipo de Ahorro</label>
                                <select class="form-control selectpicker" data-live-search="true" id="cmbTipoAhorro">
                                    <option value="-1">--Seleccione Tipo Ahorro--</option>
                                    <option value="Directo">Directo</option>
                                    <option value="Soporte">Soporte</option>
                                    <option value="Emergencia">Emergencia</option>
                                    <option value="Ingenieria">Ingenieria</option>
                                    <option value="Capacitacion">Capacitacion</option>
                                    <option value="Logistica">Logistica</option>
                                    <option value="Paquete">Paquete</option>
                                    <option value="Generadores">Generadores</option>
                                </select>
                                
                            </div>

                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button type="button" class="btn btn-info" id="btnGuardarTipoAhorro" data-dismiss="modal">Guardar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="modalDetalle" tabindex="-1" role="dialog" aria-labelledby="modalEntregada" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="width:60%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="LabelmodalDetalle">Actualizar Monto</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <form class="form-horizontal">
                    <div class="modal-body">
                        <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <div style="overflow-x: auto; overflow-y: auto; height: 100%;">
                            <table class="table table-sm" data-pagination="true" id="TablaSavings">
                                <thead>
                                    <tr>
                                        <th data-field="FolioSavings" data-sortable="true"><i class="icon_calendar"></i>Folio Saving</th> 
                                        <th data-field="NoCotizaciones" data-sortable="true"><i class="icon_calendar"></i>Cotizacion</th> 
                                        <th data-field="FolioProyecto" data-sortable="true"><i class="icon_building"></i>Folio Proyecto</th>     
                                        <th data-field="NombreOC" data-sortable="true"><i class="icon_info_alt"></i>Folio PO</th>          
                                        <th data-field="TipoAhorro" data-sortable="true"><i class="icon_info_alt"></i>Tipo</th>      
                                        <th data-field="Monto" data-sortable="true"><i class="icon_currency"></i>Monto</th>         
                                        <th data-align="center" data-formatter="accionFormatter" data-events="accionEvents"><i class="icon_ol"></i>Acciones</th>             
                                    </tr >
                                </thead>
                            </table>
                        </div>
                    </section>
                </div>
            </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/Savings.js" type="text/javascript"></script>
</asp:Content>
