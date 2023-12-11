using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ListaZakupowa.Models
{
    public class Category
    {
        public string Name { get; set; }
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();

        public Category(string Name)
        {
            this.Name = Name;
            LoadItems();
        }

        public void SaveItems()
        {
            Items.Add(new Item("Banany", 2, "szt.", "Lidl"));
            Items.Add(new Item("Mleko", 1, "l", "Dino"));

            XDocument xDocument = new XDocument();

            xDocument.Add(new XElement("Items"));
            foreach (Item item in Items)
            {
                xDocument.Element("Items").Add(new XElement("Item",
                    new XElement("Name", item.Name.ToString()),
                    new XElement("Quantity", item.Quantity.ToString()),
                    new XElement("QuantityUnit", item.QuantityUnit.ToString()),
                    new XElement("DefaultShop", item.DefaultShop.ToString()),
                    new XElement("isItemBought", item.isItemBought.ToString())
                    ));
            }

            string _fileName = "shoppingList.items.xml";
            string _filePath = Path.Combine(FileSystem.AppDataDirectory, _fileName);

            if (File.Exists(_filePath))
                File.Delete(_filePath);

            xDocument.Save(_filePath);

            Items.Clear();
            Debug.WriteLine("Dane aplikacji" + FileSystem.AppDataDirectory);
        }

        public void LoadItems()
        {
            Items.Clear();
            string _filename = "shoppingList.items.xml";

            if (!File.Exists(Path.Combine(FileSystem.AppDataDirectory, _filename)))
                return;

            XDocument xml = XDocument.Load(Path.Combine(FileSystem.AppDataDirectory, _filename));
            IEnumerable<XElement> tempList = xml.Descendants("Item");
            foreach (var el in tempList)
            {
                string elName = el.Descendants().ElementAt(0).Value;
                int elQuantity = Int32.Parse(el.Descendants().ElementAt(1).Value);
                string elQuantityUnit = el.Descendants().ElementAt(2).Value;
                string elDefaultShop = el.Descendants().ElementAt(3).Value;
                bool elIsBought = Boolean.Parse(el.Descendants().ElementAt(4).Value);

                Items.Add(new Item(elName, elQuantity, elQuantityUnit, elDefaultShop, elIsBought));
            }
        }
    }
}
