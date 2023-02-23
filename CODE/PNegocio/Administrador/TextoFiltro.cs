using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PNegocio.Administrador
{
    public class TextoFiltro
    {
        

        public static string textoTablaFiltro() {
         return "<table class='filtro'>" +
                "<tr>" +
                "<td>Filtrar...</td>" +
                "<td><input id='searchTerm' type='text'></td>" + // "<td><input id='searchTerm' type='text' onkeyup='doSearch()' /></td>" +
                "</tr>" +
                "</table>";
        }

        public static string textoTablaFiltroSort()
        {
            //BEGIN OF DELETE SF RSG 02.2023 V2.0
            //return "<table class='filtro'>" +
            //       "<tr>" +
            //       "<td>Filtrar...</td>" +
            //       "<td><input id='searchTermSort' type='text'/></td>" + // "<td><input id='searchTerm' type='text' onkeyup='doSearchSorter()' /></td>" +
            //       "</tr>" +
            //       "</table>";
            //END   OF DELETE SF RSG 02.2023 V2.0
            //BEGIN OF INSERT SF RSG 02.2023 V2.0
            return "Filtrar...</span>" +
                   "<input id='searchTermSort' type='text' />";
            //END   OF INSERT SF RSG 02.2023 V2.0
        }

        public static string textoTablaFiltroSortMostrarNoticias()
        {
            return "<table class='filtro'>" +
                   "<tr>" +
                   "<td>Filtrar...</td>" +
                   "<td><input id='searchTermNoticia' type='text'/></td>" + //  "<td><input id='searchTermNoticia' type='text' onkeyup='doSearchSorterMostrarNoticia()' /></td>" +
                   "</tr>" +
                   "</table>";
        }
    }
}
