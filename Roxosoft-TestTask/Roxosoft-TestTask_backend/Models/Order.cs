using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    /// <summary>
    /// Model that represents client's order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order creation date and time
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Status of order (in progress, active, etc.)
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Ordered products
        /// </summary>
        public ICollection<Product> Products { get; set; }
    }
}
