using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GPApp.Model;
using GPApp.Model.Lookups;
using GPApp.Presenter.Base;
using GPApp.Presenter.Grid;
using GPApp.Presenter.PubSub;
using GPApp.Presenter.PubSub.Eventos;
using GPApp.Repository;
using GPApp.Service;
using GPApp.Shared.Paginacao;
using GPApp.Shared.Services;
using GPApp.Wrapper;

namespace GPApp.Presenter.Modulos.Produtos
{
    public class ProdutosPresenter : BasePresenter<IProdutosView>
    {
        #region Membros privados

        private readonly GridViewPresenter<ProdutoLookupWrapper> _gridViewPresenter;
        private readonly IEmailService _emailService;
        private readonly ProdutoEditPresenter _produtoEditPresenter;
        private readonly IPaginacaoRepository<ProdutoLookupWrapper> _paginacaoRepository;
        private readonly IEventAggregator _eventAggregator;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoClientService _produtoClientService;
        private readonly IDialogService _dialogService;
        private bool _sincronizandoComNuvem;

        #endregion

        #region Construtor

        public ProdutosPresenter(
            IProdutosView view,
            GridViewPresenter<ProdutoLookupWrapper> gridViewPresenter,
            IEmailService emailService,
            ProdutoEditPresenter produtoEditPresenter,
            IPaginacaoRepository<ProdutoLookupWrapper> paginacaoRepository,
            IEventAggregator eventAggregator,
            IProdutoRepository produtoRepository,
            IProdutoClientService produtoClientService,
            IDialogService dialogService

        ) : base(view)
        {
            _gridViewPresenter = gridViewPresenter;
            _emailService = emailService;
            _produtoEditPresenter = produtoEditPresenter;
            _paginacaoRepository = paginacaoRepository;
            _eventAggregator = eventAggregator;
            _produtoRepository = produtoRepository;
            _produtoClientService = produtoClientService;
            _dialogService = dialogService;

            _eventAggregator.Subscribe<AtualizarGridProdutosEvent>(OnAtualizaGrid);

            view.LoadAction = OnLoad;
            view.IncluirProdutoAction = OnIncluirProduto;
            view.EnviarEmailAction = OnEnviarEmail;
            view.SincronizarComNuvemAction = OnSincronizarNuvem;

            gridViewPresenter.ColunaFormatingAction = OnFormataCelula;
            gridViewPresenter.FiltrouEvent += GridViewPresenter_FiltrouEvent;
            gridViewPresenter.AlterarRegistroAction = OnAlterar;
        }

        #endregion

        #region Ações

        private async void OnSincronizarNuvem()
        {
            if (_sincronizandoComNuvem) return;

            _sincronizandoComNuvem = true;
            View.ExibeProgressoWeb(true);
            View.HabilitarBotaoSincronizacaoNuvem(false);

            var resultadoProdutosNaoSincronizados = await _produtoRepository.BuscaProdutosNaoSincronizados();
            if (!resultadoProdutosNaoSincronizados.Valido)
            {
                _dialogService.Mensagem(resultadoProdutosNaoSincronizados.Mensagem);
                HabilitaSincronizacao();
                return;
            }

            var produtos = resultadoProdutosNaoSincronizados.Valor;
            var resultadoWeb = await _produtoClientService.SalvarProdutos(produtos);
            if (resultadoWeb.Valido)
            {
                var produtosAtualizados = produtos.Where(p => !resultadoWeb.ItensInvalidos.Contains(p.Id));
                var resposta = await _produtoRepository
                     .AtualizaSincronizacaoAsync(
                             produtosAtualizados.Select(p => p.Id),
                             resultadoWeb.DataAtualizacao);

                if (!resposta.Valido)
                    _dialogService.Mensagem(resposta.Mensagem);

                if (resultadoWeb.ItensInvalidos.Count > 0)
                    _dialogService.Mensagem(
                        "Produtos que não foram atualizados:" +
                        String.Join("\n", resultadoWeb.ItensInvalidos));
            }
            else
            {
                _dialogService.Mensagem(resultadoWeb.GetMensagem());
            }

            HabilitaSincronizacao();
            await _gridViewPresenter.LoadAsync();
        }

        private void HabilitaSincronizacao()
        {
            _sincronizandoComNuvem = false;
            View.HabilitarBotaoSincronizacaoNuvem(true);
            View.ExibeProgressoWeb(false);
        }

        private async void OnAlterar(object valor)
        {
            var id = new Guid(valor.ToString());
            var valido = await _produtoEditPresenter.Alterar(id);
            if (valido) ExibeEdicao();
        }

        private ColunaFormataInfo OnFormataCelula(ColunaFormataInfo<ProdutoLookupWrapper> info)
        {
            if (!info.Model.Model.Sincronizado)
            {
                info.CorTexto = Shared.Helpers.CoresHelper.Danger;
            }

            if (info.Valor != null)
            {
                switch (info.NomePropriedade)
                {
                    case nameof(ProdutoLookup.Preco):
                        info.Valor = ((decimal)info.Valor).ToString("C2", new CultureInfo("pt-BR"));
                        break;
                    case nameof(ProdutoLookup.DataCadastro):
                        info.Valor = ((DateTimeOffset)info.Valor).ToString("dd/MM/yyyy hh:mm:ss");
                        break;
                }
            }
            return info;
        }

        private async void OnAtualizaGrid(AtualizarGridProdutosEvent evento)
        {
            if (evento.Atualizar)
                await _gridViewPresenter.LoadAsync();
            ExibeListagem();
        }

        private async void OnLoad()
        {
            View.AdicionaEditPresenter(_produtoEditPresenter.View);
            View.ExibeProgressoWeb(false);

            await ConfiguraGrid();
            await VerificaSincronizacaoNuvem();
        }

        private void OnIncluirProduto()
        {
            _produtoEditPresenter.IncluirProduto();
            ExibeEdicao();
            _produtoEditPresenter.View.FocoPrincipal();
        }

        private async void OnEnviarEmail()
        {
            // TODO: Criar envio de email
            //var resultado =  await _emailService.Envia(  EmailTemplate.GetEmailMarketing());
            //if (!resultado.Valido)
            //{
            //}
        }

        #endregion

        #region Métodos

        private async System.Threading.Tasks.Task ConfiguraGrid()
        {
            _gridViewPresenter.GridView.RodapeTexto = new[] { "produto", "produtos" };
            _gridViewPresenter.SetGridInfo(ProdutoGridConfigBuilder.Instancia(_paginacaoRepository));
            await _gridViewPresenter.LoadAsync();
            View.AdicionaGrid(_gridViewPresenter.GridView);
        }

        public void ExibeListagem()
        {
            View.ExibeAbaListagem();
            View.ExibeBotoesAcaoAbaListagem(true);
        }

        public void ExibeEdicao()
        {
            View.ExibeAbaEdicao();
            View.ExibeBotoesAcaoAbaListagem(false);
        }

        private async System.Threading.Tasks.Task VerificaSincronizacaoNuvem()
        {
            var resultado = await _produtoRepository.NumeroRegistrosSincronizarAsync();
            if (resultado.Valido)
            {
                View.HabilitarBotaoSincronizacaoNuvem(resultado.Valor > 0);
            }
        }

        #endregion

        #region Handlers

        private async void GridViewPresenter_FiltrouEvent(object sender, bool filtroAtivo)
        {
            var texto = filtroAtivo ? "Desativar filtro" : "Filtrar";
            View.SetTextoBotaoFiltrar(texto);
            await VerificaSincronizacaoNuvem();
        }

        #endregion
    }
}