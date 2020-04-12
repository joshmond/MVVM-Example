using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using JoeCoffeeStore.StockManagement.App.View;

namespace JoeCoffeeStore.StockManagement.App.Services
{
    public class DialogService
    {

        Window coffeeDetailView;

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
            coffeeDetailView?.Close();
        }
    }
}

