using System.Collections;
using System.Collections.Generic;

namespace GPApp.Model
{
    public class Produto : BaseModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal Custo { get; set; }

        public virtual IList<ProdutoImagem> Imagens { get; set; }
        public virtual IList<ProdutoEspecificacao> Especificacoes { get; set; }
        public virtual IList<ProdutoEstoque> PosicoesEstoque { get; set; }
               
        public Produto()
        {
            Imagens = new List<ProdutoImagem>();
            Especificacoes = new List<ProdutoEspecificacao>();
            PosicoesEstoque = new List<ProdutoEstoque>();
        }
    }
}