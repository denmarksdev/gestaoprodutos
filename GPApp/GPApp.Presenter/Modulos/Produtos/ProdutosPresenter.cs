using GPApp.Presenter.Base;
using GPApp.Presenter.Grid;
using GPApp.Presenter.PubSub;
using GPApp.Presenter.PubSub.Eventos;
using GPApp.Service;
using GPApp.Shared.Paginacao;
using GPApp.Wrapper;

namespace GPApp.Presenter.Modulos.Produtos
{
    public class ProdutosPresenter : BasePresenter<IProdutosView>
    {
        #region Membros privados

        private readonly GridViewPresenter<ProdutoLookupWrapper> _gridViewPresenter;
        private readonly IEmailService _emailService;
        private readonly ProdutoEditPresenter _produtoEditPresenter;
        private readonly IPaginacaoRepository<ProdutoLookupWrapper> _paginacaoRepository;
        private readonly IEventAggregator _eventAggregator;

        #endregion

        #region Construtor

        public ProdutosPresenter(
            IProdutosView view,
            GridViewPresenter<ProdutoLookupWrapper> gridViewPresenter,
            IEmailService emailService,
            ProdutoEditPresenter produtoEditPresenter,
            IPaginacaoRepository<ProdutoLookupWrapper> paginacaoRepository,
            IEventAggregator eventAggregator
        ) : base(view)
        {
            _gridViewPresenter = gridViewPresenter;
            _emailService = emailService;
            _produtoEditPresenter = produtoEditPresenter;
            _paginacaoRepository = paginacaoRepository;
            _eventAggregator = eventAggregator;

            _eventAggregator.Subscribe<AtualizarGridProdutosEvent>(OnAtualizaGrid);

            view.LoadAction = OnLoad;
            view.IncluirProdutoAction = OnIncluirProduto;
            view.EnviarEmailAction = OnEnviarEmail;
        }

        #endregion

        #region Ações

        private async void OnAtualizaGrid(AtualizarGridProdutosEvent evento)
        {
            if (evento.Atualizar)
                await _gridViewPresenter.LoadAsync();
            ExibeListagem();
        }

        

        private async void OnLoad()
        {
            View.AdicionaEditPresenter(_produtoEditPresenter.View);
            await ConfiguraGrid();
        }

        private void OnIncluirProduto()
        {
            _produtoEditPresenter.IncluirProduto();
            ExibeEdicao();
        }

        private async void OnEnviarEmail()
        {
            // TODO: Criar envio de email
            //var resultado =  await _emailService.Envia(  EmailTemplate.GetEmailMarketing());
            //if (!resultado.Valido)
            //{
            //}
        }

        #endregion

        #region Métodos

        private async System.Threading.Tasks.Task ConfiguraGrid()
        {
            _gridViewPresenter.GridView.RodapeTexto = new[] { "produto", "produtos" };
            _gridViewPresenter.SetGridInfo(ProdutoGridConfigBuilder.Instancia(_paginacaoRepository));
            await _gridViewPresenter.LoadAsync();
            View.AdicionaGrid(_gridViewPresenter.GridView);
        }

        public void ExibeListagem()
        {
            View.ExibeAbaListagem();
            View.ExibeBotoesAcaoAbaListagem(true);
        }

        public void ExibeEdicao()
        {
            View.ExibeAbaEdicao();
            View.ExibeBotoesAcaoAbaListagem(false);
        }

        #endregion
    }
}