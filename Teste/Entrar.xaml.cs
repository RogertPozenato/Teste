
namespace Teste;

public partial class Entrar : ContentPage
{
	public Entrar()
	{
		InitializeComponent();
	}

    private async void D_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewPage2());
    }
    private async void C_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}