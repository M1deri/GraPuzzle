using Plugin.Maui.Audio;

namespace GraPuzzle
{
    public partial class MainPage : ContentPage
    {
        private readonly IAudioManager audioManager;

        public MainPage(IAudioManager audioManager)
        {
            InitializeComponent();
            this.audioManager = audioManager;
        }
        private async void OnPlayClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Puzzle1());
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("7f587cb8-069b-4488-bf3a-c31d9a940272.mp3"));
            player.Play();
        }
        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}
