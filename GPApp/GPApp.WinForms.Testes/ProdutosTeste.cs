using GPApp.Presenter.Grid;
using GPApp.Presenter.Modulos.Produtos;
using GPApp.Presenter.PubSub;
using GPApp.Presenter.PubSub.Eventos;
using GPApp.Repository;
using GPApp.Service;
using GPApp.Shared.Paginacao;
using GPApp.Shared.Services;
using GPApp.Wrapper;
using Moq;
using System;
using Xunit;
using static GPApp.WinForms.Testes.ProdutoEditTeste;

namespace GPApp.WinForms.Testes
{
    public class ProdutosTeste
    {
        private readonly GridViewPresenter<ProdutoLookupWrapper> _gridView;
        private readonly ProdutosPresenter _presenter;
        private readonly Mock<IProdutosView> _mockView;
        private readonly Mock<IProdutoRepository> _produtoRepoMock;
        private readonly Mock<IProdutoClientService> _clientServiceMock;
        private readonly Mock<IDialogService> _dialogServiceMock;
        private readonly Mock<IEventAggregator> _eventAggregatorMock;
        private readonly Mock<IEmailService> _emailService;
        private static Mock<IProdutoEditView> _produtoEditViewMock;

        public ProdutosTeste()
        {
            _emailService = new Mock<IEmailService>();
            _mockView = CriaMockView();
            _produtoRepoMock = new Mock<IProdutoRepository>();
            _produtoRepoMock.SetupAllProperties();
            _produtoRepoMock.Setup(f => f.NumeroRegistrosSincronizarAsync())
                .ReturnsAsync(new Model.Helpers.Resultado<int>(2));
            
            _clientServiceMock = new Mock<IProdutoClientService>();
            _clientServiceMock.SetupAllProperties();
            _dialogServiceMock = new Mock<IDialogService>();
            _dialogServiceMock.SetupAllProperties();
            _eventAggregatorMock = new Mock<IEventAggregator>();
            _eventAggregatorMock.SetupAllProperties();
            var gridMock = CriaGridMock();
            var produtoEditPresenter = CriaProdutoEditPresenter();
            var paginacaoRepoMock = ConfiguraPagincaoRepo();
          

            _gridView = new GridViewPresenter<ProdutoLookupWrapper>(gridMock.Object);
            _presenter = new ProdutosPresenter(
                _mockView.Object,
                _gridView,
                _emailService.Object,
                produtoEditPresenter,
                paginacaoRepoMock.Object,
                _eventAggregatorMock.Object,
                _produtoRepoMock.Object,
                _clientServiceMock.Object,
                _dialogServiceMock.Object
                );
                
        }
               
        [Fact]
        public void AcaoIncluirProdutoTest()
        {
            _mockView.Object.IncluirProdutoAction.Invoke();
            _mockView.Verify(f => f.ExibeAbaEdicao());
            _produtoEditViewMock.Verify(f => f.SelecionarPrimeiroCampoEdicao());
        }

        [Fact]
        public void EditPresenterConfiguradoAoCarregarFormularioTest()
        {
            _mockView.Object.LoadAction.Invoke();
            _mockView.Verify(f => f.AdicionaEditPresenter(It.IsAny<IProdutoEditView>()));
            _mockView.Verify(f => f.ExibeProgressoWeb(false));
        }

        [Fact]
        public void RegistrarEventoAtaulizacaoGridTest()
        {
            _eventAggregatorMock.Verify(f => f.Subscribe(
                It.IsAny<Action<AtualizarGridProdutosEvent>>()));
        }

        [Fact]
        public void MudarParaAbaEdicaoTest()
        {
            _presenter.ExibeEdicao();
            _mockView.Verify(f => f.ExibeBotoesAcaoAbaListagem(false));
        }

        [Fact]
        public void MudarParaAbaListagemTest()
        {
            _presenter.ExibeListagem();
            _mockView.Verify(f => f.ExibeBotoesAcaoAbaListagem(true));
        }


        #region Métodos auxiliares

        private static Mock<IPaginacaoRepository<ProdutoLookupWrapper>> ConfiguraPagincaoRepo()
        {
            var paginacaoRepo = new Mock<IPaginacaoRepository<ProdutoLookupWrapper>>();
            paginacaoRepo.SetupAllProperties();
            return paginacaoRepo;
        }

        private static Mock<IProdutosView> CriaMockView()
        {
            var mockView = new Mock<IProdutosView>();
            mockView.SetupAllProperties();
            return mockView;
        }

        private static ProdutoEditPresenter CriaProdutoEditPresenter()
        {
            _produtoEditViewMock = new Mock<IProdutoEditView>();
            _produtoEditViewMock.SetupAllProperties();
            var dialogMock = new DialogMock();
            var arquivoServiceMock = new Mock<IArquivoService>();
            var repoMock = new Mock<IProdutoRepository>();
            var eventMock = new Mock<IEventAggregator>();

            var produtoEditPresenter = new ProdutoEditPresenter(
                _produtoEditViewMock.Object,
                dialogMock,
                arquivoServiceMock.Object,
                repoMock.Object,
                eventMock.Object);

            return produtoEditPresenter;
        }

        private static Mock<IGridViewFiltro> CriaGridMock()
        {
            var gridMock = new Mock<IGridViewFiltro>();
            gridMock.SetupAllProperties();
            return gridMock;
        }

        #endregion
    }
}