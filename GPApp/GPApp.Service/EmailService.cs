using GPApp.Model;
using GPApp.Model.Helpers;
using GPApp.Shared.Services;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace GPApp.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguracaoService _config;

        public EmailService(IConfiguracaoService configuration)
        {
            _config = configuration;
        }

        public Task<Resultado> Envia(Propaganda propaganda)
        {
            return Task.Run(() =>
            {
                try
                {
                    SmtpClient client = new SmtpClient(_config.SMTP)
                    {
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(_config.EmailSMTP, _config.PasswordSMTP),
                        Port = _config.PortaSMTP,
                        EnableSsl = true
                    };

                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress(propaganda.Sender, propaganda.NomeSender),
                    };

                    foreach (var cliente in propaganda.Clientes)
                    {
                        mailMessage.To.Add(new MailAddress(cliente.Email, cliente.Nome));
                    }
                    mailMessage.Body = propaganda.Conteudo;
                    mailMessage.Subject = propaganda.Titulo;
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