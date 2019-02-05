using System;
using System.Linq;
using GPApp.Model;
using GPApp.Wrapper.Base;
using GPApp.Shared.Extensions;

namespace GPApp.Wrapper
{
    public partial class ProdutoWrapper : ModelWrapper<Produto>
    {
        public ProdutoWrapper(Produto model) : base(model)
        {
        }

        public System.String Codigo
        {
            get { return GetValue<System.String>(); }
            set { SetValue(value); }
        }
        public bool CodigoIsChanged => GetIsChanged(nameof(Codigo));
        public System.String CodigoOriginalValue => GetOriginalValue<System.String>(nameof(Codigo));


        public System.String Nome
        {
            get { return GetValue<System.String>(); }
            set { SetValue(value); }
        }
        public bool NomeIsChanged => GetIsChanged(nameof(Nome));
        public System.String NomeOriginalValue => GetOriginalValue<System.String>(nameof(Nome));


        public System.String Descricao
        {
            get { return GetValue<System.String>(); }
            set { SetValue(value); }
        }
        public bool DescricaoIsChanged => GetIsChanged(nameof(Descricao));
        public System.String DescricaoOriginalValue => GetOriginalValue<System.String>(nameof(Descricao));


        public System.Decimal Preco
        {
            get { return GetValue<System.Decimal>(); }
            set {
               if(SetValue(value))
                {
                    OnPropertyChanged(nameof(Custo));
                    OnPropertyChanged(nameof(PrecoPromocional));
                }
            } 

        }
        public bool PrecoIsChanged => GetIsChanged(nameof(Preco));
        public System.Decimal PrecoOriginalValue => GetOriginalValue<System.Decimal>(nameof(Preco));


        public System.Decimal PrecoPromocional
        {
            get { return GetValue<System.Decimal>(); }
            set {
               if (SetValue(value))
                {
                    OnPropertyChanged(nameof(Custo));
                    OnPropertyChanged(nameof(Preco));
                }
            }
        }
        public bool PrecoPromocionalIsChanged => GetIsChanged(nameof(PrecoPromocional));
        public System.Decimal PrecoPromocionalOriginalValue => GetOriginalValue<System.Decimal>(nameof(PrecoPromocional));


        public System.Decimal Custo
        {
            get { return GetValue<System.Decimal>(); }
            set {
               if ( SetValue(value))
                {
                    OnPropertyChanged(nameof(Preco));
                    OnPropertyChanged(nameof(PrecoPromocional));
                }
            }
        }
        public bool CustoIsChanged => GetIsChanged(nameof(Custo));
        public System.Decimal CustoOriginalValue => GetOriginalValue<System.Decimal>(nameof(Custo));


        public System.DateTimeOffset DataCadastro
        {
            get { return GetValue<System.DateTimeOffset>(); }
            set { SetValue(value); }
        }
        public bool DataCadastroIsChanged => GetIsChanged(nameof(DataCadastro));
        public System.DateTimeOffset DataCadastroOriginalValue => GetOriginalValue<System.DateTimeOffset>(nameof(DataCadastro));


        public System.Guid Id
        {
            get { return GetValue<System.Guid>(); }
            set { SetValue(value); }
        }
        public bool IdIsChanged => GetIsChanged(nameof(Id));
        public System.Guid IdOriginalValue => GetOriginalValue<System.Guid>(nameof(Id));


        public System.Boolean Sincronizado
        {
            get { return GetValue<System.Boolean>(); }
            set { SetValue(value); }
        }
        public bool SincronizadoIsChanged => GetIsChanged(nameof(Sincronizado));
        public System.Boolean SincronizadoOriginalValue => GetOriginalValue<System.Boolean>(nameof(Sincronizado));


        public System.DateTimeOffset UltimaAtualizacao
        {
            get { return GetValue<System.DateTimeOffset>(); }
            set { SetValue(value); }
        }
        public bool UltimaAtualizacaoIsChanged => GetIsChanged(nameof(UltimaAtualizacao));
        public System.DateTimeOffset UltimaAtualizacaoOriginalValue => GetOriginalValue<System.DateTimeOffset>(nameof(UltimaAtualizacao));

        public ProdutoEstoqueWrapper EstoqueAtual { get; private set; }

        public ChangeTrackingCollection<ProdutoImagemWrapper> Imagens { get; private set; }

        public ChangeTrackingCollection<ProdutoEspecificacaoWrapper> Especificacoes { get; private set; }

        public ChangeTrackingCollection<ProdutoEstoqueWrapper> PosicoesEstoque { get; private set; }


        protected override void InitializeComplexProperties(Produto model)
        {
            if (model.EstoqueAtual == null) throw new ArgumentNullException("EstoqueAtual ser nulo");

            EstoqueAtual = new ProdutoEstoqueWrapper(model.EstoqueAtual);
            RegisterComplex(EstoqueAtual);
        }
               
        protected override void InitializeCollentionProperties(Produto model)
        {
            if (model.Imagens == null) throw new ArgumentNullException("Imagens não pode ser nulo");

            Imagens = new ChangeTrackingCollection<ProdutoImagemWrapper>(model.Imagens.Select(e => new ProdutoImagemWrapper(e)));
            RegisterCollection(Imagens, model.Imagens);

            if (model.Especificacoes == null) throw new ArgumentNullException("Especificacoes não pode ser nulo");

            Especificacoes = new ChangeTrackingCollection<ProdutoEspecificacaoWrapper>(model.Especificacoes.Select(e => new ProdutoEspecificacaoWrapper(e)));
            RegisterCollection(Especificacoes, model.Especificacoes);

            if (model.PosicoesEstoque == null) throw new ArgumentNullException("PosicoesEstoque não pode ser nulo");

            PosicoesEstoque = new ChangeTrackingCollection<ProdutoEstoqueWrapper>(model.PosicoesEstoque.Select(e => new ProdutoEstoqueWrapper(e)));
            RegisterCollection(PosicoesEstoque, model.PosicoesEstoque);
        }

        public static ProdutoWrapper Empty = new ProdutoWrapper(new Produto
        {
            EstoqueAtual = new ProdutoEstoque()
        });

        public short GeraProximoOrdemImagem()
        {
            short ordem = Convert.ToInt16(
                Imagens.Count == 0
                ? 1
                : Imagens.Max(i => i.Ordem) + 1);

            return ordem;
        }

        public short GeraProximoOrdemEspecificacao()
        {
            short ordem = Convert.ToInt16(
                Especificacoes.Count == 0
                ? 1
                : Especificacoes.Max(i => i.Ordem) + 1);

            return ordem;
        }

        public void ReordenarImagens()
        {
            for (int i = 0; i < Imagens.Count; i++)
            {
                Imagens[i].Ordem = (i + 1).ToShort();
            }
        }

        public void ReordenarEspecificacoes()
        {
            for (int i = 0; i < Especificacoes.Count; i++)
            {
                Especificacoes[i].Ordem =  (i + 1).ToShort();
            }
        }
    }
}