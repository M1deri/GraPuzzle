namespace GraPuzzle;

public partial class Puzzle1 : ContentPage
{
    private string enteredCode = "";
    private const string correctCode = "1234";
    private bool key = false;

    public Puzzle1()
    {
        InitializeComponent();
    }
    private void OnNumberClicked(object sender, EventArgs e)
    {
        var button = sender as Button;

        if (enteredCode.Length < 4)
        {
            enteredCode += button.Text;
            UpdateDisplay();
        }
    }
    private void OnClearClicked(object sender, EventArgs e)
    {
        enteredCode = "";
        UpdateDisplay();
    }

    private async void OnOkClicked(object sender, EventArgs e)
    {
        if (enteredCode == correctCode)
        {
            await DisplayAlert("Sukces", "Kod poprawny!", "OK");

           
            await Navigation.PushAsync(new Sypialnia());
        }
        else
        {
            await DisplayAlert("Błąd", "Zły kod!", "OK");
            enteredCode = "";
            UpdateDisplay();
        }
    }
    private void UpdateDisplay()
    {
        CodeDisplay.Text = enteredCode.PadRight(4, '_');
    }
    private async void OnLeftArrowClicked1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new dzieckopokoj());
    }

    private async void OnRightArrowClicked1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sypialnia());
    }

    private void OnHeartClicked(object sender, EventArgs e)
    {
        if (key){
            DisplayAlert("cwel", "pedal", "OK");
        }
        else
        {
            DisplayAlert("Stop", "Nie posiadasz klucza", "OK");
        }
       
    }
}