using GPApp.Presenter.Grid;
using GPApp.Presenter.Modulos.Produtos;
using GPApp.Presenter.PubSub;
using GPApp.Repository;
using GPApp.Service;
using GPApp.Shared.Dados;
using GPApp.Shared.Paginacao;
using GPApp.Shared.Services;
using GPApp.WinForms.Componentes;
using GPApp.WinForms.Services;
using GPApp.WinForms.Views;
using GPApp.Wrapper;

namespace GPApp.WinForms.PontoPartida
{
    class IOCContainer
    {
        public static Ninject.IKernel GetContainer()
        {
            Ninject.IKernel Kernel = new Ninject.StandardKernel();

            ConfiguraView(Kernel);
            ConfiguraGrid(Kernel);
            ConfiguraRepository(Kernel);
            ConfiguraService(Kernel);

            Kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();

            return Kernel;
        }

        private static void ConfiguraService(Ninject.IKernel Kernel)
        {
            Kernel.Bind<IEmailService>().To<EmailService>();
            Kernel.Bind<IConfiguracaoService>().To<ConfigurationService>();
            Kernel.Bind<IDialogService>().To<DialogService>();
            Kernel.Bind<IArquivoService>().To<ArquivoService>();
        }

        private static void ConfiguraRepository(Ninject.IKernel Kernel)
        {
            Kernel.Bind<IDataBaseRepository>().To<DataBaseRepository>();
            Kernel.Bind<IPaginacaoRepository<ProdutoLookupWrapper>>().To<ProdutoPaginacaoRepository>();
            Kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
        }

        private static void ConfiguraView(Ninject.IKernel Kernel)
        {
            Kernel.Bind<IProdutosView>().To<ProdutosView>();
            Kernel.Bind<IProdutoEditView>().To<ProdutoEditView>();
        }

        private static void ConfiguraGrid(Ninject.IKernel Kernel)
        {
            Kernel.Bind<IGridView>().To<VirtualGrid>();
            Kernel.Bind<IGridViewFiltro>().To<VirtualGridFiltro>();
        }
    }
}