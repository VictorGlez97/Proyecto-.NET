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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_enviar_Click(object sender, EventArgs e)
        {
            Correo c = new Correo();

            if (!Regex.IsMatch(txt_correo.Text, @"") || txt_correo.Text == "")
            {
                Response.Write("<script> alert('ERROR: Correo no valido'); </script>");
                Response.Redirect("/NET-Equipo7-Unidad0102.aspx");
            }

            if (!Regex.IsMatch(txt_tel.Text, @"{3}[0-9]+{7}[0-9]") || txt_tel.Text == "")
            {
                Response.Write("<script> alert('ERROR: Telefono no valido'); </script>");
                Response.Redirect("/NET-Equipo7-Unidad0102.aspx");
            }

            if (!Regex.IsMatch(txt_CURP.Text, @"") || txt_CURP.Text == "")
            {
                Response.Write("<script> alert('ERROR: CURP no valido'); </script>");
                Response.Redirect("/NET-Equipo7-Unidad0102.aspx");
            }

            if (!Regex.IsMatch(txt_RFC.Text, @"") || txt_RFC.Text == "")
            {
                Response.Write("<script> alert('ERROR: RFC no valido'); </script>");
                Response.Redirect("/NET-Equipo7-Unidad0102.aspx");
            }

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

            StringBuilder BodyMesage = new StringBuilder();

            BodyMesage.AppendLine("Solicitante: " + txt_nombre.Text);
            BodyMesage.AppendLine("Nacimiento: " + nacimiento);
            BodyMesage.AppendLine("Correo: " + txt_correo.Text);
            BodyMesage.AppendLine("Telefono: " + txt_tel.Text);
            BodyMesage.AppendLine("CURP: " + txt_CURP.Text);
            BodyMesage.AppendLine("RFC: " + txt_RFC.Text);

            if (c.EnviarMail(BodyMesage.ToString()) == true)
            {
                Response.Write("<script> alert('Solicitud entregada con EXITO'); </script>");
                Response.Redirect("/");
            }
            else
            {
                Response.Write("<script> alert('ERROR: no se ha podido enviar la solicitud'); </script>");
            }

        }
    }
}

namespace Aplicacion_1.NET-Equipo7-Unidad0102.aspx{
    class Correo
    {
    }
}