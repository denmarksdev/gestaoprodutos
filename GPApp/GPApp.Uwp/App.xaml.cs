using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using GPApp.Shared.Constantes;
using Prism.Mvvm;
using Prism.Unity.Windows;
using Unity;
using Windows.ApplicationModel.Activation;
using GPApp.Shared.Services;
using GPApp.Uwp.Services;
using GPApp.Shared.Dados;
using GPApp.Repository;
using GPApp.Wrapper;
using GPApp.Shared.Paginacao;
using GPApp.Model.Database;

namespace GPApp.Uwp
{
    [Bindable(true)]
    sealed partial class App : PrismUnityApplication
    {
        private static string _AssemblyNameViewModel;

        public App()
        {
            InitializeComponent();
            var logica = Assembly.Load("GPApp.Uwp.Logica");
            _AssemblyNameViewModel = logica.FullName;
        }

        protected async  override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            var dadosRepo = Container.Resolve<IDataBaseRepository>();
            var configuracaoService = Container.Resolve<IConfiguracaoService>();
            var config = new BancoDadosConfig(BancoDados.Sqlite, configuracaoService.ConnectionString);
            var resultado = await dadosRepo.IniciaAsync(config);

            if (resultado.Valido)
            {
                NavigationService.Navigate(RegionNames.PRODUTOS, null);
            }
            else
            {
            }
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            ConfiguraServicosProxy();
            ConfiguraRepositorios();
        }

        private void ConfiguraServicosProxy()
        {
            Container
                .RegisterType<IArquivoService, Services.ArquivoService>()
                .RegisterType<IDialogService, DialogService>()
                .RegisterSingleton<IConfiguracaoService, ConfiguracaoService>();
        }

        private void ConfiguraRepositorios()
        {
            Container
                .RegisterType<IDataBaseRepository, DataBaseRepository>()
                .RegisterType<IProdutoRepository, ProdutoRepository>()
                .RegisterType<IPaginacaoRepository<ProdutoLookupWrapper>, ProdutoPaginacaoRepository>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewName = $"GPApp.Uwp.Logica.ViewModels.{viewType.Name}";
                var viewModelName = $"{viewName}ViewModel, {_AssemblyNameViewModel}";
                return Type.GetType(viewModelName);
            });
        }
    }
}