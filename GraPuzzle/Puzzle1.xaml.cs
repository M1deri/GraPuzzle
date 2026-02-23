namespace GraPuzzle;

public partial class Puzzle1 : ContentPage
{

    public Puzzle1()
    {
        InitializeComponent();
    }

    private async void OnLeftArrowClicked1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new dzieckopokoj());
    }

    private async void OnRightArrowClicked1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sypialnia());
    }

}