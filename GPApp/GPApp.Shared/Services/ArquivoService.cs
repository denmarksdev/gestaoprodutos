using System;
using System.IO;

namespace GPApp.Shared.Services
{
    public class ArquivoService : IArquivoService
    {
        public string GetImagemBase64(string path)
        {
            var bytes = GetImagemBytes(path);
            return Convert.ToBase64String(bytes);
        }

        public string GetImagemBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public byte[] GetImagemBytes(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}
