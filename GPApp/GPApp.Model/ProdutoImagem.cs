namespace GPApp.Model
{
    public class ProdutoImagem : BaseModel
    {
        public string Prefixo { get; set; }
        public string Sufixo { get; set; }
        public string Dados { get; set; }
        public short Ordem { get; set; }
    }
}
