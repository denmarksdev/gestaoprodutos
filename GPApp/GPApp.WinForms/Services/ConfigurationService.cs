using GPApp.Shared.Services;
using System.Configuration;

namespace GPApp.WinForms.Services
{
    public class ConfigurationService : IConfiguracaoService
    {
        public string SMTP { get; set; }
        public string EmailSMTP { get; set; }
        public string PasswordSMTP { get; set; }
        public string BaseUrlApi { get; set; }

        public void Configura()
        {
            SMTP = ConfigurationManager.AppSettings[nameof(SMTP)];
            EmailSMTP = ConfigurationManager.AppSettings[nameof(EmailSMTP)];
            PasswordSMTP = ConfigurationManager.AppSettings[nameof(PasswordSMTP)];
            BaseUrlApi  = ConfigurationManager.AppSettings[nameof(BaseUrlApi)];
        }

        public ConfigurationService()
        {
            Configura();
        }
    }
}