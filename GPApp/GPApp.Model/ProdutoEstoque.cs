using System;

namespace GPApp.Model
{
    public class ProdutoEstoque : BaseModel
    {
        public int Quantidade { get; set; }
        public  string ProdutoId  { get; set; }
        public DateTime Lancamento { get; set; }
    }
}
