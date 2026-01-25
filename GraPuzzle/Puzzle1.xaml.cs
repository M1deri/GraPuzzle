namespace GraPuzzle;

public partial class Puzzle1 : ContentPage
{
    private Button selectedButton;
    private List<Button> allButtons = new();
    public Puzzle1()
    {
        InitializeComponent();
        CreateGrids();
    }
    private void CreateGrids()
    {
        TargetGrid.Children.Clear();
        PuzzleGrid.Children.Clear();
        allButtons.Clear();


        for (int i = 0; i < 9; i++)
        {
            var btn = CreatePuzzleButton("?");
            TargetGrid.Add(btn, i % 3, i / 3);
            allButtons.Add(btn);
        }

        for (int i = 1; i <= 9; i++)
        {
            var btn = CreatePuzzleButton(i.ToString());
            PuzzleGrid.Add(btn, (i - 1) % 3, (i - 1) / 3);
            allButtons.Add(btn);
        }
        var baseNumbers = Enumerable.Range(1, 9).ToList();
        for (int i = 0; i < 9; i++)
        {
            var btn = CreatePuzzleButton(baseNumbers[i].ToString());
            PuzzleGrid.Add(btn, i % 3, i / 3);
            allButtons.Add(btn);
        }
    }
    private Button CreatePuzzleButton(string text)
    {
        var btn = new Button
        {
            Text = text,
            Style = (Style)Application.Current.Resources["PuzzleButtonStyle"]
        };


        btn.Clicked += OnPuzzleClicked;
        return btn;
    }

    private async void OnPuzzleClicked(object sender, EventArgs e)
    {
        var clicked = (Button)sender;


        if (selectedButton == null)
        {
            selectedButton = clicked;
            selectedButton.BackgroundColor = Colors.Orange;
            return;
        }


        if (selectedButton == clicked)
        {
            ClearSelection();
            return;
        }


        (clicked.Text, selectedButton.Text) = (selectedButton.Text, clicked.Text);
        ClearSelection();


        if (CheckWin())
        {
            await DisplayAlert("skoñczone", "Tu bedzie wiadomoœæ o dostaniu przedmiotu potrzebnego do progressu", "tego typu");
        }
    }
    private void ClearSelection()
    {
        if (selectedButton != null)
        {
            selectedButton.BackgroundColor = ((Color)Application.Current.Resources["PuzzleColor"]);
            selectedButton = null;
        }
    }
    private bool CheckWin()
    {
        int expected = 1;
        foreach (var btn in TargetGrid.Children.Cast<Button>())
        {
            if (btn.Text != expected.ToString()) return false;
            expected++;
        }
        return true;
    }
    private void OnResetClicked(object sender, EventArgs e)
    {
        ClearSelection();
        CreateGrids();
    }
}