using System.Collections.ObjectModel;

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
}