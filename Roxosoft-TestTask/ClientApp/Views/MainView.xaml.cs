using ClientApp.Models;
using ClientApp.Properties;
using ClientApp.Utils;
using ClientApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            
        }

        private async void OrdersList_Loaded(object sender, RoutedEventArgs e)
        {
            var orders = await _requestService.FromUrl(Settings.Default.GetOrdersListUrl)
                                              .GetAsync<ICollection<OrderPure>>();

            ordersList.DataContext = new OrdersListViewModel(orders); 
        }

        private IRequestService _requestService = new RequestService();

        private void OrdersList_Selected(object sender, RoutedEventArgs e)
        {

        }

        private async void OrdersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                var order = e.AddedItems[0] as OrderPure;

                var orderDetail = await _requestService.FromUrl(Settings.Default.GetOrderDetailUrl)
                                                 .With("id", order.Id)
                                                 .GetAsync<OrderDetailed>();

                orderDetailed.DataContext = new OrderDetailViewModel(orderDetail);
                productList.DataContext = new OrderDetailProductListViewModel(orderDetail);
            }
        }
    }
}
