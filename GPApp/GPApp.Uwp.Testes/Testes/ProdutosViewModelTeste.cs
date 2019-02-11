using GPApp.Model;
using GPApp.Model.Helpers;
using GPApp.Repository;
using GPApp.Shared.Constantes;
using GPApp.Shared.Paginacao;
using GPApp.Shared.Services;
using GPApp.Uwp.Logica.ViewModels;
using GPApp.Wrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Windows.Navigation;
using Windows.UI.Xaml;

namespace GPApp.Uwp.Testes.Testes
{

    [TestClass]
    public class ProdutosViewModelTeste
    {
        private readonly Mock<INavigationService> _navigationMock;
        private readonly Mock<IPaginacaoRepository<ProdutoLookupWrapper>> _paginacoaRepository;
        private readonly Mock<IProdutoRepository> _produtoRepository;
        private readonly Mock<IDialogService> _dialogMock;
        private  readonly ProdutosPageViewModel _viewModel;

        public ProdutosViewModelTeste()
        {
            _navigationMock = new Mock<INavigationService>();
            _navigationMock.SetupAllProperties();

            _paginacoaRepository = new Mock<IPaginacaoRepository<ProdutoLookupWrapper>>();
            _paginacoaRepository.SetupAllProperties();

            _produtoRepository = new Mock<IProdutoRepository>();
            _produtoRepository.SetupAllProperties();

            _dialogMock = new Mock<IDialogService>();
            _dialogMock.SetupAllProperties();

            _viewModel = new ProdutosPageViewModel(
                _navigationMock.Object,
                _paginacoaRepository.Object,
                _produtoRepository.Object,
                _dialogMock.Object
            );
        }

        [TestMethod]
        public void IniciaViewModelTeste()
        {
            Assert.AreEqual(Visibility.Collapsed, _viewModel.ExibirPesquisa);
            Assert.AreEqual(Visibility.Collapsed, _viewModel.ExibirDesativarFiltro);
        }

        [TestMethod]
        public void IncluirTeste()
        {
            _viewModel.IncluirCommand.Execute(null);
            _navigationMock.Verify(f => 
            f.Navigate(
                RegionNames.EDIT_PRODUTO, 
                It.Is<NavegacaoParametro<Produto>>((p)=> p.Operacao == string.Empty )));
        }

        [TestMethod]
        public void AtualizacaoGridTeste()
        {
            _viewModel.OnNavigatedTo(null, null);

            var produtosAnterior = _viewModel.Produtos;

            var param = new NavigatedToEventArgs
            {
                Parameter = new NavegacaoParametro(ContantesGlobais.ATUALIZAR_GRID)
            };
            _viewModel.OnNavigatedTo(param, null);

            Assert.IsNotNull(_viewModel.Produtos);
            Assert.AreNotEqual(produtosAnterior, _viewModel.Produtos);
        }
    }
}
