using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GPApp.Model;
using GPApp.Model.Helpers;

namespace GPApp.Service
{
    public interface IProdutoClientService
    {
        Task<ResultadoItens<Guid>> SalvarProdutos(IEnumerable<Produto> produtos);
    }
}