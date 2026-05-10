namespace GraPuzzle;

// Logika wejścia do piwnicy
public partial class piwnica_wejscie : ContentPage
{
    // Konstruktor strony
    public piwnica_wejscie()
    {
        InitializeComponent();
    }

    // Strzałka w lewo – przejście do pokoju dziecięcego
    private async void OnLeftArrowClicked3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new dzieckopokoj());
    }

    // Strzałka w prawo – przejście do sypialni
    private async void OnRightArrowClicked3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sypialnia());
    }

    // Otwarcie ekwipunku
    private async void OnInventoryClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new InventoryPage());
    }

    // Kliknięcie ukrytego obiektu – wejście do podziemi
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new piwnicaziemia());
    }
}
