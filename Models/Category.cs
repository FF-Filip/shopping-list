using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ListaZakupowa.Models
{
    public class Category : INotifyPropertyChanged
    {
        private string _name;
        public ObservableCollection<Item> _items { get; set; } = new ObservableCollection<Item>();

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public ObservableCollection<Item> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public Category(string Name, ObservableCollection<Item> Items = null)
        {
            this.Name = Name;
            this.Items = Items;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
