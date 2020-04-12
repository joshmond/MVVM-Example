using JoeCoffeeStore.StockManagement.App.Services;
using JoeCoffeeStore.StockManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoeCoffeeStore.StockManagement.App.Extensions;
using System.Windows.Input;
using JoeCoffeeStore.StockManagement.App.Utility;
using JoeCoffeeStore.StockManagement.App.Messages;

namespace JoeCoffeeStore.StockManagement.App.ViewModel
{
    public class CoffeeOverviewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CoffeeDataService coffeeDataService;

        private ObservableCollection<Coffee> coffees;
        public ObservableCollection<Coffee> Coffees
        {
            get
            {
                return coffees;
            }
            set
            {
                coffees = value;
                RaisePropertyChanged("Coffees");
            }
        }

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
        public ICommand EditCommand { get; set; }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public CoffeeOverviewViewModel()
        {
            coffeeDataService = new CoffeeDataService();
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
        
        private DialogService dialogService = new DialogService();

        private void EditCoffee(object obj)
        {
            Messenger.Default.Send<Coffee>(selectedCoffee);

            dialogService.ShowDetailDialog();
        }

        private bool CanEditCoffee(object obj)
        {
            if (SelectedCoffee != null)
                return true;
            return false;
        }

        private void LoadData()
        {
            Coffees = coffeeDataService.GetAllCoffees().ToObservableCollection();
        }

    }
}
