using GPApp.Repository;
using GPApp.Shared.Dados;
using GPApp.Shared.Paginacao;
using GPApp.Shared.Services;
using GPApp.Wpf.Modulo.Produtos;
using GPApp.Wpf.Services;
using GPApp.Wpf.ViewModels;
using GPApp.Wpf.Views;
using GPApp.Wrapper;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Linq;
using System.Windows;

namespace GPApp.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.SplashScreen, SplashScreenViewModel>();

            containerRegistry.Register<IDialogService, DialogService>();
            containerRegistry.Register<IArquivoService, ArquivoService>();
            containerRegistry.Register<IConfiguracaoService, ConfigurationService>();

            containerRegistry.Register<IDataBaseRepository, DataBaseRepository>();
            containerRegistry.Register<IProdutoRepository, ProdutoRepository>();
            containerRegistry.Register<IPaginacaoRepository<ProdutoLookupWrapper>,ProdutoPaginacaoRepository>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Type produtosType = typeof(ProdutosModule);
            moduleCatalog.AddModule(
            new ModuleInfo()
            {
                ModuleName = produtosType.Name,
                ModuleType = produtosType.AssemblyQualifiedName,
            });
        }
    }
}
