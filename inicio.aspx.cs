using ComiteEvaluativo.clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComiteEvaluativo
{
    public partial class inicio : System.Web.UI.Page
    {
        string usuario, nombre, correo, comentario, alertaEstado, planta, fecha, hora;
        int id_planta, contadorEstado, estadoProceso, idProceso;

        SqlComite com = new SqlComite();
        string idUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {

            SqlComite conProc = new SqlComite();
            DataSet dsValProceso = new DataSet();
            SqlComite conProcID = new SqlComite();
            DataSet dsValProcesoID = new DataSet();
            dsValProceso = conProc.GetDatosProceso();
            dsValProcesoID = conProc.GetDatosProcesoID();
            estadoProceso = Convert.ToInt32(dsValProceso.Tables[0].Rows[0].ItemArray[0].ToString());
            idProceso = Convert.ToInt32(dsValProcesoID.Tables[0].Rows[0].ItemArray[0].ToString());
            if (estadoProceso == 0)
            {
                HttpContext.Current.Response.Redirect("proceso.aspx", true);
            }

            divAlert.Visible = false;
            try
            {
                idUsuario = HttpContext.Current.User.Identity.Name.ToString().ToUpper();
                idUsuario = (idUsuario.Replace("CORPORATIVO\\", ""));
                //idUsuario = Environment.UserName;
                lblUserID.Text = idUsuario.ToUpper();
                SqlComite con = new SqlComite();
                DataSet ds = new DataSet();
                ds = con.GetCargaDatos(idUsuario);
                TextBoxNombre.Text = ds.Tables["Tabla"].Rows[0].ItemArray[0].ToString();
                TextBoxCorreo.Text = ds.Tables["Tabla"].Rows[0].ItemArray[1].ToString();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }


        private void fnEnviaCorreos(String usuario, String nombre, string correo,string planta, string fecha, string hora)
        {
            SqlComite con = new SqlComite();
            DataSet ds = new DataSet();
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(correo));
            //email.CC.Add(new MailAddress(""));
            email.From = new MailAddress("serviciosonline@uahurtado.cl");
            email.Subject = "No Responder: Comité Consultivo.";
            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.SubjectEncoding = System.Text.Encoding.UTF8;
            email.Body = "";
            email.Body = email.Body + "<p style='font-family:Source Sans Pro; font -size:11px;padding-left:10px;'>Estimado(a): " + nombre + "</p>";
            email.Body = email.Body + "<p style='font-family:Source Sans Pro; font -size:11px;padding-left:10px;'>Se ha registrado correctamente tu respuesta.</p>";
            email.Body = email.Body + "<p style='font-family:Source Sans Pro; font -size:11px;padding-left:10px;'>A continuación una copia de tu respuesta.</p>";
            email.Body = email.Body + "<p style='font-family:Source Sans Pro; font -size:11px;padding-left:10px;'><b>Te conectaste como: " + nombre + "</b></p>";
            email.Body = email.Body + "<p style='font-family:Source Sans Pro; font -size:11px;padding-left:10px;'><b>Tu dirección de correo electrónico es: " + correo + "</b></p>";
            email.Body = email.Body + "<p style='font-family:Source Sans Pro; font -size:11px;padding-left:10px;'><b>Perteneces al tipo planta: " + planta + "</b></p>";
            email.Body = email.Body + "<p style='font-family:Source Sans Pro; font -size:11px;padding-left:10px;'><b>Fecha: " + fecha + "</b></p>";
            email.Body = email.Body + "<p style='font-family:Source Sans Pro; font -size:11px;padding-left:10px;'><b>Hora: " + hora + "</b></p>";
            email.Body = email.Body + "<p style='font-family:Source Sans Pro; font -size:11px;padding-left:10px;'>Atentamente</p>";
            email.Body = email.Body + "<p style='font-family:Source Sans Pro; font -size:11px;padding-left:10px;'><b>Comité Consultivo.</b></p>";
            email.Body = email.Body + "<p><img src='https://www.uahurtado.cl/wp-content/themes/uah-2019/images/logo.png'/></p>";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "proxmox.uahurtado.cl";
            smtp.Port = 26;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            string output = null;
            try
            {
                smtp.Send(email);
                email.Dispose();
                output = "Correo electrónico fue enviado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                output = "Error enviando correo electrónico: " + correo + ", detale del error: " + ex.Message;
                Console.Write(output);
            }
        }


        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlComite com = new SqlComite();
                DataSet dsVal = new DataSet();
                dsVal = com.GetEstado(idUsuario);
                contadorEstado = Convert.ToInt32(dsVal.Tables[0].Rows[0].ItemArray[0].ToString());
                if (contadorEstado >= 1)
                {
                    alertaEstado = "<br/><p>Estimado(a): Ya posee una respuesta registrada.</p>";
                    divAlert.Visible = true;
                }
                else
                {
                    SqlComite con = new SqlComite();
                    DataSet ds = new DataSet();
                    usuario = lblUserID.Text.ToString();
                    nombre = TextBoxNombre.Text.ToString();
                    correo = TextBoxCorreo.Text.ToString();
                    id_planta = Int32.Parse(DropDownListPlanta.SelectedValue.ToString());
                    comentario = TextOpinion.InnerText.ToString();
                    ds = con.GetInsertaEncuesta(usuario, nombre, correo, id_planta, comentario.ToUpper());
                    DataSet ds1 = new DataSet();
                    ds1 = com.GetDatosMail(idUsuario);
                    planta = ds1.Tables["Tabla"].Rows[0].ItemArray[0].ToString();;
                    fecha = ds1.Tables["Tabla"].Rows[0].ItemArray[1].ToString();
                    hora = ds1.Tables["Tabla"].Rows[0].ItemArray[2].ToString();
                    if (correo != "")
                    {
                        fnEnviaCorreos(usuario, nombre, correo, planta, fecha, hora);
                    }
                    HttpContext.Current.Response.Redirect("confirmacion.aspx", true);
                }
                lblAlerta.Text = alertaEstado.ToString();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}