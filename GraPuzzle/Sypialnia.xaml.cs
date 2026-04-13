namespace GraPuzzle;

public partial class Sypialnia : ContentPage
{
    // Prawidłowa kolejność: Kruk (1) → Jeleń (2) → Koza (3)
    private readonly List<string> _correctSequence = new() { "Raven", "Deer", "Goat" };
    private readonly List<string> _playerSequence  = new();
    private bool _puzzleSolved = false;

    public Sypialnia()
    {
        InitializeComponent();
    }

    // ── KLIKNIĘCIA OBRAZÓW ──────────────────────────────────────────────

    private async void OnRavenClicked(object sender, EventArgs e)
    {
        if (_puzzleSolved) return;
        await RegisterClick("Raven", RavenHighlight,
            "Kruk",
            "Czarny kruk wpatruje się w ciebie martwym wzrokiem.\nJego pióra lśnią w blasku księżyca.");
    }

    private async void OnDeerClicked(object sender, EventArgs e)
    {
        if (_puzzleSolved) return;
        await RegisterClick("Deer", DeerHighlight,
            "Jeleń",
            "Poroże jelenia rzuca długi cień na ścianę.\nSkóra zwierzęcia wygląda niemal jak żywa.");
    }

    private async void OnGoatClicked(object sender, EventArgs e)
    {
        if (_puzzleSolved) return;
        await RegisterClick("Goat", GoatHighlight,
            "Koza",
            "Koza ma dziwnie ludzkie oczy.\nCzujesz się obserwowany.");
    }

    // ── LOGIKA ZAGADKI ──────────────────────────────────────────────────

    private async Task RegisterClick(string animal, BoxView highlight, string title, string description)
    {
        // Pokaż opis obrazu
        await DisplayAlert(title, description, "OK");

        // Jeśli ten obraz już jest w sekwencji — reset
        if (_playerSequence.Contains(animal))
        {
            await DisplayAlert("🔄 Reset", "Coś zachrzęściło... Obrazy wróciły do poprzedniego stanu.", "OK");
            ResetSequence();
            return;
        }

        // Dodaj do sekwencji i podświetl
        _playerSequence.Add(animal);
        highlight.IsVisible = true;
        UpdateSequenceLabel();

        // Sprawdź czy kolejność jest poprawna na bieżąco
        int step = _playerSequence.Count - 1;
        if (_playerSequence[step] != _correctSequence[step])
        {
            await DisplayAlert("❌ Błąd", "Usłyszałeś cichy trzask.\nCoś jest nie tak z kolejnością...", "OK");
            ResetSequence();
            return;
        }

        // Sprawdź czy cała sekwencja gotowa
        if (_playerSequence.Count == _correctSequence.Count)
        {
            await SolveAsync();
        }
    }

    private async Task SolveAsync()
    {
        _puzzleSolved = true;
        SequenceLabel.IsVisible = false;

        await DisplayAlert(
            "✨ Sukces!",
            "Obrazy lekko przesunęły się ze ściany.\nZa jeleniem kryła się mała wnęka — a w niej...\nStary, zardzewiały klucz!",
            "OK");

        Inventory.Add("Heart Key");
    }

    private void ResetSequence()
    {
        _playerSequence.Clear();
        RavenHighlight.IsVisible = false;
        DeerHighlight.IsVisible  = false;
        GoatHighlight.IsVisible  = false;
        UpdateSequenceLabel();
    }

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

    // ── NAWIGACJA ───────────────────────────────────────────────────────

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
