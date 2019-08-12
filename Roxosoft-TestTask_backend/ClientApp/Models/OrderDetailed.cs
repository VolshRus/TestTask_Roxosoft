using System;
using System.Collections.Generic;

namespace ClientApp.Models
{
    /// <summary>
    /// Model that represents client's order with detailed information and products list
    /// </summary>
    class OrderDetailed
    {
        /// <summary>
        /// Identifier 
        /// </summary>
        public int Id { get; set; }

        public string Name => $"Order # {Id}";
        /// <summary>
        /// Order creation date and time
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Status of order (in progress, active, etc.)
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// List of ordered products
        /// </summary>
        public IEnumerable<Product> Products { get; set; }
    }
}
