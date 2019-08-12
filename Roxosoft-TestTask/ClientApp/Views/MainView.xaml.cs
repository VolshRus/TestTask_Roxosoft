using ClientApp.Models;
using ClientApp.Properties;
using ClientApp.Utils;
using ClientApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            //TODO: add Logging
            try
            {
                var orders = await _requestService.FromUrl(Settings.Default.GetOrdersListUrl)
                                                  .GetAsync<ICollection<OrderPure>>();

                ordersList.DataContext = new OrdersListViewModel(orders);
            }
            catch (Exception) { }
        }

        private IRequestService _requestService = new RequestService();

        private async void OrdersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                // TODO: addLogging
                try
                {
                    var order = e.AddedItems[0] as OrderPure;

                    var renewOrders = await _requestService.FromUrl(Settings.Default.GetOrdersListUrl)
                                                  .GetAsync<ICollection<OrderPure>>();
                    var orderDetail = await _requestService.FromUrl(Settings.Default.GetOrderDetailUrl)
                                                     .With("id", order.Id)
                                                     .GetAsync<OrderDetailed>();

                    var currentOrders = (ordersList.DataContext as OrdersListViewModel).Orders;
                    var oldOrders = currentOrders.Except(renewOrders).ToList();
                    var newOrders = renewOrders.Except(currentOrders).ToList();
                    if (oldOrders.Any() || newOrders.Any())
                    {
                        foreach (var difOrder in oldOrders)
                                currentOrders.Remove(difOrder);
                        foreach (var difOrder in newOrders)
                                currentOrders.Add(difOrder);
                    }
                    orderDetailed.DataContext = new OrderDetailViewModel(orderDetail);
                    productList.DataContext = new OrderDetailProductListViewModel(orderDetail);
                }
                catch (Exception) { }
            }
        }
    }
}
