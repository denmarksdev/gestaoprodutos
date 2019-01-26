using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPApp.Presenter.Grid
{
    public class GridViewPresenter<T>
    {
        #region Membros

        private GridConfig<T> _gridInfo;
        public IGridViewFiltro GridView;
        public bool FiltroAtivo { get; set; }
        public event EventHandler<Boolean> FiltrouEvent;

        #endregion

        #region Construtor

        public GridViewPresenter(IGridViewFiltro gridView)
        {
            GridView = gridView;
            GridView.Inicializa = OnInicializaGrid;
            GridView.GetValue = OnGetValueGrid;
            GridView.OrderAction = OnOrderAction;
            GridView.FiltrarAcion = OnFiltrarAction;
            GridView.ErroPagincaoAction = OnErroPaginacaoAction;
        }

        #endregion

        #region Ações

        private Task<bool> OnInicializaGrid()
        {
            var tarefa = Task.Run<bool>(() =>
            {
                _gridInfo.Cache.CarregarDuasPaginas();
                return true;

            });

            var continueUi = tarefa.ContinueWith(async (t) =>
            {

                var continuar = await t;
                if (!continuar) return;

                AtualizaRowGridView();

            }, TaskScheduler.FromCurrentSynchronizationContext());


            return tarefa;
        }

        private object OnGetValueGrid(int indice, string nomePropriedade)
        {
            return _gridInfo.Cache.RecuperarValorDoItem(indice, nomePropriedade);
        }

        private void OnErroPaginacaoAction()
        {
            _gridInfo.Cache.LimparCache();
            GridView.AtualizarDesign();
        }

        private void OnFiltrarAction(string textoPesquisa)
        {
            Filtra(textoPesquisa);
            GridView.ExibePainelPesquisa(false);
            FiltroAtivo = !string.IsNullOrWhiteSpace(textoPesquisa);
            FiltrouEvent.Invoke(this, FiltroAtivo);
        }

        private void OnOrderAction(string nomePropriedade)
        {
            _gridInfo.DataRetriever.Order = nomePropriedade;
            _gridInfo.Cache.CarregarDuasPaginas();
            GridView.AtualizarDesign();
        }

        #endregion

        #region Métodos

        public void AtualizaRowGridView()
        {
            GridView.SetNumeroRegistros(_gridInfo.DataRetriever.NumeroRegistros);
            GridView.AtualizarDesign();

        }

        public void SetColunaChave(string chave)
        {
            GridView.ColunaChave = chave;
        }

        public void SetGridInfo(GridConfig<T> gridInfo)
        {
            _gridInfo = gridInfo;
            GridView.SetColunas(_gridInfo.ColumnsInfo);
            GridView.DefineColunaModoLeitura(_gridInfo.ModoLeitura);
            GridView.ColunaChave = gridInfo.ColunaChave;
        }

        public Task<bool> Load()
        {
            return GridView.Inicializa();
        }

        public void LimpaFiltro()
        {
            Filtra(string.Empty);
            FiltroAtivo = false;
        }

        internal Task<IList<T>> GetItensAsync()
        {
            return _gridInfo.DataRetriever.GetItensAsync();
        }

        internal IList<M> GetIds<M>()
        {
            return _gridInfo.DataRetriever.Getids<M>();
        }

        private void Filtra(string textoPesquisa)
        {
            _gridInfo.DataRetriever.Pesquisa = textoPesquisa;
            GridView.SetNumeroRegistros(0);
        }

        #endregion
    }
}