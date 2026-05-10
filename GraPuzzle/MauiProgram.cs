using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;

namespace GraPuzzle
{
    // Klasa konfigurująca aplikację .NET MAUI
    public static class MauiProgram
    {
        // Metoda tworząca aplikację MAUI
        public static MauiApp CreateMauiApp()
        {
            // Tworzenie buildera aplikacji
            var builder = MauiApp.CreateBuilder();

            builder

                // Ustawienie głównej klasy aplikacji
                .UseMauiApp<App>()

                // Konfiguracja czcionek
                .ConfigureFonts(fonts =>
                {
                    // Dodanie podstawowej czcionki
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");

                    // Dodanie pogrubionej czcionki
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            // Włączenie logowania w trybie debugowania
    		builder.Logging.AddDebug();
#endif

            // Rejestracja menedżera audio jako singleton
            builder.Services.AddSingleton(AudioManager.Current);

            // Rejestracja strony MainPage
            builder.Services.AddTransient<MainPage>();

            // Zbudowanie i zwrócenie aplikacji
            return builder.Build();
        }
    }
}
