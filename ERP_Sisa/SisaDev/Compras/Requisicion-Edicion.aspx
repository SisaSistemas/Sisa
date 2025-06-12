<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Requisicion-Edicion.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Compras.Requisicion_Edicion" %>


<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     
 </script>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
 <%--   <div id="loading-img">  <img src="../img/logoloading.png" /></div>--%>
    <section id="main-content">
      <section class="wrapper">
        <div class="row">
          <div class="col-lg-12">
            
            <ol class="breadcrumb">
              <li><i class="icon_folder-open"></i>Administración</li>
              <li><i class="icon_building"></i>Requisiciones</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
                <div class="form-group" id="MensajeRequisiciones">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
              <div class="alert alert-danger fade in">
                  <asp:Literal runat="server"  ID="FailureText" />
              </div>
            </asp:PlaceHolder>
                <div class="form-group" id="CargandoRequisiciones">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              <form class="form-horizontal" runat="server">
      
        <input type="hidden" id="txtIdRequicion" runat="server"/>
             <div class="form-group">
              <div class="col-sm-10">
                  <label>Folio</label>
                  <input type="text" class="form-control" placeholder="Folio" id="txtFolio" readonly/>
              </div>
            </div>
             <div class="form-group">
              <div class="col-sm-10">
                  <label>Fecha</label>
                  <input type="text" class="form-control" placeholder="Fecha" id="txtFecha" readonly/>
              </div>
            </div>
            <div class="form-group">
              <div class="col-sm-10">
                  <label>Proyecto</label>
                  <input id="idProyecto" type="hidden" class="form-control"/>
                  <input id="txtProyecto" type="text"  class="form-control" readonly/>
                      
              </div>
          </div>  
          <div>
              <div class="col-sm-10">
                  <%--<input type="hidden" class="form-control col-lg-4 agrega" style="width:20%;" value="" placeholder="idDetalle" id="txtidDetalle" required/>--%>
                  <input type="text" class="form-control col-lg-4 agregaedita" style="width:20%;" placeholder="Descripcion" id="txtDescripcion" required/>
                  <input type="number" class="form-control col-lg-4 agregaedita" style="width:20%;" placeholder="Cantidad" id="txtCantidad" required/>
                  <input type="text" class="form-control col-lg-4 agregaedita" style="width:15%;" placeholder="Unidad" id="txtUnidad" required/>
                  <input type="text" class="form-control col-lg-4 agregaedita" style="width:20%;" placeholder="No. Parte" id="txtParte"/>
                  <input type="text" class="form-control col-lg-4 agregaedita" style="width:15%;" placeholder="Marca" id="txtMarca"/>
                  <a data-toggle="tooltip" data-placement="top" style="width:10%;"  title="Agregar"><span class="btn btn-primary" id="btnAgregarItem"><i class="icon_plus_alt"></i></span></a>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                   <table id="tblReqAddEdit" class="table table-striped table-advance table-hover">
                        <thead>
                            <tr>                                
                                <th>#</th>
                                <th>Descripción</th>
                                <th>Cantidad</th>
                                <th>Unidad</th>
                                <th>Num Parte</th>
                                <th>Marca</th>
                                <th></th>
                            </tr>
                        </thead>
                    </table>
                  </div>
              </div>
         
            <div class="form-group">
              <div class="col-sm-10">
                  <textarea class="form-control" placeholder="Comentarios" id="txtComentariosReq" cols="5" style="resize: none;"></textarea>
              </div>
            </div>
          <div class="form-group">
              <div class="col-sm-10">
                  <div class="form-group" id="AddMsgRequisiciones">
                     <%--<label id="txtMensajeDatos"></label>--%>
                  </div>
              </div>
            </div>
      
      <button class="btn btn-primary" id="btnActualizarRequisiciones" type="button">Actualizar</button>
      
      </form>
            </section>
          </div>
        </div>
        <!-- page end-->
      </section>
    </section>
   
    
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">    
    <script src="<%= ResolveUrl("~") %>js/Requisicion-Edicion.js" type="text/javascript" ></script> 
</asp:Content>






