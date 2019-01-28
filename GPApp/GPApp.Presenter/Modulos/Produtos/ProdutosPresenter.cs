using GPApp.Presenter.Base;
using GPApp.Presenter.Grid;
using GPApp.Service;
using GPApp.Wrapper;

namespace GPApp.Presenter.Modulos.Produtos
{
    public class ProdutosPresenter : BasePresenter<ProdutoWrapper, IProdutosView>
    {
        #region Membros privados

        private readonly GridViewPresenter<ProdutoLookupWrapper> _gridViewPresenter;
        private readonly IEmailService _emailService;

        #endregion

        #region Construtor

        public ProdutosPresenter(
            IProdutosView view,
            GridViewPresenter<ProdutoLookupWrapper> gridViewPresenter,
            IEmailService emailService
        ) : base(view)
        {
            _gridViewPresenter = gridViewPresenter;
            _emailService = emailService;

            view.LoadAction = OnLoad;
            view.IncluirProdutoAction = OnIncluirProduto;
            view.EnviarEmailAction = OnEnviarEmail;
        }
                
        #endregion

        #region Ações

        private async void OnLoad()
        {
            await ConfiguraGrid();
        }

        private void OnIncluirProduto()
        {
            View.ExibeAbaEdicao();
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
            _gridViewPresenter.SetGridInfo(ProdutoGridConfigBuilder.Instancia());
            await _gridViewPresenter.LoadAsync();
            View.AdicionaGrid(_gridViewPresenter.GridView);
        }
        #endregion
    }
}