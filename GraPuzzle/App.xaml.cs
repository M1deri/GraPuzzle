namespace GraPuzzle
{
    // Główna klasa aplikacji
    public partial class App : Application
    {
        // Konstruktor aplikacji
        public App()
        {
            // Inicjalizacja komponentów z App.xaml
            InitializeComponent();
        }

        // Metoda tworząca główne okno aplikacji
        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Utworzenie okna z główną nawigacją AppShell
            return new Window(new AppShell());
        }
    }
}
