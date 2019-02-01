using GPApp.Model;
using GPApp.Model.Helpers;
using GPApp.Shared.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GPApp.Service
{
    public class ProdutoClientService : IProdutoClientService
    {
        private readonly string _baseUrl;

        public ProdutoClientService(IConfiguracaoService configuracaoService)
        {
            _baseUrl = configuracaoService.BaseUrlApi + "/produtos";
        }

        public async Task<ResultadoItens<Guid>> SalvarProdutos(IEnumerable<Produto> produtos)
        {
            using (var client = new HttpClient())
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(produtos);
                var content = new StringContent(json, UTF8Encoding.UTF8);
                var resposta = await client.PostAsync(_baseUrl + "/envia", content);

                if (resposta.IsSuccessStatusCode)
                {
                    var jsonReposta = await resposta.Content.ReadAsStringAsync();
                    var resultado = Newtonsoft
                        .Json
                        .JsonConvert
                        .DeserializeObject<ResultadoItens<Guid>>(jsonReposta);
                    return resultado;
                }

                return new ResultadoItens<Guid>(
                    "Falha ao processar a requisição",
                    resposta.ReasonPhrase);
            }
        }
    }
}
