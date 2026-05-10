namespace GraPuzzle;

// Logika sceny piwnicy (dalsza część)
public partial class piwnicaza : ContentPage
{
    // Konstruktor strony
    public piwnicaza()
    {
        InitializeComponent();
    }

    // Strzałka w lewo – (funkcja aktualnie niepodłączona w XAML)
    private async void OnLeftArrowClicked3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new dzieckopokoj());
    }

    // Strzałka w prawo – (funkcja aktualnie niepodłączona w XAML)
    private async void OnRightArrowClicked3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sypialnia());
    }

    // Otwarcie ekwipunku
    private async void OnInventoryClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new InventoryPage());
    }

    // Kliknięcie głównego obiektu – przejście do Puzzle1
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Puzzle1());
    }

    // Kliknięcie obiektu (trumna) – zdobycie przedmiotu i informacji
    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await DisplayAlert(
            "Sukces!",
            "Trumna została otwarta.\nKryje się w niej klucz w kształcie czaszki i\nKod 6767",
            "OK");

        // Dodanie klucza do ekwipunku
        Inventory.Add("Skool Key");
    }
}
