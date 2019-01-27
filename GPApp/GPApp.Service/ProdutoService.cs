using GPApp.Model;
using GPApp.Repository;
using GPApp.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using static GPApp.Shared.Helpers.ImagemHelper;

namespace GPApp.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repo;

        public ProdutoService(IProdutoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Atualiza(Produto produto)
        {
            var resultado = await _repo.AtualizaAsync(produto);
            if (resultado.Valido)
            {
                var imagensExcluidas = resultado.Valor;
                foreach (var path in imagensExcluidas)
                {
                    ArquivoHelper.RemoveArquivo(path);
                }
                GerarImagensNoServidor(produto.Imagens, produto.Id);
                return new StatusCodeResult(StatusCodes.Status202Accepted);
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        public async Task<IActionResult> IncluiAsync(Produto produto)
        {
            var resposta = await _repo.IncluirAsync(produto);
            if (resposta.Valido)
            {
                GerarImagensNoServidor(produto.Imagens, produto.Id);
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        public async Task<Produto> GetProduto(Guid id)
        {
            var resultado = await _repo.LocalizaPorChavePrimariaAsync(id);
            Produto produto = null;
            if (resultado.Valido)
            {
                produto = resultado.Valor;
                foreach (var imagem in produto.Imagens)
                {
                    var path = ArquivoHelper.GetDiretorioDeImagensDeProdutos();
                    imagem.Preview = GeraCaminhoNoClient(imagem, Tamanho.Pequeno, produto.Id);
                }
            }
            return produto;
        }

        public async Task<IActionResult> Todos()
        {
            var resultado = await _repo.TodosAsyc();

            foreach (var item in resultado.Valor)
            {
                item.DataCadastro = ReturnTimeOnServer(item.DataCadastro);
            }

            if (resultado.Valido) return new OkObjectResult(resultado.Valor);

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        private void GerarImagensNoServidor(IEnumerable<ProdutoImagem> imagens, Guid produtoId)
        {
            foreach (var imagem in imagens)
            {
                SalvarImagem(imagem, Tamanho.Original, produtoId);
                SalvarImagem(imagem, Tamanho.Pequeno, produtoId);
            }
        }

        public DateTimeOffset ReturnTimeOnServer(DateTimeOffset dateClient)
        {
            TimeSpan serverOffset = TimeZoneInfo.Local.GetUtcOffset(DateTimeOffset.Now);
            try
            {
                DateTimeOffset serverTime = dateClient.ToOffset(serverOffset);
                return serverTime;
            }
            catch (FormatException ex)
            {
                return DateTimeOffset.MinValue;
            }
        }
    }
}