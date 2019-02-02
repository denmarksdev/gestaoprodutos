using System.Collections.Generic;

namespace GPApp.Model
{
    public class Propaganda : BaseModel
    {
        public string Titulo { get; set; }
        public string Chave { get; set; }
        public string Conteudo { get; set; }
        public string Sender { get; set; }
        public string NomeSender { get; set; }
        public List<PropagandaCliente> Clientes { get; set; }
        public List<ProdutoPropaganda> Produtos { get; set; }

        public Propaganda()
        {
            Clientes = new List<PropagandaCliente>();
        }
    }
}
