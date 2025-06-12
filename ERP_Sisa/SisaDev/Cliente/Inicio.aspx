<%@ Page Title="" Language="C#" MasterPageFile="~/SitioCliente.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SisaDev.Cliente.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script> 
        function iniciar() {
            var video = document.getElementById('video');
            //video.src = "../Video/VideoSisa.mp4";
            video.play();

           //var boton=document.getElementById('boton'); 
           //boton.addEventListener('click', presionar, false); 
        } 
        function presionar() { 
            var video = document.getElementById('video');
            //video.src = "../Video/VideoSisa.mp4";
           video.play(); 
        } 
        window.addEventListener('load', presionar, false);
    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                <video id="video" width="1200" height="650">
                    <source src="../Video/VideoSisa.mp4">
                </video>
               <%-- <input type="button" id="boton" value="Reproducir">--%>
            </div>
            <!-- page end-->
        </section>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsxpage" runat="server">
</asp:Content>
