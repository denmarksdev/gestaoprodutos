using GPApp.Model;
using GPApp.Wrapper.Base;

namespace GPApp.Wrapper
{
    public partial class ItemVitrineWrapper:ModelWrapper<ItemVitrine>
	{
		 public ItemVitrineWrapper(ItemVitrine model): base(model)
		 {
		 }
		 						
		public System.Guid Id
		{
			get { return GetValue<System.Guid>(); }
			set { SetValue(value); }
		}
		public bool IdIsChanged => GetIsChanged(nameof(Id));
		public  System.Guid IdOriginalValue => GetOriginalValue< System.Guid>(nameof(Id));

								
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

								
		public System.Decimal PrecoPromocional
		{
			get { return GetValue<System.Decimal>(); }
			set { SetValue(value); }
		}
		public bool PrecoPromocionalIsChanged => GetIsChanged(nameof(PrecoPromocional));
		public  System.Decimal PrecoPromocionalOriginalValue => GetOriginalValue< System.Decimal>(nameof(PrecoPromocional));

								
		public System.String ImagemUrl
		{
			get { return GetValue<System.String>(); }
			set { SetValue(value); }
		}
		public bool ImagemUrlIsChanged => GetIsChanged(nameof(ImagemUrl));
		public  System.String ImagemUrlOriginalValue => GetOriginalValue< System.String>(nameof(ImagemUrl));
	}
}
