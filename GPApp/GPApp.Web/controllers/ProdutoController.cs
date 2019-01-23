using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPApp.Web.controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private static List<Produto> _produtos = new List<Produto>();

        // GET: api/Produto
        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _produtos;
        }

        // GET: api/Produto/5
        [HttpGet("{id}", Name = "Get")]
        public Produto Get(Guid id)
        {
            return _produtos.FirstOrDefault(p=> p.Id == id);
        }

        // POST: api/Produto
        [HttpPost]
        public void Post([FromBody] Produto produto) {
            _produtos.Add(produto);
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
