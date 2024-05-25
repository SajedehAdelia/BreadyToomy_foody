using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BreadyToomy_Foody.Models;

namespace BreadyToomy_Foody.ViewModels
{
    public class OrderManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged();
            }
        }

        private Order _selectedOrder;
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddOrderCommand { get; }
        public ICommand UpdateOrderCommand { get; }
        public ICommand DeleteOrderCommand { get; }

        public OrderManagementViewModel()
        {
            Orders = new ObservableCollection<Order>();
            SelectedOrder = new Order();

            AddOrderCommand = new Command(AddOrder);
            UpdateOrderCommand = new Command(UpdateOrder);
            DeleteOrderCommand = new Command(DeleteOrder);
        }

        private void AddOrder()
        {
            if (SelectedOrder != null)
            {
                Orders.Add(new Order
                {
                    Id = SelectedOrder.Id,
                    Number = SelectedOrder.Number,
                    Type = SelectedOrder.Type,
                    State = SelectedOrder.State
                });

                SelectedOrder = new Order();
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        private void UpdateOrder()
        {
            var existingOrder = Orders.FirstOrDefault(o => o.Id == SelectedOrder.Id);
            if (existingOrder != null)
            {
                existingOrder.Number = SelectedOrder.Number;
                existingOrder.Type = SelectedOrder.Type;
                existingOrder.State = SelectedOrder.State;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private void DeleteOrder()
        {
            var orderToDelete = Orders.FirstOrDefault(o => o.Id == SelectedOrder.Id);
            if (orderToDelete != null)
            {
                Orders.Remove(orderToDelete);
                SelectedOrder = new Order();
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
