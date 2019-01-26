using System;

namespace GPApp.Presenter.Grid
{
    public interface IGridViewFiltro: IGridView
    {
        Action AtivarFiltroAction { get; set; }
        Action<string> FiltrarAcion { get; set; }
        Action RecuperarPaginacaoAction { get; set; }
        void ExibePainelPesquisa(bool exibir);
        void HabilitaGrid(bool desabilita);
        int NumeroRegitros();
    }
}