namespace ListaZakupowa.Controls;

public partial class ItemCategory : ContentView
{
	public static readonly BindableProperty CategoryNameProperty = BindableProperty.Create(nameof(CategoryName), typeof(string), typeof(ItemCategory), "Category Name");

	public string CategoryName
    {
		get => (string)GetValue(CategoryNameProperty);
		set => SetValue(CategoryNameProperty, value);
	}

	public ItemCategory()
	{
		InitializeComponent();
	}
}