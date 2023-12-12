using ListaZakupowa.Models;

namespace ListaZakupowa.Views;

public partial class NewItemPage : ContentPage
{
	public NewItemPage()
	{
		InitializeComponent();
		BindingContext = new AllCategories();
	}

    protected override void OnAppearing()
    {
        ((AllCategories)BindingContext).LoadCategories();
        CategoryPicker.Items.Clear();

        List<Category> categories = (BindingContext as AllCategories).Categories.ToList();
        foreach (var category in categories)
        {
            CategoryPicker.Items.Add(category.Name);
        }
    }

    private async void CreateButton_Clicked(object sender, EventArgs e)
    {
        if(CategoryPicker.SelectedItem == null)
        {
            await DisplayAlert("Uwaga", "Nie wybrano kategorii produktu", "OK");
            return;
        }



		await Shell.Current.GoToAsync("..");
    }
}