using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using XML_Test_Reader;

namespace Proveedores.portal
{
    public partial class facturas3 : System.Web.UI.Page
    {
        string index = "";
        private System.Xml.XmlDocument xmlDoc;
        XElement xmlFact;
        string[] indexs;
        string[] indexs2;   //ADD SF RSG 02.2023 v2.0
        int maxXML = 10;
        string complementoMsgError = "";

        string fn = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //INICIO Permiso de ver esta pantalla
            bool permiso = false;
            try
            {
                int[] idPantallas = (int[])Session["Pantallas"];
                for (int i = 0; i < idPantallas.Length; i++)
                {
                    if (idPantallas[i] == 1)
                    {
                        permiso = true;
                        break;
                    }

                }
                if (permiso == false)
                {
                    cerrarSesion();
                }
            }
            catch (Exception)
            {
                cerrarSesion();
            }
            //FIN Permiso de ver esta pantalla
            //String s = Request.QueryString["index"];

            string strIndex = this.hidIndexs.Value;
            if (strIndex != "")
            {
                if (strIndex.Length == 1)
                {
                    indexs = new string[1];
                    indexs[0] = strIndex;
                }
                else
                {
                    indexs = strIndex.Split(',');
                }

            }
            if (strIndex != "")
            {
                maxXML = int.Parse(obtenerMaxXML());
                this.File1.Visible = true;
                this.cargararchivo.Visible = true;
                cargarDatosTabla();
            }
            else
            {
                this.File1.Visible = false;
                this.cargararchivo.Visible = false;
            }

        }

        private void cerrarSesion()
        {
            //se borra la cookie de autenticacion
            System.Web.Security.FormsAuthentication.SignOut();
            //se redirecciona al usuario a la pagina de login
            //Response.Redirect("Inicio.aspx");     //DELETE SF RSG 02.2023 v2.0
            Response.Redirect("Default.aspx");      //ADD SF RSG 02.2023 v2.0
        }

        public void cargarDatosTabla()
        {
            List<PEntidades.FacturasXVerificar> listFact = new List<PEntidades.FacturasXVerificar>();
            listFact = (List<PEntidades.FacturasXVerificar>)Session["lstFacturas2"];
            string tablas = "";
            string consolas = "";
            string clase = "show";
            if (listFact.Count > 0)
            {
                //indexs2 = new string[indexs.Length + 1];      //ADD SF RSG 02.2023 v2.0
                indexs2 = new string[indexs.Length];            //ADD SF RSG 02.2023 v2.0
                int iddetalle = int.Parse(indexs[0]) - 1;
                //indexs2[0] = iddetalle.ToString();            //ADD SF RSG 02.2023 v2.0
                //indexs.CopyTo(indexs2, 1);                    //ADD SF RSG 02.2023 v2.0
                indexs.CopyTo(indexs2,0);                       //ADD SF RSG 02.2023 v2.0

                tablas += "<div id='carouselExampleIndicators' class='carousel slide' data-ride='carousel' data-interval='false'>";
                tablas += "  <ol class='carousel-indicators'>";
                //for (int i = 0; i < indexs.Length; i++)
                for (int i = 0; i < indexs2.Length; i++)                  //ADD SF RSG 02.2023 v2.0
                {
                    if (i == 0)
                        tablas += "   <li data-target='#carouselExampleIndicators' data-slide-to='" + i + "' class='active'></li>";
                    else
                        tablas += "   <li data-target='#carouselExampleIndicators' data-slide-to='" + i + "'></li>";
                }
                tablas += " </ol>";
                tablas += "<div class='carousel-inner'>";
                //for (int i = 0; i < indexs.Length; i++)
                for (int i = 0; i < indexs2.Length; i++)                  //ADD SF RSG 02.2023 v2.0
                {
                    if (i == 0)
                        tablas += "  <div class='carousel-item active'>";
                    else
                        tablas += "   <div class='carousel-item'>";
                    tablas += "<div class='form-group'><label>";
                    tablas += "Referencia";
                    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    tablas += listFact[iddetalle].XBLNR2;
                    tablas += "'></div>";

                    tablas += "<div class='form-group'><label>";
                    tablas += "Proveedor";
                    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //tablas += listFact[int.Parse(indexs[i])].LIFNR;
                    tablas += listFact[int.Parse(indexs2[i])].LIFNR;                  //ADD SF RSG 02.2023 v2.0
                    tablas += "'></div>";

                    tablas += "<div class='row'>";

                    tablas += "<div class='form-group col'><label>";
                    tablas += "Sociedad";
                    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //tablas += listFact[int.Parse(indexs[i])].BUKRS;
                    tablas += listFact[int.Parse(indexs2[i])].BUKRS;                  //ADD SF RSG 02.2023 v2.0
                    tablas += "'></div>";

                    tablas += "<div class='form-group col'><label>";
                    tablas += "Centro";
                    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //tablas += listFact[int.Parse(indexs[i])].WERKS;
                    tablas += listFact[int.Parse(indexs2[i])].WERKS;                  //ADD SF RSG 02.2023 v2.0
                    tablas += "'></div>";

                    tablas += "</div>";
                    tablas += "<div class='row'>";

                    tablas += "<div class='form-group col'><label>";
                    tablas += "Fecha MIGO/BASE";
                    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //tablas += listFact[int.Parse(indexs[i])].BUDAT;
                    tablas += listFact[int.Parse(indexs2[i])].BUDAT;                  //ADD SF RSG 02.2023 v2.0
                    tablas += "'></div>";

                    tablas += "<div class='form-group col'><label>";
                    tablas += "Fecha del documento";
                    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //tablas += listFact[int.Parse(indexs[i])].BLDAT;
                    tablas += listFact[int.Parse(indexs2[i])].BLDAT;                  //ADD SF RSG 02.2023 v2.0
                    tablas += "'></div>";

                    tablas += "</div>";
                    tablas += "<div class='row'>";

                    tablas += "<div class='form-group col col-lg-8'><label>";
                    tablas += "Importe";
                    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //tablas += formatCurrency(listFact[int.Parse(indexs[i])].WRBTR);
                    tablas += formatCurrency(listFact[int.Parse(indexs2[i])].WRBTR);                  //ADD SF RSG 02.2023 v2.0
                    tablas += "'></div>";

                    tablas += "<div class='form-group col col-lg-4'><label>";
                    tablas += "Moneda";
                    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //tablas += listFact[int.Parse(indexs[i])].WAERS;
                    tablas += listFact[int.Parse(indexs2[i])].WAERS;                  //ADD SF RSG 02.2023 v2.0
                    tablas += "'></div>";

                    tablas += "</div>";
                    tablas += "<div class='row'>";

                    tablas += "<div class='form-group col col-lg-4'><label>";
                    tablas += "Importe IVA";
                    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //tablas += formatCurrency(listFact[int.Parse(indexs[i])].IVA);
                    tablas += formatCurrency(listFact[int.Parse(indexs2[i])].IVA);                  //ADD SF RSG 02.2023 v2.0
                    tablas += "'></div>";

                    tablas += "<div class='form-group col col-lg-4'><label>";
                    tablas += "IVA";
                    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //tablas += listFact[int.Parse(indexs[i])].MWSKZ;
                    tablas += listFact[int.Parse(indexs2[i])].MWSKZ;                  //ADD SF RSG 02.2023 v2.0
                    tablas += "'></div>";

                    tablas += "<div class='form-group col col-lg-4'><label>";
                    tablas += "Retención";
                    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //tablas += formatCurrency(listFact[int.Parse(indexs[i])].RETENCION);
                    tablas += formatCurrency(listFact[int.Parse(indexs2[i])].RETENCION);                  //ADD SF RSG 02.2023 v2.0
                    tablas += "'></div>";

                    tablas += "</div>";

                    tablas += "<div class='form-group'><label>";
                    tablas += "Factura electrónica";
                    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //tablas += listFact[int.Parse(indexs[i])].ELECT;
                    tablas += listFact[int.Parse(indexs2[i])].ELECT;                  //ADD SF RSG 02.2023 v2.0
                    tablas += "'></div>";

                    tablas += "<div class='row'>";

                    tablas += "<div class='form-group col-lg-8'><label>";
                    tablas += "Saldo";
                    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //tablas += formatCurrency(listFact[int.Parse(indexs[i])].SALDO);
                    tablas += formatCurrency(listFact[int.Parse(indexs2[i])].SALDO);                  //ADD SF RSG 02.2023 v2.0
                    tablas += "'></div>";

                    tablas += "<div class='form-group col-lg-4'><label>";
                    tablas += "XML Adjuntos";
                    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //tablas += listFact[int.Parse(indexs[i])].cantidadXML;
                    tablas += listFact[int.Parse(indexs2[i])].cantidadXML;                  //ADD SF RSG 02.2023 v2.0
                    tablas += "'></div>";
                    tablas += "</div>";
                    tablas += "<br/>";
                    tablas += "<br/>";
                    tablas += "   </div>";
                }
                tablas += "</div>";
                tablas += "<a class='carousel-control-prev' href='#carouselExampleIndicators' role='button' data-slide='prev'>";
                tablas += "  <span class='carousel-control-prev-icon' aria-hidden='true'></span>";
                tablas += "  <span class='sr-only'>Previous</span>";
                tablas += "</a>";
                tablas += "<a class='carousel-control-next' href='#carouselExampleIndicators' role='button' data-slide='next'>";
                tablas += "  <span class='carousel-control-next-icon' aria-hidden='true'></span>";
                tablas += "  <span class='sr-only'>Next</span>";
                tablas += "</a>";
                tablas += "</div>";

                //for (int i = 0; i < indexs.Length; i++)
                for (int i = 0; i < indexs2.Length; i++)                  //ADD SF RSG 02.2023 v2.0
                    {

                    //    //listFact[int.Parse(indexs[i])].consola = "";
                    //    tablas += "<table class='tblCV' " + clase + ">";
                    //    tablas += "<tbody>";
                    //    tablas += "<tr><td style='width:100%;' colspan='2'>";

                    //    tablas += "<div class='form-group'><label>";
                    //    tablas += "Referencia";
                    //    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //    tablas += listFact[iddetalle].XBLNR2;
                    //    tablas += "'></div>";

                    //    tablas += "<div class='form-group'><label>";
                    //    tablas += "Proveedor";
                    //    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //    tablas += listFact[int.Parse(indexs[i])].LIFNR;
                    //    tablas += "'></div>";

                    //    tablas += "<div class='row'>";

                    //    tablas += "<div class='form-group col'><label>";
                    //    tablas += "Sociedad";
                    //    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //    tablas += listFact[int.Parse(indexs[i])].BUKRS;
                    //    tablas += "'></div>";

                    //    tablas += "<div class='form-group col'><label>";
                    //    tablas += "Centro";
                    //    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //    tablas += listFact[int.Parse(indexs[i])].WERKS;
                    //    tablas += "'></div>";

                    //    tablas += "</div>";
                    //    tablas += "<div class='row'>";

                    //    tablas += "<div class='form-group col'><label>";
                    //    tablas += "Fecha MIGO/BASE";
                    //    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //    tablas += listFact[int.Parse(indexs[i])].BUDAT;
                    //    tablas += "'></div>";

                    //    tablas += "<div class='form-group col'><label>";
                    //    tablas += "Fecha del documento";
                    //    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //    tablas += listFact[int.Parse(indexs[i])].BLDAT;
                    //    tablas += "'></div>";

                    //    tablas += "</div>";
                    //    tablas += "<div class='row'>";

                    //    tablas += "<div class='form-group col col-lg-8'><label>";
                    //    tablas += "Importe";
                    //    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //    tablas += formatCurrency(listFact[int.Parse(indexs[i])].WRBTR);
                    //    tablas += "'></div>";

                    //    tablas += "<div class='form-group col col-lg-4'><label>";
                    //    tablas += "Moneda";
                    //    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //    tablas += listFact[int.Parse(indexs[i])].WAERS;
                    //    tablas += "'></div>";

                    //    tablas += "</div>";
                    //    tablas += "<div class='row'>";

                    //    tablas += "<div class='form-group col col-lg-4'><label>";
                    //    tablas += "Importe IVA";
                    //    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //    tablas += formatCurrency(listFact[int.Parse(indexs[i])].IVA);
                    //    tablas += "'></div>";

                    //    tablas += "<div class='form-group col col-lg-4'><label>";
                    //    tablas += "IVA";
                    //    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //    tablas += listFact[int.Parse(indexs[i])].MWSKZ;
                    //    tablas += "'></div>";

                    //    tablas += "<div class='form-group col col-lg-4'><label>";
                    //    tablas += "Retención";
                    //    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //    tablas += formatCurrency(listFact[int.Parse(indexs[i])].RETENCION);
                    //    tablas += "'></div>";

                    //    tablas += "</div>";

                    //    tablas += "<div class='form-group'><label>";
                    //    tablas += "Factura electrónica";
                    //    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //    tablas += listFact[int.Parse(indexs[i])].ELECT;
                    //    tablas += "'></div>";

                    //    tablas += "<div class='row'>";

                    //    tablas += "<div class='form-group col-lg-8'><label>";
                    //    tablas += "Saldo";
                    //    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //    tablas += formatCurrency(listFact[int.Parse(indexs[i])].SALDO);
                    //    tablas += "'></div>";

                    //    tablas += "<div class='form-group col-lg-4'><label>";
                    //    tablas += "XML Adjuntos";
                    //    tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                    //    tablas += listFact[int.Parse(indexs[i])].cantidadXML;
                    //    tablas += "'></div>";
                    //    tablas += "</div>";

                    //    tablas += "</td></tr>";
                    //    tablas += "<tr>";
                    //    tablas += "<td style='width:50%;text-align:left'>";
                    //    tablas += "<i class='fa-solid fa-arrow-left imgBack pointer' align='left' style='font-size:3rem'></i>";
                    //    tablas += "</td>";
                    //    tablas += "<td style='width:50%;text-align:right'>";
                    //    tablas += "<i class='fa-solid fa-arrow-right imgNext pointer' align='right' style='font-size:3rem'></i>";
                    //    tablas += "</td></tr>";


                    //    //tablas += "<tr>";
                    //    //tablas += "<td>";
                    //    //tablas += "Referencia";
                    //    //tablas += "</td>";
                    //    //tablas += "<td>";
                    //    //tablas += listFact[iddetalle].XBLNR2;
                    //    //tablas += "</td>";
                    //    //tablas += "</tr>";

                    //    //tablas += "<tr>";
                    //    //tablas += "<td>";
                    //    //tablas += "Proveedor";
                    //    //tablas += "</td>";
                    //    //tablas += "<td>";
                    //    //tablas += listFact[int.Parse(indexs[i])].LIFNR;
                    //    //tablas += "</td>";
                    //    //tablas += "</tr>";

                    //    //tablas += "<tr>";
                    //    //tablas += "<td>";
                    //    //tablas += "Sociedad";
                    //    //tablas += "</td>";
                    //    //tablas += "<td>";
                    //    //tablas += listFact[int.Parse(indexs[i])].BUKRS;
                    //    //tablas += "</td>";
                    //    //tablas += "</tr>";

                    //    //tablas += "<tr>";
                    //    //tablas += "<td>";
                    //    //tablas += "Centro";
                    //    //tablas += "</td>";
                    //    //tablas += "<td>";
                    //    //tablas += listFact[int.Parse(indexs[i])].WERKS;
                    //    //tablas += "</td>";
                    //    //tablas += "</tr>";

                    //    //tablas += "<tr>";
                    //    //tablas += "<td>";
                    //    //tablas += "Fecha MIGO/BASE";
                    //    //tablas += "</td>";
                    //    //tablas += "<td>";
                    //    //tablas += listFact[int.Parse(indexs[i])].BUDAT;
                    //    //tablas += "</td>";
                    //    //tablas += "</tr>";

                    //    //tablas += "<tr>";
                    //    //tablas += "<td>";
                    //    //tablas += "Fecha del documento";
                    //    //tablas += "</td>";
                    //    //tablas += "<td>";
                    //    //tablas += listFact[int.Parse(indexs[i])].BLDAT;
                    //    //tablas += "</td>";
                    //    //tablas += "</tr>";

                    //    //tablas += "<tr>";
                    //    //tablas += "<td>";
                    //    //tablas += "Importe";
                    //    //tablas += "</td>";
                    //    //tablas += "<td>";
                    //    //tablas += listFact[int.Parse(indexs[i])].WRBTR;
                    //    //tablas += "</td>";
                    //    //tablas += "</tr>";

                    //    //tablas += "<tr>";
                    //    //tablas += "<td>";
                    //    //tablas += "Importe IVA";
                    //    //tablas += "</td>";
                    //    //tablas += "<td>";
                    //    //tablas += listFact[int.Parse(indexs[i])].IVA;
                    //    //tablas += "</td>";
                    //    //tablas += "</tr>";

                    //    //tablas += "<tr>";
                    //    //tablas += "<td>";
                    //    //tablas += "IVA";
                    //    //tablas += "</td>";
                    //    //tablas += "<td>";
                    //    //tablas += listFact[int.Parse(indexs[i])].MWSKZ;
                    //    //tablas += "</td>";
                    //    //tablas += "</tr>";

                    //    //tablas += "<tr>";
                    //    //tablas += "<td>";
                    //    //tablas += "Retención";
                    //    //tablas += "</td>";
                    //    //tablas += "<td>";
                    //    //tablas += listFact[int.Parse(indexs[i])].RETENCION;
                    //    //tablas += "</td>";
                    //    //tablas += "</tr>";

                    //    //tablas += "<tr>";
                    //    //tablas += "<td>";
                    //    //tablas += "Moneda";
                    //    //tablas += "</td>";
                    //    //tablas += "<td>";
                    //    //tablas += listFact[int.Parse(indexs[i])].WAERS;
                    //    //tablas += "</td>";
                    //    //tablas += "</tr>";

                    //    //tablas += "<tr>";
                    //    //tablas += "<td>";
                    //    //tablas += "Factura Elec.";
                    //    //tablas += "</td>";
                    //    //tablas += "<td>";
                    //    //tablas += listFact[int.Parse(indexs[i])].ELECT;
                    //    //tablas += "</td>";
                    //    //tablas += "</tr>";

                    //    //tablas += "<tr>";
                    //    //tablas += "<td>";
                    //    //tablas += "Saldo";
                    //    //tablas += "</td>";
                    //    //tablas += "<td>";
                    //    //tablas += listFact[int.Parse(indexs[i])].SALDO;
                    //    //tablas += "</td>";
                    //    //tablas += "</tr>";

                    //    //tablas += "<tr>";
                    //    //tablas += "<td>";
                    //    //tablas += "XML adjuntos";
                    //    //tablas += "</td>";
                    //    //tablas += "<td class='contadorXML'>";
                    //    //tablas += listFact[int.Parse(indexs[i])].cantidadXML;
                    //    //tablas += "</td>";
                    //    //tablas += "</tr>";

                    //    //tablas += "<tr>";
                    //    //tablas += "<td>";




                    //    //tablas += "";



                    //    //tablas += "</td>";
                    //    //tablas += "<td style='width:100%;'>";
                    //    //tablas += "<img src='../css/images/fl_back.png' class='imgBack pointer' align='left'><img src='../css/images/fl_next.png' class='imgNext pointer' align='right'>";
                    //    //tablas += "</td>";
                    //    //tablas += "</tr>";

                    //    tablas += "</tbody>";
                    //    tablas += "</table>";

                    //consolas += "<label class='consola " + clase + "'>" + listFact[int.Parse(indexs[i])].consola + "</label> ";
                    consolas += "<label class='consola " + clase + "'>" + listFact[int.Parse(indexs2[i])].consola + "</label> ";                  //ADD SF RSG 02.2023 v2.0

                    //clase = "hidd";                  //DELETE SF RSG 02.2023 v2.0
                }
            }

            this.ltlTablas.Text = tablas;
            this.lblConsola.Text = consolas;
        }

        private void cargar()
        {
            if ((File1.PostedFile != null)
                && (File1.PostedFile.ContentLength > 0) && (File2.PostedFile != null)
                && (File2.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(File2.PostedFile.FileName);
                string SaveLocation = Server.MapPath("Files") + "\\" + fn;
                string nombrePdf = Path.GetFileName(SaveLocation);
                string extPDF = Path.GetExtension(SaveLocation).ToLower();
                fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                SaveLocation = Server.MapPath("Files") + "\\" + fn;
                string extXML = Path.GetExtension(SaveLocation).ToLower();
                string tipoArchivo = "";
                bool inveref = false;
                string extencionValidaXML = "";
                string extencionValidaPDF = "";
                string error = "";
                string fecha_xml = "";
                string referencia = "";
                string impRetencion = "";
                string rfc = Session["rfc"].ToString();
                if (String.IsNullOrEmpty(rfc) == false)
                {
                    extencionValidaXML = ".xml";
                    tipoArchivo = "XML";
                }
                extencionValidaPDF = ".pdf";
                extencionValidaPDF = extencionValidaPDF.ToUpper();
                extPDF = extPDF.ToUpper();
                extencionValidaXML = extencionValidaXML.ToUpper();
                extXML = extXML.ToUpper();
                if (extXML == extencionValidaXML && extPDF == extencionValidaPDF) /////////////
                {
                    byte[] rawByte = new byte[0];
                    byte[] rawBytePDF = new byte[0];
                    try
                    {
                        System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
                        customCulture.NumberFormat.NumberDecimalSeparator = ".";
                        System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
                        if (tipoArchivo == "XML")
                        {
                            this.xmlDoc = new System.Xml.XmlDocument();
                            this.xmlDoc.Load(File1.PostedFile.InputStream);
                            rawByte = Encoding.UTF8.GetBytes(this.xmlDoc.InnerXml.ToString());
                        }
                        //else
                        //{
                        //    int tam = 36; // tamaño del UUID
                        //    error = "1 " + File1.PostedFile.FileName;
                        int fileLen;
                        fileLen = File2.PostedFile.ContentLength;
                        rawBytePDF = new Byte[fileLen];
                        File2.PostedFile.InputStream.Read(rawBytePDF, 0, fileLen);
                        //    File1.PostedFile.InputStream.Read(rawByte, 0, rawByte.Length);
                        //    Random r = new Random();
                        //    int ramdom = r.Next(10000000, 99999999);
                        //    nombrePdf = "_PDF_" + DateTime.Now + DateTime.Now.Millisecond + "_" + ramdom;
                        //    if (nombrePdf.Length >= tam)
                        //    {
                        //        nombrePdf = nombrePdf.Substring(0, tam);    
                        //    }
                        //}

                        List<PEntidades.FacturasXVerificar> listFact = new List<PEntidades.FacturasXVerificar>();
                        listFact = (List<PEntidades.FacturasXVerificar>)Session["lstFacturas2"];

                        List<string[]> listaDiferentesInstancias = (List<string[]>)Session["listaDiferentesInstancias"];

                        bool continuar = false;
                        if (tipoArchivo == "XML")
                        {

                            bool noValida = WebConfigurationManager.AppSettings["noValidaSat"].ToString().Equals("X"); //MODIFY SF RSG 02.2023 v2.0
                            continuar = validarSAT(ref impRetencion, noValida); //MODIFY SF RSG 02.2023 v2.0
                        }
                        //else if (tipoArchivo == "PDF")
                        //{
                        //    continuar = true;
                        //}
                        if (continuar)
                        {
                            //raw = this.xmlDoc.InnerXml.ToString();
                            if (tipoArchivo == "XML")
                            {

                                continuar = validarSAP(ref fecha_xml, ref referencia, impRetencion, listFact[int.Parse(indexs[0])].XBLNR2, ref inveref);
                            }
                            //else if (tipoArchivo == "PDF")
                            //{
                            //    continuar = true;
                            //}

                            if (String.IsNullOrEmpty(impRetencion)) 
                            {
                                impRetencion = "0";
                            }
                            if (continuar)
                            {
                                PNegocio.CargarFactura cf = new PNegocio.CargarFactura();                                
                                for (int i = 0; i < indexs.Length; i++)
                                {
                                    if ((listFact[int.Parse(indexs[i])].DescripcionErrorSAP == "SAP : Cargada correctamente" || tipoArchivo == "PDF") &&
                                        listFact[int.Parse(indexs[i])].cantidadXML <= maxXML)
                                    {
                                        int contadorres = 0;
                                        int indexInstanciaCorrespondiente = Gen.Util.CS.Gen.buscarIndexUbicacionInstanciaCorrres(listaDiferentesInstancias, listFact[int.Parse(indexs[i])].IDINSTANCIA);
                                        //if (tipoArchivo == "PDF"){
                                        //    error = "2";
                                        //    listFact[int.Parse(indexs[i])].uuid = nombrePdf;
                                        //    listFact[int.Parse(indexs[i])].DescripcionErrorSAP = "SAP : Cargada correctamente";
                                        //    listFact[int.Parse(indexs[i])].DescripcionErrorSAT = "SAT : N/A";
                                        //}
                                        if (inveref) listFact[int.Parse(indexs[i])].DescripcionErrorSAP += " XML adjunto mediante FOLIO - SERIE";
                                        else listFact[int.Parse(indexs[i])].DescripcionErrorSAP += " XML adjunto mediante SERIE - FOLIO";
                                        try
                                        {
                                            error = "3";

                                            contadorres =
                                            cf.setFacturascargadasNew(listFact[int.Parse(indexs[i])].BUKRS,
                                            obtener_correo(),
                                            listFact[int.Parse(indexs[i])].EBELN,
                                            listFact[int.Parse(indexs[i])].LIFNR,
                                            listFact[int.Parse(indexs[i])].DescripcionErrorSAP,
                                            listFact[int.Parse(indexs[i])].DescripcionErrorSAT,
                                            "1",
                                            listFact[int.Parse(indexs[i])].TIPO,
                                            listFact[int.Parse(indexs[i])].WERKS,
                                            //listFact[int.Parse(indexs[i])].XBLNR2,referencia anterior
                                            referencia,
                                            fecha_xml,
                                            fn.ToString(),
                                            listaDiferentesInstancias[indexInstanciaCorrespondiente][1].ToString().Trim(),
                                            listaDiferentesInstancias[indexInstanciaCorrespondiente][4].Split(new Char[] { ',' }),
                                            rawByte,
                                            listFact[int.Parse(indexs[i])].uuid,
                                            listFact[int.Parse(indexs[i])].total,
                                            listFact[int.Parse(indexs[i])].posicion,
                                            listFact[int.Parse(indexs[i])].BELNR,
                                            listFact[int.Parse(indexs[i])].BWTAR,
                                            listFact[int.Parse(indexs[i])].KSCHL,
                                            tipoArchivo,
                                            rawBytePDF, nombrePdf, Convert.ToDecimal(impRetencion)
                                            );
                                            error = "4";
                                            listFact[int.Parse(indexs[i])].UrlXML = fn;

                                            complementoMsgError = "XML: " + fn.ToString();
                                            complementoMsgError += "</br>";
                                            complementoMsgError += "UUID: " + listFact[int.Parse(indexs[i])].uuid;
                                            complementoMsgError += "</br>";
                                            complementoMsgError += listFact[int.Parse(indexs[i])].DescripcionErrorSAT;
                                            complementoMsgError += "</br>";
                                            if (contadorres != 0)
                                            {
                                                complementoMsgError += listFact[int.Parse(indexs[i])].DescripcionErrorSAP;
                                                listFact[int.Parse(indexs[i])].cantidadXML = contadorres;
                                                listFact[int.Parse(indexs[i])].consola = "Cargada correctamente";                                                
                                            }else{
                                                complementoMsgError += "SAP: Error al guardar el " + tipoArchivo;
                                                if (!String.IsNullOrEmpty(cf.error))
                                                {
                                                    complementoMsgError += ", " + cf.error;
                                                    listFact[int.Parse(indexs[i])].DescripcionErrorSAP = "SAP: Error al guardar el " + tipoArchivo;
                                                }
                                                listFact[int.Parse(indexs[i])].ErrorMostrar = "N/A";
                                                listFact[int.Parse(indexs[i])].consola = complementoMsgError;
                                            }
                                            complementoMsgError += "</br>";
                                            complementoMsgError += "</br>";

                                            if (listFact[int.Parse(indexs[i])].msgVarios == "")
                                            {
                                                listFact[int.Parse(indexs[i])].esPrimerCarga = true;
                                            }
                                            else
                                            {
                                                listFact[int.Parse(indexs[i])].esPrimerCarga = false;
                                            }
                                            listFact[int.Parse(indexs[i])].msgVarios += complementoMsgError;
                                        }
                                        catch (Exception z)
                                        {
                                            listFact[int.Parse(indexs[i])].consola = "Error al momento de adjuntar el archivo al sistema SAP.";
                                            listFact[int.Parse(indexs[i])].DescripcionErrorSAP = "N/A";
                                            listFact[int.Parse(indexs[i])].DescripcionErrorSAT = "";
                                            listFact[int.Parse(indexs[i])].ErrorMostrar = "N/A";
                                        }

                                        //if (contadorres != 0)
                                        //{



                                        //}
                                        //else
                                        //{
                                        //    complementoMsgError = "XML: " + fn.ToString();
                                        //    complementoMsgError += "</br>";
                                        //    complementoMsgError += "UUID: " + listFact[int.Parse(indexs[i])].uuid;
                                        //    complementoMsgError += "</br>";
                                        //    complementoMsgError += listFact[int.Parse(indexs[i])].DescripcionErrorSAT;
                                        //    complementoMsgError += "</br>";
                                        //    complementoMsgError += listFact[int.Parse(indexs[i])].DescripcionErrorSAP;
                                        //    complementoMsgError += "</br>";
                                        //    listFact[int.Parse(indexs[i])].consola = "Error al guardar el XML";
                                        //    listFact[int.Parse(indexs[i])].msgVarios += complementoMsgError + "Error al guardar el XML" + "</br></br>"; 
                                        //}


                                    }
                                    else if (listFact[int.Parse(indexs[i])].cantidadXML > maxXML)
                                    {
                                        listFact[int.Parse(indexs[i])].consola = "Limite de archivos alcanzado";
                                    }
                                }
                                //File1.PostedFile.SaveAs(SaveLocation);
                                //this.lblConsola.Text = "Cargada correctamente ";

                                Session["lstFacturas"] = listFact;
                                cargarDatosTabla();

                            }
                            else
                            {
                                PNegocio.CargarFactura cf = new PNegocio.CargarFactura();

                                for (int i = 0; i < indexs.Length; i++)
                                {
                                    if (listFact[int.Parse(indexs[i])].cantidadXML <= maxXML)
                                    {
                                        complementoMsgError = "XML: " + fn.ToString();
                                        complementoMsgError += "</br>";
                                        complementoMsgError += "UUID: " + listFact[int.Parse(indexs[i])].uuid;
                                        complementoMsgError += "</br>";
                                        complementoMsgError += listFact[int.Parse(indexs[i])].DescripcionErrorSAT;
                                        complementoMsgError += "</br>";
                                        complementoMsgError += listFact[int.Parse(indexs[i])].DescripcionErrorSAP;
                                        complementoMsgError += "</br>";
                                        complementoMsgError += "</br>";

                                        if (listFact[int.Parse(indexs[i])].msgVarios == "")
                                        {
                                            listFact[int.Parse(indexs[i])].esPrimerCarga = true;
                                        }
                                        else
                                        {
                                            listFact[int.Parse(indexs[i])].esPrimerCarga = false;
                                        }
                                        listFact[int.Parse(indexs[i])].msgVarios += complementoMsgError;

                                        listFact[int.Parse(indexs[i])].consola = listFact[int.Parse(indexs[i])].DescripcionErrorSAP;
                                    }
                                }




                                cargarDatosTabla();
                            }
                        }
                        else
                        {
                            PNegocio.CargarFactura cf = new PNegocio.CargarFactura();

                            for (int i = 0; i < indexs.Length; i++)
                            {
                                if (listFact[int.Parse(indexs[i])].cantidadXML <= maxXML)
                                {
                                    listFact[int.Parse(indexs[i])].consola = listFact[int.Parse(indexs[i])].DescripcionErrorSAT;

                                    complementoMsgError += "UUID: " + listFact[int.Parse(indexs[i])].uuid;
                                    complementoMsgError += "</br>";
                                    complementoMsgError = "XML: " + fn.ToString();
                                    complementoMsgError += "</br>";
                                    complementoMsgError += listFact[int.Parse(indexs[i])].DescripcionErrorSAT;
                                    complementoMsgError += "</br>";
                                    complementoMsgError += listFact[int.Parse(indexs[i])].DescripcionErrorSAP;
                                    complementoMsgError += "</br>";
                                    complementoMsgError += "</br>";

                                    if (listFact[int.Parse(indexs[i])].msgVarios == "")
                                    {
                                        listFact[int.Parse(indexs[i])].esPrimerCarga = true;
                                    }
                                    else
                                    {
                                        listFact[int.Parse(indexs[i])].esPrimerCarga = false;
                                    }
                                    listFact[int.Parse(indexs[i])].msgVarios += complementoMsgError;

                                }
                            }

                            
                            
                            
                            cargarDatosTabla();
                        }

                    }
                    catch (Exception ex)
                    {
                        
                        
                        
                        this.lblConsola.Text = "Error al cargar el archivo" + " " + error + "" + ex;
                        
                        //Response.Write("Error: " + ex.Message); //Nota: Exception.Message devuelve un mensaje detallado que describe la excepción actual. //Por motivos de seguridad, no se recomienda devolver Exception.Message a los usuarios finales de //entornos de producción. Sería más aconsejable poner un mensaje de error genérico. } } else { Response.Write("Seleccione un archivo que cargar."); 
                    }
                }
                else
                {
                    string mesajeerr = "";
                    List<PEntidades.FacturasXVerificar> listFact = new List<PEntidades.FacturasXVerificar>();
                    listFact = (List<PEntidades.FacturasXVerificar>)Session["lstFacturas2"];
                    if ((extXML == extencionValidaXML) == false)
                    {
                        mesajeerr += "El formato del campo de achivos XML es icorrecto.</br>";
                    }
                    if ((extPDF == extencionValidaPDF) == false)
                    {
                        mesajeerr += "El formato del campo de achivos PDF es icorrecto.</br>";
                    }

                    for (int i = 0; i < indexs.Length; i++)
                    {

                        listFact[int.Parse(indexs[i])].DescripcionErrorSAP = "N/A";
                        listFact[int.Parse(indexs[i])].DescripcionErrorSAT = mesajeerr; //No es XML
                        listFact[int.Parse(indexs[i])].consola = mesajeerr; //No es XML
                    }
                    
                    
                    
                    
                    cargarDatosTabla();
                    //this.lblConsola.Text = "No es un XML";
                    this.hidMessage.Value = "Error al cargar el archivo" + "(" + error + ")  " + mesajeerr;  // ADD SF RSG 02.2023 v2.0
                }

            }
            else
            {
                string mesajeerr = "";
                if ((File1.PostedFile == null)
                || (File1.PostedFile.ContentLength == 0))
                {
                    mesajeerr += "Ingrese un archivo XML.</br>";
                }
                if ((File2.PostedFile == null)
                || (File2.PostedFile.ContentLength == 0))
                {
                    mesajeerr += "Ingrese un archivo PDF.</br>";
                }
                List<PEntidades.FacturasXVerificar> listFact = new List<PEntidades.FacturasXVerificar>();
                listFact = (List<PEntidades.FacturasXVerificar>)Session["lstFacturas2"];
                for (int i = 0; i < indexs.Length; i++)
                {
                    listFact[int.Parse(indexs[i])].DescripcionErrorSAP = "N/A";
                    listFact[int.Parse(indexs[i])].DescripcionErrorSAT = mesajeerr; //No es XML
                    listFact[int.Parse(indexs[i])].consola = mesajeerr; //No es XML
                }
                
                
                
          
                cargarDatosTabla();
                //this.lblConsola.Text = "No es un XML";
                this.hidMessage.Value = "Error al cargar el archivo" + "(0)  " + mesajeerr;  // ADD SF RSG 02.2023 v2.0
            }

        }

        private void resulFacturaCorrecta()
        {

        }

        private void resulFacturaIncorrecta(string ubicacion, string index)
        {
            List<PEntidades.FacturasXVerificar> listFact = new List<PEntidades.FacturasXVerificar>();
            listFact = (List<PEntidades.FacturasXVerificar>)Session["lstFacturas2"];

            if (ubicacion.Equals("SAP"))
            {
                //this.lblConsola.Text = listFact[int.Parse(index)].DescripcionErrorSAP.ToString();
                listFact[int.Parse(index)].consola = listFact[int.Parse(index)].DescripcionErrorSAP;
            }
            else
            {
                listFact[int.Parse(index)].consola = listFact[int.Parse(index)].DescripcionErrorSAT;
                //this.lblConsola.Text = listFact[int.Parse(index)].DescripcionErrorSAT.ToString();
            }

        }

        private bool validarSAT(ref string impRetencion, bool nv) //MODIFY SF RSG 02.2023 v2.0
        {
            PNegocio.ConsultaCFDI c = new PNegocio.ConsultaCFDI();
            string resul = c.esCorrectoCFDI(this.xmlDoc.InnerXml, nv); //MODIFY SF RSG 02.2023 v2.0

            List<PEntidades.FacturasXVerificar> listFact = new List<PEntidades.FacturasXVerificar>();
            listFact = (List<PEntidades.FacturasXVerificar>)Session["lstFacturas2"];
            string uuid = "";
            System.Xml.XmlNode ndComplemento;
            ndComplemento = xmlDoc.GetElementsByTagName("cfdi:Complemento")[0];
            if (ndComplemento != null)
            {
                ndComplemento = xmlDoc.GetElementsByTagName("tfd:TimbreFiscalDigital")[0];
                try
                {
                    uuid = ndComplemento.Attributes["UUID"].Value;
                }
                catch (Exception)
                {
                }
            }

            ndComplemento = xmlDoc.GetElementsByTagName("cfdi:Impuestos")[0];
            try
            {
                impRetencion = ndComplemento.Attributes["TotalImpuestosRetenidos"].Value;
            }
            catch (Exception)
            {
                    impRetencion = "";
            }

            for (int i = 0; i < indexs.Length; i++)
            {
                if (listFact[int.Parse(indexs[i])].cantidadXML <= maxXML)
                {
                    listFact[int.Parse(indexs[i])].uuid = uuid;
                    switch (resul.Trim())
                    {
                        case "Vigente":
                            listFact[int.Parse(indexs[i])].DescripcionErrorSAT = "SAT : Vigente";
                            break;

                        case "Cancelado":
                            listFact[int.Parse(indexs[i])].DescripcionErrorSAT = "SAT : Cancelado";
                            listFact[int.Parse(indexs[i])].DescripcionErrorSAP = "N/A";
                            resulFacturaIncorrecta("SAT", indexs[i]);
                            break;

                        case "Sin estructura CFDI":
                            listFact[int.Parse(indexs[i])].DescripcionErrorSAT = "SAT : Estructura incorrecta";
                            listFact[int.Parse(indexs[i])].DescripcionErrorSAP = "N/A";
                            resulFacturaIncorrecta("SAT", indexs[i]);
                            break;

                        default:
                            listFact[int.Parse(indexs[i])].DescripcionErrorSAT = "SAT : " + resul;
                            break;
                    }
                }
                else
                {
                    listFact[int.Parse(indexs[i])].consola = "Limite de XML adjuntos alcanzado";
                }
            }

            
            
            
            
            switch (resul.Trim())
            {
                case "Vigente":
                    return true;

                case "Cancelado":
                    return false;

                case "Sin estructura CFDI":
                    return false;

                default:
                    return false;
            }

        }

        private bool validarSAP(ref string fecha_xml, ref string referencia, string impRetencion, string refer, ref bool inveref)
        {

            bool result = false;

            string idPRoveedor = Session["ProveedorLoged"].ToString();
            List<string[]> listaValidaciones = PNegocio.Facturas.obtenerListaValidacionesXML(idPRoveedor);

            List<PEntidades.FacturasXVerificar> listFact = new List<PEntidades.FacturasXVerificar>();
            listFact = (List<PEntidades.FacturasXVerificar>)Session["lstFacturas2"];

            for (int j = 0; j < indexs.Length; j++)
            {
                index = indexs[j];
                if (listFact[int.Parse(index)].cantidadXML <= maxXML)
                {
                    string folio = "";
                    string xmlString = this.xmlDoc.InnerXml.ToString();
                    //Comprobante comprobante = null;
                    //comprobante = (Comprobante)Serializer.FromXml(xmlString, typeof(Comprobante));
                    folio = "";
                    string emisor = "";// comprobante._Emisor.rfc;
                    string va_mon = "", val_impt = "", val_imps = "", val_iva = "", val_fec = "", serfol, folser, serie = "";
                    string moneda = "";
                    //decimal monto = comprobante.total;
                    string receptor = "";//comprobante.Receptor.rfc;
                    bool validarmir7 = false;
                    decimal importe = 0;
                    decimal importeiva = 0;
                    decimal importesub = 0;
                    decimal importedes = 0;
                    string mensajeval = "";
                    System.Xml.XmlNode ndComplemento;
                    ndComplemento = xmlDoc.GetElementsByTagName("cfdi:Complemento")[0];
                    if (ndComplemento != null)
                    {
                        ndComplemento = xmlDoc.GetElementsByTagName("tfd:TimbreFiscalDigital")[0];
                        try
                        {
                            listFact[int.Parse(index)].uuid = ndComplemento.Attributes["UUID"].Value;
                        }
                        catch (Exception){}
                    }
                    int indice = xmlDoc.ChildNodes.Count - 1;
                    try
                    {
                        for (int i = 0; i < xmlDoc.ChildNodes[indice].Attributes.Count; i++)
                        {
                            switch (xmlDoc.ChildNodes[indice].Attributes[i].Name)
                            {
                                case "Total":
                                case "total":
                                    importe = decimal.Round(Convert.ToDecimal(xmlDoc.ChildNodes[indice].Attributes[i].Value), 2);
                                    break;
                                case "subTotal":
                                case "SubTotal":
                                    importesub = decimal.Round(Convert.ToDecimal(xmlDoc.ChildNodes[indice].Attributes[i].Value), 2);
                                    break;
                                case "moneda":
                                case "Moneda":
                                    moneda = xmlDoc.ChildNodes[indice].Attributes[i].Value.ToUpper();
                                    break;
                                case "folio":
                                case "Folio":
                                    folio = xmlDoc.ChildNodes[indice].Attributes[i].Value;
                                    break;
                                case "serie":
                                case "Serie":
                                    serie = xmlDoc.ChildNodes[indice].Attributes[i].Value;
                                    break;
                                case "fecha":
                                case "Fecha":
                                    fecha_xml = Convert.ToDateTime(xmlDoc.ChildNodes[indice].Attributes[i].Value.Replace("T", " ")).ToString("yyyy-MM-dd");
                                    break;
                                case "descuento":
                                case "Descuento":
                                    importedes = TruncateDecimal(Convert.ToDecimal(xmlDoc.ChildNodes[indice].Attributes[i].Value), 2);
                                    break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        mensajeval = "Error al obtener Datos del XML<br/>";
                    }
                    
                    try
                    {
                        emisor = xmlDoc.ChildNodes[indice].ChildNodes[0].Attributes["rfc"].Value;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            emisor = xmlDoc.ChildNodes[indice].ChildNodes[0].Attributes["Rfc"].Value;
                        }
                        catch (Exception){}
                    }
                    try
                    {
                        receptor = xmlDoc.ChildNodes[indice].ChildNodes[1].Attributes["rfc"].Value;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            receptor = xmlDoc.ChildNodes[indice].ChildNodes[1].Attributes["Rfc"].Value;
                        }
                        catch (Exception) { }
                    }
                    int ind = 0;
                    if (xmlDoc.ChildNodes[indice].ChildNodes[3].Attributes.Count > 1 || xmlDoc.ChildNodes[indice].ChildNodes[3].ChildNodes.Count >1)
                    {
                        ind = 1;
                    }
                    try
                    {
                        importeiva = decimal.Round(Convert.ToDecimal(xmlDoc.ChildNodes[indice].ChildNodes[3].Attributes["totalImpuestosTrasladados"].Value), 2);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            importeiva = decimal.Round(Convert.ToDecimal(xmlDoc.ChildNodes[indice].ChildNodes[3].Attributes["TotalImpuestosTrasladados"].Value), 2);
                        }
                        catch (Exception)
                        {
                            if (xmlDoc.ChildNodes[indice].ChildNodes[3].ChildNodes[ind].LocalName == "Traslados")
                            {
                                for (int i = 0; i < xmlDoc.ChildNodes[indice].ChildNodes[3].ChildNodes[ind].ChildNodes.Count; i++)
                                {
                                    try
                                    {
                                        importeiva = importeiva + Convert.ToDecimal(xmlDoc.ChildNodes[indice].ChildNodes[3].ChildNodes[ind].ChildNodes[i].Attributes["importe"].Value);
                                    }
                                    catch (Exception)
                                    {
                                        try
                                        {
                                            importeiva = importeiva + Convert.ToDecimal(xmlDoc.ChildNodes[indice].ChildNodes[3].ChildNodes[ind].ChildNodes[i].Attributes["Importe"].Value);
                                        }
                                        catch (Exception) { }
                                    }
                                }
                            }
                        }
                    }
                    try
                    {
                        importe = importe + decimal.Round(Convert.ToDecimal(xmlDoc.ChildNodes[indice].ChildNodes[3].Attributes["totalImpuestosRetenidos"].Value), 2);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            importe = importe + decimal.Round(Convert.ToDecimal(xmlDoc.ChildNodes[indice].ChildNodes[3].Attributes["TotalImpuestosRetenidos"].Value), 2);
                        }
                        catch (Exception)
                        {
                            if (xmlDoc.ChildNodes[indice].ChildNodes[3].ChildNodes[ind].LocalName == "Retenciones")
                            {
                                for (int i = 0; i < xmlDoc.ChildNodes[indice].ChildNodes[3].ChildNodes[0].ChildNodes.Count; i++)
                                {
                                    try
                                    {
                                        importe = importe + Convert.ToDecimal(xmlDoc.ChildNodes[indice].ChildNodes[3].ChildNodes[0].ChildNodes[i].Attributes["importe"].Value);
                                    }
                                    catch (Exception)
                                    {
                                        try
                                        {
                                            importe = importe + Convert.ToDecimal(xmlDoc.ChildNodes[indice].ChildNodes[3].ChildNodes[0].ChildNodes[i].Attributes["Importe"].Value);
                                        }
                                        catch (Exception) { }
                                    }
                                }
                            }
                        }
                    }   
                    bool boolfolio = true;                    
                    serfol = serie + folio;
                    folser = folio + serie;
                    serfol = serfol.Replace("_", "").Replace("-", "");
                    folser = folser.Replace("_", "").Replace("-", "");
                    if (serfol != refer)
                    {
                        if (folser != refer)
                        {
                            mensajeval = mensajeval + "Referencia incorrecta : </br> XML: " + serfol + "</br>Factura: " + refer + "</br>";
                        }
                        else
                        {
                            inveref = true;
                            referencia = folser;
                        }
                    }
                    else
                    {
                        referencia = serfol;
                    }                    
                    if (listaValidaciones.Count <= 1)
                    {
                        listaValidaciones.Add(new string[] { "Moneda" });
                        listaValidaciones.Add(new string[] { "RFC Emisor" });
                        listaValidaciones.Add(new string[] { "Importe Total" });
                        listaValidaciones.Add(new string[] { "Importe IVA" });
                        listaValidaciones.Add(new string[] { "Sub Total" });
                        listaValidaciones.Add(new string[] { "Fecha Factura" });
                    }
                    if (listaValidaciones.Count > 1) // si contiene mas validaciones editadas por el administrador
                    {
                        for (int i = 1; i < listaValidaciones.Count; i++)
                        {
                            switch (listaValidaciones[i][0].Trim())
                            {
                                case "Moneda":
                                    validarmir7 = true;
                                    va_mon = "X";                                    
                                    break;
                                case "RFC Emisor":
                                    if (listFact[int.Parse(index)].RFCCorrespon.Trim() != emisor)
                                    {
                                        mensajeval = mensajeval + "El RFC emisor es incorrecto.</br>";
                                    }
                                    break;
                                //case "Monto":
                                //    if (listFact[int.Parse(index)].WRBTR.Trim() != decimal.Round(monto, 2).ToString())
                                //    {

                                //    }
                                //    break;
                                case "Importe Total":
                                    val_impt = "X";
                                    validarmir7 = true;                                    
                                    //if (String.IsNullOrEmpty(impRetencion) == false)
                                    //{
                                    //    importe = decimal.Round(importe + Convert.ToDecimal(impRetencion), 2);
                                    //}
                                    //importe = decimal.Round(comprobante.total + importe, 2);
                                    break;
                                case "Importe IVA":
                                    val_iva = "X";
                                    validarmir7 = true;
                                    //importeiva = decimal.Round(comprobante.Impuestos.totalImpuestosTrasladados, 2);
                                    break;
                                case "Sub Total":
                                    val_imps = "X";
                                    validarmir7 = true;
                                    //importesub = decimal.Round(comprobante.subTotal, 2);
                                    break;
                                case "Fecha Factura":
                                    val_fec = "X";
                                    validarmir7 = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (validarmir7)
                        {
                            verificarMir7(fecha_xml, listFact[int.Parse(index)].GJAHR.Trim(), importe, importeiva, importesub, moneda, listFact[int.Parse(index)].BELNR.Trim(), ref mensajeval, val_fec, val_impt, val_imps, val_iva, va_mon, importedes); //by jemo 15/
                        }
                    }

                    if (listFact[int.Parse(index)].RFCSociedad.Trim() != receptor)
                    {
                        mensajeval = mensajeval + "El RFC receptor es incorrecto.</br>";
                    }

                    //if (listFact[int.Parse(index)].RFCSociedad.Trim() != receptor && (String.IsNullOrEmpty(mensajeval) == false))
                    //{
                    //    mensajeval = mensajeval + "El RFC receptor no coincide con el de sociedad.</br>";
                    //}                

                    //if (folio.Equals(listFact[int.Parse(index)].XBLNR) // siempre valida al menos el folio
                    //    )
                    //{
                    //    boolfolio = true;
                    //}
                    //else {
                    //    boolfolio = false;
                    //}

                    if (String.IsNullOrEmpty(mensajeval) && boolfolio)
                    {
                        listFact[int.Parse(index)].DescripcionErrorSAP = "SAP : Cargada correctamente";
                        //resulFacturaCorrecta();
                        result = true;
                    }
                    else
                    {
                        listFact[int.Parse(index)].DescripcionErrorSAP = "SAP : Valores de XML no coinciden:</br>" + mensajeval;
                        resulFacturaIncorrecta("SAP", index);
                    }
                    //-----------<
                }
                else
                {
                    listFact[int.Parse(index)].consola = "Limite de XML adjuntos alcanzado";
                }

            }

            return result; // si alguno fue correcto pasara como true


        }
        public void verificarMir7(string fechafac, string año, decimal importe, decimal importeIVA, decimal importeSub, string moneda, string numerodoc, ref string mensaje, string val_fec, string val_impt, string val_imps, string val_iva, string val_mon, decimal importedesc)
        {
            PNegocio.FacturasNE nFac = new PNegocio.FacturasNE();
            List<string[]> listaDiferentesInstancias = new List<string[]>();
            listaDiferentesInstancias = (List<string[]>)Session["listaDiferentesInstancias"];
            string repuesta =
             nFac.validardatosMir7(listaDiferentesInstancias, fechafac, año, importe, importeIVA, importeSub, moneda, numerodoc, val_fec, val_impt, val_imps, val_iva, val_mon, importedesc);
            if (repuesta.Contains('N'))
            {
                mensaje = mensaje + "Error: no se pudo validar algunos datos en SAP.</br>";
            }
            else
            {
                if (repuesta.Contains('M'))
                {
                    mensaje = mensaje + "Tipo de moneda incorrecta.</br>";
                }
                if (repuesta.Contains('I'))
                {
                    mensaje = mensaje + "Importe total incorrecto.</br>";
                }
                if (repuesta.Contains('V'))
                {
                    mensaje = mensaje + "Importe IVA incorrecto.</br>";
                }
                if (repuesta.Contains('S'))
                {
                    mensaje = mensaje + "Importe subtotal incorrecto.</br>";
                }
                if (repuesta.Contains('F'))
                {
                    mensaje = mensaje + "Fecha de factura incorrecta.</br>";
                }
                if (repuesta.Contains('E'))
                {
                    mensaje = mensaje + "No existe moneda registrada en el sistema.</br>";
                }
            }
        }
        private decimal TruncateDecimal(decimal value, int precision)
        {
            decimal step = (decimal)Math.Pow(10, precision);
            int tmp = (int)Math.Truncate(step * value);
            return tmp / step;
        }
        protected string obtener_correo()
        {
            string usuario = HttpContext.Current.User.Identity.Name;
            PNegocio.CargarFactura cf = new PNegocio.CargarFactura();
            string sqlstring = "select email from usuario where usuarioLog = '" + usuario + "'";
            return cf.otener_correo(sqlstring);
        }
        protected string obtenerMaxXML()
        {
            PNegocio.CargarFactura cf = new PNegocio.CargarFactura();
            return cf.getMaxXML();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            cargar();
        }

        protected void Regresar_Click(object sender, EventArgs e)
        {

        }

        protected void btnLLenarTbs_Click(object sender, EventArgs e)
        {

        }

        public string formatCurrency(float input)
        {
            return input.ToString("C", CultureInfo.CurrentCulture);
        }
        public string formatCurrency(string input)
        {
            float temp = float.Parse(input);
            return temp.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}