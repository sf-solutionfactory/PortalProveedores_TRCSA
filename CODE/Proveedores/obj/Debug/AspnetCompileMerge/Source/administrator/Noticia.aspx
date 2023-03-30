<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaestra/MtrAdministrador.Master" AutoEventWireup="true" CodeBehind="Noticia.aspx.cs" Inherits="Proveedores.administrator.Noticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/Orden.css" rel="stylesheet" />

    <script src="../js/validarNotNull.js"></script>
    <script src="../js/BusquedaTabla.js"></script>
    <script src="../js/EliminarFila.js"></script>
    <script src="../scripts/tinymce/tinymce.js"></script>
    <script src="../js/validarCalendario.js"></script>
    <%--<script src="../js/ValidarCaracteresEntrada.js"></script>--%>

    <script>
        $(function () {

            var activaFiltro = true;

            $("#searchTerm").keyup(function () { 
                if (activaFiltro) {
                    activaFiltro = false;
                    setTimeout(function () {
                        doSearch();
                        activaFiltro = true;
                    }, 1500);
                }
            });
            
            $("#noticias").addClass("selected active");  //MODIFY SF RSG 02.2023 V2.0
           
            $('#ContentPlaceHolder1_btnGuardar, #ContentPlaceHolder1_btnModificar').click(function () {
                if (validar()) {
                    if (validarCalendario("#ContentPlaceHolder1_datepicker")){
                        if (validarCalendario("#ContentPlaceHolder1_datepicker2")) {
                            if (validarCalendario(".datepicker")) {
                                validarCalendario(".datepicker2");
                            }
                        }
                    }
                }                
            });

            //$("table").tablesorter({ debug: true });  //DELETE SF RSG 02.2023 v2.0

            tinymce.init({
                selector: 'textarea',
                plugins: "fullpage",
                toolbar_items_size: 'small',
                inline: false,
                //width: 310,
                language: "es_MX",
                plugins: [
                'advlist autolink lists charmap anchor',
                'searchreplace visualblocks code fullscreen',
                'insertdatetime table contextmenu paste textcolor textcolor'
                ],
                toolbar: 'bold italic bullist numlist | alignleft aligncenter alignright alignjustify | forecolor backcolor fontsizeselect styleselect ',
                fontsize_formats: '10px 12px 14px 16px 18px 24px 36px',
                menubar: false

            });

            //$("#wrapMenu").css({ "z-index": "3" });
            //$("#mceu_16").css({ "z-index": "1" });

            $("#<%=btnGuardar.ClientID%>").click(function () {
                var codeHtml = tinyMCE.activeEditor.getContent({ format: 'raw' });
                codeHtml = codeHtml.replace(/</g, "[");
                codeHtml = codeHtml.replace(/>/g, "]");
                $("#<%=hidContenido.ClientID%>").val(codeHtml);
            });
            $("#<%=btnModificar.ClientID%>").click(function () {
                var codeHtml = tinyMCE.activeEditor.getContent({ format: 'raw' });
                codeHtml = codeHtml.replace(/</g, "[");
                codeHtml = codeHtml.replace(/>/g, "]");
                $("#<%=hidContenido.ClientID%>").val(codeHtml);
            });
            $("#<%=btnCancelar.ClientID%>").click(function () {
                var codeHtml = tinyMCE.activeEditor.getContent({ format: 'raw' });
                codeHtml = codeHtml.replace(/</g, "[");
                codeHtml = codeHtml.replace(/>/g, "]");
                $("#<%=hidContenido.ClientID%>").val(codeHtml);
            });
            if($("#<%=hidContenido.ClientID%>").val() != "") {
                $("#txtAreaContenido1").val($("#<%=hidContenido.ClientID%>").val());
            }
            mostrarDialog($("#ContentPlaceHolder1_lblDialog").text());  //MODIFY SF RSG 02.2023 V2.0
        });
    </script>
    <style>
        
    </style>

    <asp:Label ID="lblDialog" runat="server" title="Informe" Text=""></asp:Label>
    
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="col">
    <div class="card col-md-12 col-lg-12">
        <div class="card-body">
            <h4 class="card-title"></h4>  
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
    <%--<div class="paraDiseno ">--%> <!--MODIFY SF RSG 02.2023 V2.0-->

        <table class="tblFm2">
            <tr>
                <td><strong style="font-weight: bold; font-size: 17px;">Aquí puedes crear nuevas noticias:</strong></td>
            </tr>
        </table>
    
    <br/>
            <div class="row">
                <div class="col-md-6">
                    <div class="row">
                        <div class="form-group col-md-12">
                            <label>Título</label>
                            <asp:TextBox ID="txtTitulo" runat="server" class="txtValidar form-control <%--ampliar--%>" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-md-6">
                            <label>Inicio validez</label>
                            <asp:TextBox ID="datepicker" runat="server" class="txtValidar form-control <%--ampliar--%>"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Fin validez</label>
                            <asp:TextBox ID="datepicker2" runat="server" class="txtValidar form-control <%--ampliar--%>"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-md-12">
                            <label>Dirección URL de imagen</label>
                            <asp:TextBox ID="txtURLImagen" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <fieldset class="form-group">
                        <div class="row">
                            <legend class="col-form-label col-sm-3 pt-0">Tipo</legend>
                            <asp:RadioButtonList ID="rdbTipoNoticia" runat="server">
                                <asp:ListItem Selected="True">General</asp:ListItem>
                                <asp:ListItem>Asignable</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </fieldset>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="form-group col-md-12">
                            <label>Cuerpo de noticia</label>
                            <textarea id="txtAreaContenido1" style="width: 100%; height: 200px; margin-top: 100px;" class="form-control"></textarea>
                        </div>
                    </div>
                </div>
            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnModificar" runat="server" Text="Guardar cambios" OnClick="btnModificar_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-light" OnClick="btnCancelar_Click" />
<%--    <table class="tblFm">
        <tr>
            <td>
                Titulo
            </td>
            <td>
                <asp:TextBox ID="txtTitulo" runat="server" class="txtValidar ampliar" MaxLength="100"></asp:TextBox>
            </td>

        </tr> 
        <tr>
            <td>
                Cuerpo de noticia
            </td>
            <td>
                <textarea id="txtAreaContenido1" style="width: 400px; height: 200px; margin-top: 100px;"></textarea>--%>
                <%--<asp:TextBox ID="txtAreaContenido" runat="server" Columns="50" Rows="8" TextMode="multiline" class="txtValidar" MaxLength="500" />--%>
                
<%--            </td>
        </tr> 
        <tr>
            <td>
               Inicio validez 
            </td>
            <td>
               <asp:TextBox ID="datepicker" runat="server" class="txtValidar ampliar"></asp:TextBox>
            </td>

        </tr> 
        <tr>
            <td>
                Fin validez
            </td>
            <td>
                 <asp:TextBox ID="datepicker2" runat="server" class="txtValidar ampliar"></asp:TextBox>
            </td>
        </tr> 
        <tr>
            <td>
                Dirección URL de imagen 
            </td>
            <td>
                <asp:TextBox ID="txtURLImagen" runat="server" CssClass="ampliar"></asp:TextBox>
            </td>

        </tr> 
        <tr>
            <td>
                Tipo 
            </td>
            <td>
                <asp:RadioButtonList ID="rdbTipoNoticia" runat="server">
                            <asp:ListItem Selected="True">General</asp:ListItem>
                            <asp:ListItem>Asignable</asp:ListItem>
                        </asp:RadioButtonList>
            </td>

        </tr>
         <tr>
            <td>
                
            </td>
            <td style="text-align:right">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
                <asp:Button ID="btnModificar" runat="server" Text="Guardar cambios" OnClick="btnModificar_Click"  CssClass="btn btn-primary" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-light" OnClick="btnCancelar_Click" />
            </td>

        </tr> 

    </table>--%>

   <%--</div>--%>
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
   </div>
   </div>
    <div class="card col-md-12 col-lg-12">
        <div class="card-body">
            <h4 class="card-title"></h4>  
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
            
    <div id="tablaResultados">
    <%--<br/><br/>--%>
        <table class="tblFm2">
            <tr>
                <td><asp:Label ID="lblDescribeResultados" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        

        <%--<table class="tblFm">
            <tr>
                <td><asp:Label ID="lblTablaFiltro" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        <br/>--%>
     
<%--    <br/>
    <br/>--%>
     <asp:Label ID="lblTablaNoticias" runat="server" Text=""></asp:Label>

   </div>
   </div>
   </div>
   </div>
    <br/>
    
    <asp:HiddenField ID="hidContenido" runat="server" />
    <asp:HiddenField ID="hidVerificar" runat="server" />
    <asp:HiddenField ID="hidPantalla" runat="server" Value="Noticia" />

    <asp:HiddenField ID="hidIdAnt" runat="server" />
    <asp:HiddenField ID="hidComplementoUr" runat="server" />

    <asp:HiddenField ID="hidCerrarSesion" runat="server" />
</asp:Content>
