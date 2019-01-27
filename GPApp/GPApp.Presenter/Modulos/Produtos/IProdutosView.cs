using GPApp.Presenter.Base;
using GPApp.Presenter.Grid;
using System;

namespace GPApp.Presenter.Modulos.Produtos
{
    public interface IProdutosView : IView
    {
        Action LoadAction { get; set; }
        Action IncluirProdutAction { get; set; }
        Action EnviarEmailAction { get; set; }
        void AdicionaGrid(IGridViewFiltro gridViewFiltro);
        void ExibeAbaEdicao();
        void ExibeAbaManutencao();
    }
}