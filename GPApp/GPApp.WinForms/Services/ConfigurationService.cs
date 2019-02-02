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
        public int PortaSMTP { get ; set ; }

        public void Configura()
        {
            SMTP = ConfigurationManager.AppSettings[nameof(SMTP)];
            EmailSMTP = ConfigurationManager.AppSettings[nameof(EmailSMTP)];
            PasswordSMTP = ConfigurationManager.AppSettings[nameof(PasswordSMTP)];
            BaseUrlApi  = ConfigurationManager.AppSettings[nameof(BaseUrlApi)];
            int.TryParse(ConfigurationManager.AppSettings[nameof(PortaSMTP)], out int porta);
            PortaSMTP = porta;
        }

        public ConfigurationService()
        {
            Configura();
        }
    }
}