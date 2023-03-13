
using PEntidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Proveedores.portal
{
    public partial class PagosDet : System.Web.UI.Page
    {
        string index = "";
        private System.Xml.XmlDocument xmlDoc;
        string[] indexs;
        string[] indexs2;
        int maxXML = 10;
        string complementoMsgError = "";
        Pagos datosGlobal;

        string tablas = "";
        string[] datos;
        List<PEntidades.Pagos> lista = new List<PEntidades.Pagos>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Pagos p = new Pagos(Session["AUGBL1"].ToString());
            p.BELNR1 = Session["BLART1"].ToString();
            p.BUKRS = Session["BUKRS"].ToString();
            p.GJAHR = Session["GJAHR1"].ToString();
            lista.Add(p);

            for (int i = 0; i < lista.Count; i++)
            {
                string prue = lista[i].AUGBL1;
            }
            if (!IsPostBack)
            {
                tablas += "<br />";
                tablas += "<div class='form-group'><label>";
                tablas += "Clearing Document";
                tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                tablas += lista[0].AUGBL1;
                tablas += "'></div>";

                tablas += "<div class='form-group'><label>";
                tablas += "Nº Documento";
                tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                tablas += Session["BLART1"].ToString();
                tablas += "'></div>";

                tablas += "<div class='row'>";

                tablas += "<div class='form-group col-lg-6'><label>";
                tablas += "Sociedad";
                tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                tablas += Session["BUKRS"].ToString();
                tablas += "'></div>";

                tablas += "<div class='form-group col-lg-6'><label>";
                tablas += "Ejercicio";
                tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                tablas += Session["GJAHR1"].ToString();
                tablas += "'></div>";

                tablas += "</div>";

                tablas += "<div class='form-group'><label>";
                tablas += "Tipo de documento";
                tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                tablas += Session["BELNR1"].ToString();
                tablas += "'></div>";

                tablas += "<div class='form-group'><label>";
                tablas += "Fecha de Pago";
                tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                tablas += Session["BLDAT1"].ToString();
                tablas += "'></div>";

                tablas += "<div class='form-group'><label>";
                tablas += "Monto";
                tablas += "</label><input type='text' id='text1' class='form-control' readonly placeholder='";
                tablas += Session["monPago"].ToString();
                tablas += "'></div>";

                //tablas += "<table class='tblCV1'>";
                //tablas += "<tbody>";

                //tablas += "<tr>";
                //tablas += "<td>";
                //tablas += "Clearing Document";
                //tablas += "</td>";
                //tablas += "<td>";
                //tablas += lista[0].AUGBL1;
                //tablas += "</td>";
                //tablas += "</tr>";

                //tablas += "<tr>";
                //tablas += "<td>";
                //tablas += "Nº Documento";
                //tablas += "</td>";
                //tablas += "<td>";
                //tablas += Session["BLART1"].ToString();
                //tablas += "</td>";
                //tablas += "</tr>";

                //tablas += "<tr>";
                //tablas += "<td>";
                //tablas += "Ejercicio";
                //tablas += "</td>";
                //tablas += "<td>";
                //tablas += Session["GJAHR1"].ToString();
                //tablas += "</td>";
                //tablas += "</tr>";

                //tablas += "<tr>";
                //tablas += "<td>";
                //tablas += "Tipo de documento";
                //tablas += "</td>";
                //tablas += "<td>";
                //tablas += Session["BELNR1"].ToString();
                //tablas += "</td>";
                //tablas += "</tr>";

                //tablas += "<tr>";
                //tablas += "<td>";
                //tablas += "Fecha de Pago";
                //tablas += "</td>";
                //tablas += "<td>";
                //tablas += Session["BLDAT1"].ToString();
                //tablas += "</td>";
                //tablas += "</tr>";

                //tablas += "<tr>";
                //tablas += "<td>";
                //tablas += "Monto y moneda";
                //tablas += "</td>";
                //tablas += "<td>";
                //tablas += Session["monPago"].ToString();
                //tablas += "</td>";
                //tablas += "</tr>";

                //tablas += "</tbody>";
                //tablas += "</table>";
                this.ltlTablas.Text = tablas;

            }

            this.hidIndexs.Value = "0";
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

            indexs2 = new string[indexs.Length + 1];
            int iddetalle = int.Parse(indexs[0]) - 1;
            indexs2[0] = iddetalle.ToString();
            indexs.CopyTo(indexs2, 1);

            if (strIndex != "")
            {
                maxXML = int.Parse(obtenerMaxXML());
                this.File1.Visible = true;
                this.cargararchivo.Visible = true;
                //cargarDatosTabla(datosGlobal);
            }
            else
            {
                this.File1.Visible = false;
                this.cargararchivo.Visible = false;
            }

        }

        [WebMethod()]
        public void cargarDatosTabla(Pagos dataPagos)
        {
            string respuesta = "";

            Pagos datos = dataPagos;
            datosGlobal = datos;
            //return dataPagos.AUGBL1;

            List<PEntidades.FacturasXVerificar> listFact = new List<PEntidades.FacturasXVerificar>();
            listFact = (List<PEntidades.FacturasXVerificar>)Session["lstPagos2"];
            string consolas = "";
            string clase = "show";

            if (listFact.Count > 0)
            {
                indexs2 = new string[indexs.Length + 1];
                int iddetalle = int.Parse(indexs[0]) - 1;
                indexs2[0] = iddetalle.ToString();
                indexs.CopyTo(indexs2, 1);
                for (int i = 1; i < indexs2.Length; i++)
                {
                    consolas += "<label class='consola " + clase + "'>" + listFact[int.Parse(indexs2[i])].consola + "</label> ";
                }
            }

            this.lblConsola.Text = consolas;
        }

        public void prueba(string clgDocument, string numDocument, string tipoDocumento, string fechaPago, string montoMoneda, string ejercicio, string bukrs)
        {
            //datos = dato.Split(',');
            ////lista.Add(new PEntidades.Pagos(clgDocument));
            //lista.Add(new PEntidades.Pagos(numDocument));
            Pagos p = new Pagos(clgDocument);
            p.BELNR1 = tipoDocumento;
            p.GJAHR = ejercicio;
            lista.Add(p);

            Session["AUGBL1"] = lista[0].AUGBL1;
            Session["BLART1"] = numDocument;
            Session["BELNR1"] = tipoDocumento;
            Session["BLDAT1"] = fechaPago;
            Session["monPago"] = montoMoneda;
            Session["GJAHR1"] = ejercicio;
            Session["BUKRS"] = bukrs;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            cargar();
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

                        int fileLen;
                        fileLen = File2.PostedFile.ContentLength;
                        rawBytePDF = new Byte[fileLen];
                        File2.PostedFile.InputStream.Read(rawBytePDF, 0, fileLen);

                        List<PEntidades.FacturasXVerificar> listFact = new List<PEntidades.FacturasXVerificar>();
                        foreach (Pagos p in lista)
                        {
                            FacturasXVerificar fact = new FacturasXVerificar();
                            fact.BUKRS = p.BUKRS;
                            fact.BELNR = p.BELNR1;
                            fact.GJAHR = p.GJAHR;
                            listFact.Add(fact);
                        }
                        Session["lstPagos2"] = listFact;

                        List<string[]> listaDiferentesInstancias = (List<string[]>)Session["listaDiferentesInstancias"];

                        bool continuar = false;
                        if (tipoArchivo == "XML")
                        {
                            error = "1";
                            bool noValida = WebConfigurationManager.AppSettings["noValidaSat"].ToString().Equals("X");//SF RSG 09.02.2021
                            continuar = validarSAT(ref impRetencion, noValida);
                        }

                        if (continuar)
                        {
                            if (tipoArchivo == "XML")
                            {
                                error = "2";
                                continuar = validarSAP(ref fecha_xml, ref referencia, impRetencion, listFact[int.Parse(indexs[0])].XBLNR2, ref error, listFact[int.Parse(indexs[0])].BUKRS);
                            }

                            error = "3.0";
                            if (String.IsNullOrEmpty(impRetencion))
                            {
                                impRetencion = "0";
                            }
                            if (continuar)
                            {
                                PNegocio.CargarFactura cf = new PNegocio.CargarFactura();
                                for (int i = 0; i < indexs.Length; i++)
                                {
                                    if ((listFact[int.Parse(indexs[i])].DescripcionErrorSAP.Contains("SAP : Cargada correctamente") || tipoArchivo == "PDF") &&
                                        listFact[int.Parse(indexs[i])].cantidadXML <= maxXML)
                                    {
                                        int contadorres = 0;
                                        int indexInstanciaCorrespondiente = Gen.Util.CS.Gen.buscarIndexUbicacionInstanciaCorrres(listaDiferentesInstancias, listFact[int.Parse(indexs[i])].IDINSTANCIA);

                                        try
                                        {
                                            error = "3";
                                            if (tipoArchivo == "XML")   //ADD SF RSG 21.12.2022
                                                tipoArchivo = "XMP";
                                            if (tipoArchivo == "PDF")
                                                tipoArchivo = "PDP";
                                            if (listFact[int.Parse(indexs[i])].LIFNR == "" || listFact[int.Parse(indexs[i])].LIFNR == null)
                                                listFact[int.Parse(indexs[i])].LIFNR = listaDiferentesInstancias[0][3].ToString();
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
                                            ////listFact[int.Parse(indexs[i])].XBLNR2,referencia anterior
                                            "",//referencia,
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
                                                listFact[int.Parse(indexs[i])].consola = listFact[int.Parse(index)].DescripcionErrorSAP.Replace("SAP : ", "");
                                            }
                                            else
                                            {
                                                listFact[int.Parse(indexs[i])].consola = "SAP: Error al guardar el " + tipoArchivo;
                                                complementoMsgError += "SAP: Error al guardar el " + tipoArchivo;
                                            }
                                            if (i == 0)
                                            {
                                                listFact[int.Parse(indexs2[1])].consola = listFact[int.Parse(indexs[i])].consola;
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
                                    }
                                    else if (listFact[int.Parse(indexs[i])].cantidadXML > maxXML)
                                    {
                                        listFact[int.Parse(indexs[i])].consola = "Limite de archivos alcanzado";
                                    }
                                }

                                List<PEntidades.PAbiertasYPago> listPagos = new List<PEntidades.PAbiertasYPago>();
                                listPagos = (List<PAbiertasYPago>)Session["lstPagos"];
                                foreach (FacturasXVerificar f in listFact)
                                {
                                    foreach (PAbiertasYPago p in listPagos)
                                    {
                                        if (f.BUKRS == p.BUKRS && f.BELNR == p.BELNR1 && f.GJAHR == p.GJAHR)
                                        {
                                            p.ZCOUNT = p.ZCOUNT + 1;
                                            p.UUID = f.uuid;
                                        }
                                    }
                                }
                                Session["lstPagos"] = listPagos;
                                cargarDatosTabla(datosGlobal);

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
                                        if (i == 0)
                                        {
                                            listFact[int.Parse(indexs2[1])].consola = listFact[int.Parse(indexs[0])].DescripcionErrorSAP;
                                        }
                                    }
                                }
                                cargarDatosTabla(datosGlobal);
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
                                    if (i == 0)
                                    {
                                        listFact[int.Parse(indexs2[1])].consola = listFact[int.Parse(indexs[0])].DescripcionErrorSAP;
                                    }
                                }
                            }

                            cargarDatosTabla(lista[0]);
                        }

                    }
                    catch (Exception ex)
                    {
                        this.lblConsola.Text = "Error al cargar el archivo verifique que el XML este generado correctamente";
                        this.hidMessage.Value = "Error al cargar el archivo" + "(" + error + ")  " + ex.ToString();  // ADD SF RSG 09.04.2021
                    }
                }
                else
                {
                    string mesajeerr = "";
                    List<PEntidades.FacturasXVerificar> listFact = new List<PEntidades.FacturasXVerificar>();
                    listFact = (List<PEntidades.FacturasXVerificar>)Session["lstPagos2"];
                    if ((extXML == extencionValidaXML) == false)
                    {
                        mesajeerr += "El formato del campo de achivos XML es incorrecto.</br>";
                    }
                    if ((extPDF == extencionValidaPDF) == false)
                    {
                        mesajeerr += "El formato del campo de achivos PDF es incorrecto.</br>";
                    }

                    for (int i = 0; i < indexs.Length; i++)
                    {

                        listFact[int.Parse(indexs[i])].DescripcionErrorSAP = "N/A";
                        listFact[int.Parse(indexs[i])].DescripcionErrorSAT = mesajeerr; //No es XML
                        listFact[int.Parse(indexs[i])].consola = mesajeerr; //No es XML
                        if (i == 0)
                        {
                            listFact[int.Parse(indexs2[i])].consola = listFact[int.Parse(indexs[i])].consola;
                        }
                    }
                    cargarDatosTabla(datosGlobal);
                    this.hidMessage.Value = "Error al cargar el archivo" + "(" + error + ")  " + mesajeerr;  // ADD SF RSG 09.04.2021
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
                listFact = (List<PEntidades.FacturasXVerificar>)Session["lstPagos2"];
                for (int i = 0; i < indexs.Length; i++)
                {
                    listFact[int.Parse(indexs[i])].DescripcionErrorSAP = "N/A";
                    listFact[int.Parse(indexs[i])].DescripcionErrorSAT = mesajeerr; //No es XML
                    listFact[int.Parse(indexs[i])].consola = mesajeerr; //No es XML
                    if (i == 0)
                    {
                        listFact[int.Parse(indexs2[i])].consola = listFact[int.Parse(indexs[i])].consola;
                    }
                }
                cargarDatosTabla(datosGlobal);
                this.hidMessage.Value = "Error al cargar el archivo" + "(0)  " + mesajeerr;  // ADD SF RSG 09.04.2021
            }

        }

        private void resulFacturaIncorrecta(string ubicacion, string index)
        {
            List<PEntidades.FacturasXVerificar> listFact = new List<PEntidades.FacturasXVerificar>();
            listFact = (List<PEntidades.FacturasXVerificar>)Session["lstPagos2"];

            if (ubicacion.Equals("SAP"))
            {
                listFact[int.Parse(index)].consola = listFact[int.Parse(index)].DescripcionErrorSAP;
            }
            else
            {
                listFact[int.Parse(index)].consola = listFact[int.Parse(index)].DescripcionErrorSAT;
            }

        }

        private bool validarSAT(ref string impRetencion, bool nv)
        {
            PNegocio.ConsultaCFDI c = new PNegocio.ConsultaCFDI();
            string resul = c.esCorrectoCFDI(this.xmlDoc.InnerXml, nv);
            //resul = "Cancelado"; //TEST RSG 

            List<PEntidades.FacturasXVerificar> listFact = new List<PEntidades.FacturasXVerificar>();
            listFact = (List<PEntidades.FacturasXVerificar>)Session["lstPagos2"];
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
                if (i == 0)
                {
                    listFact[int.Parse(indexs2[1])].DescripcionErrorSAT = listFact[int.Parse(indexs[0])].DescripcionErrorSAT;
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

        private bool validarSAP(ref string fecha_xml, ref string referencia, string impRetencion, string refer, ref string error, string bukrs = "")
        {

            bool result = false;
            error = "2.1";
            string idPRoveedor = Session["ProveedorLoged"].ToString();
            List<string[]> listaValidaciones = PNegocio.Facturas.obtenerListaValidacionesXML(idPRoveedor);

            error = "2.1.1";
            List<PEntidades.FacturasXVerificar> listFact = new List<PEntidades.FacturasXVerificar>();
            listFact = (List<PEntidades.FacturasXVerificar>)Session["lstPagos2"];
            System.Xml.XmlNode ndNodos;

            error = "2.1.2";
            for (int j = 0; j < indexs.Length; j++)
            {
                index = indexs[j];
                error = "2.1.2_" + j;
                if (listFact[int.Parse(index)].cantidadXML <= maxXML)
                {
                    error = "2.1.2_" + j + ".1";
                    string folio = "";
                    string xmlString = this.xmlDoc.InnerXml.ToString();
                    error = "2.1.2_" + j + ".1.1";

                    error = "2.1.2_" + j + ".2";
                    ndNodos = xmlDoc.GetElementsByTagName("cfdi:Emisor")[0];
                    string emisor = ndNodos.Attributes["Rfc"].Value;
                    string va_mon = "", val_impt = "", val_imps = "", val_iva = "", val_fec = "";
                    string moneda = "";
                    decimal monto = Convert.ToDecimal(xmlDoc.LastChild.Attributes["Total"].Value);
                    error = "2.1.2_" + j + ".3";
                    ndNodos = xmlDoc.GetElementsByTagName("cfdi:Receptor")[0];
                    string receptor = ndNodos.Attributes["Rfc"].Value;
                    bool validarmir7 = false;
                    decimal importe = 0;
                    decimal importeiva = 0;
                    decimal importesub = 0;
                    decimal importedes = 0;
                    string version = "";    //ADD SF RSG 20.12.2022
                    try
                    {
                        importedes = TruncateDecimal(Convert.ToDecimal(xmlDoc.LastChild.Attributes["Descuento"].Value), 2);
                    }
                    catch (Exception)
                    {
                        importedes = 0;
                    }
                    System.Xml.XmlNode ndComplemento;
                    ndComplemento = xmlDoc.GetElementsByTagName("cfdi:Complemento")[0];
                    if (ndComplemento != null)
                    {
                        ndComplemento = xmlDoc.GetElementsByTagName("tfd:TimbreFiscalDigital")[0];
                        try
                        {
                            listFact[int.Parse(index)].uuid = ndComplemento.Attributes["UUID"].Value;
                        }
                        catch (Exception)
                        {
                        }
                    }
                    var total = xmlDoc.LastChild.Attributes["Total"].Value;
                    //----------->
                    string mensajeval = "";
                    string advertencia = "";
                    bool boolfolio = true;
                    fecha_xml = xmlDoc.LastChild.Attributes["Fecha"].Value.Substring(0, 10);
                    try
                    {
                        referencia = xmlDoc.LastChild.Attributes["Serie"].Value.ToUpper() + xmlDoc.LastChild.Attributes["Folio"].Value;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            referencia = xmlDoc.LastChild.Attributes["Serie"].Value.ToUpper();
                        }
                        catch (Exception)
                        {
                            try
                            {
                                referencia = xmlDoc.LastChild.Attributes["Folio"].Value;
                            }
                            catch (Exception)
                            {
                            }
                        }

                    }

                    error = "2.2";
                    referencia = referencia.Replace("_", "").Replace("-", "");
                    ////if (referencia != refer)
                    ////{
                    ////    advertencia = advertencia + "Las referencias son diferentes: </br> XML: " + referencia + "</br>Factura: " + refer + "</br>";
                    ////}
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
                                    try
                                    {
                                        version = xmlDoc.LastChild.Attributes["Version"].Value.ToUpper();
                                        if (version == "4.0")
                                            version = "pago20:Pago";
                                        else
                                            version = "pago10:Pago";
                                        moneda = xmlDoc.LastChild.Attributes["Moneda"].Value.ToUpper();
                                        foreach (System.Xml.XmlNode comp in xmlDoc.GetElementsByTagName("cfdi:Complemento"))
                                        {

                                            ndNodos = xmlDoc.GetElementsByTagName(version)[0];
                                            moneda = ndNodos.Attributes["MonedaP"].Value.ToUpper();
                                        }

                                    }
                                    catch (Exception)
                                    {
                                        mensajeval = mensajeval + "El archivo XML no cuenta con moneda. </br>";
                                    }

                                    break;
                                case "RFC Emisor":
                                    ////if (listFact[int.Parse(index)].RFCCorrespon.Trim() != emisor)
                                    ////{
                                    ////    mensajeval = mensajeval + "El RFC emisor es incorrecto.</br>";
                                    ////}
                                    break;
                                case "Importe Total":
                                    val_impt = "X";
                                    validarmir7 = true;
                                    if (String.IsNullOrEmpty(impRetencion) == false)
                                    {
                                        importe = Convert.ToDecimal(impRetencion);
                                    }
                                    try
                                    {
                                        version = xmlDoc.LastChild.Attributes["Version"].Value.ToUpper();
                                        if (version == "4.0")
                                            version = "MontoTotalPagos";
                                        else
                                            version = "Monto";

                                        foreach (System.Xml.XmlNode comp in xmlDoc.GetElementsByTagName("cfdi:Complemento"))
                                        {

                                            ndNodos = xmlDoc.GetElementsByTagName("cfdi:Complemento")[0];
                                            foreach (System.Xml.XmlNode pag in ndNodos.ChildNodes)
                                            {
                                                if (pag.InnerXml.Contains("Pagos"))
                                                {
                                                    //System.Xml.XmlNode tot = pag.FirstChild;
                                                    importe = decimal.Round(Convert.ToDecimal(pag.FirstChild.Attributes[version].Value), 2) + importe;
                                                    importesub = importe;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        break;
                                    }
                                    break;
                                case "Importe IVA":
                                    val_iva = "X";
                                    validarmir7 = true;
                                    try
                                    {
                                        for (int k = 0; k < xmlDoc.GetElementsByTagName("cfdi:Impuestos").Count; k++)
                                        {
                                            ndNodos = xmlDoc.GetElementsByTagName("cfdi:Impuestos")[k];
                                            if (ndNodos.Attributes.Count > 0)
                                            {
                                                importeiva = decimal.Round(Convert.ToDecimal(ndNodos.Attributes["TotalImpuestosTrasladados"].Value), 2);
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        importeiva = 0;
                                    }
                                    break;
                                case "Sub Total":
                                    val_imps = "X";
                                    validarmir7 = true;
                                    ////importesub = decimal.Round(Convert.ToDecimal(xmlDoc.LastChild.Attributes["SubTotal"].Value), 2);
                                    break;
                                case "Fecha Factura":
                                    val_fec = "X";
                                    validarmir7 = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                        error = "2.3";
                        if (validarmir7)
                        {
                            verificarMir7(fecha_xml, listFact[int.Parse(index)].GJAHR.Trim(), importe, importeiva, importesub, moneda, listFact[int.Parse(index)].BELNR.Trim(), ref mensajeval, ref advertencia, val_fec, val_impt, val_imps, val_iva, va_mon, importedes, bukrs); //by jemo 15/
                            error = "2.3";
                        }
                    }

                    error = "2.4";
                    //if (listFact[int.Parse(index)].RFCSociedad.Trim() != receptor)
                    //{
                    //    mensajeval = mensajeval + "El RFC receptor es incorrecto.</br>";
                    //}


                    error = "2.5";
                    if (String.IsNullOrEmpty(mensajeval) && boolfolio)
                    {
                        if (String.IsNullOrEmpty(advertencia) == false)
                        {
                            advertencia = "</br>Advertencia: " + advertencia;
                        }
                        listFact[int.Parse(index)].DescripcionErrorSAP = "SAP : Cargada correctamente" + advertencia;
                        result = true;
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(advertencia) == false)
                        {
                            advertencia = "Advertencia: " + advertencia;
                        }
                        listFact[int.Parse(index)].DescripcionErrorSAP = "SAP : Valores de XML no coinciden:</br>" + mensajeval + advertencia;
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
        public void verificarMir7(string fechafac, string año, decimal importe, decimal importeIVA, decimal importeSub, string moneda, string numerodoc, ref string mensaje, ref string advertencia, string val_fec, string val_impt, string val_imps, string val_iva, string val_mon, decimal importedesc, string bukrs = "")
        {
            PNegocio.FacturasNE nFac = new PNegocio.FacturasNE();
            List<string[]> listaDiferentesInstancias = new List<string[]>();
            listaDiferentesInstancias = (List<string[]>)Session["listaDiferentesInstancias"];
            string repuesta =
             nFac.validardatosMir7(listaDiferentesInstancias, fechafac, año, importe, importeIVA, importeSub, moneda, numerodoc, val_fec, val_impt, val_imps, val_iva, val_mon, importedesc, bukrs);
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
                    advertencia = advertencia + "Fecha diferente al sistema</br>";
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
    }
}