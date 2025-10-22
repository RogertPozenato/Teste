namespace Teste
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}

        //private void Aula1_Clicked(object sender, EventArgs e)
        //{
        //    Recebe.Text = Entrada.Text;
        //}

        private async void OnAbrirCalendarioClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPage1());
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new Entrar());
        }
        private async void Button_Agência(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadAgência());
        }
    }
}