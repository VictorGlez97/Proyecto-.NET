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

    public partial class NET_Equipo7_Unidad0102 : System.Web.UI.Page
    {
        List<string> lstArchivos = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_enviar_Click(object sender, EventArgs e)
        {
            Correo c = new Correo();

            if (!Regex.IsMatch(txt_correo.Text, @"\w+@\w+\.+[a-z]") || txt_correo.Text == "")
            {
                Response.Write("<script> window.alert('ERROR: Correo no valido'); </script>");
                Response.Redirect("/NET-Equipo7-Unidad0102.aspx");
            }

            if (!Regex.IsMatch(txt_tel.Text, @"[0-9]{10}") || txt_tel.Text == "")
            {
                Response.Write("<script> window.alert('ERROR: Telefono no valido'); </script>");
                Response.Redirect("/NET-Equipo7-Unidad0102.aspx");
            }
            

            if (!Regex.IsMatch(txt_CURP.Text, @"[A-Z]{4}[0-9]{6}[H,M][A-Z]{5}[0-9]{2}") || txt_CURP.Text == "")
            {
                Response.Write("<script> window.alert('ERROR: CURP no valido'); </script>");
                Response.Redirect("/NET-Equipo7-Unidad0102.aspx");
            }

            if (!Regex.IsMatch(txt_RFC.Text, @"[A-Z]{4}[0-9]{6}") || txt_RFC.Text == "")
            {
                Response.Write("<script> window.alert('ERROR: RFC no valido'); </script>");
                //Response.Redirect("/NET-Equipo7-Unidad0102.aspx");
            }

            int tam = doc.PostedFile.ContentLength;

            /*if (archivo.HasFile && doc.HasFile)
            {

                Response.Write("<script> window.alert('Hay 2 archivos'); </script>");

                /*int tm = archivo.PostedFile.ContentLength;
                if ((tm + tam) < 25000)
                {
                    foreach (HttpPostedFile file in archivo.PostedFiles)
                    {
                        string fileName = Path.GetFileName(file.FileName);

                        string strExtension = Path.GetExtension(fileName);
                        if (strExtension == ".png" || strExtension == ".jpg" || strExtension == ".jpeg")
                        {
                            file.SaveAs(Server.MapPath("~/") + fileName);
                            c.Anexos = new Attachment(file.InputStream, fileName);
                            Response.Write("<script> window.alert(" + file.InputStream +"); </script> ");
                        }
                    }
                }*/
            /*}
            else
            {*/
                if (archivo.HasFile)
                {
                    foreach (HttpPostedFile file in archivo.PostedFiles)
                    {
                        string fileName = Path.GetFileName(file.FileName);

                        string strExtension = Path.GetExtension(fileName);
                        if (strExtension == ".png" || strExtension == ".jpg" || strExtension == ".jpeg")
                        {
                            file.SaveAs(Server.MapPath("~/") + fileName);
                            c.Anexos = new Attachment(file.InputStream, fileName);
                        }
                    }
                }

                if (tam < 5000)
                {
                    if (doc.HasFile)
                    {
                        foreach (HttpPostedFile fi in doc.PostedFiles)
                        {
                            string fN = Path.GetFileName(fi.FileName);

                            string strExt = Path.GetExtension(fN);
                            if (strExt == ".docx" || strExt == ".pdf" || strExt == ".txt")
                            {
                                fi.SaveAs(Server.MapPath("~/") + fN);
                                c.Docs = new Attachment(fi.InputStream, fN);
                            }
                        }
                    }
                }
            //}


            StringBuilder BodyMesage = new StringBuilder();

            BodyMesage.AppendLine("Solicitante: " + txt_nombre.Text);
            BodyMesage.AppendLine("Nacimiento: " + txt_nacimiento.Text);
            BodyMesage.AppendLine("Correo: " + txt_correo.Text);
            BodyMesage.AppendLine("Telefono: " + txt_tel.Text);
            BodyMesage.AppendLine("CURP: " + txt_CURP.Text);
            BodyMesage.AppendLine("RFC: " + txt_RFC.Text);

            if (c.EnviarMail(BodyMesage.ToString()) == true)
            {
                Response.Write("<script> window.alert('Solicitud entregada con EXITO'); </script>");
                Response.Redirect("/NET-Equipo7-Unidad0102.aspx");
            }
            else
            {
                Response.Write("<script> window.alert('ERROR: no se ha podido enviar la solicitud'); </script>");
                Response.Redirect("/NET-Equipo7-Unidad0102.aspx");
            }

        }
    }
}