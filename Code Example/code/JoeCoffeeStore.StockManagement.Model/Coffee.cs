using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JoeCoffeeStore.StockManagement.Model
{
    public class Coffee : INotifyPropertyChanged
    {
        private int coffeeId;
        private int price;
        private string coffeeName;
        private string description;
        private Country originCountry;
        private DateTime firstAddedToStockDate;
        private bool isInStock;
        private int amountInStock;
        private int imageId;

        

        public int CoffeeId
        {
            get => coffeeId;

            set
            {
                coffeeId = value; 
                OnRaisePropertyChanged();
                
            }
        }

        public string CoffeeName
        {
            get => coffeeName;

            set 
            { 
                coffeeName = value; 
                OnRaisePropertyChanged();
            }
        }

        public int Price
        {
            get => price;
            set
            {
                price = value; 
                OnRaisePropertyChanged();
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value; 
                OnRaisePropertyChanged();
            }
        }

        public Country OriginCountry
        {
            get => originCountry;
            set
            {
                originCountry = value; 
                OnRaisePropertyChanged();
            }
        }

        public bool IsInStock
        {
            get => isInStock;
            set
            {
                isInStock = value; 
                OnRaisePropertyChanged();
            }
        }

        public int AmountInStock
        {
            get => amountInStock;
            set
            {
                amountInStock = value; 
                OnRaisePropertyChanged();
            }
        }

        public DateTime FirstAddedToStockDate
        {
            get => firstAddedToStockDate;
            set
            {
                firstAddedToStockDate = value; 
                OnRaisePropertyChanged();
            }
        }

        public int ImageId
        {
            get => imageId;
            set
            {
                imageId = value; 
                OnRaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnRaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
