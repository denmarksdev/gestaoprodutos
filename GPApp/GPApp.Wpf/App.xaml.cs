using GPApp.Wpf.Modulo.Produtos;
using GPApp.Wpf.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Windows;

namespace GPApp.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
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
