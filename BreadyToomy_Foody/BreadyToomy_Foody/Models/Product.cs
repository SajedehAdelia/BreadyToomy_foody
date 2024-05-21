using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BreadyToomy_Foody.Models
{
    public class Product : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private Recipe _recipe;
        public Recipe Recipe
        {
            get => _recipe;
            set
            {
                _recipe = value;
                OnPropertyChanged();
            }
        }

        private ProductType _type;
        public ProductType Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        private bool _archived;
        public bool Archived
        {
            get => _archived;
            set
            {
                _archived = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum ProductType
    {
        Meal,
        Drink,
        Snack
    }
}
