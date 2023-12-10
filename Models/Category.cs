using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaZakupowa.Models
{
    public class Category
    {
        public string Name { get; set; }
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();

        public Category(string name)
        {
            Name = name;
            LoadItems();
        }

        public void LoadItems()
        {
            Items.Clear();

            Items.Add(new Item("Mleko", 5, "l", "Biedronka"));
            Items.Add(new Item("Bułki", 2, "szt.", "Lidl"));
        }
    }
}
