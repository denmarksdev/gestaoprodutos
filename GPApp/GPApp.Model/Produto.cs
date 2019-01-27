using System;
using System.Collections.Generic;

namespace GPApp.Model
{
    public class Produto : BaseModel
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public decimal PrecoPromocional { get; set; }
        public decimal Custo { get; set; }
        public DateTime DataCadastro { get; set; }
        public ProdutoEstoque EstoqueAtual { get; set; }

        public virtual List<ProdutoImagem> Imagens { get; set; }
        public virtual List<ProdutoEspecificacao> Especificacoes { get; set; }
        public virtual List<ProdutoEstoque> PosicoesEstoque { get; set; }
               
        public Produto()
        {
            Imagens = new List<ProdutoImagem>();
            Especificacoes = new List<ProdutoEspecificacao>();
            PosicoesEstoque = new List<ProdutoEstoque>();
        }
    }
}