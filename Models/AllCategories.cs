using System.Collections.ObjectModel;

namespace ListaZakupowa.Models
{
    public class AllCategories
    {
        private static ObservableCollection<Category> _categories { get; set; } = new ObservableCollection<Category>();

        public static ObservableCollection<Category> Categories 
        {
            get => _categories;
            set => _categories = value;
        }

        public static void AddCategory(Category category)
        {
            Categories.Add(category);
            FileHelper.SaveCategories(Categories.ToList());
        }

        public static void AddItem(Item newItem)
        {
            foreach (var category in Categories)
            {
                if (category.Name == newItem.ParentCategory)
                    category.Items.Add(newItem);
            }
            FileHelper.SaveCategories(Categories.ToList());
        }
    }
}
