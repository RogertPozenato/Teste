using System.Collections.ObjectModel;

namespace Teste;

public partial class Sreservas : ContentPage
{
    public ObservableCollection<dynamic> Reservas { get; set; }

    public Sreservas()
    {
        InitializeComponent();

        Reservas = new ObservableCollection<dynamic>
        {
            new {
                Nome = "Juan Carlos Silva",
                Dia = "13/09/2025",
                Horario = "13:00",
                Pessoas = "3",
                Detalhes = "2 de 12 anos e mais\n1 de 6 a 12 anos",
                Cafe = "Café da manhã básico",
                Valor = "R$ 137,50"
            },
            new {
                Nome = "Juan Carlos Silva",
                Dia = "21/09/2025",
                Horario = "13:00",
                Pessoas = "3",
                Detalhes = "2 de 12 anos e mais\n1 de 6 a 12 anos",
                Cafe = "Café da manhã básico",
                Valor = "R$ 137,50"
            }
        };

        BindingContext = this;
    }

    private async void OnCancelarClicked(object sender, EventArgs e)
    {
        var reserva = (sender as Button)?.BindingContext;

        if (reserva != null)
        {
            bool confirm = await DisplayAlert("Cancelar Reserva", "Deseja cancelar esta reserva?", "Sim", "Não");
            if (confirm)
            {
                Reservas.Remove(reserva);
            }
        }
    }

    private async void VoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}