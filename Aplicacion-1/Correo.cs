using System.Net;
using System.Net.Mail;
using System;

namespace Aplicacion_1
{
    public class Correo
    {

        private MailMessage CorreoElectronico;
        private SmtpClient EnvioCorreo;
        private String MailFrom;
        private String Password;
        public Attachment Anexos;
        public Attachment Docs;

        public Correo()
        {
            CorreoElectronico = new MailMessage("vichgleza@outlook.com", "vichgleza@gmail.com");
            EnvioCorreo = new SmtpClient("smtp.live.com", 587);
            MailFrom = "vichgleza@outlook.com";
            Password = "*****";
        }

        public bool EnviarMail(string Mensaje)
        {
            try
            {
                CorreoElectronico.Body = Mensaje;
                CorreoElectronico.Subject = "Nueva Solicitud de Empleo";

                EnvioCorreo.Credentials = new NetworkCredential(MailFrom, Password);
                EnvioCorreo.EnableSsl = true;
                EnvioCorreo.DeliveryMethod = SmtpDeliveryMethod.Network;
                CorreoElectronico.Body = Mensaje;
                CorreoElectronico.Attachments.Add(Anexos);
                CorreoElectronico.Attachments.Add(Docs);

                EnvioCorreo.Send(CorreoElectronico);

                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

    }
}