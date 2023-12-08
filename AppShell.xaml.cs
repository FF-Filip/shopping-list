namespace ListaZakupowa
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.NewCategory), typeof(Views.NewCategory));
        }


    }
}