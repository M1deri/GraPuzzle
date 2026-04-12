namespace GraPuzzle;

public partial class InventoryPage : ContentPage
{
    // Słownik: nazwa przedmiotu -> emoji ikona
    private static readonly Dictionary<string, string> ItemIcons = new()
    {
        { "Key",       "🗝" },
        { "Note",      "📜" },
        { "Flashlight","🔦" },
        { "Map",       "🗺" },
    };

    public InventoryPage()
    {
        InitializeComponent();
        LoadItems();
    }

    private void LoadItems()
    {
        if (Inventory.Items.Count == 0)
        {
            EmptyLabel.IsVisible = true;
            return;
        }

        foreach (var item in Inventory.Items)
        {
            var icon = ItemIcons.TryGetValue(item, out var emoji) ? emoji : "📦";
            var card = BuildItemCard(icon, TranslateName(item));
            ItemsContainer.Add(card);
        }
    }

    private static Frame BuildItemCard(string icon, string name)
    {
        return new Frame
        {
            BackgroundColor = Color.FromArgb("#2a1500"),
            BorderColor     = Color.FromArgb("#d4a84b"),
            CornerRadius    = 10,
            Padding         = new Thickness(16, 12),
            Content = new HorizontalStackLayout
            {
                Spacing = 16,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    new Label
                    {
                        Text     = icon,
                        FontSize = 32,
                        VerticalOptions = LayoutOptions.Center
                    },
                    new Label
                    {
                        Text      = name,
                        FontSize  = 18,
                        TextColor = Color.FromArgb("#f0d080"),
                        FontAttributes = FontAttributes.Bold,
                        VerticalOptions = LayoutOptions.Center
                    }
                }
            }
        };
    }

    // Tłumaczenie nazw przedmiotów na polski
    private static string TranslateName(string item) => item switch
    {
        "Key"        => "Klucz",
        "Note"       => "Notatka",
        "Flashlight" => "Latarka",
        "Map"        => "Mapa",
        _            => item
    };

    private async void OnCloseClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
