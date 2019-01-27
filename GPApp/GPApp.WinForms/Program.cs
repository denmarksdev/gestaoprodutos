using GPApp.WinForms.PontoPartida;
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
           new Bootstrapper(IOCContainer.GetContainer())
                .Start();
        }
    }
}