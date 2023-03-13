using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNegocio
{
    public class Pagos
    {
        public Pagos()
        {
            
        }

        public string[] status = new string[0];

        public List<PEntidades.PAbiertasYPago> getPagos(string date1, string date2, List<string[]> listaDiferentesInstancias)
        {
            List<PEntidades.PAbiertasYPago> list = new List<PEntidades.PAbiertasYPago>();
            PEntidades.SrvSAPUProveedores.ZWS_UPROVEEDORESClient srv;
            status = new string[listaDiferentesInstancias.Count];
            for (int j = 0; j < listaDiferentesInstancias.Count; j++) // listaDiferentesInstancias contiene idInstacia, endpoint, y las sociedades separadas por "," ;  
            {
                try
                {
                    srv = new PPersistencia.WebServices().getZWS_UPROVEEDORESInstanceNew(
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

                    var resultado = srv.Z_UPAGOS(Gen.Util.CS.Gen.convertirFecha_SAP(date1), Gen.Util.CS.Gen.convertirFecha_SAP(date2), objLifnr, objetoSoc);
                    int cantidad = resultado.Count();
            
                    PEntidades.PAbiertasYPago objPabYPag;
                    for (int i = 0; i < cantidad; i++)
                    {
                        objPabYPag = new PEntidades.PAbiertasYPago();
                        string AUGBL = resultado.ElementAt(i).AUGBL.ToString();
                        string ZUONR = resultado.ElementAt(i).ZUONR.ToString();
                        string BELNR = resultado.ElementAt(i).BELNR.ToString();
                        string BLART = resultado.ElementAt(i).BLART.ToString();
                        string BLDAT = resultado.ElementAt(i).BLDAT.ToString();
                        float DMSHB = float.Parse(resultado.ElementAt(i).DMSHB.ToString());
                        string HWAER = resultado.ElementAt(i).HWAER.ToString();

                        string XBLNR = resultado.ElementAt(i).XBLNR.ToString();
                        string KONTO = resultado.ElementAt(i).KONTO.ToString();
                        string NAME1 = resultado.ElementAt(i).NAME1.ToString();
                        string SGTXT = resultado.ElementAt(i).SGTXT.ToString();
                        string EBELN = resultado.ElementAt(i).EBELN.ToString();

                        objPabYPag.AUGBL1 = AUGBL;
                        objPabYPag.ZUONR1 = ZUONR;
                        objPabYPag.BELNR1 = BELNR;
                        objPabYPag.BLART1 = BLART;
                        objPabYPag.BLDAT1 = BLDAT;
                        objPabYPag.DMSHB1 = DMSHB;
                        objPabYPag.HWAER1 = HWAER;

                        objPabYPag.XBLNR = XBLNR;
                        objPabYPag.KONTO = KONTO;
                        objPabYPag.NAME1 = NAME1;
                        objPabYPag.SGTXT = SGTXT;
                        objPabYPag.EBELN = EBELN;

                        objPabYPag.indice = i;

                        list.Add(objPabYPag);

                    }
                    srv.Close();

                }
                catch (Exception)
                {
                    status[j] = "Error al cargar en la instancia: " + listaDiferentesInstancias[j][6];
                }
            }

            return list;
        }
    }
}
