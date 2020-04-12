using JoeCoffeeStore.StockManagement.App.Messages;
using JoeCoffeeStore.StockManagement.App.Services;
using JoeCoffeeStore.StockManagement.App.Utility;
using JoeCoffeeStore.StockManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JoeCoffeeStore.StockManagement.App.ViewModel
{
    public class CoffeeDetailViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CoffeeDataService coffeeDataService;


        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private Coffee selectedCoffee;
        public Coffee SelectedCoffee
        {
            get
            {
                return selectedCoffee;
            }
            set
            {
                selectedCoffee = value;
                RaisePropertyChanged("SelectedCoffee");
            }
        }

        public CoffeeDetailViewModel()
        {
            Messenger.Default.Register<Coffee>(this, OnCoffeeReceived);

            SaveCommand = new CustomCommand(SaveCoffee, CanSaveCoffee);
            DeleteCommand = new CustomCommand(DeleteCoffee, CanDeleteCoffee);

            coffeeDataService = new CoffeeDataService();
        }

        public void OnCoffeeReceived(Coffee coffee)
        {
            SelectedCoffee = coffee;
        }

        private bool CanDeleteCoffee(object obj)
        {
            return true;
        }

        private void DeleteCoffee(object coffee)
        {
            coffeeDataService.DeleteCoffee(selectedCoffee);

            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private bool CanSaveCoffee(object obj)
        {
            return true;
        }

        private void SaveCoffee(object coffee)
        {
            coffeeDataService.UpdateCoffee(selectedCoffee);
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }
    }
}
