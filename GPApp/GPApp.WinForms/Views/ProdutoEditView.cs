using GPApp.Presenter.Modulos.Produtos;
using GPApp.WinForms.Helpers;
using GPApp.Wrapper;
using MetroFramework.Controls;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GPApp.WinForms.Views
{
    public partial class ProdutoEditView : UserControl, IProdutoEditView
    {
        #region Membros privados

        //private bool _processandoInclusao;
        private int[] _colunasAcaoImagemindex;

        #endregion

        #region Construtor

        public ProdutoEditView()
        {
            InitializeComponent();
            CoresHelper.ConfiguraBotaoConfirmacao(metroButtonSalvar);
            CoresHelper.ConfiguraBotaoSecundario(metroButtonIncluirImagem);
            CoresHelper.ConfiguraBotaoSecundario(metroButtonIncluirEspecificacao);
            metroTabControlProdutoEdit.SelectedTab = metroTabPagePrincipal;
            ConfiguracoesGridDeImagens();
            ConfiguracoesGridDeEspecificacoes();
        }

        #endregion

        #region Propriedades

        public Action LoadAction { get; set; }
        public Action IncluirImagemAction { get; set; }
        public Action<ProdutoImagemWrapper> AlterarImagemAction { get; set; }
        public Action<ProdutoImagemWrapper> ExcluirImagemAction { get; set; }
        public Action IncluirEspecificacaoAction { get; set; }
        public Action<ProdutoEspecificacaoWrapper> ExcluirEspecificacaoAction { get; set; }
        public Action SalvarAction { get ; set ; }
        public Action CancelarAction { get ; set ; }

        #endregion

        #region Overrides

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadAction?.Invoke();
        }

        #endregion

        #region Métodos

        public void ExibirProgressoSalvar(bool exibir)
        {
            metroProgressSpinnerSalvar.Visible = exibir;
            metroProgressSpinnerSalvar.Enabled = exibir;
        }

        public void FocoPrincipal()
        {
            throw new NotImplementedException();
        }

        private void ConfiguracoesGridDeEspecificacoes()
        {
            metroGridEspecificacoes.BorderStyle = BorderStyle.FixedSingle;
            metroGridEspecificacoes.CellClick += MetroGridEspecificacoes_CellClick;
            metroGridEspecificacoes.CellMouseEnter += MetroGridEspecificacoes_CellMouseEnter;
            metroGridEspecificacoes.CellMouseLeave += MetroGridEspecificacoes_CellMouseLeave; ;
        }

        private void MetroGridEspecificacoes_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as MetroGrid;
            grid.Cursor = Cursors.Default;
        }

        private void MetroGridEspecificacoes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as MetroGrid;
            if (e.ColumnIndex == ColumnEspExcluir.Index)
            {
                grid.Cursor = Cursors.Hand;
            }
        }

        private void MetroGridEspecificacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex != ColumnEspExcluir.Index) return;

            var grid = sender as MetroGrid;
            var espe = grid.Rows[e.RowIndex].DataBoundItem as ProdutoEspecificacaoWrapper;
            ExcluirEspecificacaoAction?.Invoke(espe);
        }

        private void ConfiguracoesGridDeImagens()
        {
            _colunasAcaoImagemindex = new[]
                        {
                alterarImagemColumn.Index,
                ExcluirImagemColumn.Index
            };
            metroGridImagens.BorderStyle = BorderStyle.FixedSingle;
            metroGridImagens.SelectionChanged += MetroGridImagens_SelectionChanged;
            metroGridImagens.CellClick += MetroGridImagens_CellClick;
            metroGridImagens.DataError += MetroGridImagens_DataError;
            metroGridImagens.CellMouseEnter += MetroGridImagens_CellMouseEnter;
            metroGridImagens.CellMouseLeave += MetroGridImagens_CellMouseLeave;
        }

        public void HabiltaBotaoSalvar(bool habilitar)
        {
            metroButtonSalvar.Enabled = habilitar;
        }

        public void IncluirImagem(ProdutoImagemWrapper imagemWrapper)
        {
            var indice = produtoImagemBindingSource.Add(imagemWrapper);

            //TODO: Melhorar ação de seleção.
            //_processandoInclusao = true;
            //metroGridImagens.ClearSelection();
            //_processandoInclusao = false;
            //metroGridImagens.Rows[indice].Selected = true;
        }

        public void ExcluirImage(ProdutoImagemWrapper imagemWrapper)
        {
            produtoImagemBindingSource.Remove(imagemWrapper);
        }

        public void SelecionarPrimeiroCampoEdicao()
        {
            customEditCodigo.Focus();
        }

        public void ConfiguraProdutoBindings(ProdutoEditPresenter presenter)
        {
            ProdutoBindingSource.DataSource = ProdutoWrapper.Empty;

            BindingHelper.Configura(
                customEditCodigo.Edit,
                nameof(customEditCodigo.Edit.Text),
                ProdutoBindingSource,
                nameof(ProdutoWrapper.Codigo)
            );
            BindingHelper.Configura(
                customEditNome.Edit,
                nameof(customEditNome.Edit.Text),
                ProdutoBindingSource,
                nameof(ProdutoWrapper.Nome)
            );
            BindingHelper.Configura(
                customEditMultlineDescricao.Edit,
                nameof(customEditMultlineDescricao.Edit.Text),
                ProdutoBindingSource,
                nameof(ProdutoWrapper.Descricao)
            );
            BindingHelper.Configura(
                customEditCusto.Edit,
                nameof(customEditCusto.Edit.Text),
                ProdutoBindingSource,
                nameof(ProdutoWrapper.Custo),
                mascara: "N2"
            );
            BindingHelper.Configura(
                customEditPreco.Edit,
                nameof(customEditPreco.Edit.Text),
                ProdutoBindingSource,
                nameof(ProdutoWrapper.Preco),
                mascara: "N2"
            );
            BindingHelper.Configura(
                customEditPrecoPromocional.Edit,
                nameof(customEditPrecoPromocional.Edit.Text),
                ProdutoBindingSource,
                nameof(ProdutoWrapper.PrecoPromocional),
                mascara: "N2"
            );
            BindingHelper.Configura(
                customEditQuantidade.Edit,
                nameof(customEditQuantidade.Edit.Text),
                presenter,
                nameof(presenter.Quantidade),
                mascara: "N0"
            );
        }

        public void InicializaBinding(ProdutoWrapper wrapper)
        {
            ProdutoBindingSource.DataSource = wrapper;
            produtoImagemBindingSource.DataSource = wrapper.Imagens;
            produtoEspecificacaoBindingSource.DataSource = wrapper.Especificacoes;

            ProdutoBindingSource.ResumeBinding();
            produtoImagemBindingSource.ResumeBinding();
            produtoEspecificacaoBindingSource.ResumeBinding();
        }

        public void SetMensagenErro(string propriedade, string mensagem)
        {
            switch (propriedade)
            {
                case nameof(ProdutoWrapper.Codigo):
                    customEditCodigo.LabelErroText = mensagem;
                    break;
                case nameof(ProdutoWrapper.Nome):
                    customEditNome.LabelErroText = mensagem;
                    break;
                case nameof(ProdutoWrapper.Descricao):
                    customEditMultlineDescricao.LabelErroText = mensagem;
                    break;
                case nameof(ProdutoWrapper.Custo):
                    customEditCusto.LabelErroText = mensagem;
                    break;
                case nameof(ProdutoWrapper.Preco):
                    customEditPreco.LabelErroText = mensagem;
                    break;
                case nameof(ProdutoWrapper.PrecoPromocional):
                    customEditPrecoPromocional.LabelErroText = mensagem;
                    break;
            }
        }

        public void SetImagemPreview(string base64)
        {
            if (string.IsNullOrWhiteSpace(base64))
            {
                pictureBoxPreview.Image = null;
                return;
            }

            var bytes = Shared.Helpers.ImagemHelper.Base64ToBytes(base64);
            var imagem = Helpers.ImagemHelper.ImagemFromBytes(bytes);
            pictureBoxPreview.Image = imagem;
        }

        public void SelecionaImagemGrid(int indice)
        {
            if (indice < 0)
            {
                SetImagemPreview(String.Empty);
                return;
            }
            metroGridImagens.Rows[indice].Selected = true;
        }

        public void IncluirEspecificacao(ProdutoEspecificacaoWrapper produtoEspecificacaoWrapper)
        {
            var indice = produtoEspecificacaoBindingSource.Add(produtoEspecificacaoWrapper);
            var celula = metroGridEspecificacoes[EspNomeDataGridViewTextBoxColumn.Index, indice];
            metroGridEspecificacoes.CurrentCell = celula;
            metroGridEspecificacoes.BeginEdit(true);
        }

        public void ExcluirEspecificacao(ProdutoEspecificacaoWrapper produtoEspecificacaoWrapper)
        {
            produtoEspecificacaoBindingSource.Remove(produtoEspecificacaoWrapper);
        }

        #endregion

        #region Handlers

        private void MetroButtonIncluirImagem_Click(object sender, EventArgs e)
        {
            IncluirImagemAction?.Invoke();
        }

        private void MetroGridImagens_SelectionChanged(object sender, EventArgs e)
        {
            //if (_processandoInclusao) return;
            if (!(sender is MetroGrid grid)) return;

            if (grid.CurrentRow == null)
            {
                SetImagemPreview(string.Empty);
            }
            else
            {
                var imagem = grid.CurrentRow.DataBoundItem as ProdutoImagemWrapper;
                SetImagemPreview(imagem.Dados);
            }
        }

        private void MetroGridImagens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (!_colunasAcaoImagemindex.Contains(e.ColumnIndex)) return;

            var imagem = metroGridImagens.Rows[e.RowIndex].DataBoundItem as ProdutoImagemWrapper;
            if (e.ColumnIndex == alterarImagemColumn.Index)
            {
                AlterarImagemAction?.Invoke(imagem);
            }
            else if (e.ColumnIndex == ExcluirImagemColumn.Index)
            {
                ExcluirImagemAction?.Invoke(imagem);
            }
        }

        private void MetroGridImagens_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void MetroGridImagens_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as MetroGrid;
            if (_colunasAcaoImagemindex.Contains(e.ColumnIndex))
            {
                grid.Cursor = Cursors.Hand;
            }
        }

        private void MetroGridImagens_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as MetroGrid;
            grid.Cursor = Cursors.Default;
        }

        private void MetroButtonIncluirEspecificacao_Click(object sender, EventArgs e)
        {
            IncluirEspecificacaoAction?.Invoke();
        }

        private void MetroButtonSalvar_Click(object sender, EventArgs e)
        {
            SalvarAction?.Invoke();
        }

        private void MetroButtonCancelar_Click(object sender, EventArgs e)
        {
            CancelarAction?.Invoke();
        }


    }

    #endregion
}   