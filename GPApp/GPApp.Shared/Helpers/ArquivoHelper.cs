using System.IO;

namespace GPApp.Shared.Helpers
{
    public static class ArquivoHelper
    {
        private const string PATH_WEB = "wwwroot";
        private const string PATH_IMAGENS = "imagens";
        private const string PATH_PRODUTOS = "produtos";

        public static string GetDiretorioDeImagens()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), PATH_WEB, PATH_IMAGENS);
             
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }

        public static string GetDiretorioDeImagensDeProdutos()
        {
            var path = Path.Combine(GetDiretorioDeImagens(), PATH_PRODUTOS);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return path;
        }

        public static string GetNomeArquivoNoServidorImagem(string nomeArquivo)
        {
            Path.Combine(GetDiretorioDeImagens(), nomeArquivo);
            if (!Directory.Exists(GetDiretorioDeImagens()))
                Directory.CreateDirectory(GetDiretorioDeImagens());
            return Path.Combine(GetDiretorioDeImagens(), nomeArquivo);
        }

        public static string GetExtensaoArquivo(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return string.Empty;
            return Path.GetExtension(fileName).Replace(".", "");
        }

        public static void  SalvarImagem(string path, byte[] bytes)
        {
            File.WriteAllBytes(Path.Combine(GetDiretorioDeImagens(), path), bytes);
        }

        public static void RemoveArquivo(string path)
        {
            if (!File.Exists(path)) return;

            File.Delete(path);
        }
    }
}