using ListaZakupowa.Models;
using System.Diagnostics;
using System.Globalization;

namespace ListaZakupowa.Controls;

public partial class ShoppingItem : ContentView
{
	public static readonly BindableProperty ItemNameProperty = BindableProperty.Create(nameof(ItemName), typeof(string), typeof(ShoppingItem), "Default name");
	public static readonly BindableProperty DefaultShopProperty = BindableProperty.Create(nameof(DefaultShop), typeof(string), typeof(ShoppingItem), "Default shop");
    public static readonly BindableProperty QuantityProperty = BindableProperty.Create(nameof(Quantity), typeof(double), typeof(ShoppingItem), -1.0);
	public static readonly BindableProperty QuantityUnitProperty = BindableProperty.Create(nameof(QuantityUnit), typeof(string), typeof(ShoppingItem), "unit");
    public static readonly BindableProperty IsItemBoughtProperty = BindableProperty.Create(nameof(IsItemBought), typeof(bool), typeof(ShoppingItem), false);

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

	public double Quantity
	{
		get => (double)GetValue(QuantityProperty);
		set => SetValue(QuantityProperty, value);
	}

	public string QuantityUnit
	{
		get => (string)GetValue(QuantityUnitProperty);
		set => SetValue(QuantityUnitProperty, value);
	}

    public bool IsItemBought
    {
        get => (bool)GetValue(IsItemBoughtProperty);
        set => SetValue(IsItemBoughtProperty, value);
    }

    public ShoppingItem()
    {
        InitializeComponent();
    }

    private void IsBought_Changed(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox)
        {
            if (checkBox.IsChecked)
			{
				NameLabel.TextColor = Colors.Grey;
                NameLabel.TextDecorations = TextDecorations.Strikethrough;
                QuantityLabel.TextColor = Colors.Grey;
                UnitLabel.TextColor = Colors.Grey;
				ShopLabel.TextColor = Colors.Grey;

                ((Item)BindingContext).IsItemBought = true;
				if(BindingContext is Item item)
				{
                    foreach (var category in AllCategories.Categories)
                    {
						int lastIndex = category.Items.Count - 1;
                        if (category.Name == item.ParentCategory)
                        {
                            int itemIndex = category.Items.IndexOf(item);
                            if (itemIndex != lastIndex && itemIndex >= 0 && lastIndex != 0)
                            {
                                category.Items.Move(itemIndex, category.Items.Count - 1);
                            }
                            break;
                        }
                    }
                }
            } 
			else
			{
                NameLabel.TextColor = Colors.White;
                NameLabel.TextDecorations = TextDecorations.None;
                QuantityLabel.TextColor = Colors.White;
                UnitLabel.TextColor = Colors.White;
                ShopLabel.TextColor = Colors.White;

                ((Item)BindingContext).IsItemBought = false;
                if (BindingContext is Item item)
                {
                    foreach (var category in AllCategories.Categories)
                    {
                        if (category.Name == item.ParentCategory)
                        {
                            int itemIndex = category.Items.IndexOf(item);
                            if (itemIndex > 0)
                                category.Items.Move(itemIndex, 0);
                        }
                    }
                }
            }

			FileHelper.SaveCategories(AllCategories.Categories.ToList());
        }
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Item item)
        {
			foreach (var category in AllCategories.Categories)
			{
				if(category.Name == item.ParentCategory)
				{
					category.Items.Remove(item);
					FileHelper.SaveCategories(AllCategories.Categories.ToList());
				}
			}
        }
    }

    private void QuantityValue_Changed(object sender, ValueChangedEventArgs e)
    {
        if (BindingContext is Item newItem)
        {
            newItem.Quantity = ((Stepper)sender).Value;
            FileHelper.SaveCategories(AllCategories.Categories.ToList());
        }
    }
}