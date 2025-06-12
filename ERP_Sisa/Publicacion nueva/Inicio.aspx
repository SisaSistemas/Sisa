<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Sitio.Master" CodeBehind="Inicio.aspx.cs" Inherits="SisaDev.Inicio" %>


<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <link href="css/slider.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="overlay"></div>
    <section id="main-content">
      <section class="wrapper">
        <div class="row">
          <div class="col-lg-12">
            
            <ol class="breadcrumb">
              <li><i class="fa fa-home"></i>Inicio</li>
              
            </ol>
          </div>
        </div>
        <!-- page start-->
		  <div class="wrapper2">
    <div class="slider" id="slider">      
        <ul class="slides" id="slideimagenes">       
            <%--<li class="slide" id="slide1">
                <a href="#">
                    <p class="caption">Texto llamativo</p>
                    <img src="img/Russia.png" alt="photo 1">      
                </a>
            </li>--%>
                          
        </ul>
        <ul class="slider-controler" id="slidenumeracion">         
            <%--<li><a href="#slide1">&bullet;</a></li>
            <li><a href="#slide2">&bullet;</a></li>
            <li><a href="#slide3">&bullet;</a></li>
            <li><a href="#slide4">&bullet;</a></li>
            <li><a href="#slide5">&bullet;</a></li>--%>
        </ul>
    </div>
</div>
        <!-- page end-->
      </section>
    </section>
    

</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="jsxpage" runat="server">
    <script src="<%= ResolveUrl("~") %>js/Inicio.js" type="text/javascript"></script>
    <%--<script src="<%= ResolveUrl("~") %>js/Inicio.js"></script>
    <script src="<%= ResolveUrl("~") %>js/fullcalendar.min.js"></script>
    <script src="<%= ResolveUrl("~") %>js/jquery-1.8.1.min.js"></script>
    <script src="<%= ResolveUrl("~") %>js/jquery-ui-1.8.23.custom.min.js"></script>--%>

</asp:Content>
