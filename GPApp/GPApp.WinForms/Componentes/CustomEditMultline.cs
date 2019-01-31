using MaterialSkin.Controls;
using MetroFramework.Controls;
using System.ComponentModel;
using System.Windows.Forms;

namespace GPApp.WinForms.Componentes
{
    public partial class CustomEditMultline : UserControl
    {
        [Browsable(false)]
        public MaterialLabel Label
        {
            get => materialLabel;
        }

        [Browsable(false)]
        public Label LabelErro
        {
            get => labelErro;
        }

        [Browsable(false)]
        public MetroTextBox Edit
        {
            get => metroTextBox1;
        }

        [Browsable(true)]
        [DefaultValue(true)]
        public string LabelText
        {
            get => materialLabel.Text;
            set => materialLabel.Text = value;
        }

        [Browsable(true)]
        [DefaultValue(true)]
        public string LabelErroText
        {
            get => labelErro.Text;
            set => labelErro.Text = value;
        }

        public CustomEditMultline()
        {
            InitializeComponent();
            Edit.Text = string.Empty;
        }

        
    }
}