namespace ListaZakupowa.Controls;

public partial class ShoppingItem : ContentView
{
	public static readonly BindableProperty ItemNameProperty = BindableProperty.Create(nameof(ItemName), typeof(string), typeof(ShoppingItem), "Default name");
	public static readonly BindableProperty DefaultShopProperty = BindableProperty.Create(nameof(DefaultShop), typeof(string), typeof(ShoppingItem), "Default shop");
    public static readonly BindableProperty QuantityProperty = BindableProperty.Create(nameof(Quantity), typeof(int), typeof(ShoppingItem), -1);
	public static readonly BindableProperty QuantityUnitProperty = BindableProperty.Create(nameof(QuantityUnit), typeof(string), typeof(ShoppingItem), "unit");
    public static readonly BindableProperty isNotBoughtProperty = BindableProperty.Create(nameof(isNotBought), typeof(bool), typeof(ShoppingItem), true);

    public string ItemName
	{
		get => (string)GetValue(ItemNameProperty);
		set => SetValue(ItemNameProperty, value);
	}

	public string DefaultShop
	{
		get => (string)GetValue(DefaultShopProperty);
		set => SetValue(DefaultShopProperty, value);
	}

	public int Quantity
	{
		get => (int)GetValue(QuantityProperty);
		set => SetValue(QuantityProperty, value);
	}

	public string QuantityUnit
	{
		get => (string)GetValue(QuantityUnitProperty);
		set => SetValue(QuantityUnitProperty, value);
	}

	public bool isNotBought
	{
		get => (bool)GetValue(isNotBoughtProperty);
		set => SetValue(isNotBoughtProperty, value);
	}

	public ShoppingItem()
	{
		InitializeComponent();
	}
}