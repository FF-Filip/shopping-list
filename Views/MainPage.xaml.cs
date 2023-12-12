using ListaZakupowa.Models;
using System.Diagnostics;
using System.Linq;

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
        await Shell.Current.GoToAsync(nameof(NewCategoryPage));
    }

    private void NewItem_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(NewItemPage));
    }

    
}