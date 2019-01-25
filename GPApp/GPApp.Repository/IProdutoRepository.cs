using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GPApp.Model;
using GPApp.Model.Helpers;

namespace GPApp.Repository
{
    public interface IProdutoRepository
    {
        Task<Resultado> IncluirAsync(Produto produto);
        Task<Resultado<Produto>> LocalizaPorChavePrimariaAsync(Guid id);
        Task<Resultado<IEnumerable<Produto>>> TodosAsyc();
        Task<Resultado<List<string>>> AtualizaAsync(Produto produto);
        Task<Resultado<IEnumerable<Produto>>> TodosComImagemAsyc();
    }
}