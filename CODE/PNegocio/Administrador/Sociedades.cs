//using PEntidades.SrvSAPResSociedades;
using PEntidades.SrvSAPUProveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PNegocio.Administrador
{
    public class Sociedades
    {
        public ZERES_SOCIEDADES[] ResSociedades(string endpoint, string[] userPass, string extranjero)
        {
            PEntidades.SrvSAPUProveedores.ZWS_UPROVEEDORESClient srv = new PPersistencia.WebServices().getZWS_UPROVEEDORESInstanceNew(
                    endpoint,
                    userPass
                    );
            srv.Open();
            ZERES_SOCIEDADES[] resul = null;
            resul = srv.Z_URES_SOCIEDADES(userPass[2], extranjero);
            srv.Close();
            return resul;
        }

        public string[] insertarSociedades(
            string proveedor_idProveedor, string detProveedor_lifnr, string bukrs, string idInstancia
            )
        {
            PPersistencia.ejecutaProcedures ejec = new PPersistencia.ejecutaProcedures();
            return ejec.ejcPsdEjectSociedad(proveedor_idProveedor, detProveedor_lifnr, bukrs, idInstancia);

        }
    }
}
