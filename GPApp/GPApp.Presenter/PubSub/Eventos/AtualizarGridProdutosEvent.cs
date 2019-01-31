namespace GPApp.Presenter.PubSub.Eventos
{
    public class AtualizarGridProdutosEvent : IApplicationEvent
    {
        public AtualizarGridProdutosEvent(bool atualizar)
        {
            Atualizar = atualizar;
        }

        public bool Atualizar { get; private set; }
    }
}