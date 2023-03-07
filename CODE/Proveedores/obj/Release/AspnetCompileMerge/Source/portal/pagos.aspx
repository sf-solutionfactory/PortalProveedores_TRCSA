<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaestra/MtrProveedor.Master" AutoEventWireup="true" CodeBehind="pagos.aspx.cs" Inherits="Proveedores.pagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/BusquedaTabla.js"></script>

    <script>
        $(function () {

            var activaFiltro = true;

            $("#pagos").addClass("selected active"); //MODIFY SF RSG 02.2023 V2.0");
            //$(".btn").button();
            //$("#ContentPlaceHolder1_hidActualiza").val("");
            $(".ico-actualizar").click(function () {
                //alert("in")
                $("#ContentPlaceHolder1_hidActualiza").val("actualiza");
            });

            $("#ContentPlaceHolder1_hidHeader").val("");

            //$("th").click(function () {
            //    $("#ContentPlaceHolder1_hidHeader").val($(this).html());
            //    $("#ContentPlaceHolder1_btnToOrder").click();
                
            //});

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
            //BEGIN OF INSERT SF RSG 02.2023 V2.0
        var dialog;
        //$(".desadjuntarXML").click(function () {//evento de desajuntar archivois
        function desadjuntarCP(belnr, uuid) {
            //var mensaje = $(this).attr('msm');
            var mensaje = belnr;

            //mensaje = $.parseHTML(mensaje);
            if (mensaje != "" && mensaje != null) {
                mensaje = "¿Desea desadjuntar los archivos del documento: " + mensaje + "?";
                $("#ContentPlaceHolder1_lblDialog").text(mensaje);
                swal(mensaje)
                swal({
                    title: "¿Está seguro?",
                    text: mensaje,
                    type: "warning",
                    showCancelButton: true,
                    cancelButtonText: "Cancelar",
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Desadjuntar",
                    closeOnConfirm: false,
                    html: false
                }, function () {
                    desadjuntarCP_XML(belnr, uuid.trim())
                });
            }

        }

        function desadjuntarCP_XML(belnr, uuid) {
            var params = new Object();
            params.belnr = belnr;
            params.uuid = uuid;
            params = JSON.stringify(params);

            $.ajax({
                type: "POST",
                url: "../portal/pagos.aspx/desadjuntar",
                data: params,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function () {
                    swal({
                        title: "OK!",
                        text: "Se desadjuntaron los archivos.",
                        icon: "success",
                    }, function () {
                        document.getElementById("ContentPlaceHolder1_btnActualizaX").click();
                    });
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + ": " + XMLHttpRequest.responseText);
                }
            });
        }

        //);
        function cerrardialog() {
            dialog.dialog("close");
        }

        function datosTabla(button) {
            var rows = $(button).parents('tr');
            var cellsOfRow = rows[0].getElementsByTagName('td');
            var valor1 = $.trim(cellsOfRow[1].innerHTML);
            var valor2 = $.trim(cellsOfRow[2].innerHTML);
            var valor3 = $.trim(cellsOfRow[3].innerHTML);
            var valor4 = $.trim(cellsOfRow[4].innerHTML);
            var valor5 = $.trim(cellsOfRow[5].innerHTML);
            var valor6 = $.trim(cellsOfRow[6].innerHTML);
            var valor7 = $.trim(cellsOfRow[15].innerHTML);   //ADD SF RSG 15.12.2022
            var valor8 = $.trim(cellsOfRow[16].innerHTML);   //ADD SF RSG 15.12.2022
            var parametros = new Object();
            var dataPagos = {
                AUGBL1: rows.find('.AUGBL1').text(),
                BLART1: rows.find('.BLART1').text(),
                BELNR1: rows.find('.BELNR1').text(),
                BLDAT1: rows.find('.BLDAT1').text(),
                DMSHB1: rows.find('.DMSHB1').text(),
                HWAER1: rows.find('.HWAER1').text(),
                ZUONR1: rows.find('.ZUONR1').text(),
                XBLNR: rows.find('.XBLNR').text(),
                KONTO: rows.find('.KONTO').text(),
                NAME1: rows.find('.NAME1').text(),
                SGTXT: rows.find('.SGTXT').text(),
                EBELN: rows.find('.EBELN').text(),
                GJAHR: rows.find('.GJAHR').text(),  //ADD SF RSG 15.12.2022
                BUKRS: rows.find('.BUKRS').text()  //ADD SF RSG 15.12.2022
            };

            parametros.dataPagos = dataPagos;

            parametros = JSON.stringify(dataPagos);
            console.log(parametros);
            console.log(dataPagos);
            console.log('Este es un idex', rows[0]);


            var data = {
                objDatos: {
                    clngDocumento: valor1,
                    numDocumento: valor2,
                }
            }

            $.ajax({
                type: "POST",
                url: "pagos.aspx/cargarDatos",
                data: "{clgDocument:'" + valor1 + "', numDocument:'" + valor2 + "', tipoDocumento:'" + valor3 + "', fechaPago:'" + valor4 + "',montoMoneda:'" + valor5 + " " + valor6 + "', ejercicio:'" + valor7 + "', bukrs:'" + valor8 + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    if (result.d == null)
                        alert("Incorecto");
                    else {
                        document.location.href = "PagosDet.aspx";
                    }
                },
                error: function (msg) {
                    var objJSONText = msg.responseText;
                    var objJSON = JSON.parse(objJSONText);
                    alert("ERROR: " + objJSON.Message);
                }
            });
        }
        function showFiltros() {
            document.getElementById("collapseOne").classList.add("show");
        }
            //END   OF INSERT SF RSG 02.2023 V2.0
    </script>
<%--    <label class="h1">
        Pagos
    </label>--%>
    
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
                <div class="row">
                <div class="col-sm-12">
                    <div class="table-responsive1" style="overflow-x:auto;">
                        <asp:Label ID="lblTabla" runat="server"></asp:Label>
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
<%--    <table class="tblComp">
        <tr>
            <td>
                Fecha inicio:<asp:TextBox ID="datepicker" runat="server" CssClass="form-control-lg form-control"></asp:TextBox> 
            </td>
            <td>
                Fecha Fin:<asp:TextBox ID="datepicker2" runat="server" CssClass="form-control-lg form-control"></asp:TextBox> 
            </td>
            <td>
                <asp:Button ID="btnActualizaX" runat="server" Text="" CssClass="btn btn-successico-actualizar" OnClick="Button1_Click" /> 
            </td>
            <td>--%>
                <asp:Label ID="lblExpandirTodo" runat="server" Text="Label" CssClass="btn btn-primary feather-icon invisible" ></asp:Label> <%--MODIFY SF RSG 02.2023 V2.0--%>
<%--            </td>
            <td>--%>
                <asp:Label ID="lblContraerTodo" runat="server" Text="Label" CssClass="btn btn-primary feather-icon invisible" ></asp:Label>  <%--MODIFY SF RSG 02.2023 V2.0--%>
            <%--</td>
        </tr>
    </table>--%>
    <%--<table class="filtro">
        <tr>
            <td>Filtrar...</td>
            <td><input id="searchTerm" type="text"/></td>
        </tr>
    </table>--%>
    
<%--    <div class="table-responsive"> 
    <asp:Label ID="lblTabla" runat="server"></asp:Label>
    </div>--%>

    <%--<div style="width:100%;height:50px;">
        <a href='pagos.aspx'>
            <div class="ico-actualizar">

            </div>
        </a>
    </div>--%>
    <%--<asp:Button ID="btnActualiza" runat="server" Text="" CssClass="ico-actualizar" />--%>


    <asp:HiddenField ID="hidFiltro" runat="server" />

    <asp:HiddenField ID="hidCerrarSesion" runat="server" />
    <asp:HiddenField ID="hidActualiza" runat="server" />

    <asp:Button ID="btnToOrder" runat="server" Text="" />
    <asp:HiddenField ID="hidHeader" runat="server" />
    <asp:HiddenField ID="modoOrdenar" runat="server" Value="asc" />

    <asp:Label ID="lblDialog" runat="server" title="Informe" Text=""></asp:Label>

</asp:Content>
