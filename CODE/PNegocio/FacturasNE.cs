using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PEntidades.SrvSAPProveedores; /// no ZZZ

namespace PNegocio
{
    public class FacturasNE
    {
        public FacturasNE()
        {
        }

        public string[] status = new string[0];

        public List<PEntidades.FacturasXVerificar> getListFacturasNew( 
            List<string[]> listaDiferentesInstancias,
            string ordenarOrden,string ordenarRef,
            string fhigh, string flow,
            string facthig, string factlow,
            string monedahig, string monedalow,
            string refhig, string refLow, ref string mensaje
            //objetoSoc, "f hig", "f low", "fact hig", "fact low", "moneda hig", "moneda low", objLifnr, ordenarOrden, ordenarRef, "ref hig", "ref low"
            ) // informacion importante = u.sociedad_bukrs, u.RFC, u.lifnr, u.instancia, i.endpointAdd

        {
            //int contadorIntentos = 0;
            List<PEntidades.FacturasXVerificar> lstResul = new List<PEntidades.FacturasXVerificar>(); // objeto lista
            status = new string[listaDiferentesInstancias.Count];
            for (int j = 0; j < listaDiferentesInstancias.Count; j++) // listaDiferentesInstancias contiene idInstacia, endpoint, y las sociedades separadas por "," ;  
            {
                try
                {
                    PEntidades.SrvSAPUProveedores.ZWS_UPROVEEDORESClient srv = new PPersistencia.WebServices().getZWS_UPROVEEDORESInstanceNew(
                    listaDiferentesInstancias[j][1].ToString().Trim(),
                    listaDiferentesInstancias[j][4].Split(new Char[] { ',' })
                    );
                    
                    srv.Open();
                    srv.InnerChannel.OperationTimeout = new TimeSpan(0, 10, 0);
                    PEntidades.SrvSAPUProveedores.ZEPLANT_PROV[] objetoSoc;
                    PEntidades.SrvSAPUProveedores.ZELIFNR_PROV[] objLifnr;
                    string[] splitSoc = listaDiferentesInstancias[j][2].Split(new Char[] { ',' });
                    string[] splitLifnr = listaDiferentesInstancias[j][3].Split(new Char[] { ',' });

                    objetoSoc = PEntidades.Utiles.objetoSociedad(splitSoc);
                    objLifnr = PEntidades.Utiles.objetoLifnr(splitLifnr);
                    
                    var resul = srv.Z_UFAC_VERIFICAR(objetoSoc, fhigh, flow, facthig, factlow, monedahig, monedalow, objLifnr, "X", ordenarOrden, ordenarRef, refhig, refLow, out mensaje);
                    //contadorIntentos = 0;
                    //var resul = srv.Z_UFAC_VERIFICAR(objetoSoc, "f hig", "f loq", "fact hig", "fact low", "moneda hig", "moneda low", objLifnr, ordenarOrden, ordenarRef, "ref hig", "ref low");
                    for (int i = 0; i < resul.Length; i++)
                    {
                        PEntidades.FacturasXVerificar tmpFac = new PEntidades.FacturasXVerificar(); // objeto de la lista

                        tmpFac.IDINSTANCIA = int.Parse(listaDiferentesInstancias[j][0]);
                        tmpFac.TIPO = resul[i].TIPO;
                        tmpFac.EBELN = resul[i].EBELN;
                        //tmpFac.RFCCorrespon = listaDiferentesInstancias[j][5];
                        tmpFac.RFCCorrespon = resul[i].RFC_PROVEEDOR;
                        tmpFac.RFCSociedad = resul[i].RFC_SOC;
                        tmpFac.DescripcionErrorSAP = resul[i].FACT_SAP;
                        tmpFac.DescripcionErrorSAT = resul[i].FACT_SAT;
                        tmpFac.InsidenciaPersonal = resul[i].INCIDENCIA;
                        tmpFac.XBLNR2 = resul[i].XBLNR2;
                        tmpFac.LIFNR = resul[i].LIFNR;
                        tmpFac.BUKRS = resul[i].BUKRS;
                        tmpFac.WERKS = resul[i].WERKS.ToString();
                        tmpFac.BUDAT = resul[i].BUDAT;
                        tmpFac.BLDAT = resul[i].BLDAT;
                        tmpFac.WRBTR = resul[i].WRBTR.ToString();//Decimal
                         tmpFac.IVA = resul[i].IVA.ToString();
                        tmpFac.MWSKZ = resul[i].MWSKZ.ToString();//Decimal
                        tmpFac.IMP_TOTAL = resul[i].IMP_TOTAL.ToString();//Decimal
                        tmpFac.RETENCION = resul[i].RETENCION.ToString();//Decimal
                        tmpFac.WAERS = resul[i].WAERS.ToString();//Decimal
                        tmpFac.SALDO = resul[i].SALDO.ToString();
                        tmpFac.descMaterial = resul[i].TXZ01.ToString();
                        tmpFac.LIGHTS = resul[i].LIGHTS.ToString();
                        tmpFac.posicion = resul[i].POSICION.ToString();
                        tmpFac.tipoLinea = resul[i].TIPOLINEA.ToString();
                        tmpFac.BWTAR = resul[i].BWTAR.ToString();
                        tmpFac.cantidadXML = resul[i].ZCOUNT;
                        tmpFac.MATNR = resul[i].MATNR;
                        tmpFac.GJAHR = resul[i].GJAHR;
                        if (resul[i].KSCHL == null)
                        {
                            tmpFac.KSCHL = "";      
                        }
                        else
                        {
                            tmpFac.KSCHL = resul[i].KSCHL.ToString();   
                        }
                        
                        tmpFac.BELNR = resul[i].BELNR.ToString();
                        
                        if (resul[i].MSG_VARIOS == null)
                        {
                            tmpFac.msgVarios = ""; 
                        }
                        else
                        {
                            tmpFac.msgVarios = resul[i].MSG_VARIOS;
                        }

                        tmpFac.esPrimerCarga = false;
                        

                        lstResul.Add(tmpFac);
                    } // for result
                    srv.Close();

                } // try
                catch (Exception e)
                {
                    status[j] = "Error al cargar en la instancia: " + listaDiferentesInstancias[j][6];
                }

            } // for

            return lstResul;
        }
        
        /// <summary>
        /// Valida importe total, subtotal iva y moneda.
        /// </summary>
        /// <param name="listaDiferentesInstancias">endpoin, usuario y contraseña</param>
        /// <param name="fechafac">Fecha de factura</param>
        /// <param name="año">Año de documento</param>
        /// <param name="importe">Importe total</param>
        /// <param name="importeIVA">Importe de IVA</param>
        /// <param name="importeSub">Importe sin IVA</param>
        /// <param name="moneda">Tipo de Moneda</param>
        /// <param name="numerodoc">Numero de documento</param>
        /// <returns></returns>
        public string validardatosMir7(List<string[]> listaDiferentesInstancias, string fechafac, string año, decimal importe, decimal importeIVA, decimal importeSub, string moneda, string  numerodoc, string val_fec, string val_impt, string val_imps, string val_iva, string val_mon, decimal importedesc)
        {
            PEntidades.SrvSAPUProveedores.ZWS_UPROVEEDORESClient srv = new PPersistencia.WebServices().getZWS_UPROVEEDORESInstanceNew(
                    listaDiferentesInstancias[0][1].ToString().Trim(),
                    listaDiferentesInstancias[0][4].Split(new Char[] { ',' })
                    );
            
            srv.Open();
            srv.InnerChannel.OperationTimeout = new TimeSpan(0, 10, 0);
            string resul = null;
            resul = srv.Z_UFAC_VERIFMIR7(fechafac, año, importe, importeIVA, importeSub, importedesc, moneda, numerodoc, val_fec, val_impt, val_iva, val_imps, val_mon);
            srv.Close();
            return resul;
        }
    }
}
