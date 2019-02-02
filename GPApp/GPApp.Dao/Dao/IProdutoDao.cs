using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GPApp.Model;

namespace GPApp.Dal.Dao
{
    public interface IProdutoDao
    {
        Task IncluirAsync(Produto produto);
        Task IncluirAsync(IEnumerable<Produto> produtos);

        Task<IEnumerable<string>> Atualiza(Produto produto);
        Task<Dictionary<Guid, IEnumerable<string>>> Atualiza(IEnumerable<Produto> produtos);

        Task<IEnumerable<Produto>> TodosAsync();
        Task<IEnumerable<Produto>> TodosComImagemAsync();

        Task<Produto> LocalizarPorChavePrimaria(Guid id);
        Task<IEnumerable<Produto>> BuscaProdutosNaoSincronizados();
        Task AtualizaSincronizacaoAsync(IEnumerable<Guid> ids, DateTimeOffset dataAtualizacao);
        Task<int> ProdutoNaoSincronizadosAsync();
        Task<IEnumerable<Guid>> GetIdsCadastradosAsync(IEnumerable<Guid> ids);
    }
}