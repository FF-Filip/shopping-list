using System.ComponentModel;

namespace ListaZakupowa
{
    public class Item : INotifyPropertyChanged
    {
        private string _name;
        private string _parentCategory;
        private double _quantity;
        private string _quantityUnit;
        private string _defaultShop;
        private bool _isItemBought;
        private bool _isItemNotBought;

        public string Name 
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string ParentCategory
        {
            get => _parentCategory;
            set
            {
                _parentCategory = value;
                OnPropertyChanged("ParentCategory");
            }
        }
        public double Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public string QuantityUnit
        {
            get => _quantityUnit;
            set
            {
                _quantityUnit = value;
                OnPropertyChanged("QuantityUnit");
            }
        }

        public string DefaultShop
        {
            get => _defaultShop;
            set
            {
                _defaultShop = value;
                OnPropertyChanged("DefaultShop");
            }
        }
        public bool IsItemBought
        {
            get => _isItemBought;
            set
            {
                _isItemBought = value;
                OnPropertyChanged("IsItemBought");
            }
        }

        public bool IsItemNotBought
        {
            get => _isItemNotBought;
            set
            {
                _isItemNotBought = value;
                OnPropertyChanged("IsItemNotBought");
            }
        }

        public Item(string Name, string ParentCategory, double Quantity, string QuantityUnit,
            string DefaultShop, bool IsItemBought = false)
        {
            this.Name = Name;
            this.ParentCategory = ParentCategory;
            this.Quantity = Quantity;
            this.QuantityUnit = QuantityUnit;
            this.DefaultShop = DefaultShop;
            this.IsItemBought = IsItemBought;
            this.IsItemNotBought = !IsItemBought;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
