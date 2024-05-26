using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BreadyToomy_Foody.Models;

namespace BreadyToomy_Foody.ViewModels
{
    public class ProductManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddProductCommand { get; }
        public ICommand UpdateProductCommand { get; }
        public ICommand DeleteProductCommand { get; }

        public ProductManagementViewModel()
        {
            Products = new ObservableCollection<Product>();
            SelectedProduct = new Product();

            AddProductCommand = new Command(AddProduct);
            UpdateProductCommand = new Command(UpdateProduct);
            DeleteProductCommand = new Command(DeleteProduct);
        }

        private void AddProduct()
        {
            if (SelectedProduct != null)
            {
                Products.Add(new Product
                {
                    Id = SelectedProduct.Id,
                    Name = SelectedProduct.Name,
                    Type = SelectedProduct.Type,
                    Price = SelectedProduct.Price
                });

                SelectedProduct = new Product();
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private void UpdateProduct()
        {
            var existingProduct = Products.FirstOrDefault(p => p.Id == SelectedProduct.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = SelectedProduct.Name;
                existingProduct.Type = SelectedProduct.Type;
                existingProduct.Price = SelectedProduct.Price;
                OnPropertyChanged(nameof(Products));
            }
        }

        private void DeleteProduct()
        {
            var productToDelete = Products.FirstOrDefault(p => p.Id == SelectedProduct.Id);
            if (productToDelete != null)
            {
                Products.Remove(productToDelete);
                SelectedProduct = new Product();
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
