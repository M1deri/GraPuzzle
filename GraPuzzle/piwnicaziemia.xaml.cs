namespace GraPuzzle;

// Logika sceny: piwnica (ziemia / podziemia)
public partial class piwnicaziemia : ContentPage
{
    // Konstruktor strony
    public piwnicaziemia()
    {
        InitializeComponent();
    }

    // Strzałka w lewo (funkcja nieużywana w XAML)
    private async void OnLeftArrowClicked3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new dzieckopokoj());
    }

    // Strzałka w prawo (funkcja nieużywana w XAML)
    private async void OnRightArrowClicked3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sypialnia());
    }

    // Otwarcie ekwipunku
    private async void OnInventoryClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new InventoryPage());
    }

    // Kliknięcie głównego obiektu – przejście do dalszej części piwnicy
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new piwnicaza());
    }

    // Kliknięcie powrotu – przejście do wejścia piwnicy
    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new piwnica_wejscie());
    }
}
