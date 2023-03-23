<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaestra/MtrAdministrador.Master" AutoEventWireup="true" CodeBehind="instancia.aspx.cs" Inherits="Proveedores.administrator.instancia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/Orden.css" rel="stylesheet" />

    <script src="../js/validarNotNull.js"></script>
    <script src="../js/BusquedaTabla.js"></script>
    <script src="../js/EliminarFila.js"></script>
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

            //$("table").tablesorter({ debug: true });  //DELETE SF RSG 02.2023 v2.0

            $("#opener").click(function () {
                mostrarDialog($("#ContentPlaceHolder1_lblDialog").html());  //MODIFY SF RSG 02.2023 V2.0
            });

            //$("#Div1").click(function () {       //DELETE SF RSG 02.2023 V2.0
            //    if (mostrar) {
            //        alert($("#ContentPlaceHolder1_lblDialog").text());
            //        mostrar = false;

            //    }
                
            //});

            $("#instancia").addClass("selected active");    //MODIFY SF RSG 02.2023 V2.0

            $('#ContentPlaceHolder1_btnEjecutaInstancia').click(function () {
                validar();
            });

            $('#ContentPlaceHolder1_btnEditaInstancia').click(function () {
                validar();
            });
            //mostrarDialog();                                           //DELETE SF RSG 02.2023 V2.0
            mostrarDialog($("#ContentPlaceHolder1_lblDialog").html());   //ADD SF RSG 02.2023 V2.0
            $('.nav-link').text($("#ContentPlaceHolder1_hidPantalla")[0].value);   //ADD SF RSG 02.2023 V2.0
        });

    </script>

    <asp:Label ID="lblDialog" runat="server" title="Informe" Text=""></asp:Label>

    <style>
        
        div.ui-dialog {
            min-height: 100px;
        }

        .ui-dialog .ui-dialog-title {
            color: #58ACFA;
            font-size: 14px;
        }

        .ui-dialog .ui-dialog-content {
            color: #6E6E6E;
            font-weight: bold;
            font-size: 12px;
        }
    </style>
    
    <%--//---------------------------------------------------------------------------------------------------------------------//--%>
        <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="col-md-12 col-lg-6"><div class="card">
        <div class="card-body">
            <h4 class="card-title"></h4>  
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="paraDiseno">
        <table class="tblFm2">
            <tr>
                <%--<td><strong>Llena todos los campos para dar de alta nuevas instancias de SAP</strong></td>--%>  <%--DELETE SF RSG 02.2023 V2.0--%>
                <td><strong style="font-weight: bold; font-size: 17px;">Llena todos los campos para dar de alta nuevas instancias de SAP</strong></td>  <%--ADD SF RSG 02.2023 V2.0--%>
            </tr>
        </table>
        
        <div class="form-group">
            <label for="ContentPlaceHolder1_TextBox1">Descripción</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" class="txtValidar form-control"></asp:TextBox>
        </div>
        <div class="row">
        <div class="form-group col">
            <label for="ContentPlaceHolder1_TextBox2">Usuario</label>
                    <asp:TextBox ID="txtUsuario" runat="server" class="txtValidar form-control"></asp:TextBox>
        </div>
        <div class="form-group col">
            <label for="ContentPlaceHolder1_TextBox3">Repetir usuario</label>
                    <asp:TextBox ID="txtRepiteUsuario" runat="server" class="txtValidar form-control"></asp:TextBox>
        </div>
        </div>
        <div class="row">
        <div class="form-group col">
            <label for="ContentPlaceHolder1_TextBox4">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="txtValidar form-control"></asp:TextBox>
        </div>
        <div class="form-group col">
            <label for="ContentPlaceHolder1_TextBox5">Repetir password</label>
                    <asp:TextBox ID="txtRepitePassword" runat="server" TextMode="Password" class="txtValidar form-control"></asp:TextBox>
        </div>
        </div>
        <div class="form-group">
            <label for="ContentPlaceHolder1_TextBox5">Endpoint</label>
                    <asp:TextBox ID="txtEndpoint" runat="server" class="txtValidar form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ContentPlaceHolder1_TextBox5">Mi sociedad</label>
                    <asp:TextBox ID="txtMiSociedad" runat="server" MaxLength="4" class="txtValidar form-control"></asp:TextBox>
        </div>
<%--        <table class="tblFm">
            <tr>
                <td></td>
                <td>--%>
                    <asp:Button ID="btnEjecutaInstancia" runat="server" Text="Guardar" OnClick="btnEjecutaInstancia_Click" CssClass="btn btn-primary" />    
                    <asp:Button ID="btnEditaInstancia" runat="server" Text="Guardar cambios" CssClass="btn btn-primary" OnClick="btnEditaInstancia_Click" />
                    <asp:Button ID="btnCancelEdit" runat="server" Text="Cancelar" OnClick="btnCancelEdit_Click" CssClass="btn btn-light" />
<%--                </td>
            </tr>
        </table>--%>
    </div>
    
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    </div>
    </div>
    </div>
    <%--//---------------------------------------------------------------------------------------------------------------------//--%>
        <%--//---------------------------------------------------------------------------------------------------------------------//--%>
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="col">
    <div class="col-md-12 col-lg-6" style="display:none;"><div class="card">
        <div class="card-body">
            <h4 class="card-title"></h4>  
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="paraDiseno row"> <!--MODIFY SF RSG 02.2023 V2.0-->
        <table class="tblFm2">
            <tr>
                <%--<td><strong>Llena todos los campos para dar de alta nuevas instancias de SAP</strong></td>--%>  <%--DELETE SF RSG 02.2023 V2.0--%>
                <td><strong style="font-weight: bold; font-size: 17px;">Llena todos los campos para dar de alta nuevas instancias de SAP</strong></td>  <%--ADD SF RSG 02.2023 V2.0--%>
            </tr>
        </table>

        <table class="tblFm">
            <%--<tr>
                <td>Descripción
                </td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" class="txtValidar"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Usuario
                </td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server" class="txtValidar"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Repetir usuario
                </td>
                <td>
                    <asp:TextBox ID="txtRepiteUsuario" runat="server" class="txtValidar"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="txtValidar"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Repetir password
                </td>
                <td>
                    <asp:TextBox ID="txtRepitePassword" runat="server" TextMode="Password" class="txtValidar"></asp:TextBox>
                </td>
            </tr>--%>
            
            <%--<tr>
                <td>
                    <asp:Label ID="lblTextoCambiarPass" runat="server" Text="Para poder cambiar esta instancia "></asp:Label>
                    <br />
                    <asp:Label ID="lblTextoCambiarPass2" runat="server" Text="debe introducir el password anterior:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassCambiar" runat="server" TextMode="Password" class="txtValidar"></asp:TextBox>
                </td>
            </tr>--%>
<%--            <tr>
                <td>Endpoint
                </td>
                <td>
                    <asp:TextBox ID="txtEndpoint" runat="server" class="txtValidar"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Mi sociedad
                </td>
                 <td>
                    <asp:TextBox ID="txtMiSociedad" runat="server" MaxLength="4" class="txtValidar"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnEjecutaInstancia" runat="server" Text="Guardar" OnClick="btnEjecutaInstancia_Click" CssClass="btn btn-primary" />    
                    <asp:Button ID="btnEditaInstancia" runat="server" Text="Guardar cambios" CssClass="btn btn-primary" OnClick="btnEditaInstancia_Click" />
                    <asp:Button ID="btnCancelEdit" runat="server" Text="Cancelar" OnClick="btnCancelEdit_Click" CssClass="btn btn-light" />
                </td>
            </tr>--%>
        </table>
    </div>
    
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    </div>
    </div>
    </div>
        <%--//---------------------------------------------------------------------------------------------------------------------//--%>

    <div class="card col-md-12">
        <div class="card-body">
            <h4 class="card-title"></h4>  
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
    <div id="tablaResultados">



        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
<%--        <br /><br />--%>
        <table class="tblFm2">
            <tr>
                <td><asp:Label ID="lblExplicacionInstancias" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        <%--BEGIN OF DELETE SF RSG 02.2023 V2.0--%>
<%--        <table class="tblFm">
            <tr>
              <td> <asp:Label ID="lblTablaFiltro" runat="server" Text=""></asp:Label> </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Label ID="lblTabla" runat="server" CssClass="lblTable"></asp:Label>--%>
        <%--END OF DELETE SF RSG 02.2023 V2.0--%>
<%--        <br />
        <br />
        <br />--%>
        <asp:HiddenField ID="hidVerificar" runat="server" />
        <asp:HiddenField ID="hidPantalla" runat="server" Value="Instancia" />
        <asp:HiddenField ID="hidPsAnt" runat="server" />
        <asp:HiddenField ID="hidIdAnt" runat="server" />
        <asp:HiddenField ID="hidComplementoUr" runat="server" />

        <asp:HiddenField ID="hidCerrarSesion" runat="server" />
    </div>
    <asp:Label ID="lblTabla" runat="server" CssClass="lblTable"></asp:Label><%--ADD SF RSG 02.2023 V2.0--%>
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    </div>
    </div> </div>
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
</asp:Content>
