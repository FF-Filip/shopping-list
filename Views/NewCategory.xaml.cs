namespace ListaZakupowa.Views;

public partial class NewCategory : ContentPage
{
	public NewCategory()
	{
		InitializeComponent();
	}

    private async void CreateButton_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("..");
    }
}