using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace GraPuzzle;

// Pokój dziecięcy – logika zagadki
public partial class dzieckopokoj : ContentPage
{
    // Liczniki kliknięć na obiektach
    private int blocksClicks = 0;
    private int bearClicks = 0;
    private int tableClicks = 0;
    private int chestClicks = 0;

    // Flaga czy zagadka została rozwiązana
    private bool puzzleSolved = false;

    // Konstruktor strony
    public dzieckopokoj()
    {
        InitializeComponent();
    }

    // Sprawdzenie poprawnej sekwencji kliknięć
    private async Task CheckPuzzle()
    {
        if (blocksClicks == 1 &&
            bearClicks == 3 &&
            tableClicks == 4 &&
            chestClicks == 5)
        {
            puzzleSolved = true;

            await DisplayAlert("Sukces!", "Zdobyłeś klucz", "OK");

            // Dodanie przedmiotu do ekwipunku
            Inventory.Add("Baby Key");
        }
    }

    // Kliknięcie w klocki
    private async void OnBlocksClicked(object sender, EventArgs e)
    {
        if (puzzleSolved)
            return;

        blocksClicks++;

        if (blocksClicks > 1)
        {
            await DisplayAlert("Błąd", "Już nic się nie dzieje", "OK");
            blocksClicks = 1;
        }
        else
        {
            await DisplayAlert("Klocki", "Leżą na podłodze...", "OK");
        }

        await CheckPuzzle();
    }

    // Kliknięcie w misia
    private async void OnBearClicked(object sender, EventArgs e)
    {
        if (puzzleSolved)
            return;

        bearClicks++;

        if (bearClicks > 3)
        {
            await DisplayAlert("Błąd", "Już nic się nie dzieje", "OK");
            bearClicks = 3;
        }
        else
        {
            await DisplayAlert("Miś", "Wygląda trochę dziwnie...", "OK");
        }

        await CheckPuzzle();
    }

    // Kliknięcie w stół
    private async void OnTableClicked(object sender, EventArgs e)
    {
        if (puzzleSolved)
            return;

        tableClicks++;

        if (tableClicks > 4)
        {
            await DisplayAlert("Błąd", "Już nic się nie dzieje", "OK");
            tableClicks = 4;
        }
        else
        {
            await DisplayAlert("Stół", "Coś tu było używane...", "OK");
        }

        await CheckPuzzle();
    }

    // Kliknięcie w skrzynię
    private async void OnChestClicked(object sender, EventArgs e)
    {
        if (puzzleSolved)
        {
            await DisplayAlert("Skrzynia", "Już masz klucz!", "OK");
            return;
        }

        chestClicks++;

        if (chestClicks > 5)
        {
            await DisplayAlert("Błąd", "Już nic się nie dzieje", "OK");
            chestClicks = 5;
        }
        else
        {
            await DisplayAlert("Skrzynia", "Zamknięta...", "OK");
        }

        await CheckPuzzle();
    }

    // Przejście do poprzedniego pokoju
    private async void OnLeftArrowClicked4(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Puzzle1());
    }

    // Przejście do kolejnego pokoju
    private async void OnRightArrowClicked4(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new piwnica_wejscie());
    }

    // Otwarcie ekwipunku
    private async void OnInventoryClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new InventoryPage());
    }
}
