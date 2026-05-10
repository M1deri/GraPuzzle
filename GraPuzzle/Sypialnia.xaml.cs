namespace GraPuzzle;

// Logika pokoju: Sypialnia (zagadka obrazów)
public partial class Sypialnia : ContentPage
{
    // Poprawna sekwencja kliknięć obrazów
    private readonly List<string> _correctSequence = new() { "Raven", "Deer", "Goat" };

    // Aktualna sekwencja gracza
    private readonly List<string> _playerSequence = new();

    // Flaga ukończenia zagadki
    private bool _puzzleSolved = false;

    // Konstruktor strony
    public Sypialnia()
    {
        InitializeComponent();
    }

    // ───────────────────────────────
    // KLIKNIĘCIA OBRAZÓW
    // ───────────────────────────────

    private async void OnRavenClicked(object sender, EventArgs e)
    {
        if (_puzzleSolved) return;

        await RegisterClick(
            "Raven",
            RavenHighlight,
            "Kruk",
            "Czarny kruk wpatruje się w ciebie martwym wzrokiem.\nJego pióra lśnią w blasku księżyca.");
    }

    private async void OnDeerClicked(object sender, EventArgs e)
    {
        if (_puzzleSolved) return;

        await RegisterClick(
            "Deer",
            DeerHighlight,
            "Jeleń",
            "Poroże jelenia rzuca długi cień na ścianę.\nSkóra zwierzęcia wygląda niemal jak żywa.");
    }

    private async void OnGoatClicked(object sender, EventArgs e)
    {
        if (_puzzleSolved) return;

        await RegisterClick(
            "Goat",
            GoatHighlight,
            "Koza",
            "Koza ma dziwnie ludzkie oczy.\nCzujesz się obserwowany.");
    }

    // ───────────────────────────────
    // LOGIKA ZAGADKI
    // ───────────────────────────────

    private async Task RegisterClick(
        string animal,
        BoxView highlight,
        string title,
        string description)
    {
        // Pokazanie opisu obiektu
        await DisplayAlert(title, description, "OK");

        // Jeśli już kliknięto ten obiekt → reset
        if (_playerSequence.Contains(animal))
        {
            await DisplayAlert(
                "🔄 Reset",
                "Coś zachrzęściło... Obrazy wróciły do poprzedniego stanu.",
                "OK");

            ResetSequence();
            return;
        }

        // Dodanie do sekwencji
        _playerSequence.Add(animal);

        // Podświetlenie obiektu
        highlight.IsVisible = true;

        UpdateSequenceLabel();

        // Sprawdzenie poprawności bieżącego kroku
        int step = _playerSequence.Count - 1;

        if (_playerSequence[step] != _correctSequence[step])
        {
            await DisplayAlert(
                "❌ Błąd",
                "Usłyszałeś cichy trzask.\nCoś jest nie tak z kolejnością...",
                "OK");

            ResetSequence();
            return;
        }

        // Sprawdzenie ukończenia zagadki
        if (_playerSequence.Count == _correctSequence.Count)
        {
            await SolveAsync();
        }
    }

    // Rozwiązanie zagadki
    private async Task SolveAsync()
    {
        _puzzleSolved = true;
        SequenceLabel.IsVisible = false;

        await DisplayAlert(
            "✨ Sukces!",
            "Obrazy przesunęły się na ścianie.\nZa jeleniem była wnęka, a w niej...\nstary, zardzewiały klucz!",
            "OK");

        // Dodanie przedmiotu do ekwipunku
        Inventory.Add("Heart Key");
    }

    // Reset sekwencji
    private void ResetSequence()
    {
        _playerSequence.Clear();

        RavenHighlight.IsVisible = false;
        DeerHighlight.IsVisible = false;
        GoatHighlight.IsVisible = false;

        UpdateSequenceLabel();
    }

    // Aktualizacja debugowego wyświetlacza sekwencji
    private void UpdateSequenceLabel()
    {
        if (_playerSequence.Count == 0)
        {
            SequenceLabel.IsVisible = false;
            return;
        }

        var names = new Dictionary<string, string>
        {
            { "Raven", "Kruk" },
            { "Deer",  "Jeleń" },
            { "Goat",  "Koza" }
        };

        SequenceLabel.Text = "Kolejność: " +
            string.Join(" → ", _playerSequence.Select(a => names[a]));

        SequenceLabel.IsVisible = true;
    }

    // ───────────────────────────────
    // NAWIGACJA
    // ───────────────────────────────

    private async void OnRightArrowClicked2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Puzzle1());
    }

    private async void OnLeftArrowClicked2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new piwnica_wejscie());
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnInventoryClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new InventoryPage());
    }
}
