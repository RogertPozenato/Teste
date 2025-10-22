namespace Teste;


public partial class NewPage1 : ContentPage
{
    public NewPage1()
    {
        InitializeComponent();
    }

    private async void A_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewPage2());
    }

    private async void B_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}

