﻿using GPApp.Shared.Services;
using Microsoft.Extensions.Configuration;

namespace GPApp.Web.Services
{
    public class ConfigurationService : IConfiguracaoService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string SMTP { get;  set; }
        public string EmailSMTP { get;  set; }

        public string PasswordSMTP { get; set; }

        public void Configura()
        {
            SMTP = _configuration.GetValue<string>("SMTPConfig:SMTP");
            EmailSMTP = _configuration.GetValue<string>("SMTPConfig:Email");
            PasswordSMTP = _configuration.GetValue<string>("SMTPConfig:Password");
        }
    }
}
