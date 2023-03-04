<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaestra/MtrProveedor.Master" AutoEventWireup="true" CodeBehind="datosMaestros.aspx.cs" Inherits="Proveedores.datosMaestros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            
            $("#datosMaestros").addClass("selected active");
        });
    </script>

    <style>

        .lblDM, .lblDM_H {
              color: #4D4D4D;
              text-align: left;
              font-weight: bolder;
              font-size: 12px;
        }

        .lblDM_H {
              font-size: 14px;
        }

        .form-control{
            font-size:1.4rem;
        }

    </style>


    <%--<label class="h1">
        Mis datos
    </label>--%>
  <%--  <br/><br/>--%>


    <%--BEGIN OF INSERT SF RSG 02.2023 V2.0--%>
    <div class="col-md-8 col-lg-6">
        <div class="card">
            <div class="card-body">
                
    <%--END   OF INSERT SF RSG 02.2023 V2.0--%>
                <asp:Panel ID="pnlDatosMaestros" runat="server"></asp:Panel>
                <br />
                <asp:Label ID="lblTabla" runat="server"></asp:Label>
                <br />
            </div>
        </div>
    </div>
    <div style="width:100%;height:50px; display:none" > <%--MODIFY SF RSG 02.2023 V2.0--%>
        <a href='datosMaestros.aspx' class="btn btn-success" > <%--MODIFY SF RSG 02.2023 V2.0--%>
            <%--<div class="ico-actualizar">
            </div>--%>
            Actualizar
        </a>
    </div>

    <asp:HiddenField ID="hidCerrarSesion" runat="server" />

    </asp:Content>
