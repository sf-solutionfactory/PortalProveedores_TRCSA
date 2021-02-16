using PPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PNegocio
{
    public class CargarFactura
    {
        public string error = "";
        public int setFacturascargadasNew(string bukrs, string correo, string ebeln, string lifnr, string msjsap, string msgsat, string estatus, string tipo,
            string werks, string xblnr, string fecha_xml, string xmlfile, string endpoint, string[] userPass, byte[] raw, string uuid, decimal total,
            string numeroItem, string BELNR, string BWTAR, string KSCHL, string tipoarchivo, byte[] rawpdf, string pdffile, decimal retencion)
        {

            var result = "";
            int res = 0;
            PEntidades.SrvSAPUProveedores.ZWS_UPROVEEDORESClient srv = new PPersistencia.WebServices().getZWS_UPROVEEDORESInstanceNew(endpoint, userPass);
            srv.Open();
            srv.InnerChannel.OperationTimeout = new TimeSpan(0, 10, 0);
            result = srv.Z_UFAC_CARGADAS(BELNR, bukrs, BWTAR, correo, "", ebeln, numeroItem, fecha_xml, retencion, KSCHL, lifnr, msjsap, msgsat, pdffile, raw, rawpdf, estatus, tipo, tipoarchivo, null, werks, xblnr, xmlfile, uuid);
            srv.Close();
            if (result != "" && result != null)
            {
                try
                {
                    res = int.Parse(result.Trim());
                }
                catch (Exception)
                {
                    error = result.ToString().Trim();
                }
            }
            return res;
        }

        public int desvincular(List<string[]> listaDiferentesInstancias, string [] uuid)
        {
            PEntidades.SrvSAPUProveedores.ZEDATA_UUID[] objetoUui = PEntidades.Utiles.objetoUuid(uuid);
            string result = "";
            int res = 0;
            PEntidades.SrvSAPUProveedores.ZWS_UPROVEEDORESClient srv = new PPersistencia.WebServices().getZWS_UPROVEEDORESInstanceNew(
                    listaDiferentesInstancias[0][1].ToString().Trim(),
                    listaDiferentesInstancias[0][4].Split(new Char[] { ',' })
                    );            
            srv.Open();
            srv.InnerChannel.OperationTimeout = new TimeSpan(0, 10, 0);
            result = srv.Z_UFAC_CARGADAS("", "", "", "", "X", "", "", "", 0, "", "", "", "", "", null, null, "", "", "", objetoUui, "", "", "", "");
            srv.Close();
            if (result != "" && result != null)
            {
                res = int.Parse(result.Trim());
            }
            return res;
        }

        public string getMaxXML()
        {
            ejecutaProcedures ejecPd = new ejecutaProcedures();
            string[] res = ejecPd.ejcPsdMaxXML();
            return res[0];
        }

        public string otener_correo(string sqlstring)
        {
            ejecutaProcedures ejecPd = new ejecutaProcedures();
            string[] res = ejecPd.ejecCon(sqlstring);
            return res[0];
        }
    }
}
