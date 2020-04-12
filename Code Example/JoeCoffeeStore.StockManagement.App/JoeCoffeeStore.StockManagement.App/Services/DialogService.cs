using JoeCoffeeStore.StockManagement.App.View;
using JoeCoffeeStore.StockManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JoeCoffeeStore.StockManagement.App.Services
{
    public class DialogService
    {

        Window coffeeDetailView = null;

        public DialogService()
        {
        }

        public void ShowDetailDialog()
        {
            coffeeDetailView = new CoffeeDetailView();
            coffeeDetailView.ShowDialog();
        }

        public void CloseDetailDialog()
        {
            if (coffeeDetailView != null)
                coffeeDetailView.Close();
        }
    }
}
