namespace GraPuzzle
{
    // Klasa odpowiedzialna za nawigację w aplikacji
    public partial class AppShell : Shell
    {
        // Konstruktor AppShell
        public AppShell()
        {
            // Inicjalizacja komponentów z AppShell.xaml
            InitializeComponent();

            // Rejestracja trasy do strony Sypialnia
            Routing.RegisterRoute("sypialnia", typeof(Sypialnia));

            // Rejestracja trasy do strony dzieckopokoj
            Routing.RegisterRoute("dzieckopokoj", typeof(dzieckopokoj));

            // Rejestracja trasy do strony końcowej
            Routing.RegisterRoute("end", typeof(end));
        }
    }
}
