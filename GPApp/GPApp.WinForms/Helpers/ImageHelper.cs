using System.Drawing;

namespace GPApp.WinForms.Helpers
{
    public static class ImagemHelper
    {

        public static Image ImagemFromBytes(byte[] bytes)
        {
            using (var ms = new System.IO.MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
