<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaestra/MtrProveedor.Master" AutoEventWireup="true" CodeBehind="prtAbiertas.aspx.cs" Inherits="Proveedores.portal.prtAbiertas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script src="../js/BusquedaTabla.js"></script>

    

    <script>
        $(function () {

            var activaFiltro = true;
            
            $("#prtAbiertas").addClass("active");

            $(".ico-actualizar").click(function () {
                //alert("in")
                $("#ContentPlaceHolder1_hidActualiza").val("actualiza");
                //document.location.href = "facturas.aspx";
            });

            //$("#searchTerm").keyup(function () { //$("#searchTerm").keyup(function () {
            //    if (activaFiltro) {
            //        activaFiltro = false;
            //        setTimeout(function () {
            //            doSearch();
            //            activaFiltro = true;
            //        }, 1500);
            //    }
            //});

        });

        $(document).ready(function () {
            $('#tableToOrder').DataTable({
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
                }
            });
        });
         $(document).ready(function () {
             $('#tableToOrder').DataTable();
         });

        function showFiltros() {
            document.getElementById("collapseOne").classList.add("show");
        }
    </script>
    <%--<label class="h1">Partidas abiertas</label>--%>
    
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="col-md-12 col-lg-12">
        <div class="card">
            <div class="card-body">
                <h4 class="card-title"></h4>
                <div id="accordion">
                    <div class="card1 mb-3">
                        <div class="card-header1 mb-2" id="headingOne">
                            <h5 class="mb-0">
                                <a class="btn-link" data-toggle="collapse" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne">[ - ] Filtros</a>
                            </h5>
                        </div>

                        <div id="collapseOne" class="collapse" aria-labelledby="headingOne" data-parent="#accordion">
                            <div style="background-color: rgba(0,0,0,.03);">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="form-group col-md-4 col-lg-2">
                                            <label>Fecha inicio</label>
                                            <asp:TextBox ID="datepicker" runat="server" class="txtValidar form-control"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-4 col-lg-2">
                                            <label>Fecha inicio</label>
                                            <asp:TextBox ID="datepicker2" runat="server" class="txtValidar form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                <asp:Button ID="btnActualizaX" runat="server" Text="Buscar" CssClass="btn btn-success" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
<%--                <br />
                <br />--%>
                <div class="row">
                <div class="col-sm-12">
                    <div class="table-responsive1">
                        <asp:Label ID="lblTabla" runat="server"></asp:Label>
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
<%--     <table class="tblComp">
        <tr>
            <td>
                Fecha inicio:<asp:TextBox ID="datepicker" runat="server"></asp:TextBox>
            </td>
            <td>
                Fecha Fin:<asp:TextBox ID="datepicker2" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnActualizaX" runat="server" Text="" CssClass="btn btn-success" OnClick="Button1_Click" />
                
            </td>
        </tr>
    </table>--%>

<%--    <table class="filtro">
        <tr>
            <td>Filtrar...</td>
            <td><input id="searchTerm" type="text"/></td>
        </tr>
    </table>--%>
    
<%--				    <div class="table-responsive">
    <asp:Label ID="lblTabla" runat="server"></asp:Label>
                        </div>--%>

    <asp:Button ID="btnActualiza" runat="server" Text="" CssClass=".ico-actualizar" />

    <asp:HiddenField ID="hidCerrarSesion" runat="server" />
    <asp:HiddenField ID="hidActualiza" runat="server" />
</asp:Content>
