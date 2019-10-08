using System.Net;
using System.Net.Mail;
using System;

public class Correo
{
    private MailMessage CorreoElectronico;
    private SmtpClient EnvioCorreo;
    private String MailFrom;
    private String Password;
    public Attachment Anexos;

    public Correo()
    {
        CorreoElectronico = new MailMessage("vichgleza@hotmail.com", "vichgleza@gmail.com");
        EnvioCorreo       = new SmtpClient("smtp.live.com", 587);
        MailFrom          = "victor19031997@hotmail.com";
        Password          = "";   
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
