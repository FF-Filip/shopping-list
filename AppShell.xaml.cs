namespace ListaZakupowa
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.NewCategoryPage), typeof(Views.NewCategoryPage));
            Routing.RegisterRoute(nameof(Views.NewItemPage), typeof(Views.NewItemPage));
        }
    }
}
