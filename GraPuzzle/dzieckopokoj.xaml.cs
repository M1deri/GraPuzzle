namespace GraPuzzle;

public partial class dzieckopokoj : ContentPage
{
	public dzieckopokoj()
	{
		InitializeComponent();
	}
    private async void OnLeftArrowClicked4(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sypialnia());
    }

    private async void OnRightArrowClicked4(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Puzzle1());
    }
}