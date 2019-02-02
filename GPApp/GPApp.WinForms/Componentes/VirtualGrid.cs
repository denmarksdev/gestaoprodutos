﻿using GPApp.Presenter.Grid;
using GPApp.Shared.Helpers;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPApp.WinForms.Componentes
{
    public partial class VirtualGrid : MetroGrid , IGridView
    {
        #region Membros privados

        private const string COLUNA_SUFIXO = "Column";
        private const string COLUNA_ALTERACAO = ColunaInfo.COLUNA_ALTERACAO + COLUNA_SUFIXO;
        private string _colunaChave;
        private readonly List<string> _naoOrdenarColunas = new List<string>();
        private ColunaFormataInfo _formataInfo = new ColunaFormataInfo();

        #endregion

        #region Construtor

        public VirtualGrid()
        {
            InitializeComponent();

            ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8.0F, FontStyle.Bold);
            VirtualMode = true;
            RowHeadersVisible = false;
            BorderStyle = BorderStyle.None;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
        }

        #endregion

        #region Propriedades

        public string ColunaChave { get ; set ; }
        public bool ErroPaginacao { get ; set ; }
        public Func<int, string, object> GetValue { get ; set ; }
        public Action<string> OrderAction { get ; set ; }
        public Action ConsultaAction { get ; set ; }
        public Action ErroPagincaoAction { get ; set ; }
        public Func<Task<bool>> Inicializa { get ; set ; }
        public Func<ColunaFormataInfo, ColunaFormataInfo> FormataCelulaFunc { get ; set ; }
        public Action<object> AlterarAction { get ; set ; }

        #endregion

        #region Overrides

        protected override void OnCellValueNeeded(DataGridViewCellValueEventArgs e)
        {
            try
            {
               var propriedade = Columns[e.ColumnIndex].DataPropertyName;

                if (ErroPaginacao) return;
                if (propriedade == ColunaInfo.COLUNA_ALTERACAO) return;
                e.Value = GetValue?.Invoke(e.RowIndex, propriedade) ;
            }
            catch (Exception)
            {
                ErroPaginacao = true;
                RowCount = 0;
                ErroPagincaoAction?.Invoke();
            }
        }

        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            var nomePropriedade = Columns[e.ColumnIndex].DataPropertyName;
            if (_naoOrdenarColunas.Contains(nomePropriedade)) return;

            OrderAction?.Invoke(nomePropriedade);

            foreach (DataGridViewColumn coluna in Columns)
            {
                coluna.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
        }

        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            base.OnCellFormatting(e);

            _formataInfo.CorTexto = CoresHelper.Preto;
            _formataInfo.CoreFundo = CoresHelper.Branco;
            _formataInfo.CorFundoSelecao = CoresHelper.Primaria;
            _formataInfo.CorTextoSelecao = CoresHelper.Branco;
            _formataInfo.Valor = e.Value;
            _formataInfo.NomePropriedade = this.Columns[e.ColumnIndex].DataPropertyName;
            _formataInfo.IndexRow = e.RowIndex;

            _formataInfo = FormataCelulaFunc?.Invoke(_formataInfo)??_formataInfo;

            e.CellStyle.BackColor = ColorTranslator.FromHtml(_formataInfo.CoreFundo);
            e.CellStyle.ForeColor = ColorTranslator.FromHtml(_formataInfo.CorTexto);
            e.CellStyle.SelectionBackColor = ColorTranslator.FromHtml(_formataInfo.CorFundoSelecao);
            e.CellStyle.SelectionForeColor = ColorTranslator.FromHtml(_formataInfo.CorTextoSelecao);
            e.Value = _formataInfo.Valor;
        }

        protected override void OnColumnHeadersDefaultCellStyleChanged(EventArgs e)
        {
            base.OnColumnHeadersDefaultCellStyleChanged(e);
            ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(CoresHelper.Secundaria);

            EnableHeadersVisualStyles = false;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ColumnHeadersHeight = 50;
        }

        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            if (Columns[e.ColumnIndex].DataPropertyName == ColunaInfo.COLUNA_ALTERACAO)
            {
                var valor = this[_colunaChave, e.RowIndex].Value;

                AlterarAction?.Invoke(valor);
            }

            base.OnCellClick(e);
        }

        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            if (  Columns.Contains(COLUNA_ALTERACAO) && e.ColumnIndex == Columns[COLUNA_ALTERACAO].Index )
            {
                this.Cursor = Cursors.Hand;
            }
            base.OnCellMouseEnter(e);
        }

        protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Default;
            base.OnCellMouseLeave(e);
        }

        #endregion

        #region Métodos

        public void AtualizarDesign()
        {
            Update();
            Invalidate();
        }

        public void DefineColunaModoLeitura(bool permitir)
        {
            foreach (DataGridViewColumn column in Columns)
            {
                column.ReadOnly = !permitir;
            }
        }

        public T GetValorChaveDataRowAtual<T>(string coluna = null)
        {
            var nomePropriedade = coluna ?? ColunaChave;

            if (nomePropriedade == null) return default(T);
            if (Rows.Count == 0) return default(T);
            if (CurrentRow == null) return default(T);
            if (!Columns.Contains(nomePropriedade + COLUNA_SUFIXO)) return default(T);
                       
            return (T)CurrentRow.Cells[nomePropriedade + COLUNA_SUFIXO].Value;
        }

        public void SetColunas(IList<ColunaInfo> colunas)
        {
            foreach (ColunaInfo coluna in colunas)
            {
                DataGridViewColumn columnGrid = CriaColuna(coluna);

                columnGrid.DataPropertyName = coluna.NomePropriedade;
                columnGrid.Name = coluna.NomePropriedade + COLUNA_SUFIXO;
                columnGrid.HeaderText = coluna.Titulo;
                columnGrid.SortMode = DataGridViewColumnSortMode.Programmatic;
                columnGrid.HeaderCell.Style.Alignment = DefineAlinhamento(coluna.TipoAlinhamento);
                columnGrid.DefaultCellStyle.Alignment = columnGrid.HeaderCell.Style.Alignment;
                columnGrid.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(CoresHelper.Primaria);
                columnGrid.HeaderCell.Style.ForeColor = ColorTranslator.FromHtml(CoresHelper.Secundaria);
                columnGrid.Visible = coluna.Exibir;

                ConfiguraColunasParaNaoOrdenar(coluna);
                ConfiguraTipo(coluna, columnGrid);
                AjustaTamanhoModoDimensionamento(coluna, columnGrid);

                if (coluna.ChavePrimaria)
                {
                    _colunaChave = columnGrid.Name;
                }

                Columns.Add(columnGrid);
            }
            DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(CoresHelper.Primaria);
        }

        private void AjustaTamanhoModoDimensionamento(ColunaInfo coluna, DataGridViewColumn columnGrid)
        {
            if (coluna.TipoAjuste != ColunaTipoAjuste.Nenhum)
                columnGrid.AutoSizeMode = DefineTipoAjusteColuna(coluna.TipoAjuste);
            else if (coluna.Tamanho > 0)
                columnGrid.Width = coluna.Tamanho;
        }

        private static void ConfiguraTipo(ColunaInfo coluna, DataGridViewColumn columnGrid)
        {
            if (coluna.Type != null)
                columnGrid.ValueType = coluna.Type;
        }

        private void ConfiguraColunasParaNaoOrdenar(ColunaInfo coluna)
        {
            if (!coluna.PermitirOrdenar)
                _naoOrdenarColunas.Add(coluna.NomePropriedade);
        }

        private static DataGridViewColumn CriaColuna(ColunaInfo coluna)
        {
            DataGridViewColumn columnGrid;
            if (coluna.NomePropriedade != ColunaInfo.COLUNA_ALTERACAO)
            {
                columnGrid = new DataGridViewTextBoxColumn();
            }
            else
            {
                columnGrid = new DataGridViewImageColumn
                {
                    Image = Properties.Resources.edit__1_,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
            }

            return columnGrid;
        }

        public void SetCores()
        {
            BackgroundColor = ColorTranslator.FromHtml(CoresHelper.Branco);
            DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(CoresHelper.Primaria);
            GridColor = ColorTranslator.FromHtml(CoresHelper.Branco);
            RowsDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml( CoresHelper.Primaria);
            DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(CoresHelper.Primaria);
            ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(CoresHelper.Branco);
        }

        public void SetNumeroRegistros(int numero)
        {
            RowCount = numero;
        }

        private DataGridViewContentAlignment DefineAlinhamento(TipoAlinhamentoColuna tipoAlinhamento)
        {
            switch (tipoAlinhamento)
            {
                case TipoAlinhamentoColuna.Direita:
                    return DataGridViewContentAlignment.MiddleRight;
                case TipoAlinhamentoColuna.Centro:
                    return DataGridViewContentAlignment.MiddleCenter;
                default:
                    return DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private DataGridViewAutoSizeColumnMode DefineTipoAjusteColuna(ColunaTipoAjuste tipoAjuste)
        {
            switch (tipoAjuste)
            {
                case ColunaTipoAjuste.Nenhum: return DataGridViewAutoSizeColumnMode.NotSet;
                case ColunaTipoAjuste.Preencher: return DataGridViewAutoSizeColumnMode.Fill;
                default:return DataGridViewAutoSizeColumnMode.None;
            }
        }

        #endregion
    }
}