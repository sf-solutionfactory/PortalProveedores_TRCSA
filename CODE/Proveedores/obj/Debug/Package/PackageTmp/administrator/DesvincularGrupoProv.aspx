<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaestra/MtrAdministrador.Master" AutoEventWireup="true" CodeBehind="DesvincularGrupoProv.aspx.cs" Inherits="Proveedores.administrator.DesvincularGrupoProv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/Orden.css" rel="stylesheet" />

    <script src="../js/EliminarFila.js"></script>
    <script src="../js/BusquedaTabla.js"></script>

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

            $("#proveedores").addClass("selected active");    //MODIFY SF RSG 02.2023 V2.0
            mostrarDialog($("#ContentPlaceHolder1_lblDialog").html());  //MODIFY SF RSG 02.2023 V2.0
            
            //$("table").tablesorter({ debug: true });  //DELETE SF RSG 02.2023 v2.0
            $('.nav-link').text($("#ContentPlaceHolder1_hidPantalla1")[0].value);   //ADD SF RSG 02.2023 V2.0
       
        });


    </script>

    <asp:Label ID="lblDialog" runat="server" title="Informe" Text=""></asp:Label>
    
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="col">
    <div class="card col-md-12 col-lg-12">
        <div class="card-body">
            <h4 class="card-title"></h4>  
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="paraDiseno">
        <strong style="font-weight: bold; font-size: 17px;">Elija como desea desvincular</strong>  <%--MODIFY SF RSG 02.2023 V2.0--%>
        <br/><%--<br/><br/>--%>
        <div class="col-md-4 col-sm-12" style="padding-left:0px;">
        <div class="input-group mb-3">
            <asp:DropDownList ID="chkModoDesvincular" runat="server" AutoPostBack="True" OnTextChanged="MostrarInformacion" CssClass="custom-select">
                <asp:ListItem Selected="True">Por grupo</asp:ListItem>
                <asp:ListItem>Por proveedor</asp:ListItem>
            </asp:DropDownList>
            <div class="input-group-append">
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="input-group-text" />
            </div>
        </div>
        </div>
<%--        <asp:DropDownList ID="chkModoDesvincular" runat="server" AutoPostBack="True" OnTextChanged="MostrarInformacion" CssClass="form-control">
        <asp:ListItem Selected="True">Por grupo</asp:ListItem>
        <asp:ListItem>Por proveedor</asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-success" />--%> <%--MODIFY SF RSG 02.2023 V2.0--%>

<%--     <table>
        <tr>
            <td><asp:Label ID="lblDescribeNombre" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblNombreGrupo" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblDescribeTituloGrupo" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblTItuloGrupoNoticia" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>--%>
        
    </div>

    <br/>

    <div id="tablaResultados">
    <asp:Label ID="lblTextoExplicacion" runat="server" Text=""></asp:Label>
    <%--<br/>--%>
    <%--<asp:Label ID="lblTablaFiltro" runat="server" Text=""></asp:Label>--%>
    <asp:Label ID="lblMostrarTabla" runat="server" Text=""></asp:Label>

    <asp:HiddenField ID="hidVerificar" runat="server" />
    <%--<asp:HiddenField ID="hidPantalla" runat="server" Value="DesvincularGrupoProv" />--%>
    <asp:HiddenField ID="hidPantalla" runat="server" Value="DesvincularGrupoProv" />
    <asp:HiddenField ID="hidPantalla1" runat="server" Value="Ver Grupos" />

    <asp:HiddenField ID="hidComplementoUr" runat="server" />

        <asp:HiddenField ID="hidCerrarSesion" runat="server" />
    </div>
    </div>
    </div>
    </div>

</asp:Content>
