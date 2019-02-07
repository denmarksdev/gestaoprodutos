using GPApp.Model;
using GPApp.Shared.Helpers;
using GPApp.Wrapper;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using System;
using System.Threading.Tasks;

namespace GPApp.Uwp.Logica.Model
{
    public class ProdutoImageUWPWrapper : ProdutoImagemWrapper
    {
        public ProdutoImageUWPWrapper(ProdutoImagem model) : base(model)
        {
        }

        public async Task<bool> InitImage() {

            if (string.IsNullOrWhiteSpace(Dados)) return false;

            var bytes = ImagemHelper.Base64ToBytes(Dados);

            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(bytes);
                    await writer.StoreAsync();
                }
                var image = new BitmapImage();
                await image.SetSourceAsync(stream);
                Image = image;
            }
            return true;
        }

        private BitmapImage _image;
        public BitmapImage Image
        {
            get { return _image; }
            set
            {
                if (value != _image)
                {
                    _image = value;
                    OnPropertyChanged(nameof(Image));
                }
            }
        }
    }
}
