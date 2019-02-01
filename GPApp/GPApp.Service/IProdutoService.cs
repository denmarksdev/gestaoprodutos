using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GPApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace GPApp.Service
{
    public interface IProdutoService
    {
        Task<IActionResult> IncluiAsync(Produto produto);
        Task<IActionResult> Todos();
        Task<Produto> GetProduto(Guid id);
        Task<IActionResult> Atualiza(Produto produto);
        Task<IActionResult> SalvarProdutosAsync(IEnumerable<Produto> produto);
    }
}