using System;

namespace GPApp.Model
{
    public class ItemVitrine
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public decimal PrecoPromocional { get; set; }
        public string ImagemUrl { get; set; }

        public ItemVitrine(Produto produto)
        {
            Id = produto.Id;
            Nome = produto.Nome;
            Preco = produto.Preco;
            PrecoPromocional = produto.PrecoPromocional;
        }
    }
}