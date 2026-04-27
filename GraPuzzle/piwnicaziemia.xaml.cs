namespace GraPuzzle;

public partial class piwnicaziemia : ContentPage
{
	public piwnicaziemia()
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
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new piwnicaza());
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new piwnica_wejscie());
    }
}