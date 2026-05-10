namespace GraPuzzle;

// Strona wyświetlająca ekwipunek gracza
public partial class InventoryPage : ContentPage
{
    // Słownik przechowujący ikony przypisane do przedmiotów
    private static readonly Dictionary<string, string> ItemIcons = new()
    {
        { "Heart Key", "🗝" },
        { "Note",      "📜" },
        { "Baby Key",  "🗝" },
        { "Map",       "🗺" },
    };

    // Konstruktor strony
    public InventoryPage()
    {
        // Inicjalizacja komponentów XAML
        InitializeComponent();

        // Załadowanie przedmiotów do widoku
        LoadItems();
    }

    // Metoda wczytująca przedmioty z ekwipunku
    private void LoadItems()
    {
        // Sprawdzenie czy ekwipunek jest pusty
        if (Inventory.Items.Count == 0)
        {
            // Wyświetlenie informacji o pustym ekwipunku
            EmptyLabel.IsVisible = true;
            return;
        }

        // Przechodzenie przez wszystkie przedmioty
        foreach (var item in Inventory.Items)
        {
            // Pobranie ikony przedmiotu lub domyślnej ikony
            var icon = ItemIcons.TryGetValue(item, out var emoji)
                ? emoji
                : "📦";

            // Utworzenie karty przedmiotu
            var card = BuildItemCard(icon, item);

            // Dodanie karty do kontenera
            ItemsContainer.Add(card);
        }
    }

    // Metoda tworząca kartę przedmiotu
    private static Frame BuildItemCard(string icon, string name)
    {
        return new Frame
        {
            // Kolor tła karty
            BackgroundColor = Color.FromArgb("#2a1500"),

            // Kolor obramowania
            BorderColor = Color.FromArgb("#d4a84b"),

            // Zaokrąglenie rogów
            CornerRadius = 10,

            // Wewnętrzne odstępy
            Padding = new Thickness(16, 12),

            // Zawartość karty
            Content = new HorizontalStackLayout
            {
                // Odstęp między elementami
                Spacing = 16,

                // Wyśrodkowanie w pionie
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                    // Ikona przedmiotu
                    new Label
                    {
                        Text = icon,
                        FontSize = 32,
                        VerticalOptions = LayoutOptions.Center
                    },

                    // Nazwa przedmiotu
                    new Label
                    {
                        Text = name,
                        FontSize = 18,
                        TextColor = Color.FromArgb("#f0d080"),
                        FontAttributes = FontAttributes.Bold,
                        VerticalOptions = LayoutOptions.Center
                    }
                }
            }
        };
    }

    // Obsługa przycisku zamykania ekwipunku
    private async void OnCloseClicked(object sender, EventArgs e)
    {
        // Zamknięcie okna modalnego
        await Navigation.PopModalAsync();
    }
}
