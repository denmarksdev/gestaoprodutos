using System;
using System.Windows.Forms;

namespace GPApp.WinForms.Componentes
{
    public partial class Expander : UserControl
    {
        public bool Toogle { get; set; }
        public int  Altura  { get; set; }

        public Expander()
        {
            InitializeComponent();

            Altura = Height;
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            Toogle = !Toogle;
            Height = Toogle ?  panelHeader.Height : Altura;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Altura = Height;
        }
    }
}