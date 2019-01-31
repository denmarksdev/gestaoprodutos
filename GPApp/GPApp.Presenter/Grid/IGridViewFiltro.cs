using System;

namespace GPApp.Presenter.Grid
{
    public interface IGridViewFiltro: IGridView
    {
        /// <summary>
        /// {Singular|Plural}
        /// </summary>
        string[] RodapeTexto { get; set; }
        bool FiltroAtivo { get; set; }

        Action AtivarFiltroAction { get; set; }
        Action<string> FiltrarAcion { get; set; }
        Action RecuperarPaginacaoAction { get; set; }
        void ExibePainelPesquisa(bool exibir);
        void HabilitaGrid(bool desabilita);
        int NumeroRegitros();
    }
}