using Prism.Mvvm;
using Prism.Windows.Navigation;
using System.Collections.Generic;
using System.Windows.Input;
using GPApp.Shared.Paginacao;
using GPApp.Wrapper;
using Prism.Commands;
using System;
using GPApp.Shared.Constantes;
using GPApp.Model;
using GPApp.Model.Helpers;
using GPApp.Repository;
using GPApp.Shared.Services;
using GPApp.Service;
using System.Linq;

namespace GPApp.Uwp.Logica.ViewModels
{
    public class ProdutosPageViewModel : BindableBase, INavigationAware
    {
        #region Membros privados

        private readonly INavigationService _navigationService;
        private readonly IPaginacaoRepository<ProdutoLookupWrapper> _paginacaoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IDialogService _dialogService;
        private readonly ProdutoClientService _produtoClientService;

        #endregion

        #region Construtor

        public ProdutosPageViewModel(
            INavigationService navigationService,
            IPaginacaoRepository<ProdutoLookupWrapper> paginacaoRepository,
            IProdutoRepository produtoRepository,
            IDialogService dialogService,
            ProdutoClientService produtoClientService
         ){
            _navigationService = navigationService;
            _paginacaoRepository = paginacaoRepository;
            _produtoRepository = produtoRepository;
            _dialogService = dialogService;
            _produtoClientService = produtoClientService;

            IncluirCommand = new DelegateCommand(OnIncluir);
            AlterarCommand = new DelegateCommand<Guid?>(OnAlterar);

            FiltrarCommand = new DelegateCommand(OnFiltrar, ()=> !ExibirPesquisa && string.IsNullOrWhiteSpace(_paginacaoRepository.Pesquisa));
            PesquisarCommand = new DelegateCommand(OnPesquisar);
            DesativarFiltroCommand = new DelegateCommand(OnDesativarFiltro);

            SincronizarNuvemCommand = new DelegateCommand(OnSincronizarWeb, () 
                => (NumeroProdutosSincronizar > 0) && !ProcessandoSincronizacaoWeb);

            PropertyChanged += ViewModelPropertyChanged;
        }

        #endregion

        #region Comandos

        public ICommand IncluirCommand { get; set; }
        public ICommand AlterarCommand { get; set; }

        public ICommand FiltrarCommand { get; set; }
        public ICommand PesquisarCommand { get; set; }
        public ICommand DesativarFiltroCommand { get; set; }

        public ICommand SincronizarNuvemCommand { get; set; }

        #endregion

        #region Ações

        private async void OnSincronizarWeb()
        {
            if (ProcessandoSincronizacaoWeb) return;
            ProcessandoSincronizacaoWeb = true;

            var resultado = await _produtoRepository.BuscaProdutosNaoSincronizados();
            if (!resultado.Valido)
            {
                _dialogService.Mensagem(resultado.Mensagem);
                ProcessandoSincronizacaoWeb = false;
                return;
            }

            var produtos = resultado.Valor;
            var resultadoWeb = await _produtoClientService.SalvarProdutos(produtos);
            if (resultadoWeb.Valido)
            {
                var produtosAtualizados = produtos.Where(p => !resultadoWeb.ItensInvalidos.Contains(p.Id));
                var resposta = await _produtoRepository
                     .AtualizaSincronizacaoAsync(
                             produtosAtualizados.Select(p => p.Id),
                             resultadoWeb.DataAtualizacao);

                if (resultadoWeb.ItensInvalidos.Count > 0)
                    _dialogService.Mensagem(
                        "Produtos que não foram atualizados:" +
                        String.Join("\n", resultadoWeb.ItensInvalidos));
            }
            else
            {
                _dialogService.Mensagem(resultado.Mensagem);
            }

            ProcessandoSincronizacaoWeb = false;
            await AtualizarNumeroRegistrosSincronizarAsync();
        }

        private void OnDesativarFiltro()
        {
            _paginacaoRepository.Pesquisa = string.Empty;
            Produtos.CleanUpPages();
            ExibirDesativarFiltro = false;
        }

        private void OnPesquisar()
        {
            _paginacaoRepository.Pesquisa = Pesquisa;
            Produtos.CleanUpPages();
            SetNumeroProdutosGrid();
            ExibirDesativarFiltro = !string.IsNullOrWhiteSpace(Pesquisa);
            ExibirPesquisa = false;
        }

        private void OnFiltrar()
        {
            ExibirPesquisa = true;
        }

        private async void OnAlterar(Guid? id)
        {
            if (!id.HasValue) return;

            var resultado = await _produtoRepository.LocalizaPorChavePrimariaAsync(id.Value);
            if (!resultado.Valido)
            {
                _dialogService.Mensagem(resultado.Mensagem);
                return;
            }
            var produto = resultado.Valor;
            _navigationService.Navigate(
                RegionNames.EDIT_PRODUTO,
                new NavegacaoParametro<Produto>(
                    ContantesGlobais.OPERACAO_ALTERACAO, produto));
        }

        private void OnIncluir()
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

        private bool _exibirPesquisa;
        public bool ExibirPesquisa
        {
            get { return _exibirPesquisa; }
            set { SetProperty(ref _exibirPesquisa, value); }
        }

        private bool _exibirDesativarFiltro;
        public bool ExibirDesativarFiltro
        {
            get { return _exibirDesativarFiltro; }
            set { SetProperty(ref _exibirDesativarFiltro, value); }
        }

        private int _numeroProdutosSincronizar;
        public int NumeroProdutosSincronizar
        {
            get { return _numeroProdutosSincronizar; }
            set { SetProperty(ref _numeroProdutosSincronizar, value); }
        }

        private bool _processandoSincronizacaoWeb;
        public bool ProcessandoSincronizacaoWeb
        {
            get { return _processandoSincronizacaoWeb; }
            set { SetProperty(ref _processandoSincronizacaoWeb, value); }
        }

        #endregion

        #region Navegação

        public async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            if ((Produtos == null) || EhParaAtualizarGrid(e))
                CarregaProdutos();

            await AtualizarNumeroRegistrosSincronizarAsync();
        }

        public void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
        }

        #endregion

        #region Handlers

        private void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ((DelegateCommand)IncluirCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)FiltrarCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)PesquisarCommand).RaiseCanExecuteChanged();
        }

        private void Produtos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
        }

        #endregion

        #region Métodos

        private async System.Threading.Tasks.Task AtualizarNumeroRegistrosSincronizarAsync()
        {
            var resultadoBase = await _produtoRepository.NumeroRegistrosSincronizarAsync();
            if (resultadoBase.Valido)
                NumeroProdutosSincronizar = resultadoBase.Valor;
        }

        private void CarregaProdutos()
        {
            Produtos = new VirtualizingCollection<ProdutoLookupWrapper>(_paginacaoRepository, 100);
            Produtos.CollectionChanged -= Produtos_CollectionChanged;
            Produtos.CollectionChanged += Produtos_CollectionChanged;
            SetNumeroProdutosGrid();
        }

        private void SetNumeroProdutosGrid()
        {
            string strNumeroProdutos;
            switch (Produtos.Count)
            {
                case 0:
                    strNumeroProdutos = "Nenhum produto cadastrado";
                    break;
                case 1:
                    strNumeroProdutos = "1 produto";
                    break;
                default:
                    strNumeroProdutos = Produtos.Count + " produtos";
                    break;
            }
            NumeroProdutos = strNumeroProdutos;
        }

        private static bool EhParaAtualizarGrid(NavigatedToEventArgs e)
        {
            return e != null &&
                   e.Parameter is NavegacaoParametro param && 
                   param.Operacao == ContantesGlobais.ATUALIZAR_GRID;
        }

        #endregion
    }
}