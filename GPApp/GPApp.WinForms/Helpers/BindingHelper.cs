using System.Windows.Forms;

namespace GPApp.WinForms.Helpers
{
    public static class BindingHelper
    {
        public static void Configura(
            Control controle,
            string nomePropriedade,
            object source,
            string propriedadeModel,
            DataSourceUpdateMode mode = DataSourceUpdateMode.OnPropertyChanged,
            string mascara = null
            ) {
            controle.DataBindings.Add(
                nomePropriedade,
                source,
                propriedadeModel,
                false,
                mode,
                null,
                mascara);

        }
    }
}
