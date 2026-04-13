using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace GraPuzzle;

public partial class dzieckopokoj : ContentPage
{
    private int blocksClicks = 0;
    private int bearClicks = 0;
    private int tableClicks = 0;
    private int chestClicks = 0;

    private bool puzzleSolved = false;

    public dzieckopokoj()
    {
        InitializeComponent();
    }

    private async Task CheckPuzzle()
    {
        if (blocksClicks == 1 && bearClicks == 3 && tableClicks == 4 && chestClicks == 5)
        {
            puzzleSolved = true;
            await DisplayAlert("Sukces!", "Zdoby³eœ klucz", "OK");
            Inventory.Add("Baby Key");
        }
    }

    private async void OnBlocksClicked(object sender, EventArgs e)
    {
        if (puzzleSolved)
            return;

        blocksClicks++;
        if (blocksClicks > 1)
        {
            await DisplayAlert("B³¹d", "Ju¿ nic sie nie dzieje", "OK");
            blocksClicks = 1;
        }
        else
        {
            await DisplayAlert("Klocki", "Le¿¹ na pod³odze...", "OK");
        }

        await CheckPuzzle();
    }

    private async void OnBearClicked(object sender, EventArgs e)
    {
        if (puzzleSolved)
            return;

        bearClicks++;
        if (bearClicks > 3)
        {
            await DisplayAlert("B³¹d", "Ju¿ nic sie nie dzieje", "OK");
            bearClicks = 3;
        }
        else
        {
            await DisplayAlert("Miœ", "Wygl¹da trochê dziwnie...", "OK");
        }

        await CheckPuzzle();
    }

    private async void OnTableClicked(object sender, EventArgs e)
    {
        if (puzzleSolved)
            return;

        tableClicks++;
        if (tableClicks > 4)
        {
            await DisplayAlert("B³¹d", "Ju¿ nic sie nie dzieje", "OK");
            tableClicks = 4;
        }
        else
        {
            await DisplayAlert("Stó³", "Coœ tu by³o u¿ywane...", "OK");
        }

        await CheckPuzzle();
    }

    private async void OnChestClicked(object sender, EventArgs e)
    {
        if (puzzleSolved)
        {
            await DisplayAlert("Skrzynia", "Ju¿ masz klucz!", "OK");
            return;
        }

        chestClicks++;
        if (chestClicks > 5)
        {
            await DisplayAlert("B³¹d", "Ju¿ nic sie nie dzieje", "OK");
            chestClicks = 5;
        }
        else
        {
            await DisplayAlert("Skrzynia", "Zamkniêta...", "OK");
        }

        await CheckPuzzle();
    }

    private async void OnLeftArrowClicked4(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Puzzle1());
    }

    private async void OnRightArrowClicked4(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new piwnica_wejscie());
    }

    private async void OnInventoryClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new InventoryPage());
    }
}