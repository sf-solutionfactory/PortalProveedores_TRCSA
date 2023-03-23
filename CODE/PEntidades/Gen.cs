using System;
using System.Collections.Generic;

namespace Gen.Util.CS
{
    public class Gen
    {
        /** Método que convierte un SQLReader a una Lista de arreglos de string List<string[]>
          *
          * 
          */
        public static List<string[]> SQLReaderToListArray(System.Data.SqlClient.SqlDataReader datRdr)
        {
            int tamCol = datRdr.FieldCount;
            string[] tupla = new string[tamCol];
            List<string[]> lstRes = new List<string[]>();

            System.Data.DataTable schemaTable = datRdr.GetSchemaTable();
            System.Data.DataRow datRow;
            for (int i = 0; i < schemaTable.Rows.Count; i++)
            {
                datRow = schemaTable.Rows[i];
                tupla[i] = "" + datRow[0];
            }
            lstRes.Add(tupla);

            while (datRdr.Read())
            {
                tupla = new string[tamCol];
                for (int i = 0; i < tamCol; i++)
                {
                    tupla[i] = datRdr[i].ToString();
                }
                lstRes.Add(tupla);
            }
            return lstRes;
        }

        public static string convertToHtmlTable(List<string[]> lista)
        {
            return Gen.convertToHtmlTable(lista, "", "");
        }

        public static string convertToHtmlTable(List<string[]> lista, string htmlId, string cssClass) // se utiliza solo para mostrar tabñas de la parte del usuario
        {
            string html = "";
            int tamcol = lista[0].Length;
            html += "<table id='" + htmlId + "' class='" + cssClass + "'>" +
                    "<thead>";
            html += "<tr>";
            for (int i = 0; i < tamcol; i++)
            {
                html += "<th>" + lista[0][i] + "</th>";
            }
            html += "</tr></thead>";
            html += "<tbody>";
            for (int i = 1; i < lista.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < tamcol; j++)
                {
                    html += "<td>" + lista[i][j] + "</td>";
                }
                html += "</tr>";
            }
            html += "</tbody>";
            html += "</table>";
            return html;
        }

        public static string convertToHtmlTableSort(List<string[]> lista, string htmlId, string cssClass)
        {
            string html = "";
            int tamcol = lista[0].Length;
            //html += "<table>";
            //html += "<tr><td>";

            html += "<ul id='" + htmlId + "' class='" + cssClass + "'>";
            for (int i = 1; i < lista.Count; i++)
            {
                html += "<li class='ui-state-default' class='moveIt'>";
                for (int j = 0; j < tamcol; j++)
                {
                    if (j == 0)
                    {
                        html += "<div class='idProv'>" + lista[i][j].Trim() + "</div>";
                        //html += " <br>";
                    }
                    else
                    {
                        html += " <br>";
                        html += "<div class='DivSort'>" + lista[i][j].Trim() + "</div>";
                        //html += " <br>";
                    }
                }
                html += "</li>";
            }
            html += "</ul>";
            //html += "</td>";
            //html += "</tr>";
            //html += "</table>";
            return html;
        }

        public static string convertToHtmlTableSort2(List<string[]> lista, string htmlId, string cssClass, int ocultarIzquierda)
        {
            string html = "";
            int tamcol = lista[0].Length;
            //html += "<table>";
            //html += "<tr><td>";

            html += "<ul id='" + htmlId + "' class='" + cssClass + "'>";
            for (int i = 1; i < lista.Count; i++)
            {
                html += "<li class='ui-state-default' class='moveIt'>";
                for (int j = 0; j < tamcol; j++)
                {
                    if (j == 0)
                    {
                        html += "<div class='idProv'>" + lista[i][j].Trim() + "</div>";
                        html += " <br>";
                    }
                    else
                    {
                        html += "<div class='DivSort'>" + lista[i][j].Trim() + "</div>";
                        html += " <br>";
                    }
                }
                html += "</li>";
            }
            html += "</ul>";
            //html += "</td>";
            //html += "</tr>";
            //html += "</table>";
            return html;
        }


        public static string convertToHtmlTableSortGrupoNoticia(List<string[]> lista, string htmlId, string cssClass, int evitarDerecha)
        {
            //evitarDerecha = 1;
            string html = "";
            int tamcol = lista[0].Length;
            html += "<table>";
            //html += "<tr><td><label class='tituloSortNum'>" + lista[0][0].Trim() + "</label><label class='tituloSort'>" + lista[0][1].Trim() + "</label></td></tr>";
            html += "<tr><td>";

            html += "<ul id='" + htmlId + "' class='" + cssClass + "'>";
            for (int i = 1; i < lista.Count; i++)
            {
                html += "<li class='ui-state-default' class='moveIt'>";
                for (int j = (0 + 0); j < tamcol-(evitarDerecha); j++)
                {
                    if (j == 0)
                    {
                        html += "<label class='idProv tHide' >" + lista[i][j].Trim() + "</label>";
                        html += " <br>";

                    }
                    else
                    {
                        if (j == 3 || j == 4)
                        { // cuando sean fechas,(en este caso de la tabla de noticias)
                            if (j == 3)
                            {
                                //html += "<center>";
                                html += "<label class='DivSort dateli'>" + convertirFechaBDaFormatoJq(lista[i][j].Trim()) + "</label>";
                            }
                            else
                            {
                                html += "<label class='DivSort dateli'>" + convertirFechaBDaFormatoJq(lista[i][j].Trim()) + "</label>";
                                //html += "</center>";
                                html += " <br>";
                                
                            }
                        }
                        else {
                            html += "<label class='DivSort'>" + lista[i][j].Trim() + "</label>";
                            html += " <br>";
                        }
                    }
                }
                html += "</li>";
            }
            html += "</ul>";
            html += "</td>";
            html += "</tr>";
            html += "</table>";
            return html;
        }

        public static string convertToHtmlTableDelete(List<string[]> lista, string htmlId, string cssClass, List<int> listaEvitar, bool modificable, bool activable, bool desechable, bool detalles, int colEvitarDer, int colEvitarIzq)
        {
            //int colEvitarIzq = 1;
            string html = "";
            int tamcol = lista[0].Length - colEvitarDer;
            //html += "<table id='" + htmlId + "' class='" + cssClass + "'>" +                              //DELETE SF RSG 02.2023 V2.0
            html += "<div class='table-responsive'><table id='" + htmlId + "' class='" + cssClass + "'>" +  //ADD SF RSG 02.2023 V2.0
                            "<thead>";
            html += "<tr>";
            for (int i = 0; i < tamcol; i++)
            {
                if (i < colEvitarIzq)
                {
                    html += "<th class='tHide'>" + lista[0][i] + "</th>";
                }
                else
                {
                    html += "<th>" + lista[0][i] + "</th>";
                }

            }
            if (activable || modificable || desechable || detalles)
            {
                html += "<th>Modificaciones</th>"; // agregar titulo de cambios para modificar, Activar/desactivar
            }

            //if (lista.Count > 1000) 
            //    lista.RemoveRange(1001,lista.Count-1002);   //-------------------------------QUITAR-----------------------------------------//
            html += "</tr></thead>";
            html += "<tbody>";
            for (int i = 1; i < lista.Count; i++)
            {
                string enviar = "";
                string estatus = "";
                //string ComplementoBoton = "Activar";  //DELETE SF RSG 02.2023 V2.0
                string ComplementoBoton = "<i id='btnActiDesacti' class='fa-solid fa-lock-open' style='color:#FFFFFF;' name='Activar'  title='Activar'></i>";  //ADD SF RSG 02.2023 V2.0
                html += "<tr>";
                for (int j = 0; j < tamcol; j++)
                {
                    if (tamcol - 1 == j) // esto es para tomar el ultimo registro, se pone el menos uno para tomar la ultima columna que es la que trae el estatus
                    {
                        estatus = lista[i][j];
                        if (lista[i][j] == "True")
                        {
                            //html += "<td>" + "Activo" + "</td>";                                           //DELETE SF RSG 02.2023 V2.0
                            html += "<td style='color:#00C279;font-weight: bold;'>" + "Activo" + "</td>";    //ADD SF RSG 02.2023 V2.0
                        }
                        else
                        {
                            if (activable) // si el activable quiere decir que trae informacion de bloqueo(esbloq)
                            {
                                //html += "<td>" + "Inactivo" + "</td>";                                        //DELETE SF RSG 02.2023 V2.0
                                html += "<td style='color:#E75353;font-weight: bold;'>" + "Inactivo" + "</td>"; //ADD SF RSG 02.2023 V2.0
                            }
                            else
                            {
                                html += "<td>" + lista[i][j] + "</td>"; // en caso de que no contenga el estatus se debe de mostrar el contenido
                            }
                        }
                    }
                    else
                    {
                        if (j < colEvitarIzq)
                        {
                            html += "<td class='tHide'>" + lista[i][j] + "</td>";
                        }
                        else
                        {
                            html += "<td>" + lista[i][j] + "</td>";
                        }

                    }
                }

                if (estatus == "True")
                {
                    //ComplementoBoton = "Desactivar";                                                                                                              //DELETE SF RSG 02.2023 V2.0
                    ComplementoBoton = "<i id='btnActiDesacti' class='fa-solid fa-lock' style='color:#FFFFFF;'name='Desactivar' title='Desactivar'></i>";    //ADD SF RSG 02.2023 V2.0
                }

                enviar = lista[i][0].ToString();

                bool revisar = true;
                if (listaEvitar.Count != 0)
                    revisar = false;
                if (!revisar)
                    if (!Gen.isIn(listaEvitar, enviar))
                        revisar = true;

                if (revisar) { 
                    if (activable || modificable || desechable || detalles)
                    {
                        html += "<td>";
                        html += "<center>";
                        if (activable)// si Activar
                        {
                            //html += "<label class='btn plusBtn'onclick='workThis(this);'>" + ComplementoBoton + "</label>";    //DELETE SF RSG 02.2023 V2.0
                            html += "<label id='btnActionActiDesacti' class='btn btn-warning' onclick='workThis(this);' title='Activar/Desactivar'>" + ComplementoBoton + "</label>";    //ADD SF RSG 02.2023 V2.0
                        }
                        if (modificable) // editar
                        {

                            //html += "<label class='btn plusBtn' onclick='workThis(this);'>Modificar</label>";    //DELETE SF RSG 02.2023 V2.0
                            html += "&nbsp<label id='btnActionModificar'class='btn btn-primary' onclick='workThis(this);'  title='Editar'><i id='btnModificar' class='fa-solid fa-pen-to-square' name='Modificar'></i></label>";    //ADD SF RSG 02.2023 V2.0
                        }
                        if (desechable) // eliminar
                        {
                            //html += "<label class='btn plusBtn' onclick='workThis(this);'>Eliminar</label>";    //DELETE SF RSG 02.2023 V2.0
                            html += "&nbsp<label class='btn btn-danger' onclick='workThis(this);' title='Eliminar'><i id='btnEliminar' class='fa-solid fa-trash' name='Eliminar'></i></label>";    //ADD SF RSG 02.2023 V2.0
                            if (detalles) // eliminar
                            {
                                //html += "<label class='btn plusBtn' onclick='workThis(this);'>Ver más</label>";    //DELETE SF RSG 02.2023 V2.0
                                html += "&nbsp<label class='btn btn-success' onclick='workThis(this);' title='Ver más información del usuario'><i id='btnVerMas' class='fa-solid fa-eye' name='Ver más'></i></label>";    //ADD SF RSG 02.2023 V2.0
                            }
                        }
                        html += "</center>";
                        html += "</td>";
                    }
                }
                else// si se encuentra en la lista sera imposible editar
                {
                    html += "<td>Imposible cambiar</td>";
                }
                html += "</tr>";
            }
            html += "</tbody>";
            //html += "</table>";           //DELETE SF RSG 02.2023 V2.0
            html += "</table></div>";       //ADD SF RSG 02.2023 V2.0
            return html;
        }

        public static string convertToHtmlTableDelete2(List<string[]> lista, string htmlId, string cssClass, List<int> listaEvitar, bool modificable, bool activable, bool desechable, bool detalles, int colEvitarDer, int colEvitarIzq, bool checkBox,  List<int> ListcheckBox)
        { 
            
            //int colEvitarIzq = 1;
            string html = "";
            int tamcol = lista[0].Length - colEvitarDer;
            //html += "<table id='" + htmlId + "' class='" + cssClass + "'>" +  //DELETE SF RSG 02.2023 v2.0
            html += "<div class='table-responsive'><table id='" + htmlId + "' class='" + cssClass + "'>" +  //ADD SF RSG 02.2023 v2.0
                     "<thead>";
            html += "<tr>";

            //bool checkBox = false;
            if(ListcheckBox.Count > 0){
                checkBox = true;  
            }

            ////
            if (checkBox == true) {
                //html += "<th class='tHide'>idCheck</th>";  
                html += "<th>Check</th>";  
            }
            ////

            for (int i = 0; i < tamcol; i++)
            {
                if (i < colEvitarIzq)
                {
                    html += "<th class='tHide'>" + lista[0][i] + "</th>"; // se agrega la clase de ocultar a la izquierda si es que se tiene considerado
                }
                else
                {
                    html += "<th>" + lista[0][i] + "</th>";
                }
            }
            if (activable || modificable || desechable || detalles)
            {
                html += "<th>Modificaciones</th>"; // agregar titulo de cambios para modificar, Activar/desactivar
            }

            html += "</tr></thead>";
            html += "<tbody>";
            for (int i = 1; i < lista.Count; i++)
            {
                string enviar = "";
                string estatus = "";
                string ComplementoBoton = "Activar";

                
                html += "<tr>";
                /////
                if (checkBox == true)
                {
                    //html += "<td class='tHide'>"+i+"</td>";
                    string isCheck = ""; 
                    for(int t = 0; t < ListcheckBox.Count; t++){
                        if (ListcheckBox[t] == i) {
                            isCheck = "checked"; 
                        }
                    }
                        //
                    html += "<td><input type='checkbox' class='chk' value='" + i + "' "+isCheck+"/></td>";
                }
                ////
                for (int j = 0; j < tamcol; j++)
                {
                    if (tamcol - 1 == j) // esto es para tomar el ultimo registro, se pone el menos uno para tomar la ultima columna que es la que trae el estatus
                    {
                        estatus = lista[i][j];
                        if (lista[i][j] == "True")
                        {
                            //html += "<td>" + "Activo" + "</td>";    //DELETE SF RSG 02.2023 V2.0
                            html += "<td style='color:#00C279; font-weight: bold;'>" + "Activo" + "</td>";    //ADD SF RSG 02.2023 V2.0
                        }
                        else
                        {
                            if (activable) // si el activable quiere decir que trae informacion de bloqueo(esbloq)
                            {
                                //html += "<td>" + "Inactivo" + "</td>";    //DELETE SF RSG 02.2023 V2.0
                                html += "<td style='color:#E75353; font-weight: bold;'>" + "Inactivo" + "</td>";    //ADD SF RSG 02.2023 V2.0
                            }
                            else
                            {
                                html += "<td>" + lista[i][j] + "</td>"; // en caso de que no contenga el estatus se debe de mostrar el contenido
                            }
                        }
                    }
                    else
                    {
                        if (j < colEvitarIzq)
                        {
                            html += "<td class='tHide'>" + lista[i][j] + "</td>";
                        }
                        else
                        {
                            html += "<td>" + lista[i][j] + "</td>";
                        }

                    }
                }

                if (estatus == "True")
                {
                    ComplementoBoton = "Desactivar";
                }

                enviar = lista[i][0].ToString();


                if (!Gen.isIn(listaEvitar, enviar))
                {
                    if (activable || modificable || desechable || detalles)
                    {
                        html += "<td>";
                        html += "<center>";
                        if (activable)// si Activar
                        {
                            html += "<label class='btn plusBtn'onclick='workThis(this);'>" + ComplementoBoton + "</label>";
                        }
                        if (modificable) // editar
                        {
                            html += "<label class='btn plusBtn' onclick='workThis(this);'>Modificar</label>";
                        }
                        if (desechable) // eliminar
                        {
                            html += "<label class='btn plusBtn' onclick='workThis(this);'>Eliminar</label>";
                        if (detalles) // eliminar
                        {
                            html += "<label class='btn plusBtn' onclick='workThis(this);'>Ver más</label>";
                        }
                        }
                        html += "</center>";
                        html += "</td>";
                    }
                }
                else// si se encuentra en la lista sera imposible editar
                {
                    html += "<td>Imposible cambiar</td>";
                }
                html += "</tr>";
            }
            html += "</tbody>";
            html += "</table></div>";    //MODIFY SF RSG 02.2023 V2.0
            return html;
        }

        public static bool isIn(List<int> listaEvitar, string id) {
            bool res = false;
            for(int i=0; i<listaEvitar.Count; i++ ){
                if (listaEvitar[i].ToString() == id)
                {
                    listaEvitar.Remove(i);
                    res = true;
                    break;
                }
            }
            return res;
        }

        public static string convertirFechaBDaFormatoJq(string fecha) {
            char[] delimiterChars = new char[1];
            delimiterChars[0] = ' ';
            string[] fechaS;
            fechaS = fecha.ToString().Split(delimiterChars);
            delimiterChars[0] = '/';
            fechaS = fechaS[0].ToString().Split(delimiterChars);
            fechaS[0] = fechaS[1] + "/" + fechaS[0] + "/" + fechaS[2];
            return fechaS[0].ToString();
        }

        public static string convertirFechaDesdeSesion(string date)
        {
            string[] split = date.Split(new Char[] { '/' });
            date = split[2] + "-" + split[0] + "-" + split[1];
            return date;
        }

        public static string convertirFecha(string date) // para SQL
        {
            string[] split = date.Split(new Char[] { '/' });
            if (split.Length==3)
            {
                //date = split[2] + "-" + split[1] + "-" + split[0];  // local
                date = split[2] + "-" + split[0] + "-" + split[1];  // ADN
                //año - dia - mes
            }
            return date;
        }


        public static string convertirFecha_SAP(string date) // para pasar a sap
        {
            string[] split = date.Split(new Char[] { '/' });
            if (split.Length == 3)
            {
                date = split[2] + "-" + split[1] + "-" + split[0];
            }
            return date;
        }

        public static List<string[]> sintetizaInfoConexiones(List<string[]> informacionImportante)
        {
            List<string[]> listaDiferentesInstancias = new List<string[]>();
            PNegocio.Encript encript = new PNegocio.Encript();

            if (informacionImportante.Count > 1)
            {
                string[] datosEndpoint = new string[7]; // idInstancia, endpoint
                datosEndpoint[0] = informacionImportante[1][3];
                datosEndpoint[1] = informacionImportante[1][4];
                datosEndpoint[2] = informacionImportante[1][0];
                datosEndpoint[3] = informacionImportante[1][5];
                //string desencript = encript.Desencriptar(encript.Desencriptar(informacionImportante[1][7].Trim()));
                datosEndpoint[4] = informacionImportante[1][6].Trim() + "," + informacionImportante[1][7].Trim();
                //datosEndpoint[4] = informacionImportante[1][6].Trim() + "," + encript.Desencriptar(encript.Desencriptar(informacionImportante[1][7].Trim()));
                datosEndpoint[5] = informacionImportante[1][8].Trim();
                datosEndpoint[6] = informacionImportante[1][9].Trim();
                listaDiferentesInstancias.Add(datosEndpoint);

                for (int i = 2; i < informacionImportante.Count; i++)
                {
                    if (informacionImportante[i][3] != listaDiferentesInstancias[listaDiferentesInstancias.Count - 1][0] ||
                        informacionImportante[i][4] != listaDiferentesInstancias[listaDiferentesInstancias.Count - 1][1]
                        )
                    { // primera vez que se encuentra
                        datosEndpoint = new string[7];
                        //instancias = "";
                        datosEndpoint[0] = informacionImportante[i][3];
                        datosEndpoint[1] = informacionImportante[i][4];
                        datosEndpoint[2] = informacionImportante[i][0];
                        datosEndpoint[3] = informacionImportante[i][5];
                        datosEndpoint[4] = informacionImportante[i][6].Trim() + "," + informacionImportante[i][7].Trim();
                        //datosEndpoint[4] = informacionImportante[i][6].Trim() + "," + encript.Desencriptar(encript.Desencriptar(informacionImportante[1][7].Trim()));
                        datosEndpoint[5] = informacionImportante[i][8].Trim();
                        datosEndpoint[6] = informacionImportante[i][9].Trim();
                        listaDiferentesInstancias.Add(datosEndpoint);
                    }
                    else // se concatenan los datos que nose repiten
                    {
                        datosEndpoint[2] += "," + informacionImportante[i][0];
                        datosEndpoint[3] += "," + informacionImportante[i][5];
                    }
                }



            }
            return listaDiferentesInstancias; 
        }

        public static int buscarIndexUbicacionInstanciaCorrres(List<string[]> listaDiferentesInstancias, int numeroBuscar)
        {
            int buscado = 0;
            for (int i = 0; i < listaDiferentesInstancias.Count; i ++ )
            {
                if (int.Parse(listaDiferentesInstancias[i][0]) == numeroBuscar)
                {
                    buscado = i;
                    break;
                }
            }
            return buscado;
        }

        //      BEGIN OF INSERT SF RSG 02.2023 V2.0     ------------------------    //
        public static string convertToHtmlTableDelete3(List<string[]> lista, string htmlId, string cssClass, List<int> listaEvitar, bool modificable, bool activable, bool desechable, bool detalles, int colEvitarDer, int colEvitarIzq)
        {
            //int colEvitarIzq = 1;
            string html = "";
            int tamcol = lista[0].Length - colEvitarDer;
            html += "<div class='table-responsive'><table id='" + htmlId + "' class='" + cssClass + "'>" + 
                            "<thead>";
            html += "<tr>";
            for (int i = 0; i < tamcol; i++)
            {
                if (i < colEvitarIzq)
                {
                    html += "<th class='tHide'>" + lista[0][i] + "</th>";
                }
                else
                {
                    html += "<th>" + lista[0][i] + "</th>";
                }

            }
            if (activable || modificable)
            {
                html += "<th>Modificaciones</th>"; // agregar titulo de cambios para modificar, Activar/desactivar
            }

            html += "</tr></thead>";
            html += "<tbody>";
            for (int i = 1; i < lista.Count; i++)
            {
                string enviar = "";
                string estatus = "";
                string ComplementoBoton = "<i id='btnActiDesacti' class='fa-solid fa-lock-open' style='color:#FFFFFF;' name='Activar'  title='Activar'></i>"; 
                html += "<tr>";
                html += "<td class='tHide'>" + lista[i][0] + "</td>";
                html += "<td>" + lista[i][1] + "</td>";
                html += "<td>" + lista[i][2] + "</td>";
                html += "<td>" + lista[i][3] + "</td>";
                html += "<td>" + lista[i][4] + "</td>";
                //for (int j = 1; j < tamcol - 1; j++)
                //{
                //    html += "<td>" + lista[i][j] + "</td>";
                //}

                estatus = lista[i][tamcol - 1];
                if (lista[i][tamcol - 1] == "True")
                {
                    html += "<td style='color:#00C279;font-weight: bold;'>" + "Activo" + "</td>";
                }
                else
                {
                    html += "<td style='color:#E75353;font-weight: bold;'>" + "Inactivo" + "</td>";
                }

                if (estatus == "True")
                {
                    ComplementoBoton = "<i id='btnActiDesacti' class='fa-solid fa-lock' style='color:#FFFFFF;'name='Desactivar' title='Desactivar'></i>"; 
                }

                enviar = lista[i][0].ToString();

                    if (activable || modificable)
                    {
                        html += "<td>";
                        html += "<center>";
                        if (activable)// si Activar
                        {
                            html += "<label id='btnActionActiDesacti' class='btn btn-warning' onclick='workThis(this);' title='Activar/Desactivar'>" + ComplementoBoton + "</label>"; 
                        }
                        if (modificable) // editar
                        {

                            html += "&nbsp<label id='btnActionModificar'class='btn btn-primary' onclick='workThis(this);'  title='Editar'><i id='btnModificar' class='fa-solid fa-pen-to-square' name='Modificar'></i></label>";   
                        }
                        html += "</center>";
                        html += "</td>";
                    }

                html += "</tr>";
            }
            html += "</tbody>";
            html += "</table></div>";     
            return html;
        }
        public static string convertToHtmlTableDelete4(List<string[]> lista, string htmlId, string cssClass, List<int> listaEvitar, bool modificable, bool activable, bool desechable, bool detalles, int colEvitarDer, int colEvitarIzq)
        {
            //int colEvitarIzq = 1;
            string html = "";
            int tamcol = lista[0].Length - colEvitarDer;
            html += "<table id='" + htmlId + "' class='" + cssClass + " display' width='100%;'></table>";
            html += "<script>";
            html += "var dataColumns = [";
            for (int i = 0; i < tamcol; i++)
            {
                html += "{ title: '" + lista[0][i] + "'} ,";
            }
            html.Remove(html.Length - 2, 1);
            if (activable || modificable)
            {
                html += "{title: 'Modificaciones'}"; // agregar titulo de cambios para modificar, Activar/desactivar
            }

            html += "];";
            html += "var dataSet = [";
            for (int i = 1; i < lista.Count; i++)
            {
                html += "[";
                html += "'" + lista[i][0] + "', ";
                html += "'" + lista[i][1] + "', ";
                html += "'" + lista[i][2] + "', ";
                html += "'" + lista[i][3] + "', ";
                html += "'" + lista[i][4] + "', ";
                html += "'" + lista[i][5] + "', ";

                if (activable)// si Activar
                    html += "'True' ";
                else
                    html += "'False' ";
                html += "], ";
            }

            html.Remove(html.Length - 2, 1);
            html += "];";

            html += "$(document).ready(function () {";
            html += "   $('#example').DataTable({";
            html += "       data:   dataSet,";
            html += "       columns: dataColumns";
            html += "   }); ";
            html += "});";

            html += "</script>";
            return html;
        }

        //      END   OF INSERT SF RSG 02.2023 V2.0     ------------------------    //
    }
}