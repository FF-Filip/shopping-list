namespace ListaZakupowa.Views;

public partial class ShoppingItems : ContentPage
{
	public ShoppingItems()
	{
		InitializeComponent();
        BindingContext = new Models.AllItems();
	}

    protected override void OnAppearing()
    {
        ((Models.AllItems)BindingContext).LoadItems();
    }
}