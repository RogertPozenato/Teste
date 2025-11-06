namespace Teste;

public partial class OpcoesAgencia : ContentPage
{
	public OpcoesAgencia()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sreservas());
    }

    private async void Button_Clicked1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReservaAgencia());
    }
}