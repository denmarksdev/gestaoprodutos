using System;
using GPApp.Model;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace GPApp.Shared.Helpers
{
    public static class ImagemHelper
    {
        public const string STR_TAMANHO_REPLACE = "[T]";
        public static void SalvarImagem(ProdutoImagem imagem, Tamanho tamanho, Guid produtoId)
        {
            byte fator = GeraFator(tamanho);
            var imageParts = imagem.Dados.Split(',');
            string clean64 = ChecaImagemContemInformacoesAdicionaisBase64(imageParts);

            string filePath = GeraCaminho(imagem, tamanho, produtoId);

            try
            {
                byte[] dados = Convert.FromBase64String(clean64);

                using (var image = Image.Load(dados))
                {
                    image.Mutate(i =>
                        i.Resize(image.Width / fator, image.Height / fator)
                    );
                    image.Save(filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar a imagem \n{0}", ex.Message);
            }
        }

        private static string ChecaImagemContemInformacoesAdicionaisBase64(string[] imageParts)
        {
            return imageParts.Length == 1
                            ? imageParts[0]
                            : imageParts[1];
        }

        public static string GeraCaminho(ProdutoImagem imagem, Tamanho tamanho, Guid produtoId)
        {
            var path = ArquivoHelper.GetDiretorioDeImagensDeProdutos();
            return $"{path}/{produtoId.ToString()}_{GetTamanhaoAbreviado(tamanho)}{imagem.Ordem}.{imagem.Sufixo}";
        }

        public static string GeraCaminhoNoClient(ProdutoImagem imagem, Tamanho tamanho, Guid produtoId)
        {
            return $"imagens/produtos/{produtoId.ToString()}_{GetTamanhaoAbreviado(tamanho)}{imagem.Ordem}.{imagem.Sufixo}";
        }

        public static byte[] Base64ToBytes(string base64)
        {
           return Convert.FromBase64String(base64);
        }

        public static string BytesToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
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