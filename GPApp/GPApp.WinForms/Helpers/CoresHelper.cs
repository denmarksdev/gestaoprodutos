using MetroFramework.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace GPApp.WinForms.Helpers
{
    public static class CoresHelper
    {

        public static readonly Color Primaria = ColorTranslator.FromHtml(Shared.Helpers.CoresHelper.Primaria);
        public static readonly Color Selecao = ColorTranslator.FromHtml(Shared.Helpers.CoresHelper.Selecao);
        public static readonly Color Secundaria = ColorTranslator.FromHtml(Shared.Helpers.CoresHelper.Secundaria);

        public static void ConfiguraBotaoConfirmacao(MetroButton button)
        {
            button.ForeColor = Selecao;
            button.BackColor = Primaria;
            button.Cursor = Cursors.Hand;
            button.UseCustomBackColor = true;
            button.UseCustomForeColor = true;
            button.UseVisualStyleBackColor = false;
        }

        public static void ConfiguraBotaoSecundario(MetroButton button)
        {
            button.ForeColor = Selecao;
            button.BackColor = Secundaria;
            button.Cursor = Cursors.Hand;
            button.UseCustomBackColor = true;
            button.UseCustomForeColor = true;
            button.UseVisualStyleBackColor = false;
        }
    }
}
