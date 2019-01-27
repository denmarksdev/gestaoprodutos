using GPApp.Model;
using GPApp.Wrapper.Base;

namespace GPApp.Wrapper
{
    public partial class ProdutoEspecificacaoWrapper : ModelWrapper<ProdutoEspecificacao>
    {
        public ProdutoEspecificacaoWrapper(ProdutoEspecificacao model) : base(model)
        {
        }

        public string Nome
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public bool NomeIsChanged => GetIsChanged(nameof(Nome));
        public string NomeOriginalValue => GetOriginalValue<string>(nameof(Nome));


        public string Descricao
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public bool DescricaoIsChanged => GetIsChanged(nameof(Descricao));
        public string DescricaoOriginalValue => GetOriginalValue<string>(nameof(Descricao));


        public System.Guid ProdutoId
        {
            get { return GetValue<System.Guid>(); }
            set { SetValue(value); }
        }
        public bool ProdutoIdIsChanged => GetIsChanged(nameof(ProdutoId));
        public System.Guid ProdutoIdOriginalValue => GetOriginalValue<System.Guid>(nameof(ProdutoId));


        public System.Int16 Ordem
        {
            get { return GetValue<System.Int16>(); }
            set { SetValue(value); }
        }
        public bool OrdemIsChanged => GetIsChanged(nameof(Ordem));
        public short OrdemOriginalValue => GetOriginalValue<System.Int16>(nameof(Ordem));


        public System.Guid Id
        {
            get { return GetValue<System.Guid>(); }
            set { SetValue(value); }
        }
        public bool IdIsChanged => GetIsChanged(nameof(Id));
        public System.Guid IdOriginalValue => GetOriginalValue<System.Guid>(nameof(Id));


        public bool Sincronizado
        {
            get { return GetValue<System.Boolean>(); }
            set { SetValue(value); }
        }
        public bool SincronizadoIsChanged => GetIsChanged(nameof(Sincronizado));
        public bool SincronizadoOriginalValue => GetOriginalValue<bool>(nameof(Sincronizado));


        public System.DateTime UltimaAtualizacao
        {
            get { return GetValue<System.DateTime>(); }
            set { SetValue(value); }
        }
        public bool UltimaAtualizacaoIsChanged => GetIsChanged(nameof(UltimaAtualizacao));
        public System.DateTime UltimaAtualizacaoOriginalValue => GetOriginalValue<System.DateTime>(nameof(UltimaAtualizacao));
    }
}