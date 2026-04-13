using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Dispatching;

namespace GraPuzzle;

public partial class Puzzle1 : ContentPage
{
    private string enteredCode = "";
    private const string correctCode = "6767";

    public Puzzle1()
    {
        InitializeComponent();

        this.Loaded += (s, e) =>
        {
            AddKeypadHotspots();
            AddObjectHotspots();
        };
    }

    private void AddKeypadHotspots()
    {
        AddKey("1", 0.38, 0.735, 0.07, 0.025);
        AddKey("2", 0.46, 0.735, 0.07, 0.025);
        AddKey("3", 0.54, 0.735, 0.07, 0.025);

        AddKey("4", 0.62, 0.735, 0.07, 0.025);   
        AddKey("5", 0.38, 0.767, 0.07, 0.025); 
        AddKey("6", 0.46, 0.767, 0.07, 0.025); 

        AddKey("7", 0.54, 0.767, 0.07, 0.025); 
        AddKey("8", 0.62, 0.767, 0.07, 0.025); 
        AddKey("9", 0.38, 0.798, 0.07, 0.025);

        AddKey("0", 0.46, 0.798, 0.07, 0.025);
        AddKey("OK", 0.574, 0.798, 0.128, 0.025);
    }

    private void AddKey(string value, double xCenter, double yCenter, double widthProp, double heightProp)
    {
        var box = new BoxView
        {
            Color = Colors.Red.WithAlpha(0.3f),
            InputTransparent = false
        };

        var tap = new TapGestureRecognizer();
        tap.Tapped += (s, e) => OnKeyPressed(value);
        box.GestureRecognizers.Add(tap);

        MainLayout.Children.Add(box);

        SetBoxBounds(box, xCenter, yCenter, widthProp, heightProp);
    }

    private async void OnKeyPressed(string key)
    {
        if (key == "OK")
        {
            if (enteredCode == correctCode)
            {
                await DisplayAlert("Sukces", "Kod poprawny!", "OK");
                await Navigation.PushAsync(new end());
                return;
            }
            else
            {
                await DisplayAlert("Błąd", "Zły kod!", "OK");
                enteredCode = "";
            }
        }
        else
        {
            if (enteredCode.Length < 4)
                enteredCode += key;
        }

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        CodeDisplay.Text = enteredCode.PadRight(4, '_');
    }

    private void AddObjectHotspots()
    {
        AddHotspot("heart", 0.5, 0.275, 0.22, 0.14);
        AddHotspot("skull", 0.5, 0.41, 0.18, 0.11);
        AddHotspot("doll", 0.5, 0.57, 0.2, 0.18);
    }

    private void AddHotspot(string id, double xCenter, double yCenter, double widthProp, double heightProp)
    {
        var box = new BoxView
        {
            Color = Colors.Red.WithAlpha(0.3f),
            InputTransparent = false
        };

        var tap = new TapGestureRecognizer();
        tap.Tapped += (s, e) => OnHotspotTapped(id);
        box.GestureRecognizers.Add(tap);

        MainLayout.Children.Add(box);

        SetBoxBounds(box, xCenter, yCenter, widthProp, heightProp);
    }

    private void SetBoxBounds(BoxView box, double xCenter, double yCenter, double widthProp, double heightProp)
    {
        Dispatcher.Dispatch(() =>
        {
            var width = MainLayout.Width * widthProp;
            var height = MainLayout.Height * heightProp;
            var x = MainLayout.Width * xCenter - width / 2;
            var y = MainLayout.Height * yCenter - height / 2;

            AbsoluteLayout.SetLayoutBounds(box, new Rect(x, y, width, height));
        });
    }

    private async void OnHotspotTapped(string id)
    {
        switch (id)
        {
            case "heart":

                if (Inventory.Has("Heart Key"))
                {
                    await DisplayAlert("Serce", "Kłódka otwarta!", "OK");
                }
                else
                {
                    await DisplayAlert("Serce", "Nie masz odpowiedniego klucza", "OK");
                }

                break;

            case "skull":
                await DisplayAlert("Czaszka", "Trochę straszna...", "OK");
                break;

            case "doll":
                if (Inventory.Has("Baby Key"))
                {
                    await DisplayAlert("Lalka", "Kłódka otwarta!", "OK");
                }
                else
                {
                    await DisplayAlert("Lalka", "Nie masz odpowiedniego klucza", "OK");
                }
                break;
        }
    }

    private async void OnRightArrowClicked1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new dzieckopokoj());
    }

    private async void OnLeftArrowClicked1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sypialnia());
    }
    private async void OnInventoryClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new InventoryPage());
    }
}