using System.Net.Mail;

namespace Proyecto1V1.Helpers
{
    public class MailService:IMailService
    {
        public void SendEmail(String receptor, String asunto, String contenido)
        {
            string EmailOrigen = "emailsenderproyecto1avanzada@gmail.com";

            string Password = "olpxrnhdjyhguwkf";

            MailMessage eMailMessage = new MailMessage(EmailOrigen,receptor,asunto,contenido);

            eMailMessage.IsBodyHtml = true;

            SmtpClient eSmtpClient = new SmtpClient("smtp.gmail.com");
            eSmtpClient.EnableSsl = true;
            eSmtpClient.UseDefaultCredentials = false;
            eSmtpClient.Host = "smtp.gmail.com";
            eSmtpClient.Port = 587;
            eSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Password);

            eSmtpClient.Send(eMailMessage);
            eSmtpClient.Dispose();
        }

    }
}
