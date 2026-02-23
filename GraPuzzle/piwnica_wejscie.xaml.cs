namespace GraPuzzle;

public partial class piwnica_wejscie : ContentPage
{
	public piwnica_wejscie()
	{
		InitializeComponent();
	}
    private async void OnLeftArrowClicked3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sypialnia());
    }

    private async void OnRightArrowClicked3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new dzieckopokoj());
    }
}