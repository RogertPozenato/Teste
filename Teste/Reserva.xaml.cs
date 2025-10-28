
using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace Teste;

public partial class Reserva : ContentPage
{
    int valor1 = 0;
    int valor2 = 0;
    int valor3 = 0;

    //Calendário
    DateTime mesAtual;
    Border diaSelecionado;
    Button horaSelecionada;



    public Reserva()
    {
        InitializeComponent();



        // Adiciona eventos para atualizar o valor total
      
        TC.CheckedChanged += OnItemCheckedChanged;
        CafeCompleto.CheckedChanged += OnItemCheckedChanged;
        CafeBasico.CheckedChanged += OnItemCheckedChanged;

        UpdateTotal();

        AtualizarValores();

        //Calendário

        mesAtual = DateTime.Now;
        GerarCalendario(mesAtual);
        GerarHorarios();


    }





    void GerarCalendario(DateTime mes)
    {
        MonthLabel.Text = mes.ToString("MMMM yyyy").ToUpper();
        MostrarSafras(mes.Month);

        CalendarGrid.Children.Clear();
        CalendarGrid.RowDefinitions.Clear();
        CalendarGrid.ColumnDefinitions.Clear();

        for (int i = 0; i < 7; i++)
            CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Auto));

        int diasNoMes = DateTime.DaysInMonth(mes.Year, mes.Month);
        int diaSemanaInicio = (int)new DateTime(mes.Year, mes.Month, 1).DayOfWeek;

        int linha = 0;
        CalendarGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));

        DateTime mesAnterior = mes.AddMonths(-1);
        int diasMesAnterior = DateTime.DaysInMonth(mesAnterior.Year, mesAnterior.Month);
        for (int i = diaSemanaInicio - 1; i >= 0; i--)
        {
            AdicionarDia(diasMesAnterior - i, linha, diaSemanaInicio - 1 - i, Colors.Brown, false);
        }

        for (int dia = 1; dia <= diasNoMes; dia++)
        {
            int coluna = (diaSemanaInicio + dia - 1) % 7;
            if (coluna == 0 && dia != 1)
            {
                linha++;
                CalendarGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
            }

            Color cor = Colors.White;
            AdicionarDia(dia, linha, coluna, cor, true);
        }

        int diasExtras = 7 - ((diaSemanaInicio + diasNoMes) % 7);
        if (diasExtras < 7)
        {
            for (int i = 1; i <= diasExtras; i++)
            {
                AdicionarDia(i, linha, (diaSemanaInicio + diasNoMes + i - 1) % 7, Colors.Brown, false);
            }
        }
    }

    void AdicionarDia(int numero, int linha, int coluna, Color cor, bool clicavel)
    {
        var border = new Border
        {
            BackgroundColor = cor,
            StrokeShape = new RoundRectangle { CornerRadius = 50 },
            WidthRequest = 40,
            HeightRequest = 40,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        var label = new Label
        {
            Text = numero.ToString(),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            TextColor = Colors.Black
        };

        border.Content = label;

        if (clicavel)
        {
            var tap = new TapGestureRecognizer();
            tap.Tapped += (s, e) =>
            {
                if (diaSelecionado != null)
                    diaSelecionado.BackgroundColor = Colors.White;

                diaSelecionado = border;
                diaSelecionado.BackgroundColor = Color.FromArgb("#F4A460"); // Laranja
            };
            border.GestureRecognizers.Add(tap);
        }

        CalendarGrid.Add(border, coluna, linha);
    }

    void GerarHorarios()
    {
        TimeSlotsLayout.Children.Clear();
        string[] horarios = { "8:00", "10:00", "12:00", "13:00", "15:00", "17:00" };

        foreach (var h in horarios)
        {
            var btn = new Button
            {
                Text = h,
                BackgroundColor = Colors.White,
                TextColor = Colors.Black
            };

            btn.Clicked += (s, e) =>
            {
                if (horaSelecionada != null)
                    horaSelecionada.BackgroundColor = Colors.White;

                horaSelecionada = btn;
                horaSelecionada.BackgroundColor = Color.FromArgb("#F4A460"); // Laranja
            };

            TimeSlotsLayout.Children.Add(btn);
        }
    }

    void MostrarSafras(int mes)
    {
        string safra = mes switch
        {
            1 => "Uva, Goiaba, Morango, Lichia",
            2 => "Uva, Goiaba, Morango",
            3 => "Uva, Goiaba",
            4 => "Goiaba, Morango",
            5 => "Uva, Goiaba, Morango",
            6 => "Uva, Goiaba, Morango",
            7 => "Uva, Goiaba, Morango",
            8 => "Morango",
            9 => "Morango",
            10 => "Pêssego, Morango, Goiaba",
            11 => "Pêssego, Morango, Goiaba",
            12 => "Uva, Goiaba, Morango, Lichia",
            _ => ""
        };

        SafraLabel.Text = $"Safras do mês: {safra}";
    }

    void Anterior_Clicked(object sender, EventArgs e)
    {
        mesAtual = mesAtual.AddMonths(-1);
        GerarCalendario(mesAtual);
    }

    void Proximo_Clicked(object sender, EventArgs e)
    {
        mesAtual = mesAtual.AddMonths(1);
        GerarCalendario(mesAtual);
    }








    private void OnItemCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        UpdateTotal();
    }

    private void UpdateTotal()
    {
        double total = 0;

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

        if (!TC.IsChecked && !CafeCompleto.IsChecked && !CafeBasico.IsChecked)
        {

        }
        else
        {
            // Aqui você pode salvar os dados ou enviar para um backend
            await DisplayAlert("Reserva", "Pedido concluído com sucesso!", "OK");
        }

        bool irParaProximaPagina = true;

        if (irParaProximaPagina && !TC.IsChecked && !CafeCompleto.IsChecked && !CafeBasico.IsChecked)
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
