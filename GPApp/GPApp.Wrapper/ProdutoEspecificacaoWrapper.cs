using GPApp.Model;
using GPApp.Wrapper.Base;

namespace GPApp.Wrapper
{
    public partial class ProdutoEspecificacaoWrapper:ModelWrapper<ProdutoEspecificacao>
	{
		 public ProdutoEspecificacaoWrapper(ProdutoEspecificacao model): base(model)
		 {
		 }
		 						
		public System.String Nome
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool NomeIsChanged => GetIsChanged(nameof(Nome));
		public  System.String NomeOriginalValue => GetOriginalValue< System.String>(nameof(Nome));

								
		public System.String Descricao
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool DescricaoIsChanged => GetIsChanged(nameof(Descricao));
		public  System.String DescricaoOriginalValue => GetOriginalValue< System.String>(nameof(Descricao));

								
		public System.Guid ProdutoId
		{
			get { return GetValue<System.Guid>(); }
			set { SetValue(value); }
		}
		public bool ProdutoIdIsChanged => GetIsChanged(nameof(ProdutoId));
		public  System.Guid ProdutoIdOriginalValue => GetOriginalValue< System.Guid>(nameof(ProdutoId));

								
		public System.Int16 Ordem
		{
			get { return GetValue<System.Int16>(); }
			set { SetValue(value); }
		}
		public bool OrdemIsChanged => GetIsChanged(nameof(Ordem));
		public  System.Int16 OrdemOriginalValue => GetOriginalValue< System.Int16>(nameof(Ordem));

								
		public System.Guid Id
		{
			get { return GetValue<System.Guid>(); }
			set { SetValue(value); }
		}
		public bool IdIsChanged => GetIsChanged(nameof(Id));
		public  System.Guid IdOriginalValue => GetOriginalValue< System.Guid>(nameof(Id));

								
		public System.Boolean Sincronizado
		{
			get { return GetValue<System.Boolean>(); }
			set { SetValue(value); }
		}
		public bool SincronizadoIsChanged => GetIsChanged(nameof(Sincronizado));
		public  System.Boolean SincronizadoOriginalValue => GetOriginalValue< System.Boolean>(nameof(Sincronizado));

								
		public System.DateTimeOffset UltimaAtualizacao
		{
			get { return GetValue<System.DateTimeOffset>(); }
			set { SetValue(value); }
		}
		public bool UltimaAtualizacaoIsChanged => GetIsChanged(nameof(UltimaAtualizacao));
		public  System.DateTimeOffset UltimaAtualizacaoOriginalValue => GetOriginalValue< System.DateTimeOffset>(nameof(UltimaAtualizacao));

			
	}
}
