<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaestra/MtrAdministrador.Master" AutoEventWireup="true" CodeBehind="config.aspx.cs" Inherits="Proveedores.administrator.config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">        
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
<div class="col-md-12 col-lg-6">
<div class="col-md-12 col-lg-12"><div class="card">
    <div class="card-body"> 
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
    <asp:Panel ID="Panel1" runat="server" GroupingText="Configuración global">
        <%--<script src="../js/validarNotNull.js"></script>--%>
        <link href="../css/Orden.css" rel="stylesheet" />
        <script src="../js/validarEmail.js"></script>
        <script>
            $(function () {
                $("#config").addClass("selected active");

                $('#ContentPlaceHolder1_btnEnviarConfig').click(function () {
                    var resultEmail1 = false;

                    if ($('#ContentPlaceHolder1_hidTipoCorreo').val() == "configurado") {

                        if ($('#ContentPlaceHolder1_txtEmail').val() != null
                            && $('#ContentPlaceHolder1_txtEmail').val() != ""
                            ) {
                            resultEmail1 = validateEmail('ContentPlaceHolder1_txtCorreoServidorCorreo');
                        }
                        else {
                            resultEmail1 = true;
                        }
                    
                        if (resultEmail1) {
                            validar();
                        }
                    }
                });

                $('#ContentPlaceHolder1_lblVernterior').click(function () {
                    document.location.href = "config.aspx?dir=verAnt&btn=ant";

                });

                if ($('#ContentPlaceHolder1_hidTipoCorreo').val() == "configurado") {
                    $('#divConfigEspecialCorreo').show();
                    $('.tablaEmailNormal').hide();
                    $('#ContentPlaceHolder1_hidTipoCorreo').val("configurado");
                }
                else {
                    $('#divConfigEspecialCorreo').hide();
                    $('.tablaEmailNormal').show();
                    $('#ContentPlaceHolder1_hidTipoCorreo').val("normal");
                }

                //$('#divConfigEspecialCorreo').hide();

                $('.btnConfigCorreo').click(function () {
                    mostrarCorreoEspecial();
                });

                $('.btnCancel').click(function () {
                    ocultarCorreoEspecial();
                });

                $('#ContentPlaceHolder1_btnEnviarConfig').click(function () {
                    revalidaNumeros();
                });

                

                //mostrarDialog();  /*ADD SF RSG 02.2023 V2.0*/
                $('.nav-link').text($("#ContentPlaceHolder1_hidPantalla")[0].value);   //ADD SF RSG 02.2023 V2.0

            });

            

            function ocultarCorreoEspecial() {
                $('#divConfigEspecialCorreo').hide("slow");
                $('.tablaEmailNormal').show("slow");
                $('#ContentPlaceHolder1_hidTipoCorreo').val("normal");
            }

            function mostrarCorreoEspecial() {
                $('#divConfigEspecialCorreo').show("slow");
                $('.tablaEmailNormal').hide("slow");
                $('#ContentPlaceHolder1_hidTipoCorreo').val("configurado");
            }

            


        </script>

        <style>
            #ContentPlaceHolder1_lblVernterior {
                min-width:100px;
            }

            .btnConfigCorreo, .btnCancel {
                width: 160px;
            }

            #ContentPlaceHolder1_dpdTipoCuenta,
             #ContentPlaceHolder1_dpdSufijoEmail,
            #ContentPlaceHolder1_dpdBloqSociedad
             {
                min-height: 15px;
            }

            #divConfigEspecialCorreo {
                border:dashed;
            }

/*            #ContentPlaceHolder1_dpdSufijoEmail, #ContentPlaceHolder1_txtEmail {
                min-width: 150px;
                width:150px;
            }*/
            


        </style>

        <asp:Label ID="lblDialog" runat="server" title="Informe" Text=""></asp:Label>

        <%--<div class="paraDiseno row"> <!--MODIFY SF RSG 02.2023 V2.0-->--%>
        <fieldset class="form-group">
            <div class="row">
                <legend class="col-form-label col-sm-3 pt-0">Estatus del portal</legend>
                <asp:RadioButtonList ID="rdbPortal" runat="server" style="margin-left:5%;">
                    <asp:ListItem Selected="True">Activado</asp:ListItem>
                    <asp:ListItem>Desactivado</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </fieldset>
        <div class="form-group">
            <label for="ContentPlaceHolder1_txtUmbral">Umbral de usuarios por proveedor</label>
            <asp:TextBox ID="txtUmbral" runat="server" onkeypress="return soloNumeros2(event)" CssClass="soloNumeros2 form-control" value="5" MaxLength="2"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ContentPlaceHolder1_dpdBloqSociedad">Bloqueo de sociedad</label>
            <asp:DropDownList ID="dpdBloqSociedad" runat="server" CssClass="form-control">
                <asp:ListItem>1 = N</asp:ListItem>
                <asp:ListItem>1 = 1</asp:ListItem>
            </asp:DropDownList>
        </div>
        <%--    <table class="tblFm tblFm3">
                <tr>
                    <td>Estatus del portal
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbdEsactivo" runat="server">
                            <asp:ListItem>Activado</asp:ListItem>
                            <asp:ListItem>Desactivado</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>Umbral de usuarios por proveedor
                    </td>
                    <td>
                        <asp:TextBox ID="txtUmbral" runat="server" onkeypress="return soloNumeros2(event)" CssClass="soloNumeros2" value="5" MaxLength="2"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>Bloqueo de sociedad</td>
                    <td>
                        <asp:DropDownList ID="dpdBloqSociedad" runat="server">
                            <asp:ListItem>1 = N</asp:ListItem>
                            <asp:ListItem>1 = 1</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
               
            </table>--%>
        <%--</div>--%>
    </asp:Panel>
    <%--<br />--%>    
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    </div>
    </div>
    </div>
    <div class="col-md-12 col-lg-12"><div class="card">
            <div class="card-body">
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
    <asp:Panel ID="Panel2" runat="server" GroupingText="Correo">
        <%--<div class="paraDiseno row"> <!--MODIFY SF RSG 02.2023 V2.0-->--%>
        <div class="tblFm tblFm3 tablaEmailNormal">
            <div class="row">
                <div class="col">
                    <label for="ContentPlaceHolder1_txtEmail">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" class="txtValidar form-control"></asp:TextBox>
                </div>
                <div class="col">
                    <label for="ContentPlaceHolder1_dpdSufijoEmail" style="color: transparent">Sufijo</label>
                    <asp:DropDownList ID="dpdSufijoEmail" runat="server" CssClass="form-control">
                        <asp:ListItem>@gmail.com</asp:ListItem>
                        <asp:ListItem>@yahoo.com</asp:ListItem>
                        <asp:ListItem>@hotmail.com</asp:ListItem>
                        <asp:ListItem>@outlook.com</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col">
                    <label for="ContentPlaceHolder1_txtPassword">Contraseña</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="txtValidar form-control"></asp:TextBox>
                </div>
                <div class="col">
                    <label for="ContentPlaceHolder1_txtPassword">Confirmar contraseña</label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" class="txtValidar form-control"></asp:TextBox>
                </div>
            </div>
            <br />
                    <div class="btn btn-success btnConfigCorreo">Configuración especial...</div>
        </div>
        <div class="card">
        <div id="divConfigEspecialCorreo" class="tblFm tblFm3 card-body">
            <div class="row">
                <div class="col form-group">
                    <label for="ContentPlaceHolder1_txtSMTP">SMTP</label>
                    <asp:TextBox ID="txtSMTP" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col form-group">
                    <label for="ContentPlaceHolder1_txtPuerto">Puerto</label>
                    <asp:TextBox ID="txtPuerto" runat="server" class="soloNumeros2 form-control" onkeypress="return soloNumeros2(event)"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <%--<label for="ContentPlaceHolder1_txtPuerto">SSL</label>--%>
                <asp:CheckBox ID="chkSSL" runat="server" Text="SSL" CssClass="" />
            </div>
            <%--<strong>Información de inicio de sesión</strong>--%>
            <div class="form-group">
                <label for="ContentPlaceHolder1_txtCorreoServidorCorreo">Correo</label>
                <asp:TextBox ID="txtCorreoServidorCorreo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="row">
                <div class="col form-group">
                    <label for="ContentPlaceHolder1_txtContraServidorCorreoo">Contraseña</label>
                    <asp:TextBox ID="txtContraServidorCorreo" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col form-group">
                    <label for="ContentPlaceHolder1_txtRepiteContraServidorCorreo">Repite contraseña</label>
                    <asp:TextBox ID="txtRepiteContraServidorCorreo" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="btn btn-light btnCancel">
                Cancelar
            </div>
        </div>
        </div>
                <div class="form-group">
                    <label for="ContentPlaceHolder1_txtAsunto">Asunto</label>
                    <asp:TextBox ID="txtAsunto" runat="server" class="txtValidar form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="ContentPlaceHolder1_txtAreaContenido">Contenido</label>
                    <asp:TextBox ID="txtAreaContenido" runat="server" Columns="50" Rows="5" TextMode="multiline" class="txtValidar form-control" />
                </div>
                <%--<table class="tblFm tblFm3 tablaEmailNormal" >
            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" class="txtValidar form-control"></asp:TextBox>
                    <asp:DropDownList ID="dpdSufijoEmail" runat="server" CssClass="form-control">
                        <asp:ListItem>@gmail.com</asp:ListItem>
                        <asp:ListItem>@yahoo.com</asp:ListItem>
                        <asp:ListItem>@hotmail.com</asp:ListItem>
                        <asp:ListItem>@outlook.com</asp:ListItem>
                    </asp:DropDownList>
                   </td>
            </tr>
            <tr>
                <td>Contraseña
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="txtValidar form-control"></asp:TextBox>
                    <br />

                </td>
            </tr>>
            <tr>
                <td>Confirmar contraseña
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" class="txtValidar form-control"></asp:TextBox>
                    </td>
            </tr>--%
            <tr>
                <td>
                </td>
                <td>
                    <%--<div class="btn btnConfigCorreo">Configuración especial...</div>--%>
<%--                </td>
            </tr>
        </table>--%>
          <%--<table id="divConfigEspecialCorreo1" class="tblFm tblFm3">
                <tr>
                    <td><strong>Tipo de servidor</strong></td>
                    <td></td>
                </tr>
                <tr>
                    <td>SMTP</td>
                    <td>
                        <asp:TextBox ID="txtSMTP" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Puerto</td>
                    <td>
                        <asp:TextBox ID="txtPuerto" runat="server" class="soloNumeros2 form-control" onkeypress="return soloNumeros2(event)" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>SSL</td>
                    <td>
                        <asp:CheckBox ID="chkSSL" runat="server" Text="SSL" CssClass="" />
                    </td>
                </tr>
                <tr>
                    <td><strong>Información de inicio de sesión</strong></td>
                    <td></td>
                </tr>
                <tr>
                    <td>Correo</td>
                    <td>
                        <asp:TextBox ID="txtCorreoServidorCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Contraseña</td>
                    <td>
                        <asp:TextBox ID="txtContraServidorCorreo" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
              <tr>
                    <td>Repite contraseña</td>
                    <td>
                        <asp:TextBox ID="txtRepiteContraServidorCorreo" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>--%>
                        
                        
                        <%--<div class="btn btnCancel">--%>
                        <%-- <div class="btn btn-light btnCancel">
                            Cancelar
                        </div>
                   </td>
                </tr>
         </table>--%>
    <%--<table class="tblFm tblFm3">
            <tr>
                <td>Asunto</td>
                <td>
                    <asp:TextBox ID="txtAsunto" runat="server" class="txtValidar form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Contenido</td>
                <td>
                    <asp:TextBox ID="txtAreaContenido" runat="server" Columns="50" Rows="5" TextMode="multiline" class="txtValidar form-control" />
                </td>
            </tr>
        </table>--%>
    <%--</div>--%>
    </asp:Panel>
    <%--<br />--%>
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    </div>
    </div>
    </div>
    </div>
    <div class="col-md-12 col-lg-6">
    <div class="col-md-12 col-lg-12"><div class="card">
        <div class="card-body"> 
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
    <asp:Panel ID="Panel3" runat="server" GroupingText="Seguridad">
        <%--<div class="paraDiseno row"> <!--MODIFY SF RSG 02.2023 V2.0-->--%>
        <div class="form-group">
            <label for="ContentPlaceHolder1_txtAreaContenido">Nº passwords por recordar</label>
            <asp:TextBox ID="txtNumPassRec" runat="server" onkeypress="return soloNumeros2(event)" value="3" class="txtValidar soloNumeros2 form-control" MaxLength="2"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ContentPlaceHolder1_txtAreaContenido">Máximo de intentos</label>
                    <asp:TextBox ID="txtMaxIntentos" runat="server" onkeypress="return soloNumeros2(event)" value="3" class="txtValidar soloNumeros2 form-control" MaxLength="2"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ContentPlaceHolder1_txtAreaContenido">Intervalo de tiempo para bloqueo(m)</label>
                    <asp:TextBox ID="txtIntervalo" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="2" onkeypress="return soloNumeros2(event)"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ContentPlaceHolder1_txtAreaContenido">Caducidad de password(d)</label>
                    <asp:TextBox ID="txtCaducidadPass" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="3" onkeypress="return soloNumeros2(event)"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ContentPlaceHolder1_txtAreaContenido">Tiempo de bloqueo de Administrador(m)</label>
                    <asp:TextBox ID="txtTiempoBloqAdmin" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="4" onkeypress="return soloNumeros2(event)"></asp:TextBox>
        </div>
        <%--<table class="tblFm tblFm3">
            <tr>
                <td>Nº passwords por recordar</td>
                <td>
                    <asp:TextBox ID="txtNumPassRec" runat="server" onkeypress="return soloNumeros2(event)" value="3" class="txtValidar soloNumeros2 form-control" MaxLength="2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Máximo de intentos</td>
                <td>
                    <asp:TextBox ID="txtMaxIntentos" runat="server" onkeypress="return soloNumeros2(event)" value="3" class="txtValidar soloNumeros2 form-control" MaxLength="2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Intervalo de tiempo para bloqueo(m)</td>
                <td>
                    <asp:TextBox ID="txtIntervalo" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="2" onkeypress="return soloNumeros2(event)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Caducidad de password(d)</td>
                <td>
                    <asp:TextBox ID="txtCaducidadPass" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="3" onkeypress="return soloNumeros2(event)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Tiempo de bloqueo de Administrador(m)</td>
                <td>
                    <asp:TextBox ID="txtTiempoBloqAdmin" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="4" onkeypress="return soloNumeros2(event)"></asp:TextBox>
                </td>
            </tr>
        </table>--%>
    </asp:Panel>
    
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    </div>
    </div>
    </div>
    <div class="col-md-12 col-lg-12"><div class="card">
        <div class="card-body">  
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
    <asp:Panel ID="Panel6" runat="server" GroupingText="Contenido Password">
        <div class="form-group">
            <label for="ContentPlaceHolder1_txtAreaContenido">Numero de letras</label>
            <asp:TextBox ID="txtNumeroLetras" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="3" onkeypress="return soloNumeros2(event)"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ContentPlaceHolder1_txtAreaContenido">Numero de letras en Mayuscúla</label>
            <asp:TextBox ID="txtNumeroLetrasM" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="3" onkeypress="return soloNumeros2(event)"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ContentPlaceHolder1_txtAreaContenido">Cantidad de números</label>
            <asp:TextBox ID="txtCantidadNumeros" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="3" onkeypress="return soloNumeros2(event)"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ContentPlaceHolder1_txtAreaContenido">Numero de caracteres</label>
            <asp:TextBox ID="txtNumeroCaracteres" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="3" onkeypress="return soloNumeros2(event)"></asp:TextBox>
        </div>
        <%-- <table class="tblFm tblFm3">
           <tr>
                <td>Numero de letras</td>
                <td>
                    <asp:TextBox ID="txtNumeroLetras" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="3"  onkeypress="return soloNumeros2(event)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Numero de letras en Mayuscúla</td>
                <td>
                    <asp:TextBox ID="txtNumeroLetrasM" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="3"  onkeypress="return soloNumeros2(event)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Cantidad de números</td>
                <td>
                    <asp:TextBox ID="txtCantidadNumeros" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="3"  onkeypress="return soloNumeros2(event)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Numero de caracteres</td>
                <td>
                    <asp:TextBox ID="txtNumeroCaracteres" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="3"  onkeypress="return soloNumeros2(event)"></asp:TextBox>
                </td>
            </tr>
        </table>--%>
    </asp:Panel>
    
    
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    </div>
    </div>
    </div>
    <div class="col-md-12 col-lg-12"><div class="card">
        <div class="card-body"> 
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
    <asp:Panel ID="Panel5" runat="server" GroupingText="XML:">
        <div class="form-group">
            <label for="ContentPlaceHolder1_txtAreaContenido">Máximo de XML permitidos para adjuntar</label>
            <asp:TextBox ID="txtMaxXML" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="3" onkeypress="return soloNumeros2(event)"></asp:TextBox>
        </div>
       <%-- <table class="tblFm tblFm3">
            <tr>
                <td>Maximo de XML permitidos para adjuntar</td>
                <td>
                    <asp:TextBox ID="txtMaxXML" runat="server" class="txtValidar soloNumeros2 form-control" MaxLength="3"  onkeypress="return soloNumeros2(event)"></asp:TextBox>
                </td>
            </tr>
        </table>--%>
    </asp:Panel>
    
    
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    </div>
    </div>
    </div>
    <div class="col-md-12 col-lg-12"><div class="card">
        <div class="card-body">
            <%--<h1 class="card-title">Opciones</h1>--%>  
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
    <asp:Panel ID="Panel4" runat="server" GroupingText="Opciones:">
        
    <%--<br />
    <br />--%>

        <style>
            table.opciones.primerTd {
                width:40%;
            }

            .primerTd {
                /*width:40%;*/
                /*padding-rigt:3em;*/    
            }

            .segundoTd {
                padding-left:3em;           
            }

            #ContentPlaceHolder1_dpdBloqSociedad {
/*                height:12px;
                min-height:25px;*/
            }
            
        </style>
        <strong>Seleccione:</strong><br />
        <asp:Label ID="lblInfoGuardar" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblAdvertencia" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblLeyendaConfigAnterior" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblLeyendaConfigAnterior2" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="lblVernterior" runat="server" CssClass="btn btn-light" Text=""></asp:Label>
        <asp:Button ID="btnEnviarConfig" runat="server" OnClick="btnEnviarConfig_Click" Text="Guardar" CssClass="btn btn-primary" />
        <asp:Button ID="btnRecuperarAnterior" runat="server" CssClass="btn btn-danger" OnClick="btnRecuperarAnterior_Click" Text="Restablecer" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancelar" CssClass="btn btn-light" />
    <%--<table class="opciones tblFm">
        <thead>
            <tr>
                <th>
                    <table class="tblFm2">
                        <tr>
                            <td><strong>Seleccione:</strong></td>
                        </tr>
                    </table>
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
               <td class="primerTd">
                   <asp:Label ID="lblInfoGuardar" runat="server" Text=""></asp:Label>
               </td>
               <td class="segundoTd">
                   <asp:Button ID="btnEnviarConfig" runat="server" OnClick="btnEnviarConfig_Click" Text="Guardar" CssClass="btn btn-primary" /> 
               </td>
            </tr>
<%--            <tr>
                <td>
                    <asp:Label ID="lblAdvertencia" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblLeyendaConfigAnterior" runat="server" Text="Para ver la configuración anterior presione este botón "></asp:Label>
                    <asp:Label ID="lblLeyendaConfigAnterior2" runat="server" Text="Para recuperar la configuración anterior presione este botón: "></asp:Label>
                </td>
                <td class="segundoTd">
                    <br />
                    <asp:Label ID="lblVernterior" runat="server" CssClass="btn btn-light" Text=""></asp:Label>
                    <br />
                    <asp:Button ID="btnRecuperarAnterior" runat="server" CssClass="btn btn-danger" OnClick="btnRecuperarAnterior_Click" Text="Restablecer" />
                    <br/>
                    <br/>
                    
                </td>
            </tr>
            <tr>
                <td></td>
                <%--<td class="segundoTd"><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancelar" CssClass="btn btn-light" /></td>
            </tr>
        </tbody>
    </table>--%>

    </asp:Panel>

    
    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    </div>
    </div>
    </div>
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>

    <asp:HiddenField ID="hidVerificar" runat="server" Value="si" />
        <asp:HiddenField ID="hidPantalla" runat="server" Value="Configuración" />

    
    <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
    <asp:HiddenField ID="hidTipoCorreo" runat="server" />

    <asp:HiddenField ID="hidloadconfpass" runat="server" />
    <asp:HiddenField ID="hidCerrarSesion" runat="server" />
    </div>
</asp:Content>
