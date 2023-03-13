using PNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proveedores
{
    public partial class datosMaestros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.hidCerrarSesion.Value != "cerrar")
            {
                //INICIO Permiso de ver esta pantalla
                bool permiso = false;
                try
                {
                    int[] idPantallas = (int[])Session["Pantallas"];
                    for (int i = 0; i < idPantallas.Length; i++)
                    {
                        if (idPantallas[i] == 8)
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

                DatoMaestro dm = new DatoMaestro();
                string userName = HttpContext.Current.User.Identity.Name;

                try
                {
                    List<string[]> listaDiferentesInstancias = (List<string[]>)Session["listaDiferentesInstancias"];

                    if (listaDiferentesInstancias.Count > 0)
                    {
                        for (int i = 0; i < listaDiferentesInstancias.Count; i++)
                        {
                            try
                            {
                                PEntidades.SrvSAPUProveedores.ZELIFNR_PROV[] objLifnr;

                                string[] splitLifnr = listaDiferentesInstancias[i][3].Split(new Char[] { ',' });

                                objLifnr = PEntidades.Utiles.objetoLifnr(splitLifnr);

                                List<PEntidades.Proveedor> proveedoresPorIsntancia;

                                proveedoresPorIsntancia = dm.getDatoMaestro(objLifnr,
                                    listaDiferentesInstancias[i][1].ToString().Trim(),  // endpoint
                                listaDiferentesInstancias[i][4].Split(new Char[] { ',' }) // pass
                                    );

                                Panel panelTotal = new Panel();

                                Literal imagenMaestros = new Literal();
                                imagenMaestros.Text =  "<h4 class='card-title'>";
                                imagenMaestros.Text += "<img src='../images/ico-datos_maestros.png' style='margin-top:-40px'/>";
                                imagenMaestros.Text += "<span class='h1' style='font-size:2rem;'>SAPQAS2</span></h4>";
                                panelTotal.Controls.Add(imagenMaestros);

                                //Label etiquetaInstancia = new Label();
                                //etiquetaInstancia.Text = listaDiferentesInstancias[i][6].ToString().Trim();
                                //etiquetaInstancia.CssClass = "lblDM_H";
                                //panelTotal.Controls.Add(etiquetaInstancia);

                                for (int j = 0; j < proveedoresPorIsntancia.Count; j++)
                                {

                                    panelTotal.Controls.Add(pintarDatosMestros(proveedoresPorIsntancia[j]));
                                }
                                pnlDatosMaestros.Controls.Add(panelTotal);

                            }
                            catch (Exception)
                            {
                                //throw;
                                this.lblTabla.Text = "<br/><h3>" + "Hubo un error al obtener la información" + "</h3>";
                            }
                        }
                    }
                    else
                    {
                        this.lblTabla.Text = "<br/><h3>" + "Este usuario no tiene sociedades activas, por lo que no puede obtener datos" + "</h3>";
                    }




                }
                catch (Exception)
                {


                }

            }
            

                

                
        }

        private void cerrarSesion()
        {
            //se borra la cookie de autenticacion
            System.Web.Security.FormsAuthentication.SignOut();
            //se redirecciona al usuario a la pagina de login
            //Response.Redirect("Inicio.aspx");     //DELETE SF RSG 02.2023 v2.0
            Response.Redirect("Default.aspx");      //ADD SF RSG 02.2023 v2.0
        }

        

        

        private Panel pintarDatosMestros(PEntidades.Proveedor objProveedor)
        {
            //------
            Panel panelInterno = new Panel();
            panelInterno.CssClass = "datMtrWrap1 row";

            Panel form1 = new Panel();
            form1.CssClass = "form-group col-lg-4";
            Label label1 = new Label();
            label1.Text = "N° Proveedor";
            TextBox input1 = new TextBox();
            input1.CssClass = "form-control";
            input1.ID = "input1";
            input1.Enabled = false;
            input1.Text = objProveedor.Liftnr;
            form1.Controls.Add(label1);
            form1.Controls.Add(input1);
            panelInterno.Controls.Add(form1);

            Panel form3 = new Panel();
            form3.CssClass = "form-group col-lg-8";
            Label label3 = new Label();
            label3.Text = "Nombre";
            TextBox input3 = new TextBox();
            input3.CssClass = "form-control";
            input3.ID = "input3";
            input3.Enabled = false;
            input3.Text = objProveedor.NAME1;
            form3.Controls.Add(label3);
            form3.Controls.Add(input3);
            panelInterno.Controls.Add(form3);

            Panel form2 = new Panel();
            form2.CssClass = "form-group col-lg-6";
            Label label2 = new Label();
            label2.Text = "País";
            TextBox input2 = new TextBox();
            input2.CssClass = "form-control";
            input2.ID = "input2";
            input2.Enabled = false;
            input2.Text = objProveedor.NAMECOUNTRY;
            form2.Controls.Add(label2);
            form2.Controls.Add(input2);
            panelInterno.Controls.Add(form2);

            Panel form5 = new Panel();
            form5.CssClass = "form-group col-lg-6";
            Label label5 = new Label();
            label5.Text = "Estado";
            TextBox input5 = new TextBox();
            input5.CssClass = "form-control";
            input5.ID = "input5";
            input5.Enabled = false;
            input5.Text = objProveedor.NAMEREGION;
            form5.Controls.Add(label5);
            form5.Controls.Add(input5);
            panelInterno.Controls.Add(form5);

            Panel form4 = new Panel();
            form4.CssClass = "form-group col-lg-12";
            Label label4 = new Label();
            label4.Text = "Ciudad";
            TextBox input4 = new TextBox();
            input4.CssClass = "form-control";
            input4.ID = "input4";
            input4.Enabled = false;
            input4.Text = objProveedor.ADDR2_DATA;  //ADD SF RSG 03.2023 v2.0
            form4.Controls.Add(label4);
            form4.Controls.Add(input4);
            panelInterno.Controls.Add(form4);

            Panel form6 = new Panel();
            form6.CssClass = "form-group col-lg-12";
            Label label6 = new Label();
            label6.Text = "Calle";
            TextBox input6 = new TextBox();
            input6.CssClass = "form-control";
            input6.ID = "input6";
            input6.Enabled = false;
            input6.Text = objProveedor.STREET;
            form6.Controls.Add(label6);
            form6.Controls.Add(input6);
            panelInterno.Controls.Add(form6);

            Panel form7 = new Panel();
            form7.CssClass = "form-group col-lg-12";
            Label label7 = new Label();
            label7.Text = "Colonia";
            TextBox input7 = new TextBox();
            input7.CssClass = "form-control";
            input7.ID = "input7";
            input7.Enabled = false;
            input7.Text = objProveedor.ADDR1_DATA;
            form7.Controls.Add(label7);
            form7.Controls.Add(input7);
            panelInterno.Controls.Add(form7);

            Panel form8 = new Panel();
            form8.CssClass = "form-group col-lg-4";
            Label label8 = new Label();
            label8.Text = "Código postal";
            TextBox input8 = new TextBox();
            input8.CssClass = "form-control";
            input8.ID = "input8";
            input8.Enabled = false;
            input8.Text = objProveedor.POST_CODE1;
            form8.Controls.Add(label8);
            form8.Controls.Add(input8);
            panelInterno.Controls.Add(form8);


            ////------
            //Table tabla1_1 = new Table();
            //    tabla1_1.CssClass = "tblDatMtr";
            //        //------
            //        TableRow tr_1 = new TableRow();

            //        TableCell celda1_1 = new TableCell();
            //        celda1_1.Text = "N° Proveedor";

            //        TableCell celda1_2 = new TableCell();
            //        Label lbltexto1_2 = new Label();
            //        lbltexto1_2.Text = "";
            //        lbltexto1_2.CssClass = "lblDM";
            //        lbltexto1_2.Text = objProveedor.Liftnr;
            //        celda1_2.Controls.Add(lbltexto1_2);

            //        tr_1.Cells.Add(celda1_1);
            //        tr_1.Cells.Add(celda1_2);
            //        //------
            //        TableRow tr_2 = new TableRow();

            //        TableCell celda2_1 = new TableCell();
            //        celda2_1.Text = "País";

            //        TableCell celda2_2 = new TableCell();
            //        Label lbltexto2_2 = new Label();
            //        lbltexto2_2.Text = "";
            //        lbltexto2_2.CssClass = "lblDM";
            //        lbltexto2_2.Text = objProveedor.NAMECOUNTRY;
            //        celda2_2.Controls.Add(lbltexto2_2);

            //        tr_2.Cells.Add(celda2_1);
            //        tr_2.Cells.Add(celda2_2);
            //        //------
            //        TableRow tr_3 = new TableRow();

            //        TableCell celda3_1 = new TableCell();
            //        celda3_1.Text = "Nombre";

            //        TableCell celda3_2 = new TableCell();
            //        Label lbltexto3_2 = new Label();
            //        lbltexto3_2.Text = "";
            //        lbltexto3_2.CssClass = "lblDM";
            //        lbltexto3_2.Text = objProveedor.NAME1;
            //        celda3_2.Controls.Add(lbltexto3_2);

            //        tr_3.Cells.Add(celda3_1);
            //        tr_3.Cells.Add(celda3_2);
            //        //------
            //        TableRow tr_4 = new TableRow();

            //        TableCell celda4_1 = new TableCell();
            //        celda4_1.Text = "Ciudad";

            //        TableCell celda4_2 = new TableCell();
            //        Label lbltexto4_2 = new Label();
            //        lbltexto4_2.Text = "";
            //        lbltexto4_2.CssClass = "lblDM";
            //        lbltexto4_2.Text = objProveedor.ADDR1_DATA;
            //        celda4_2.Controls.Add(lbltexto4_2);


            //        tr_4.Cells.Add(celda4_1);
            //        tr_4.Cells.Add(celda4_2);
            //        //------
            //        tabla1_1.Rows.Add(tr_1); tabla1_1.Rows.Add(tr_2); tabla1_1.Rows.Add(tr_3); tabla1_1.Rows.Add(tr_4);
            //        //this.pnlDatosMaestros.Controls.Add(espacio);
            //    //------
            //    Table tabla2_1 = new Table();
            //    tabla2_1.CssClass = "tblDatMtr";
            //        //------
            //    TableRow tr_1_2 = new TableRow();

            //    TableCell celda1_1_2 = new TableCell();
            //        celda1_1_2.Text = "Estado";

            //        TableCell celda1_2_2 = new TableCell();
            //         Label lbltexto5_2 = new Label();
            //         lbltexto5_2.Text = "";
            //         lbltexto5_2.CssClass = "lblDM";
            //         lbltexto5_2.Text = objProveedor.NAMEREGION;
            //         celda1_2_2.Controls.Add(lbltexto5_2);


            //         tr_1_2.Cells.Add(celda1_1_2);
            //         tr_1_2.Cells.Add(celda1_2_2);
            //        //------
            //         TableRow tr_2_2 = new TableRow();

            //         TableCell celda2_1_2 = new TableCell();
            //         celda2_1_2.Text = "Calle";

            //         TableCell celda2_2_2 = new TableCell();
            //         Label lbltexto6_2 = new Label();
            //         lbltexto6_2.Text = "";
            //         lbltexto6_2.CssClass = "lblDM";
            //         lbltexto6_2.Text = objProveedor.STREET;
            //         celda2_2_2.Controls.Add(lbltexto6_2);


            //         tr_2_2.Cells.Add(celda2_1_2);
            //         tr_2_2.Cells.Add(celda2_2_2);
            //        //------
            //         TableRow tr_3_2 = new TableRow();

            //         TableCell celda3_1_2 = new TableCell();
            //         celda3_1_2.Text = "Colonia";

            //         TableCell celda3_2_2 = new TableCell();
            //         Label lbltexto7_2 = new Label();
            //         lbltexto7_2.Text = "";
            //         lbltexto7_2.CssClass = "lblDM";
            //         lbltexto7_2.Text = "";
            //         celda3_2_2.Controls.Add(lbltexto7_2);


            //         tr_3_2.Cells.Add(celda3_1_2);
            //         tr_3_2.Cells.Add(celda3_2_2);
            //        //------
            //        TableRow tr_4_2 = new TableRow();

            //        TableCell celda4_1_2 = new TableCell();
            //        celda4_1_2.Text = "CP";

            //        TableCell celda4_2_2 = new TableCell();
            //         Label lbltexto8_2 = new Label();
            //         lbltexto8_2.Text = "";
            //         lbltexto8_2.CssClass = "lblDM";
            //         lbltexto8_2.Text = objProveedor.POST_CODE1;
            //         celda4_2_2.Controls.Add(lbltexto8_2);


            //         tr_4_2.Cells.Add(celda4_1_2);
            //         tr_4_2.Cells.Add(celda4_2_2);
            //        //------
            //        //tabla2_1.Rows.Add(tr_1_2); tabla2_1.Rows.Add(tr_2_2); tabla2_1.Rows.Add(tr_3_2); tabla2_1.Rows.Add(tr_4_2);
            //        tabla1_1.Rows.Add(tr_1_2); tabla1_1.Rows.Add(tr_2_2); tabla1_1.Rows.Add(tr_3_2); tabla1_1.Rows.Add(tr_4_2); //ADD SF RSG 02.2023 v2.0
            ////------

            ////------
            //panelInterno.Controls.Add(tabla1_1);
            //        panelInterno.Controls.Add(tabla2_1);

                    return panelInterno;

        }
    }
}