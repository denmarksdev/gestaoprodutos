using GPApp.Model;
using GPApp.Model.Helpers;
using GPApp.Repository;
using GPApp.Shared.Constantes;
using GPApp.Shared.Helpers;
using GPApp.Shared.Services;
using GPApp.Wrapper;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace GPApp.Wpf.Modulo.Produtos.ViewModels
{
    public class ProdutoEditViewModel : BindableBase , INavigationAware
    {
        #region Membros privados

        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        private IArquivoService _arquivoService;
        private readonly IProdutoRepository _produtoRepository;
        private bool _processando;

        #endregion

        #region Contrutor

        public ProdutoEditViewModel(
            IRegionManager regionManager,
            IDialogService dialogService,
            IArquivoService arquivoService,
            IProdutoRepository produtoRepository
         ){
            _regionManager = regionManager;
            _dialogService = dialogService;
            _arquivoService = arquivoService;
            _produtoRepository = produtoRepository;

            IncluirImagemCommand = new DelegateCommand(OnIncluirImagem);
            AlterarImagemCommand = new DelegateCommand<short?>(OnAlterarImagem);
            ExcluirImagemCommand = new DelegateCommand<short?>(OnExcluirImagem);

            IncluirEspecificacaoCommand = new DelegateCommand(OnIncluirEspecificacao);
            ExcluirEspecificacaoCommand = new DelegateCommand<short?>(OnExcluirEspecificacao);

            SalvarCommand = new DelegateCommand(OnSalvar, PodeSalvar);
            VoltarCommand = new DelegateCommand(() =>
                _regionManager.RequestNavigate(RegionNames.MAIN_REGION, RegionNames.PRODUTOS));
        }
       
        #endregion

        #region Propriedades

        private ProdutoWrapper _wrapper;
        public ProdutoWrapper Wrapper
        {
            get { return _wrapper; }
            set { SetProperty(ref _wrapper, value); }
        }

        private ProdutoImagemWrapper _imagemSelecionada;
        public ProdutoImagemWrapper ImagemSelecionada
        {
            get { return _imagemSelecionada; }
            set { SetProperty(ref _imagemSelecionada, value); }
        }

        private string _operacao;
        public string Operacao
        {
            get { return _operacao; }
            set { SetProperty(ref _operacao, value); }
        }


        public ICommand SalvarCommand { get; set; }
        public ICommand VoltarCommand { get; set; }

        public ICommand IncluirImagemCommand { get; set; }
        public ICommand AlterarImagemCommand { get; set; }
        public ICommand ExcluirImagemCommand { get; set; }

        public ICommand IncluirEspecificacaoCommand { get; set; }
        public ICommand ExcluirEspecificacaoCommand { get; set; }

        #endregion

        #region Acões

        private bool PodeSalvar()
        {
            return Wrapper != null &&
                   Wrapper.IsValid &&
                   Wrapper.IsChanged &&
                   !_processando;
        }

        private async void OnSalvar()
        {
            if (_processando) return;
            _processando = true;

            var model = Wrapper.Model;

            Resultado resultado;
            if (Guid.Empty == model.Id)
                resultado = await _produtoRepository.IncluirAsync(model);
            else
                resultado = await _produtoRepository.AtualizaAsync(model);

            if (resultado.Valido)
            {
                var parametros = new NavigationParameters
                {
                    {ContantesGlobais.ATUALIZAR_GRID,ContantesGlobais.ATUALIZAR_GRID}
                };
                _regionManager.RequestNavigate(RegionNames.MAIN_REGION, RegionNames.PRODUTOS , parametros);
            }
            else
            {
                _dialogService.Mensagem(resultado.Mensagem);
            }

            _processando = false;
        }

        private void OnIncluirImagem()
        {
            _dialogService.BuscaCamimhoImagem(path =>
            {
                var imagem = new ProdutoImagemWrapper(new ProdutoImagem
                {
                    Ordem = Wrapper.GeraProximoOrdemImagem()
                });

                SetImagemPorPath(path, imagem);
                Wrapper.Imagens.Add(imagem);
                ImagemSelecionada = imagem;
            });
            
        }

        private void OnAlterarImagem(short? ordem)
        {
            _dialogService.BuscaCamimhoImagem(path =>
            {
               var imagem = Wrapper.Imagens.First(i => i.Ordem == ordem);
                SetImagemPorPath(path,imagem);
            });
            
        }

        private void OnExcluirImagem(short? ordem)
        {
            _dialogService.Confirmacao($"Excluir imagem nº {ordem}?", () => {

                var imagem = Wrapper.Imagens.First(i => i.Ordem == ordem);
                Wrapper.Imagens.Remove(imagem);
                ImagemSelecionada = Wrapper.Imagens.FirstOrDefault();
                Wrapper.ReordenarImagens();
            });
        }

        private void OnIncluirEspecificacao()
        {
            var Especificacao = new ProdutoEspecificacaoWrapper(new ProdutoEspecificacao
            {
                Ordem = Wrapper.GeraProximoOrdemEspecificacao()
            });
            Wrapper.Especificacoes.Add(Especificacao);
        }

        private void OnExcluirEspecificacao(short? ordem)
        {
            _dialogService.Confirmacao($"Excluir especificação n° {ordem}?", () =>
            {
                var especificacao = Wrapper.Especificacoes.First(e => e.Ordem == ordem);
                Wrapper.Especificacoes.Remove(especificacao);
                Wrapper.ReordenarEspecificacoes();
            });
        }

        #endregion

        #region Métodos

        private void SetImagemPorPath(string path, ProdutoImagemWrapper imagem)
        {
            imagem.Sufixo = ArquivoHelper.GetExtensaoArquivo(path);
            imagem.Dados = _arquivoService.GetImagemBase64(path);
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

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey(ContantesGlobais.OPERACAO_ALTERACAO))
            {
                var produto = navigationContext
                        .Parameters[ContantesGlobais.OPERACAO_ALTERACAO] as Produto;

                Operacao = "Alterar produto";
                Wrapper = new ProdutoWrapper(produto);
            }
            else
            {
                Operacao = "Novo produto";
                Wrapper = new ProdutoWrapper(new Produto
                {
                    Imagens = new List<ProdutoImagem>(),
                    Especificacoes = new List<ProdutoEspecificacao>(),
                    EstoqueAtual = new ProdutoEstoque(),
                    DataCadastro = DateTime.UtcNow
                });
            }
            Wrapper.PropertyChanged -= ViewModelPropertyChanged;
            Wrapper.PropertyChanged += ViewModelPropertyChanged;
        }

        #endregion

        #region Handlers

        private void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ((DelegateCommand)SalvarCommand).RaiseCanExecuteChanged();
        }

        #endregion
    }
}
