using GPApp.Model;
using GPApp.Model.Helpers;
using GPApp.Repository;
using GPApp.Shared.Constantes;
using GPApp.Shared.Services;
using GPApp.Uwp.Logica.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Windows.Navigation;
using System;

namespace GPApp.Uwp.Testes.Testes
{

    [TestClass]
    public class ProdutoEditViewModelTeste
    {
        private readonly Mock<IArquivoService> _arquivoServiceMock;
        private readonly Mock<IDialogService> _dialogServiceMock;
        private Mock<IProdutoRepository> _repo;
        private Mock<INavigationService> _navigationService;
        private readonly ProdutoEditPageViewModel _viewModel;

        public ProdutoEditViewModelTeste()
        {
            _arquivoServiceMock = new Mock<IArquivoService>();
            _arquivoServiceMock.SetupAllProperties();

            _dialogServiceMock = new Mock<IDialogService>();
            _dialogServiceMock.SetupAllProperties();
            _dialogServiceMock
                .Setup(f => f.BuscaCamimhoImagem(It.IsAny<Action<string,byte[]>>()))
                .Callback<Action<string, byte[]>>(c => c.Invoke("teste.jpg", new byte[] { })) ;
            _dialogServiceMock.Setup(f => f.Confirmacao(It.IsAny<string>(), It.IsAny<Action>(), "Atenção"))
                        .Callback<string,Action,string>((mensagem, acao, titulo) => acao.Invoke());

            _repo = new Mock<IProdutoRepository>();
            _repo.SetupAllProperties();
            _repo.Setup(f => f.IncluirAsync(It.IsAny<Produto>()))
                    .ReturnsAsync(new Resultado());

            _navigationService = new Mock<INavigationService>();
            _navigationService.SetupAllProperties();
            _navigationService.Setup(f => f.Navigate(It.IsAny<string>(), It.IsAny<object>()));

            _viewModel = new ProdutoEditPageViewModel(
                _dialogServiceMock.Object,
                _arquivoServiceMock.Object,
                _repo.Object,
                _navigationService.Object
            );
        }
        
        [TestMethod]
        public void InicializaInclusaoTeste()
        {
            InicializaInclusao();
            Assert.IsNotNull(_viewModel.Wrapper);
            Assert.IsNotNull(_viewModel.Imagens);
        }

        private void InicializaInclusao()
        {
            var param = new NavigatedToEventArgs
            {
                Parameter = new NavegacaoParametro<Produto>()
            };
            _viewModel.OnNavigatedTo(param, null);
            
        }

        [TestMethod]
        public void IncluirImageTeste()
        {
            InicializaInclusao();
            _viewModel.IncluirImagemCommand.Execute(null);

            Assert.IsNotNull(_viewModel.ImagemSelecionada);
            Assert.IsTrue(_viewModel.Imagens.Count == 1);
        }

        [TestMethod]
        public void AlterarImageTeste()
        {
            IncluirImageTeste();

            _dialogServiceMock
                .Setup(f => f.BuscaCamimhoImagem(It.IsAny<Action<string, byte[]>>()))
                .Callback<Action<string, byte[]>>(c => c.Invoke("teste.png", new byte[] { }));

            short? ordem = 1;
            _viewModel.AlterarImagemCommand.Execute(ordem);

            Assert.IsTrue(_viewModel.ImagemSelecionada.Sufixo == "png" );
        }

        [TestMethod]
        public void ExcluirImageTeste()
        {
            IncluirImageTeste();
            _viewModel.ExcluirImagemCommand.Execute( short.Parse("1"));
            Assert.IsTrue(_viewModel.Imagens.Count == 0);
        }

        [TestMethod]
        public void IncluirEspecificacaoTeste()
        {
            InicializaInclusao();
            _viewModel.IncluirEspecificacaoCommand.Execute(null);
            Assert.AreEqual(1, _viewModel.Wrapper.Especificacoes.Count);
        }

        [TestMethod]
        public void ExcluirEspecificacaoTeste()
        {
            InicializaInclusao();
            IncluirEspecificacaoTeste();
            short ordem = short.Parse("1");
            _viewModel.ExcluirEspecificacaoCommand.Execute(ordem);
            Assert.AreEqual(0, _viewModel.Wrapper.Especificacoes.Count);
        }

        [TestMethod]
        public void SalvarDadosInvalidosTeste()
        {
            InicializaInclusao();
            Assert.IsFalse(_viewModel.SalvarCommand.CanExecute(false));
        }


        [TestMethod]
        public void SalvarTeste()
        {
            InicializaInclusao();

            _viewModel.Wrapper.Codigo = "A1";
            _viewModel.Wrapper.Nome = "Teste";
            _viewModel.Wrapper.Descricao = "Este teste possui ...";
            _viewModel.Wrapper.Custo = 5;
            _viewModel.Wrapper.Preco = 10;
            
            Assert.IsTrue(_viewModel.SalvarCommand.CanExecute(null));

            _viewModel.SalvarCommand.Execute(null);

            _repo.Verify(f => f.IncluirAsync(It.IsAny<Produto>()));
            _navigationService.Verify(f => f.Navigate("Produtos", 
                It.Is<NavegacaoParametro>(n=> n.Operacao == ContantesGlobais.ATUALIZAR_GRID)));

            Assert.IsFalse(_viewModel.ExibirProgressBar);

            _viewModel.Wrapper.Preco = 0;

            Assert.IsFalse(_viewModel.SalvarCommand.CanExecute(false));
        }
    }
}
