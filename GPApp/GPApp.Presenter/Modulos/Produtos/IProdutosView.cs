﻿using GPApp.Presenter.Base;
using GPApp.Presenter.Grid;
using System;

namespace GPApp.Presenter.Modulos.Produtos
{
    public interface IProdutosView : IView
    {
        Action IncluirProdutoAction { get; set; }
        Action EnviarEmailAction { get; set; }
        Action SincronizarComNuvemAction { get; set; }

        void AdicionaGrid(IGridViewFiltro gridViewFiltro);
        void ExibeAbaEdicao();
        void ExibeAbaListagem();
        void AdicionaEditPresenter(IProdutoEditView editView);
        void ExibeBotoesAcaoAbaListagem(bool exibe);
        void SetTextoBotaoFiltrar(string texto);
        void HabilitarBotaoSincronizacaoNuvem(bool habilita);
        void ExibeProgressoWeb(bool exibir);
    }
}