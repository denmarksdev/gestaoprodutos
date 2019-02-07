using GPApp.Shared.Services;
using System;

namespace GPApp.Uwp.Services
{
    public class ArquivoService : IArquivoService
    {
        public string GetImagemBase64(string path)
        {
            throw new System.NotImplementedException();
        }

        public string GetImagemBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public byte[] GetImagemBytes(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}
