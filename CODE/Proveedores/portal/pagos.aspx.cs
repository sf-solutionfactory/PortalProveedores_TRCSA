﻿
using PEntidades;
using PNegocio;
using Proveedores.portal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Proveedores
{
    public partial class pagos : System.Web.UI.Page
    {
        int indice = -2;
        bool btnbuscar = false;
        string cont = "";
        public static List<string[]> listaDiferentesInstanciasg;

        protected void Page_Load(object sender, EventArgs e)
        {


            this.btnToOrder.BorderStyle = BorderStyle.None;
            this.btnToOrder.BackColor = Color.Transparent;

            int n_instancias = 0;

            if (this.hidCerrarSesion.Value != "cerrar")
            {
                //this.btnActualiza.BorderStyle = BorderStyle.None; //DELETE SF RSG 02.2023 v2.0
                //this.btnActualiza.Visible = false;                //DELETE SF RSG 02.2023 v2.0
                this.btnActualizaX.BorderStyle = BorderStyle.None;
                //INICIO Permiso de ver esta pantalla
            bool permiso = false;
            try
            {
                int[] idPantallas = (int[])Session["Pantallas"];
                for (int i = 0; i < idPantallas.Length; i++)
                {
                    if (idPantallas[i] == 4)
                    {
                        permiso = true;
                        break;
                    }

                }
                if (permiso == false)
                {
                    cerrarSesion();
                }

            }
            catch (Exception)
            {
                cerrarSesion();
            }

            indice = -2;

            if (btnbuscar == false)
            {
                try 
                    {
                    indice = int.Parse(Request.QueryString["index"]);
                    cont = Request.QueryString["cont"];
                }
                catch (Exception)
                {
                }
            }
 
            if (this.datepicker.Text != "" && this.datepicker2.Text != "")
            {
                Session["fecha1"] = this.datepicker.Text;
                Session["fecha2"] = this.datepicker2.Text;
            }

            this.lblExpandirTodo.Text = "<a href='pagos.aspx?index=-3&cont=et'><div class='ico-expandir_Todo' title='Expandir todo'></div></a>";
            this.lblContraerTodo.Text = "<a href='pagos.aspx?index=-4&cont=ct'><div class='ico-contraer_Todo' title='Contraer todo'></div></a>";
            PNegocio.Pagos res = new PNegocio.Pagos();  //MODIFY SF RSG 02.2023 v2.0
            List<PAbiertasYPago> lstPag = null;
            try
            {
                try
                {
                        if (this.hidActualiza.Value != "actualiza")
                        {
                                lstPag = (List<PAbiertasYPago>)Session["lstPagos"];
                        }
                }
                catch (Exception)
                {
                    
                }
                if (lstPag == null || lstPag.Count <= 0)
                {
                    List<string[]> listaDiferentesInstancias = (List<string[]>)Session["listaDiferentesInstancias"];
                    listaDiferentesInstanciasg = listaDiferentesInstancias; //ADD SF RSG 02.2023 v2.0
                    n_instancias = listaDiferentesInstancias.Count;
                    string fecha1 = Session["fecha1"].ToString();
                    lstPag = res.getPagos(fecha1, Session["fecha2"].ToString(), listaDiferentesInstancias);

                    Session["lstPagos"] = lstPag;
                }
            }
            catch (Exception)
            {
                this.lblTabla.Text = "<h3>Ocurrio un error al obtener los datos<h3>";
            }

            if (lstPag.Count > 0)
                {
                    ConvertTittles conv = new ConvertTittles();

                    if (this.hidHeader.Value != "")
                    {
                        List<PAbiertasYPago> list = null;
                        List<PAbiertasYPago> lstPag2 = null;
                        list = eliminarRE(lstPag);
                        list = Utiles.ordenarListaPagos(list, this.hidHeader.Value.ToString().Trim());
                        lstPag2 = rellenarRE(list, lstPag);
                        if (this.modoOrdenar.Value.ToString().Trim() == "desc")
                        {
                            lstPag2 = ordenarReversa(lstPag2);
                            this.modoOrdenar.Value = "asc";
                        }
                        else
                        {
                            this.modoOrdenar.Value = "desc";
                        }
                        lstPag = lstPag2;
                        //lstPag = lstPag2;
                        Session["lstPagos"] = lstPag;
                    }
                    this.lblTabla.Text = conv.convertListPAbiertasToTableInCode(lstPag, indice, cont, "tableToOrder");
                    //this.btnActualiza.Visible = true; //DELETE SF RSG 02.2023 v2.0
                }
                else
                {
                    string[] status = res.status;
                    this.lblTabla.Text = "<br/><br/><h3>No se encontraron datos<h3>";
                    if (status.Length > 0)
                    {
                        for (int i = 0; i < status.Length; i++)
                        {
                            if (status[i] != "" && status[i] != null)
                            {
                                this.lblTabla.Text += "<br/><h3>" + status[i] + "</h3>";   
                            }                          
                        }
                        this.lblTabla.Text += "<br/><h3>" + "Se recomienda intentar utilizando los campos de fecha" + "</h3>";
                    }
                    if (n_instancias <= 0)
                    {
                        this.lblTabla.Text = "<br/><br/><br/><h3>" + "Este usuario no tiene sociedades activas, por lo que no puede obtener datos" + "</h3>";
                    }

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showFiltros()", true); //ADD SF RSG 02.2023 V2.0  
                }
  
            btnbuscar = false;
            }



        }


        [System.Web.Services.WebMethod]
        public static string cargarDatos(String clgDocument, String numDocument, String tipoDocumento, String fechaPago, String montoMoneda, String ejercicio, String bukrs)
        {
            //List<PEntidades.Pagos> lista = new List<PEntidades.Pagos>();
            //lista.Add(new PEntidades.Pagos(clgDocument));
            //lista.Add(new PEntidades.Pagos(numDocument));
            PagosDet pagos = new PagosDet();

            pagos.prueba(clgDocument, numDocument, tipoDocumento, fechaPago, montoMoneda, ejercicio, bukrs);
            return clgDocument;
        }
        private List<PAbiertasYPago> eliminarRE(List<PAbiertasYPago> lista)
        {
            List<PAbiertasYPago> list = new List<PAbiertasYPago>();
            for (int i = 0; i < lista.Count; i++)
            {
                //PAbiertasYPago obj = null;

                if (lista[i].BLART1 == "KZ")
                {
                    list.Add(lista[i]);   
                }

            }
            return list;
        }

        private List<PAbiertasYPago> ordenarReversa(List<PAbiertasYPago> listOrdenada)
        {
            List<PAbiertasYPago> list = new List<PAbiertasYPago>();
            for (int i = listOrdenada.Count-1; i >= 0; i--)
            {

                if (listOrdenada[i].BLART1 == "KZ")
                {
                    list.Add(listOrdenada[i]);
                    int j = i+1;
                    try
                    {

                        while (listOrdenada[j].BLART1 != "KZ")
                        {
                            if (j < listOrdenada.Count)
                            {
                                list.Add(listOrdenada[j]);
                                j++;
                            }

                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return list;
        }

        private List<PAbiertasYPago> rellenarRE(List<PAbiertasYPago> listOrdenada, List<PAbiertasYPago> listaCompleta)
        {
            List<PAbiertasYPago> list = new List<PAbiertasYPago>();
            for (int i = 0; i < listOrdenada.Count; i++)
            {
                for (int j = 0; j < listaCompleta.Count; j++)
                {
                    if (listOrdenada[i].indice == listaCompleta[j].indice)
                    {
                        list.Add(listaCompleta[j]);
                        j++;
                        try
                        {

                            while (listaCompleta[j].BLART1 != "KZ")
                            {
                                list.Add(listaCompleta[j]);
                                j++;
                                if (j == listaCompleta.Count)
                                {
                                    break;
                                }
                            }

                        }                         
                        catch (Exception)
                        {
                        }
                    }
                }

            }
            return list;
        }


        private void cerrarSesion()
        {
            //se borra la cookie de autenticacion
            System.Web.Security.FormsAuthentication.SignOut();
            //se redirecciona al usuario a la pagina de login
            Response.Redirect("Inicio.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            btnbuscar = true;
        }
        //BEGIN OF INSERT SF RSG 02.2023 v2.0
        [WebMethod]
        public static string desadjuntar(string belnr, string uuid)
        {
            string[] uui = uuid.Split('|');
            string mensaje = "";
            int cantidad = 0;
            PNegocio.CargarFactura nFac = new PNegocio.CargarFactura();
            try
            {
                cantidad = nFac.desvincular(listaDiferentesInstanciasg, uui);
                if (cantidad > 1)
                {
                    mensaje = "<br> Se desadjuntaron " + cantidad + " XML/s y " + cantidad + " PDF/s. <br>";
                }
                else
                {
                    mensaje = "<br> Se desadjunto " + cantidad + " XML y " + cantidad + " PDF. <br>";
                }
            }
            catch (Exception)
            {
                mensaje = "Error al quitar archivos adjuntos.";
            }
            return mensaje;
        }
        //END   OF INSERT SF RSG 02.2023 v2.0
    }
}