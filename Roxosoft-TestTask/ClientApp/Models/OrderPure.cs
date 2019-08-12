using System;

namespace ClientApp.Models
{
    /// <summary>
    /// Model that represents client's order
    /// </summary>
    class OrderPure
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
    }
}
