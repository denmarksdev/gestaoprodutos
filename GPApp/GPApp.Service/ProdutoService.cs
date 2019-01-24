using GPApp.Model;
using GPApp.Shared.Dados;
using GPApp.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPApp.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IGenericRepository<Produto> _repo;

        public ProdutoService(IGenericRepository<Produto> repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> IncluiAsync(Produto produto)
        {
            var resposta = await _repo.IncluiAsync(produto);
            if (resposta.Valido)
            {
                GerarImagensNoServidor(produto.Imagens);
                return new OkResult();
            }
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        public async Task<IActionResult> Todos()
        {
            var resultado = await _repo.TodosAsyc();
            if (resultado.Valido) return new OkObjectResult(resultado.Valor);

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        private void GerarImagensNoServidor(IEnumerable<ProdutoImagem> imagens)
        {
            var path = ArquivoHelper.GetDiretorioDeImagensDeProdutos();
            foreach (var imagem in imagens)
            {
                var filePath = $@"{path}\{imagem.Id}_{ImagemHelper.STR_TAMANHO_REPLACE}.jpeg";

                ImagemHelper.SalvarImagem(imagem.Dados, ImagemHelper.Tamanho.Original, filePath);
                ImagemHelper.SalvarImagem(imagem.Dados, ImagemHelper.Tamanho.Pequeno, filePath);
            }
        }
    }
}
