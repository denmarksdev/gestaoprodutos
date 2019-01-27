using GPApp.Model;
using GPApp.Wrapper.Base;

namespace GPApp.Wrapper
{
    public partial class ProdutoImagemWrapper:ModelWrapper<ProdutoImagem>
	{
		 public ProdutoImagemWrapper(ProdutoImagem model): base(model)
		 {
		 }
		 						
		public System.String Prefixo
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool PrefixoIsChanged => GetIsChanged(nameof(Prefixo));
		public  System.String PrefixoOriginalValue => GetOriginalValue< System.String>(nameof(Prefixo));

								
		public System.String Sufixo
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool SufixoIsChanged => GetIsChanged(nameof(Sufixo));
		public  System.String SufixoOriginalValue => GetOriginalValue< System.String>(nameof(Sufixo));

								
		public System.String Dados
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool DadosIsChanged => GetIsChanged(nameof(Dados));
		public  System.String DadosOriginalValue => GetOriginalValue< System.String>(nameof(Dados));

								
		public System.String Preview
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool PreviewIsChanged => GetIsChanged(nameof(Preview));
		public  System.String PreviewOriginalValue => GetOriginalValue< System.String>(nameof(Preview));

								
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
