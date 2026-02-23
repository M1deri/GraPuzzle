namespace GraPuzzle;

public partial class Sypialnia : ContentPage
{
	public Sypialnia()
	{
		InitializeComponent();
	}
    private async void OnLeftArrowClicked2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Puzzle1());
    }

    private async void OnRightArrowClicked2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new piwnica_wejscie());
    }
}