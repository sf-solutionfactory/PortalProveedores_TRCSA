<%@ Page Language="C#" MasterPageFile="~/pagMaestra/MtrProveedor.Master" AutoEventWireup="true" CodeBehind="estadoCuenta.aspx.cs" Inherits="Proveedores.portal.estadoCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script src="../js/BusquedaTabla.js"></script>

    
<%--    <style>.table th { font-weight:bolder;}  </style>--%>
    <script>
        $(function () {

            var activaFiltro = true;
            
            $("#estado").addClass("selected active");

            $(".ico-actualizar").click(function () {
                //alert("in")
                $("#ContentPlaceHolder1_hidActualiza").val("actualiza");
                //document.location.href = "facturas.aspx";
            });

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
                                        <asp:RadioButtonList ID="rdbTipo" runat="server" Style="margin-left:2rem">
                                            <asp:ListItem Selected="True">Partidas abiertas</asp:ListItem>
                                            <asp:ListItem>Todas las partidas</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
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

                <div class="row">
                <div class="col-sm-12" style="overflow-x:auto;">
                    <div class="table-responsive1">
                        <asp:Label ID="lblTabla" runat="server"></asp:Label>
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="col">
        <div class="row">
<%--            <div class="col-md-6 col-lg-8" style="display:none;">
                <div class="card">
                    <div class="card-body"></div>
                </div>
            </div>--%>
            <div class="col-md-6 col-lg-4  ml-auto">
                <div class="card">
                    <div class="card-body">
                        <h4 class="card-title" style="font-size: 2.1rem;">Total</h4>

                        <div class="form-group col-md-12">
                            <%--<label>Importe</label>--%>
                            <asp:TextBox ID="txtTotal" runat="server" class="txtValidar form-control" Enabled="false" Width="100%" Style="text-align: right; font-size: 2rem;"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <asp:Button ID="btnActualiza" runat="server" Text="" CssClass=".ico-actualizar" Visible="false"/>

    <asp:HiddenField ID="hidCerrarSesion" runat="server" />
    <asp:HiddenField ID="hidActualiza" runat="server" />
</asp:Content>
