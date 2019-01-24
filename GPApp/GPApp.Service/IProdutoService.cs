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
    }
}