namespace GraPuzzle
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnPlayClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Puzzle1());
        }
        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}
