using System;
using System.Linq;

namespace GPApp.Model.Lookups
{
    public class ProdutoLookup
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Estoque { get; set; }

        public ProdutoLookup()
        {
        }

        public ProdutoLookup(Produto produto)
        {
            Id = produto.Id;
            Codigo = produto.Codigo;
            Nome = produto.Nome;
            Preco = produto.Preco;
            DataCadastro = produto.DataCadastro;

            Estoque = produto.PosicoesEstoque
                         .OrderByDescending(e => e.Lancamento)
                         .First().Quantidade;
        }

        public static ProdutoLookup Empty
        {
            get => new ProdutoLookup
            {
                Id = Guid.Empty,
                Codigo = string.Empty,
                Nome = string.Empty,
                Preco = 0,
                Estoque = 0,
                DataCadastro = DateTime.MinValue
            };
        }
    }
}