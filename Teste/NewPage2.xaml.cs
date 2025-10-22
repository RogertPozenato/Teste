namespace Teste;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sreservas());
    }

    private async void Button_Clicked1(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new Reserva());
    }
}