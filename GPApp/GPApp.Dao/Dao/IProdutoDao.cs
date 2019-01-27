using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GPApp.Model;

namespace GPApp.Dal.Dao
{
    public interface IProdutoDao
    {
        Task IncluirAsync(Produto produto);
        Task<Produto> LocalizarPorChavePrimaria(Guid id);
        Task<IEnumerable<Produto>> TodosAsync();
        Task<List<string>> Atualiza(Produto produto);
        Task<IEnumerable<Produto>> TodosComImagemAsync();
    }
}