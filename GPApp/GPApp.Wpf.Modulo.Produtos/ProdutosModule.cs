using GPApp.Shared.Constantes;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace GPApp.Wpf.Modulo.Produtos
{
    public class ProdutosModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ProdutosModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
 
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.Produtos, ViewModels.ProdutosViewModel>();
            containerRegistry.RegisterForNavigation<Views.ProdutoEdit, ViewModels.ProdutoEditViewModel>();
            _regionManager.RequestNavigate(RegionNames.MAIN_REGION, nameof(Views.Produtos));
        }
    }
}