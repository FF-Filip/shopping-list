namespace ListaZakupowa
{
    public class Item
    {
        public string Name { get; set; }
        public string  ParentCategory { get; set; }
        public int Quantity { get; set; }
        public string QuantityUnit { get; set; }
        public string DefaultShop { get; set; }
        public bool isItemBought { get; set; }

        public Item(string Name, string ParentCategory, int Quantity, string QuantityUnit,
            string DefaultShop, bool isItemBought = false)
        {
            this.Name = Name;
            this.ParentCategory = ParentCategory;
            this.Quantity = Quantity;
            this.QuantityUnit = QuantityUnit;
            this.DefaultShop = DefaultShop;
            this.isItemBought = isItemBought;
        }
    }
}
