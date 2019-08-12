using System;

using ClientApp.Models;

namespace ClientApp.ViewModels
{
    class ProductViewModel
    {
        public string Name => _product.Name;
        public int Qty => _product.Quantity;
        public double Price => Math.Round(_product.Price, 2);
        public double Total => Math.Round(_product.Quantity * _product.Price, 2);

        public ProductViewModel(Product product) => _product = product;

        private readonly Product _product;
    }
}
