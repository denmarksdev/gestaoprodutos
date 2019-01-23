namespace GPApp.Model
{
    public class ProdutoImagem : BaseModel
    {
        public string Prefixo { get; set; }
        public string Sufixo { get; set; }
        public byte[] Dados { get; set; }
        public short Ordem { get; set; }
    }
}
