namespace Teste;

public partial class CadAgência : ContentPage
{
	public CadAgência()
	{
		InitializeComponent();
	}

    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
        // Verifica se todos os campos estão preenchidos
        if (string.IsNullOrWhiteSpace(NomeEntry.Text) ||
            string.IsNullOrWhiteSpace(TelefoneEntry.Text) ||
            string.IsNullOrWhiteSpace(EmailEntry.Text) ||
            string.IsNullOrWhiteSpace(CnpjEntry.Text) ||
            string.IsNullOrWhiteSpace(SenhaEntry.Text))
        {
            await DisplayAlert("Erro", "Preencha todos os campos antes de continuar.", "OK");
            return;
        }

        // Aqui você pode adicionar validações extras (e-mail válido, CNPJ válido, etc.)
        // Exemplo simples para e-mail:
        if (!EmailEntry.Text.Contains("@"))
        {
            await DisplayAlert("Erro", "E-mail inválido.", "OK");
            return;
        }
        else
        {
            // Se tudo estiver certo:
            await DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "OK");
            await Navigation.PushAsync(new OpcoesAgencia()); // vai para a próxima página
        }
        
    }
    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}