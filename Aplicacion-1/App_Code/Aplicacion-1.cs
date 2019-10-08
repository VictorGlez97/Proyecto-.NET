using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace Aplicacion_1
{
    public class Aplicacion_1
    {

        private MailMessage CorreoElectronico;
        private SmtpClient EnvioCorreo;
        private String MailFrom;
        private String Password;
        public Attachment Anexos;

        public Aplicacion_1()
        {
            CorreoElectronico = new MailMessage("miguel_vara@hotmail.com", "migueldelavararamirez@gmail.com");
            EnvioCorreo = new SmtpClient("smtp.live.com", 587);
            MailFrom = "miguel_vara@hotmail.com";
            Password = "********";
        }

        public bool EnviarMail(string Mensaje)
        {
            try
            {
                CorreoElectronico.Body = Mensaje;
                CorreoElectronico.Subject = "Pregunta Por Carreras Disponibles";

                EnvioCorreo.Credentials = new NetworkCredential(MailFrom, Password);
                EnvioCorreo.EnableSsl = true;
                EnvioCorreo.DeliveryMethod = SmtpDeliveryMethod.Network;
                CorreoElectronico.Body = Mensaje;
                CorreoElectronico.Attachments.Add(Anexos);

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