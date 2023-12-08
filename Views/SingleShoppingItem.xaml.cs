namespace ListaZakupowa.Views;

public partial class SingleShoppingItem : ContentPage
{
	public SingleShoppingItem()
	{
		InitializeComponent();
	}

    private async void NewCategoryButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NewCategory));
    }
}