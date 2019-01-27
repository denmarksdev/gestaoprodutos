using System;
using GPApp.Presenter.Base;
using GPApp.Presenter.Grid;
using GPApp.Wrapper;

namespace GPApp.Presenter.Modulos.Produtos
{
    public class ProdutosPresenter : BasePresenter<ProdutoWrapper, IProdutosView>
    {
        #region Membros privados

        private readonly GridViewPresenter<ProdutoLookupWrapper> _gridViewPresenter;

        #endregion

        #region Construtor

        public ProdutosPresenter(
            IProdutosView view,
            GridViewPresenter<ProdutoLookupWrapper> gridViewPresenter
        ) : base(view)
        {
            _gridViewPresenter = gridViewPresenter;

            view.LoadAction = OnLoad;
            view.IncluirProdutAction = OnIncluirProduto;
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