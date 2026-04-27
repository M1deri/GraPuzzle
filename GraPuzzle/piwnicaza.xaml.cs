namespace GraPuzzle;

public partial class piwnicaza : ContentPage
{
	public piwnicaza()
	{
		InitializeComponent();
	}
    private async void OnLeftArrowClicked3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new dzieckopokoj());
    }

    private async void OnRightArrowClicked3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sypialnia());
    }
    private async void OnInventoryClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new InventoryPage());
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Puzzle1());
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        DisplayAlert(
            "Sukces!",
            "Trumna zosta³a otwarta.\nKryje siê w niej klucz w kszta³cie czaszki i\nKod 6767",
            "OK");
        Inventory.Add("Skool Key");
    }
}