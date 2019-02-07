namespace GPApp.Shared.Services
{
    public interface IArquivoService
    {
        byte[] GetImagemBytes(string path);
        string GetImagemBase64(string path);
        string GetImagemBase64(byte[] bytes);
    }
}