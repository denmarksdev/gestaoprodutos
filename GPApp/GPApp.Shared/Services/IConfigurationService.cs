namespace GPApp.Shared.Services
{
    public interface IConfiguracaoService
    {
        string SMTP { get; set; }
        string EmailSMTP { get; set; }
        string PasswordSMTP { get; set; }
        int PortaSMTP { get; set; }

        string ConnectionString { get; set; }

        string BaseUrlApi { get; set; }

        void Configura();
    }
}