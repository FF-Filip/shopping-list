using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaZakupowa.Models
{
    class AllItems
    {
        public ObservableCollection<ShoppingItem> AllShoppingItems { get; set; } = new ObservableCollection<ShoppingItem>();

        AllItems() { }

        public void LoadItems()
        {
            AllShoppingItems.Clear();

            AllShoppingItems.Add(new ShoppingItem("Mleko", 5, "l", "Biedronka"));
            AllShoppingItems.Add(new ShoppingItem("Bułki", 2, "szt.", "Lidl"));
        }
    }
}
