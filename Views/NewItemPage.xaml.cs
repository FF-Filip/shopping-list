using ListaZakupowa.Models;
using System.Globalization;

namespace ListaZakupowa.Views;

public partial class NewItemPage : ContentPage
{
	public NewItemPage()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        AllCategories.Categories = FileHelper.LoadCategories();

        CategoryPicker.Items.Clear();

        foreach (var category in AllCategories.Categories)
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

        NumberFormatInfo provider = new NumberFormatInfo();
        provider.NumberDecimalSeparator = ".";
        provider.NumberGroupSeparator = ",";

        string newItemName = NameEditor.Text.Trim();
        string newItemCategory = CategoryPicker.SelectedItem.ToString();
        double newItemQuantity = Convert.ToDouble(QuantityEditor.Text.Trim(), provider);
        string newItemUnit = UnitEditor.Text.Trim();
        string newItemShop = ShopEditor.Text.Trim();

        Item newItem = new Item(newItemName, newItemCategory, newItemQuantity, newItemUnit, newItemShop);

        AllCategories.AddItem(newItem);

        await Shell.Current.GoToAsync("..");
    }
}