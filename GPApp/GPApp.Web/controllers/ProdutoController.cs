using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPApp.Model;
using GPApp.Service;
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
        public Produto Get(Guid id)
        {
            return _produtos.FirstOrDefault(p=> p.Id == id);
        }

        // POST: api/Produto
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produto produto) {
           return await _service.IncluiAsync(produto);
        }

        // PUT: api/Produto/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
