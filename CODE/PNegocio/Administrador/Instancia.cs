using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PNegocio.Administrador
{
    public class Instancia
    {
        public Instancia()
        {

        }

        public string guardarInstancia(string descripcion, string user, string password, string endpoint)
        {
              PPersistencia.ejecutaProcedures ejec = new PPersistencia.ejecutaProcedures();
              return ejec.ejcPsdInsertInstancia(descripcion, user, password, endpoint);
        }

        public string actualizarInstancia(string id, string descripcion, string user, string password, string endpoint)
        {
            PPersistencia.ejecutaProcedures ejec = new PPersistencia.ejecutaProcedures();
            return ejec.ejcPsdActualizaInstancia(id, descripcion, user, password, endpoint);
        }

        public string consultarInstancia()
        {
            PPersistencia.ejecutaProcedures ejec = new PPersistencia.ejecutaProcedures();
            List<string[]> resultado = ejec.ejcPsdConsultaInstancias();
            if (resultado.Count > 1)
            {
                List<int> listaEvitar = new List<int>();
                //return Gen.Util.CS.Gen.convertToHtmlTableDelete(resultado, "tableToOrder", "tblComun' style='width:90%;", listaEvitar, true, true, false, false, 0, 1);   //DELETE SF RSG 02.2023 V2.0  
                return Gen.Util.CS.Gen.convertToHtmlTableDelete(resultado, "tableToOrder", "table table-striped table-bordered' style='width:100%;", listaEvitar, true, true, false, false, 0, 1);  //ADD SF RSG 02.2023 V2.0
            }
            else {
                return "<strong>No se encontraron resultados para mostrar en la tabla</strong>";  
            }
            
        }

        public List<string[]> consultarInstanciaPorId(string sqlString)
        {
            PPersistencia.ejecutaProcedures ejec = new PPersistencia.ejecutaProcedures();
            List<string[]> resultado = ejec.ejcPsdConsulta(sqlString);
            return resultado;
        }

        public List<string[]> insertarRFCPorInstancia(string sqlString)
        {
            PPersistencia.ejecutaProcedures ejec = new PPersistencia.ejecutaProcedures();
            List<string[]> resultado = ejec.ejcPsdConsulta(sqlString);
            return resultado;
        }

        public List<string[]> consultarInstanciaArray()
        {
            PPersistencia.ejecutaProcedures ejec = new PPersistencia.ejecutaProcedures();
            return ejec.ejcPsdConsultaInstancias();
        }

        public static string RFCPorSociedad (string endpoint, string[] userPass, string sociedad)
        {
            PEntidades.SrvSAPUProveedores.ZWS_UPROVEEDORESClient srv = new PPersistencia.WebServices().getZWS_UPROVEEDORESInstanceNew(
                    endpoint,
                    userPass
                    );
            srv.Open();
            string resul = null;
            resul = srv.Z_URFC(sociedad);
            srv.Close();
            return resul;
        }
    }
    
}
