<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitarCotizacion.aspx.cs" Inherits="SisaDev.Cliente.SolicitarCotizacion" MasterPageFile="~/SitioCliente.Master"%>

<%@ Import Namespace="SisaDev.Models" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <ol class="breadcrumb">
                        <li><i class="icon_folder-open"></i>Solicitar cotizacion</li>
                        <li><i class="icon_building"></i>Crear/Modificar</li>
                    </ol>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="x_panel">

                        <div class="x_content">
                            <section class="content invoice">

                                <!-- info row -->
                                <div class="row invoice-info">
                                    <div class="col-sm-4 invoice-col">
                                        <input type="hidden" id="txtIdRFQ" runat="server" />
                                        <div class="form-group">
                                            <div class="col-sm-10">
                                                <div class="form-group" id="AddMsgRFQ">
                                                    <%--<label id="txtMensajeDatos"></label>--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.row -->
                                <div class="row">
                                    <%--<div class="col-sm-4">
                                         <label>Fecha:</label>
                                        <input type="date" class="form-control" id="dtFecha" placeholder="Fecha" />
                                    </div>
                                    --%>
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="x_panel">
                                                <div class="x_content">
                                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                                        <label><b>PLANTA:</b></label>
                                                        <select id="slctPlanta" class="form-control selectpicker" data-live-search="true">
                                                            <option value="0">-- SELECCIONE PLANTA --</option>
                                                            <option value="HSAP">FORD HSAP</option>
                                                            <option value="CHEP">FORD CHIHUAHUA</option>
                                                            <option value="CSAP">FORD CUAUTITLAN</option>
                                                            <option value="ITP">FORD IRAPUATO</option>
                                                        </select>
                                                    </div>
                                                    <div id="dvTipo" class="col-md-4 col-sm-4 col-xs-12">
                                                        <label><b>TIPO:</b></label> <i class="fa-solid fa-circle-question" id="iFoto"></i> 
                                                        <select id="slctTipo" class="form-control selectpicker" data-live-search="true">
                                                            <option value="0">-- SELECCIONE TIPO --</option>
                                                            <option value="CONSTRUCTION">CONSTRUCTION</option>
                                                            <option value="MECHANICAL">MECHANICAL</option>
                                                            <option value="SERVICES">SERVICES</option>
                                                            <option value="ELECTRICAL">ELECTRICAL</option>
                                                            <option value="INSTALLATION">INSTALLATION / RELOCATION</option>
                                                            <option value="OTHER">OTHER</option>
                                                        </select>
                                                        
                                                    </div>
                                                    <div id="dvDescTipo" class="col-md-2 col-sm-2 col-xs-12">
                                                        <label><b>DESCRIPCION:</b></label>
                                                        <input type="text" id="txtDescTipo" class="form-control col-md-2 col-sm-2 col-xs-12" placeholder="Describe el tipo" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="x_panel">
                                                <div class="x_content">
                                                    <div class="col-sm-12">
                                                        <label><b>Informacion del requisitor ó persona que atendera visita</b></label>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <div class="col-sm-5">
                                                            <div >
                                                                <label>Nombre:</label>
                                                                <input type="text" class="form-control" id="txtNombreRequisitor" placeholder="Nombre de quien atendera visita" />
                                                            </div>
                                                            <div>
                                                                <label>CDS ID:</label>
                                                                <input class="form-control" type="text" id="txtCDSID" placeholder="Identificador CDS">
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-5">
                                                            <div ">
                                                                <label>Telefono:</label>
                                                                <input type="text" class="form-control" id="txtTelefonoRequisitor" placeholder="Telefono" />
                                                            </div>
                                                            <div >
                                                                <label>Area:</label>
                                                                <select id="slctAreas" class="form-control selectpicker" data-live-search="true"></select>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="x_panel">
                                                <div class="x_content">
                                                    <div class="col-sm-12">
                                                        <label><strong>Requerimiento:</strong></label>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <label><b>1. Objetivo:</b></label>
                                                    </div>
                                                     <div class="col-sm-10">

                                                         <div class="col-sm-2">
                                                            <input type="radio"  name="grupoProposito" id="rbtnBudget" placeholder="Budget" /> 
                                                            <label for="rbtnBudget">Budget</label>
                                                         </div>
                                                        <div class="col-sm-2">
                                                            <input type="radio" name="grupoProposito" id="rbtnProyecto" placeholder="Proyecto" />
                                                            <label for="rbtnProyecto"> Proyecto</label>
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <input type="radio" name="grupoProposito" id="rbtnMantenimiento" placeholder="Mantenimiento" />
                                                            <label for="rbtnMantenimiento"> Mantenimiento</label>
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <input type="radio" name="grupoProposito" id="rbtnSeguridad" placeholder="Seguridad" /> 
                                                            <label for="rbtnSeguridad">Seguridad</label>
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <input type="radio" name="grupoProposito" id="rbtnEmergencia" placeholder="Emergencia" /> 
                                                            <label for="rbtnEmergencia">Emergencia</label>
                                                        </div>
                                                         <div class="col-sm-2">
                                                            <input type="radio" name="grupoProposito" id="rbtnSingleSource" placeholder="Single source" /> 
                                                            <label for="rbtnSingleSource">Single Source</label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="x_panel">
                                                <div class="x_content">
                                                    <div class="col-sm-10">
                                                        <label><b>2. Resumen / Scope:</b></label>
                                                        <textarea class="form-control" id="txtResumen" rows="5" cols="50" ></textarea>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="x_panel">
                                                <div class="x_content">
                                                    <div class="col-sm-12">
                                                        <label><b>3. Fecha de Visita:</b></label>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <div class="col-sm-3">
                                                            <label>Fecha</label>
                                                            <input type="date" class="form-control" id="dtFechaVisita" placeholder="Fecha de visita" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <label>Hora</label>
                                                            <input type="time" class="form-control" id="dtHoraVisita" placeholder="Hora de visita" />
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        
                                    </div>
                                    
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="x_panel">
                                                <div class="x_content">
                                                    <div class="col-sm-10">
                                                        <label><b>4. Ubicacion del trabajo a realizar:</b></label>
                                                    </div>
                                                    <div class="col-sm-10">
                                                        <input type="text" class="form-control" id="txtUbicacionTrabajo" placeholder="Ubicacion del trabajo a realizar" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        
                                    </div>
                                    
                                    
                                    
                                    
                                </div>

                                <br />

                                <!-- this row will not appear when printing -->
                                <div class="row no-print">
                                    <div class="col-xs-10">
                                        <%--<button class="btn btn-default" onclick="window.print();"><i class="fa fa-print"></i>Print</button>--%>
                                        <button class="btn btn-success pull-right btn-lg" id="btnGuardarSolicitud" type="submit"> <i class="fas fa-save"></i>Guardar</button>
                                        <%--<button class="btn btn-success pull-right" id="btnModificarCotizacion"><i class="fas fa-save"></i>Guardar</button>--%>
                                        <%--<button class="btn btn-primary pull-right" id="btnPDFRFQ" style="margin-right: 5px;"><i class="fa fa-download"></i>Generate PDF</button>--%>
                                    </div>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal fade" data-backdrop="static" data-keyboard="true" id="imgModal" tabindex="-1" role="dialog" aria-labelledby="imgModal" aria-hidden="true">
                <div class="modal-dialog modal-lg">
                   <img src="../img/Inclusions.png" />
                    <%--<div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="LabelEliminarOC">Eliminar OC</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            </button>
                        </div>
                        <div class="modal-body">
                            <img src="../img/Inclusions.png" />
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>--%>
                </div>
            </div>
        </section>
    </section>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/SolicitarCotizacion.js" type="text/javascript"></script>
</asp:Content>