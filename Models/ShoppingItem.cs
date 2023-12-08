using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaZakupowa
{
    class ShoppingItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string QuantityUnit { get; set; }
        public string DefaultShop { get; set; }
        public bool isItemBought { get; set; }

        public ShoppingItem() { }

        public ShoppingItem(string Name, int Quantity, string QuantityUnit, string DefaultShop,
            bool isItemBought = false)
        {
            this.Name = Name;
            this.Quantity = Quantity;
            this.QuantityUnit = QuantityUnit;
            this.DefaultShop = DefaultShop;
            this.isItemBought = isItemBought;
        }
    }
}
