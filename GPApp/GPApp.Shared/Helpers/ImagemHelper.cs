using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace GPApp.Shared.Helpers
{
    public static class ImagemHelper
    {
        public const string STR_TAMANHO_REPLACE = "[T]";
        public static void SalvarImagem(string base64, Tamanho tamanho, string path)
        {
            byte[] dados = null;
            byte fator = GeraFator(tamanho);
            var clean64 = base64.Split(',')[1];
            string novoCaminho = path.Replace("[T]", GetTamanhaoAbreviado(tamanho));

            try
            {
                dados = Convert.FromBase64String(clean64);
                System.IO.File.WriteAllBytes(novoCaminho, dados);

                using (var image = Image.Load(dados))
                {
                    image.Mutate(i =>
                        i.Resize(image.Width / fator, image.Height / fator)
                    );
                    image.Save(novoCaminho);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar a imagem \n{0}", ex.Message);
            }
        }

        private static string GetTamanhaoAbreviado(Tamanho tamanho)
        {
            switch (tamanho)
            {
                case Tamanho.Pequeno: return "P";
                case Tamanho.Medio: return "M";
                case Tamanho.Original: return "O";
            }

            throw new ArgumentException( nameof(tamanho));
        }

        private static byte GeraFator(Tamanho tamanho)
        {
            switch (tamanho)
            {
                case Tamanho.Pequeno: return 3;
                case Tamanho.Medio: return 2;
                case Tamanho.Original: return 1;
            }
            throw new ArgumentException(nameof(tamanho));
        }

        public enum Tamanho {
            Pequeno,
            Medio,
            Original
        }
    }
}