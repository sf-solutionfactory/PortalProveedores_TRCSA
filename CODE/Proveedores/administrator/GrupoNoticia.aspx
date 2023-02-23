<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaestra/MtrAdministrador.Master" AutoEventWireup="true" CodeBehind="GrupoNoticia.aspx.cs" Inherits="Proveedores.administrator.GrupoNoticia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/Orden.css" rel="stylesheet" />
    <link href="../css/SortTable.css" rel="stylesheet" />



    <script src="../js/BusquedaTabla.js"></script>
    <script src="../js/AddDeleteTable.js"></script>
    <script src="../js/validarNotNull.js"></script>

    <link href="../js/SortTable/jquery-ui.css" rel="stylesheet" />
    <link href="../js/SortTable/style.css" rel="stylesheet" />

    <link href="../css/SortableGrupoNoticia.css" rel="stylesheet" />
    <link href="../css/EstiloSortTables.css" rel="stylesheet" />

    <script>

        $(function () {

            var activaFiltro = true;

            $("#searchTermSort").keyup(function () { //$("#searchTerm").keyup(function () {
                if (activaFiltro) {
                    activaFiltro = false;
                    setTimeout(function () {
                        doSearchSorter();
                        activaFiltro = true;
                    }, 1500);
                }
            });

            $("#grupoNoticia").addClass("selected active");

            $("#ContentPlaceHolder1_btnSubmit").click(function () {
                //alert("por entrar");
                var nombre = $("#ContentPlaceHolder1_txtNombreGrupoN").val();
                var idNoticia = $("#ContentPlaceHolder1_lblIdNoticia").text();
                var titulo = $("#ContentPlaceHolder1_lblNoticiaSeleccionada").text();
                if (validar()) {
                    takeIdSelectedsUl('sortable2', nombre, idNoticia, titulo);
                }

            });

            $("#ContentPlaceHolder1_btnGuardarCambios").click(function () {
                var nombre = $("#ContentPlaceHolder1_txtNombreGrupoN").val();
                var idNoticia = $("#ContentPlaceHolder1_lblIdNoticia").text();
                var titulo = $("#ContentPlaceHolder1_lblNoticiaSeleccionada").text();
                if (validar()) {
                    takeIdSelectedsUl('sortable2', nombre, idNoticia, titulo);
                }

            });

            $("#lblBUsquedaNoticia").click(function () {
                //alert("alive");
                var nombre = "";
                nombre = $.trim($("#ContentPlaceHolder1_txtNombreGrupoN").val());
                document.location.href = "MostrarNoticias.aspx?vinculador=GrupoNoticia&nombreGrupo=" + nombre;
            });

            $("#btnGrupoNoticia").click(function () {
                document.location.href = "DesvincularGrupoNoticia.aspx";

            });

            //$(".tableIco").click(function () {
            //    //alert("alive");
            //    //var nombre = $trim($("#ContentPlaceHolder1_txtNombreGrupoN").val());
            //    document.location.href = "DesvincularGrupoNoticia.aspx";
            //    //$(location).attr('href', "DesvincularGrupoNoticia.aspx");
            //});


            
           $("table").tablesorter({ debug: true });
            

            $("ul.droptrue").sortable({
                connectWith: "ul"
            });

            $("ul.dropfalse").sortable({
                connectWith: "ul",
                dropOnEmpty: true
            });

            $("#sortable1, #sortable2").sortable({
                placeholder: "ui-state-highlight"
            });

            $("#sortable1, #sortable2").disableSelection();

            mostrarDialog($("#ContentPlaceHolder1_lblDialog").text());  //MODIFY SF RSG 02.2023 V2.0

            if ($("#sortable1").height() != $("#sortable2").height()) {
                $("#sortable2").css("height", $("#sortable1").height()*0.9);
            }

            $(".idProv").hide();
            $(".cls_mpletras").click(function () {//para mostrar por orden de letra
                var codeHtml = $("#<%=lblTablaDos.ClientID%>").html();
                codeHtml = codeHtml.replace(/</g, "[");
                codeHtml = codeHtml.replace(/>/g, "]");
                $("#procar").val(codeHtml);
            });

        });

        function eventoEnter() {
            if ($("#ContentPlaceHolder1_lblDialog").text() != null && $("#ContentPlaceHolder1_lblDialog").text() != "") {
                $("#ContentPlaceHolder1_lblDialog").dialog("open");
            }
        }
    </script>

    <style>

         
        

        #btnGrupoNoticia {
            width: 100px;
        }

        .img {
            max-width: 60px;
        }

        .tableIco {
            background: none;
            border-style: solid;
            border-width: medium;
            border-color: #FAFAFA;
            float: right;
            margin-right: 7%;
        }

            .tableIco:hover {
                background: #E6E6E6;
                cursor: pointer;
            }

        #datosNoticia, .tableIco {
            display: inline-block;
            vertical-align: top;
        }

        #tablaResultados {
            margin-top: 3em;
        }

         #ContentPlaceHolder1_drlbTipoGrupo {
           min-width: inherit;
            min-height: inherit;
        }

        /*.actionFloat {
            float: right;
             min-height: 20px;
             width:30px;
             margin-right:2%;
             
        }*/

        

        

        /*#sortable1.droptrue.ui-sortable, #sortable2.droptrue.ui-sortable {
            min-width: 600px;
            width:45%;
        }*/
    </style>

    <asp:Label ID="lblDialog" runat="server" title="Informe" Text="sssdd"></asp:Label>
    
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="card col-md-12 col-lg-12">
        <div class="card-body">
            <h4 class="card-title"></h4>  
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="paraDiseno">
        
        <table class="tblFm2">
            <tr>
                <td><strong style="font-weight: bold; font-size: 18px;">Aquí puedes crear grupos de noticias</strong></td>    <%--MODIFY SF RSG 02.2023 V2.0--%>
            </tr>
        </table>
        <%--<br/>--%>


        <table id="datosNoticia" class="tblFm">
            <tr>
                <td>Nombre del grupo
                </td>
                <td class="ampliar2"></td>
                <td>
                    <asp:TextBox ID="txtNombreGrupoN" runat="server" class="txtValidar"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>Noticia seleccionada
                </td>
                <td>
                    <asp:Label ID="lblIdNoticia" runat="server" Text=""></asp:Label><asp:Label ID="lblNoticiaSeleccionada" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnBUscarNoticia" runat="server" Text="Buscar noticia..." OnClick="btnBUscarNoticia_Click" CssClass="btn btn-primary" />    <%--MODIFY SF RSG 02.2023 V2.0--%>
                </td>
            </tr>
            <tr>
                <td>Tabla de noticias seleccionadas
                </td>
            </tr>
        </table>

        <br />
       <asp:Literal ID="ltlTablaNoticiasSeleccionadas" runat="server"></asp:Literal>
    </div>

        
    <div id="tablaResultados">

    </div>
        
        <table class="tblFm2">
            <tr>
                <td><strong style="font-weight: bold; font-size: 18px;">Proveedores</strong></td>    <%--MODIFY SF RSG 02.2023 V2.0--%>
            </tr>
        </table>

        <%--<br />--%>
        <table class="tblFm">
            <tr>
               <td>
                <asp:DropDownList ID="drlbTipoGrupo" runat="server" CssClass="btn actionFloat">
                    <asp:ListItem Value="proveedor">Por proveedor</asp:ListItem>
                    <asp:ListItem Value="grupo">Por grupo</asp:ListItem>
                </asp:DropDownList>
                   </td>
<%--                <td>
                    <asp:Label ID="lblTablaFiltro" runat="server" Text=""></asp:Label></td>--%>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Crear grupo" OnClick="crearGrupo" CssClass="btn btn-primary" /></td>    <%--MODIFY SF RSG 02.2023 V2.0--%>
                <td>
                    <asp:Button ID="btnGuardarCambios" runat="server" Text="Guardar cambios" OnClick="GuardarCambios" CssClass="btn btn-primary" /></td>    <%--MODIFY SF RSG 02.2023 V2.0--%>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="Cancelar" CssClass="btn btn-light" /></td>    <%--MODIFY SF RSG 02.2023 V2.0--%>
                <td>
            </td>
            </tr>
        </table>

        <br />
        <br />
        <table>
            <tr>
                <td><input type="submit" name="letra" class="cls_mpletras" value="0 - 9"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="A"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="B"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="C"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="D"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="E"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="F"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="G"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="H"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="I"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="J"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="K"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="L"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="M"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="N"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="Ñ"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="O"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="P"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="Q"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="R"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="S"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="T"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="U"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="V"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="W"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="X"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="Y"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="Z"/></td>         
                <td><input type="submit" name="letra" class="cls_mpletras" value="Otros"/></td>         
            </tr>
        </table>
        <input id="procar" type="hidden" name="procargado" value="" />
        <br />

    <div class="row">
        <div class="col-lg-6">
            <asp:Label ID="lblTablaProveedores" runat="server" Text=""></asp:Label>
        </div>
         <div class="col-lg-6">
        <asp:Label ID="lblTablaDos" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </div>
    </div>
        <%--</center>--%>
    


    <asp:HiddenField ID="hidIdsNoticiasSeleciondas" runat="server" />
    <asp:HiddenField ID="HidGrupoEdit" runat="server" />
    <asp:HiddenField ID="hidIDX" runat="server" />
    <asp:HiddenField ID="hidVerificar" runat="server" />
    <asp:HiddenField ID="HidHecho" runat="server" />
    <asp:HiddenField ID="hidIdSelected" runat="server" />

    <asp:HiddenField ID="hidCerrarSesion" runat="server" />

</asp:Content>
