using GPApp.Model.Lookups;
using GPApp.Wrapper.Base;

namespace GPApp.Wrapper
{
    public partial class ProdutoLookupWrapper:ModelWrapper<ProdutoLookup>
	{
		 public ProdutoLookupWrapper(ProdutoLookup model): base(model)
		 {
		 }
		 						
		public System.Guid Id
		{
			get { return GetValue<System.Guid>(); }
			set { SetValue(value); }
		}
		public bool IdIsChanged => GetIsChanged(nameof(Id));
		public  System.Guid IdOriginalValue => GetOriginalValue< System.Guid>(nameof(Id));

								
		public System.String Codigo
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool CodigoIsChanged => GetIsChanged(nameof(Codigo));
		public  System.String CodigoOriginalValue => GetOriginalValue< System.String>(nameof(Codigo));

								
		public System.String Nome
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool NomeIsChanged => GetIsChanged(nameof(Nome));
		public  System.String NomeOriginalValue => GetOriginalValue< System.String>(nameof(Nome));

								
		public System.Decimal Preco
		{
			get { return GetValue<System.Decimal>(); }
			set { SetValue(value); }
		}
		public bool PrecoIsChanged => GetIsChanged(nameof(Preco));
		public  System.Decimal PrecoOriginalValue => GetOriginalValue< System.Decimal>(nameof(Preco));

								
		public System.DateTime DataCadastro
		{
			get { return GetValue<System.DateTime>(); }
			set { SetValue(value); }
		}
		public bool DataCadastroIsChanged => GetIsChanged(nameof(DataCadastro));
		public  System.DateTime DataCadastroOriginalValue => GetOriginalValue< System.DateTime>(nameof(DataCadastro));

								
		public System.Int32 Estoque
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
		public bool EstoqueIsChanged => GetIsChanged(nameof(Estoque));
		public  System.Int32 EstoqueOriginalValue => GetOriginalValue< System.Int32>(nameof(Estoque));

			
	}
}
