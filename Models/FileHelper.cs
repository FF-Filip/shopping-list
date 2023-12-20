using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ListaZakupowa.Models
{
    internal class FileHelper
    {
        public static void SaveCategories(List<Category> categories)
        {
            XDocument xDocument = new XDocument();
            xDocument.Add(new XElement("Categories"));

            foreach (Category category in categories)
            {
                if (category.Items == null)
                {
                    xDocument.Element("Categories").Add(new XElement(category.Name));
                    continue;
                }

                xDocument.Element("Categories").Add(new XElement(category.Name,
                    category.Items.Select(item => new XElement("Item",
                    new XElement("Name", item.Name),
                    new XElement("ParentCategory", item.ParentCategory),
                    new XElement("Quantity", item.Quantity),
                    new XElement("QuantityUnit", item.QuantityUnit),
                    new XElement("DefaultShop", item.DefaultShop),
                    new XElement("isBought", item.IsItemBought)
                    ))));
            }

            string _fileName = "shoppingList.items.xml";
            string _filePath = Path.Combine(FileSystem.AppDataDirectory, _fileName);

            xDocument.Save(_filePath);
        }

        public static ObservableCollection<Category> LoadCategories()
        {
            ObservableCollection<Category> categories = new ObservableCollection<Category>();

            string _fileName = "shoppingList.items.xml";
            string _filePath = Path.Combine(FileSystem.AppDataDirectory, _fileName);
            Debug.WriteLine(_filePath);

            if (!File.Exists(_filePath))
                SaveCategories(categories.ToList());

            XDocument xml = XDocument.Load(_filePath);
            XElement xmlRoot = xml.Root;

            foreach (XElement el in xmlRoot.Elements())
            {
                string catName = el.Name.ToString();

                ObservableCollection<Item> tempItems = new ObservableCollection<Item>();
                foreach (XElement item in el.Elements())
                {
                    if (item == null)
                        continue;

                    NumberFormatInfo provider = new NumberFormatInfo();
                    provider.NumberDecimalSeparator = ".";
                    provider.NumberGroupSeparator = ",";

                    string itemName = item.Element("Name").Value;
                    string itemCategory = item.Element("ParentCategory").Value;
                    double itemQuantity = Convert.ToDouble(item.Element("Quantity").Value, provider);
                    string itemQuantityUnit = item.Element("QuantityUnit").Value;
                    string itemDefaultShop = item.Element("DefaultShop").Value;
                    bool itemIsBought = Boolean.Parse(item.Element("isBought").Value);

                    Debug.WriteLine("Odczytana wartość bool: " + itemIsBought);

                    tempItems.Add(new Item(itemName, itemCategory, itemQuantity, itemQuantityUnit,
                        itemDefaultShop, itemIsBought));
                }
                categories.Add(new Category(catName, tempItems));
            }
            return categories;
        }
    }
}
