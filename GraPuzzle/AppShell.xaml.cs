namespace GraPuzzle
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("sypialnia", typeof(Sypialnia));
            Routing.RegisterRoute("dzieckopokoj", typeof(dzieckopokoj));
            Routing.RegisterRoute("end", typeof(end));
        }

    }
}
