using Prism.Mvvm;
using Prism.Windows.Navigation;
using System.Collections.Generic;
using System.Windows.Input;
using GPApp.Shared.Paginacao;
using GPApp.Wrapper;
using Windows.UI.Xaml;
using Prism.Commands;
using System;
using GPApp.Shared.Constantes;
using GPApp.Model;
using GPApp.Model.Helpers;

namespace GPApp.Uwp.Logica.ViewModels
{
    public class ProdutosPageViewModel : BindableBase, INavigationAware
    {
        #region Membros privados

        private readonly INavigationService _navigationService;
        private readonly IPaginacaoRepository<ProdutoLookupWrapper> _paginacaoRepository;

        #endregion

        #region Construtor

        public ProdutosPageViewModel(
            INavigationService navigationService,
            IPaginacaoRepository<ProdutoLookupWrapper> paginacaoRepository
         ){
            _navigationService = navigationService;
            _paginacaoRepository = paginacaoRepository;

            ExibirPesquisa = Visibility.Collapsed;
            ExibirDesativarFiltro = Visibility.Collapsed;

            IncluirCommand = new DelegateCommand(OnIncluirCommand);

            PropertyChanged += ViewModelPropertyChanged;
        }

        #endregion

        #region Comandos

        public ICommand IncluirCommand { get; set; }
        public ICommand AlterarCommand { get; set; }

        public ICommand FiltrarCommand { get; set; }
        public ICommand PesquisarCommand { get; set; }

        public ICommand SincronizarNuvemCommand { get; set; }

        #endregion

        #region Ações
        private void OnIncluirCommand()
        {
            _navigationService.Navigate(
                RegionNames.EDIT_PRODUTO, 
                new NavegacaoParametro<Produto>());
        }

        #endregion

        #region Propriedades

        private VirtualizingCollection<ProdutoLookupWrapper> _produtos;
        public VirtualizingCollection<ProdutoLookupWrapper> Produtos
        {
            get { return _produtos; }
            set { SetProperty(ref _produtos, value); }
        }

        private string _numeroProdutos;
        public string NumeroProdutos
        {
            get  =>  _numeroProdutos;
            set  =>  SetProperty(ref _numeroProdutos, value);
        }

        private string _pesquisa;
        public string Pesquisa
        {
            get => _pesquisa; 
            set => SetProperty(ref _pesquisa, value); 
        }

        private Visibility _exibirPesquisa;
        public Visibility ExibirPesquisa
        {
            get { return _exibirPesquisa; }
            set { SetProperty(ref _exibirPesquisa, value); }
        }

        private Visibility _exibirDesativarFiltro;
        public Visibility ExibirDesativarFiltro
        {
            get { return _exibirDesativarFiltro; }
            set { SetProperty(ref _exibirDesativarFiltro, value); }
        }

        #endregion

        #region Navegação

        public void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            if (Produtos == null)
                Produtos = new VirtualizingCollection<ProdutoLookupWrapper>(_paginacaoRepository, 30);

            if (EhParaAtualizarGrid(e))
            {
                Produtos = new VirtualizingCollection<ProdutoLookupWrapper>(_paginacaoRepository, 30);
            }
        }

        public void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
        }

        #endregion

        #region Handlers

        private void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ((DelegateCommand)IncluirCommand).RaiseCanExecuteChanged();
        }

        #endregion

        #region Métodos

        private static bool EhParaAtualizarGrid(NavigatedToEventArgs e)
        {
            return e != null &&
                   e.Parameter is NavegacaoParametro param && 
                   param.Operacao == ContantesGlobais.ATUALIZAR_GRID;
        }

        #endregion
    }
}
