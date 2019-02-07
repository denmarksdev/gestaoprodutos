namespace GPApp.Model.Helpers
{
    public class NavegacaoParametro
    {
        public NavegacaoParametro(string operacao)
        {
            Operacao = operacao;
        }

        public string Operacao { get; }
    }

    public class NavegacaoParametro<T> : NavegacaoParametro
    {
        public NavegacaoParametro(string operacao, T item):base(operacao)
        {
            Item = item;
        }

        public NavegacaoParametro():this(string.Empty, default(T))
        {
        }
        
        public T Item { get; }
    }
}