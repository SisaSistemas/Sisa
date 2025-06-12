<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Documentos.aspx.cs" MasterPageFile="~/Sitio.Master"  Inherits="SisaDev.Admin.WebForm1" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
 <script>
     
 </script>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
      <section class="wrapper">
        <div class="row">
          <div class="col-lg-12">
            
            <ol class="breadcrumb">
              <li><i class="icon_folder-open"></i>Administración</li>
              <li><i class="icon_building"></i>Documentos</li>
            </ol>
          </div>
        </div>
        <!-- page start-->
         <div class="row">
          <div class="col-lg-12">
            <section class="panel">
               <iframe id="doc" runat="server" width="100%" height="600px"></iframe>
            </section>
          </div>
        </div>
        <!-- page end-->
      </section>
    </section>
   
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">

    
</asp:Content>






