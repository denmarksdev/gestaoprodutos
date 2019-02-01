using MaterialSkin.Controls;
using MetroFramework.Controls;
using System.ComponentModel;
using System.Windows.Forms;

namespace GPApp.WinForms.Componentes
{
    public partial class CustomEdit : UserControl
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
            get => metroTextBoxEdit;
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

        [Browsable(true)]
        [DefaultValue(true)]
        public int MaxWidthEdit
        {
            get => metroTextBoxEdit.MaximumSize.Width;
            set => metroTextBoxEdit.MaximumSize = new System.Drawing.Size(value, metroTextBoxEdit.Height); 
        }

        public CustomEdit()
        {
            InitializeComponent();
            Edit.Text = string.Empty;
        }
    }
}