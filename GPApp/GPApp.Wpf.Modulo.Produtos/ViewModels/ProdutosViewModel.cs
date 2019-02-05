using GPApp.Repository;
using GPApp.Shared.Constantes;
using GPApp.Shared.Paginacao;
using GPApp.Shared.Services;
using GPApp.Wrapper;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Input;

namespace GPApp.Wpf.Modulo.Produtos.ViewModels
{
    public class ProdutosViewModel : BindableBase, INavigationAware
    {
        #region Membros privados

        private readonly IRegionManager _regionManager;
        private readonly IPaginacaoRepository<ProdutoLookupWrapper> _paginacaoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IDialogService _dialogService;

        #endregion

        #region Construtor

        public ProdutosViewModel(
            IRegionManager regionManager,
            IPaginacaoRepository<ProdutoLookupWrapper> paginacaoRepository,
            IProdutoRepository produtoRepository,
            IDialogService dialogService
         )
        {
            _regionManager = regionManager;
            _paginacaoRepository = paginacaoRepository;
            _produtoRepository = produtoRepository;
            _dialogService = dialogService;


            IncluirCommand = new DelegateCommand(OnIncluir);
            AlterarCommand = new DelegateCommand<Guid?>(OnAlterar);

            SincronizarNuvemCommand = new DelegateCommand(OnSincronizarNuvem, () => NumeroRegistrosSincronizar > 0);
            FiltrarCommand = new DelegateCommand(OnFiltrarCommand, PodeFiltrar);
            PesquisarCommand = new DelegateCommand(OnPesquisar);
            DesativarFiltroCommand = new DelegateCommand(OnDesativarFiltro);

            ExibirPesquisa = Visibility.Hidden;
            ExibirDesativarFiltro = Visibility.Hidden;

            PropertyChanged += ViewModelPropertyChanged;
        }

        #endregion

        #region Propriedades

        public Action AtualizarGrid { get; set; }

        public ICommand IncluirCommand { get; set; }
        public ICommand AlterarCommand { get; set; }
        public ICommand SincronizarNuvemCommand { get; set; }
        public ICommand FiltrarCommand { get; set; }
        public ICommand PesquisarCommand { get; set; }
        public ICommand DesativarFiltroCommand { get; set; }

        private VirtualizingCollection<ProdutoLookupWrapper> _produtos;
        public VirtualizingCollection<ProdutoLookupWrapper> Produtos
        {
            get { return _produtos; }
            set { SetProperty(ref _produtos, value); }
        }

        private string _numeroRegistros;
        public string NumeroRegistros
        {
            get { return _numeroRegistros; }
            set { SetProperty(ref _numeroRegistros, value); }
        }

        private Visibility _exibirPesquisa;
        public Visibility ExibirPesquisa
        {
            get { return _exibirPesquisa; }
            set { SetProperty(ref _exibirPesquisa, value); }
        }

        private Visibility _desativaFiltro;
        public Visibility ExibirDesativarFiltro
        {
            get { return _desativaFiltro; }
            set { SetProperty(ref _desativaFiltro, value); }
        }

        private int _numeroRegistrosSincronizar;
        public int NumeroRegistrosSincronizar
        {
            get { return _numeroRegistrosSincronizar; }
            set { SetProperty(ref _numeroRegistrosSincronizar, value); }
        }

        private string _textoPesquisa;
        public string TextoPesquisa
        {
            get { return _textoPesquisa; }
            set { SetProperty(ref _textoPesquisa, value); }
        }

        #endregion

        #region Ações

        private void OnDesativarFiltro()
        {
            _paginacaoRepository.Pesquisa = string.Empty;
            Produtos.Reload();
            AtualizarGrid?.Invoke();
            ExibirDesativarFiltro = Visibility.Hidden;
            SetnumeroRegistros();
        }

        private void OnPesquisar()
        {
            _paginacaoRepository.Pesquisa = TextoPesquisa;
            Produtos.Reload();
            AtualizarGrid?.Invoke();

            if (!string.IsNullOrEmpty(TextoPesquisa))
            {
                ExibirDesativarFiltro = Visibility.Visible;
            }

            ExibirPesquisa = Visibility.Hidden;
            SetnumeroRegistros();
        }

        private void OnFiltrarCommand()
        {
            ExibirPesquisa = Visibility.Visible;
        }

        private void OnIncluir()
        {
            _regionManager.RequestNavigate(RegionNames.MAIN_REGION, RegionNames.EDIT_PRODUTO);
        }

        private async void OnAlterar(Guid? id)
        {
            var resultado = await _produtoRepository
                                .LocalizaPorChavePrimariaAsync(id.Value);
            if (!resultado.Valido)
            {
                _dialogService.Mensagem(resultado.Mensagem);
                return;
            }

            var produto = resultado.Valor;
            var param = new NavigationParameters
                {
                    { ContantesGlobais.OPERACAO_ALTERACAO,produto}
                };

            _regionManager.RequestNavigate(
                RegionNames.MAIN_REGION,
                RegionNames.EDIT_PRODUTO,
                param);
        }

        private void OnSincronizarNuvem()
        {
        }

        #endregion

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
            if (Produtos == null)
                Produtos = new VirtualizingCollection<ProdutoLookupWrapper>(
                    _paginacaoRepository, pageSize: 100);

            if (navigationContext.Parameters.ContainsKey(ContantesGlobais.ATUALIZAR_GRID))
            {
                Produtos = new VirtualizingCollection<ProdutoLookupWrapper>(
                    _paginacaoRepository, pageSize: 100);
            }

            SetnumeroRegistros();
            await SetNumeroREgistrosSincronizarNuvem();
        }

        #endregion

        #region Métodos

        private bool PodeFiltrar()
        {
            return (Produtos != null) &&
                    (Produtos.Count > 0) &&
                    string.IsNullOrEmpty(_paginacaoRepository.Pesquisa);
        }

        private async System.Threading.Tasks.Task SetNumeroREgistrosSincronizarNuvem()
        {
            var resultado = await _produtoRepository
                                         .NumeroRegistrosSincronizarAsync();
            if (resultado.Valido)
            {
                NumeroRegistrosSincronizar = resultado.Valor;
            }
        }

        private void SetnumeroRegistros()
        {
            NumeroRegistros = FormataNumeroRegistros(Produtos.Count);
        }

        private string FormataNumeroRegistros(int numero)
        {
            var strNumeroRegistros = string.Empty;
            switch (numero)
            {
                case 0: return "Nenhum produto cadastrado";
                case 1: return "1 produto";
                default: return numero + " produtos";
            }
        }

        #endregion

        #region Handlers

        private void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ((DelegateCommand)SincronizarNuvemCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)FiltrarCommand).RaiseCanExecuteChanged();
        }

        #endregion
    }
}
