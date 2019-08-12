using ClientApp.Models;

using System;
using System.Linq;

namespace ClientApp.ViewModels
{
    class OrderDetailViewModel
    {
        public string Name => $"Order # {_order.Id}";
        public DateTimeOffset Created => _order.Created;
        public string Status => _order.Status.ToString();
        public double Total => Math.Round(_order.Products.Select(p => p.Price * p.Quantity).Sum(), 2);

        public OrderDetailViewModel(OrderDetailed order) => _order = order;

        private OrderDetailed _order;
    }
}
