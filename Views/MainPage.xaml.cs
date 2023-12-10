namespace ListaZakupowa.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		BindingContext = new Models.AllCategories();
        
	}

    protected override void OnAppearing()
    {
        ((Models.AllCategories)BindingContext).LoadCategories();
        
    }

    private async void NewCategoryButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NewCategory));
    }
}