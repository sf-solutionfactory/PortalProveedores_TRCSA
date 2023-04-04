<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaestra/MtrAdministrador.Master" AutoEventWireup="true" CodeBehind="Seguridad.aspx.cs" Inherits="Proveedores.administrator.Seguridad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/Orden.css" rel="stylesheet" />
    <script src="../js/EliminarFila.js"></script>

    <script src="../js/BusquedaTabla.js"></script>
    <script src="../js/validarNotNull.js"></script>

     <script>
         $(function () {

             var activaFiltro = true;

             $("#usuario").addClass("selected active"); /*ADD SF RSG 02.2023 V2.0*/
             $("#searchTerm").keyup(function () { //$("#searchTerm").keyup(function () {
                 if (activaFiltro) {
                     activaFiltro = false;
                     setTimeout(function () {
                         doSearch();
                         activaFiltro = true;
                     }, 1500);
                 }
             });

             $('#ContentPlaceHolder1_btnGCredInac').click(function () {
                 validar();
             });

             mostrarDialog($("#ContentPlaceHolder1_lblDialog").html());  //MODIFY SF RSG 02.2023 V2.0

             
            //$("table").tablesorter({ debug: true });  //DELETE SF RSG 02.2023 v2.0


         });

     </script>

    <asp:Label ID="lblDialog" runat="server" title="Informe" Text=""></asp:Label>
        <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="col-md-12 col-lg-6"><div class="card">
        <div class="card-body">
            <h4 class="card-title"></h4>
            <div class="form-group">
                    <label for="ContentPlaceHolder1_txtCredencial">Credencial inaceptada</label>
                    <asp:TextBox ID="txtCredencial" runat="server" CssClass="txtValidar form-control" ></asp:TextBox>
                <br />
                <asp:Button ID="btnGCredInac" runat="server" Text="Agregar" OnClick="btnGCredInac_Click" CssClass=" btn btn-primary" /> 
            </div>
        </div>
    </div>
    </div>
    <div class="col-md-12 col-lg-12"><div class="card">
        <div class="card-body">
            <h4 class="card-title"></h4>
            <div id="tablaResultados">

                <div>
                     <asp:Label ID="lblTablaFiltro" runat="server" Text=""></asp:Label>
                    <%--<br />--%>
                    <asp:Literal ID="ltlTablaCredInaceptadas" runat="server" ></asp:Literal>
                </div>
            </div>
        </div>
    </div>
    </div>
            <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
<%--    <div class="paraDiseno row"> <!--MODIFY SF RSG 02.2023 V2.0-->

        
    <table class="tblFm tblFm3">
        <tr>
            <td>
                Credencial inaceptada
            </td>
            <td>
                <asp:TextBox ID="txtCredencial" runat="server" CssClass="txtValidar"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                <asp:Button ID="btnGCredInac" runat="server" Text="Guardar" OnClick="btnGCredInac_Click" CssClass=" btn btn-primary"/> 
            </td>
        </tr>
    </table>

        </div>

    <br/><br/><br/>

     <div id="tablaResultados">

    <div>
         <asp:Label ID="lblTablaFiltro" runat="server" Text=""></asp:Label>
        <br />
        <asp:Literal ID="ltlTablaCredInaceptadas" runat="server" ></asp:Literal>
    </div>
         </div>--%>


    <asp:HiddenField ID="hidVerificar" runat="server" />
    <asp:HiddenField ID="hidPantalla" runat="server" Value="Seguridad" />

         

    <asp:HiddenField ID="hidPsAnt" runat="server" />
        <asp:HiddenField ID="hidIdAnt" runat="server" />
        <asp:HiddenField ID="hidComplementoUr" runat="server" />

    <asp:HiddenField ID="hidCerrarSesion" runat="server" />
</asp:Content>
