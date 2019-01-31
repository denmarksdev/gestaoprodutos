using GPApp.Presenter.Base;
using GPApp.Wrapper;
using System;

namespace GPApp.Presenter.Modulos.Produtos
{
    public interface IProdutoEditView : IView
    {
        Action IncluirImagemAction { get; set; }
        Action<ProdutoImagemWrapper> AlterarImagemAction { get; set; }
        Action<ProdutoImagemWrapper> ExcluirImagemAction { get; set; }

        Action IncluirEspecificacaoAction { get; set; }
        Action<ProdutoEspecificacaoWrapper> ExcluirEspecificacaoAction { get; set; }

        Action SalvarAction { get; set; }  
        Action CancelarAction { get; set; }

        void IncluirImagem(ProdutoImagemWrapper imagemWrapper);
        void ExcluirImage(ProdutoImagemWrapper imagemWrapper);

        void SelecionarPrimeiroCampoEdicao();
        void ConfiguraProdutoBindings(ProdutoEditPresenter presenter);
        void InicializaBinding(ProdutoWrapper wrapper);
        void SetMensagenErro(string propriedade, string mensagem);
        void HabiltaBotaoSalvar(bool habilitar);
        void SetImagemPreview(string base64);
        void SelecionaImagemGrid(int indice);

        void IncluirEspecificacao(ProdutoEspecificacaoWrapper produtoEspecificacaoWrapper);
        void ExcluirEspecificacao(ProdutoEspecificacaoWrapper produtoEspecificacaoWrapper);
        void ExibirProgressoSalvar(bool exibir);
    }
}
