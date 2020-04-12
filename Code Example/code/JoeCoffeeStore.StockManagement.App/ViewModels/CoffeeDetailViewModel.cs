using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using JoeCoffeeStore.StockManagement.App.Annotations;
using JoeCoffeeStore.StockManagement.App.Commands;
using JoeCoffeeStore.StockManagement.App.Messages;
using JoeCoffeeStore.StockManagement.App.Services;
using JoeCoffeeStore.StockManagement.App.Utility;
using JoeCoffeeStore.StockManagement.Model;

namespace JoeCoffeeStore.StockManagement.App.ViewModels
{
    public class CoffeeDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CoffeeDataService coffeeDataService;


        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private Coffee selectedCoffee;
        public Coffee SelectedCoffee
        {
            get => selectedCoffee;
            set
            {
                selectedCoffee = value;
                RaisePropertyChanged();
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

            Messenger.Default.Send(new UpdateListMessage());
        }

        private bool CanSaveCoffee(object obj)
        {
            return true;
        }

        private void SaveCoffee(object coffee)
        {
            coffeeDataService.UpdateCoffee(selectedCoffee);
            Messenger.Default.Send(new UpdateListMessage());
        }
    }
}
