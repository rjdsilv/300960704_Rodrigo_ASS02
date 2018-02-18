using _300960704_Rodrigo_ASS02.DataSources;
using System.Collections.ObjectModel;
using System.Windows;

namespace _300960704_Rodrigo_ASS02
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Collections to be bound to the combo boxes.
        private ObservableCollection<RestaurantItem> _beverages = new ObservableCollection<RestaurantItem>();
        private ObservableCollection<RestaurantItem> _appetizers = new ObservableCollection<RestaurantItem>();
        private ObservableCollection<RestaurantItem> _mainCourses = new ObservableCollection<RestaurantItem>();
        private ObservableCollection<RestaurantItem> _desserts = new ObservableCollection<RestaurantItem>();

        public ObservableCollection<RestaurantItem> Beverages
        {
            get
            {
                return _beverages;
            }

            set
            {
                _beverages = value;
            }
        }
        public ObservableCollection<RestaurantItem> Appetizers
        {
            get
            {
                return _appetizers;
            }

            set
            {
                _appetizers = value;
            }
        }
        public ObservableCollection<RestaurantItem> MainCourses
        {
            get
            {
                return _mainCourses;
            }

            set
            {
                _mainCourses = value;
            }
        }
        public ObservableCollection<RestaurantItem> Desserts
        {
            get
            {
                return _desserts;
            }

            set
            {
                _desserts = value;
            }
        }

        /// <summary>
        /// Application initialization method.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="args">The event arguments.</param>
        void AppStartup(object sender, StartupEventArgs args)
        {
            LoadRestaurantData();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        /// <summary>
        /// Initializes the combo boxes.
        /// </summary>
        void LoadRestaurantData()
        {
            // Load all the beverages.
            _beverages.Add(new RestaurantItem("Sprite", "Beverage", 1.95f));
            _beverages.Add(new RestaurantItem("Coca Cola", "Beverage", 1.95f));
            _beverages.Add(new RestaurantItem("Fanta", "Beverage", 1.95f));
            _beverages.Add(new RestaurantItem("Tea", "Beverage", 1.50f));
            _beverages.Add(new RestaurantItem("Coffee", "Beverage", 1.25f));
            _beverages.Add(new RestaurantItem("Hot Chocolate", "Beverage", 2.25f));
            _beverages.Add(new RestaurantItem("Mineral Water", "Beverage", 2.95f));
            _beverages.Add(new RestaurantItem("Juice", "Beverage", 2.50f));
            _beverages.Add(new RestaurantItem("Milk", "Beverage", 1.50f));

            // Load all the appetizers.
            _appetizers.Add(new RestaurantItem("Buffalo Wings", "Appetizers", 5.95f));
            _appetizers.Add(new RestaurantItem("Buffalo Fingers", "Appetizers", 6.50f));
            _appetizers.Add(new RestaurantItem("Potato Skins", "Appetizers", 8.25f));
            _appetizers.Add(new RestaurantItem("Spice Shrimp", "Appetizers", 8.95f));
            _appetizers.Add(new RestaurantItem("Fries'n Bacon", "Appetizers", 4.45f));

            // Load all the main courses.
            _mainCourses.Add(new RestaurantItem("Chicken Alfredo", "Main Course", 13.95f));
            _mainCourses.Add(new RestaurantItem("Chicken Picatta", "Main Course", 13.95f));
            _mainCourses.Add(new RestaurantItem("Turkey Club", "Main Course", 11.95f));
            _mainCourses.Add(new RestaurantItem("Lobster Pie", "Main Course", 19.95f));
            _mainCourses.Add(new RestaurantItem("Prime Rib", "Main Course", 20.95f));
            _mainCourses.Add(new RestaurantItem("Shrimp Scamp", "Main Course", 18.95f));
            _mainCourses.Add(new RestaurantItem("Turkey Dinner", "Main Course", 13.95f));
            _mainCourses.Add(new RestaurantItem("Stuffed Chicken", "Main Course", 14.95f));

            // Load all desserts.
            _desserts.Add(new RestaurantItem("Apple Pie", "Dessert", 5.95f));
            _desserts.Add(new RestaurantItem("Lemon Pie", "Dessert", 6.95f));
            _desserts.Add(new RestaurantItem("Tiramissu", "Dessert", 9.95f));
            _desserts.Add(new RestaurantItem("Papaya", "Dessert", 4.95f));
            _desserts.Add(new RestaurantItem("Ice Cream", "Dessert", 2.95f));
        }
    }
}
