using GPApp.Model;
using GPApp.Model.Helpers;
using GPApp.Repository;
using GPApp.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
                ExcluirImagens(imagensExcluidas);
                GerarImagensNoServidor(produto);
                return new StatusCodeResult(StatusCodes.Status202Accepted);
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        private static void ExcluirImagens(IEnumerable<string> imagensExcluidas)
        {
            foreach (var path in imagensExcluidas)
            {
                ArquivoHelper.RemoveArquivo(path);
            }
        }

        public async Task<IActionResult> IncluiAsync(Produto produto)
        {
            var resposta = await _repo.IncluirAsync(produto);
            if (resposta.Valido)
            {
                GerarImagensNoServidor(produto);
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

        public async Task<IActionResult> SalvarProdutosAsync(IEnumerable<Produto> produtos)
        {
            foreach (var produto in produtos)
            {
                produto.Sincronizado = true;
                produto.UltimaAtualizacao = DateTime.UtcNow;
            }

            var produtosIncluir = produtos.Where(p => p.Id == Guid.Empty);
            var produtosAtualizar = produtos.Where(p => p.Id != Guid.Empty);
            var resultadoIncluir = await _repo.IncluirAsync(produtosIncluir);
            var resultadoAtualizar = await _repo.AtualizaAsync(produtosAtualizar);

            var resultadoFinal = new ResultadoItens<Guid>();
            if (resultadoIncluir.Valido)
            {
                foreach (var produto in produtosIncluir)
                {
                    GerarImagensNoServidor(produto);
                }
            } else
            {
                resultadoFinal.Mensagens.Add(Shared.Constantes.ContantesGlobais.ERRO_INCLUSAO_ITENS);
                resultadoFinal.Mensagens.Add(resultadoIncluir.Mensagem);
            }

            if (resultadoAtualizar.Valido)
            {
                ExcluirImagens(resultadoAtualizar.Valor.Select(i => i.Value));
                var idsInvalidos = resultadoAtualizar.Valor.Select(i => i.Key);

                foreach (var produto in produtosAtualizar.Where( p=> !idsInvalidos.Contains(p.Id)))
                {
                    GerarImagensNoServidor(produto);
                }
            }else
            {
                resultadoFinal.Mensagens.Add(Shared.Constantes.ContantesGlobais.ERRO_ATUALIZACAO_ITENS);
                resultadoFinal.Mensagens.Add(resultadoAtualizar.Mensagem);
            }

            return new OkObjectResult(resultadoFinal);
        }

        private void GerarImagensNoServidor(Produto produto)
        {
            foreach (var imagem in produto.Imagens)
            {
                SalvarImagem(imagem, Tamanho.Original, produto.Id);
                SalvarImagem(imagem, Tamanho.Pequeno, produto.Id);
            }
        }

        private DateTimeOffset ReturnTimeOnServer(DateTimeOffset dateClient)
        {
            TimeSpan serverOffset = TimeZoneInfo.Local.GetUtcOffset(DateTimeOffset.Now);
            try
            {
                DateTimeOffset serverTime = dateClient.ToOffset(serverOffset);
                return serverTime;
            }
            catch 
            {
                return DateTimeOffset.MinValue;
            }
        }
    }
}