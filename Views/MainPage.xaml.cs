using ListaZakupowa.Models;
using System.Diagnostics;
using System.Linq;

namespace ListaZakupowa.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();
        CategoriesCollection.CancelAnimations();
        BindingContext = AllCategories.Categories;
    }

    protected override void OnAppearing()
    {
        try
        {
            AllCategories.Categories = FileHelper.LoadCategories();
            List<Category> catList = AllCategories.Categories.ToList();
            CategoriesCollection.ItemsSource = catList;
        }
        catch (AccessViolationException ex)
        {
            Debug.WriteLine($"AccessViolationException: {ex.Message}");
        }
    }

    private async void NewCategoryButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NewCategoryPage));
    }

    private void NewItem_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(NewItemPage));
    }

    private void NewCategory_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(NewCategoryPage));
    }
}
