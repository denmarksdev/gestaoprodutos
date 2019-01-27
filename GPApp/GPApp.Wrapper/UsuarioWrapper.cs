using System;
using GPApp.Model;
using GPApp.Wrapper.Base;

namespace GPApp.Wrapper
{
    public partial class UsuarioWrapper:ModelWrapper<Usuario>
	{
		 public UsuarioWrapper(Usuario model): base(model)
		 {
		 }
		 						
		public string Nome
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool NomeIsChanged => GetIsChanged(nameof(Nome));
		public string NomeOriginalValue => GetOriginalValue<string>(nameof(Nome));

								
		public string Senha
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool SenhaIsChanged => GetIsChanged(nameof(Senha));
		public string SenhaOriginalValue => GetOriginalValue<string>(nameof(Senha));

								
		public string Email
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool EmailIsChanged => GetIsChanged(nameof(Email));
		public string EmailOriginalValue => GetOriginalValue<string>(nameof(Email));

								
		public string Celular
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool CelularIsChanged => GetIsChanged(nameof(Celular));
		public  System.String CelularOriginalValue => GetOriginalValue<string>(nameof(Celular));

								
		public System.Guid Id
		{
			get { return GetValue<System.Guid>(); }
			set { SetValue(value); }
		}
		public bool IdIsChanged => GetIsChanged(nameof(Id));
		public Guid IdOriginalValue => GetOriginalValue<Guid>(nameof(Id));

								
		public bool Sincronizado
		{
			get { return GetValue<System.Boolean>(); }
			set { SetValue(value); }
		}
		public bool SincronizadoIsChanged => GetIsChanged(nameof(Sincronizado));
		public bool SincronizadoOriginalValue => GetOriginalValue< System.Boolean>(nameof(Sincronizado));

								
		public DateTime UltimaAtualizacao
		{
			get { return GetValue<System.DateTime>(); }
			set { SetValue(value); }
		}
		public bool UltimaAtualizacaoIsChanged => GetIsChanged(nameof(UltimaAtualizacao));
		public DateTime UltimaAtualizacaoOriginalValue => GetOriginalValue<DateTime>(nameof(UltimaAtualizacao));
	}
}