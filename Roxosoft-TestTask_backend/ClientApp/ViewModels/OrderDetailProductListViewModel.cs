using ClientApp.Models;

using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ClientApp.ViewModels
{
    class OrderDetailProductListViewModel
    {
        public ObservableCollection<ProductViewModel> Products { get; set; }

        public int TotalQty => Products.Select(p => p.Qty).Sum();
        public double TotalPrice => Math.Round(Products.Select(p => p.Price).Sum(), 2);
        public double Total => Math.Round(Products.Select(p => p.Price * p.Qty).Sum(), 2);
        public OrderDetailProductListViewModel(OrderDetailed order)
        {
            var productsViewModelList = order.Products.Select(p => new ProductViewModel(p));
            Products = new ObservableCollection<ProductViewModel>(productsViewModelList);
        }
    }
}
