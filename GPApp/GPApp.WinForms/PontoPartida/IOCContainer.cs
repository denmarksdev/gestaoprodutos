using GPApp.Presenter.Grid;
using GPApp.Presenter.Modulos.Produtos;
using GPApp.Repository;
using GPApp.Shared.Dados;
using GPApp.WinForms.Componentes;
using GPApp.WinForms.Views;

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

            return Kernel;
        }

        private static void ConfiguraRepository(Ninject.IKernel Kernel)
        {
            Kernel.Bind<IDataBaseRepository>().To<DataBaseRepository>();
        }

        private static void ConfiguraView(Ninject.IKernel Kernel)
        {
            Kernel.Bind<IProdutosView>().To<ProdutosView>();
        }

        private static void ConfiguraGrid(Ninject.IKernel Kernel)
        {
            Kernel.Bind<IGridView>().To<VirtualGrid>();
            Kernel.Bind<IGridViewFiltro>().To<VirtualGridFiltro>();
        }
    }
}