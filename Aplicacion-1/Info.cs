using System.Net;
using System.Net.Mail;
using System;
using System.Collections.Generic;

namespace Aplicacion_1
{
    public class Info
    {

        private MailMessage CorreoElectronico;
        private SmtpClient EnvioCorreo;
        private String MailFrom;
        private String Password;
        public Attachment Anexos;

        public Info()
        {
            //vichgleza@gmail.com
            CorreoElectronico = new MailMessage("vichgleza@outlook.com", "vichgleza@gmail.com");
            EnvioCorreo = new SmtpClient("smtp.live.com", 587);
            MailFrom = "vichgleza@outlook.com";
            Password = "*******";
        }

        public bool EnviarMail(string Mensaje, string asunto)
        {
            try
            {
                CorreoElectronico.Body = Mensaje;
                CorreoElectronico.Subject =asunto;

                EnvioCorreo.Credentials = new NetworkCredential(MailFrom, Password);
                EnvioCorreo.EnableSsl = true;
                EnvioCorreo.DeliveryMethod = SmtpDeliveryMethod.Network;
                CorreoElectronico.Body = Mensaje;

                if (Anexos != null)
                {
                    CorreoElectronico.Attachments.Add(Anexos);
                }


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