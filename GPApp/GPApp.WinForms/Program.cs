using GPApp.WinForms.PontoPartida;
using MaterialSkin;
using System;

namespace GPApp.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MaterialSkinManager
                .Instance
                .ColorScheme = new ColorScheme(
                    Primary.BlueGrey800,
                    Primary.BlueGrey900,
                    Primary.BlueGrey500,
                    Accent.LightBlue200,
                    TextShade.WHITE);

        new Bootstrapper(IOCContainer.GetContainer())
                 .Start();
        }
    }
}