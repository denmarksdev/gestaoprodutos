namespace GPApp.Model
{
    public class Usuario : BaseModel
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
    }
}