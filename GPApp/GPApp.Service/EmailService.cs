using GPApp.Model.Helpers;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace GPApp.Service
{
    public class EmailService : IEmailService
    {
        public Task<Resultado> Envia(string mensagem)
        {
            return Task.Run(() =>
            {
                try
                {
                    SmtpClient client = new SmtpClient("smtp provider")
                    {
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("test@teste", "password"),
                        Port = 587,
                        EnableSsl = true
                    };

                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress("test@teste", "Nome"),
                    };
                    mailMessage.To.Add(new MailAddress("test@teste", "Nome"));
                    mailMessage.Body =  mensagem;
                    mailMessage.Subject = "subject";
                    mailMessage.IsBodyHtml = true;
                    client.Send(mailMessage);

                    return new Resultado();

                }
                catch (System.Exception ex)
                {
                    return new Resultado(ex.Message, ex);
                }
            });
        }
    }
}
