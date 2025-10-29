using System.Collections.ObjectModel;
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
        try
        {
            // Copia o texto da chave Pix para a área de transferência
            await Clipboard.SetTextAsync(PixEntry.Text);

            // Exibe uma mensagem de confirmação
            await DisplayAlert("Sucesso", "Chave Pix copiada para a área de transferência!", "OK");
        }
        catch (Exception ex)
        {
            // Exibe uma mensagem de erro caso algo dê errado
            await DisplayAlert("Erro", $"Não foi possível copiar a chave Pix: {ex.Message}", "OK");
        }
    }

    private async void VerClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OutroSreservas());
    }
}

