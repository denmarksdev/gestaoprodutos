using GPApp.Shared.Services;
using Windows.Storage;
using System;

namespace GPApp.Uwp.Services
{
    public class ConfiguracaoService : IConfiguracaoService
    {
        public string SMTP { get ; set ; }
        public string EmailSMTP { get ; set ; }
        public string PasswordSMTP { get ; set ; }
        public int PortaSMTP { get ; set ; }
        public string ConnectionString { get ; set ; }
        public string BaseUrlApi { get ; set ; }

        public void Configura()
        {
            var resources = new Windows.ApplicationModel.Resources.ResourceLoader("Configuracao");

            SMTP = resources.GetString(nameof(SMTP));
            EmailSMTP = resources.GetString(nameof(EmailSMTP));
            PasswordSMTP = resources.GetString(nameof(PasswordSMTP));
            PortaSMTP = int.Parse(resources.GetString(nameof(PortaSMTP)));
            ConnectionString = resources.GetString(nameof(ConnectionString));
            BaseUrlApi = resources.GetString(nameof(BaseUrlApi));
        }

        public ConfiguracaoService()
        {
            Configura();
        }
    }
}
