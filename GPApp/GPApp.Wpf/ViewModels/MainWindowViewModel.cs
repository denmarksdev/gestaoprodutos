using GPApp.Shared.Constantes;
using Prism.Mvvm;
using Prism.Regions;

namespace GPApp.Wpf.ViewModels
{
    public class MainWindowViewModel : BindableBase , INavigationAware
    {
        private string _title = "Gestão de produtos";
        private readonly IRegionManager _regionManager;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public  MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            
        }

        #region Navegação

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
         
        }

        #endregion

    }
}
