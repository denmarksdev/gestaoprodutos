using System;
using System.Drawing;
using System.Windows.Forms;
using GPApp.Presenter.Grid;
using GPApp.Presenter.Modulos.Produtos;
using MetroFramework.Forms;

namespace GPApp.WinForms.Views
{
    public partial class ProdutosView : MetroForm, IProdutosView
    {
        #region Construtor
        public ProdutosView()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrrides
        protected override void OnLoad(EventArgs e)
        {
            Text = "Produtos";
            base.OnLoad(e);
            LoadAction?.Invoke();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);    
        }

        #endregion

        #region Propriedades

        public Action LoadAction { get ; set ; }
        public Action IncluirProdutAction { get ; set ; }
        public Action EnviarEmailAction { get ; set ; }

        #endregion

        #region Métodos


        public void AdicionaGrid(IGridViewFiltro gridViewFiltro)
        {
            var control = (Control)gridViewFiltro;
            if (metroPanelGrid.Controls.Contains(control)) return;
            
            control.Dock = DockStyle.Fill;
            metroPanelGrid.Controls.Add(control);
            metroPanelGrid.Focus();

            _ativarFiltroHandler += (s, e) =>
            {
                gridViewFiltro.AtivarFiltroAction?.Invoke();
            };

            metroButtonFiltrar.Click += _ativarFiltroHandler;
        }

        public void ExibeAbaEdicao()
        {
            tabControlProdutos.SelectedTab = tabPageEdicao;
        }

        public void ExibeAbaManutencao()
        {
            tabControlProdutos.SelectedTab = tabPageManutencao;
        }

        #endregion

        #region Handlers

        private event EventHandler _ativarFiltroHandler;

        private void MetroButtonIncluir_Click(object sender, EventArgs e)
        {
            IncluirProdutAction?.Invoke();
        }

        private void MetroButtonEmail_Click(object sender, EventArgs e)
        {
            EnviarEmailAction?.Invoke();
        }

        #endregion
    }
}