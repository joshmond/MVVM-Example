using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoeCoffeeStore.StockManagement.App.ViewModels;

namespace JoeCoffeeStore.StockManagement.App
{
    public class ViewModelLocator
    {
        public static CoffeeDetailViewModel CoffeeDetailViewModel { get; } = new CoffeeDetailViewModel();

        public static CoffeeOverviewViewModel CoffeeOverviewViewModel { get; } = new CoffeeOverviewViewModel();
    }

}