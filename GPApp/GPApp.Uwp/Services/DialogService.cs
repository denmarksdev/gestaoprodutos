using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using GPApp.Shared.Services;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace GPApp.Uwp.Services
{
    public class DialogService : IDialogService
    {
        public async void BuscaCamimhoImagem(Action<string> okAction)
        {
            var inputFile =  await GetFile();
            if (inputFile == null) return;

            okAction?.Invoke(inputFile.Name);
        }

        public async void BuscaCamimhoImagem(Action<string, byte[]> okAction)
        {
            try
            {
                var inputFile = await GetFile();
                if (inputFile == null) return;
                byte[] imagem = null;
                IBuffer buffer = await FileIO.ReadBufferAsync(inputFile);
                imagem = buffer.ToArray();

                okAction?.Invoke(inputFile.Name, imagem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void Confirmacao(string mensagem, Action okAction, string titulo = "Atenção")
        {
            var dialog = new MessageDialog(mensagem,titulo);

            dialog.Commands.Add(new UICommand { Label = "Confirmar", Id = true });
            dialog.Commands.Add(new UICommand { Label = "Canncelar", Id = false });

            var resultado = (IUICommand) await dialog.ShowAsync();
            if ( Convert.ToBoolean(resultado.Id))okAction?.Invoke();
        }

        public async void Mensagem(string mensagem, Action okAction = null, string titulo = "Aviso")
        {
            var dialog = new MessageDialog(mensagem, titulo);
            await dialog.ShowAsync();
            okAction?.Invoke();
        }

        private async Task<StorageFile> GetFile()
        {
            FileOpenPicker fileOpenPicker = new FileOpenPicker
            {
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                ViewMode = PickerViewMode.Thumbnail
            };
            fileOpenPicker.FileTypeFilter.Add(".jpg");
            fileOpenPicker.FileTypeFilter.Add(".jpge");
            fileOpenPicker.FileTypeFilter.Add(".png");
            fileOpenPicker.FileTypeFilter.Add(".gif");

            return await fileOpenPicker.PickSingleFileAsync();
        }
    }
}
