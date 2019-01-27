using System.Collections.Generic;

namespace GPApp.Model
{
    public class Propaganda : BaseModel
    {
        public string Chave { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public List<PropagandaCliente> Clientes { get; set; }

        public Propaganda()
        {
            Clientes = new List<PropagandaCliente>();
        }
    }
}
