using PEntidades;
using PNegocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proveedores.portal
{
    public partial class estadoCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.hidCerrarSesion.Value != "cerrar")
            {
                this.btnActualiza.BorderStyle = BorderStyle.None;
                this.btnActualiza.Visible = false;
                this.btnActualizaX.BorderStyle = BorderStyle.None;
                //INICIO Permiso de ver esta pantalla
                bool permiso = false;
                try
                {
                    int[] idPantallas = (int[])Session["Pantallas"];
                    for (int i = 0; i < idPantallas.Length; i++)
                    {
                        if (idPantallas[i] == 2)
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
                //FIN Permiso de ver esta pantalla

                PartidasAbiertas res = new PartidasAbiertas();

                string fecha1 = this.datepicker.Text;
                string fecha2 = this.datepicker2.Text;
                string ptAbiertas = this.rdbTipo.Text.Trim().Substring(0,1);

                try
                {
                    int n_instancias = 0;
                    List<string[]> listaDiferentesInstancias = (List<string[]>)Session["listaDiferentesInstancias"];
                    n_instancias = listaDiferentesInstancias.Count;

                    List<PAbiertasYPago> lstPAbiertas = res.getfacturasAbiertas(fecha1, fecha2, listaDiferentesInstancias, ptAbiertas);

                    ConvertTittles conv = new ConvertTittles();

                    if (lstPAbiertas.Count > 0)
                    {
                        this.lblTabla.Text = conv.convertListPAbiertasToTableInCodeEstado(lstPAbiertas);
                        this.txtTotal.Text = getTotal(lstPAbiertas);
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

                            this.btnActualiza.Visible = true;
                        }
                        if (n_instancias <= 0)
                        {
                            this.lblTabla.Text = "<br/><br/><br/><h3>" + "Este usuario no tiene sociedades activas, por lo que no puede obtener datos" + "</h3>";
                        }

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showFiltros()", true); //ADD SF RSG 02.2023 V2.0  
                        this.txtTotal.Text = "0.00";
                    }
                    //if (this.lblTabla.Text  != "")
                    //{
                    //    this.btnActualiza.Visible = true;
                    //}
                }
                catch (Exception)
                {
                    this.lblTabla.Text = "<h3>Ocurrio un error al obtener los datos<h3>";
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //btnbuscar = true;
        }

        private void cerrarSesion()
        {
            //se borra la cookie de autenticacion
            System.Web.Security.FormsAuthentication.SignOut();
            //se redirecciona al usuario a la pagina de login
            //Response.Redirect("Inicio.aspx");     //DELETE SF RSG 02.2023 v2.0
            Response.Redirect("Default.aspx");      //ADD SF RSG 02.2023 v2.0
        }

        private string getTotal(List<PAbiertasYPago> lstPAbiertas)
        {
            string ret = "";
            float total = new float();
            foreach(PAbiertasYPago p in lstPAbiertas)
            {
                total += p.DMSHB1;
            }
            ret = formatCurrency(float.Parse(Math.Truncate(total*100).ToString())/100);

            return ret;
        }
        public string formatCurrency(float input)
        {
            return input.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}