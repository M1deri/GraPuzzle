using Plugin.Maui.Audio;

namespace GraPuzzle
{
    // Główna strona aplikacji
    public partial class MainPage : ContentPage
    {
        // Obiekt odpowiedzialny za obsługę dźwięku
        private readonly IAudioManager audioManager;

        // Konstruktor strony
        public MainPage(IAudioManager audioManager)
        {
            // Inicjalizacja komponentów XAML
            InitializeComponent();

            // Przypisanie menedżera audio
            this.audioManager = audioManager;
        }

        // Obsługa kliknięcia przycisku "Play"
        private async void OnPlayClicked(object sender, EventArgs e)
        {
            // Przejście do strony Puzzle1
            await Navigation.PushAsync(new Puzzle1());

            // Kod odtwarzania muzyki (obecnie wyłączony)
            //var player = audioManager.CreatePlayer(
            //    await FileSystem.OpenAppPackageFileAsync(
            //    "7f587cb8-069b-4488-bf3a-c31d9a940272.mp3"));

            //player.Play();
        }

        // Obsługa kliknięcia przycisku ustawień
        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            // Przejście do strony ustawień
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}
