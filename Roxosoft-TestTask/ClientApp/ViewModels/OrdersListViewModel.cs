using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using ClientApp.Models;

namespace ClientApp.ViewModels
{
    class OrdersListViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<OrderPure> Orders { get; set; }
        public OrderPure SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged();
            }
        }
        public OrdersListViewModel(IEnumerable<OrderPure> orders) => Orders = new ObservableCollection<OrderPure>(orders);

        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        
        private OrderPure _selectedOrder;
    }
}
