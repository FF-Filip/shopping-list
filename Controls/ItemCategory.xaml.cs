using ListaZakupowa.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ListaZakupowa.Controls;

public partial class ItemCategory : ContentView
{
	public static readonly BindableProperty CategoryNameProperty = BindableProperty.Create(nameof(CategoryName), typeof(string), typeof(ItemCategory), "Category Name");
	public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<Item>), typeof(ItemCategory));
	public string CategoryName
	{
		get => (string)GetValue(CategoryNameProperty);
		set => SetValue(CategoryNameProperty, value);
	}

	public ObservableCollection<Item> Items
	{
		get => (ObservableCollection<Item>)GetValue(ItemsProperty);
		set => SetValue(ItemsProperty, value);
	}

	public ItemCategory()
	{
		InitializeComponent();
	}

    private void ItemSelection_Changed(object sender, SelectionChangedEventArgs e)
    {
        Item selectedItem = e.CurrentSelection.FirstOrDefault() as Item;
        //selectedItem.isItemBought = !selectedItem.isItemBought;

        CollectionView senderCategory = sender as CollectionView;
        Debug.WriteLine(senderCategory.ItemsSource);

        //((AllCategories)BindingContext).Categories.IndexOf(senderCategory)
    }
}