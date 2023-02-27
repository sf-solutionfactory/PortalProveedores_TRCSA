<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaestra/MtrAdministrador.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="Proveedores.administrator.usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/Orden.css" rel="stylesheet" />

    <script src="../js/validarNotNull.js"></script>
    <script src="../js/validarEmail.js"></script>
    <script src="../js/BusquedaTabla.js"></script>
    <script src="../js/validarCalendario.js"></script>
    <script src="../js/EliminarFila.js"></script>
    <script src="../js/AddDeleteTable.js"></script>

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

            $("table").tablesorter({ debug: true });
        });
    </script>

    <link href="../css/passSeguro/stylePassSeguro.css" rel="stylesheet" />
    <script src="../css/passSeguro/ValidaPassSeguro.js"></script>

    <div id="pswd_info">
        <h4>La contraseña debería cumplir con los siguientes requerimientos:</h4>
        <ul>
            <li id="letter">Al menos debería tener <strong><%=hidNumeroLetras.Value%> letra/s</strong></li>
            <li id="capital">Al menos debería tener <strong><%=hidNumeroLetrasM.Value%> letra/s en mayúsculas</strong></li>
            <li id="number">Al menos debería tener <strong><%=hidCantidadNumeros.Value%> número/s</strong></li>
            <li id="length">Debería tener <strong><%=hidNumeroCaracteres.Value%> caractere/s</strong> como mínimo</li>
        </ul>
    </div>

    <style>
        #ltlbtnCancel {
            width: 6em;
            max-width: 50%;
        }

        #ltlbtnCancel, #ContentPlaceHolder1_btnGuardarCambios {
            display: inline-block;
            vertical-align: top;
        }

        #ContentPlaceHolder1_cmbRol {
            height: 12px;
            min-height: 25px;
        }
    </style>
    <script>

        $(function () {

            //$("#usuario").setMenuItemFocused();
            $("#usuario").addClass("selected active"); /*MODIFY SF RSG 02.2023 V2.0*/
            $(".busquedaProveedor").click(function () {
                document.location.href = "MostrarPertenencia.aspx?vinculador=usuario&campo=Proveedor&primerproveedor=me";
                //alert(cambiarPassNext);
            });

            $('#ContentPlaceHolder1_btnGuardarCambios').click(function () {
                if (validarCalendario("#ContentPlaceHolder1_datepicker")) {
                    if (validarCalendario("#ContentPlaceHolder1_datepicker2")) {

                    }
                }
            });

            $('#ContentPlaceHolder1_btnEnviar').click(function () {
                if ($('.ckbVigencia').is(':checked')) {
                    alert('Seleccionado');
                }
                if (validar()) {
                    //var resultEmail1 = validateEmail('ContentPlaceHolder1_txtIdemailRepetir');
                    //alert(resultEmail1);
                    if (validateEmail('ContentPlaceHolder1_txtIdemailRepetir')) {
                        if (validateEmail('ContentPlaceHolder1_txtIdemail')) {
                            //if (validar()) {

                            if (validarCalendario("#ContentPlaceHolder1_datepicker")) {
                                if (validarCalendario("#ContentPlaceHolder1_datepicker2")) {

                                }
                            }
                            //}
                        }
                    }
                }

            });

            $("#<%=ckbVigenciaIlimitada.ClientID%>").on('change', function () {
                if ($(this).is(':checked')) {
                    $("#rowInicioV").hide();
                    $("#rowFinV").hide();
                    $("#<%=datepicker.ClientID%>").val("01/01/1900");
                    $("#<%=datepicker2.ClientID%>").val("12/31/2099");
                }
                else {
                    $("#rowInicioV").show();
                    $("#rowFinV").show();
                    $("#<%=datepicker.ClientID%>").val("");
                    $("#<%=datepicker2.ClientID%>").val("");
                }
            });

            if ($("#<%=ckbVigenciaIlimitada.ClientID%>").attr('checked')) {
                $("#rowInicioV").hide();
                $("#rowFinV").hide();
            } else {
                $("#rowInicioV").show();
                $("#rowFinV").show();
            }

            $(".validaMostrar").hide();
            //alert($.trim($("#ContentPlaceHolder1_lblProveedorSelected").html()) );
            //if ($.trim($("#ContentPlaceHolder1_lblProveedorSelected").html()) != "Proveedor...") {
            if ($.trim($("#ContentPlaceHolder1_lblProveedorSelected1")[0].value) != "Proveedor...") {
                $(".validaMostrar").show("slow");

            }
            else {
                //$(".validaMostrar").show("slow");
            }

            $(".focusTxt").focus(function () {
                var user1 = "";
                //user1 = $("#ContentPlaceHolder1_lblProveedorSelected").html();
                user1 = $("#ContentPlaceHolder1_lblProveedorSelected1")[0].value;
                //user2 = $("#ContentPlaceHolder1_lblRepeatProveedorSelected").html();
                if ($.trim(user1) == "Proveedor...") {
                    $("#ContentPlaceHolder1_lblProveedorSelected").css("color", "#FF0000");
                    $("#ContentPlaceHolder1_lblDialog").text("llenar proveedores");
                    mostrarDialog($("#ContentPlaceHolder1_lblDialog").html());  //MODIFY SF RSG 02.2023 V2.0
                    //alert("llenar proveedores");
                    this.blur();
                }


            });

            $('#ltlbtnCancel').click(function () {
                var v = "usuario.aspx?" + $('#ContentPlaceHolder1_hidComplementoUr').val();
                //alert(v);
                document.location.href = v;
            });

            $('#obtenerCheckbox').click(function () {
                //alert("DDDDDD");
                takeIdSelectedsCheckBox('check');
            });

            $('#ContentPlaceHolder1_btnEnviar').click(function () {
                //alert("DDDDDD");
                takeIdSelectedsCheckBox('check');
            });

            $('#ContentPlaceHolder1_btnGuardarCambios').click(function () {
                //alert("DDDDDD");
                takeIdSelectedsCheckBox('check');
            });


            mostrarDialog($("#ContentPlaceHolder1_lblDialog").html());  //MODIFY SF RSG 02.2023 V2.0

        });

    </script>

    <asp:Label ID="lblDialog" runat="server" title="Informe" Text=""></asp:Label>


    <%--<div id="opener" class="btn">Open Dialog</div>--%>

    <%--<div class="menuHelper">
                    <img src="../images/ico-ayuda.png" />
                    <img src="../images/ico-descargar.png" />
                    <img src="../images/ico-imprimir.png" />
    </div>--%>

    <%--<a href="Seguridad.aspx">Seguridad</a>--%>
    
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
<div class="col-md-12 col-lg-12"><div class="card">
        <div class="card-body">
            <h4 class="card-title"></h4>  
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="paraDiseno"> <!--MODIFY SF RSG 02.2023 V2.0-->
        
        <table class="tblFm2">
            <tr>
                <td><strong style="font-weight: bold; font-size: 17px;">Llena todos los campos para dar de alta nuevos usuarios </strong></td>  <%--MODIFY SF RSG 02.2023 V2.0--%>
            </tr>
        </table>

        <div class="row">
            <div class="form-group col-md-4">
                <label for="ContentPlaceHolder1_txtNombreRol">Proveedor</label>
                <asp:TextBox ID="lblProveedorSelected1" runat="server" class="txtValidar form-control" Text="Proveedor..." ReadOnly></asp:TextBox>
                <asp:Label ID="lblProveedorSelected" CssClass="silverColor" runat="server" Text="Proveedor..." Width="310px" Visible="false"></asp:Label> <%--MODIFY SF RSG 02.2023 V2.0--%>
            </div>
            <div class="busquedaProveedor link btn btn-light" style="height: 30px;margin-top: 24px;">Busqueda...</div>  <%--MODIFY SF RSG 02.2023 V2.0--%>
        </div>
<%--        <br />
        <br />--%>
        <%--<table class="tblFm">
            <tr>
                <td>Proveedor
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblProveedorSelected" CssClass="silverColor" runat="server" Text="Proveedor..." Width="310px"></asp:Label></td> 
                            <td><strong class="busquedaProveedor link btn btn-light">Busqueda...</strong></td> 
                        </tr>
                    </table>
                </td>
            </tr>
        </table>--%>

        <div class="validaMostrar">
            <div class="row">
                <div class="form-group col-md-6">
                    <label for="ContentPlaceHolder1_txtIdUsuario">Usuario</label>
                    <asp:TextBox ID="txtIdUsuario" runat="server" CssClass="txtbox focusTxt txtValidar form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-md-3">
                    <label for="ContentPlaceHolder1_txtIdNombre">Nombre</label>
                    <asp:TextBox ID="txtIdNombre" runat="server" CssClass="focusTxt txtValidar form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="ContentPlaceHolder1_txtIdApellidos">Apellidos</label>
                    <asp:TextBox ID="txtIdApellidos" runat="server" CssClass="focusTxt txtValidar form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-md-3">
                    <label for="ContentPlaceHolder1_txtIdNombre">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="txtbox focusTxt txtValidar form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="ContentPlaceHolder1_txtIdApellidos">Repetir password</label>
                    <asp:TextBox ID="txtPasswordRepetir" runat="server" CssClass="txtbox focusTxt txtValidar form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group col-md-6">
                    <div class="col-sm-9" style="margin-top: 32px;">
                        <asp:CheckBox ID="ckbCambiarPassNext" Text="Cambiar password" runat="server" name="ckbCambiarPassNext" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-md-3" id="rowInicioV">
                    <label for="ContentPlaceHolder1_txtIdNombre">Inicio vigencia</label>
                        <asp:TextBox ID="datepicker" runat="server" class="txtValidar form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3" id="rowFinV">
                    <label for="ContentPlaceHolder1_txtIdApellidos">Fin vigencia</label>
                        <asp:TextBox ID="datepicker2" runat="server" class="txtValidar form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-6">
                    <div class="col-sm-9" style="margin-top: 32px;">
                        <asp:CheckBox ID="ckbVigenciaIlimitada" Text="Vigencia permanente" runat="server" CssClass="ckbVigenciaI" />
                    </div>
                </div>
            </div>

            <table class="tblFm">
                <%-- <tr>
            <td>Proveedor
            </td>
            <td>
                <table>
                    <tr><td><asp:Label ID="lblProveedorSelected" CssClass="silverColor" runat="server" Text="Proveedor..."></asp:Label></td><td><strong class="busquedaProveedor link">Busqueda...</strong></td></tr> 
                </table>
            </td>
        </tr>--%>
                <%--<tr>
                    <td>Usuario</td>
                    <td>
                        <asp:TextBox ID="txtIdUsuario" runat="server" CssClass="txtbox focusTxt txtValidar"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Nombre</td>
                    <td>
                        <asp:TextBox ID="txtIdNombre" runat="server" CssClass="focusTxt txtValidar"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Apellidos</td>
                    <td>
                        <asp:TextBox ID="txtIdApellidos" runat="server" CssClass="focusTxt txtValidar"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="txtbox focusTxt txtValidar" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Repetir password</td>
                    <td>
                        <asp:TextBox ID="txtPasswordRepetir" runat="server" CssClass="txtbox focusTxt txtValidar" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>               
                <tr>
                    <td>Cambiar password</td>
                    <td>
                        <asp:CheckBox ID="ckbCambiarPassNext" runat="server" />
                    </td>
                </tr> 
                <tr id="rowInicioV">
                    <td>Inicio vigencia</td>
                    <td>
                        <asp:TextBox ID="datepicker" runat="server" class="txtValidar"></asp:TextBox>
                    </td>
                </tr>
                <tr id="rowFinV">
                    <td>Fin vigencia</td>
                    <td>
                        <asp:TextBox ID="datepicker2" runat="server" class="txtValidar"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Vigencia permanente</td>
                    <td>
                        <asp:CheckBox ID="ckbVigenciaIlimitada" runat="server" CssClass="ckbVigenciaI" />
                    </td>
                </tr>--%>

                <%--<tr>
            <td>Clase usuario</td>
            <td>
                <asp:DropDownList ID="cmbClaseUsuario" runat="server" class="focusTxt txtValidar"></asp:DropDownList>
            </td>
        </tr>--%>
            </table>


            <div class="row">
                <div class="form-group col-md-3">
                    <label for="ContentPlaceHolder1_txtIdNombre">Email</label>
                    <asp:TextBox ID="txtIdemail" runat="server" class="focusTxt txtValidar form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="ContentPlaceHolder1_txtIdApellidos">Repetir email</label>
                    <asp:TextBox ID="txtIdemailRepetir" runat="server" class="focusTxt txtValidar form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-md-6">
                    <label for="ContentPlaceHolder1_txtIdApellidos">Rol a asignar</label>
                    <asp:DropDownList ID="cmbRol" runat="server" CssClass="txtValidar form-control" AutoPostBack="false"></asp:DropDownList>
                </div>
            </div>
            <strong style="font-weight: bold; font-size: 17px;">Sociedades </strong>
                        <asp:Panel ID="pnlSociedades" runat="server"></asp:Panel>
                        <%--<asp:Button ID="btnAdminSoc" runat="server" Text="Administrar sociedades ..." CssClass="btn btn-primary" OnClick="btnAdminSoc_Click" />--%><%--MODIFY SF RSG 02.2023 V2.0--%>
                        <asp:Literal ID="ltlTablaSociedades" runat="server"></asp:Literal>
            
                        <asp:Button ID="btnEnviar" runat="server" Text="Guardar" OnClick="btnEnviar_Click" CssClass="btn btn-primary" />    <%--MODIFY SF RSG 02.2023 V2.0--%>
                        <asp:Button ID="btnGuardarCambios" runat="server" Text="Guardar cambios" OnClick="btnGuardarCambios_Click" CssClass="btn btn-secondary" />    <%--MODIFY SF RSG 02.2023 V2.0--%>
                        <%--<asp:Button ID="btnCancel" runat="server" Text="Cancelar" />--%>
                        <asp:Literal ID="ltlbtnCancel" runat="server" Text="<div id='ltlbtnCancel' class='btn btn-light'>Cancelar</div>"></asp:Literal>   <%--MODIFY SF RSG 02.2023 V2.0--%>
                        <asp:Button ID="btnAdminSoc" runat="server" Text="Administrar sociedades ..." CssClass="btn btn-primary" OnClick="btnAdminSoc_Click" /><%--MODIFY SF RSG 02.2023 V2.0--%>
            <table class="tblFm">
                <%--<tr>
            <td>Tipo usuario</td>
            <td>
                <asp:DropDownList ID="cmbTipoUsuario" runat="server" class="focusTxt txtValidar"></asp:DropDownList></td>
        </tr>--%>

                <%-- <tr>
            <td>Creado por</td>
            <td>
                <asp:Label ID="lblCreadoPor" runat="server" Text=""></asp:Label></td>
        </tr>--%>
               <%-- <tr>
                    <td>Email
                    </td>
                    <td>
                        <asp:TextBox ID="txtIdemail" runat="server" class="focusTxt txtValidar"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Repetir email</td>
                    <td>
                        <asp:TextBox ID="txtIdemailRepetir" runat="server" class="focusTxt txtValidar"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Rol a asignar</td>
                    <td>
                        <asp:DropDownList ID="cmbRol" runat="server" CssClass="txtValidar" AutoPostBack="false"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Sociedades</td>
                    <td>
                        <asp:Panel ID="pnlSociedades" runat="server"></asp:Panel>
                        <asp:Button ID="btnAdminSoc" runat="server" Text="Administrar sociedades ..." CssClass="btn btn-primary" OnClick="btnAdminSoc_Click" />
                        <br /><br />
                        <asp:Literal ID="ltlTablaSociedades" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnEnviar" runat="server" Text="Guardar" OnClick="btnEnviar_Click" CssClass="btn btn-primary" />    
                        <asp:Button ID="btnGuardarCambios" runat="server" Text="Guardar cambios" OnClick="btnGuardarCambios_Click" CssClass="btn btn-secondary" />    
                        <%--<asp:Button ID="btnCancel" runat="server" Text="Cancelar" />
                        <asp:Literal ID="ltlbtnCancel" runat="server" Text="<div id='ltlbtnCancel' class='btn btn-light'>Cancelar</div>"></asp:Literal>   
                        <%--<div id="btnCancelZ">cancelar</div>
                    </td>
                </tr>--%>
            </table>



        </div>

    </div>
    
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    </div>
    </div>
    </div>
<div class="col-md-12 col-lg-12"><div class="card">
        <div class="card-body">
            <h4 class="card-title"></h4>  
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
    <%--<div id="obtenerCheckbox">chechbox</div>--%>

    <div class="validaMostrar">
        <%--<div class ="resUsuariosTabla">--%>
        <%--<br />--%>



        <%--<div id="contenidoPost"></div>--%>
<%--        <br />
        <br />--%>
        <asp:Label ID="lblExplicacionResultados" runat="server" Text=""></asp:Label>
<%--        <br />
        <br />--%>
        <asp:Label ID="lblTablaFiltro" runat="server" Text=""></asp:Label>

        <br />
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="lblTablaUsuarios" runat="server" Text=""></asp:Label>


        <br />
        <asp:HiddenField ID="hidProveedor" runat="server" />

        <asp:HiddenField ID="hidVerificar" runat="server" />
        <asp:HiddenField ID="hidVerificarPass" runat="server" />
        <asp:HiddenField ID="hidPantalla" runat="server" Value="usuario" />
        <asp:HiddenField ID="hidComplementoUr" runat="server" />
        <asp:HiddenField ID="hidId" runat="server" />
        <asp:HiddenField ID="hidValCheck" runat="server" />
        <asp:HiddenField ID="hidNumeroLetras" runat="server" />
        <asp:HiddenField ID="hidNumeroLetrasM" runat="server" />
        <asp:HiddenField ID="hidCantidadNumeros" runat="server" />
        <asp:HiddenField ID="hidNumeroCaracteres" runat="server" />
        <asp:HiddenField ID="hidCerrarSesion" runat="server" />

        <%--</div>--%>
    </div>
            
    </div>
    </div>
    </div>

</asp:Content>
