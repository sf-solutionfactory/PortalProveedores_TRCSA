﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace PNegocio
{
    
    public class ConsultaCFDI
    {
        public ConsultaCFDI()
        {
        }

        public string esCorrectoCFDI(string innerXML, bool nv)  //MODIFY SF RSG 02.2023 v2.0
        {
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.InnerXml = innerXML;
            System.Xml.XmlNode ndEmisor;
            System.Xml.XmlNode ndReceptor;
            System.Xml.XmlNode ndComprobante;
            System.Xml.XmlNode ndComplemento;
            string re, rr, tt, id, cdn;
            re = rr = tt = id = cdn = "";
            try
            {
                ndEmisor = xmlDoc.GetElementsByTagName("cfdi:Emisor")[0];
                ndReceptor = xmlDoc.GetElementsByTagName("cfdi:Receptor")[0];
                ndComprobante = xmlDoc.GetElementsByTagName("cfdi:Comprobante")[0];
                ndComplemento = xmlDoc.GetElementsByTagName("cfdi:Complemento")[0];
                if (ndComplemento != null)
                {
                    ndComplemento = xmlDoc.GetElementsByTagName("tfd:TimbreFiscalDigital")[0];
                    try
                    {
                        id = ndComplemento.Attributes["UUID"].Value;
                    }
                    catch (Exception)
                    {
                    }

                }
                try
                {
                    re = ndEmisor.Attributes["rfc"].Value;
                    rr = ndReceptor.Attributes["rfc"].Value;
                    tt = ndComprobante.Attributes["total"].Value;

                    cdn = "?re=" + re
                                + "&rr=" + rr
                                + "&tt=" + tt
                                + "&id=" + id;
                }
                catch (Exception)
                {
                    try
                    {
                        re = ndEmisor.Attributes["Rfc"].Value;
                        rr = ndReceptor.Attributes["Rfc"].Value;
                        tt = ndComprobante.Attributes["Total"].Value;

                        cdn = "?re=" + re
                                    + "&rr=" + rr
                                    + "&tt=" + tt
                                    + "&id=" + id;
                    }
                    catch (Exception)
                    {
                        return "Sin estructura CFDI";//Estructura mala
                    }
                }                
            }
            catch (Exception)
            {
                return "Sin estructura CFDI";//Estructura mala
            }

            // BEGIN MODIFY SF RSG 02.2023 v2.0
            if (!nv)
            {
                PEntidades.SrvSATConsultaCFDI.ValidarCFDI srv = new PEntidades.SrvSATConsultaCFDI.ValidarCFDI();
                PEntidades.SrvSATConsultaCFDI.MiAcuse acuse = srv.esValidoCFDI(cdn);
                return acuse.Estado;
            }
            else
            {
                return "Vigente";
            }
            // END MODIFY SF RSG 02.2023 v2.0
        }
    }
}
