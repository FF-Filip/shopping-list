using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;

namespace ListaZakupowa.Models
{
    class AllCategories
    {
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();

        public AllCategories()
        {
            //SaveCategories();
        }

        public void AddCategory(Category category)
        {
            Categories.Add(category);
            SaveCategories(Categories.ToList());
        }

        public void AddItem(Item newItem)
        {
            foreach (var category in Categories)
            {
                if(category.Name == newItem.ParentCategory)
                    category.Items.Add(newItem);
            }
            SaveCategories(Categories.ToList());
        }

        public void SaveCategories(List<Category> categories)
        {
            /*

            Item test1 = new Item("Banan", "Żywność", 3, "kg", "Biedronka");
            Item test2 = new Item("Mleko", "Elektronika", 2, "l", "Lidl");

            ObservableCollection<Item> itemsTest = new ObservableCollection<Item>();
            itemsTest.Add(test1);
            itemsTest.Add(test2);
            Category cat1 = new Category("Spożywcze", itemsTest);
            Category cat2 = new Category("Elektronika", itemsTest);

            Categories.Add(cat1);
            Categories.Add(cat2);
            
            */

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
                    new XElement("isBought", item.isItemBought)
                    ))));
            }

            string _fileName = "shoppingList.items.xml";
            string _filePath = Path.Combine(FileSystem.AppDataDirectory, _fileName);

            if (File.Exists(_filePath))
                File.Delete(_filePath);

            xDocument.Save(_filePath);
            Debug.WriteLine("Dane aplikacji" + FileSystem.AppDataDirectory);
        }

        public void LoadCategories()
        {
            Categories.Clear();
            
            string _filename = "shoppingList.items.xml";
            XDocument xml = XDocument.Load(Path.Combine(FileSystem.AppDataDirectory, _filename));

            XElement xmlRoot = xml.Root;
            foreach (XElement el in xmlRoot.Elements())
            {
                string catName = el.Name.ToString();
                Debug.WriteLine(catName);
                Debug.WriteLine("");

                ObservableCollection<Item> tempItems = new ObservableCollection<Item>();

                foreach (XElement item in el.Elements())
                {
                    if(item == null)
                        continue;

                    string itemName = item.Element("Name").Value;
                    string itemCategory = item.Element("ParentCategory").Value;
                    int itemQuantity = Int32.Parse(item.Element("Quantity").Value);
                    string itemQuantityUnit = item.Element("QuantityUnit").Value;
                    string itemDefaultShop = item.Element("DefaultShop").Value;
                    bool itemIsBought = Boolean.Parse(item.Element("isBought").Value);

                    tempItems.Add(new Item(itemName, itemCategory, itemQuantity, itemQuantityUnit,
                        itemDefaultShop, itemIsBought));
                }

                Categories.Add(new Category(catName, tempItems));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
