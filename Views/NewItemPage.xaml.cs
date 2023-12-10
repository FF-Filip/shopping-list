namespace ListaZakupowa.Views;

public partial class NewItemPage : ContentPage
{
	public NewItemPage()
	{
		InitializeComponent();
	}

    private void CreateButton_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}