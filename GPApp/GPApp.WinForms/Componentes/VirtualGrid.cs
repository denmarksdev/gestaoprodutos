using GPApp.Presenter.Grid;
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

        #endregion

        #region Overrides

        protected override void OnCellValueNeeded(DataGridViewCellValueEventArgs e)
        {
            try
            {
                if (ErroPaginacao) return;

                e.Value = GetValue?.Invoke(e.RowIndex, Columns[e.ColumnIndex].DataPropertyName);
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
            OrderAction?.Invoke(Columns[e.ColumnIndex].DataPropertyName);

            foreach (DataGridViewColumn coluna in Columns)
            {
                coluna.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
        }

        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            base.OnCellFormatting(e);
            e.CellStyle.SelectionBackColor = Color.FromArgb(CoresHelper.Primaria);
            e.CellStyle.SelectionForeColor = Color.FromArgb(CoresHelper.Selecao);
        }

        protected override void OnColumnHeadersDefaultCellStyleChanged(EventArgs e)
        {
            base.OnColumnHeadersDefaultCellStyleChanged(e);
            ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(CoresHelper.Secundaria);

            EnableHeadersVisualStyles = false;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ColumnHeadersHeight = 50;
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
            if (!Columns.Contains(nomePropriedade + "Column")) return default(T);


            return (T)CurrentRow.Cells[nomePropriedade + "Column"].Value;
        }

        public void SetColunas(IList<ColunaInfo> colunas)
        {
            throw new NotImplementedException();
        }

        public void SetCores()
        {
            BackgroundColor = Color.FromArgb(CoresHelper.Selecao);
            DefaultCellStyle.SelectionBackColor = Color.FromArgb(CoresHelper.Primaria);
            GridColor = Color.FromArgb(CoresHelper.Selecao);
            RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb( CoresHelper.Primaria);
            DefaultCellStyle.SelectionBackColor = Color.FromArgb(CoresHelper.Primaria);
            ColumnHeadersDefaultCellStyle.BackColor = Color.Red; //TODO:Criar cor
            ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(CoresHelper.Secundaria);
        }

        public void SetNumeroRegistros(int numero)
        {
            RowCount = numero;
        }

        #endregion
    }
}