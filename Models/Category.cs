using System.Collections.ObjectModel;

namespace ListaZakupowa.Models
{
    public class Category
    {
        public string Name { get; set; }
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();

        public Category(string Name, ObservableCollection<Item> Items = null)
        {
            this.Name = Name;
            this.Items = Items;
        }

    }
}
