using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPApp.Model;
using GPApp.Repository;
using GPApp.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GPApp.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VitrineController : ControllerBase
    {
        private readonly IProdutoRepository _repository;

        public VitrineController(IProdutoRepository repository)
        {
            _repository = repository;
        }


        // GET: api/Vitrine
        [HttpGet]
        public async Task<IEnumerable<ItemVitrine>> Get()
        {
            List<ItemVitrine> vitrine = new List<ItemVitrine>();
            var resultado = await _repository.TodosComImagemAsyc();
            if (resultado.Valido)
            {
                foreach (var produto in resultado.Valor)
                {
                    var item = new ItemVitrine(produto);
                    DefineImagemUrl(produto, item);
                    vitrine.Add(item);
                }
            }
            return  vitrine;
        }

        private static void DefineImagemUrl(Produto produto, ItemVitrine item)
        {
            var imagem1 = produto.Imagens.FirstOrDefault();
            if (imagem1 == null)
            {
                item.ImagemUrl = "/imagens/produtos/sem-imagem.jpeg";
            }
            else
            {
                item.ImagemUrl = ImagemHelper.GeraCaminhoNoClient(imagem1, ImagemHelper.Tamanho.Pequeno, produto.Id);
            }
        }
    }
}