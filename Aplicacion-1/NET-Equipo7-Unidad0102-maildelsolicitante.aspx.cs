using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Aplicacion_1
{
    public partial class NET_Equipo7_Unidad0102_maildelsolicitante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_enviar_Click(object sender, EventArgs e)
        {

            try
            {

                Info i = new Info();

                if (!Regex.IsMatch(txt_correo.Text, @"\w+@\w+\.+[a-z]") || txt_correo.Text == "")
                {
                    Response.Write("<script> window.alert('ERROR: Correo no valido'); </script>");
                    Response.Redirect("/NET-Equipo7-Unidad0102-maildelsolicitante.aspx");
                }

                if (!Regex.IsMatch(txt_tel.Text, @"[0-9]{10}") || txt_tel.Text == "")
                {
                    Response.Write("<script> window.alert('ERROR: Telefono celular no valido'); </scrip");
                    Response.Redirect("/NET-Equipo7-Unidad0102-maildelsolicitante.aspx");
                }

                int size = archivo.PostedFile.ContentLength;

                if (size < 5000)
                {
                    if (archivo.HasFile)
                    {
                        foreach (HttpPostedFile file in archivo.PostedFiles)
                        {
                            string fileName = Path.GetFileName(file.FileName);

                            string strExtension = Path.GetExtension(fileName);
                            if (strExtension == ".docx" || strExtension == ".pdf" || strExtension == ".jpeg")
                            {
                                file.SaveAs(Server.MapPath("~/") + fileName);
                                i.Anexos = new Attachment(file.InputStream, fileName);
                            }
                        }
                    }
                }


                StringBuilder BodyMesage = new StringBuilder();

                BodyMesage.AppendLine("Solicitante:        " + txt_nombre.Text);
                BodyMesage.AppendLine("Telefono:           " + txt_tel.Text);
                BodyMesage.AppendLine("Vacante Solicitada: " + txt_vacante.Text);
                BodyMesage.AppendLine("Correo:             " + txt_correo.Text);
                BodyMesage.AppendLine("Mensaje:            " + txt_mensaje.Text);

                if (i.EnviarMail(BodyMesage.ToString(), "Pregunta sobre vacantes") == true)
                {
                    Response.Write("<script> window.alert('Solicitud entregada con EXITO'); </script>");
                    Response.Redirect("/NET-Equipo7-Unidad0102-maildelsolicitante.aspx");
                }
                else
                {
                    Response.Write("<script> window.alert('ERROR: no se ha podido enviar la solicitud'); </script>");
                    Response.Redirect("/Site.Master");
                }

            }
            catch (Exception f)
            {
                Response.Write("<script> window.alert(" + f + "); </script>");
                throw;
            }

        }
    }
}