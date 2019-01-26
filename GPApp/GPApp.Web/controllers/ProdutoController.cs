using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GPApp.Model;
using GPApp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPApp.Web.controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        private static List<Produto> _produtos = new List<Produto>();
        private readonly IProdutoService _service;

        // GET: api/Produto
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await _service.Todos();
        }

        // GET: api/Produto/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Produto> Get(Guid id)
        {
            return await _service.GetProduto(id);
        }

        // POST: api/Produto
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produto produto) {
           return await _service.IncluiAsync(produto);
        }

        // PUT: api/Produto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Produto produto)
        {
            if (id != produto.Id) return new StatusCodeResult((int) StatusCodes.Status404NotFound) ;
            return await _service.Atualiza(produto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
