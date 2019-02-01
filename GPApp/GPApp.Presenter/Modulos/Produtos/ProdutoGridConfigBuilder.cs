using GPApp.Model.Lookups;
using GPApp.Presenter.Grid;
using GPApp.Repository;
using GPApp.Shared.Paginacao;
using GPApp.Wrapper;

namespace GPApp.Presenter.Modulos.Produtos
{
    public static class ProdutoGridConfigBuilder
    {
        public static GridConfig<ProdutoLookupWrapper> Instancia(
            IPaginacaoRepository<ProdutoLookupWrapper> paginacaoRepository )
        {
            var wrapper = new ProdutoLookupWrapper(ProdutoLookup.Empty);

            return new GridInfoBuilder<ProdutoLookupWrapper>(nameof(ProdutoLookupWrapper.Nome))

                .NomeColuna(nameof(ProdutoLookup.Id))
                .Exibir(false)
                .ChavePrimaria()
                .BuildColuna()

                .NomeColuna(nameof(ProdutoLookup.Codigo))
                .TamanhoColuna(90)
                .TituloColuna("Código")
                .TipoColuna(wrapper.Codigo.GetType())
                .Alinhada(TipoAlinhamentoColuna.Direita)
                .BuildColuna()

                .NomeColuna(nameof(ProdutoLookup.Nome))
                .AutoSizeMode(ColunaTipoAjuste.Preencher)
                .TituloColuna(nameof(ProdutoLookup.Nome))
                .TipoColuna(wrapper.Nome.GetType())
                .BuildColuna()

                .NomeColuna(nameof(ProdutoLookup.Preco))
                .TituloColuna("Preço")
                .TipoColuna(wrapper.Nome.GetType())
                .Alinhada(TipoAlinhamentoColuna.Direita)
                .TamanhoColuna(100)
                .BuildColuna()

                .NomeColuna(nameof(ProdutoLookup.Estoque))
                .TituloColuna(nameof(ProdutoLookup.Estoque))
                .Alinhada(TipoAlinhamentoColuna.Direita)
                .TamanhoColuna(100)
                .TipoColuna(wrapper.Estoque.GetType())
                .PermitirOrdenar(false)
                .BuildColuna()

                .NomeColuna(nameof(ProdutoLookup.DataCadastro))
                .TituloColuna("Cadastrado em")
                .TipoColuna(wrapper.DataCadastro.GetType())
                .Alinhada(TipoAlinhamentoColuna.Centro)
                .TamanhoColuna(150)
                .BuildColuna()

                .IncluiColunaAlteracao()

                .Repository(paginacaoRepository)

                .Build();
        }
    }
}