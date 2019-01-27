 using System; 
	 using System.Linq;
	 using GPApp.Model;
	 using GPApp.Wrapper.Base;

namespace GPApp.Wrapper
{
	public partial class ProdutoEstoqueWrapper:ModelWrapper<ProdutoEstoque>
	{
		 public ProdutoEstoqueWrapper(ProdutoEstoque model): base(model)
		 {
		 }
		 						
		public System.Int32 Quantidade
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
		public bool QuantidadeIsChanged => GetIsChanged(nameof(Quantidade));
		public  System.Int32 QuantidadeOriginalValue => GetOriginalValue< System.Int32>(nameof(Quantidade));

								
		public System.Guid ProdutoId
		{
			get { return GetValue<System.Guid>(); }
			set { SetValue(value); }
		}
		public bool ProdutoIdIsChanged => GetIsChanged(nameof(ProdutoId));
		public  System.Guid ProdutoIdOriginalValue => GetOriginalValue< System.Guid>(nameof(ProdutoId));

								
		public System.DateTime Lancamento
		{
			get { return GetValue<System.DateTime>(); }
			set { SetValue(value); }
		}
		public bool LancamentoIsChanged => GetIsChanged(nameof(Lancamento));
		public  System.DateTime LancamentoOriginalValue => GetOriginalValue< System.DateTime>(nameof(Lancamento));

								
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

								
		public System.DateTime UltimaAtualizacao
		{
			get { return GetValue<System.DateTime>(); }
			set { SetValue(value); }
		}
		public bool UltimaAtualizacaoIsChanged => GetIsChanged(nameof(UltimaAtualizacao));
		public  System.DateTime UltimaAtualizacaoOriginalValue => GetOriginalValue< System.DateTime>(nameof(UltimaAtualizacao));

			
	}
}
