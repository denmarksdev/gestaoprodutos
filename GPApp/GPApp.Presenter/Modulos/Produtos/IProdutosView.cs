using GPApp.Presenter.Base;
using GPApp.Presenter.Grid;
using System;

namespace GPApp.Presenter.Modulos.Produtos
{
    public interface IProdutosView : IView
    {
        Action IncluirProdutoAction { get; set; }
        Action EnviarEmailAction { get; set; }
        void AdicionaGrid(IGridViewFiltro gridViewFiltro);
        void ExibeAbaEdicao();
        void ExibeAbaListagem();
        void AdicionaEditPresenter(IProdutoEditView editView);
        void ExibeBotoesAcaoAbaListagem(bool exibe);
    }
}