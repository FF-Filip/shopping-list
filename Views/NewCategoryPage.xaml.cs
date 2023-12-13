using ListaZakupowa.Models;

namespace ListaZakupowa.Views;

public partial class NewCategoryPage : ContentPage
{
	public NewCategoryPage()
	{
		InitializeComponent();
        BindingContext = new AllCategories();
    }

    protected override void OnAppearing()
    {
        ((AllCategories)BindingContext).LoadCategories();
    }

    private async void CreateButton_Clicked(object sender, EventArgs e)
    {
        if (CategoryEditor.Text == null)
        {
            await DisplayAlert("Uwaga", "Wpisz nazwê kategorii.", "OK");
            return;
        }

        string newCategoryName = CategoryEditor.Text;

        Category category = new Category(newCategoryName);
        ((AllCategories)BindingContext).AddCategory(category);

        await Shell.Current.GoToAsync("..");
    }
}