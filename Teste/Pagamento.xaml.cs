using Microsoft.Maui;

namespace Teste;

public partial class Pagamento : ContentPage
{
	public Pagamento()
	{
		InitializeComponent();
	}

    private async void OnCopyPixClicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(PixEntry.Text);
        await DisplayAlert("Sucesso", "Chave Pix copiada!", "OK");
    }

}