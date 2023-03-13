﻿<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaestra/MtrProveedor.Master" AutoEventWireup="true" CodeBehind="facturasDet.aspx.cs" Inherits="Proveedores.portal.facturas3" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/BusquedaTabla.js"></script>
    <script>
        $(function () {

        var posicionMostrar = 0;
            var tablas = 0;

        $("#facturas").addClass("selected active"); //MODIFY SF RSG 02.2023 V2.0");
        $("#ContentPlaceHolder1_btnLLenarTbs").hide();
            
        $(".btnCargar").click(function () {
            animarLogo();
        });

        $("#ContentPlaceHolder1_File1").click(function () {
            $("#ContentPlaceHolder1_lblConsola").text("");
        });

        $("#ContentPlaceHolder1_btnLLenarTbs").hide();
        function animarLogo() {
            $("#imgNoAnimacion").hide();
            $("#imgAnimacion").show();
        }

        ocultaTablas("tblCV", posicionMostrar);
        //ocultaTablas("consola", posicionMostrar);
        if ($("#ContentPlaceHolder1_hidIndexs").val() == "") {
            if (sessionStorage.getItem("contadorCarga") != "1") {
                sessionStorage.setItem("contadorCarga", "1");
                $("#ContentPlaceHolder1_hidIndexs").val(sessionStorage.getItem("indexs"));
                $("#ContentPlaceHolder1_btnLLenarTbs").click();
            }
        }
        else {
            sessionStorage.setItem("contadorCarga", "0");
            tablas = $(".tblCV");
        }
        
        $(".imgBack").click(function () {
            if (posicionMostrar > 0) {
                if (posicionMostrar - 1 >= 0) {
                    posicionMostrar = posicionMostrar - 1;
                    ocultaTablas("tblCV", posicionMostrar);
                    ocultaTablas("consola", posicionMostrar);
                } 
            }
        });

        $(".imgNext").click(function () {
            if (posicionMostrar < tablas.length) {
                if (posicionMostrar + 1 < tablas.length) {
                    posicionMostrar = posicionMostrar + 1;
                    ocultaTablas("tblCV", posicionMostrar);
                    ocultaTablas("consola", posicionMostrar);
                }
            }
        });

 
        });
        function mostrarEstatus(idEstatus) {//  1 = Estructura correcta     2 = Estrcuctura incorrecta      3 = SAT:Cancelado   4 = SAT:Vigente     ....
            switch (idEstatus) {
                case '0':
                    break;
                case '1':
                    $("#valEstructura").html("<img src='../css/images/estatus-correcto.png' />");
                    break;
                case '2':
                    $("#valEstructura").html("<img src='../css/images/estatus-estructura_invalida.png' />");
                    break;
                default:
                    break;
            }
            
        }
        $(document).ready(function () {
            if ($(".consola").val() != 'Cargada correctamente') {
                $(".consola").css({ 'font-size': '1.5rem' });
            }
            else {
                $(".consola").css({ 'font-size': '2rem' });
            }
        });
    </script>

    <style>
        .imgNext:hover, .imgBack:hover, ico-cerrar:hover {
            -webkit-transform: scale(1.2);
            transform: scale(1.2);
        }

        .consola {
/*            font-family: fantasy;
            line-height: 20px;*/
        }
    
        .tblCV{
            border:none;
        }

        .carousel-indicators li {
            background-color: #7c8798;
        }
        
        
        
        </style>
    <%--<br />--%>
        <div class="row">
        <div class="col-md-5">
            <div class="card">
                <div class="card-body">
                    <div class="row" <%--style="border: 3px solid #0B2161;--%>">
                    <div class="col-md-12">
                        <div style="float: left; width: 100%; padding-right: 10px; margin-bottom: 10px;">
                            <asp:Literal ID="ltlTablas" runat="server"></asp:Literal>
                        </div>
                        <div class="custom-file mb-3">
                            <input type="file" class="custom-file-input" id="File1" name="File1" runat="server" lang="es" />
                            <label class="custom-file-label" for="customFile">Archivo XML</label>
                        </div>
                        <div class="custom-file mb-3">
                            <input type="file" class="custom-file-input" id="File2" name="File1" runat="server" lang="es"  />
                            <label class="custom-file-label" for="customFile">Archivo PDF</label>
                        </div>
                    </div>
                    <div class="col-md-12" style="text-align: right">
                        <asp:Button ID="cargararchivo" CssClass="btnCargar btn_ cargador btn btn-primary mb-2" runat="server" Text="Cargar" OnClick="Button1_Click" />
                    </div></div>
                </div>
            </div>
        </div>
        <div class="col-md-2">
            <div class="card1">
                <div class="card-body">
                    <div id="divValidaciones1">
                        <div class="row">
                        <div id="divLogoSF1" class="col-sm-12 text-center" style="width:100%">
                            <img id="imgNoAnimacion" src="../images/logo-ico.png" style="width:60%;max-width:100px;min-width:70px;"/>
                            <img id="imgAnimacion" src="../images/ico-sf-2-steps.gif" style="display: none;width:90%;max-width:150px;min-width:70px;" />
                        </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4 col-md-12 col-lg-4 text-center">
                                <img src="../images/ficheroNew.png" />
                            </div>
                            <div class="col-sm-4 col-md-12 col-lg-4 text-center">
                                <img src="../images/satNew.png" />
                            </div>
                            <div class="col-sm-4 col-md-12 col-lg-4 text-center">
                                <img src="../images/sapNew.png" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-5">
            <div class="card">
                <div class="card-body">
                    <div id="divConsola" style="width: 100%;min-height: 277px;border: 3px solid #0B2161; background:#CCCCCC;/*margin-left:510px*/;padding:10px;color:#333333;">
                        <%--<asp:Label ID="lblConsola" runat="server" Text="" CssClass="consola"></asp:Label>--%>
                        <asp:Label ID="lblConsola" runat="server" Text="" CssClass="error" style="font-size:1.5rem;"></asp:Label>
                        <asp:HiddenField ID="hidMessage" runat="server" /> <%--ADD SF RSG 09.04.2021--%>
                        <%--<label class="consola">ASK</label>--%> 
                        <br />
                        <asp:Label ID="lblIdEstatus" runat="server" CssClass="lblIdEstatus" Visible="False"></asp:Label>
                    </div>
                </div>
            </div>
        </div></div>
    <center>
        <div id="">
            <div id="msgWrap" style="width: 840px;">
            </div>
            <a href="facturas.aspx"><div class="ico-cerrar">VOLVER</div></a>
        </div>
    </center>
    <%--<center>
        <div id="pop-up">
                <div id="msgWrap" style="width: 840px;">
                    <div style="float: left;width: 340px;/*height: 300px;*/padding-right:10px;margin-bottom: 10px;  /*background:#E0E0E0;*/">

                        <asp:Literal ID="ltlTablas" runat="server"></asp:Literal>

                        <div id="divCargadorArchivo">
                            <strong>Archivo XML</strong><input type="file" class="input-file cargador" id="File1" name="File1" runat="server"/><br />
                            <strong>Archivo PDF</strong><input type="file" class="input-file cargador" id="File2" name="File1" runat="server"/>
                            <%--<asp:Button ID="cargararchivo" CssClass="btnCargar btn_ cargador" runat="server" Text="Cargar" OnClick="Button1_Click" Width="15%" />
                            <asp:Button ID="cargararchivo" CssClass="btnCargar btn_ cargador btn btn-primary mb-2" runat="server" Text="Cargar" OnClick="Button1_Click" Width="15%" />  <%--MODIFY SF RSG 02.2023 V2.0
                        </div>
                    </div>
                
                    <div id="divValidaciones" style="float: left;width: 150px;height:300px;/*background:#F0F0F0;*//*margin-bottom: 10px;*/">
                        <div id="divLogoSF">
                            <img id="imgNoAnimacion"src="../images/ico-sf-1-step.gif">
                            <img id="imgAnimacion" src="../images/ico-sf-2-steps.gif" style="display:none;">
                        </div>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td><img src="../images/fichero.png"></td>
                                    <td><img src="../images/sat.png"></td>
                                    <td><img src="../images/sap.png"><br /></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                
                    <div id="divConsola" style="width: 340px;height: 277px;border: 3px solid #0B2161; background:#CCCCCC;margin-left:510px;padding:10px;color:#333333;">
                        
                        <%--<asp:Label ID="lblConsola" runat="server" Text="" CssClass="consola"></asp:Label>
                        <asp:Label ID="lblConsola" runat="server" Text="" CssClass=""></asp:Label>
                        <asp:HiddenField ID="hidMessage" runat="server" /> <%--ADD SF RSG 09.04.2021
                        <%--<label class="consola">ASK</label>--
                        <br />
                        <asp:Label ID="lblIdEstatus" runat="server" CssClass="lblIdEstatus" Visible="False"></asp:Label>

                    </div>
                </div>
                <a href="facturas.aspx"><div class="ico-cerrar">VOLVER</div></a>
            </div>
        </center>--%>

    <asp:HiddenField ID="hidIndexs" runat="server" />
    <asp:Button ID="btnLLenarTbs" runat="server" Text="LLenar" OnClick="btnLLenarTbs_Click" />
</asp:Content>
