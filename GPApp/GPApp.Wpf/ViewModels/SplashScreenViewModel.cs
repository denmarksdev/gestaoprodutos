using GPApp.Model.Database;
using GPApp.Shared.Constantes;
using GPApp.Shared.Dados;
using GPApp.Shared.Services;
using Prism.Mvvm;
using Prism.Regions;

namespace GPApp.Wpf.ViewModels
{
    public class SplashScreenViewModel : BindableBase , INavigationAware
    {
        private readonly IDataBaseRepository _dataBaseRepository;
        private readonly IConfiguracaoService _configuracaoService;
        private readonly IRegionManager _regionManager;

        public SplashScreenViewModel(
            IDataBaseRepository dataBaseRepository,
            IConfiguracaoService configuracaoService,
            IRegionManager regionManager
        ){
            _dataBaseRepository = dataBaseRepository;
            _configuracaoService = configuracaoService;
            _regionManager = regionManager;
        }

        #region Navegação

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var config = new BancoDadosConfig(BancoDados.SqlServer, _configuracaoService.ConnectionString);
            var resultado =  await _dataBaseRepository.IniciaAsync(config);
            if (resultado.Valido)
            {
                _regionManager.RequestNavigate(RegionNames.MAIN_REGION, RegionNames.PRODUTOS);
            }
        }

        #endregion
    }
}
