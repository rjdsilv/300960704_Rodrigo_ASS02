

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _300960704_Rodrigo_ASS02.DataSources
{
    public class RestaurantItem : INotifyPropertyChanged
    {
        private float _price;
        private int _quantity;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public string Category { get; set; }

        public string Price
        {
            get
            {
                return _price.ToString("$0.00");
            }

            set
            {
                _price = float.Parse(value);
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }

            set
            {
                _quantity = value;
                NotifyPropertyChanged();
            }
        }

        public RestaurantItem(string name, string category, float price)
        {
            Name = name;
            Category = category;
            Price = price.ToString();
            Quantity = 0;
        }

        public RestaurantItem(string name, string category, float price, int quantity)
        {
            Name = name;
            Category = category;
            Price = price.ToString();
            Quantity = quantity;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
