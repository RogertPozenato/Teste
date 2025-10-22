
namespace Teste;

public partial class Reserva : ContentPage
{
    int valor1 = 0;
    int valor2 = 0;
    int valor3 = 0;

    public Reserva()
    {
        InitializeComponent();

        // Adiciona eventos para atualizar o valor total
        Morango.CheckedChanged += OnItemCheckedChanged;
        TC.CheckedChanged += OnItemCheckedChanged;
        CafeCompleto.CheckedChanged += OnItemCheckedChanged;
        CafeBasico.CheckedChanged += OnItemCheckedChanged;

        UpdateTotal();

        AtualizarValores();
    }

    private void OnItemCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        UpdateTotal();
    }

    private void UpdateTotal()
    {
        double total = 0;

        if (Morango.IsChecked)
            total += 45.00;

        if (TC.IsChecked)
            total += 15.00;

        if (CafeCompleto.IsChecked)
            total += 65.00;

        if (CafeBasico.IsChecked)
            total += 55.00;

        lblTotal.Text = $"VALOR TOTAL: R$ {total:F2}";
    }



    private async void OnFazerReservaClicked(object sender, EventArgs e)
    {

        if (!Morango.IsChecked && !TC.IsChecked && !CafeCompleto.IsChecked && !CafeBasico.IsChecked)
        {

        }
        else
        {
            // Aqui você pode salvar os dados ou enviar para um backend
            await DisplayAlert("Reserva", "Pedido concluído com sucesso!", "OK");
        }

        bool irParaProximaPagina = true;

        if (irParaProximaPagina && !Morango.IsChecked && !TC.IsChecked && !CafeCompleto.IsChecked && !CafeBasico.IsChecked)
        {
            await DisplayAlert("Erro", "Você precisa selecionar pelo menos uma opção para fazer a reserva.", "OK");

        }
        else
        {
            await Navigation.PushAsync(new Pagamento()); // vai para a próxima página
        }
    }
    



    void OnMinusTapped1(object sender, EventArgs e)
    {
        if (valor1 > 0)
        {
            valor1--;
            AtualizarValores();
        }
    }

    void OnPlusTapped1(object sender, EventArgs e)
    {
        if (valor1 < 999999999)
        {
            valor1++;
            AtualizarValores();
        }
    }

    void OnMinusTapped2(object sender, EventArgs e)
    {
        if (valor2 > 0)
        {
            valor2--;
            AtualizarValores();
        }
    }

    void OnPlusTapped2(object sender, EventArgs e)
    {
        if (valor2 < 999999999)
        {
            valor2++;
            AtualizarValores();
        }
    }

    void OnMinusTapped3(object sender, EventArgs e)
    {
        if (valor3 > 0)
        {
            valor3--;
            AtualizarValores();
        }
    }

    void OnPlusTapped3(object sender, EventArgs e)
    {
        if (valor3 < 999999999)
        {
            valor3++;
            AtualizarValores();
        }
    }

    void AtualizarValores()
    {
        ZeroCinco.Text = valor1.ToString();
        SeisDoze.Text = valor2.ToString();
        Adulto.Text = valor3.ToString();
    }
}
