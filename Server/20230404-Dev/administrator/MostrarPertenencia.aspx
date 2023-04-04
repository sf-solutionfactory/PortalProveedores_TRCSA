<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaestra/MtrAdministrador.Master" AutoEventWireup="true" CodeBehind="MostrarPertenencia.aspx.cs" Inherits="Proveedores.administrator.MostrarPertenencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/Orden.css" rel="stylesheet" />
    <%--<link href="../css/EstiloSortTables.css" rel="stylesheet" />--%>

    <script src="../js/BusquedaTabla.js"></script>
    <script src="../js/EliminarFila.js"></script>

    
    
    
    <style>        .btn { min-width:10px;        }    </style>    <%--//ADD SF RSG 02.2023 V2.0--%>
    <script>

        $(function () {

            var activaFiltro = true;

            $("#searchTerm").keyup(function () { //$("#searchTerm").keyup(function () {
                if (activaFiltro) {
                    activaFiltro = false;
                    setTimeout(function () {
                        doSearch();
                        activaFiltro = true;
                    }, 1500);
                }
            });

            switch ($("#ContentPlaceHolder1_hidVinculador").val()) {
                case "usuario":
                    $("#usuario").addClass("selected active");    //MODIFY SF RSG 02.2023 V2.0
                    break;
                case "AsignarRol":
                    $("#asignarRol").addClass("selected active");    //MODIFY SF RSG 02.2023 V2.0
                    break;
                case "Proveedores":
                    $("#proveedores").addClass("selected active");    //MODIFY SF RSG 02.2023 V2.0
                    break;
                default:
                    break;
            }

            $("#btnBack").click(function () {
                try {
                    var vinculador = $("#ContentPlaceHolder1_hidVinculador").val();
                } catch (e) {
                    vinculador = "Proveedores";
                }
                document.location.href = vinculador + ".aspx";
            });

            $(".tblComun2>tbody>tr").click(function () {

                var proveedor = $(this).find("td:nth-child(1)").html();
                var nombre = $(this).find("td:nth-child(2)").html();
                var descripcion = $(this).find("td:nth-child(3)").html();
                var vinculador = $("#ContentPlaceHolder1_hidVinculador").val();// se recibe al llamar esta ASP
                var campo = $("#ContentPlaceHolder1_hidCampo").val(); // se recibe de 'usuario' al llamar esta ASP
                var primerProveedor = $("#ContentPlaceHolder1_hidPrimerProveedor").val();
                switch (vinculador) {
                    case "AsignarRol":
                        document.location.href = "AsignarRol.aspx?rfc=" + $.trim(proveedor) + "&nom=" + $.trim(nombre) + "&desc=" + $.trim(descripcion);
                        break;
                    case "usuario":
                        document.location.href = "usuario.aspx?rfc=" + $.trim(proveedor) + "&nom=" + $.trim(nombre) + "&desc=" + $.trim(descripcion) + "&campo=" + campo + "&primerproveedor=" + $.trim(primerProveedor);
                        break;
                    case "Proveedores":
                        break;
                    default:
                        document.location.href = "Proveedores.aspx";
                        break;
                }
            });
            mostrarDialog($("#ContentPlaceHolder1_lblDialog").html());    //MODIFY SF RSG 02.2023 V2.0
            //$('.nav-link').text($("#ContentPlaceHolder1_hidPantalla")[0].value);   //ADD SF RSG 02.2023 V2.0


            //$("table").tablesorter({ debug: true });  //DELETE SF RSG 02.2023 v2.0

        });

    </script>

    <asp:Label ID="lblDialog" runat="server" title="Informe" Text=""></asp:Label>
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="col">
    <div class="card col-md-12 col-lg-12">
        <div class="card-body">
            <h4 class="card-title"></h4>  
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>

    <%--<img id="btnBack" src="../images/ico-Volver.png" />--%>
    <div class="row">  <%--ADD SF RSG 02.2023 V2.0--%>
        <div class="col-md-6">  <%--ADD SF RSG 02.2023 V2.0--%>
            <label class="btn btn-success" title="Volver" style="margin-bottom:0px;"><i id="btnBack" class="fa-solid fa-arrow-left" name="Regresar"></i></label>
            <%--<br />--%>
            <asp:Label ID="lblInfoProveedores" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblEleccion" runat="server" Text=""></asp:Label>
            <asp:Button ID="btnDescargarE" runat="server" Text="Descargar en formato Excel" OnClick="btnDescargarE_Click" Visible="False" CssClass="btn btn-primary" />  <%--MODIFY SF RSG 02.2023 V2.0--%>
        </div>
    </div>
    <div class="paraDiseno">
        <%--<br />--%>
        <%--<div id="contenidoPost"></div>--%>  <%--DELETE SF RSG 02.2023 V2.0--%>
        <br />
        <%--BEGIN OF DELETE SF RSG 02.2023 V2.0--%>
<%--        <table>
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

        <br />
        <asp:Label ID="lblTablaFiltro" runat="server" Text=""></asp:Label>
        <br />--%>
        <%--BEGIN OF DELETE SF RSG 02.2023 V2.0--%>
        
        <%--//BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
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
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>

        <br />
        <br />
        <asp:Label ID="lblComplementoFail" runat="server" Text=""></asp:Label>

        <asp:HiddenField ID="hidVinculador" runat="server" />
        <asp:HiddenField ID="hidCampo" runat="server" />
        <asp:HiddenField ID="hidPrimerProveedor" runat="server" />

        <asp:HiddenField ID="hidPantalla" runat="server" Value="Proveedores" />

        <asp:HiddenField ID="hidCerrarSesion" runat="server" />

    </div>
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
            </div>
            </div>
            </div>
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>

</asp:Content>
