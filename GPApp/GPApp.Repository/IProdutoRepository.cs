﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GPApp.Model;
using GPApp.Model.Helpers;

namespace GPApp.Repository
{
    public interface IProdutoRepository
    {
        Task<Resultado> IncluirAsync(Produto produto);
        Task<Resultado>IncluirAsync(IEnumerable<Produto> produtos);

        Task<Resultado<IEnumerable<string>>> AtualizaAsync(Produto produto);
        Task<Resultado<Dictionary<Guid, IEnumerable<string>>>> AtualizaAsync(IEnumerable<Produto> produto);

        Task<Resultado<Produto>> LocalizaPorChavePrimariaAsync(Guid id);
        Task<Resultado<IEnumerable<Produto>>> TodosAsyc();

        Task<Resultado<IEnumerable<Produto>>> TodosComImagemAsyc();
        Task<Resultado<IEnumerable<Produto>>> BuscaProdutosNaoSincronizados();
        Task<Resultado> AtualizaSincronizacaoAsync(IEnumerable<Guid> enumerable, DateTimeOffset dataAtualizacao);
        Task<Resultado<int>> NumeroRegistrosSincronizarAsync();
        Task<Resultado<IEnumerable<Guid>>> GetIdsCadastradosAsync(IEnumerable<Guid> ids);
    }
}