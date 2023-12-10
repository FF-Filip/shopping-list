using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaZakupowa.Models
{
    class AllCategories
    {
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();

        public AllCategories() => LoadCategories();

        public void LoadCategories()
        {
            Categories.Clear();

            Categories.Add(new Category("Żywność"));
            Categories.Add(new Category("Elektronika"));
        }
    }
}
