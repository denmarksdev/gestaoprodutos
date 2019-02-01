﻿using GPApp.Helpers;
using GPApp.Presenter.Grid;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPApp.WinForms.Componentes
{
    public partial class VirtualGridFiltro : UserControl , IGridViewFiltro
    {
        #region Construtor

        public VirtualGridFiltro()
        {
            InitializeComponent();
        }

        #endregion

        #region Propriedades

        [System.ComponentModel.ReadOnly(true)]
        public string ColunaChave { get => virtualGridPrincipal.ColunaChave; set => virtualGridPrincipal.ColunaChave = value; }
        [System.ComponentModel.ReadOnly(true)]
        public Func<int, string, object> GetValue { get => virtualGridPrincipal.GetValue; set => virtualGridPrincipal.GetValue = value; }
        [System.ComponentModel.ReadOnly(true)]
        public Action<string> OrderAction { get => virtualGridPrincipal.OrderAction; set => virtualGridPrincipal.OrderAction = value; }
        [System.ComponentModel.ReadOnly(true)]
        public Action ConsultaAction { get => virtualGridPrincipal.ConsultaAction; set => virtualGridPrincipal.ConsultaAction = value; }
        [System.ComponentModel.ReadOnly(true)]
        public Func<Task<bool>> Inicializa { get => virtualGridPrincipal.Inicializa; set => virtualGridPrincipal.Inicializa = value; }
        [System.ComponentModel.ReadOnly(true)]
        public Action AtivarFiltroAction { get; set; }
        [System.ComponentModel.ReadOnly(true)]
        public Action<string> FiltrarAcion { get; set; }
        [System.ComponentModel.ReadOnly(true)]
        public Action RecuperarPaginacaoAction { get; set; }
        [System.ComponentModel.ReadOnly(true)]
        public bool ErroPaginacao
        {
            get => virtualGridPrincipal.ErroPaginacao;
            set => virtualGridPrincipal.ErroPaginacao = value;
        }
        [System.ComponentModel.ReadOnly(true)]
        public Action ErroPagincaoAction
        {
            get => virtualGridPrincipal.ErroPagincaoAction;
            set => virtualGridPrincipal.ErroPagincaoAction = value;
        }
        public string[] RodapeTexto { get; set; } = {"item", "itens"};
        public Func<ColunaFormataInfo, ColunaFormataInfo> FormataCelulaFunc
        {
            get => virtualGridPrincipal.FormataCelulaFunc;
            set => virtualGridPrincipal.FormataCelulaFunc = value;
        }
        public bool FiltroAtivo { get ; set ; }
        public Action<object> AlterarAction
        {
            get => virtualGridPrincipal.AlterarAction;
            set => virtualGridPrincipal.AlterarAction = value;
        }

        #endregion

        #region Métodos

        public void AtualizarDesign()
        {
            virtualGridPrincipal.AtualizarDesign();
            Update();
        }

        public void DefineColunaModoLeitura(bool permitir)
        {
            virtualGridPrincipal.DefineColunaModoLeitura(permitir);
        }

        public void HabilitaGrid(bool habilita)
        {
            virtualGridPrincipal.Enabled = habilita;
        }

        public void ExibePainelPesquisa(bool exibir)
        {
            metroPanelFiltro.Visible = exibir;
            metroTextBoxPequisa.Clear();
            metroTextBoxPequisa.Focus();
        }

        public T GetValorChaveDataRowAtual<T>(string teste)
        {
            return virtualGridPrincipal.GetValorChaveDataRowAtual<T>(teste);
        }

        public void SetColunas(IList<ColunaInfo> colunas)
        {
            virtualGridPrincipal.SetColunas(colunas);
        }

        public void SetNumeroRegistros(int numero)
        {
            virtualGridPrincipal.SetNumeroRegistros(numero);
            htmlLabelRodape.Text = GridTemplate.GetRodape(RodapeTexto, numero, FiltroAtivo);
        }

        public int NumeroRegitros()
        {
            return virtualGridPrincipal.RowCount;
        }

        public void SetCores()
        {
            virtualGridPrincipal.SetCores();
        }

        #endregion

        #region Handlers

        private void MetroButtonPesquisar_Click(object sender, EventArgs e)
        {
            FiltrarAcion?.Invoke(metroTextBoxPequisa.Text);
        }

        #endregion
    }
}