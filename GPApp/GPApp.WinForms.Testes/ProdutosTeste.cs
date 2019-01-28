using GPApp.Presenter.Grid;
using GPApp.Presenter.Modulos.Produtos;
using GPApp.Service;
using GPApp.Wrapper;
using Moq;
using Xunit;

namespace GPApp.WinForms.Testes
{
    public class ProdutosTeste
    {
        private readonly GridViewPresenter<ProdutoLookupWrapper> _gridView;
        private readonly ProdutosPresenter _presenter;
        private readonly Mock<IProdutosView> _mockView;
        private readonly Mock<IEmailService> _emailService;

        public ProdutosTeste()
        {
            _mockView = new Mock<IProdutosView>();
            _mockView.SetupAllProperties();
            _emailService = new Mock<IEmailService>();

            var gridMock = new Mock<IGridViewFiltro>();
            gridMock.SetupAllProperties();

            _gridView = new GridViewPresenter<ProdutoLookupWrapper>(gridMock.Object);
            _presenter = new ProdutosPresenter(_mockView.Object, _gridView, _emailService.Object);
        }

        [Fact]
        public void AcaoIncluirTest()
        {
            _mockView.Object.IncluirProdutoAction.Invoke();
            _mockView.Verify(f => f.ExibeAbaEdicao());
        }
    }
}