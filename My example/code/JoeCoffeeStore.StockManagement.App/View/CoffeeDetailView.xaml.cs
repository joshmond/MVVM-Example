using JoeCoffeeStore.StockManagement.Model;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JoeCoffeeStore.StockManagement.App.View
{
    /// <summary>
    /// Interaction logic for CoffeeDetailView.xaml
    /// </summary>
    public partial class CoffeeDetailView : MetroWindow
    {
        public Coffee SelectedCoffee { get; set; }

        public CoffeeDetailView()
        {
            InitializeComponent();

            this.Loaded += CoffeeDetailView_Loaded;
        }

        void CoffeeDetailView_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadData();
            this.DataContext = SelectedCoffee;
        }

        //private void LoadData()
        //{
        //    CoffeeNameLabel.Content = SelectedCoffee.CoffeeName;
        //    CoffeeIdTextBox.Text = SelectedCoffee.CoffeeId.ToString();
        //    CoffeeDescriptionTextBox.Text = SelectedCoffee.Description;
        //    CoffeePriceTextBox.Text = SelectedCoffee.Price.ToString();
        //    StockAmountTextBox.Text = SelectedCoffee.AmountInStock.ToString();
        //    FirstTimeAddedTextBox.Text = SelectedCoffee.FirstAddedToStockDate.ToShortDateString();
        //    if (SelectedCoffee is SuperiorCoffee)
        //        ExtraDescriptionTextBox.Text = (SelectedCoffee as SuperiorCoffee).ExtraDescription;
        //    else
        //        ExtraDescriptionTextBox.Text = "NA";

        //    BitmapImage img = new BitmapImage();
        //    img.BeginInit();
        //    img.UriSource = new Uri("/JoeCoffeeStore.StockManagement.App;component/Images/coffee" + SelectedCoffee.CoffeeId + ".jpg", UriKind.Relative);
        //    img.EndInit();
        //    CoffeeImage.Source = img;
        //}

        private void DeleteCoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveCoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChangeCoffeeButton_OnClickCoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedCoffee.CoffeeName = "Something really expensive";
            SelectedCoffee.Price = 1000;
        }
    }
}
