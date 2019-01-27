using System;
using System.Windows.Forms;

namespace GPApp.WinForms.Componentes
{
    public partial class TabControlCustom : TabControl
    {
        private const int TCM_ADJUSTRECT = 0x1328;

        public TabControlCustom()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == TCM_ADJUSTRECT && !DesignMode)
            {
                m.Result = (IntPtr)1;
                return;
            }

            // call the base class implementation
            base.WndProc(ref m);
        }
    }
}