using System;

namespace GPApp.Model
{
    public class Cliente : BaseModel
    {
        public string Nome { get; set; }
        public string Email  { get; set; }
        public DateTimeOffset DataCadastro { get; set; }
    }
}
