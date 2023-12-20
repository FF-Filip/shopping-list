using ListaZakupowa.Models;
using System.Collections.ObjectModel;

namespace ListaZakupowa.Views;

public partial class ShopView : ContentPage
{
	public ShopView()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        AllCategories.Categories = FileHelper.LoadCategories();
        ObservableCollection<Item> allItems = new ObservableCollection<Item>();
        foreach(Category category in AllCategories.Categories)
        {
            foreach(Item item in category.Items)
            {
                allItems.Add(item);
            }
        }

        ItemsCollection.ItemsSource = allItems;
    }
}