using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BreadyToomy_Foody.Models;
using Microsoft.Maui.Controls;

namespace BreadyToomy_Foody.ViewModels
{
    public class ProductFoodManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ProductFood> _productFoods;
        public ObservableCollection<ProductFood> ProductFoods
        {
            get => _productFoods;
            set
            {
                _productFoods = value;
                OnPropertyChanged();
            }
        }

        private ProductFood _selectedProductFood;
        public ProductFood SelectedProductFood
        {
            get => _selectedProductFood;
            set
            {
                _selectedProductFood = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddProductFoodCommand { get; }
        public ICommand UpdateProductFoodCommand { get; }
        public ICommand DeleteProductFoodCommand { get; }

        public ProductFoodManagementViewModel()
        {
            ProductFoods = new ObservableCollection<ProductFood>();
            SelectedProductFood = new ProductFood();

            AddProductFoodCommand = new Command(AddProductFood);
            UpdateProductFoodCommand = new Command(UpdateProductFood);
            DeleteProductFoodCommand = new Command(DeleteProductFood);
        }

        private void AddProductFood()
        {
            if (SelectedProductFood != null)
            {
                ProductFoods.Add(new ProductFood
                {
                    ProductId = SelectedProductFood.ProductId,
                    FoodId = SelectedProductFood.FoodId,
                    Quantity = SelectedProductFood.Quantity,
                    Archived = SelectedProductFood.Archived
                });

                SelectedProductFood = new ProductFood();
                OnPropertyChanged(nameof(SelectedProductFood));
            }
        }

        private void UpdateProductFood()
        {
            var existingProductFood = ProductFoods.FirstOrDefault(pf => pf.ProductId == SelectedProductFood.ProductId && pf.FoodId == SelectedProductFood.FoodId);
            if (existingProductFood != null)
            {
                existingProductFood.Quantity = SelectedProductFood.Quantity;
                existingProductFood.Archived = SelectedProductFood.Archived;
                OnPropertyChanged(nameof(ProductFoods));
            }
        }

        private void DeleteProductFood()
        {
            var productFoodToDelete = ProductFoods.FirstOrDefault(pf => pf.ProductId == SelectedProductFood.ProductId && pf.FoodId == SelectedProductFood.FoodId);
            if (productFoodToDelete != null)
            {
                ProductFoods.Remove(productFoodToDelete);
                SelectedProductFood = new ProductFood();
                OnPropertyChanged(nameof(SelectedProductFood));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
