using System;

namespace GPApp.Model
{
    public class ProdutoEstoque : BaseModel
    {
        public int Quantidade { get; set; }
        public Guid ProdutoId { get; set; }
        public DateTime Lancamento { get; set; }
    }
}