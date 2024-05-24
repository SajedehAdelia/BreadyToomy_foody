using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        public ProductManagementViewModel()
        {
            Products = new ObservableCollection<Product>
            {
                //data
            };
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Recipe = product.Recipe;
                existingProduct.Type = product.Type;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                OnPropertyChanged(nameof(Products));
            }
        }

        public void DeleteProduct(Product product)
        {
            Products.Remove(product);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
