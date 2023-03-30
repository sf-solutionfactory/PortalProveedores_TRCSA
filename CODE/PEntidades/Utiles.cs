using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PEntidades
{
    public class Utiles
    {
        public static PEntidades.SrvSAPUProveedores.ZELIFNR_PROV[] objetoLifnr(string[] lifnrs)
        {

            PEntidades.SrvSAPUProveedores.ZELIFNR_PROV[] Objlifnrs = new PEntidades.SrvSAPUProveedores.ZELIFNR_PROV[lifnrs.Length];// hace un objeto del tipo ZEPLANT_PROV 
            int cont = 0;
            foreach (string lifnr in lifnrs)
            {
                Objlifnrs[cont] = new PEntidades.SrvSAPUProveedores.ZELIFNR_PROV();
                Objlifnrs[cont].LIFNR = lifnr;
                cont++;
            }
            return Objlifnrs;
        }

        public static PEntidades.SrvSAPUProveedores.ZEPLANT_PROV[] objetoSociedad(string[] sociedades)
        {

            PEntidades.SrvSAPUProveedores.ZEPLANT_PROV[] bukrs = new PEntidades.SrvSAPUProveedores.ZEPLANT_PROV[sociedades.Length];// hace un objeto del tipo ZEPLANT_PROV 
            int cont = 0;
            foreach (string sociedad in sociedades)
            {
                bukrs[cont] = new PEntidades.SrvSAPUProveedores.ZEPLANT_PROV();
                bukrs[cont].WERKS = sociedad;
                cont++;
            }
            return bukrs;
        }

        public static PEntidades.SrvSAPUProveedores.ZEDATA_UUID[] objetoUuid(string[] uuid)
        {

            PEntidades.SrvSAPUProveedores.ZEDATA_UUID[] uuid_xml = new PEntidades.SrvSAPUProveedores.ZEDATA_UUID[uuid.Length];// hace un objeto del tipo ZEPLANT_PROV 
            int cont = 0;
            foreach (string uui in uuid)
            {
                uuid_xml[cont] = new PEntidades.SrvSAPUProveedores.ZEDATA_UUID();
                uuid_xml[cont].UUID_XML = uui;
                cont++;
            }
            return uuid_xml;
        }

        public static List<PAbiertasYPago> ordenarListaPagos(List<PAbiertasYPago> lista, string mode)
        {
            switch (mode)
            {
                case "Clearing Document":
                    lista.Sort(delegate(PAbiertasYPago x, PAbiertasYPago y) // Sort funciona de acuerdo a resultados enteros, si es 0 termina, si es -1 continua comparando con los siguientes, si es -1 regresa a comparar los resultados que fueron guardados anteriormente para acoodarlo, cuando vuelve a ser 1, regresa donde se quedo 
                    {
                        if (x.AUGBL1 == null && y.AUGBL1 == null) return 0;
                        else if (x.AUGBL1 == null) return -1;
                        else if (y.AUGBL1 == null) return 1;
                        else
                        {
                            int compar = x.AUGBL1.CompareTo(y.AUGBL1);
                            return compar;
                        }
                    });
                    break;
                case "Nº documento":
                    lista.Sort(delegate(PAbiertasYPago x, PAbiertasYPago y) // Sort funciona de acuerdo a resultados enteros, si es 0 termina, si es -1 continua comparando con los siguientes, si es -1 regresa a comparar los resultados que fueron guardados anteriormente para acoodarlo, cuando vuelve a ser 1, regresa donde se quedo 
                    {
                        if (x.BELNR1 == null && y.BELNR1 == null) return 0;
                        else if (x.BELNR1 == null) return -1;
                        else if (y.BELNR1 == null) return 1;
                        else
                        {
                            int compar = x.BELNR1.CompareTo(y.BELNR1);
                            return compar;
                        }
                    });
                    break;
                case "Tipo de documento":
                    lista.Sort(delegate(PAbiertasYPago x, PAbiertasYPago y) // Sort funciona de acuerdo a resultados enteros, si es 0 termina, si es -1 continua comparando con los siguientes, si es -1 regresa a comparar los resultados que fueron guardados anteriormente para acoodarlo, cuando vuelve a ser 1, regresa donde se quedo 
                    {
                        if (x.BLART1 == null && y.BLART1 == null) return 0;
                        else if (x.BLART1 == null) return -1;
                        else if (y.BLART1 == null) return 1;
                        else
                        {
                            int compar = x.BLART1.CompareTo(y.BLART1);
                            return compar;
                        }
                    });
                    break;
                case "Fecha de pago":
                    lista.Sort(delegate(PAbiertasYPago x, PAbiertasYPago y) // Sort funciona de acuerdo a resultados enteros, si es 0 termina, si es -1 continua comparando con los siguientes, si es -1 regresa a comparar los resultados que fueron guardados anteriormente para acoodarlo, cuando vuelve a ser 1, regresa donde se quedo 
                    {
                        if (x.BLDAT1 == null && y.BLDAT1 == null) return 0;
                        else if (x.BLDAT1 == null) return -1;
                        else if (y.BLDAT1 == null) return 1;
                        else
                        {
                            int compar = x.BLDAT1.CompareTo(y.BLDAT1);
                            return compar;
                        }
                    });
                    break;
                case "Monto":
                    lista.Sort(delegate(PAbiertasYPago x, PAbiertasYPago y) // Sort funciona de acuerdo a resultados enteros, si es 0 termina, si es -1 continua comparando con los siguientes, si es -1 regresa a comparar los resultados que fueron guardados anteriormente para acoodarlo, cuando vuelve a ser 1, regresa donde se quedo 
                    {
                        //if (x.DMSHB1 == null && y.DMSHB1 == null) return 0;
                        //else if (x.DMSHB1 == null) return -1;
                        //else if (y.DMSHB1 == null) return 1;
                        //else
                        //{
                            int compar = x.DMSHB1.CompareTo(y.DMSHB1);
                            return compar;
                        //}
                    });
                    break;
                case "Moneda":
                    lista.Sort(delegate(PAbiertasYPago x, PAbiertasYPago y) // Sort funciona de acuerdo a resultados enteros, si es 0 termina, si es -1 continua comparando con los siguientes, si es -1 regresa a comparar los resultados que fueron guardados anteriormente para acoodarlo, cuando vuelve a ser 1, regresa donde se quedo 
                    {
                        if (x.HWAER1 == null && y.HWAER1 == null) return 0;
                        else if (x.HWAER1 == null) return -1;
                        else if (y.HWAER1 == null) return 1;
                        else
                        {
                            int compar = x.HWAER1.CompareTo(y.HWAER1);
                            return compar;
                        }
                    });
                    break;
                case "Nº asignacion":
                    lista.Sort(delegate(PAbiertasYPago x, PAbiertasYPago y) // Sort funciona de acuerdo a resultados enteros, si es 0 termina, si es -1 continua comparando con los siguientes, si es -1 regresa a comparar los resultados que fueron guardados anteriormente para acoodarlo, cuando vuelve a ser 1, regresa donde se quedo 
                    {
                        if (x.ZUONR1 == null && y.ZUONR1 == null) return 0;
                        else if (x.ZUONR1 == null) return -1;
                        else if (y.ZUONR1 == null) return 1;
                        else
                        {
                            int compar = x.ZUONR1.CompareTo(y.ZUONR1);
                            return compar;
                        }
                    });
                    break;
                    
                default:
                    break;
                
            }
            return lista;
        }

        public static List<ArrTablas> getTablasbyLetras(List<string []> tabla, string tipo)
        {
            List<ArrTablas> tablas = new List<ArrTablas>();
            List<string[]> tab = new List<string[]>();
            tab.Add(tabla[0]);
            string[] r_letras = { "0|1|2|3|4|5|6|7|8|9", "a|A", "b|B", "c|C", "d|D", "e|E", "f|F", "g|G", "h|H", "i|I", "j|J", "k|K", "l|L", "m|M", "n|N", "ñ|Ñ", "o|O", "p|P", "q|Q", "r|R", "s|S", "t|T", "u|U", "v|V", "w|W", "x|X", "y|Y", "z|Z", "Otros"};
            int cont = 0;
            string valor = "";
            bool otros = false;
            Regex r = new Regex(r_letras[0]);
            if (tabla.Count > 1)
            {
                for (int i = 1; i < tabla.Count; i++)
                {
                    if (otros)
                    {
                        tab.Add(tabla[i]);
                    }
                    else
                    {
                        if (tipo.Equals("tab"))
                        {
                            valor = tabla[i][1].Substring(0, 1);
                        }
                        else if (tipo.Equals("div"))
                        {
                            valor = tabla[i][2].Substring(0, 1);
                        }
                        if (r.IsMatch(valor))
                        {
                            tab.Add(tabla[i]);
                        }
                        else
                        {
                            tablas.Add(new ArrTablas(tab, r_letras[cont]));
                            tab = new List<string[]>();
                            tab.Add(tabla[0]);
                            cont++;
                            if (cont <= (r_letras.Length - 2))
                            {
                                r = new Regex(r_letras[cont]);
                            }
                            if (cont == (r_letras.Length-1))
                            {
                                otros = true;
                            }
                            i--;
                        }
                    }
                }
                tablas.Add(new ArrTablas(tab, r_letras[cont]));
                cont++;
                if (cont<(r_letras.Length))
                {
                    tab = new List<string[]>();
                    tab.Add(tabla[0]);
                    for (int i = cont; i < r_letras.Length; i++)
                    {
                        tablas.Add(new ArrTablas(tab, r_letras[i]));
                    }
                }
            }
            else
            {
                for (int i = 0; i < r_letras.Length; i++)
                {
                    tablas.Add(new ArrTablas(tabla, r_letras[cont]));
                }
                
            }
            return tablas;
        }
    }

}
