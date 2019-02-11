using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GPApp.Model;
using GPApp.Model.Helpers;
using GPApp.Repository;
using GPApp.Shared.Constantes;
using GPApp.Shared.Helpers;
using GPApp.Shared.Services;
using GPApp.Uwp.Logica.Model;
using GPApp.Wrapper;
using GPApp.Wrapper.Base;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Windows.Navigation;

namespace GPApp.Uwp.Logica.ViewModels
{
    public class ProdutoEditPageViewModel : BindableBase, INavigationAware
    {
        #region Membros privados

        private readonly IDialogService _dialogService;
        private readonly IArquivoService _arquivoService;
        private readonly IProdutoRepository _produtoRepository;
        private readonly INavigationService _navigationService;

        #endregion

        #region Construtor

        public ProdutoEditPageViewModel(
            IDialogService dialogService,
            IArquivoService arquivoService,
            IProdutoRepository produtoRepository,
            INavigationService navigationService
        )
        {
            _dialogService = dialogService;
            _arquivoService = arquivoService;
            _produtoRepository = produtoRepository;
            _navigationService = navigationService;

            ConfigurarCommands();

            PropertyChanged += ViewModelPropertyChanged;
        }

        #endregion

        #region Comandos

        public ICommand SalvarCommand { get; set; }

        public ICommand IncluirImagemCommand { get; set; }
        public ICommand AlterarImagemCommand { get; set; }
        public ICommand ExcluirImagemCommand { get; set; }

        public ICommand IncluirEspecificacaoCommand { get; set; }
        public ICommand ExcluirEspecificacaoCommand { get; set; }

        #endregion

        #region Propriedades


        private bool _imagensForamAlteradas;
        public bool ImagensForamAlteradas
        {
            get { return _imagensForamAlteradas; }
            set { SetProperty(ref _imagensForamAlteradas, value); }
        }


        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set { SetProperty(ref _titulo, value); }
        }

        private ProdutoWrapper _wrapper;
        public ProdutoWrapper Wrapper
        {
            get { return _wrapper; }
            set { SetProperty(ref _wrapper, value); }
        }

        private ChangeTrackingCollection<ProdutoImageUWPWrapper> _imagens;
        public ChangeTrackingCollection<ProdutoImageUWPWrapper> Imagens
        {
            get { return _imagens; }
            set { SetProperty(ref _imagens, value); }
        }

        private ProdutoImageUWPWrapper _imagemSelecionda;
        public ProdutoImageUWPWrapper ImagemSelecionada
        {
            get { return _imagemSelecionda; }
            set { SetProperty(ref _imagemSelecionda, value); }
        }

        private bool _exibeProgressBar;
        public bool ExibirProgressBar
        {
            get { return _exibeProgressBar; }
            set { SetProperty(ref _exibeProgressBar, value); }
        }

        #endregion

        #region Ações

        private bool PodeSalvar()
        {
            return Wrapper != null &&
                   Wrapper.IsValid &&
                   Wrapper.IsChanged || ImagensForamAlteradas;
        }

        private async void OnSalvar()
        {
            if (ExibirProgressBar) return;

            ExibirProgressBar = true;

            foreach (var imagem in Imagens)
            {
                Wrapper.Imagens.Add(imagem);
            }

            var model = Wrapper.Model;
            Resultado resultado;
            if (model.Id == Guid.Empty)
                resultado = await _produtoRepository.IncluirAsync(model);
            else
                resultado = await _produtoRepository.AtualizaAsync(model);

            if (resultado.Valido)
            {
                var param = new NavegacaoParametro(ContantesGlobais.ATUALIZAR_GRID);
                _navigationService.Navigate(RegionNames.PRODUTOS, param);
            }
            else
            {
                _dialogService.Mensagem(resultado.Mensagem);
            }

            ExibirProgressBar = false;
        }

        private void OnExcluirEspecificacao(short? ordem)
        {
            if (!ordem.HasValue) return;

            _dialogService.Confirmacao($"Excluir especificação n° {ordem}", () =>
            {
                var especificacao = Wrapper.Especificacoes.First(e => e.Ordem == ordem);
                Wrapper.Especificacoes.Remove(especificacao);
                Wrapper.ReordenarEspecificacoes();
            });
        }


        private void OnIncluirEspecificacao()
        {
            var especfificacao = new ProdutoEspecificacaoWrapper(new ProdutoEspecificacao {
                Ordem = Wrapper.GeraProximoOrdemEspecificacao()
            });
            Wrapper.Especificacoes.Add(especfificacao);
        }


        private  void OnExcluirImagem(short? ordem)
        {
            if (!ordem.HasValue) return;

            _dialogService.Confirmacao($"Excluir imagem nº {ordem} ", async () =>
            {
                var imagem = Imagens.First(i => i.Ordem == ordem);
                
                Imagens.Remove(imagem);
                ReordenarImagens();
                ImagemSelecionada = Imagens.FirstOrDefault();
                if (ImagemSelecionada != null)
                {
                    await ImagemSelecionada.InitImage();
                }
                else
                {
                    ImagemSelecionada = new ProdutoImageUWPWrapper(new ProdutoImagem())
                    {
                        Image = null
                    };
                }

            });
        }
        

        private void OnAlterarImagem(short? ordem)
        {
            if (!ordem.HasValue) return;

            _dialogService.BuscaCamimhoImagem(async (path, bytes) =>
            {
                var imagem = Imagens.First(i => i.Ordem == ordem);

                imagem.Dados = _arquivoService.GetImagemBase64(bytes);
                imagem.Sufixo = ArquivoHelper.GetExtensaoArquivo(path);

                await imagem.InitImage();

                ImagemSelecionada = imagem;
            });
        }


        private void OnIncluirImagem()
        {
            _dialogService.BuscaCamimhoImagem( async (path, bytes) =>
            {
                var imagem = new ProdutoImageUWPWrapper(new ProdutoImagem
                {
                    Ordem = GeraPróximaOrdem(),
                    Dados = _arquivoService.GetImagemBase64(bytes),
                    Prefixo = ArquivoHelper.GetExtensaoArquivo(path)
                });
                await imagem.InitImage();
                ImagemSelecionada = imagem;
                Imagens.Add(imagem);
            });
        }

        private short GeraPróximaOrdem()
        {
            return Imagens.Count == 0
                     ? short.Parse("1")
                     : Convert.ToInt16(Imagens.Max(i => i.Ordem) + 1);
        }

        #endregion

        #region Navegação

        public async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            if (!(e.Parameter is NavegacaoParametro<Produto> param)) return;

            if (param.Operacao == ContantesGlobais.OPERACAO_ALTERACAO)
            {
                Titulo = "Alterar produto";

                Wrapper = new ProdutoWrapper(param.Item);
                Imagens = new ChangeTrackingCollection<ProdutoImageUWPWrapper>(
                                 param.Item.Imagens.Select(i => new ProdutoImageUWPWrapper(i)));
                foreach (var imagem in Imagens)
                {
                    await imagem.InitImage();
                }

                param.Item.Imagens.Clear();
                Wrapper.Imagens.Clear();
            }
            else
            {
                Titulo = "Incluir produto";

                Wrapper = new ProdutoWrapper(new Produto
                {
                    DataCadastro = DateTime.UtcNow,
                    EstoqueAtual = new ProdutoEstoque()
                });
                Imagens = new ChangeTrackingCollection<ProdutoImageUWPWrapper>(new List<ProdutoImageUWPWrapper>());
            }

            Wrapper.PropertyChanged -= ViewModelPropertyChanged;
            Wrapper.PropertyChanged += ViewModelPropertyChanged;
            Imagens.CollectionChanged += Imagens_CollectionChanged;
            
        }

        private void Imagens_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ImagensForamAlteradas = true;
        }

        public void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
        }

        #endregion

        #region Handlers

        private void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RaiseSalvarCommand();
        }

        private void RaiseSalvarCommand()
        {
            ((DelegateCommand)SalvarCommand).RaiseCanExecuteChanged();
        }

        #endregion

        #region Métodos

        private void ConfigurarCommands()
        {
            SalvarCommand = new DelegateCommand(OnSalvar, PodeSalvar);

            IncluirImagemCommand = new DelegateCommand(OnIncluirImagem);
            AlterarImagemCommand = new DelegateCommand<short?>(OnAlterarImagem);
            ExcluirImagemCommand = new DelegateCommand<short?>(OnExcluirImagem);

            IncluirEspecificacaoCommand = new DelegateCommand(OnIncluirEspecificacao);
            ExcluirEspecificacaoCommand = new DelegateCommand<short?>(OnExcluirEspecificacao);
        }

        private void ReordenarImagens()
        {
            for (int i = 0; i < Imagens.Count; i++)
            {
                Imagens[i].Ordem = Convert.ToInt16(i + 1);
            }
        }

        #endregion
    }
}
