using System;
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
        public Action IncluirProdutoAction { get ; set ; }
        public Action EnviarEmailAction { get ; set ; }
        public Action SincronizarComNuvemAction { get ; set; }

        #endregion

        #region Métodos

        public void ExibeBotoesAcaoAbaListagem(bool exibe)
        {
            metroButtonIncluir.Visible = exibe;
            metroButtonEmail.Visible = exibe;
            metroButtonFiltrar.Visible = exibe;
            metroButtonSincronizarNuvem.Visible = exibe;
        }

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

        public void ExibeAbaListagem()
        {
            tabControlProdutos.SelectedTab = tabPageListagem;
        }

        public void AdicionaEditPresenter(IProdutoEditView editView)
        {
            if (!(editView is Control editControl)) return;

            editControl.Dock = DockStyle.Fill;
            panelEditProduto.Controls.Add(editControl);
        }

        public void SetTextoBotaoFiltrar(string texto)
        {
            metroButtonFiltrar.Text = texto;
        }

        public void HabilitarBotaoSincronizacaoNuvem(bool habilita)
        {
            metroButtonSincronizarNuvem.Enabled = habilita;
        }

        public void ExibeProgressoWeb(bool exibir)
        {
            metroProgressBarSincronizar.Visible = exibir;
            metroProgressBarSincronizar.Enabled = exibir;
        }

        #endregion

        #region Handlers

        private event EventHandler _ativarFiltroHandler;

        private void MetroButtonIncluir_Click(object sender, EventArgs e)
        {
            IncluirProdutoAction?.Invoke();
        }

        private void MetroButtonEmail_Click(object sender, EventArgs e)
        {
            EnviarEmailAction?.Invoke();
        }

        private void MetroButtonSincronizarNuvem_Click(object sender, EventArgs e)
        {
            SincronizarComNuvemAction?.Invoke();
        }

        #endregion
    }
}