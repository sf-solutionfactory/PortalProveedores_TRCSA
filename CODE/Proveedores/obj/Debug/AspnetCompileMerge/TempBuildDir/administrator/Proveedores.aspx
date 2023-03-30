<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaestra/MtrAdministrador.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="Proveedores.administrator.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/SortTable.css" rel="stylesheet" />
    <link href="../css/Orden.css" rel="stylesheet" />
    <link href="../css/EstiloSortTables.css" rel="stylesheet" />

    <script src="../js/BusquedaTabla.js"></script>
    <script src="../js/AddDeleteTable.js"></script>

    <script>
        $(function () {

            var activaFiltro = true;

            $("#searchTermSort").keyup(function () { //$("#searchTerm").keyup(function () {
                if (activaFiltro) {
                    activaFiltro = false;
                    setTimeout(function () {
                        doSearchSorter()
                        activaFiltro = true;
                    }, 1500);
                }
            });

            //$(function () {
            //$("table").tablesorter({ debug: true });  //DELETE SF RSG 02.2023 v2.0
            //});
            //Marcar pestaña
            $("#proveedor").addClass("selected active");    //MODIFY SF RSG 02.2023 V2.0
            //sortable
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
            //bloquear y desbloquear proveedores
            $("#btnBloqDesBloqProveedores").click(function () {
                document.location.href = "MostrarPertenencia.aspx?vinculador=Proveedores&campo=Proveedor&primerproveedor=me";
            });

            $("#ContentPlaceHolder1_btnUnir").click(function () {
                takeIdSelectedsUl('sortable2', "", "", "");
            });;


            $("#btnSubmitCargaAutomatica").click(function () {
                $("#ContentPlaceHolder1_btnCargaAutomaticaProv").submit();
            });

            $("#sortable2").mouseenter(function (e) {
                ulBorrar("sortable2");
            });


            $("#sortable2").mouseleave(function (e) {
                ulPintarPrimero("sortable2");
            });

            $("#sortable1").mouseleave(function (e) {
                ulBorrar("sortable1");
                ulPintarPrimero("sortable2");
            });

            if ($("#sortable1").height() != $("#sortable2").height()) {
                $("#sortable2").css("height", $("#sortable1").height());
            }
            $(".cls_mpletras").click(function () {//para mostrar por orden de letra
                var codeHtml = $("#<%=lblObjeto1.ClientID%>").html();
                codeHtml = codeHtml.replace(/</g, "[");
                codeHtml = codeHtml.replace(/>/g, "]");
                $("#procar").val(codeHtml);
            });
            mostrarDialog($("#ContentPlaceHolder1_lblDialog").html());  //MODIFY SF RSG 02.2023 V2.0
            //agregarTitle();

            $(".tblComun td:nth-child(2n+1)").addClass("td-impar");
            $(".tblComun td:nth-child(2n)").addClass("td-par");

        });

        //function agregarTitle() {
        //    $(".primerLi").attr('title', 'Sera tomado como el titular del nuevo grupo');
        //}

    </script>

    <style>
        .primerLi {
            border: 5px solid #F78181;
            /*border-color: #FE2E2E;*/
        }

        .idProv {
            margin-right: 3em;
            /*margin: 5em;*/
        }

        /*.img {
            max-width: 60px;
            
        }*/

        /*.tableIco {
            background: none;
            border-style: solid;
            border-width: medium;
            border-color: #FAFAFA;
            float: right;
        }

        .tableIco:hover {
            background: #E6E6E6;
            cursor:pointer;
        }*/

        .datMtrWrap {
            height: 7em;
        }

        .btn {
            /*margin-left: 60%;*/
            min-width:10px;
        }
    </style>

    <asp:Label ID="lblDialog" runat="server" title="Informe" Text=""></asp:Label>
    
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="col">
    <div class="card col-md-12 col-lg-12">
        <div class="card-body">
            <h4 class="card-title"></h4>  
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="paraDiseno row"> <!--MODIFY SF RSG 02.2023 V2.0-->

        <table class="tblFm2">
            <tr>
                <td><strong style="font-weight: bold; font-size: 17px;">Estos son los proveedores existentes: </strong></td>    <%--//MODIFY SF RSG 02.2023 V2.0--%>
            </tr>
        </table>
        <br />
        <br />
    </div>
    <%--//BEGIN OF DELETE SF RSG 02.2023 V2.0--%>
<%--    <table class="tblFm">
        <tr>
            <td>
                <asp:Label ID="lblTablaFiltro" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblNombreGrupo" runat="server" Text="Nombre del grupo:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombreGrupo" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnUnir" runat="server" Text="Unir" OnClick="btnUnir_Click" class="btn btn-success" />  
            </td>
        </tr>
    <br />
    </table>--%>
    <%--//END   OF DELETE SF RSG 02.2023 V2.0--%>
    <%--//BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
            <div class="row">
                <div class="col-md-6 col-sm-12">
                    <div class="col-md-6 col-sm-6">
                        <asp:Label ID="lblTablaFiltro" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 col-sm-12">
                    <div class="form-group col-md-6">
                        <asp:Label ID="lblNombreGrupo" runat="server" Text="Nombre del grupo:"></asp:Label>
                        <asp:TextBox ID="txtNombreGrupo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                        <div class="col-md-12" style="text-align:right">
                            <asp:Button ID="btnUnir" runat="server" Text="Unir" OnClick="btnUnir_Click" class="btn btn-success" Width="100"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <div class="btn-group" role="group" aria-label="Basic example"><input type="submit" name="letra" class="cls_mpletras btn" value="0 - 9" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="A" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="B" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="C" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="D" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="E" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="F" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="G" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="H" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="I" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="J" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="K" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="L" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="M" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="N" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="Ñ" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="O" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="P" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="Q" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="R" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="S" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="T" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="U" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="V" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="W" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="X" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="Y" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="Z" /></div>
                    <div class="btn-group" role="group" aria-label="Second group"><input type="submit" name="letra" class="cls_mpletras btn" value="Otros" /></div>
                </div>
            </div>
        <%--//END   OF INSERT SF RSG 02.2023 V2.0--%>
   <%-- <table>
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
        </table>--%>
        <input id="procar" type="hidden" name="procargado" value="" />
<%--    <table class="tblFm">
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>--%>
    <%--//BEGIN OF DELETE SF RSG 02.2023 V2.0--%>
    <%--<div id="tablaPRoveedores">--%>
    <%--<asp:Label ID="lblTablaProveedores" runat="server" Text=""></asp:Label>--%>
    <%--</div>--%>

    <%--<div id="DatosProveedoresUnir">--%>
    <%--<asp:Label ID="lblObjeto1" runat="server" Text=""></asp:Label>--%>
    <%--</div>--%>
    <%--//END OF DELETE SF RSG 02.2023 V2.0--%>
    <%--//BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="row">
        <div class="col-sm-6" style="max-width:50%;">
            <asp:Label ID="lblTablaProveedores" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-sm-6" style="max-width:50%;">
            <asp:Label ID="lblObjeto1" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <%--//END OF INSERT SF RSG 02.2023 V2.0--%>
    <br />

    <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
    <br />
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
            </div>
            </div>
            </div>
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>

    <asp:HiddenField ID="hidRFC1" runat="server" />
    <asp:HiddenField ID="hidRFC2" runat="server" />
    <asp:HiddenField ID="hidVerificar" runat="server" Value="si" />
    <asp:HiddenField ID="hidIdSelected" runat="server" />
    <asp:HiddenField ID="hidComplementoUr" runat="server" />

    <asp:HiddenField ID="hidCerrarSesion" runat="server" />

</asp:Content>
