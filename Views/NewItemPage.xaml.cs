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

        foreach (var category in (BindingContext as AllCategories).Categories)
        {
            CategoryPicker.Items.Add(category.Name);
        }
    }

    private async void CreateButton_Clicked(object sender, EventArgs e)
    {
        
        if (NameEditor.Text == null)
        {
            await DisplayAlert("Uwaga", "Wpisz nazwê produktu.", "OK");
            return;
        }

        if (CategoryPicker.SelectedItem == null)
        {
            await DisplayAlert("Uwaga", "Nie wybrano kategorii produktu.", "OK");
            return;
        }

        if (QuantityEditor.Text == null)
        {
            await DisplayAlert("Uwaga", "Wpisz iloœæ produktu.", "OK");
            return;
        }

        if (UnitEditor.Text == null)
        {
            await DisplayAlert("Uwaga", "Wpisz jednostkê iloœci produktu.", "OK");
            return;
        }

        if (ShopEditor.Text == null)
        {
            await DisplayAlert("Uwaga", "Wpisz sklep dla produktu.", "OK");
            return;
        }
        

        string newItemName = NameEditor.Text;
        string newItemCategory = CategoryPicker.SelectedItem.ToString();
        int newItemQuantity = Int32.Parse(QuantityEditor.Text);
        string newItemUnit = UnitEditor.Text;
        string newItemShop = ShopEditor.Text;

        Item newItem = new Item(newItemName, newItemCategory, newItemQuantity, newItemUnit, newItemShop);

        (BindingContext as AllCategories).AddItem(newItem);

        await Shell.Current.GoToAsync("..");
    }
}