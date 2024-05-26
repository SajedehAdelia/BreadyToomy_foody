using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BreadyToomy_Foody.Models;
using Microsoft.Maui.Controls;

namespace BreadyToomy_Foody.ViewModels
{
    public class OrderProductManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<OrderProduct> _orderProducts;
        public ObservableCollection<OrderProduct> OrderProducts
        {
            get => _orderProducts;
            set
            {
                _orderProducts = value;
                OnPropertyChanged();
            }
        }

        private OrderProduct _selectedOrderProduct;
        public OrderProduct SelectedOrderProduct
        {
            get => _selectedOrderProduct;
            set
            {
                _selectedOrderProduct = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddOrderProductCommand { get; }
        public ICommand UpdateOrderProductCommand { get; }
        public ICommand DeleteOrderProductCommand { get; }

        public OrderProductManagementViewModel()
        {

            OrderProducts = new ObservableCollection<OrderProduct>
            {
               //data
            };

            SelectedOrderProduct = new OrderProduct();

            AddOrderProductCommand = new Command(AddOrderProduct);
            UpdateOrderProductCommand = new Command(UpdateOrderProduct);
            DeleteOrderProductCommand = new Command(DeleteOrderProduct);
        }

        public void AddOrderProduct()
        {
            if (SelectedOrderProduct != null)
            {
                OrderProducts.Add(new OrderProduct
                {
                    OrderId = SelectedOrderProduct.OrderId,
                    ProductId = SelectedOrderProduct.ProductId,
                    Quantity = SelectedOrderProduct.Quantity,
                    Archived = SelectedOrderProduct.Archived
                });

                // Clear the selected order product after adding
                SelectedOrderProduct = new OrderProduct();
                OnPropertyChanged(nameof(SelectedOrderProduct));
            }
        }

        public void UpdateOrderProduct()
        {
            var existingOrderProduct = OrderProducts.FirstOrDefault(op => op.OrderId == SelectedOrderProduct.OrderId && op.ProductId == SelectedOrderProduct.ProductId);
            if (existingOrderProduct != null)
            {
                existingOrderProduct.Quantity = SelectedOrderProduct.Quantity;
                existingOrderProduct.Archived = SelectedOrderProduct.Archived;
                OnPropertyChanged(nameof(OrderProducts));
            }
        }

        public void DeleteOrderProduct()
        {
            var orderProductToDelete = OrderProducts.FirstOrDefault(op => op.OrderId == SelectedOrderProduct.OrderId && op.ProductId == SelectedOrderProduct.ProductId);
            if (orderProductToDelete != null)
            {
                OrderProducts.Remove(orderProductToDelete);
                // Clear the selected order product after deleting
                SelectedOrderProduct = new OrderProduct();
                OnPropertyChanged(nameof(SelectedOrderProduct));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
