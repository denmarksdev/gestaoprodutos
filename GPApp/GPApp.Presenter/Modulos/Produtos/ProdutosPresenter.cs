using System;
using System.Globalization;
using GPApp.Model;
using GPApp.Model.Lookups;
using GPApp.Presenter.Base;
using GPApp.Presenter.Grid;
using GPApp.Presenter.PubSub;
using GPApp.Presenter.PubSub.Eventos;
using GPApp.Service;
using GPApp.Shared.Paginacao;
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

        #endregion

        #region Construtor

        public ProdutosPresenter(
            IProdutosView view,
            GridViewPresenter<ProdutoLookupWrapper> gridViewPresenter,
            IEmailService emailService,
            ProdutoEditPresenter produtoEditPresenter,
            IPaginacaoRepository<ProdutoLookupWrapper> paginacaoRepository,
            IEventAggregator eventAggregator
        ) : base(view)
        {
            _gridViewPresenter = gridViewPresenter;
            _emailService = emailService;
            _produtoEditPresenter = produtoEditPresenter;
            _paginacaoRepository = paginacaoRepository;
            _eventAggregator = eventAggregator;

            _eventAggregator.Subscribe<AtualizarGridProdutosEvent>(OnAtualizaGrid);

            view.LoadAction = OnLoad;
            view.IncluirProdutoAction = OnIncluirProduto;
            view.EnviarEmailAction = OnEnviarEmail;

            gridViewPresenter.GridView.FormataCelulaFunc = OnFormataCelula;
            gridViewPresenter.FiltrouEvent += GridViewPresenter_FiltrouEvent;  
        }

        #endregion

        #region Ações

        private ColunaFormataInfo OnFormataCelula(ColunaFormataInfo info)
        {
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
            await ConfiguraGrid();
        }

        private void OnIncluirProduto()
        {
            _produtoEditPresenter.IncluirProduto();
            ExibeEdicao();
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

        #endregion

        #region Handlers

        private void GridViewPresenter_FiltrouEvent(object sender, bool filtroAtivo)
        {
            var texto = filtroAtivo ? "Desativar filtro" : "Filtrar";
            View.SetTextoBotaoFiltrar(texto);
        }

        #endregion
    }
}