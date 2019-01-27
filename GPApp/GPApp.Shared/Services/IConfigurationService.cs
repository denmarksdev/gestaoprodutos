namespace GPApp.Shared.Services
{
    public interface IConfiguracaoService
    {
        string SMTP { get; set; }
        string EmailSMTP { get; set; }
        string PasswordSMTP { get; set; }

        void Configura();
    }
}