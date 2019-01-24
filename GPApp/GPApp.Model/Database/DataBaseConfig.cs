namespace GPApp.Model.Database
{
    public class BancoDadosConfig
    {
        public BancoDadosConfig(BancoDados tipo, string stringConexao)
        {
            this.Tipo = tipo;
            this.StringConexao = stringConexao;
        }

        public BancoDados Tipo { get; }

        public string StringConexao { get; }
    }
}
