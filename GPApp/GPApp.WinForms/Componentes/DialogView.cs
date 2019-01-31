using MaterialSkin;

namespace GPApp.WinForms.Componentes
{
    public partial class DialogView : MaterialSkin.Controls.MaterialForm
    {
        public DialogView(string titulo, string mensagem, bool modoMensagem = false)
        {
            InitializeComponent();
            ConfiguraDesign(titulo);
            ConfiguraMensagens(titulo, mensagem);
            DefineModoDeApresentacao(modoMensagem);
        }

        private void ConfiguraMensagens(string titulo, string mensagem)
        {
            Text = titulo;
            materialLabelMensagem.Text = mensagem;
        }

        private void DefineModoDeApresentacao(bool modoMensagem)
        {
            if (modoMensagem)
            {
                materialRaisedButtonNao.Visible = false;
                materialRaisedButtonSim.Text = "Ok";
            }
        }

        private void ConfiguraDesign(string titulo)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            if (titulo == "Atenção")
                materialSkinManager.ColorScheme = new ColorScheme(
                    Primary.Indigo500, 
                    Primary.Indigo700, 
                    Primary.Indigo100, 
                    Accent.Pink200, 
                    TextShade.WHITE);
            else
                materialSkinManager.ColorScheme = new ColorScheme(
                    Primary.Red500,
                    Primary.Red700,
                    Primary.Red100,
                    Accent.Red200,
                    TextShade.WHITE);

            materialSkinManager.AddFormToManage(this);
        }

        private void MaterialRaisedButtonSim_Click(object sender, System.EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void MaterialRaisedButton1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
