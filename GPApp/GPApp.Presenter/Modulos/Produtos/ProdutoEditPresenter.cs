using GPApp.Model;
using GPApp.Model.Helpers;
using GPApp.Presenter.Base;
using GPApp.Presenter.PubSub;
using GPApp.Presenter.PubSub.Eventos;
using GPApp.Repository;
using GPApp.Shared.Helpers;
using GPApp.Shared.Services;
using GPApp.Wrapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GPApp.Presenter.Modulos.Produtos
{
    public class ProdutoEditPresenter : BasePresenterModel<ProdutoWrapper, IProdutoEditView>
    {
        #region Membros privados

        private readonly IDialogService _dialogService;
        private readonly IArquivoService _arquivoService;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEventAggregator _eventAggregator;

        #endregion

        #region Construtor

        public ProdutoEditPresenter(
            IProdutoEditView view,
            IDialogService dialogService,
            IArquivoService arquivoService,
            IProdutoRepository produtoRepository,
            IEventAggregator eventAggregator
        ) : base(view)
        {
            _dialogService = dialogService;
            _arquivoService = arquivoService;
            _produtoRepository = produtoRepository;
            _eventAggregator = eventAggregator;

            ConfiguraView();
            PropertyChanged += PresenterPropertyChanged;
        }

        #endregion

        #region Propriedades

        private int _quantidade;
        public int Quantidade
        {
            get => _quantidade;
            set
            {
                if (SetProperty(ref _quantidade, value))
                {
                    Wrapper.EstoqueAtual.Quantidade = _quantidade;
                };
            }
        }

        #endregion

        #region Ações

        private void OnCancelar()
        {
            _eventAggregator.Publish(new AtualizarGridProdutosEvent(false));
        }

        private async void OnSalvar()
        {
            if (!Wrapper.IsValid) return;

            View.ExibirProgressoSalvar(true);

            Wrapper.Sincronizado = false;

            var model = Wrapper.Model;
            Resultado resultado;
            if (model.Id == Guid.Empty)
                resultado = await _produtoRepository.IncluirAsync(model);
            else
                resultado = await _produtoRepository.AtualizaAsync(model);

            View.ExibirProgressoSalvar(false);

            if (!resultado.Valido)
            {
                _dialogService.Mensagem(resultado.Mensagem);
                return;
            }

            _eventAggregator.Publish(new AtualizarGridProdutosEvent(true));
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

                View.IncluirImagem(imagem);
            });
        }

        private void OnAlterarImagem(ProdutoImagemWrapper imagemWrapper)
        {
            _dialogService.BuscaCamimhoImagem((path => {
                SetImagemPorPath(path, imagemWrapper);
                View.SetImagemPreview(imagemWrapper.Dados);
            }));
        }

        private void OnExcluirImagem(ProdutoImagemWrapper imagem)
        {
            _dialogService.Confirmacao($"Excluir imagem nª {imagem.Ordem}?", () =>
            {
                View.ExcluirImage(imagem);
                var indice = (Wrapper.Imagens.Count > 0) ? 0 : -1;
                View.SelecionaImagemGrid(indice);
                Wrapper.ReordenarImagens();
            });
        }

        private void OnIncluirEspecificacao()
        {
            var espe = new ProdutoEspecificacaoWrapper(new ProdutoEspecificacao
            {
                Ordem = Wrapper.GeraProximoOrdemEspecificacao() 
            });

            View.IncluirEspecificacao(espe);
        }

        private void OnExcluirEspecificacao(ProdutoEspecificacaoWrapper esp)
        {
            _dialogService.Confirmacao($"Excluir especificação nº {esp.Ordem}?", () =>
            {
                View.ExcluirEspecificacao(esp);
                Wrapper.ReordenarEspecificacoes();
            });
        }

        #endregion

        #region Métodos

        private void ConfiguraView()
        {
            ConfiguraAcoesImagem();
            ConfiguraAcoesEspecificacao();
            View.SalvarAction = OnSalvar;
            View.CancelarAction = OnCancelar;
            View.ConfiguraProdutoBindings(this);
        }

        private void ConfiguraAcoesEspecificacao()
        {
            View.IncluirEspecificacaoAction = OnIncluirEspecificacao;
            View.ExcluirEspecificacaoAction = OnExcluirEspecificacao;
        }

        private void ConfiguraAcoesImagem()
        {
            View.IncluirImagemAction = OnIncluirImagem;
            View.AlterarImagemAction = OnAlterarImagem;
            View.ExcluirImagemAction = OnExcluirImagem;
        }

        public void IncluirProduto()
        {
            Wrapper = new ProdutoWrapper(new Produto
            {
                DataCadastro = DateTime.Now,
                EstoqueAtual = new ProdutoEstoque()
            });

            PreparaCamposParaEdicao();
        }

        private void PreparaCamposParaEdicao()
        {
            Wrapper.PropertyChanged -= PresenterPropertyChanged;
            Wrapper.PropertyChanged += PresenterPropertyChanged;
            Wrapper.Imagens.CollectionChanged += CollectionChanged;
            Wrapper.Especificacoes.CollectionChanged += CollectionChanged;

            View.SelecionarPrimeiroCampoEdicao();
            View.InicializaBinding(Wrapper);
            Quantidade = Wrapper.EstoqueAtual.Quantidade;
            ValidaModel();
            View.FocoPrincipal();
        }

        internal async Task<bool> Alterar(Guid id)
        {
            var resultado = await _produtoRepository.LocalizaPorChavePrimariaAsync(id) ;
            if (resultado.Valido)
            {
                Wrapper = new ProdutoWrapper(resultado.Valor);
                PreparaCamposParaEdicao();
            }
            else
            {
                _dialogService.Mensagem(resultado.Mensagem);
            }
            return resultado.Valido;
        }

        private void VerificaErros(System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (PropriedadeEhValida(e))
            {
                var erros = Wrapper.GetErrors(e.PropertyName).Cast<string>();
                var mensagemErro = string.Empty;
                if ((erros.Count() > 0))
                {
                    mensagemErro = erros.First();
                }
                View.SetMensagenErro(e.PropertyName, mensagemErro);
            }
            ValidaModel();
        }

        private void ValidaModel()
        {
            var valido = (Wrapper.IsChanged || Wrapper.EstoqueAtual.IsChanged)
                && Wrapper.IsValid;

            View.HabiltaBotaoSalvar(valido);
        }

        private bool PropriedadeEhValida(System.ComponentModel.PropertyChangedEventArgs e)
        {
            return !(e.PropertyName.Contains(nameof(Wrapper.IsChanged)) ||
                     e.PropertyName.Contains(nameof(Wrapper.IsValid)));
        }

        private void SetImagemPorPath(string path, ProdutoImagemWrapper imagem)
        {
            imagem.Sufixo = ArquivoHelper.GetExtensaoArquivo(path);
            imagem.Dados = _arquivoService.GetImagemBase64(path);
        }

        #endregion

        #region Handlers

        private void PresenterPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            VerificaErros(e);
        }

        private void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ValidaModel();
        }

        #endregion
    }
}
