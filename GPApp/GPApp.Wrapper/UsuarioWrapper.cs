using GPApp.Model;
using GPApp.Wrapper.Base;

namespace GPApp.Wrapper
{
    public partial class UsuarioWrapper:ModelWrapper<Usuario>
	{
		 public UsuarioWrapper(Usuario model): base(model)
		 {
		 }
		 						
		public System.String Nome
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool NomeIsChanged => GetIsChanged(nameof(Nome));
		public  System.String NomeOriginalValue => GetOriginalValue< System.String>(nameof(Nome));

								
		public System.String Senha
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool SenhaIsChanged => GetIsChanged(nameof(Senha));
		public  System.String SenhaOriginalValue => GetOriginalValue< System.String>(nameof(Senha));

								
		public System.String Email
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool EmailIsChanged => GetIsChanged(nameof(Email));
		public  System.String EmailOriginalValue => GetOriginalValue< System.String>(nameof(Email));

								
		public System.String Celular
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool CelularIsChanged => GetIsChanged(nameof(Celular));
		public  System.String CelularOriginalValue => GetOriginalValue< System.String>(nameof(Celular));

								
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
