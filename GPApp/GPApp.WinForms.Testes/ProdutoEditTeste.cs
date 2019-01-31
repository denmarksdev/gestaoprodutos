using System;
using GPApp.Model;
using GPApp.Model.Helpers;
using GPApp.Presenter.Modulos.Produtos;
using GPApp.Presenter.PubSub;
using GPApp.Presenter.PubSub.Eventos;
using GPApp.Repository;
using GPApp.Shared.Services;
using GPApp.Wrapper;
using Moq;
using Xunit;

namespace GPApp.WinForms.Testes
{
    public  class ProdutoEditTeste 
    {
        private static string _mensagemDoDialodMock;
        
        private readonly Mock<IProdutoEditView> _viewMock;
        private readonly Mock<IProdutoRepository> _repo;
        private Mock<IEventAggregator> _eventAggregator;
        private ProdutoEditPresenter _presenter;

        public ProdutoEditTeste()
        {
            _viewMock = new Mock<IProdutoEditView>();
            _viewMock.SetupAllProperties();
            _repo = new Mock<IProdutoRepository>();
            _repo.Setup(f => f.IncluirAsync(It.IsAny<Produto>()))
                .ReturnsAsync(new Resultado());

            _eventAggregator = new Mock<IEventAggregator>();
            _eventAggregator.SetupAllProperties();

            var dialogMock = new DialogMock();
            var arquivoServiceMock = new Mock<IArquivoService>();
            arquivoServiceMock.SetupAllProperties();
            
            _presenter = new ProdutoEditPresenter(
                _viewMock.Object, 
                dialogMock,
                arquivoServiceMock.Object,
                _repo.Object,
                _eventAggregator.Object);
        }
               
        [Fact]
        public void ConfiguraBindingTeste()
        {
            _viewMock.Verify(f => f.ConfiguraProdutoBindings(_presenter));
        }

        [Fact]
        public void IncluirProdutoTeste()
        {
            _presenter.IncluirProduto();
            _viewMock.Verify(f => f.InicializaBinding(It.IsAny<ProdutoWrapper>()));
        }

        [Fact]
        public void VerificaMensagemErroTeste()
        {
            _presenter.IncluirProduto();
            _presenter.Wrapper.Codigo = "A";
            _presenter.Wrapper.Codigo = "";

            _viewMock.Verify(f => f.SetMensagenErro("Codigo", It.IsAny<string>()));
        }

        [Fact]
        public void DesabilitaBotaoErroValidacaoTeste()
        {
            _presenter.IncluirProduto();
            _viewMock.Verify(f => f.HabiltaBotaoSalvar(false));
        }

        [Fact]
        public void HabilitaBotaoModelValidaTeste()
        {
            _presenter.IncluirProduto();

            _presenter.Wrapper.Codigo = "A1";
            _presenter.Wrapper.Nome = "Teste";
            _presenter.Wrapper.Descricao = "Este teste ...";
            _presenter.Wrapper.Custo = 5;
            _presenter.Wrapper.Preco = 10;

            _viewMock.Verify(f => f.HabiltaBotaoSalvar(true));
        }
               
        [Fact]
        public void IncluirImagemTeste()
        {
            _presenter.IncluirProduto();
            _viewMock.Object.IncluirImagemAction.Invoke();
            _viewMock.Verify(f => f.IncluirImagem(It.IsAny<ProdutoImagemWrapper>()));
        }

        [Fact]
        public void AlterarImagemTeste()
        {
            _presenter.IncluirProduto();
            _presenter.Wrapper.Imagens.Add(new ProdutoImagemWrapper(new Model.ProdutoImagem()));

            _viewMock.Object.AlterarImagemAction.Invoke (_presenter.Wrapper.Imagens[0]);
            _viewMock.Verify(f => f.SetImagemPreview(It.IsAny<string>()));
        }

        [Fact]
        public void ExcluirImagemTeste()
        {
            _presenter.IncluirProduto();
            var imagens = new[]
            {
                new ProdutoImagemWrapper(new Model.ProdutoImagem { Ordem = 4 }),
                new ProdutoImagemWrapper(new Model.ProdutoImagem { Ordem = 1 }),
                new ProdutoImagemWrapper(new Model.ProdutoImagem { Ordem = 2 }),
                new ProdutoImagemWrapper(new Model.ProdutoImagem { Ordem = 3 })
            };
            foreach (var imagem in imagens)
            {
                _presenter.Wrapper.Imagens.Add(imagem);
            }

            _viewMock.Object.ExcluirImagemAction.Invoke(_presenter.Wrapper.Imagens[1]);
            _viewMock.Verify(f => f.SelecionaImagemGrid(It.IsAny<int>()));

            Assert.True(_presenter.Wrapper.Imagens[0].Ordem == 1 );
        }

        [Fact]
        public void IncluirEspecificacaoTeste()
        {
            _presenter.IncluirProduto();
            _viewMock.Object.IncluirEspecificacaoAction.Invoke();
            _viewMock.Verify(f => f.IncluirEspecificacao(It.IsAny<ProdutoEspecificacaoWrapper>()));
        }

        [Fact]
        public void ExcluirEspecificacaoTeste()
        {
            _presenter.IncluirProduto();
            var especificacoes = new[]
            {
                new ProdutoEspecificacaoWrapper(new Model.ProdutoEspecificacao { Ordem = 4 }),
                new ProdutoEspecificacaoWrapper(new Model.ProdutoEspecificacao { Ordem = 1 }),
                new ProdutoEspecificacaoWrapper(new Model.ProdutoEspecificacao { Ordem = 2 }),
                new ProdutoEspecificacaoWrapper(new Model.ProdutoEspecificacao { Ordem = 3 })
            };
            foreach (var esp in especificacoes)
            {
                _presenter.Wrapper.Especificacoes.Add(esp);
            }

            _viewMock.Object.ExcluirEspecificacaoAction.Invoke(_presenter.Wrapper.Especificacoes[1]);
            _viewMock.Verify(f=> f.ExcluirEspecificacao(It.IsAny<ProdutoEspecificacaoWrapper>()));
            Assert.True(_presenter.Wrapper.Especificacoes[0].Ordem == 1);
        }

        [Fact]
        public void SalvarTeste() {

            _presenter.IncluirProduto();
            DefineProdurtoValido();

            _viewMock.Object.SalvarAction.Invoke();

            _viewMock.Verify(f => f.ExibirProgressoSalvar(true));
            _repo.Verify(f  =>  f.IncluirAsync(It.IsAny<Produto>()));
            _viewMock.Verify(f => f.ExibirProgressoSalvar(false));
            _eventAggregator.Verify(f => 
                f.Publish(
                    It.IsAny<AtualizarGridProdutosEvent>()));
        }

        [Fact]
        public void SalvarComErroDaBaseDadosTeste()
        {
            const string MENSAGEM = "Não foi possível salvar o produto";
            _presenter.IncluirProduto();
            DefineProdurtoValido();
            _repo.Setup(f => f.IncluirAsync(It.IsAny<Produto>()))
                .ReturnsAsync(new Resultado(MENSAGEM, valido:false));

            _viewMock.Object.SalvarAction.Invoke();

            _viewMock.Verify(f => f.ExibirProgressoSalvar(true));
            _repo.Verify(f => f.IncluirAsync(It.IsAny<Produto>()));
            _viewMock.Verify(f => f.ExibirProgressoSalvar(false));
            Assert.Equal(MENSAGEM, _mensagemDoDialodMock);
        }

        [Fact]
        public void CancelarTeste()
        {
            _viewMock.Object.CancelarAction.Invoke();
            _eventAggregator.Verify(f => f.Publish(It.IsAny<AtualizarGridProdutosEvent>()));
        }

        #region Métodos auxiliares

        private void DefineProdurtoValido()
        {
            _presenter.Wrapper.Codigo = "A1";
            _presenter.Wrapper.Nome = "A1 Teste";
            _presenter.Wrapper.Descricao = "A2 Teste";
            _presenter.Wrapper.Custo = 5;
            _presenter.Wrapper.Preco = 10;
        }

        internal class DialogMock : IDialogService
        {
            public void BuscaCamimhoImagem(Action<string> OkAction)
            {
                OkAction?.Invoke("imagemMock.jpeg");
            }

            public void Confirmacao(string mensagem, Action OkAction, string titulo = "Atenção")
            {
                OkAction?.Invoke();
            }

            public void Mensagem(string mensagem, Action okAction = null, string titulo = "Aviso")
            {
                okAction?.Invoke();
                _mensagemDoDialodMock = mensagem;
            }
        }

        #endregion
    }
}