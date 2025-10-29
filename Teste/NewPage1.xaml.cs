namespace Teste;


public partial class NewPage1 : ContentPage
{
    public NewPage1()
    {
        InitializeComponent();
    }

    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
        // Verifica se todos os campos estão preenchidos
        if (string.IsNullOrWhiteSpace(NomeEntry.Text) ||
            string.IsNullOrWhiteSpace(TelefoneEntry.Text) ||
            string.IsNullOrWhiteSpace(SenhaEntry.Text))
        {
            await DisplayAlert("Erro", "Preencha todos os campos antes de continuar.", "OK");
            return;
        }

        else
        {
            // Se tudo estiver certo:
            await DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "OK");
            await Navigation.PushAsync(new NewPage2()); // vai para a próxima página
        }

    }
    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}

