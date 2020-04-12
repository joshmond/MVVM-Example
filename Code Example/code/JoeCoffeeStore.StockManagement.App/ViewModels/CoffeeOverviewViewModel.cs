using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using JoeCoffeeStore.StockManagement.App.Annotations;
using JoeCoffeeStore.StockManagement.App.Commands;
using JoeCoffeeStore.StockManagement.App.Extensions;
using JoeCoffeeStore.StockManagement.App.Messages;
using JoeCoffeeStore.StockManagement.App.Services;
using JoeCoffeeStore.StockManagement.App.Utility;
using JoeCoffeeStore.StockManagement.Model;


namespace JoeCoffeeStore.StockManagement.App.ViewModels
{
    public class CoffeeOverviewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CoffeeDataService coffeeDataService;
        private DialogService dialogService;

        private ObservableCollection<Coffee> coffees;
        public ObservableCollection<Coffee> Coffees
        {
            get => coffees;
            set
            {
                coffees = value;
                RaisePropertyChanged();
            }
        }

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
        public ICommand EditCommand { get; set; }

        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CoffeeOverviewViewModel()
        {
            coffeeDataService = new CoffeeDataService();
            dialogService = new DialogService();
            LoadData();

            LoadCommands();

            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);
        }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditCoffee, CanEditCoffee);
        }

        private void OnUpdateListMessageReceived(UpdateListMessage obj)
        {
            LoadData();
            dialogService.CloseDetailDialog();
        }

         

        private void EditCoffee(object obj)
        {
            Messenger.Default.Send(selectedCoffee);
            Trace.WriteLine(selectedCoffee.CoffeeId);
            Trace.WriteLine(selectedCoffee.CoffeeName);
            Trace.WriteLine(selectedCoffee.Description);
            Trace.WriteLine(selectedCoffee.AmountInStock);
            Trace.WriteLine(selectedCoffee.IsInStock);
            Trace.WriteLine(selectedCoffee.Price);
            Trace.WriteLine(selectedCoffee.FirstAddedToStockDate);
            Trace.WriteLine(selectedCoffee.ImageId);
            dialogService.ShowDetailDialog();
        }

        private bool CanEditCoffee(object obj)
        {
            return SelectedCoffee != null;
        }

        private void LoadData()
        {
            Coffees = coffeeDataService.GetAllCoffees().ToObservableCollection();
        }

    }
}
