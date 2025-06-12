<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnviarCorreo.aspx.cs" MasterPageFile="~/Sitio.Master" Inherits="SisaDev.Administracion.EnviarCorreo"  ValidateRequest="false"%>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <script>

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
                        <li><i class="icon_building"></i>Enviar correo</li>
                    </ol>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        
                        <form role="form" class="form-horizontal" runat="server">
                             <b style="color:blue;"><h4 class="modal-title" id="LabelEnviarOC"></h4></b>
                            <div class="form-group">
                               
                                <label id="TipoEnviar" hidden="hidden" runat="server"></label>
                                <label id="idEnviar" hidden="hidden" runat="server"></label>
                                <label class="col-lg-2 control-label">Para</label>
                                <div class="col-lg-10">
                                    <input type="text" placeholder="" id="txtPara" class="form-control" runat="server">
                                   
                                    <%--<asp:TextBox ID="txtPara" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                </div>
                                <label class="col-lg-2 control-label">CC</label>
                                <div class="col-lg-10">
                                    <input type="text" placeholder="" id="txtConCopia" class="form-control" runat="server">
                                    <label class="control-label" style="font-size:smaller;">Separar correos con ';'</label>
                                    <%--<asp:TextBox ID="txtPara" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                </div>
                            </div>                            
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Asunto</label>
                                <div class="col-lg-10">
                                    <input type="text" placeholder="" id="txtSubject" class="form-control" runat="server">
                                    <%--<asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <div class="col-lg-offset-2 col-lg-10">
                                    <i class="icon_documents_alt"></i>
                                        <span>Adjunto</span>
                                        
                                        <asp:FileUpload ID="files" runat="server" AllowMultiple="true" />
                                    
                                </div>
                            </div>
                           
                                <textarea style="width: 80%;" class="ckeditor" name="editor1" id="editor1" rows="15" runat="server">                               


                            </textarea>
                            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                                <div class="alert alert-danger fade in">
                                    <asp:Literal runat="server" ID="FailureText" />
                                </div>
                            </asp:PlaceHolder>
                            <asp:PlaceHolder runat="server" ID="SuccesMessage" Visible="false">
                                <div class="alert alert-success fade in">
                                    <asp:Literal runat="server" ID="SuccessText" />
                                </div>
                            </asp:PlaceHolder>
                            <asp:Button CssClass="btn btn-info pull-right" ID="btnEnviar" OnClick="btnEnviar_Click" runat="server" Text="Enviar" />
                            <input type="hidden" runat="server" id="txtCorreo" class="form-control">
                        </form>
                    </section>
                </div>
            </div>

        </section>
    </section>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/EnviarCorreo.js" type="text/javascript"></script>
</asp:Content>





