using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PNegocio
{
    public class Usuario
    {

        public Usuario()
        {

        }

        public List<string[]> getSociedadesByUsuario(string idUsuario)
        {
            return new PPersistencia.ejecutaProcedures().ejcPsdConsultaSociedadesByIdUsuario(idUsuario);
        }

        public int[] getIdPantallasByIdRol(int idRol)
        {
            //return new PPersistencia.ejecutaProcedures().ejcPsdConsultaPantallaByIdRol(idRol);
            int[] temp = new PPersistencia.ejecutaProcedures().ejcPsdConsultaPantallaByIdRol(idRol);
            int[] ret = new int[temp.Length];
            if (temp.Contains(32))
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] == 32)
                        ret[i] = 7;
                    else
                        ret[i] = temp[i];
                }
            else
                ret = temp;

            Array.Sort(ret);
            return ret;
        }
    }
}
