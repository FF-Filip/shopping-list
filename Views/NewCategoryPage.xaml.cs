namespace ListaZakupowa.Views;

public partial class NewCategoryPage : ContentPage
{
	public NewCategoryPage()
	{
		InitializeComponent();
	}

    private async void CreateButton_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("..");
    }
}