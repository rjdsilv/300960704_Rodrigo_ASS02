using _300960704_Rodrigo_ASS02.DataSources;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace _300960704_Rodrigo_ASS02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Collection View Sources to be bound in the applcation.
        // Using it due to the CompositeCollection being used in the combo boxes.
        private CollectionViewSource beverageDataView;
        private CollectionViewSource appetizerDataView;
        private CollectionViewSource mainCourseDataView;
        private CollectionViewSource dessertDataView;

        // Collection to be bound to the bill grid
        private ObservableCollection<RestaurantItem> bill = new ObservableCollection<RestaurantItem>();

        /// <summary>
        /// Initializes the main window and it's properties.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            beverageDataView = Resources["beverageDataView"] as CollectionViewSource;
            appetizerDataView = Resources["appetizerDataView"] as CollectionViewSource;
            mainCourseDataView = Resources["mainCourseDataView"] as CollectionViewSource;
            dessertDataView = Resources["dessertDataView"] as CollectionViewSource;
            BillGrid.ItemsSource = bill;
            CloseBillButton.IsEnabled = false;
        }

        /// <summary>
        /// Called when the beverage combo box is changed.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void BeverageComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            AddBillItem(sender as ComboBox, e.AddedItems);
        }

        /// <summary>
        /// Called when the apptizer combo box is changed.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AppetizerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddBillItem(sender as ComboBox, e.AddedItems);
        }

        /// <summary>
        /// Called when the main course combo box is changed.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MainCourseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddBillItem(sender as ComboBox, e.AddedItems);
        }

        /// <summary>
        /// Called when the dessert combo box is changed.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void DessertComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddBillItem(sender as ComboBox, e.AddedItems);
        }

        /// <summary>
        /// Closes the current bill and opens a new one.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void CloseBillButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show(this, "Are you sure you want to close the bill?", "Rodrigo's Restaurant Bill Calculator", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                MessageBox.Show(this, "Bill successfully closed.\n" +
                    $"\tSubtotal (No taxes)\t: {bill[bill.Count - 3].Price}\n" +
                    $"\tTaxes (HST 13%)\t\t: {bill[bill.Count - 2].Price}\n" +
                    $"\tTotal (Taxes Included)\t: {bill[bill.Count - 1].Price}\n",
                    "Rodrigo's Restaurant Bill Calculator - Bill Closed",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
                bill.Clear();
                bill.Add(new RestaurantItem("Subtotal (No taxes)", "", 0, 0));
                bill.Add(new RestaurantItem("Taxes (HST 13%)", "", 0, 0));
                bill.Add(new RestaurantItem("Total (Taxes included)", "", 0, 0));
                CloseBillButton.IsEnabled = true;
            }
        }

        /// <summary>
        /// Adds selected items to the bill.
        /// </summary>
        /// <param name="comboBox">The combo box where the item was selected from.</param>
        /// <param name="addedItems">The items that were added.</param>
        private void AddBillItem(ComboBox comboBox, IList addedItems)
        {
            RemoveBillTotals();
            AddNewItemToBill(comboBox, addedItems);
            CalculateBillTotal();
            
            comboBox.SelectedIndex = 0;
            if (null != CloseBillButton)
            {
                CloseBillButton.IsEnabled = true;
            }
        }

        /// <summary>
        /// Remove the subtotal, taxes, and total from the bill. It will be re-added later.
        /// </summary>
        private void RemoveBillTotals()
        {
            if (bill.Count > 2)
            {
                bill.RemoveAt(bill.Count - 3);
                bill.RemoveAt(bill.Count - 2);
                bill.RemoveAt(bill.Count - 1);
            }
        }

        /// <summary>
        /// Add the new selected item to the bill.
        /// </summary>
        /// <param name="comboBox">The combo box from where the item was selected.</param>
        /// <param name="addedItems">The items added.</param>
        private void AddNewItemToBill(ComboBox comboBox, IList addedItems)
        {
            if (comboBox.SelectedIndex != 0)
            {
                foreach (RestaurantItem item in addedItems)
                {
                    item.Quantity++;
                    if (!bill.Contains(item))
                    {
                        bill.Add(item);
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the total for the current bill.
        /// </summary>
        private void CalculateBillTotal()
        {
            float totalPrice = 0;
            int totalQuantity = 0;
            foreach (RestaurantItem item in bill)
            {
                totalPrice += float.Parse(item.Price.Substring(1)) * item.Quantity;
                totalQuantity += item.Quantity;
            }
            bill.Add(new RestaurantItem("Subtotal (No taxes)", "", totalPrice, totalQuantity));
            bill.Add(new RestaurantItem("Taxes (HST 13%)", "", totalPrice * 0.13f, totalQuantity));
            bill.Add(new RestaurantItem("Total (Taxes included)", "", totalPrice * 1.13f, totalQuantity));
        }
    }
}
