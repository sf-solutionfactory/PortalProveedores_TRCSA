<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaestra/MtrInicio.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proveedores.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<link href="css/passSeguro/stylePassSeguro.css" rel="stylesheet" />--%> <%--DELETE SF RSG 02.2023 v2.0--%>
    <%--BEGIN OF INSERT SF RSG 02.2023 v2.0--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <link href="css/passSeguro/style.css" rel="stylesheet" />
    <script src="css/passSeguro/ValidaPassSeguro.js"></script>
    <%--END OF INSERT SF RSG 02.2023 v2.0--%>
    <style>
        .lblError {
            color: red;
        }

        /*.btn {
            color: #C82B40;
        }*/
    </style>
    
    <%--BEGIN OF DELETE SF RSG 02.2023 v2.0--%>
<%--    <div id="pswd_info">
        <h4>La contraseña debe cumplir con los siguientes requerimientos:</h4>
        <ul>
            <li id="letter">Al menos debe tener <strong><%=hidNumeroLetras.Value%> letra/s</strong></li>
            <li id="capital">Al menos debe tener <strong><%=hidNumeroLetrasM.Value%> letra/s en mayúsculas</strong></li>
            <li id="number">Al menos debe tener <strong><%=hidCantidadNumeros.Value%> número/s</strong></li>
            <li id="length">Debe tener <strong><%=hidNumeroCaracteres.Value%> caractere/s</strong> como mínimo</li>
        </ul>
    </div>

    <center>

        <div class="login">
            <div class="divImg">
                <img src="images/candadoCerrado.png" />
            </div>
            <asp:Label ID="lblPortalProveedores" CssClass="titleText" runat="server" Text="Portal de Proveedores"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblDescripUsuario" runat="server" Text="Usuario"></asp:Label>
            <br />
            <asp:TextBox ID="txtUsuario" CssClass="txt" runat="server" MaxLength="50"></asp:TextBox>
            <asp:TextBox ID="txtrepitContra" CssClass="txt modepass" runat="server" Height="22px" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="lblDescContrasena" runat="server" Text="Contraseña"></asp:Label>
            <br />
            <asp:TextBox ID="txtContrasena" CssClass="txt modepass" runat="server" Height="22px" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="lblError" CssClass="lblError" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnAcceder" CssClass="btn" runat="server" OnClick="btnAcceder_Click" Text="Acceder" />
        </div>
    </center>--%>
    <%--END OF DELETE SF RSG 02.2023 v2.0--%>
    
    <%--BEGIN OF INSERT SF RSG 02.2023 v2.0--%>
    <center>
        
        <div class="wrapper fadeInDown">
            <div id="formContent">
                <div class="fadeIn first">
                    <div class="divImg">
                        <img src="images/candadov2.png" id="icon" alt="User Icon" />
                    </div>
	            </div>
                <formview >
                    <asp:Label ID="lblPortalProveedores" CssClass="titleText" runat="server" Text="Portal de Proveedores"></asp:Label>
                    <br />
                    <asp:Label ID="lblDescripUsuario" CssClass="" runat="server" Text="Usuario"></asp:Label>
                    <asp:TextBox ID="txtUsuario" CssClass="fadeIn second" runat="server" MaxLength="50" placeholder="Usuario"></asp:TextBox>
                    <asp:TextBox ID="txtrepitContra" CssClass="txt modepass" runat="server" Height="22px" TextMode="Password"></asp:TextBox>
                     <asp:Label ID="lblDescContrasena" runat="server" Text="Contraseña"></asp:Label>
                    <asp:TextBox ID="txtContrasena" CssClass="fadeIn third" runat="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblError" CssClass="lblError" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Button ID="btnAcceder" CssClass="fadeIn fourth" runat="server" OnClick="btnAcceder_Click" autopostback="false" Text="Acceder" />
                </formview>
            </div>
        </div>
        <div style="margin-top:45px;">
            <img src="images/logo_tracusa.bmp" class="imglogo" style="max-height:200px;"/>
        </div>
    </center>
    <div id="pswd_info" class="">
       <h4>La contraseña debe cumplir con los siguientes requerimientos:</h4>
       <ul>
          <li id="letter">Al menos debe tener <strong><%=hidNumeroLetras.Value%> letra/s</strong></li>
          <li id="capital">Al menos debe tener <strong><%=hidNumeroLetrasM.Value%> letra/s en mayúsculas</strong></li>
          <li id="number">Al menos debe tener <strong><%=hidCantidadNumeros.Value%> número/s</strong></li>
          <li id="length">Debe tener <strong><%=hidNumeroCaracteres.Value%> caractere/s</strong> como mínimo</li>
       </ul>
    </div>
    <%--BEGIN OF INSERT SF RSG 02.2023 v2.0--%>

    <asp:HiddenField ID="hidVerificar" runat="server" />
    <asp:HiddenField ID="hidNumeroLetras" runat="server" />
    <asp:HiddenField ID="hidNumeroLetrasM" runat="server" />
    <asp:HiddenField ID="hidCantidadNumeros" runat="server" />
    <asp:HiddenField ID="hidNumeroCaracteres" runat="server" />
    <asp:HiddenField ID="hidVerificarPass" runat="server" />

</asp:Content>
